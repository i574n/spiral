#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method1(mut v0: i32, mut v1: i32) -> i32 {
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
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                -1i32
            } else {
                v1
            }
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method1(v0, v1);
    let mut v3: i32 = method2(v2, v1);
    let mut v4: bool = v3 < 0i32;
    if v4 {
        -1i32
    } else {
        v3
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    -1i32
                } else {
                    let mut v6: i32 = v0 + 1i32;
                    v6
                }
            }
        }
    }
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
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
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method5(v0, v1);
    let mut v3: bool = v2 < 1i32;
    if v3 {
        -1i32
    } else {
        method4(v0, v1)
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            -1i32
        } else {
            v0
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    method7(v0, v1)
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            -1i32
        } else {
            v0
        }
    }
}
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    method9(v0, v1)
}
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 1i32 < v1;
            if v4 {
                -1i32
            } else {
                v0
            }
        }
    }
}
fn method12(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v1;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1i32 < v0;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method13(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 1i32 < v1;
            if v4 {
                -1i32
            } else {
                v0
            }
        }
    }
}
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method11(v0, v1);
    let mut v3: i32 = 1i32;
    let mut v4: i32 = method12(v1, v3);
    let mut v5: i32 = method13(v2, v4);
    let mut v6: bool = v5 < 0i32;
    if v6 {
        -1i32
    } else {
        v5
    }
}
fn method15(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v0 < v1;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v1 < v0;
                if v5 {
                    -1i32
                } else {
                    v0
                }
            }
        }
    }
}
fn method14(mut v0: i32, mut v1: i32) -> i32 {
    method15(v0, v1)
}
fn method17(mut v0: i32, mut v1: i32) -> i32 {
    method4(v0, v1)
}
fn method16(mut v0: i32, mut v1: i32) -> i32 {
    method17(v0, v1)
}
fn method19(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
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
fn method20(mut v0: i32, mut v1: i32) -> i32 {
    method1(v0, v1)
}
fn method18(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method19(v0, v1);
    let mut v3: i32 = method20(v0, v1);
    let mut v4: bool = v2 < 1i32;
    if v4 {
        0i32
    } else {
        let mut v5: bool = v3 < 1i32;
        if v5 {
            0i32
        } else {
            1i32
        }
    }
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method3(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method8(v0, v1)
    })
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure5() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method14(v0, v1)
    })
}
fn closure6() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method16(v0, v1)
    })
}
fn closure7() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method18(v0, v1)
    })
}
pub fn eoie_patch_orchestration_witness_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_patch_orchestration_operation_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_patch_orchestration_guard_identity(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_patch_orchestration_guard_needle_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_patch_orchestration_guard_match_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_patch_orchestration_stage_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_patch_orchestration_promotion_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_patch_orchestration_complete_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
