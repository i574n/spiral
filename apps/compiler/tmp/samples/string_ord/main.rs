#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("éx"); } LIT.with(|lit| lit.clone()) };
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v5: bool = &*v0 < &*v0;
    if v5 {
        1i32
    } else {
        let v6: bool = &*v0 < &*v1;
        let v8: bool = if v6 {
            let v7: bool = &*v1 < &*v2;
            v7
        } else {
            false
        };
        let v10: bool = if v8 {
            let v9: bool = &*v2 < &*v3;
            v9
        } else {
            false
        };
        let v12: bool = if v10 {
            let v11: bool = &*v4 < &*v0;
            v11
        } else {
            false
        };
        let v14: bool = if v12 {
            let v13: bool = &*v0 <= &*v0;
            v13
        } else {
            false
        };
        let v16: bool = if v14 {
            let v15: bool = &*v0 >= &*v0;
            v15
        } else {
            false
        };
        let v18: bool = if v16 {
            let v17: bool = &*v3 > &*v2;
            v17
        } else {
            false
        };
        let v20: bool = if v18 {
            let v19: bool = &*v1 >= &*v0;
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
