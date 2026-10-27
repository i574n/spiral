#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn runtime_byte_2(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let v2: u8 = v0.as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_1(mut v0: Rc<str>, mut v1: i32) -> i32 {
    let v2: i32 = (v0.clone().len() as i32);
    let v3: bool = v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let v5: bool = v1 >= v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let v7: u8 = runtime_byte_2(v0.clone(), v1);
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
                        let v13: i32 = v1.wrapping_add(1i32);
                        let v14: bool = v13 >= v2;
                        if v14 {
                            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 sequence is truncated."); } LIT.with(|lit| lit.clone()) }))
                        } else {
                            let v16: u8 = runtime_byte_2(v0.clone(), v13);
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
                                let v33: u8 = runtime_byte_2(v0.clone(), v32);
                                let v34: i32 = i32::from(v33);
                                let v35: u8 = runtime_byte_2(v0.clone(), v29);
                                let v36: i32 = i32::from(v35);
                                let v37: bool = v34 < 128i32;
                                let v39: bool = if v37 {
                                    false
                                } else {
                                    let v38: bool = v34 < 192i32;
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
                                    let v68: u8 = runtime_byte_2(v0.clone(), v67);
                                    let v69: i32 = i32::from(v68);
                                    let v70: i32 = v1.wrapping_add(2i32);
                                    let v71: u8 = runtime_byte_2(v0.clone(), v70);
                                    let v72: i32 = i32::from(v71);
                                    let v73: u8 = runtime_byte_2(v0.clone(), v64);
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
fn utf8_grapheme_count_bounded_loop_0(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let v4: bool = v1 == v3;
        if v4 {
            return v2;
        } else {
            let v5: bool = v1 > v3;
            if v5 {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 scalar width exceeds the string."); } LIT.with(|lit| lit.clone()) }));
            } else {
                let v7: i32 = utf8_scalar_at_byte_offset_1(v0.clone(), v1);
                let v8: bool = v7 < 128i32;
                let v13: i32 = if v8 {
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
                let v14: bool = v7 >= 768i32;
                let v44: bool = if v14 {
                    let v15: bool = v7 <= 879i32;
                    if v15 {
                        true
                    } else {
                        let v16: bool = v7 >= 6832i32;
                        if v16 {
                            let v17: bool = v7 <= 6911i32;
                            if v17 {
                                true
                            } else {
                                let v18: bool = v7 >= 7616i32;
                                if v18 {
                                    let v19: bool = v7 <= 7679i32;
                                    if v19 {
                                        true
                                    } else {
                                        let v20: bool = v7 >= 8400i32;
                                        if v20 {
                                            let v21: bool = v7 <= 8447i32;
                                            if v21 {
                                                true
                                            } else {
                                                let v22: bool = v7 >= 65024i32;
                                                if v22 {
                                                    let v23: bool = v7 <= 65039i32;
                                                    if v23 {
                                                        true
                                                    } else {
                                                        let v24: bool = v7 >= 65056i32;
                                                        if v24 {
                                                            let v25: bool = v7 <= 65071i32;
                                                            if v25 {
                                                                true
                                                            } else {
                                                                let v26: bool = v7 >= 127995i32;
                                                                if v26 {
                                                                    let v27: bool = v7 <= 127999i32;
                                                                    if v27 {
                                                                        true
                                                                    } else {
                                                                        let v28: bool = v7 >= 917760i32;
                                                                        if v28 {
                                                                            let v29: bool = v7 <= 917999i32;
                                                                            v29
                                                                        } else {
                                                                            false
                                                                        }
                                                                    }
                                                                } else {
                                                                    false
                                                                }
                                                            }
                                                        } else {
                                                            false
                                                        }
                                                    }
                                                } else {
                                                    false
                                                }
                                            }
                                        } else {
                                            false
                                        }
                                    }
                                } else {
                                    false
                                }
                            }
                        } else {
                            false
                        }
                    }
                } else {
                    false
                };
                let v48: i32 = if v44 {
                    let v45: bool = v2 == 0i32;
                    if v45 {
                        1i32
                    } else {
                        v2
                    }
                } else {
                    let v47: i32 = v2.wrapping_add(1i32);
                    v47
                };
                let v49: i32 = v1.wrapping_add(v13);
                (v0, v1, v2, v3) = (v0.clone(), v49, v48, v3);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aéé☕️👍🏽Z"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = 0i32;
    let v2: i32 = 0i32;
    let v3: i32 = 21i32;
    let v4: i32 = utf8_grapheme_count_bounded_loop_0(v0.clone(), v1, v2, v3);
    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("́̈A"); } LIT.with(|lit| lit.clone()) };
    let v6: i32 = 0i32;
    let v7: i32 = 0i32;
    let v8: i32 = 5i32;
    let v9: i32 = utf8_grapheme_count_bounded_loop_0(v5.clone(), v6, v7, v8);
    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Aé🙂Z"); } LIT.with(|lit| lit.clone()) };
    let v11: i32 = 4i32;
    let v12: i32 = utf8_scalar_at_byte_offset_1(v10.clone(), v11);
    let v13: bool = v12 >= 768i32;
    let v43: bool = if v13 {
        let v14: bool = v12 <= 879i32;
        if v14 {
            true
        } else {
            let v15: bool = v12 >= 6832i32;
            if v15 {
                let v16: bool = v12 <= 6911i32;
                if v16 {
                    true
                } else {
                    let v17: bool = v12 >= 7616i32;
                    if v17 {
                        let v18: bool = v12 <= 7679i32;
                        if v18 {
                            true
                        } else {
                            let v19: bool = v12 >= 8400i32;
                            if v19 {
                                let v20: bool = v12 <= 8447i32;
                                if v20 {
                                    true
                                } else {
                                    let v21: bool = v12 >= 65024i32;
                                    if v21 {
                                        let v22: bool = v12 <= 65039i32;
                                        if v22 {
                                            true
                                        } else {
                                            let v23: bool = v12 >= 65056i32;
                                            if v23 {
                                                let v24: bool = v12 <= 65071i32;
                                                if v24 {
                                                    true
                                                } else {
                                                    let v25: bool = v12 >= 127995i32;
                                                    if v25 {
                                                        let v26: bool = v12 <= 127999i32;
                                                        if v26 {
                                                            true
                                                        } else {
                                                            let v27: bool = v12 >= 917760i32;
                                                            if v27 {
                                                                let v28: bool = v12 <= 917999i32;
                                                                v28
                                                            } else {
                                                                false
                                                            }
                                                        }
                                                    } else {
                                                        false
                                                    }
                                                }
                                            } else {
                                                false
                                            }
                                        }
                                    } else {
                                        false
                                    }
                                }
                            } else {
                                false
                            }
                        }
                    } else {
                        false
                    }
                }
            } else {
                false
            }
        }
    } else {
        false
    };
    let v49: i32 = if v43 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 grapheme byte offset is inside a bounded grapheme cluster."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let v45: i32 = 4i32;
        let v46: i32 = 0i32;
        let v47: i32 = 9i32;
        utf8_grapheme_count_bounded_loop_0(v10.clone(), v45, v46, v47)
    };
    let v50: bool = v4 == 6i32;
    if v50 {
        let v51: bool = v9 == 2i32;
        if v51 {
            let v52: bool = v49 == 2i32;
            if v52 {
                0i32
            } else {
                4i32
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
