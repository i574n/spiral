#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn runtime_byte_1(mut v0: Rc<str>, mut v1: i32) -> u8 {
    let v2: u8 = v0.as_bytes()[v1 as usize];
    v2
}
fn utf8_scalar_at_byte_offset_0(mut v0: Rc<str>, mut v1: i32) -> i32 {
    let v2: i32 = (v0.clone().len() as i32);
    let v3: bool = v1 < 0i32;
    if v3 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is negative."); } LIT.with(|lit| lit.clone()) }))
    } else {
        let v5: bool = v1 >= v2;
        if v5 {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("UTF-8 byte offset is outside the string."); } LIT.with(|lit| lit.clone()) }))
        } else {
            let v7: u8 = runtime_byte_1(v0.clone(), v1);
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
                            let v16: u8 = runtime_byte_1(v0.clone(), v13);
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
                                let v33: u8 = runtime_byte_1(v0.clone(), v32);
                                let v34: i32 = i32::from(v33);
                                let v35: u8 = runtime_byte_1(v0.clone(), v29);
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
                                    let v68: u8 = runtime_byte_1(v0.clone(), v67);
                                    let v69: i32 = i32::from(v68);
                                    let v70: i32 = v1.wrapping_add(2i32);
                                    let v71: u8 = runtime_byte_1(v0.clone(), v70);
                                    let v72: i32 = i32::from(v71);
                                    let v73: u8 = runtime_byte_1(v0, v64);
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
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("é"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = 0i32;
    let v2: i32 = utf8_scalar_at_byte_offset_0(v0, v1);
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("õ"); } LIT.with(|lit| lit.clone()) };
    let v4: i32 = 0i32;
    let v5: i32 = utf8_scalar_at_byte_offset_0(v3, v4);
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ç"); } LIT.with(|lit| lit.clone()) };
    let v7: i32 = 0i32;
    let v8: i32 = utf8_scalar_at_byte_offset_0(v6, v7);
    let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("́"); } LIT.with(|lit| lit.clone()) };
    let v10: i32 = 0i32;
    let v11: i32 = utf8_scalar_at_byte_offset_0(v9, v10);
    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("̃"); } LIT.with(|lit| lit.clone()) };
    let v13: i32 = 0i32;
    let v14: i32 = utf8_scalar_at_byte_offset_0(v12, v13);
    let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("̧"); } LIT.with(|lit| lit.clone()) };
    let v16: i32 = 0i32;
    let v17: i32 = utf8_scalar_at_byte_offset_0(v15, v16);
    let v18: bool = v2 == 192i32;
    let (mut v64, mut v65): (i32, i32) = if v18 {
        (65i32, 768i32)
    } else {
        let v19: bool = v2 == 193i32;
        if v19 {
            (65i32, 769i32)
        } else {
            let v20: bool = v2 == 195i32;
            if v20 {
                (65i32, 771i32)
            } else {
                let v21: bool = v2 == 196i32;
                if v21 {
                    (65i32, 776i32)
                } else {
                    let v22: bool = v2 == 199i32;
                    if v22 {
                        (67i32, 807i32)
                    } else {
                        let v23: bool = v2 == 201i32;
                        if v23 {
                            (69i32, 769i32)
                        } else {
                            let v24: bool = v2 == 211i32;
                            if v24 {
                                (79i32, 769i32)
                            } else {
                                let v25: bool = v2 == 213i32;
                                if v25 {
                                    (79i32, 771i32)
                                } else {
                                    let v26: bool = v2 == 224i32;
                                    if v26 {
                                        (97i32, 768i32)
                                    } else {
                                        let v27: bool = v2 == 225i32;
                                        if v27 {
                                            (97i32, 769i32)
                                        } else {
                                            let v28: bool = v2 == 227i32;
                                            if v28 {
                                                (97i32, 771i32)
                                            } else {
                                                let v29: bool = v2 == 228i32;
                                                if v29 {
                                                    (97i32, 776i32)
                                                } else {
                                                    let v30: bool = v2 == 231i32;
                                                    if v30 {
                                                        (99i32, 807i32)
                                                    } else {
                                                        let v31: bool = v2 == 233i32;
                                                        if v31 {
                                                            (101i32, 769i32)
                                                        } else {
                                                            let v32: bool = v2 == 243i32;
                                                            if v32 {
                                                                (111i32, 769i32)
                                                            } else {
                                                                let v33: bool = v2 == 245i32;
                                                                if v33 {
                                                                    (111i32, 771i32)
                                                                } else {
                                                                    (v2, -1i32)
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
    let v66: bool = v5 == 192i32;
    let (mut v112, mut v113): (i32, i32) = if v66 {
        (65i32, 768i32)
    } else {
        let v67: bool = v5 == 193i32;
        if v67 {
            (65i32, 769i32)
        } else {
            let v68: bool = v5 == 195i32;
            if v68 {
                (65i32, 771i32)
            } else {
                let v69: bool = v5 == 196i32;
                if v69 {
                    (65i32, 776i32)
                } else {
                    let v70: bool = v5 == 199i32;
                    if v70 {
                        (67i32, 807i32)
                    } else {
                        let v71: bool = v5 == 201i32;
                        if v71 {
                            (69i32, 769i32)
                        } else {
                            let v72: bool = v5 == 211i32;
                            if v72 {
                                (79i32, 769i32)
                            } else {
                                let v73: bool = v5 == 213i32;
                                if v73 {
                                    (79i32, 771i32)
                                } else {
                                    let v74: bool = v5 == 224i32;
                                    if v74 {
                                        (97i32, 768i32)
                                    } else {
                                        let v75: bool = v5 == 225i32;
                                        if v75 {
                                            (97i32, 769i32)
                                        } else {
                                            let v76: bool = v5 == 227i32;
                                            if v76 {
                                                (97i32, 771i32)
                                            } else {
                                                let v77: bool = v5 == 228i32;
                                                if v77 {
                                                    (97i32, 776i32)
                                                } else {
                                                    let v78: bool = v5 == 231i32;
                                                    if v78 {
                                                        (99i32, 807i32)
                                                    } else {
                                                        let v79: bool = v5 == 233i32;
                                                        if v79 {
                                                            (101i32, 769i32)
                                                        } else {
                                                            let v80: bool = v5 == 243i32;
                                                            if v80 {
                                                                (111i32, 769i32)
                                                            } else {
                                                                let v81: bool = v5 == 245i32;
                                                                if v81 {
                                                                    (111i32, 771i32)
                                                                } else {
                                                                    (v5, -1i32)
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
    let v114: bool = v8 == 192i32;
    let (mut v160, mut v161): (i32, i32) = if v114 {
        (65i32, 768i32)
    } else {
        let v115: bool = v8 == 193i32;
        if v115 {
            (65i32, 769i32)
        } else {
            let v116: bool = v8 == 195i32;
            if v116 {
                (65i32, 771i32)
            } else {
                let v117: bool = v8 == 196i32;
                if v117 {
                    (65i32, 776i32)
                } else {
                    let v118: bool = v8 == 199i32;
                    if v118 {
                        (67i32, 807i32)
                    } else {
                        let v119: bool = v8 == 201i32;
                        if v119 {
                            (69i32, 769i32)
                        } else {
                            let v120: bool = v8 == 211i32;
                            if v120 {
                                (79i32, 769i32)
                            } else {
                                let v121: bool = v8 == 213i32;
                                if v121 {
                                    (79i32, 771i32)
                                } else {
                                    let v122: bool = v8 == 224i32;
                                    if v122 {
                                        (97i32, 768i32)
                                    } else {
                                        let v123: bool = v8 == 225i32;
                                        if v123 {
                                            (97i32, 769i32)
                                        } else {
                                            let v124: bool = v8 == 227i32;
                                            if v124 {
                                                (97i32, 771i32)
                                            } else {
                                                let v125: bool = v8 == 228i32;
                                                if v125 {
                                                    (97i32, 776i32)
                                                } else {
                                                    let v126: bool = v8 == 231i32;
                                                    if v126 {
                                                        (99i32, 807i32)
                                                    } else {
                                                        let v127: bool = v8 == 233i32;
                                                        if v127 {
                                                            (101i32, 769i32)
                                                        } else {
                                                            let v128: bool = v8 == 243i32;
                                                            if v128 {
                                                                (111i32, 769i32)
                                                            } else {
                                                                let v129: bool = v8 == 245i32;
                                                                if v129 {
                                                                    (111i32, 771i32)
                                                                } else {
                                                                    (v8, -1i32)
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
    let v162: bool = v11 == 769i32;
    let v163: i32 = if v162 {
        233i32
    } else {
        -1i32
    };
    let v164: bool = v163 < 0i32;
    let (mut v165, mut v166): (i32, i32) = if v164 {
        (101i32, v11)
    } else {
        (v163, -1i32)
    };
    let v167: bool = v14 == 769i32;
    let v170: i32 = if v167 {
        243i32
    } else {
        let v168: bool = v14 == 771i32;
        if v168 {
            245i32
        } else {
            -1i32
        }
    };
    let v171: bool = v170 < 0i32;
    let (mut v172, mut v173): (i32, i32) = if v171 {
        (111i32, v14)
    } else {
        (v170, -1i32)
    };
    let v174: bool = v17 == 807i32;
    let v175: i32 = if v174 {
        231i32
    } else {
        -1i32
    };
    let v176: bool = v175 < 0i32;
    let (mut v177, mut v178): (i32, i32) = if v176 {
        (99i32, v17)
    } else {
        (v175, -1i32)
    };
    let v179: bool = v64 == 101i32;
    let v181: bool = if v179 {
        let v180: bool = v65 == v11;
        v180
    } else {
        false
    };
    if v181 {
        let v182: bool = v112 == 111i32;
        let v184: bool = if v182 {
            let v183: bool = v113 == v14;
            v183
        } else {
            false
        };
        if v184 {
            let v185: bool = v160 == 99i32;
            let v187: bool = if v185 {
                let v186: bool = v161 == v17;
                v186
            } else {
                false
            };
            if v187 {
                let v188: bool = v165 == v2;
                let v190: bool = if v188 {
                    let v189: bool = v166 == -1i32;
                    v189
                } else {
                    false
                };
                if v190 {
                    let v191: bool = v172 == v5;
                    let v193: bool = if v191 {
                        let v192: bool = v173 == -1i32;
                        v192
                    } else {
                        false
                    };
                    if v193 {
                        let v194: bool = v177 == v8;
                        let v196: bool = if v194 {
                            let v195: bool = v178 == -1i32;
                            v195
                        } else {
                            false
                        };
                        if v196 {
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
