#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: u32 = 1u32;
    let mut v1: i32 = 0i32;
    let mut v2: i32 = 31i32;
    let mut v3: u32 = v0.wrapping_shl((v2) as u32);
    let mut v4: u32 = v3.wrapping_shr((v2) as u32);
    let mut v5: u32 = v0.wrapping_shl((v1) as u32);
    let mut v6: bool = v3 == 2147483648u32;
    let mut v8: bool = if v6 {
        let mut v7: bool = v4 == 1u32;
        v7
    } else {
        false
    };
    let mut v10: bool = if v8 {
        let mut v9: bool = v5 == 1u32;
        v9
    } else {
        false
    };
    if v10 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
