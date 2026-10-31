#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let v2: i32 = v0.wrapping_sub(1i32);
        let v3: bool = v2 == 0i32;
        if v3 {
            return v1.clone();
        } else {
            let v4: i32 = v2.wrapping_rem(2i32);
            let v5: bool = v4 == 0i32;
            let v8: Rc<str> = if v5 {
                let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
                v6.clone()
            } else {
                let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("go"); } LIT.with(|lit| lit.clone()) };
                v7.clone()
            };
            (v0, v1) = (v2, v8.clone());
            continue;
        }
    }
}
fn method0() -> Rc<str> {
    let v0: i32 = 1000000i32;
    let v1: bool = v0 == 0i32;
    if v1 {
        let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("seed"); } LIT.with(|lit| lit.clone()) };
        v2
    } else {
        let v3: i32 = v0.wrapping_rem(2i32);
        let v4: bool = v3 == 0i32;
        let v7: Rc<str> = if v4 {
            let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
            v5
        } else {
            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("go"); } LIT.with(|lit| lit.clone()) };
            v6
        };
        method1(v0, v7)
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = method0();
    let v1: i32 = (v0.len() as i32);
    let v2: bool = v1 == 2i32;
    if v2 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
