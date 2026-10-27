#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }; }
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn runtime_byte_0(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let v2: u8 = v0.as_bytes()[v1 as usize];
    v2
}
fn codepoint_length_loop_1(mut v0: Rc<str>, mut v1: u8, mut v2: u8, mut v3: i32, mut v4: i32, mut v5: i32) -> i32 {
    loop {
        let v6: bool = v3 == v5;
        if v6 {
            return v4;
        } else {
            let v7: u8 = v0.clone().as_bytes()[v3 as usize];
            let v8: bool = v7 < v1;
            let v10: bool = if v8 {
                false
            } else {
                let v9: bool = v7 < v2;
                v9
            };
            let v12: i32 = if v10 {
                v4
            } else {
                let v11: i32 = v4.wrapping_add(1i32);
                v11
            };
            let v13: i32 = v3.wrapping_add(1i32);
            (v0, v1, v2, v3, v4, v5) = (v0.clone(), v1, v2, v13, v12, v5);
            continue;
        }
    }
}
fn codepoint_byte_offset_loop_2(mut v0: Rc<str>, mut v1: u8, mut v2: u8, mut v3: i32, mut v4: i32, mut v5: i32, mut v6: i32) -> i32 {
    loop {
        let v7: bool = v4 == v6;
        if v7 {
            return v6;
        } else {
            let v8: u8 = v0.clone().as_bytes()[v4 as usize];
            let v9: bool = v8 < v1;
            let v11: bool = if v9 {
                false
            } else {
                let v10: bool = v8 < v2;
                v10
            };
            if v11 {
                let v12: i32 = v4.wrapping_add(1i32);
                (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v1, v2, v3, v12, v5, v6);
                continue;
            } else {
                let v14: bool = v5 == v3;
                if v14 {
                    return v4;
                } else {
                    let v15: i32 = v4.wrapping_add(1i32);
                    let v16: i32 = v5.wrapping_add(1i32);
                    (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v1, v2, v3, v15, v16, v6);
                    continue;
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("À"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = 1i32;
    let v2: u8 = runtime_byte_0(v0.clone(), v1);
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("©"); } LIT.with(|lit| lit.clone()) };
    let v4: i32 = 0i32;
    let v5: u8 = runtime_byte_0(v3.clone(), v4);
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéλ🙂Z"); } LIT.with(|lit| lit.clone()) };
    let v7: i32 = 0i32;
    let v8: i32 = 0i32;
    let v9: i32 = 10i32;
    let v10: i32 = codepoint_length_loop_1(v6.clone(), v2, v5, v7, v8, v9);
    let v11: i32 = 1i32;
    let v12: u8 = runtime_byte_0(v0.clone(), v11);
    let v13: i32 = 0i32;
    let v14: u8 = runtime_byte_0(v3.clone(), v13);
    let v15: i32 = 1i32;
    let v16: i32 = 0i32;
    let v17: i32 = 0i32;
    let v18: i32 = 10i32;
    let v19: i32 = codepoint_byte_offset_loop_2(v6.clone(), v12, v14, v15, v16, v17, v18);
    let v20: i32 = 1i32;
    let v21: u8 = runtime_byte_0(v0.clone(), v20);
    let v22: i32 = 0i32;
    let v23: u8 = runtime_byte_0(v3.clone(), v22);
    let v24: i32 = 2i32;
    let v25: i32 = 0i32;
    let v26: i32 = 0i32;
    let v27: i32 = 10i32;
    let v28: i32 = codepoint_byte_offset_loop_2(v6.clone(), v21, v23, v24, v25, v26, v27);
    let v29: i32 = v28.wrapping_sub(1i32);
    let v30: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéλ🙂Z"); } LIT.with(|lit| lit.clone()) }, v19 as i64, v29 as i64);
    let v31: i32 = 1i32;
    let v32: u8 = runtime_byte_0(v0.clone(), v31);
    let v33: i32 = 0i32;
    let v34: u8 = runtime_byte_0(v3.clone(), v33);
    let v35: i32 = 3i32;
    let v36: i32 = 0i32;
    let v37: i32 = 0i32;
    let v38: i32 = 10i32;
    let v39: i32 = codepoint_byte_offset_loop_2(v6.clone(), v32, v34, v35, v36, v37, v38);
    let v40: i32 = 1i32;
    let v41: u8 = runtime_byte_0(v0.clone(), v40);
    let v42: i32 = 0i32;
    let v43: u8 = runtime_byte_0(v3.clone(), v42);
    let v44: i32 = 4i32;
    let v45: i32 = 0i32;
    let v46: i32 = 0i32;
    let v47: i32 = 10i32;
    let v48: i32 = codepoint_byte_offset_loop_2(v6.clone(), v41, v43, v44, v45, v46, v47);
    let v49: i32 = v48.wrapping_sub(1i32);
    let v50: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéλ🙂Z"); } LIT.with(|lit| lit.clone()) }, v39 as i64, v49 as i64);
    let v51: i32 = 1i32;
    let v52: u8 = runtime_byte_0(v0.clone(), v51);
    let v53: i32 = 0i32;
    let v54: u8 = runtime_byte_0(v3.clone(), v53);
    let v55: i32 = 1i32;
    let v56: i32 = 0i32;
    let v57: i32 = 0i32;
    let v58: i32 = 10i32;
    let v59: i32 = codepoint_byte_offset_loop_2(v6.clone(), v52, v54, v55, v56, v57, v58);
    let v60: i32 = 1i32;
    let v61: u8 = runtime_byte_0(v0.clone(), v60);
    let v62: i32 = 0i32;
    let v63: u8 = runtime_byte_0(v3.clone(), v62);
    let v64: i32 = 4i32;
    let v65: i32 = 0i32;
    let v66: i32 = 0i32;
    let v67: i32 = 10i32;
    let v68: i32 = codepoint_byte_offset_loop_2(v6.clone(), v61, v63, v64, v65, v66, v67);
    let v69: i32 = v68.wrapping_sub(1i32);
    let v70: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéλ🙂Z"); } LIT.with(|lit| lit.clone()) }, v59 as i64, v69 as i64);
    let v71: i32 = 1i32;
    let v72: u8 = runtime_byte_0(v0.clone(), v71);
    let v73: i32 = 0i32;
    let v74: u8 = runtime_byte_0(v3.clone(), v73);
    let v75: i32 = 3i32;
    let v76: i32 = 0i32;
    let v77: i32 = 0i32;
    let v78: i32 = 10i32;
    let v79: i32 = codepoint_byte_offset_loop_2(v6.clone(), v72, v74, v75, v76, v77, v78);
    let v80: i32 = 0i32;
    let v81: u8 = runtime_byte_0(v30.clone(), v80);
    let v82: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let v83: i32 = 0i32;
    let v84: u8 = runtime_byte_0(v82.clone(), v83);
    let v85: i32 = 3i32;
    let v86: u8 = runtime_byte_0(v50.clone(), v85);
    let v87: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("🙂"); } LIT.with(|lit| lit.clone()) };
    let v88: i32 = 3i32;
    let v89: u8 = runtime_byte_0(v87.clone(), v88);
    let v90: bool = v10 == 5i32;
    if v90 {
        let v91: i32 = (v30.clone().len() as i32);
        let v92: bool = v91 == 2i32;
        if v92 {
            let v93: bool = v81 == v84;
            if v93 {
                let v94: i32 = (v50.clone().len() as i32);
                let v95: bool = v94 == 4i32;
                if v95 {
                    let v96: bool = v86 == v89;
                    if v96 {
                        let v97: i32 = (v70.clone().len() as i32);
                        let v98: bool = v97 == 8i32;
                        if v98 {
                            let v99: bool = v79 == 5i32;
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
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
