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
fn method9(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> bool {
    loop {
        let mut v3: bool = v1 == v2 ;
        if v3 {
            return false;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v5: Rc<str> = Rc::<str>::from(" ");
            let mut v6: u8 = method4(v5.clone());
            let mut v7: bool = v4 == v6 ;
            let mut v11: bool = if v7 {
                true
            } else {
                let mut v8: Rc<str> = Rc::<str>::from("\t");
                let mut v9: u8 = method4(v8.clone());
                let mut v10: bool = v4 == v9 ;
                v10
            };
            let mut v15: bool = if v11 {
                true
            } else {
                let mut v12: Rc<str> = Rc::<str>::from("\n");
                let mut v13: u8 = method4(v12.clone());
                let mut v14: bool = v4 == v13 ;
                v14
            };
            let mut v19: bool = if v15 {
                true
            } else {
                let mut v16: Rc<str> = Rc::<str>::from("\r");
                let mut v17: u8 = method4(v16.clone());
                let mut v18: bool = v4 == v17 ;
                v18
            };
            if v19 {
                let mut v20: i32 = v1 + 1i32 ;
                (v0, v1, v2) = (v0.clone(), v20, v2);
                continue;
            } else {
                return true;
            }
        }
    }
}
fn method10(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: Rc<str>) -> bool {
    loop {
        let mut v5: bool = v1 < v2;
        if v5 {
            let mut v6: Rc<str> = Rc::<str>::from("\n");
            let mut v7: u8 = method4(v6.clone());
            let mut v8: i32 = (v0.clone().len() as i32);
            let mut v9: i32 = method5(v0.clone(), v1, v8, v7);
            let mut v10: bool = v1 == v9 ;
            let mut v14: Rc<str> = if v10 {
                method2()
            } else {
                let mut v12: i32 = v9 - 1i32 ;
                let mut v13: Rc<str> = string_slice(&v0.clone(), v1 as i64, v12 as i64);
                v13.clone()
            };
            let mut v15: i32 = (v14.clone().len() as i32);
            let mut v16: bool = v9 == v3 ;
            let mut v18: i32 = if v16 {
                v3
            } else {
                let mut v17: i32 = v9 + 1i32 ;
                v17
            };
            let mut v19: Rc<str> = Rc::<str>::from("HandoffSection (");
            let mut v20: i32 = 0i32;
            let mut v21: i32 = 16i32;
            let mut v22: i32 = method6(v14.clone(), v19.clone(), v20, v15, v21);
            let mut v23: bool = v22 < v15;
            if v23 {
                let mut v24: Rc<str> = Rc::<str>::from("\"");
                let mut v25: u8 = method4(v24.clone());
                let mut v26: i32 = 0i32;
                let mut v27: i32 = method5(v14.clone(), v26, v15, v25);
                let mut v28: bool = v27 == v15 ;
                let mut v56: Rc<str> = if v28 {
                    method2()
                } else {
                    let mut v30: bool = v27 == v15 ;
                    let (mut v45, mut v46, mut v47): (Rc<str>, i32, bool) = if v30 {
                        let mut v31: Rc<str> = method2();
                        (v31.clone(), v27, false)
                    } else {
                        let mut v32: u8 = v14.clone().as_bytes()[v27 as usize];
                        let mut v33: u8 = method4(v24.clone());
                        let mut v34: bool = v32 == v33 ;
                        if v34 {
                            let mut v35: i32 = v27 + 1i32 ;
                            let mut v36: Rc<str> = Rc::<str>::from("");
                            let mut v37: bool = false;
                            method8(v14.clone(), v35, v15, v36.clone(), v37)
                        } else {
                            let mut v41: Rc<str> = method2();
                            (v41.clone(), v27, false)
                        }
                    };
                    let mut v49: bool = if v47 {
                        let mut v48: bool = v46 <= v15;
                        v48
                    } else {
                        false
                    };
                    let mut v53: bool = if v49 {
                        let mut v50: i32 = 0i32;
                        let mut v51: i32 = (v45.clone().len() as i32);
                        method9(v45.clone(), v50, v51)
                    } else {
                        false
                    };
                    if v53 {
                        v45.clone()
                    } else {
                        method2()
                    }
                };
                let mut v57: bool = v56 == v4 ;
                if v57 {
                    return true;
                } else {
                    (v0, v1, v2, v3, v4) = (v0.clone(), v18, v2, v3, v4.clone());
                    continue;
                }
            } else {
                (v0, v1, v2, v3, v4) = (v0.clone(), v18, v2, v3, v4.clone());
                continue;
            }
        } else {
            return false;
        }
    }
}
fn method1(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: Rc<str>) -> Rc<str> {
    loop {
        let mut v5: bool = v1 == v2 ;
        if v5 {
            let mut v6: bool = v3 < 4i32;
            if v6 {
                return method2();
            } else {
                let mut v8: bool = 10i32 < v3;
                if v8 {
                    return method2();
                } else {
                    return v4.clone();
                }
            }
        } else {
            let mut v12: Rc<str> = Rc::<str>::from("\n");
            let mut v13: u8 = method4(v12.clone());
            let mut v14: i32 = (v0.clone().len() as i32);
            let mut v15: i32 = method5(v0.clone(), v1, v14, v13);
            let mut v16: bool = v1 == v15 ;
            let mut v20: Rc<str> = if v16 {
                method2()
            } else {
                let mut v18: i32 = v15 - 1i32 ;
                let mut v19: Rc<str> = string_slice(&v0.clone(), v1 as i64, v18 as i64);
                v19.clone()
            };
            let mut v21: i32 = (v20.clone().len() as i32);
            let mut v22: bool = v15 == v2 ;
            let mut v24: i32 = if v22 {
                v2
            } else {
                let mut v23: i32 = v15 + 1i32 ;
                v23
            };
            let mut v25: Rc<str> = Rc::<str>::from("HandoffSection (");
            let mut v26: i32 = 0i32;
            let mut v27: i32 = 16i32;
            let mut v28: i32 = method6(v20.clone(), v25.clone(), v26, v21, v27);
            let mut v29: bool = v28 < v21;
            if v29 {
                let mut v30: Rc<str> = Rc::<str>::from("\"");
                let mut v31: u8 = method4(v30.clone());
                let mut v32: i32 = 0i32;
                let mut v33: i32 = method5(v20.clone(), v32, v21, v31);
                let mut v34: bool = v33 == v21 ;
                let mut v62: Rc<str> = if v34 {
                    method2()
                } else {
                    let mut v36: bool = v33 == v21 ;
                    let (mut v51, mut v52, mut v53): (Rc<str>, i32, bool) = if v36 {
                        let mut v37: Rc<str> = method2();
                        (v37.clone(), v33, false)
                    } else {
                        let mut v38: u8 = v20.clone().as_bytes()[v33 as usize];
                        let mut v39: u8 = method4(v30.clone());
                        let mut v40: bool = v38 == v39 ;
                        if v40 {
                            let mut v41: i32 = v33 + 1i32 ;
                            let mut v42: Rc<str> = Rc::<str>::from("");
                            let mut v43: bool = false;
                            method8(v20.clone(), v41, v21, v42.clone(), v43)
                        } else {
                            let mut v47: Rc<str> = method2();
                            (v47.clone(), v33, false)
                        }
                    };
                    let mut v55: bool = if v53 {
                        let mut v54: bool = v52 <= v21;
                        v54
                    } else {
                        false
                    };
                    let mut v59: bool = if v55 {
                        let mut v56: i32 = 0i32;
                        let mut v57: i32 = (v51.clone().len() as i32);
                        method9(v51.clone(), v56, v57)
                    } else {
                        false
                    };
                    if v59 {
                        v51.clone()
                    } else {
                        method2()
                    }
                };
                let mut v63: u8 = method4(v30.clone());
                let mut v64: i32 = 0i32;
                let mut v65: i32 = method5(v20.clone(), v64, v21, v63);
                let mut v66: bool = v65 == v21 ;
                let mut v127: Rc<str> = if v66 {
                    method2()
                } else {
                    let mut v68: bool = v65 == v21 ;
                    let (mut v83, mut v84, mut v85): (Rc<str>, i32, bool) = if v68 {
                        let mut v69: Rc<str> = method2();
                        (v69.clone(), v65, false)
                    } else {
                        let mut v70: u8 = v20.clone().as_bytes()[v65 as usize];
                        let mut v71: u8 = method4(v30.clone());
                        let mut v72: bool = v70 == v71 ;
                        if v72 {
                            let mut v73: i32 = v65 + 1i32 ;
                            let mut v74: Rc<str> = Rc::<str>::from("");
                            let mut v75: bool = false;
                            method8(v20.clone(), v73, v21, v74.clone(), v75)
                        } else {
                            let mut v79: Rc<str> = method2();
                            (v79.clone(), v65, false)
                        }
                    };
                    let mut v89: bool = if v85 {
                        let mut v86: i32 = 0i32;
                        let mut v87: i32 = (v83.clone().len() as i32);
                        method9(v83.clone(), v86, v87)
                    } else {
                        false
                    };
                    if v89 {
                        let mut v90: u8 = method4(v30.clone());
                        let mut v91: i32 = method5(v20.clone(), v84, v21, v90);
                        let mut v92: bool = v91 == v21 ;
                        if v92 {
                            method2()
                        } else {
                            let mut v94: bool = v91 == v21 ;
                            let (mut v109, mut v110, mut v111): (Rc<str>, i32, bool) = if v94 {
                                let mut v95: Rc<str> = method2();
                                (v95.clone(), v91, false)
                            } else {
                                let mut v96: u8 = v20.clone().as_bytes()[v91 as usize];
                                let mut v97: u8 = method4(v30.clone());
                                let mut v98: bool = v96 == v97 ;
                                if v98 {
                                    let mut v99: i32 = v91 + 1i32 ;
                                    let mut v100: Rc<str> = Rc::<str>::from("");
                                    let mut v101: bool = false;
                                    method8(v20.clone(), v99, v21, v100.clone(), v101)
                                } else {
                                    let mut v105: Rc<str> = method2();
                                    (v105.clone(), v91, false)
                                }
                            };
                            let mut v112: u8 = method4(v30.clone());
                            let mut v113: i32 = method5(v20.clone(), v110, v21, v112);
                            let mut v115: bool = if v111 {
                                let mut v114: bool = v110 <= v21;
                                v114
                            } else {
                                false
                            };
                            let mut v117: bool = if v115 {
                                let mut v116: bool = v113 == v21 ;
                                v116
                            } else {
                                false
                            };
                            let mut v121: bool = if v117 {
                                let mut v118: i32 = 0i32;
                                let mut v119: i32 = (v109.clone().len() as i32);
                                method9(v109.clone(), v118, v119)
                            } else {
                                false
                            };
                            if v121 {
                                v109.clone()
                            } else {
                                method2()
                            }
                        }
                    } else {
                        method2()
                    }
                };
                let mut v128: Rc<str> = Rc::<str>::from("");
                let mut v129: bool = v62 == v128 ;
                let mut v131: bool = if v129 {
                    true
                } else {
                    let mut v130: bool = v127 == v128 ;
                    v130
                };
                let mut v134: bool = if v131 {
                    true
                } else {
                    let mut v132: i32 = 0i32;
                    method10(v0.clone(), v132, v1, v14, v62.clone())
                };
                if v134 {
                    return method2();
                } else {
                    let mut v136: bool = v3 == 0i32 ;
                    let mut v139: Rc<str> = if v136 {
                        let mut v137: Rc<str> = Rc::<str>::from("\n## ");
                        v137.clone()
                    } else {
                        let mut v138: Rc<str> = Rc::<str>::from("\n\n## ");
                        v138.clone()
                    };
                    let mut v140: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), v139.clone()));
                    let mut v141: Rc<str> = Rc::<str>::from(format!("{}{}", v140.clone(), v62.clone()));
                    let mut v142: Rc<str> = Rc::<str>::from(format!("{}{}", v141.clone(), Rc::<str>::from("\n\n")));
                    let mut v143: Rc<str> = Rc::<str>::from(format!("{}{}", v142.clone(), v127.clone()));
                    let mut v144: i32 = v3 + 1i32 ;
                    (v0, v1, v2, v3, v4) = (v0.clone(), v24, v2, v144, v143.clone());
                    continue;
                }
            } else {
                (v0, v1, v2, v3, v4) = (v0.clone(), v24, v2, v3, v4.clone());
                continue;
            }
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: i32 = 0i32;
    let mut v4: Rc<str> = Rc::<str>::from("ok");
    method1(v0.clone(), v1, v2, v3, v4.clone())
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
pub fn eoie_handoff_sections_projection(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
