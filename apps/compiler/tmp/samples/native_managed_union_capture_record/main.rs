#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<str>, Rc<RefCell<Vec<i32>>>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn closure1(mut v0: US0) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v12: i32 = match &v0 {
            US0::US0_0 => { // Empty
                3i32
            }
            US0::US0_1(v2, v3) => { // Item
                let mut v2: Rc<str> = v2.clone();
                let mut v3: Rc<RefCell<Vec<i32>>> = v3.clone();
                let mut v4: i32 = (v2.clone().len() as i32);
                let mut v5: i32 = (v3.clone().borrow().len() as i32);
                let mut v6: i32 = v4 + v5;
                let mut v7: i32 = v3.clone().borrow()[0i32 as usize].clone();
                let mut v8: i32 = v6 + v7;
                let mut v9: i32 = v3.clone().borrow()[1i32 as usize].clone();
                let mut v10: i32 = v8 + v9;
                v10
            }
            _ => unreachable!(),
        };
        let mut v13: i32 = v12 + v1;
        v13
    })
}
fn closure0() -> Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> {
    Rc::new(move |mut v0: i32| -> Rc<dyn Fn(i32) -> i32> {
        let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 2i32 as usize]));
        v1.clone().borrow_mut()[0i32 as usize] = v0;
        let mut v2: i32 = v0 + 1i32;
        v1.clone().borrow_mut()[1i32 as usize] = v2;
        let mut v3: bool = v0 == 0i32;
        let mut v7: US0 = if v3 {
            US0::US0_0
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("hi");
            US0::US0_1(v5.clone(), v1.clone())
        };
        closure1(v7.clone())
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>>) -> Rc<dyn Fn(i32) -> i32> {
    v0(0i32)
}
fn method1(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>>) -> Rc<dyn Fn(i32) -> i32> {
    v0(4i32)
}
fn method4(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    let mut v1: i32 = v0(2i32);
    let mut v2: i32 = v1 + 5i32;
    v2
}
fn method3(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    let mut v1: i32 = v0(1i32);
    let mut v2: i32 = method4(v0.clone());
    let mut v3: i32 = v1 + v2;
    v3
}
fn method2(mut v0: Rc<dyn Fn(i32) -> i32>, mut v1: Rc<dyn Fn(i32) -> i32>) -> i32 {
    let mut v2: i32 = v0(5i32);
    let mut v3: i32 = method3(v1.clone());
    let mut v4: i32 = v2 + v3;
    v4
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> = closure0();
    let mut v1: Rc<dyn Fn(i32) -> i32> = method0(v0.clone());
    let mut v2: Rc<dyn Fn(i32) -> i32> = method1(v0.clone());
    method2(v1.clone(), v2.clone())
}
fn main() {
    std::process::exit(spiral_main());
}
