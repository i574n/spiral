#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: f64 = 2.7f64;
    let mut v1: f64 = 3.2f64;
    let mut v2: f64 = -2.5f64;
    let mut v3: f64 = 3.5f64;
    let mut v4: f64 = 0.5f64;
    let mut v5: f64 = 1.0f64;
    let mut v6: f32 = 2.7f32;
    let mut v7: f64 = v0.floor();
    let mut v8: bool = v7 == 2.0f64;
    let mut v9: bool = v8 != true;
    if v9 {
        1i32
    } else {
        let mut v10: f64 = v0.ceil();
        let mut v11: bool = v10 == 3.0f64;
        let mut v12: bool = v11 != true;
        if v12 {
            2i32
        } else {
            let mut v13: f64 = (v0).round_ties_even();
            let mut v14: bool = v13 == 3.0f64;
            let mut v15: bool = v14 != true;
            if v15 {
                3i32
            } else {
                let mut v16: f64 = (v1).round_ties_even();
                let mut v17: bool = v16 == 3.0f64;
                let mut v18: bool = v17 != true;
                if v18 {
                    4i32
                } else {
                    let mut v19: f64 = (v2).round_ties_even();
                    let mut v20: bool = v19 == -2.0f64;
                    let mut v21: bool = v20 != true;
                    if v21 {
                        5i32
                    } else {
                        let mut v22: f64 = (v3).round_ties_even();
                        let mut v23: bool = v22 == 4.0f64;
                        let mut v24: bool = v23 != true;
                        if v24 {
                            6i32
                        } else {
                            let mut v25: f64 = (v4).round_ties_even();
                            let mut v26: bool = v25 == 0.0f64;
                            let mut v27: bool = v26 != true;
                            if v27 {
                                7i32
                            } else {
                                let mut v28: f64 = (v5).atan2(v5);
                                let mut v29: f64 = v28 * 1000.0f64;
                                let mut v30: f64 = v29.floor();
                                let mut v31: bool = v30 == 785.0f64;
                                let mut v32: bool = v31 != true;
                                if v32 {
                                    8i32
                                } else {
                                    let mut v33: f32 = v6.floor();
                                    let mut v34: bool = v33 == 2.0f32;
                                    let mut v35: bool = v34 != true;
                                    if v35 {
                                        9i32
                                    } else {
                                        0i32
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
