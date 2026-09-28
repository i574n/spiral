#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0() -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v0: i32| -> i32 {
        let mut v1: i32 = v0 + 2i32;
        v1
    })
}
fn closure1() -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v0: i32| -> i32 {
        let mut v1: i32 = v0 + 3i32;
        v1
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(40i32)
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v3: Rc<dyn Fn(i32) -> i32> = if v0 {
        closure0()
    } else {
        closure1()
    };
    method0(v3.clone())
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
