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
fn method6(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("1");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("snapshot");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("2");
        let mut v5: bool = v0 == v4 ;
        if v5 {
            let mut v6: Rc<str> = Rc::<str>::from("module");
            v6.clone()
        } else {
            let mut v7: Rc<str> = Rc::<str>::from("");
            v7.clone()
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
fn method8(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("runtime");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        1u64
    } else {
        let mut v3: i32 = (v0.clone().len() as i32);
        let mut v4: bool = v3 < 6i32;
        let mut v10: bool = if v4 {
            false
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("build:");
            let mut v6: i32 = 0i32;
            let mut v7: i32 = 0i32;
            let mut v8: i32 = 6i32;
            method7(v0.clone(), v5.clone(), v6, v7, v8)
        };
        if v10 {
            2u64
        } else {
            0u64
        }
    }
}
fn method9(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: u64 = method8(v0.clone());
    let mut v2: bool = v1 == 2u64 ;
    if v2 {
        let mut v3: i32 = (v0.clone().len() as i32);
        let mut v4: bool = 6i32 == v3 ;
        if v4 {
            method4()
        } else {
            let mut v6: i32 = v3 - 1i32 ;
            let mut v7: Rc<str> = string_slice(&v0.clone(), 6i32 as i64, v6 as i64);
            v7.clone()
        }
    } else {
        method4()
    }
}
fn method11(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
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
fn method10(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> bool {
    loop {
        let mut v3: bool = v1 == v2 ;
        if v3 {
            return true;
        } else {
            let mut v4: Rc<str> = string_slice(&v0.clone(), v1 as i64, v1 as i64);
            let mut v5: Rc<str> = Rc::<str>::from("0123456789");
            let mut v6: i32 = 0i32;
            let mut v7: i32 = 10i32;
            let mut v8: i32 = (v4.clone().len() as i32);
            let mut v9: i32 = method11(v5.clone(), v4.clone(), v6, v7, v8);
            let mut v10: bool = v9 < 10i32;
            if v10 {
                let mut v11: i32 = v1 + 1i32 ;
                (v0, v1, v2) = (v0.clone(), v11, v2);
                continue;
            } else {
                return false;
            }
        }
    }
}
fn method12(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: Rc<str>) -> Rc<str> {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return v3.clone();
        } else {
            let mut v5: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v6: Rc<str> = Rc::<str>::from("\\");
            let mut v7: u8 = method2(v6.clone());
            let mut v8: bool = v5 == v7 ;
            let mut v31: Rc<str> = if v8 {
                let mut v9: Rc<str> = Rc::<str>::from("\\\\");
                v9.clone()
            } else {
                let mut v10: Rc<str> = Rc::<str>::from("\"");
                let mut v11: u8 = method2(v10.clone());
                let mut v12: bool = v5 == v11 ;
                if v12 {
                    let mut v13: Rc<str> = Rc::<str>::from("\\\"");
                    v13.clone()
                } else {
                    let mut v14: Rc<str> = Rc::<str>::from("\n");
                    let mut v15: u8 = method2(v14.clone());
                    let mut v16: bool = v5 == v15 ;
                    if v16 {
                        let mut v17: Rc<str> = Rc::<str>::from("\\n");
                        v17.clone()
                    } else {
                        let mut v18: Rc<str> = Rc::<str>::from("\r");
                        let mut v19: u8 = method2(v18.clone());
                        let mut v20: bool = v5 == v19 ;
                        if v20 {
                            let mut v21: Rc<str> = Rc::<str>::from("\\r");
                            v21.clone()
                        } else {
                            let mut v22: Rc<str> = Rc::<str>::from("\t");
                            let mut v23: u8 = method2(v22.clone());
                            let mut v24: bool = v5 == v23 ;
                            if v24 {
                                let mut v25: Rc<str> = Rc::<str>::from("\\t");
                                v25.clone()
                            } else {
                                let mut v26: Rc<str> = string_slice(&v0.clone(), v1 as i64, v1 as i64);
                                v26.clone()
                            }
                        }
                    }
                }
            };
            let mut v32: i32 = v1 + 1i32 ;
            let mut v33: Rc<str> = Rc::<str>::from(format!("{}{}", v3.clone(), v31.clone()));
            (v0, v1, v2, v3) = (v0.clone(), v32, v2, v33.clone());
            continue;
        }
    }
}
fn method1(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: Rc<str>) -> Rc<str> {
    loop {
        let mut v5: bool = v1 == v2 ;
        if v5 {
            return v4.clone();
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("\n");
            let mut v7: u8 = method2(v6.clone());
            let mut v8: i32 = method3(v0.clone(), v1, v2, v7);
            let mut v9: bool = v1 == v8 ;
            let mut v13: Rc<str> = if v9 {
                method4()
            } else {
                let mut v11: i32 = v8 - 1i32 ;
                let mut v12: Rc<str> = string_slice(&v0.clone(), v1 as i64, v11 as i64);
                v12.clone()
            };
            let mut v14: Rc<str> = Rc::<str>::from("1");
            let mut v15: Rc<str> = method6(v14.clone());
            let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15.clone(), Rc::<str>::from("\t")));
            let mut v17: Rc<str> = Rc::<str>::from("2");
            let mut v18: Rc<str> = method6(v17.clone());
            let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18.clone(), Rc::<str>::from("\t")));
            let mut v20: i32 = (v13.clone().len() as i32);
            let mut v21: i32 = (v16.clone().len() as i32);
            let mut v22: i32 = 0i32 + v21 ;
            let mut v23: bool = v20 < v22;
            let mut v27: bool = if v23 {
                false
            } else {
                let mut v24: i32 = 0i32;
                let mut v25: i32 = 0i32;
                method7(v13.clone(), v16.clone(), v24, v25, v21)
            };
            let mut v28: i32 = (v19.clone().len() as i32);
            let mut v29: i32 = 0i32 + v28 ;
            let mut v30: bool = v20 < v29;
            let mut v34: bool = if v30 {
                false
            } else {
                let mut v31: i32 = 0i32;
                let mut v32: i32 = 0i32;
                method7(v13.clone(), v19.clone(), v31, v32, v28)
            };
            let mut v139: Rc<str> = if v27 {
                let mut v35: Rc<str> = method6(v14.clone());
                let mut v36: Rc<str> = Rc::<str>::from(format!("{}{}", v35.clone(), Rc::<str>::from("\t")));
                let mut v37: i32 = (v36.clone().len() as i32);
                let mut v38: bool = v37 == v20 ;
                let mut v42: Rc<str> = if v38 {
                    method4()
                } else {
                    let mut v40: i32 = v20 - 1i32 ;
                    let mut v41: Rc<str> = string_slice(&v13.clone(), v37 as i64, v40 as i64);
                    v41.clone()
                };
                let mut v43: Rc<str> = Rc::<str>::from(format!("{}{}", v42.clone(), Rc::<str>::from("u64\n")));
                let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("inl snapshot () : state_check_snapshot = StateCheckSnapshot "), v43.clone()));
                v44.clone()
            } else {
                if v34 {
                    let mut v45: Rc<str> = method6(v17.clone());
                    let mut v46: Rc<str> = Rc::<str>::from(format!("{}{}", v45.clone(), Rc::<str>::from("\t")));
                    let mut v47: i32 = (v46.clone().len() as i32);
                    let mut v48: Rc<str> = Rc::<str>::from("\t");
                    let mut v49: u8 = method2(v48.clone());
                    let mut v50: i32 = method3(v13.clone(), v47, v20, v49);
                    let mut v51: bool = v50 == v20 ;
                    if v51 {
                        method4()
                    } else {
                        let mut v53: i32 = v50 + 1i32 ;
                        let mut v54: u8 = method2(v48.clone());
                        let mut v55: i32 = method3(v13.clone(), v53, v20, v54);
                        let mut v56: bool = v55 == v20 ;
                        if v56 {
                            method4()
                        } else {
                            let mut v58: i32 = v55 + 1i32 ;
                            let mut v59: u8 = method2(v48.clone());
                            let mut v60: i32 = method3(v13.clone(), v58, v20, v59);
                            let mut v61: bool = v60 == v20 ;
                            if v61 {
                                method4()
                            } else {
                                let mut v63: bool = v47 == v50 ;
                                let mut v67: Rc<str> = if v63 {
                                    method4()
                                } else {
                                    let mut v65: i32 = v50 - 1i32 ;
                                    let mut v66: Rc<str> = string_slice(&v13.clone(), v47 as i64, v65 as i64);
                                    v66.clone()
                                };
                                let mut v68: i32 = v50 + 1i32 ;
                                let mut v69: bool = v68 == v55 ;
                                let mut v73: Rc<str> = if v69 {
                                    method4()
                                } else {
                                    let mut v71: i32 = v55 - 1i32 ;
                                    let mut v72: Rc<str> = string_slice(&v13.clone(), v68 as i64, v71 as i64);
                                    v72.clone()
                                };
                                let mut v74: i32 = v55 + 1i32 ;
                                let mut v75: bool = v74 == v60 ;
                                let mut v79: Rc<str> = if v75 {
                                    method4()
                                } else {
                                    let mut v77: i32 = v60 - 1i32 ;
                                    let mut v78: Rc<str> = string_slice(&v13.clone(), v74 as i64, v77 as i64);
                                    v78.clone()
                                };
                                let mut v80: i32 = v60 + 1i32 ;
                                let mut v81: bool = v80 == v20 ;
                                let mut v85: Rc<str> = if v81 {
                                    method4()
                                } else {
                                    let mut v83: i32 = v20 - 1i32 ;
                                    let mut v84: Rc<str> = string_slice(&v13.clone(), v80 as i64, v83 as i64);
                                    v84.clone()
                                };
                                let mut v86: u64 = method8(v85.clone());
                                let mut v87: bool = v86 == 1u64 ;
                                let mut v103: Rc<str> = if v87 {
                                    let mut v88: Rc<str> = Rc::<str>::from("RuntimeAttestation");
                                    v88.clone()
                                } else {
                                    let mut v89: bool = v86 == 2u64 ;
                                    if v89 {
                                        let mut v90: Rc<str> = method9(v85.clone());
                                        let mut v91: i32 = (v90.clone().len() as i32);
                                        let mut v92: bool = v91 == 0i32 ;
                                        if v92 {
                                            method4()
                                        } else {
                                            let mut v94: i32 = 0i32;
                                            let mut v95: bool = method10(v90.clone(), v94, v91);
                                            if v95 {
                                                let mut v96: Rc<str> = Rc::<str>::from(format!("{}{}", v90.clone(), Rc::<str>::from("u64")));
                                                let mut v97: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("BuildAttestation "), v96.clone()));
                                                v97.clone()
                                            } else {
                                                method4()
                                            }
                                        }
                                    } else {
                                        method4()
                                    }
                                };
                                let mut v104: Rc<str> = Rc::<str>::from("");
                                let mut v105: bool = v103 == v104 ;
                                if v105 {
                                    method4()
                                } else {
                                    let mut v107: i32 = v3 / 1000i32 ;
                                    let mut v108: i32 = v3 % 1000i32 ;
                                    let mut v109: i32 = v108 / 100i32 ;
                                    let mut v110: i32 = v3 % 100i32 ;
                                    let mut v111: i32 = v110 / 10i32 ;
                                    let mut v112: i32 = v3 % 10i32 ;
                                    let mut v113: Rc<str> = string_slice(&Rc::<str>::from("0123456789"), v107 as i64, v107 as i64);
                                    let mut v114: Rc<str> = string_slice(&Rc::<str>::from("0123456789"), v109 as i64, v109 as i64);
                                    let mut v115: Rc<str> = string_slice(&Rc::<str>::from("0123456789"), v111 as i64, v111 as i64);
                                    let mut v116: Rc<str> = string_slice(&Rc::<str>::from("0123456789"), v112 as i64, v112 as i64);
                                    let mut v117: Rc<str> = Rc::<str>::from(format!("{}{}", v115.clone(), v116.clone()));
                                    let mut v118: Rc<str> = Rc::<str>::from(format!("{}{}", v114.clone(), v117.clone()));
                                    let mut v119: Rc<str> = Rc::<str>::from(format!("{}{}", v113.clone(), v118.clone()));
                                    let mut v120: Rc<str> = Rc::<str>::from(format!("{}{}", v119.clone(), Rc::<str>::from(" () : module_typecheck_receipt = ModuleTypecheckReceipt (\"")));
                                    let mut v121: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("inl receipt_"), v120.clone()));
                                    let mut v122: i32 = 0i32;
                                    let mut v123: i32 = (v67.clone().len() as i32);
                                    let mut v124: Rc<str> = method12(v67.clone(), v122, v123, v104.clone());
                                    let mut v125: Rc<str> = Rc::<str>::from(format!("{}{}", v73.clone(), Rc::<str>::from("u64, ")));
                                    let mut v126: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("\", "), v125.clone()));
                                    let mut v127: Rc<str> = Rc::<str>::from(format!("{}{}", v124.clone(), v126.clone()));
                                    let mut v128: Rc<str> = Rc::<str>::from(format!("{}{}", v103.clone(), Rc::<str>::from(")\n")));
                                    let mut v129: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("u64, "), v128.clone()));
                                    let mut v130: Rc<str> = Rc::<str>::from(format!("{}{}", v79.clone(), v129.clone()));
                                    let mut v131: Rc<str> = Rc::<str>::from(format!("{}{}", v127.clone(), v130.clone()));
                                    let mut v132: Rc<str> = Rc::<str>::from(format!("{}{}", v121.clone(), v131.clone()));
                                    v132.clone()
                                }
                            }
                        }
                    }
                } else {
                    method4()
                }
            };
            let mut v141: i32 = if v34 {
                let mut v140: i32 = v3 + 1i32 ;
                v140
            } else {
                v3
            };
            let mut v142: bool = v8 == v2 ;
            let mut v144: i32 = if v142 {
                v2
            } else {
                let mut v143: i32 = v8 + 1i32 ;
                v143
            };
            let mut v145: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), v139.clone()));
            (v0, v1, v2, v3, v4) = (v0.clone(), v144, v2, v141, v145.clone());
            continue;
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: i32 = 0i32;
    let mut v4: Rc<str> = Rc::<str>::from("");
    let mut v5: Rc<str> = method1(v0.clone(), v1, v2, v3, v4.clone());
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v5.clone(), Rc::<str>::from("inl main () : i32 = 0i32\n")));
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("union state_check_snapshot = | StateCheckSnapshot :: u64 -> state_check_snapshot\nunion module_attestation = | RuntimeAttestation | BuildAttestation :: u64 -> module_attestation\nunion module_typecheck_receipt = | ModuleTypecheckReceipt :: string * u64 * u64 * module_attestation -> module_typecheck_receipt\n\n"), v6.clone()));
    v7.clone()
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
pub fn eoie_state_receipt_serialize(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
