#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> bool {
    let mut v2: i32 = -v0 ;
    let mut v3: bool = v2 <= 0i32;
    if v3 {
        let mut v4: i32 = v1 * 2i32;
        let mut v5: i32 = v0 + v4;
        let mut v6: bool = v5 >= 9i32;
        if v6 {
            true
        } else {
            let mut v7: bool = v1 == 0i32;
            v7
        }
    } else {
        false
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 3i32;
    let mut v2: bool = method0(v0, v1);
    if v2 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
