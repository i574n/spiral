#![cfg(windows)]
use eoie_bundle_manifest::*;
#[test]
fn windows_zip_keeps_executable_entries_and_replaces_atomically() {
    let root = std::env::temp_dir().join(format!("eoie-zip-mode-{}-{}", std::process::id(), std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).unwrap().as_nanos()));
    let source = root.join("source"); std::fs::create_dir_all(&source).unwrap();
    for name in ["eoie", "eoie.exe", "readme.txt"] { std::fs::write(source.join(name), "data").unwrap(); }
    let manifest = collect_bundle_manifest(&source).unwrap();
    let output = root.join("bundle.zip");
    std::fs::write(&output, "old").unwrap();
    write_deterministic_deflate_zip(&source, &output, &manifest).unwrap();
    let mut archive = zip::ZipArchive::new(std::fs::File::open(&output).unwrap()).unwrap();
    for name in ["eoie", "eoie.exe"] { assert_ne!(archive.by_name(name).unwrap().unix_mode().unwrap() & 0o111, 0); }
    assert_eq!(archive.by_name("readme.txt").unwrap().unix_mode().unwrap() & 0o111, 0);
    drop(archive); std::fs::remove_dir_all(root).unwrap();
}
