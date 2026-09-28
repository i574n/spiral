#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: Rc<str>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = (v0.clone().len() as i32);
        let mut v3: i32 = v2 + v1;
        v3
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>, mut v1: i32) -> i32 {
    v0(v1)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("abc");
    let mut v1: Rc<dyn Fn(i32) -> i32> = closure0(v0.clone());
    let mut v2: i32 = 39i32;
    method0(v1.clone(), v2)
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
