#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }; }
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn empty_middle_0(mut v0: Rc<str>) -> Rc<str> {
    let v1: Rc<str> = string_slice(&v0, 2i32 as i64, 1i32 as i64);
    v1
}
fn empty_end_1(mut v0: Rc<str>) -> Rc<str> {
    let v1: Rc<str> = string_slice(&v0, 5i32 as i64, 4i32 as i64);
    v1
}
fn empty_source_2(mut v0: Rc<str>) -> Rc<str> {
    let v1: Rc<str> = string_slice(&v0, 0i32 as i64, -1i32 as i64);
    v1
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("alpha"); } LIT.with(|lit| lit.clone()) };
    let v1: Rc<str> = empty_middle_0(v0.clone());
    let v2: Rc<str> = empty_end_1(v0);
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v4: Rc<str> = empty_source_2(v3);
    let v5: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v2.clone()));
    let v6: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) }));
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    let v8: i32 = (v1.len() as i32);
    let v9: bool = v8 == 0i32;
    if v9 {
        let v10: i32 = (v2.len() as i32);
        let v11: bool = v10 == 0i32;
        if v11 {
            let v12: i32 = (v4.len() as i32);
            let v13: bool = v12 == 0i32;
            if v13 {
                let v14: i32 = (v7.clone().len() as i32);
                let v15: bool = v14 == 2i32;
                if v15 {
                    let v16: u8 = v7.clone().as_bytes()[0i32 as usize];
                    let v17: bool = v16 == b'o';
                    if v17 {
                        let v18: u8 = v7.as_bytes()[1i32 as usize];
                        let v19: bool = v18 == b'k';
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
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
