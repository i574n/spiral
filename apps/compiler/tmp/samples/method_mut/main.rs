#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
fn method0(mut v0: Rc<RefCell<Mut0>>) -> Rc<RefCell<Mut0>> {
    v0
}
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 1i32 }));
    let mut v1: Rc<RefCell<Mut0>> = method0(v0);
    v1.borrow_mut().l0 = 7i32;
    let v2: i32 = v1.borrow().l0.clone();
    let v3: bool = v2 == 7i32;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
