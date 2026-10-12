#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i64 = 5000000007i64;
    let mut v1: i64 = 1000i64;
    let mut v2: i64 = spiral_abi_libc_lldiv_pack(v0,v1);
    let mut v3: bool = v2 == 5000000007;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
