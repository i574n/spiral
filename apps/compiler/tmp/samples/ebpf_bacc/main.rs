#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: bool) -> bool {
    loop {
        let v2: i32 = v0.wrapping_sub(1i32);
        let v4: bool = if v1 {
            let v3: bool = v0 > 0i32;
            v3
        } else {
            false
        };
        let v5: bool = v2 == 0i32;
        if v5 {
            return v4;
        } else {
            (v0, v1) = (v2, v4);
            continue;
        }
    }
}
fn method0(mut v0: i32) -> bool {
    let v1: bool = true;
    let v2: bool = v0 == 0i32;
    if v2 {
        v1
    } else {
        method1(v0, v1)
    }
}
fn method2(mut v0: i32) -> bool {
    let v1: bool = false;
    let v2: bool = v0 == 0i32;
    if v2 {
        v1
    } else {
        method1(v0, v1)
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: bool = method0(v0);
    let v2: bool = method2(v0);
    if v1 {
        if v2 {
            1i32
        } else {
            0i32
        }
    } else {
        2i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
