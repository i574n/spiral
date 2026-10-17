#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("éx"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v5: bool = v0.clone() < v0.clone();
    if v5 {
        1i32
    } else {
        let mut v6: bool = v0.clone() < v1.clone();
        let mut v8: bool = if v6 {
            let mut v7: bool = v1.clone() < v2.clone();
            v7
        } else {
            false
        };
        let mut v10: bool = if v8 {
            let mut v9: bool = v2.clone() < v3.clone();
            v9
        } else {
            false
        };
        let mut v12: bool = if v10 {
            let mut v11: bool = v4.clone() < v0.clone();
            v11
        } else {
            false
        };
        let mut v14: bool = if v12 {
            let mut v13: bool = v0.clone() <= v0.clone();
            v13
        } else {
            false
        };
        let mut v16: bool = if v14 {
            let mut v15: bool = v0.clone() >= v0.clone();
            v15
        } else {
            false
        };
        let mut v18: bool = if v16 {
            let mut v17: bool = v3.clone() > v2.clone();
            v17
        } else {
            false
        };
        let mut v20: bool = if v18 {
            let mut v19: bool = v1.clone() >= v0.clone();
            v19
        } else {
            false
        };
        if v20 {
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
