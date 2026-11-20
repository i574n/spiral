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
fn method2(mut v0: &Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 20.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -20.0f64 * v10;
    let v12: f64 = v11 * v6;
    let v13: f64 = v12 * v8;
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
    let x_v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let y_v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let v38: f64 = 20.0f64 * v6;
    let v39: f64 = v37 + v38;
    let z_v40: f64 = v39 + 100.0f64;
    let ooz_v41: f64 = 1.0f64 / z_v40;
    let v42: f64 = 40.0f64 * ooz_v41;
    let v43: f64 = v42 * x_v25;
    let v44: f64 = v43 * 2.0f64;
    let xp_v45: f64 = 40.0f64 + v44;
    let v46: f64 = v42 * y_v34;
    let yp_v47: f64 = 22.0f64 + v46;
    let v48: bool = xp_v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = xp_v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = yp_v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = yp_v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(xp_v45, yp_v47, ooz_v41)
    } else {
        US0::US0_Hidden
    };
    match v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = v58;
            let v59: f64 = v59;
            let v60: f64 = v60;
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
                let ix_v66: i32 = (v58 as i32);
                let iy_v67: i32 = (v59 as i32);
                let v68: i32 = iy_v67.wrapping_mul(160i32);
                let idx_v69: i32 = ix_v66.wrapping_add(v68);
                v0.borrow_mut()[idx_v69 as usize] = 35i32;
                idx_v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
}
fn method3(mut v0: &Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 10.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -10.0f64 * v10;
    let v12: f64 = v11 * v6;
    let v13: f64 = v12 * v8;
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
    let x_v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let y_v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let v38: f64 = 10.0f64 * v6;
    let v39: f64 = v37 + v38;
    let z_v40: f64 = v39 + 100.0f64;
    let ooz_v41: f64 = 1.0f64 / z_v40;
    let v42: f64 = 40.0f64 * ooz_v41;
    let v43: f64 = v42 * x_v25;
    let v44: f64 = v43 * 2.0f64;
    let xp_v45: f64 = 90.0f64 + v44;
    let v46: f64 = v42 * y_v34;
    let yp_v47: f64 = 22.0f64 + v46;
    let v48: bool = xp_v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = xp_v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = yp_v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = yp_v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(xp_v45, yp_v47, ooz_v41)
    } else {
        US0::US0_Hidden
    };
    match v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = v58;
            let v59: f64 = v59;
            let v60: f64 = v60;
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
                let ix_v66: i32 = (v58 as i32);
                let iy_v67: i32 = (v59 as i32);
                let v68: i32 = iy_v67.wrapping_mul(160i32);
                let idx_v69: i32 = ix_v66.wrapping_add(v68);
                v0.borrow_mut()[idx_v69 as usize] = 64i32;
                idx_v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
}
fn method4(mut v0: &Rc<RefCell<Vec<i32>>>, mut v1: f64, mut v2: f64, mut v3: f64) -> i32 {
    let v4: f64 = (v1).sin();
    let v5: f64 = 5.0f64 * v4;
    let v6: f64 = (v2).sin();
    let v7: f64 = v5 * v6;
    let v8: f64 = (v3).cos();
    let v9: f64 = v7 * v8;
    let v10: f64 = (v1).cos();
    let v11: f64 = -5.0f64 * v10;
    let v12: f64 = v11 * v6;
    let v13: f64 = v12 * v8;
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
    let x_v25: f64 = v21 + v24;
    let v26: f64 = v15 * v8;
    let v27: f64 = v19 * v8;
    let v28: f64 = v26 + v27;
    let v29: f64 = v7 * v16;
    let v30: f64 = v28 - v29;
    let v31: f64 = v12 * v16;
    let v32: f64 = v30 + v31;
    let v33: f64 = v23 * v16;
    let y_v34: f64 = v32 - v33;
    let v35: f64 = v11 * v22;
    let v36: f64 = v5 * v22;
    let v37: f64 = v35 - v36;
    let v38: f64 = 5.0f64 * v6;
    let v39: f64 = v37 + v38;
    let z_v40: f64 = v39 + 100.0f64;
    let ooz_v41: f64 = 1.0f64 / z_v40;
    let v42: f64 = 40.0f64 * ooz_v41;
    let v43: f64 = v42 * x_v25;
    let v44: f64 = v43 * 2.0f64;
    let xp_v45: f64 = 120.0f64 + v44;
    let v46: f64 = v42 * y_v34;
    let yp_v47: f64 = 22.0f64 + v46;
    let v48: bool = xp_v45 >= 0.0f64;
    let v50: bool = if v48 {
        let v49: bool = xp_v45 < 160.0f64;
        v49
    } else {
        false
    };
    let v52: bool = if v50 {
        let v51: bool = yp_v47 >= 0.0f64;
        v51
    } else {
        false
    };
    let v54: bool = if v52 {
        let v53: bool = yp_v47 < 44.0f64;
        v53
    } else {
        false
    };
    let v57: US0 = if v54 {
        US0::US0_Visible(xp_v45, yp_v47, ooz_v41)
    } else {
        US0::US0_Hidden
    };
    match v57 {
        US0::US0_Visible(v58, v59, v60) => {
            let v58: f64 = v58;
            let v59: f64 = v59;
            let v60: f64 = v60;
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
                let ix_v66: i32 = (v58 as i32);
                let iy_v67: i32 = (v59 as i32);
                let v68: i32 = iy_v67.wrapping_mul(160i32);
                let idx_v69: i32 = ix_v66.wrapping_add(v68);
                v0.borrow_mut()[idx_v69 as usize] = 43i32;
                idx_v69
            } else {
                0i32
            }
        }
        _ => {
            0i32
        }
    }
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
    let mut frame_v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 7040i32 as usize]));
    let mut checksums_v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    let mut step_v2: i32 = 0i32;
    while method0(step_v2) {
        let v4: bool = step_v2 == 0i32;
        let (mut draw_v9, mut draw_v10, mut draw_v11): (f64, f64, f64) = if v4 {
            (0.0f64, 0.0f64, 0.0f64)
        } else {
            let v5: bool = step_v2 == 1i32;
            if v5 {
                (0.1f64, 0.05f64, 0.02f64)
            } else {
                (0.2f64, 0.1f64, 0.04f64)
            }
        };
        let mut i_v12: i32 = 0i32;
        while method1(i_v12) {
            frame_v0.borrow_mut()[i_v12 as usize] = 46i32;
            let b_v14: i32 = i_v12.wrapping_add(1i32);
            i_v12 = b_v14;
            ()
        };
        let i0_v15: i32 = method2(&frame_v0, draw_v9, draw_v10, draw_v11);
        let i1_v16: i32 = method3(&frame_v0, draw_v9, draw_v10, draw_v11);
        let i2_v17: i32 = method4(&frame_v0, draw_v9, draw_v10, draw_v11);
        let width_v18: i32 = 160i32;
        let size_v19: i32 = 7040i32;
        let i_v20: i32 = 0i32;
        let text_v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        let text_v22: Rc<str> = frame_text_loop_5(&frame_v0, width_v18, size_v19, i_v20, text_v21);
        let text_length_v23: i32 = (text_v22.clone().len() as i32);
        let byte_offset_v24: i32 = 0i32;
        let state_v25: i32 = 0i32;
        let text_checksum_v26: i32 = loop_6(text_v22.clone(), text_length_v23, byte_offset_v24, state_v25);
        let output_v27: Rc<str> = string_concat(&["\u{1b}[H", &*text_v22]);
        print!("{}", output_v27);
        let v28: i32 = i1_v16.wrapping_mul(3i32);
        let v29: i32 = i0_v15.wrapping_add(v28);
        let v30: i32 = i2_v17.wrapping_mul(7i32);
        let spatial_checksum_v31: i32 = v29.wrapping_add(v30);
        let v32: bool = text_length_v23 == 7083i32;
        let v34: bool = if v32 {
            let v33: bool = text_checksum_v26 == 324274i32;
            v33
        } else {
            false
        };
        let v35: i32 = if v34 {
            spatial_checksum_v31
        } else {
            0i32
        };
        checksums_v1.borrow_mut()[step_v2 as usize] = v35;
        let b_v36: i32 = step_v2.wrapping_add(1i32);
        step_v2 = b_v36;
        ()
    };
    let c0_v37: i32 = checksums_v1.borrow()[0i32 as usize];
    let c1_v38: i32 = checksums_v1.borrow()[1i32 as usize];
    let c2_v39: i32 = checksums_v1.borrow()[2i32 as usize];
    let v40: bool = c0_v37 == 45702i32;
    let v42: bool = if v40 {
        let v41: bool = c1_v38 == 43786i32;
        v41
    } else {
        false
    };
    let v44: bool = if v42 {
        let v43: bool = c2_v39 == 43631i32;
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
