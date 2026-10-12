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
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 2i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method3(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method4(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method5(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 0i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method6(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 0i32 as usize]));
    method0(v0.clone());
    let mut v1: i32 = method1(v0.clone());
    let mut v2: bool = v1 < 3i32;
    if v2 {
        10i32
    } else {
        method2(v0.clone());
        let mut v3: i32 = method3(v0.clone());
        let mut v4: bool = v3 == v1;
        if v4 {
            method4(v0.clone());
            v0.clone().borrow_mut()[0i32 as usize] = 4i32;
            v0.clone().borrow_mut()[1i32 as usize] = 5i32;
            v0.clone().borrow_mut()[2i32 as usize] = 6i32;
            method5(v0.clone());
            method6(v0.clone());
            let mut v5: i32 = (v0.clone().borrow().len() as i32);
            let mut v6: i32 = v0.clone().borrow()[0i32 as usize].clone();
            let mut v7: i32 = v5 + v6;
            let mut v8: i32 = v0.clone().borrow()[1i32 as usize].clone();
            let mut v9: i32 = v7 + v8;
            let mut v10: i32 = v0.clone().borrow()[2i32 as usize].clone();
            let mut v11: i32 = v9 + v10;
            let mut v12: i32 = v11 - 3i32;
            v12
        } else {
            11i32
        }
    }
}
fn main() {
    std::process::exit(spiral_main());
}
