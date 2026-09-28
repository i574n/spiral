#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32) -> bool {
    let mut v1: bool = v0 == 42i32;
    v1
}
fn method0(mut v0: i32) -> bool {
    method1(v0)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 42i32;
    let mut v1: bool = method0(v0);
    if v1 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
