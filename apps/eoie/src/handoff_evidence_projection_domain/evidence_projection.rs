#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn method2() -> Rc<str> {
    let mut v0: Rc<str> = Rc::<str>::from("");
    v0.clone()
}
fn method1() -> Rc<str> {
    method2()
}
fn method4(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> bool {
    loop {
        let mut v5: bool = v3 == v4 ;
        if v5 {
            return true;
        } else {
            let mut v6: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v7: u8 = v1.clone().as_bytes()[v3 as usize];
            let mut v8: bool = v6 == v7 ;
            if v8 {
                let mut v9: i32 = v2 + 1i32 ;
                let mut v10: i32 = v3 + 1i32 ;
                (v0, v1, v2, v3, v4) = (v0.clone(), v1.clone(), v9, v10, v4);
                continue;
            } else {
                return false;
            }
        }
    }
}
fn method3(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
    loop {
        let mut v5: i32 = v2 + v4 ;
        let mut v6: bool = v3 < v5;
        if v6 {
            return v3;
        } else {
            let mut v7: i32 = (v0.clone().len() as i32);
            let mut v8: i32 = (v1.clone().len() as i32);
            let mut v9: i32 = v2 + v8 ;
            let mut v10: bool = v7 < v9;
            let mut v13: bool = if v10 {
                false
            } else {
                let mut v11: i32 = 0i32;
                method4(v0.clone(), v1.clone(), v2, v11, v8)
            };
            if v13 {
                return v2;
            } else {
                let mut v14: i32 = v2 + 1i32 ;
                (v0, v1, v2, v3, v4) = (v0.clone(), v1.clone(), v14, v3, v4);
                continue;
            }
        }
    }
}
fn method5(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method6(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u8) -> i32 {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return v2;
        } else {
            let mut v5: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v6: bool = v5 == v3 ;
            if v6 {
                return v1;
            } else {
                let mut v7: i32 = v1 + 1i32 ;
                (v0, v1, v2, v3) = (v0.clone(), v7, v2, v3);
                continue;
            }
        }
    }
}
fn method7(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: Rc<str>, mut v4: bool) -> (Rc<str>, i32, bool) {
    loop {
        let mut v5: bool = v1 == v2 ;
        if v5 {
            return (v3.clone(), v1, false);
        } else {
            let mut v6: u8 = v0.clone().as_bytes()[v1 as usize];
            if v4 {
                let mut v7: bool = v6 == b'n' ;
                let mut v24: Rc<str> = if v7 {
                    let mut v8: Rc<str> = Rc::<str>::from("\n");
                    v8.clone()
                } else {
                    let mut v9: bool = v6 == b'r' ;
                    if v9 {
                        let mut v10: Rc<str> = Rc::<str>::from("\r");
                        v10.clone()
                    } else {
                        let mut v11: bool = v6 == b't' ;
                        if v11 {
                            let mut v12: Rc<str> = Rc::<str>::from("\t");
                            v12.clone()
                        } else {
                            let mut v13: Rc<str> = Rc::<str>::from("\\");
                            let mut v14: u8 = method5(v13.clone());
                            let mut v15: bool = v6 == v14 ;
                            if v15 {
                                v13.clone()
                            } else {
                                let mut v16: Rc<str> = Rc::<str>::from("\"");
                                let mut v17: u8 = method5(v16.clone());
                                let mut v18: bool = v6 == v17 ;
                                if v18 {
                                    v16.clone()
                                } else {
                                    method1()
                                }
                            }
                        }
                    }
                };
                let mut v25: Rc<str> = Rc::<str>::from("");
                let mut v26: bool = v24 == v25 ;
                if v26 {
                    return (v3.clone(), v1, false);
                } else {
                    let mut v27: i32 = v1 + 1i32 ;
                    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), v24.clone()));
                    let mut v29: bool = false;
                    (v0, v1, v2, v3, v4) = (v0.clone(), v27, v2, v28.clone(), v29);
                    continue;
                }
            } else {
                let mut v36: Rc<str> = Rc::<str>::from("\\");
                let mut v37: u8 = method5(v36.clone());
                let mut v38: bool = v6 == v37 ;
                if v38 {
                    let mut v39: i32 = v1 + 1i32 ;
                    let mut v40: bool = true;
                    (v0, v1, v2, v3, v4) = (v0.clone(), v39, v2, v3.clone(), v40);
                    continue;
                } else {
                    let mut v44: Rc<str> = Rc::<str>::from("\"");
                    let mut v45: u8 = method5(v44.clone());
                    let mut v46: bool = v6 == v45 ;
                    if v46 {
                        let mut v47: i32 = v1 + 1i32 ;
                        return (v3.clone(), v47, true);
                    } else {
                        let mut v48: i32 = v1 + 1i32 ;
                        let mut v49: Rc<str> = string_slice(&v0.clone(), v1 as i64, v1 as i64);
                        let mut v50: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), v49.clone()));
                        let mut v51: bool = false;
                        (v0, v1, v2, v3, v4) = (v0.clone(), v48, v2, v50.clone(), v51);
                        continue;
                    }
                }
            }
        }
    }
}
fn method8(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v1 == v2 ;
        if v3 {
            return v2;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v5: bool = v4 == b'0' ;
            let mut v24: u64 = if v5 {
                0u64
            } else {
                let mut v6: bool = v4 == b'1' ;
                if v6 {
                    1u64
                } else {
                    let mut v7: bool = v4 == b'2' ;
                    if v7 {
                        2u64
                    } else {
                        let mut v8: bool = v4 == b'3' ;
                        if v8 {
                            3u64
                        } else {
                            let mut v9: bool = v4 == b'4' ;
                            if v9 {
                                4u64
                            } else {
                                let mut v10: bool = v4 == b'5' ;
                                if v10 {
                                    5u64
                                } else {
                                    let mut v11: bool = v4 == b'6' ;
                                    if v11 {
                                        6u64
                                    } else {
                                        let mut v12: bool = v4 == b'7' ;
                                        if v12 {
                                            7u64
                                        } else {
                                            let mut v13: bool = v4 == b'8' ;
                                            if v13 {
                                                8u64
                                            } else {
                                                let mut v14: bool = v4 == b'9' ;
                                                if v14 {
                                                    9u64
                                                } else {
                                                    10u64
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
            let mut v25: bool = v24 < 10u64;
            if v25 {
                return v1;
            } else {
                let mut v26: i32 = v1 + 1i32 ;
                (v0, v1, v2) = (v0.clone(), v26, v2);
                continue;
            }
        }
    }
}
fn method10(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u64) -> bool {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return true;
        } else {
            let mut v5: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v6: bool = v5 == b'0' ;
            let mut v25: u64 = if v6 {
                0u64
            } else {
                let mut v7: bool = v5 == b'1' ;
                if v7 {
                    1u64
                } else {
                    let mut v8: bool = v5 == b'2' ;
                    if v8 {
                        2u64
                    } else {
                        let mut v9: bool = v5 == b'3' ;
                        if v9 {
                            3u64
                        } else {
                            let mut v10: bool = v5 == b'4' ;
                            if v10 {
                                4u64
                            } else {
                                let mut v11: bool = v5 == b'5' ;
                                if v11 {
                                    5u64
                                } else {
                                    let mut v12: bool = v5 == b'6' ;
                                    if v12 {
                                        6u64
                                    } else {
                                        let mut v13: bool = v5 == b'7' ;
                                        if v13 {
                                            7u64
                                        } else {
                                            let mut v14: bool = v5 == b'8' ;
                                            if v14 {
                                                8u64
                                            } else {
                                                let mut v15: bool = v5 == b'9' ;
                                                if v15 {
                                                    9u64
                                                } else {
                                                    10u64
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
            let mut v26: bool = v25 == 10u64 ;
            if v26 {
                return false;
            } else {
                let mut v27: bool = v3 > 1844674407370955161u64;
                if v27 {
                    return false;
                } else {
                    let mut v28: bool = v3 == 1844674407370955161u64 ;
                    if v28 {
                        let mut v29: bool = v25 > 5u64;
                        if v29 {
                            return false;
                        } else {
                            let mut v30: i32 = v1 + 1i32 ;
                            let mut v31: u64 = v3 * 10u64 ;
                            let mut v32: u64 = v31 + v25 ;
                            (v0, v1, v2, v3) = (v0.clone(), v30, v2, v32);
                            continue;
                        }
                    } else {
                        let mut v35: i32 = v1 + 1i32 ;
                        let mut v36: u64 = v3 * 10u64 ;
                        let mut v37: u64 = v36 + v25 ;
                        (v0, v1, v2, v3) = (v0.clone(), v35, v2, v37);
                        continue;
                    }
                }
            }
        }
    }
}
fn method9(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: bool = v1 == 0i32 ;
    if v2 {
        method1()
    } else {
        let mut v4: i32 = 0i32;
        let mut v5: u64 = 0u64;
        let mut v6: bool = method10(v0.clone(), v4, v1, v5);
        if v6 {
            v0.clone()
        } else {
            method1()
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("SpiralCompilerEntrypoint, EvidenceRef (");
    let mut v3: i32 = 0i32;
    let mut v4: i32 = 39i32;
    let mut v5: i32 = method3(v0.clone(), v2.clone(), v3, v1, v4);
    let mut v6: bool = v5 == v1 ;
    let mut v16: Rc<str> = if v6 {
        method1()
    } else {
        let mut v8: Rc<str> = Rc::<str>::from("\n");
        let mut v9: u8 = method5(v8.clone());
        let mut v10: i32 = method6(v0.clone(), v5, v1, v9);
        let mut v11: bool = v5 == v10 ;
        if v11 {
            method1()
        } else {
            let mut v13: i32 = v10 - 1i32 ;
            let mut v14: Rc<str> = string_slice(&v0.clone(), v5 as i64, v13 as i64);
            v14.clone()
        }
    };
    let mut v17: i32 = (v16.clone().len() as i32);
    let mut v18: bool = v17 == 0i32 ;
    if v18 {
        method1()
    } else {
        let mut v20: Rc<str> = Rc::<str>::from("\"");
        let mut v21: u8 = method5(v20.clone());
        let mut v22: i32 = 0i32;
        let mut v23: i32 = method6(v16.clone(), v22, v17, v21);
        let mut v24: bool = v23 == v17 ;
        let (mut v79, mut v80, mut v81, mut v82): (Rc<str>, Rc<str>, i32, bool) = if v24 {
            let mut v25: Rc<str> = method1();
            let mut v26: Rc<str> = method1();
            (v25.clone(), v26.clone(), v17, false)
        } else {
            let mut v27: bool = v23 == v17 ;
            let (mut v42, mut v43, mut v44): (Rc<str>, i32, bool) = if v27 {
                let mut v28: Rc<str> = method1();
                (v28.clone(), v23, false)
            } else {
                let mut v29: u8 = v16.clone().as_bytes()[v23 as usize];
                let mut v30: u8 = method5(v20.clone());
                let mut v31: bool = v29 == v30 ;
                if v31 {
                    let mut v32: i32 = v23 + 1i32 ;
                    let mut v33: Rc<str> = Rc::<str>::from("");
                    let mut v34: bool = false;
                    method7(v16.clone(), v32, v17, v33.clone(), v34)
                } else {
                    let mut v38: Rc<str> = method1();
                    (v38.clone(), v23, false)
                }
            };
            let mut v45: bool = v44 == false ;
            if v45 {
                let mut v46: Rc<str> = method1();
                let mut v47: Rc<str> = method1();
                (v46.clone(), v47.clone(), v17, false)
            } else {
                let mut v48: u8 = method5(v20.clone());
                let mut v49: i32 = method6(v16.clone(), v43, v17, v48);
                let mut v50: bool = v49 == v17 ;
                if v50 {
                    let mut v51: Rc<str> = method1();
                    let mut v52: Rc<str> = method1();
                    (v51.clone(), v52.clone(), v17, false)
                } else {
                    let mut v53: bool = v49 == v17 ;
                    let (mut v68, mut v69, mut v70): (Rc<str>, i32, bool) = if v53 {
                        let mut v54: Rc<str> = method1();
                        (v54.clone(), v49, false)
                    } else {
                        let mut v55: u8 = v16.clone().as_bytes()[v49 as usize];
                        let mut v56: u8 = method5(v20.clone());
                        let mut v57: bool = v55 == v56 ;
                        if v57 {
                            let mut v58: i32 = v49 + 1i32 ;
                            let mut v59: Rc<str> = Rc::<str>::from("");
                            let mut v60: bool = false;
                            method7(v16.clone(), v58, v17, v59.clone(), v60)
                        } else {
                            let mut v64: Rc<str> = method1();
                            (v64.clone(), v49, false)
                        }
                    };
                    (v42.clone(), v68.clone(), v69, v70)
                }
            }
        };
        let mut v83: bool = v82 == false ;
        if v83 {
            method1()
        } else {
            let mut v85: i32 = method8(v16.clone(), v81, v17);
            let mut v86: bool = v85 == v17 ;
            if v86 {
                method1()
            } else {
                let mut v88: Rc<str> = Rc::<str>::from("u64");
                let mut v89: i32 = 3i32;
                let mut v90: i32 = method3(v16.clone(), v88.clone(), v85, v17, v89);
                let mut v91: bool = v90 == v17 ;
                if v91 {
                    method1()
                } else {
                    let mut v93: bool = v85 == v90 ;
                    let mut v97: Rc<str> = if v93 {
                        method1()
                    } else {
                        let mut v95: i32 = v90 - 1i32 ;
                        let mut v96: Rc<str> = string_slice(&v16.clone(), v85 as i64, v95 as i64);
                        v96.clone()
                    };
                    let mut v98: Rc<str> = method9(v97.clone());
                    let mut v99: Rc<str> = Rc::<str>::from("");
                    let mut v100: bool = v98 == v99 ;
                    if v100 {
                        method1()
                    } else {
                        let mut v102: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(" bytes="), v98.clone()));
                        let mut v103: Rc<str> = Rc::<str>::from(format!("{}{}", v80.clone(), v102.clone()));
                        let mut v104: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(" sha256="), v103.clone()));
                        let mut v105: Rc<str> = Rc::<str>::from(format!("{}{}", v79.clone(), v104.clone()));
                        let mut v106: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("spiral_compiler="), v105.clone()));
                        v106.clone()
                    }
                }
            }
        }
    }
}
fn method11(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("ColdReceiptClosed");
    let mut v3: i32 = 0i32;
    let mut v4: i32 = 17i32;
    let mut v5: i32 = method3(v0.clone(), v2.clone(), v3, v1, v4);
    let mut v6: Rc<str> = Rc::<str>::from("ColdReceiptPending");
    let mut v7: i32 = 0i32;
    let mut v8: i32 = 18i32;
    let mut v9: i32 = method3(v0.clone(), v6.clone(), v7, v1, v8);
    let mut v10: bool = v5 < v1;
    let mut v16: Rc<str> = if v10 {
        let mut v11: Rc<str> = Rc::<str>::from("closed");
        v11.clone()
    } else {
        let mut v12: bool = v9 < v1;
        if v12 {
            let mut v13: Rc<str> = Rc::<str>::from("pending");
            v13.clone()
        } else {
            let mut v14: Rc<str> = Rc::<str>::from("other");
            v14.clone()
        }
    };
    let mut v17: Rc<str> = Rc::<str>::from("inl current_cold_replay_flags");
    let mut v18: i32 = 0i32;
    let mut v19: i32 = 29i32;
    let mut v20: i32 = method3(v0.clone(), v17.clone(), v18, v1, v19);
    let mut v21: bool = v20 == v1 ;
    let mut v31: Rc<str> = if v21 {
        method1()
    } else {
        let mut v23: Rc<str> = Rc::<str>::from("\n");
        let mut v24: u8 = method5(v23.clone());
        let mut v25: i32 = method6(v0.clone(), v20, v1, v24);
        let mut v26: bool = v20 == v25 ;
        if v26 {
            method1()
        } else {
            let mut v28: i32 = v25 - 1i32 ;
            let mut v29: Rc<str> = string_slice(&v0.clone(), v20 as i64, v28 as i64);
            v29.clone()
        }
    };
    let mut v32: i32 = (v31.clone().len() as i32);
    let mut v33: bool = v32 == 0i32 ;
    let mut v58: Rc<str> = if v33 {
        method1()
    } else {
        let mut v35: i32 = 0i32;
        let mut v36: u8 = b'=';
        let mut v37: i32 = method6(v31.clone(), v35, v32, v36);
        let mut v38: bool = v37 == v32 ;
        if v38 {
            method1()
        } else {
            let mut v40: i32 = v37 + 1i32 ;
            let mut v41: i32 = method8(v31.clone(), v40, v32);
            let mut v42: bool = v41 == v32 ;
            if v42 {
                method1()
            } else {
                let mut v44: Rc<str> = Rc::<str>::from("u32");
                let mut v45: i32 = 3i32;
                let mut v46: i32 = method3(v31.clone(), v44.clone(), v41, v32, v45);
                let mut v47: bool = v46 == v32 ;
                if v47 {
                    method1()
                } else {
                    let mut v49: bool = v41 == v46 ;
                    let mut v53: Rc<str> = if v49 {
                        method1()
                    } else {
                        let mut v51: i32 = v46 - 1i32 ;
                        let mut v52: Rc<str> = string_slice(&v31.clone(), v41 as i64, v51 as i64);
                        v52.clone()
                    };
                    method9(v53.clone())
                }
            }
        }
    };
    let mut v59: Rc<str> = Rc::<str>::from("inl binary_gate");
    let mut v60: i32 = 0i32;
    let mut v61: i32 = 15i32;
    let mut v62: i32 = method3(v0.clone(), v59.clone(), v60, v1, v61);
    let mut v63: bool = v62 == v1 ;
    let mut v73: Rc<str> = if v63 {
        method1()
    } else {
        let mut v65: Rc<str> = Rc::<str>::from("\n");
        let mut v66: u8 = method5(v65.clone());
        let mut v67: i32 = method6(v0.clone(), v62, v1, v66);
        let mut v68: bool = v62 == v67 ;
        if v68 {
            method1()
        } else {
            let mut v70: i32 = v67 - 1i32 ;
            let mut v71: Rc<str> = string_slice(&v0.clone(), v62 as i64, v70 as i64);
            v71.clone()
        }
    };
    let mut v74: i32 = (v73.clone().len() as i32);
    let mut v75: Rc<str> = Rc::<str>::from("\"");
    let mut v76: u8 = method5(v75.clone());
    let mut v77: i32 = 0i32;
    let mut v78: i32 = method6(v73.clone(), v77, v74, v76);
    let mut v79: bool = v78 == v74 ;
    let (mut v134, mut v135, mut v136, mut v137): (Rc<str>, Rc<str>, i32, bool) = if v79 {
        let mut v80: Rc<str> = method1();
        let mut v81: Rc<str> = method1();
        (v80.clone(), v81.clone(), v74, false)
    } else {
        let mut v82: bool = v78 == v74 ;
        let (mut v97, mut v98, mut v99): (Rc<str>, i32, bool) = if v82 {
            let mut v83: Rc<str> = method1();
            (v83.clone(), v78, false)
        } else {
            let mut v84: u8 = v73.clone().as_bytes()[v78 as usize];
            let mut v85: u8 = method5(v75.clone());
            let mut v86: bool = v84 == v85 ;
            if v86 {
                let mut v87: i32 = v78 + 1i32 ;
                let mut v88: Rc<str> = Rc::<str>::from("");
                let mut v89: bool = false;
                method7(v73.clone(), v87, v74, v88.clone(), v89)
            } else {
                let mut v93: Rc<str> = method1();
                (v93.clone(), v78, false)
            }
        };
        let mut v100: bool = v99 == false ;
        if v100 {
            let mut v101: Rc<str> = method1();
            let mut v102: Rc<str> = method1();
            (v101.clone(), v102.clone(), v74, false)
        } else {
            let mut v103: u8 = method5(v75.clone());
            let mut v104: i32 = method6(v73.clone(), v98, v74, v103);
            let mut v105: bool = v104 == v74 ;
            if v105 {
                let mut v106: Rc<str> = method1();
                let mut v107: Rc<str> = method1();
                (v106.clone(), v107.clone(), v74, false)
            } else {
                let mut v108: bool = v104 == v74 ;
                let (mut v123, mut v124, mut v125): (Rc<str>, i32, bool) = if v108 {
                    let mut v109: Rc<str> = method1();
                    (v109.clone(), v104, false)
                } else {
                    let mut v110: u8 = v73.clone().as_bytes()[v104 as usize];
                    let mut v111: u8 = method5(v75.clone());
                    let mut v112: bool = v110 == v111 ;
                    if v112 {
                        let mut v113: i32 = v104 + 1i32 ;
                        let mut v114: Rc<str> = Rc::<str>::from("");
                        let mut v115: bool = false;
                        method7(v73.clone(), v113, v74, v114.clone(), v115)
                    } else {
                        let mut v119: Rc<str> = method1();
                        (v119.clone(), v104, false)
                    }
                };
                (v97.clone(), v123.clone(), v124, v125)
            }
        }
    };
    let mut v138: Rc<str> = Rc::<str>::from("");
    let mut v139: bool = v58 == v138 ;
    if v139 {
        method1()
    } else {
        let mut v141: bool = v137 == false ;
        if v141 {
            method1()
        } else {
            let mut v143: bool = v74 < v136;
            if v143 {
                method1()
            } else {
                let mut v145: Rc<str> = Rc::<str>::from("eoie");
                let mut v146: bool = v134 == v145 ;
                if v146 {
                    let mut v147: bool = v135 == v138 ;
                    if v147 {
                        method1()
                    } else {
                        let mut v149: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(" binary_sha256="), v135.clone()));
                        let mut v150: Rc<str> = Rc::<str>::from(format!("{}{}", v58.clone(), v149.clone()));
                        let mut v151: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(" replay_flags="), v150.clone()));
                        let mut v152: Rc<str> = Rc::<str>::from(format!("{}{}", v16.clone(), v151.clone()));
                        let mut v153: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("cold_proof="), v152.clone()));
                        v153.clone()
                    }
                } else {
                    method1()
                }
            }
        }
    }
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
fn closure1() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method11(v0.clone())
    })
}
pub fn eoie_handoff_toolchain_projection(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
pub fn eoie_handoff_cold_projection(v0: &str) -> Rc<str> {
    closure1()(Rc::<str>::from(v0))
}
