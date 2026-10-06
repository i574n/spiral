#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> (i32, i32, bool) {
    let mut v1: i32 = v0 + 2i32;
    let mut v2: bool = v0 > 0i32;
    (v0, v1, v2)
}
fn method1(mut v0: i32, mut v1: i32, mut v2: bool) -> i32 {
    if v2 {
        let mut v3: i32 = v0 + v1;
        let mut v4: i32 = v3 - 4i32;
        v4
    } else {
        1i32
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let (mut v1, mut v2, mut v3): (i32, i32, bool) = method0(v0);
    method1(v1, v2, v3)
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
