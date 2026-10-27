#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
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
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 4i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone() });
    let v7: Rc<RefCell<Vec<Rc<Heap1>>>> = Rc::new(RefCell::new(vec![<Rc<Heap1>>::default(); 1i32 as usize]));
    v7.clone().borrow_mut()[0i32 as usize] = v6.clone();
    let v8: Rc<Heap1> = v7.clone().borrow()[0i32 as usize].clone();
    let (mut v9, mut v10): (Rc<Heap0>, Rc<Heap0>) = (v8.l0.clone(), v8.l1.clone());
    let (mut v11, mut v12): (i32, Rc<str>) = (v9.l0.clone(), v9.l1.clone());
    let (mut v13, mut v14): (i32, Rc<str>) = (v10.l0.clone(), v10.l1.clone());
    let v15: bool = v11 == 7i32;
    let v17: bool = if v15 {
        let v16: bool = &*v12 == "hi";
        v16
    } else {
        false
    };
    let v19: bool = if v17 {
        let v18: bool = v13 == 4i32;
        v18
    } else {
        false
    };
    let v21: bool = if v19 {
        let v20: bool = &*v14 == "yo";
        v20
    } else {
        false
    };
    if v21 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
