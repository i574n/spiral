#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_patch_compat_driver::patch_apply_gated_context_owned;
use eoie_process::run_bounded_program_in_dir;

#[must_use]
fn patch_gated_error(message: &str) -> i32 {
    eprintln!("eoie error: {message}");
    2
}

#[must_use]
fn patch_gated_context_owned(root: &str, source: &str, validated_count: i32, gate_program: &str, timeout_ms: u64) -> i32 {
    let gate = std::path::Path::new(gate_program);
    if !gate.is_absolute() || !gate.is_file() {
        return patch_gated_error(&format!("patch gate program must be an absolute regular file: {}", gate.display()));
    }
    let root_path = std::path::Path::new(root).to_path_buf();
    patch_apply_gated_context_owned(root, source, validated_count, || {
        let status = run_bounded_program_in_dir(gate_program, &root_path, timeout_ms)?;
        if status.success() {
            Ok(())
        } else {
            Err(format!("gate program exited nonzero: {status}"))
        }
    })
}

use eoie_patch_compat_driver::{patch_plan_error, patch_prepare_source_owned, patch_rehearse_context_owned};

#[must_use]
fn patch_mutation_error(message: &str) -> i32 {
    eprintln!("eoie error: {message}");
    2
}

#[derive(Clone)]
enum US0 {
    US0_0(i32),
    US0_1,
    US0_2,
    US0_3,
    US0_4,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1 => 1,
            US0::US0_2 => 2,
            US0::US0_3 => 3,
            US0::US0_4 => 4,
        }
    }
}
#[derive(Clone)]
enum US1 {
    US1_0(i32),
    US1_1,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_0(..) => 0,
            US1::US1_1 => 1,
        }
    }
}
#[derive(Clone)]
enum US2 {
    US2_0(i32),
    US2_1,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_0(..) => 0,
            US2::US2_1 => 1,
        }
    }
}
#[derive(Clone)]
enum US3 {
    US3_0(i32),
    US3_1,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_0(..) => 0,
            US3::US3_1 => 1,
        }
    }
}
fn method3(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v1 < v2;
        if v3 {
            let mut v4: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
            let mut v5: bool = v4 == 32i32;
            if v5 {
                let mut v6: i32 = v1 + 1i32;
                (v0, v1, v2) = (v0.clone(), v6, v2);
                continue;
            } else {
                let mut v8: bool = v4 == 9i32;
                if v8 {
                    let mut v9: i32 = v1 + 1i32;
                    (v0, v1, v2) = (v0.clone(), v9, v2);
                    continue;
                } else {
                    return v1;
                }
            }
        } else {
            return v1;
        }
    }
}
fn method4(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> US1 {
    loop {
        let mut v3: bool = v1 < v2;
        if v3 {
            let mut v4: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
            let mut v5: bool = v4 == 34i32;
            if v5 {
                let mut v6: i32 = v1 + 1i32;
                return US1::US1_0(v6);
            } else {
                let mut v8: bool = v4 == 92i32;
                if v8 {
                    let mut v9: i32 = v1 + 1i32;
                    let mut v10: bool = v9 < v2;
                    if v10 {
                        let mut v11: i32 = usize::try_from(v9).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                        let mut v12: bool = v11 == 110i32;
                        let mut v20: bool = if v12 {
                            true
                        } else {
                            let mut v13: bool = v11 == 114i32;
                            if v13 {
                                true
                            } else {
                                let mut v14: bool = v11 == 116i32;
                                if v14 {
                                    true
                                } else {
                                    let mut v15: bool = v11 == 92i32;
                                    if v15 {
                                        true
                                    } else {
                                        let mut v16: bool = v11 == 34i32;
                                        v16
                                    }
                                }
                            }
                        };
                        if v20 {
                            let mut v21: i32 = v1 + 2i32;
                            (v0, v1, v2) = (v0.clone(), v21, v2);
                            continue;
                        } else {
                            return US1::US1_1;
                        }
                    } else {
                        return US1::US1_1;
                    }
                } else {
                    let mut v27: i32 = v1 + 1i32;
                    (v0, v1, v2) = (v0.clone(), v27, v2);
                    continue;
                }
            }
        } else {
            return US1::US1_1;
        }
    }
}
fn method6(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32) -> bool {
    loop {
        let mut v4: bool = v1 < v2;
        if v4 {
            let mut v5: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
            let mut v6: bool = v5 == 92i32;
            if v6 {
                return false;
            } else {
                let mut v7: bool = v5 == 47i32;
                if v7 {
                    let mut v8: i32 = v1 - v3;
                    let mut v9: bool = 0 < v8;
                    let mut v24: bool = if v9 {
                        let mut v10: bool = v8 == 1i32;
                        if v10 {
                            let mut v11: i32 = usize::try_from(v3).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                            let mut v12: bool = v11 == 46i32;
                            let mut v13: bool = v12 == false;
                            v13
                        } else {
                            let mut v14: bool = v8 == 2i32;
                            if v14 {
                                let mut v15: i32 = usize::try_from(v3).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                let mut v16: bool = v15 == 46i32;
                                if v16 {
                                    let mut v17: i32 = v3 + 1i32;
                                    let mut v18: i32 = usize::try_from(v17).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                    let mut v19: bool = v18 == 46i32;
                                    let mut v20: bool = v19 == false;
                                    v20
                                } else {
                                    true
                                }
                            } else {
                                true
                            }
                        }
                    } else {
                        false
                    };
                    if v24 {
                        let mut v25: i32 = v1 + 1i32;
                        let mut v26: i32 = v1 + 1i32;
                        (v0, v1, v2, v3) = (v0.clone(), v25, v2, v26);
                        continue;
                    } else {
                        return false;
                    }
                } else {
                    let mut v29: i32 = v1 + 1i32;
                    (v0, v1, v2, v3) = (v0.clone(), v29, v2, v3);
                    continue;
                }
            }
        } else {
            let mut v33: i32 = v2 - v3;
            let mut v34: bool = 0 < v33;
            if v34 {
                let mut v35: bool = v33 == 1i32;
                if v35 {
                    let mut v36: i32 = usize::try_from(v3).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                    let mut v37: bool = v36 == 46i32;
                    let mut v38: bool = v37 == false;
                    return v38;
                } else {
                    let mut v39: bool = v33 == 2i32;
                    if v39 {
                        let mut v40: i32 = usize::try_from(v3).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                        let mut v41: bool = v40 == 46i32;
                        if v41 {
                            let mut v42: i32 = v3 + 1i32;
                            let mut v43: i32 = usize::try_from(v42).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                            let mut v44: bool = v43 == 46i32;
                            let mut v45: bool = v44 == false;
                            return v45;
                        } else {
                            return true;
                        }
                    } else {
                        return true;
                    }
                }
            } else {
                return false;
            }
        }
    }
}
fn method5(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> bool {
    let mut v3: bool = v1 < v2;
    if v3 {
        let mut v4: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
        let mut v5: bool = v4 == 92i32;
        if v5 {
            false
        } else {
            let mut v6: bool = v4 == 47i32;
            if v6 {
                let mut v7: i32 = v1 - v1;
                let mut v8: bool = 0 < v7;
                let mut v23: bool = if v8 {
                    let mut v9: bool = v7 == 1i32;
                    if v9 {
                        let mut v10: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                        let mut v11: bool = v10 == 46i32;
                        let mut v12: bool = v11 == false;
                        v12
                    } else {
                        let mut v13: bool = v7 == 2i32;
                        if v13 {
                            let mut v14: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                            let mut v15: bool = v14 == 46i32;
                            if v15 {
                                let mut v16: i32 = v1 + 1i32;
                                let mut v17: i32 = usize::try_from(v16).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                let mut v18: bool = v17 == 46i32;
                                let mut v19: bool = v18 == false;
                                v19
                            } else {
                                true
                            }
                        } else {
                            true
                        }
                    }
                } else {
                    false
                };
                if v23 {
                    let mut v24: i32 = v1 + 1i32;
                    let mut v25: i32 = v1 + 1i32;
                    method6(v0.clone(), v24, v2, v25)
                } else {
                    false
                }
            } else {
                let mut v28: i32 = v1 + 1i32;
                method6(v0.clone(), v28, v2, v1)
            }
        }
    } else {
        let mut v32: i32 = v2 - v1;
        let mut v33: bool = 0 < v32;
        if v33 {
            let mut v34: bool = v32 == 1i32;
            if v34 {
                let mut v35: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                let mut v36: bool = v35 == 46i32;
                let mut v37: bool = v36 == false;
                v37
            } else {
                let mut v38: bool = v32 == 2i32;
                if v38 {
                    let mut v39: i32 = usize::try_from(v1).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                    let mut v40: bool = v39 == 46i32;
                    if v40 {
                        let mut v41: i32 = v1 + 1i32;
                        let mut v42: i32 = usize::try_from(v41).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                        let mut v43: bool = v42 == 46i32;
                        let mut v44: bool = v43 == false;
                        v44
                    } else {
                        true
                    }
                } else {
                    true
                }
            }
        } else {
            false
        }
    }
}
fn method2(mut v0: Rc<str>, mut v1: i32, mut v2: i32, mut v3: i32) -> US0 {
    loop {
        let mut v4: bool = v1 < v2;
        if v4 {
            let mut v5: i32 = v1 + 0i32;
            let mut v6: i32 = usize::try_from(v5).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
            let mut v7: bool = v6 == 80i32;
            let mut v51: bool = if v7 {
                let mut v8: i32 = v1 + 1i32;
                let mut v9: i32 = usize::try_from(v8).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                let mut v10: bool = v9 == 97i32;
                if v10 {
                    let mut v11: i32 = v1 + 2i32;
                    let mut v12: i32 = usize::try_from(v11).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                    let mut v13: bool = v12 == 116i32;
                    if v13 {
                        let mut v14: i32 = v1 + 3i32;
                        let mut v15: i32 = usize::try_from(v14).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                        let mut v16: bool = v15 == 99i32;
                        if v16 {
                            let mut v17: i32 = v1 + 4i32;
                            let mut v18: i32 = usize::try_from(v17).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                            let mut v19: bool = v18 == 104i32;
                            if v19 {
                                let mut v20: i32 = v1 + 5i32;
                                let mut v21: i32 = usize::try_from(v20).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                let mut v22: bool = v21 == 69i32;
                                if v22 {
                                    let mut v23: i32 = v1 + 6i32;
                                    let mut v24: i32 = usize::try_from(v23).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                    let mut v25: bool = v24 == 120i32;
                                    if v25 {
                                        let mut v26: i32 = v1 + 7i32;
                                        let mut v27: i32 = usize::try_from(v26).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                        let mut v28: bool = v27 == 97i32;
                                        if v28 {
                                            let mut v29: i32 = v1 + 8i32;
                                            let mut v30: i32 = usize::try_from(v29).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                            let mut v31: bool = v30 == 99i32;
                                            if v31 {
                                                let mut v32: i32 = v1 + 9i32;
                                                let mut v33: i32 = usize::try_from(v32).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                let mut v34: bool = v33 == 116i32;
                                                if v34 {
                                                    let mut v35: i32 = v1 + 10i32;
                                                    let mut v36: i32 = usize::try_from(v35).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                    let mut v37: bool = v36 == 32i32;
                                                    if v37 {
                                                        let mut v38: i32 = v1 + 11i32;
                                                        let mut v39: i32 = usize::try_from(v38).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                        let mut v40: bool = v39 == 40i32;
                                                        v40
                                                    } else {
                                                        false
                                                    }
                                                } else {
                                                    false
                                                }
                                            } else {
                                                false
                                            }
                                        } else {
                                            false
                                        }
                                    } else {
                                        false
                                    }
                                } else {
                                    false
                                }
                            } else {
                                false
                            }
                        } else {
                            false
                        }
                    } else {
                        false
                    }
                } else {
                    false
                }
            } else {
                false
            };
            if v51 {
                let mut v52: i32 = v1 + 12i32;
                let mut v53: i32 = method3(v0.clone(), v52, v2);
                let mut v54: bool = v53 < v2;
                let mut v62: US1 = if v54 {
                    let mut v55: i32 = usize::try_from(v53).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                    let mut v56: bool = v55 == 34i32;
                    if v56 {
                        let mut v57: i32 = v53 + 1i32;
                        method4(v0.clone(), v57, v2)
                    } else {
                        US1::US1_1
                    }
                } else {
                    US1::US1_1
                };
                let mut v145: US2 = match &v62 {
                    US1::US1_1 => { // QuotedError
                        US2::US2_1
                    }
                    US1::US1_0(v63) => { // QuotedOk
                        let mut v63: i32 = v63.clone();
                        let mut v64: i32 = v53 + 1i32;
                        let mut v65: i32 = v63 - 1i32;
                        let mut v66: i32 = v65 - v64;
                        let mut v67: bool = 0 < v66;
                        let mut v74: bool = if v67 {
                            let mut v68: i32 = usize::try_from(v64).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                            let mut v69: bool = v68 == 47i32;
                            if v69 {
                                false
                            } else {
                                let mut v70: bool = v68 == 92i32;
                                if v70 {
                                    false
                                } else {
                                    method5(v0.clone(), v64, v65)
                                }
                            }
                        } else {
                            false
                        };
                        if v74 {
                            let mut v75: i32 = method3(v0.clone(), v63, v2);
                            let mut v76: bool = v75 < v2;
                            let mut v85: US3 = if v76 {
                                let mut v77: i32 = usize::try_from(v75).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                let mut v78: bool = v77 == 44i32;
                                if v78 {
                                    let mut v79: i32 = v75 + 1i32;
                                    let mut v80: i32 = method3(v0.clone(), v79, v2);
                                    US3::US3_0(v80)
                                } else {
                                    US3::US3_1
                                }
                            } else {
                                US3::US3_1
                            };
                            match &v85 {
                                US3::US3_1 => { // SeparatorError
                                    US2::US2_1
                                }
                                US3::US3_0(v86) => { // SeparatorOk
                                    let mut v86: i32 = v86.clone();
                                    let mut v87: bool = v86 < v2;
                                    let mut v95: US1 = if v87 {
                                        let mut v88: i32 = usize::try_from(v86).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                        let mut v89: bool = v88 == 34i32;
                                        if v89 {
                                            let mut v90: i32 = v86 + 1i32;
                                            method4(v0.clone(), v90, v2)
                                        } else {
                                            US1::US1_1
                                        }
                                    } else {
                                        US1::US1_1
                                    };
                                    match &v95 {
                                        US1::US1_1 => { // QuotedError
                                            US2::US2_1
                                        }
                                        US1::US1_0(v96) => { // QuotedOk
                                            let mut v96: i32 = v96.clone();
                                            let mut v97: i32 = method3(v0.clone(), v96, v2);
                                            let mut v98: bool = v97 < v2;
                                            let mut v107: US3 = if v98 {
                                                let mut v99: i32 = usize::try_from(v97).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                let mut v100: bool = v99 == 44i32;
                                                if v100 {
                                                    let mut v101: i32 = v97 + 1i32;
                                                    let mut v102: i32 = method3(v0.clone(), v101, v2);
                                                    US3::US3_0(v102)
                                                } else {
                                                    US3::US3_1
                                                }
                                            } else {
                                                US3::US3_1
                                            };
                                            match &v107 {
                                                US3::US3_1 => { // SeparatorError
                                                    US2::US2_1
                                                }
                                                US3::US3_0(v108) => { // SeparatorOk
                                                    let mut v108: i32 = v108.clone();
                                                    let mut v109: bool = v108 < v2;
                                                    let mut v117: US1 = if v109 {
                                                        let mut v110: i32 = usize::try_from(v108).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                        let mut v111: bool = v110 == 34i32;
                                                        if v111 {
                                                            let mut v112: i32 = v108 + 1i32;
                                                            method4(v0.clone(), v112, v2)
                                                        } else {
                                                            US1::US1_1
                                                        }
                                                    } else {
                                                        US1::US1_1
                                                    };
                                                    match &v117 {
                                                        US1::US1_1 => { // QuotedError
                                                            US2::US2_1
                                                        }
                                                        US1::US1_0(v118) => { // QuotedOk
                                                            let mut v118: i32 = v118.clone();
                                                            let mut v119: i32 = method3(v0.clone(), v118, v2);
                                                            let mut v120: bool = v119 < v2;
                                                            if v120 {
                                                                let mut v121: i32 = usize::try_from(v119).ok().and_then(|index| v0.as_bytes().get(index).copied()).map_or(-1, i32::from);
                                                                let mut v122: bool = v121 == 41i32;
                                                                if v122 {
                                                                    let mut v123: i32 = v119 + 1i32;
                                                                    US2::US2_0(v123)
                                                                } else {
                                                                    US2::US2_1
                                                                }
                                                            } else {
                                                                US2::US2_1
                                                            }
                                                        }
                                                        _ => unreachable!(),
                                                    }
                                                }
                                                _ => unreachable!(),
                                            }
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                _ => unreachable!(),
                            }
                        } else {
                            US2::US2_1
                        }
                    }
                    _ => unreachable!(),
                };
                match &v145 {
                    US2::US2_1 => { // InvalidPatch
                        return US0::US0_2;
                    }
                    US2::US2_0(v146) => { // ParsedPatch
                        let mut v146: i32 = v146.clone();
                        let mut v147: i32 = v3 + 1i32;
                        (v0, v1, v2, v3) = (v0.clone(), v146, v2, v147);
                        continue;
                    }
                    _ => unreachable!(),
                }
            } else {
                let mut v152: i32 = v1 + 1i32;
                (v0, v1, v2, v3) = (v0.clone(), v152, v2, v3);
                continue;
            }
        } else {
            let mut v155: bool = 0 < v3;
            if v155 {
                return US0::US0_0(v3);
            } else {
                return US0::US0_1;
            }
        }
    }
}
fn method1() -> i32 {
    let mut v0: i32 = 4i32;
    let mut v1: bool = i32::try_from(std::env::args().skip(2).count()).unwrap_or(i32::MAX) == v0 ;
    if v1 {
        let mut v2: i32 = 1i32;
        let mut v3: Rc<str> = usize::try_from(v2).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or_else(std::rc::Rc::<str>::default, std::rc::Rc::<str>::from);
        let mut v4: i32 = 2i32;
        let mut v5: Rc<str> = usize::try_from(v4).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or_else(std::rc::Rc::<str>::default, std::rc::Rc::<str>::from);
        let mut v6: i32 = 3i32;
        let mut v7: Rc<str> = usize::try_from(v6).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or_else(std::rc::Rc::<str>::default, std::rc::Rc::<str>::from);
        let mut v8: Rc<str> = patch_prepare_source_owned(v3.as_ref(), v5.as_ref());
        let mut v9: i32 = i32::try_from(v8.len()).unwrap_or(i32::MAX);
        let mut v10: bool = 0 < v9;
        if v10 {
            let mut v11: i32 = canonical_plan_ir_domain::plan_ir_manifest_count(&v8);
            let mut v12: bool = 0 < v11;
            let mut v27: US0 = if v12 {
                US0::US0_0(v11)
            } else {
                let mut v14: bool = v11 < 0i32;
                if v14 {
                    US0::US0_2
                } else {
                    let mut v16: i32 = i32::try_from(v8.len()).unwrap_or(i32::MAX);
                    let mut v17: bool = v16 < 0i32;
                    if v17 {
                        US0::US0_4
                    } else {
                        let mut v19: bool = v16 <= 262144i32;
                        if v19 {
                            let mut v20: i32 = 0i32;
                            let mut v21: i32 = 0i32;
                            method2(v8.clone(), v20, v16, v21)
                        } else {
                            US0::US0_3
                        }
                    }
                }
            };
            let mut v33: i32 = match &v27 {
                US0::US0_1 => { // PatchPlanEmpty
                    0i32
                }
                US0::US0_2 => { // PatchPlanMalformed
                    -1i32
                }
                US0::US0_3 => { // PatchPlanTooLarge
                    -2i32
                }
                US0::US0_4 => { // PatchPlanUnavailable
                    -3i32
                }
                US0::US0_0(v28) => { // PatchPlanValid
                    let mut v28: i32 = v28.clone();
                    v28
                }
                _ => unreachable!(),
            };
            let mut v34: i32 = 0i32;
            let mut v35: Rc<str> = Rc::<str>::from("gated");
            let mut v36: bool = usize::try_from(v34).ok().and_then(|index| std::env::args().skip(2).nth(index)).is_some_and(|value| value.as_str() == v35.as_ref());
            if v36 {
                let mut v37: bool = 0 < v33;
                if v37 {
                    let mut v38: u64 = 30000u64;
                    let mut v39: i32 = patch_gated_context_owned(v3.as_ref(), v8.as_ref(), v33, v7.as_ref(), v38);
                    v39
                } else {
                    let mut v40: i32 = patch_plan_error(v33);
                    v40
                }
            } else {
                let mut v42: i32 = patch_gated_error("patch gated expects: gated <root> <plan.spi> <gate-program>");
                v42
            }
        } else {
            2i32
        }
    } else {
        let mut v45: i32 = patch_gated_error("patch gated expects: gated <root> <plan.spi> <gate-program>");
        v45
    }
}
fn method0() -> i32 {
    method1()
}
fn closure0() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method0()
    })
}
fn method8() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: bool = i32::try_from(std::env::args().skip(2).count()).unwrap_or(i32::MAX) == v0 ;
    if v1 {
        let mut v2: i32 = 1i32;
        let mut v3: Rc<str> = usize::try_from(v2).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or_else(std::rc::Rc::<str>::default, std::rc::Rc::<str>::from);
        let mut v4: i32 = 2i32;
        let mut v5: Rc<str> = usize::try_from(v4).ok().and_then(|index| std::env::args().skip(2).nth(index)).map_or_else(std::rc::Rc::<str>::default, std::rc::Rc::<str>::from);
        let mut v6: Rc<str> = patch_prepare_source_owned(v3.as_ref(), v5.as_ref());
        let mut v7: i32 = i32::try_from(v6.len()).unwrap_or(i32::MAX);
        let mut v8: bool = 0 < v7;
        if v8 {
            let mut v9: i32 = canonical_plan_ir_domain::plan_ir_manifest_count(&v6);
            let mut v10: bool = 0 < v9;
            let mut v25: US0 = if v10 {
                US0::US0_0(v9)
            } else {
                let mut v12: bool = v9 < 0i32;
                if v12 {
                    US0::US0_2
                } else {
                    let mut v14: i32 = i32::try_from(v6.len()).unwrap_or(i32::MAX);
                    let mut v15: bool = v14 < 0i32;
                    if v15 {
                        US0::US0_4
                    } else {
                        let mut v17: bool = v14 <= 262144i32;
                        if v17 {
                            let mut v18: i32 = 0i32;
                            let mut v19: i32 = 0i32;
                            method2(v6.clone(), v18, v14, v19)
                        } else {
                            US0::US0_3
                        }
                    }
                }
            };
            let mut v31: i32 = match &v25 {
                US0::US0_1 => { // PatchPlanEmpty
                    0i32
                }
                US0::US0_2 => { // PatchPlanMalformed
                    -1i32
                }
                US0::US0_3 => { // PatchPlanTooLarge
                    -2i32
                }
                US0::US0_4 => { // PatchPlanUnavailable
                    -3i32
                }
                US0::US0_0(v26) => { // PatchPlanValid
                    let mut v26: i32 = v26.clone();
                    v26
                }
                _ => unreachable!(),
            };
            let mut v32: i32 = 0i32;
            let mut v33: Rc<str> = Rc::<str>::from("rehearse");
            let mut v34: bool = usize::try_from(v32).ok().and_then(|index| std::env::args().skip(2).nth(index)).is_some_and(|value| value.as_str() == v33.as_ref());
            if v34 {
                let mut v35: bool = 0 < v31;
                if v35 {
                    let mut v36: i32 = patch_rehearse_context_owned(v3.as_ref(), v6.as_ref(), v31);
                    v36
                } else {
                    let mut v37: i32 = patch_plan_error(v31);
                    v37
                }
            } else {
                let mut v39: i32 = patch_mutation_error("patch rehearse expects: rehearse <root> <plan.spi>");
                v39
            }
        } else {
            2i32
        }
    } else {
        let mut v42: i32 = patch_mutation_error("patch rehearse expects: rehearse <root> <plan.spi>");
        v42
    }
}
fn method7() -> i32 {
    method8()
}
fn closure1() -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        method7()
    })
}
pub fn eoie_patch_gated_run() -> i32 {
    closure0()()
}
pub fn eoie_patch_rehearse_run() -> i32 {
    closure1()()
}
