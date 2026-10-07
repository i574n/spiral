#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 41i32;
    let mut v41: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
    println!("{}", v41);
    let mut v59: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v59);
    let mut v61: bool = true;
    let mut v79: Rc<str> = Rc::<str>::from(format!("{:?}", v61));
    println!("{}", v79);
    let mut v84: i32 = v0.wrapping_add(1i32);
    let mut v85: bool = v84 == 42i32;
    if v85 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
