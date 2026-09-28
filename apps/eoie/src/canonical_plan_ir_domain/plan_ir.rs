#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CanonicalPlanRow { pub op: String, pub target: String, pub expected: String, pub payload: String, pub effect: String }

fn plan_hex_nibble(byte: u8) -> Option<u8> { match byte { b'0'..=b'9' => Some(byte-b'0'), b'a'..=b'f' => Some(byte-b'a'+10), b'A'..=b'F' => Some(byte-b'A'+10), _ => None } }
fn plan_hex_decode(value: &str) -> Result<String,String> { if !value.len().is_multiple_of(2) { return Err("canonical plan IR hex field has odd length".to_owned()); } let bytes=value.as_bytes(); let mut out=Vec::with_capacity(bytes.len()/2); let mut index=0usize; while index<bytes.len() { let hi=plan_hex_nibble(bytes[index]).ok_or_else(|| "canonical plan IR contains non-hex data".to_owned())?; let lo=plan_hex_nibble(bytes[index+1]).ok_or_else(|| "canonical plan IR contains non-hex data".to_owned())?; out.push((hi<<4)|lo); index+=2; } String::from_utf8(out).map_err(|error| format!("canonical plan IR field is not UTF-8: {error}")) }

pub fn parse_plan_ir_manifest(text: &str) -> Result<Vec<CanonicalPlanRow>,String> { let mut lines=text.lines(); let header=lines.next().unwrap_or_default(); if eoie_plan_ir_header_projection(header).as_ref()!="1" { return Err("canonical plan IR header mismatch".to_owned()); } let mut rows=Vec::new(); for (index,line) in lines.enumerate() { if line.is_empty() { continue; } let (op_hex,target_hex,expected_hex,payload_hex,effect_hex)=eoie_plan_ir_row_hex_tuple(line); if op_hex.is_empty() { return Err(format!("canonical plan IR row {} has invalid shape", index+1)); } let row=CanonicalPlanRow { op:plan_hex_decode(op_hex.as_ref())?, target:plan_hex_decode(target_hex.as_ref())?, expected:plan_hex_decode(expected_hex.as_ref())?, payload:plan_hex_decode(payload_hex.as_ref())?, effect:plan_hex_decode(effect_hex.as_ref())? }; let code=eoie_plan_ir_decode_code(&row.op,&row.target,&row.expected,&row.payload,&row.effect); if code>=8 { return Err(format!("canonical plan IR row {} was rejected by Spiral decoder", index+1)); } rows.push(row); } if rows.is_empty() { return Err("canonical plan IR manifest contains no operations".to_owned()); } Ok(rows) }
pub fn plan_ir_manifest_count(value: &str) -> i32 { let header=value.lines().next().unwrap_or_default(); if eoie_plan_ir_header_projection(header).as_ref()=="1" { match parse_plan_ir_manifest(value) { Ok(rows) => i32::try_from(rows.len()).unwrap_or(-1), Err(_) => -1 } } else if header.starts_with("EOIE-PLAN-IR") { -1 } else { 0 } }

fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return Rc::<str>::from(""); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
fn method0(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("schema");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("canonical-plan-ir");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("invalid");
        v4.clone()
    }
}
fn method1(mut v0: Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    let mut v1: Rc<str> = Rc::<str>::from("0");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("create");
        let mut v4: Rc<str> = Rc::<str>::from("state/example.spi");
        let mut v5: Rc<str> = Rc::<str>::from("-");
        let mut v6: Rc<str> = Rc::<str>::from("typed-payload");
        let mut v7: Rc<str> = Rc::<str>::from("write");
        (v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7.clone())
    } else {
        let mut v8: Rc<str> = Rc::<str>::from("1");
        let mut v9: bool = v0 == v8 ;
        if v9 {
            let mut v10: Rc<str> = Rc::<str>::from("replace");
            let mut v11: Rc<str> = Rc::<str>::from("src/example.spi");
            let mut v12: Rc<str> = Rc::<str>::from("expected");
            let mut v13: Rc<str> = Rc::<str>::from("replacement");
            let mut v14: Rc<str> = Rc::<str>::from("write");
            (v10.clone(), v11.clone(), v12.clone(), v13.clone(), v14.clone())
        } else {
            let mut v15: Rc<str> = Rc::<str>::from("2");
            let mut v16: bool = v0 == v15 ;
            if v16 {
                let mut v17: Rc<str> = Rc::<str>::from("patch-exact");
                let mut v18: Rc<str> = Rc::<str>::from("src/example.spi");
                let mut v19: Rc<str> = Rc::<str>::from("old");
                let mut v20: Rc<str> = Rc::<str>::from("new");
                let mut v21: Rc<str> = Rc::<str>::from("write");
                (v17.clone(), v18.clone(), v19.clone(), v20.clone(), v21.clone())
            } else {
                let mut v22: Rc<str> = Rc::<str>::from("3");
                let mut v23: bool = v0 == v22 ;
                if v23 {
                    let mut v24: Rc<str> = Rc::<str>::from("mkdir");
                    let mut v25: Rc<str> = Rc::<str>::from("src/generated");
                    let mut v26: Rc<str> = Rc::<str>::from("-");
                    let mut v27: Rc<str> = Rc::<str>::from("write");
                    (v24.clone(), v25.clone(), v26.clone(), v26.clone(), v27.clone())
                } else {
                    let mut v28: Rc<str> = Rc::<str>::from("4");
                    let mut v29: bool = v0 == v28 ;
                    if v29 {
                        let mut v30: Rc<str> = Rc::<str>::from("toolchain");
                        let mut v31: Rc<str> = Rc::<str>::from("cargo-check");
                        let mut v32: Rc<str> = Rc::<str>::from("-");
                        (v30.clone(), v31.clone(), v32.clone(), v32.clone(), v30.clone())
                    } else {
                        let mut v33: Rc<str> = Rc::<str>::from("5");
                        let mut v34: bool = v0 == v33 ;
                        if v34 {
                            let mut v35: Rc<str> = Rc::<str>::from("copy");
                            let mut v36: Rc<str> = Rc::<str>::from("src/copied.spi");
                            let mut v37: Rc<str> = Rc::<str>::from("expected-sha");
                            let mut v38: Rc<str> = Rc::<str>::from("src/source.spi");
                            let mut v39: Rc<str> = Rc::<str>::from("write");
                            (v35.clone(), v36.clone(), v37.clone(), v38.clone(), v39.clone())
                        } else {
                            let mut v40: Rc<str> = Rc::<str>::from("6");
                            let mut v41: bool = v0 == v40 ;
                            if v41 {
                                let mut v42: Rc<str> = Rc::<str>::from("chmod");
                                let mut v43: Rc<str> = Rc::<str>::from("src/tool");
                                let mut v44: Rc<str> = Rc::<str>::from("0755");
                                let mut v45: Rc<str> = Rc::<str>::from("0644");
                                let mut v46: Rc<str> = Rc::<str>::from("write");
                                (v42.clone(), v43.clone(), v44.clone(), v45.clone(), v46.clone())
                            } else {
                                let mut v47: Rc<str> = Rc::<str>::from("7");
                                let mut v48: bool = v0 == v47 ;
                                if v48 {
                                    let mut v49: Rc<str> = Rc::<str>::from("symlink");
                                    let mut v50: Rc<str> = Rc::<str>::from("src/current");
                                    let mut v51: Rc<str> = Rc::<str>::from("-");
                                    let mut v52: Rc<str> = Rc::<str>::from("src/target");
                                    let mut v53: Rc<str> = Rc::<str>::from("write");
                                    (v49.clone(), v50.clone(), v51.clone(), v52.clone(), v53.clone())
                                } else {
                                    let mut v54: Rc<str> = Rc::<str>::from("invalid");
                                    let mut v55: Rc<str> = Rc::<str>::from("");
                                    (v54.clone(), v55.clone(), v55.clone(), v55.clone(), v54.clone())
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
fn method4() -> Rc<str> {
    let mut v0: Rc<str> = Rc::<str>::from("");
    v0.clone()
}
fn method3() -> Rc<str> {
    method4()
}
fn method2(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("EOIE-PLAN-IR\t1");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("1");
        v3.clone()
    } else {
        method3()
    }
}
fn method6(mut v0: Rc<str>) -> u8 {
    let mut v1: u8 = v0.clone().as_bytes()[0i32 as usize];
    v1
}
fn method7(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: u8) -> i32 {
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
fn method5(mut v0: Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: Rc<str> = Rc::<str>::from("\t");
    let mut v3: u8 = method6(v2.clone());
    let mut v4: i32 = 0i32;
    let mut v5: i32 = method7(v0.clone(), v4, v1, v3);
    let mut v6: bool = v5 == v1 ;
    if v6 {
        let mut v7: Rc<str> = method3();
        let mut v8: Rc<str> = method3();
        let mut v9: Rc<str> = method3();
        let mut v10: Rc<str> = method3();
        let mut v11: Rc<str> = method3();
        (v7.clone(), v8.clone(), v9.clone(), v10.clone(), v11.clone())
    } else {
        let mut v12: i32 = v5 + 1i32 ;
        let mut v13: i32 = method7(v0.clone(), v12, v1, v3);
        let mut v14: bool = v13 == v1 ;
        if v14 {
            let mut v15: Rc<str> = method3();
            let mut v16: Rc<str> = method3();
            let mut v17: Rc<str> = method3();
            let mut v18: Rc<str> = method3();
            let mut v19: Rc<str> = method3();
            (v15.clone(), v16.clone(), v17.clone(), v18.clone(), v19.clone())
        } else {
            let mut v20: i32 = v13 + 1i32 ;
            let mut v21: i32 = method7(v0.clone(), v20, v1, v3);
            let mut v22: bool = v21 == v1 ;
            if v22 {
                let mut v23: Rc<str> = method3();
                let mut v24: Rc<str> = method3();
                let mut v25: Rc<str> = method3();
                let mut v26: Rc<str> = method3();
                let mut v27: Rc<str> = method3();
                (v23.clone(), v24.clone(), v25.clone(), v26.clone(), v27.clone())
            } else {
                let mut v28: i32 = v21 + 1i32 ;
                let mut v29: i32 = method7(v0.clone(), v28, v1, v3);
                let mut v30: bool = v29 == v1 ;
                if v30 {
                    let mut v31: Rc<str> = method3();
                    let mut v32: Rc<str> = method3();
                    let mut v33: Rc<str> = method3();
                    let mut v34: Rc<str> = method3();
                    let mut v35: Rc<str> = method3();
                    (v31.clone(), v32.clone(), v33.clone(), v34.clone(), v35.clone())
                } else {
                    let mut v36: i32 = v29 + 1i32 ;
                    let mut v37: i32 = method7(v0.clone(), v36, v1, v3);
                    let mut v38: bool = v37 == v1 ;
                    if v38 {
                        let mut v39: Rc<str> = method3();
                        let mut v40: Rc<str> = method3();
                        let mut v41: Rc<str> = method3();
                        let mut v42: Rc<str> = method3();
                        let mut v43: Rc<str> = method3();
                        (v39.clone(), v40.clone(), v41.clone(), v42.clone(), v43.clone())
                    } else {
                        let mut v44: i32 = v37 + 1i32 ;
                        let mut v45: i32 = method7(v0.clone(), v44, v1, v3);
                        let mut v46: bool = 0i32 == v5 ;
                        let mut v50: Rc<str> = if v46 {
                            method3()
                        } else {
                            let mut v48: i32 = v5 - 1i32 ;
                            let mut v49: Rc<str> = string_slice(&v0.clone(), 0i32 as i64, v48 as i64);
                            v49.clone()
                        };
                        let mut v51: bool = v45 < v1;
                        if v51 {
                            let mut v52: Rc<str> = method3();
                            let mut v53: Rc<str> = method3();
                            let mut v54: Rc<str> = method3();
                            let mut v55: Rc<str> = method3();
                            let mut v56: Rc<str> = method3();
                            (v52.clone(), v53.clone(), v54.clone(), v55.clone(), v56.clone())
                        } else {
                            let mut v57: Rc<str> = Rc::<str>::from("op");
                            let mut v58: bool = v50 == v57 ;
                            if v58 {
                                let mut v59: i32 = v5 + 1i32 ;
                                let mut v60: bool = v59 == v13 ;
                                let mut v64: Rc<str> = if v60 {
                                    method3()
                                } else {
                                    let mut v62: i32 = v13 - 1i32 ;
                                    let mut v63: Rc<str> = string_slice(&v0.clone(), v59 as i64, v62 as i64);
                                    v63.clone()
                                };
                                let mut v65: i32 = v13 + 1i32 ;
                                let mut v66: bool = v65 == v21 ;
                                let mut v70: Rc<str> = if v66 {
                                    method3()
                                } else {
                                    let mut v68: i32 = v21 - 1i32 ;
                                    let mut v69: Rc<str> = string_slice(&v0.clone(), v65 as i64, v68 as i64);
                                    v69.clone()
                                };
                                let mut v71: i32 = v21 + 1i32 ;
                                let mut v72: bool = v71 == v29 ;
                                let mut v76: Rc<str> = if v72 {
                                    method3()
                                } else {
                                    let mut v74: i32 = v29 - 1i32 ;
                                    let mut v75: Rc<str> = string_slice(&v0.clone(), v71 as i64, v74 as i64);
                                    v75.clone()
                                };
                                let mut v77: i32 = v29 + 1i32 ;
                                let mut v78: bool = v77 == v37 ;
                                let mut v82: Rc<str> = if v78 {
                                    method3()
                                } else {
                                    let mut v80: i32 = v37 - 1i32 ;
                                    let mut v81: Rc<str> = string_slice(&v0.clone(), v77 as i64, v80 as i64);
                                    v81.clone()
                                };
                                let mut v83: i32 = v37 + 1i32 ;
                                let mut v84: bool = v83 == v1 ;
                                let mut v88: Rc<str> = if v84 {
                                    method3()
                                } else {
                                    let mut v86: i32 = v1 - 1i32 ;
                                    let mut v87: Rc<str> = string_slice(&v0.clone(), v83 as i64, v86 as i64);
                                    v87.clone()
                                };
                                (v64.clone(), v70.clone(), v76.clone(), v82.clone(), v88.clone())
                            } else {
                                let mut v89: Rc<str> = method3();
                                let mut v90: Rc<str> = method3();
                                let mut v91: Rc<str> = method3();
                                let mut v92: Rc<str> = method3();
                                let mut v93: Rc<str> = method3();
                                (v89.clone(), v90.clone(), v91.clone(), v92.clone(), v93.clone())
                            }
                        }
                    }
                }
            }
        }
    }
}
fn method8() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("EOIE-PLAN-IR\t1");
    let mut v1: Rc<str> = method2(v0.clone());
    let mut v2: Rc<str> = Rc::<str>::from("1");
    let mut v3: bool = v1 == v2 ;
    if v3 {
        let mut v4: Rc<str> = Rc::<str>::from("EOIE-PLAN-IR\t2");
        let mut v5: Rc<str> = method2(v4.clone());
        let mut v6: Rc<str> = Rc::<str>::from("");
        let mut v7: bool = v5 == v6 ;
        if v7 {
            let mut v8: Rc<str> = Rc::<str>::from("op\t01\t02\t03\t04\t05");
            let (mut v9, mut v10, mut v11, mut v12, mut v13): (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) = method5(v8.clone());
            let mut v14: Rc<str> = Rc::<str>::from("01");
            let mut v15: bool = v9 == v14 ;
            if v15 {
                let mut v16: Rc<str> = Rc::<str>::from("02");
                let mut v17: bool = v10 == v16 ;
                if v17 {
                    let mut v18: Rc<str> = Rc::<str>::from("03");
                    let mut v19: bool = v11 == v18 ;
                    if v19 {
                        let mut v20: Rc<str> = Rc::<str>::from("04");
                        let mut v21: bool = v12 == v20 ;
                        if v21 {
                            let mut v22: Rc<str> = Rc::<str>::from("05");
                            let mut v23: bool = v13 == v22 ;
                            if v23 {
                                let mut v24: Rc<str> = Rc::<str>::from("op\t01\t02\t03\t04\t05\t06");
                                let (mut v25, mut v26, mut v27, mut v28, mut v29): (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) = method5(v24.clone());
                                let mut v30: bool = v25 == v6 ;
                                if v30 {
                                    let mut v31: bool = v26 == v6 ;
                                    if v31 {
                                        let mut v32: bool = v27 == v6 ;
                                        if v32 {
                                            let mut v33: bool = v28 == v6 ;
                                            if v33 {
                                                let mut v34: bool = v29 == v6 ;
                                                if v34 {
                                                    1i32
                                                } else {
                                                    0i32
                                                }
                                            } else {
                                                0i32
                                            }
                                        } else {
                                            0i32
                                        }
                                    } else {
                                        0i32
                                    }
                                } else {
                                    0i32
                                }
                            } else {
                                0i32
                            }
                        } else {
                            0i32
                        }
                    } else {
                        0i32
                    }
                } else {
                    0i32
                }
            } else {
                0i32
            }
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method9() -> i32 {
    8i32
}
fn method10() -> i32 {
    1i32
}
fn method11(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("0|1|2|3|4|5|6|7");
    let mut v2: bool = v1.split("|").any(|item| item == &*v0);
    if v2 {
        1u64
    } else {
        0u64
    }
}
fn method12(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: Rc<str>, mut v3: Rc<str>, mut v4: Rc<str>) -> u64 {
    let mut v5: Rc<str> = Rc::<str>::from("create");
    let mut v6: bool = v0 == v5 ;
    let mut v9: bool = if v6 {
        let mut v7: Rc<str> = Rc::<str>::from("write");
        let mut v8: bool = v4 == v7 ;
        v8
    } else {
        false
    };
    if v9 {
        let mut v10: Rc<str> = Rc::<str>::from("|-");
        let mut v11: bool = v10.split("|").any(|item| item == &*v1);
        if v11 {
            8u64
        } else {
            let mut v12: Rc<str> = Rc::<str>::from("-");
            let mut v13: bool = v2 == v12 ;
            if v13 {
                0u64
            } else {
                8u64
            }
        }
    } else {
        let mut v16: Rc<str> = Rc::<str>::from("replace");
        let mut v17: bool = v0 == v16 ;
        let mut v20: bool = if v17 {
            let mut v18: Rc<str> = Rc::<str>::from("write");
            let mut v19: bool = v4 == v18 ;
            v19
        } else {
            false
        };
        if v20 {
            let mut v21: Rc<str> = Rc::<str>::from("|-");
            let mut v22: bool = v21.split("|").any(|item| item == &*v1);
            if v22 {
                8u64
            } else {
                let mut v23: bool = v21.split("|").any(|item| item == &*v2);
                if v23 {
                    8u64
                } else {
                    1u64
                }
            }
        } else {
            let mut v26: Rc<str> = Rc::<str>::from("patch-exact");
            let mut v27: bool = v0 == v26 ;
            let mut v30: bool = if v27 {
                let mut v28: Rc<str> = Rc::<str>::from("write");
                let mut v29: bool = v4 == v28 ;
                v29
            } else {
                false
            };
            if v30 {
                let mut v31: Rc<str> = Rc::<str>::from("|-");
                let mut v32: bool = v31.split("|").any(|item| item == &*v1);
                if v32 {
                    8u64
                } else {
                    2u64
                }
            } else {
                let mut v34: Rc<str> = Rc::<str>::from("mkdir");
                let mut v35: bool = v0 == v34 ;
                let mut v38: bool = if v35 {
                    let mut v36: Rc<str> = Rc::<str>::from("write");
                    let mut v37: bool = v4 == v36 ;
                    v37
                } else {
                    false
                };
                if v38 {
                    let mut v39: Rc<str> = Rc::<str>::from("|-");
                    let mut v40: bool = v39.split("|").any(|item| item == &*v1);
                    if v40 {
                        8u64
                    } else {
                        let mut v41: Rc<str> = Rc::<str>::from("-");
                        let mut v42: bool = v2 == v41 ;
                        let mut v44: bool = if v42 {
                            let mut v43: bool = v3 == v41 ;
                            v43
                        } else {
                            false
                        };
                        if v44 {
                            3u64
                        } else {
                            8u64
                        }
                    }
                } else {
                    let mut v47: Rc<str> = Rc::<str>::from("toolchain");
                    let mut v48: bool = v0 == v47 ;
                    let mut v50: bool = if v48 {
                        let mut v49: bool = v4 == v47 ;
                        v49
                    } else {
                        false
                    };
                    if v50 {
                        let mut v51: Rc<str> = Rc::<str>::from("|-");
                        let mut v52: bool = v51.split("|").any(|item| item == &*v1);
                        if v52 {
                            8u64
                        } else {
                            let mut v53: Rc<str> = Rc::<str>::from("-");
                            let mut v54: bool = v2 == v53 ;
                            let mut v56: bool = if v54 {
                                let mut v55: bool = v3 == v53 ;
                                v55
                            } else {
                                false
                            };
                            if v56 {
                                4u64
                            } else {
                                8u64
                            }
                        }
                    } else {
                        let mut v59: Rc<str> = Rc::<str>::from("copy");
                        let mut v60: bool = v0 == v59 ;
                        let mut v63: bool = if v60 {
                            let mut v61: Rc<str> = Rc::<str>::from("write");
                            let mut v62: bool = v4 == v61 ;
                            v62
                        } else {
                            false
                        };
                        if v63 {
                            let mut v64: Rc<str> = Rc::<str>::from("|-");
                            let mut v65: bool = v64.split("|").any(|item| item == &*v1);
                            if v65 {
                                8u64
                            } else {
                                let mut v66: bool = v64.split("|").any(|item| item == &*v2);
                                if v66 {
                                    8u64
                                } else {
                                    let mut v67: bool = v64.split("|").any(|item| item == &*v3);
                                    if v67 {
                                        8u64
                                    } else {
                                        5u64
                                    }
                                }
                            }
                        } else {
                            let mut v71: Rc<str> = Rc::<str>::from("chmod");
                            let mut v72: bool = v0 == v71 ;
                            let mut v75: bool = if v72 {
                                let mut v73: Rc<str> = Rc::<str>::from("write");
                                let mut v74: bool = v4 == v73 ;
                                v74
                            } else {
                                false
                            };
                            if v75 {
                                let mut v76: Rc<str> = Rc::<str>::from("|-");
                                let mut v77: bool = v76.split("|").any(|item| item == &*v1);
                                if v77 {
                                    8u64
                                } else {
                                    let mut v78: bool = v76.split("|").any(|item| item == &*v2);
                                    if v78 {
                                        8u64
                                    } else {
                                        let mut v79: bool = v76.split("|").any(|item| item == &*v3);
                                        if v79 {
                                            8u64
                                        } else {
                                            6u64
                                        }
                                    }
                                }
                            } else {
                                let mut v83: Rc<str> = Rc::<str>::from("symlink");
                                let mut v84: bool = v0 == v83 ;
                                let mut v87: bool = if v84 {
                                    let mut v85: Rc<str> = Rc::<str>::from("write");
                                    let mut v86: bool = v4 == v85 ;
                                    v86
                                } else {
                                    false
                                };
                                if v87 {
                                    let mut v88: Rc<str> = Rc::<str>::from("|-");
                                    let mut v89: bool = v88.split("|").any(|item| item == &*v1);
                                    if v89 {
                                        8u64
                                    } else {
                                        let mut v90: Rc<str> = Rc::<str>::from("-");
                                        let mut v91: bool = v2 == v90 ;
                                        if v91 {
                                            let mut v92: bool = v88.split("|").any(|item| item == &*v3);
                                            if v92 {
                                                8u64
                                            } else {
                                                7u64
                                            }
                                        } else {
                                            8u64
                                        }
                                    }
                                } else {
                                    8u64
                                }
                            }
                        }
                    }
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
fn closure1() -> Rc<dyn Fn(Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>)> {
    Rc::new(move |mut v0: Rc<str>| -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
        method1(v0.clone())
    })
}
fn closure2() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method2(v0.clone())
    })
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>)> {
    Rc::new(move |mut v0: Rc<str>| -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
        method5(v0.clone())
    })
}
fn closure4() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method8()
    })
}
fn closure5() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method9()
    })
}
fn closure6() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method10()
    })
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method11(v0.clone())
    })
}
fn closure8() -> Rc<dyn Fn(Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>, mut v1: Rc<str>, mut v2: Rc<str>, mut v3: Rc<str>, mut v4: Rc<str>| -> u64 {
        method12(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone())
    })
}
pub fn eoie_plan_ir_schema(v0: &str) -> Rc<str> {
    closure0()(Rc::<str>::from(v0))
}
pub fn eoie_plan_ir_descriptor(v0: &str) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    closure1()(Rc::<str>::from(v0))
}
pub fn eoie_plan_ir_header_projection(v0: &str) -> Rc<str> {
    closure2()(Rc::<str>::from(v0))
}
pub fn eoie_plan_ir_row_hex_tuple(v0: &str) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {
    closure3()(Rc::<str>::from(v0))
}
pub fn eoie_plan_ir_projection_witness() -> i32 {
    closure4()()
}
pub fn eoie_plan_ir_count() -> i32 {
    closure5()()
}
pub fn eoie_plan_ir_stage_witness() -> i32 {
    closure6()()
}
pub fn eoie_plan_ir_index_valid(v0: &str) -> u64 {
    closure7()(Rc::<str>::from(v0))
}
pub fn eoie_plan_ir_decode_code(v0: &str, v1: &str, v2: &str, v3: &str, v4: &str) -> u64 {
    closure8()(Rc::<str>::from(v0), Rc::<str>::from(v1), Rc::<str>::from(v2), Rc::<str>::from(v3), Rc::<str>::from(v4))
}
