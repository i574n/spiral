#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: i32 = 2i32;
    let mut v2: u32 = 4294967295u32;
    let mut v3: i32 = v0.wrapping_neg();
    let mut v4: i32 = -3i32;
    let mut v5: i32 = -12i32;
    let mut v6: i32 = -4i32;
    let mut v7: i32 = -1i32;
    let mut v8: i32 = v3.wrapping_div(v1);
    let mut v9: bool = v8 == v4;
    if v9 {
        let mut v10: i32 = v3.wrapping_rem(v1);
        let mut v11: bool = v10 == v7;
        if v11 {
            let mut v12: i32 = v3.wrapping_shr((1i32) as u32);
            let mut v13: bool = v12 == v6;
            if v13 {
                let mut v14: i32 = v4.wrapping_shl((2i32) as u32);
                let mut v15: bool = v14 == v5;
                if v15 {
                    let mut v16: u32 = v2.wrapping_add(1u32);
                    let mut v17: bool = v16 == 0u32;
                    if v17 {
                        let mut v18: u32 = v2.wrapping_mul(v2);
                        let mut v19: bool = v18 == 1u32;
                        if v19 {
                            let mut v20: u32 = v2.wrapping_shr((28i32) as u32);
                            let mut v21: bool = v20 == 15u32;
                            if v21 {
                                0i32
                            } else {
                                7i32
                            }
                        } else {
                            6i32
                        }
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
