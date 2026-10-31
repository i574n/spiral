#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: u32, l1: Rc<str>, l2: bool }
fn spiral_main() -> i32 {
    let v0: u32 = 4000000000u32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: bool = true;
    let v3: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1, l2: v2 });
    let (mut v4, mut v5, mut v6): (u32, Rc<str>, bool) = (v3.l0.clone(), v3.l1.clone(), v3.l2.clone());
    let v7: bool = v4 == 4000000000u32;
    let v9: bool = if v7 {
        let v8: bool = &*v5 == "hi";
        v8
    } else {
        false
    };
    let v10: bool = v9 && v6;
    if v10 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
