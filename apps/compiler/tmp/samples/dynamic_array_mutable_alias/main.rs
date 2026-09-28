#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 1i32;
    let mut v2: i32 = 9i32;
    v0.clone().borrow_mut()[v1 as usize] = v2;
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = v0.clone().borrow()[v1 as usize].clone();
    v2
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = 1i32;
    let mut v2: i32 = v0.clone().borrow()[v1 as usize].clone();
    v2
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 1i32;
    v1.clone().borrow_mut()[1i32 as usize] = 2i32;
    method0(v1.clone());
    let mut v2: i32 = method1(v1.clone());
    let mut v3: i32 = method2(v1.clone());
    let mut v4: i32 = v2 + v3;
    let mut v5: i32 = v4 - 10i32;
    v5
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
