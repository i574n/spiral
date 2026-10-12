use rayon::ThreadPoolBuilder;
use rayon::prelude::*;
use spiral_split_gear_artifact_state::{
    ArtifactPreparation, ArtifactTarget, prepare_artifact_state, write_artifact_state,
};
use spiral_split_gear_executor::{GearUnit, load_gear_plan};
use spiral_split_gear_restore::{GearRestoreOptions, ensure_gear_restore_assets};
use std::fs;
use std::path::{Path, PathBuf};

const FNV_OFFSET: u64 = 0xcbf29ce484222325;
const FNV_PRIME: u64 = 0x100000001b3;

#[derive(Clone, Debug)]
pub struct GearHydrationOptions {
    pub source_root: PathBuf,
    pub output_root: PathBuf,
    pub dotnet: PathBuf,
    pub jobs: usize,
    pub through: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearHydrationReceipt {
    pub gears: usize,
    pub mismatched_gears: usize,
    pub copied_files: usize,
    pub restore_copied: usize,
    pub restore_reused: usize,
    pub receipt: PathBuf,
}

#[derive(Clone, Debug)]
struct ArtifactLayout {
    output_root: PathBuf,
    intermediate_root: PathBuf,
    assembly_name: String,
}

fn mix(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash ^= u64::from(*byte);
        hash = hash.wrapping_mul(FNV_PRIME);
    }
    hash
}

fn atomic_write(path: &Path, bytes: &[u8]) -> Result<(), String> {
    let parent = path
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, bytes)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn atomic_copy(source: &Path, destination: &Path) -> Result<(), String> {
    let parent = destination
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", destination.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = destination.with_extension(format!("tmp-{}", std::process::id()));
    fs::copy(source, &temporary).map_err(|error| {
        format!(
            "copy {} -> {}: {error}",
            source.display(),
            temporary.display()
        )
    })?;
    if destination.exists() {
        fs::remove_file(destination)
            .map_err(|error| format!("remove {}: {error}", destination.display()))?;
    }
    fs::rename(&temporary, destination)
        .map_err(|error| format!("commit {}: {error}", destination.display()))
}

fn property(text: &str, name: &str) -> Result<String, String> {
    let opening = format!("<{name}>");
    let closing = format!("</{name}>");
    let start = text
        .find(&opening)
        .ok_or_else(|| format!("Directory.Build.props is missing {opening}"))?
        + opening.len();
    let tail = &text[start..];
    let end = tail
        .find(&closing)
        .ok_or_else(|| format!("Directory.Build.props is missing {closing}"))?;
    Ok(tail[..end].trim().to_owned())
}

fn resolve(root: &Path, value: &str) -> PathBuf {
    let path = PathBuf::from(value);
    if path.is_absolute() {
        path
    } else {
        root.join(path)
    }
}

fn artifact_layout(root: &Path, target: ArtifactTarget) -> Result<ArtifactLayout, String> {
    let props_path = root.join("Directory.Build.props");
    let props = fs::read_to_string(&props_path)
        .map_err(|error| format!("read {}: {error}", props_path.display()))?;
    let project = target.project_name();
    let output = property(&props, "BaseOutputPath")?.replace("$(MSBuildProjectName)", &project);
    let intermediate =
        property(&props, "BaseIntermediateOutputPath")?.replace("$(MSBuildProjectName)", &project);
    let assembly_name = match target {
        ArtifactTarget::Gear { id } => format!("SpiralCompilerGear{id:04}.dll"),
        ArtifactTarget::Root => "SpiralCompilerGearRoot.dll".to_owned(),
    };
    Ok(ArtifactLayout {
        output_root: resolve(root, output.trim_end_matches(['/', '\\'])),
        intermediate_root: resolve(root, intermediate.trim_end_matches(['/', '\\'])),
        assembly_name,
    })
}

fn find_named(root: &Path, name: &str) -> Option<PathBuf> {
    let entries = fs::read_dir(root).ok()?;
    for entry in entries.flatten() {
        let path = entry.path();
        if path.is_file() && path.file_name().is_some_and(|file| file == name) {
            return Some(path);
        }
        if path.is_dir()
            && let Some(found) = find_named(&path, name)
        {
            return Some(found);
        }
    }
    None
}

fn find_named_under(root: &Path, name: &str, parent_name: &str) -> Option<PathBuf> {
    let entries = fs::read_dir(root).ok()?;
    for entry in entries.flatten() {
        let path = entry.path();
        if path.is_file()
            && path.file_name().is_some_and(|file| file == name)
            && path
                .parent()
                .and_then(Path::file_name)
                .is_some_and(|parent| parent == parent_name)
        {
            return Some(path);
        }
        if path.is_dir()
            && let Some(found) = find_named_under(&path, name, parent_name)
        {
            return Some(found);
        }
    }
    None
}

fn normalized_props(text: &str) -> Result<String, String> {
    let mut result = text.to_owned();
    for name in ["BaseOutputPath", "BaseIntermediateOutputPath"] {
        let opening = format!("<{name}>");
        let closing = format!("</{name}>");
        let start = result
            .find(&opening)
            .ok_or_else(|| format!("Directory.Build.props is missing {opening}"))?
            + opening.len();
        let end = result[start..]
            .find(&closing)
            .ok_or_else(|| format!("Directory.Build.props is missing {closing}"))?
            + start;
        result.replace_range(start..end, "<identity-cache-path>");
    }
    Ok(result)
}

fn portable_identity(root: &Path, configuration: &str, unit: &GearUnit) -> Result<u64, String> {
    let mut hash = mix(
        FNV_OFFSET,
        format!(
            "gear={}\nlayer={}\nsource={}\ndependencies={:?}\nconfiguration={}\n",
            unit.id, unit.layer, unit.source_fingerprint, unit.dependencies, configuration
        )
        .as_bytes(),
    );
    for path in &unit.inputs {
        let relative = path.strip_prefix(root).map_err(|error| {
            format!(
                "portable identity input {} is outside {}: {error}",
                path.display(),
                root.display()
            )
        })?;
        hash = mix(hash, relative.to_string_lossy().as_bytes());
        hash = mix(hash, b"\0");
        let bytes = if relative
            .file_name()
            .is_some_and(|name| name == "Directory.Build.props")
        {
            normalized_props(
                &fs::read_to_string(path)
                    .map_err(|error| format!("read {}: {error}", path.display()))?,
            )?
            .into_bytes()
        } else {
            fs::read(path).map_err(|error| format!("read {}: {error}", path.display()))?
        };
        hash = mix(hash, &bytes);
        hash = mix(hash, b"\xff");
    }
    Ok(hash)
}

fn copy_relative(source: &Path, source_root: &Path, destination_root: &Path) -> Result<(), String> {
    let relative = source.strip_prefix(source_root).map_err(|error| {
        format!(
            "artifact {} is outside {}: {error}",
            source.display(),
            source_root.display()
        )
    })?;
    atomic_copy(source, &destination_root.join(relative))
}

fn hydrate_one(
    source_root: &Path,
    output_root: &Path,
    source_unit: &GearUnit,
    output_unit: &GearUnit,
) -> Result<usize, String> {
    let target = ArtifactTarget::Gear { id: output_unit.id };
    if !matches!(
        prepare_artifact_state(source_root, target, source_unit.artifact_fingerprint)?,
        ArtifactPreparation::Current | ArtifactPreparation::Hydrated
    ) {
        return Err(format!(
            "Gear{:04} source artifact is not certified for fingerprint {}",
            output_unit.id, source_unit.artifact_fingerprint
        ));
    }
    let source = artifact_layout(source_root, target)?;
    let destination = artifact_layout(output_root, target)?;
    let assets = destination.intermediate_root.join("project.assets.json");
    if !fs::metadata(&assets)
        .map(|metadata| metadata.len() > 0)
        .unwrap_or(false)
    {
        return Err(format!(
            "Gear{:04} destination restore assets are missing: {}",
            output_unit.id,
            assets.display()
        ));
    }

    let runtime = find_named(&source.output_root, &source.assembly_name).ok_or_else(|| {
        format!(
            "Gear{:04} source runtime assembly is missing",
            output_unit.id
        )
    })?;
    let reference = find_named_under(&source.intermediate_root, &source.assembly_name, "ref")
        .ok_or_else(|| {
            format!(
                "Gear{:04} source reference assembly is missing",
                output_unit.id
            )
        })?;
    copy_relative(&runtime, &source.output_root, &destination.output_root)?;
    copy_relative(
        &reference,
        &source.intermediate_root,
        &destination.intermediate_root,
    )?;
    let mut copied = 2usize;
    if let Some(reference_intermediate) =
        find_named_under(&source.intermediate_root, &source.assembly_name, "refint")
    {
        copy_relative(
            &reference_intermediate,
            &source.intermediate_root,
            &destination.intermediate_root,
        )?;
        copied += 1;
    }
    write_artifact_state(output_root, target, output_unit.artifact_fingerprint)?;
    if !matches!(
        prepare_artifact_state(output_root, target, output_unit.artifact_fingerprint)?,
        ArtifactPreparation::Current
    ) {
        return Err(format!(
            "Gear{:04} cross-output hydration did not become current",
            output_unit.id
        ));
    }
    Ok(copied)
}

pub fn hydrate_matching_gears(
    options: &GearHydrationOptions,
) -> Result<GearHydrationReceipt, String> {
    if options.jobs == 0 {
        return Err("gear hydration jobs must be greater than zero".to_owned());
    }
    let restore = ensure_gear_restore_assets(&GearRestoreOptions {
        output_root: options.output_root.clone(),
        dotnet: options.dotnet.clone(),
        jobs: options.jobs,
    })?;
    let source =
        load_gear_plan(&options.source_root, "Release", Some(options.through))?.validate()?;
    let output =
        load_gear_plan(&options.output_root, "Release", Some(options.through))?.validate()?;
    let source_by_id = source
        .units
        .iter()
        .map(|unit| (unit.id, unit))
        .collect::<std::collections::BTreeMap<_, _>>();
    let mut matching_pairs = Vec::new();
    let mut mismatched_gears = 0usize;
    for output_unit in &output.units {
        let Some(source_unit) = source_by_id.get(&output_unit.id).copied() else {
            mismatched_gears += 1;
            continue;
        };
        let source_identity =
            portable_identity(&source.output_root, &source.configuration, source_unit)?;
        let output_identity =
            portable_identity(&output.output_root, &output.configuration, output_unit)?;
        if source_identity == output_identity {
            matching_pairs.push((source_unit, output_unit));
        } else {
            mismatched_gears += 1;
        }
    }

    let pool = ThreadPoolBuilder::new()
        .num_threads(options.jobs)
        .build()
        .map_err(|error| format!("create gear hydration thread pool: {error}"))?;
    let copied = pool.install(|| {
        matching_pairs
            .par_iter()
            .map(|(source_unit, output_unit)| {
                hydrate_one(
                    &options.source_root,
                    &options.output_root,
                    source_unit,
                    output_unit,
                )
            })
            .collect::<Result<Vec<_>, _>>()
    })?;
    let copied_files = copied.iter().sum::<usize>();
    let receipt = options.output_root.join("gear-hydration.receipt.tsv");
    let text = format!(
        "key\tvalue\nstatus\tpass\nsource_root\t{}\noutput_root\t{}\nthrough\t{}\ngears\t{}\nmismatched_gears\t{}\ncopied_files\t{}\nrestore_copied\t{}\nrestore_reused\t{}\nidentity\tportable-source+project+dependencies+normalized-build-policy\nartifacts\tbin+obj/ref+optional-obj/refint\nassets\tdestination-local-project.assets.json\n",
        options.source_root.display(),
        options.output_root.display(),
        options.through,
        matching_pairs.len(),
        mismatched_gears,
        copied_files,
        restore.copied,
        restore.reused,
    );
    atomic_write(&receipt, text.as_bytes())?;
    Ok(GearHydrationReceipt {
        gears: matching_pairs.len(),
        mismatched_gears,
        copied_files,
        restore_copied: restore.copied,
        restore_reused: restore.reused,
        receipt,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn normalizes_only_identity_scoped_cache_paths() {
        let first = "<Project><PropertyGroup><BaseOutputPath>/a/bin/$(MSBuildProjectName)/</BaseOutputPath><BaseIntermediateOutputPath>/a/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath><Optimize>false</Optimize></PropertyGroup></Project>";
        let second = "<Project><PropertyGroup><BaseOutputPath>/b/bin/$(MSBuildProjectName)/</BaseOutputPath><BaseIntermediateOutputPath>/b/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath><Optimize>false</Optimize></PropertyGroup></Project>";
        assert_eq!(
            normalized_props(first).unwrap(),
            normalized_props(second).unwrap()
        );
        let changed = second.replace("<Optimize>false</Optimize>", "<Optimize>true</Optimize>");
        assert_ne!(
            normalized_props(first).unwrap(),
            normalized_props(&changed).unwrap()
        );
    }
}
