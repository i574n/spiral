use spiral_split_model::{CompilerProfile, SourceText, fnv1a64};
use std::fs;
use std::path::Path;

fn normalize_text(bytes: Vec<u8>) -> Result<String, String> {
    let mut text =
        String::from_utf8(bytes).map_err(|error| format!("source is not UTF-8: {error}"))?;
    if text.starts_with('\u{feff}') {
        text.remove(0);
    }
    Ok(text.replace("\r\n", "\n").replace('\r', "\n"))
}

fn module_name(line: &str) -> Option<String> {
    let trimmed = line.trim();
    let rest = trimmed.strip_prefix("module ")?;
    let name = rest.strip_suffix('=')?.trim();
    if name.is_empty() {
        None
    } else {
        Some(name.to_owned())
    }
}

fn detect_profile(text: &str) -> CompilerProfile {
    let (hopac, portable) = text
        .lines()
        .map(str::trim_start)
        .filter(|line| !line.starts_with("//"))
        .fold((false, false), |(hopac, portable), line| {
            let hopac_marker = line.starts_with("module BigStack =")
                || line.contains("CompilerKernelV2")
                || line.contains("EvalWorklist")
                || line.contains("EvalReplayValueStore");
            let portable_marker = line.contains("StdoutFlush")
                || (line.contains("Delphi") && line.contains("Rust"))
                || line.contains("PortableBackends");
            (hopac || hopac_marker, portable || portable_marker)
        });
    match (hopac, portable) {
        (true, _) => CompilerProfile::Hopac,
        (false, true) => CompilerProfile::PortableFork,
        (false, false) if text.contains("module spiral_compiler") => CompilerProfile::PreHopac,
        _ => CompilerProfile::Unknown,
    }
}

pub fn load_source(path: &Path) -> Result<SourceText, String> {
    let bytes = fs::read(path).map_err(|error| format!("read {}: {error}", path.display()))?;
    let byte_count = bytes.len();
    let fingerprint = fnv1a64(&bytes);
    let text = normalize_text(bytes)?;
    let lines = text.split('\n').map(str::to_owned).collect::<Vec<_>>();
    let (module_line, module_name) = lines
        .iter()
        .enumerate()
        .find_map(|(index, line)| {
            let name = module_name(line)?;
            if name == "spiral_compiler" || name.ends_with(".spiral_compiler") {
                Some((index, name))
            } else {
                None
            }
        })
        .ok_or_else(|| format!("module spiral_compiler = not found in {}", path.display()))?;
    Ok(SourceText {
        path: path.to_path_buf(),
        lines,
        module_line,
        module_name,
        profile: detect_profile(&text),
        fingerprint,
        bytes: byte_count,
    })
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::io::Write;

    #[test]
    fn loads_pre_hopac_source() {
        let path = std::env::temp_dir().join(format!("spiral-source-{}.fs", std::process::id()));
        let mut file = fs::File::create(&path).expect("create");
        writeln!(
            file,
            "namespace Polyglot\nmodule spiral_compiler =\n    let x = 1"
        )
        .expect("write");
        let source = load_source(&path).expect("load");
        assert_eq!(source.module_line, 1);
        assert_eq!(source.profile, CompilerProfile::PreHopac);
        let _ = fs::remove_file(path);
    }

    #[test]
    fn hopac_migration_wins_over_portable_markers() {
        assert_eq!(
            detect_profile(
                "module spiral_compiler =\nmodule BigStack =\n    let x = CompilerKernelV2.run ()\ntype Target = Rust | Delphi"
            ),
            CompilerProfile::Hopac
        );
    }

    #[test]
    fn commented_hopac_migration_markers_do_not_change_profile() {
        assert_eq!(
            detect_profile(
                "module spiral_compiler =\n// module BigStack =\n// CompilerKernelV2\nlet x = 1"
            ),
            CompilerProfile::PreHopac
        );
    }
}
