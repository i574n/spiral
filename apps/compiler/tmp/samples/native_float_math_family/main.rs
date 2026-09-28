#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f32 = 0.0f32;
    let mut v1: f32 = 1.0f32;
    let mut v2: f64 = 0.0f64;
    let mut v3: f64 = 1.0f64;
    let mut v4: f32 = (v1).ln();
    let mut v5: bool = v4 == v0;
    let mut v8: bool = if v5 {
        let mut v6: f64 = (v3).ln();
        let mut v7: bool = v6 == v2;
        v7
    } else {
        false
    };
    let mut v11: bool = if v8 {
        let mut v9: f32 = (v0).exp();
        let mut v10: bool = v9 == v1;
        v10
    } else {
        false
    };
    let mut v14: bool = if v11 {
        let mut v12: f64 = (v2).exp();
        let mut v13: bool = v12 == v3;
        v13
    } else {
        false
    };
    let mut v17: bool = if v14 {
        let mut v15: f32 = (v0).tanh();
        let mut v16: bool = v15 == v0;
        v16
    } else {
        false
    };
    let mut v20: bool = if v17 {
        let mut v18: f64 = (v2).tanh();
        let mut v19: bool = v18 == v2;
        v19
    } else {
        false
    };
    let mut v23: bool = if v20 {
        let mut v21: f32 = (v0).sin();
        let mut v22: bool = v21 == v0;
        v22
    } else {
        false
    };
    let mut v26: bool = if v23 {
        let mut v24: f64 = (v2).sin();
        let mut v25: bool = v24 == v2;
        v25
    } else {
        false
    };
    let mut v29: bool = if v26 {
        let mut v27: f32 = (v0).cos();
        let mut v28: bool = v27 == v1;
        v28
    } else {
        false
    };
    let mut v32: bool = if v29 {
        let mut v30: f64 = (v2).cos();
        let mut v31: bool = v30 == v3;
        v31
    } else {
        false
    };
    if v32 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
