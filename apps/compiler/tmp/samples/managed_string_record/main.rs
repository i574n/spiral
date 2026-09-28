#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<str>) -> (Rc<str>, i32) {
    let mut v1: i32 = (v0.clone().len() as i32);
    (v0.clone(), v1)
}
fn method1(mut v0: i32, mut v1: Rc<str>) -> i32 {
    let mut v2: i32 = (v1.clone().len() as i32);
    let mut v3: i32 = v2 + v0;
    v3
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("qwe");
    let (mut v1, mut v2): (Rc<str>, i32) = method0(v0.clone());
    let mut v3: i32 = method1(v2, v1.clone());
    let mut v4: i32 = method1(v2, v1.clone());
    let mut v5: i32 = v3 + v4;
    let mut v6: i32 = v5 - 12i32;
    v6
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
