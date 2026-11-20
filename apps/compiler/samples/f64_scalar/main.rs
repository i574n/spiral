#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f64 = 1.5f64;
    let v1: f64 = -2.0f64;
    let v2: f64 = v0 / v1;
    let v3: f64 = 1000000.0f64;
    let v4: f64 = v3 * v3;
    let v5: f64 = v4 * v3;
    let v6: f64 = v5 * 10000.0f64;
    let v7: f64 = v6 * v6;
    let v8: i32 = 3i32;
    let v9: f64 = (v8 as f64);
    let v10: f64 = 2.9f64;
    let v11: f64 = -1.9f64;
    let v12: i32 = (v10 as i32);
    let v13: i32 = (v11 as i32);
    let v14: f32 = 1.5f32;
    let v15: f64 = (v14 as f64);
    let v16: bool = v2 == -0.75f64;
    let v18: bool = if v16 {
        let v17: bool = v7 > v6;
        v17
    } else {
        false
    };
    let v21: bool = if v18 {
        let v19: f64 = v7 * v6;
        let v20: bool = v7 < v19;
        v20
    } else {
        false
    };
    let v23: bool = if v21 {
        let v22: bool = v9 == 3.0f64;
        v22
    } else {
        false
    };
    let v25: bool = if v23 {
        let v24: bool = v12 == 2i32;
        v24
    } else {
        false
    };
    let v27: bool = if v25 {
        let v26: bool = v13 == -1i32;
        v26
    } else {
        false
    };
    let v29: bool = if v27 {
        let v28: bool = v15 == 1.5f64;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
