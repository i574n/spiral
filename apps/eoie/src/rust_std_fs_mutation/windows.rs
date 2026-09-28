// Native Windows backend. Ancestor handles deny delete sharing, preventing
// directory replacement while a path-based operation is in progress.
use std::fs::{self as win_fs, File as WinFile, OpenOptions as WinOptions};
use std::os::windows::fs::{MetadataExt as _, OpenOptionsExt as _};

pub struct WindowsPathGuard { pub path: PathBuf, _ancestors: Vec<WinFile> }

pub fn windows_validate_component(value: &std::ffi::OsStr) -> Result<(), String> {
    let text = value.to_string_lossy();
    let stem = text.split('.').next().unwrap_or("").trim_end().to_ascii_uppercase();
    if text.is_empty() || text.ends_with([' ', '.']) || text.chars().any(|c| c < ' ' || "<>:\"|?*".contains(c))
        || matches!(stem.as_str(), "CON" | "PRN" | "AUX" | "NUL" | "CONIN$" | "CONOUT$")
        || ((stem.starts_with("COM") || stem.starts_with("LPT")) && matches!(&stem[3..], "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" | "¹" | "²" | "³")) {
        return Err(format!("unsafe Windows path component: {text}"));
    }
    Ok(())
}

fn windows_open_directory(path: &Path) -> Result<WinFile, String> {
    let file = WinOptions::new().read(true).share_mode(3)
        .custom_flags(0x02000000 | 0x00200000).open(path)
        .map_err(|e| format!("open directory {}: {e}", path.display()))?;
    let meta = file.metadata().map_err(|e| e.to_string())?;
    if !meta.is_dir() || meta.file_attributes() & 0x400 != 0 {
        return Err(format!("real non-reparse directory required: {}", path.display()));
    }
    Ok(file)
}

pub fn windows_guard(path: &Path, include_leaf: bool, create: bool) -> Result<WindowsPathGuard, String> {
    if matches!(path.components().next(), Some(std::path::Component::Prefix(_))) && !path.has_root() {
        return Err(format!("drive-relative path rejected: {}", path.display()));
    }
    for c in path.components() {
        match c {
            std::path::Component::ParentDir => return Err(format!("parent component rejected: {}", path.display())),
            std::path::Component::Normal(n) => windows_validate_component(n)?,
            std::path::Component::Prefix(p) => match p.kind() {
                std::path::Prefix::Disk(_) | std::path::Prefix::VerbatimDisk(_) |
                std::path::Prefix::UNC(_, _) | std::path::Prefix::VerbatimUNC(_, _) => (),
                _ => return Err("Windows device paths are not supported".to_owned()),
            },
            _ => (),
        }
    }
    let absolute = std::path::absolute(path).map_err(|e| e.to_string())?;
    let directory = if include_leaf { absolute.as_path() } else { absolute.parent().ok_or("path has no parent")? };
    let mut cursor = PathBuf::new();
    let mut handles = Vec::new();
    for c in directory.components() {
        cursor.push(c.as_os_str());
        if matches!(c, std::path::Component::Prefix(_)) { continue; }
        if create && matches!(c, std::path::Component::Normal(_)) {
            match win_fs::create_dir(&cursor) {
                Ok(()) => (),
                Err(e) if e.kind() == std::io::ErrorKind::AlreadyExists => (),
                Err(e) => return Err(format!("mkdir {}: {e}", cursor.display())),
            }
        }
        handles.push(windows_open_directory(&cursor)?);
    }
    Ok(WindowsPathGuard { path: absolute, _ancestors: handles })
}

pub fn windows_open_regular(path: &Path) -> Result<WinFile, String> {
    let guard = windows_guard(path, false, false)?;
    let file = WinOptions::new().read(true).custom_flags(0x00200000).open(&guard.path)
        .map_err(|e| format!("open {}: {e}", path.display()))?;
    let meta = file.metadata().map_err(|e| e.to_string())?;
    if !meta.is_file() || meta.file_attributes() & 0x400 != 0 {
        return Err(format!("regular non-reparse file required: {}", path.display()));
    }
    Ok(file)
}

fn windows_existing(path: &Path) -> Result<Option<std::fs::Permissions>, String> {
    match win_fs::symlink_metadata(path) {
        Ok(m) if m.is_file() && m.file_attributes() & 0x400 == 0 => Ok(Some(m.permissions())),
        Ok(_) => Err(format!("regular non-reparse target required: {}", path.display())),
        Err(e) if e.kind() == std::io::ErrorKind::NotFound => Ok(None),
        Err(e) => Err(e.to_string()),
    }
}

fn windows_within(root: &Path, path: &Path) -> Result<(), String> {
    let relative = path.strip_prefix(root).map_err(|_| format!("path escapes root: {}", path.display()))?;
    if relative.as_os_str().is_empty() || relative.components().any(|c| !matches!(c, std::path::Component::Normal(_))) {
        return Err(format!("nonempty confined relative path required: {}", path.display()));
    }
    Ok(())
}

pub fn rooted_ensure_directory(path: &Path) -> Result<(), String> { windows_guard(path, true, true).map(|_| ()) }
pub fn rooted_create_directory_within(root: &Path, path: &Path) -> Result<(), String> {
    windows_within(root, path)?;
    let g = windows_guard(path, false, false)?;
    win_fs::create_dir(&g.path).map_err(|e| e.to_string())
}
pub fn rooted_set_directory_mode_within(root: &Path, path: &Path, _mode: u32) -> Result<(), String> {
    windows_within(root, path)?;
    // POSIX directory mode bits have no equivalent in Windows ACLs.
    windows_guard(path, true, false).map(|_| ())
}
pub fn rooted_promote_directory_within(root: &Path, temporary: &Path, target: &Path) -> Result<(), String> {
    windows_within(root, temporary)?; windows_within(root, target)?;
    let a = windows_guard(temporary, false, false)?;
    let b = windows_guard(target, false, false)?;
    { let _validated = windows_open_directory(&a.path)?; }
    if win_fs::symlink_metadata(&b.path).is_ok() { return Err("directory destination already exists".to_owned()); }
    win_fs::rename(&a.path, &b.path).map_err(|e| e.to_string())
}
pub fn rooted_create_regular_within(root: &Path, path: &Path, _mode: u32) -> Result<WinFile, String> {
    windows_within(root, path)?;
    let g = windows_guard(path, false, false)?;
    WinOptions::new().write(true).create_new(true).custom_flags(0x00200000).open(&g.path).map_err(|e| e.to_string())
}
pub fn windows_symlink(target: &Path, link: &Path) -> std::io::Result<()> {
    let resolved = if target.is_absolute() { target.to_path_buf() } else { link.parent().unwrap_or(Path::new(".")).join(target) };
    if resolved.is_dir() { std::os::windows::fs::symlink_dir(target, link) }
    else { std::os::windows::fs::symlink_file(target, link) }
}
pub fn rooted_create_symlink_within(root: &Path, path: &Path, target: &Path) -> Result<(), String> {
    windows_within(root, path)?;
    let g = windows_guard(path, false, false)?;
    windows_symlink(target, &g.path).map_err(|e| format!("create symlink (Windows Developer Mode or symlink privilege required): {e}"))
}
pub fn rooted_create_hardlink_within(root: &Path, existing: &Path, link: &Path) -> Result<(), String> {
    windows_within(root, existing)?; windows_within(root, link)?;
    let a = windows_guard(existing, false, false)?;
    let b = windows_guard(link, false, false)?;
    let _source = windows_open_regular(&a.path)?;
    win_fs::hard_link(&a.path, &b.path).map_err(|e| e.to_string())
}

fn windows_stage(target: &Path, bytes: &[u8], permissions: Option<std::fs::Permissions>, create: bool) -> Result<PathBuf, String> {
    use std::io::Write as _;
    let g = windows_guard(target, false, create)?;
    let nonce = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map_err(|e| e.to_string())?.as_nanos();
    for attempt in 0..32 {
        let stage = target.with_file_name(format!(".eoie-stage-{}-{nonce}-{attempt}", std::process::id()));
        let absolute_stage = g.path.with_file_name(stage.file_name().ok_or("stage has no filename")?);
        let mut file = match WinOptions::new().write(true).create_new(true).open(&absolute_stage) {
            Ok(f) => f, Err(e) if e.kind() == std::io::ErrorKind::AlreadyExists => continue, Err(e) => return Err(e.to_string()),
        };
        let result = (|| {
            file.write_all(bytes).map_err(|e| e.to_string())?;
            if let Some(p) = permissions { file.set_permissions(p).map_err(|e| e.to_string())?; }
            file.sync_all().map_err(|e| e.to_string())
        })();
        drop(file);
        if let Err(e) = result { let _ = win_fs::remove_file(&absolute_stage); return Err(e); }
        return Ok(stage);
    }
    Err("unable to allocate a unique stage".to_owned())
}
pub fn atomic_write(path: &Path, bytes: &[u8]) -> Result<(), String> {
    let g = windows_guard(path, false, true)?;
    let stage = windows_stage(&g.path, bytes, windows_existing(&g.path)?, false)?;
    if let Err(e) = promote_stage(&stage, &g.path) { let _ = discard_stage(&stage); return Err(e); }
    Ok(())
}
pub fn copy_regular_atomic_preserve(source: &Path, target: &Path) -> Result<u64, String> {
    use std::io::Read as _;
    let mut file = windows_open_regular(source)?;
    let permissions = file.metadata().map_err(|e| e.to_string())?.permissions();
    let mut bytes = Vec::new(); file.read_to_end(&mut bytes).map_err(|e| e.to_string())?;
    let g = windows_guard(target, false, true)?;
    windows_existing(&g.path)?;
    let stage = windows_stage(&g.path, &bytes, Some(permissions), false)?;
    if let Err(e) = promote_stage(&stage, &g.path) { let _ = discard_stage(&stage); return Err(e); }
    Ok(bytes.len() as u64)
}
pub fn stage_text_receipted_bound(target: &Path, text: &str, stage_index: i32, backup_slot: i32) -> Result<StagedWriteReceipt, String> {
    if stage_index < 0 || backup_slot < 0 { return Err("stage identity must be non-negative".to_owned()); }
    let g = windows_guard(target, false, false)?;
    let permissions = windows_existing(&g.path)?.ok_or("replace target is absent")?;
    let temporary = windows_stage(target, text.as_bytes(), Some(permissions), false)?;
    Ok(StagedWriteReceipt { target: target.to_path_buf(), temporary, bytes_written: text.len(), stage_index, backup_slot })
}
pub fn stage_new_text(target: &Path, text: &str) -> Result<PathBuf, String> {
    let g = windows_guard(target, false, true)?;
    if windows_existing(&g.path)?.is_some() { return Err("new target already exists".to_owned()); }
    windows_stage(target, text.as_bytes(), None, false)
}
pub fn promote_stage(temporary: &Path, target: &Path) -> Result<(), String> {
    if temporary.parent() != target.parent() { return Err("staged promotion requires a shared parent".to_owned()); }
    let g = windows_guard(target, false, false)?;
    windows_existing(&g.path)?;
    let stage = windows_guard(temporary, false, false)?;
    { let _validated = windows_open_regular(&stage.path)?; }
    win_fs::rename(&stage.path, &g.path).map_err(|e| format!("promote stage: {e}"))
}
pub fn discard_stage(temporary: &Path) -> Result<(), String> {
    let g = windows_guard(temporary, false, false)?;
    if windows_existing(&g.path)?.is_none() { return Ok(()); }
    win_fs::remove_file(&g.path).map_err(|e| e.to_string())
}
pub fn rooted_remove_regular(path: &Path) -> Result<(), String> {
    let g = windows_guard(path, false, false)?;
    windows_existing(&g.path)?.ok_or("remove target is absent")?;
    win_fs::remove_file(&g.path).map_err(|e| e.to_string())
}
pub fn rooted_unlink_nondirectory(path: &Path) -> Result<(), String> {
    let g = windows_guard(path, false, false)?;
    let m = win_fs::symlink_metadata(&g.path).map_err(|e| e.to_string())?;
    if m.file_attributes() & 0x400 != 0 && m.is_dir() { win_fs::remove_dir(&g.path).map_err(|e| e.to_string()) }
    else if m.is_dir() { Err("unlink target is a directory".to_owned()) }
    else { win_fs::remove_file(&g.path).map_err(|e| e.to_string()) }
}
pub fn rooted_remove_tree_within(root: &Path, path: &Path) -> Result<u64, String> {
    windows_within(root, path)?;
    let parent = windows_guard(path, false, false)?;
    let directory = windows_guard(&parent.path, true, false)?;
    let mut count = 0;
    for entry in win_fs::read_dir(&directory.path).map_err(|e| e.to_string())? {
        let p = entry.map_err(|e| e.to_string())?.path();
        let m = win_fs::symlink_metadata(&p).map_err(|e| e.to_string())?;
        if m.is_dir() && m.file_attributes() & 0x400 == 0 { count += rooted_remove_tree_within(&directory.path, &p)?; }
        else { rooted_unlink_nondirectory(&p)?; count += 1; }
    }
    drop(directory);
    win_fs::remove_dir(&parent.path).map_err(|e| e.to_string())?;
    Ok(count + 1)
}
