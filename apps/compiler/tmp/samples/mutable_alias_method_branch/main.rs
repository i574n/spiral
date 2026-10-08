#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
fn method0(mut v0: Rc<RefCell<Mut0>>) -> () {
    let mut v1: i32 = v0.borrow().l0.clone();
    let mut v2: i32 = v1.wrapping_add(5i32);
    v0.borrow_mut().l0 = v2;
    ()
}
fn method1(mut v0: Rc<RefCell<Mut0>>) -> () {
    ()
}
fn method2(mut v0: Rc<RefCell<Mut0>>) -> () {
    let mut v1: i32 = v0.borrow().l0.clone();
    let mut v2: i32 = v1.wrapping_add(7i32);
    v0.borrow_mut().l0 = v2;
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32 }));
    method0(v0.clone());
    method1(v0.clone());
    method2(v0.clone());
    let mut v1: i32 = v0.borrow().l0.clone();
    let mut v2: i32 = v1.wrapping_sub(12i32);
    v2
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
