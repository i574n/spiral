#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn is_odd_1(mut v0: i32) -> bool {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        false
    } else {
        let mut v2: i32 = v0.wrapping_sub(1i32);
        is_even_0(v2)
    }
}
fn is_even_0(mut v0: i32) -> bool {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        true
    } else {
        let mut v2: i32 = v0.wrapping_sub(1i32);
        is_odd_1(v2)
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 10i32;
    let mut v1: bool = is_even_0(v0);
    if v1 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
