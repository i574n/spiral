#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_proxy_search::{inspection_sha256, manifest_collect};
use std::collections::{BTreeMap, BTreeSet};
use std::path::Path;

fn product_manifest_index(entries: Vec<String>) -> Result<BTreeMap<String,String>, String> {
    let mut index = BTreeMap::new();
    for entry in entries {
        let cells = entry.split(char::from(9u8)).collect::<Vec<_>>();
        let (path, signature) = match cells.first().copied() {
            Some("d") if cells.len() == 3 => (cells[2].to_owned(), "d".to_owned()),
            Some("f") if cells.len() == 5 => (cells[2].to_owned(), format!("f\t{}\t{}", cells[3], cells[4])),
            _ => return Err(format!("invalid manifest entry: {entry}")),
        };
        if index.insert(path.clone(), signature).is_some() { return Err(format!("duplicate manifest path: {path}")); }
    }
    Ok(index)
}

pub fn product_diff_run(args: &[String]) -> Result<(), String> {
    if args.len() != 3 { return Err("product-diff expects left-root right-root".to_owned()); }
    let left_root = Path::new(args.get(1).map(String::as_str).ok_or_else(|| "missing left-root".to_owned())?);
    let right_root = Path::new(args.get(2).map(String::as_str).ok_or_else(|| "missing right-root".to_owned())?);
    if eoie_product_diff_request_binding(i32::from(left_root.is_dir()), i32::from(right_root.is_dir())) != 1 { return Err("typed product-diff request rejected".to_owned()); }
    let limit = std::env::var("EOIE_PRODUCT_DIFF_MAX_ENTRIES").ok().and_then(|value| value.parse::<usize>().ok()).unwrap_or(200_000);
    let workers = std::env::var("EOIE_PARALLEL_WORKERS").ok().and_then(|value| value.parse::<usize>().ok()).unwrap_or(56);
    if eoie_product_diff_worker_binding(workers as i32, 56) != 1 { return Err("typed product-diff worker request rejected".to_owned()); }
    let pool = rayon::ThreadPoolBuilder::new().num_threads(workers).build().map_err(|error| format!("build Rayon pool: {error}"))?;
    let (left_manifest, right_manifest) = pool.install(|| rayon::join(|| manifest_collect(left_root, left_root, limit, true), || manifest_collect(right_root, right_root, limit, true)));
    let left_manifest = left_manifest?;
    let right_manifest = right_manifest?;
    let manifest_hash = |entries: &[String]| { let mut bytes = Vec::new(); for entry in entries { bytes.extend_from_slice(entry.as_bytes()); bytes.push(10u8); } inspection_sha256(bytes) };
    let left_hash = manifest_hash(&left_manifest);
    let right_hash = manifest_hash(&right_manifest);
    let left = product_manifest_index(left_manifest)?;
    let right = product_manifest_index(right_manifest)?;
    let keys = left.keys().chain(right.keys()).cloned().collect::<BTreeSet<_>>();
    let mut added = 0usize; let mut removed = 0usize; let mut changed = 0usize; let mut unchanged = 0usize;
    for key in keys { match (left.get(&key), right.get(&key)) {
        (None, Some(after)) => { added += 1; println!("product-diff change=added path={key} after={after}"); }
        (Some(before), None) => { removed += 1; println!("product-diff change=removed path={key} before={before}"); }
        (Some(before), Some(after)) if before != after => { changed += 1; println!("product-diff change=changed path={key} before={before} after={after}"); }
        (Some(_), Some(_)) => unchanged += 1,
        (None, None) => {}
    }}
    let changed_entries = added + removed + changed;
    let total = changed_entries + unchanged;
    if eoie_product_diff_summary_binding(changed_entries as i32, total as i32) != 1 { return Err("typed product-diff summary rejected".to_owned()); }
    println!("eoie proxy product-diff ok left={} right={} workers={workers} added={added} removed={removed} changed={changed} unchanged={unchanged} total={total} exact={} left_sha256={left_hash} right_sha256={right_hash}", left_root.display(), right_root.display(), changed_entries == 0);
    Ok(())
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum SourceRecoveryProvenance { Authored, Generated, CompilerSidecar }

#[derive(Clone, Debug)]
struct SourceRecoveryFile { rel: String, name: String, bytes: usize, fingerprint: u64 }

#[derive(Default)]
struct SourceRecoveryIndex { authored: Vec<SourceRecoveryFile>, generated: usize, sidecars: usize }

fn source_recovery_hash(bytes: &[u8]) -> u64 {
    let mut hash = 14695981039346656037u64;
    for byte in bytes { hash ^= u64::from(*byte); hash = hash.wrapping_mul(1099511628211); }
    hash
}

fn source_recovery_skip(path: &std::path::Path) -> bool {
    matches!(path.file_name().and_then(|value| value.to_str()), Some("vendor" | "target" | ".git" | ".cargo"))
}

fn source_recovery_track(path: &std::path::Path) -> bool {
    let name = path.file_name().and_then(|value| value.to_str()).unwrap_or_default();
    if matches!(name, "Cargo.toml" | "package.spiproj" | "README.md") { return true; }
    matches!(path.extension().and_then(|value| value.to_str()), Some("spi" | "rs" | "cpp" | "hpp" | "h" | "c" | "md"))
}

fn source_recovery_sidecar(path: &std::path::Path) -> bool {
    let name = path.file_name().and_then(|value| value.to_str()).unwrap_or_default();
    if name == ".spiral-entry" || name.starts_with(".eoie-typecheck-") { return true; }
    if path.extension().and_then(|value| value.to_str()) == Some("c") {
        let mut spi = path.to_path_buf();
        spi.set_extension("spi");
        if spi.is_file() { return true; }
    }
    false
}

fn source_recovery_provenance(root: &std::path::Path, path: &std::path::Path) -> Result<SourceRecoveryProvenance, String> {
    let sidecar = source_recovery_sidecar(path);
    let generated = if sidecar { false } else { eoie_source_map::source_generated_residual(root, path)? };
    let code = eoie_source_recovery_provenance_binding(i32::from(sidecar), i32::from(generated));
    match code {
        1 => Ok(SourceRecoveryProvenance::Authored),
        2 => Ok(SourceRecoveryProvenance::Generated),
        3 => Ok(SourceRecoveryProvenance::CompilerSidecar),
        _ => Err(format!("invalid source recovery provenance: {}", path.display())),
    }
}

fn source_recovery_walk(root: &std::path::Path, path: &std::path::Path, index: &mut SourceRecoveryIndex) -> Result<(), String> {
    let metadata = std::fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("source-recovery-diff rejects symlink: {}", path.display())); }
    if metadata.is_dir() {
        if path != root && source_recovery_skip(path) { return Ok(()); }
        let mut entries = std::fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))?
            .map(|entry| entry.map(|value| value.path()).map_err(|error| error.to_string()))
            .collect::<Result<Vec<_>, _>>()?;
        entries.sort();
        for child in entries { source_recovery_walk(root, &child, index)?; }
        return Ok(());
    }
    if !metadata.is_file() || !source_recovery_track(path) { return Ok(()); }
    match source_recovery_provenance(root, path)? {
        SourceRecoveryProvenance::Generated => index.generated += 1,
        SourceRecoveryProvenance::CompilerSidecar => index.sidecars += 1,
        SourceRecoveryProvenance::Authored => {
            let bytes = std::fs::read(path).map_err(|error| format!("read {}: {error}", path.display()))?;
            if std::str::from_utf8(&bytes).is_err() { return Ok(()); }
            index.authored.push(SourceRecoveryFile {
                rel: path.strip_prefix(root).unwrap_or(path).to_string_lossy().replace('\\', "/"),
                name: path.file_name().and_then(|value| value.to_str()).unwrap_or_default().to_owned(),
                bytes: bytes.len(),
                fingerprint: source_recovery_hash(&bytes),
            });
        }
    }
    Ok(())
}

fn source_recovery_collect(root: &std::path::Path) -> Result<SourceRecoveryIndex, String> {
    if !root.is_dir() { return Err(format!("source-recovery root is not a directory: {}", root.display())); }
    let mut index = SourceRecoveryIndex::default();
    source_recovery_walk(root, root, &mut index)?;
    index.authored.sort_by(|a, b| a.rel.cmp(&b.rel));
    Ok(index)
}

pub fn source_recovery_run(args: &[String]) -> Result<(), String> {
    if args.len() < 3 { return Err("source-recovery-diff expects current-root candidate-root [candidate-root ...]".to_owned()); }
    let current_root = std::path::Path::new(&args[1]);
    let current = source_recovery_collect(current_root)?;
    let exact = current.authored.iter().map(|file| file.fingerprint).collect::<std::collections::BTreeSet<_>>();
    let basenames = current.authored.iter().map(|file| file.name.clone()).collect::<std::collections::BTreeSet<_>>();
    println!("eoie proxy source-recovery-diff current={} authored={} generated={} sidecars={} fingerprints={} basenames={}", current_root.display(), current.authored.len(), current.generated, current.sidecars, exact.len(), basenames.len());
    let mut any_warning = false;
    for candidate_arg in &args[2..] {
        let candidate_root = std::path::Path::new(candidate_arg);
        let candidate = source_recovery_collect(candidate_root)?;
        let mut exact_count = 0usize;
        let mut basename_count = 0usize;
        let mut missing_by_name = 0usize;
        let mut missing_large = 0usize;
        let mut warnings = 0usize;
        for file in &candidate.authored {
            if exact.contains(&file.fingerprint) { exact_count += 1; }
            if basenames.contains(&file.name) { basename_count += 1; } else {
                missing_by_name += 1;
                if file.bytes >= 4096 {
                    missing_large += 1;
                    if warnings < 32 { println!("source-recovery missing path={} bytes={} fingerprint={:016x} status=warn", file.rel, file.bytes, file.fingerprint); warnings += 1; }
                }
            }
        }
        if eoie_source_recovery_warning_binding(missing_large as i32, candidate.authored.len() as i32) != 1 { return Err("invalid source recovery warning counts".to_owned()); }
        any_warning |= missing_large > 0;
        println!("source-recovery candidate={} authored={} exact={} basename={} missing_by_name={} missing_large={} filtered_generated={} filtered_sidecars={} status={}", candidate_root.display(), candidate.authored.len(), exact_count, basename_count, missing_by_name, missing_large, candidate.generated, candidate.sidecars, if missing_large == 0 { "pass" } else { "warn" });
    }
    println!("eoie proxy source-recovery-diff ok status={}", if any_warning { "warn" } else { "pass" });
    Ok(())
}

fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 1i32;
    if v2 {
        let mut v3: bool = v1 == 1i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    method1(v0, v1)
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < v0;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    method3(v0, v1)
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < v0;
        if v3 {
            0i32
        } else {
            1i32
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    method5(v0, v1)
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
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
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v0 == 1i32;
                    if v6 {
                        let mut v7: bool = v1 == 1i32;
                        if v7 {
                            0i32
                        } else {
                            3i32
                        }
                    } else {
                        let mut v9: bool = v1 == 1i32;
                        if v9 {
                            2i32
                        } else {
                            1i32
                        }
                    }
                }
            }
        }
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < v0;
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
        method2(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method4(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method7(v0, v1)
    })
}
pub fn eoie_product_diff_request_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_product_diff_summary_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_product_diff_worker_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_source_recovery_provenance_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_source_recovery_warning_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
