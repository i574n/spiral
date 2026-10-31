#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
impl Default for Heap1 {
    fn default() -> Self {
        Heap1 { l0: <Rc<Heap0>>::default(), l1: <i32>::default() }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v3 });
    let v5: Rc<RefCell<Vec<Rc<Heap1>>>> = Rc::new(RefCell::new(vec![<Rc<Heap1>>::default(); 1i32 as usize]));
    v5.clone().borrow_mut()[0i32 as usize] = v4;
    let v6: Rc<Heap1> = v5.borrow()[0i32 as usize].clone();
    let (mut v7, mut v8): (Rc<Heap0>, i32) = (v6.l0.clone(), v6.l1.clone());
    let (mut v9, mut v10): (i32, Rc<str>) = (v7.l0.clone(), v7.l1.clone());
    let v11: bool = v9 == 7i32;
    let v13: bool = if v11 {
        let v12: bool = &*v10 == "hi";
        v12
    } else {
        false
    };
    let v15: bool = if v13 {
        let v14: bool = v8 == 1i32;
        v14
    } else {
        false
    };
    if v15 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
