#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn runtime_byte_2(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let mut v2: u8 = v0.clone().as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_1(mut v0: Rc<str>, mut v1: i32) -> i32 {
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: bool = v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let mut v5: bool = v1 >= v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let mut v7: u8 = runtime_byte_2(v0.clone(), v1);
            let mut v8: i32 = i32::from(v7);
            let mut v9: bool = v8 < 128i32;
            if v9 {
                v8
            } else {
                let mut v10: bool = v8 < 194i32;
                if v10 {
                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar starts with an invalid lead byte."); } LIT.with(|lit| lit.clone()) }))
                } else {
                    let mut v12: bool = v8 < 224i32;
                    if v12 {
                        let mut v13: i32 = v1.wrapping_add(1i32);
                        let mut v14: bool = v13 >= v2;
                        if v14 {
                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                        } else {
                            let mut v16: u8 = runtime_byte_2(v0.clone(), v13);
                            let mut v17: i32 = i32::from(v16);
                            let mut v18: bool = v17 < 128i32;
                            let mut v20: bool = if v18 {
                                false
                            } else {
                                let mut v19: bool = v17 < 192i32;
                                v19
                            };
                            if v20 {
                                let mut v21: i32 = v8.wrapping_sub(192i32);
                                let mut v22: i32 = v21.wrapping_mul(64i32);
                                let mut v23: i32 = v17.wrapping_sub(128i32);
                                let mut v24: i32 = v22.wrapping_add(v23);
                                v24
                            } else {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                            }
                        }
                    } else {
                        let mut v28: bool = v8 < 240i32;
                        if v28 {
                            let mut v29: i32 = v1.wrapping_add(2i32);
                            let mut v30: bool = v29 >= v2;
                            if v30 {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                            } else {
                                let mut v32: i32 = v1.wrapping_add(1i32);
                                let mut v33: u8 = runtime_byte_2(v0.clone(), v32);
                                let mut v34: i32 = i32::from(v33);
                                let mut v35: u8 = runtime_byte_2(v0.clone(), v29);
                                let mut v36: i32 = i32::from(v35);
                                let mut v37: bool = v34 < 128i32;
                                let mut v39: bool = if v37 {
                                    false
                                } else {
                                    let mut v38: bool = v34 < 192i32;
                                    v38
                                };
                                if v39 {
                                    let mut v40: bool = v36 < 128i32;
                                    let mut v42: bool = if v40 {
                                        false
                                    } else {
                                        let mut v41: bool = v36 < 192i32;
                                        v41
                                    };
                                    if v42 {
                                        let mut v43: i32 = v8.wrapping_sub(224i32);
                                        let mut v44: i32 = v43.wrapping_mul(4096i32);
                                        let mut v45: i32 = v34.wrapping_sub(128i32);
                                        let mut v46: i32 = v45.wrapping_mul(64i32);
                                        let mut v47: i32 = v44.wrapping_add(v46);
                                        let mut v48: i32 = v36.wrapping_sub(128i32);
                                        let mut v49: i32 = v47.wrapping_add(v48);
                                        let mut v50: bool = v49 < 2048i32;
                                        if v50 {
                                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                        } else {
                                            let mut v52: bool = v49 >= 55296i32;
                                            if v52 {
                                                let mut v53: bool = v49 <= 57343i32;
                                                if v53 {
                                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence encodes a surrogate."); } LIT.with(|lit| lit.clone()) }))
                                                } else {
                                                    v49
                                                }
                                            } else {
                                                v49
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
                            let mut v63: bool = v8 < 245i32;
                            if v63 {
                                let mut v64: i32 = v1.wrapping_add(3i32);
                                let mut v65: bool = v64 >= v2;
                                if v65 {
                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                                } else {
                                    let mut v67: i32 = v1.wrapping_add(1i32);
                                    let mut v68: u8 = runtime_byte_2(v0.clone(), v67);
                                    let mut v69: i32 = i32::from(v68);
                                    let mut v70: i32 = v1.wrapping_add(2i32);
                                    let mut v71: u8 = runtime_byte_2(v0.clone(), v70);
                                    let mut v72: i32 = i32::from(v71);
                                    let mut v73: u8 = runtime_byte_2(v0.clone(), v64);
                                    let mut v74: i32 = i32::from(v73);
                                    let mut v75: bool = v69 < 128i32;
                                    let mut v77: bool = if v75 {
                                        false
                                    } else {
                                        let mut v76: bool = v69 < 192i32;
                                        v76
                                    };
                                    if v77 {
                                        let mut v78: bool = v72 < 128i32;
                                        let mut v80: bool = if v78 {
                                            false
                                        } else {
                                            let mut v79: bool = v72 < 192i32;
                                            v79
                                        };
                                        if v80 {
                                            let mut v81: bool = v74 < 128i32;
                                            let mut v83: bool = if v81 {
                                                false
                                            } else {
                                                let mut v82: bool = v74 < 192i32;
                                                v82
                                            };
                                            if v83 {
                                                let mut v84: i32 = v8.wrapping_sub(240i32);
                                                let mut v85: i32 = v84.wrapping_mul(262144i32);
                                                let mut v86: i32 = v69.wrapping_sub(128i32);
                                                let mut v87: i32 = v86.wrapping_mul(4096i32);
                                                let mut v88: i32 = v85.wrapping_add(v87);
                                                let mut v89: i32 = v72.wrapping_sub(128i32);
                                                let mut v90: i32 = v89.wrapping_mul(64i32);
                                                let mut v91: i32 = v88.wrapping_add(v90);
                                                let mut v92: i32 = v74.wrapping_sub(128i32);
                                                let mut v93: i32 = v91.wrapping_add(v92);
                                                let mut v94: bool = v93 < 65536i32;
                                                if v94 {
                                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                                } else {
                                                    let mut v96: bool = v93 > 1114111i32;
                                                    if v96 {
                                                        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar is above U+10FFFF."); } LIT.with(|lit| lit.clone()) }))
                                                    } else {
                                                        v93
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
fn loop_0(mut v0: i32, mut v1: i32, mut v2: i32) -> (i32, i32) {
    loop {
        let mut v3: bool = v0 == 10i32;
        if v3 {
            return (v1, v2);
        } else {
            let mut v4: bool = v0 > 10i32;
            if v4 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéλ🙂Z"); } LIT.with(|lit| lit.clone()) };
                let mut v8: i32 = utf8_scalar_at_byte_offset_1(v7.clone(), v0);
                let mut v9: bool = v8 < 128i32;
                let mut v14: i32 = if v9 {
                    1i32
                } else {
                    let mut v10: bool = v8 < 2048i32;
                    if v10 {
                        2i32
                    } else {
                        let mut v11: bool = v8 < 65536i32;
                        if v11 {
                            3i32
                        } else {
                            4i32
                        }
                    }
                };
                let mut v15: i32 = v0.wrapping_add(v14);
                let mut v16: i32 = v1.wrapping_add(1i32);
                let mut v17: i32 = v2.wrapping_mul(3i32);
                let mut v18: i32 = v8.wrapping_rem(17i32);
                let mut v19: i32 = v17.wrapping_add(v18);
                (v0, v1, v2) = (v15, v16, v19);
                continue;
            }
        }
    }
}
fn loop_3(mut v0: i32, mut v1: i32, mut v2: i32) -> (i32, i32) {
    loop {
        let mut v3: bool = v0 == 0i32;
        if v3 {
            return (v1, v2);
        } else {
            let mut v4: bool = v0 > 0i32;
            if v4 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let mut v8: i32 = utf8_scalar_at_byte_offset_1(v7.clone(), v0);
                let mut v9: bool = v8 < 128i32;
                let mut v14: i32 = if v9 {
                    1i32
                } else {
                    let mut v10: bool = v8 < 2048i32;
                    if v10 {
                        2i32
                    } else {
                        let mut v11: bool = v8 < 65536i32;
                        if v11 {
                            3i32
                        } else {
                            4i32
                        }
                    }
                };
                let mut v15: i32 = v0.wrapping_add(v14);
                let mut v16: i32 = v1.wrapping_add(1i32);
                let mut v17: i32 = v2.wrapping_mul(3i32);
                let mut v18: i32 = v8.wrapping_rem(17i32);
                let mut v19: i32 = v17.wrapping_add(v18);
                (v0, v1, v2) = (v15, v16, v19);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    let mut v1: i32 = 0i32;
    let mut v2: i32 = 0i32;
    let (mut v3, mut v4): (i32, i32) = loop_0(v0, v1, v2);
    let mut v5: i32 = 0i32;
    let mut v6: i32 = 0i32;
    let mut v7: i32 = 0i32;
    let (mut v8, mut v9): (i32, i32) = loop_3(v5, v6, v7);
    let mut v10: i32 = 5i32;
    let mut v11: i32 = 0i32;
    let mut v12: i32 = 0i32;
    let (mut v13, mut v14): (i32, i32) = loop_0(v10, v11, v12);
    let mut v15: bool = v3 == 5i32;
    if v15 {
        let mut v16: bool = v4 == 1511i32;
        if v16 {
            let mut v17: bool = v8 == 0i32;
            if v17 {
                let mut v18: bool = v9 == 0i32;
                if v18 {
                    let mut v19: bool = v13 == 2i32;
                    if v19 {
                        let mut v20: bool = v14 == 26i32;
                        if v20 {
                            0i32
                        } else {
                            6i32
                        }
                    } else {
                        5i32
                    }
                } else {
                    4i32
                }
            } else {
                3i32
            }
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
