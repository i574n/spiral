#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32) -> (Rc<str>, Rc<str>) {
    let v1: bool = v0 == 0i32;
    if v1 {
        let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
        (v2.clone(), v2)
    } else {
        let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
        (v3, v4)
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let (mut v1, mut v2): (Rc<str>, Rc<str>) = method0(v0);
    let v3: bool = &*v1 == "hi";
    let v5: bool = if v3 {
        let v4: bool = &*v2 == "yo";
        v4
    } else {
        false
    };
    if v5 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
