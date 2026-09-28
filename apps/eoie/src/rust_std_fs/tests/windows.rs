#![cfg(windows)]
use eoie_rust_std_fs::*;
use std::fs;
use std::path::PathBuf;
static COUNTER: std::sync::atomic::AtomicU64 = std::sync::atomic::AtomicU64::new(0);
fn scratch() -> PathBuf {
    let count = COUNTER.fetch_add(1, std::sync::atomic::Ordering::Relaxed);
    let root = std::env::temp_dir().join(format!(
        "eoie windows ü {}-{}-{}",
        std::process::id(),
        count,
        std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).unwrap().as_nanos()
    ));
    fs::create_dir_all(&root).unwrap();
    root
}
#[test]
fn read_write_replace_stage_copy_and_remove() {
    let root = scratch();
    let file = root.join("nested/a.txt");
    atomic_write(&file, b"first").unwrap();
    atomic_write(&file, b"second").unwrap();
    assert_eq!(read_regular_text_limited(&file, 20).unwrap(), "second");
    assert!(read_regular_limited(&file, 2).is_err());
    let receipt = stage_text_receipted_bound(&file, "third", 1, 2).unwrap();
    promote_stage_receipted(&receipt).unwrap();
    assert_eq!(read_regular_limited(&file, 20).unwrap(), b"third");
    let copy = root.join("copy.txt");
    assert_eq!(copy_regular_atomic_preserve(&file, &copy).unwrap(), 5);
    assert_eq!(rooted_list_names(&root.join("nested")).unwrap(), ["a.txt"]);
    assert!(rooted_entry_exists(&copy).unwrap());
    rooted_remove_regular(&copy).unwrap();
    assert!(!rooted_entry_exists(&copy).unwrap());
    rooted_remove_tree_within(&root, &root.join("nested")).unwrap();
    assert!(rooted_remove_tree_within(&root, &root).is_err());
    fs::remove_dir(root).unwrap();
}
#[test]
fn rejects_windows_aliases_and_traversal() {
    for path in ["../x", "C:relative", "C:\\absolute", "file:stream", "NUL", "con.txt", "COM1", "trailing.", "trailing ", "x/<bad>"] {
        assert!(safe_relative_path(path).is_err(), "accepted {path}");
    }
    assert!(safe_relative_path("folder\\valid ü.txt").is_ok());
}
#[test]
fn rejects_junctions_and_holds_ancestors_against_rename() {
    let root = scratch();
    let real = root.join("real");
    fs::create_dir(&real).unwrap();
    fs::write(real.join("secret"), b"secret").unwrap();
    let link = root.join("junction");
    let status = std::process::Command::new("cmd.exe").args(["/d", "/c", "mklink", "/J"]).arg(&link).arg(&real).output().unwrap();
    assert!(status.status.success(), "{}", String::from_utf8_lossy(&status.stderr));
    assert!(read_regular_limited(&link.join("secret"), 20).is_err());
    assert!(atomic_write(&link.join("secret"), b"changed").is_err());
    assert!(rooted_list_names(&link).is_err());
    assert_eq!(fs::read(real.join("secret")).unwrap(), b"secret");
    let guard = windows_guard(&real.join("secret"), false, false).unwrap();
    assert!(fs::rename(&real, root.join("moved")).is_err());
    drop(guard);
    fs::remove_dir(&link).unwrap();
    fs::remove_dir_all(root).unwrap();
}
