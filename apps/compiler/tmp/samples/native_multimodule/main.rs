#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    let mut v3: i32 = v0 * v1;
    let mut v4: i32 = v3 + v2;
    let mut v5: i32 = v4 - 42i32;
    v5
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 5i32;
    let mut v1: i32 = 8i32;
    let mut v2: i32 = 2i32;
    method0(v0, v1, v2)
}
fn main() {
    std::process::exit(spiral_main());
}
