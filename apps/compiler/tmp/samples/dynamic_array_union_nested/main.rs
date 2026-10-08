#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => {
            0i32
        }
        US0::US0_1(v1) => {
            let mut v1: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>> = v1.clone();
            let mut v2: Rc<RefCell<Vec<i32>>> = v1.clone().borrow()[0i32 as usize].clone();
            let mut v3: Rc<RefCell<Vec<i32>>> = v1.clone().borrow()[1i32 as usize].clone();
            let mut v4: i32 = (v1.clone().borrow().len() as i32);
            let mut v5: i32 = v2.clone().borrow()[0i32 as usize].clone();
            let mut v6: i32 = v4.wrapping_add(v5);
            let mut v7: i32 = v2.clone().borrow()[1i32 as usize].clone();
            let mut v8: i32 = v6.wrapping_add(v7);
            let mut v9: i32 = v3.clone().borrow()[0i32 as usize].clone();
            let mut v10: i32 = v8.wrapping_add(v9);
            let mut v11: i32 = v3.clone().borrow()[1i32 as usize].clone();
            let mut v12: i32 = v10.wrapping_add(v11);
            v12
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<Rc<RefCell<Vec<i32>>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Vec<i32>>>>::default(); v0 as usize]));
    let mut v2: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let mut v3: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v2.clone().borrow_mut()[0i32 as usize] = 3i32;
    v2.clone().borrow_mut()[1i32 as usize] = 4i32;
    v3.clone().borrow_mut()[0i32 as usize] = 5i32;
    v3.clone().borrow_mut()[1i32 as usize] = 6i32;
    v1.clone().borrow_mut()[0i32 as usize] = v2.clone();
    v1.clone().borrow_mut()[1i32 as usize] = v3.clone();
    let mut v4: US0 = US0::US0_1(v1.clone());
    let mut v5: i32 = score_0(v4.clone());
    let mut v6: i32 = v5.wrapping_sub(20i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
