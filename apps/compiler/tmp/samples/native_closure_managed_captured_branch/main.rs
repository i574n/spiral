#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn left_c0(mut v0: Rc<str>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let v2: i32 = (v0.clone().len() as i32);
        let v3: i32 = v2.wrapping_add(v1);
        v3
    })
}
fn right_c1(mut v0: Rc<str>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let v2: i32 = (v0.clone().len() as i32);
        let v3: i32 = v2.wrapping_add(v1);
        let v4: i32 = v3.wrapping_sub(1i32);
        v4
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(39i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("abc"); } LIT.with(|lit| lit.clone()) };
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wxyz"); } LIT.with(|lit| lit.clone()) };
    let v2: bool = true;
    let v5: Rc<dyn Fn(i32) -> i32> = if v2 {
        left_c0(v0)
    } else {
        right_c1(v1)
    };
    method0(v5)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
