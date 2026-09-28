use std::collections::BTreeMap;
use std::fs;
use std::path::{Component, Path, PathBuf};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LocRow {
    pub language: &'static str,
    pub scope: &'static str,
    pub files: usize,
    pub lines: usize,
    pub bytes: usize,
}

#[derive(Clone, Copy, Debug, Default)]
struct Totals {
    files: usize,
    lines: usize,
    bytes: usize,
}

fn language(path: &Path) -> Option<&'static str> {
    let extension = path.extension()?.to_str()?.to_ascii_lowercase();
    match extension.as_str() {
        "rs" => Some("Rust"),
        "fs" | "fsx" | "fsi" => Some("Fsharp"),
        "pas" | "pp" | "inc" | "lpr" => Some("Delphi_Pascal"),
        "c" | "h" => Some("C_headers"),
        "cc" | "cpp" | "cxx" | "hpp" | "hh" | "hxx" => Some("Cpp"),
        "cs" => Some("Csharp"),
        "sh" | "ps1" => Some("Shell_PowerShell"),
        "spi" | "spir" => Some("Spiral"),
        _ => None,
    }
}

fn ignored_directory(name: &str) -> bool {
    matches!(
        name,
        ".git"
            | ".build-cache"
            | "target"
            | "obj"
            | "node_modules"
            | "__pycache__"
            | "split-cache"
            | "generated-hopac"
    )
}

fn is_vendor(relative: &Path) -> bool {
    relative.components().any(
        |component| matches!(component, Component::Normal(name) if name.to_str() == Some("vendor")),
    )
}

fn line_count(bytes: &[u8]) -> usize {
    if bytes.is_empty() {
        0
    } else {
        bytes.iter().filter(|byte| **byte == b'\n').count()
            + usize::from(bytes.last() != Some(&b'\n'))
    }
}

fn walk(
    root: &Path,
    current: &Path,
    totals: &mut BTreeMap<(&'static str, &'static str), Totals>,
) -> Result<(), String> {
    let mut entries = fs::read_dir(current)
        .map_err(|error| format!("list {}: {error}", current.display()))?
        .collect::<Result<Vec<_>, _>>()
        .map_err(|error| format!("read {}: {error}", current.display()))?;
    entries.sort_by_key(std::fs::DirEntry::file_name);
    for entry in entries {
        let path = entry.path();
        let kind = entry
            .file_type()
            .map_err(|error| format!("type {}: {error}", path.display()))?;
        if kind.is_dir() {
            let name = entry.file_name();
            let name = name.to_string_lossy();
            if !ignored_directory(&name) {
                walk(root, &path, totals)?;
            }
            continue;
        }
        if !kind.is_file() {
            continue;
        }
        let Some(language) = language(&path) else {
            continue;
        };
        let relative = path
            .strip_prefix(root)
            .map_err(|error| format!("relative {}: {error}", path.display()))?;
        let scope = if is_vendor(relative) { "vendor" } else { "own" };
        let bytes = fs::read(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
        let total = totals.entry((language, scope)).or_default();
        total.files += 1;
        total.lines += line_count(&bytes);
        total.bytes += bytes.len();
    }
    Ok(())
}

pub fn measure_workspace_loc(root: &Path) -> Result<Vec<LocRow>, String> {
    if !root.is_dir() {
        return Err(format!("LOC root is not a directory: {}", root.display()));
    }
    let mut totals = BTreeMap::new();
    walk(root, root, &mut totals)?;
    Ok(totals
        .into_iter()
        .map(|((language, scope), totals)| LocRow {
            language,
            scope,
            files: totals.files,
            lines: totals.lines,
            bytes: totals.bytes,
        })
        .collect())
}

pub fn render_loc_tsv(rows: &[LocRow]) -> String {
    let mut output = String::from(
        "language	scope	files	lines	bytes
",
    );
    for row in rows {
        output.push_str(&format!(
            "{}	{}	{}	{}	{}
",
            row.language, row.scope, row.files, row.lines, row.bytes
        ));
    }
    output
}

pub fn write_loc_report(root: &Path) -> Result<PathBuf, String> {
    let rows = measure_workspace_loc(root)?;
    let report = root.join("reports/LOC_BY_LANGUAGE.tsv");
    let parent = report
        .parent()
        .ok_or_else(|| format!("report has no parent: {}", report.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = report.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, render_loc_tsv(&rows))
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if report.exists() {
        fs::remove_file(&report)
            .map_err(|error| format!("remove {}: {error}", report.display()))?;
    }
    fs::rename(&temporary, &report)
        .map_err(|error| format!("commit {}: {error}", report.display()))?;
    Ok(report)
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::sync::atomic::{AtomicUsize, Ordering};

    static NEXT: AtomicUsize = AtomicUsize::new(0);

    fn fixture() -> PathBuf {
        let root = std::env::temp_dir().join(format!(
            "spiral-loc-{}-{}",
            std::process::id(),
            NEXT.fetch_add(1, Ordering::Relaxed)
        ));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join("src")).expect("src");
        fs::create_dir_all(root.join("vendor/rayon/src")).expect("vendor");
        fs::create_dir_all(root.join("target/debug")).expect("target");
        fs::write(
            root.join("src/main.rs"),
            "fn main() {}
",
        )
        .expect("own");
        fs::write(
            root.join("vendor/rayon/src/lib.rs"),
            "pub fn par() {}
",
        )
        .expect("vendor");
        fs::write(
            root.join("target/debug/generated.rs"),
            "ignored
",
        )
        .expect("ignored");
        root
    }

    #[test]
    fn own_and_vendor_are_separate() {
        let root = fixture();
        let rows = measure_workspace_loc(&root).expect("measure");
        assert_eq!(
            rows,
            vec![
                LocRow {
                    language: "Rust",
                    scope: "own",
                    files: 1,
                    lines: 1,
                    bytes: 13,
                },
                LocRow {
                    language: "Rust",
                    scope: "vendor",
                    files: 1,
                    lines: 1,
                    bytes: 16,
                },
            ]
        );
        fs::remove_dir_all(root).expect("cleanup");
    }

    #[test]
    fn empty_file_has_zero_lines() {
        assert_eq!(line_count(&[]), 0);
        assert_eq!(line_count(b"a"), 1);
        assert_eq!(
            line_count(
                b"a
"
            ),
            1
        );
        assert_eq!(
            line_count(
                b"a
b"
            ),
            2
        );
    }
}
