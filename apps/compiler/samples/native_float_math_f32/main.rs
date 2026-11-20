#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = 0.0f32;
    let v1: f32 = 1.0f32;
    let v2: f32 = 4.0f32;
    let v3: f32 = 3.0f32;
    let v4: f32 = f32::INFINITY;
    let v5: f32 = v4 - v4;
    let v6: f32 = (v2).sqrt();
    let v7: bool = v6 == 2.0f32;
    let v10: bool = if v7 {
        let v8: f32 = (v0).exp();
        let v9: bool = v8 == v1;
        v9
    } else {
        false
    };
    let v13: bool = if v10 {
        let v11: f32 = (v1).ln();
        let v12: bool = v11 == v0;
        v12
    } else {
        false
    };
    let v16: bool = if v13 {
        let v14: f32 = (v0).sin();
        let v15: bool = v14 == v0;
        v15
    } else {
        false
    };
    let v19: bool = if v16 {
        let v17: f32 = (v0).cos();
        let v18: bool = v17 == v1;
        v18
    } else {
        false
    };
    let v22: bool = if v19 {
        let v20: f32 = (v0).tanh();
        let v21: bool = v20 == v0;
        v21
    } else {
        false
    };
    let v25: bool = if v22 {
        let v23: f32 = v3.powf(v1);
        let v24: bool = v23 == v3;
        v24
    } else {
        false
    };
    let v27: bool = if v25 {
        let v26: bool = (v5).is_nan();
        v26
    } else {
        false
    };
    if v27 {
        let v28: bool = (v1).is_nan();
        if v28 {
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
