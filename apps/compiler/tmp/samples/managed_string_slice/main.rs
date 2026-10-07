#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }; }
    // A slice that starts or ends inside a code point fails like the C and Delphi backends (abort / Halt(3)).
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = string_slice(&v0.clone(), 1i32 as i64, 3i32 as i64);
    v1.clone()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("alpha"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = method0(v0.clone());
    let mut v2: i32 = (v1.clone().len() as i32);
    let mut v3: bool = v2 == 3i32;
    if v3 {
        let mut v4: u8 = v1.clone().as_bytes()[0i32 as usize];
        let mut v5: bool = v4 == b'l';
        if v5 {
            let mut v6: u8 = v1.clone().as_bytes()[2i32 as usize];
            let mut v7: bool = v6 == b'h';
            if v7 {
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
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
