#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
fn method0(mut v0: &Rc<RefCell<Mut0>>) -> bool {
    let mut v1: i32 = v0.borrow().l0;
    let mut v2: bool = v1 < 3i32;
    v2
}
fn keep_1(mut v0: Rc<str>) -> Rc<str> {
    v0
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    let mut v2: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32 }));
    while method0(&v2) {
        let v4: i32 = v2.borrow().l0;
        v1.borrow_mut()[v4 as usize] = v4;
        let v5: i32 = v4.wrapping_add(1i32);
        v2.borrow_mut().l0 = v5;
        ()
    };
    let mut v6: Vec<i32> = (v1).borrow().clone();
    let v8: bool = true; let _vec_fold_ = v6.into_iter().fold(0i32, |acc, x| { //;
    let v10: i32 = acc;
    let v12: i32 = x;
    let v13: Rc<str> = keep_1(v0.clone());
    let v14: i32 = (v13.clone().len() as i32);
    let v15: i32 = v10.wrapping_add(v14);
    let v16: i32 = v15.wrapping_add(v12);
    let v18: bool = true; v16 });
    let v20: i32 = _vec_fold_;
    let v21: i32 = v20.wrapping_sub(9i32);
    v21
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
