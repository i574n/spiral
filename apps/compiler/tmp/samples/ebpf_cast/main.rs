#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = -2i32;
    let v2: u32 = 7u32;
    let v3: f32 = 2.9f32;
    let v4: f32 = (v0 as f32);
    let v5: f32 = (v1 as f32);
    let v6: f32 = (v2 as f32);
    let v7: u32 = (v3 as u32);
    let v8: bool = v4 == 3.0f32;
    let v10: bool = if v8 {
        let v9: bool = v5 == -2.0f32;
        v9
    } else {
        false
    };
    let v12: bool = if v10 {
        let v11: bool = v6 == 7.0f32;
        v11
    } else {
        false
    };
    let v14: bool = if v12 {
        let v13: bool = v7 == 2u32;
        v13
    } else {
        false
    };
    if v14 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
