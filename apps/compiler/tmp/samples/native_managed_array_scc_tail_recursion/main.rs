#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 4i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method3(mut v0: i32, mut v1: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v2: i32 = v0 - 1i32;
    let mut v3: bool = v2 == 0i32;
    if v3 {
        let mut v4: i32 = v1.clone().borrow()[0i32 as usize].clone();
        v4
    } else {
        method2(v2, v1.clone())
    }
}
fn method2(mut v0: i32, mut v1: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v2: i32 = v0 - 1i32;
    let mut v3: bool = v2 == 0i32;
    if v3 {
        99i32
    } else {
        method3(v2, v1.clone())
    }
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = 1000000i32;
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: i32 = v0.clone().borrow()[0i32 as usize].clone();
        v3
    } else {
        method2(v1, v0.clone())
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 7i32;
    method0(v1.clone());
    let mut v2: i32 = method1(v1.clone());
    v1.clone().borrow_mut()[0i32 as usize] = 13i32;
    let mut v3: bool = v2 == 7i32;
    if v3 {
        let mut v4: i32 = v1.clone().borrow()[0i32 as usize].clone();
        let mut v5: bool = v4 == 13i32;
        if v5 {
            0i32
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
