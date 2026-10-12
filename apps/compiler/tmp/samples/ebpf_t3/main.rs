#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method2(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> (i32, i32, i32) {
    loop {
        let mut v4: i32 = v0.wrapping_sub(1i32);
        let mut v5: i32 = v1.wrapping_add(1i32);
        let mut v6: i32 = v2.wrapping_add(2i32);
        let mut v7: i32 = v3.wrapping_add(3i32);
        let mut v8: bool = v4 == 0i32;
        if v8 {
            return (v5, v6, v7);
        } else {
            (v0, v1, v2, v3) = (v4, v5, v6, v7);
            continue;
        }
    }
}
fn method1(mut v0: i32) -> (i32, i32, i32) {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = 0i32;
    let mut v3: i32 = 0i32;
    let mut v4: bool = v0 == 0i32;
    if v4 {
        (v1, v2, v3)
    } else {
        method2(v0, v1, v2, v3)
    }
}
fn method0(mut v0: i32) -> i32 {
    let (mut v1, mut v2, mut v3): (i32, i32, i32) = method1(v0);
    let mut v4: bool = v1 == 3i32;
    let mut v6: bool = if v4 {
        let mut v5: bool = v2 == 6i32;
        v5
    } else {
        false
    };
    let mut v8: bool = if v6 {
        let mut v7: bool = v3 == 9i32;
        v7
    } else {
        false
    };
    if v8 {
        0i32
    } else {
        1i32
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    method0(v0)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
