#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> Rc<RefCell<Vec<i32>>> {
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 1i32 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = v0;
    v1.clone()
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = method0(v0);
    let mut v2: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let mut v3: bool = v2 == 7i32;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
