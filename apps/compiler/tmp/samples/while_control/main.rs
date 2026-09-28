#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0() -> bool {
    true
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    let mut v1: i32 = 0i32;
    while method0() {
        let mut v3: i32 = v0 + 1i32;
        v0 = v3;
        let mut v4: bool = v0 < 3i32;
        if v4 {
            continue;
            ()
        } else {
            let mut v5: bool = v0 >= 6i32;
            if v5 {
                break;
                ()
            } else {
                let mut v6: i32 = v1 + v0;
                v1 = v6;
                ()
            }
        }
    };
    let mut v7: i32 = v1 - 12i32;
    v7
}
fn main() {
    std::process::exit(spiral_main());
}
