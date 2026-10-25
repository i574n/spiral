#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
struct Mut0 { l0: Rc<Heap2> }
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v3 });
    let v5: i32 = 2i32;
    let v6: Rc<Heap2> = Rc::new(Heap2 { l0: v4, l1: v5 });
    let mut v7: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v6 }));
    let v8: i32 = 7i32;
    let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v10: Rc<Heap0> = Rc::new(Heap0 { l0: v8, l1: v9 });
    let v11: i32 = 4i32;
    let v12: Rc<Heap1> = Rc::new(Heap1 { l0: v10, l1: v11 });
    let v13: i32 = 5i32;
    let v14: Rc<Heap2> = Rc::new(Heap2 { l0: v12, l1: v13 });
    v7.borrow_mut().l0 = v14;
    let v15: Rc<Heap2> = v7.borrow().l0.clone();
    let (mut v16, mut v17): (Rc<Heap1>, i32) = (v15.l0.clone(), v15.l1.clone());
    let (mut v18, mut v19): (Rc<Heap0>, i32) = (v16.l0.clone(), v16.l1.clone());
    let (mut v20, mut v21): (i32, Rc<str>) = (v18.l0.clone(), v18.l1.clone());
    let v22: bool = v20 == 7i32;
    let v24: bool = if v22 {
        let v23: bool = &*v21 == "hi";
        v23
    } else {
        false
    };
    let v26: bool = if v24 {
        let v25: bool = v19 == 4i32;
        v25
    } else {
        false
    };
    let v28: bool = if v26 {
        let v27: bool = v17 == 5i32;
        v27
    } else {
        false
    };
    if v28 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
