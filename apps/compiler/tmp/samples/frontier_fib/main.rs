#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> i32 {
    let mut v1: bool = v0 <= 1i32;
    if v1 {
        v0
    } else {
        let mut v2: i32 = v0 - 1i32;
        let mut v3: i32 = method0(v2);
        let mut v4: i32 = v0 - 2i32;
        let mut v5: i32 = method0(v4);
        let mut v6: i32 = v3 + v5;
        v6
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 10i32;
    let mut v1: i32 = method0(v0);
    let mut v2: i32 = v1 - 55i32;
    v2
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
