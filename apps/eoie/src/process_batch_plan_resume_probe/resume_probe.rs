#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: i32 = 3i32;
    let mut v2: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v0, v1);
    let mut v3: i32 = 4i32;
    let mut v4: i32 = process_batch_plan_domain::eoie_batch_plan_advance(v2, v3);
    let mut v5: i32 = 2i32;
    let mut v6: i32 = 0i32;
    let mut v7: i32 = process_batch_plan_domain::eoie_batch_matrix_row_policy(v5, v6);
    let mut v8: i32 = 1i32;
    let mut v9: i32 = 0i32;
    let mut v10: i32 = process_batch_plan_domain::eoie_batch_matrix_dependency(v8, v9);
    let mut v11: i32 = 0i32;
    let mut v12: i32 = 1i32;
    let mut v13: i32 = process_batch_plan_domain::eoie_batch_matrix_observed_accept(v11, v12);
    let mut v14: i32 = 0i32;
    let mut v15: i32 = 1i32;
    let mut v16: i32 = process_batch_plan_domain::eoie_batch_matrix_resume_action(v14, v15);
    let mut v17: i32 = 0i32;
    let mut v18: i32 = 0i32;
    let mut v19: i32 = process_batch_plan_domain::eoie_batch_matrix_resume_action(v17, v18);
    let mut v20: bool = v2 == 4i32;
    if v20 {
        let mut v21: bool = v4 == 5i32;
        if v21 {
            let mut v22: bool = v7 < 0i32;
            if v22 {
                let mut v23: bool = v10 == 0i32;
                if v23 {
                    let mut v24: bool = v13 == 0i32;
                    if v24 {
                        let mut v25: bool = v16 == 1i32;
                        if v25 {
                            let mut v26: bool = v19 == 2i32;
                            if v26 {
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
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
