#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0() -> (Rc<RefCell<Vec<i32>>>, i32) {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 3i32;
    v1.clone().borrow_mut()[1i32 as usize] = 4i32;
    (v1.clone(), 1i32)
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: i32) -> i32 {
    let mut v2: i32 = v0.clone().borrow()[0i32 as usize].clone();
    let mut v3: i32 = v2.wrapping_add(v1);
    let mut v4: i32 = v3.wrapping_sub(1i32);
    v4
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: i32) -> i32 {
    let mut v2: i32 = v0.clone().borrow()[0i32 as usize].clone();
    let mut v3: i32 = v0.clone().borrow()[1i32 as usize].clone();
    let mut v4: i32 = v2.wrapping_add(v3);
    let mut v5: i32 = v4.wrapping_add(v1);
    v5
}
fn spiral_main() -> i32 {
    let (mut v0, mut v1): (Rc<RefCell<Vec<i32>>>, i32) = method0();
    let mut v2: i32 = method1(v0.clone(), v1);
    let mut v3: i32 = method2(v0.clone(), v1);
    let mut v4: i32 = v2.wrapping_add(v3);
    let mut v5: i32 = v4.wrapping_sub(11i32);
    v5
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
