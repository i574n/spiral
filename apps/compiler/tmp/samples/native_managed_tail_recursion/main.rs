#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let mut v2: i32 = v0 - 1i32;
        let mut v3: bool = v2 == 0i32;
        if v3 {
            return v1.clone();
        } else {
            let mut v4: i32 = v2 % 2i32;
            let mut v5: bool = v4 == 0i32;
            let mut v8: Rc<str> = if v5 {
                let mut v6: Rc<str> = Rc::<str>::from("ok");
                v6.clone()
            } else {
                let mut v7: Rc<str> = Rc::<str>::from("go");
                v7.clone()
            };
            (v0, v1) = (v2, v8.clone());
            continue;
        }
    }
}
fn method0() -> Rc<str> {
    let mut v0: i32 = 1000000i32;
    let mut v1: bool = v0 == 0i32;
    if v1 {
        let mut v2: Rc<str> = Rc::<str>::from("seed");
        v2.clone()
    } else {
        let mut v3: i32 = v0 % 2i32;
        let mut v4: bool = v3 == 0i32;
        let mut v7: Rc<str> = if v4 {
            let mut v5: Rc<str> = Rc::<str>::from("ok");
            v5.clone()
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("go");
            v6.clone()
        };
        method1(v0, v7.clone())
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = method0();
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: bool = v1 == 2i32;
    if v2 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
