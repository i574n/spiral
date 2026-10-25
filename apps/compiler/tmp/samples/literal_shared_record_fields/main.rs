#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn run_0(mut v0: i32, mut v1: Rc<str>, mut v2: Rc<str>, mut v3: i32) -> (Rc<str>, Rc<str>, i32) {
    let mut v4: bool = v0 <= 0i32;
    let (mut v11, mut v12, mut v13): (Rc<str>, Rc<str>, i32) = if v4 {
        (v1.clone(), v2.clone(), v3)
    } else {
        let mut v5: i32 = v0.wrapping_sub(1i32);
        let mut v6: i32 = v3.wrapping_add(1i32);
        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("y"); } LIT.with(|lit| lit.clone()) };
        let (mut v8, mut v9, mut v10): (Rc<str>, Rc<str>, i32) = run_0(v5, v2.clone(), v7.clone(), v6);
        (v8.clone(), v9.clone(), v10)
    };
    (v11.clone(), v12.clone(), v13)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 5i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: i32 = 0i32;
    let (mut v3, mut v4, mut v5): (Rc<str>, Rc<str>, i32) = run_0(v0, v1.clone(), v1.clone(), v2);
    let mut v6: i32 = v5.wrapping_sub(5i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
