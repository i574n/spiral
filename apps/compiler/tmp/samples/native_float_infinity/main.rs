#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = f32::INFINITY;
    let v1: f64 = f64::INFINITY;
    let v2: f32 = -(v0);
    let v3: f64 = -(v1);
    let v4: f32 = 1.0f32;
    let v5: f64 = 1.0f64;
    let v6: bool = (v4).is_nan();
    let v8: bool = if v6 {
        true
    } else {
        let v7: bool = (v5).is_nan();
        v7
    };
    if v8 {
        3i32
    } else {
        let v9: bool = v0 > v4;
        let v11: bool = if v9 {
            let v10: bool = v1 > v5;
            v10
        } else {
            false
        };
        if v11 {
            let v12: bool = v2 < 0.0f32;
            let v14: bool = if v12 {
                let v13: bool = v3 < 0.0f64;
                v13
            } else {
                false
            };
            if v14 {
                0i32
            } else {
                2i32
            }
        } else {
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
