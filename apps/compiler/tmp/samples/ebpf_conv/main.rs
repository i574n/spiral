#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = -2147483648i32;
    let v1: u32 = 4294967295u32;
    let v2: i32 = -1i32;
    let v3: f32 = 0.0f32;
    let v4: f32 = 1.9f32;
    let v5: f32 = 2.9f32;
    let v6: u32 = 4294967294u32;
    let v7: u32 = 5u32;
    let v8: u32 = 0u32;
    let v9: f32 = v3 - v4;
    let v10: u32 = (v0 as u32);
    let v11: i32 = (v10 as i32);
    let v12: i32 = (v1 as i32);
    let v13: u32 = (v2 as u32);
    let v14: i32 = (v9 as i32);
    let v15: i32 = (v5 as i32);
    let v16: u32 = v10.wrapping_div(2u32);
    let v17: u32 = v6.wrapping_div(2u32);
    let v18: u32 = v7.wrapping_rem(3u32);
    let v19: u32 = !v8;
    let v20: u32 = v1.wrapping_shr((31i32) as u32);
    let v21: bool = v0 < -1i32;
    let v23: bool = if v21 {
        let v22: bool = v0 <= v0;
        v22
    } else {
        false
    };
    let v26: bool = if v23 {
        let v24: bool = v0 > 0i32;
        let v25: bool = v24 == false;
        v25
    } else {
        false
    };
    if v26 {
        let v27: bool = v10 > 1u32;
        let v29: bool = if v27 {
            let v28: bool = v11 == v0;
            v28
        } else {
            false
        };
        let v31: bool = if v29 {
            let v30: bool = v12 == v2;
            v30
        } else {
            false
        };
        let v33: bool = if v31 {
            let v32: bool = v13 == v1;
            v32
        } else {
            false
        };
        if v33 {
            let v34: bool = v14 == v2;
            let v36: bool = if v34 {
                let v35: bool = v15 == 2i32;
                v35
            } else {
                false
            };
            if v36 {
                let v37: bool = v16 == 1073741824u32;
                let v39: bool = if v37 {
                    let v38: bool = v17 == 2147483647u32;
                    v38
                } else {
                    false
                };
                let v41: bool = if v39 {
                    let v40: bool = v18 == 2u32;
                    v40
                } else {
                    false
                };
                if v41 {
                    let v42: bool = v19 == v1;
                    let v44: bool = if v42 {
                        let v43: bool = v20 == 1u32;
                        v43
                    } else {
                        false
                    };
                    if v44 {
                        0i32
                    } else {
                        5i32
                    }
                } else {
                    4i32
                }
            } else {
                3i32
            }
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
