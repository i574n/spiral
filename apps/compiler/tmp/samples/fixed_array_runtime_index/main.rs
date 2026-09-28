#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4i32 as usize]));
    v0.clone().borrow_mut()[0i32 as usize] = 2i32;
    v0.clone().borrow_mut()[1i32 as usize] = 3i32;
    v0.clone().borrow_mut()[2i32 as usize] = 5i32;
    v0.clone().borrow_mut()[3i32 as usize] = 7i32;
    let mut v1: i32 = 2i32;
    let mut v2: i32 = v0.clone().borrow()[v1 as usize].clone();
    let mut v3: i32 = v2 - 5i32;
    v3
}
fn main() {
    std::process::exit(spiral_main());
}
