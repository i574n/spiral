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
fn utf8_canonical_equal_bounded_loop_0(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32, mut v5: i32, mut v6: i32, mut v7: i32) -> bool {
    loop {
        let mut v8: bool = v4 >= 0i32;
        let (mut v76, mut v77, mut v78): (i32, i32, i32) = if v8 {
            (v4, v2, -1i32)
        } else {
            let mut v9: bool = v2 == v6;
            if v9 {
                (-1i32, v2, -1i32)
            } else {
                let mut v10: bool = v2 > v6;
                if v10 {
                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 canonical stream offset exceeds the string."); } LIT.with(|lit| lit.clone()) }))
                } else {
                    let mut v14: i32 = utf8_scalar_at_byte_offset_1(v0.clone(), v2);
                    let mut v15: bool = v14 < 128i32;
                    let mut v20: i32 = if v15 {
                        1i32
                    } else {
                        let mut v16: bool = v14 < 2048i32;
                        if v16 {
                            2i32
                        } else {
                            let mut v17: bool = v14 < 65536i32;
                            if v17 {
                                3i32
                            } else {
                                4i32
                            }
                        }
                    };
                    let mut v21: bool = v14 == 192i32;
                    let (mut v67, mut v68): (i32, i32) = if v21 {
                        (65i32, 768i32)
                    } else {
                        let mut v22: bool = v14 == 193i32;
                        if v22 {
                            (65i32, 769i32)
                        } else {
                            let mut v23: bool = v14 == 195i32;
                            if v23 {
                                (65i32, 771i32)
                            } else {
                                let mut v24: bool = v14 == 196i32;
                                if v24 {
                                    (65i32, 776i32)
                                } else {
                                    let mut v25: bool = v14 == 199i32;
                                    if v25 {
                                        (67i32, 807i32)
                                    } else {
                                        let mut v26: bool = v14 == 201i32;
                                        if v26 {
                                            (69i32, 769i32)
                                        } else {
                                            let mut v27: bool = v14 == 211i32;
                                            if v27 {
                                                (79i32, 769i32)
                                            } else {
                                                let mut v28: bool = v14 == 213i32;
                                                if v28 {
                                                    (79i32, 771i32)
                                                } else {
                                                    let mut v29: bool = v14 == 224i32;
                                                    if v29 {
                                                        (97i32, 768i32)
                                                    } else {
                                                        let mut v30: bool = v14 == 225i32;
                                                        if v30 {
                                                            (97i32, 769i32)
                                                        } else {
                                                            let mut v31: bool = v14 == 227i32;
                                                            if v31 {
                                                                (97i32, 771i32)
                                                            } else {
                                                                let mut v32: bool = v14 == 228i32;
                                                                if v32 {
                                                                    (97i32, 776i32)
                                                                } else {
                                                                    let mut v33: bool = v14 == 231i32;
                                                                    if v33 {
                                                                        (99i32, 807i32)
                                                                    } else {
                                                                        let mut v34: bool = v14 == 233i32;
                                                                        if v34 {
                                                                            (101i32, 769i32)
                                                                        } else {
                                                                            let mut v35: bool = v14 == 243i32;
                                                                            if v35 {
                                                                                (111i32, 769i32)
                                                                            } else {
                                                                                let mut v36: bool = v14 == 245i32;
                                                                                if v36 {
                                                                                    (111i32, 771i32)
                                                                                } else {
                                                                                    (v14, -1i32)
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
                    };
                    let mut v69: i32 = v2.wrapping_add(v20);
                    (v67, v69, v68)
                }
            }
        };
        let mut v79: bool = v5 >= 0i32;
        let (mut v147, mut v148, mut v149): (i32, i32, i32) = if v79 {
            (v5, v3, -1i32)
        } else {
            let mut v80: bool = v3 == v7;
            if v80 {
                (-1i32, v3, -1i32)
            } else {
                let mut v81: bool = v3 > v7;
                if v81 {
                    std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 canonical stream offset exceeds the string."); } LIT.with(|lit| lit.clone()) }))
                } else {
                    let mut v85: i32 = utf8_scalar_at_byte_offset_1(v1.clone(), v3);
                    let mut v86: bool = v85 < 128i32;
                    let mut v91: i32 = if v86 {
                        1i32
                    } else {
                        let mut v87: bool = v85 < 2048i32;
                        if v87 {
                            2i32
                        } else {
                            let mut v88: bool = v85 < 65536i32;
                            if v88 {
                                3i32
                            } else {
                                4i32
                            }
                        }
                    };
                    let mut v92: bool = v85 == 192i32;
                    let (mut v138, mut v139): (i32, i32) = if v92 {
                        (65i32, 768i32)
                    } else {
                        let mut v93: bool = v85 == 193i32;
                        if v93 {
                            (65i32, 769i32)
                        } else {
                            let mut v94: bool = v85 == 195i32;
                            if v94 {
                                (65i32, 771i32)
                            } else {
                                let mut v95: bool = v85 == 196i32;
                                if v95 {
                                    (65i32, 776i32)
                                } else {
                                    let mut v96: bool = v85 == 199i32;
                                    if v96 {
                                        (67i32, 807i32)
                                    } else {
                                        let mut v97: bool = v85 == 201i32;
                                        if v97 {
                                            (69i32, 769i32)
                                        } else {
                                            let mut v98: bool = v85 == 211i32;
                                            if v98 {
                                                (79i32, 769i32)
                                            } else {
                                                let mut v99: bool = v85 == 213i32;
                                                if v99 {
                                                    (79i32, 771i32)
                                                } else {
                                                    let mut v100: bool = v85 == 224i32;
                                                    if v100 {
                                                        (97i32, 768i32)
                                                    } else {
                                                        let mut v101: bool = v85 == 225i32;
                                                        if v101 {
                                                            (97i32, 769i32)
                                                        } else {
                                                            let mut v102: bool = v85 == 227i32;
                                                            if v102 {
                                                                (97i32, 771i32)
                                                            } else {
                                                                let mut v103: bool = v85 == 228i32;
                                                                if v103 {
                                                                    (97i32, 776i32)
                                                                } else {
                                                                    let mut v104: bool = v85 == 231i32;
                                                                    if v104 {
                                                                        (99i32, 807i32)
                                                                    } else {
                                                                        let mut v105: bool = v85 == 233i32;
                                                                        if v105 {
                                                                            (101i32, 769i32)
                                                                        } else {
                                                                            let mut v106: bool = v85 == 243i32;
                                                                            if v106 {
                                                                                (111i32, 769i32)
                                                                            } else {
                                                                                let mut v107: bool = v85 == 245i32;
                                                                                if v107 {
                                                                                    (111i32, 771i32)
                                                                                } else {
                                                                                    (v85, -1i32)
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
                    };
                    let mut v140: i32 = v3.wrapping_add(v91);
                    (v138, v140, v139)
                }
            }
        };
        let mut v150: bool = v76 < 0i32;
        if v150 {
            let mut v151: bool = v147 == -1i32;
            return v151;
        } else {
            let mut v152: bool = v147 < 0i32;
            if v152 {
                return false;
            } else {
                let mut v153: bool = v76 == v147;
                if v153 {
                    (v0, v1, v2, v3, v4, v5, v6, v7) = (v0.clone(), v1.clone(), v77, v148, v78, v149, v6, v7);
                    continue;
                } else {
                    return false;
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("plain"); } LIT.with(|lit| lit.clone()) };
    let mut v1: i32 = 0i32;
    let mut v2: i32 = 0i32;
    let mut v3: i32 = -1i32;
    let mut v4: i32 = -1i32;
    let mut v5: i32 = 5i32;
    let mut v6: i32 = 5i32;
    let mut v7: bool = utf8_canonical_equal_bounded_loop_0(v0.clone(), v0.clone(), v1, v2, v3, v4, v5, v6);
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v9: i32 = 0i32;
    let mut v10: i32 = 0i32;
    let mut v11: i32 = -1i32;
    let mut v12: i32 = -1i32;
    let mut v13: i32 = 0i32;
    let mut v14: i32 = 0i32;
    let mut v15: bool = utf8_canonical_equal_bounded_loop_0(v8.clone(), v8.clone(), v9, v10, v11, v12, v13, v14);
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("éõç"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("éõç"); } LIT.with(|lit| lit.clone()) };
    let mut v18: i32 = 0i32;
    let mut v19: i32 = 0i32;
    let mut v20: i32 = -1i32;
    let mut v21: i32 = -1i32;
    let mut v22: i32 = 6i32;
    let mut v23: i32 = 9i32;
    let mut v24: bool = utf8_canonical_equal_bounded_loop_0(v16.clone(), v17.clone(), v18, v19, v20, v21, v22, v23);
    let mut v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é̃"); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é̃"); } LIT.with(|lit| lit.clone()) };
    let mut v27: i32 = 0i32;
    let mut v28: i32 = 0i32;
    let mut v29: i32 = -1i32;
    let mut v30: i32 = -1i32;
    let mut v31: i32 = 4i32;
    let mut v32: i32 = 5i32;
    let mut v33: bool = utf8_canonical_equal_bounded_loop_0(v25.clone(), v26.clone(), v27, v28, v29, v30, v31, v32);
    let mut v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("À"); } LIT.with(|lit| lit.clone()) };
    let mut v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("À"); } LIT.with(|lit| lit.clone()) };
    let mut v36: i32 = 0i32;
    let mut v37: i32 = 0i32;
    let mut v38: i32 = -1i32;
    let mut v39: i32 = -1i32;
    let mut v40: i32 = 2i32;
    let mut v41: i32 = 3i32;
    let mut v42: bool = utf8_canonical_equal_bounded_loop_0(v34.clone(), v35.clone(), v36, v37, v38, v39, v40, v41);
    let mut v43: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ω"); } LIT.with(|lit| lit.clone()) };
    let mut v44: i32 = 0i32;
    let mut v45: i32 = 0i32;
    let mut v46: i32 = -1i32;
    let mut v47: i32 = -1i32;
    let mut v48: i32 = 2i32;
    let mut v49: i32 = 2i32;
    let mut v50: bool = utf8_canonical_equal_bounded_loop_0(v43.clone(), v43.clone(), v44, v45, v46, v47, v48, v49);
    let mut v51: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ẽ́"); } LIT.with(|lit| lit.clone()) };
    let mut v52: i32 = 0i32;
    let mut v53: i32 = 0i32;
    let mut v54: i32 = -1i32;
    let mut v55: i32 = -1i32;
    let mut v56: i32 = 5i32;
    let mut v57: i32 = 5i32;
    let mut v58: bool = utf8_canonical_equal_bounded_loop_0(v26.clone(), v51.clone(), v52, v53, v54, v55, v56, v57);
    let mut v59: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let mut v60: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("á"); } LIT.with(|lit| lit.clone()) };
    let mut v61: i32 = 0i32;
    let mut v62: i32 = 0i32;
    let mut v63: i32 = -1i32;
    let mut v64: i32 = -1i32;
    let mut v65: i32 = 2i32;
    let mut v66: i32 = 2i32;
    let mut v67: bool = utf8_canonical_equal_bounded_loop_0(v59.clone(), v60.clone(), v61, v62, v63, v64, v65, v66);
    let mut v68: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ω"); } LIT.with(|lit| lit.clone()) };
    let mut v69: i32 = 0i32;
    let mut v70: i32 = 0i32;
    let mut v71: i32 = -1i32;
    let mut v72: i32 = -1i32;
    let mut v73: i32 = 2i32;
    let mut v74: i32 = 2i32;
    let mut v75: bool = utf8_canonical_equal_bounded_loop_0(v43.clone(), v68.clone(), v69, v70, v71, v72, v73, v74);
    let mut v76: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e"); } LIT.with(|lit| lit.clone()) };
    let mut v77: i32 = 0i32;
    let mut v78: i32 = 0i32;
    let mut v79: i32 = -1i32;
    let mut v80: i32 = -1i32;
    let mut v81: i32 = 2i32;
    let mut v82: i32 = 1i32;
    let mut v83: bool = utf8_canonical_equal_bounded_loop_0(v59.clone(), v76.clone(), v77, v78, v79, v80, v81, v82);
    if v7 {
        if v15 {
            if v24 {
                if v33 {
                    if v42 {
                        if v50 {
                            if v58 {
                                7i32
                            } else {
                                if v67 {
                                    8i32
                                } else {
                                    if v75 {
                                        9i32
                                    } else {
                                        if v83 {
                                            10i32
                                        } else {
                                            0i32
                                        }
                                    }
                                }
                            }
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
