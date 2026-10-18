#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<RefCell<Vec<Rc<str>>>>, bool),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2) => {
            let mut v1: Rc<RefCell<Vec<Rc<str>>>> = v1.clone();
            let mut v2: bool = *v2;
            let mut v3: Rc<str> = v1.clone().borrow()[0i32 as usize].clone();
            let mut v4: bool = v3.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
            let mut v5: bool = v4 && v2;
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
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 1i32 as usize]));
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    v0.clone().borrow_mut()[0i32 as usize] = v1.clone();
    let mut v2: bool = true;
    let mut v5: US0 = if v2 {
        US0::US0_Held(v0.clone(), v2)
    } else {
        US0::US0_None
    };
    score_0(v5.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
