#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f64 = 1.5f64;
    let mut v1: f64 = -2.0f64;
    let mut v2: f64 = v0 / v1;
    let mut v3: f64 = 1000000.0f64;
    let mut v4: f64 = v3 * v3;
    let mut v5: f64 = v4 * v3;
    let mut v6: f64 = v5 * 10000.0f64;
    let mut v7: f64 = v6 * v6;
    let mut v8: i32 = 3i32;
    let mut v9: f64 = (v8 as f64);
    let mut v10: f64 = 2.9f64;
    let mut v11: f64 = -1.9f64;
    let mut v12: i32 = (v10 as i32);
    let mut v13: i32 = (v11 as i32);
    let mut v14: f32 = 1.5f32;
    let mut v15: f64 = (v14 as f64);
    let mut v16: bool = v2 == -0.75f64;
    let mut v18: bool = if v16 {
        let mut v17: bool = v7 > v6;
        v17
    } else {
        false
    };
    let mut v21: bool = if v18 {
        let mut v19: f64 = v7 * v6;
        let mut v20: bool = v7 < v19;
        v20
    } else {
        false
    };
    let mut v23: bool = if v21 {
        let mut v22: bool = v9 == 3.0f64;
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v12 == 2i32;
        v24
    } else {
        false
    };
    let mut v27: bool = if v25 {
        let mut v26: bool = v13 == -1i32;
        v26
    } else {
        false
    };
    let mut v29: bool = if v27 {
        let mut v28: bool = v15 == 1.5f64;
        v28
    } else {
        false
    };
    if v29 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
