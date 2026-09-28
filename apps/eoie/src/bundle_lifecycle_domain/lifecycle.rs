#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(clippy::needless_late_init)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 2i32 < v1;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v0 < 1i32;
                    if v6 {
                        1i32
                    } else {
                        let mut v7: bool = v1 < 2i32;
                        if v7 {
                            0i32
                        } else {
                            1i32
                        }
                    }
                }
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    method0(v0, v1)
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    method2(v0, v1)
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                0i32
            } else {
                let mut v5: i32 = v0 - v1;
                v5
            }
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    method6(v0, v1)
}
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    method6(v0, v1)
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    method6(v0, v1)
}
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    method6(v0, v1)
}
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    method7(v0, v1)
}
fn method12(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v0 < 1i32;
                    if v6 {
                        1i32
                    } else {
                        0i32
                    }
                }
            }
        }
    }
}
fn method13(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method14(mut v0: i32, mut v1: i32) -> i32 {
    method4(v0, v1)
}
fn method15(mut v0: i32, mut v1: i32) -> i32 {
    method7(v0, v1)
}
fn method17(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method16(mut v0: i32, mut v1: i32) -> i32 {
    method17(v0, v1)
}
fn method19(mut v0: i32, mut v1: i32) -> i32 {
    method17(v0, v1)
}
fn method18(mut v0: i32, mut v1: i32) -> i32 {
    method19(v0, v1)
}
fn method21(mut v0: i32, mut v1: i32) -> i32 {
    method17(v0, v1)
}
fn method20(mut v0: i32, mut v1: i32) -> i32 {
    method21(v0, v1)
}
fn method23(mut v0: i32, mut v1: i32) -> i32 {
    method19(v0, v1)
}
fn method22(mut v0: i32, mut v1: i32) -> i32 {
    method23(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method2(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method3(v0, v1)
    })
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method4(v0, v1)
    })
}
fn closure5() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method5(v0, v1)
    })
}
fn closure6() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure7() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method7(v0, v1)
    })
}
fn closure8() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method8(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method9(v0, v1)
    })
}
fn closure10() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method11(v0, v1)
    })
}
fn closure12() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method12(v0, v1)
    })
}
fn closure13() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method13(v0, v1)
    })
}
fn closure14() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method14(v0, v1)
    })
}
fn closure15() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method15(v0, v1)
    })
}
fn closure16() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method16(v0, v1)
    })
}
fn closure17() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method18(v0, v1)
    })
}
fn closure18() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method20(v0, v1)
    })
}
fn closure19() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method22(v0, v1)
    })
}
pub fn eoie_bundle_root_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_bundle_coverage_checkpoint_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_bundle_entry_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_bundle_size_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_bundle_extract_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_bundle_payload_count_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_bundle_rehydration_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_bundle_complete_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_bundle_rehydrate_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_bundle_rehydrate_extract_binding(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
pub fn eoie_bundle_rehydrate_validate_binding(v0: i32, v1: i32) -> i32 {
    closure10()(v0, v1)
}
pub fn eoie_bundle_rehydrate_receipt_binding(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
pub fn eoie_archive_extract_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure12()(v0, v1)
}
pub fn eoie_archive_extract_process_binding(v0: i32, v1: i32) -> i32 {
    closure13()(v0, v1)
}
pub fn eoie_archive_extract_complete_binding(v0: i32, v1: i32) -> i32 {
    closure14()(v0, v1)
}
pub fn eoie_archive_extract_receipt_binding(v0: i32, v1: i32) -> i32 {
    closure15()(v0, v1)
}
pub fn eoie_bundle_output_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure16()(v0, v1)
}
pub fn eoie_bundle_output_complete_binding(v0: i32, v1: i32) -> i32 {
    closure17()(v0, v1)
}
pub fn eoie_bundle_verify_preflight_binding(v0: i32, v1: i32) -> i32 {
    closure18()(v0, v1)
}
pub fn eoie_bundle_verify_complete_binding(v0: i32, v1: i32) -> i32 {
    closure19()(v0, v1)
}
