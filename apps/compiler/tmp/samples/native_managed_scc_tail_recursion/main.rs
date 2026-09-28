#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method2(mut v0: i32, mut v1: Rc<str>) -> i32 {
    let mut v2: i32 = v0 - 1i32;
    let mut v3: bool = v2 == 0i32;
    if v3 {
        let mut v4: i32 = (v1.clone().len() as i32);
        v4
    } else {
        method1(v2, v1.clone())
    }
}
fn method1(mut v0: i32, mut v1: Rc<str>) -> i32 {
    let mut v2: i32 = v0 - 1i32;
    let mut v3: bool = v2 == 0i32;
    if v3 {
        99i32
    } else {
        method2(v2, v1.clone())
    }
}
fn method0(mut v0: i32, mut v1: Rc<str>) -> i32 {
    let mut v2: bool = v0 == 0i32;
    let mut v5: i32 = if v2 {
        let mut v3: i32 = (v1.clone().len() as i32);
        v3
    } else {
        method1(v0, v1.clone())
    };
    let mut v6: i32 = v5 - 2i32;
    v6
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1000000i32;
    let mut v1: i32 = v0 % 2i32;
    let mut v2: bool = v1 == 0i32;
    let mut v5: Rc<str> = if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("ok");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("go");
        v4.clone()
    };
    method0(v0, v5.clone())
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
