#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 1i32;
    if v2 {
        let mut v3: bool = v1 == 1i32;
        if v3 {
            2i32
        } else {
            1i32
        }
    } else {
        0i32
    }
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
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
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
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
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method2(v0, v1)
    })
}
fn method3(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        0u64
    } else {
        1u64
    }
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method3(v0.clone())
    })
}
fn method4(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("Task (");
    let mut v2: bool = v0.contains(&*v1);
    if v2 {
        1u64
    } else {
        0u64
    }
}
fn closure4() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method4(v0.clone())
    })
}
fn method6(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("snapshot");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        1u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from("module");
        let mut v4: bool = v0 == v3 ;
        if v4 {
            2u64
        } else {
            0u64
        }
    }
}
fn method5(mut v0: Rc<str>) -> u64 {
    method6(v0.clone())
}
fn closure5() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method5(v0.clone())
    })
}
fn method8(mut v0: Rc<str>) -> Rc<str> {
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
fn method7(mut v0: Rc<str>) -> Rc<str> {
    method8(v0.clone())
}
fn closure6() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method7(v0.clone())
    })
}
fn method11(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: i32, mut v3: i32, mut v4: i32) -> bool {
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
fn method10(mut v0: Rc<str>) -> u64 {
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
            method11(v0.clone(), v5.clone(), v6, v7, v8)
        };
        if v10 {
            2u64
        } else {
            0u64
        }
    }
}
fn method9(mut v0: Rc<str>) -> u64 {
    method10(v0.clone())
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method9(v0.clone())
    })
}
fn method13(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("runtime");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from("build:"), v0.clone()));
        v4.clone()
    }
}
fn method12(mut v0: Rc<str>) -> Rc<str> {
    method13(v0.clone())
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method12(v0.clone())
    })
}
fn method14(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("LeaseActive");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        1u64
    } else {
        0u64
    }
}
fn closure9() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method14(v0.clone())
    })
}
fn method15(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("1");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("PromptLease (");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("");
        v4.clone()
    }
}
fn closure10() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method15(v0.clone())
    })
}
fn method16(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 7i32;
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
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method16(v0, v1)
    })
}
fn method17(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 == 1i32;
    if v2 {
        2i32
    } else {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn closure12() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method17(v0, v1)
    })
}
fn method18(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("0");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("Planned");
        v3.clone()
    } else {
        let mut v4: Rc<str> = Rc::<str>::from("1");
        let mut v5: bool = v0 == v4 ;
        if v5 {
            let mut v6: Rc<str> = Rc::<str>::from("Active");
            v6.clone()
        } else {
            let mut v7: Rc<str> = Rc::<str>::from("2");
            let mut v8: bool = v0 == v7 ;
            if v8 {
                let mut v9: Rc<str> = Rc::<str>::from("Blocked");
                v9.clone()
            } else {
                let mut v10: Rc<str> = Rc::<str>::from("3");
                let mut v11: bool = v0 == v10 ;
                if v11 {
                    let mut v12: Rc<str> = Rc::<str>::from("Paused");
                    v12.clone()
                } else {
                    let mut v13: Rc<str> = Rc::<str>::from("4");
                    let mut v14: bool = v0 == v13 ;
                    if v14 {
                        let mut v15: Rc<str> = Rc::<str>::from("Done");
                        v15.clone()
                    } else {
                        let mut v16: Rc<str> = Rc::<str>::from("");
                        v16.clone()
                    }
                }
            }
        }
    }
}
fn closure13() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method18(v0.clone())
    })
}
fn method19(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from("\\");
    let mut v2: Rc<str> = Rc::<str>::from("\\\\");
    let mut v3: Rc<str> = std::rc::Rc::<str>::from(v0.replace(&*v1, &v2));
    let mut v4: Rc<str> = Rc::<str>::from("\"");
    let mut v5: Rc<str> = Rc::<str>::from("\\\"");
    let mut v6: Rc<str> = std::rc::Rc::<str>::from(v3.replace(&*v4, &v5));
    let mut v7: Rc<str> = Rc::<str>::from("\n");
    let mut v8: Rc<str> = Rc::<str>::from("\\n");
    let mut v9: Rc<str> = std::rc::Rc::<str>::from(v6.replace(&*v7, &v8));
    let mut v10: Rc<str> = Rc::<str>::from("\r");
    let mut v11: Rc<str> = Rc::<str>::from("\\r");
    let mut v12: Rc<str> = std::rc::Rc::<str>::from(v9.replace(&*v10, &v11));
    v12.clone()
}
fn closure14() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method19(v0.clone())
    })
}
fn method20(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = std::rc::Rc::<str>::from(v0.trim());
    let mut v2: Rc<str> = Rc::<str>::from("modules:");
    let mut v3: bool = v1 == v2 ;
    if v3 {
        1u64
    } else {
        let mut v4: Rc<str> = Rc::<str>::from(" ");
        let mut v5: bool = v0.starts_with(&*v4);
        let mut v8: bool = if v5 {
            true
        } else {
            let mut v6: Rc<str> = Rc::<str>::from("\t");
            let mut v7: bool = v0.starts_with(&*v6);
            v7
        };
        if v8 {
            let mut v9: Rc<str> = Rc::<str>::from("");
            let mut v10: bool = v1 == v9 ;
            let mut v13: bool = if v10 {
                true
            } else {
                let mut v11: Rc<str> = Rc::<str>::from("//");
                let mut v12: bool = v1.starts_with(&*v11);
                v12
            };
            if v13 {
                0u64
            } else {
                2u64
            }
        } else {
            3u64
        }
    }
}
fn closure15() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method20(v0.clone())
    })
}
fn method21(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = std::rc::Rc::<str>::from(v0.trim());
    let mut v2: Rc<str> = Rc::<str>::from("*");
    let mut v3: Rc<str> = std::rc::Rc::<str>::from(v1.trim_end_matches(&*v2));
    let mut v4: Rc<str> = Rc::<str>::from("-");
    let mut v5: Rc<str> = std::rc::Rc::<str>::from(v3.trim_end_matches(&*v4));
    let mut v6: Rc<str> = std::rc::Rc::<str>::from(v5.trim());
    let mut v7: Rc<str> = Rc::<str>::from("");
    let mut v8: bool = v6 == v7 ;
    let mut v11: bool = if v8 {
        true
    } else {
        let mut v9: Rc<str> = Rc::<str>::from("/");
        let mut v10: bool = v6.contains(&*v9);
        v10
    };
    let mut v14: bool = if v11 {
        true
    } else {
        let mut v12: Rc<str> = Rc::<str>::from("\\");
        let mut v13: bool = v6.contains(&*v12);
        v13
    };
    if v14 {
        v7.clone()
    } else {
        let mut v15: Rc<str> = Rc::<str>::from(".spi");
        let mut v16: Rc<str> = std::rc::Rc::<str>::from([&*v6, &*v15, &*v7, &*v7, &*v7].concat());
        v16.clone()
    }
}
fn closure16() -> Rc<dyn Fn(Rc<str>) -> Rc<str>> {
    Rc::new(move |mut v0: Rc<str>| -> Rc<str> {
        method21(v0.clone())
    })
}
pub fn eoie_agile_state_mutation_target_decision_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_agile_lease_budget_decision_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_agile_lease_readback_decision_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_agile_prompt_title_code(v0: &str) -> u64 {
    closure3()(Rc::<str>::from(v0))
}
pub fn eoie_agile_task_line_candidate_code(v0: &str) -> u64 {
    closure4()(Rc::<str>::from(v0))
}
pub fn eoie_agile_receipt_row_kind_code(v0: &str) -> u64 {
    closure5()(Rc::<str>::from(v0))
}
pub fn eoie_agile_receipt_row_kind_text(v0: &str) -> Rc<str> {
    closure6()(Rc::<str>::from(v0))
}
pub fn eoie_agile_receipt_attestation_kind_code(v0: &str) -> u64 {
    closure7()(Rc::<str>::from(v0))
}
pub fn eoie_agile_receipt_attestation_text(v0: &str) -> Rc<str> {
    closure8()(Rc::<str>::from(v0))
}
pub fn eoie_agile_prompt_lease_status_code(v0: &str) -> u64 {
    closure9()(Rc::<str>::from(v0))
}
pub fn eoie_agile_prompt_lease_marker_text(v0: &str) -> Rc<str> {
    closure10()(Rc::<str>::from(v0))
}
pub fn eoie_agile_prompt_lease_shape_binding(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
pub fn eoie_agile_lease_clock_phase_binding(v0: i32, v1: i32) -> i32 {
    closure12()(v0, v1)
}
pub fn eoie_agile_status_text(v0: &str) -> Rc<str> {
    closure13()(Rc::<str>::from(v0))
}
pub fn eoie_agile_spi_escape_text(v0: &str) -> Rc<str> {
    closure14()(Rc::<str>::from(v0))
}
pub fn eoie_agile_state_package_line_code(v0: &str) -> u64 {
    closure15()(Rc::<str>::from(v0))
}
pub fn eoie_agile_state_package_module_name(v0: &str) -> Rc<str> {
    closure16()(Rc::<str>::from(v0))
}
