#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method1(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 8i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method2(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method3(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn method4(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method5(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 4i32 as usize]));
    method0(v0.clone());
    let mut v1: Rc<str> = Rc::<str>::from("ab");
    v0.clone().borrow_mut()[0i32 as usize] = v1.clone();
    method1(v0.clone());
    method2(v0.clone());
    let mut v2: Rc<str> = Rc::<str>::from("cde");
    v0.clone().borrow_mut()[1i32 as usize] = v2.clone();
    let mut v3: Rc<str> = Rc::<str>::from("f");
    v0.clone().borrow_mut()[2i32 as usize] = v3.clone();
    let mut v4: Rc<str> = v0.clone().borrow()[0i32 as usize].clone();
    let mut v5: Rc<str> = v0.clone().borrow()[1i32 as usize].clone();
    let mut v6: Rc<str> = v0.clone().borrow()[2i32 as usize].clone();
    let mut v7: i32 = method3(v0.clone());
    let mut v8: i32 = method4(v0.clone());
    method5(v0.clone());
    let mut v9: i32 = (v4.clone().len() as i32);
    let mut v10: i32 = (v5.clone().len() as i32);
    let mut v11: i32 = v9 + v10;
    let mut v12: i32 = (v6.clone().len() as i32);
    let mut v13: i32 = v11 + v12;
    let mut v14: i32 = v13 + v7;
    let mut v15: i32 = v14 + v8;
    let mut v16: i32 = (v0.clone().borrow().len() as i32);
    let mut v17: i32 = v15 + v16;
    let mut v18: i32 = v17 - 17i32;
    v18
}
fn main() {
    std::process::exit(spiral_main());
}
