use std::fs;
use std::path::{Path, PathBuf};

fn hash_bytes(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash = (hash ^ u64::from(*byte)).wrapping_mul(1_099_511_628_211);
    }
    hash
}

fn collect_files(root: &Path, path: &Path, files: &mut Vec<PathBuf>) {
    let Ok(entries) = fs::read_dir(path) else {
        return;
    };
    let mut entries = entries.filter_map(Result::ok).collect::<Vec<_>>();
    entries.sort_by_key(|entry| entry.file_name());
    for entry in entries {
        let path = entry.path();
        if path.is_dir() {
            let name = entry.file_name();
            if name != "target" && name != "vendor" {
                collect_files(root, &path, files);
            }
        } else if (path.extension().is_some_and(|ext| ext == "rs")
            || path.file_name().is_some_and(|name| name == "Cargo.toml"))
            && path.starts_with(root)
        {
            files.push(path);
        }
    }
}

fn transform_input(root: &Path, path: &Path) -> bool {
    let Ok(relative) = path.strip_prefix(root) else {
        return true;
    };
    let Some(crate_name) = relative
        .components()
        .next()
        .and_then(|part| part.as_os_str().to_str())
    else {
        return true;
    };
    !matches!(
        crate_name,
        "spiral-split-cli"
            | "spiral-split-build-checkpoint"
            | "spiral-split-gear-executor"
            | "spiral-split-gear-execution-trace"
            | "spiral-split-gear-restore"
            | "spiral-split-process-supervisor"
            | "spiral-split-render-bench"
            | "spiral-split-loc"
            | "spiral-split-release"
    )
}

fn hash_file(mut hash: u64, root: &Path, path: &Path) -> u64 {
    let relative = path.strip_prefix(root).unwrap_or(path).to_string_lossy();
    hash = hash_bytes(hash, relative.as_bytes());
    hash = hash_bytes(hash, &[0]);
    hash = hash_bytes(hash, &fs::read(path).expect("read generator source"));
    hash_bytes(hash, &[0xff])
}

fn main() {
    let manifest = PathBuf::from(std::env::var("CARGO_MANIFEST_DIR").expect("manifest dir"));
    let root = manifest.parent().expect("workspace root");
    let mut files = Vec::new();
    let mut roots = fs::read_dir(root)
        .expect("workspace entries")
        .filter_map(Result::ok)
        .filter(|entry| entry.path().is_dir())
        .filter(|entry| {
            entry
                .file_name()
                .to_string_lossy()
                .starts_with("spiral-split-")
        })
        .map(|entry| entry.path())
        .collect::<Vec<_>>();
    roots.sort();
    for path in roots {
        collect_files(root, &path, &mut files);
    }
    for name in ["Cargo.toml", "Cargo.lock"] {
        let path = root.join(name);
        if path.is_file() {
            files.push(path);
        }
    }
    files.sort();
    files.dedup();
    let mut tool_hash = 14_695_981_039_346_656_037u64;
    let mut transform_hash = 14_695_981_039_346_656_037u64;
    for path in files {
        println!("cargo:rerun-if-changed={}", path.display());
        tool_hash = hash_file(tool_hash, root, &path);
        if transform_input(root, &path) {
            transform_hash = hash_file(transform_hash, root, &path);
        }
    }
    println!("cargo:rustc-env=SPIRAL_SPLIT_TOOL_FINGERPRINT={tool_hash}");
    println!("cargo:rustc-env=SPIRAL_SPLIT_TRANSFORM_FINGERPRINT={transform_hash}");
}
