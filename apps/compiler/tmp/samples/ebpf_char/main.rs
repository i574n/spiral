#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: u8 = b'A';
    let mut v1: u8 = b'B';
    let mut v2: bool = v0 == b'A';
    if v2 {
        let mut v3: bool = v1 == b'B';
        if v3 {
            let mut v4: bool = v0 == v1;
            if v4 {
                2i32
            } else {
                0i32
            }
        } else {
            3i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
