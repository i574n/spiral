#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0>, l2: Rc<Heap0> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
impl Default for Heap1 {
    fn default() -> Self {
        Heap1 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default(), l2: <Rc<Heap0>>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 4i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: i32 = 9i32;
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let mut v9: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone(), l2: v8.clone() });
    let mut v10: Rc<RefCell<Vec<Rc<Heap1>>>> = Rc::new(RefCell::new(vec![<Rc<Heap1>>::default(); 1i32 as usize]));
    v10.clone().borrow_mut()[0i32 as usize] = v9.clone();
    let mut v11: Rc<Heap1> = v10.clone().borrow()[0i32 as usize].clone();
    let (mut v12, mut v13, mut v14): (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) = (v11.l0.clone(), v11.l1.clone(), v11.l2.clone());
    let (mut v15, mut v16): (i32, Rc<str>) = (v12.l0.clone(), v12.l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v13.l0.clone(), v13.l1.clone());
    let (mut v19, mut v20): (i32, Rc<str>) = (v14.l0.clone(), v14.l1.clone());
    let mut v21: bool = v15 == 7i32;
    let mut v23: bool = if v21 {
        let mut v22: bool = v16.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v17 == 4i32;
        v24
    } else {
        false
    };
    let mut v27: bool = if v25 {
        let mut v26: bool = v18.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v26
    } else {
        false
    };
    let mut v29: bool = if v27 {
        let mut v28: bool = v19 == 9i32;
        v28
    } else {
        false
    };
    let mut v31: bool = if v29 {
        let mut v30: bool = v20.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
        v30
    } else {
        false
    };
    if v31 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
