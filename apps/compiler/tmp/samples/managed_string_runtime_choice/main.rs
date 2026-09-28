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
    let mut v0: bool = true;
    let mut v1: Rc<str> = method0(v0);
    let mut v2: bool = false;
    let mut v3: Rc<str> = method0(v2);
    let mut v4: i32 = method1(v1.clone());
    let mut v5: i32 = method1(v1.clone());
    let mut v6: i32 = v4 + v5;
    let mut v7: i32 = method1(v3.clone());
    let mut v8: i32 = v6 + v7;
    let mut v9: i32 = v8 - 14i32;
    v9
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
