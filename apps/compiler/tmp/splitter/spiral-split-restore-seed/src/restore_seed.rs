use rayon::prelude::*;
use std::fs;
use std::path::{Path, PathBuf};

#[derive(Clone, Debug, PartialEq, Eq)]
enum RestoreLayout {
    Declared { intermediate_template: String },
    Legacy { obj_root: PathBuf },
}

impl RestoreLayout {
    fn discover(output_root: &Path) -> Result<Self, String> {
        let props_path = output_root.join("Directory.Build.props");
        if let Ok(props) = fs::read_to_string(&props_path)
            && let Some(template) = tag_value(&props, "BaseIntermediateOutputPath")
        {
            return Ok(Self::Declared {
                intermediate_template: template.to_owned(),
            });
        }
        Ok(Self::Legacy {
            obj_root: output_root.join(".build-cache/obj"),
        })
    }

    fn assets_path(&self, project: &str) -> PathBuf {
        match self {
            Self::Declared {
                intermediate_template,
            } => PathBuf::from(intermediate_template.replace("$(MSBuildProjectName)", project))
                .join("project.assets.json"),
            Self::Legacy { obj_root } => obj_root.join(project).join("project.assets.json"),
        }
    }

    fn label(&self) -> &'static str {
        match self {
            Self::Declared { .. } => "declared",
            Self::Legacy { .. } => "legacy",
        }
    }
}

fn tag_value<'a>(text: &'a str, tag: &str) -> Option<&'a str> {
    let open = format!("<{tag}>");
    let close = format!("</{tag}>");
    let start = text.find(&open)? + open.len();
    let end = text[start..].find(&close)? + start;
    Some(text[start..end].trim())
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let parent = path
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!(
        "{}.tmp",
        path.extension()
            .and_then(|value| value.to_str())
            .unwrap_or("file")
    ));
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    let _ = fs::remove_file(path);
    fs::rename(&temporary, path).map_err(|error| {
        format!(
            "commit {} -> {}: {error}",
            temporary.display(),
            path.display()
        )
    })
}

fn shard_count(output_root: &Path) -> Result<usize, String> {
    let parts_path = output_root.join("parts.tsv");
    let parts = fs::read_to_string(&parts_path)
        .map_err(|error| format!("read {}: {error}", parts_path.display()))?;
    let count = parts
        .lines()
        .skip(1)
        .filter(|line| !line.is_empty())
        .count();
    if count == 0 {
        return Err("parts.tsv contains no shards".to_owned());
    }
    Ok(count)
}

fn part_name(id: usize) -> String {
    format!("Part{id:04}")
}

pub fn seed_restore_assets(output_root: &Path) -> Result<usize, String> {
    let count = shard_count(output_root)?;
    let layout = RestoreLayout::discover(output_root)?;
    let seed_path = layout.assets_path("Part0000");
    let assets = fs::read_to_string(&seed_path).map_err(|error| {
        format!(
            "read restore seed {}: {error}; restore Part0000.fsproj first",
            seed_path.display()
        )
    })?;

    let mut projects = (0..count).map(part_name).collect::<Vec<_>>();
    projects.push("SplitRoot".to_owned());
    projects
        .par_iter()
        .try_for_each(|project| atomic_write(&layout.assets_path(project), &assets))?;

    let receipt = format!(
        "layout\t{}\nseed_project\tPart0000\nseed_path\t{}\nshards\t{count}\nseeded_projects\t{}\n",
        layout.label(),
        seed_path.display(),
        projects.len(),
    );
    atomic_write(&output_root.join("restore-seed.receipt.tsv"), &receipt)?;
    Ok(projects.len())
}

#[cfg(test)]
mod tests {
    use super::*;

    fn temp_root(label: &str) -> PathBuf {
        std::env::temp_dir().join(format!(
            "spiral-split-restore-seed-{label}-{}",
            std::process::id()
        ))
    }

    fn prepare_parts(root: &Path) {
        fs::write(root.join("parts.tsv"), "shard\tdeclarations\n0\t0\n1\t1\n").unwrap();
    }

    #[test]
    fn seeds_declared_identity_scoped_cache() {
        let root = temp_root("declared");
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join(".build-cache/feedface/obj/Part0000")).unwrap();
        prepare_parts(&root);
        fs::write(
            root.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseIntermediateOutputPath>{}/.build-cache/feedface/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath></PropertyGroup></Project>",
                root.display()
            ),
        )
        .unwrap();
        fs::write(
            root.join(".build-cache/feedface/obj/Part0000/project.assets.json"),
            "{}",
        )
        .unwrap();

        assert_eq!(seed_restore_assets(&root).unwrap(), 3);
        assert_eq!(
            fs::read_to_string(root.join(".build-cache/feedface/obj/Part0001/project.assets.json"))
                .unwrap(),
            "{}"
        );
        assert!(
            fs::read_to_string(root.join("restore-seed.receipt.tsv"))
                .unwrap()
                .contains("layout\tdeclared")
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn preserves_legacy_flat_cache_compatibility() {
        let root = temp_root("legacy");
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join(".build-cache/obj/Part0000")).unwrap();
        prepare_parts(&root);
        fs::write(
            root.join(".build-cache/obj/Part0000/project.assets.json"),
            "{}",
        )
        .unwrap();

        assert_eq!(seed_restore_assets(&root).unwrap(), 3);
        assert_eq!(
            fs::read_to_string(root.join(".build-cache/obj/SplitRoot/project.assets.json"))
                .unwrap(),
            "{}"
        );
        assert!(
            fs::read_to_string(root.join("restore-seed.receipt.tsv"))
                .unwrap()
                .contains("layout\tlegacy")
        );
        fs::remove_dir_all(root).unwrap();
    }
}
