#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum FsActionKind { Mkdir, Copy { source: String, expected_sha: String }, Chmod { expected_mode: u32, new_mode: u32 }, Symlink { target: String } }

#[derive(Clone)]
struct FsActionItem { relative: String, kind: FsActionKind }

fn fs_action_compiled_manifest(plan: &std::path::Path) -> Result<String, String> {
    // Canonical providers are mandatory; compile every plan to Plan IR.
    let Some(compiler) = eoie_process::resolve_spiral_compiler(None)? else { return Err("compiled fs-actions provider requires a Spiral compiler".to_owned()); };
    let output = plan.with_extension(format!("eoie-plan-ir-{}.ir", std::process::id()));
    let status = eoie_process::compile_spiral_plan_ir(compiler.path.to_string_lossy().as_ref(), plan, &output, 30000)?;
    let manifest_result = if status.success() { std::fs::read_to_string(&output).map_err(|error| format!("read {}: {error}", output.display())) } else { Err(format!("Spiral Plan IR compilation failed for {}", plan.display())) };
    let _ = std::fs::remove_file(&output);
    let _ = std::fs::remove_file(std::path::PathBuf::from(format!("{}.spiral-entry", output.display())));
    let _ = std::fs::remove_file(plan.with_extension("c"));
    let manifest = manifest_result?;
    canonical_plan_ir_domain::parse_plan_ir_manifest(&manifest)?;
    Ok(manifest)
}

#[derive(Clone)]
enum FsLinkOriginal { Absent, File(Vec<u8>, std::fs::Permissions), Symlink(std::path::PathBuf) }

#[derive(Clone)]
enum FsPreparedAction { Mkdir { path: std::path::PathBuf, existed: bool }, Copy { source: std::path::PathBuf, path: std::path::PathBuf, expected_sha: String, original: Option<(Vec<u8>, std::fs::Permissions)> }, Chmod { path: std::path::PathBuf, old_permissions: std::fs::Permissions, new_mode: u32 }, Symlink { path: std::path::PathBuf, target: std::path::PathBuf, original: FsLinkOriginal } }

enum FsActionUndo { Noop, RemoveDir(std::path::PathBuf), RestoreFile { path: std::path::PathBuf, original: Option<(Vec<u8>, std::fs::Permissions)> }, RestoreMode { path: std::path::PathBuf, permissions: std::fs::Permissions }, RestoreLink { path: std::path::PathBuf, original: FsLinkOriginal } }

fn fs_action_parse_mode(text: &str) -> Result<u32, String> {
    let value = text.trim().trim_start_matches("0o");
    let mode = u32::from_str_radix(value, 8).map_err(|error| format!("invalid octal mode {text}: {error}"))?;
    if eoie_fs_actions_mode_valid_binding(mode as i32, 0) != 1 { return Err(format!("mode outside 0o7777: {text}")); }
    Ok(mode)
}

fn fs_action_parse(manifest: &str) -> Result<Vec<FsActionItem>, String> {
    {
        let rows = canonical_plan_ir_domain::parse_plan_ir_manifest(manifest)?;
        let mut items = Vec::with_capacity(rows.len());
        for row in rows {
            let code = canonical_plan_ir_domain::eoie_plan_ir_decode_code(&row.op, &row.target, &row.expected, &row.payload, &row.effect);
            let item = match code {
                3 => FsActionItem { relative: row.target, kind: FsActionKind::Mkdir },
                5 => FsActionItem { relative: row.target, kind: FsActionKind::Copy { source: row.payload, expected_sha: row.expected } },
                6 => FsActionItem { relative: row.target, kind: FsActionKind::Chmod { expected_mode: fs_action_parse_mode(&row.expected)?, new_mode: fs_action_parse_mode(&row.payload)? } },
                7 => FsActionItem { relative: row.target, kind: FsActionKind::Symlink { target: row.payload } },
                _ => return Err("compiled Plan IR contains a non-fs-action operation".to_owned()),
            };
            items.push(item);
        }
        return Ok(items);
    }
}

fn fs_action_parent_ready(path: &std::path::Path) -> Result<(), String> {
    let parent = path.parent().ok_or_else(|| format!("target has no parent: {}", path.display()))?;
    let metadata = std::fs::symlink_metadata(parent).map_err(|error| format!("metadata {}: {error}", parent.display()))?;
    if metadata.file_type().is_symlink() || !metadata.is_dir() { return Err(format!("real parent directory required: {}", parent.display())); }
    Ok(())
}

#[cfg(unix)]
fn fs_action_mode(path: &std::path::Path) -> Result<u32, String> {
    use std::os::unix::fs::PermissionsExt;
    let metadata = std::fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("chmod target cannot be symlink: {}", path.display())); }
    Ok(metadata.permissions().mode() & 0o7777)
}

#[cfg(not(unix))]
fn fs_action_mode(path: &std::path::Path) -> Result<u32, String> {
    #[cfg(windows)] let _guard = eoie_rust_std_fs::windows_guard(path, false, false)?;
    let metadata = std::fs::symlink_metadata(path).map_err(|e| e.to_string())?;
    #[cfg(windows)] {
        use std::os::windows::fs::MetadataExt;
        if metadata.file_attributes() & 0x400 != 0 { return Err("chmod target cannot be a reparse point".to_owned()); }
    }
    if metadata.file_type().is_symlink() || !(metadata.is_file() || metadata.is_dir()) {
        return Err("chmod target must be a regular file or directory".to_owned());
    }
    Ok(eoie_rust_std_fs::portable_mode(&metadata.permissions()))
}

#[cfg(unix)]
fn fs_action_set_mode(path: &std::path::Path, mode: u32) -> Result<(), String> {
    use std::os::unix::fs::PermissionsExt;
    std::fs::set_permissions(path, std::fs::Permissions::from_mode(mode)).map_err(|error| format!("chmod {}: {error}", path.display()))
}

#[cfg(not(unix))]
fn fs_action_set_mode(path: &std::path::Path, mode: u32) -> Result<(), String> { eoie_rust_std_fs::portable_set_mode(path, mode).map_err(|e| e.to_string()) }

#[cfg(unix)]
fn fs_action_make_symlink(target: &std::path::Path, link: &std::path::Path) -> Result<(), String> {
    std::os::unix::fs::symlink(target, link).map_err(|error| format!("symlink {} -> {}: {error}", link.display(), target.display()))
}

#[cfg(not(unix))]
fn fs_action_make_symlink(target: &std::path::Path, link: &std::path::Path) -> Result<(), String> { eoie_rust_std_fs::portable_symlink(target, link).map_err(|e| e.to_string()) }

fn fs_action_existing_link(path: &std::path::Path) -> Result<FsLinkOriginal, String> {
    match std::fs::symlink_metadata(path) {
        Err(error) if error.kind() == std::io::ErrorKind::NotFound => Ok(FsLinkOriginal::Absent),
        Err(error) => Err(format!("metadata {}: {error}", path.display())),
        Ok(metadata) if metadata.file_type().is_symlink() => Ok(FsLinkOriginal::Symlink(std::fs::read_link(path).map_err(|error| format!("readlink {}: {error}", path.display()))?)),
        Ok(metadata) if metadata.is_file() => Ok(FsLinkOriginal::File(std::fs::read(path).map_err(|error| format!("read {}: {error}", path.display()))?, metadata.permissions())),
        Ok(_) => Err(format!("symlink destination cannot replace directory: {}", path.display())),
    }
}

fn fs_action_prepare(root: &std::path::Path, items: &[FsActionItem]) -> Result<Vec<FsPreparedAction>, String> {
    let mut targets = std::collections::BTreeSet::new();
    for item in items {
        let relative = eoie_patch_control_domain::patch_safe_relative(&item.relative)?;
        if !targets.insert(relative) { return Err(format!("duplicate fs action target: {}", item.relative)); }
    }
    let mut prepared = Vec::with_capacity(items.len());
    for item in items {
        let relative = eoie_patch_control_domain::patch_safe_relative(&item.relative)?;
        let path = root.join(&relative);
        fs_action_parent_ready(&path)?;
        let action = match &item.kind {
            FsActionKind::Mkdir => {
                let existed = match std::fs::symlink_metadata(&path) {
                    Err(error) if error.kind() == std::io::ErrorKind::NotFound => false,
                    Err(error) => return Err(format!("metadata {}: {error}", path.display())),
                    Ok(metadata) if metadata.is_dir() && !metadata.file_type().is_symlink() => true,
                    Ok(_) => return Err(format!("mkdir target exists but is not real directory: {}", path.display())),
                };
                if eoie_fs_actions_freshness_binding(0, 1) != 1 { return Err("typed mkdir freshness rejected".to_owned()); }
                FsPreparedAction::Mkdir { path, existed }
            }
            FsActionKind::Copy { source, expected_sha } => {
                let source_relative = eoie_patch_control_domain::patch_safe_relative(source)?;
                if targets.contains(&source_relative) { return Err(format!("copy source is also batch target: {source}")); }
                let source_path = root.join(source_relative);
                let source_metadata = std::fs::symlink_metadata(&source_path).map_err(|error| format!("metadata {}: {error}", source_path.display()))?;
                if source_metadata.file_type().is_symlink() || !source_metadata.is_file() { return Err(format!("copy source must be regular: {}", source_path.display())); }
                let observed = eoie_proxy_search::inspection_file_sha256(&source_path)?;
                if &observed != expected_sha { return Err(format!("copy source stale expected={expected_sha} observed={observed}")); }
                let original = match std::fs::symlink_metadata(&path) {
                    Err(error) if error.kind() == std::io::ErrorKind::NotFound => None,
                    Err(error) => return Err(format!("metadata {}: {error}", path.display())),
                    Ok(metadata) if metadata.is_file() && !metadata.file_type().is_symlink() => Some((std::fs::read(&path).map_err(|error| format!("read {}: {error}", path.display()))?, metadata.permissions())),
                    Ok(_) => return Err(format!("copy target must be absent or regular file: {}", path.display())),
                };
                if eoie_fs_actions_freshness_binding(1, 1) != 1 { return Err("typed copy freshness rejected".to_owned()); }
                FsPreparedAction::Copy { source: source_path, path, expected_sha: expected_sha.clone(), original }
            }
            FsActionKind::Chmod { expected_mode, new_mode } => {
                let metadata = std::fs::symlink_metadata(&path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
                if metadata.file_type().is_symlink() || (!metadata.is_file() && !metadata.is_dir()) { return Err(format!("chmod target must be real file or directory: {}", path.display())); }
                let observed = fs_action_mode(&path)?;
                if !eoie_rust_std_fs::portable_mode_matches(observed, *expected_mode) { return Err(format!("chmod stale expected=0o{expected_mode:o} observed=0o{observed:o} path={}", path.display())); }
                if eoie_fs_actions_freshness_binding(2, 1) != 1 { return Err("typed chmod freshness rejected".to_owned()); }
                FsPreparedAction::Chmod { path, old_permissions: metadata.permissions(), new_mode: *new_mode }
            }
            FsActionKind::Symlink { target } => {
                let target_relative = eoie_patch_control_domain::patch_safe_relative(target)?;
                let target_path = root.join(&target_relative);
                if !target_path.exists() { return Err(format!("symlink target missing: {}", target_path.display())); }
                let original = fs_action_existing_link(&path)?;
                if eoie_fs_actions_freshness_binding(3, 1) != 1 { return Err("typed symlink freshness rejected".to_owned()); }
                // Plan targets are root-relative; filesystem link payloads are link-relative.
                let mut link_target = std::path::PathBuf::new();
                for _ in relative.parent().into_iter().flat_map(|parent| parent.components()) { link_target.push(".."); }
                link_target.push(target_relative);
                FsPreparedAction::Symlink { path, target: link_target, original }
            }
        };
        prepared.push(action);
    }
    Ok(prepared)
}

fn fs_action_remove_file_or_link(path: &std::path::Path) -> Result<(), String> {
    match std::fs::remove_file(path) {
        Ok(()) => Ok(()),
        Err(error) if error.kind() == std::io::ErrorKind::NotFound => Ok(()),
        Err(error) => Err(format!("remove {}: {error}", path.display())),
    }
}

fn fs_action_restore_link(path: &std::path::Path, original: &FsLinkOriginal) -> Result<(), String> {
    fs_action_remove_file_or_link(path)?;
    match original {
        FsLinkOriginal::Absent => Ok(()),
        FsLinkOriginal::File(bytes, permissions) => {
            eoie_rust_std_fs::atomic_write(path, bytes)?;
            std::fs::set_permissions(path, permissions.clone()).map_err(|error| format!("permissions {}: {error}", path.display()))
        }
        FsLinkOriginal::Symlink(target) => fs_action_make_symlink(target, path),
    }
}

fn fs_action_rollback(undos: &[FsActionUndo]) -> Result<(), String> {
    let mut restored = 0usize;
    let mut failures = Vec::new();
    for undo in undos.iter().rev() {
        let result = match undo {
            FsActionUndo::Noop => Ok(()),
            FsActionUndo::RemoveDir(path) => std::fs::remove_dir(path).map_err(|error| format!("remove dir {}: {error}", path.display())),
            FsActionUndo::RestoreFile { path, original } => match original {
                Some((bytes, permissions)) => eoie_rust_std_fs::atomic_write(path, bytes).and_then(|()| std::fs::set_permissions(path, permissions.clone()).map_err(|error| format!("permissions {}: {error}", path.display()))),
                None => fs_action_remove_file_or_link(path),
            },
            FsActionUndo::RestoreMode { path, permissions } => std::fs::set_permissions(path, permissions.clone()).map_err(|error| format!("permissions {}: {error}", path.display())),
            FsActionUndo::RestoreLink { path, original } => fs_action_restore_link(path, original),
        };
        match result { Ok(()) => restored += 1, Err(error) => failures.push(error) }
    }
    let typed = eoie_fs_actions_rollback_binding(undos.len() as i32, restored as i32);
    if typed != 1 || !failures.is_empty() { return Err(format!("fs actions rollback incomplete restored={restored}/{} failures={}", undos.len(), failures.join(" | "))); }
    Ok(())
}

fn fs_action_apply_one(action: &FsPreparedAction) -> Result<FsActionUndo, String> {
    match action {
        FsPreparedAction::Mkdir { path, existed } => {
            if *existed { Ok(FsActionUndo::Noop) } else { std::fs::create_dir(path).map_err(|error| format!("mkdir {}: {error}", path.display()))?; Ok(FsActionUndo::RemoveDir(path.clone())) }
        }
        FsPreparedAction::Copy { source, path, original, .. } => {
            eoie_rust_std_fs::copy_regular_atomic_preserve(source, path)?;
            Ok(FsActionUndo::RestoreFile { path: path.clone(), original: original.clone() })
        }
        FsPreparedAction::Chmod { path, old_permissions, new_mode } => {
            fs_action_set_mode(path, *new_mode)?;
            Ok(FsActionUndo::RestoreMode { path: path.clone(), permissions: old_permissions.clone() })
        }
        FsPreparedAction::Symlink { path, target, original } => {
            fs_action_remove_file_or_link(path)?;
            fs_action_make_symlink(target, path)?;
            Ok(FsActionUndo::RestoreLink { path: path.clone(), original: original.clone() })
        }
    }
}

fn fs_action_verify_one(action: &FsPreparedAction) -> Result<(), String> {
    match action {
        FsPreparedAction::Mkdir { path, .. } => {
            let metadata = std::fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
            if metadata.is_dir() && !metadata.file_type().is_symlink() { Ok(()) } else { Err(format!("mkdir verification failed: {}", path.display())) }
        }
        FsPreparedAction::Copy { path, expected_sha, .. } => {
            let observed = eoie_proxy_search::inspection_file_sha256(path)?;
            if &observed == expected_sha { Ok(()) } else { Err(format!("copy verification expected={expected_sha} observed={observed}")) }
        }
        FsPreparedAction::Chmod { path, new_mode, .. } => {
            let observed = fs_action_mode(path)?;
            if eoie_rust_std_fs::portable_mode_matches(observed, *new_mode) { Ok(()) } else { Err(format!("chmod verification expected=0o{new_mode:o} observed=0o{observed:o}")) }
        }
        FsPreparedAction::Symlink { path, target, .. } => {
            let metadata = std::fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
            if !metadata.file_type().is_symlink() { return Err(format!("symlink verification target is not link: {}", path.display())); }
            let observed = std::fs::read_link(path).map_err(|error| format!("readlink {}: {error}", path.display()))?;
            if observed == *target { Ok(()) } else { Err(format!("symlink verification expected={} observed={}", target.display(), observed.display())) }
        }
    }
}

pub fn filesystem_actions_run(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("fs-actions expects preview|apply root plan.spi".to_owned()); }
    let mode = args.get(1).map(String::as_str).unwrap_or("");
    if mode != "preview" && mode != "apply" { return Err("fs-actions mode must be preview or apply".to_owned()); }
    let root = std::path::Path::new(args.get(2).ok_or_else(|| "missing root".to_owned())?);
    let root_metadata = std::fs::symlink_metadata(root).map_err(|error| format!("metadata {}: {error}", root.display()))?;
    if root_metadata.file_type().is_symlink() || !root_metadata.is_dir() { return Err(format!("real root directory required: {}", root.display())); }
    let plan = std::path::Path::new(args.get(3).ok_or_else(|| "missing plan.spi".to_owned())?);
    let metadata = std::fs::symlink_metadata(plan).map_err(|error| format!("metadata {}: {error}", plan.display()))?;
    if !plan.is_absolute() || !metadata.is_file() || metadata.file_type().is_symlink() || plan.extension().and_then(|value| value.to_str()) != Some("spi") { return Err("fs-actions plan must be an absolute regular .spi file".to_owned()); }
    let manifest = fs_action_compiled_manifest(plan)?;
    let items = fs_action_parse(&manifest)?;
    let prepared = fs_action_prepare(root, &items)?;
    if eoie_fs_actions_shape_binding(items.len() as i32, 0) != 1 { return Err("typed fs action shape rejected".to_owned()); }
    if mode == "preview" {
        println!("eoie proxy fs-actions preview ok rows={} mutation=false", items.len());
        for item in &items { println!("path={} kind={}", item.relative, match item.kind { FsActionKind::Mkdir => "mkdir", FsActionKind::Copy { .. } => "copy", FsActionKind::Chmod { .. } => "chmod", FsActionKind::Symlink { .. } => "symlink" }); }
        return Ok(());
    }
    let fault_after = std::env::var("EOIE_FS_ACTIONS_FAULT_AFTER").ok().map(|value| value.parse::<usize>().map_err(|_| "EOIE_FS_ACTIONS_FAULT_AFTER must be an integer".to_owned())).transpose()?;
    let mut undos = Vec::with_capacity(prepared.len());
    for action in &prepared {
        match fs_action_apply_one(action) {
            Ok(undo) => undos.push(undo),
            Err(error) => { let rollback = fs_action_rollback(&undos); return Err(format!("fs action apply failed: {error}; rollback={rollback:?}")); }
        }
        if fault_after == Some(undos.len()) { let rollback = fs_action_rollback(&undos); return Err(format!("injected fs action failure after {}; rollback={rollback:?}", undos.len())); }
    }
    if eoie_fs_actions_apply_binding(items.len() as i32, undos.len() as i32) != 1 { let rollback = fs_action_rollback(&undos); return Err(format!("typed fs action apply rejected; rollback={rollback:?}")); }
    let mut verified = 0usize;
    for action in &prepared {
        if let Err(error) = fs_action_verify_one(action) { let rollback = fs_action_rollback(&undos); return Err(format!("fs action verification failed: {error}; rollback={rollback:?}")); }
        verified += 1;
    }
    if eoie_fs_actions_verify_binding(items.len() as i32, verified as i32) != 1 { let rollback = fs_action_rollback(&undos); return Err(format!("typed fs action verification rejected; rollback={rollback:?}")); }
    println!("eoie proxy fs-actions apply ok rows={} verified={} mutation=true", items.len(), verified);
    Ok(())
}

#[cfg(test)] #[path = "regression_tests.rs"] mod regression_tests;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = 0i32 < v1;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
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
                1i32
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                1i32
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
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 != 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v0 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = 4095i32 < v0;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn closure5() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method5(v0, v1)
    })
}
pub fn eoie_fs_actions_shape_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_fs_actions_freshness_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_fs_actions_apply_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_fs_actions_verify_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_fs_actions_rollback_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_fs_actions_mode_valid_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
