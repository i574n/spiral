#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: bool) -> Rc<str> {
    if v0 {
        let mut v1: Rc<str> = Rc::<str>::from("alpha");
        v1.clone()
    } else {
        let mut v2: Rc<str> = Rc::<str>::from("beta");
        v2.clone()
    }
}
fn method1(mut v0: Rc<str>) -> i32 {
    let mut v1: i32 = (v0.clone().len() as i32);
    v1
}
fn spiral_main() -> i32 {
    let mut v0: bool = false;
    let mut v1: Rc<str> = method0(v0);
    let mut v2: bool = true;
    let mut v3: Rc<str> = method0(v2);
    let mut v4: bool = true;
    let mut v5: Rc<str> = method0(v4);
    let mut v6: bool = false;
    let mut v7: Rc<str> = method0(v6);
    let mut v8: bool = false;
    let mut v9: Rc<str> = method0(v8);
    let mut v10: bool = true;
    let mut v11: Rc<str> = method0(v10);
    let mut v12: bool = false;
    let mut v13: Rc<str> = method0(v12);
    let mut v14: i32 = method1(v11.clone());
    let mut v15: i32 = method1(v11.clone());
    let mut v16: i32 = v14 + v15;
    let mut v17: i32 = method1(v13.clone());
    let mut v18: i32 = v16 + v17;
    let mut v19: i32 = v18 - 14i32;
    v19
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
