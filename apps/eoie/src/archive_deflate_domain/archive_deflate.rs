#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(clippy::needless_late_init)]
#![allow(clippy::items_after_test_module)]
use std::collections::BTreeSet;
use eoie_rust_std_fs::{rooted_list_names, rooted_open_regular_read, rooted_read_symlink};
use eoie_rust_std_fs_mutation::{rooted_create_directory_within, rooted_create_hardlink_within, rooted_create_regular_within, rooted_create_symlink_within, rooted_ensure_directory, rooted_promote_directory_within, rooted_remove_tree_within, rooted_set_directory_mode_within};
use std::io::{Read, Write};
use std::path::{Component, Path, PathBuf};
use zip::CompressionMethod;
use zip::ZipArchive;

const DEFAULT_ARCHIVE_LIMIT_BYTES: u64 = 256 * 1024 * 1024;

fn archive_fault_code() -> Result<i32, String> {
    match std::env::var("EOIE_ARCHIVE_FAULT").ok().as_deref() {
        None | Some("") | Some("none") => Ok(0),
        Some("after-first-payload") => Ok(1),
        Some("before-commit") => Ok(2),
        Some(value) => Err(format!("unknown EOIE_ARCHIVE_FAULT: {value}")),
    }
}

fn archive_arg<'a>(args: &'a [String], index: usize, name: &str) -> Result<&'a str, String> {
    args.get(index).map(String::as_str).ok_or_else(|| format!("missing argument: {name}"))
}

fn archive_safe_relative(path: &Path) -> bool {
    !path.as_os_str().is_empty()
        && !path.is_absolute()
        && path.components().all(|component| matches!(component, Component::Normal(_)))
}

pub fn archive_link_target_confined(link_relative: &Path, target: &Path) -> bool {
    if target.is_absolute() { return false; }
    let mut depth = link_relative.parent().map(|path| path.components().filter(|component| matches!(component, Component::Normal(_))).count()).unwrap_or(0);
    for component in target.components() {
        match component {
            Component::Normal(_) => depth += 1,
            Component::CurDir => {},
            Component::ParentDir => { if depth == 0 { return false; } depth -= 1; },
            _ => return false,
        }
    }
    true
}

pub fn archive_create_confined_symlink(link_relative: &Path, target: &Path, output: &Path, stage: &Path, size: u64) -> Result<(), String> {
    let confined = archive_link_target_confined(link_relative, target);
    if eoie_archive_tar_symlink_binding(i32::from(confined), i32::from(size == 0)) != 1 {
        return Err(format!("tar symlink rejected: {} -> {}", link_relative.display(), target.display()));
    }
    rooted_create_symlink_within(stage, output, target)?;
    Ok(())
}

pub fn archive_create_confined_hardlink(target_relative: &Path, output: &Path, stage: &Path, size: u64) -> Result<(), String> {
    let target_safe = archive_safe_relative(target_relative);
    let target = stage.join(target_relative);
    let target_regular = rooted_open_regular_read(&target).is_ok();
    if eoie_archive_tar_hardlink_binding(i32::from(target_safe && target_regular), i32::from(size == 0)) != 1 {
        return Err(format!("tar hardlink rejected: {} -> {}", output.display(), target_relative.display()));
    }
    if let Some(parent) = output.parent() { rooted_ensure_directory(parent)?; }
    rooted_create_hardlink_within(stage, &target, output)?;
    Ok(())
}

fn archive_validate_tree(root: &Path) -> Result<usize, String> {
    let mut stack = vec![root.to_path_buf()];
    let mut files = 0usize;
    while let Some(directory) = stack.pop() {
        let names = rooted_list_names(&directory)
            .map_err(|error| format!("list {}: {error}", directory.display()))?;
        for name in names {
            let path = directory.join(name);
            if let Ok(target) = rooted_read_symlink(&path) {
                let relative = path.strip_prefix(root).map_err(|error| format!("relative symlink {}: {error}", path.display()))?;
                if !archive_link_target_confined(relative, &target) { return Err(format!("extracted symlink escapes root: {} -> {}", relative.display(), target.display())); }
                files += 1;
            }
            else if rooted_list_names(&path).is_ok() {
                stack.push(path);
            }
            else if rooted_open_regular_read(&path).is_ok() {
                files += 1;
            }
            else { return Err(format!("unsupported extracted entry: {}", path.display())); }
        }
    }
    Ok(files)
}

pub fn archive_extract_with_limit(archive_path: &Path, destination: &Path, limit_bytes: u64) -> Result<(usize, usize, u64), String> {
    if eoie_archive_preflight_binding(i32::from(archive_path.is_file()), i32::from(!destination.exists())) != 1 {
        return Err(format!("archive preflight rejected archive={} destination={}", archive_path.display(), destination.display()));
    }
    if limit_bytes == 0 || limit_bytes > i32::MAX as u64 { return Err("archive limit must be between 1 and i32::MAX".to_owned()); }
    let fault = archive_fault_code()?;
    let parent = destination.parent().ok_or_else(|| format!("destination has no parent: {}", destination.display()))?;
    rooted_ensure_directory(parent)?;
    let name = destination.file_name().and_then(|value| value.to_str()).unwrap_or("archive");
    let stage = parent.join(format!(".{name}.eoie-extract-{}", std::process::id()));
    if stage.exists() { return Err(format!("staging path already exists: {}", stage.display())); }
    rooted_create_directory_within(parent, &stage)?;
    let result = (|| {
        let file = rooted_open_regular_read(archive_path).map_err(|error| format!("open archive {}: {error}", archive_path.display()))?;
        let mut archive = ZipArchive::new(file).map_err(|error| format!("open zip {}: {error}", archive_path.display()))?;
        let entries_total = archive.len();
        let mut payloads = 0usize;
        let mut total_bytes = 0u64;
        let mut seen = BTreeSet::<PathBuf>::new();
        for index in 0..entries_total {
            let mut entry = archive.by_index(index).map_err(|error| format!("read zip entry {index}: {error}"))?;
            let relative = entry.enclosed_name().map(Path::to_path_buf).ok_or_else(|| format!("unsafe zip entry: {}", entry.name()))?;
            if !archive_safe_relative(&relative) { return Err(format!("unsafe zip entry path: {}", relative.display())); }
            if !seen.insert(relative.clone()) { return Err(format!("duplicate zip entry: {}", relative.display())); }
            let compression_supported = matches!(entry.compression(), CompressionMethod::Stored | CompressionMethod::Deflated);
            let mode = entry.unix_mode().unwrap_or(if entry.is_dir() { 0o755 } else { 0o644 });
            let is_symlink = mode & 0o170000 == 0o120000;
            if eoie_archive_compression_binding(1, i32::from(compression_supported)) != 1 {
                return Err(format!("zip entry rejected path={} compression={:?} mode={mode:o}", relative.display(), entry.compression()));
            }
            let output = stage.join(&relative);
            if entry.is_dir() {
                if is_symlink || eoie_archive_entry_binding(1, 1) != 1 { return Err(format!("directory zip entry rejected: {}", relative.display())); }
                rooted_ensure_directory(&output)?;
                rooted_set_directory_mode_within(&stage, &output, mode)?;
                continue;
            }
            let declared = entry.size();
            let projected = total_bytes.checked_add(declared).ok_or_else(|| "archive size overflow".to_owned())?;
            if projected > limit_bytes { return Err(format!("archive budget exceeded projected={projected} limit={limit_bytes}")); }
            if let Some(parent) = output.parent() { rooted_ensure_directory(parent)?; }
            if is_symlink {
                let mut bytes = Vec::new();
                entry.read_to_end(&mut bytes).map_err(|error| format!("read symlink {}: {error}", relative.display()))?;
                total_bytes = total_bytes.checked_add(bytes.len() as u64).ok_or_else(|| "archive size overflow".to_owned())?;
                if total_bytes > limit_bytes || bytes.len() as u64 != declared { return Err(format!("symlink payload budget or size mismatch: {}", relative.display())); }
                let target_text = String::from_utf8(bytes).map_err(|_| format!("symlink target is not UTF-8: {}", relative.display()))?;
                let target = PathBuf::from(target_text);
                let confined = archive_link_target_confined(&relative, &target);
                if eoie_archive_entry_binding(1, i32::from(confined)) != 1 { return Err(format!("zip symlink escapes root: {} -> {}", relative.display(), target.display())); }
                rooted_create_symlink_within(&stage, &output, &target)?;
                payloads += 1;
                if eoie_archive_fault_binding(fault, 1) == 1 {
                    return Err("injected archive fault after-first-payload".to_owned());
                }
                continue;
            }
            if eoie_archive_entry_binding(1, 1) != 1 { return Err(format!("zip file entry rejected: {}", relative.display())); }
            let mut output_file = rooted_create_regular_within(&stage, &output, mode)?;
            let mut written = 0u64;
            let mut buffer = [0u8; 64 * 1024];
            loop {
                let count = entry.read(&mut buffer).map_err(|error| format!("decompress {}: {error}", relative.display()))?;
                if count == 0 { break; }
                written = written.checked_add(count as u64).ok_or_else(|| "entry size overflow".to_owned())?;
                total_bytes = total_bytes.checked_add(count as u64).ok_or_else(|| "archive size overflow".to_owned())?;
                if total_bytes > limit_bytes { return Err(format!("archive budget exceeded observed={total_bytes} limit={limit_bytes}")); }
                output_file.write_all(&buffer[..count]).map_err(|error| format!("write {}: {error}", output.display()))?;
            }
            if written != declared { return Err(format!("zip entry size mismatch path={} declared={declared} written={written}", relative.display())); }
            output_file.sync_all().map_err(|error| format!("sync {}: {error}", output.display()))?;
            payloads += 1;
            if eoie_archive_fault_binding(fault, 1) == 1 {
                return Err("injected archive fault after-first-payload".to_owned());
            }
        }
        if eoie_archive_budget_binding(limit_bytes as i32, total_bytes as i32) != 1 { return Err("typed archive budget rejected".to_owned()); }
        let tree_files = archive_validate_tree(&stage)?;
        if eoie_archive_complete_binding(payloads as i32, tree_files as i32) != 1 || eoie_archive_tree_binding(1, 1) != 1 {
            return Err(format!("typed archive completion rejected payloads={payloads} tree_files={tree_files}"));
        }
        if eoie_archive_fault_binding(fault, 2) == 1 {
            return Err("injected archive fault before-commit".to_owned());
        }
        Ok((entries_total, payloads, total_bytes))
    })();
    match result {
        Ok(receipt) => {
            rooted_promote_directory_within(parent, &stage, destination)?;
            Ok(receipt)
        }
        Err(error) => {
            if let Err(rollback) = rooted_remove_tree_within(parent, &stage) {
                return Err(format!("archive extraction failed: {error}; rollback failed: {rollback}"));
            }
            Err(format!("archive extraction rolled back: {error}"))
        }
    }
}

pub fn archive_extract_run(args: &[String]) -> Result<(), String> {
    if args.len() != 3 { return Err("zip-extract expects archive.zip destination".to_owned()); }
    let archive = Path::new(archive_arg(args, 1, "archive.zip")?);
    let destination = Path::new(archive_arg(args, 2, "destination")?);
    let limit = std::env::var("EOIE_ARCHIVE_MAX_BYTES").ok().and_then(|value| value.parse::<u64>().ok()).unwrap_or(DEFAULT_ARCHIVE_LIMIT_BYTES);
    let (entries, payloads, bytes) = archive_extract_with_limit(archive, destination, limit)?;
    println!("eoie proxy zip-extract ok entries_total={entries} payloads={payloads} bytes={bytes} compression=stored,deflate receipt=typed-generic");
    Ok(())
}
use std::cell::RefCell;
use std::rc::Rc;
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
fn method2(mut v0: i32, mut v1: i32) -> i32 {
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
        let mut v3: bool = v1 < 0i32;
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
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
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
fn method9(mut v0: i32, mut v1: i32) -> i32 {
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
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 4i32 < v0;
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
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 2i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 2i32 < v1;
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
        method8(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method9(v0, v1)
    })
}
fn closure10() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method11(v0, v1)
    })
}
pub fn eoie_archive_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_archive_entry_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_archive_tar_symlink_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_archive_tar_hardlink_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_archive_tar_long_link_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_archive_tar_pax_path_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_archive_compression_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_archive_budget_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_archive_complete_binding(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_archive_tree_binding(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
pub fn eoie_archive_format_binding(v0: i32, v1: i32) -> i32 {
    closure10()(v0, v1)
}
pub fn eoie_archive_fault_binding(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
