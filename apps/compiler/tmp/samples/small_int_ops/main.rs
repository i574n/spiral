#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i8 = 100i8;
    let v1: i8 = 3i8;
    let v2: i8 = v0.wrapping_mul(v1);
    let v3: i8 = -8i8;
    let v4: i8 = 2i8;
    let v5: i8 = v3.wrapping_div(v4);
    let v6: i8 = v3.wrapping_rem(v1);
    let v7: i8 = v1.wrapping_neg();
    let v8: i8 = v0.wrapping_shl((1i32) as u32);
    let v9: u8 = 200u8;
    let v10: u8 = 3u8;
    let v11: u8 = v9.wrapping_div(v10);
    let v12: u8 = v9.wrapping_rem(v10);
    let v13: u8 = 15u8;
    let v14: u8 = v9 & v13;
    let v15: u8 = v9 | v13;
    let v16: u8 = v9 ^ v13;
    let v17: u8 = !v13;
    let v18: i16 = 20000i16;
    let v19: i16 = 7i16;
    let v20: i16 = v18.wrapping_div(v19);
    let v21: i16 = v18.wrapping_rem(v19);
    let v22: i16 = v18.wrapping_neg();
    let v23: u16 = 40000u16;
    let v24: u16 = v23.wrapping_shl((1i32) as u32);
    let v25: bool = v2 == 44i8;
    let v27: bool = if v25 {
        let v26: bool = v5 == -4i8;
        v26
    } else {
        false
    };
    let v29: bool = if v27 {
        let v28: bool = v6 == -2i8;
        v28
    } else {
        false
    };
    let v31: bool = if v29 {
        let v30: bool = v7 == -3i8;
        v30
    } else {
        false
    };
    let v33: bool = if v31 {
        let v32: bool = v8 == -56i8;
        v32
    } else {
        false
    };
    let v35: bool = if v33 {
        let v34: bool = v11 == 66u8;
        v34
    } else {
        false
    };
    let v37: bool = if v35 {
        let v36: bool = v12 == 2u8;
        v36
    } else {
        false
    };
    let v39: bool = if v37 {
        let v38: bool = v14 == 8u8;
        v38
    } else {
        false
    };
    let v41: bool = if v39 {
        let v40: bool = v15 == 207u8;
        v40
    } else {
        false
    };
    let v43: bool = if v41 {
        let v42: bool = v16 == 199u8;
        v42
    } else {
        false
    };
    let v45: bool = if v43 {
        let v44: bool = v17 == 240u8;
        v44
    } else {
        false
    };
    let v47: bool = if v45 {
        let v46: bool = v20 == 2857i16;
        v46
    } else {
        false
    };
    let v49: bool = if v47 {
        let v48: bool = v21 == 1i16;
        v48
    } else {
        false
    };
    let v51: bool = if v49 {
        let v50: bool = v22 == -20000i16;
        v50
    } else {
        false
    };
    let v53: bool = if v51 {
        let v52: bool = v24 == 14464u16;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
