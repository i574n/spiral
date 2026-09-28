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
                    let mut v6: bool = v0 == 0i32;
                    if v6 {
                        2i32
                    } else {
                        let mut v7: bool = v0 == 1i32;
                        if v7 {
                            3i32
                        } else {
                            let mut v8: bool = v0 == 2i32;
                            if v8 {
                                4i32
                            } else {
                                let mut v9: bool = v0 == 3i32;
                                if v9 {
                                    3i32
                                } else {
                                    let mut v10: bool = v0 == 4i32;
                                    if v10 {
                                        6i32
                                    } else {
                                        let mut v11: bool = v0 == 5i32;
                                        if v11 {
                                            4i32
                                        } else {
                                            1i32
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
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 3i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v0 == 0i32;
                if v5 {
                    let mut v6: bool = v1 == 0i32;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = v1 == 1i32;
                        if v7 {
                            1i32
                        } else {
                            -1i32
                        }
                    }
                } else {
                    let mut v10: bool = v0 == 1i32;
                    if v10 {
                        let mut v11: bool = v1 == 0i32;
                        if v11 {
                            2i32
                        } else {
                            let mut v12: bool = v1 == 1i32;
                            if v12 {
                                3i32
                            } else {
                                let mut v13: bool = v1 == 2i32;
                                if v13 {
                                    4i32
                                } else {
                                    -1i32
                                }
                            }
                        }
                    } else {
                        let mut v17: bool = v0 == 2i32;
                        if v17 {
                            let mut v18: bool = v1 == 0i32;
                            if v18 {
                                5i32
                            } else {
                                let mut v19: bool = v1 == 1i32;
                                if v19 {
                                    6i32
                                } else {
                                    let mut v20: bool = v1 == 2i32;
                                    if v20 {
                                        1i32
                                    } else {
                                        let mut v21: bool = v1 == 3i32;
                                        if v21 {
                                            7i32
                                        } else {
                                            -1i32
                                        }
                                    }
                                }
                            }
                        } else {
                            let mut v26: bool = v1 == 0i32;
                            if v26 {
                                8i32
                            } else {
                                let mut v27: bool = v1 == 1i32;
                                if v27 {
                                    1i32
                                } else {
                                    let mut v28: bool = v1 == 2i32;
                                    if v28 {
                                        7i32
                                    } else {
                                        -1i32
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
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        -1i32
    } else {
        let mut v3: bool = 13i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 2i32 < v1;
                if v5 {
                    -1i32
                } else {
                    let mut v6: bool = v0 == 0i32;
                    if v6 {
                        let mut v7: bool = v1 == 0i32;
                        if v7 {
                            17970310i32
                        } else {
                            let mut v8: bool = v1 == 1i32;
                            if v8 {
                                82176147i32
                            } else {
                                1044750506i32
                            }
                        }
                    } else {
                        let mut v11: bool = v0 == 1i32;
                        if v11 {
                            let mut v12: bool = v1 == 0i32;
                            if v12 {
                                374520666i32
                            } else {
                                let mut v13: bool = v1 == 1i32;
                                if v13 {
                                    1073713576i32
                                } else {
                                    1073741823i32
                                }
                            }
                        } else {
                            let mut v16: bool = v0 == 2i32;
                            if v16 {
                                let mut v17: bool = v1 == 0i32;
                                if v17 {
                                    1052083034i32
                                } else {
                                    1073741823i32
                                }
                            } else {
                                let mut v19: bool = v0 == 3i32;
                                if v19 {
                                    let mut v20: bool = v1 == 0i32;
                                    if v20 {
                                        1073741658i32
                                    } else {
                                        1073741823i32
                                    }
                                } else {
                                    let mut v22: bool = v0 == 4i32;
                                    if v22 {
                                        let mut v23: bool = v1 == 0i32;
                                        if v23 {
                                            71535450i32
                                        } else {
                                            let mut v24: bool = v1 == 1i32;
                                            if v24 {
                                                1073741802i32
                                            } else {
                                                1073741823i32
                                            }
                                        }
                                    } else {
                                        let mut v27: bool = v0 == 5i32;
                                        if v27 {
                                            let mut v28: bool = v1 == 0i32;
                                            if v28 {
                                                1050743010i32
                                            } else {
                                                1073741823i32
                                            }
                                        } else {
                                            let mut v30: bool = v0 == 6i32;
                                            if v30 {
                                                let mut v31: bool = v1 == 0i32;
                                                if v31 {
                                                    884310874i32
                                                } else {
                                                    let mut v32: bool = v1 == 1i32;
                                                    if v32 {
                                                        641942547i32
                                                    } else {
                                                        1073741810i32
                                                    }
                                                }
                                            } else {
                                                let mut v35: bool = v0 == 7i32;
                                                if v35 {
                                                    let mut v36: bool = v1 == 0i32;
                                                    if v36 {
                                                        338112346i32
                                                    } else {
                                                        let mut v37: bool = v1 == 1i32;
                                                        if v37 {
                                                            1073740900i32
                                                        } else {
                                                            1073741823i32
                                                        }
                                                    }
                                                } else {
                                                    let mut v40: bool = v0 == 8i32;
                                                    if v40 {
                                                        let mut v41: bool = v1 == 0i32;
                                                        if v41 {
                                                            1073334419i32
                                                        } else {
                                                            1073741823i32
                                                        }
                                                    } else {
                                                        let mut v43: bool = v0 == 9i32;
                                                        if v43 {
                                                            let mut v44: bool = v1 == 0i32;
                                                            if v44 {
                                                                1073741690i32
                                                            } else {
                                                                1073741823i32
                                                            }
                                                        } else {
                                                            let mut v46: bool = v0 == 10i32;
                                                            if v46 {
                                                                let mut v47: bool = v1 == 0i32;
                                                                if v47 {
                                                                    445039638i32
                                                                } else {
                                                                    let mut v48: bool = v1 == 1i32;
                                                                    if v48 {
                                                                        1073741382i32
                                                                    } else {
                                                                        1073741823i32
                                                                    }
                                                                }
                                                            } else {
                                                                let mut v51: bool = v0 == 11i32;
                                                                if v51 {
                                                                    let mut v52: bool = v1 == 0i32;
                                                                    if v52 {
                                                                        1043702401i32
                                                                    } else {
                                                                        1073741823i32
                                                                    }
                                                                } else {
                                                                    let mut v54: bool = v0 == 12i32;
                                                                    if v54 {
                                                                        let mut v55: bool = v1 == 0i32;
                                                                        if v55 {
                                                                            621959002i32
                                                                        } else {
                                                                            let mut v56: bool = v1 == 1i32;
                                                                            if v56 {
                                                                                1073722824i32
                                                                            } else {
                                                                                1073741823i32
                                                                            }
                                                                        }
                                                                    } else {
                                                                        let mut v59: bool = v1 == 0i32;
                                                                        if v59 {
                                                                            145901402i32
                                                                        } else {
                                                                            let mut v60: bool = v1 == 1i32;
                                                                            if v60 {
                                                                                1020480i32
                                                                            } else {
                                                                                1073741823i32
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
pub fn eoie_toolchain_argument_count(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_toolchain_argument_token_low(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_toolchain_argument_token_chunk(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
