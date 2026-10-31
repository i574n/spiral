#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: Rc<RefCell<Vec<Rc<str>>>> }
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 1i32 as usize]));
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let v3: Rc<RefCell<Vec<Rc<str>>>> = v2.l0.clone();
    let v4: Rc<str> = v3.borrow()[0i32 as usize].clone();
    let v5: bool = &*v4 == "hi";
    if v5 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
