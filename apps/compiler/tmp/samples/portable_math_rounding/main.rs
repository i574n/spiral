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
    let mut v22: bool = v15 == 2.0f64;
    let mut v23: bool = v22 != true;
    if v23 {
        1i32
    } else {
        let mut v33: f64 = v0.ceil();
        let mut v40: bool = v33 == 3.0f64;
        let mut v41: bool = v40 != true;
        if v41 {
            2i32
        } else {
            let mut v90: f64 = (v0).round_ties_even();
            let mut v169: bool = v90 == 3.0f64;
            let mut v170: bool = v169 != true;
            if v170 {
                3i32
            } else {
                let mut v171: f64 = (v1).round_ties_even();
                let mut v172: bool = v171 == 3.0f64;
                let mut v173: bool = v172 != true;
                if v173 {
                    4i32
                } else {
                    let mut v174: f64 = (v2).round_ties_even();
                    let mut v175: bool = v174 == -2.0f64;
                    let mut v176: bool = v175 != true;
                    if v176 {
                        5i32
                    } else {
                        let mut v177: f64 = (v3).round_ties_even();
                        let mut v178: bool = v177 == 4.0f64;
                        let mut v179: bool = v178 != true;
                        if v179 {
                            6i32
                        } else {
                            let mut v180: f64 = (v4).round_ties_even();
                            let mut v181: bool = v180 == 0.0f64;
                            let mut v182: bool = v181 != true;
                            if v182 {
                                7i32
                            } else {
                                let mut v188: f64 = (v5).atan2(v5);
                                let mut v195: f64 = v188 * 1000.0f64;
                                let mut v196: f64 = v195.floor();
                                let mut v197: bool = v196 == 785.0f64;
                                let mut v198: bool = v197 != true;
                                if v198 {
                                    8i32
                                } else {
                                    let mut v207: f32 = v6.floor();
                                    let mut v214: bool = v207 == 2.0f32;
                                    let mut v215: bool = v214 != true;
                                    if v215 {
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
