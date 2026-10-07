#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f32 = f32::INFINITY;
    let mut v1: f64 = f64::INFINITY;
    let mut v2: f32 = -(v0);
    let mut v3: f64 = -(v1);
    let mut v4: f32 = 1.0f32;
    let mut v5: f64 = 1.0f64;
    let mut v6: bool = (v4).is_nan();
    let mut v8: bool = if v6 {
        true
    } else {
        let mut v7: bool = (v5).is_nan();
        v7
    };
    if v8 {
        3i32
    } else {
        let mut v9: bool = v0 > v4;
        let mut v11: bool = if v9 {
            let mut v10: bool = v1 > v5;
            v10
        } else {
            false
        };
        if v11 {
            let mut v12: bool = v2 < 0.0f32;
            let mut v14: bool = if v12 {
                let mut v13: bool = v3 < 0.0f64;
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
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
