#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: f64, l1: Rc<str> }
fn spiral_main() -> i32 {
    let mut v0: f64 = 1.5f64;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v0, l1: v1.clone() }));
    let mut v3: f64 = 2.5f64;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    v2.borrow_mut().l0 = v3;
    v2.borrow_mut().l1 = v4.clone();
    let (mut v5, mut v6): (f64, Rc<str>) = (v2.borrow().l0.clone(), v2.borrow().l1.clone());
    let mut v7: bool = v5 == 2.5f64;
    let mut v9: bool = if v7 {
        let mut v8: bool = v6.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v8
    } else {
        false
    };
    if v9 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
