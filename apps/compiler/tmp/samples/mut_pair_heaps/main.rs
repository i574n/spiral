#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
struct Mut0 { l0: Rc<Heap0>, l1: Rc<Heap0> }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 2i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v2.clone(), l1: v5.clone() }));
    let mut v7: i32 = 7i32;
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<Heap0> = Rc::new(Heap0 { l0: v7, l1: v8.clone() });
    let mut v10: i32 = 4i32;
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<Heap0> = Rc::new(Heap0 { l0: v10, l1: v11.clone() });
    v6.borrow_mut().l0 = v9.clone();
    v6.borrow_mut().l1 = v12.clone();
    let (mut v13, mut v14): (Rc<Heap0>, Rc<Heap0>) = (v6.borrow().l0.clone(), v6.borrow().l1.clone());
    let (mut v15, mut v16): (i32, Rc<str>) = (v13.l0.clone(), v13.l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v14.l0.clone(), v14.l1.clone());
    let mut v19: bool = v15 == 7i32;
    let mut v21: bool = if v19 {
        let mut v20: bool = v16.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v20
    } else {
        false
    };
    let mut v23: bool = if v21 {
        let mut v22: bool = v17 == 4i32;
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v18.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v24
    } else {
        false
    };
    if v25 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
