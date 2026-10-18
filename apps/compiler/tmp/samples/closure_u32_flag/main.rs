#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn f_c0(mut v0: u32, mut v1: Rc<str>, mut v2: bool) -> Rc<dyn Fn(i32) -> (u32, Rc<str>, bool)> {
    Rc::new(move |mut v3: i32| -> (u32, Rc<str>, bool) {
        let mut v4: bool = v3 == 0i32;
        if v4 {
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
            (0u32, v5.clone(), false)
        } else {
            (v0, v1.clone(), v2)
        }
    })
}
fn spiral_main() -> i32 {
    let mut v0: u32 = 4000000000u32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: bool = true;
    let mut v3: Rc<dyn Fn(i32) -> (u32, Rc<str>, bool)> = f_c0(v0, v1.clone(), v2);
    let (mut v4, mut v5, mut v6): (u32, Rc<str>, bool) = v3(1i32);
    let mut v7: bool = v4 == 4000000000u32;
    let mut v9: bool = if v7 {
        let mut v8: bool = v5.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v8
    } else {
        false
    };
    let mut v10: bool = v9 && v6;
    if v10 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
