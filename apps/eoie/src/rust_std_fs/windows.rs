pub use eoie_rust_std_fs_mutation::{windows_guard, windows_open_regular, windows_symlink, windows_validate_component};
fn open_nofollow_path(path: &Path, directory: bool) -> Result<std::fs::File, String> {
    if directory { return Err("use rooted directory operations on Windows".to_owned()); }
    windows_open_regular(path)
}
pub fn rooted_list_names(path: &Path) -> Result<Vec<String>, String> {
    let g = windows_guard(path, true, false)?;
    let mut names = std::fs::read_dir(&g.path).map_err(|e| e.to_string())?
        .map(|e| e.map(|e| e.file_name().to_string_lossy().into_owned()).map_err(|e| e.to_string()))
        .collect::<Result<Vec<_>, _>>()?;
    names.sort(); Ok(names)
}
pub fn rooted_canonical_directory(path: &Path) -> Result<PathBuf, String> {
    let g = windows_guard(path, true, false)?;
    std::fs::canonicalize(&g.path).map_err(|e| e.to_string())
}
pub fn rooted_read_symlink(path: &Path) -> Result<PathBuf, String> {
    let g = windows_guard(path, false, false)?;
    std::fs::read_link(&g.path).map_err(|e| e.to_string())
}
pub fn rooted_entry_exists(path: &Path) -> Result<bool, String> {
    let g = windows_guard(path, false, false)?;
    match std::fs::symlink_metadata(&g.path) {
        Ok(_) => Ok(true),
        Err(e) if e.kind() == std::io::ErrorKind::NotFound => Ok(false),
        Err(e) => Err(e.to_string()),
    }
}
