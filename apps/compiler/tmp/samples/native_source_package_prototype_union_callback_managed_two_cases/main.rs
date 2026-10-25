#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Idle,
    US0_Text(Rc<str>),
    US0_Note(Rc<str>),
}
fn closure0() -> Rc<dyn Fn(i32) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> US0> = Rc::new(move |mut v0: i32| -> US0 {
        let mut v1: bool = v0 == 1i32;
        if v1 {
            let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("alpha"); } LIT.with(|lit| lit.clone()) };
            US0::US0_Text(v2.clone())
        } else {
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("beta"); } LIT.with(|lit| lit.clone()) };
            US0::US0_Note(v4.clone())
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(1i32)
}
fn method1(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(2i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> US0> = closure0();
    let mut v1: US0 = method0(v0.clone());
    let mut v6: i32 = match &v1 {
        US0::US0_Idle => {
            3i32
        }
        US0::US0_Note(v3) => {
            let mut v3: Rc<str> = v3.clone();
            6i32
        }
        US0::US0_Text(v2) => {
            let mut v2: Rc<str> = v2.clone();
            5i32
        }
    };
    let mut v7: US0 = method1(v0.clone());
    let mut v12: i32 = match &v7 {
        US0::US0_Idle => {
            3i32
        }
        US0::US0_Note(v9) => {
            let mut v9: Rc<str> = v9.clone();
            6i32
        }
        US0::US0_Text(v8) => {
            let mut v8: Rc<str> = v8.clone();
            5i32
        }
    };
    let mut v13: i32 = v6.wrapping_add(v12);
    let mut v14: i32 = v13.wrapping_add(31i32);
    v14
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
