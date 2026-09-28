#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<RefCell<Vec<i32>>>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn method1(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 8i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method3(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 5i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method4(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 2i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            90i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            method2(v1.clone());
            method3(v1.clone());
            v1.clone().borrow_mut()[1i32 as usize] = 11i32;
            method4(v1.clone());
            method1(v1.clone())
        }
        _ => unreachable!(),
    }
}
fn method5(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            91i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            let mut v2: i32 = (v1.clone().borrow().len() as i32);
            let mut v3: i32 = v1.clone().borrow()[0i32 as usize].clone();
            let mut v4: i32 = v2 + v3;
            let mut v5: i32 = v1.clone().borrow()[1i32 as usize].clone();
            let mut v6: i32 = v4 + v5;
            v6
        }
        _ => unreachable!(),
    }
}
fn method6(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 0i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method7(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 2i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 2i32 as usize]));
    v0.clone().borrow_mut()[0i32 as usize] = 7i32;
    v0.clone().borrow_mut()[1i32 as usize] = 3i32;
    let mut v1: US0 = US0::US0_1(v0.clone());
    let mut v2: i32 = method0(v1.clone());
    let mut v3: US0 = US0::US0_1(v0.clone());
    let mut v4: i32 = method5(v3.clone());
    method6(v0.clone());
    method7(v0.clone());
    let mut v5: i32 = DynamicArrayRefCount0(v0);
    let mut v6: i32 = v4 + v2;
    let mut v7: i32 = (v0.clone().borrow().len() as i32);
    let mut v8: i32 = v6 + v7;
    let mut v9: i32 = v0.clone().borrow()[0i32 as usize].clone();
    let mut v10: i32 = v8 + v9;
    let mut v11: i32 = v0.clone().borrow()[1i32 as usize].clone();
    let mut v12: i32 = v10 + v11;
    let mut v13: i32 = v12 + v5;
    let mut v14: i32 = v13 - 31i32;
    v14
}
fn main() {
    std::process::exit(spiral_main());
}
