#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = -3i32;
    let v1: i32 = -4i32;
    let v2: i32 = -3i32;
    let v3: u32 = 4294967295u32;
    let v4: u32 = 0u32;
    let v5: u32 = 4294967295u32;
    let v6: f32 = -1.5f32;
    let v7: f32 = -0.5f32;
    let v8: f32 = -1.5f32;
    let v9: bool = v0 != v1;
    let v10: bool = v0 != v2;
    let v11: bool = v3 != v4;
    let v12: bool = v3 != v5;
    let v13: bool = v6 != v7;
    let v14: bool = v6 != v8;
    let v15: bool = v9 && v11;
    let v16: bool = v15 && v13;
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
