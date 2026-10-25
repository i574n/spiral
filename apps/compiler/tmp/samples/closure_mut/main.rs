#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
fn f_c0(mut v0: Rc<RefCell<Mut0>>) -> Rc<dyn Fn(i32) -> Rc<RefCell<Mut0>>> {
    Rc::new(move |mut v1: i32| -> Rc<RefCell<Mut0>> {
        v0.clone()
    })
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 1i32 }));
    let mut v1: Rc<dyn Fn(i32) -> Rc<RefCell<Mut0>>> = f_c0(v0.clone());
    let mut v2: Rc<RefCell<Mut0>> = v1(1i32);
    v2.borrow_mut().l0 = 7i32;
    let mut v3: i32 = v2.borrow().l0.clone();
    let mut v4: bool = v3 == 7i32;
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
