#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> (i32, i32, i32, i32) {
    let mut v1: i32 = v0 + 1i32;
    let mut v2: i32 = v0 + 2i32;
    let mut v3: i32 = v0 + 3i32;
    (v0, v1, v2, v3)
}
fn method1(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    let mut v4: i32 = v0 + v1;
    let mut v5: i32 = v4 + v2;
    let mut v6: i32 = v5 + v3;
    let mut v7: i32 = v6 - 10i32;
    v7
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let (mut v1, mut v2, mut v3, mut v4): (i32, i32, i32, i32) = method0(v0);
    method1(v1, v2, v3, v4)
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
