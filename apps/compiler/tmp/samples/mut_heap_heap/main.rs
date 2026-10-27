#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
struct Mut0 { l0: Rc<Heap1> }
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let mut v5: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v4.clone() }));
    let v6: i32 = 7i32;
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v8: Rc<Heap0> = Rc::new(Heap0 { l0: v6, l1: v7.clone() });
    let v9: i32 = 4i32;
    let v10: Rc<Heap1> = Rc::new(Heap1 { l0: v8.clone(), l1: v9 });
    v5.borrow_mut().l0 = v10.clone();
    let v11: Rc<Heap1> = v5.borrow().l0.clone();
    let (mut v12, mut v13): (Rc<Heap0>, i32) = (v11.l0.clone(), v11.l1.clone());
    let (mut v14, mut v15): (i32, Rc<str>) = (v12.l0.clone(), v12.l1.clone());
    let v16: bool = v14 == 7i32;
    let v18: bool = if v16 {
        let v17: bool = &*v15 == "hi";
        v17
    } else {
        false
    };
    let v20: bool = if v18 {
        let v19: bool = v13 == 4i32;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
