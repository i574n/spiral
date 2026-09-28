#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    match std::str::from_utf8(&bytes[from as usize..(to + 1) as usize]) { Ok(slice) => Rc::<str>::from(slice), Err(_) => std::process::abort() }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = string_slice(&v0.clone(), 0i32 as i64, 1i32 as i64);
    v1.clone()
}
fn method1(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = string_slice(&v0.clone(), 2i32 as i64, 3i32 as i64);
    v1.clone()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("éλ");
    let mut v1: Rc<str> = method0(v0.clone());
    let mut v2: Rc<str> = method1(v0.clone());
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v2.clone()));
    let mut v4: i32 = (v1.clone().len() as i32);
    let mut v5: bool = v4 == 2i32;
    if v5 {
        let mut v6: i32 = (v2.clone().len() as i32);
        let mut v7: bool = v6 == 2i32;
        if v7 {
            let mut v8: i32 = (v3.clone().len() as i32);
            let mut v9: bool = v8 == 4i32;
            if v9 {
                0i32
            } else {
                1i32
            }
        } else {
            2i32
        }
    } else {
        3i32
    }
}
fn main() {
    std::process::exit(spiral_main());
}
