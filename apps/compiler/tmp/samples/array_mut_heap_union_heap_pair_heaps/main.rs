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
struct Mut0 { l0: Rc<Heap3> }
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
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap3>>::default() }
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1) => {
            let v1: Rc<Heap2> = v1.clone();
            let (mut v2, mut v3): (Rc<Heap1>, i32) = (v1.l0.clone(), v1.l1.clone());
            let (mut v4, mut v5): (Rc<Heap0>, Rc<Heap0>) = (v2.l0.clone(), v2.l1.clone());
            let (mut v6, mut v7): (i32, Rc<str>) = (v4.l0.clone(), v4.l1.clone());
            let (mut v8, mut v9): (i32, Rc<str>) = (v5.l0.clone(), v5.l1.clone());
            let v10: bool = v6 == 7i32;
            let v12: bool = if v10 {
                let v11: bool = &*v7 == "hi";
                v11
            } else {
                false
            };
            let v14: bool = if v12 {
                let v13: bool = v8 == 4i32;
                v13
            } else {
                false
            };
            let v16: bool = if v14 {
                let v15: bool = &*v9 == "yo";
                v15
            } else {
                false
            };
            let v18: bool = if v16 {
                let v17: bool = v3 == 2i32;
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
    let v0: i32 = 1i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 2i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4 });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v5 });
    let v7: i32 = 3i32;
    let v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6, l1: v7 });
    let v9: bool = true;
    let v12: US0 = if v9 {
        US0::US0_Held(v8)
    } else {
        US0::US0_None
    };
    let v13: Rc<Heap3> = Rc::new(Heap3 { l0: v12 });
    let v14: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v13 }));
    let v15: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v15.clone().borrow_mut()[0i32 as usize] = v14;
    let v16: i32 = 7i32;
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<Heap0> = Rc::new(Heap0 { l0: v16, l1: v17 });
    let v19: i32 = 4i32;
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v21: Rc<Heap0> = Rc::new(Heap0 { l0: v19, l1: v20 });
    let v22: Rc<Heap1> = Rc::new(Heap1 { l0: v18, l1: v21 });
    let v23: i32 = 2i32;
    let v24: Rc<Heap2> = Rc::new(Heap2 { l0: v22, l1: v23 });
    let v25: bool = true;
    let v28: US0 = if v25 {
        US0::US0_Held(v24)
    } else {
        US0::US0_None
    };
    let v29: Rc<Heap3> = Rc::new(Heap3 { l0: v28 });
    let mut v30: Rc<RefCell<Mut0>> = v15.borrow()[0i32 as usize].clone();
    v30.borrow_mut().l0 = v29;
    let v31: Rc<Heap3> = v30.borrow().l0.clone();
    let v32: US0 = v31.l0.clone();
    score_0(v32)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
