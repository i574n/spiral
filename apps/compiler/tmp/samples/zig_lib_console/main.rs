#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 41i32;
    let v1: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
    println!("{}", v1);
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v2);
    let v3: bool = true;
    let v4: Rc<str> = Rc::<str>::from(format!("{:?}", v3));
    println!("{}", v4);
    let v5: i32 = v0.wrapping_add(1i32);
    let v6: bool = v5 == 42i32;
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
