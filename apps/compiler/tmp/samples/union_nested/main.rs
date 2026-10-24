#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US1 {
    US1_A(i32),
    US1_B(i32),
}
#[derive(Clone)]
enum US0 {
    US0_Wrap(US1),
    US0_Other(i32),
}
fn score_inner_1(mut v0: US1) -> i32 {
    match &v0 {
        US1::US1_A(v1) => {
            let v1: i32 = *v1;
            v1
        }
        US1::US1_B(v2) => {
            let v2: i32 = *v2;
            let v3: i32 = v2.wrapping_neg();
            v3
        }
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Other(v3) => {
            let v3: i32 = *v3;
            v3
        }
        US0::US0_Wrap(v1) => {
            let v1: US1 = v1.clone();
            score_inner_1(v1)
        }
    }
}
fn spiral_main() -> i32 {
    let v0: bool = true;
    let v4: US0 = if v0 {
        let v1: US1 = US1::US1_A(7i32);
        US0::US0_Wrap(v1)
    } else {
        US0::US0_Other(1i32)
    };
    let v8: US0 = if v0 {
        US0::US0_Other(4i32)
    } else {
        let v6: US1 = US1::US1_B(2i32);
        US0::US0_Wrap(v6)
    };
    let v9: i32 = score_0(v4);
    let v10: bool = v9 == 7i32;
    let v13: bool = if v10 {
        let v11: i32 = score_0(v8);
        let v12: bool = v11 == 4i32;
        v12
    } else {
        false
    };
    if v13 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
