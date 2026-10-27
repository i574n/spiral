#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0>, l2: Rc<Heap0> }
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 4i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let v6: i32 = 9i32;
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let v9: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone(), l2: v8.clone() });
    let (mut v10, mut v11, mut v12): (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) = (v9.l0.clone(), v9.l1.clone(), v9.l2.clone());
    let (mut v13, mut v14): (i32, Rc<str>) = (v10.l0.clone(), v10.l1.clone());
    let (mut v15, mut v16): (i32, Rc<str>) = (v11.l0.clone(), v11.l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v12.l0.clone(), v12.l1.clone());
    let v19: bool = v13 == 7i32;
    let v21: bool = if v19 {
        let v20: bool = &*v14 == "hi";
        v20
    } else {
        false
    };
    let v23: bool = if v21 {
        let v22: bool = v15 == 4i32;
        v22
    } else {
        false
    };
    let v25: bool = if v23 {
        let v24: bool = &*v16 == "yo";
        v24
    } else {
        false
    };
    let v27: bool = if v25 {
        let v26: bool = v17 == 9i32;
        v26
    } else {
        false
    };
    let v29: bool = if v27 {
        let v28: bool = &*v18 == "ok";
        v28
    } else {
        false
    };
    if v29 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
