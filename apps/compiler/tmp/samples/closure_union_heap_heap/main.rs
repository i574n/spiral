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
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap1>),
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
fn f_c0(mut v0: Rc<Heap1>) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v1: i32| -> US0 {
        let mut v2: bool = v1 == 0i32;
        if v2 {
            US0::US0_None
        } else {
            US0::US0_Held(v0.clone())
        }
    })
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1) => {
            let mut v1: Rc<Heap1> = v1.clone();
            let (mut v2, mut v3): (Rc<Heap0>, i32) = (v1.l0.clone(), v1.l1.clone());
            let (mut v4, mut v5): (i32, Rc<str>) = (v2.l0.clone(), v2.l1.clone());
            let mut v6: bool = v4 == 7i32;
            let mut v8: bool = if v6 {
                let mut v7: bool = v5.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v7
            } else {
                false
            };
            let mut v10: bool = if v8 {
                let mut v9: bool = v3 == 1i32;
                v9
            } else {
                false
            };
            if v10 {
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
    let mut v5: Rc<dyn Fn(i32) -> US0> = f_c0(v4.clone());
    let mut v6: US0 = v5(1i32);
    score_0(v6.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
