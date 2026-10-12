#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Both(Rc<str>, Rc<str>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_None => 0,
            US0::US0_Both(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Both(v1, v2) => {
            let mut v1: Rc<str> = v1.clone();
            let mut v2: Rc<str> = v2.clone();
            let mut v3: bool = v1.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
            let mut v5: bool = if v3 {
                let mut v4: bool = v2.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
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
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v2: bool = true;
    let mut v5: US0 = if v2 {
        US0::US0_Both(v0.clone(), v1.clone())
    } else {
        US0::US0_None
    };
    score_0(v5.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
