#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method2() -> i32 {
    14i32
}
fn method1() -> i32 {
    let mut v0: i32 = method2();
    let mut v1: i32 = 14i32.wrapping_add(v0);
    v1
}
fn method0() -> i32 {
    let mut v0: i32 = method1();
    let mut v1: i32 = 14i32.wrapping_add(v0);
    v1
}
fn spiral_main() -> i32 {
    method0()
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
