#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method2(mut v0: i32, mut v1: Rc<str>, mut v2: Rc<str>) -> Rc<str> {
    loop {
        let mut v3: i32 = v0 - 1i32;
        let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v2.clone()));
        let mut v5: bool = v3 == 0i32;
        if v5 {
            return v4.clone();
        } else {
            let mut v6: i32 = v3 % 2i32;
            let mut v7: bool = v6 == 0i32;
            let mut v10: Rc<str> = if v7 {
                let mut v8: Rc<str> = Rc::<str>::from("ab");
                v8.clone()
            } else {
                let mut v9: Rc<str> = Rc::<str>::from("c");
                v9.clone()
            };
            (v0, v1, v2) = (v3, v4.clone(), v10.clone());
            continue;
        }
    }
}
fn method1(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    let mut v2: i32 = v0 - 1i32;
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(""), v1.clone()));
    let mut v4: bool = v2 == 0i32;
    if v4 {
        v3.clone()
    } else {
        let mut v5: i32 = v2 % 2i32;
        let mut v6: bool = v5 == 0i32;
        let mut v9: Rc<str> = if v6 {
            let mut v7: Rc<str> = Rc::<str>::from("ab");
            v7.clone()
        } else {
            let mut v8: Rc<str> = Rc::<str>::from("c");
            v8.clone()
        };
        method2(v2, v3.clone(), v9.clone())
    }
}
fn method0() -> Rc<str> {
    let mut v0: i32 = 4i32;
    let mut v1: bool = v0 == 0i32;
    if v1 {
        let mut v2: Rc<str> = Rc::<str>::from("");
        v2.clone()
    } else {
        let mut v3: i32 = v0 % 2i32;
        let mut v4: bool = v3 == 0i32;
        let mut v7: Rc<str> = if v4 {
            let mut v5: Rc<str> = Rc::<str>::from("ab");
            v5.clone()
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("c");
            v6.clone()
        };
        method1(v0, v7.clone())
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = method0();
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: bool = v1 == 6i32;
    if v2 {
        let mut v3: u8 = v0.clone().as_bytes()[0i32 as usize];
        let mut v4: bool = v3 == b'a';
        if v4 {
            let mut v5: u8 = v0.clone().as_bytes()[5i32 as usize];
            let mut v6: bool = v5 == b'c';
            if v6 {
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
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
