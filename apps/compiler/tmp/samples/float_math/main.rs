#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: f32, mut v1: f32) -> f32 {
    let mut v2: f32 = v0 * v1;
    let mut v3: f32 = v2 + 0.5f32;
    v3
}
fn spiral_main() -> i32 {
    let mut v0: f32 = 1.5f32;
    let mut v1: f32 = 2.0f32;
    let mut v2: f32 = method0(v0, v1);
    let mut v3: bool = v2 >= 3.5f32;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
