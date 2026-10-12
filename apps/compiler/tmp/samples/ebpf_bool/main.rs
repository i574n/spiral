#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: bool) -> i32 {
    if v0 {
        1i32
    } else {
        3i32
    }
}
fn method1(mut v0: bool, mut v1: bool) -> i32 {
    let mut v2: bool = v0 && v1;
    if v2 {
        1i32
    } else {
        let mut v3: bool = v0 || v1;
        if v3 {
            2i32
        } else {
            3i32
        }
    }
}
fn method2(mut v0: bool) -> i32 {
    if v0 {
        1i32
    } else {
        3i32
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v1: bool = false;
    let mut v2: i32 = method0(v0);
    let mut v3: i32 = method1(v0, v1);
    let mut v4: i32 = method2(v1);
    let mut v5: bool = v0 == v1;
    let mut v6: bool = v5 == false;
    let mut v7: bool = v2 == 1i32;
    let mut v9: bool = if v7 {
        let mut v8: bool = v3 == 2i32;
        v8
    } else {
        false
    };
    let mut v11: bool = if v9 {
        let mut v10: bool = v4 == 3i32;
        v10
    } else {
        false
    };
    let mut v12: bool = v11 && v6;
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
