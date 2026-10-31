#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
struct Mut0 { l0: Rc<Heap2> }
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 2i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4 });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v5 });
    let v7: i32 = 3i32;
    let v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6, l1: v7 });
    let mut v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v8 }));
    let v10: i32 = 7i32;
    let v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<Heap0> = Rc::new(Heap0 { l0: v10, l1: v11 });
    let v13: i32 = 4i32;
    let v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v15: Rc<Heap0> = Rc::new(Heap0 { l0: v13, l1: v14 });
    let v16: Rc<Heap1> = Rc::new(Heap1 { l0: v12, l1: v15 });
    let v17: i32 = 2i32;
    let v18: Rc<Heap2> = Rc::new(Heap2 { l0: v16, l1: v17 });
    v9.borrow_mut().l0 = v18;
    let v19: Rc<Heap2> = v9.borrow().l0.clone();
    let (mut v20, mut v21): (Rc<Heap1>, i32) = (v19.l0.clone(), v19.l1.clone());
    let (mut v22, mut v23): (Rc<Heap0>, Rc<Heap0>) = (v20.l0.clone(), v20.l1.clone());
    let (mut v24, mut v25): (i32, Rc<str>) = (v22.l0.clone(), v22.l1.clone());
    let (mut v26, mut v27): (i32, Rc<str>) = (v23.l0.clone(), v23.l1.clone());
    let v28: bool = v24 == 7i32;
    let v30: bool = if v28 {
        let v29: bool = &*v25 == "hi";
        v29
    } else {
        false
    };
    let v32: bool = if v30 {
        let v31: bool = v26 == 4i32;
        v31
    } else {
        false
    };
    let v34: bool = if v32 {
        let v33: bool = &*v27 == "yo";
        v33
    } else {
        false
    };
    let v36: bool = if v34 {
        let v35: bool = v21 == 2i32;
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
