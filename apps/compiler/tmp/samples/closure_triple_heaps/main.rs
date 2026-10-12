#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
fn f_c0(mut v0: Rc<Heap0>, mut v1: Rc<Heap0>, mut v2: Rc<Heap0>) -> Rc<dyn Fn(i32) -> (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>)> {
    Rc::new(move |mut v3: i32| -> (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) {
        (v0.clone(), v1.clone(), v2.clone())
    })
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
    let mut v9: Rc<dyn Fn(i32) -> (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>)> = f_c0(v2.clone(), v5.clone(), v8.clone());
    let (mut v10, mut v11, mut v12): (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) = v9(1i32);
    let (mut v13, mut v14): (i32, Rc<str>) = (v10.l0.clone(), v10.l1.clone());
    let (mut v15, mut v16): (i32, Rc<str>) = (v11.l0.clone(), v11.l1.clone());
    let (mut v17, mut v18): (i32, Rc<str>) = (v12.l0.clone(), v12.l1.clone());
    let mut v19: bool = v13 == 7i32;
    let mut v21: bool = if v19 {
        let mut v20: bool = v14.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v20
    } else {
        false
    };
    let mut v23: bool = if v21 {
        let mut v22: bool = v15 == 4i32;
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v16.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        v24
    } else {
        false
    };
    let mut v27: bool = if v25 {
        let mut v26: bool = v17 == 9i32;
        v26
    } else {
        false
    };
    let mut v29: bool = if v27 {
        let mut v28: bool = v18.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
