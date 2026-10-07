#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: i32 = 40i32;
    let mut v4: i32 = { let (x, y) = (v0, v1); x + y + v2 };
    let mut v6: i32 = { let (x, y) = (v0, v1); v2 - x - y };
    let mut v8: i32 = { let (x, y) = (v0, v1); x * y };
    let mut v9: i32 = v4.wrapping_add(v6);
    let mut v10: i32 = v9.wrapping_add(v8);
    v10
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
