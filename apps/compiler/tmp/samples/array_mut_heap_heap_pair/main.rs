#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
struct Mut0 { l0: Rc<Heap2> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
impl Default for Heap1 {
    fn default() -> Self {
        Heap1 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default() }
    }
}
impl Default for Heap2 {
    fn default() -> Self {
        Heap2 { l0: <Rc<Heap1>>::default(), l1: <i32>::default() }
    }
}
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap2>>::default() }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 2i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone() });
    let v7: i32 = 3i32;
    let v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6.clone(), l1: v7 });
    let v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v8.clone() }));
    let v10: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v10.clone().borrow_mut()[0i32 as usize] = v9.clone();
    let v11: i32 = 7i32;
    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v13: Rc<Heap0> = Rc::new(Heap0 { l0: v11, l1: v12.clone() });
    let v14: i32 = 4i32;
    let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v16: Rc<Heap0> = Rc::new(Heap0 { l0: v14, l1: v15.clone() });
    let v17: Rc<Heap1> = Rc::new(Heap1 { l0: v13.clone(), l1: v16.clone() });
    let v18: i32 = 2i32;
    let v19: Rc<Heap2> = Rc::new(Heap2 { l0: v17.clone(), l1: v18 });
    let mut v20: Rc<RefCell<Mut0>> = v10.clone().borrow()[0i32 as usize].clone();
    v20.borrow_mut().l0 = v19.clone();
    let v21: Rc<Heap2> = v20.borrow().l0.clone();
    let (mut v22, mut v23): (Rc<Heap1>, i32) = (v21.l0.clone(), v21.l1.clone());
    let (mut v24, mut v25): (Rc<Heap0>, Rc<Heap0>) = (v22.l0.clone(), v22.l1.clone());
    let (mut v26, mut v27): (i32, Rc<str>) = (v24.l0.clone(), v24.l1.clone());
    let (mut v28, mut v29): (i32, Rc<str>) = (v25.l0.clone(), v25.l1.clone());
    let v30: bool = v26 == 7i32;
    let v32: bool = if v30 {
        let v31: bool = &*v27 == "hi";
        v31
    } else {
        false
    };
    let v34: bool = if v32 {
        let v33: bool = v28 == 4i32;
        v33
    } else {
        false
    };
    let v36: bool = if v34 {
        let v35: bool = &*v29 == "yo";
        v35
    } else {
        false
    };
    let v38: bool = if v36 {
        let v37: bool = v23 == 2i32;
        v37
    } else {
        false
    };
    if v38 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
