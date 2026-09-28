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
fn method2(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method3(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u8) -> i32 {
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
fn method5() -> Rc<str> {
    let mut v0: Rc<str> = Rc::<str>::from("");
    v0.clone()
}
fn method4() -> Rc<str> {
    method5()
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
                            let mut v14: u8 = method2(v13.clone());
                            let mut v15: bool = v6 == v14 ;
                            if v15 {
                                v13.clone()
                            } else {
                                let mut v16: Rc<str> = Rc::<str>::from("\"");
                                let mut v17: u8 = method2(v16.clone());
                                let mut v18: bool = v6 == v17 ;
                                if v18 {
                                    v16.clone()
                                } else {
                                    method4()
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
                let mut v37: u8 = method2(v36.clone());
                let mut v38: bool = v6 == v37 ;
                if v38 {
                    let mut v39: i32 = v1 + 1i32 ;
                    let mut v40: bool = true;
                    (v0, v1, v2, v3, v4) = (v0.clone(), v39, v2, v3.clone(), v40);
                    continue;
                } else {
                    let mut v44: Rc<str> = Rc::<str>::from("\"");
                    let mut v45: u8 = method2(v44.clone());
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
fn method9(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v1 == v2 ;
        if v3 {
            return v2;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v5: bool = v4 == b' ' ;
            if v5 {
                let mut v6: i32 = v1 + 1i32 ;
                (v0, v1, v2) = (v0.clone(), v6, v2);
                continue;
            } else {
                let mut v8: Rc<str> = Rc::<str>::from("\t");
                let mut v9: u8 = method2(v8.clone());
                let mut v10: bool = v4 == v9 ;
                if v10 {
                    let mut v11: i32 = v1 + 1i32 ;
                    (v0, v1, v2) = (v0.clone(), v11, v2);
                    continue;
                } else {
                    return v1;
                }
            }
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
            let mut v6: u8 = method2(v5.clone());
            let mut v7: i32 = method3(v0.clone(), v1, v2, v6);
            let mut v8: bool = v1 == v7 ;
            let mut v12: Rc<str> = if v8 {
                method4()
            } else {
                let mut v10: i32 = v7 - 1i32 ;
                let mut v11: Rc<str> = string_slice(&v0.clone(), v1 as i64, v10 as i64);
                v11.clone()
            };
            let mut v13: i32 = (v12.clone().len() as i32);
            let mut v14: Rc<str> = Rc::<str>::from("= StateCheckSnapshot ");
            let mut v15: i32 = 0i32;
            let mut v16: i32 = 21i32;
            let mut v17: i32 = method6(v12.clone(), v14.clone(), v15, v13, v16);
            let mut v18: bool = v17 == v13 ;
            let mut v34: Rc<str> = if v18 {
                method4()
            } else {
                let mut v20: i32 = v17 + 21i32 ;
                let mut v21: Rc<str> = Rc::<str>::from("u64");
                let mut v22: i32 = 3i32;
                let mut v23: i32 = method6(v12.clone(), v21.clone(), v20, v13, v22);
                let mut v24: bool = v23 == v13 ;
                if v24 {
                    method4()
                } else {
                    let mut v26: bool = v20 == v23 ;
                    let mut v30: Rc<str> = if v26 {
                        method4()
                    } else {
                        let mut v28: i32 = v23 - 1i32 ;
                        let mut v29: Rc<str> = string_slice(&v12.clone(), v20 as i64, v28 as i64);
                        v29.clone()
                    };
                    let mut v31: Rc<str> = Rc::<str>::from(format!("{}{}", v30.clone(), Rc::<str>::from("\n")));
                    let mut v32: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("snapshot\t"), v31.clone()));
                    v32.clone()
                }
            };
            let mut v35: Rc<str> = Rc::<str>::from("");
            let mut v36: bool = v34 == v35 ;
            let mut v189: Rc<str> = if v36 {
                let mut v37: Rc<str> = Rc::<str>::from("= ModuleTypecheckReceipt (");
                let mut v38: i32 = 0i32;
                let mut v39: i32 = 26i32;
                let mut v40: i32 = method6(v12.clone(), v37.clone(), v38, v13, v39);
                let mut v41: bool = v40 == v13 ;
                if v41 {
                    method4()
                } else {
                    let mut v43: i32 = v40 + 26i32 ;
                    let mut v44: bool = v43 == v13 ;
                    let (mut v59, mut v60, mut v61): (Rc<str>, i32, bool) = if v44 {
                        let mut v45: Rc<str> = method4();
                        (v45.clone(), v43, false)
                    } else {
                        let mut v46: u8 = v12.clone().as_bytes()[v43 as usize];
                        let mut v47: Rc<str> = Rc::<str>::from("\"");
                        let mut v48: u8 = method2(v47.clone());
                        let mut v49: bool = v46 == v48 ;
                        if v49 {
                            let mut v50: i32 = v43 + 1i32 ;
                            let mut v51: bool = false;
                            method8(v12.clone(), v50, v13, v35.clone(), v51)
                        } else {
                            let mut v55: Rc<str> = method4();
                            (v55.clone(), v43, false)
                        }
                    };
                    let mut v62: bool = v61 == false ;
                    if v62 {
                        method4()
                    } else {
                        let mut v64: u8 = b',';
                        let mut v65: i32 = method3(v12.clone(), v60, v13, v64);
                        let mut v66: bool = v65 == v13 ;
                        if v66 {
                            method4()
                        } else {
                            let mut v68: i32 = v65 + 1i32 ;
                            let mut v69: i32 = method9(v12.clone(), v68, v13);
                            let mut v70: Rc<str> = Rc::<str>::from("u64");
                            let mut v71: i32 = 3i32;
                            let mut v72: i32 = method6(v12.clone(), v70.clone(), v69, v13, v71);
                            let mut v73: bool = v72 == v13 ;
                            if v73 {
                                method4()
                            } else {
                                let mut v75: i32 = v72 + 3i32 ;
                                let mut v76: u8 = b',';
                                let mut v77: i32 = method3(v12.clone(), v75, v13, v76);
                                let mut v78: bool = v77 == v13 ;
                                if v78 {
                                    method4()
                                } else {
                                    let mut v80: i32 = v77 + 1i32 ;
                                    let mut v81: i32 = method9(v12.clone(), v80, v13);
                                    let mut v82: i32 = 3i32;
                                    let mut v83: i32 = method6(v12.clone(), v70.clone(), v81, v13, v82);
                                    let mut v84: bool = v83 == v13 ;
                                    if v84 {
                                        method4()
                                    } else {
                                        let mut v86: Rc<str> = Rc::<str>::from("\t");
                                        let mut v87: u8 = method2(v86.clone());
                                        let mut v88: i32 = method3(v12.clone(), v81, v13, v87);
                                        let mut v89: bool = v88 < v83;
                                        let mut v90: i32 = if v89 {
                                            v88
                                        } else {
                                            v83
                                        };
                                        let mut v91: bool = v69 == v72 ;
                                        let mut v95: Rc<str> = if v91 {
                                            method4()
                                        } else {
                                            let mut v93: i32 = v72 - 1i32 ;
                                            let mut v94: Rc<str> = string_slice(&v12.clone(), v69 as i64, v93 as i64);
                                            v94.clone()
                                        };
                                        let mut v96: bool = v81 == v90 ;
                                        let mut v100: Rc<str> = if v96 {
                                            method4()
                                        } else {
                                            let mut v98: i32 = v90 - 1i32 ;
                                            let mut v99: Rc<str> = string_slice(&v12.clone(), v81 as i64, v98 as i64);
                                            v99.clone()
                                        };
                                        let mut v112: i32 = if v89 {
                                            let mut v101: i32 = v88 + 1i32 ;
                                            method9(v12.clone(), v101, v13)
                                        } else {
                                            let mut v103: i32 = v83 + 3i32 ;
                                            let mut v104: i32 = method9(v12.clone(), v103, v13);
                                            let mut v105: bool = v104 == v13 ;
                                            if v105 {
                                                v104
                                            } else {
                                                let mut v106: u8 = v12.clone().as_bytes()[v104 as usize];
                                                let mut v107: bool = v106 == b',' ;
                                                if v107 {
                                                    let mut v108: i32 = v104 + 1i32 ;
                                                    method9(v12.clone(), v108, v13)
                                                } else {
                                                    v104
                                                }
                                            }
                                        };
                                        let mut v113: i32 = method9(v12.clone(), v112, v13);
                                        let mut v114: bool = v113 == v13 ;
                                        let mut v171: Rc<str> = if v114 {
                                            let mut v115: Rc<str> = Rc::<str>::from("runtime");
                                            v115.clone()
                                        } else {
                                            let mut v116: i32 = v113 + 18i32 ;
                                            let mut v117: bool = v13 < v116;
                                            let mut v122: bool = if v117 {
                                                false
                                            } else {
                                                let mut v118: Rc<str> = Rc::<str>::from("RuntimeAttestation");
                                                let mut v119: i32 = 0i32;
                                                let mut v120: i32 = 18i32;
                                                method7(v12.clone(), v118.clone(), v113, v119, v120)
                                            };
                                            if v122 {
                                                let mut v123: Rc<str> = Rc::<str>::from("runtime");
                                                v123.clone()
                                            } else {
                                                let mut v124: i32 = v113 + 16i32 ;
                                                let mut v125: bool = v13 < v124;
                                                let mut v130: bool = if v125 {
                                                    false
                                                } else {
                                                    let mut v126: Rc<str> = Rc::<str>::from("BuildAttestation");
                                                    let mut v127: i32 = 0i32;
                                                    let mut v128: i32 = 16i32;
                                                    method7(v12.clone(), v126.clone(), v113, v127, v128)
                                                };
                                                if v130 {
                                                    let mut v131: i32 = v113 + 16i32 ;
                                                    let mut v132: i32 = method9(v12.clone(), v131, v13);
                                                    let mut v133: i32 = 3i32;
                                                    let mut v134: i32 = method6(v12.clone(), v70.clone(), v132, v13, v133);
                                                    let mut v135: bool = v134 == v13 ;
                                                    if v135 {
                                                        method4()
                                                    } else {
                                                        let mut v137: bool = v132 == v134 ;
                                                        let mut v141: Rc<str> = if v137 {
                                                            method4()
                                                        } else {
                                                            let mut v139: i32 = v134 - 1i32 ;
                                                            let mut v140: Rc<str> = string_slice(&v12.clone(), v132 as i64, v139 as i64);
                                                            v140.clone()
                                                        };
                                                        let mut v142: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("build:"), v141.clone()));
                                                        v142.clone()
                                                    }
                                                } else {
                                                    let mut v144: i32 = v113 + 6i32 ;
                                                    let mut v145: bool = v13 < v144;
                                                    let mut v150: bool = if v145 {
                                                        false
                                                    } else {
                                                        let mut v146: Rc<str> = Rc::<str>::from("build:");
                                                        let mut v147: i32 = 0i32;
                                                        let mut v148: i32 = 6i32;
                                                        method7(v12.clone(), v146.clone(), v113, v147, v148)
                                                    };
                                                    if v150 {
                                                        let mut v151: i32 = v113 + 6i32 ;
                                                        let mut v152: i32 = 3i32;
                                                        let mut v153: i32 = method6(v12.clone(), v70.clone(), v151, v13, v152);
                                                        let mut v154: bool = v153 == v13 ;
                                                        if v154 {
                                                            method4()
                                                        } else {
                                                            let mut v156: bool = v151 == v153 ;
                                                            let mut v160: Rc<str> = if v156 {
                                                                method4()
                                                            } else {
                                                                let mut v158: i32 = v153 - 1i32 ;
                                                                let mut v159: Rc<str> = string_slice(&v12.clone(), v151 as i64, v158 as i64);
                                                                v159.clone()
                                                            };
                                                            let mut v161: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("build:"), v160.clone()));
                                                            v161.clone()
                                                        }
                                                    } else {
                                                        let mut v163: u8 = v12.clone().as_bytes()[v113 as usize];
                                                        let mut v164: bool = v163 == b')' ;
                                                        if v164 {
                                                            let mut v165: Rc<str> = Rc::<str>::from("runtime");
                                                            v165.clone()
                                                        } else {
                                                            method4()
                                                        }
                                                    }
                                                }
                                            }
                                        };
                                        let mut v172: bool = v171 == v35 ;
                                        if v172 {
                                            method4()
                                        } else {
                                            let mut v174: Rc<str> = Rc::<str>::from(format!("{}{}", v171.clone(), Rc::<str>::from("\n")));
                                            let mut v175: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("\t"), v174.clone()));
                                            let mut v176: Rc<str> = Rc::<str>::from(format!("{}{}", v100.clone(), v175.clone()));
                                            let mut v177: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("\t"), v176.clone()));
                                            let mut v178: Rc<str> = Rc::<str>::from(format!("{}{}", v95.clone(), v177.clone()));
                                            let mut v179: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("\t"), v178.clone()));
                                            let mut v180: Rc<str> = Rc::<str>::from(format!("{}{}", v59.clone(), v179.clone()));
                                            let mut v181: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("module\t"), v180.clone()));
                                            v181.clone()
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } else {
                v34.clone()
            };
            let mut v190: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), v189.clone()));
            let mut v191: bool = v7 == v2 ;
            let mut v193: i32 = if v191 {
                v2
            } else {
                let mut v192: i32 = v7 + 1i32 ;
                v192
            };
            (v0, v1, v2, v3) = (v0.clone(), v193, v2, v190.clone());
            continue;
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: Rc<str> = Rc::<str>::from("");
    method1(v0.clone(), v1, v2, v3.clone())
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
pub fn eoie_state_receipt_parse(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
