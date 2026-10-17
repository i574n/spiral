#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Both(f64, i32),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Both(v1, v2) => {
            let mut v1: f64 = *v1;
            let mut v2: i32 = *v2;
            let mut v3: bool = v1 == 1.5f64;
            let mut v5: bool = if v3 {
                let mut v4: bool = v2 == 7i32;
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
        US0::US0_None => {
            1i32
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: f64 = 1.5f64;
    let mut v1: i32 = 7i32;
    let mut v2: bool = true;
    let mut v5: US0 = if v2 {
        US0::US0_Both(v0, v1)
    } else {
        US0::US0_None
    };
    score_0(v5.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
