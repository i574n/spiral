#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i8 = 100i8;
    let mut v1: i8 = 3i8;
    let mut v2: i8 = v0.wrapping_mul(v1);
    let mut v3: i8 = -8i8;
    let mut v4: i8 = 2i8;
    let mut v5: i8 = v3.wrapping_div(v4);
    let mut v6: i8 = v3.wrapping_rem(v1);
    let mut v7: i8 = v1.wrapping_neg();
    let mut v8: i8 = v0.wrapping_shl((1i32) as u32);
    let mut v9: u8 = 200u8;
    let mut v10: u8 = 3u8;
    let mut v11: u8 = v9.wrapping_div(v10);
    let mut v12: u8 = v9.wrapping_rem(v10);
    let mut v13: u8 = 15u8;
    let mut v14: u8 = v9 & v13;
    let mut v15: u8 = v9 | v13;
    let mut v16: u8 = v9 ^ v13;
    let mut v17: u8 = !v13;
    let mut v18: i16 = 20000i16;
    let mut v19: i16 = 7i16;
    let mut v20: i16 = v18.wrapping_div(v19);
    let mut v21: i16 = v18.wrapping_rem(v19);
    let mut v22: i16 = v18.wrapping_neg();
    let mut v23: u16 = 40000u16;
    let mut v24: u16 = v23.wrapping_shl((1i32) as u32);
    let mut v25: bool = v2 == 44i8;
    let mut v27: bool = if v25 {
        let mut v26: bool = v5 == -4i8;
        v26
    } else {
        false
    };
    let mut v29: bool = if v27 {
        let mut v28: bool = v6 == -2i8;
        v28
    } else {
        false
    };
    let mut v31: bool = if v29 {
        let mut v30: bool = v7 == -3i8;
        v30
    } else {
        false
    };
    let mut v33: bool = if v31 {
        let mut v32: bool = v8 == -56i8;
        v32
    } else {
        false
    };
    let mut v35: bool = if v33 {
        let mut v34: bool = v11 == 66u8;
        v34
    } else {
        false
    };
    let mut v37: bool = if v35 {
        let mut v36: bool = v12 == 2u8;
        v36
    } else {
        false
    };
    let mut v39: bool = if v37 {
        let mut v38: bool = v14 == 8u8;
        v38
    } else {
        false
    };
    let mut v41: bool = if v39 {
        let mut v40: bool = v15 == 207u8;
        v40
    } else {
        false
    };
    let mut v43: bool = if v41 {
        let mut v42: bool = v16 == 199u8;
        v42
    } else {
        false
    };
    let mut v45: bool = if v43 {
        let mut v44: bool = v17 == 240u8;
        v44
    } else {
        false
    };
    let mut v47: bool = if v45 {
        let mut v46: bool = v20 == 2857i16;
        v46
    } else {
        false
    };
    let mut v49: bool = if v47 {
        let mut v48: bool = v21 == 1i16;
        v48
    } else {
        false
    };
    let mut v51: bool = if v49 {
        let mut v50: bool = v22 == -20000i16;
        v50
    } else {
        false
    };
    let mut v53: bool = if v51 {
        let mut v52: bool = v24 == 14464u16;
        v52
    } else {
        false
    };
    if v53 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
