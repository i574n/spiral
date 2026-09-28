#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> (Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>) {
    (v0.clone(), v0.clone())
}
fn method5(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v2: i32 = DynamicArrayRefCount0(v0);
    let mut v3: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let mut v4: i32 = v2 + v3;
    let mut v5: i32 = v0.clone().borrow()[0i32 as usize].clone();
    let mut v6: i32 = v4 + v5;
    v6
}
fn method4(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v2: i32 = DynamicArrayCapacity0(v1);
    let mut v3: i32 = method5(v0.clone(), v1.clone());
    let mut v4: i32 = v2 + v3;
    v4
}
fn method3(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>) -> i32 {
    method4(v1.clone(), v0.clone())
}
fn method6(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 7i32;
    method0(v1.clone());
    let mut v2: i32 = method1(v1.clone());
    let (mut v3, mut v4): (Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>) = method2(v1.clone());
    let mut v5: i32 = method3(v3.clone(), v4.clone());
    let mut v6: i32 = method6(v1.clone());
    let mut v7: i32 = v5 + v2;
    let mut v8: i32 = v7 + v6;
    let mut v9: i32 = v8 - 29i32;
    v9
}
fn main() {
    std::process::exit(spiral_main());
}
