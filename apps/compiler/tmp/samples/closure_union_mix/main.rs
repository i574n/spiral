#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_Both(i32, Rc<str>),
}
fn f_c0(mut v0: i32, mut v1: Rc<str>) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v2: i32| -> US0 {
        let v3: bool = v2 == 0i32;
        if v3 {
            US0::US0_One(0i32)
        } else {
            US0::US0_Both(v0, v1.clone())
        }
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<dyn Fn(i32) -> US0> = f_c0(v0, v1);
    let v3: US0 = v2(1i32);
    match &v3 {
        US0::US0_Both(v5, v6) => {
            let v5: i32 = *v5;
            let v6: Rc<str> = v6.clone();
            let v7: bool = v5 == 3i32;
            let v9: bool = if v7 {
                let v8: bool = &*v6 == "hi";
                v8
            } else {
                false
            };
            if v9 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_One(v4) => {
            let v4: i32 = *v4;
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
