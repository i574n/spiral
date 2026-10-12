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
struct Mut0 { l0: Rc<Heap1> }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <Rc<Heap1>>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 1i32;
    let mut v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let mut v5: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v4.clone() }));
    let mut v6: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v6.clone().borrow_mut()[0i32 as usize] = v5.clone();
    let mut v7: i32 = 7i32;
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<Heap0> = Rc::new(Heap0 { l0: v7, l1: v8.clone() });
    let mut v10: i32 = 4i32;
    let mut v11: Rc<Heap1> = Rc::new(Heap1 { l0: v9.clone(), l1: v10 });
    let mut v12: Rc<RefCell<Mut0>> = v6.clone().borrow()[0i32 as usize].clone();
    v12.borrow_mut().l0 = v11.clone();
    let mut v13: Rc<Heap1> = v12.borrow().l0.clone();
    let (mut v14, mut v15): (Rc<Heap0>, i32) = (v13.l0.clone(), v13.l1.clone());
    let (mut v16, mut v17): (i32, Rc<str>) = (v14.l0.clone(), v14.l1.clone());
    let mut v18: bool = v16 == 7i32;
    let mut v20: bool = if v18 {
        let mut v19: bool = v17.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v19
    } else {
        false
    };
    let mut v22: bool = if v20 {
        let mut v21: bool = v15 == 4i32;
        v21
    } else {
        false
    };
    if v22 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
