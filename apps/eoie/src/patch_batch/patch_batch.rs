#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-a.txt");
    let mut v1: bool = std::fs::remove_file(&*v0).is_ok() || !std::path::Path::new(&*v0).exists();
    let mut v4: bool = if v1 {
        let mut v2: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
        let mut v3: bool = std::fs::remove_file(&*v2).is_ok() || !std::path::Path::new(&*v2).exists();
        v3
    } else {
        false
    };
    let mut v7: bool = if v4 {
        let mut v5: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-a.txt");
        let mut v6: bool = std::fs::remove_file(&*v5).is_ok() || !std::path::Path::new(&*v5).exists();
        v6
    } else {
        false
    };
    let mut v10: bool = if v7 {
        let mut v8: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
        let mut v9: bool = std::fs::remove_file(&*v8).is_ok() || !std::path::Path::new(&*v8).exists();
        v9
    } else {
        false
    };
    let mut v13: bool = if v10 {
        let mut v11: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
        let mut v12: bool = std::fs::remove_file(&*v11).is_ok() || !std::path::Path::new(&*v11).exists();
        v12
    } else {
        false
    };
    let mut v16: bool = if v13 {
        let mut v14: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
        let mut v15: bool = std::fs::remove_file(&*v14).is_ok() || !std::path::Path::new(&*v14).exists();
        v15
    } else {
        false
    };
    let mut v74: bool = if v16 {
        let mut v17: Rc<str> = Rc::<str>::from("original-a");
        let mut v18: bool = std::fs::write(&*v0, &*v17).is_ok();
        let mut v22: bool = if v18 {
            let mut v19: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
            let mut v20: Rc<str> = Rc::<str>::from("original-b");
            let mut v21: bool = std::fs::write(&*v19, &*v20).is_ok();
            v21
        } else {
            false
        };
        let mut v25: bool = if v22 {
            let mut v23: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-a.txt");
            let mut v24: bool = std::fs::write(&*v23, &*v17).is_ok();
            v24
        } else {
            false
        };
        let mut v29: bool = if v25 {
            let mut v26: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
            let mut v27: Rc<str> = Rc::<str>::from("original-b");
            let mut v28: bool = std::fs::write(&*v26, &*v27).is_ok();
            v28
        } else {
            false
        };
        let mut v33: bool = if v29 {
            let mut v30: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
            let mut v31: Rc<str> = Rc::<str>::from("changed-a");
            let mut v32: bool = std::fs::write(&*v30, &*v31).is_ok();
            v32
        } else {
            false
        };
        let mut v37: bool = if v33 {
            let mut v34: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
            let mut v35: Rc<str> = Rc::<str>::from("changed-b");
            let mut v36: bool = std::fs::write(&*v34, &*v35).is_ok();
            v36
        } else {
            false
        };
        let mut v40: bool = if v37 {
            let mut v38: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
            let mut v39: bool = std::fs::rename(&*v38, &*v0).is_ok();
            v39
        } else {
            false
        };
        let mut v43: bool = if v40 {
            let mut v41: Rc<str> = Rc::<str>::from("changed-a");
            let mut v42: bool = std::fs::read_to_string(&*v0).is_ok_and(|value| value == *v41);
            v42
        } else {
            false
        };
        let mut v47: bool = if v43 {
            let mut v44: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
            let mut v45: Rc<str> = Rc::<str>::from("original-b");
            let mut v46: bool = std::fs::read_to_string(&*v44).is_ok_and(|value| value == *v45);
            v46
        } else {
            false
        };
        if v47 {
            let mut v48: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-a.txt");
            let mut v49: bool = std::fs::rename(&*v48, &*v0).is_ok();
            let mut v52: bool = if v49 {
                let mut v50: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
                let mut v51: bool = std::fs::remove_file(&*v50).is_ok() || !std::path::Path::new(&*v50).exists();
                v51
            } else {
                false
            };
            let mut v55: bool = if v52 {
                let mut v53: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
                let mut v54: bool = std::fs::remove_file(&*v53).is_ok() || !std::path::Path::new(&*v53).exists();
                v54
            } else {
                false
            };
            let mut v61: bool = if v55 {
                let mut v56: bool = std::fs::read_to_string(&*v0).is_ok_and(|value| value == *v17);
                if v56 {
                    let mut v57: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
                    let mut v58: Rc<str> = Rc::<str>::from("original-b");
                    let mut v59: bool = std::fs::read_to_string(&*v57).is_ok_and(|value| value == *v58);
                    v59
                } else {
                    false
                }
            } else {
                false
            };
            if v61 {
                let mut v62: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
                let mut v63: bool = !std::path::Path::new(&*v62).is_file();
                let mut v66: bool = if v63 {
                    let mut v64: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
                    let mut v65: bool = !std::path::Path::new(&*v64).is_file();
                    v65
                } else {
                    false
                };
                let mut v68: bool = if v66 {
                    let mut v67: bool = !std::path::Path::new(&*v48).is_file();
                    v67
                } else {
                    false
                };
                if v68 {
                    let mut v69: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
                    let mut v70: bool = !std::path::Path::new(&*v69).is_file();
                    v70
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
    let mut v75: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-missing-promoted.txt");
    let mut v76: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-missing.txt");
    let mut v77: bool = std::fs::rename(&*v75, &*v76).is_ok();
    let mut v78: bool = v77 == false;
    let mut v79: bool = std::fs::remove_file(&*v0).is_ok() || !std::path::Path::new(&*v0).exists();
    let mut v82: bool = if v79 {
        let mut v80: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
        let mut v81: bool = std::fs::remove_file(&*v80).is_ok() || !std::path::Path::new(&*v80).exists();
        v81
    } else {
        false
    };
    let mut v85: bool = if v82 {
        let mut v83: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-a.txt");
        let mut v84: bool = std::fs::remove_file(&*v83).is_ok() || !std::path::Path::new(&*v83).exists();
        v84
    } else {
        false
    };
    let mut v88: bool = if v85 {
        let mut v86: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
        let mut v87: bool = std::fs::remove_file(&*v86).is_ok() || !std::path::Path::new(&*v86).exists();
        v87
    } else {
        false
    };
    let mut v91: bool = if v88 {
        let mut v89: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
        let mut v90: bool = std::fs::remove_file(&*v89).is_ok() || !std::path::Path::new(&*v89).exists();
        v90
    } else {
        false
    };
    let mut v94: bool = if v91 {
        let mut v92: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
        let mut v93: bool = std::fs::remove_file(&*v92).is_ok() || !std::path::Path::new(&*v92).exists();
        v93
    } else {
        false
    };
    let mut v95: bool = std::fs::remove_file(&*v0).is_ok() || !std::path::Path::new(&*v0).exists();
    let mut v98: bool = if v95 {
        let mut v96: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-a.txt");
        let mut v97: bool = std::fs::remove_file(&*v96).is_ok() || !std::path::Path::new(&*v96).exists();
        v97
    } else {
        false
    };
    let mut v101: bool = if v98 {
        let mut v99: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-a.txt");
        let mut v100: bool = std::fs::remove_file(&*v99).is_ok() || !std::path::Path::new(&*v99).exists();
        v100
    } else {
        false
    };
    let mut v104: bool = if v101 {
        let mut v102: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-target-b.txt");
        let mut v103: bool = std::fs::remove_file(&*v102).is_ok() || !std::path::Path::new(&*v102).exists();
        v103
    } else {
        false
    };
    let mut v107: bool = if v104 {
        let mut v105: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-stage-b.txt");
        let mut v106: bool = std::fs::remove_file(&*v105).is_ok() || !std::path::Path::new(&*v105).exists();
        v106
    } else {
        false
    };
    let mut v110: bool = if v107 {
        let mut v108: Rc<str> = Rc::<str>::from("/tmp/eoie-patch-batch-backup-b.txt");
        let mut v109: bool = std::fs::remove_file(&*v108).is_ok() || !std::path::Path::new(&*v108).exists();
        v109
    } else {
        false
    };
    let mut v111: bool = v74 && v78;
    let mut v112: bool = v111 && v94;
    let mut v113: bool = v112 && v110;
    if v113 {
        0i32
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
