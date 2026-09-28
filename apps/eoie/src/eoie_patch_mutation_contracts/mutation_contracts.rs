#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
use std::process::{Command, Output};
use std::time::{SystemTime, UNIX_EPOCH};

fn eoie_binary() -> PathBuf {
    if let Ok(path) = env::var("EOIE_BIN_UNDER_TEST") { return PathBuf::from(path); }
    let current = env::current_exe().expect("current test executable");
    let name = if cfg!(windows) { "eoie.exe" } else { "eoie" };
    let debug = current.parent().and_then(Path::parent).expect("target profile directory");
    let candidate = current.ancestors().skip(1).take_while(|directory| directory.file_name().is_some_and(|dir| dir != "target")).map(|directory| directory.join(name)).find(|path| path.is_file()).unwrap_or_else(|| debug.join(name));
    candidate
}

fn run(args: &[&str]) -> Output { Command::new(eoie_binary()).current_dir(env::temp_dir()).args(args).output().expect("run EOIE") }

fn temporary(label: &str) -> PathBuf {
    let stamp = SystemTime::now().duration_since(UNIX_EPOCH).expect("clock").as_nanos();
    env::temp_dir().join(format!("eoie-patch-mutation-{label}-{}-{stamp}", std::process::id()))
}

fn write(path: &Path, text: &str) {
    fs::create_dir_all(path.parent().expect("parent")).expect("create parent");
    fs::write(path, text).expect("write fixture");
}

fn prepared(label: &str) -> PathBuf {
    let root = temporary(label);
    fs::create_dir_all(root.join("state")).expect("state");
    write(&root.join("state/package.spiproj"), "modules:\n    plan\n");
    root
}

fn plan(path: &str, from: &str, to: &str) -> String {
    let esc = |value: &str| value.chars().flat_map(char::escape_default).collect::<String>();
    format!("inl main () : i32 =\n    $\"RustPlanOp(\\\"patch-exact\\\",\\\"{}\\\",\\\"{}\\\",\\\"{}\\\",\\\"write\\\")\" : ()\n    0i32\n", esc(path), esc(from), esc(to))
}

fn plans(rows: &[(&str, &str, &str)]) -> String { let esc = |value: &str| value.chars().flat_map(char::escape_default).collect::<String>(); let mut text = String::from("inl main () : i32 =\n"); for (path, from, to) in rows { text.push_str(&format!("    $\"RustPlanOp(\\\"patch-exact\\\",\\\"{}\\\",\\\"{}\\\",\\\"{}\\\",\\\"write\\\")\" : ()\n", esc(path), esc(from), esc(to))); } text.push_str("    0i32\n"); text }
#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_applies_one_typed_mutation() {
    let root = prepared("apply");
    write(&root.join("value.txt"), "old");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plan("value.txt", "old", "new"));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(output.status.success(), "{}", String::from_utf8_lossy(&output.stderr));
    assert!(String::from_utf8_lossy(&output.stdout).contains("witness=spiral"));
    assert_eq!(fs::read_to_string(root.join("value.txt")).expect("value"), "new");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
fn owner_rejects_incomplete_usage() {
    let output = run(&["patch", "apply"]);
    assert!(!output.status.success());
    assert!(String::from_utf8_lossy(&output.stderr).contains("patch supports only"));
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rejects_zero_witness_without_mutation() {
    let root = prepared("zero-witness");
    write(&root.join("value.txt"), "old");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, "union patch_exact = | PatchExact :: string * string * string -> patch_exact\ninl main () : i32 = 0i32\n");
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(!output.status.success());
    assert_eq!(fs::read_to_string(root.join("value.txt")).expect("value"), "old");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rejects_unsafe_relative_path() {
    let root = prepared("unsafe");
    let name = format!("escape-{}", std::process::id());
    let relative = format!("../{name}");
    let escaped = root.parent().expect("parent").join(&name);
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plan(&relative, "old", "new"));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(!output.status.success());
    assert!(!output.stderr.is_empty());
    assert!(!escaped.exists());
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rejects_repeated_matches_transactionally() {
    let root = prepared("repeated");
    write(&root.join("value.txt"), "xxx");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plan("value.txt", "x", "y"));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(!output.status.success());
    assert!(String::from_utf8_lossy(&output.stderr).contains("3 matches"));
    assert_eq!(fs::read_to_string(root.join("value.txt")).expect("value"), "xxx");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
fn owner_rejects_unknown_patch_action() {
    let output = run(&["patch", "unknown", "root", "plan"]);
    assert!(!output.status.success());
    let stderr = String::from_utf8_lossy(&output.stderr);
    assert!(stderr.contains("intent: patch") && stderr.contains("valid:") && stderr.contains("corrected: eoie help patch"));
}

#[test]
fn owner_rejects_missing_plan_file() {
    let root = prepared("missing-plan");
    let plan_path = root.join("state/missing.spi");
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(!output.status.success());
    assert!(!output.stderr.is_empty());
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_applies_two_typed_mutations() {
    let root = prepared("two");
    write(&root.join("a.txt"), "one");
    write(&root.join("b.txt"), "two");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plans(&[("a.txt", "one", "changed-a"), ("b.txt", "two", "changed-b")]));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(output.status.success(), "{}", String::from_utf8_lossy(&output.stderr));
    assert_eq!(fs::read_to_string(root.join("a.txt")).expect("a"), "changed-a");
    assert_eq!(fs::read_to_string(root.join("b.txt")).expect("b"), "changed-b");
    fs::remove_dir_all(root).expect("cleanup");
}

#[cfg(unix)]
#[test]
fn owner_rejects_symlink_plan_before_compilation() {
    use std::os::unix::fs::symlink;
    let root = prepared("symlink-plan");
    write(&root.join("value.txt"), "old");
    let real_plan = root.join("state/plan.spi");
    let linked_plan = root.join("state/plan-link.spi");
    write(&real_plan, &plan("value.txt", "old", "new"));
    symlink(&real_plan, &linked_plan).expect("symlink plan");
    let output = run(&["patch", "apply", root.to_str().expect("root"), linked_plan.to_str().expect("plan")]);
    assert!(!output.status.success());
    let stderr = String::from_utf8_lossy(&output.stderr);
    assert!(stderr.contains("nofollow") || stderr.contains("symlink"), "{stderr}");
    assert!(!stderr.contains("no PatchExact"), "{stderr}");
    assert_eq!(fs::read_to_string(root.join("value.txt")).expect("value"), "old");
    fs::remove_dir_all(root).expect("cleanup");
}

fn run_with_fault(args: &[&str], fault: &str) -> Output { Command::new(eoie_binary()).current_dir(env::temp_dir()).env("EOIE_PATCH_FAULT", fault).args(args).output().expect("run EOIE with fault") }

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_applies_three_files_and_five_places() {
    let root = prepared("three-files-five-places");
    write(&root.join("a.txt"), "a0 a1");
    write(&root.join("b.txt"), "b0");
    write(&root.join("c.txt"), "c0 c1");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plans(&[("a.txt", "a0", "A0"), ("b.txt", "b0", "B0"), ("a.txt", "a1", "A1"), ("c.txt", "c0", "C0"), ("c.txt", "c1", "C1")]));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(output.status.success(), "{}", String::from_utf8_lossy(&output.stderr));
    assert!(String::from_utf8_lossy(&output.stdout).contains("operations=5 files=3 witness=spiral"));
    assert_eq!(fs::read_to_string(root.join("a.txt")).expect("a"), "A0 A1");
    assert_eq!(fs::read_to_string(root.join("b.txt")).expect("b"), "B0");
    assert_eq!(fs::read_to_string(root.join("c.txt")).expect("c"), "C0 C1");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rolls_back_three_files_between_promotions() {
    let root = prepared("three-file-rollback");
    write(&root.join("a.txt"), "one");
    write(&root.join("b.txt"), "two");
    write(&root.join("c.txt"), "three");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plans(&[("a.txt", "one", "ONE"), ("b.txt", "two", "TWO"), ("c.txt", "three", "THREE")]));
    let output = run_with_fault(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")], "between-promotions");
    assert!(!output.status.success());
    assert_eq!(fs::read_to_string(root.join("a.txt")).expect("a"), "one");
    assert_eq!(fs::read_to_string(root.join("b.txt")).expect("b"), "two");
    assert_eq!(fs::read_to_string(root.join("c.txt")).expect("c"), "three");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rejects_stale_batch_before_any_promotion() {
    let root = prepared("stale-batch");
    write(&root.join("a.txt"), "one");
    write(&root.join("b.txt"), "two");
    write(&root.join("c.txt"), "three");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plans(&[("a.txt", "one", "ONE"), ("b.txt", "stale", "TWO"), ("c.txt", "three", "THREE")]));
    let output = run(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]);
    assert!(!output.status.success());
    assert_eq!(fs::read_to_string(root.join("a.txt")).expect("a"), "one");
    assert_eq!(fs::read_to_string(root.join("b.txt")).expect("b"), "two");
    assert_eq!(fs::read_to_string(root.join("c.txt")).expect("c"), "three");
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_resume_recompiles_provider_and_rolls_back_between_promotions() {
    let root = prepared("resume-rollback");
    write(&root.join("a.txt"), "one");
    write(&root.join("b.txt"), "two");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plans(&[("a.txt", "one", "ONE"), ("b.txt", "two", "TWO")]));
    let first = run_with_fault(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")], "after-typecheck");
    assert!(!first.status.success());
    assert!(root.join("state/patch_resume.spi").is_file());
    let second = Command::new(eoie_binary()).current_dir(env::temp_dir()).env("EOIE_PATCH_FAULT", "between-promotions").args(["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]).output().expect("resume patch");
    assert!(!second.status.success());
    let stdout = String::from_utf8_lossy(&second.stdout);
    let stderr = String::from_utf8_lossy(&second.stderr);
    assert!(stdout.contains("phase=identified resumed=true compiler=plan-ir:"), "{stdout} {stderr}");
    assert!(stderr.contains("rollback=restored"), "{stdout} {stderr}");
    assert_eq!(fs::read_to_string(root.join("a.txt")).expect("a"), "one");
    assert_eq!(fs::read_to_string(root.join("b.txt")).expect("b"), "two");
    assert!(root.join("state/patch_resume.spi").is_file());
    fs::remove_dir_all(root).expect("cleanup");
}

#[test]
#[ignore = "requires a Spiral facade with --check/--plan-ir; run build.ps1 -Test -CompilerContracts"]
fn owner_rejects_stale_resume_receipt_before_compiler_reuse() {
    let root = prepared("resume-stale");
    write(&root.join("value.txt"), "old");
    let plan_path = root.join("state/plan.spi");
    write(&plan_path, &plan("value.txt", "old", "new"));
    let first = run_with_fault(&["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")], "after-typecheck");
    assert!(!first.status.success());
    let receipt = root.join("state/patch_resume.spi");
    assert!(receipt.is_file());
    write(&plan_path, &plan("value.txt", "old", "newer"));
    let second = Command::new(eoie_binary()).current_dir(env::temp_dir()).args(["patch", "apply", root.to_str().expect("root"), plan_path.to_str().expect("plan")]).output().expect("stale patch");
    assert!(second.status.success());
    let stdout = String::from_utf8_lossy(&second.stdout);
    assert!(stdout.contains("phase=identified resumed=false compiler=plan-ir:"), "{stdout}");
    assert!(!receipt.exists());
    assert_eq!(fs::read_to_string(root.join("value.txt")).expect("value"), "newer");
    fs::remove_dir_all(root).expect("cleanup");
}

fn spiral_main() -> i32 {
    0i32
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
