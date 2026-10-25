#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32, l1: Rc<str> }
struct Heap0 { l0: Rc<RefCell<Mut0>> }
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v0, l1: v1.clone() }));
    let mut v3: Rc<Heap0> = Rc::new(Heap0 { l0: v2.clone() });
    let mut v4: Rc<RefCell<Mut0>> = v3.l0.clone();
    let mut v5: i32 = 7i32;
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    v4.borrow_mut().l0 = v5;
    v4.borrow_mut().l1 = v6.clone();
    let (mut v7, mut v8): (i32, Rc<str>) = (v4.borrow().l0.clone(), v4.borrow().l1.clone());
    let mut v9: bool = v7 == 7i32;
    let mut v11: bool = if v9 {
        let mut v10: bool = v8.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v10
    } else {
        false
    };
    if v11 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
