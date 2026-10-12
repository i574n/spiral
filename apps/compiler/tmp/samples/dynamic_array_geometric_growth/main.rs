#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 0i32 as usize]));
    method0(v0.clone());
    let mut v1: i32 = method1(v0.clone());
    let mut v2: i32 = v1 - 4i32;
    v2
}
fn main() {
    std::process::exit(spiral_main());
}
