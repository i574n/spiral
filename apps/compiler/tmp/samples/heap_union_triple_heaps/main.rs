#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap0>, Rc<Heap0>, Rc<Heap0>),
}
struct Heap1 { l0: US0 }
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2, v3) => {
            let v1: Rc<Heap0> = v1.clone();
            let v2: Rc<Heap0> = v2.clone();
            let v3: Rc<Heap0> = v3.clone();
            let (mut v4, mut v5): (i32, Rc<str>) = (v1.l0.clone(), v1.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v2.l0.clone(), v2.l1.clone());
            let (mut v8, mut v9): (i32, Rc<str>) = (v3.l0.clone(), v3.l1.clone());
            let v10: bool = v4 == 7i32;
            let v12: bool = if v10 {
                let v11: bool = &*v5 == "hi";
                v11
            } else {
                false
            };
            let v14: bool = if v12 {
                let v13: bool = v6 == 4i32;
                v13
            } else {
                false
            };
            let v16: bool = if v14 {
                let v15: bool = &*v7 == "yo";
                v15
            } else {
                false
            };
            let v18: bool = if v16 {
                let v17: bool = v8 == 9i32;
                v17
            } else {
                false
            };
            let v20: bool = if v18 {
                let v19: bool = &*v9 == "ok";
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
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 4i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4 });
    let v6: i32 = 9i32;
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7 });
    let v9: bool = true;
    let v12: US0 = if v9 {
        US0::US0_Held(v2, v5, v8)
    } else {
        US0::US0_None
    };
    let v13: Rc<Heap1> = Rc::new(Heap1 { l0: v12 });
    let v14: US0 = v13.l0.clone();
    score_0(v14)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
