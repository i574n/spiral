#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
struct Mut0 { l0: Rc<Heap0>, l1: Rc<Heap0>, l2: Rc<Heap0> }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default(), l2: <Rc<Heap0>>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 2i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: i32 = 3i32;
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("aa"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let mut v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v2.clone(), l1: v5.clone(), l2: v8.clone() }));
    let mut v10: i32 = 7i32;
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<Heap0> = Rc::new(Heap0 { l0: v10, l1: v11.clone() });
    let mut v13: i32 = 4i32;
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<Heap0> = Rc::new(Heap0 { l0: v13, l1: v14.clone() });
    let mut v16: i32 = 9i32;
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<Heap0> = Rc::new(Heap0 { l0: v16, l1: v17.clone() });
    v9.borrow_mut().l0 = v12.clone();
    v9.borrow_mut().l1 = v15.clone();
    v9.borrow_mut().l2 = v18.clone();
    let (mut v19, mut v20, mut v21): (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) = (v9.borrow().l0.clone(), v9.borrow().l1.clone(), v9.borrow().l2.clone());
    let (mut v22, mut v23): (i32, Rc<str>) = (v19.l0.clone(), v19.l1.clone());
    let (mut v24, mut v25): (i32, Rc<str>) = (v20.l0.clone(), v20.l1.clone());
    let (mut v26, mut v27): (i32, Rc<str>) = (v21.l0.clone(), v21.l1.clone());
    let mut v28: bool = v22 == 7i32;
    let mut v30: bool = if v28 {
        let mut v29: bool = v23.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v29
    } else {
        false
    };
    let mut v32: bool = if v30 {
        let mut v31: bool = v24 == 4i32;
        v31
    } else {
        false
    };
    let mut v34: bool = if v32 {
        let mut v33: bool = v25.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v33
    } else {
        false
    };
    let mut v36: bool = if v34 {
        let mut v35: bool = v26 == 9i32;
        v35
    } else {
        false
    };
    let mut v38: bool = if v36 {
        let mut v37: bool = v27.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
        v37
    } else {
        false
    };
    if v38 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
