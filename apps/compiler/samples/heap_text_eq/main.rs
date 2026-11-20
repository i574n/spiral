#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: Rc<str>, l1: Rc<str> }
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v1: Rc<Heap0> = Rc::new(Heap0 { l0: v0.clone(), l1: v0 });
    let (mut v2, mut v3): (Rc<str>, Rc<str>) = (v1.l0.clone(), v1.l1.clone());
    let v4: bool = &*v2 == &*v3;
    if v4 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
