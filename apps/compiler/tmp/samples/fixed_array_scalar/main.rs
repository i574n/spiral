#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    v0.clone().borrow_mut()[0i32 as usize] = 2i32;
    v0.clone().borrow_mut()[1i32 as usize] = 3i32;
    v0.clone().borrow_mut()[2i32 as usize] = 5i32;
    let mut v1: i32 = v0.clone().borrow()[0i32 as usize].clone();
    let mut v2: i32 = v0.clone().borrow()[1i32 as usize].clone();
    let mut v3: i32 = v0.clone().borrow()[2i32 as usize].clone();
    let mut v4: i32 = v1 + v2;
    let mut v5: i32 = v4 + v3;
    let mut v6: i32 = v5 - 10i32;
    v6
}
fn main() {
    std::process::exit(spiral_main());
}
