#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(dead_code)]
use std::cell::RefCell;
use std::rc::Rc;
use std::fs;
use std::path::{Path, PathBuf};

fn hygiene_arg<'a>(args: &'a [String], index: usize, name: &str) -> Result<&'a str, String> {
    args.get(index).map(String::as_str).ok_or_else(|| format!("missing argument: {name}"))
}

fn compiler_sidecar(path: &Path) -> bool {
    let name = path.file_name().and_then(|value| value.to_str()).unwrap_or_default();
    let lexical = eoie_hygiene_name_classification(name) == 1;
    let c_with_spi = path.extension().and_then(|value| value.to_str()) == Some("c") && path.with_extension("spi").is_file();
    lexical || eoie_hygiene_secondary_binding(0, i32::from(c_with_spi)) == 1
}

fn release_root_transient_file(path: &Path) -> bool {
    path.file_name().and_then(|value| value.to_str()).is_some_and(|name| eoie_hygiene_name_classification(name) == 2)
}

fn release_root_transient_directory(path: &Path) -> bool {
    path.file_name().and_then(|value| value.to_str()).is_some_and(|name| eoie_hygiene_name_classification(name) == 3)
}

pub fn prune_release_transients(args: &[String]) -> Result<(), String> {
    if args.len() < 2 || args.len() > 3 { return Err("prune-release-transients expects root [--dry-run]".to_owned()); }
    let root = Path::new(hygiene_arg(args, 1, "root")?);
    if !root.is_dir() { return Err(format!("release hygiene root is not a directory: {}", root.display())); }
    let dry_run = match args.get(2).map(String::as_str) { None => false, Some("--dry-run") => true, Some(value) => return Err(format!("unknown release hygiene option: {value}")), };
    let mut files = Vec::new();
    let mut directories = Vec::new();
    for entry in fs::read_dir(root).map_err(|error| format!("read {}: {error}", root.display()))? {
        let entry = entry.map_err(|error| error.to_string())?;
        let path = entry.path();
        let metadata = fs::symlink_metadata(&path).map_err(|error| error.to_string())?;
        if metadata.file_type().is_symlink() { continue; }
        if metadata.is_file() && release_root_transient_file(&path) { files.push(path); }
        else if metadata.is_dir() && release_root_transient_directory(&path) { directories.push(path); }
    }
    files.sort();
    directories.sort();
    if !dry_run {
        for path in &files { fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?; }
        for path in &directories { fs::remove_dir_all(path).map_err(|error| format!("remove tree {}: {error}", path.display()))?; }
    }
    println!("eoie proxy prune-release-transients ok files={} directories={} removed={} dry_run={}", files.len(), directories.len(), if dry_run { 0 } else { files.len() + directories.len() }, i32::from(dry_run));
    Ok(())
}

fn collect_matching_regular_files(path: &Path, found: &mut Vec<PathBuf>, label: &str, matches: fn(&Path) -> bool) -> Result<(), String> {
    for entry in fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))? {
        let entry = entry.map_err(|error| error.to_string())?;
        let child = entry.path();
        let metadata = fs::symlink_metadata(&child).map_err(|error| error.to_string())?;
        if metadata.file_type().is_symlink() { return Err(format!("{label} refuses symlink: {}", child.display())); }
        if metadata.is_dir() { collect_matching_regular_files(&child, found, label, matches)?; }
        else if metadata.is_file() && matches(&child) { found.push(child); }
    }
    Ok(())
}

pub fn prune_compiler_sidecars(args: &[String]) -> Result<(), String> {
    if args.len() < 2 || args.len() > 3 {
        return Err("prune-compiler-sidecars expects root [--dry-run]".to_owned());
    }
    let root = Path::new(hygiene_arg(args, 1, "root")?);
    if !root.is_dir() {
        return Err(format!("release hygiene root is not a directory: {}", root.display()));
    }
    let dry_run = match args.get(2).map(String::as_str) {
        None => false,
        Some("--dry-run") => true,
        Some(value) => return Err(format!("unknown release hygiene option: {value}")),
    };
    let mut candidates = Vec::new();
    for relative in ["src", "state"] {
        let scope = root.join(relative);
        if scope.is_dir() { collect_matching_regular_files(&scope, &mut candidates, "release hygiene", compiler_sidecar)?; }
    }
    candidates.sort();
    if !dry_run {
        for path in &candidates {
            fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
        }
    }
    println!("eoie proxy prune-compiler-sidecars ok candidates={} removed={} dry_run={}", candidates.len(), if dry_run { 0 } else { candidates.len() }, i32::from(dry_run));
    Ok(())
}

use eoie_proxy_search::inspection_tree_sha256;
use eoie_rust_std_fs::{atomic_write, safe_relative_path};

fn incident_arg<'a>(args: &'a [String], index: usize, name: &str) -> Result<&'a str, String> { args.get(index).map(String::as_str).ok_or_else(|| format!("missing argument: {name}")) }

fn incident_leaf(path: &Path) -> Result<String, String> { path.file_name().and_then(|value| value.to_str()).map(str::to_owned).ok_or_else(|| format!("path has no UTF-8 leaf: {}", path.display())) }

fn incident_tree_hash(path: &Path) -> Result<String, String> { let parent = path.parent().ok_or_else(|| format!("path has no parent: {}", path.display()))?; let leaf = incident_leaf(path)?; inspection_tree_sha256(parent, &leaf) }

fn incident_copy_tree(source: &Path, destination: &Path) -> Result<(), String> { legacy_capability_domain::legacy_copy_tree_run(&["fs-copy-tree".to_owned(), source.display().to_string(), destination.display().to_string()]) }

fn incident_paths_separated(left: &Path, right: &Path) -> bool { left != right && !left.starts_with(right) && !right.starts_with(left) }

fn incident_parse_receipt(path: &Path) -> Result<(String, String), String> { let text = fs::read_to_string(path).map_err(|error| format!("read receipt {}: {error}", path.display()))?; if text.len() > 16 * 1024 { return Err("incident receipt exceeds 16 KiB".to_owned()); } let mut snapshot = None; let mut sha256 = None; for line in text.lines() { if let Some(value) = line.strip_prefix("snapshot=") { snapshot = Some(value.to_owned()); } else if let Some(value) = line.strip_prefix("sha256=") { sha256 = Some(value.to_owned()); } } Ok((snapshot.ok_or_else(|| "incident receipt missing snapshot".to_owned())?, sha256.ok_or_else(|| "incident receipt missing sha256".to_owned())?)) }

fn incident_snapshot(args: &[String]) -> Result<(), String> {
    if args.len() != 6 { return Err("incident-recovery snapshot expects root source-relative snapshot-parent-relative receipt-relative".to_owned()); }
    let root = Path::new(incident_arg(args, 2, "root")?); if !root.is_dir() { return Err(format!("incident root is not a directory: {}", root.display())); }
    let source_relative = safe_relative_path(incident_arg(args, 3, "source-relative")?)?; let snapshot_parent_relative = safe_relative_path(incident_arg(args, 4, "snapshot-parent-relative")?)?; let receipt_relative = safe_relative_path(incident_arg(args, 5, "receipt-relative")?)?;
    if eoie_incident_recovery_scope_mask_binding(15,0) != 1 { return Err("typed incident snapshot scope rejected".to_owned()); }
    let source = root.join(&source_relative); let source_meta = fs::symlink_metadata(&source).map_err(|error| format!("metadata {}: {error}", source.display()))?; if source_meta.file_type().is_symlink() || !source_meta.is_dir() { return Err(format!("incident source must be a real directory: {}", source.display())); }
    let snapshot_parent = root.join(&snapshot_parent_relative); let leaf = incident_leaf(&source)?; let snapshot = snapshot_parent.join(&leaf); let receipt = root.join(&receipt_relative);
    let separated = incident_paths_separated(&source, &snapshot_parent) && incident_paths_separated(&source, &receipt) && incident_paths_separated(&snapshot, &receipt); if eoie_incident_recovery_leaf_binding(1, i32::from(separated)) != 1 { return Err("typed incident snapshot path separation rejected".to_owned()); }
    if snapshot.exists() { return Err(format!("incident snapshot already exists: {}", snapshot.display())); }
    fs::create_dir_all(&snapshot_parent).map_err(|error| format!("create {}: {error}", snapshot_parent.display()))?; incident_copy_tree(&source, &snapshot)?; let source_hash = incident_tree_hash(&source)?; let snapshot_hash = incident_tree_hash(&snapshot)?; let parity = i32::from(source_hash == snapshot_hash); if eoie_incident_recovery_snapshot_mask_binding(7 + 8 * parity,0) != 1 { let _ = fs::remove_dir_all(&snapshot); return Err("typed incident snapshot verification rejected".to_owned()); }
    let body = format!("schema=1\nsource={}\nsnapshot={}\nsha256={}\n", source_relative.display(), snapshot_parent_relative.join(&leaf).display(), snapshot_hash); atomic_write(&receipt, body.as_bytes())?; println!("eoie proxy incident-recovery snapshot ok source={} snapshot={} sha256={} receipt={}", source.display(), snapshot.display(), snapshot_hash, receipt.display()); Ok(())
}

fn incident_rollback(target: &Path, quarantine: Option<&Path>, original_hash: Option<&str>) -> Result<(), String> { if target.exists() { fs::remove_dir_all(target).map_err(|error| format!("rollback remove {}: {error}", target.display()))?; }
if let Some(saved) = quarantine && saved.exists() { fs::rename(saved, target).map_err(|error| format!("rollback restore {}: {error}", target.display()))?; } let restored = if let Some(expected) = original_hash { target.is_dir() && incident_tree_hash(target)? == expected } else { !target.exists() }; if eoie_incident_recovery_rollback_mask_binding(i32::from(original_hash.is_some()) + 2 * i32::from(restored) + 4 * i32::from(restored),0) != 1 { return Err("typed incident rollback verification rejected".to_owned()); } Ok(()) }

fn incident_restore(args: &[String]) -> Result<(), String> {
    if args.len() != 6 { return Err("incident-recovery restore expects root target-relative snapshot-relative receipt-relative".to_owned()); }
    let root = Path::new(incident_arg(args, 2, "root")?); if !root.is_dir() { return Err(format!("incident root is not a directory: {}", root.display())); }
    let target_relative = safe_relative_path(incident_arg(args, 3, "target-relative")?)?; let snapshot_relative = safe_relative_path(incident_arg(args, 4, "snapshot-relative")?)?; let receipt_relative = safe_relative_path(incident_arg(args, 5, "receipt-relative")?)?; if eoie_incident_recovery_scope_mask_binding(15,0) != 1 { return Err("typed incident restore scope rejected".to_owned()); }
    let target = root.join(&target_relative); let snapshot = root.join(&snapshot_relative); let receipt = root.join(&receipt_relative); let target_leaf = incident_leaf(&target)?; let snapshot_leaf = incident_leaf(&snapshot)?; let separated = incident_paths_separated(&target, &snapshot) && incident_paths_separated(&target, &receipt) && incident_paths_separated(&snapshot, &receipt); if eoie_incident_recovery_leaf_binding(i32::from(target_leaf == snapshot_leaf), i32::from(separated)) != 1 { return Err("typed incident restore leaf/separation rejected".to_owned()); }
    let snapshot_meta = fs::symlink_metadata(&snapshot).map_err(|error| format!("metadata {}: {error}", snapshot.display()))?; if snapshot_meta.file_type().is_symlink() || !snapshot_meta.is_dir() { return Err(format!("incident snapshot must be a real directory: {}", snapshot.display())); }
    let target_kind = match fs::symlink_metadata(&target) { Ok(meta) if meta.file_type().is_symlink() || !meta.is_dir() => return Err(format!("incident target must be absent or directory: {}", target.display())), Ok(_) => 1, Err(error) if error.kind() == std::io::ErrorKind::NotFound => 0, Err(error) => return Err(format!("metadata {}: {error}", target.display())) };
    let snapshot_hash = incident_tree_hash(&snapshot)?; let (receipt_snapshot, receipt_hash) = incident_parse_receipt(&receipt)?; let receipt_match = receipt_snapshot == snapshot_relative.to_string_lossy() && receipt_hash == snapshot_hash; let target_parent = target.parent().ok_or_else(|| format!("target has no parent: {}", target.display()))?; fs::create_dir_all(target_parent).map_err(|error| format!("create {}: {error}", target_parent.display()))?; let pid = std::process::id(); let stage_parent = target_parent.join(format!(".eoie-recovery-stage-{pid}")); let stage = stage_parent.join(&target_leaf); if stage_parent.exists() { return Err(format!("incident stage already exists: {}", stage_parent.display())); } let restore_mask = 3 + 4 * i32::from(receipt_match) + 8 * target_kind; if eoie_incident_recovery_restore_mask_binding(restore_mask,0) != 1 { return Err("typed incident restore preflight rejected".to_owned()); }
    fs::create_dir_all(&stage_parent).map_err(|error| format!("create {}: {error}", stage_parent.display()))?; if let Err(error) = incident_copy_tree(&snapshot, &stage) { let _ = fs::remove_dir_all(&stage_parent); return Err(error); } let stage_hash = incident_tree_hash(&stage)?; if stage_hash != snapshot_hash { let _ = fs::remove_dir_all(&stage_parent); return Err("incident staged restore hash mismatch".to_owned()); }
    let original_hash = if target_kind == 1 { Some(incident_tree_hash(&target)?) } else { None }; let quarantine_parent = target_parent.join(format!(".eoie-recovery-damaged-{pid}")); let quarantine = quarantine_parent.join(&target_leaf); if quarantine_parent.exists() { let _ = fs::remove_dir_all(&stage_parent); return Err(format!("incident quarantine already exists: {}", quarantine_parent.display())); }
    if target_kind == 1 { fs::create_dir_all(&quarantine_parent).map_err(|error| format!("create {}: {error}", quarantine_parent.display()))?; fs::rename(&target, &quarantine).map_err(|error| format!("quarantine {}: {error}", target.display()))?; }
    let fault = std::env::var("EOIE_INCIDENT_RECOVERY_FAULT").unwrap_or_default(); if fault == "after-quarantine" { if eoie_incident_recovery_fault_binding(1,1) != 1 { return Err("typed incident fault rejected".to_owned()); } incident_rollback(&target, if target_kind == 1 { Some(quarantine.as_path()) } else { None }, original_hash.as_deref())?; let _ = fs::remove_dir_all(&stage_parent); let _ = fs::remove_dir_all(&quarantine_parent); return Err("injected incident recovery failure after quarantine".to_owned()); }
    if let Err(error) = fs::rename(&stage, &target) { incident_rollback(&target, if target_kind == 1 { Some(quarantine.as_path()) } else { None }, original_hash.as_deref())?; let _ = fs::remove_dir_all(&stage_parent); let _ = fs::remove_dir_all(&quarantine_parent); return Err(format!("promote incident restore: {error}")); } let _ = fs::remove_dir_all(&stage_parent);
    if fault == "after-promotion" { if eoie_incident_recovery_fault_binding(2,2) != 1 { return Err("typed incident fault rejected".to_owned()); } incident_rollback(&target, if target_kind == 1 { Some(quarantine.as_path()) } else { None }, original_hash.as_deref())?; let _ = fs::remove_dir_all(&quarantine_parent); return Err("injected incident recovery failure after promotion".to_owned()); }
    let final_hash = incident_tree_hash(&target)?; let complete = eoie_incident_recovery_completion_mask_binding(1 + 2 * i32::from(stage_hash == snapshot_hash) + 4 * i32::from(final_hash == snapshot_hash),0); if complete != 1 { incident_rollback(&target, if target_kind == 1 { Some(quarantine.as_path()) } else { None }, original_hash.as_deref())?; let _ = fs::remove_dir_all(&quarantine_parent); return Err("typed incident recovery completion rejected".to_owned()); }
    println!("eoie proxy incident-recovery restore ok target={} snapshot={} sha256={} damaged={}", target.display(), snapshot.display(), final_hash, if target_kind == 1 { quarantine.display().to_string() } else { "none".to_owned() }); Ok(())
}

pub fn incident_recovery_run(args: &[String]) -> Result<(), String> { match args.get(1).map(String::as_str) { Some("snapshot") => incident_snapshot(args), Some("restore") => incident_restore(args), _ => Err("incident-recovery expects snapshot or restore".to_owned()) } }

fn runtime_filename(path: &std::path::Path) -> bool {
    path.file_name().and_then(|value| value.to_str()) == Some("runtime.spi")
}

pub fn validate_runtime_filenames(root: &std::path::Path) -> Result<(), String> {
    let src = root.join("src");
    if !src.is_dir() { return Err(format!("runtime filename guard missing src: {}", src.display())); }
    let mut found = Vec::new();
    collect_matching_regular_files(&src, &mut found, "runtime filename guard", runtime_filename)?;
    found.sort();
    if found.is_empty() { Ok(()) } else { Err(format!("generic runtime.spi files are forbidden: {}", found.iter().map(|path| path.display().to_string()).collect::<Vec<_>>().join(","))) }
}

#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1,
    US0_2,
    US0_3,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1 => 1,
            US0::US0_2 => 2,
            US0::US0_3 => 3,
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0i32 < v0;
    if v2 {
        1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0i32 < v0;
    if v2 {
        1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0i32 < v0;
    if v2 {
        1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0i32 < v0;
    if v2 {
        1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0i32 < v0;
    if v2 {
        1i32
    } else {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method5(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from(".spiral-entry");
    let mut v2: bool = v0.ends_with(&*v1);
    let mut v44: US0 = if v2 {
        US0::US0_1
    } else {
        let mut v4: Rc<str> = Rc::<str>::from(".eoie-typecheck-");
        let mut v5: bool = v0.contains(&*v4);
        let mut v8: bool = if v5 {
            let mut v6: Rc<str> = Rc::<str>::from(".rs");
            let mut v7: bool = v0.ends_with(&*v6);
            v7
        } else {
            false
        };
        if v8 {
            US0::US0_1
        } else {
            let mut v10: bool = v0.contains(&*v4);
            let mut v13: bool = if v10 {
                let mut v11: Rc<str> = Rc::<str>::from(".rs.eoie-");
                let mut v12: bool = v0.contains(&*v11);
                v12
            } else {
                false
            };
            let mut v16: bool = if v13 {
                let mut v14: Rc<str> = Rc::<str>::from(".tmp");
                let mut v15: bool = v0.ends_with(&*v14);
                v15
            } else {
                false
            };
            if v16 {
                US0::US0_1
            } else {
                let mut v18: Rc<str> = Rc::<str>::from(".receipt");
                let mut v19: bool = v0.ends_with(&*v18);
                if v19 {
                    US0::US0_2
                } else {
                    let mut v21: Rc<str> = Rc::<str>::from(".release-eoie-candidate");
                    let mut v22: bool = v0.starts_with(&*v21);
                    if v22 {
                        US0::US0_2
                    } else {
                        let mut v24: Rc<str> = Rc::<str>::from("probe");
                        let mut v25: bool = v0.starts_with(&*v24);
                        let mut v28: bool = if v25 {
                            let mut v26: Rc<str> = Rc::<str>::from(".rs");
                            let mut v27: bool = v0.ends_with(&*v26);
                            v27
                        } else {
                            false
                        };
                        if v28 {
                            US0::US0_2
                        } else {
                            let mut v30: Rc<str> = Rc::<str>::from(".cold-rebuild");
                            let mut v31: bool = v0.starts_with(&*v30);
                            if v31 {
                                US0::US0_3
                            } else {
                                let mut v33: Rc<str> = Rc::<str>::from(".cargo");
                                let mut v34: bool = v0 == v33 ;
                                if v34 {
                                    US0::US0_3
                                } else {
                                    US0::US0_0
                                }
                            }
                        }
                    }
                }
            }
        }
    };
    match &v44 {
        US0::US0_1 => { // HygieneCompilerSidecar
            1u64
        }
        US0::US0_0 => { // HygieneKeep
            0u64
        }
        US0::US0_3 => { // HygieneRootTransientDirectory
            3u64
        }
        US0::US0_2 => { // HygieneRootTransientFile
            2u64
        }
        _ => unreachable!(),
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
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
fn method7(mut v0: i32, mut v1: i32) -> i32 {
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
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 15i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 15i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 15i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 15i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 7i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            let mut v4: bool = v0 < 15i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 15i32 < v0;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v1 < 0i32;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = 0i32 < v1;
                        if v7 {
                            0i32
                        } else {
                            1i32
                        }
                    }
                }
            }
        } else {
            let mut v12: bool = v1 < 0i32;
            if v12 {
                0i32
            } else {
                let mut v13: bool = 0i32 < v1;
                if v13 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 6i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method12(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 7i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
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
fn closure5() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method5(v0.clone())
    })
}
fn closure6() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method8(v0, v1)
    })
}
fn closure7() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure8() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method9(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure10() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method7(v0, v1)
    })
}
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method11(v0, v1)
    })
}
fn closure12() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method12(v0, v1)
    })
}
pub fn eoie_hygiene_primary_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_hygiene_secondary_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_hygiene_root_file_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_hygiene_root_aux_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_hygiene_root_directory_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_hygiene_name_classification(v0: &str) -> u64 {
    closure5()(Rc::<str>::from(v0))
}
pub fn eoie_incident_recovery_scope_mask_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_incident_recovery_leaf_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_incident_recovery_snapshot_mask_binding(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_incident_recovery_restore_mask_binding(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
pub fn eoie_incident_recovery_fault_binding(v0: i32, v1: i32) -> i32 {
    closure10()(v0, v1)
}
pub fn eoie_incident_recovery_rollback_mask_binding(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
pub fn eoie_incident_recovery_completion_mask_binding(v0: i32, v1: i32) -> i32 {
    closure12()(v0, v1)
}
