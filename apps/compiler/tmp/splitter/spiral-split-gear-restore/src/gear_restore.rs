use rayon::ThreadPoolBuilder;
use rayon::prelude::*;
use std::collections::BTreeSet;
use std::fs;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};
use std::process::Command;

#[derive(Debug)]
pub enum Discovered {}
#[derive(Debug)]
pub enum Validated {}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum RestoreTarget {
    Gear { id: usize, project: PathBuf },
    Root { project: PathBuf },
}

impl RestoreTarget {
    fn name(&self) -> String {
        match self {
            Self::Gear { id, .. } => format!("Gear{id:04}"),
            Self::Root { .. } => "GearRoot".to_owned(),
        }
    }

    fn project(&self) -> &Path {
        match self {
            Self::Gear { project, .. } | Self::Root { project } => project,
        }
    }
}

#[derive(Clone, Debug)]
pub struct GearRestorePlan<S> {
    pub output_root: PathBuf,
    pub cache_root: PathBuf,
    pub seed_project: PathBuf,
    pub seed_assets: PathBuf,
    pub targets: Vec<RestoreTarget>,
    stage: PhantomData<S>,
}

#[derive(Clone, Debug)]
pub struct GearRestoreOptions {
    pub output_root: PathBuf,
    pub dotnet: PathBuf,
    pub jobs: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearRestoreReceipt {
    pub gears: usize,
    pub targets: usize,
    pub restored_seed: bool,
    pub copied: usize,
    pub reused: usize,
    pub seed_assets: PathBuf,
    pub receipt: PathBuf,
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

fn cache_root(output_root: &Path) -> Result<PathBuf, String> {
    let props = output_root.join("Directory.Build.props");
    let text =
        fs::read_to_string(&props).map_err(|error| format!("read {}: {error}", props.display()))?;
    let raw = property(&text, "BaseIntermediateOutputPath")?;
    let prefix = raw
        .split("$(MSBuildProjectName)")
        .next()
        .unwrap_or(&raw)
        .trim_end_matches(['/', '\\']);
    if prefix.is_empty() {
        return Err("BaseIntermediateOutputPath has no cache prefix".to_owned());
    }
    let path = PathBuf::from(prefix);
    Ok(if path.is_absolute() {
        path.parent()
            .map(Path::to_path_buf)
            .ok_or_else(|| format!("cache prefix has no parent: {}", path.display()))?
    } else {
        output_root
            .join(path)
            .parent()
            .map(Path::to_path_buf)
            .ok_or_else(|| "relative cache prefix has no parent".to_owned())?
    })
}

fn gear_ids(output_root: &Path) -> Result<Vec<usize>, String> {
    let manifest = output_root.join("gears.tsv");
    let text = fs::read_to_string(&manifest)
        .map_err(|error| format!("read {}: {error}", manifest.display()))?;
    let mut ids = Vec::new();
    for (index, line) in text.lines().enumerate().skip(1) {
        if line.trim().is_empty() {
            continue;
        }
        let field = line
            .split_whitespace()
            .next()
            .ok_or_else(|| format!("gears.tsv line {} has no gear id", index + 1))?;
        ids.push(
            field.parse::<usize>().map_err(|error| {
                format!("gears.tsv line {} invalid gear id: {error}", index + 1)
            })?,
        );
    }
    if ids.is_empty() {
        return Err("gears.tsv contains no gears".to_owned());
    }
    Ok(ids)
}

pub fn discover_restore_plan(output_root: &Path) -> Result<GearRestorePlan<Discovered>, String> {
    let ids = gear_ids(output_root)?;
    let cache_root = cache_root(output_root)?;
    let targets = ids
        .iter()
        .copied()
        .map(|id| RestoreTarget::Gear {
            id,
            project: output_root.join(format!("Gear{id:04}.fsproj")),
        })
        .chain(std::iter::once(RestoreTarget::Root {
            project: output_root.join("GearRoot.fsproj"),
        }))
        .collect::<Vec<_>>();
    Ok(GearRestorePlan {
        output_root: output_root.to_path_buf(),
        cache_root: cache_root.clone(),
        seed_project: output_root.join("Gear0000.fsproj"),
        seed_assets: cache_root.join("obj/Gear0000/project.assets.json"),
        targets,
        stage: PhantomData,
    })
}

impl GearRestorePlan<Discovered> {
    pub fn validate(self) -> Result<GearRestorePlan<Validated>, String> {
        let ids = self
            .targets
            .iter()
            .filter_map(|target| match target {
                RestoreTarget::Gear { id, .. } => Some(*id),
                RestoreTarget::Root { .. } => None,
            })
            .collect::<Vec<_>>();
        let unique = ids.iter().copied().collect::<BTreeSet<_>>();
        if unique.len() != ids.len() {
            return Err("gears.tsv contains duplicate gear ids".to_owned());
        }
        for (expected, actual) in ids.iter().copied().enumerate() {
            if expected != actual {
                return Err(format!(
                    "gear ids must be dense from zero: expected {expected}, found {actual}"
                ));
            }
        }
        for target in &self.targets {
            if !target.project().is_file() {
                return Err(format!(
                    "restore project is missing: {}",
                    target.project().display()
                ));
            }
        }
        Ok(GearRestorePlan {
            output_root: self.output_root,
            cache_root: self.cache_root,
            seed_project: self.seed_project,
            seed_assets: self.seed_assets,
            targets: self.targets,
            stage: PhantomData,
        })
    }
}

fn asset_path(plan: &GearRestorePlan<Validated>, target: &RestoreTarget) -> PathBuf {
    plan.cache_root
        .join("obj")
        .join(target.name())
        .join("project.assets.json")
}

fn ensure_seed(plan: &GearRestorePlan<Validated>, dotnet: &Path) -> Result<bool, String> {
    if fs::metadata(&plan.seed_assets)
        .map(|metadata| metadata.len() > 0)
        .unwrap_or(false)
    {
        return Ok(false);
    }
    let log_root = plan.output_root.join(".gear-restore/logs");
    let output = Command::new(dotnet)
        .current_dir(&plan.output_root)
        .env("DOTNET_MULTILEVEL_LOOKUP", "0")
        .env("DOTNET_NOLOGO", "1")
        .env("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
        .env("DOTNET_SKIP_FIRST_TIME_EXPERIENCE", "1")
        .arg("restore")
        .arg("Gear0000.fsproj")
        .arg("--disable-parallel")
        .arg("--ignore-failed-sources")
        .arg("--force-evaluate")
        .arg("-v:q")
        .output()
        .map_err(|error| format!("spawn dotnet restore Gear0000: {error}"))?;
    atomic_write(&log_root.join("Gear0000.stdout"), &output.stdout)?;
    atomic_write(&log_root.join("Gear0000.stderr"), &output.stderr)?;
    if !output.status.success() {
        return Err(format!(
            "Gear0000 restore failed; stderr={}",
            log_root.join("Gear0000.stderr").display()
        ));
    }
    if !fs::metadata(&plan.seed_assets)
        .map(|metadata| metadata.len() > 0)
        .unwrap_or(false)
    {
        return Err(format!(
            "Gear0000 restore succeeded without producing {}",
            plan.seed_assets.display()
        ));
    }
    Ok(true)
}

fn seed_target(path: &Path, assets: &[u8]) -> Result<bool, String> {
    if fs::read(path).is_ok_and(|existing| existing == assets) {
        return Ok(false);
    }
    atomic_write(path, assets)?;
    Ok(true)
}

pub fn ensure_gear_restore_assets(
    options: &GearRestoreOptions,
) -> Result<GearRestoreReceipt, String> {
    if options.jobs == 0 {
        return Err("gear restore jobs must be greater than zero".to_owned());
    }
    let plan = discover_restore_plan(&options.output_root)?.validate()?;
    let restored_seed = ensure_seed(&plan, &options.dotnet)?;
    let assets = fs::read(&plan.seed_assets)
        .map_err(|error| format!("read restore seed {}: {error}", plan.seed_assets.display()))?;
    let pool = ThreadPoolBuilder::new()
        .num_threads(options.jobs)
        .build()
        .map_err(|error| format!("create gear restore thread pool: {error}"))?;
    let copied_flags = pool.install(|| {
        plan.targets
            .par_iter()
            .map(|target| seed_target(&asset_path(&plan, target), &assets))
            .collect::<Result<Vec<_>, _>>()
    })?;
    let copied = copied_flags.iter().filter(|copied| **copied).count();
    let reused = copied_flags.len() - copied;
    let gears = plan
        .targets
        .iter()
        .filter(|target| matches!(target, RestoreTarget::Gear { .. }))
        .count();
    let receipt = plan.output_root.join("gear-restore.receipt.tsv");
    let text = format!(
        "key\tvalue\nstatus\tpass\nseed_project\tGear0000\nseed_assets\t{}\ngears\t{}\ntargets\t{}\nrestored_seed\t{}\ncopied\t{}\nreused\t{}\njobs\t{}\n",
        plan.seed_assets.display(),
        gears,
        plan.targets.len(),
        restored_seed,
        copied,
        reused,
        options.jobs,
    );
    atomic_write(&receipt, text.as_bytes())?;
    Ok(GearRestoreReceipt {
        gears,
        targets: plan.targets.len(),
        restored_seed,
        copied,
        reused,
        seed_assets: plan.seed_assets,
        receipt,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    fn root(name: &str) -> PathBuf {
        std::env::temp_dir().join(format!("spiral-gear-restore-{name}-{}", std::process::id()))
    }

    fn fixture(name: &str, ids: &[usize]) -> PathBuf {
        let output = root(name);
        let _ = fs::remove_dir_all(&output);
        fs::create_dir_all(&output).unwrap();
        fs::write(
            output.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseIntermediateOutputPath>{}/cache/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath></PropertyGroup></Project>",
                output.display()
            ),
        )
        .unwrap();
        let mut manifest = String::from("gear source_layer\n");
        for id in ids {
            manifest.push_str(&format!("{id} 0\n"));
            fs::write(output.join(format!("Gear{id:04}.fsproj")), "<Project />").unwrap();
        }
        fs::write(output.join("GearRoot.fsproj"), "<Project />").unwrap();
        fs::write(output.join("gears.tsv"), manifest).unwrap();
        output
    }

    #[test]
    fn rejects_non_dense_gear_ids() {
        let output = fixture("non-dense", &[0, 2]);
        let error = discover_restore_plan(&output)
            .unwrap()
            .validate()
            .unwrap_err();
        assert!(error.contains("dense"));
        fs::remove_dir_all(output).unwrap();
    }

    #[test]
    fn seeds_all_gears_and_root_from_one_asset() {
        let output = fixture("seed", &[0, 1]);
        let seed = output.join("cache/obj/Gear0000/project.assets.json");
        fs::create_dir_all(seed.parent().unwrap()).unwrap();
        fs::write(&seed, b"asset-bytes").unwrap();
        let receipt = ensure_gear_restore_assets(&GearRestoreOptions {
            output_root: output.clone(),
            dotnet: PathBuf::from("unused-dotnet"),
            jobs: 4,
        })
        .unwrap();
        assert_eq!(receipt.gears, 2);
        assert_eq!(receipt.targets, 3);
        assert_eq!(receipt.copied, 2);
        assert_eq!(
            fs::read(output.join("cache/obj/Gear0001/project.assets.json")).unwrap(),
            b"asset-bytes"
        );
        assert_eq!(
            fs::read(output.join("cache/obj/GearRoot/project.assets.json")).unwrap(),
            b"asset-bytes"
        );
        fs::remove_dir_all(output).unwrap();
    }
}
