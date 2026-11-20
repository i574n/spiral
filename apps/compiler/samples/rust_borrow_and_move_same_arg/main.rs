#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn pick_0(mut v0: &Rc<str>, mut v1: Rc<str>) -> Rc<str> {
    let v2: i32 = (v0.clone().len() as i32);
    let v3: bool = v2 > 2i32;
    if v3 {
        v1
    } else {
        let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v4
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("abc"); } LIT.with(|lit| lit.clone()) };
    let v1: Rc<str> = pick_0(&v0, v0.clone());
    let v2: i32 = (v1.len() as i32);
    let v3: i32 = v2.wrapping_sub(3i32);
    v3
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
