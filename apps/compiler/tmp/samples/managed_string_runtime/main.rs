#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("qwe");
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: i32 = v1 + v1;
    let mut v3: i32 = v2 - 6i32;
    v3
}
fn main() {
    std::process::exit(spiral_main());
}
