#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32, l1: i32 }
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 1i32, l1: 2i32 }));
    v0.borrow_mut().l0 = 3i32;
    v0.borrow_mut().l1 = 4i32;
    let (mut v1, mut v2): (i32, i32) = (v0.borrow().l0.clone(), v0.borrow().l1.clone());
    let mut v3: i32 = v1.wrapping_add(v2);
    v3
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
