#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<RefCell<Vec<Rc<str>>>>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn method0(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method2(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method3(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 8i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method4(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 3i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method5(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 2i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method1(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            90i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<Rc<str>>>> = v1.clone();
            method3(v1.clone());
            method4(v1.clone());
            let mut v2: Rc<str> = Rc::<str>::from("cde");
            v1.clone().borrow_mut()[1i32 as usize] = v2.clone();
            let mut v3: Rc<str> = Rc::<str>::from("f");
            v1.clone().borrow_mut()[2i32 as usize] = v3.clone();
            method5(v1.clone());
            method2(v1.clone())
        }
        _ => unreachable!(),
    }
}
fn method6(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            91i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<Rc<str>>>> = v1.clone();
            let mut v2: i32 = (v1.clone().borrow().len() as i32);
            let mut v3: Rc<str> = v1.clone().borrow()[0i32 as usize].clone();
            let mut v4: i32 = (v3.clone().len() as i32);
            let mut v5: i32 = v2 + v4;
            let mut v6: Rc<str> = v1.clone().borrow()[1i32 as usize].clone();
            let mut v7: i32 = (v6.clone().len() as i32);
            let mut v8: i32 = v5 + v7;
            v8
        }
        _ => unreachable!(),
    }
}
fn method7(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 0i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn method8(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> () {
    let mut v1: i32 = 1i32;
    DynamicArrayResize0(v0,v1);
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 4i32 as usize]));
    method0(v0.clone());
    let mut v1: Rc<str> = Rc::<str>::from("ab");
    v0.clone().borrow_mut()[0i32 as usize] = v1.clone();
    let mut v2: US0 = US0::US0_1(v0.clone());
    let mut v3: i32 = method1(v2.clone());
    let mut v4: US0 = US0::US0_1(v0.clone());
    let mut v5: i32 = method6(v4.clone());
    method7(v0.clone());
    method8(v0.clone());
    let mut v6: i32 = v5 + v3;
    let mut v7: i32 = (v0.clone().borrow().len() as i32);
    let mut v8: i32 = v6 + v7;
    let mut v9: i32 = v8 - 16i32;
    v9
}
fn main() {
    std::process::exit(spiral_main());
}
