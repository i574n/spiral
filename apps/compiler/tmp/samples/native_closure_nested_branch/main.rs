#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: Rc<str>, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let mut v3: bool = v2 > 0i32;
        if v3 {
            let mut v4: i32 = (v0.clone().len() as i32);
            let mut v5: i32 = v4 + v1;
            let mut v6: i32 = v5 + v2;
            v6
        } else {
            0i32
        }
    })
}
fn closure1(mut v0: Rc<str>, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let mut v3: bool = v2 > 0i32;
        if v3 {
            let mut v4: i32 = (v0.clone().len() as i32);
            let mut v5: i32 = v4 + v1;
            let mut v6: i32 = v5 + v2;
            let mut v7: i32 = v6 - 1i32;
            v7
        } else {
            -1i32
        }
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(37i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("abc");
    let mut v1: Rc<str> = Rc::<str>::from("wxyz");
    let mut v2: i32 = 2i32;
    let mut v3: i32 = 2i32;
    let mut v4: bool = true;
    let mut v7: Rc<dyn Fn(i32) -> i32> = if v4 {
        closure0(v0.clone(), v2)
    } else {
        closure1(v1.clone(), v3)
    };
    method0(v7.clone())
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
