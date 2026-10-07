#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: u32) -> bool {
    let mut v1: u32 = v0.wrapping_add(5u32);
    let mut v2: u32 = v1.wrapping_rem(4u32);
    let mut v3: bool = v2 == 0u32;
    v3
}
fn spiral_main() -> i32 {
    let mut v0: u32 = 7u32;
    let mut v1: bool = method0(v0);
    if v1 {
        0i32
    } else {
        1i32
    }
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
