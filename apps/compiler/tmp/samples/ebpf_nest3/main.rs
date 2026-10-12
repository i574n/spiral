#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: u32, mut v2: f32) -> (i32, u32, f32) {
    (v0, v1, v2)
}
fn method0(mut v0: i32, mut v1: u32, mut v2: f32) -> i32 {
    let (mut v3, mut v4, mut v5): (i32, u32, f32) = method1(v0, v1, v2);
    let mut v6: bool = v3 == 2i32;
    let mut v8: bool = if v6 {
        let mut v7: bool = v4 == 3u32;
        v7
    } else {
        false
    };
    let mut v10: bool = if v8 {
        let mut v9: bool = v5 == 1.5f32;
        v9
    } else {
        false
    };
    if v10 {
        0i32
    } else {
        1i32
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: u32 = 3u32;
    let mut v2: f32 = 1.5f32;
    method0(v0, v1, v2)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
