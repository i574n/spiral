#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
fn f_c0(mut v0: Rc<Heap2>) -> Rc<dyn Fn(i32) -> Rc<Heap2>> {
    Rc::new(move |mut v1: i32| -> Rc<Heap2> {
        v0.clone()
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let v5: i32 = 2i32;
    let v6: Rc<Heap2> = Rc::new(Heap2 { l0: v4.clone(), l1: v5 });
    let mut v7: Rc<dyn Fn(i32) -> Rc<Heap2>> = f_c0(v6.clone());
    let v8: Rc<Heap2> = v7(1i32);
    let (mut v9, mut v10): (Rc<Heap1>, i32) = (v8.l0.clone(), v8.l1.clone());
    let (mut v11, mut v12): (Rc<Heap0>, i32) = (v9.l0.clone(), v9.l1.clone());
    let (mut v13, mut v14): (i32, Rc<str>) = (v11.l0.clone(), v11.l1.clone());
    let v15: bool = v13 == 7i32;
    let v17: bool = if v15 {
        let v16: bool = &*v14 == "hi";
        v16
    } else {
        false
    };
    let v19: bool = if v17 {
        let v18: bool = v12 == 1i32;
        v18
    } else {
        false
    };
    let v21: bool = if v19 {
        let v20: bool = v10 == 2i32;
        v20
    } else {
        false
    };
    if v21 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
