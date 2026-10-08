#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn fib_0(mut v0: i32) -> i32 {
    let mut v1: bool = v0 <= 1i32;
    if v1 {
        v0
    } else {
        let mut v2: i32 = v0.wrapping_sub(1i32);
        let mut v3: i32 = fib_0(v2);
        let mut v4: i32 = v0.wrapping_sub(2i32);
        let mut v5: i32 = fib_0(v4);
        let mut v6: i32 = v3.wrapping_add(v5);
        v6
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 10i32;
    let mut v1: i32 = fib_0(v0);
    let mut v2: i32 = v1.wrapping_sub(55i32);
    v2
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
