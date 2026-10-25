#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
fn f_c0(mut v0: Rc<Heap2>) -> Rc<dyn Fn(i32) -> Rc<Heap2>> {
    Rc::new(move |mut v1: i32| -> Rc<Heap2> {
        v0.clone()
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 4i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4 });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v5 });
    let v7: i32 = 2i32;
    let v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6, l1: v7 });
    let mut v9: Rc<dyn Fn(i32) -> Rc<Heap2>> = f_c0(v8);
    let v10: Rc<Heap2> = v9(1i32);
    let (mut v11, mut v12): (Rc<Heap1>, i32) = (v10.l0.clone(), v10.l1.clone());
    let (mut v13, mut v14): (Rc<Heap0>, Rc<Heap0>) = (v11.l0.clone(), v11.l1.clone());
    let (mut v15, mut v16): (i32, Rc<str>) = (v13.l0.clone(), v13.l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v14.l0.clone(), v14.l1.clone());
    let v19: bool = v15 == 7i32;
    let v21: bool = if v19 {
        let v20: bool = &*v16 == "hi";
        v20
    } else {
        false
    };
    let v23: bool = if v21 {
        let v22: bool = v17 == 4i32;
        v22
    } else {
        false
    };
    let v25: bool = if v23 {
        let v24: bool = &*v18 == "yo";
        v24
    } else {
        false
    };
    let v27: bool = if v25 {
        let v26: bool = v12 == 2i32;
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
