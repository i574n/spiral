#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i64 = 5000000000i64;
    let mut v1: i64 = -4i64;
    let mut v2: i64 = v0.wrapping_div(v1);
    let mut v3: i64 = 1000000i64;
    let mut v4: i64 = v3.wrapping_mul(v3);
    let mut v5: i64 = -8i64;
    let mut v6: i64 = v5.wrapping_shr((1i32) as u32);
    let mut v7: i32 = 7i32;
    let mut v8: i64 = (v7 as i64);
    let mut v9: i64 = 9i64;
    let mut v10: i32 = (v9 as i32);
    let mut v11: u64 = 4294967296u64;
    let mut v12: u64 = v11.wrapping_add(1u64);
    let mut v13: u64 = v11.wrapping_shr((1i32) as u32);
    let mut v14: u64 = (v7 as u64);
    let mut v15: bool = v2 == -1250000000i64;
    let mut v17: bool = if v15 {
        let mut v16: bool = v4 == 1000000000000i64;
        v16
    } else {
        false
    };
    let mut v19: bool = if v17 {
        let mut v18: bool = v6 == -4i64;
        v18
    } else {
        false
    };
    let mut v21: bool = if v19 {
        let mut v20: bool = v8 == 7i64;
        v20
    } else {
        false
    };
    let mut v23: bool = if v21 {
        let mut v22: bool = v10 == 9i32;
        v22
    } else {
        false
    };
    let mut v25: bool = if v23 {
        let mut v24: bool = v12 == 4294967297u64;
        v24
    } else {
        false
    };
    let mut v27: bool = if v25 {
        let mut v26: bool = v13 == 2147483648u64;
        v26
    } else {
        false
    };
    let mut v29: bool = if v27 {
        let mut v28: bool = v14 == 7u64;
        v28
    } else {
        false
    };
    if v29 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
