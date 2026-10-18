#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Circle(i32),
    US0_Rect(i32, i32),
    US0_Empty,
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: US0 = US0::US0_Circle(v0);
    let mut v2: i32 = 3i32;
    let mut v3: i32 = 4i32;
    let mut v4: US0 = US0::US0_Rect(v2, v3);
    let mut v5: US0 = US0::US0_Empty;
    let mut v6: i32 = 2i32;
    let mut v7: US0 = US0::US0_Circle(v6);
    let mut v18: bool = match (&v1, &v7) {
        (US0::US0_Circle(v8), US0::US0_Circle(v9)) => {
            let mut v8: i32 = *v8;
            let mut v9: i32 = *v9;
            let mut v10: bool = v8 == v9;
            v10
        }
        (US0::US0_Empty, US0::US0_Empty) => {
            true
        }
        (US0::US0_Rect(v11, v12), US0::US0_Rect(v13, v14)) => {
            let mut v11: i32 = *v11;
            let mut v12: i32 = *v12;
            let mut v13: i32 = *v13;
            let mut v14: i32 = *v14;
            let mut v15: bool = v11 == v13;
            if v15 {
                let mut v16: bool = v12 == v14;
                v16
            } else {
                false
            }
        }
        _ => {
            false
        }
    };
    let mut v19: i32 = if v18 {
        100i32
    } else {
        0i32
    };
    let mut v28: i32 = match &v1 {
        US0::US0_Circle(v20) => {
            let mut v20: i32 = *v20;
            let mut v21: i32 = 3i32.wrapping_mul(v20);
            let mut v22: i32 = v21.wrapping_mul(v20);
            v22
        }
        US0::US0_Empty => {
            0i32
        }
        US0::US0_Rect(v23, v24) => {
            let mut v23: i32 = *v23;
            let mut v24: i32 = *v24;
            let mut v25: i32 = v23.wrapping_mul(v24);
            v25
        }
    };
    let mut v37: i32 = match &v4 {
        US0::US0_Circle(v29) => {
            let mut v29: i32 = *v29;
            let mut v30: i32 = 3i32.wrapping_mul(v29);
            let mut v31: i32 = v30.wrapping_mul(v29);
            v31
        }
        US0::US0_Empty => {
            0i32
        }
        US0::US0_Rect(v32, v33) => {
            let mut v32: i32 = *v32;
            let mut v33: i32 = *v33;
            let mut v34: i32 = v32.wrapping_mul(v33);
            v34
        }
    };
    let mut v38: i32 = v28.wrapping_add(v37);
    let mut v47: i32 = match &v5 {
        US0::US0_Circle(v39) => {
            let mut v39: i32 = *v39;
            let mut v40: i32 = 3i32.wrapping_mul(v39);
            let mut v41: i32 = v40.wrapping_mul(v39);
            v41
        }
        US0::US0_Empty => {
            0i32
        }
        US0::US0_Rect(v42, v43) => {
            let mut v42: i32 = *v42;
            let mut v43: i32 = *v43;
            let mut v44: i32 = v42.wrapping_mul(v43);
            v44
        }
    };
    let mut v48: i32 = v38.wrapping_add(v47);
    let mut v49: i32 = v48.wrapping_add(v19);
    v49
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
