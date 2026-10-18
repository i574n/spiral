#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap2>),
}
struct Heap3 { l0: US0 }
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
impl Default for Heap3 {
    fn default() -> Self {
        Heap3 { l0: <US0>::default() }
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1) => {
            let mut v1: Rc<Heap2> = v1.clone();
            let (mut v2, mut v3): (Rc<Heap1>, i32) = (v1.l0.clone(), v1.l1.clone());
            let (mut v4, mut v5): (Rc<Heap0>, Rc<Heap0>) = (v2.l0.clone(), v2.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v4.l0.clone(), v4.l1.clone());
            let (mut v8, mut v9): (i32, Rc<str>) = (v5.l0.clone(), v5.l1.clone());
            let mut v10: bool = v6 == 7i32;
            let mut v12: bool = if v10 {
                let mut v11: bool = v7.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v11
            } else {
                false
            };
            let mut v14: bool = if v12 {
                let mut v13: bool = v8 == 4i32;
                v13
            } else {
                false
            };
            let mut v16: bool = if v14 {
                let mut v15: bool = v9.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
                v15
            } else {
                false
            };
            let mut v18: bool = if v16 {
                let mut v17: bool = v3 == 2i32;
                v17
            } else {
                false
            };
            if v18 {
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
    let mut v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone() });
    let mut v7: i32 = 2i32;
    let mut v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6.clone(), l1: v7 });
    let mut v9: bool = true;
    let mut v12: US0 = if v9 {
        US0::US0_Held(v8.clone())
    } else {
        US0::US0_None
    };
    let mut v13: Rc<Heap3> = Rc::new(Heap3 { l0: v12.clone() });
    let mut v14: Rc<RefCell<Vec<Rc<Heap3>>>> = Rc::new(RefCell::new(vec![<Rc<Heap3>>::default(); 1i32 as usize]));
    v14.clone().borrow_mut()[0i32 as usize] = v13.clone();
    let mut v15: Rc<Heap3> = v14.clone().borrow()[0i32 as usize].clone();
    let mut v16: US0 = v15.l0.clone();
    score_0(v16.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
