#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_Both(i32, Rc<str>),
}
fn method0(mut v0: i32, mut v1: Rc<str>) -> US0 {
    let mut v2: bool = v0 == 0i32;
    if v2 {
        US0::US0_One(0i32)
    } else {
        US0::US0_Both(v0, v1.clone())
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: US0 = method0(v0, v1.clone());
    match &v2 {
        US0::US0_Both(v4, v5) => {
            let mut v4: i32 = *v4;
            let mut v5: Rc<str> = v5.clone();
            let mut v6: bool = v4 == 3i32;
            let mut v8: bool = if v6 {
                let mut v7: bool = v5.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
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
        US0::US0_One(v3) => {
            let mut v3: i32 = *v3;
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
