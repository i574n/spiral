#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>) -> Rc<RefCell<Vec<i32>>> {
    loop {
        let mut v3: i32 = v0.wrapping_sub(1i32);
        let mut v4: bool = v3 == 0i32;
        if v4 {
            return v2.clone();
        } else {
            (v0, v1, v2) = (v3, v2.clone(), v1.clone());
            continue;
        }
    }
}
fn method0(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>) -> Rc<RefCell<Vec<i32>>> {
    let mut v2: i32 = 1000000i32;
    let mut v3: bool = v2 == 0i32;
    if v3 {
        v0.clone()
    } else {
        method1(v2, v0.clone(), v1.clone())
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let mut v2: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 7i32;
    v2.clone().borrow_mut()[0i32 as usize] = 11i32;
    let mut v3: Rc<RefCell<Vec<i32>>> = method0(v1.clone(), v2.clone());
    v3.clone().borrow_mut()[0i32 as usize] = 13i32;
    let mut v4: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let mut v5: bool = v4 == 13i32;
    if v5 {
        let mut v6: i32 = v2.clone().borrow()[0i32 as usize].clone();
        let mut v7: bool = v6 == 11i32;
        if v7 {
            0i32
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
