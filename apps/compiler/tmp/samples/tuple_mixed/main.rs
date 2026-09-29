#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: f32) -> (bool, f32, i32) {
    let mut v1: bool = v0 >= 3.5f32;
    (v1, v0, 7i32)
}
fn method1(mut v0: i32, mut v1: f32, mut v2: bool) -> i32 {
    if v2 {
        let mut v3: bool = v1 >= 3.5f32;
        if v3 {
            let mut v4: i32 = v0 - 7i32;
            v4
        } else {
            1i32
        }
    } else {
        2i32
    }
}
fn spiral_main() -> i32 {
    let mut v0: f32 = 4.0f32;
    let (mut v1, mut v2, mut v3): (bool, f32, i32) = method0(v0);
    method1(v3, v2, v1)
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
