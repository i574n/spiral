#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f32 = 2.0f32;
    let mut v1: f32 = 3.0f32;
    let mut v2: f64 = 2.0f64;
    let mut v3: f64 = 3.0f64;
    let mut v4: f32 = 3.1415927f32;
    let mut v5: f64 = 3.141592653589793f64;
    let mut v6: f32 = v0.powf(v1);
    let mut v7: bool = v6 == 8.0f32;
    let mut v10: bool = if v7 {
        let mut v8: f64 = v2.powf(v3);
        let mut v9: bool = v8 == 8.0f64;
        v9
    } else {
        false
    };
    let mut v12: bool = if v10 {
        let mut v11: bool = v4 > 3.0f32;
        v11
    } else {
        false
    };
    let mut v14: bool = if v12 {
        let mut v13: bool = v4 < 4.0f32;
        v13
    } else {
        false
    };
    let mut v16: bool = if v14 {
        let mut v15: bool = v5 > 3.0f64;
        v15
    } else {
        false
    };
    let mut v18: bool = if v16 {
        let mut v17: bool = v5 < 4.0f64;
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
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
