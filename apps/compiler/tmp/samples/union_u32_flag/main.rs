#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_All(u32, Rc<str>, bool),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_All(v1, v2, v3) => {
            let mut v1: u32 = *v1;
            let mut v2: Rc<str> = v2.clone();
            let mut v3: bool = *v3;
            let mut v4: bool = v1 == 4000000000u32;
            let mut v6: bool = if v4 {
                let mut v5: bool = v2.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v5
            } else {
                false
            };
            let mut v7: bool = v6 && v3;
            if v7 {
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
    let mut v0: u32 = 4000000000u32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: bool = true;
    let mut v3: bool = true;
    let mut v6: US0 = if v3 {
        US0::US0_All(v0, v1.clone(), v2)
    } else {
        US0::US0_None
    };
    score_0(v6.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
