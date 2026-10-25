#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap0>, Rc<Heap0>, Rc<Heap0>),
}
fn f_c0(mut v0: Rc<Heap0>, mut v1: Rc<Heap0>, mut v2: Rc<Heap0>) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v3: i32| -> US0 {
        let mut v4: bool = v3 == 0i32;
        if v4 {
            US0::US0_None
        } else {
            US0::US0_Held(v0.clone(), v1.clone(), v2.clone())
        }
    })
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2, v3) => {
            let mut v1: Rc<Heap0> = v1.clone();
            let mut v2: Rc<Heap0> = v2.clone();
            let mut v3: Rc<Heap0> = v3.clone();
            let (mut v4, mut v5): (i32, Rc<str>) = (v1.l0.clone(), v1.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v2.l0.clone(), v2.l1.clone());
            let (mut v8, mut v9): (i32, Rc<str>) = (v3.l0.clone(), v3.l1.clone());
            let mut v10: bool = v4 == 7i32;
            let mut v12: bool = if v10 {
                let mut v11: bool = v5.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v11
            } else {
                false
            };
            let mut v14: bool = if v12 {
                let mut v13: bool = v6 == 4i32;
                v13
            } else {
                false
            };
            let mut v16: bool = if v14 {
                let mut v15: bool = v7.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
                v15
            } else {
                false
            };
            let mut v18: bool = if v16 {
                let mut v17: bool = v8 == 9i32;
                v17
            } else {
                false
            };
            let mut v20: bool = if v18 {
                let mut v19: bool = v9.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
                v19
            } else {
                false
            };
            if v20 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_None => {
            1i32
        }
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
    let mut v9: Rc<dyn Fn(i32) -> US0> = f_c0(v2.clone(), v5.clone(), v8.clone());
    let mut v10: US0 = v9(1i32);
    score_0(v10.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
