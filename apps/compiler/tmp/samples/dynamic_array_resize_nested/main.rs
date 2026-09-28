#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>>) -> () {
    let mut v1: i32 = 0i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 0i32;
    DynamicArrayResize1(v0,v1);
    ()
}
fn method3(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize1(v0,v1);
    ()
}
fn method5(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity1(v0);
    v1
}
fn method4(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>>) -> i32 {
    let mut v2: i32 = DynamicArrayCapacity0(v1);
    let mut v3: i32 = method5(v0.clone());
    let mut v4: i32 = v2 + v3;
    v4
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 7i32;
    let mut v2: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Vec<i32>>>>::default(); v0 as usize]));
    v2.clone().borrow_mut()[0i32 as usize] = v1.clone();
    let mut v3: Rc<RefCell<Vec<i32>>> = v2.clone().borrow()[0i32 as usize].clone();
    method0(v2.clone());
    method1(v2.clone());
    v2.clone().borrow_mut()[0i32 as usize] = v3.clone();
    method2(v1.clone());
    method3(v3.clone());
    v1.clone().borrow_mut()[0i32 as usize] = 9i32;
    let mut v4: Rc<RefCell<Vec<i32>>> = v2.clone().borrow()[0i32 as usize].clone();
    let mut v5: i32 = v4.clone().borrow()[0i32 as usize].clone();
    let mut v6: i32 = (v4.clone().borrow().len() as i32);
    let mut v7: i32 = v5 + v6;
    let mut v8: i32 = (v2.clone().borrow().len() as i32);
    let mut v9: i32 = v7 + v8;
    let mut v10: i32 = method4(v1.clone(), v2.clone());
    let mut v11: i32 = v9 + v10;
    let mut v12: i32 = v11 - 13i32;
    v12
}
fn main() {
    std::process::exit(spiral_main());
}
