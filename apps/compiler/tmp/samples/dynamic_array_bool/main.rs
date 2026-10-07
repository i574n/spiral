#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<bool>>> = Rc::new(RefCell::new(vec![<bool>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = true;
    v1.clone().borrow_mut()[1i32 as usize] = false;
    let mut v2: i32 = 0i32;
    let mut v3: bool = v1.clone().borrow()[v2 as usize].clone();
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
