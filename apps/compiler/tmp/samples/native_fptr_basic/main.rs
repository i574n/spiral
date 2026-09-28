#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0() -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v0: i32| -> i32 {
        let mut v1: i32 = v0 + 2i32;
        v1
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 40i32;
    let mut v1: Rc<dyn Fn(i32) -> i32> = closure0();
    v1(v0)
}
fn main() {
    std::process::exit(spiral_main());
}
