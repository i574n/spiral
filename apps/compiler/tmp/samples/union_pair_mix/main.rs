#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_Both(i32, Rc<str>),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Both(v2, v3) => {
            let mut v2: i32 = *v2;
            let mut v3: Rc<str> = v3.clone();
            let mut v4: bool = v2 == 3i32;
            let mut v6: bool = if v4 {
                let mut v5: bool = v3.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
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
        US0::US0_One(v1) => {
            let mut v1: i32 = *v1;
            v1
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v1: i32 = 3i32;
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v5: US0 = if v0 {
        US0::US0_Both(v1, v2.clone())
    } else {
        US0::US0_One(1i32)
    };
    score_0(v5.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
