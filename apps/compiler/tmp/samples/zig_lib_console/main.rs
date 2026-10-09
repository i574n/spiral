#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 41i32;
    let mut v69: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
    println!("{}", v69);
    let mut v91: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v91);
    let mut v93: bool = true;
    let mut v115: Rc<str> = Rc::<str>::from(format!("{:?}", v93));
    println!("{}", v115);
    let mut v124: i32 = v0.wrapping_add(1i32);
    let mut v125: bool = v124 == 42i32;
    if v125 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
