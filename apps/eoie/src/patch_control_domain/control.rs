#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use std::env;
use std::path::{Path, PathBuf};

pub fn patch_safe_relative(value: &str) -> Result<PathBuf, String> { eoie_rust_std_fs::safe_relative_path(value) }

pub fn patch_rooted(root: &Path, relative: &str) -> Result<PathBuf, String> { eoie_rust_std_fs::rooted_path(root, relative) }

pub fn patch_target_max_bytes() -> Result<usize, String> {
    let value = env::var("EOIE_PATCH_TARGET_MAX_BYTES")
        .unwrap_or_else(|_| "1048576".to_owned());
    let limit = value
        .parse::<usize>()
        .map_err(|_| "EOIE_PATCH_TARGET_MAX_BYTES must be a positive integer".to_owned())?;
    if limit == 0 || limit > i32::MAX as usize {
        return Err("EOIE_PATCH_TARGET_MAX_BYTES is outside the typed i32 range".to_owned());
    }
    Ok(limit)
}

#[derive(Clone)]
pub struct PatchExactValue {
    pub relative: String,
    pub before: String,
    pub after: String,
}

pub fn patch_quoted_fields(line: &str) -> Result<Vec<String>, String> {
    let chars: Vec<char> = line.chars().collect();
    let mut fields = Vec::new();
    let mut index = 0usize;
    while index < chars.len() {
        if chars[index] != '"' { index += 1; continue; }
        index += 1;
        let mut value = String::new();
        let mut closed = false;
        while index < chars.len() {
            let current = chars[index];
            index += 1;
            if current == '"' { closed = true; break; }
            if current == '\\' {
                if index >= chars.len() { return Err("unterminated escape in quoted field".to_owned()); }
                let escaped = chars[index];
                index += 1;
                value.push(match escaped { 'n' => '\n', 'r' => '\r', 't' => '\t', '\\' => '\\', '"' => '"', other => return Err(format!("unsupported escape: \\{other}")), });
            } else { value.push(current); }
        }
        if !closed { return Err("unterminated quoted field".to_owned()); }
        fields.push(value);
    }
    Ok(fields)
}

pub fn parse_patch_exact_source(source: &str) -> Result<Vec<PatchExactValue>, String> {
    {
        let rows = canonical_plan_ir_domain::parse_plan_ir_manifest(source)?;
        let mut patches = Vec::with_capacity(rows.len());
        for row in rows {
            if canonical_plan_ir_domain::eoie_plan_ir_decode_code(&row.op, &row.target, &row.expected, &row.payload, &row.effect) != 2 {
                return Err("compiled Plan IR contains a non-patch operation".to_owned());
            }
            patches.push(PatchExactValue { relative: row.target, before: row.expected, after: row.payload });
        }
        return Ok(patches);
    }
}

pub fn patch_occurrence_count(text: &str, needle: &str) -> usize {
    if needle.is_empty() {
        return text.chars().count() + 1;
    }
    text.char_indices()
        .filter(|(index, _)| text[*index..].starts_with(needle))
        .count()
}

fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    -1i32
                } else {
                    v0
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 1i32 < v1;
            if v4 {
                -1i32
            } else {
                v0
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 2i32 < v1;
            if v4 {
                -1i32
            } else {
                v0
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
pub fn eoie_patch_restoration_payload_identity(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_patch_restoration_payload_slot_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_patch_restoration_payload_outcome_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
