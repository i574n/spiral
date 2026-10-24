#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
fn method0(mut v0: i32) -> US0 {
    let v1: bool = v0 == 0i32;
    if v1 {
        US0::US0_None
    } else {
        US0::US0_Some(v0)
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: US0 = method0(v0);
    match &v1 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v2) => {
            let v2: i32 = *v2;
            let v3: bool = v2 == 7i32;
            if v3 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
