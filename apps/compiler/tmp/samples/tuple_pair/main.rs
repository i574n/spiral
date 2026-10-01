#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> (i32, i32) {
    (v0, v1)
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = v1 + v0;
    v2
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 20i32;
    let mut v1: i32 = 22i32;
    let (mut v2, mut v3): (i32, i32) = method0(v0, v1);
    let mut v4: i32 = method1(v3, v2);
    let mut v5: i32 = v4 - 42i32;
    v5
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
