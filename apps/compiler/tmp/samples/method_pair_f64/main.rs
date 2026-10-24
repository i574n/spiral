#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> (f64, f64) {
    let v1: bool = v0 == 0i32;
    if v1 {
        (0.0f64, 0.0f64)
    } else {
        (1.5f64, 2.5f64)
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let (mut v1, mut v2): (f64, f64) = method0(v0);
    let v3: bool = v1 == 1.5f64;
    let v5: bool = if v3 {
        let v4: bool = v2 == 2.5f64;
        v4
    } else {
        false
    };
    if v5 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
