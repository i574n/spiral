#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn f_c0(mut v0: i64, mut v1: Rc<str>) -> Rc<dyn Fn(i32) -> (i64, Rc<str>)> {
    Rc::new(move |mut v2: i32| -> (i64, Rc<str>) {
        let v3: bool = v2 == 0i32;
        if v3 {
            let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
            (0i64, v4.clone())
        } else {
            (v0, v1.clone())
        }
    })
}
fn spiral_main() -> i32 {
    let v0: i64 = 5000000000i64;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<dyn Fn(i32) -> (i64, Rc<str>)> = f_c0(v0, v1.clone());
    let (mut v3, mut v4): (i64, Rc<str>) = v2(1i32);
    let v5: bool = v3 == 5000000000i64;
    let v7: bool = if v5 {
        let v6: bool = &*v4 == "hi";
        v6
    } else {
        false
    };
    if v7 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
