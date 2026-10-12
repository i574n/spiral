#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<u8>>> = Rc::new(RefCell::new(vec![<u8>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 0u8;
    v1.clone().borrow_mut()[1i32 as usize] = 0u8;
    let mut v2: i32 = 65i32;
    let mut v3: i32 = 3i32;
    let mut v4: i32 = spiral_abi_libc_memset(v1,v2,v3);
    v4
}
fn main() {
    std::process::exit(spiral_main());
}
