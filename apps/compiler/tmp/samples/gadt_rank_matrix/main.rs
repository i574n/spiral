#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_RawA(i32),
}
#[derive(Clone)]
enum US1 {
    US1_DecidedA(i32, bool),
}
#[derive(Clone)]
enum US2 {
    US2_RawB(i32),
}
#[derive(Clone)]
enum US3 {
    US3_DecidedB(bool, i32),
}
#[derive(Clone)]
enum US4 {
    US4_RawC(i32),
}
#[derive(Clone)]
enum US5 {
    US5_DecidedC(i32, bool),
}
#[derive(Clone)]
enum US6 {
    US6_FinalC(bool),
}
fn decide_a_0(mut v0: US0) -> US1 {
    match &v0 {
        US0::US0_RawA(v1) => {
            let v1: i32 = *v1;
            US1::US1_DecidedA(v1, true)
        }
    }
}
fn decide_b_1(mut v0: US2) -> US3 {
    match &v0 {
        US2::US2_RawB(v1) => {
            let v1: i32 = *v1;
            US3::US3_DecidedB(true, v1)
        }
    }
}
fn decide_c_2(mut v0: US4) -> US5 {
    match &v0 {
        US4::US4_RawC(v1) => {
            let v1: i32 = *v1;
            US5::US5_DecidedC(v1, true)
        }
    }
}
fn finalize_c_3(mut v0: US5) -> US6 {
    match &v0 {
        US5::US5_DecidedC(v1, v2) => {
            let v1: i32 = *v1;
            let v2: bool = *v2;
            US6::US6_FinalC(v2)
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: US0 = US0::US0_RawA(v0);
    let v2: US1 = decide_a_0(v1);
    let v3: i32 = 9i32;
    let v4: US2 = US2::US2_RawB(v3);
    let v5: US3 = decide_b_1(v4);
    let v6: i32 = 11i32;
    let v7: US4 = US4::US4_RawC(v6);
    let v8: US5 = decide_c_2(v7);
    let v9: US6 = finalize_c_3(v8);
    let v12: bool = match &v2 {
        US1::US1_DecidedA(v10, v11) => {
            let v10: i32 = *v10;
            let v11: bool = *v11;
            v11
        }
    };
    let v15: bool = match &v5 {
        US3::US3_DecidedB(v13, v14) => {
            let v13: bool = *v13;
            let v14: i32 = *v14;
            v13
        }
    };
    let v17: bool = match &v9 {
        US6::US6_FinalC(v16) => {
            let v16: bool = *v16;
            v16
        }
    };
    let v18: bool = v12 && v15;
    let v19: bool = v18 && v17;
    if v19 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
