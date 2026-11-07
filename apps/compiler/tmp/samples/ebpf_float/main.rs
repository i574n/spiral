#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = -1.5f32;
    let v1: f32 = 2.0f32;
    let v2: f32 = v0 / v1;
    let v3: f32 = -0.75f32;
    let v4: f32 = v0 * v1;
    let v5: f32 = v4 + 0.5f32;
    let v6: f32 = -2.5f32;
    let v7: bool = v2 == v3;
    if v7 {
        let v8: bool = v5 == v6;
        if v8 {
            0i32
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
