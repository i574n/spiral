#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: std::rc::Rc<str> = std::rc::Rc::<str>::from("abc"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: ::std::rc::Rc<str> = ::std::rc::Rc::<str>::from("de"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = crate::Rc::<str>::from("fgh");
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ijkl"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("mnopq"); } LIT.with(|lit| lit.clone()) };
    let mut v6: Rc<str> = None::<std::rc::Rc<str>>.unwrap_or_else(|| { thread_local!{ static LIT: std::rc::Rc<str> = std::rc::Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) });
    let mut v7: i32 = v1.len() as i32;
    let mut v8: i32 = v2.len() as i32;
    let mut v9: i32 = v7 + v8;
    let mut v10: i32 = v3.len() as i32;
    let mut v11: i32 = v9 + v10;
    let mut v12: i32 = v4.len() as i32;
    let mut v13: i32 = v11 + v12;
    let mut v14: i32 = v5.len() as i32;
    let mut v15: i32 = v13 + v14;
    let mut v16: i32 = v6.len() as i32;
    let mut v17: i32 = v15 + v16;
    let mut v18: i32 = v17 + v0;
    v18
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
