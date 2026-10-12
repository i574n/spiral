#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
fn f_c0(mut v0: Rc<Heap0>, mut v1: Rc<Heap0>) -> Rc<dyn Fn(i32) -> (Rc<Heap0>, Rc<Heap0>)> {
    Rc::new(move |mut v2: i32| -> (Rc<Heap0>, Rc<Heap0>) {
        let mut v3: bool = v2 == 0i32;
        (v0.clone(), v1.clone())
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 4i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: Rc<dyn Fn(i32) -> (Rc<Heap0>, Rc<Heap0>)> = f_c0(v2.clone(), v5.clone());
    let (mut v7, mut v8): (Rc<Heap0>, Rc<Heap0>) = v6(1i32);
    let (mut v9, mut v10): (i32, Rc<str>) = (v7.l0.clone(), v7.l1.clone());
    let (mut v11, mut v12): (i32, Rc<str>) = (v8.l0.clone(), v8.l1.clone());
    let mut v13: bool = v9 == 7i32;
    let mut v15: bool = if v13 {
        let mut v14: bool = v10.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v14
    } else {
        false
    };
    let mut v17: bool = if v15 {
        let mut v16: bool = v11 == 4i32;
        v16
    } else {
        false
    };
    let mut v19: bool = if v17 {
        let mut v18: bool = v12.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
