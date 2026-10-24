#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Empty,
    US0_Nested(Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>>),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Empty => {
            0i32
        }
        US0::US0_Nested(v1) => {
            let v1: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>> = v1.clone();
            let v2: Rc<RefCell<Vec<i32>>> = v1.clone().borrow()[0i32 as usize].clone();
            let v3: Rc<RefCell<Vec<i32>>> = v1.clone().borrow()[1i32 as usize].clone();
            let v4: i32 = (v1.borrow().len() as i32);
            let v5: i32 = v2.clone().borrow()[0i32 as usize].clone();
            let v6: i32 = v4.wrapping_add(v5);
            let v7: i32 = v2.borrow()[1i32 as usize].clone();
            let v8: i32 = v6.wrapping_add(v7);
            let v9: i32 = v3.clone().borrow()[0i32 as usize].clone();
            let v10: i32 = v8.wrapping_add(v9);
            let v11: i32 = v3.borrow()[1i32 as usize].clone();
            let v12: i32 = v10.wrapping_add(v11);
            v12
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 2i32;
    let v1: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Vec<i32>>>>::default(); v0 as usize]));
    let v2: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let v3: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v2.clone().borrow_mut()[0i32 as usize] = 3i32;
    v2.clone().borrow_mut()[1i32 as usize] = 4i32;
    v3.clone().borrow_mut()[0i32 as usize] = 5i32;
    v3.clone().borrow_mut()[1i32 as usize] = 6i32;
    v1.clone().borrow_mut()[0i32 as usize] = v2;
    v1.clone().borrow_mut()[1i32 as usize] = v3;
    let v4: US0 = US0::US0_Nested(v1);
    let v5: i32 = score_0(v4);
    let v6: i32 = v5.wrapping_sub(20i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
