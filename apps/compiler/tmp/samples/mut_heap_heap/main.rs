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
    let mut v6: i32 = 7i32;
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let mut v9: i32 = 4i32;
    let mut v10: Rc<Heap1> = Rc::new(Heap1 { l0: v8.clone(), l1: v9 });
    v5.borrow_mut().l0 = v10.clone();
    let mut v11: Rc<Heap1> = v5.borrow().l0.clone();
    let (mut v12, mut v13): (Rc<Heap0>, i32) = (v11.l0.clone(), v11.l1.clone());
    let (mut v14, mut v15): (i32, Rc<str>) = (v12.l0.clone(), v12.l1.clone());
    let mut v16: bool = v14 == 7i32;
    let mut v18: bool = if v16 {
        let mut v17: bool = v15.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v17
    } else {
        false
    };
    let mut v20: bool = if v18 {
        let mut v19: bool = v13 == 4i32;
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
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
