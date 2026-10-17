#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
struct Mut0 { l0: Rc<Heap2> }
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 2i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone() });
    let mut v7: i32 = 3i32;
    let mut v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6.clone(), l1: v7 });
    let mut v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v8.clone() }));
    let mut v10: i32 = 7i32;
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<Heap0> = Rc::new(Heap0 { l0: v10, l1: v11.clone() });
    let mut v13: i32 = 4i32;
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<Heap0> = Rc::new(Heap0 { l0: v13, l1: v14.clone() });
    let mut v16: Rc<Heap1> = Rc::new(Heap1 { l0: v12.clone(), l1: v15.clone() });
    let mut v17: i32 = 2i32;
    let mut v18: Rc<Heap2> = Rc::new(Heap2 { l0: v16.clone(), l1: v17 });
    v9.borrow_mut().l0 = v18.clone();
    let mut v19: Rc<Heap2> = v9.borrow().l0.clone();
    let (mut v20, mut v21): (Rc<Heap1>, i32) = (v19.l0.clone(), v19.l1.clone());
    let (mut v22, mut v23): (Rc<Heap0>, Rc<Heap0>) = (v20.l0.clone(), v20.l1.clone());
    let (mut v24, mut v25): (i32, Rc<str>) = (v22.l0.clone(), v22.l1.clone());
    let (mut v26, mut v27): (i32, Rc<str>) = (v23.l0.clone(), v23.l1.clone());
    let mut v28: bool = v24 == 7i32;
    let mut v30: bool = if v28 {
        let mut v29: bool = v25.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v29
    } else {
        false
    };
    let mut v32: bool = if v30 {
        let mut v31: bool = v26 == 4i32;
        v31
    } else {
        false
    };
    let mut v34: bool = if v32 {
        let mut v33: bool = v27.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v33
    } else {
        false
    };
    let mut v36: bool = if v34 {
        let mut v35: bool = v21 == 2i32;
        v35
    } else {
        false
    };
    if v36 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
