#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: u32 = 2147483647u32;
    let mut v1: u32 = 2u32;
    let mut v2: u32 = 1u32;
    let mut v3: u32 = v0.wrapping_add(v1);
    let mut v4: u32 = v0.wrapping_add(v2);
    let mut v5: bool = v3 == 2147483649u32;
    let mut v7: bool = if v5 {
        let mut v6: bool = v4 == 2147483648u32;
        v6
    } else {
        false
    };
    if v7 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
