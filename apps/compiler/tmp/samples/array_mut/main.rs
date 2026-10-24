#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <i32>::default() }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    let v1: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 1i32 }));
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let mut v2: Rc<RefCell<Mut0>> = v0.borrow()[0i32 as usize].clone();
    v2.borrow_mut().l0 = 7i32;
    let v3: i32 = v2.borrow().l0.clone();
    let v4: bool = v3 == 7i32;
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
