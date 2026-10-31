#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap2>),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1) => {
            let v1: Rc<Heap2> = v1.clone();
            let (mut v2, mut v3): (Rc<Heap1>, i32) = (v1.l0.clone(), v1.l1.clone());
            let (mut v4, mut v5): (Rc<Heap0>, i32) = (v2.l0.clone(), v2.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v4.l0.clone(), v4.l1.clone());
            let v8: bool = v6 == 7i32;
            let v10: bool = if v8 {
                let v9: bool = &*v7 == "hi";
                v9
            } else {
                false
            };
            let v12: bool = if v10 {
                let v11: bool = v5 == 1i32;
                v11
            } else {
                false
            };
            let v14: bool = if v12 {
                let v13: bool = v3 == 2i32;
                v13
            } else {
                false
            };
            if v14 {
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
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v3 });
    let v5: i32 = 2i32;
    let v6: Rc<Heap2> = Rc::new(Heap2 { l0: v4, l1: v5 });
    let v7: bool = true;
    let v10: US0 = if v7 {
        US0::US0_Held(v6)
    } else {
        US0::US0_None
    };
    score_0(v10)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
