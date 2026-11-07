#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i64 = 5000000000i64;
    let v1: i64 = -4i64;
    let v2: i64 = v0.wrapping_div(v1);
    let v3: i64 = 1000000i64;
    let v4: i64 = v3.wrapping_mul(v3);
    let v5: i64 = -8i64;
    let v6: i64 = v5.wrapping_shr((1i32) as u32);
    let v7: i32 = 7i32;
    let v8: i64 = (v7 as i64);
    let v9: i64 = 9i64;
    let v10: i32 = (v9 as i32);
    let v11: u64 = 4294967296u64;
    let v12: u64 = v11.wrapping_add(1u64);
    let v13: u64 = v11.wrapping_shr((1i32) as u32);
    let v14: u64 = (v7 as u64);
    let v15: bool = v2 == -1250000000i64;
    let v17: bool = if v15 {
        let v16: bool = v4 == 1000000000000i64;
        v16
    } else {
        false
    };
    let v19: bool = if v17 {
        let v18: bool = v6 == -4i64;
        v18
    } else {
        false
    };
    let v21: bool = if v19 {
        let v20: bool = v8 == 7i64;
        v20
    } else {
        false
    };
    let v23: bool = if v21 {
        let v22: bool = v10 == 9i32;
        v22
    } else {
        false
    };
    let v25: bool = if v23 {
        let v24: bool = v12 == 4294967297u64;
        v24
    } else {
        false
    };
    let v27: bool = if v25 {
        let v26: bool = v13 == 2147483648u64;
        v26
    } else {
        false
    };
    let v29: bool = if v27 {
        let v28: bool = v14 == 7u64;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
