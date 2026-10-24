#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn loop_0(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> (i32, i32) {
    let v4: bool = v1 >= v0;
    let (mut v9, mut v10): (i32, i32) = if v4 {
        (v2, v3)
    } else {
        let v5: i32 = v1.wrapping_add(1i32);
        let v6: i32 = v2.wrapping_add(1i32);
        let (mut v7, mut v8): (i32, i32) = loop_0(v0, v5, v6, v3);
        (v7, v8)
    };
    (v9, v10)
}
fn spiral_main() -> i32 {
    let v0: i32 = 5i32;
    let v1: i32 = 0i32;
    let v2: i32 = 1i32;
    let v3: i32 = 2i32;
    let (mut v4, mut v5): (i32, i32) = loop_0(v0, v1, v2, v3);
    let v6: i32 = v4.wrapping_add(v5);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
