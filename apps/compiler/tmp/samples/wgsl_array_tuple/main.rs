#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<RefCell<Vec<(i32, bool)>>> = Rc::new(RefCell::new(vec![<(i32, bool)>::default(); v0 as usize]));
    let mut v2: i32 = 4i32;
    v1.clone().borrow_mut()[0i32 as usize] = (v2, true);
    v1.clone().borrow_mut()[1i32 as usize] = (7i32, false);
    v1.clone().borrow_mut()[2i32 as usize] = (9i32, true);
    let (mut v3, mut v4): (i32, bool) = v1.clone().borrow()[0i32 as usize].clone();
    let (mut v5, mut v6): (i32, bool) = v1.clone().borrow()[1i32 as usize].clone();
    let mut v7: i32 = 2i32;
    let (mut v8, mut v9): (i32, bool) = v1.clone().borrow()[v7 as usize].clone();
    let mut v10: i32 = if v4 {
        1i32
    } else {
        0i32
    };
    let mut v11: i32 = if v6 {
        10i32
    } else {
        0i32
    };
    let mut v12: i32 = if v9 {
        100i32
    } else {
        0i32
    };
    let mut v13: i32 = v3.wrapping_add(v5);
    let mut v14: i32 = v13.wrapping_add(v8);
    let mut v15: i32 = v14.wrapping_add(v10);
    let mut v16: i32 = v15.wrapping_add(v11);
    let mut v17: i32 = v16.wrapping_add(v12);
    v17
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
