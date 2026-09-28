#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 2i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 4i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    let mut v2: i32 = v1 - 15i32;
    v2
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 4i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 1i32;
    v1.clone().borrow_mut()[1i32 as usize] = 2i32;
    v1.clone().borrow_mut()[2i32 as usize] = 3i32;
    v1.clone().borrow_mut()[3i32 as usize] = 4i32;
    method0(v1.clone());
    method1(v1.clone());
    v1.clone().borrow_mut()[3i32 as usize] = 7i32;
    let mut v2: i32 = (v1.clone().borrow().len() as i32);
    let mut v3: i32 = v1.clone().borrow()[3i32 as usize].clone();
    let mut v4: i32 = v2 + v3;
    let mut v5: i32 = method2(v1.clone());
    let mut v6: i32 = v4 + v5;
    v6
}
fn main() {
    std::process::exit(spiral_main());
}
