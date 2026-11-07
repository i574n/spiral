#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = f32::NAN;
    let v1: f64 = f64::NAN;
    let v2: f32 = 1.0f32;
    let v3: f64 = 1.0f64;
    let v4: bool = (v0).is_nan();
    let v6: bool = if v4 {
        let v5: bool = (v1).is_nan();
        v5
    } else {
        false
    };
    if v6 {
        let v7: bool = (v2).is_nan();
        let v9: bool = if v7 {
            true
        } else {
            let v8: bool = (v3).is_nan();
            v8
        };
        if v9 {
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
