#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = -3i32;
    let mut v1: i32 = -4i32;
    let mut v2: i32 = -3i32;
    let mut v3: u32 = 4294967295u32;
    let mut v4: u32 = 0u32;
    let mut v5: u32 = 4294967295u32;
    let mut v6: f32 = -1.5f32;
    let mut v7: f32 = -0.5f32;
    let mut v8: f32 = -1.5f32;
    let mut v9: bool = v0 != v1;
    let mut v10: bool = v0 != v2;
    let mut v11: bool = v3 != v4;
    let mut v12: bool = v3 != v5;
    let mut v13: bool = v6 != v7;
    let mut v14: bool = v6 != v8;
    let mut v15: bool = v9 && v11;
    let mut v16: bool = v15 && v13;
    if v16 {
        if v10 {
            1i32
        } else {
            if v12 {
                2i32
            } else {
                if v14 {
                    3i32
                } else {
                    0i32
                }
            }
        }
    } else {
        4i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
