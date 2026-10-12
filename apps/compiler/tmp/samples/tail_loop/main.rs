#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    loop {
        let mut v2: i32 = v0.wrapping_sub(1i32);
        let mut v3: i32 = v1.wrapping_add(v0);
        let mut v4: bool = v2 == 0i32;
        if v4 {
            return v3;
        } else {
            (v0, v1) = (v2, v3);
            continue;
        }
    }
}
fn method0(mut v0: i32) -> i32 {
    let mut v1: i32 = 0i32;
    let mut v2: bool = v0 == 0i32;
    let mut v4: i32 = if v2 {
        v1
    } else {
        method1(v0, v1)
    };
    let mut v5: i32 = v4.wrapping_sub(55i32);
    v5
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 10i32;
    method0(v0)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
