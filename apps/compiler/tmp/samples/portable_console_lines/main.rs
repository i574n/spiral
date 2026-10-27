#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hello"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v0);
    let v1: i32 = 42i32;
    println!("{}", v1);
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
    print!("{}", v2);
    std::io::Write::flush(&mut std::io::stdout()).unwrap();
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
    print!("{}", v3);
    std::io::Write::flush(&mut std::io::stdout()).unwrap();
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    println!("{}", v4);
    let v5: i64 = -7i64;
    println!("{}", v5);
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
