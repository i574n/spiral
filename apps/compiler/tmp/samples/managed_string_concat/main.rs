#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn choose_left_0(mut v0: bool) -> Rc<str> {
    if v0 {
        let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spi"); } LIT.with(|lit| lit.clone()) };
        v1.clone()
    } else {
        let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("bad"); } LIT.with(|lit| lit.clone()) };
        v2.clone()
    }
}
fn choose_right_1(mut v0: bool) -> Rc<str> {
    if v0 {
        let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("bad"); } LIT.with(|lit| lit.clone()) };
        v1.clone()
    } else {
        let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ral"); } LIT.with(|lit| lit.clone()) };
        v2.clone()
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v1: Rc<str> = choose_left_0(v0);
    let mut v2: bool = false;
    let mut v3: Rc<str> = choose_right_1(v2);
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v3.clone()));
    let mut v5: i32 = (v4.clone().len() as i32);
    let mut v6: bool = v5 == 6i32;
    if v6 {
        let mut v7: u8 = v4.clone().as_bytes()[0i32 as usize];
        let mut v8: bool = v7 == b's';
        if v8 {
            let mut v9: u8 = v4.clone().as_bytes()[5i32 as usize];
            let mut v10: bool = v9 == b'l';
            if v10 {
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
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
