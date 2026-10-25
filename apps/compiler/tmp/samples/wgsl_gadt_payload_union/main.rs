#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US1 {
    US1_Living(i32, i32),
}
#[derive(Clone)]
enum US2 {
    US2_Fallen(i32),
}
#[derive(Clone)]
enum US0 {
    US0_Survived(US1),
    US0_Slain(US2),
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 60i32;
    let mut v1: bool = v0 > 0i32;
    let mut v6: US0 = if v1 {
        let mut v2: US1 = US1::US1_Living(v0, 100i32);
        US0::US0_Survived(v2.clone())
    } else {
        let mut v4: US2 = US2::US2_Fallen(100i32);
        US0::US0_Slain(v4.clone())
    };
    match &v6 {
        US0::US0_Slain(v13) => {
            let mut v13: US2 = v13.clone();
            2i32
        }
        US0::US0_Survived(v7) => {
            let mut v7: US1 = v7.clone();
            match &v7 {
                US1::US1_Living(v8, v9) => {
                    let mut v8: i32 = *v8;
                    let mut v9: i32 = *v9;
                    let mut v10: bool = v8 == 60i32;
                    if v10 {
                        0i32
                    } else {
                        1i32
                    }
                }
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
