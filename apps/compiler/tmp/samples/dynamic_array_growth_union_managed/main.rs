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
fn method0(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 1i32;
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
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method5(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method6(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 5i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method7(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method8(mut v0: Rc<RefCell<Vec<i32>>>) -> () {
    let mut v1: i32 = 9i32;
    DynamicArrayReserve0(v0,v1);
    ()
}
fn method9(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    v1
}
fn method10(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn method13(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn method12(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayCapacity0(v0);
    let mut v2: i32 = method13(v0.clone());
    let mut v3: i32 = v1 + v2;
    v3
}
fn method11(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            70i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            method12(v1.clone())
        }
        _ => unreachable!(),
    }
}
fn method14(mut v0: Rc<RefCell<Vec<i32>>>) -> i32 {
    let mut v1: i32 = DynamicArrayRefCount0(v0);
    v1
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 0i32 as usize]));
    method0(v0.clone());
    let mut v1: i32 = method1(v0.clone());
    method2(v0.clone());
    let mut v2: i32 = method3(v0.clone());
    method4(v0.clone());
    let mut v3: i32 = method5(v0.clone());
    method6(v0.clone());
    let mut v4: i32 = method7(v0.clone());
    method8(v0.clone());
    let mut v5: i32 = method9(v0.clone());
    let mut v6: i32 = method10(v0.clone());
    let mut v7: US0 = US0::US0_1(v0.clone());
    let mut v8: i32 = method11(v7.clone());
    let mut v9: i32 = method14(v0.clone());
    let mut v10: i32 = v1 - 1i32;
    let mut v11: i32 = v2 - 2i32;
    let mut v12: i32 = v10 + v11;
    let mut v13: i32 = v3 - 4i32;
    let mut v14: i32 = v12 + v13;
    let mut v15: i32 = v4 - 8i32;
    let mut v16: i32 = v14 + v15;
    let mut v17: i32 = v5 - 16i32;
    let mut v18: i32 = v16 + v17;
    let mut v19: i32 = v6 - 2i32;
    let mut v20: i32 = v18 + v19;
    let mut v21: i32 = v8 - 20i32;
    let mut v22: i32 = v20 + v21;
    let mut v23: i32 = v9 - 2i32;
    let mut v24: i32 = v22 + v23;
    v24
}
fn main() {
    std::process::exit(spiral_main());
}
