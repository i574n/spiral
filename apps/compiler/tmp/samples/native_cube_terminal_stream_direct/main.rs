#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Hidden,
    US0_Visible(f64, f64, f64),
}
fn method0(mut v0: i32) -> bool {
    let mut v1: bool = v0 < 3i32;
    v1
}
fn method1(mut v0: i32) -> bool {
    let mut v1: bool = v0 < 7040i32;
    v1
}
fn method2(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let mut v4: f64 = (v1).sin();
    let mut v5: f64 = 20.0f64 * v4;
    let mut v6: f64 = (v2).sin();
    let mut v7: f64 = v5 * v6;
    let mut v8: f64 = (v3).cos();
    let mut v9: f64 = v7 * v8;
    let mut v10: f64 = (v1).cos();
    let mut v11: f64 = -20.0f64 * v10;
    let mut v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let mut v14: f64 = v9 - v13;
    let mut v15: f64 = 20.0f64 * v10;
    let mut v16: f64 = (v3).sin();
    let mut v17: f64 = v15 * v16;
    let mut v18: f64 = v14 + v17;
    let mut v19: f64 = -20.0f64 * v4;
    let mut v20: f64 = v19 * v16;
    let mut v21: f64 = v18 + v20;
    let mut v22: f64 = (v2).cos();
    let mut v23: f64 = 20.0f64 * v22;
    let mut v24: f64 = v23 * v8;
    let mut v25: f64 = v21 + v24;
    let mut v26: f64 = v15 * v8;
    let mut v27: f64 = v19 * v8;
    let mut v28: f64 = v26 + v27;
    let mut v29: f64 = v7 * v16;
    let mut v30: f64 = v28 - v29;
    let mut v31: f64 = v12 * v16;
    let mut v32: f64 = v30 + v31;
    let mut v33: f64 = v23 * v16;
    let mut v34: f64 = v32 - v33;
    let mut v35: f64 = v11 * v22;
    let mut v36: f64 = v5 * v22;
    let mut v37: f64 = v35 - v36;
    let mut v38: f64 = 20.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let mut v40: f64 = v39 + 100.0f64;
    let mut v41: f64 = 1.0f64 / v40;
    let mut v42: f64 = 40.0f64 * v41;
    let mut v43: f64 = v42 * v25;
    let mut v44: f64 = v43 * 2.0f64;
    let mut v45: f64 = 40.0f64 + v44;
    let mut v46: f64 = v42 * v34;
    let mut v47: f64 = 22.0f64 + v46;
    let mut v48: bool = v45 >= 0.0f64;
    let mut v50: bool = if v48 {
        let mut v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let mut v52: bool = if v50 {
        let mut v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let mut v54: bool = if v52 {
        let mut v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let mut v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let mut v58: f64 = *v58;
            let mut v59: f64 = *v59;
            let mut v60: f64 = *v60;
            let mut v61: bool = v58 >= 0.0f64;
            let mut v63: bool = if v61 {
                let mut v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let mut v65: bool = if v63 {
                let mut v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let mut v66: i32 = (v58 as i32);
                let mut v67: i32 = (v59 as i32);
                let mut v68: i32 = v67.wrapping_mul(160i32);
                let mut v69: i32 = v66.wrapping_add(v68);
                v0.clone().borrow_mut()[v69 as usize] = 35i32;
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
    let mut v4: f64 = (v1).sin();
    let mut v5: f64 = 10.0f64 * v4;
    let mut v6: f64 = (v2).sin();
    let mut v7: f64 = v5 * v6;
    let mut v8: f64 = (v3).cos();
    let mut v9: f64 = v7 * v8;
    let mut v10: f64 = (v1).cos();
    let mut v11: f64 = -10.0f64 * v10;
    let mut v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let mut v14: f64 = v9 - v13;
    let mut v15: f64 = 10.0f64 * v10;
    let mut v16: f64 = (v3).sin();
    let mut v17: f64 = v15 * v16;
    let mut v18: f64 = v14 + v17;
    let mut v19: f64 = -10.0f64 * v4;
    let mut v20: f64 = v19 * v16;
    let mut v21: f64 = v18 + v20;
    let mut v22: f64 = (v2).cos();
    let mut v23: f64 = 10.0f64 * v22;
    let mut v24: f64 = v23 * v8;
    let mut v25: f64 = v21 + v24;
    let mut v26: f64 = v15 * v8;
    let mut v27: f64 = v19 * v8;
    let mut v28: f64 = v26 + v27;
    let mut v29: f64 = v7 * v16;
    let mut v30: f64 = v28 - v29;
    let mut v31: f64 = v12 * v16;
    let mut v32: f64 = v30 + v31;
    let mut v33: f64 = v23 * v16;
    let mut v34: f64 = v32 - v33;
    let mut v35: f64 = v11 * v22;
    let mut v36: f64 = v5 * v22;
    let mut v37: f64 = v35 - v36;
    let mut v38: f64 = 10.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let mut v40: f64 = v39 + 100.0f64;
    let mut v41: f64 = 1.0f64 / v40;
    let mut v42: f64 = 40.0f64 * v41;
    let mut v43: f64 = v42 * v25;
    let mut v44: f64 = v43 * 2.0f64;
    let mut v45: f64 = 90.0f64 + v44;
    let mut v46: f64 = v42 * v34;
    let mut v47: f64 = 22.0f64 + v46;
    let mut v48: bool = v45 >= 0.0f64;
    let mut v50: bool = if v48 {
        let mut v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let mut v52: bool = if v50 {
        let mut v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let mut v54: bool = if v52 {
        let mut v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let mut v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let mut v58: f64 = *v58;
            let mut v59: f64 = *v59;
            let mut v60: f64 = *v60;
            let mut v61: bool = v58 >= 0.0f64;
            let mut v63: bool = if v61 {
                let mut v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let mut v65: bool = if v63 {
                let mut v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let mut v66: i32 = (v58 as i32);
                let mut v67: i32 = (v59 as i32);
                let mut v68: i32 = v67.wrapping_mul(160i32);
                let mut v69: i32 = v66.wrapping_add(v68);
                v0.clone().borrow_mut()[v69 as usize] = 64i32;
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
    let mut v4: f64 = (v1).sin();
    let mut v5: f64 = 5.0f64 * v4;
    let mut v6: f64 = (v2).sin();
    let mut v7: f64 = v5 * v6;
    let mut v8: f64 = (v3).cos();
    let mut v9: f64 = v7 * v8;
    let mut v10: f64 = (v1).cos();
    let mut v11: f64 = -5.0f64 * v10;
    let mut v12: f64 = v11 * v6;
    let mut v13: f64 = v12 * v8;
    let mut v14: f64 = v9 - v13;
    let mut v15: f64 = 5.0f64 * v10;
    let mut v16: f64 = (v3).sin();
    let mut v17: f64 = v15 * v16;
    let mut v18: f64 = v14 + v17;
    let mut v19: f64 = -5.0f64 * v4;
    let mut v20: f64 = v19 * v16;
    let mut v21: f64 = v18 + v20;
    let mut v22: f64 = (v2).cos();
    let mut v23: f64 = 5.0f64 * v22;
    let mut v24: f64 = v23 * v8;
    let mut v25: f64 = v21 + v24;
    let mut v26: f64 = v15 * v8;
    let mut v27: f64 = v19 * v8;
    let mut v28: f64 = v26 + v27;
    let mut v29: f64 = v7 * v16;
    let mut v30: f64 = v28 - v29;
    let mut v31: f64 = v12 * v16;
    let mut v32: f64 = v30 + v31;
    let mut v33: f64 = v23 * v16;
    let mut v34: f64 = v32 - v33;
    let mut v35: f64 = v11 * v22;
    let mut v36: f64 = v5 * v22;
    let mut v37: f64 = v35 - v36;
    let mut v38: f64 = 5.0f64 * v6;
    let mut v39: f64 = v37 + v38;
    let mut v40: f64 = v39 + 100.0f64;
    let mut v41: f64 = 1.0f64 / v40;
    let mut v42: f64 = 40.0f64 * v41;
    let mut v43: f64 = v42 * v25;
    let mut v44: f64 = v43 * 2.0f64;
    let mut v45: f64 = 120.0f64 + v44;
    let mut v46: f64 = v42 * v34;
    let mut v47: f64 = 22.0f64 + v46;
    let mut v48: bool = v45 >= 0.0f64;
    let mut v50: bool = if v48 {
        let mut v49: bool = v45 < 160.0f64;
        v49
    } else {
        false
    };
    let mut v52: bool = if v50 {
        let mut v51: bool = v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let mut v54: bool = if v52 {
        let mut v53: bool = v47 < 44.0f64;
        v53
    } else {
        false
    };
    let mut v57: US0 = if v54 {
        US0::US0_Visible(v45, v47, v41)
    } else {
        US0::US0_Hidden
    };
    match &v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let mut v58: f64 = *v58;
            let mut v59: f64 = *v59;
            let mut v60: f64 = *v60;
            let mut v61: bool = v58 >= 0.0f64;
            let mut v63: bool = if v61 {
                let mut v62: bool = v59 >= 0.0f64;
                v62
            } else {
                false
            };
            let mut v65: bool = if v63 {
                let mut v64: bool = v60 > 0.0f64;
                v64
            } else {
                false
            };
            if v65 {
                let mut v66: i32 = (v58 as i32);
                let mut v67: i32 = (v59 as i32);
                let mut v68: i32 = v67.wrapping_mul(160i32);
                let mut v69: i32 = v66.wrapping_add(v68);
                v0.clone().borrow_mut()[v69 as usize] = 43i32;
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
        let mut v5: bool = v3 == v2;
        if v5 {
            return v4.clone();
        } else {
            let mut v6: i32 = v0.clone().borrow()[v3 as usize].clone();
            let mut v7: bool = v6 == 35i32;
            let mut v16: Rc<str> = if v7 {
                let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("#"); } LIT.with(|lit| lit.clone()) };
                v8.clone()
            } else {
                let mut v9: bool = v6 == 43i32;
                if v9 {
                    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+"); } LIT.with(|lit| lit.clone()) };
                    v10.clone()
                } else {
                    let mut v11: bool = v6 == 64i32;
                    if v11 {
                        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("@"); } LIT.with(|lit| lit.clone()) };
                        v12.clone()
                    } else {
                        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) };
                        v13.clone()
                    }
                }
            };
            let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), v16.clone()));
            let mut v18: i32 = v3.wrapping_add(1i32);
            let mut v19: i32 = v3.wrapping_rem(v1);
            let mut v20: i32 = v1.wrapping_sub(1i32);
            let mut v21: bool = v19 == v20;
            let mut v23: bool = if v21 {
                let mut v22: bool = v18 < v2;
                v22
            } else {
                false
            };
            if v23 {
                let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v17.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
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
    let mut v2: u8 = v0.clone().as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_7(mut v0: Rc<str>, mut v1: i32) -> i32 {
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: bool = v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let mut v5: bool = v1 >= v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let mut v7: u8 = runtime_byte_8(v0.clone(), v1);
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
                            let mut v16: u8 = runtime_byte_8(v0.clone(), v13);
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
                                let mut v33: u8 = runtime_byte_8(v0.clone(), v32);
                                let mut v34: i32 = i32::from(v33);
                                let mut v35: u8 = runtime_byte_8(v0.clone(), v29);
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
                                    let mut v68: u8 = runtime_byte_8(v0.clone(), v67);
                                    let mut v69: i32 = i32::from(v68);
                                    let mut v70: i32 = v1.wrapping_add(2i32);
                                    let mut v71: u8 = runtime_byte_8(v0.clone(), v70);
                                    let mut v72: i32 = i32::from(v71);
                                    let mut v73: u8 = runtime_byte_8(v0.clone(), v64);
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
fn loop_6(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = v2 == v1;
        if v4 {
            return v3;
        } else {
            let mut v5: bool = v2 > v1;
            if v5 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let mut v7: i32 = utf8_scalar_at_byte_offset_7(v0.clone(), v2);
                let mut v8: bool = v7 < 128i32;
                let mut v13: i32 = if v8 {
                    1i32
                } else {
                    let mut v9: bool = v7 < 2048i32;
                    if v9 {
                        2i32
                    } else {
                        let mut v10: bool = v7 < 65536i32;
                        if v10 {
                            3i32
                        } else {
                            4i32
                        }
                    }
                };
                let mut v14: i32 = v2.wrapping_add(v13);
                let mut v15: i32 = v3.wrapping_add(v7);
                (v0, v1, v2, v3) = (v0.clone(), v1, v14, v15);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 7040i32 as usize]));
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    let mut v2: i32 = 0i32;
    while method0(v2) {
        let mut v4: bool = v2 == 0i32;
        let (mut v9, mut v10, mut v11): (f64, f64, f64) = if v4 {
            (0.0f64, 0.0f64, 0.0f64)
        } else {
            let mut v5: bool = v2 == 1i32;
            if v5 {
                (0.1f64, 0.05f64, 0.02f64)
            } else {
                (0.2f64, 0.1f64, 0.04f64)
            }
        };
        let mut v12: i32 = 0i32;
        while method1(v12) {
            v0.clone().borrow_mut()[v12 as usize] = 46i32;
            let mut v14: i32 = v12.wrapping_add(1i32);
            v12 = v14;
            ()
        };
        let mut v15: i32 = method2(v0.clone(), v9, v10, v11);
        let mut v16: i32 = method3(v0.clone(), v9, v10, v11);
        let mut v17: i32 = method4(v0.clone(), v9, v10, v11);
        let mut v18: i32 = 160i32;
        let mut v19: i32 = 7040i32;
        let mut v20: i32 = 0i32;
        let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        let mut v22: Rc<str> = frame_text_loop_5(v0.clone(), v18, v19, v20, v21.clone());
        let mut v23: i32 = (v22.clone().len() as i32);
        let mut v24: i32 = 0i32;
        let mut v25: i32 = 0i32;
        let mut v26: i32 = loop_6(v22.clone(), v23, v24, v25);
        let mut v27: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\u{1b}[H"); } LIT.with(|lit| lit.clone()) }, v22.clone()));
        print!("{}", v27.clone());
        let mut v28: i32 = v16.wrapping_mul(3i32);
        let mut v29: i32 = v15.wrapping_add(v28);
        let mut v30: i32 = v17.wrapping_mul(7i32);
        let mut v31: i32 = v29.wrapping_add(v30);
        let mut v32: bool = v23 == 7083i32;
        let mut v34: bool = if v32 {
            let mut v33: bool = v26 == 324274i32;
            v33
        } else {
            false
        };
        let mut v35: i32 = if v34 {
            v31
        } else {
            0i32
        };
        v1.clone().borrow_mut()[v2 as usize] = v35;
        let mut v36: i32 = v2.wrapping_add(1i32);
        v2 = v36;
        ()
    };
    let mut v37: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let mut v38: i32 = v1.clone().borrow()[1i32 as usize].clone();
    let mut v39: i32 = v1.clone().borrow()[2i32 as usize].clone();
    let mut v40: bool = v37 == 45702i32;
    let mut v42: bool = if v40 {
        let mut v41: bool = v38 == 43786i32;
        v41
    } else {
        false
    };
    let mut v44: bool = if v42 {
        let mut v43: bool = v39 == 43631i32;
        v43
    } else {
        false
    };
    if v44 {
        42i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
