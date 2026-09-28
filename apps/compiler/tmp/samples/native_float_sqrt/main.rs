#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f32 = 144.0f32;
    let mut v1: f64 = 81.0f64;
    let mut v2: f32 = (v0).sqrt();
    let mut v3: f64 = (v1).sqrt();
    let mut v4: bool = v2 == 12.0f32;
    let mut v6: bool = if v4 {
        let mut v5: bool = v3 == 9.0f64;
        v5
    } else {
        false
    };
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
