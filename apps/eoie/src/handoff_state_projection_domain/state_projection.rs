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
fn method7(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
fn method9(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u64) -> bool {
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
fn method8(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: bool = v1 == 0i32 ;
    if v2 {
        method1()
    } else {
        let mut v4: i32 = 0i32;
        let mut v5: u64 = 0u64;
        let mut v6: bool = method9(v0.clone(), v4, v1, v5);
        if v6 {
            v0.clone()
        } else {
            method1()
        }
    }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("inl active_codebase_readiness");
    let mut v3: i32 = 0i32;
    let mut v4: i32 = 29i32;
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
    let mut v43: Rc<str> = if v18 {
        method1()
    } else {
        let mut v20: i32 = 0i32;
        let mut v21: u8 = b'=';
        let mut v22: i32 = method6(v16.clone(), v20, v17, v21);
        let mut v23: bool = v22 == v17 ;
        if v23 {
            method1()
        } else {
            let mut v25: i32 = v22 + 1i32 ;
            let mut v26: i32 = method7(v16.clone(), v25, v17);
            let mut v27: bool = v26 == v17 ;
            if v27 {
                method1()
            } else {
                let mut v29: Rc<str> = Rc::<str>::from("u32");
                let mut v30: i32 = 3i32;
                let mut v31: i32 = method3(v16.clone(), v29.clone(), v26, v17, v30);
                let mut v32: bool = v31 == v17 ;
                if v32 {
                    method1()
                } else {
                    let mut v34: bool = v26 == v31 ;
                    let mut v38: Rc<str> = if v34 {
                        method1()
                    } else {
                        let mut v36: i32 = v31 - 1i32 ;
                        let mut v37: Rc<str> = string_slice(&v16.clone(), v26 as i64, v36 as i64);
                        v37.clone()
                    };
                    method8(v38.clone())
                }
            }
        }
    };
    let mut v44: Rc<str> = Rc::<str>::from("inl subjective_phase_ceiling");
    let mut v45: i32 = 0i32;
    let mut v46: i32 = 28i32;
    let mut v47: i32 = method3(v0.clone(), v44.clone(), v45, v1, v46);
    let mut v48: bool = v47 == v1 ;
    let mut v58: Rc<str> = if v48 {
        method1()
    } else {
        let mut v50: Rc<str> = Rc::<str>::from("\n");
        let mut v51: u8 = method5(v50.clone());
        let mut v52: i32 = method6(v0.clone(), v47, v1, v51);
        let mut v53: bool = v47 == v52 ;
        if v53 {
            method1()
        } else {
            let mut v55: i32 = v52 - 1i32 ;
            let mut v56: Rc<str> = string_slice(&v0.clone(), v47 as i64, v55 as i64);
            v56.clone()
        }
    };
    let mut v59: i32 = (v58.clone().len() as i32);
    let mut v60: bool = v59 == 0i32 ;
    let mut v85: Rc<str> = if v60 {
        method1()
    } else {
        let mut v62: i32 = 0i32;
        let mut v63: u8 = b'=';
        let mut v64: i32 = method6(v58.clone(), v62, v59, v63);
        let mut v65: bool = v64 == v59 ;
        if v65 {
            method1()
        } else {
            let mut v67: i32 = v64 + 1i32 ;
            let mut v68: i32 = method7(v58.clone(), v67, v59);
            let mut v69: bool = v68 == v59 ;
            if v69 {
                method1()
            } else {
                let mut v71: Rc<str> = Rc::<str>::from("u32");
                let mut v72: i32 = 3i32;
                let mut v73: i32 = method3(v58.clone(), v71.clone(), v68, v59, v72);
                let mut v74: bool = v73 == v59 ;
                if v74 {
                    method1()
                } else {
                    let mut v76: bool = v68 == v73 ;
                    let mut v80: Rc<str> = if v76 {
                        method1()
                    } else {
                        let mut v78: i32 = v73 - 1i32 ;
                        let mut v79: Rc<str> = string_slice(&v58.clone(), v68 as i64, v78 as i64);
                        v79.clone()
                    };
                    method8(v80.clone())
                }
            }
        }
    };
    let mut v86: Rc<str> = Rc::<str>::from("inl active_coverage_attainment");
    let mut v87: i32 = 0i32;
    let mut v88: i32 = 30i32;
    let mut v89: i32 = method3(v0.clone(), v86.clone(), v87, v1, v88);
    let mut v90: bool = v89 == v1 ;
    let mut v100: Rc<str> = if v90 {
        method1()
    } else {
        let mut v92: Rc<str> = Rc::<str>::from("\n");
        let mut v93: u8 = method5(v92.clone());
        let mut v94: i32 = method6(v0.clone(), v89, v1, v93);
        let mut v95: bool = v89 == v94 ;
        if v95 {
            method1()
        } else {
            let mut v97: i32 = v94 - 1i32 ;
            let mut v98: Rc<str> = string_slice(&v0.clone(), v89 as i64, v97 as i64);
            v98.clone()
        }
    };
    let mut v101: i32 = (v100.clone().len() as i32);
    let mut v102: bool = v101 == 0i32 ;
    let mut v127: Rc<str> = if v102 {
        method1()
    } else {
        let mut v104: i32 = 0i32;
        let mut v105: u8 = b'=';
        let mut v106: i32 = method6(v100.clone(), v104, v101, v105);
        let mut v107: bool = v106 == v101 ;
        if v107 {
            method1()
        } else {
            let mut v109: i32 = v106 + 1i32 ;
            let mut v110: i32 = method7(v100.clone(), v109, v101);
            let mut v111: bool = v110 == v101 ;
            if v111 {
                method1()
            } else {
                let mut v113: Rc<str> = Rc::<str>::from("u32");
                let mut v114: i32 = 3i32;
                let mut v115: i32 = method3(v100.clone(), v113.clone(), v110, v101, v114);
                let mut v116: bool = v115 == v101 ;
                if v116 {
                    method1()
                } else {
                    let mut v118: bool = v110 == v115 ;
                    let mut v122: Rc<str> = if v118 {
                        method1()
                    } else {
                        let mut v120: i32 = v115 - 1i32 ;
                        let mut v121: Rc<str> = string_slice(&v100.clone(), v110 as i64, v120 as i64);
                        v121.clone()
                    };
                    method8(v122.clone())
                }
            }
        }
    };
    let mut v128: Rc<str> = Rc::<str>::from("inl phase_runtime_drift");
    let mut v129: i32 = 0i32;
    let mut v130: i32 = 23i32;
    let mut v131: i32 = method3(v0.clone(), v128.clone(), v129, v1, v130);
    let mut v132: bool = v131 == v1 ;
    let mut v142: Rc<str> = if v132 {
        method1()
    } else {
        let mut v134: Rc<str> = Rc::<str>::from("\n");
        let mut v135: u8 = method5(v134.clone());
        let mut v136: i32 = method6(v0.clone(), v131, v1, v135);
        let mut v137: bool = v131 == v136 ;
        if v137 {
            method1()
        } else {
            let mut v139: i32 = v136 - 1i32 ;
            let mut v140: Rc<str> = string_slice(&v0.clone(), v131 as i64, v139 as i64);
            v140.clone()
        }
    };
    let mut v143: i32 = (v142.clone().len() as i32);
    let mut v144: bool = v143 == 0i32 ;
    let mut v169: Rc<str> = if v144 {
        method1()
    } else {
        let mut v146: i32 = 0i32;
        let mut v147: u8 = b'=';
        let mut v148: i32 = method6(v142.clone(), v146, v143, v147);
        let mut v149: bool = v148 == v143 ;
        if v149 {
            method1()
        } else {
            let mut v151: i32 = v148 + 1i32 ;
            let mut v152: i32 = method7(v142.clone(), v151, v143);
            let mut v153: bool = v152 == v143 ;
            if v153 {
                method1()
            } else {
                let mut v155: Rc<str> = Rc::<str>::from("u32");
                let mut v156: i32 = 3i32;
                let mut v157: i32 = method3(v142.clone(), v155.clone(), v152, v143, v156);
                let mut v158: bool = v157 == v143 ;
                if v158 {
                    method1()
                } else {
                    let mut v160: bool = v152 == v157 ;
                    let mut v164: Rc<str> = if v160 {
                        method1()
                    } else {
                        let mut v162: i32 = v157 - 1i32 ;
                        let mut v163: Rc<str> = string_slice(&v142.clone(), v152 as i64, v162 as i64);
                        v163.clone()
                    };
                    method8(v164.clone())
                }
            }
        }
    };
    let mut v170: Rc<str> = Rc::<str>::from("inl phase_parallel_readiness");
    let mut v171: i32 = 0i32;
    let mut v172: i32 = 28i32;
    let mut v173: i32 = method3(v0.clone(), v170.clone(), v171, v1, v172);
    let mut v174: bool = v173 == v1 ;
    let mut v184: Rc<str> = if v174 {
        method1()
    } else {
        let mut v176: Rc<str> = Rc::<str>::from("\n");
        let mut v177: u8 = method5(v176.clone());
        let mut v178: i32 = method6(v0.clone(), v173, v1, v177);
        let mut v179: bool = v173 == v178 ;
        if v179 {
            method1()
        } else {
            let mut v181: i32 = v178 - 1i32 ;
            let mut v182: Rc<str> = string_slice(&v0.clone(), v173 as i64, v181 as i64);
            v182.clone()
        }
    };
    let mut v185: i32 = (v184.clone().len() as i32);
    let mut v186: bool = v185 == 0i32 ;
    let mut v211: Rc<str> = if v186 {
        method1()
    } else {
        let mut v188: i32 = 0i32;
        let mut v189: u8 = b'=';
        let mut v190: i32 = method6(v184.clone(), v188, v185, v189);
        let mut v191: bool = v190 == v185 ;
        if v191 {
            method1()
        } else {
            let mut v193: i32 = v190 + 1i32 ;
            let mut v194: i32 = method7(v184.clone(), v193, v185);
            let mut v195: bool = v194 == v185 ;
            if v195 {
                method1()
            } else {
                let mut v197: Rc<str> = Rc::<str>::from("u32");
                let mut v198: i32 = 3i32;
                let mut v199: i32 = method3(v184.clone(), v197.clone(), v194, v185, v198);
                let mut v200: bool = v199 == v185 ;
                if v200 {
                    method1()
                } else {
                    let mut v202: bool = v194 == v199 ;
                    let mut v206: Rc<str> = if v202 {
                        method1()
                    } else {
                        let mut v204: i32 = v199 - 1i32 ;
                        let mut v205: Rc<str> = string_slice(&v184.clone(), v194 as i64, v204 as i64);
                        v205.clone()
                    };
                    method8(v206.clone())
                }
            }
        }
    };
    let mut v212: Rc<str> = Rc::<str>::from("inl phase_plan_ir");
    let mut v213: i32 = 0i32;
    let mut v214: i32 = 17i32;
    let mut v215: i32 = method3(v0.clone(), v212.clone(), v213, v1, v214);
    let mut v216: bool = v215 == v1 ;
    let mut v226: Rc<str> = if v216 {
        method1()
    } else {
        let mut v218: Rc<str> = Rc::<str>::from("\n");
        let mut v219: u8 = method5(v218.clone());
        let mut v220: i32 = method6(v0.clone(), v215, v1, v219);
        let mut v221: bool = v215 == v220 ;
        if v221 {
            method1()
        } else {
            let mut v223: i32 = v220 - 1i32 ;
            let mut v224: Rc<str> = string_slice(&v0.clone(), v215 as i64, v223 as i64);
            v224.clone()
        }
    };
    let mut v227: i32 = (v226.clone().len() as i32);
    let mut v228: bool = v227 == 0i32 ;
    let mut v253: Rc<str> = if v228 {
        method1()
    } else {
        let mut v230: i32 = 0i32;
        let mut v231: u8 = b'=';
        let mut v232: i32 = method6(v226.clone(), v230, v227, v231);
        let mut v233: bool = v232 == v227 ;
        if v233 {
            method1()
        } else {
            let mut v235: i32 = v232 + 1i32 ;
            let mut v236: i32 = method7(v226.clone(), v235, v227);
            let mut v237: bool = v236 == v227 ;
            if v237 {
                method1()
            } else {
                let mut v239: Rc<str> = Rc::<str>::from("u32");
                let mut v240: i32 = 3i32;
                let mut v241: i32 = method3(v226.clone(), v239.clone(), v236, v227, v240);
                let mut v242: bool = v241 == v227 ;
                if v242 {
                    method1()
                } else {
                    let mut v244: bool = v236 == v241 ;
                    let mut v248: Rc<str> = if v244 {
                        method1()
                    } else {
                        let mut v246: i32 = v241 - 1i32 ;
                        let mut v247: Rc<str> = string_slice(&v226.clone(), v236 as i64, v246 as i64);
                        v247.clone()
                    };
                    method8(v248.clone())
                }
            }
        }
    };
    let mut v254: Rc<str> = Rc::<str>::from("inl migration ()");
    let mut v255: i32 = 0i32;
    let mut v256: i32 = 16i32;
    let mut v257: i32 = method3(v0.clone(), v254.clone(), v255, v1, v256);
    let mut v258: bool = v257 == v1 ;
    let mut v268: Rc<str> = if v258 {
        method1()
    } else {
        let mut v260: Rc<str> = Rc::<str>::from("\n");
        let mut v261: u8 = method5(v260.clone());
        let mut v262: i32 = method6(v0.clone(), v257, v1, v261);
        let mut v263: bool = v257 == v262 ;
        if v263 {
            method1()
        } else {
            let mut v265: i32 = v262 - 1i32 ;
            let mut v266: Rc<str> = string_slice(&v0.clone(), v257 as i64, v265 as i64);
            v266.clone()
        }
    };
    let mut v269: i32 = (v268.clone().len() as i32);
    let mut v270: bool = v269 == 0i32 ;
    let mut v295: Rc<str> = if v270 {
        method1()
    } else {
        let mut v272: i32 = 0i32;
        let mut v273: u8 = b'=';
        let mut v274: i32 = method6(v268.clone(), v272, v269, v273);
        let mut v275: bool = v274 == v269 ;
        if v275 {
            method1()
        } else {
            let mut v277: i32 = v274 + 1i32 ;
            let mut v278: i32 = method7(v268.clone(), v277, v269);
            let mut v279: bool = v278 == v269 ;
            if v279 {
                method1()
            } else {
                let mut v281: Rc<str> = Rc::<str>::from("u32");
                let mut v282: i32 = 3i32;
                let mut v283: i32 = method3(v268.clone(), v281.clone(), v278, v269, v282);
                let mut v284: bool = v283 == v269 ;
                if v284 {
                    method1()
                } else {
                    let mut v286: bool = v278 == v283 ;
                    let mut v290: Rc<str> = if v286 {
                        method1()
                    } else {
                        let mut v288: i32 = v283 - 1i32 ;
                        let mut v289: Rc<str> = string_slice(&v268.clone(), v278 as i64, v288 as i64);
                        v289.clone()
                    };
                    method8(v290.clone())
                }
            }
        }
    };
    let mut v296: Rc<str> = Rc::<str>::from("");
    let mut v297: bool = v43 == v296 ;
    if v297 {
        method1()
    } else {
        let mut v299: bool = v85 == v296 ;
        if v299 {
            method1()
        } else {
            let mut v301: bool = v127 == v296 ;
            if v301 {
                method1()
            } else {
                let mut v303: bool = v169 == v296 ;
                if v303 {
                    method1()
                } else {
                    let mut v305: bool = v211 == v296 ;
                    if v305 {
                        method1()
                    } else {
                        let mut v307: bool = v253 == v296 ;
                        if v307 {
                            method1()
                        } else {
                            let mut v309: bool = v295 == v296 ;
                            if v309 {
                                method1()
                            } else {
                                let mut v311: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("active_readiness="), v43.clone()));
                                let mut v312: Rc<str> = Rc::<str>::from(format!("{}{}", v311.clone(), Rc::<str>::from("/1000 subjective_ceiling=")));
                                let mut v313: Rc<str> = Rc::<str>::from(format!("{}{}", v312.clone(), v85.clone()));
                                let mut v314: Rc<str> = Rc::<str>::from(format!("{}{}", v313.clone(), Rc::<str>::from("/1000 coverage=")));
                                let mut v315: Rc<str> = Rc::<str>::from(format!("{}{}", v314.clone(), v127.clone()));
                                let mut v316: Rc<str> = Rc::<str>::from(format!("{}{}", v315.clone(), Rc::<str>::from("/1000 runtime_drift=")));
                                let mut v317: Rc<str> = Rc::<str>::from(format!("{}{}", v316.clone(), v169.clone()));
                                let mut v318: Rc<str> = Rc::<str>::from(format!("{}{}", v317.clone(), Rc::<str>::from("/1000 parallel_readiness=")));
                                let mut v319: Rc<str> = Rc::<str>::from(format!("{}{}", v318.clone(), v211.clone()));
                                let mut v320: Rc<str> = Rc::<str>::from(format!("{}{}", v319.clone(), Rc::<str>::from("/1000 canonical_plan_ir=")));
                                let mut v321: Rc<str> = Rc::<str>::from(format!("{}{}", v320.clone(), v253.clone()));
                                let mut v322: Rc<str> = Rc::<str>::from(format!("{}{}", v321.clone(), Rc::<str>::from("/1000 migration_historical=")));
                                let mut v323: Rc<str> = Rc::<str>::from(format!("{}{}", v322.clone(), v295.clone()));
                                let mut v324: Rc<str> = Rc::<str>::from(format!("{}{}", v323.clone(), Rc::<str>::from("/1000")));
                                v324.clone()
                            }
                        }
                    }
                }
            }
        }
    }
}
fn method11(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: Rc<str>) -> Rc<str> {
    loop {
        let mut v5: i32 = method7(v0.clone(), v1, v2);
        let mut v6: bool = v5 == v2 ;
        if v6 {
            let mut v7: bool = v3 == 10i32 ;
            if v7 {
                return v4.clone();
            } else {
                return method1();
            }
        } else {
            let mut v10: bool = v3 >= 10i32;
            if v10 {
                return method1();
            } else {
                let mut v12: Rc<str> = Rc::<str>::from("u32");
                let mut v13: i32 = (v0.clone().len() as i32);
                let mut v14: i32 = 3i32;
                let mut v15: i32 = method3(v0.clone(), v12.clone(), v5, v13, v14);
                let mut v16: bool = v15 == v2 ;
                if v16 {
                    return method1();
                } else {
                    let mut v18: bool = v5 == v15 ;
                    let mut v22: Rc<str> = if v18 {
                        method1()
                    } else {
                        let mut v20: i32 = v15 - 1i32 ;
                        let mut v21: Rc<str> = string_slice(&v0.clone(), v5 as i64, v20 as i64);
                        v21.clone()
                    };
                    let mut v23: Rc<str> = method8(v22.clone());
                    let mut v24: Rc<str> = Rc::<str>::from("");
                    let mut v25: bool = v23 == v24 ;
                    if v25 {
                        return method1();
                    } else {
                        let mut v27: bool = v3 == 0i32 ;
                        let mut v54: Rc<str> = if v27 {
                            let mut v28: Rc<str> = Rc::<str>::from("spiral_files=");
                            v28.clone()
                        } else {
                            let mut v29: bool = v3 == 1i32 ;
                            if v29 {
                                let mut v30: Rc<str> = Rc::<str>::from(" generated_rust_files=");
                                v30.clone()
                            } else {
                                let mut v31: bool = v3 == 2i32 ;
                                if v31 {
                                    let mut v32: Rc<str> = Rc::<str>::from(" rust_global_sites=");
                                    v32.clone()
                                } else {
                                    let mut v33: bool = v3 == 3i32 ;
                                    if v33 {
                                        let mut v34: Rc<str> = Rc::<str>::from(" spiral_loc=");
                                        v34.clone()
                                    } else {
                                        let mut v35: bool = v3 == 4i32 ;
                                        if v35 {
                                            let mut v36: Rc<str> = Rc::<str>::from(" generated_rust_loc=");
                                            v36.clone()
                                        } else {
                                            let mut v37: bool = v3 == 5i32 ;
                                            if v37 {
                                                let mut v38: Rc<str> = Rc::<str>::from(" cargo_crates=");
                                                v38.clone()
                                            } else {
                                                let mut v39: bool = v3 == 6i32 ;
                                                if v39 {
                                                    let mut v40: Rc<str> = Rc::<str>::from(" spiral_packages=");
                                                    v40.clone()
                                                } else {
                                                    let mut v41: bool = v3 == 7i32 ;
                                                    if v41 {
                                                        let mut v42: Rc<str> = Rc::<str>::from(" package_only=");
                                                        v42.clone()
                                                    } else {
                                                        let mut v43: bool = v3 == 8i32 ;
                                                        if v43 {
                                                            let mut v44: Rc<str> = Rc::<str>::from(" max_crate_loc=");
                                                            v44.clone()
                                                        } else {
                                                            let mut v45: Rc<str> = Rc::<str>::from(" max_rust_file_loc=");
                                                            v45.clone()
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        };
                        let mut v55: Rc<str> = Rc::<str>::from(format!("{}{}", v54.clone(), v23.clone()));
                        let mut v56: i32 = v15 + 3i32 ;
                        let mut v57: i32 = v3 + 1i32 ;
                        let mut v58: Rc<str> = Rc::<str>::from(format!("{}{}", v4.clone(), v55.clone()));
                        (v0, v1, v2, v3, v4) = (v0.clone(), v56, v2, v57, v58.clone());
                        continue;
                    }
                }
            }
        }
    }
}
fn method10(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("AuthorityCensus (");
    let mut v3: i32 = 0i32;
    let mut v4: i32 = 17i32;
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
        let mut v20: i32 = 0i32;
        let mut v21: i32 = 0i32;
        let mut v22: Rc<str> = Rc::<str>::from("");
        method11(v16.clone(), v20, v17, v21, v22.clone())
    }
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method0(v0.clone())
    })
}
fn closure1() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method10(v0.clone())
    })
}
pub fn eoie_handoff_ratings_projection(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
pub fn eoie_handoff_census_projection(v0: &str) -> Rc<str> {
    closure1()(Rc::<str>::from(v0))
}
