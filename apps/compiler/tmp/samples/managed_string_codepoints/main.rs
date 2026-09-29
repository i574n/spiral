#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    match std::str::from_utf8(&bytes[from as usize..(to + 1) as usize]) { Ok(slice) => Rc::<str>::from(slice), Err(_) => std::process::abort() }
}
fn method0(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let mut v2: u8 = v0.clone().as_bytes()[v1 as usize];
    v2
}
fn method1(mut v0: Rc<str>, mut v1: u8, mut v2: u8, mut v3: i32, mut v4: i32, mut v5: i32) -> i32 {
    loop {
        let mut v6: bool = v3 == v5;
        if v6 {
            return v4;
        } else {
            let mut v7: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v8: bool = v7 < v1;
            let mut v10: bool = if v8 {
                false
            } else {
                let mut v9: bool = v7 < v2;
                v9
            };
            let mut v12: i32 = if v10 {
                v4
            } else {
                let mut v11: i32 = v4 + 1i32;
                v11
            };
            let mut v13: i32 = v3 + 1i32;
            (v0, v1, v2, v3, v4, v5) = (v0.clone(), v1, v2, v13, v12, v5);
            continue;
        }
    }
}
fn method2(mut v0: Rc<str>, mut v1: u8, mut v2: u8, mut v3: i32, mut v4: i32, mut v5: i32, mut v6: i32) -> i32 {
    loop {
        let mut v7: bool = v4 == v6;
        if v7 {
            return v6;
        } else {
            let mut v8: u8 = v0.clone().as_bytes()[v4 as usize];
            let mut v9: bool = v8 < v1;
            let mut v11: bool = if v9 {
                false
            } else {
                let mut v10: bool = v8 < v2;
                v10
            };
            if v11 {
                let mut v12: i32 = v4 + 1i32;
                (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v1, v2, v3, v12, v5, v6);
                continue;
            } else {
                let mut v14: bool = v5 == v3;
                if v14 {
                    return v4;
                } else {
                    let mut v15: i32 = v4 + 1i32;
                    let mut v16: i32 = v5 + 1i32;
                    (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v1, v2, v3, v15, v16, v6);
                    continue;
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("À");
    let mut v1: i32 = 1i32;
    let mut v2: u8 = method0(v0.clone(), v1);
    let mut v3: Rc<str> = Rc::<str>::from("©");
    let mut v4: i32 = 0i32;
    let mut v5: u8 = method0(v3.clone(), v4);
    let mut v6: Rc<str> = Rc::<str>::from("Aéλ🙂Z");
    let mut v7: i32 = 0i32;
    let mut v8: i32 = 0i32;
    let mut v9: i32 = 10i32;
    let mut v10: i32 = method1(v6.clone(), v2, v5, v7, v8, v9);
    let mut v11: i32 = 1i32;
    let mut v12: u8 = method0(v0.clone(), v11);
    let mut v13: i32 = 0i32;
    let mut v14: u8 = method0(v3.clone(), v13);
    let mut v15: i32 = 1i32;
    let mut v16: i32 = 0i32;
    let mut v17: i32 = 0i32;
    let mut v18: i32 = 10i32;
    let mut v19: i32 = method2(v6.clone(), v12, v14, v15, v16, v17, v18);
    let mut v20: i32 = 1i32;
    let mut v21: u8 = method0(v0.clone(), v20);
    let mut v22: i32 = 0i32;
    let mut v23: u8 = method0(v3.clone(), v22);
    let mut v24: i32 = 2i32;
    let mut v25: i32 = 0i32;
    let mut v26: i32 = 0i32;
    let mut v27: i32 = 10i32;
    let mut v28: i32 = method2(v6.clone(), v21, v23, v24, v25, v26, v27);
    let mut v29: i32 = v28 - 1i32;
    let mut v30: Rc<str> = string_slice(&Rc::<str>::from("Aéλ🙂Z"), v19 as i64, v29 as i64);
    let mut v31: i32 = 1i32;
    let mut v32: u8 = method0(v0.clone(), v31);
    let mut v33: i32 = 0i32;
    let mut v34: u8 = method0(v3.clone(), v33);
    let mut v35: i32 = 3i32;
    let mut v36: i32 = 0i32;
    let mut v37: i32 = 0i32;
    let mut v38: i32 = 10i32;
    let mut v39: i32 = method2(v6.clone(), v32, v34, v35, v36, v37, v38);
    let mut v40: i32 = 1i32;
    let mut v41: u8 = method0(v0.clone(), v40);
    let mut v42: i32 = 0i32;
    let mut v43: u8 = method0(v3.clone(), v42);
    let mut v44: i32 = 4i32;
    let mut v45: i32 = 0i32;
    let mut v46: i32 = 0i32;
    let mut v47: i32 = 10i32;
    let mut v48: i32 = method2(v6.clone(), v41, v43, v44, v45, v46, v47);
    let mut v49: i32 = v48 - 1i32;
    let mut v50: Rc<str> = string_slice(&Rc::<str>::from("Aéλ🙂Z"), v39 as i64, v49 as i64);
    let mut v51: i32 = 1i32;
    let mut v52: u8 = method0(v0.clone(), v51);
    let mut v53: i32 = 0i32;
    let mut v54: u8 = method0(v3.clone(), v53);
    let mut v55: i32 = 1i32;
    let mut v56: i32 = 0i32;
    let mut v57: i32 = 0i32;
    let mut v58: i32 = 10i32;
    let mut v59: i32 = method2(v6.clone(), v52, v54, v55, v56, v57, v58);
    let mut v60: i32 = 1i32;
    let mut v61: u8 = method0(v0.clone(), v60);
    let mut v62: i32 = 0i32;
    let mut v63: u8 = method0(v3.clone(), v62);
    let mut v64: i32 = 4i32;
    let mut v65: i32 = 0i32;
    let mut v66: i32 = 0i32;
    let mut v67: i32 = 10i32;
    let mut v68: i32 = method2(v6.clone(), v61, v63, v64, v65, v66, v67);
    let mut v69: i32 = v68 - 1i32;
    let mut v70: Rc<str> = string_slice(&Rc::<str>::from("Aéλ🙂Z"), v59 as i64, v69 as i64);
    let mut v71: i32 = 1i32;
    let mut v72: u8 = method0(v0.clone(), v71);
    let mut v73: i32 = 0i32;
    let mut v74: u8 = method0(v3.clone(), v73);
    let mut v75: i32 = 3i32;
    let mut v76: i32 = 0i32;
    let mut v77: i32 = 0i32;
    let mut v78: i32 = 10i32;
    let mut v79: i32 = method2(v6.clone(), v72, v74, v75, v76, v77, v78);
    let mut v80: i32 = 0i32;
    let mut v81: u8 = method0(v30.clone(), v80);
    let mut v82: Rc<str> = Rc::<str>::from("é");
    let mut v83: i32 = 0i32;
    let mut v84: u8 = method0(v82.clone(), v83);
    let mut v85: i32 = 3i32;
    let mut v86: u8 = method0(v50.clone(), v85);
    let mut v87: Rc<str> = Rc::<str>::from("🙂");
    let mut v88: i32 = 3i32;
    let mut v89: u8 = method0(v87.clone(), v88);
    let mut v90: bool = v10 == 5i32;
    if v90 {
        let mut v91: i32 = (v30.clone().len() as i32);
        let mut v92: bool = v91 == 2i32;
        if v92 {
            let mut v93: bool = v81 == v84;
            if v93 {
                let mut v94: i32 = (v50.clone().len() as i32);
                let mut v95: bool = v94 == 4i32;
                if v95 {
                    let mut v96: bool = v86 == v89;
                    if v96 {
                        let mut v97: i32 = (v70.clone().len() as i32);
                        let mut v98: bool = v97 == 8i32;
                        if v98 {
                            let mut v99: bool = v79 == 5i32;
                            if v99 {
                                0i32
                            } else {
                                1i32
                            }
                        } else {
                            2i32
                        }
                    } else {
                        3i32
                    }
                } else {
                    4i32
                }
            } else {
                5i32
            }
        } else {
            6i32
        }
    } else {
        7i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
