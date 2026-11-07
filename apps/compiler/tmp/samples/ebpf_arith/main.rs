#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: i32 = 2i32;
    let v2: u32 = 4294967295u32;
    let v3: i32 = v0.wrapping_neg();
    let v4: i32 = -3i32;
    let v5: i32 = -12i32;
    let v6: i32 = -4i32;
    let v7: i32 = -1i32;
    let v8: i32 = v3.wrapping_div(v1);
    let v9: bool = v8 == v4;
    if v9 {
        let v10: i32 = v3.wrapping_rem(v1);
        let v11: bool = v10 == v7;
        if v11 {
            let v12: i32 = v3.wrapping_shr((1i32) as u32);
            let v13: bool = v12 == v6;
            if v13 {
                let v14: i32 = v4.wrapping_shl((2i32) as u32);
                let v15: bool = v14 == v5;
                if v15 {
                    let v16: u32 = v2.wrapping_add(1u32);
                    let v17: bool = v16 == 0u32;
                    if v17 {
                        let v18: u32 = v2.wrapping_mul(v2);
                        let v19: bool = v18 == 1u32;
                        if v19 {
                            let v20: u32 = v2.wrapping_shr((28i32) as u32);
                            let v21: bool = v20 == 15u32;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
