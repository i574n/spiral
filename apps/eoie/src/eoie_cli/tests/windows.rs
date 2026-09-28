#![cfg(windows)]
use std::{fs, path::PathBuf, process::{Command, Output}};
struct Fixture(PathBuf);
impl Fixture {
    fn new() -> Self {
        let p = std::env::temp_dir().join(format!("eoie cli ü {} {}", std::process::id(), std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).unwrap().as_nanos()));
        fs::create_dir_all(&p).unwrap(); Self(p)
    }
    fn run(&self, args: &[&str]) -> Output {
        Command::new(env!("CARGO_BIN_EXE_eoie")).current_dir(&self.0).env_remove("EOIE_LEASE_ROOT").env_remove("EOIE_CONTROL_READ_ONLY").args(args).output().unwrap()
    }
    fn ok(&self, args: &[&str]) -> String {
        let o = self.run(args);
        assert!(o.status.success(), "{args:?}: {}", String::from_utf8_lossy(&o.stderr));
        String::from_utf8(o.stdout).unwrap()
    }
    fn path(&self) -> &str { self.0.to_str().unwrap() }
}
impl Drop for Fixture { fn drop(&mut self) { let _ = fs::remove_dir_all(&self.0); } }
#[test]
fn public_filesystem_roundtrip_and_guards() {
    let f = Fixture::new();
    f.ok(&["proxy", "fs-write", f.path(), "value.txt", "first"]);
    f.ok(&["proxy", "fs-write", f.path(), "value.txt", "--replace-existing", "--", "second"]);
    assert!(f.ok(&["proxy", "fs-read", f.path(), "value.txt"]).contains("second"));
    let hash = f.ok(&["proxy", "hash", f.path(), "value.txt"]);
    assert_eq!(hash.trim().len(), 64);
    f.ok(&["proxy", "fs-copy", f.path(), "value.txt", "copy.txt"]);
    assert_eq!(fs::read(f.0.join("copy.txt")).unwrap(), b"second");
    f.ok(&["proxy", "fs-remove", f.path(), "copy.txt"]);
    for relative in ["../escape.txt", "file:stream", "NUL"] {
        assert!(!f.run(&["proxy", "fs-write", f.path(), relative, "bad"]).status.success());
    }
}
#[test]
fn public_process_capture_timeout_and_failure() {
    let f = Fixture::new();
    let text = f.ok(&["proxy", "run", "--cwd", f.path(), "--program", "cmd.exe", "--timeout-ms", "10000", "--", "/d", "/c", "echo windows"]);
    assert!(text.contains("windows"));
    assert!(!f.run(&["proxy", "run", "--cwd", f.path(), "--program", "cmd.exe", "--timeout-ms", "10000", "--", "/d", "/c", "exit /b 7"]).status.success());
    let start = std::time::Instant::now();
    assert!(!f.run(&["proxy", "run", "--cwd", f.path(), "--program", "cmd.exe", "--timeout-ms", "100", "--", "/d", "/c", "ping -n 30 127.0.0.1 >nul"]).status.success());
    assert!(start.elapsed() < std::time::Duration::from_secs(10));
    f.ok(&["proxy", "command-capture", f.path(), "receipt.spi", "10000", "cmd.exe", "/d", "/c", "echo captured"]);
    assert!(f.0.join("receipt.spi").is_file());
}
#[test]
fn generic_bundle_roundtrip() {
    let f = Fixture::new();
    let source = f.0.join("source");
    fs::create_dir(&source).unwrap(); fs::write(source.join("value.txt"), "roundtrip").unwrap();
    let archive = f.0.join("bundle.zip"); let restored = f.0.join("restored");
    f.ok(&["bundle", "create", source.to_str().unwrap(), archive.to_str().unwrap(), "generic"]);
    f.ok(&["bundle", "verify", archive.to_str().unwrap(), "generic"]);
    f.ok(&["bundle", "rehydrate", archive.to_str().unwrap(), restored.to_str().unwrap(), "generic"]);
    assert_eq!(fs::read(restored.join("value.txt")).unwrap(), b"roundtrip");
}
