#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: i32 }
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let v3: i32 = 1i32;
    let v4: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v3 });
    let (mut v5, mut v6): (Rc<Heap0>, i32) = (v4.l0.clone(), v4.l1.clone());
    let (mut v7, mut v8): (i32, Rc<str>) = (v5.l0.clone(), v5.l1.clone());
    let v9: bool = v7 == 7i32;
    let v11: bool = if v9 {
        let v10: bool = &*v8 == "hi";
        v10
    } else {
        false
    };
    let v13: bool = if v11 {
        let v12: bool = v6 == 1i32;
        v12
    } else {
        false
    };
    if v13 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
