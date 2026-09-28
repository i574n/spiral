#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 < 1i32;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = 1i32 < v0;
                        if v7 {
                            let mut v8: bool = v0 < 4i32;
                            if v8 {
                                0i32
                            } else {
                                let mut v9: bool = 4i32 < v0;
                                if v9 {
                                    0i32
                                } else {
                                    2i32
                                }
                            }
                        } else {
                            1i32
                        }
                    }
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 < 7i32;
                    if v6 {
                        v0
                    } else {
                        6i32
                    }
                }
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 < 3i32;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = 3i32 < v0;
                        if v7 {
                            let mut v8: bool = v0 < 7i32;
                            if v8 {
                                0i32
                            } else {
                                1i32
                            }
                        } else {
                            2i32
                        }
                    }
                }
            }
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    0i32
                }
            }
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    0i32
                }
            }
        }
    }
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method0(v0, v1);
    let mut v3: i32 = method2(v0, v1);
    let mut v4: i32 = method3(v0, v1);
    let mut v5: i32 = method4(v0, v1);
    let mut v6: bool = v2 < 0i32;
    if v6 {
        -1i32
    } else {
        let mut v7: bool = v3 < 0i32;
        if v7 {
            -1i32
        } else {
            let mut v8: bool = v4 < 0i32;
            if v8 {
                -1i32
            } else {
                let mut v9: bool = v5 < 0i32;
                if v9 {
                    -1i32
                } else {
                    let mut v10: i32 = v3 * 4i32;
                    let mut v11: i32 = v4 * 16i32;
                    let mut v12: i32 = v5 * 32i32;
                    let mut v13: i32 = v11 + v12;
                    let mut v14: i32 = v10 + v13;
                    let mut v15: i32 = v2 + v14;
                    v15
                }
            }
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 7i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 == 2i32;
                    if v6 {
                        1i32
                    } else {
                        let mut v7: bool = v0 == 3i32;
                        if v7 {
                            2i32
                        } else {
                            let mut v8: bool = v0 == 4i32;
                            if v8 {
                                3i32
                            } else {
                                let mut v9: bool = v0 == 5i32;
                                if v9 {
                                    4i32
                                } else {
                                    let mut v10: bool = v0 == 7i32;
                                    if v10 {
                                        5i32
                                    } else {
                                        0i32
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 4i32;
    let mut v4: bool = if v2 {
        let mut v3: bool = v1 == 3i32;
        v3
    } else {
        false
    };
    if v4 {
        1i32
    } else {
        0i32
    }
}
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = method2(v0, v1);
    let mut v3: bool = v2 < 0i32;
    if v3 {
        -1i32
    } else {
        let mut v4: bool = v2 == 1i32;
        if v4 {
            0i32
        } else {
            let mut v5: bool = v2 == 2i32;
            if v5 {
                8i32
            } else {
                5i32
            }
        }
    }
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = 0i32;
    let mut v3: i32 = method2(v0, v2);
    let mut v4: i32 = 0i32;
    let mut v5: i32 = method8(v0, v4);
    let mut v6: bool = v3 < 0i32;
    if v6 {
        -1i32
    } else {
        let mut v7: bool = v1 < 0i32;
        if v7 {
            -1i32
        } else {
            let mut v8: bool = v1 < v5;
            if v8 {
                let mut v9: bool = v1 == 0i32;
                if v9 {
                    0i32
                } else {
                    let mut v10: bool = v1 == 1i32;
                    if v10 {
                        17i32
                    } else {
                        let mut v11: bool = v1 == 2i32;
                        if v11 {
                            34i32
                        } else {
                            let mut v12: bool = v1 == 3i32;
                            if v12 {
                                51i32
                            } else {
                                let mut v13: bool = v1 == 4i32;
                                if v13 {
                                    68i32
                                } else {
                                    let mut v14: bool = v1 == 5i32;
                                    if v14 {
                                        85i32
                                    } else {
                                        let mut v15: bool = v1 == 6i32;
                                        if v15 {
                                            86i32
                                        } else {
                                            103i32
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } else {
                -1i32
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
        method8(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method9(v0, v1)
    })
}
pub fn eoie_toolchain_program_profile(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_toolchain_argument_profile(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_toolchain_environment_profile(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_toolchain_timeout_profile(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_toolchain_success_profile(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_toolchain_execution_plan(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_toolchain_resume_profile(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_toolchain_resume_retry(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_toolchain_environment_entry_count(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_toolchain_environment_entry(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
