#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
impl Default for Heap1 {
    fn default() -> Self {
        Heap1 { l0: <Rc<Heap0>>::default(), l1: <i32>::default() }
    }
}
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
impl Default for Heap2 {
    fn default() -> Self {
        Heap2 { l0: <Rc<Heap1>>::default(), l1: <i32>::default() }
    }
}
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap2>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_None => 0,
            US0::US0_Held(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1) => {
            let mut v1: Rc<Heap2> = v1.clone();
            let (mut v2, mut v3): (Rc<Heap1>, i32) = (v1.l0.clone(), v1.l1.clone());
            let (mut v4, mut v5): (Rc<Heap0>, i32) = (v2.l0.clone(), v2.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v4.l0.clone(), v4.l1.clone());
            let mut v8: bool = v6 == 7i32;
            let mut v10: bool = if v8 {
                let mut v9: bool = v7.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v9
            } else {
                false
            };
            let mut v12: bool = if v10 {
                let mut v11: bool = v5 == 1i32;
                v11
            } else {
                false
            };
            let mut v14: bool = if v12 {
                let mut v13: bool = v3 == 2i32;
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
    let mut v0: i32 = 7i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 1i32;
    let mut v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let mut v5: i32 = 2i32;
    let mut v6: Rc<Heap2> = Rc::new(Heap2 { l0: v4.clone(), l1: v5 });
    let mut v7: bool = true;
    let mut v10: US0 = if v7 {
        US0::US0_Held(v6.clone())
    } else {
        US0::US0_None
    };
    score_0(v10.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
