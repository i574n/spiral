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
    let mut v12: bool = v11 == 7i32;
    let mut v13: bool = v12 != true;
    if v13 {
        1i32
    } else {
        let mut v14: u8 = v6.clone().as_bytes()[2i32 as usize];
        let mut v15: bool = v14 == b'"';
        let mut v16: bool = v15 != true;
        if v16 {
            2i32
        } else {
            let mut v17: i32 = (v7.clone().len() as i32);
            let mut v18: bool = v17 == 0i32;
            let mut v19: bool = v18 != true;
            if v19 {
                3i32
            } else {
                let mut v20: i32 = (v8.clone().len() as i32);
                let mut v21: bool = v20 == 4i32;
                let mut v22: bool = v21 != true;
                if v22 {
                    4i32
                } else {
                    let mut v23: u8 = v8.clone().as_bytes()[1i32 as usize];
                    let mut v24: bool = v23 == b'\\';
                    let mut v25: bool = v24 != true;
                    if v25 {
                        5i32
                    } else {
                        let mut v26: i32 = (v9.clone().len() as i32);
                        let mut v27: bool = v26 == 83i32;
                        let mut v28: bool = v27 != true;
                        if v28 {
                            6i32
                        } else {
                            let mut v29: u8 = v9.clone().as_bytes()[5i32 as usize];
                            let mut v30: bool = v29 == b'\n';
                            let mut v31: bool = v30 != true;
                            if v31 {
                                7i32
                            } else {
                                let mut v32: u8 = v9.clone().as_bytes()[37i32 as usize];
                                let mut v33: bool = v32 == b'\n';
                                let mut v34: bool = v33 != true;
                                if v34 {
                                    8i32
                                } else {
                                    let mut v35: u8 = v9.clone().as_bytes()[38i32 as usize];
                                    let mut v36: bool = v35 == b'\n';
                                    let mut v37: bool = v36 != true;
                                    if v37 {
                                        9i32
                                    } else {
                                        let mut v38: u8 = v9.clone().as_bytes()[39i32 as usize];
                                        let mut v39: bool = v38 == b'$';
                                        let mut v40: bool = v39 != true;
                                        if v40 {
                                            10i32
                                        } else {
                                            let mut v41: u8 = v9.clone().as_bytes()[57i32 as usize];
                                            let mut v42: bool = v41 == b'i';
                                            let mut v43: bool = v42 != true;
                                            if v43 {
                                                11i32
                                            } else {
                                                let mut v44: u8 = v9.clone().as_bytes()[82i32 as usize];
                                                let mut v45: bool = v44 == b'd';
                                                let mut v46: bool = v45 != true;
                                                if v46 {
                                                    12i32
                                                } else {
                                                    let mut v47: i32 = (v10.clone().len() as i32);
                                                    let mut v48: bool = v47 == 11i32;
                                                    let mut v49: bool = v48 != true;
                                                    if v49 {
                                                        13i32
                                                    } else {
                                                        let mut v50: u8 = v10.clone().as_bytes()[0i32 as usize];
                                                        let mut v51: bool = v50 == b'\n';
                                                        let mut v52: bool = v51 != true;
                                                        if v52 {
                                                            14i32
                                                        } else {
                                                            let mut v53: u8 = v10.clone().as_bytes()[5i32 as usize];
                                                            let mut v54: bool = v53 == b'\n';
                                                            let mut v55: bool = v54 != true;
                                                            if v55 {
                                                                15i32
                                                            } else {
                                                                let mut v56: bool = v0 == 16i32;
                                                                let mut v57: bool = v56 != true;
                                                                if v57 {
                                                                    16i32
                                                                } else {
                                                                    let mut v58: i32 = (v1.clone().len() as i32);
                                                                    let mut v59: bool = v58 == 3i32;
                                                                    let mut v60: bool = v59 != true;
                                                                    if v60 {
                                                                        17i32
                                                                    } else {
                                                                        let mut v61: i32 = (v2.clone().len() as i32);
                                                                        let mut v62: bool = v61 == 8i32;
                                                                        let mut v63: bool = v62 != true;
                                                                        if v63 {
                                                                            18i32
                                                                        } else {
                                                                            let mut v64: u8 = v2.clone().as_bytes()[7i32 as usize];
                                                                            let mut v65: bool = v64 == b'"';
                                                                            let mut v66: bool = v65 != true;
                                                                            if v66 {
                                                                                19i32
                                                                            } else {
                                                                                let mut v67: i32 = (v3.clone().len() as i32);
                                                                                let mut v68: bool = v67 == 7i32;
                                                                                let mut v69: bool = v68 != true;
                                                                                if v69 {
                                                                                    20i32
                                                                                } else {
                                                                                    let mut v70: u8 = v3.clone().as_bytes()[4i32 as usize];
                                                                                    let mut v71: bool = v70 == b'"';
                                                                                    let mut v72: bool = v71 != true;
                                                                                    if v72 {
                                                                                        21i32
                                                                                    } else {
                                                                                        let mut v73: i32 = (v4.clone().len() as i32);
                                                                                        let mut v74: bool = v73 == 23i32;
                                                                                        let mut v75: bool = v74 != true;
                                                                                        if v75 {
                                                                                            22i32
                                                                                        } else {
                                                                                            let mut v76: u8 = v4.clone().as_bytes()[6i32 as usize];
                                                                                            let mut v77: bool = v76 == b' ';
                                                                                            let mut v78: bool = v77 != true;
                                                                                            if v78 {
                                                                                                23i32
                                                                                            } else {
                                                                                                let mut v79: u8 = v4.clone().as_bytes()[10i32 as usize];
                                                                                                let mut v80: bool = v79 == b's';
                                                                                                let mut v81: bool = v80 != true;
                                                                                                if v81 {
                                                                                                    24i32
                                                                                                } else {
                                                                                                    let mut v82: u8 = v4.clone().as_bytes()[17i32 as usize];
                                                                                                    let mut v83: bool = v82 == b'\n';
                                                                                                    let mut v84: bool = v83 != true;
                                                                                                    if v84 {
                                                                                                        25i32
                                                                                                    } else {
                                                                                                        let mut v85: u8 = v4.clone().as_bytes()[22i32 as usize];
                                                                                                        let mut v86: bool = v85 == b'd';
                                                                                                        let mut v87: bool = v86 != true;
                                                                                                        if v87 {
                                                                                                            26i32
                                                                                                        } else {
                                                                                                            let mut v88: i32 = (v5.clone().len() as i32);
                                                                                                            let mut v89: bool = v88 == 5i32;
                                                                                                            let mut v90: bool = v89 != true;
                                                                                                            if v90 {
                                                                                                                27i32
                                                                                                            } else {
                                                                                                                let mut v91: u8 = v5.clone().as_bytes()[3i32 as usize];
                                                                                                                let mut v92: bool = v91 == b'c';
                                                                                                                let mut v93: bool = v92 != true;
                                                                                                                if v93 {
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
