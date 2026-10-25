#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_All(i32, Rc<str>, bool),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_All(v2, v3, v4) => {
            let v2: i32 = *v2;
            let v3: Rc<str> = v3.clone();
            let v4: bool = *v4;
            let v5: bool = v2 == 7i32;
            let v7: bool = if v5 {
                let v6: bool = &*v3 == "hi";
                v6
            } else {
                false
            };
            let v8: bool = v7 && v4;
            if v8 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_One(v1) => {
            let v1: i32 = *v1;
            v1
        }
    }
}
fn spiral_main() -> i32 {
    let v0: bool = true;
    let v1: i32 = 7i32;
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v3: bool = true;
    let v6: US0 = if v0 {
        US0::US0_All(v1, v2, v3)
    } else {
        US0::US0_One(1i32)
    };
    score_0(v6)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
