#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_concat(parts: &[&str]) -> Rc<str> {
    let mut joined = Rc::<[u8]>::new_uninit_slice(parts.iter().map(|part| part.len()).sum());
    let bytes = Rc::get_mut(&mut joined).unwrap().as_mut_ptr() as *mut u8;
    let mut at = 0;
    for part in parts {
        unsafe { std::ptr::copy_nonoverlapping(part.as_ptr(), bytes.add(at), part.len()) };
        at += part.len();
    }
    unsafe { Rc::from_raw(Rc::into_raw(joined.assume_init()) as *const str) }
}
fn method1(mut v0: i32) -> bool {
    let v1: bool = v0 < 7040i32;
    v1
}
fn method0() -> Rc<RefCell<Vec<i32>>> {
    let mut frame_v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 7040i32 as usize]));
    let mut i_v1: i32 = 0i32;
    while method1(i_v1) {
        frame_v0.borrow_mut()[i_v1 as usize] = 46i32;
        let b_v3: i32 = i_v1.wrapping_add(1i32);
        i_v1 = b_v3;
        ()
    };
    frame_v0
}
fn method2(mut v0: &Rc<RefCell<Vec<i32>>>) -> i32 {
    v0.borrow_mut()[5180i32 as usize] = 35i32;
    5180i32
}
fn method3(mut v0: &Rc<RefCell<Vec<i32>>>) -> i32 {
    v0.borrow_mut()[4258i32 as usize] = 64i32;
    4258i32
}
fn method4(mut v0: &Rc<RefCell<Vec<i32>>>) -> i32 {
    v0.borrow_mut()[3964i32 as usize] = 43i32;
    3964i32
}
fn frame_text_loop_5(mut frame_v0: &Rc<RefCell<Vec<i32>>>, mut width_v1: i32, mut size_v2: i32, mut v3: i32, mut v4: Rc<str>) -> Rc<str> {
    let frame_v0_ref = frame_v0.borrow();
    loop {
        let v5: bool = v3 == size_v2;
        if v5 {
            return v4;
        } else {
            let v6: i32 = frame_v0_ref[v3 as usize];
            let v7: bool = v6 == 35i32;
            let v16: Rc<str> = if v7 {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("#"); } LIT.with(|lit| lit.clone()) };
                v8
            } else {
                let v9: bool = v6 == 43i32;
                if v9 {
                    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+"); } LIT.with(|lit| lit.clone()) };
                    v10
                } else {
                    let v11: bool = v6 == 64i32;
                    if v11 {
                        let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("@"); } LIT.with(|lit| lit.clone()) };
                        v12
                    } else {
                        let v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) };
                        v13
                    }
                }
            };
            let text_v17: Rc<str> = string_concat(&[&*v4, &*v16]);
            let next_v18: i32 = v3.wrapping_add(1i32);
            let v19: i32 = v3.wrapping_rem(width_v1);
            let v20: i32 = width_v1.wrapping_sub(1i32);
            let v21: bool = v19 == v20;
            let v23: bool = if v21 {
                let v22: bool = next_v18 < size_v2;
                v22
            } else {
                false
            };
            if v23 {
                let text_v24: Rc<str> = string_concat(&[&*text_v17, "\n"]);
                (v3, v4) = (next_v18, text_v24);
                continue;
            } else {
                (v3, v4) = (next_v18, text_v17);
                continue;
            }
        }
    }
}
fn runtime_byte_8(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let v2: u8 = v0.as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_7(mut str_v0: Rc<str>, mut i_v1: i32) -> i32 {
    let byte_length_v2: i32 = (str_v0.clone().len() as i32);
    let v3: bool = i_v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let v5: bool = i_v1 >= byte_length_v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let v7: u8 = runtime_byte_8(str_v0.clone(), i_v1);
            let b0_v8: i32 = i32::from(v7);
            let v9: bool = b0_v8 < 128i32;
            if v9 {
                b0_v8
            } else {
                let v10: bool = b0_v8 < 194i32;
                if v10 {
                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar starts with an invalid lead byte."); } LIT.with(|lit| lit.clone()) }))
                } else {
                    let v12: bool = b0_v8 < 224i32;
                    if v12 {
                        let i_v13: i32 = i_v1.wrapping_add(1i32);
                        let v14: bool = i_v13 >= byte_length_v2;
                        if v14 {
                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                        } else {
                            let v16: u8 = runtime_byte_8(str_v0, i_v13);
                            let b1_v17: i32 = i32::from(v16);
                            let v18: bool = b1_v17 < 128i32;
                            let v20: bool = if v18 {
                                false
                            } else {
                                let v19: bool = b1_v17 < 192i32;
                                v19
                            };
                            if v20 {
                                let v21: i32 = b0_v8.wrapping_sub(192i32);
                                let v22: i32 = v21.wrapping_mul(64i32);
                                let v23: i32 = b1_v17.wrapping_sub(128i32);
                                let v24: i32 = v22.wrapping_add(v23);
                                v24
                            } else {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                            }
                        }
                    } else {
                        let v28: bool = b0_v8 < 240i32;
                        if v28 {
                            let i_v29: i32 = i_v1.wrapping_add(2i32);
                            let v30: bool = i_v29 >= byte_length_v2;
                            if v30 {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                            } else {
                                let i_v32: i32 = i_v1.wrapping_add(1i32);
                                let v33: u8 = runtime_byte_8(str_v0.clone(), i_v32);
                                let b1_v34: i32 = i32::from(v33);
                                let v35: u8 = runtime_byte_8(str_v0, i_v29);
                                let b2_v36: i32 = i32::from(v35);
                                let v37: bool = b1_v34 < 128i32;
                                let v39: bool = if v37 {
                                    false
                                } else {
                                    let v38: bool = b1_v34 < 192i32;
                                    v38
                                };
                                if v39 {
                                    let v40: bool = b2_v36 < 128i32;
                                    let v42: bool = if v40 {
                                        false
                                    } else {
                                        let v41: bool = b2_v36 < 192i32;
                                        v41
                                    };
                                    if v42 {
                                        let v43: i32 = b0_v8.wrapping_sub(224i32);
                                        let v44: i32 = v43.wrapping_mul(4096i32);
                                        let v45: i32 = b1_v34.wrapping_sub(128i32);
                                        let v46: i32 = v45.wrapping_mul(64i32);
                                        let v47: i32 = v44.wrapping_add(v46);
                                        let v48: i32 = b2_v36.wrapping_sub(128i32);
                                        let scalar_v49: i32 = v47.wrapping_add(v48);
                                        let v50: bool = scalar_v49 < 2048i32;
                                        if v50 {
                                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                        } else {
                                            let v52: bool = scalar_v49 >= 55296i32;
                                            if v52 {
                                                let v53: bool = scalar_v49 <= 57343i32;
                                                if v53 {
                                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence encodes a surrogate."); } LIT.with(|lit| lit.clone()) }))
                                                } else {
                                                    scalar_v49
                                                }
                                            } else {
                                                scalar_v49
                                            }
                                        }
                                    } else {
                                        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                                    }
                                } else {
                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                                }
                            }
                        } else {
                            let v63: bool = b0_v8 < 245i32;
                            if v63 {
                                let i_v64: i32 = i_v1.wrapping_add(3i32);
                                let v65: bool = i_v64 >= byte_length_v2;
                                if v65 {
                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                                } else {
                                    let i_v67: i32 = i_v1.wrapping_add(1i32);
                                    let v68: u8 = runtime_byte_8(str_v0.clone(), i_v67);
                                    let b1_v69: i32 = i32::from(v68);
                                    let i_v70: i32 = i_v1.wrapping_add(2i32);
                                    let v71: u8 = runtime_byte_8(str_v0.clone(), i_v70);
                                    let b2_v72: i32 = i32::from(v71);
                                    let v73: u8 = runtime_byte_8(str_v0, i_v64);
                                    let b3_v74: i32 = i32::from(v73);
                                    let v75: bool = b1_v69 < 128i32;
                                    let v77: bool = if v75 {
                                        false
                                    } else {
                                        let v76: bool = b1_v69 < 192i32;
                                        v76
                                    };
                                    if v77 {
                                        let v78: bool = b2_v72 < 128i32;
                                        let v80: bool = if v78 {
                                            false
                                        } else {
                                            let v79: bool = b2_v72 < 192i32;
                                            v79
                                        };
                                        if v80 {
                                            let v81: bool = b3_v74 < 128i32;
                                            let v83: bool = if v81 {
                                                false
                                            } else {
                                                let v82: bool = b3_v74 < 192i32;
                                                v82
                                            };
                                            if v83 {
                                                let v84: i32 = b0_v8.wrapping_sub(240i32);
                                                let v85: i32 = v84.wrapping_mul(262144i32);
                                                let v86: i32 = b1_v69.wrapping_sub(128i32);
                                                let v87: i32 = v86.wrapping_mul(4096i32);
                                                let v88: i32 = v85.wrapping_add(v87);
                                                let v89: i32 = b2_v72.wrapping_sub(128i32);
                                                let v90: i32 = v89.wrapping_mul(64i32);
                                                let v91: i32 = v88.wrapping_add(v90);
                                                let v92: i32 = b3_v74.wrapping_sub(128i32);
                                                let scalar_v93: i32 = v91.wrapping_add(v92);
                                                let v94: bool = scalar_v93 < 65536i32;
                                                if v94 {
                                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                                } else {
                                                    let v96: bool = scalar_v93 > 1114111i32;
                                                    if v96 {
                                                        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar is above U+10FFFF."); } LIT.with(|lit| lit.clone()) }))
                                                    } else {
                                                        scalar_v93
                                                    }
                                                }
                                            } else {
                                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                                            }
                                        } else {
                                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                                        }
                                    } else {
                                        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                                    }
                                }
                            } else {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar starts with an invalid lead byte."); } LIT.with(|lit| lit.clone()) }))
                            }
                        }
                    }
                }
            }
        }
    }
}
fn loop_6(mut str_v0: Rc<str>, mut v1: i32, mut byte_offset_v2: i32, mut v3: i32) -> i32 {
    loop {
        let v4: bool = byte_offset_v2 == v1;
        if v4 {
            return v3;
        } else {
            let v5: bool = byte_offset_v2 > v1;
            if v5 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let scalar_v7: i32 = utf8_scalar_at_byte_offset_7(str_v0.clone(), byte_offset_v2);
                let v8: bool = scalar_v7 < 128i32;
                let width_v13: i32 = if v8 {
                    1i32
                } else {
                    let v9: bool = scalar_v7 < 2048i32;
                    if v9 {
                        2i32
                    } else {
                        let v10: bool = scalar_v7 < 65536i32;
                        if v10 {
                            3i32
                        } else {
                            4i32
                        }
                    }
                };
                let byte_offset_v14: i32 = byte_offset_v2.wrapping_add(width_v13);
                let state_v15: i32 = v3.wrapping_add(scalar_v7);
                (byte_offset_v2, v3) = (byte_offset_v14, state_v15);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut frame_v0: Rc<RefCell<Vec<i32>>> = method0();
    let i0_v1: i32 = method2(&frame_v0);
    let i1_v2: i32 = method3(&frame_v0);
    let i2_v3: i32 = method4(&frame_v0);
    let p0_v4: i32 = frame_v0.borrow()[0i32 as usize];
    let p1_v5: i32 = frame_v0.borrow()[5180i32 as usize];
    let p2_v6: i32 = frame_v0.borrow()[4258i32 as usize];
    let p3_v7: i32 = frame_v0.borrow()[3964i32 as usize];
    let width_v8: i32 = 160i32;
    let size_v9: i32 = 7040i32;
    let i_v10: i32 = 0i32;
    let text_v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let text_v12: Rc<str> = frame_text_loop_5(&frame_v0, width_v8, size_v9, i_v10, text_v11);
    let text_length_v13: i32 = (text_v12.clone().len() as i32);
    let byte_offset_v14: i32 = 0i32;
    let state_v15: i32 = 0i32;
    let checksum_v16: i32 = loop_6(text_v12.clone(), text_length_v13, byte_offset_v14, state_v15);
    let byte_offset_v17: i32 = 0i32;
    let t0_v18: i32 = utf8_scalar_at_byte_offset_7(text_v12.clone(), byte_offset_v17);
    let byte_offset_v19: i32 = 160i32;
    let t1_v20: i32 = utf8_scalar_at_byte_offset_7(text_v12.clone(), byte_offset_v19);
    let byte_offset_v21: i32 = 3988i32;
    let t2_v22: i32 = utf8_scalar_at_byte_offset_7(text_v12.clone(), byte_offset_v21);
    let byte_offset_v23: i32 = 4284i32;
    let t3_v24: i32 = utf8_scalar_at_byte_offset_7(text_v12.clone(), byte_offset_v23);
    let byte_offset_v25: i32 = 5212i32;
    let t4_v26: i32 = utf8_scalar_at_byte_offset_7(text_v12.clone(), byte_offset_v25);
    let byte_offset_v27: i32 = 7082i32;
    let t5_v28: i32 = utf8_scalar_at_byte_offset_7(text_v12, byte_offset_v27);
    let v29: bool = i0_v1 == 5180i32;
    let v31: bool = if v29 {
        let v30: bool = i1_v2 == 4258i32;
        v30
    } else {
        false
    };
    let v33: bool = if v31 {
        let v32: bool = i2_v3 == 3964i32;
        v32
    } else {
        false
    };
    let v35: bool = if v33 {
        let v34: bool = p0_v4 == 46i32;
        v34
    } else {
        false
    };
    let v37: bool = if v35 {
        let v36: bool = p1_v5 == 35i32;
        v36
    } else {
        false
    };
    let v39: bool = if v37 {
        let v38: bool = p2_v6 == 64i32;
        v38
    } else {
        false
    };
    let v41: bool = if v39 {
        let v40: bool = p3_v7 == 43i32;
        v40
    } else {
        false
    };
    let v43: bool = if v41 {
        let v42: bool = text_length_v13 == 7083i32;
        v42
    } else {
        false
    };
    let v45: bool = if v43 {
        let v44: bool = checksum_v16 == 324274i32;
        v44
    } else {
        false
    };
    let v47: bool = if v45 {
        let v46: bool = t0_v18 == 46i32;
        v46
    } else {
        false
    };
    let v49: bool = if v47 {
        let v48: bool = t1_v20 == 10i32;
        v48
    } else {
        false
    };
    let v51: bool = if v49 {
        let v50: bool = t2_v22 == 43i32;
        v50
    } else {
        false
    };
    let v53: bool = if v51 {
        let v52: bool = t3_v24 == 64i32;
        v52
    } else {
        false
    };
    let v55: bool = if v53 {
        let v54: bool = t4_v26 == 35i32;
        v54
    } else {
        false
    };
    let v57: bool = if v55 {
        let v56: bool = t5_v28 == 46i32;
        v56
    } else {
        false
    };
    if v57 {
        42i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
