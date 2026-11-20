#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn count_down_0(mut v0: i32, mut v1: i32) -> i32 {
    loop {
        let v2: bool = 0i32 < v0;
        if v2 {
            let v3: i32 = v0.wrapping_sub(1i32);
            let v4: i32 = v1.wrapping_add(1i32);
            (v0, v1) = (v3, v4);
            continue;
        } else {
            return v1;
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 5000i32;
    let v1: i32 = 0i32;
    let v2: i32 = count_down_0(v0, v1);
    let v3: bool = v2 == 5000i32;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
