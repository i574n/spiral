#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
fn method0(mut v0: i32) -> (US0, i32) {
    let v1: bool = v0 == 0i32;
    if v1 {
        let v2: US0 = US0::US0_None;
        (v2, 0i32)
    } else {
        let v3: US0 = US0::US0_Some(v0);
        (v3, v0)
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let (mut v1, mut v2): (US0, i32) = method0(v0);
    match &v1 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v3) => {
            let v3: i32 = *v3;
            let v4: bool = v3 == 7i32;
            let v6: bool = if v4 {
                let v5: bool = v2 == 7i32;
                v5
            } else {
                false
            };
            if v6 {
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
