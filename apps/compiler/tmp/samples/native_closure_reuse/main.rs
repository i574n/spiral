#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: i32, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let mut v3: i32 = v0 + v1;
        let mut v4: i32 = v3 + v2;
        v4
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: Rc<dyn Fn(i32) -> i32> = closure0(v0, v1);
    let mut v3: i32 = v2(10i32);
    let mut v4: i32 = v2(20i32);
    let mut v5: i32 = v2(3i32);
    let mut v6: i32 = v3 + v4;
    let mut v7: i32 = v6 + v5;
    v7
}
fn main() {
    std::process::exit(spiral_main());
}
