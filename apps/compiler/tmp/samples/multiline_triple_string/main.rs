#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 16i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("x\ny"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("say \"hi\""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a \"\"\" b"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("first\n    second\n\nthird"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab\ncd"); } LIT.with(|lit| lit.clone()) };
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a \"b\" c"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a\\nb"); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"); } LIT.with(|lit| lit.clone()) };
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\ntop\n\nlevel"); } LIT.with(|lit| lit.clone()) };
    let mut v11: i32 = (v6.clone().len() as i32);
    let mut v12: bool = v11 != 7i32;
    if v12 {
        1i32
    } else {
        let mut v13: u8 = v6.clone().as_bytes()[2i32 as usize];
        let mut v14: bool = v13 != b'"';
        if v14 {
            2i32
        } else {
            let mut v15: i32 = (v7.clone().len() as i32);
            let mut v16: bool = v15 != 0i32;
            if v16 {
                3i32
            } else {
                let mut v17: i32 = (v8.clone().len() as i32);
                let mut v18: bool = v17 != 4i32;
                if v18 {
                    4i32
                } else {
                    let mut v19: u8 = v8.clone().as_bytes()[1i32 as usize];
                    let mut v20: bool = v19 != b'\\';
                    if v20 {
                        5i32
                    } else {
                        let mut v21: i32 = (v9.clone().len() as i32);
                        let mut v22: bool = v21 != 83i32;
                        if v22 {
                            6i32
                        } else {
                            let mut v23: u8 = v9.clone().as_bytes()[5i32 as usize];
                            let mut v24: bool = v23 != b'\n';
                            if v24 {
                                7i32
                            } else {
                                let mut v25: u8 = v9.clone().as_bytes()[37i32 as usize];
                                let mut v26: bool = v25 != b'\n';
                                if v26 {
                                    8i32
                                } else {
                                    let mut v27: u8 = v9.clone().as_bytes()[38i32 as usize];
                                    let mut v28: bool = v27 != b'\n';
                                    if v28 {
                                        9i32
                                    } else {
                                        let mut v29: u8 = v9.clone().as_bytes()[39i32 as usize];
                                        let mut v30: bool = v29 != b'$';
                                        if v30 {
                                            10i32
                                        } else {
                                            let mut v31: u8 = v9.clone().as_bytes()[57i32 as usize];
                                            let mut v32: bool = v31 != b'i';
                                            if v32 {
                                                11i32
                                            } else {
                                                let mut v33: u8 = v9.clone().as_bytes()[82i32 as usize];
                                                let mut v34: bool = v33 != b'd';
                                                if v34 {
                                                    12i32
                                                } else {
                                                    let mut v35: i32 = (v10.clone().len() as i32);
                                                    let mut v36: bool = v35 != 11i32;
                                                    if v36 {
                                                        13i32
                                                    } else {
                                                        let mut v37: u8 = v10.clone().as_bytes()[0i32 as usize];
                                                        let mut v38: bool = v37 != b'\n';
                                                        if v38 {
                                                            14i32
                                                        } else {
                                                            let mut v39: u8 = v10.clone().as_bytes()[5i32 as usize];
                                                            let mut v40: bool = v39 != b'\n';
                                                            if v40 {
                                                                15i32
                                                            } else {
                                                                let mut v41: bool = v0 != 16i32;
                                                                if v41 {
                                                                    16i32
                                                                } else {
                                                                    let mut v42: i32 = (v1.clone().len() as i32);
                                                                    let mut v43: bool = v42 != 3i32;
                                                                    if v43 {
                                                                        17i32
                                                                    } else {
                                                                        let mut v44: i32 = (v2.clone().len() as i32);
                                                                        let mut v45: bool = v44 != 8i32;
                                                                        if v45 {
                                                                            18i32
                                                                        } else {
                                                                            let mut v46: u8 = v2.clone().as_bytes()[7i32 as usize];
                                                                            let mut v47: bool = v46 != b'"';
                                                                            if v47 {
                                                                                19i32
                                                                            } else {
                                                                                let mut v48: i32 = (v3.clone().len() as i32);
                                                                                let mut v49: bool = v48 != 7i32;
                                                                                if v49 {
                                                                                    20i32
                                                                                } else {
                                                                                    let mut v50: u8 = v3.clone().as_bytes()[4i32 as usize];
                                                                                    let mut v51: bool = v50 != b'"';
                                                                                    if v51 {
                                                                                        21i32
                                                                                    } else {
                                                                                        let mut v52: i32 = (v4.clone().len() as i32);
                                                                                        let mut v53: bool = v52 != 23i32;
                                                                                        if v53 {
                                                                                            22i32
                                                                                        } else {
                                                                                            let mut v54: u8 = v4.clone().as_bytes()[6i32 as usize];
                                                                                            let mut v55: bool = v54 != b' ';
                                                                                            if v55 {
                                                                                                23i32
                                                                                            } else {
                                                                                                let mut v56: u8 = v4.clone().as_bytes()[10i32 as usize];
                                                                                                let mut v57: bool = v56 != b's';
                                                                                                if v57 {
                                                                                                    24i32
                                                                                                } else {
                                                                                                    let mut v58: u8 = v4.clone().as_bytes()[17i32 as usize];
                                                                                                    let mut v59: bool = v58 != b'\n';
                                                                                                    if v59 {
                                                                                                        25i32
                                                                                                    } else {
                                                                                                        let mut v60: u8 = v4.clone().as_bytes()[22i32 as usize];
                                                                                                        let mut v61: bool = v60 != b'd';
                                                                                                        if v61 {
                                                                                                            26i32
                                                                                                        } else {
                                                                                                            let mut v62: i32 = (v5.clone().len() as i32);
                                                                                                            let mut v63: bool = v62 != 5i32;
                                                                                                            if v63 {
                                                                                                                27i32
                                                                                                            } else {
                                                                                                                let mut v64: u8 = v5.clone().as_bytes()[3i32 as usize];
                                                                                                                let mut v65: bool = v64 != b'c';
                                                                                                                if v65 {
                                                                                                                    28i32
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
