#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: i32) -> (i32, i32) {
    (v0, v1)
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let (mut v2, mut v3): (i32, i32) = method1(v0, v1);
    let mut v4: i32 = v2.wrapping_add(v3);
    v4
}
fn method3(mut v0: i32, mut v1: i32, mut v2: i32) -> (i32, i32, i32) {
    (v0, v1, v2)
}
fn method2(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    let (mut v3, mut v4, mut v5): (i32, i32, i32) = method3(v0, v1, v2);
    let mut v6: i32 = v3.wrapping_add(v4);
    let mut v7: i32 = v6.wrapping_add(v5);
    v7
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: i32 = 3i32;
    let mut v3: i32 = method0(v0, v1);
    let mut v4: i32 = method2(v0, v1, v2);
    let mut v5: i32 = v3.wrapping_add(v4);
    let mut v6: i32 = v5.wrapping_sub(9i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
