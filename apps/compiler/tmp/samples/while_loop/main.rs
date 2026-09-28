#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> bool {
    let mut v1: bool = v0 < 10i32;
    v1
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    let mut v1: i32 = 0i32;
    while method0(v0) {
        let mut v3: i32 = v1 + v0;
        v1 = v3;
        let mut v4: i32 = v0 + 1i32;
        v0 = v4;
        ()
    };
    let mut v5: i32 = v1 - 45i32;
    v5
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
