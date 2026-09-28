use std::{
    collections::BTreeMap,
    fs,
    marker::PhantomData,
    path::{Path, PathBuf},
};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct AssemblyReference {
    pub name: String,
    pub path: PathBuf,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ReferenceChain {
    Empty,
    Link(AssemblyReference, Box<ReferenceChain>),
}

impl ReferenceChain {
    fn from_sorted(mut references: Vec<AssemblyReference>) -> Self {
        references.reverse();
        references
            .into_iter()
            .fold(Self::Empty, |tail, head| Self::Link(head, Box::new(tail)))
    }

    fn append_pairs(&self, output: &mut Vec<(String, PathBuf)>) {
        match self {
            Self::Empty => {}
            Self::Link(head, tail) => {
                output.push((head.name.clone(), head.path.clone()));
                tail.append_pairs(output);
            }
        }
    }
}

pub enum Pending {}
pub enum Ready {}

#[derive(Clone, Debug)]
pub struct AssemblyInventory<State> {
    root: PathBuf,
    references: ReferenceChain,
    state: PhantomData<State>,
}

impl AssemblyInventory<Pending> {
    pub fn at(root: &Path) -> Self {
        Self {
            root: root.to_path_buf(),
            references: ReferenceChain::Empty,
            state: PhantomData,
        }
    }

    pub fn scan(self) -> Result<AssemblyInventory<Ready>, String> {
        if !self.root.is_dir() {
            return Ok(AssemblyInventory {
                root: self.root,
                references: ReferenceChain::Empty,
                state: PhantomData,
            });
        }
        let mut references = fs::read_dir(&self.root)
            .map_err(|error| {
                format!(
                    "cannot inspect assembly root {}: {error}",
                    self.root.display()
                )
            })?
            .filter_map(Result::ok)
            .filter_map(|entry| {
                let path = entry.path();
                let extension = path.extension()?.to_str()?;
                if !extension.eq_ignore_ascii_case("dll") || !path.is_file() {
                    return None;
                }
                let name = path.file_stem()?.to_str()?.to_owned();
                let runtime_config = self.root.join(format!("{name}.runtimeconfig.json"));
                (!runtime_config.is_file()).then_some(AssemblyReference { name, path })
            })
            .collect::<Vec<_>>();
        references.sort_by(|left, right| left.name.cmp(&right.name));
        Ok(AssemblyInventory {
            root: self.root,
            references: ReferenceChain::from_sorted(references),
            state: PhantomData,
        })
    }
}

impl AssemblyInventory<Ready> {
    pub fn pairs(&self) -> Vec<(String, PathBuf)> {
        let mut output = Vec::new();
        self.references.append_pairs(&mut output);
        output
    }
}

pub fn discover_assembly_references(root: &Path) -> Result<Vec<(String, PathBuf)>, String> {
    Ok(AssemblyInventory::<Pending>::at(root).scan()?.pairs())
}

pub fn discover_assembly_references_with_overlay(
    fallback_root: &Path,
    overlay_root: Option<&Path>,
) -> Result<Vec<(String, PathBuf)>, String> {
    let mut by_name = discover_assembly_references(fallback_root)?
        .into_iter()
        .collect::<BTreeMap<_, _>>();
    if let Some(root) = overlay_root {
        for (name, path) in discover_assembly_references(root)? {
            by_name.insert(name, path);
        }
    }
    Ok(by_name.into_iter().collect())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn scan_is_sorted_and_excludes_runtime_host() {
        let root =
            std::env::temp_dir().join(format!("spiral-assembly-refs-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).expect("root");
        fs::write(root.join("Zeta.dll"), b"z").expect("zeta");
        fs::write(root.join("Alpha.dll"), b"a").expect("alpha");
        fs::write(root.join("Host.dll"), b"host").expect("host");
        fs::write(root.join("Host.runtimeconfig.json"), b"{}").expect("runtimeconfig");
        fs::write(root.join("note.txt"), b"ignored").expect("note");
        let pairs = discover_assembly_references(&root).expect("scan");
        assert_eq!(
            pairs
                .iter()
                .map(|(name, _)| name.as_str())
                .collect::<Vec<_>>(),
            vec!["Alpha", "Zeta"]
        );
        fs::remove_dir_all(root).expect("cleanup");
    }

    #[test]
    fn overlay_wins_by_assembly_name_and_keeps_fallback_only_entries() {
        let base =
            std::env::temp_dir().join(format!("spiral-assembly-overlay-{}", std::process::id()));
        let fallback = base.join("fallback");
        let overlay = base.join("overlay");
        let _ = fs::remove_dir_all(&base);
        fs::create_dir_all(&fallback).expect("fallback");
        fs::create_dir_all(&overlay).expect("overlay");
        fs::write(fallback.join("Shared.dll"), b"old").expect("fallback shared");
        fs::write(fallback.join("Hopac.dll"), b"hopac").expect("fallback hopac");
        fs::write(overlay.join("Shared.dll"), b"new").expect("overlay shared");
        fs::write(overlay.join("Supervisor.dll"), b"supervisor").expect("overlay supervisor");

        let pairs = discover_assembly_references_with_overlay(&fallback, Some(&overlay))
            .expect("overlay scan");
        assert_eq!(
            pairs,
            vec![
                ("Hopac".to_owned(), fallback.join("Hopac.dll")),
                ("Shared".to_owned(), overlay.join("Shared.dll")),
                ("Supervisor".to_owned(), overlay.join("Supervisor.dll")),
            ]
        );
        fs::remove_dir_all(base).expect("cleanup");
    }
}
