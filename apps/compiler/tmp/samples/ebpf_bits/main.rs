#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: u32 = 4294967295u32;
    let mut v1: u32 = 15u32;
    let mut v2: u32 = v0 & v1;
    let mut v3: u32 = v0 | v1;
    let mut v4: u32 = v0 ^ v1;
    let mut v5: u32 = !v1;
    let mut v6: bool = v2 == 15u32;
    let mut v8: bool = if v6 {
        let mut v7: bool = v3 == v0;
        v7
    } else {
        false
    };
    let mut v10: bool = if v8 {
        let mut v9: bool = v4 == v5;
        v9
    } else {
        false
    };
    let mut v12: bool = if v10 {
        let mut v11: bool = v5 == 4294967280u32;
        v11
    } else {
        false
    };
    if v12 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
