#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<str>) -> bool {
    true
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("spiral");
    let mut v1: bool = method0(v0.clone());
    if v1 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
