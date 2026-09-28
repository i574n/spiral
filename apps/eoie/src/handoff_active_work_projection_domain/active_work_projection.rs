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
fn method3() -> Rc<str> {
    let mut v0: Rc<str> = Rc::<str>::from("");
    v0.clone()
}
fn method2() -> Rc<str> {
    method3()
}
fn method4(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method5(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u8) -> i32 {
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
fn method7(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> bool {
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
fn method6(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
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
                method7(v0.clone(), v1.clone(), v2, v11, v8)
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
fn method8(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: Rc<str>, mut v4: bool) -> (Rc<str>, i32, bool) {
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
                            let mut v14: u8 = method4(v13.clone());
                            let mut v15: bool = v6 == v14 ;
                            if v15 {
                                v13.clone()
                            } else {
                                let mut v16: Rc<str> = Rc::<str>::from("\"");
                                let mut v17: u8 = method4(v16.clone());
                                let mut v18: bool = v6 == v17 ;
                                if v18 {
                                    v16.clone()
                                } else {
                                    method2()
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
                let mut v37: u8 = method4(v36.clone());
                let mut v38: bool = v6 == v37 ;
                if v38 {
                    let mut v39: i32 = v1 + 1i32 ;
                    let mut v40: bool = true;
                    (v0, v1, v2, v3, v4) = (v0.clone(), v39, v2, v3.clone(), v40);
                    continue;
                } else {
                    let mut v44: Rc<str> = Rc::<str>::from("\"");
                    let mut v45: u8 = method4(v44.clone());
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
fn method9(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 == 0i32 ;
        if v2 {
            return 0i32;
        } else {
            let mut v3: i32 = v1 - 1i32 ;
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
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
                (v0, v1) = (v0.clone(), v3);
                continue;
            } else {
                return v1;
            }
        }
    }
}
fn method11(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u64) -> bool {
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
fn method10(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: bool = v1 == 0i32 ;
    if v2 {
        method2()
    } else {
        let mut v4: i32 = 0i32;
        let mut v5: u64 = 0u64;
        let mut v6: bool = method11(v0.clone(), v4, v1, v5);
        if v6 {
            v0.clone()
        } else {
            method2()
        }
    }
}
fn method1(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: Rc<str>) -> Rc<str> {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return v3.clone();
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("\n");
            let mut v6: u8 = method4(v5.clone());
            let mut v7: i32 = (v0.clone().len() as i32);
            let mut v8: i32 = method5(v0.clone(), v1, v7, v6);
            let mut v9: bool = v1 == v8 ;
            let mut v13: Rc<str> = if v9 {
                method2()
            } else {
                let mut v11: i32 = v8 - 1i32 ;
                let mut v12: Rc<str> = string_slice(&v0.clone(), v1 as i64, v11 as i64);
                v12.clone()
            };
            let mut v14: i32 = (v13.clone().len() as i32);
            let mut v15: bool = v8 == v2 ;
            let mut v17: i32 = if v15 {
                v2
            } else {
                let mut v16: i32 = v8 + 1i32 ;
                v16
            };
            let mut v18: Rc<str> = Rc::<str>::from("Task (");
            let mut v19: i32 = 0i32;
            let mut v20: i32 = 6i32;
            let mut v21: i32 = method6(v13.clone(), v18.clone(), v19, v14, v20);
            let mut v22: bool = v21 < v14;
            let mut v23: Rc<str> = Rc::<str>::from(", Active,");
            let mut v24: i32 = 0i32;
            let mut v25: i32 = 9i32;
            let mut v26: i32 = method6(v13.clone(), v23.clone(), v24, v14, v25);
            let mut v27: bool = v26 < v14;
            let mut v28: Rc<str> = Rc::<str>::from(", Blocked,");
            let mut v29: i32 = 0i32;
            let mut v30: i32 = 10i32;
            let mut v31: i32 = method6(v13.clone(), v28.clone(), v29, v14, v30);
            let mut v32: bool = v31 < v14;
            let mut v34: bool = if v22 {
                let mut v33: bool = v27 || v32;
                v33
            } else {
                false
            };
            if v34 {
                let mut v35: Rc<str> = Rc::<str>::from("\"");
                let mut v36: u8 = method4(v35.clone());
                let mut v37: i32 = 0i32;
                let mut v38: i32 = method5(v13.clone(), v37, v14, v36);
                let mut v39: bool = v38 == v14 ;
                let mut v145: Rc<str> = if v39 {
                    method2()
                } else {
                    let mut v41: bool = v38 == v14 ;
                    let (mut v56, mut v57, mut v58): (Rc<str>, i32, bool) = if v41 {
                        let mut v42: Rc<str> = method2();
                        (v42.clone(), v38, false)
                    } else {
                        let mut v43: u8 = v13.clone().as_bytes()[v38 as usize];
                        let mut v44: u8 = method4(v35.clone());
                        let mut v45: bool = v43 == v44 ;
                        if v45 {
                            let mut v46: i32 = v38 + 1i32 ;
                            let mut v47: Rc<str> = Rc::<str>::from("");
                            let mut v48: bool = false;
                            method8(v13.clone(), v46, v14, v47.clone(), v48)
                        } else {
                            let mut v52: Rc<str> = method2();
                            (v52.clone(), v38, false)
                        }
                    };
                    if v58 {
                        let mut v59: u8 = method4(v35.clone());
                        let mut v60: i32 = method5(v13.clone(), v57, v14, v59);
                        let mut v61: bool = v60 == v14 ;
                        if v61 {
                            method2()
                        } else {
                            let mut v63: bool = v60 == v14 ;
                            let (mut v78, mut v79, mut v80): (Rc<str>, i32, bool) = if v63 {
                                let mut v64: Rc<str> = method2();
                                (v64.clone(), v60, false)
                            } else {
                                let mut v65: u8 = v13.clone().as_bytes()[v60 as usize];
                                let mut v66: u8 = method4(v35.clone());
                                let mut v67: bool = v65 == v66 ;
                                if v67 {
                                    let mut v68: i32 = v60 + 1i32 ;
                                    let mut v69: Rc<str> = Rc::<str>::from("");
                                    let mut v70: bool = false;
                                    method8(v13.clone(), v68, v14, v69.clone(), v70)
                                } else {
                                    let mut v74: Rc<str> = method2();
                                    (v74.clone(), v60, false)
                                }
                            };
                            let mut v82: bool = if v80 {
                                let mut v81: bool = v79 <= v14;
                                v81
                            } else {
                                false
                            };
                            if v82 {
                                let mut v83: Rc<str> = Rc::<str>::from("u32");
                                let mut v84: i32 = 3i32;
                                let mut v85: i32 = method6(v13.clone(), v83.clone(), v79, v14, v84);
                                let mut v86: bool = v85 == v14 ;
                                let mut v98: Rc<str> = if v86 {
                                    method2()
                                } else {
                                    let mut v88: i32 = method9(v13.clone(), v85);
                                    let mut v89: bool = v88 == v85 ;
                                    if v89 {
                                        method2()
                                    } else {
                                        let mut v91: bool = v88 == v85 ;
                                        let mut v95: Rc<str> = if v91 {
                                            method2()
                                        } else {
                                            let mut v93: i32 = v85 - 1i32 ;
                                            let mut v94: Rc<str> = string_slice(&v13.clone(), v88 as i64, v93 as i64);
                                            v94.clone()
                                        };
                                        method10(v95.clone())
                                    }
                                };
                                let mut v99: Rc<str> = Rc::<str>::from("");
                                let mut v100: bool = v98 == v99 ;
                                if v100 {
                                    method2()
                                } else {
                                    let mut v102: Rc<str> = Rc::<str>::from(", P0,");
                                    let mut v103: i32 = 0i32;
                                    let mut v104: i32 = 5i32;
                                    let mut v105: i32 = method6(v13.clone(), v102.clone(), v103, v14, v104);
                                    let mut v106: bool = v105 < v14;
                                    let mut v123: Rc<str> = if v106 {
                                        let mut v107: Rc<str> = Rc::<str>::from("P0");
                                        v107.clone()
                                    } else {
                                        let mut v108: Rc<str> = Rc::<str>::from(", P1,");
                                        let mut v109: i32 = 0i32;
                                        let mut v110: i32 = 5i32;
                                        let mut v111: i32 = method6(v13.clone(), v108.clone(), v109, v14, v110);
                                        let mut v112: bool = v111 < v14;
                                        if v112 {
                                            let mut v113: Rc<str> = Rc::<str>::from("P1");
                                            v113.clone()
                                        } else {
                                            let mut v114: Rc<str> = Rc::<str>::from(", P2,");
                                            let mut v115: i32 = 0i32;
                                            let mut v116: i32 = 5i32;
                                            let mut v117: i32 = method6(v13.clone(), v114.clone(), v115, v14, v116);
                                            let mut v118: bool = v117 < v14;
                                            if v118 {
                                                let mut v119: Rc<str> = Rc::<str>::from("P2");
                                                v119.clone()
                                            } else {
                                                let mut v120: Rc<str> = Rc::<str>::from("P3+");
                                                v120.clone()
                                            }
                                        }
                                    };
                                    let mut v124: i32 = 0i32;
                                    let mut v125: i32 = 10i32;
                                    let mut v126: i32 = method6(v13.clone(), v28.clone(), v124, v14, v125);
                                    let mut v127: bool = v126 < v14;
                                    let mut v130: Rc<str> = if v127 {
                                        let mut v128: Rc<str> = Rc::<str>::from("Blocked");
                                        v128.clone()
                                    } else {
                                        let mut v129: Rc<str> = Rc::<str>::from("Active");
                                        v129.clone()
                                    };
                                    let mut v131: Rc<str> = Rc::<str>::from(format!("{}{}", v123.clone(), Rc::<str>::from(" ")));
                                    let mut v132: Rc<str> = Rc::<str>::from(format!("{}{}", v131.clone(), v130.clone()));
                                    let mut v133: Rc<str> = Rc::<str>::from(format!("{}{}", v132.clone(), Rc::<str>::from(" ")));
                                    let mut v134: Rc<str> = Rc::<str>::from(format!("{}{}", v133.clone(), v98.clone()));
                                    let mut v135: Rc<str> = Rc::<str>::from(format!("{}{}", v134.clone(), Rc::<str>::from("% ")));
                                    let mut v136: Rc<str> = Rc::<str>::from(format!("{}{}", v135.clone(), v56.clone()));
                                    let mut v137: Rc<str> = Rc::<str>::from(format!("{}{}", v136.clone(), Rc::<str>::from(" — ")));
                                    let mut v138: Rc<str> = Rc::<str>::from(format!("{}{}", v137.clone(), v78.clone()));
                                    v138.clone()
                                }
                            } else {
                                method2()
                            }
                        }
                    } else {
                        method2()
                    }
                };
                let mut v146: Rc<str> = Rc::<str>::from("");
                let mut v147: bool = v145 == v146 ;
                if v147 {
                    return method2();
                } else {
                    let mut v149: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), Rc::<str>::from("\n")));
                    let mut v150: Rc<str> = Rc::<str>::from(format!("{}{}", v149.clone(), v145.clone()));
                    (v0, v1, v2, v3) = (v0.clone(), v17, v2, v150.clone());
                    continue;
                }
            } else {
                (v0, v1, v2, v3) = (v0.clone(), v17, v2, v3.clone());
                continue;
            }
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: Rc<str> = Rc::<str>::from("ok");
    method1(v0.clone(), v1, v2, v3.clone())
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
pub fn eoie_handoff_active_work_projection(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
