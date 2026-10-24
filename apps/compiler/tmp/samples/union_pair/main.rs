#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_Both(i32, i32),
}
fn sum_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Both(v2, v3) => {
            let v2: i32 = *v2;
            let v3: i32 = *v3;
            let v4: i32 = v2.wrapping_mul(10i32);
            let v5: i32 = v4.wrapping_add(v3);
            v5
        }
        US0::US0_One(v1) => {
            let v1: i32 = *v1;
            v1
        }
    }
}
fn spiral_main() -> i32 {
    let v0: bool = true;
    let v3: US0 = if v0 {
        US0::US0_Both(3i32, 4i32)
    } else {
        US0::US0_One(1i32)
    };
    let v6: US0 = if v0 {
        US0::US0_One(5i32)
    } else {
        US0::US0_Both(1i32, 1i32)
    };
    let v7: i32 = sum_0(v3);
    let v8: bool = v7 == 34i32;
    let v11: bool = if v8 {
        let v9: i32 = sum_0(v6);
        let v10: bool = v9 == 5i32;
        v10
    } else {
        false
    };
    if v11 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
