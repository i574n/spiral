#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 4i32;
    let mut v2: u32 = 1u32;
    let mut v3: u32 = 1u32;
    let mut v4: f32 = 1.5f32;
    let mut v5: f32 = -(v4);
    let mut v6: bool = v0 != v1;
    if v6 {
        let mut v7: bool = v2 != v3;
        if v7 {
            2i32
        } else {
            let mut v8: bool = v5 == -1.5f32;
            if v8 {
                0i32
            } else {
                3i32
            }
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
