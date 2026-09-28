#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = -42i32;
    let mut v1: i32 = spiral_abi_libc_abs(v0);
    v1
}
fn main() {
    std::process::exit(spiral_main());
}
