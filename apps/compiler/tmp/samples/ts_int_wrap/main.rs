#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: u8 = 250u8;
    let v1: u8 = 10u8;
    let v2: u32 = 4294967295u32;
    let v3: u64 = 18446744073709551615u64;
    let v4: i8 = 127i8;
    let v5: i8 = 1i8;
    let v6: i32 = 7i32;
    let v7: i32 = 2i32;
    let v8: i64 = 9223372036854775807i64;
    let v9: i32 = v6.wrapping_neg();
    let v10: i64 = v8.wrapping_neg();
    let v11: u8 = v0.wrapping_add(v1);
    let v12: bool = v11 == 4u8;
    if v12 {
        let v13: u32 = v2.wrapping_add(1u32);
        let v14: bool = v13 == 0u32;
        if v14 {
            let v15: u32 = v2.wrapping_mul(v2);
            let v16: bool = v15 == 1u32;
            if v16 {
                let v17: u64 = v3.wrapping_add(1u64);
                let v18: bool = v17 == 0u64;
                if v18 {
                    let v19: u64 = v3.wrapping_mul(v3);
                    let v20: bool = v19 == 1u64;
                    if v20 {
                        let v21: u64 = v3.wrapping_div(3u64);
                        let v22: bool = v21 == 6148914691236517205u64;
                        if v22 {
                            let v23: i8 = v4.wrapping_add(v5);
                            let v24: bool = v23 < 0i8;
                            if v24 {
                                let v25: i32 = v9.wrapping_div(v7);
                                let v26: bool = v25 == -3i32;
                                if v26 {
                                    let v27: i32 = v9.wrapping_rem(v7);
                                    let v28: bool = v27 == -1i32;
                                    if v28 {
                                        let v29: i64 = v10.wrapping_rem(10i64);
                                        let v30: bool = v29 == -7i64;
                                        if v30 {
                                            let v31: u32 = v2.wrapping_shr((28i32) as u32);
                                            let v32: bool = v31 == 15u32;
                                            if v32 {
                                                let v33: i32 = v9.wrapping_shr((1i32) as u32);
                                                let v34: bool = v33 == -4i32;
                                                if v34 {
                                                    0i32
                                                } else {
                                                    12i32
                                                }
                                            } else {
                                                11i32
                                            }
                                        } else {
                                            10i32
                                        }
                                    } else {
                                        9i32
                                    }
                                } else {
                                    8i32
                                }
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
