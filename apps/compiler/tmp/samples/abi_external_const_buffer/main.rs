#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 4i32;
    let mut v1: Rc<RefCell<Vec<u8>>> = Rc::new(RefCell::new(vec![<u8>::default(); v0 as usize]));
    let mut v2: Rc<RefCell<Vec<u8>>> = Rc::new(RefCell::new(vec![<u8>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 65u8;
    v1.clone().borrow_mut()[1i32 as usize] = 66u8;
    v1.clone().borrow_mut()[2i32 as usize] = 67u8;
    v1.clone().borrow_mut()[3i32 as usize] = 68u8;
    v2.clone().borrow_mut()[0i32 as usize] = 65u8;
    v2.clone().borrow_mut()[1i32 as usize] = 66u8;
    v2.clone().borrow_mut()[2i32 as usize] = 67u8;
    v2.clone().borrow_mut()[3i32 as usize] = 69u8;
    let mut v3: i32 = 3i32;
    let mut v4: i32 = 4i32;
    let mut v5: i32 = spiral_abi_libc_memcmp(v1,v2,v3);
    let mut v6: i32 = spiral_abi_libc_memcmp(v1,v2,v4);
    let mut v7: bool = v5 == 0i32;
    if v7 {
        let mut v8: bool = v6 == 0i32;
        if v8 {
            2i32
        } else {
            let mut v9: u8 = v1.clone().borrow()[3i32 as usize].clone();
            let mut v10: bool = v9 == 68u8;
            if v10 {
                let mut v11: u8 = v2.clone().borrow()[3i32 as usize].clone();
                let mut v12: bool = v11 == 69u8;
                if v12 {
                    0i32
                } else {
                    4i32
                }
            } else {
                3i32
            }
        }
    } else {
        1i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
