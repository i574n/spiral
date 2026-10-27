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
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = (v0.clone().len() as i32);
    let v2: u8 = v0.clone().as_bytes()[0i32 as usize];
    let v3: u8 = v0.clone().as_bytes()[1i32 as usize];
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("x"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0.clone(), v4.clone()));
    let v6: i32 = (v5.clone().len() as i32);
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
    let v8: u8 = v7.clone().as_bytes()[0i32 as usize];
    let v9: Rc<str> = string_slice(&v7.clone(), 0i32 as i64, 0i32 as i64);
    let v10: i32 = (v9.clone().len() as i32);
    let v11: Rc<str> = string_slice(&v7.clone(), 1i32 as i64, 0i32 as i64);
    let v12: i32 = (v11.clone().len() as i32);
    let v13: Rc<str> = string_slice(&v0.clone(), 0i32 as i64, 1i32 as i64);
    let v14: i32 = (v13.clone().len() as i32);
    let v15: bool = v2 == v3;
    if v15 {
        1i32
    } else {
        let v16: bool = v1 == 2i32;
        let v18: bool = if v16 {
            let v17: bool = v8 == b'a';
            v17
        } else {
            false
        };
        let v20: bool = if v18 {
            let v19: bool = v6 == 3i32;
            v19
        } else {
            false
        };
        let v22: bool = if v20 {
            let v21: bool = v10 == 1i32;
            v21
        } else {
            false
        };
        let v24: bool = if v22 {
            let v23: bool = v12 == 0i32;
            v23
        } else {
            false
        };
        let v26: bool = if v24 {
            let v25: bool = v14 == 2i32;
            v25
        } else {
            false
        };
        if v26 {
            0i32
        } else {
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
