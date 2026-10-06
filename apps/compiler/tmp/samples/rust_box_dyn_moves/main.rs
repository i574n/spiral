#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Box<dyn Fn() -> i32>) -> i32 {
    let mut v1: i32 = (v0)();
    v1
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Box<dyn Fn() -> i32> = Box::new(move || v0 * 3) as Box<dyn Fn() -> i32>;
    let mut v2: i32 = method0(v1);
    let mut v3: i32 = v2 + 1i32;
    v3
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
