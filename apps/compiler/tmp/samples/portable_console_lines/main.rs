#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hello"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v9);
    let mut v12: i32 = 42i32;
    println!("{}", v12);
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
    { use std::io::Write; print!("{}", v21); std::io::stdout().flush().unwrap(); };
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
    { use std::io::Write; print!("{}", v28); std::io::stdout().flush().unwrap(); };
    let mut v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    println!("{}", v36);
    let mut v38: i64 = -7i64;
    println!("{}", v38);
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
