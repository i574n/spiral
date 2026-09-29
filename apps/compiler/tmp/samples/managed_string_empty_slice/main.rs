#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
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
    let mut v1: Rc<str> = string_slice(&v0.clone(), 2i32 as i64, 1i32 as i64);
    v1.clone()
}
fn method1(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = string_slice(&v0.clone(), 5i32 as i64, 4i32 as i64);
    v1.clone()
}
fn method2(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = string_slice(&v0.clone(), 0i32 as i64, -1i32 as i64);
    v1.clone()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("alpha");
    let mut v1: Rc<str> = method0(v0.clone());
    let mut v2: Rc<str> = method0(v0.clone());
    let mut v3: Rc<str> = method0(v0.clone());
    let mut v4: Rc<str> = method1(v0.clone());
    let mut v5: Rc<str> = Rc::<str>::from("");
    let mut v6: Rc<str> = method2(v5.clone());
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), v4.clone()));
    let mut v8: Rc<str> = Rc::<str>::from(format!("{}{}", v6.clone(), Rc::<str>::from("ok")));
    let mut v9: Rc<str> = Rc::<str>::from(format!("{}{}", v7.clone(), v8.clone()));
    let mut v10: i32 = (v3.clone().len() as i32);
    let mut v11: bool = v10 == 0i32;
    if v11 {
        let mut v12: i32 = (v4.clone().len() as i32);
        let mut v13: bool = v12 == 0i32;
        if v13 {
            let mut v14: i32 = (v6.clone().len() as i32);
            let mut v15: bool = v14 == 0i32;
            if v15 {
                let mut v16: i32 = (v9.clone().len() as i32);
                let mut v17: bool = v16 == 2i32;
                if v17 {
                    let mut v18: u8 = v9.clone().as_bytes()[0i32 as usize];
                    let mut v19: bool = v18 == b'o';
                    if v19 {
                        let mut v20: u8 = v9.clone().as_bytes()[1i32 as usize];
                        let mut v21: bool = v20 == b'k';
                        if v21 {
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
            } else {
                4i32
            }
        } else {
            5i32
        }
    } else {
        6i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
