#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i8 = 100i8;
    let v1: i8 = v0.wrapping_add(v0);
    let v2: u8 = 200u8;
    let v3: u8 = 100u8;
    let v4: u8 = v2.wrapping_add(v3);
    let v5: i8 = -8i8;
    let v6: i8 = v5.wrapping_shr((1i32) as u32);
    let v7: u8 = v2.wrapping_shr((1i32) as u32);
    let v8: i16 = 20000i16;
    let v9: i16 = v8.wrapping_add(v8);
    let v10: u16 = 40000u16;
    let v11: u16 = v10.wrapping_add(v10);
    let v12: i32 = 7i32;
    let v13: i8 = (v12 as i8);
    let v14: i8 = 9i8;
    let v15: i32 = (v14 as i32);
    let v16: bool = v1 == -56i8;
    let v18: bool = if v16 {
        let v17: bool = v4 == 44u8;
        v17
    } else {
        false
    };
    let v20: bool = if v18 {
        let v19: bool = v6 == -4i8;
        v19
    } else {
        false
    };
    let v22: bool = if v20 {
        let v21: bool = v7 == 100u8;
        v21
    } else {
        false
    };
    let v24: bool = if v22 {
        let v23: bool = v9 == -25536i16;
        v23
    } else {
        false
    };
    let v26: bool = if v24 {
        let v25: bool = v11 == 14464u16;
        v25
    } else {
        false
    };
    let v28: bool = if v26 {
        let v27: bool = v13 == 7i8;
        v27
    } else {
        false
    };
    let v30: bool = if v28 {
        let v29: bool = v15 == 9i32;
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
