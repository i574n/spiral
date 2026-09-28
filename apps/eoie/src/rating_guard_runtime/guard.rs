#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
pub fn active_rating_receipt_check(root: &std::path::Path) -> Result<(), String> {
    let path = root.join("state/ratings.spi");
    let source = std::fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
    let mut observed = 0usize;
    for line in source.lines().filter(|line| line.contains("// active_rating")) {
        let score_text = line.split(',').nth(1).map(str::trim).ok_or_else(|| format!("malformed active rating row: {line}"))?;
        let score = score_text.trim_end_matches("u32").parse::<i32>().map_err(|_| format!("invalid active rating score: {score_text}"))?;
        if rating_guard_active_rating_ceiling_binding(score, 620) != 1 { return Err(format!("active rating ceiling rejected score={score} ceiling=620 row={line}")); }
        observed += 1;
    }
    if observed != 14 { return Err(format!("active rating marker count mismatch observed={observed} expected=14")); }
    Ok(())
}

fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
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
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    method0(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
pub fn rating_guard_active_rating_ceiling_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
