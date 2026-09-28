#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 4i32;
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
                let mut v5: bool = v0 == 4i32;
                if v5 {
                    let mut v6: bool = v1 == 0i32;
                    if v6 {
                        6i32
                    } else {
                        let mut v7: bool = v1 == 1i32;
                        if v7 {
                            1i32
                        } else {
                            let mut v8: bool = v1 == 2i32;
                            if v8 {
                                7i32
                            } else {
                                let mut v9: bool = v1 == 3i32;
                                if v9 {
                                    3i32
                                } else {
                                    let mut v10: bool = v1 == 4i32;
                                    if v10 {
                                        9i32
                                    } else {
                                        let mut v11: bool = v1 == 5i32;
                                        if v11 {
                                            10i32
                                        } else {
                                            -1i32
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else {
                    let mut v18: bool = v0 == 5i32;
                    if v18 {
                        let mut v19: bool = v1 == 0i32;
                        if v19 {
                            11i32
                        } else {
                            let mut v20: bool = v1 == 1i32;
                            if v20 {
                                13i32
                            } else {
                                let mut v21: bool = v1 == 2i32;
                                if v21 {
                                    1i32
                                } else {
                                    let mut v22: bool = v1 == 3i32;
                                    if v22 {
                                        7i32
                                    } else {
                                        -1i32
                                    }
                                }
                            }
                        }
                    } else {
                        let mut v27: bool = v1 == 0i32;
                        if v27 {
                            12i32
                        } else {
                            -1i32
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
pub fn eoie_toolchain_argument_token_high(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
