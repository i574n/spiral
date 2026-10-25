#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i8) -> i8 {
    let mut v1: bool = v0 == 0i8;
    if v1 {
        1i8
    } else {
        v0
    }
}
fn spiral_main() -> i32 {
    let mut v0: i8 = 100i8;
    let mut v1: i8 = method0(v0);
    let mut v2: bool = v1 == 100i8;
    if v2 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
