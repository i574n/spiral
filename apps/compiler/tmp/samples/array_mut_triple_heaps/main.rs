#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Mut0 { l0: Rc<Heap0>, l1: Rc<Heap0>, l2: Rc<Heap0> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default(), l2: <Rc<Heap0>>::default() }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 2i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zz"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let v6: i32 = 3i32;
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("aa"); } LIT.with(|lit| lit.clone()) };
    let v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v2.clone(), l1: v5.clone(), l2: v8.clone() }));
    let v10: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v10.clone().borrow_mut()[0i32 as usize] = v9.clone();
    let v11: i32 = 7i32;
    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v13: Rc<Heap0> = Rc::new(Heap0 { l0: v11, l1: v12.clone() });
    let v14: i32 = 4i32;
    let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v16: Rc<Heap0> = Rc::new(Heap0 { l0: v14, l1: v15.clone() });
    let v17: i32 = 9i32;
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let v19: Rc<Heap0> = Rc::new(Heap0 { l0: v17, l1: v18.clone() });
    let mut v20: Rc<RefCell<Mut0>> = v10.clone().borrow()[0i32 as usize].clone();
    v20.borrow_mut().l0 = v13.clone();
    v20.borrow_mut().l1 = v16.clone();
    v20.borrow_mut().l2 = v19.clone();
    let (mut v21, mut v22, mut v23): (Rc<Heap0>, Rc<Heap0>, Rc<Heap0>) = (v20.borrow().l0.clone(), v20.borrow().l1.clone(), v20.borrow().l2.clone());
    let (mut v24, mut v25): (i32, Rc<str>) = (v21.l0.clone(), v21.l1.clone());
    let (mut v26, mut v27): (i32, Rc<str>) = (v22.l0.clone(), v22.l1.clone());
    let (mut v28, mut v29): (i32, Rc<str>) = (v23.l0.clone(), v23.l1.clone());
    let v30: bool = v24 == 7i32;
    let v32: bool = if v30 {
        let v31: bool = &*v25 == "hi";
        v31
    } else {
        false
    };
    let v34: bool = if v32 {
        let v33: bool = v26 == 4i32;
        v33
    } else {
        false
    };
    let v36: bool = if v34 {
        let v35: bool = &*v27 == "yo";
        v35
    } else {
        false
    };
    let v38: bool = if v36 {
        let v37: bool = v28 == 9i32;
        v37
    } else {
        false
    };
    let v40: bool = if v38 {
        let v39: bool = &*v29 == "ok";
        v39
    } else {
        false
    };
    if v40 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
