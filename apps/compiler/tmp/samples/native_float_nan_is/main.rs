#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v2: f32 = f32::NAN;
    let mut v6: f64 = f64::NAN;
    let mut v8: f32 = 1.0f32;
    let mut v9: f64 = 1.0f64;
    let mut v10: bool = (v2).is_nan();
    let mut v12: bool = if v10 {
        let mut v11: bool = (v6).is_nan();
        v11
    } else {
        false
    };
    if v12 {
        let mut v13: bool = (v8).is_nan();
        let mut v15: bool = if v13 {
            true
        } else {
            let mut v14: bool = (v9).is_nan();
            v14
        };
        if v15 {
            2i32
        } else {
            0i32
        }
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
