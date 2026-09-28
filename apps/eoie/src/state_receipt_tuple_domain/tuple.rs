#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn method2() -> Rc<str> {
    let mut v0: Rc<str> = Rc::<str>::from("");
    v0.clone()
}
fn method1() -> Rc<str> {
    method2()
}
fn method3(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method4(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u8) -> i32 {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return v2;
        } else {
            let mut v5: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v6: bool = v5 == v3 ;
            if v6 {
                return v1;
            } else {
                let mut v7: i32 = v1 + 1i32 ;
                (v0, v1, v2, v3) = (v0.clone(), v7, v2, v3);
                continue;
            }
        }
    }
}
fn method0(mut v0: Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    let mut v1: Rc<str> = method1();
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: Rc<str> = Rc::<str>::from("\t");
    let mut v4: u8 = method3(v3.clone());
    let mut v5: i32 = 0i32;
    let mut v6: i32 = method4(v0.clone(), v5, v2, v4);
    let mut v7: bool = v6 == v2 ;
    if v7 {
        (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
    } else {
        let mut v8: bool = 0i32 == v6 ;
        let mut v12: Rc<str> = if v8 {
            method1()
        } else {
            let mut v10: i32 = v6 - 1i32 ;
            let mut v11: Rc<str> = string_slice(&v0.clone(), 0i32 as i64, v10 as i64);
            v11.clone()
        };
        let mut v13: Rc<str> = Rc::<str>::from("snapshot");
        let mut v14: bool = v12 == v13 ;
        if v14 {
            let mut v15: i32 = v6 + 1i32 ;
            let mut v16: u8 = method3(v3.clone());
            let mut v17: i32 = method4(v0.clone(), v15, v2, v16);
            let mut v18: bool = v17 < v2;
            if v18 {
                (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
            } else {
                let mut v19: i32 = v6 + 1i32 ;
                let mut v20: bool = v19 == v2 ;
                let mut v24: Rc<str> = if v20 {
                    method1()
                } else {
                    let mut v22: i32 = v2 - 1i32 ;
                    let mut v23: Rc<str> = string_slice(&v0.clone(), v19 as i64, v22 as i64);
                    v23.clone()
                };
                let mut v25: Rc<str> = Rc::<str>::from("");
                let mut v26: bool = v24 == v25 ;
                if v26 {
                    (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                } else {
                    (v13.clone(), v24.clone(), v1.clone(), v1.clone(), v1.clone())
                }
            }
        } else {
            let mut v37: Rc<str> = Rc::<str>::from("module");
            let mut v38: bool = v12 == v37 ;
            if v38 {
                let mut v39: i32 = v6 + 1i32 ;
                let mut v40: u8 = method3(v3.clone());
                let mut v41: i32 = method4(v0.clone(), v39, v2, v40);
                let mut v42: bool = v41 == v2 ;
                if v42 {
                    (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                } else {
                    let mut v43: i32 = v41 + 1i32 ;
                    let mut v44: u8 = method3(v3.clone());
                    let mut v45: i32 = method4(v0.clone(), v43, v2, v44);
                    let mut v46: bool = v45 == v2 ;
                    if v46 {
                        (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                    } else {
                        let mut v47: i32 = v45 + 1i32 ;
                        let mut v48: u8 = method3(v3.clone());
                        let mut v49: i32 = method4(v0.clone(), v47, v2, v48);
                        let mut v50: bool = v49 == v2 ;
                        if v50 {
                            (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                        } else {
                            let mut v51: i32 = v49 + 1i32 ;
                            let mut v52: u8 = method3(v3.clone());
                            let mut v53: i32 = method4(v0.clone(), v51, v2, v52);
                            let mut v54: bool = v53 < v2;
                            if v54 {
                                (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                            } else {
                                let mut v55: i32 = v6 + 1i32 ;
                                let mut v56: bool = v55 == v41 ;
                                let mut v60: Rc<str> = if v56 {
                                    method1()
                                } else {
                                    let mut v58: i32 = v41 - 1i32 ;
                                    let mut v59: Rc<str> = string_slice(&v0.clone(), v55 as i64, v58 as i64);
                                    v59.clone()
                                };
                                let mut v61: i32 = v41 + 1i32 ;
                                let mut v62: bool = v61 == v45 ;
                                let mut v66: Rc<str> = if v62 {
                                    method1()
                                } else {
                                    let mut v64: i32 = v45 - 1i32 ;
                                    let mut v65: Rc<str> = string_slice(&v0.clone(), v61 as i64, v64 as i64);
                                    v65.clone()
                                };
                                let mut v67: i32 = v45 + 1i32 ;
                                let mut v68: bool = v67 == v49 ;
                                let mut v72: Rc<str> = if v68 {
                                    method1()
                                } else {
                                    let mut v70: i32 = v49 - 1i32 ;
                                    let mut v71: Rc<str> = string_slice(&v0.clone(), v67 as i64, v70 as i64);
                                    v71.clone()
                                };
                                let mut v73: i32 = v49 + 1i32 ;
                                let mut v74: bool = v73 == v2 ;
                                let mut v78: Rc<str> = if v74 {
                                    method1()
                                } else {
                                    let mut v76: i32 = v2 - 1i32 ;
                                    let mut v77: Rc<str> = string_slice(&v0.clone(), v73 as i64, v76 as i64);
                                    v77.clone()
                                };
                                let mut v79: Rc<str> = Rc::<str>::from("");
                                let mut v80: bool = v60 == v79 ;
                                if v80 {
                                    (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                                } else {
                                    let mut v81: bool = v66 == v79 ;
                                    if v81 {
                                        (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                                    } else {
                                        let mut v82: bool = v72 == v79 ;
                                        if v82 {
                                            (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                                        } else {
                                            let mut v83: bool = v78 == v79 ;
                                            if v83 {
                                                (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
                                            } else {
                                                (v37.clone(), v60.clone(), v66.clone(), v72.clone(), v78.clone())
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } else {
                (v1.clone(), v1.clone(), v1.clone(), v1.clone(), v1.clone())
            }
        }
    }
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>)> {
    Rc::new(move |mut v0: Rc<str>| -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
        method0(v0.clone())
    })
}
pub fn eoie_state_receipt_row_tuple(v0: &str) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    closure0()(Rc::<str>::from(v0))
}
