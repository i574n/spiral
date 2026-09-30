#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    // A slice that starts or ends inside a code point fails like the C and Delphi backends (abort / Halt(3)).
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
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
    let mut v2: Rc<str> = method1(v0.clone());
    let mut v3: Rc<str> = Rc::<str>::from("");
    let mut v4: Rc<str> = method2(v3.clone());
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v2.clone()));
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), Rc::<str>::from("ok")));
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5.clone(), v6.clone()));
    let mut v8: i32 = (v1.clone().len() as i32);
    let mut v9: bool = v8 == 0i32;
    if v9 {
        let mut v10: i32 = (v2.clone().len() as i32);
        let mut v11: bool = v10 == 0i32;
        if v11 {
            let mut v12: i32 = (v4.clone().len() as i32);
            let mut v13: bool = v12 == 0i32;
            if v13 {
                let mut v14: i32 = (v7.clone().len() as i32);
                let mut v15: bool = v14 == 2i32;
                if v15 {
                    let mut v16: u8 = v7.clone().as_bytes()[0i32 as usize];
                    let mut v17: bool = v16 == b'o';
                    if v17 {
                        let mut v18: u8 = v7.clone().as_bytes()[1i32 as usize];
                        let mut v19: bool = v18 == b'k';
                        if v19 {
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
