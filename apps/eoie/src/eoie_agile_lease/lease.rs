#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use agile_state_runtime_policy_domain::{eoie_agile_lease_clock_phase_binding, eoie_agile_lease_readback_decision_binding, eoie_agile_prompt_lease_marker_text, eoie_agile_prompt_lease_shape_binding, eoie_agile_prompt_lease_status_code, eoie_agile_spi_escape_text, eoie_agile_state_package_line_code, eoie_agile_state_package_module_name};
use eoie_agile_policy::{eoie_agile_attestation_normalize_binding, eoie_agile_attestation_value_binding, eoie_agile_tuple_parse_binding, eoie_agile_u64_decimal_normalize_binding, eoie_agile_u64_decimal_value_binding, eoie_agile_u64_literal_normalize_binding, eoie_agile_u64_literal_value_binding};
use eoie_rust_std_fs::read_regular_text_limited as lease_read_regular_text_limited;
use std::path::{Path, PathBuf};
use std::time::{SystemTime, UNIX_EPOCH};

pub fn agile_now_unix_ms() -> Result<u64, String> {
    let duration = SystemTime::now().duration_since(UNIX_EPOCH).map_err(|error| format!("system clock before unix epoch: {error}"))?;
    u64::try_from(duration.as_millis()).map_err(|_| "unix millisecond clock overflow".to_owned())
}

pub fn agile_tuple_fields(input: &str) -> Result<Vec<String>, String> {
    let canonical = eoie_agile_tuple_parse_binding(input);
    if canonical.is_empty() { return Err("invalid tuple fields".to_owned()); }
    Ok(canonical.lines().map(str::to_owned).collect())
}

pub fn agile_build_fingerprint(attestation: &str) -> Result<Option<u64>, String> {
    let normalized = eoie_agile_attestation_normalize_binding(attestation);
    if normalized.is_empty() { return Err(format!("invalid module receipt attestation: {attestation}")); }
    if normalized.as_ref() == "runtime" { return Ok(None); }
    Ok(Some(eoie_agile_attestation_value_binding(attestation)))
}

pub fn agile_escape_spi(value: &str) -> String {
    eoie_agile_spi_escape_text(value).as_ref().to_owned()
}

pub fn agile_parse_u64_decimal(value: &str, label: &str) -> Result<u64, String> {
    let normalized = eoie_agile_u64_decimal_normalize_binding(value);
    if normalized.is_empty() { return Err(format!("{label} is not a canonical u64 decimal")); }
    Ok(eoie_agile_u64_decimal_value_binding(value))
}

fn agile_parse_u64_literal(value: &str, label: &str) -> Result<u64, String> {
    let normalized = eoie_agile_u64_literal_normalize_binding(value);
    if normalized.is_empty() { return Err(format!("{label} is not a u64 literal")); }
    Ok(eoie_agile_u64_literal_value_binding(value))
}

pub fn agile_package_modules_and_anchor(state_dir: &Path) -> Result<(std::collections::BTreeSet<String>, PathBuf), String> {
    let source = lease_read_regular_text_limited(&state_dir.join("package.spiproj"), 1024 * 1024)?;
    let mut modules = std::collections::BTreeSet::new();
    let mut in_modules = false;
    let mut last = None;
    for raw in source.lines() {
        match eoie_agile_state_package_line_code(raw) {
            1 => { in_modules = true; continue; }
            3 => { if in_modules { break; } else { continue; } }
            2 if in_modules => {
                let module = eoie_agile_state_package_module_name(raw);
                if module.is_empty() { return Err(format!("invalid flat state module in package.spiproj: {}", raw.trim())); }
                let module = module.as_ref().to_owned();
                last = Some(state_dir.join(&module));
                modules.insert(module);
            }
            _ => continue,
        }
    }
    let anchor = last.ok_or_else(|| "state package declares no modules".to_owned())?;
    Ok((modules, anchor))
}

pub fn agile_prompt_lease_clock(root: &Path) -> Result<(u64, u64, u64, u64, bool, bool), String> {
    let state = root.join("state/prompt.spi");
    let source = lease_read_regular_text_limited(&state, 1024 * 1024)?;
    let marker = eoie_agile_prompt_lease_marker_text("1");
    if marker.is_empty() { return Err("typed Spiral prompt lease marker is unavailable".to_owned()); }
    let line = source.lines().find(|line| line.contains(marker.as_ref())).ok_or_else(|| "prompt lease row is missing".to_owned())?;
    let start = line.find(marker.as_ref()).ok_or_else(|| "prompt lease start is missing".to_owned())? + marker.len();
    let end = line.rfind(')').ok_or_else(|| "prompt lease terminator is missing".to_owned())?;
    let parts = agile_tuple_fields(&line[start..end])?;
    let active_status = parts.get(6).map(|value| eoie_agile_prompt_lease_status_code(value.trim())).unwrap_or(0);
    if eoie_agile_prompt_lease_shape_binding(parts.len() as i32, active_status as i32) != 1 { return Err(format!("typed Spiral PromptLease shape/status rejected fields={}", parts.len())); }
    let budget_ms = agile_parse_u64_literal(&parts[2], "budget_ms")?;
    let guard_ms = agile_parse_u64_literal(&parts[3], "guard_ms")?;
    let started_unix_ms = agile_parse_u64_literal(&parts[4], "started_unix_ms")?;
    let deadline_unix_ms = agile_parse_u64_literal(&parts[5], "deadline_unix_ms")?;
    let expected_deadline = started_unix_ms.checked_add(budget_ms).and_then(|value| value.checked_add(guard_ms)).ok_or_else(|| "prompt lease deadline overflow".to_owned())?;
    if eoie_agile_lease_readback_decision_binding(1, i32::from(deadline_unix_ms == expected_deadline)) != 1 { return Err(format!("prompt lease deadline mismatch expected={expected_deadline} observed={deadline_unix_ms}")); }
    let now_unix_ms = agile_now_unix_ms()?;
    let wrap_at_unix_ms = deadline_unix_ms.saturating_sub(guard_ms);
    let phase = eoie_agile_lease_clock_phase_binding(i32::from(now_unix_ms >= wrap_at_unix_ms), i32::from(now_unix_ms >= deadline_unix_ms));
    let (should_wrap, should_yield) = match phase { 0 => (false, false), 1 => (true, false), 2 => (true, true), _ => return Err("typed Spiral lease clock phase rejected".to_owned()) };
    let remaining_ms = deadline_unix_ms.saturating_sub(now_unix_ms);
    Ok((started_unix_ms, deadline_unix_ms, wrap_at_unix_ms, remaining_ms, should_wrap, should_yield))
}

use command_spec_domain::{eoie_command_effect_code, eoie_command_subcommand_effect_code};

pub fn lease_effect_code() -> i32 {
    let mut args = std::env::args();
    let _ = args.next();
    let verb = args.next().unwrap_or_default();
    let sub = args.next().unwrap_or_default();
    let base = eoie_command_effect_code(&verb);
    let key = format!("{verb}:{sub}");
    let specialized = eoie_command_subcommand_effect_code(&key);
    let effect = if specialized <= 3 { specialized } else { base };
    if effect <= 3 { effect as i32 } else { 4 }
}

fn find_lease_root() -> Result<Option<PathBuf>, String> {
    if let Some(value) = std::env::var_os("EOIE_LEASE_ROOT") {
        let root = PathBuf::from(value);
        if !root.is_dir() || !root.join("state/prompt.spi").is_file() { return Err(format!("EOIE_LEASE_ROOT is not a workspace lease root: {}", root.display())); }
        agile_prompt_lease_clock(&root)?;
        return Ok(Some(root));
    }
    let mut candidates = std::env::args().skip(2).map(PathBuf::from).filter(|path| path.is_dir() && path.join("state/prompt.spi").is_file()).collect::<Vec<_>>();
    if std::env::var_os("EOIE_CONTROL_READ_ONLY").is_none() {
        let current = std::env::current_dir().map_err(|error| format!("lease current_dir: {error}"))?;
        candidates.extend(current.ancestors().filter(|path| path.join("state/prompt.spi").is_file()).map(Path::to_path_buf));
    }
    candidates.sort(); candidates.dedup();
    Ok(candidates.into_iter().filter_map(|root| agile_prompt_lease_clock(&root).ok().map(|clock| (clock.0, root))).max_by_key(|(started, _)| *started).map(|(_, root)| root))
}

pub fn lease_wrap_code() -> i32 {
    let root = match find_lease_root() { Ok(Some(root)) => root, Ok(None) => return 0, Err(_) => return 2 };
    match agile_prompt_lease_clock(&root) { Ok((_, _, _, _, should_wrap, _)) => i32::from(should_wrap), Err(_) => 2 }
}

#[must_use]
pub fn lease_authority_code() -> i32 {
    let effect = lease_effect_code();
    if std::env::var_os("EOIE_CONTROL_READ_ONLY").is_some() && effect == 2 { eprintln!("eoie error: control/baseline read-only mode rejects semantic mutation; write receipts to the active workspace instead"); return 2; }
    match effect {
        0 | 1 | 3 => 0,
        2 => match lease_wrap_code() { 0 => 0, 1 => lease_rejected(), _ => lease_guard_error() },
        _ => lease_guard_error(),
    }
}

#[must_use]
pub fn lease_rejected() -> i32 {
    eprintln!("eoie error: lease authority blocked mutating effect because should_wrap=1; semantic mutation stops at the guard boundary; should_yield becomes 1 only at the hard deadline; wrap remains available");
    2
}

#[must_use]
pub fn lease_guard_error() -> i32 {
    eprintln!("eoie error: lease authority could not validate the active workspace lease");
    2
}

fn method1(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: bool) -> i32 {
    loop {
        let mut v4: bool = v0 < v1;
        if v4 {
            let mut v5: i32 = 2i32;
            let mut v6: i32 = usize::try_from(v5).ok().and_then(|index| std::env::args().skip(2).nth(index)).and_then(|value| usize::try_from(v0).ok().and_then(|offset| value.as_bytes().get(offset).copied())).map_or(-1, i32::from);
            let mut v7: bool = v6 == 32i32;
            let mut v9: bool = if v7 {
                true
            } else {
                let mut v8: bool = v6 == 9i32;
                v8
            };
            if v9 {
                if v3 {
                    let mut v10: i32 = v0 + 1i32;
                    let mut v11: i32 = v2 + 1i32;
                    let mut v12: bool = false;
                    (v0, v1, v2, v3) = (v10, v1, v11, v12);
                    continue;
                } else {
                    let mut v14: i32 = v0 + 1i32;
                    let mut v15: bool = false;
                    (v0, v1, v2, v3) = (v14, v1, v2, v15);
                    continue;
                }
            } else {
                let mut v18: bool = 33i32 <= v6;
                let mut v20: bool = if v18 {
                    let mut v19: bool = v6 <= 126i32;
                    v19
                } else {
                    false
                };
                if v20 {
                    let mut v21: i32 = v0 + 1i32;
                    let mut v22: bool = true;
                    (v0, v1, v2, v3) = (v21, v1, v2, v22);
                    continue;
                } else {
                    let mut v24: i32 = -1;
                    return v24;
                }
            }
        } else {
            let mut v28: i32 = if v3 {
                let mut v27: i32 = v2 + 1i32;
                v27
            } else {
                v2
            };
            let mut v29: bool = 3i32 <= v28;
            if v29 {
                let mut v30: bool = v28 <= 7i32;
                if v30 {
                    return v28;
                } else {
                    let mut v31: i32 = -1;
                    return v31;
                }
            } else {
                let mut v33: i32 = -1;
                return v33;
            }
        }
    }
}
fn method0() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: i32 = usize::try_from(v0).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or(-1, |value| i32::try_from(value.len()).unwrap_or(i32::MAX));
    let mut v2: bool = 0 < v1;
    if v2 {
        let mut v3: i32 = 0i32;
        let mut v4: i32 = 0i32;
        let mut v5: bool = false;
        method1(v3, v1, v4, v5)
    } else {
        let mut v7: i32 = -1;
        v7
    }
}
fn closure0() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method0()
    })
}
pub fn eoie_lease_title_words() -> i32 {
    closure0()()
}
