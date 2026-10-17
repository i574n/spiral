#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Mut0 { l0: Rc<Heap0>, l1: Rc<Heap0> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
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
    let mut v7: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v7.clone().borrow_mut()[0i32 as usize] = v6.clone();
    let mut v8: i32 = 7i32;
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v10: Rc<Heap0> = Rc::new(Heap0 { l0: v8, l1: v9.clone() });
    let mut v11: i32 = 4i32;
    let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<Heap0> = Rc::new(Heap0 { l0: v11, l1: v12.clone() });
    let mut v14: Rc<RefCell<Mut0>> = v7.clone().borrow()[0i32 as usize].clone();
    v14.borrow_mut().l0 = v10.clone();
    v14.borrow_mut().l1 = v13.clone();
    let (mut v15, mut v16): (Rc<Heap0>, Rc<Heap0>) = (v14.borrow().l0.clone(), v14.borrow().l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v15.l0.clone(), v15.l1.clone());
    let (mut v19, mut v20): (i32, Rc<str>) = (v16.l0.clone(), v16.l1.clone());
    let mut v21: bool = v17 == 7i32;
    let mut v23: bool = if v21 {
        let mut v22: bool = v18.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v19 == 4i32;
        v24
    } else {
        false
    };
    let mut v27: bool = if v25 {
        let mut v26: bool = v20.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v26
    } else {
        false
    };
    if v27 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
