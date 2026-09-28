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
fn method5(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method4(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
                let mut v9: u8 = method5(v8.clone());
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
fn method6(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 == 0i32 ;
        if v2 {
            return 0i32;
        } else {
            let mut v3: i32 = v1 - 1i32 ;
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v5: bool = v4 == b' ' ;
            let mut v9: bool = if v5 {
                true
            } else {
                let mut v6: Rc<str> = Rc::<str>::from("\t");
                let mut v7: u8 = method5(v6.clone());
                let mut v8: bool = v4 == v7 ;
                v8
            };
            if v9 {
                (v0, v1) = (v0.clone(), v3);
                continue;
            } else {
                return v1;
            }
        }
    }
}
fn method1(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: bool, mut v5: bool, mut v6: Rc<str>) -> Rc<str> {
    loop {
        let mut v7: bool = v1 == v2 ;
        if v7 {
            if v4 {
                return method2();
            } else {
                if v5 {
                    return method2();
                } else {
                    let mut v10: bool = v3 == v2 ;
                    let mut v14: Rc<str> = if v10 {
                        method2()
                    } else {
                        let mut v12: i32 = v2 - 1i32 ;
                        let mut v13: Rc<str> = string_slice(&v0.clone(), v3 as i64, v12 as i64);
                        v13.clone()
                    };
                    let mut v15: i32 = 0i32;
                    let mut v16: i32 = (v14.clone().len() as i32);
                    let mut v17: i32 = method4(v14.clone(), v15, v16);
                    let mut v18: i32 = method6(v14.clone(), v16);
                    let mut v19: bool = v18 < v17;
                    let mut v26: Rc<str> = if v19 {
                        method2()
                    } else {
                        let mut v21: bool = v17 == v18 ;
                        if v21 {
                            method2()
                        } else {
                            let mut v23: i32 = v18 - 1i32 ;
                            let mut v24: Rc<str> = string_slice(&v14.clone(), v17 as i64, v23 as i64);
                            v24.clone()
                        }
                    };
                    let mut v27: Rc<str> = Rc::<str>::from(format!("{}{}", v26.clone(), Rc::<str>::from("\n")));
                    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v6.clone(), v27.clone()));
                    return v28.clone();
                }
            }
        } else {
            let mut v31: u8 = v0.clone().as_bytes()[v1 as usize];
            if v4 {
                if v5 {
                    let mut v32: i32 = v1 + 1i32 ;
                    let mut v33: bool = true;
                    let mut v34: bool = false;
                    (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v32, v2, v3, v33, v34, v6.clone());
                    continue;
                } else {
                    let mut v36: Rc<str> = Rc::<str>::from("\\");
                    let mut v37: u8 = method5(v36.clone());
                    let mut v38: bool = v31 == v37 ;
                    if v38 {
                        let mut v39: i32 = v1 + 1i32 ;
                        let mut v40: bool = true;
                        let mut v41: bool = true;
                        (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v39, v2, v3, v40, v41, v6.clone());
                        continue;
                    } else {
                        let mut v43: Rc<str> = Rc::<str>::from("\"");
                        let mut v44: u8 = method5(v43.clone());
                        let mut v45: bool = v31 == v44 ;
                        if v45 {
                            let mut v46: i32 = v1 + 1i32 ;
                            let mut v47: bool = false;
                            let mut v48: bool = false;
                            (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v46, v2, v3, v47, v48, v6.clone());
                            continue;
                        } else {
                            let mut v50: i32 = v1 + 1i32 ;
                            let mut v51: bool = true;
                            let mut v52: bool = false;
                            (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v50, v2, v3, v51, v52, v6.clone());
                            continue;
                        }
                    }
                }
            } else {
                let mut v57: Rc<str> = Rc::<str>::from("\"");
                let mut v58: u8 = method5(v57.clone());
                let mut v59: bool = v31 == v58 ;
                if v59 {
                    let mut v60: i32 = v1 + 1i32 ;
                    let mut v61: bool = true;
                    let mut v62: bool = false;
                    (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v60, v2, v3, v61, v62, v6.clone());
                    continue;
                } else {
                    let mut v64: bool = v31 == b',' ;
                    if v64 {
                        let mut v65: bool = v3 == v1 ;
                        let mut v69: Rc<str> = if v65 {
                            method2()
                        } else {
                            let mut v67: i32 = v1 - 1i32 ;
                            let mut v68: Rc<str> = string_slice(&v0.clone(), v3 as i64, v67 as i64);
                            v68.clone()
                        };
                        let mut v70: i32 = 0i32;
                        let mut v71: i32 = (v69.clone().len() as i32);
                        let mut v72: i32 = method4(v69.clone(), v70, v71);
                        let mut v73: i32 = method6(v69.clone(), v71);
                        let mut v74: bool = v73 < v72;
                        let mut v81: Rc<str> = if v74 {
                            method2()
                        } else {
                            let mut v76: bool = v72 == v73 ;
                            if v76 {
                                method2()
                            } else {
                                let mut v78: i32 = v73 - 1i32 ;
                                let mut v79: Rc<str> = string_slice(&v69.clone(), v72 as i64, v78 as i64);
                                v79.clone()
                            }
                        };
                        let mut v82: i32 = v1 + 1i32 ;
                        let mut v83: i32 = v1 + 1i32 ;
                        let mut v84: bool = false;
                        let mut v85: bool = false;
                        let mut v86: Rc<str> = Rc::<str>::from(format!("{}{}", v81.clone(), Rc::<str>::from("\n")));
                        let mut v87: Rc<str> = Rc::<str>::from(format!("{}{}", v6.clone(), v86.clone()));
                        (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v82, v2, v83, v84, v85, v87.clone());
                        continue;
                    } else {
                        let mut v89: i32 = v1 + 1i32 ;
                        let mut v90: bool = false;
                        let mut v91: bool = false;
                        (v0, v1, v2, v3, v4, v5, v6) = (v0.clone(), v89, v2, v3, v90, v91, v6.clone());
                        continue;
                    }
                }
            }
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: i32 = 0i32;
    let mut v4: bool = false;
    let mut v5: bool = false;
    let mut v6: Rc<str> = Rc::<str>::from("");
    method1(v0.clone(), v1, v2, v3, v4, v5, v6.clone())
}
fn method8(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> bool {
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
        method2()
    } else {
        let mut v4: i32 = 0i32;
        let mut v5: u64 = 0u64;
        let mut v6: bool = method10(v0.clone(), v4, v1, v5);
        if v6 {
            v0.clone()
        } else {
            method2()
        }
    }
}
fn method7(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("runtime");
    let mut v3: bool = v0 == v2 ;
    if v3 {
        v2.clone()
    } else {
        let mut v4: bool = v1 < 6i32;
        let mut v10: bool = if v4 {
            false
        } else {
            let mut v5: Rc<str> = Rc::<str>::from("build:");
            let mut v6: i32 = 0i32;
            let mut v7: i32 = 0i32;
            let mut v8: i32 = 6i32;
            method8(v0.clone(), v5.clone(), v6, v7, v8)
        };
        if v10 {
            let mut v11: bool = 6i32 == v1 ;
            let mut v15: Rc<str> = if v11 {
                method2()
            } else {
                let mut v13: i32 = v1 - 1i32 ;
                let mut v14: Rc<str> = string_slice(&v0.clone(), 6i32 as i64, v13 as i64);
                v14.clone()
            };
            let mut v16: Rc<str> = method9(v15.clone());
            let mut v17: Rc<str> = Rc::<str>::from("");
            let mut v18: bool = v16 == v17 ;
            if v18 {
                method2()
            } else {
                let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("build:"), v16.clone()));
                v20.clone()
            }
        } else {
            method2()
        }
    }
}
fn method13(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u64) -> u64 {
    loop {
        let mut v4: bool = v1 == v2 ;
        if v4 {
            return v3;
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
            let mut v26: i32 = v1 + 1i32 ;
            let mut v27: u64 = v3 * 10u64 ;
            let mut v28: u64 = v27 + v25 ;
            (v0, v1, v2, v3) = (v0.clone(), v26, v2, v28);
            continue;
        }
    }
}
fn method12(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = method9(v0.clone());
    let mut v2: i32 = (v1.clone().len() as i32);
    let mut v3: bool = v2 == 0i32 ;
    if v3 {
        0u64
    } else {
        let mut v4: i32 = 0i32;
        let mut v5: u64 = 0u64;
        method13(v1.clone(), v4, v2, v5)
    }
}
fn method11(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = method7(v0.clone());
    let mut v2: i32 = (v1.clone().len() as i32);
    let mut v3: Rc<str> = Rc::<str>::from("runtime");
    let mut v4: bool = v1 == v3 ;
    if v4 {
        0u64
    } else {
        let mut v5: bool = v2 < 6i32;
        let mut v11: bool = if v5 {
            false
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("build:");
            let mut v7: i32 = 0i32;
            let mut v8: i32 = 0i32;
            let mut v9: i32 = 6i32;
            method8(v1.clone(), v6.clone(), v7, v8, v9)
        };
        if v11 {
            let mut v12: bool = 6i32 == v2 ;
            let mut v16: Rc<str> = if v12 {
                method2()
            } else {
                let mut v14: i32 = v2 - 1i32 ;
                let mut v15: Rc<str> = string_slice(&v1.clone(), 6i32 as i64, v14 as i64);
                v15.clone()
            };
            method12(v16.clone())
        } else {
            0u64
        }
    }
}
fn method15(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: i32 = method4(v0.clone(), v1, v2);
    let mut v4: i32 = method6(v0.clone(), v2);
    let mut v5: bool = v4 < v3;
    let mut v12: Rc<str> = if v5 {
        method2()
    } else {
        let mut v7: bool = v3 == v4 ;
        if v7 {
            method2()
        } else {
            let mut v9: i32 = v4 - 1i32 ;
            let mut v10: Rc<str> = string_slice(&v0.clone(), v3 as i64, v9 as i64);
            v10.clone()
        }
    };
    method9(v12.clone())
}
fn method14(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = method15(v0.clone());
    method12(v1.clone())
}
fn method17(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = 0i32;
    let mut v2: i32 = (v0.clone().len() as i32);
    let mut v3: i32 = method4(v0.clone(), v1, v2);
    let mut v4: i32 = method6(v0.clone(), v2);
    let mut v5: bool = v4 < v3;
    let mut v12: Rc<str> = if v5 {
        method2()
    } else {
        let mut v7: bool = v3 == v4 ;
        if v7 {
            method2()
        } else {
            let mut v9: i32 = v4 - 1i32 ;
            let mut v10: Rc<str> = string_slice(&v0.clone(), v3 as i64, v9 as i64);
            v10.clone()
        }
    };
    let mut v13: i32 = (v12.clone().len() as i32);
    let mut v14: bool = v13 < 4i32;
    if v14 {
        method2()
    } else {
        let mut v16: i32 = v13 - 3i32 ;
        let mut v17: u8 = v12.clone().as_bytes()[v16 as usize];
        let mut v18: bool = v17 == b'u' ;
        if v18 {
            let mut v19: i32 = v16 + 1i32 ;
            let mut v20: u8 = v12.clone().as_bytes()[v19 as usize];
            let mut v21: bool = v20 == b'6' ;
            if v21 {
                let mut v22: i32 = v16 + 2i32 ;
                let mut v23: u8 = v12.clone().as_bytes()[v22 as usize];
                let mut v24: bool = v23 == b'4' ;
                if v24 {
                    let mut v25: bool = 0i32 == v16 ;
                    let mut v29: Rc<str> = if v25 {
                        method2()
                    } else {
                        let mut v27: i32 = v16 - 1i32 ;
                        let mut v28: Rc<str> = string_slice(&v12.clone(), 0i32 as i64, v27 as i64);
                        v28.clone()
                    };
                    method9(v29.clone())
                } else {
                    method2()
                }
            } else {
                method2()
            }
        } else {
            method2()
        }
    }
}
fn method16(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = method17(v0.clone());
    method12(v1.clone())
}
fn method19(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = 0 <= v0;
    let mut v4: bool = if v2 {
        let mut v3: bool = v0 <= 100i32;
        v3
    } else {
        false
    };
    if v4 {
        let mut v5: bool = v1 == 0i32;
        let mut v13: bool = if v5 {
            true
        } else {
            let mut v6: bool = v1 == 1i32;
            if v6 {
                true
            } else {
                let mut v7: bool = v1 == 2i32;
                if v7 {
                    true
                } else {
                    let mut v8: bool = v1 == 3i32;
                    if v8 {
                        true
                    } else {
                        let mut v9: bool = v1 == 4i32;
                        v9
                    }
                }
            }
        };
        if v13 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method18(mut v0: i32, mut v1: i32) -> i32 {
    method19(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method18(v0, v1)
    })
}
fn method22(mut v0: i32) -> i32 {
    let mut v1: bool = v0 == 11i32;
    if v1 {
        1i32
    } else {
        0i32
    }
}
fn method21(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method22(v0);
    let mut v3: bool = v2 == 1i32;
    if v3 {
        let mut v4: bool = v1 == 1i32;
        if v4 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method20(mut v0: i32, mut v1: i32) -> i32 {
    method21(v0, v1)
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method20(v0, v1)
    })
}
fn method24(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 1i32;
    if v2 {
        let mut v3: bool = v1 == 1i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method23(mut v0: i32, mut v1: i32) -> i32 {
    method24(v0, v1)
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method23(v0, v1)
    })
}
fn method26(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method25(mut v0: i32, mut v1: i32) -> i32 {
    method26(v0, v1)
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method25(v0, v1)
    })
}
fn method28(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 1i32;
    if v2 {
        let mut v3: bool = v1 == 1i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method27(mut v0: i32, mut v1: i32) -> i32 {
    method28(v0, v1)
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method27(v0, v1)
    })
}
fn closure5() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
fn closure6() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method7(v0.clone())
    })
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method11(v0.clone())
    })
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method15(v0.clone())
    })
}
fn closure9() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method14(v0.clone())
    })
}
fn closure10() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method17(v0.clone())
    })
}
fn closure11() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method16(v0.clone())
    })
}
pub fn eoie_agile_set_decision_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_agile_task_identity_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_agile_receipt_content_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_agile_receipt_snapshot_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_agile_receipt_build_current_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_agile_tuple_parse_binding(v0: &str) -> Rc<str> {
    closure5()(Rc::<str>::from(v0))
}
pub fn eoie_agile_attestation_normalize_binding(v0: &str) -> Rc<str> {
    closure6()(Rc::<str>::from(v0))
}
pub fn eoie_agile_attestation_value_binding(v0: &str) -> u64 {
    closure7()(Rc::<str>::from(v0))
}
pub fn eoie_agile_u64_decimal_normalize_binding(v0: &str) -> Rc<str> {
    closure8()(Rc::<str>::from(v0))
}
pub fn eoie_agile_u64_decimal_value_binding(v0: &str) -> u64 {
    closure9()(Rc::<str>::from(v0))
}
pub fn eoie_agile_u64_literal_normalize_binding(v0: &str) -> Rc<str> {
    closure10()(Rc::<str>::from(v0))
}
pub fn eoie_agile_u64_literal_value_binding(v0: &str) -> u64 {
    closure11()(Rc::<str>::from(v0))
}
