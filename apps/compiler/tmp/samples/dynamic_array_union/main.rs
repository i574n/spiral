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
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            0i32
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
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 4i32;
    v1.clone().borrow_mut()[1i32 as usize] = 5i32;
    let mut v2: US0 = US0::US0_1(v1.clone());
    let mut v3: i32 = method0(v2.clone());
    let mut v4: i32 = v3 - 11i32;
    v4
}
fn main() {
    std::process::exit(spiral_main());
}
