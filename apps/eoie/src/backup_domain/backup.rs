#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        v1
    } else {
        v0
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        let mut v3: i32 = v1 + 1i32;
        v3
    } else {
        v1
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v0 < 0i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
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
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < v0;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
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
fn method6(mut v0: i32, mut v1: i32) -> i32 {
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
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 < v0;
    if v2 {
        let mut v3: i32 = v0 - v1;
        let mut v4: i32 = v3 - 1i32;
        v4
    } else {
        -1i32
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    method8(v0, v1)
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
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
fn method10(mut v0: i32, mut v1: i32) -> i32 {
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
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: i32 = 2147483647i32 - v0;
            let mut v5: bool = v4 < v1;
            if v5 {
                -1i32
            } else {
                let mut v6: i32 = v0 + v1;
                v6
            }
        }
    }
}
fn method12(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < v0;
            if v4 {
                1i32
            } else {
                0i32
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
                let mut v5: bool = v0 < 2147483647i32;
                if v5 {
                    let mut v6: i32 = v0 + 1i32;
                    v6
                } else {
                    -1i32
                }
            }
        }
    }
}
fn method14(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = v0 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 1i32 < v0;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v0 < 1i32;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v1 < 1i32;
                    if v6 {
                        1i32
                    } else {
                        2i32
                    }
                }
            }
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
        method9(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure10() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method11(v0, v1)
    })
}
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method12(v0, v1)
    })
}
fn closure12() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method13(v0, v1)
    })
}
fn closure13() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method14(v0, v1)
    })
}
pub fn eoie_patch_backup_slot(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_patch_backup_next_count(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_patch_backup_should_capture(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_patch_backup_binding_slot(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_patch_capture_authorized(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_patch_capture_binding_slot(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_patch_promotion_slot_authorized(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_patch_restoration_select(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_patch_restoration_bind(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_patch_restoration_complete(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
pub fn eoie_patch_restoration_attempt_count(v0: i32, v1: i32) -> i32 {
    closure10()(v0, v1)
}
pub fn eoie_patch_restoration_attempt_authorized(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
pub fn eoie_patch_restoration_counter_next(v0: i32, v1: i32) -> i32 {
    closure12()(v0, v1)
}
pub fn eoie_patch_restoration_accumulator_outcome(v0: i32, v1: i32) -> i32 {
    closure13()(v0, v1)
}
