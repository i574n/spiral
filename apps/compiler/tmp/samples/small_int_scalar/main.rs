#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i8 = 100i8;
    let mut v1: i8 = v0.wrapping_add(v0);
    let mut v2: u8 = 200u8;
    let mut v3: u8 = 100u8;
    let mut v4: u8 = v2.wrapping_add(v3);
    let mut v5: i8 = -8i8;
    let mut v6: i8 = v5.wrapping_shr((1i32) as u32);
    let mut v7: u8 = v2.wrapping_shr((1i32) as u32);
    let mut v8: i16 = 20000i16;
    let mut v9: i16 = v8.wrapping_add(v8);
    let mut v10: u16 = 40000u16;
    let mut v11: u16 = v10.wrapping_add(v10);
    let mut v12: i32 = 7i32;
    let mut v13: i8 = (v12 as i8);
    let mut v14: i8 = 9i8;
    let mut v15: i32 = (v14 as i32);
    let mut v16: bool = v1 == -56i8;
    let mut v18: bool = if v16 {
        let mut v17: bool = v4 == 44u8;
        v17
    } else {
        false
    };
    let mut v20: bool = if v18 {
        let mut v19: bool = v6 == -4i8;
        v19
    } else {
        false
    };
    let mut v22: bool = if v20 {
        let mut v21: bool = v7 == 100u8;
        v21
    } else {
        false
    };
    let mut v24: bool = if v22 {
        let mut v23: bool = v9 == -25536i16;
        v23
    } else {
        false
    };
    let mut v26: bool = if v24 {
        let mut v25: bool = v11 == 14464u16;
        v25
    } else {
        false
    };
    let mut v28: bool = if v26 {
        let mut v27: bool = v13 == 7i8;
        v27
    } else {
        false
    };
    let mut v30: bool = if v28 {
        let mut v29: bool = v15 == 9i32;
        v29
    } else {
        false
    };
    if v30 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
