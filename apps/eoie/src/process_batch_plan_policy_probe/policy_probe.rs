#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    let mut v1: i32 = 0i32;
    let mut v2: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v0, v1);
    let mut v3: i32 = 1i32;
    let mut v4: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v2, v3);
    let mut v5: i32 = 2i32;
    let mut v6: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v4, v5);
    let mut v7: i32 = 4i32;
    let mut v8: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v6, v7);
    let mut v9: i32 = 0i32;
    let mut v10: i32 = 0i32;
    let mut v11: i32 = process_batch_plan_domain::eoie_batch_matrix_row_policy(v9, v10);
    let mut v12: i32 = 1i32;
    let mut v13: i32 = 1i32;
    let mut v14: i32 = process_batch_plan_domain::eoie_batch_matrix_row_policy(v12, v13);
    let mut v15: i32 = 0i32;
    let mut v16: i32 = 0i32;
    let mut v17: i32 = process_batch_plan_domain::eoie_batch_matrix_dependency(v15, v16);
    let mut v18: i32 = 1i32;
    let mut v19: i32 = 1i32;
    let mut v20: i32 = process_batch_plan_domain::eoie_batch_matrix_dependency(v18, v19);
    let mut v21: i32 = 0i32;
    let mut v22: i32 = 0i32;
    let mut v23: i32 = process_batch_plan_domain::eoie_batch_matrix_observed_accept(v21, v22);
    let mut v24: i32 = 1i32;
    let mut v25: i32 = 1i32;
    let mut v26: i32 = process_batch_plan_domain::eoie_batch_matrix_observed_accept(v24, v25);
    let mut v27: i32 = 1i32;
    let mut v28: i32 = 0i32;
    let mut v29: i32 = process_batch_plan_domain::eoie_batch_matrix_resume_action(v27, v28);
    let mut v30: i32 = 2i32;
    let mut v31: i32 = 1i32;
    let mut v32: i32 = process_batch_plan_domain::eoie_batch_matrix_workspace_policy(v30, v31);
    let mut v33: i32 = 3i32;
    let mut v34: i32 = 1i32;
    let mut v35: i32 = process_batch_plan_domain::eoie_batch_matrix_workspace_policy(v33, v34);
    let mut v36: i32 = 0i32;
    let mut v37: i32 = 1i32;
    let mut v38: i32 = process_batch_plan_domain::eoie_batch_matrix_workspace_policy(v36, v37);
    let mut v39: i32 = 4i32;
    let mut v40: i32 = 1i32;
    let mut v41: i32 = process_batch_plan_domain::eoie_batch_matrix_workspace_policy(v39, v40);
    let mut v42: bool = v2 == 1i32;
    if v42 {
        let mut v43: bool = v4 == 2i32;
        if v43 {
            let mut v44: bool = v6 == 3i32;
            if v44 {
                let mut v45: bool = v8 == 5i32;
                if v45 {
                    let mut v46: bool = v11 == 1i32;
                    if v46 {
                        let mut v47: bool = v14 == 1i32;
                        if v47 {
                            let mut v48: bool = v17 == 1i32;
                            if v48 {
                                let mut v49: bool = v20 == 1i32;
                                if v49 {
                                    let mut v50: bool = v23 == 1i32;
                                    if v50 {
                                        let mut v51: bool = v26 == 1i32;
                                        if v51 {
                                            let mut v52: bool = v29 == 0i32;
                                            if v52 {
                                                let mut v53: bool = v32 == 1i32;
                                                if v53 {
                                                    let mut v54: bool = v35 == 0i32;
                                                    if v54 {
                                                        let mut v55: bool = v38 == 0i32;
                                                        if v55 {
                                                            let mut v56: bool = v41 < 0i32;
                                                            if v56 {
                                                                0i32
                                                            } else {
                                                                1i32
                                                            }
                                                        } else {
                                                            1i32
                                                        }
                                                    } else {
                                                        1i32
                                                    }
                                                } else {
                                                    1i32
                                                }
                                            } else {
                                                1i32
                                            }
                                        } else {
                                            1i32
                                        }
                                    } else {
                                        1i32
                                    }
                                } else {
                                    1i32
                                }
                            } else {
                                1i32
                            }
                        } else {
                            1i32
                        }
                    } else {
                        1i32
                    }
                } else {
                    1i32
                }
            } else {
                1i32
            }
        } else {
            1i32
        }
    } else {
        1i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
