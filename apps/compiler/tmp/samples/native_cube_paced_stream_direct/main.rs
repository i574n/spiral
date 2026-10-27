#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Hidden,
    US0_Visible(f64, f64, f64),
}
fn method0(mut v0: i32) -> bool {
    let v1: bool = v0 < 3i32;
    v1
}
fn method1(mut v0: i32) -> bool {
    let v1: bool = v0 < 7040i32;
    v1
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 20.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -20.0f64 * v10;
    let v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let v14: f64 = v9 - v13;
    let v15: f64 = 20.0f64 * v10;
    let v16: f64 = (v3).sin();
    let v17: f64 = v15 * v16;
    let v18: f64 = v14 + v17;
    let v19: f64 = -20.0f64 * v4;
    let v20: f64 = v19 * v16;
    let v21: f64 = v18 + v20;
    let v22: f64 = (v2).cos();
    let v23: f64 = 20.0f64 * v22;
    let v24: f64 = v23 * v8;
    let v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let mut v38: f64 = 20.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let v40: f64 = v39 + 100.0f64;
    let v41: f64 = 1.0f64 / v40;
    let v42: f64 = 40.0f64 * v41;
    let v43: f64 = v42 * v25;
    let v44: f64 = v43 * 2.0f64;
    let v45: f64 = 40.0f64 + v44;
    let v46: f64 = v42 * v34;
    let v47: f64 = 22.0f64 + v46;
    let v48: bool = v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = *v58;
            let v59: f64 = *v59;
            let v60: f64 = *v60;
            let v61: bool = v58 >= 0.0f64;
            let v63: bool = if v61 {
                let v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let v65: bool = if v63 {
                let v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let v66: i32 = (v58 as i32);
                let v67: i32 = (v59 as i32);
                let v68: i32 = v67.wrapping_mul(160i32);
                let v69: i32 = v66.wrapping_add(v68);
                v0.borrow_mut()[v69 as usize] = 35i32;
                v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
}
fn method3(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 10.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -10.0f64 * v10;
    let v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let v14: f64 = v9 - v13;
    let v15: f64 = 10.0f64 * v10;
    let v16: f64 = (v3).sin();
    let v17: f64 = v15 * v16;
    let v18: f64 = v14 + v17;
    let v19: f64 = -10.0f64 * v4;
    let v20: f64 = v19 * v16;
    let v21: f64 = v18 + v20;
    let v22: f64 = (v2).cos();
    let v23: f64 = 10.0f64 * v22;
    let v24: f64 = v23 * v8;
    let v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let mut v38: f64 = 10.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let v40: f64 = v39 + 100.0f64;
    let v41: f64 = 1.0f64 / v40;
    let v42: f64 = 40.0f64 * v41;
    let v43: f64 = v42 * v25;
    let v44: f64 = v43 * 2.0f64;
    let v45: f64 = 90.0f64 + v44;
    let v46: f64 = v42 * v34;
    let v47: f64 = 22.0f64 + v46;
    let v48: bool = v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = *v58;
            let v59: f64 = *v59;
            let v60: f64 = *v60;
            let v61: bool = v58 >= 0.0f64;
            let v63: bool = if v61 {
                let v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let v65: bool = if v63 {
                let v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let v66: i32 = (v58 as i32);
                let v67: i32 = (v59 as i32);
                let v68: i32 = v67.wrapping_mul(160i32);
                let v69: i32 = v66.wrapping_add(v68);
                v0.borrow_mut()[v69 as usize] = 64i32;
                v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
}
fn method4(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 5.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -5.0f64 * v10;
    let v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let v14: f64 = v9 - v13;
    let v15: f64 = 5.0f64 * v10;
    let v16: f64 = (v3).sin();
    let v17: f64 = v15 * v16;
    let v18: f64 = v14 + v17;
    let v19: f64 = -5.0f64 * v4;
    let v20: f64 = v19 * v16;
    let v21: f64 = v18 + v20;
    let v22: f64 = (v2).cos();
    let v23: f64 = 5.0f64 * v22;
    let v24: f64 = v23 * v8;
    let v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let mut v38: f64 = 5.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let v40: f64 = v39 + 100.0f64;
    let v41: f64 = 1.0f64 / v40;
    let v42: f64 = 40.0f64 * v41;
    let v43: f64 = v42 * v25;
    let v44: f64 = v43 * 2.0f64;
    let v45: f64 = 120.0f64 + v44;
    let v46: f64 = v42 * v34;
    let v47: f64 = 22.0f64 + v46;
    let v48: bool = v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = *v58;
            let v59: f64 = *v59;
            let v60: f64 = *v60;
            let v61: bool = v58 >= 0.0f64;
            let v63: bool = if v61 {
                let v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let v65: bool = if v63 {
                let v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let v66: i32 = (v58 as i32);
                let v67: i32 = (v59 as i32);
                let v68: i32 = v67.wrapping_mul(160i32);
                let v69: i32 = v66.wrapping_add(v68);
                v0.borrow_mut()[v69 as usize] = 43i32;
                v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
}
fn frame_text_loop_5(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: Rc<str>) -> Rc<str> {
    loop {
        let v5: bool = v3 == v2;
        if v5 {
            return v4.clone();
        } else {
            let v6: i32 = v0.clone().borrow()[v3 as usize].clone();
            let v7: bool = v6 == 35i32;
            let v16: Rc<str> = if v7 {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("#"); } LIT.with(|lit| lit.clone()) };
                v8.clone()
            } else {
                let v9: bool = v6 == 43i32;
                if v9 {
                    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+"); } LIT.with(|lit| lit.clone()) };
                    v10.clone()
                } else {
                    let v11: bool = v6 == 64i32;
                    if v11 {
                        let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("@"); } LIT.with(|lit| lit.clone()) };
                        v12.clone()
                    } else {
                        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) };
                        v13.clone()
                    }
                }
            };
            let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), v16.clone()));
            let v18: i32 = v3.wrapping_add(1i32);
            let v19: i32 = v3.wrapping_rem(v1);
            let v20: i32 = v1.wrapping_sub(1i32);
            let v21: bool = v19 == v20;
            let v23: bool = if v21 {
                let v22: bool = v18 < v2;
                v22
            } else {
                false
            };
            if v23 {
                let v24: Rc<str> = Rc::<str>::from(format!("{}{}", v17.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                (v0, v1, v2, v3, v4) = (v0.clone(), v1, v2, v18, v24.clone());
                continue;
            } else {
                (v0, v1, v2, v3, v4) = (v0.clone(), v1, v2, v18, v17.clone());
                continue;
            }
        }
    }
}
fn runtime_byte_8(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let mut v2: u8 = v0.as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_7(mut v0: Rc<str>, mut v1: i32) -> i32 {
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: bool = v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let v5: bool = v1 >= v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let v7: u8 = runtime_byte_8(v0.clone(), v1);
            let v8: i32 = i32::from(v7);
            let v9: bool = v8 < 128i32;
            if v9 {
                v8
            } else {
                let v10: bool = v8 < 194i32;
                if v10 {
                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar starts with an invalid lead byte."); } LIT.with(|lit| lit.clone()) }))
                } else {
                    let v12: bool = v8 < 224i32;
                    if v12 {
                        let mut v13: i32 = v1.wrapping_add(1i32);
                        let v14: bool = v13 >= v2;
                        if v14 {
                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                        } else {
                            let v16: u8 = runtime_byte_8(v0.clone(), v13);
                            let v17: i32 = i32::from(v16);
                            let v18: bool = v17 < 128i32;
                            let v20: bool = if v18 {
                                false
                            } else {
                                let v19: bool = v17 < 192i32;
                                v19
                            };
                            if v20 {
                                let v21: i32 = v8.wrapping_sub(192i32);
                                let v22: i32 = v21.wrapping_mul(64i32);
                                let v23: i32 = v17.wrapping_sub(128i32);
                                let v24: i32 = v22.wrapping_add(v23);
                                v24
                            } else {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence has an invalid continuation byte."); } LIT.with(|lit| lit.clone()) }))
                            }
                        }
                    } else {
                        let v28: bool = v8 < 240i32;
                        if v28 {
                            let v29: i32 = v1.wrapping_add(2i32);
                            let v30: bool = v29 >= v2;
                            if v30 {
                                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                            } else {
                                let v32: i32 = v1.wrapping_add(1i32);
                                let v33: u8 = runtime_byte_8(v0.clone(), v32);
                                let v34: i32 = i32::from(v33);
                                let v35: u8 = runtime_byte_8(v0.clone(), v29);
                                let v36: i32 = i32::from(v35);
                                let v37: bool = v34 < 128i32;
                                let mut v39: bool = if v37 {
                                    false
                                } else {
                                    let mut v38: bool = v34 < 192i32;
                                    v38
                                };
                                if v39 {
                                    let v40: bool = v36 < 128i32;
                                    let v42: bool = if v40 {
                                        false
                                    } else {
                                        let v41: bool = v36 < 192i32;
                                        v41
                                    };
                                    if v42 {
                                        let v43: i32 = v8.wrapping_sub(224i32);
                                        let v44: i32 = v43.wrapping_mul(4096i32);
                                        let v45: i32 = v34.wrapping_sub(128i32);
                                        let v46: i32 = v45.wrapping_mul(64i32);
                                        let v47: i32 = v44.wrapping_add(v46);
                                        let v48: i32 = v36.wrapping_sub(128i32);
                                        let v49: i32 = v47.wrapping_add(v48);
                                        let v50: bool = v49 < 2048i32;
                                        if v50 {
                                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                        } else {
                                            let v52: bool = v49 >= 55296i32;
                                            if v52 {
                                                let v53: bool = v49 <= 57343i32;
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
                            let v63: bool = v8 < 245i32;
                            if v63 {
                                let v64: i32 = v1.wrapping_add(3i32);
                                let v65: bool = v64 >= v2;
                                if v65 {
                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                                } else {
                                    let v67: i32 = v1.wrapping_add(1i32);
                                    let v68: u8 = runtime_byte_8(v0.clone(), v67);
                                    let v69: i32 = i32::from(v68);
                                    let v70: i32 = v1.wrapping_add(2i32);
                                    let v71: u8 = runtime_byte_8(v0.clone(), v70);
                                    let v72: i32 = i32::from(v71);
                                    let v73: u8 = runtime_byte_8(v0.clone(), v64);
                                    let v74: i32 = i32::from(v73);
                                    let v75: bool = v69 < 128i32;
                                    let v77: bool = if v75 {
                                        false
                                    } else {
                                        let v76: bool = v69 < 192i32;
                                        v76
                                    };
                                    if v77 {
                                        let v78: bool = v72 < 128i32;
                                        let v80: bool = if v78 {
                                            false
                                        } else {
                                            let v79: bool = v72 < 192i32;
                                            v79
                                        };
                                        if v80 {
                                            let v81: bool = v74 < 128i32;
                                            let v83: bool = if v81 {
                                                false
                                            } else {
                                                let v82: bool = v74 < 192i32;
                                                v82
                                            };
                                            if v83 {
                                                let v84: i32 = v8.wrapping_sub(240i32);
                                                let v85: i32 = v84.wrapping_mul(262144i32);
                                                let v86: i32 = v69.wrapping_sub(128i32);
                                                let v87: i32 = v86.wrapping_mul(4096i32);
                                                let v88: i32 = v85.wrapping_add(v87);
                                                let v89: i32 = v72.wrapping_sub(128i32);
                                                let v90: i32 = v89.wrapping_mul(64i32);
                                                let v91: i32 = v88.wrapping_add(v90);
                                                let v92: i32 = v74.wrapping_sub(128i32);
                                                let v93: i32 = v91.wrapping_add(v92);
                                                let v94: bool = v93 < 65536i32;
                                                if v94 {
                                                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is overlong."); } LIT.with(|lit| lit.clone()) }))
                                                } else {
                                                    let v96: bool = v93 > 1114111i32;
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
fn loop_6(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let v4: bool = v2 == v1;
        if v4 {
            return v3;
        } else {
            let v5: bool = v2 > v1;
            if v5 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let v7: i32 = utf8_scalar_at_byte_offset_7(v0.clone(), v2);
                let v8: bool = v7 < 128i32;
                let mut v13: i32 = if v8 {
                    1i32
                } else {
                    let v9: bool = v7 < 2048i32;
                    if v9 {
                        2i32
                    } else {
                        let v10: bool = v7 < 65536i32;
                        if v10 {
                            3i32
                        } else {
                            4i32
                        }
                    }
                };
                let v14: i32 = v2.wrapping_add(v13);
                let v15: i32 = v3.wrapping_add(v7);
                (v0, v1, v2, v3) = (v0.clone(), v1, v14, v15);
                continue;
            }
        }
    }
}
fn method9(mut v0: i32) -> bool {
    let v1: bool = v0 < 4096i32;
    v1
}
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 7040i32 as usize]));
    let v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    let mut v2: i32 = 0i32;
    let mut v3: i32 = 0i32;
    while method0(v3) {
        let v5: bool = v3 == 0i32;
        let (mut v10, mut v11, mut v12): (f64, f64, f64) = if v5 {
            (0.0f64, 0.0f64, 0.0f64)
        } else {
            let v6: bool = v3 == 1i32;
            if v6 {
                (0.1f64, 0.05f64, 0.02f64)
            } else {
                (0.2f64, 0.1f64, 0.04f64)
            }
        };
        let mut v13: i32 = 0i32;
        while method1(v13) {
            v0.clone().borrow_mut()[v13 as usize] = 46i32;
            let v15: i32 = v13.wrapping_add(1i32);
            v13 = v15;
            ()
        };
        let v16: i32 = method2(v0.clone(), v10, v11, v12);
        let v17: i32 = method3(v0.clone(), v10, v11, v12);
        let v18: i32 = method4(v0.clone(), v10, v11, v12);
        let v19: i32 = 160i32;
        let v20: i32 = 7040i32;
        let v21: i32 = 0i32;
        let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        let v23: Rc<str> = frame_text_loop_5(v0.clone(), v19, v20, v21, v22.clone());
        let v24: i32 = (v23.clone().len() as i32);
        let v25: i32 = 0i32;
        let v26: i32 = 0i32;
        let v27: i32 = loop_6(v23.clone(), v24, v25, v26);
        let v28: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\u{1b}[H"); } LIT.with(|lit| lit.clone()) }, v23.clone()));
        print!("{}", v28.clone());
        let v29: i32 = v17.wrapping_mul(3i32);
        let v30: i32 = v16.wrapping_add(v29);
        let v31: i32 = v18.wrapping_mul(7i32);
        let v32: i32 = v30.wrapping_add(v31);
        let v33: bool = v24 == 7083i32;
        let v35: bool = if v33 {
            let v34: bool = v27 == 324274i32;
            v34
        } else {
            false
        };
        let v36: i32 = if v35 {
            v32
        } else {
            0i32
        };
        v1.clone().borrow_mut()[v3 as usize] = v36;
        let v37: bool = v3 < 2i32;
        if v37 {
            let mut v38: i32 = 0i32;
            let mut v39: i32 = v3.wrapping_add(1i32);
            while method9(v38) {
                let v41: i32 = v38.wrapping_rem(17i32);
                let v42: i32 = v39.wrapping_add(v41);
                let v43: i32 = v42.wrapping_add(1i32);
                let v44: i32 = v43.wrapping_rem(997i32);
                v39 = v44;
                let v45: i32 = v38.wrapping_add(1i32);
                v38 = v45;
                ()
            };
            let v46: i32 = v2.wrapping_add(v39);
            v2 = v46;
            ()
        };
        let v47: i32 = v3.wrapping_add(1i32);
        v3 = v47;
        ()
    };
    let v48: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let v49: i32 = v1.clone().borrow()[1i32 as usize].clone();
    let v50: i32 = v1.clone().borrow()[2i32 as usize].clone();
    let v51: bool = v48 == 45702i32;
    let v53: bool = if v51 {
        let v52: bool = v49 == 43786i32;
        v52
    } else {
        false
    };
    let v55: bool = if v53 {
        let v54: bool = v50 == 43631i32;
        v54
    } else {
        false
    };
    let v57: bool = if v55 {
        let v56: bool = v2 == 1931i32;
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
