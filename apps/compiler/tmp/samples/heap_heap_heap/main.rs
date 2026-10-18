#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 1i32;
    let mut v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let mut v5: i32 = 2i32;
    let mut v6: Rc<Heap2> = Rc::new(Heap2 { l0: v4.clone(), l1: v5 });
    let (mut v7, mut v8): (Rc<Heap1>, i32) = (v6.l0.clone(), v6.l1.clone());
    let (mut v9, mut v10): (Rc<Heap0>, i32) = (v7.l0.clone(), v7.l1.clone());
    let (mut v11, mut v12): (i32, Rc<str>) = (v9.l0.clone(), v9.l1.clone());
    let mut v13: bool = v11 == 7i32;
    let mut v15: bool = if v13 {
        let mut v14: bool = v12.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v14
    } else {
        false
    };
    let mut v17: bool = if v15 {
        let mut v16: bool = v10 == 1i32;
        v16
    } else {
        false
    };
    let mut v19: bool = if v17 {
        let mut v18: bool = v8 == 2i32;
        v18
    } else {
        false
    };
    if v19 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
