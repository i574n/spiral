use std::fs;
use std::path::{Component, Path, PathBuf};

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ArtifactTarget {
    Gear { id: usize },
    Root,
}

impl ArtifactTarget {
    pub fn project_name(self) -> String {
        match self {
            Self::Gear { id } => format!("Gear{id:04}"),
            Self::Root => "GearRoot".to_owned(),
        }
    }

    fn assembly_name(self) -> String {
        match self {
            Self::Gear { id } => format!("SpiralCompilerGear{id:04}.dll"),
            Self::Root => "SpiralCompilerGearRoot.dll".to_owned(),
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ArtifactPreparation {
    Current,
    Hydrated,
    Stale,
    Missing,
}

#[derive(Clone, Debug)]
struct ArtifactLayout {
    project_root: PathBuf,
    intermediate_root: PathBuf,
    history_root: PathBuf,
    assembly_name: String,
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
    let value = tail[..end].trim();
    if value.is_empty() {
        return Err(format!("Directory.Build.props contains an empty {name}"));
    }
    Ok(value.to_owned())
}

fn resolve(output_root: &Path, raw: &str) -> PathBuf {
    let path = PathBuf::from(raw);
    if path.is_absolute() {
        path
    } else {
        output_root.join(path)
    }
}

fn layout(output_root: &Path, target: ArtifactTarget) -> Result<ArtifactLayout, String> {
    let props = output_root.join("Directory.Build.props");
    let text =
        fs::read_to_string(&props).map_err(|error| format!("read {}: {error}", props.display()))?;
    let raw = property(&text, "BaseOutputPath")?;
    let intermediate_raw = property(&text, "BaseIntermediateOutputPath")?;
    let project_name = target.project_name();
    let rendered = raw.replace("$(MSBuildProjectName)", &project_name);
    let intermediate_rendered = intermediate_raw.replace("$(MSBuildProjectName)", &project_name);
    let project_root = resolve(output_root, rendered.trim_end_matches(['/', '\\']));
    let intermediate_root = resolve(
        output_root,
        intermediate_rendered.trim_end_matches(['/', '\\']),
    );
    let prefix_raw = raw
        .split("$(MSBuildProjectName)")
        .next()
        .unwrap_or(&raw)
        .trim_end_matches(['/', '\\']);
    let prefix = resolve(output_root, prefix_raw);
    let cache_root = if prefix.file_name().is_some_and(|name| name == "bin") {
        prefix
            .parent()
            .map(Path::to_path_buf)
            .ok_or_else(|| format!("output cache prefix has no parent: {}", prefix.display()))?
    } else {
        prefix
    };
    Ok(ArtifactLayout {
        project_root,
        intermediate_root,
        history_root: cache_root.join("artifact-history").join(project_name),
        assembly_name: target.assembly_name(),
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

fn reference_artifact(layout: &ArtifactLayout) -> Option<PathBuf> {
    find_named_under(&layout.intermediate_root, &layout.assembly_name, "ref")
}

fn restore_assets_ready(layout: &ArtifactLayout) -> bool {
    fs::metadata(layout.intermediate_root.join("project.assets.json"))
        .map(|metadata| metadata.len() > 0)
        .unwrap_or(false)
}

fn consumable_artifacts_present(layout: &ArtifactLayout) -> bool {
    current_artifact(layout).is_some()
        && reference_artifact(layout).is_some()
        && restore_assets_ready(layout)
}

const FNV_OFFSET: u64 = 0xcbf29ce484222325;
const FNV_PRIME: u64 = 0x100000001b3;

fn artifact_hash(path: &Path) -> Result<u64, String> {
    let bytes =
        fs::read(path).map_err(|error| format!("read artifact {}: {error}", path.display()))?;
    Ok(bytes.into_iter().fold(FNV_OFFSET, |mut hash, byte| {
        hash ^= u64::from(byte);
        hash.wrapping_mul(FNV_PRIME)
    }))
}

fn current_artifact(layout: &ArtifactLayout) -> Option<PathBuf> {
    find_named(&layout.project_root, &layout.assembly_name)
}

fn state_path(output_root: &Path, target: ArtifactTarget) -> PathBuf {
    output_root
        .join(".gear-build/state")
        .join(format!("{}.tsv", target.project_name()))
}

fn read_state(output_root: &Path, target: ArtifactTarget) -> Option<(u64, Option<u64>)> {
    let text = fs::read_to_string(state_path(output_root, target)).ok()?;
    let fingerprint = text.lines().find_map(|line| {
        let (key, value) = line.split_once('\t')?;
        (key == "fingerprint")
            .then(|| value.parse::<u64>().ok())
            .flatten()
    })?;
    let artifact = text.lines().find_map(|line| {
        let (key, value) = line.split_once('\t')?;
        (key == "artifact_fingerprint")
            .then(|| value.parse::<u64>().ok())
            .flatten()
    });
    Some((fingerprint, artifact))
}

pub fn read_state_fingerprint(output_root: &Path, target: ArtifactTarget) -> Option<u64> {
    read_state(output_root, target).map(|state| state.0)
}

fn read_state_artifact_fingerprint(output_root: &Path, target: ArtifactTarget) -> Option<u64> {
    read_state(output_root, target).and_then(|state| state.1)
}

pub fn state_matches(output_root: &Path, target: ArtifactTarget, fingerprint: u64) -> bool {
    read_state_fingerprint(output_root, target) == Some(fingerprint)
}

pub fn write_artifact_state(
    output_root: &Path,
    target: ArtifactTarget,
    fingerprint: u64,
) -> Result<(), String> {
    let layout = layout(output_root, target)?;
    let artifact = current_artifact(&layout)
        .ok_or_else(|| format!("{} artifact is missing", target.project_name()))?;
    let artifact_fingerprint = artifact_hash(&artifact)?;
    atomic_write(
        &state_path(output_root, target),
        format!("fingerprint\t{fingerprint}\nartifact_fingerprint\t{artifact_fingerprint}\n")
            .as_bytes(),
    )
}

pub fn artifact_exists(output_root: &Path, target: ArtifactTarget) -> bool {
    layout(output_root, target)
        .ok()
        .and_then(|layout| find_named(&layout.project_root, &layout.assembly_name))
        .is_some()
}

fn safe_relative(path: &Path) -> bool {
    !path.is_absolute()
        && path
            .components()
            .all(|component| matches!(component, Component::Normal(_) | Component::CurDir))
}

fn history_dir(layout: &ArtifactLayout, fingerprint: u64) -> PathBuf {
    layout.history_root.join(fingerprint.to_string())
}

fn persist_fingerprint(layout: &ArtifactLayout, fingerprint: u64) -> Result<bool, String> {
    let Some(current) = current_artifact(layout) else {
        return Ok(false);
    };
    let relative = current
        .strip_prefix(&layout.project_root)
        .map_err(|error| {
            format!(
                "artifact {} is outside project root {}: {error}",
                current.display(),
                layout.project_root.display()
            )
        })?;
    let destination_root = history_dir(layout, fingerprint);
    let destination = destination_root.join(&layout.assembly_name);
    let current_hash = artifact_hash(&current)?;
    let destination_matches =
        destination.is_file() && artifact_hash(&destination).ok() == Some(current_hash);
    if !destination_matches {
        atomic_copy(&current, &destination)?;
    }
    atomic_write(
        &destination_root.join("relative-path.txt"),
        relative.to_string_lossy().as_bytes(),
    )?;
    atomic_write(
        &destination_root.join("artifact-fingerprint.txt"),
        current_hash.to_string().as_bytes(),
    )?;
    Ok(true)
}

fn hydrate_fingerprint(layout: &ArtifactLayout, fingerprint: u64) -> Result<bool, String> {
    let source_root = history_dir(layout, fingerprint);
    let source = source_root.join(&layout.assembly_name);
    let expected = fs::read_to_string(source_root.join("artifact-fingerprint.txt"))
        .ok()
        .and_then(|value| value.trim().parse::<u64>().ok());
    if !source.is_file() || expected.is_none() {
        return Ok(false);
    }
    let actual = artifact_hash(&source)?;
    if expected != Some(actual) {
        return Err(format!(
            "cached artifact hash mismatch for {} fingerprint {fingerprint}",
            layout.assembly_name
        ));
    }
    let relative_text = fs::read_to_string(source_root.join("relative-path.txt"))
        .map_err(|error| format!("read cached relative path: {error}"))?;
    let relative = PathBuf::from(relative_text.trim());
    if !safe_relative(&relative) {
        return Err(format!(
            "unsafe cached artifact path: {}",
            relative.display()
        ));
    }
    atomic_copy(&source, &layout.project_root.join(relative))?;
    Ok(true)
}

fn copy_relative_artifact(
    source: &Path,
    source_root: &Path,
    destination_root: &Path,
) -> Result<(), String> {
    let relative = source.strip_prefix(source_root).map_err(|error| {
        format!(
            "artifact {} is outside generation root {}: {error}",
            source.display(),
            source_root.display()
        )
    })?;
    atomic_copy(source, &destination_root.join(relative))
}

fn hydrate_sibling_generation(
    layout: &ArtifactLayout,
    expected_artifact_hash: u64,
) -> Result<bool, String> {
    if !restore_assets_ready(layout) {
        return Ok(false);
    }
    let Some(output_prefix) = layout.project_root.parent() else {
        return Ok(false);
    };
    let Some(intermediate_prefix) = layout.intermediate_root.parent() else {
        return Ok(false);
    };
    let Some(generation_root) = output_prefix.parent() else {
        return Ok(false);
    };
    if intermediate_prefix.parent() != Some(generation_root) {
        return Ok(false);
    }
    let Some(family_root) = generation_root.parent() else {
        return Ok(false);
    };
    let output_relative = layout
        .project_root
        .strip_prefix(generation_root)
        .map_err(|error| {
            format!(
                "output project root {} is outside cache generation {}: {error}",
                layout.project_root.display(),
                generation_root.display()
            )
        })?;
    let intermediate_relative = layout
        .intermediate_root
        .strip_prefix(generation_root)
        .map_err(|error| {
            format!(
                "intermediate project root {} is outside cache generation {}: {error}",
                layout.intermediate_root.display(),
                generation_root.display()
            )
        })?;
    let entries = match fs::read_dir(family_root) {
        Ok(entries) => entries,
        Err(_) => return Ok(false),
    };
    for entry in entries.flatten() {
        let candidate_generation = entry.path();
        if candidate_generation == generation_root || !candidate_generation.is_dir() {
            continue;
        }
        let candidate_output = candidate_generation.join(output_relative);
        let candidate_intermediate = candidate_generation.join(intermediate_relative);
        let Some(runtime) = find_named(&candidate_output, &layout.assembly_name) else {
            continue;
        };
        if artifact_hash(&runtime)? != expected_artifact_hash {
            continue;
        }
        let Some(reference) =
            find_named_under(&candidate_intermediate, &layout.assembly_name, "ref")
        else {
            continue;
        };
        copy_relative_artifact(&runtime, &candidate_output, &layout.project_root)?;
        copy_relative_artifact(
            &reference,
            &candidate_intermediate,
            &layout.intermediate_root,
        )?;
        if let Some(reference_intermediate) =
            find_named_under(&candidate_intermediate, &layout.assembly_name, "refint")
        {
            copy_relative_artifact(
                &reference_intermediate,
                &candidate_intermediate,
                &layout.intermediate_root,
            )?;
        }
        return Ok(true);
    }
    Ok(false)
}

pub fn prepare_artifact_state(
    output_root: &Path,
    target: ArtifactTarget,
    desired_fingerprint: u64,
) -> Result<ArtifactPreparation, String> {
    let layout = layout(output_root, target)?;
    let current_fingerprint = read_state_fingerprint(output_root, target);
    let current = current_artifact(&layout);
    if current_fingerprint == Some(desired_fingerprint)
        && let Some(path) = current.as_ref()
        && read_state_artifact_fingerprint(output_root, target) == Some(artifact_hash(path)?)
        && consumable_artifacts_present(&layout)
    {
        return Ok(ArtifactPreparation::Current);
    }
    if current_fingerprint == Some(desired_fingerprint)
        && let Some(expected_artifact_hash) = read_state_artifact_fingerprint(output_root, target)
        && hydrate_sibling_generation(&layout, expected_artifact_hash)?
        && consumable_artifacts_present(&layout)
    {
        write_artifact_state(output_root, target, desired_fingerprint)?;
        return Ok(ArtifactPreparation::Hydrated);
    }
    if let (Some(current_fingerprint), Some(path)) = (current_fingerprint, current.as_ref())
        && read_state_artifact_fingerprint(output_root, target) == Some(artifact_hash(path)?)
    {
        persist_fingerprint(&layout, current_fingerprint)?;
    }
    if hydrate_fingerprint(&layout, desired_fingerprint)? && consumable_artifacts_present(&layout) {
        write_artifact_state(output_root, target, desired_fingerprint)?;
        return Ok(ArtifactPreparation::Hydrated);
    }
    Ok(if current.is_some() {
        ArtifactPreparation::Stale
    } else {
        ArtifactPreparation::Missing
    })
}

pub fn commit_cached_artifact_state(
    output_root: &Path,
    target: ArtifactTarget,
    fingerprint: u64,
) -> Result<(), String> {
    let layout = layout(output_root, target)?;
    if !persist_fingerprint(&layout, fingerprint)? {
        return Err(format!(
            "{} build succeeded without producing {}",
            target.project_name(),
            layout.assembly_name
        ));
    }
    write_artifact_state(output_root, target, fingerprint)
}

#[cfg(test)]
mod tests {
    use super::*;

    fn fixture(name: &str, target: ArtifactTarget) -> (PathBuf, PathBuf) {
        let root = std::env::temp_dir().join(format!(
            "spiral-gear-artifact-state-{name}-{}",
            std::process::id()
        ));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        fs::write(
            root.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseOutputPath>{}/cache/bin/$(MSBuildProjectName)/</BaseOutputPath><BaseIntermediateOutputPath>{}/cache/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath></PropertyGroup></Project>",
                root.display(),
                root.display()
            ),
        )
        .unwrap();
        let project = target.project_name();
        let assembly_name = target.assembly_name();
        let assembly = root
            .join("cache/bin")
            .join(&project)
            .join("linux/amd64/Release/net11.0")
            .join(&assembly_name);
        let reference = root
            .join("cache/obj")
            .join(&project)
            .join("linux/amd64/Release/net11.0/ref")
            .join(&assembly_name);
        let assets = root
            .join("cache/obj")
            .join(&project)
            .join("project.assets.json");
        fs::create_dir_all(assembly.parent().unwrap()).unwrap();
        fs::create_dir_all(reference.parent().unwrap()).unwrap();
        fs::create_dir_all(assets.parent().unwrap()).unwrap();
        fs::write(reference, b"reference").unwrap();
        fs::write(assets, b"assets").unwrap();
        (root, assembly)
    }

    #[test]
    fn hydrates_a_previous_fingerprint_after_round_trip() {
        let target = ArtifactTarget::Gear { id: 7 };
        let (root, assembly) = fixture("round-trip", target);
        fs::write(&assembly, b"original").unwrap();
        write_artifact_state(&root, target, 11).unwrap();

        assert_eq!(
            prepare_artifact_state(&root, target, 22).unwrap(),
            ArtifactPreparation::Stale
        );
        fs::write(&assembly, b"changed").unwrap();
        commit_cached_artifact_state(&root, target, 22).unwrap();

        assert_eq!(
            prepare_artifact_state(&root, target, 11).unwrap(),
            ArtifactPreparation::Hydrated
        );
        assert_eq!(fs::read(&assembly).unwrap(), b"original");
        assert!(state_matches(&root, target, 11));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn root_uses_the_same_content_addressed_relation() {
        let target = ArtifactTarget::Root;
        let (root, assembly) = fixture("root", target);
        fs::write(&assembly, b"root").unwrap();
        commit_cached_artifact_state(&root, target, 99).unwrap();
        assert_eq!(
            prepare_artifact_state(&root, target, 99).unwrap(),
            ArtifactPreparation::Current
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn missing_reference_assembly_is_not_fresh() {
        let target = ArtifactTarget::Gear { id: 5 };
        let (root, assembly) = fixture("missing-reference", target);
        fs::write(&assembly, b"runtime").unwrap();
        write_artifact_state(&root, target, 55).unwrap();
        let artifact_layout = layout(&root, target).unwrap();
        let reference = reference_artifact(&artifact_layout).unwrap();
        fs::remove_file(reference).unwrap();
        assert_eq!(
            prepare_artifact_state(&root, target, 55).unwrap(),
            ArtifactPreparation::Stale
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn external_overwrite_is_rehydrated_from_verified_history() {
        let target = ArtifactTarget::Gear { id: 3 };
        let (root, assembly) = fixture("overwrite", target);
        fs::write(&assembly, b"trusted").unwrap();
        commit_cached_artifact_state(&root, target, 77).unwrap();
        fs::write(&assembly, b"overwritten-by-other-root").unwrap();
        assert_eq!(
            prepare_artifact_state(&root, target, 77).unwrap(),
            ArtifactPreparation::Hydrated
        );
        assert_eq!(fs::read(&assembly).unwrap(), b"trusted");
        assert!(state_matches(&root, target, 77));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn cache_generation_shift_reuses_same_input_fingerprint() {
        let target = ArtifactTarget::Gear { id: 7 };
        let (root, assembly) = fixture("generation-shift", target);
        fs::write(&assembly, b"trusted-generation").unwrap();
        commit_cached_artifact_state(&root, target, 77).unwrap();
        fs::write(
            root.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseOutputPath>{}/cache-next/bin/$(MSBuildProjectName)/</BaseOutputPath><BaseIntermediateOutputPath>{}/cache-next/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath></PropertyGroup></Project>",
                root.display(),
                root.display()
            ),
        )
        .unwrap();
        let next_assets = root.join("cache-next/obj/Gear0007/project.assets.json");
        fs::create_dir_all(next_assets.parent().unwrap()).unwrap();
        fs::write(&next_assets, b"destination-local-assets").unwrap();

        assert_eq!(
            prepare_artifact_state(&root, target, 77).unwrap(),
            ArtifactPreparation::Hydrated
        );
        let next_layout = layout(&root, target).unwrap();
        let runtime = current_artifact(&next_layout).unwrap();
        let reference = reference_artifact(&next_layout).unwrap();
        assert_eq!(fs::read(runtime).unwrap(), b"trusted-generation");
        assert_eq!(fs::read(reference).unwrap(), b"reference");
        assert!(state_matches(&root, target, 77));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn cache_generation_shift_rejects_changed_input_fingerprint() {
        let target = ArtifactTarget::Gear { id: 7 };
        let (root, assembly) = fixture("generation-change", target);
        fs::write(&assembly, b"trusted-generation").unwrap();
        commit_cached_artifact_state(&root, target, 77).unwrap();
        fs::write(
            root.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseOutputPath>{}/cache-next/bin/$(MSBuildProjectName)/</BaseOutputPath><BaseIntermediateOutputPath>{}/cache-next/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath></PropertyGroup></Project>",
                root.display(),
                root.display()
            ),
        )
        .unwrap();
        let next_assets = root.join("cache-next/obj/Gear0007/project.assets.json");
        fs::create_dir_all(next_assets.parent().unwrap()).unwrap();
        fs::write(&next_assets, b"destination-local-assets").unwrap();

        assert_eq!(
            prepare_artifact_state(&root, target, 78).unwrap(),
            ArtifactPreparation::Missing
        );
        assert!(!artifact_exists(&root, target));
        fs::remove_dir_all(root).unwrap();
    }
}
