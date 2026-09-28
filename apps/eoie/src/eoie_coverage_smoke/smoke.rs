#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_process_observation::run_bounded_observed_with_input;
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
use std::process::Command;

#[rustfmt::skip]
fn coverage_toolchain_smoke(context: &CoverageSmokeContext<'_>, scratch: &Path, cargo_text: &str, compiler_text: &str) -> Result<(), String> {
    let toolchain_root = scratch.join("toolchain-app");
    fs::create_dir_all(toolchain_root.join("src")).map_err(|error| error.to_string())?;
    fs::write(toolchain_root.join("Cargo.toml"), b"[package]\nname = \"eoie_toolchain_smoke\"\nversion = \"0.0.0\"\nedition = \"2024\"\npublish = false\n\n[dependencies]\n").map_err(|error| error.to_string())?;
    fs::write(toolchain_root.join("src/main.rs"), b"fn main() {\n    println!(\"toolchain smoke\");\n}\n").map_err(|error| error.to_string())?;
    let toolchain_text = toolchain_root.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-lock", "30000"]), "toolchain-cargo-lock", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-fmt-check", "30000"]), "toolchain-cargo-fmt", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-check", "30000"]), "toolchain-cargo-check", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-test", "30000"]), "toolchain-cargo-test", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-clippy", "30000"]), "toolchain-cargo-clippy", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-build", "30000"]), "toolchain-cargo-build", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-version", "30000"]), "toolchain-cargo-version", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, compiler_text, "spiral-version", "30000"]), "toolchain-spiral-version", true)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "unknown", "30000"]), "toolchain-unknown-action", false)?;
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &toolchain_text, cargo_text, "cargo-check", "0"]), "toolchain-zero-timeout", false)?;
    let missing_root = scratch.join("missing-toolchain-root").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &toolchain_root, &coverage_smoke_args(&["proxy", "toolchain", &missing_root, cargo_text, "cargo-check", "30000"]), "toolchain-missing-root", false)?;
    Ok(())
}

#[rustfmt::skip]
fn coverage_export_union_smoke(context: &CoverageSmokeContext<'_>, scratch: &Path, lcov_test: &Path, lcov_smoke: &Path) -> Result<(), String> {
    let grcov = env::var("EOIE_GRCOV").map_err(|_| "EOIE_GRCOV is required for coverage smoke".to_owned())?; let llvm_bin = env::var("EOIE_LLVM_BIN").map_err(|_| "EOIE_LLVM_BIN is required for coverage smoke".to_owned())?;
    let profraw = Path::new(context.profile_pattern).parent().ok_or_else(|| "coverage profile pattern has no parent".to_owned())?; let binary = context.binary; let source_root = context.root.join("src");
    let exported = scratch.join("exported.lcov"); let union = scratch.join("union.lcov"); let profraw_text = profraw.to_string_lossy().into_owned(); let binary_text = binary.to_string_lossy().into_owned(); let source_root_text = source_root.to_string_lossy().into_owned();
    let exported_text = exported.to_string_lossy().into_owned(); let union_text = union.to_string_lossy().into_owned(); let test_text = lcov_test.to_string_lossy().into_owned(); let smoke_text = lcov_smoke.to_string_lossy().into_owned(); let timeout_text = context.timeout_ms.to_string();
    coverage_smoke_exec(context, scratch, &coverage_smoke_args(&["proxy", "coverage-export", &profraw_text, &binary_text, &grcov, &llvm_bin, &source_root_text, &exported_text, &timeout_text]), "coverage-export", true)?;
    coverage_smoke_exec(context, scratch, &coverage_smoke_args(&["proxy", "coverage-union", &union_text, &test_text, &smoke_text]), "coverage-union", true)?; coverage_smoke_exec(context, scratch, &coverage_smoke_args(&["proxy", "coverage-assess", &union_text, &union_text, "0", "0", "0"]), "coverage-union-assess", true)?;
    if !PathBuf::from(format!("{}.receipt", exported.display())).is_file() || !PathBuf::from(format!("{}.receipt", union.display())).is_file() { return Err("coverage export or union receipt is missing".to_owned()); } Ok(())
}

pub struct CoverageSmokeContext<'a> { pub root: &'a Path, pub cargo: &'a Path, pub compiler: &'a Path, pub binary: &'a Path, pub target: &'a Path, pub profile_pattern: &'a str, pub timeout_ms: u64 }

fn coverage_smoke_temp(label: &str) -> PathBuf {
    let stamp = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).unwrap_or_default().as_nanos();
    env::temp_dir().join(format!("eoie-coverage-smoke-{label}-{}-{stamp}", std::process::id()))
} // coverage_smoke_temp

#[rustfmt::skip]
fn coverage_smoke_exec(context: &CoverageSmokeContext<'_>, cwd: &Path, args: &[String], phase: &str, expect_success: bool) -> Result<(), String> {
    let mut command = Command::new(context.binary);
    command.current_dir(cwd).args(args).env("LLVM_PROFILE_FILE", context.profile_pattern).env("EOIE_SPIRAL_COMPILE", context.compiler).env("EOIE_BIN_UNDER_TEST", context.binary).env("CARGO_TARGET_DIR", context.target);
    let observation = run_bounded_observed_with_input(&mut command, context.timeout_ms, None)?;
    if observation.status.success() != expect_success { return Err(format!("smoke phase {phase} expected success={expect_success} observed={} termination={:?} stderr={}", observation.status, observation.termination, String::from_utf8_lossy(&observation.stderr))); }
    println!("eoie coverage smoke phase={phase} status=passed expected_success={expect_success} termination={:?} elapsed_ms={} stdout_bytes={} stderr_bytes={}", observation.termination, observation.elapsed_ms, observation.stdout.len(), observation.stderr.len());
    Ok(()) // coverage_smoke_exec
} // coverage_smoke_exec

fn coverage_smoke_args(values: &[&str]) -> Vec<String> { values.iter().map(|value| (*value).to_owned()).collect() }

#[rustfmt::skip]
fn coverage_smoke_current_migration(context: &CoverageSmokeContext<'_>) -> Result<i32, String> {
    let mut command = Command::new(context.binary);
    command.arg("status").env("LLVM_PROFILE_FILE", context.profile_pattern);
    let observation = run_bounded_observed_with_input(&mut command, context.timeout_ms, None)?;
    if !observation.status.success() { return Err(format!("status migration probe failed status={} stderr={}", observation.status, String::from_utf8_lossy(&observation.stderr))); }
    let stdout = String::from_utf8_lossy(&observation.stdout);
    stdout.split("migration=").nth(1).and_then(|tail| tail.split('/').next()).and_then(|value| value.parse::<i32>().ok()).ok_or_else(|| format!("status migration missing: {stdout}"))
}

#[rustfmt::skip]
fn coverage_smoke_cargo(context: &CoverageSmokeContext<'_>, args: &[&str], phase: &str) -> Result<(), String> {
    let mut command = Command::new(context.cargo);
    command.current_dir(context.root.join("src")).args(args).env("CARGO_TARGET_DIR", context.target).env("CARGO_INCREMENTAL", "1").env("RUSTFLAGS", "-C instrument-coverage").env("LLVM_PROFILE_FILE", context.profile_pattern).env("EOIE_SPIRAL_COMPILE", context.compiler).env("EOIE_BIN_UNDER_TEST", context.binary).env("RAYON_NUM_THREADS", "56");
    let observation = run_bounded_observed_with_input(&mut command, context.timeout_ms, None)?;
    if !observation.status.success() { return Err(format!("probe phase {phase} failed status={} termination={:?} stderr={}", observation.status, observation.termination, String::from_utf8_lossy(&observation.stderr))); }
    println!("eoie coverage probe phase={phase} status=passed termination={:?} elapsed_ms={} stdout_bytes={} stderr_bytes={}", observation.termination, observation.elapsed_ms, observation.stdout.len(), observation.stderr.len());
    Ok(())
}

#[rustfmt::skip]
fn coverage_smoke_copy_state(source: &Path, destination: &Path) -> Result<(), String> {
    fs::create_dir_all(destination).map_err(|error| format!("create {}: {error}", destination.display()))?;
    for entry in fs::read_dir(source).map_err(|error| format!("read {}: {error}", source.display()))? {
        let entry = entry.map_err(|error| error.to_string())?;
        let path = entry.path();
        if path.is_file() { fs::copy(&path, destination.join(entry.file_name())).map_err(|error| format!("copy {}: {error}", path.display()))?; }
    } // coverage_smoke_copy_state loop
    Ok(()) // coverage_smoke_copy_state
} // coverage_smoke_copy_state

#[rustfmt::skip]
pub fn coverage_smoke_run(context: &CoverageSmokeContext<'_>) -> Result<(), String> {
    let scratch = coverage_smoke_temp("root");
    fs::create_dir_all(scratch.join("state")).map_err(|error| error.to_string())?;
    let scratch_text = scratch.to_string_lossy().into_owned();
    let source_text = context.root.to_string_lossy().into_owned();
    let cargo_text = context.cargo.to_string_lossy().into_owned();
    let compiler_text = context.compiler.to_string_lossy().into_owned();
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["status"]), "status", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-list", &scratch_text, "."]), "fs-list", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/input.txt", "alpha beta"]), "fs-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-read", &scratch_text, "state/input.txt", "5"]), "fs-read", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-slice", &scratch_text, "state/input.txt", "1", "1"]), "fs-slice", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-copy", &scratch_text, "state/input.txt", "state/copied.txt"]), "fs-copy", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "product-diff", &scratch_text, &scratch_text]), "product-diff-self", true)?;
    fs::write(scratch.join("b.txt"), b"old\n").map_err(|error| error.to_string())?;
    let batch_plan_text = context.root.join("src/filesystem_batch_write_plan_probe/main.spi").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-batch-write", "preview", &scratch_text, &batch_plan_text]), "batch-write-preview", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-batch-write", "apply", &scratch_text, &batch_plan_text]), "batch-write-apply", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-batch-write", "apply", &scratch_text, &batch_plan_text]), "batch-write-stale", false)?;
    if fs::read_to_string(scratch.join("a.txt")).map_err(|error| error.to_string())? != "alpha" || fs::read_to_string(scratch.join("b.txt")).map_err(|error| error.to_string())? != "beta" { return Err("batch-write committed bytes mismatch".to_owned()); }
    fs::write(scratch.join("b2.txt"), b"old2").map_err(|error| error.to_string())?;
    let batch_rollback_plan_text = context.root.join("src/filesystem_batch_write_plan_probe/rollback_plan.spi").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-batch-write", "apply", &scratch_text, &batch_rollback_plan_text]), "batch-write-rollback", false)?;
    if fs::read_to_string(scratch.join("b2.txt")).map_err(|error| error.to_string())? != "old2" || scratch.join("bad.spi").exists() { return Err("batch-write rollback incomplete".to_owned()); }
    fs::write(scratch.join("source.txt"), b"alpha").map_err(|error| error.to_string())?; fs::write(scratch.join("mode.txt"), b"mode").map_err(|error| error.to_string())?;
    #[cfg(unix)] { use std::os::unix::fs::PermissionsExt; fs::set_permissions(scratch.join("mode.txt"), std::fs::Permissions::from_mode(0o644)).map_err(|error| error.to_string())?; }
    let fs_actions_plan_text = context.root.join("src/filesystem_action_batch_plan_probe/main.spi").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-actions", "preview", &scratch_text, &fs_actions_plan_text]), "fs-actions-preview", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-actions", "apply", &scratch_text, &fs_actions_plan_text]), "fs-actions-apply", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-actions", "apply", &scratch_text, &fs_actions_plan_text]), "fs-actions-stale", false)?;
    if !scratch.join("newdir").is_dir() || fs::read_to_string(scratch.join("copy.txt")).map_err(|error| error.to_string())? != "alpha" { return Err("fs-actions committed surface mismatch".to_owned()); }
    #[cfg(unix)] { use std::os::unix::fs::PermissionsExt; let observed = fs::metadata(scratch.join("mode.txt")).map_err(|error| error.to_string())?.permissions().mode() & 0o7777; if observed != 0o755 { return Err(format!("fs-actions chmod mismatch: {observed:o}")); } }
    #[cfg(unix)] { if fs::read_link(scratch.join("link.txt")).map_err(|error| error.to_string())?.as_path() != Path::new("source.txt") { return Err("fs-actions symlink mismatch".to_owned()); } }
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "source-recovery-diff", &source_text, &source_text]), "source-recovery-self", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-search", &scratch_text, "state", "alpha"]), "fs-search", true)?;
    let copied = scratch.join("state/copied.txt").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "hash", &copied]), "hash", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/oracle.txt", "same text"]), "diff-oracle-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/direct.txt", "same text"]), "diff-direct-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/oracle.txt", "state/direct.txt", "state/diff.receipt"]), "differential-success", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/direct.txt", "--replace-existing", "--", "different"]), "diff-mismatch-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/oracle.txt", "state/direct.txt", "state/diff-fail.receipt"]), "differential-failure", false)?;
    fs::create_dir_all(scratch.join("state/target/cache")).map_err(|error| error.to_string())?;
    fs::write(scratch.join("state/target/cache/item"), b"cache").map_err(|error| error.to_string())?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "prune-build-cache", &scratch_text, "state/target"]), "prune-cache-present", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "prune-build-cache", &scratch_text, "state/target"]), "prune-cache-missing", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "run", &source_text, "--timeout-ms", "30000", &cargo_text, "--version"]), "run-cargo-version", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "run", &source_text, "--timeout-ms", "30000", &compiler_text, "--version"]), "run-compiler-version", true)?;
    coverage_toolchain_smoke(context, &scratch, &cargo_text, &compiler_text)?;
    let restart_bundle = scratch.join("state/restart-bundle.zip");
    fs::write(&restart_bundle, b"restart-bundle").map_err(|error| error.to_string())?;
    let restart_bundle_text = restart_bundle.to_string_lossy().into_owned();
    let restart_migration = coverage_smoke_current_migration(context)?;
    let restart_migration_text = restart_migration.to_string();
    let restart_mismatch_text = restart_migration.saturating_sub(1).to_string();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "restart-baton", &scratch_text, "state/restart-baton.spi", &restart_bundle_text, &restart_migration_text, "COVERAGE-RESTART-BATON", "src/legacy_operations_entry/restart_baton_terminal.spi", "bundle-check"]), "restart-baton-success", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "restart-baton", &scratch_text, "state/restart-baton-mismatch.spi", &restart_bundle_text, &restart_mismatch_text, "COVERAGE-RESTART-BATON", "src/legacy_operations_entry/restart_baton_terminal.spi", "bundle-check"]), "restart-baton-mismatch", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "legacy-surface"]), "legacy-surface", true)?;
    let install_source = scratch.join("state/install-source"); fs::copy(context.binary, &install_source).map_err(|error| error.to_string())?; fs::set_permissions(&install_source, fs::metadata(context.binary).map_err(|error| error.to_string())?.permissions()).map_err(|error| error.to_string())?;
    let install_source_text = install_source.to_string_lossy().into_owned(); let install_destination_text = scratch.join("state/install-destination").to_string_lossy().into_owned(); let install_link_text = scratch.join("state/install-link").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "install-self", &install_source_text, &install_destination_text, &install_link_text]), "install-self-success", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-chmod", &scratch_text, "state/input.txt", "0600"]), "legacy-fs-chmod", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-symlink", &scratch_text, "state/input.txt", "state/input-link"]), "legacy-fs-symlink", true)?;
    fs::create_dir_all(scratch.join("tree-source")).map_err(|error| error.to_string())?; fs::write(scratch.join("tree-source/item.txt"), b"tree").map_err(|error| error.to_string())?;
    let tree_source_text = scratch.join("tree-source").to_string_lossy().into_owned(); let tree_copy_text = scratch.join("tree-copy").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-copy-tree", &tree_source_text, &tree_copy_text]), "legacy-fs-copy-tree", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "command-capture", &scratch_text, "state/command.receipt", "30000", "/bin/echo", "hello"]), "legacy-command-capture", true)?;
    let probes = [("probe-release-hygiene","eoie-release-hygiene","hygiene-policy-probe"),("probe-self-install","legacy-capability-probes","self-install-policy-probe"),("probe-restart-baton","legacy-capability-probes","restart-baton-policy-probe"),("probe-bundle-negative","bundle-lifecycle-domain","archive_extract_negative"),("probe-bundle-policy","bundle-lifecycle-domain","archive_extract_policy_probe"),("probe-retention-negative","bundle-retention-domain","retention_negative"),("probe-retention-policy","bundle-retention-domain","retention_policy_probe"),("probe-inspection-negative","inspection-negative","inspection-negative"),("probe-inspection-policy","inspection-policy-probe","inspection-policy-probe"),("probe-process-policy","process-batch-plan-policy-probe","process-batch-plan-policy-probe"),("probe-process-resume","process-batch-plan-resume-probe","process-batch-plan-resume-probe"),("probe-toolchain-policy","eoie-toolchain-argument-policy-probe","eoie-toolchain-argument-policy-probe"),("probe-toolchain-agile","eoie-toolchain-argument-agile-probe","eoie-toolchain-argument-agile-probe"),("probe-bootstrap-policy","eoie-bootstrap-policy-probe","eoie-bootstrap-policy-probe"),("probe-bootstrap-root","eoie-bootstrap-probe","eoie-bootstrap-probe"),("probe-domain","eoie-domain-probe","eoie-domain-probe"),("probe-retention-physical-negative","eoie-bundle-retention","retention_physical_negative"),("probe-retention-physical","eoie-bundle-retention","retention_physical_probe"),("probe-process-stream-negative","eoie-process","process_streaming_negative"),("probe-process-stream-policy","eoie-process","process_streaming_policy_probe"),("probe-patch-batch","eoie-patch-batch","eoie-patch-batch"),("probe-policy","eoie-policy-probe","eoie-policy-probe"),("probe-rust-env","eoie-rust-std-env","eoie-rust-std-env-probe"),("probe-rust-fs","eoie-rust-std-fs","eoie-rust-std-fs"),("probe-rust-fs-negative","eoie-rust-std-fs","eoie-rust-std-fs-negative"),("probe-rust-fs-rooted","eoie-rust-std-fs","eoie-rust-std-fs-rooted"),("probe-rust-fs-rooted-negative","eoie-rust-std-fs","eoie-rust-std-fs-rooted-negative"),("probe-rust-fs-rooted-policy","eoie-rust-std-fs","eoie-rust-std-fs-rooted-policy"),("probe-toolchain-command-negative","toolchain-command-domain","toolchain-command-negative")];
    for (phase, package, example) in probes {
        let args = ["run","--offline","--locked","--release","-p",package,"--example",example];
        coverage_smoke_cargo(context, &args, phase)?;
    }
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "run", &source_text, "--timeout-ms", "30000", "/bin/false"]), "run-expected-failure", false)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["help"]), "help-public", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["unknown-verb"]), "unknown-verb", false)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["status", "extra"]), "status-arity", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "unknown-proxy"]), "unknown-proxy", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-read", &scratch_text, "state/missing.txt"]), "fs-read-missing", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "../escape.txt", "bad"]), "fs-write-escape", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-remove", &scratch_text, "state/missing.txt"]), "fs-remove-missing", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-remove-tree", &scratch_text, "state/input.txt"]), "fs-remove-tree-file", false)?;
    let missing_hash = scratch.join("state/missing.txt").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "hash", &missing_hash]), "hash-missing", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "prune-build-cache", &scratch_text, "state/not-cache"]), "prune-cache-suffix", false)?;
    let patch_root = scratch.join("patch");
    fs::create_dir_all(patch_root.join("state")).map_err(|error| error.to_string())?;
    fs::write(patch_root.join("state/package.spiproj"), b"modules:\n    plan\n").map_err(|error| error.to_string())?;
    fs::write(patch_root.join("state/value.txt"), b"before").map_err(|error| error.to_string())?;
    fs::write(patch_root.join("state/plan.spi"), b"inl main () : i32 =\n    $\"RustPlanOp(\\\"patch-exact\\\",\\\"state/value.txt\\\",\\\"before\\\",\\\"after\\\",\\\"write\\\")\" : ()\n    0i32\n").map_err(|error| error.to_string())?;
    let patch_text = patch_root.to_string_lossy().into_owned();
    let plan_text = patch_root.join("state/plan.spi").to_string_lossy().into_owned();
    coverage_smoke_exec(context, &patch_root, &coverage_smoke_args(&["patch", "apply", &patch_text, &plan_text]), "patch-success", true)?;
    coverage_smoke_exec(context, &patch_root, &coverage_smoke_args(&["patch", "apply", &patch_text, &plan_text]), "patch-repeat-failure", false)?;
    let agile_root = scratch.join("agile");
    coverage_smoke_copy_state(&context.root.join("state"), &agile_root.join("state"))?;
    let agile_text = agile_root.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &agile_root, &coverage_smoke_args(&["agile", "list", &agile_text]), "agile-list", true)?;
    coverage_smoke_exec(context, &agile_root, &coverage_smoke_args(&["agile", "set", &agile_text, "COVERAGE-SMOKE-MISSING", "90", "Active"]), "agile-set-missing", false)?;
    coverage_smoke_exec(context, &agile_root, &coverage_smoke_args(&["agile", "begin", &agile_text, ""]), "agile-begin-empty-title", false)?;
    let missing_agile_text = scratch.join("missing-agile").to_string_lossy().into_owned(); coverage_smoke_exec(context, &agile_root, &coverage_smoke_args(&["agile", "check", &missing_agile_text]), "agile-check-missing-root", false)?;
    let lcov_test = scratch.join("test.lcov");
    let lcov_smoke = scratch.join("smoke.lcov");
    fs::write(&lcov_test, b"SF:src/example.rs\nDA:1,1\nDA:2,0\nend_of_record\n").map_err(|error| error.to_string())?;
    fs::write(&lcov_smoke, b"SF:src/example.rs\nDA:1,1\nDA:2,1\nend_of_record\n").map_err(|error| error.to_string())?;
    coverage_export_union_smoke(context, &scratch, &lcov_test, &lcov_smoke)?;
    let lcov_test_text = lcov_test.to_string_lossy().into_owned();
    let lcov_smoke_text = lcov_smoke.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "coverage-assess", &lcov_test_text, &lcov_smoke_text, "500", "500", "500"]), "coverage-assess-success", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "coverage-assess", &lcov_test_text, &lcov_smoke_text, "1000", "1000", "1000"]), "coverage-assess-failure", false)?;
    let archive = scratch.join("bundle.zip");
    let archive_text = archive.to_string_lossy().into_owned();
    let rehydrated = scratch.join("rehydrated");
    let rehydrated_text = rehydrated.to_string_lossy().into_owned();
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "prune-compiler-sidecars", &source_text]), "bundle-prune-sidecars", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "check", &source_text]), "bundle-check", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "create", &source_text, &archive_text]), "bundle-create", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "verify", &archive_text]), "bundle-verify", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "rehydrate", &archive_text, &rehydrated_text]), "bundle-rehydrate", true)?;
    let inside_archive = context.root.join("state/inside.zip").to_string_lossy().into_owned();
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "create", &source_text, &inside_archive]), "bundle-output-inside-root", false)?;
    let invalid_archive = scratch.join("invalid.zip");
    fs::write(&invalid_archive, b"not-a-zip").map_err(|error| error.to_string())?;
    let invalid_archive_text = invalid_archive.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["bundle", "verify", &invalid_archive_text]), "bundle-invalid-zip", false)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["bundle", "rehydrate", &archive_text, &rehydrated_text]), "bundle-existing-destination", false)?;
    let extracted = scratch.join("zip-extracted");
    let extracted_text = extracted.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "zip-extract", &archive_text, &extracted_text]), "zip-extract", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["bundle", "check", &scratch_text]), "bundle-invalid-root", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-remove", &scratch_text, "state/copied.txt"]), "fs-remove", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-remove-tree", &scratch_text, "zip-extracted"]), "fs-remove-tree", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "source-stats", &source_text]), "source-stats", true)?;
    coverage_smoke_exec(context, context.root, &coverage_smoke_args(&["proxy", "spiral-session-shutdown", &compiler_text, "30000"]), "spiral-shutdown", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/input.txt", "--replace-existing", "--", "alpha beta gamma"]), "fs-write-overwrite", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-read", &scratch_text, "state/input.txt"]), "fs-read-full", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-copy", &scratch_text, "state/input.txt", "state/copied.txt"]), "fs-copy-recreate", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-copy", &scratch_text, "state/input.txt", "state/copied.txt"]), "fs-copy-overwrite", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/oracle.txt", "--replace-existing", "--", "line-one\r\nline-two   " ]), "diff-normalized-oracle-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "fs-write", &scratch_text, "state/direct.txt", "--replace-existing", "--", "line-one\nline-two"]), "diff-normalized-direct-write", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/oracle.txt", "state/direct.txt", "state/diff-normalized.receipt"]), "differential-normalized-success", true)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/oracle.txt", "state/direct.txt"]), "differential-arity-failure", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/missing.txt", "state/direct.txt", "state/diff-missing.receipt"]), "differential-missing-failure", false)?;
    coverage_smoke_exec(context, &scratch, &coverage_smoke_args(&["proxy", "differential-compare", &scratch_text, "state/oracle.txt", "state/direct.txt", "../escape.receipt"]), "differential-receipt-escape", false)?;
    coverage_smoke_exec(context, &rehydrated, &coverage_smoke_args(&["bundle", "check", &rehydrated_text]), "bundle-check-rehydrated", true)?;
    let rehydrated_archive = scratch.join("bundle-rehydrated.zip");
    let rehydrated_archive_text = rehydrated_archive.to_string_lossy().into_owned();
    coverage_smoke_exec(context, &rehydrated, &coverage_smoke_args(&["bundle", "create", &rehydrated_text, &rehydrated_archive_text]), "bundle-create-rehydrated", true)?;
    coverage_smoke_exec(context, &rehydrated, &coverage_smoke_args(&["bundle", "verify", &rehydrated_archive_text]), "bundle-verify-rehydrated", true)?;
    let _ = fs::remove_dir_all(&scratch);
    println!("eoie coverage smoke ok phases=123 root={}", context.root.display());
    Ok(()) // coverage_smoke_run
} // coverage_smoke_run
fn spiral_main() -> i32 {
    0i32
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
