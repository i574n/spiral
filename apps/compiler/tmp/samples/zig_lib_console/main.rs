#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 41i32;
    let mut v33: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
    println!("{}", v33);
    let mut v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v52);
    let mut v54: bool = true;
    let mut v73: Rc<str> = Rc::<str>::from(format!("{:?}", v54));
    println!("{}", v73);
    let mut v79: i32 = v0.wrapping_add(1i32);
    let mut v80: bool = v79 == 42i32;
    if v80 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
