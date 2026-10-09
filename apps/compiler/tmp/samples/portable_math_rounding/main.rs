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
    let mut v15: f64 = v0.floor();
    let mut v23: bool = v15 == 2.0f64;
    let mut v24: bool = v23 != true;
    if v24 {
        1i32
    } else {
        let mut v34: f64 = v0.ceil();
        let mut v42: bool = v34 == 3.0f64;
        let mut v43: bool = v42 != true;
        if v43 {
            2i32
        } else {
            let mut v92: f64 = (v0).round_ties_even();
            let mut v172: bool = v92 == 3.0f64;
            let mut v173: bool = v172 != true;
            if v173 {
                3i32
            } else {
                let mut v174: f64 = (v1).round_ties_even();
                let mut v175: bool = v174 == 3.0f64;
                let mut v176: bool = v175 != true;
                if v176 {
                    4i32
                } else {
                    let mut v177: f64 = (v2).round_ties_even();
                    let mut v178: bool = v177 == -2.0f64;
                    let mut v179: bool = v178 != true;
                    if v179 {
                        5i32
                    } else {
                        let mut v180: f64 = (v3).round_ties_even();
                        let mut v181: bool = v180 == 4.0f64;
                        let mut v182: bool = v181 != true;
                        if v182 {
                            6i32
                        } else {
                            let mut v183: f64 = (v4).round_ties_even();
                            let mut v184: bool = v183 == 0.0f64;
                            let mut v185: bool = v184 != true;
                            if v185 {
                                7i32
                            } else {
                                let mut v191: f64 = (v5).atan2(v5);
                                let mut v199: f64 = v191 * 1000.0f64;
                                let mut v200: f64 = v199.floor();
                                let mut v201: bool = v200 == 785.0f64;
                                let mut v202: bool = v201 != true;
                                if v202 {
                                    8i32
                                } else {
                                    let mut v211: f32 = v6.floor();
                                    let mut v219: bool = v211 == 2.0f32;
                                    let mut v220: bool = v219 != true;
                                    if v220 {
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
