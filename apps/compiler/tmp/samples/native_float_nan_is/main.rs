#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v3: f32 = f32::NAN;
    let mut v8: f64 = f64::NAN;
    let mut v10: f32 = 1.0f32;
    let mut v11: f64 = 1.0f64;
    let mut v12: bool = (v3).is_nan();
    let mut v14: bool = if v12 {
        let mut v13: bool = (v8).is_nan();
        v13
    } else {
        false
    };
    if v14 {
        let mut v15: bool = (v10).is_nan();
        let mut v17: bool = if v15 {
            true
        } else {
            let mut v16: bool = (v11).is_nan();
            v16
        };
        if v17 {
            2i32
        } else {
            0i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
