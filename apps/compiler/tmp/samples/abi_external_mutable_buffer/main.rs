#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 4i32;
    let mut v1: Rc<RefCell<Vec<u8>>> = Rc::new(RefCell::new(vec![<u8>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 0u8;
    v1.clone().borrow_mut()[1i32 as usize] = 0u8;
    v1.clone().borrow_mut()[2i32 as usize] = 0u8;
    v1.clone().borrow_mut()[3i32 as usize] = 0u8;
    let mut v2: i32 = 65i32;
    let mut v3: i32 = 3i32;
    let mut v4: i32 = spiral_abi_libc_memset(v1,v2,v3);
    let mut v5: bool = v4 == 3i32;
    if v5 {
        let mut v6: u8 = v1.clone().borrow()[0i32 as usize].clone();
        let mut v7: bool = v6 == 65u8;
        if v7 {
            let mut v8: u8 = v1.clone().borrow()[1i32 as usize].clone();
            let mut v9: bool = v8 == 65u8;
            if v9 {
                let mut v10: u8 = v1.clone().borrow()[2i32 as usize].clone();
                let mut v11: bool = v10 == 65u8;
                if v11 {
                    let mut v12: u8 = v1.clone().borrow()[3i32 as usize].clone();
                    let mut v13: bool = v12 == 0u8;
                    if v13 {
                        0i32
                    } else {
                        4i32
                    }
                } else {
                    3i32
                }
            } else {
                2i32
            }
        } else {
            1i32
        }
    } else {
        5i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
