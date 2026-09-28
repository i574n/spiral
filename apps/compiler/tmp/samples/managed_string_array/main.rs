#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 2i32 as usize]));
    let mut v1: Rc<str> = Rc::<str>::from("ab");
    v0.clone().borrow_mut()[0i32 as usize] = v1.clone();
    let mut v2: Rc<str> = Rc::<str>::from("cde");
    v0.clone().borrow_mut()[1i32 as usize] = v2.clone();
    let mut v3: Rc<str> = v0.clone().borrow()[0i32 as usize].clone();
    let mut v4: Rc<str> = v0.clone().borrow()[1i32 as usize].clone();
    let mut v5: i32 = (v3.clone().len() as i32);
    let mut v6: i32 = (v4.clone().len() as i32);
    let mut v7: i32 = v5 + v6;
    let mut v8: i32 = v7 - 5i32;
    v8
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
