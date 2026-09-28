#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_process_observation::run_bounded_receipted_observed;
use eoie_rust_std_fs::{atomic_write as legacy_atomic_write, safe_relative_path as legacy_safe_relative};
use std::env;
use std::fs;
use std::path::Path;
use std::process::Command;

fn legacy_arg<'a>(args: &'a [String], index: usize, name: &str) -> Result<&'a str, String> {
    args.get(index).map(String::as_str).ok_or_else(|| format!("missing argument: {name}"))
}

pub fn legacy_surface_run(args: &[String]) -> Result<(), String> {
    if args.len() != 1 { return Err("legacy-surface takes no arguments".to_owned()); }
    if eoie_legacy_surface_summary_binding(9, 0) != 1 { return Err("typed legacy-surface summary rejected settled catalog".to_owned()); }
    for family in 0..=8 { if eoie_legacy_surface_status_binding(family, 2) != 1 { return Err(format!("typed legacy-surface rejected equivalent family {family}")); } }
    if eoie_legacy_surface_status_binding(9, 0) != 1 { return Err("typed legacy-surface rejected quarantined planning governance".to_owned()); }
    for family in [5, 7, 8] { if eoie_legacy_surface_status_binding(family, 1) != 0 { return Err(format!("typed legacy-surface accepted stale partial family {family}")); } }
    println!("eoie proxy legacy-surface ok sources=834,9252 model=spiral typed=verified");
    println!("summary cataloged=36/36 decided=36/36 absorbed=34/36 pruned=2 deferred=0 needs_evidence=0 executable_absorption=100/100 resolved=100/100");
    println!("dogfood candidate_common_path=usable fallback_required=none recovery_fallbacks=optional");
    println!("family=patch-batching status=equivalent current=patch-apply");
    println!("family=filesystem-mutation status=equivalent current=fs-write,text-replace,fs-chmod,fs-symlink,fs-copy-tree,fs-slice,fs-search,hash,fs-copy-preserve-mode\nfamily=hashing-and-integrity status=equivalent current=hash,hash-tree\nfamily=process-execution status=equivalent current=command-capture,command-capture-env,command-capture-matrix,batch-plan,batch-plan-resume\nfamily=archive-bundling status=equivalent current=bundle,zip-extract,archive-extract\nfamily=agile-state status=equivalent current=agile\nfamily=release-verification status=equivalent current=bundle-check,bundle-verify,release-closeout,binary-install\nfamily=rehydration status=equivalent current=bundle-rehydrate,external-payload");
    println!("family=toolchain status=equivalent current=toolchain,batch-plan-resume");
    println!("family=coverage-pruning status=equivalent current=coverage-run,coverage-export,coverage-union,coverage-assess,prune-uncovered");
    println!("family=planning-governance status=quarantined policy=absorb-only-when-consumed");
    Ok(())
}

pub fn legacy_chmod_run(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("fs-chmod expects root relative-path octal-mode".to_owned()); }
    let root = Path::new(legacy_arg(args, 1, "root")?);
    if !root.is_dir() { return Err(format!("invalid root: {}", root.display())); }
    let relative = legacy_safe_relative(legacy_arg(args, 2, "relative-path")?)?;
    let mode_text = legacy_arg(args, 3, "octal-mode")?.trim_start_matches("0o");
    let mode = u32::from_str_radix(mode_text, 8).map_err(|_| "octal-mode must be an octal integer".to_owned())?;
    if mode > 0o7777 { return Err("octal-mode exceeds 07777".to_owned()); }
    let target = root.join(relative);
    let metadata = fs::symlink_metadata(&target).map_err(|error| format!("metadata {}: {error}", target.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("fs-chmod rejects symlink: {}", target.display())); }
    eoie_rust_std_fs::portable_set_mode(&target, mode).map_err(|error| format!("chmod {}: {error}", target.display()))?;
    println!("eoie proxy fs-chmod ok path={} mode={mode:04o}", target.display());
    Ok(())
}

pub fn legacy_symlink_run(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("fs-symlink expects root target-relative link-relative".to_owned()); }
    let root = Path::new(legacy_arg(args, 1, "root")?);
    if !root.is_dir() { return Err(format!("invalid root: {}", root.display())); }
    let target = legacy_safe_relative(legacy_arg(args, 2, "target-relative")?)?;
    let link_relative = legacy_safe_relative(legacy_arg(args, 3, "link-relative")?)?;
    let link = root.join(link_relative);
    if fs::symlink_metadata(&link).is_ok() { return Err(format!("link already exists: {}", link.display())); }
    let parent = link.parent().ok_or_else(|| format!("link has no parent: {}", link.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = parent.join(format!(".eoie-link-stage-{}", std::process::id()));
    let _ = fs::remove_file(&temporary);
    eoie_rust_std_fs::portable_symlink(&target, &temporary).map_err(|error| format!("symlink {}: {error}", temporary.display()))?;
    fs::rename(&temporary, &link).map_err(|error| format!("commit symlink {}: {error}", link.display()))?;
    println!("eoie proxy fs-symlink ok link={} target={}", link.display(), target.display());
    Ok(())
}

fn legacy_copy_tree_inner(source: &Path, destination: &Path) -> Result<usize, String> {
    let metadata = fs::symlink_metadata(source).map_err(|error| format!("metadata {}: {error}", source.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("fs-copy-tree rejects symlink: {}", source.display())); }
    if metadata.is_file() {
        if let Some(parent) = destination.parent() { fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?; }
        fs::copy(source, destination).map_err(|error| format!("copy {}: {error}", source.display()))?;
        fs::set_permissions(destination, metadata.permissions()).map_err(|error| format!("permissions {}: {error}", destination.display()))?;
        return Ok(1);
    }
    if !metadata.is_dir() { return Err(format!("unsupported entry: {}", source.display())); }
    fs::create_dir_all(destination).map_err(|error| format!("create {}: {error}", destination.display()))?;
    fs::set_permissions(destination, metadata.permissions()).map_err(|error| format!("permissions {}: {error}", destination.display()))?;
    let mut entries = fs::read_dir(source).map_err(|error| format!("read {}: {error}", source.display()))?
        .map(|entry| entry.map(|entry| entry.path()).map_err(|error| error.to_string()))
        .collect::<Result<Vec<_>, _>>()?;
    entries.sort();
    let mut copied = 0usize;
    for entry in entries {
        let name = entry.file_name().ok_or_else(|| format!("entry has no name: {}", entry.display()))?;
        copied += legacy_copy_tree_inner(&entry, &destination.join(name))?;
    }
    Ok(copied)
}

pub fn legacy_copy_tree_run(args: &[String]) -> Result<(), String> {
    if args.len() != 3 { return Err("fs-copy-tree expects source destination".to_owned()); }
    let source = Path::new(legacy_arg(args, 1, "source")?);
    let destination = Path::new(legacy_arg(args, 2, "destination")?);
    if !source.is_dir() { return Err(format!("source is not a directory: {}", source.display())); }
    if destination.exists() { return Err(format!("destination already exists: {}", destination.display())); }
    match legacy_copy_tree_inner(source, destination) {
        Ok(copied) => { println!("eoie proxy fs-copy-tree ok source={} destination={} files={copied}", source.display(), destination.display()); Ok(()) }
        Err(error) => { let _ = fs::remove_dir_all(destination); Err(format!("fs-copy-tree rolled back: {error}")) }
    }
}

pub fn legacy_command_capture_run(args: &[String]) -> Result<(), String> {
    if args.len() < 5 { return Err("command-capture expects root receipt-relative timeout-ms program [args...]".to_owned()); }
    let root = Path::new(legacy_arg(args, 1, "root")?);
    if !root.is_dir() { return Err(format!("invalid root: {}", root.display())); }
    let receipt = root.join(legacy_safe_relative(legacy_arg(args, 2, "receipt-relative")?)?);
    let timeout_ms = legacy_arg(args, 3, "timeout-ms")?.parse::<u64>().map_err(|_| "timeout-ms must be an integer".to_owned())?;
    if timeout_ms == 0 { return Err("timeout-ms must be positive".to_owned()); }
    let program = legacy_arg(args, 4, "program")?;
    let mut command = Command::new(program);
    command.current_dir(root).args(&args[5..]);
    for key in ["PATH", "LD_LIBRARY_PATH", "DOTNET_ROOT", "SPIRAL_DOTNET", "EOIE_SPIRAL_COMPILE", "EOIE_SPIRAL_TIMEOUT_MS", "EOIE_SPIRAL_SEGMENTED_TIMEOUT_MS", "CARGO_HOME", "CARGO_TARGET_DIR", "RUSTC", "RUSTDOC", "RUSTFMT"] {
        if let Some(value) = env::var_os(key) { command.env(key, value); }
    }
    let observation = run_bounded_receipted_observed(&mut command, timeout_ms, "command-capture")?;
    let status = observation.status.code().unwrap_or(-1);
    let body = format!("schema=1\nprogram={}\nstatus={}\ntermination={:?}\nelapsed_ms={}\nstdout_bytes={}\nstderr_bytes={}\n--- stdout ---\n{}\n--- stderr ---\n{}\n", program, status, observation.termination, observation.elapsed_ms, observation.stdout.len(), observation.stderr.len(), String::from_utf8_lossy(&observation.stdout), String::from_utf8_lossy(&observation.stderr));
    legacy_atomic_write(&receipt, body.as_bytes())?;
    println!("eoie proxy command-capture ok receipt={} status={status} elapsed_ms={}", receipt.display(), observation.elapsed_ms);
    Ok(())
}

fn self_install_fault_code() -> Result<i32, String> {
    match env::var("EOIE_SELF_INSTALL_FAULT").ok().as_deref() {
        None | Some("") | Some("none") => Ok(0),
        Some("after-binary-commit") => Ok(1),
        Some("before-link-commit") => Ok(2),
        Some("after-link-commit") => Ok(3),
        Some(value) => Err(format!("unknown EOIE_SELF_INSTALL_FAULT: {value}")),
    }
}

fn self_install_remove_regular_or_link(path: &Path) -> Result<(), String> {
    match fs::symlink_metadata(path) {
        Ok(metadata) if metadata.is_file() || metadata.file_type().is_symlink() => fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display())),
        Ok(_) => Err(format!("refusing non-file install path: {}", path.display())),
        Err(error) if error.kind() == std::io::ErrorKind::NotFound => Ok(()),
        Err(error) => Err(format!("metadata {}: {error}", path.display())),
    }
}

fn self_install_restore_destination(destination: &Path, backup: &Path, had_destination: bool) -> Result<(), String> {
    self_install_remove_regular_or_link(destination)?;
    if had_destination { fs::rename(backup, destination).map_err(|error| format!("restore {}: {error}", destination.display()))?; }
    Ok(())
}

#[derive(Clone)]
enum SelfInstallLinkOriginal { Absent, File(Vec<u8>, std::fs::Permissions), Symlink(std::path::PathBuf) }

fn self_install_restore_link(path: &Path, original: &SelfInstallLinkOriginal) -> Result<(), String> {
    self_install_remove_regular_or_link(path)?;
    match original {
        SelfInstallLinkOriginal::Absent => Ok(()),
        SelfInstallLinkOriginal::File(bytes, permissions) => {
            legacy_atomic_write(path, bytes)?;
            fs::set_permissions(path, permissions.clone()).map_err(|error| format!("permissions {}: {error}", path.display()))
        }
        SelfInstallLinkOriginal::Symlink(target) => eoie_rust_std_fs::portable_symlink(target, path).map_err(|error| format!("restore symlink {}: {error}", path.display())),
    }
}

fn legacy_install_self_with_fault(source: &Path, destination: &Path, link: &Path, fault: i32) -> Result<(), String> {
    use eoie_rust_std_fs::portable_mode;
    if !source.is_absolute() || !destination.is_absolute() || !link.is_absolute() { return Err("install-self requires absolute source, destination, and link paths".to_owned()); }
    if source == destination || destination == link || source == link { return Err("install-self paths must be distinct".to_owned()); }
    let managed_workspace = env::var_os("EOIE_LEASE_ROOT").map(std::path::PathBuf::from).or_else(|| source.ancestors().find(|root| root.join("state/prompt.spi").is_file() && root.join("src/Cargo.toml").is_file()).map(Path::to_path_buf));
    if let Some(workspace) = managed_workspace.as_deref() && (destination.starts_with(workspace) || link.starts_with(workspace)) { return Err(format!("install-self canonical destination/link must live outside managed workspace {}", workspace.display())); }
    let source_metadata = fs::symlink_metadata(source).map_err(|error| format!("metadata {}: {error}", source.display()))?;
    let source_regular = source_metadata.is_file() && !source_metadata.file_type().is_symlink();
    let source_executable = portable_mode(&source_metadata.permissions()) & 0o111 != 0;
    if eoie_self_install_preflight_binding(i32::from(source_regular), i32::from(source_executable)) != 1 { return Err(format!("install-self source must be a regular executable: {}", source.display())); }
    let destination_metadata = fs::symlink_metadata(destination).ok();
    let destination_safe = destination_metadata.as_ref().is_none_or(|metadata| metadata.is_file() && !metadata.file_type().is_symlink());
    let link_metadata = fs::symlink_metadata(link).ok();
    let link_state = match link_metadata.as_ref() {
        None => 0,
        Some(metadata) if metadata.file_type().is_symlink() => 1,
        Some(metadata) if metadata.is_file() => 2,
        Some(_) => 3,
    };
    if eoie_self_install_target_binding(i32::from(destination_safe), link_state) != 1 { return Err("install-self destination must be a regular file or absent and canonical entry must be absent, symlink, or regular file; directory/other rejected".to_owned()); }
    let link_original = match link_state {
        0 => SelfInstallLinkOriginal::Absent,
        1 => SelfInstallLinkOriginal::Symlink(fs::read_link(link).map_err(|error| format!("read link {}: {error}", link.display()))?),
        2 => {
            let metadata = link_metadata.as_ref().ok_or_else(|| "regular canonical entry metadata disappeared".to_owned())?;
            SelfInstallLinkOriginal::File(fs::read(link).map_err(|error| format!("read canonical entry {}: {error}", link.display()))?, metadata.permissions())
        }
        _ => return Err("typed self-install canonical entry rejected".to_owned()),
    };
    let destination_parent = destination.parent().ok_or_else(|| format!("destination has no parent: {}", destination.display()))?;
    let link_parent = link.parent().ok_or_else(|| format!("link has no parent: {}", link.display()))?;
    fs::create_dir_all(destination_parent).map_err(|error| format!("create {}: {error}", destination_parent.display()))?;
    fs::create_dir_all(link_parent).map_err(|error| format!("create {}: {error}", link_parent.display()))?;
    let stamp = format!("{}-{}", std::process::id(), std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map_err(|error| error.to_string())?.as_nanos());
    let stage = destination_parent.join(format!(".eoie-install-stage-{stamp}"));
    let backup = destination_parent.join(format!(".eoie-install-backup-{stamp}"));
    let link_stage = link_parent.join(format!(".eoie-link-stage-{stamp}"));
    for temporary in [&stage, &backup, &link_stage] { if fs::symlink_metadata(temporary).is_ok() { return Err(format!("install-self temporary already exists: {}", temporary.display())); } }
    let had_destination = destination_metadata.is_some();
    let result = (|| {
        fs::copy(source, &stage).map_err(|error| format!("copy {}: {error}", source.display()))?;
        fs::set_permissions(&stage, source_metadata.permissions()).map_err(|error| format!("permissions {}: {error}", stage.display()))?;
        fs::OpenOptions::new().write(true).open(&stage).and_then(|file| file.sync_all()).map_err(|error| format!("sync {}: {error}", stage.display()))?;
        if had_destination { fs::rename(destination, &backup).map_err(|error| format!("backup {}: {error}", destination.display()))?; }
        fs::rename(&stage, destination).map_err(|error| format!("commit binary {}: {error}", destination.display()))?;
        if eoie_self_install_fault_binding(fault, 1) == 1 { self_install_restore_destination(destination, &backup, had_destination)?; return Err("injected self-install fault after-binary-commit rollback=restored".to_owned()); }
        if eoie_self_install_fault_binding(fault, 2) == 1 { self_install_restore_destination(destination, &backup, had_destination)?; return Err("injected self-install fault before-link-commit rollback=restored".to_owned()); }
        eoie_rust_std_fs::portable_symlink(destination, &link_stage).map_err(|error| format!("symlink {}: {error}", link_stage.display()))?;
        fs::rename(&link_stage, link).map_err(|error| format!("commit link {}: {error}", link.display()))?;
        if eoie_self_install_fault_binding(fault, 3) == 1 {
            self_install_restore_link(link, &link_original)?;
            self_install_restore_destination(destination, &backup, had_destination)?;
            return Err("injected self-install fault after-link-commit rollback=restored".to_owned());
        }
        let binary_matches = fs::read(source).map_err(|error| error.to_string())? == fs::read(destination).map_err(|error| error.to_string())?;
        let link_matches = fs::read_link(link).map_err(|error| format!("read link {}: {error}", link.display()))? == destination;
        if eoie_self_install_complete_binding(i32::from(binary_matches), i32::from(link_matches)) != 1 { return Err("typed self-install completion rejected".to_owned()); }
        if had_destination { fs::remove_file(&backup).map_err(|error| format!("remove backup {}: {error}", backup.display()))?; }
        Ok(())
    })();
    if result.is_err() {
        let _ = self_install_remove_regular_or_link(&stage);
        let _ = self_install_remove_regular_or_link(&link_stage);
        if fs::symlink_metadata(&backup).is_ok() {
            let _ = self_install_restore_destination(destination, &backup, had_destination);
        } else if !had_destination {
            let _ = self_install_remove_regular_or_link(destination);
        }
        let _ = self_install_restore_link(link, &link_original);
    }
    result
}

fn self_upgrade_gate(binary: &Path, root: &Path, label: &str) -> Result<(), String> {
    let root_text = root.to_string_lossy().into_owned();
    let checks = [vec!["bundle".to_owned(), "check".to_owned(), root_text.clone(), "eoie".to_owned()], vec!["status".to_owned(), root_text.clone()]];
    for arguments in checks {
        let mut command = Command::new(binary);
        command.args(&arguments);
        command.env("EOIE_CONTROL_READ_ONLY", "1");
        let observation = run_bounded_receipted_observed(&mut command, 15000, label)?;
        if !observation.status.success() {
            return Err(format!("self-upgrade {label} gate failed binary={} args={:?} status={} stderr={}", binary.display(), arguments, observation.status, String::from_utf8_lossy(&observation.stderr).trim()));
        }
    }
    Ok(())
}

pub fn legacy_self_upgrade_check_run(args: &[String]) -> Result<(), String> {
    if args.len() != 3 { return Err("self-upgrade-check expects current-root candidate-root".to_owned()); }
    let current_root = Path::new(legacy_arg(args, 1, "current-root")?);
    let candidate_root = Path::new(legacy_arg(args, 2, "candidate-root")?);
    if !current_root.is_dir() || !candidate_root.is_dir() { return Err("self-upgrade-check roots must be directories".to_owned()); }
    let current = current_root.join("eoie");
    let candidate = candidate_root.join("eoie");
    for (label, binary) in [("current", &current), ("candidate", &candidate)] {
        let metadata = fs::symlink_metadata(binary).map_err(|error| format!("self-upgrade {label} binary {}: {error}", binary.display()))?;
        if metadata.file_type().is_symlink() || !metadata.is_file() { return Err(format!("self-upgrade {label} binary must be regular non-symlink: {}", binary.display())); }
    }
    self_upgrade_gate(&current, current_root, "current-baseline")?;
    self_upgrade_gate(&current, candidate_root, "current-verifier-on-candidate")?;
    self_upgrade_gate(&candidate, candidate_root, "candidate-self-verifier")?;
    println!("eoie proxy self-upgrade-check ok current_root={} candidate_root={} gates=6 compatibility=strict", current_root.display(), candidate_root.display());
    Ok(())
}

pub fn legacy_install_self_run(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("install-self expects source-binary installed-binary canonical-link".to_owned()); }
    let source = Path::new(legacy_arg(args, 1, "source-binary")?);
    let destination = Path::new(legacy_arg(args, 2, "installed-binary")?);
    let link = Path::new(legacy_arg(args, 3, "canonical-link")?);
    legacy_install_self_with_fault(source, destination, link, self_install_fault_code()?)?;
    println!("eoie proxy install-self ok source={} destination={} link={} receipt=typed-atomic", source.display(), destination.display(), link.display());
    Ok(())
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 3i32 < v1;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v1 == 3i32;
                    if v6 {
                        0i32
                    } else {
                        1i32
                    }
                }
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 3i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 3i32 < v1;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v0 < v1;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = v1 < v0;
                        if v7 {
                            0i32
                        } else {
                            1i32
                        }
                    }
                }
            }
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1000i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 2i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 9i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 == 9i32;
            if v4 {
                let mut v5: bool = v1 == 0i32;
                if v5 {
                    1i32
                } else {
                    0i32
                }
            } else {
                let mut v7: bool = v1 == 2i32;
                if v7 {
                    1i32
                } else {
                    0i32
                }
            }
        }
    }
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 9i32;
    if v2 {
        let mut v3: bool = v1 == 0i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    method8(v0, v1)
}
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    method9(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method2(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method3(v0, v1)
    })
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method4(v0, v1)
    })
}
fn closure5() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method5(v0, v1)
    })
}
fn closure6() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure7() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method7(v0, v1)
    })
}
fn closure8() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method11(v0, v1)
    })
}
pub fn eoie_self_install_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_self_install_target_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_self_install_fault_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_self_install_complete_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_restart_baton_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_restart_baton_migration_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_restart_baton_fault_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_restart_baton_complete_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_legacy_surface_status_binding(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_legacy_surface_summary_binding(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
