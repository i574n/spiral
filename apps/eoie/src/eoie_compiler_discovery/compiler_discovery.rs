#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone, Debug)]
pub struct SpiralCompilerDiscovery {
    pub path: std::path::PathBuf,
    pub source: &'static str,
    pub fingerprint: u64,
    pub entry_sha256: String,
    pub facade_sha256: Option<String>,
    pub sha256: String,
}

fn spiral_hash_bytes(hash: &mut u64, bytes: &[u8]) {
    for byte in bytes { *hash ^= u64::from(*byte); *hash = hash.wrapping_mul(1099511628211); }
}

fn spiral_hash_file_into(path: &std::path::Path, hash: &mut u64) -> Result<(), String> {
    let mut file = std::fs::File::open(path).map_err(|error| format!("open compiler artifact {}: {error}", path.display()))?;
    let mut buffer = [0u8; 64 * 1024];
    loop {
        let count = std::io::Read::read(&mut file, &mut buffer).map_err(|error| format!("read compiler artifact {}: {error}", path.display()))?;
        if count == 0 { break; }
        spiral_hash_bytes(hash, &buffer[..count]);
    }
    Ok(())
}

fn spiral_compiler_facade(path: &std::path::Path) -> Result<Option<std::path::PathBuf>, String> {
    let Some(bin) = path.parent() else { return Ok(None); };
    let Some(root) = bin.parent() else { return Ok(None); };
    let candidate = root.join("source/facade/bin/linux/amd64/Release/net11.0/SpiralCompilerFacadeCli.dll");
    let metadata = match std::fs::symlink_metadata(&candidate) {
        Ok(value) => value,
        Err(error) if error.kind() == std::io::ErrorKind::NotFound => return Ok(None),
        Err(error) => return Err(format!("inspect Spiral compiler facade {}: {error}", candidate.display())),
    };
    if metadata.file_type().is_symlink() || !metadata.is_file() {
        return Err(format!("Spiral compiler facade must be a regular non-symlink file: {}", candidate.display()));
    }
    std::fs::canonicalize(&candidate).map(Some).map_err(|error| format!("canonicalize Spiral compiler facade {}: {error}", candidate.display()))
}

fn spiral_compiler_fingerprint(path: &std::path::Path, facade: Option<&std::path::Path>) -> Result<u64, String> {
    let mut hash = 14695981039346656037u64;
    spiral_hash_bytes(&mut hash, b"entry\0");
    spiral_hash_file_into(path, &mut hash)?;
    spiral_hash_bytes(&mut hash, b"\0facade\0");
    if let Some(facade) = facade { spiral_hash_file_into(facade, &mut hash)?; } else { spiral_hash_bytes(&mut hash, b"absent"); }
    Ok(hash)
}

fn validate_spiral_compiler(candidate: &std::path::Path, source: &'static str) -> Result<SpiralCompilerDiscovery, String> {
    if !candidate.is_absolute() { return Err(format!("Spiral compiler from {source} must be absolute: {}", candidate.display())); }
    let metadata = std::fs::symlink_metadata(candidate).map_err(|error| format!("inspect Spiral compiler from {source} {}: {error}", candidate.display()))?;
    if metadata.file_type().is_symlink() || !metadata.is_file() { return Err(format!("Spiral compiler from {source} must be a regular non-symlink file: {}", candidate.display())); }
    let path = std::fs::canonicalize(candidate).map_err(|error| format!("canonicalize Spiral compiler {}: {error}", candidate.display()))?;
    let facade = spiral_compiler_facade(&path)?;
    let fingerprint = spiral_compiler_fingerprint(&path, facade.as_deref())?;
    let entry_sha256 = eoie_proxy_search::inspection_file_sha256(&path)?;
    let facade_sha256 = match facade.as_ref() { Some(path) => Some(eoie_proxy_search::inspection_file_sha256(path)?), None => None };
    let identity = format!("schema=2\nentry_sha256={entry_sha256}\nfacade_sha256={}\n", facade_sha256.as_deref().unwrap_or("absent"));
    let sha256 = eoie_proxy_search::inspection_sha256(identity.into_bytes());
    Ok(SpiralCompilerDiscovery { path, source, fingerprint, entry_sha256, facade_sha256, sha256 })
}

fn spiral_compiler_config_path() -> Option<std::path::PathBuf> {
    if let Some(value) = std::env::var_os("EOIE_CONFIG_HOME").filter(|value| !value.is_empty()) { return Some(std::path::PathBuf::from(value).join("spiral-compiler.path")); }
    if let Some(value) = std::env::var_os("XDG_CONFIG_HOME").filter(|value| !value.is_empty()) { return Some(std::path::PathBuf::from(value).join("eoie/spiral-compiler.path")); }
    #[cfg(windows)] if let Some(value) = std::env::var_os("APPDATA").filter(|v| !v.is_empty()) { return Some(std::path::PathBuf::from(value).join("eoie/spiral-compiler.path")); }
    std::env::var_os("HOME").or_else(|| std::env::var_os("USERPROFILE")).filter(|value| !value.is_empty()).map(|value| std::path::PathBuf::from(value).join(".config/eoie/spiral-compiler.path"))
}

fn configured_spiral_compiler() -> Result<Option<SpiralCompilerDiscovery>, String> {
    let Some(config) = spiral_compiler_config_path() else { return Ok(None); };
    let metadata = match std::fs::symlink_metadata(&config) {
        Ok(value) => value,
        Err(error) if error.kind() == std::io::ErrorKind::NotFound => return Ok(None),
        Err(error) => return Err(format!("inspect compiler config {}: {error}", config.display())),
    };
    if metadata.file_type().is_symlink() || !metadata.is_file() || metadata.len() > 4096 { return Err(format!("compiler config must be a regular non-symlink file <=4096 bytes: {}", config.display())); }
    let value = std::fs::read_to_string(&config).map_err(|error| format!("read compiler config {}: {error}", config.display()))?;
    let value = value.trim();
    if value.is_empty() || value.lines().count() != 1 { return Err(format!("compiler config must contain exactly one absolute path: {}", config.display())); }
    validate_spiral_compiler(std::path::Path::new(value), "config").map(Some)
}

fn path_spiral_compiler() -> Result<Option<SpiralCompilerDiscovery>, String> {
    let Some(path) = std::env::var_os("PATH") else { return Ok(None); };
    for directory in std::env::split_paths(&path) {
        for name in if cfg!(windows) { &["spiral-compile-session.exe", "spiral-compile.exe", "spiral-compile-session.cmd", "spiral-compile.cmd"][..] } else { &["spiral-compile-session", "spiral-compile"][..] } {
            let candidate = directory.join(name);
            if candidate.is_file() { return validate_spiral_compiler(&candidate, "PATH").map(Some); }
        }
    }
    Ok(None)
}

pub fn resolve_spiral_compiler(explicit: Option<&str>) -> Result<Option<SpiralCompilerDiscovery>, String> {
    if let Some(value) = explicit.filter(|value| !value.trim().is_empty()) { return validate_spiral_compiler(std::path::Path::new(value), "argument").map(Some); }
    if let Some(value) = std::env::var_os("EOIE_SPIRAL_COMPILE").filter(|value| !value.is_empty()) {
        let value = value.to_string_lossy();
        return validate_spiral_compiler(std::path::Path::new(value.as_ref()), "environment").map(Some);
    }
    if let Some(value) = configured_spiral_compiler()? { return Ok(Some(value)); }
    path_spiral_compiler()
}

fn spiral_main() -> i32 {
    0i32
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
