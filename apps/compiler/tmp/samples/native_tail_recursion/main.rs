#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32) -> i32 {
    loop {
        let mut v1: i32 = v0 - 1i32;
        let mut v2: bool = v1 == 0i32;
        if v2 {
            return 0i32;
        } else {
            v0 = v1;
            continue;
        }
    }
}
fn method0(mut v0: i32) -> i32 {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        0i32
    } else {
        method1(v0)
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1000000i32;
    method0(v0)
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
