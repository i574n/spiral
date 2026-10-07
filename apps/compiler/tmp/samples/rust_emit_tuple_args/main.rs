#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: i32 = 40i32;
    let mut v11: i32 = { let (x, y) = (v0, v1); x + y + v2 };
    let mut v13: i32 = { let (x, y) = (v0, v1); v2 - x - y };
    let mut v15: i32 = { let (x, y) = (v0, v1); x * y };
    let mut v16: i32 = v11.wrapping_add(v13);
    let mut v17: i32 = v16.wrapping_add(v15);
    v17
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
