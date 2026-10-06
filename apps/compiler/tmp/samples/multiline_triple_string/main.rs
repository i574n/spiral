#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a \"b\" c"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a\\nb"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\ntop\n\nlevel"); } LIT.with(|lit| lit.clone()) };
    let mut v5: i32 = (v0.clone().len() as i32);
    let mut v6: bool = v5 == 7i32;
    let mut v7: bool = v6 != true;
    if v7 {
        1i32
    } else {
        let mut v8: u8 = v0.clone().as_bytes()[2i32 as usize];
        let mut v9: bool = v8 == b'"';
        let mut v10: bool = v9 != true;
        if v10 {
            2i32
        } else {
            let mut v11: i32 = (v1.clone().len() as i32);
            let mut v12: bool = v11 == 0i32;
            let mut v13: bool = v12 != true;
            if v13 {
                3i32
            } else {
                let mut v14: i32 = (v2.clone().len() as i32);
                let mut v15: bool = v14 == 4i32;
                let mut v16: bool = v15 != true;
                if v16 {
                    4i32
                } else {
                    let mut v17: u8 = v2.clone().as_bytes()[1i32 as usize];
                    let mut v18: bool = v17 == b'\\';
                    let mut v19: bool = v18 != true;
                    if v19 {
                        5i32
                    } else {
                        let mut v20: i32 = (v3.clone().len() as i32);
                        let mut v21: bool = v20 == 83i32;
                        let mut v22: bool = v21 != true;
                        if v22 {
                            6i32
                        } else {
                            let mut v23: u8 = v3.clone().as_bytes()[5i32 as usize];
                            let mut v24: bool = v23 == b'\n';
                            let mut v25: bool = v24 != true;
                            if v25 {
                                7i32
                            } else {
                                let mut v26: u8 = v3.clone().as_bytes()[37i32 as usize];
                                let mut v27: bool = v26 == b'\n';
                                let mut v28: bool = v27 != true;
                                if v28 {
                                    8i32
                                } else {
                                    let mut v29: u8 = v3.clone().as_bytes()[38i32 as usize];
                                    let mut v30: bool = v29 == b'\n';
                                    let mut v31: bool = v30 != true;
                                    if v31 {
                                        9i32
                                    } else {
                                        let mut v32: u8 = v3.clone().as_bytes()[39i32 as usize];
                                        let mut v33: bool = v32 == b'$';
                                        let mut v34: bool = v33 != true;
                                        if v34 {
                                            10i32
                                        } else {
                                            let mut v35: u8 = v3.clone().as_bytes()[57i32 as usize];
                                            let mut v36: bool = v35 == b'i';
                                            let mut v37: bool = v36 != true;
                                            if v37 {
                                                11i32
                                            } else {
                                                let mut v38: u8 = v3.clone().as_bytes()[82i32 as usize];
                                                let mut v39: bool = v38 == b'd';
                                                let mut v40: bool = v39 != true;
                                                if v40 {
                                                    12i32
                                                } else {
                                                    let mut v41: i32 = (v4.clone().len() as i32);
                                                    let mut v42: bool = v41 == 11i32;
                                                    let mut v43: bool = v42 != true;
                                                    if v43 {
                                                        13i32
                                                    } else {
                                                        let mut v44: u8 = v4.clone().as_bytes()[0i32 as usize];
                                                        let mut v45: bool = v44 == b'\n';
                                                        let mut v46: bool = v45 != true;
                                                        if v46 {
                                                            14i32
                                                        } else {
                                                            let mut v47: u8 = v4.clone().as_bytes()[5i32 as usize];
                                                            let mut v48: bool = v47 == b'\n';
                                                            let mut v49: bool = v48 != true;
                                                            if v49 {
                                                                15i32
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
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
