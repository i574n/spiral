#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = 2.0f32;
    let v1: f32 = 3.0f32;
    let v2: f64 = 2.0f64;
    let v3: f64 = 3.0f64;
    let v4: f32 = 3.1415927f32;
    let v5: f64 = 3.141592653589793f64;
    let v6: f32 = v0.powf(v1);
    let v7: bool = v6 == 8.0f32;
    let v10: bool = if v7 {
        let v8: f64 = v2.powf(v3);
        let v9: bool = v8 == 8.0f64;
        v9
    } else {
        false
    };
    let v12: bool = if v10 {
        let v11: bool = v4 > 3.0f32;
        v11
    } else {
        false
    };
    let v14: bool = if v12 {
        let v13: bool = v4 < 4.0f32;
        v13
    } else {
        false
    };
    let v16: bool = if v14 {
        let v15: bool = v5 > 3.0f64;
        v15
    } else {
        false
    };
    let v18: bool = if v16 {
        let v17: bool = v5 < 4.0f64;
        v17
    } else {
        false
    };
    if v18 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
