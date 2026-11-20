#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f64 = 7.5f64;
    let v1: f64 = 2.0f64;
    let v2: f64 = -7.5f64;
    let v3: f64 = v0 % v1;
    let v4: bool = v3 == 1.5f64;
    let v7: bool = if v4 {
        let v5: f64 = v2 % v1;
        let v6: bool = v5 == -1.5f64;
        v6
    } else {
        false
    };
    if v7 {
        15i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
