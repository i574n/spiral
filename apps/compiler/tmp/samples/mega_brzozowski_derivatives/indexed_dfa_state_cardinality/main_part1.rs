use super::*;
pub(crate) fn random_bit_input_1(mut v0: u64, mut v1: i32, mut v2: Rc<UH1>) -> (Rc<UH1>, u64) {
    loop {
        let v3: bool = 0i32 < v1;
        if v3 {
            let v4: u64 = v0.wrapping_mul(1103515245u64);
            let v5: u64 = v4.wrapping_add(12345u64);
            let v6: u64 = v5 & 2147483647u64;
            let v7: i32 = v1.wrapping_sub(1i32);
            let v8: u64 = v6.wrapping_shr((16i32) as u32);
            let v9: u64 = v8 & 1u64;
            let v10: bool = v9 == 0u64;
            let v13: US0 = if v10 {
                let v11: US0 = US0::US0_BitZero;
                v11.clone()
            } else {
                let v12: US0 = US0::US0_BitOne;
                v12.clone()
            };
            let v14: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v13.clone(), v2.clone()));
            (v0, v1, v2) = (v6, v7, v14.clone());
            continue;
        } else {
            return (v2.clone(), v0);
        }
    }
}
pub(crate) fn run_2(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v4, v5) => {
                let v4: US0 = v4.clone();
                let v5: Rc<UH1> = v5.clone();
                let v6: bool = v0 == 0i32;
                let v19: i32 = if v6 {
                    let v10: US1 = match &v4 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolGreater
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    };
                    let v11: bool = match &v10 {
                        US1::US1_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v11 {
                        1i32
                    } else {
                        0i32
                    }
                } else {
                    let v16: US1 = match &v4 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolGreater
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    };
                    let v17: bool = match &v16 {
                        US1::US1_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v17 {
                        1i32
                    } else {
                        0i32
                    }
                };
                (v0, v1) = (v19, v5.clone());
                continue;
            }
            UH1::UH1_InputEmpty => {
                let v2: bool = v0 == 0i32;
                let v3: bool = v2 == false;
                return v3;
            }
        }
    }
}
pub(crate) fn regex_compare_8(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> US1 {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v53, v54) => {
                let v53: Rc<UH0> = v53.clone();
                let v54: Rc<UH0> = v54.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v55, v56) => {
                        let v55: Rc<UH0> = v55.clone();
                        let v56: Rc<UH0> = v56.clone();
                        let v57: US1 = regex_compare_8(v53.clone(), v55.clone());
                        match &v57 {
                            US1::US1_SymbolSame => {
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US1::US1_SymbolGreater;
                    }
                }
            }
            UH0::UH0_RegexCat(v28, v29) => {
                let v28: Rc<UH0> = v28.clone();
                let v29: Rc<UH0> = v29.clone();
                match &*v1 {
                    UH0::UH0_RegexCat(v34, v35) => {
                        let v34: Rc<UH0> = v34.clone();
                        let v35: Rc<UH0> = v35.clone();
                        let v36: US1 = regex_compare_8(v28.clone(), v34.clone());
                        match &v36 {
                            US1::US1_SymbolSame => {
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH0::UH0_RegexChar(v32) => {
                        let v32: US0 = v32.clone();
                        return US1::US1_SymbolGreater;
                    }
                    UH0::UH0_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH0::UH0_RegexEpsilon => {
                        return US1::US1_SymbolGreater;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH0::UH0_RegexChar(v10) => {
                let v10: US0 = v10.clone();
                match &*v1 {
                    UH0::UH0_RegexChar(v13) => {
                        let v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_BitOne => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US1::US1_SymbolSame;
                                    }
                                    US0::US0_BitZero => {
                                        return US1::US1_SymbolGreater;
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US1::US1_SymbolLess;
                                    }
                                    US0::US0_BitZero => {
                                        return US1::US1_SymbolSame;
                                    }
                                }
                            }
                        }
                    }
                    UH0::UH0_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH0::UH0_RegexEpsilon => {
                        return US1::US1_SymbolGreater;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH0::UH0_RegexEmpty => {
                match &*v1 {
                    UH0::UH0_RegexEmpty => {
                        return US1::US1_SymbolSame;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH0::UH0_RegexEpsilon => {
                match &*v1 {
                    UH0::UH0_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH0::UH0_RegexEpsilon => {
                        return US1::US1_SymbolSame;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH0::UH0_RegexStar(v44) => {
                let v44: Rc<UH0> = v44.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v45, v46) => {
                        let v45: Rc<UH0> = v45.clone();
                        let v46: Rc<UH0> = v46.clone();
                        return US1::US1_SymbolLess;
                    }
                    UH0::UH0_RegexStar(v48) => {
                        let v48: Rc<UH0> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US1::US1_SymbolGreater;
                    }
                }
            }
        }
    }
}
pub(crate) fn alt_insert_sorted_7(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    match &*v1 {
        UH0::UH0_RegexAlt(v2, v3) => {
            let v2: Rc<UH0> = v2.clone();
            let v3: Rc<UH0> = v3.clone();
            let v4: US1 = regex_compare_8(v0.clone(), v2.clone());
            match &v4 {
                US1::US1_SymbolGreater => {
                    let v6: Rc<UH0> = alt_insert_sorted_7(v0.clone(), v3);
                    Rc::new(UH0::UH0_RegexAlt(v2, v6))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH0::UH0_RegexAlt(v0.clone(), v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH0::UH0_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let v11: US1 = regex_compare_8(v0.clone(), v1.clone());
            match &v11 {
                US1::US1_SymbolGreater => {
                    Rc::new(UH0::UH0_RegexAlt(v1.clone(), v0.clone()))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH0::UH0_RegexAlt(v0, v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1
                }
            }
        }
    }
}
pub(crate) fn make_alt_6(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v2, v3) => {
                let v2: Rc<UH0> = v2.clone();
                let v3: Rc<UH0> = v3.clone();
                let v4: Rc<UH0> = alt_insert_sorted_7(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH0::UH0_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_7(v0.clone(), v1.clone());
            }
        }
    }
}
pub(crate) fn regex_equal_10(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> bool {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v18, v19) => {
                let v18: Rc<UH0> = v18.clone();
                let v19: Rc<UH0> = v19.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v20, v21) => {
                        let v20: Rc<UH0> = v20.clone();
                        let v21: Rc<UH0> = v21.clone();
                        let v22: bool = regex_equal_10(v18.clone(), v20.clone());
                        if v22 {
                            (v0, v1) = (v19.clone(), v21.clone());
                            continue;
                        } else {
                            return false;
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_RegexCat(v26, v27) => {
                let v26: Rc<UH0> = v26.clone();
                let v27: Rc<UH0> = v27.clone();
                match &*v1 {
                    UH0::UH0_RegexCat(v28, v29) => {
                        let v28: Rc<UH0> = v28.clone();
                        let v29: Rc<UH0> = v29.clone();
                        let v30: bool = regex_equal_10(v26.clone(), v28.clone());
                        if v30 {
                            (v0, v1) = (v27.clone(), v29.clone());
                            continue;
                        } else {
                            return false;
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_RegexChar(v4) => {
                let v4: US0 = v4.clone();
                match &*v1 {
                    UH0::UH0_RegexChar(v5) => {
                        let v5: US0 = v5.clone();
                        let v15: US1 = match &v4 {
                            US0::US0_BitOne => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US1::US1_SymbolSame
                                    }
                                    US0::US0_BitZero => {
                                        US1::US1_SymbolGreater
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US1::US1_SymbolLess
                                    }
                                    US0::US0_BitZero => {
                                        US1::US1_SymbolSame
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US1::US1_SymbolSame => {
                                return true;
                            }
                            _ => {
                                return false;
                            }
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_RegexEmpty => {
                match &*v1 {
                    UH0::UH0_RegexEmpty => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_RegexEpsilon => {
                match &*v1 {
                    UH0::UH0_RegexEpsilon => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_RegexStar(v34) => {
                let v34: Rc<UH0> = v34.clone();
                match &*v1 {
                    UH0::UH0_RegexStar(v35) => {
                        let v35: Rc<UH0> = v35.clone();
                        (v0, v1) = (v34.clone(), v35.clone());
                        continue;
                    }
                    _ => {
                        return false;
                    }
                }
            }
        }
    }
}
pub(crate) fn make_cat_9(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH0::UH0_RegexEmpty => {
                    { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH0::UH0_RegexEpsilon => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH0::UH0_RegexEpsilon => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH0::UH0_RegexCat(v12, v13) => {
                                            let v12: Rc<UH0> = v12.clone();
                                            let v13: Rc<UH0> = v13.clone();
                                            let v14: Rc<UH0> = make_cat_9(v13, v1.clone());
                                            Rc::new(UH0::UH0_RegexCat(v12, v14))
                                        }
                                        UH0::UH0_RegexStar(v4) => {
                                            let v4: Rc<UH0> = v4.clone();
                                            match &*v1 {
                                                UH0::UH0_RegexStar(v5) => {
                                                    let v5: Rc<UH0> = v5.clone();
                                                    let v6: bool = regex_equal_10(v4.clone(), v5);
                                                    if v6 {
                                                        Rc::new(UH0::UH0_RegexStar(v4))
                                                    } else {
                                                        Rc::new(UH0::UH0_RegexCat(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH0::UH0_RegexCat(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH0::UH0_RegexCat(v0, v1))
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
pub(crate) fn make_star_11(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexStar(v3) => {
            let v3: Rc<UH0> = v3.clone();
            Rc::new(UH0::UH0_RegexStar(v3))
        }
        _ => {
            Rc::new(UH0::UH0_RegexStar(v0))
        }
    }
}
pub(crate) fn normalize_5(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexAlt(v5, v6) => {
            let v5: Rc<UH0> = v5.clone();
            let v6: Rc<UH0> = v6.clone();
            let v7: Rc<UH0> = normalize_5(v5);
            let v8: Rc<UH0> = normalize_5(v6);
            make_alt_6(v7, v8)
        }
        UH0::UH0_RegexCat(v10, v11) => {
            let v10: Rc<UH0> = v10.clone();
            let v11: Rc<UH0> = v11.clone();
            let v12: Rc<UH0> = normalize_5(v10);
            let v13: Rc<UH0> = normalize_5(v11);
            make_cat_9(v12, v13)
        }
        UH0::UH0_RegexChar(v3) => {
            let v3: US0 = v3.clone();
            Rc::new(UH0::UH0_RegexChar(v3))
        }
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexStar(v15) => {
            let v15: Rc<UH0> = v15.clone();
            let v16: Rc<UH0> = normalize_5(v15);
            make_star_11(v16)
        }
    }
}
pub(crate) fn nullable_13(mut v0: Rc<UH0>) -> US2 {
    match &*v0 {
        UH0::UH0_RegexAlt(v5, v6) => {
            let v5: Rc<UH0> = v5.clone();
            let v6: Rc<UH0> = v6.clone();
            let v7: US2 = nullable_13(v5);
            let v8: US2 = nullable_13(v6);
            match &v7 {
                US2::US2_Nullable => {
                    US2::US2_Nullable
                }
                _ => {
                    match &v8 {
                        US2::US2_Nullable => {
                            US2::US2_Nullable
                        }
                        _ => {
                            match &v7 {
                                US2::US2_NonNullable => {
                                    match &v8 {
                                        US2::US2_NonNullable => {
                                            US2::US2_NonNullable
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                _ => unreachable!(),
                            }
                        }
                    }
                }
            }
        }
        UH0::UH0_RegexCat(v16, v17) => {
            let v16: Rc<UH0> = v16.clone();
            let v17: Rc<UH0> = v17.clone();
            let v18: US2 = nullable_13(v16);
            let v19: US2 = nullable_13(v17);
            match &v18 {
                US2::US2_Nullable => {
                    match &v19 {
                        US2::US2_Nullable => {
                            US2::US2_Nullable
                        }
                        _ => {
                            US2::US2_NonNullable
                        }
                    }
                }
                _ => {
                    US2::US2_NonNullable
                }
            }
        }
        UH0::UH0_RegexChar(v3) => {
            let v3: US0 = v3.clone();
            US2::US2_NonNullable
        }
        UH0::UH0_RegexEmpty => {
            US2::US2_NonNullable
        }
        UH0::UH0_RegexEpsilon => {
            US2::US2_Nullable
        }
        UH0::UH0_RegexStar(v25) => {
            let v25: Rc<UH0> = v25.clone();
            US2::US2_Nullable
        }
    }
}
pub(crate) fn derivative_12(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexAlt(v19, v20) => {
            let v19: Rc<UH0> = v19.clone();
            let v20: Rc<UH0> = v20.clone();
            let v21: Rc<UH0> = derivative_12(v19, v1.clone());
            let v22: Rc<UH0> = derivative_12(v20, v1.clone());
            make_alt_6(v21, v22)
        }
        UH0::UH0_RegexCat(v24, v25) => {
            let v24: Rc<UH0> = v24.clone();
            let v25: Rc<UH0> = v25.clone();
            let v26: US2 = nullable_13(v24.clone());
            match &v26 {
                US2::US2_NonNullable => {
                    let v31: Rc<UH0> = derivative_12(v24.clone(), v1.clone());
                    make_cat_9(v31, v25.clone())
                }
                US2::US2_Nullable => {
                    let v27: Rc<UH0> = derivative_12(v24, v1.clone());
                    let v28: Rc<UH0> = make_cat_9(v27, v25.clone());
                    let v29: Rc<UH0> = derivative_12(v25, v1.clone());
                    make_alt_6(v28, v29)
                }
            }
        }
        UH0::UH0_RegexChar(v4) => {
            let v4: US0 = v4.clone();
            let v14: US1 = match &v4 {
                US0::US0_BitOne => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolSame
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolGreater
                        }
                    }
                }
                US0::US0_BitZero => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolLess
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    }
                }
            };
            let v15: bool = match &v14 {
                US1::US1_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
            }
        }
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexStar(v35) => {
            let v35: Rc<UH0> = v35.clone();
            let v36: Rc<UH0> = derivative_12(v35.clone(), v1);
            let v37: Rc<UH0> = make_star_11(v35);
            make_cat_9(v36, v37)
        }
    }
}
pub(crate) fn canonical_derivative_4(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    let v2: Rc<UH0> = normalize_5(v0);
    let v3: Rc<UH0> = derivative_12(v2, v1);
    normalize_5(v3)
}
pub(crate) fn accepts_3(mut v0: Rc<UH0>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v6, v7) => {
                let v6: US0 = v6.clone();
                let v7: Rc<UH1> = v7.clone();
                let v8: Rc<UH0> = canonical_derivative_4(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH1::UH1_InputEmpty => {
                let v2: Rc<UH0> = normalize_5(v0.clone());
                let v3: US2 = nullable_13(v2.clone());
                match &v3 {
                    US2::US2_NonNullable => {
                        return false;
                    }
                    US2::US2_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
pub(crate) fn loop_0(mut v0: i32, mut v1: Rc<UH0>, mut v2: i32, mut v3: u64, mut v4: i32) -> i32 {
    loop {
        let v5: bool = 0i32 < v2;
        if v5 {
            let v6: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let (mut v7, mut v8): (Rc<UH1>, u64) = random_bit_input_1(v3, v0, v6.clone());
            let v9: i32 = 0i32;
            let v10: bool = run_2(v9, v7.clone());
            let v11: bool = accepts_3(v1.clone(), v7.clone());
            let v13: bool = if v10 {
                v11
            } else {
                let v12: bool = false == v11;
                v12
            };
            if v13 {
                let v14: i32 = v2.wrapping_sub(1i32);
                let v16: i32 = if v10 {
                    let v15: i32 = v4.wrapping_add(1i32);
                    v15
                } else {
                    v4
                };
                (v0, v1, v2, v3, v4) = (v0, v1.clone(), v14, v8, v16);
                continue;
            } else {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-core-disagrees-on-random-input"); } LIT.with(|lit| lit.clone()) }));
            }
        } else {
            return v4;
        }
    }
}
pub(crate) fn zeros_input_15(mut v0: i32, mut v1: Rc<UH1>) -> Rc<UH1> {
    loop {
        let v2: bool = 0i32 < v0;
        if v2 {
            let v3: i32 = v0.wrapping_sub(1i32);
            let v4: US0 = US0::US0_BitZero;
            let v5: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v4.clone(), v1.clone()));
            (v0, v1) = (v3, v5.clone());
            continue;
        } else {
            return v1.clone();
        }
    }
}
pub(crate) fn run_16(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v5, v6) => {
                let v5: US0 = v5.clone();
                let v6: Rc<UH1> = v6.clone();
                let v7: bool = v0 == 0i32;
                let v26: i32 = if v7 {
                    1i32
                } else {
                    let v13: bool = v0 == 1i32;
                    if v13 {
                        1i32
                    } else {
                        let v22: US1 = match &v5 {
                            US0::US0_BitOne => {
                                US1::US1_SymbolGreater
                            }
                            US0::US0_BitZero => {
                                US1::US1_SymbolSame
                            }
                        };
                        let v23: bool = match &v22 {
                            US1::US1_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        if v23 {
                            2i32
                        } else {
                            0i32
                        }
                    }
                };
                (v0, v1) = (v26, v6.clone());
                continue;
            }
            UH1::UH1_InputEmpty => {
                let v2: bool = v0 == 0i32;
                if v2 {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}
pub(crate) fn loop_14(mut v0: i32, mut v1: Rc<UH0>, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let v4: bool = v0 < v2;
        if v4 {
            return v3;
        } else {
            let v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let v6: Rc<UH1> = zeros_input_15(v2, v5.clone());
            let v7: i32 = 2i32;
            let v8: bool = run_16(v7, v6.clone());
            let v9: bool = accepts_3(v1.clone(), v6.clone());
            let v11: bool = if v8 {
                v9
            } else {
                let v10: bool = false == v9;
                v10
            };
            let v15: i32 = if v11 {
                if v8 {
                    let v12: i32 = v3.wrapping_add(1i32);
                    v12
                } else {
                    v3
                }
            } else {
                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-core-disagrees-on-zero-run"); } LIT.with(|lit| lit.clone()) }))
            };
            let v16: US0 = US0::US0_BitOne;
            let v17: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let v18: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v16.clone(), v17.clone()));
            let v19: Rc<UH1> = zeros_input_15(v2, v18.clone());
            let v20: i32 = 2i32;
            let v21: bool = run_16(v20, v19.clone());
            let v22: bool = accepts_3(v1.clone(), v19.clone());
            let v24: bool = if v21 {
                v22
            } else {
                let v23: bool = false == v22;
                v23
            };
            let v28: i32 = if v24 {
                if v21 {
                    let v25: i32 = v15.wrapping_add(1i32);
                    v25
                } else {
                    v15
                }
            } else {
                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-core-disagrees-on-zero-run"); } LIT.with(|lit| lit.clone()) }))
            };
            let v29: i32 = v2.wrapping_add(1i32);
            (v0, v1, v2, v3) = (v0, v1.clone(), v29, v28);
            continue;
        }
    }
}
pub(crate) fn run_17(mut v0: i32, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v1 {
            UH3::UH3_InputCons(v5, v6) => {
                let v5: US3 = v5.clone();
                let v6: Rc<UH3> = v6.clone();
                let v7: bool = v0 == 0i32;
                let v47: i32 = if v7 {
                    let v10: US1 = match &v5 {
                        US3::US3_TriA => {
                            US1::US1_SymbolSame
                        }
                        _ => {
                            US1::US1_SymbolGreater
                        }
                    };
                    let v11: bool = match &v10 {
                        US1::US1_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v11 {
                        0i32
                    } else {
                        let v17: US1 = match &v5 {
                            US3::US3_TriA => {
                                US1::US1_SymbolLess
                            }
                            US3::US3_TriB => {
                                US1::US1_SymbolSame
                            }
                            US3::US3_TriC => {
                                US1::US1_SymbolGreater
                            }
                        };
                        let v18: bool = match &v17 {
                            US1::US1_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        if v18 {
                            0i32
                        } else {
                            1i32
                        }
                    }
                } else {
                    let v21: bool = v0 == 1i32;
                    if v21 {
                        let v24: US1 = match &v5 {
                            US3::US3_TriA => {
                                US1::US1_SymbolSame
                            }
                            _ => {
                                US1::US1_SymbolGreater
                            }
                        };
                        let v25: bool = match &v24 {
                            US1::US1_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        if v25 {
                            2i32
                        } else {
                            2i32
                        }
                    } else {
                        let v36: US1 = match &v5 {
                            US3::US3_TriA => {
                                US1::US1_SymbolSame
                            }
                            _ => {
                                US1::US1_SymbolGreater
                            }
                        };
                        let v37: bool = match &v36 {
                            US1::US1_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        if v37 {
                            2i32
                        } else {
                            2i32
                        }
                    }
                };
                (v0, v1) = (v47, v6.clone());
                continue;
            }
            UH3::UH3_InputEmpty => {
                let v2: bool = v0 == 0i32;
                if v2 {
                    return false;
                } else {
                    let v3: bool = v0 == 1i32;
                    return v3;
                }
            }
        }
    }
}
pub(crate) fn regex_compare_23(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US1 {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v59, v60) => {
                let v59: Rc<UH2> = v59.clone();
                let v60: Rc<UH2> = v60.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v61, v62) => {
                        let v61: Rc<UH2> = v61.clone();
                        let v62: Rc<UH2> = v62.clone();
                        let v63: US1 = regex_compare_23(v59.clone(), v61.clone());
                        match &v63 {
                            US1::US1_SymbolSame => {
                                (v0, v1) = (v60.clone(), v62.clone());
                                continue;
                            }
                            _ => {
                                return v63.clone();
                            }
                        }
                    }
                    _ => {
                        return US1::US1_SymbolGreater;
                    }
                }
            }
            UH2::UH2_RegexCat(v34, v35) => {
                let v34: Rc<UH2> = v34.clone();
                let v35: Rc<UH2> = v35.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v40, v41) => {
                        let v40: Rc<UH2> = v40.clone();
                        let v41: Rc<UH2> = v41.clone();
                        let v42: US1 = regex_compare_23(v34.clone(), v40.clone());
                        match &v42 {
                            US1::US1_SymbolSame => {
                                (v0, v1) = (v35.clone(), v41.clone());
                                continue;
                            }
                            _ => {
                                return v42.clone();
                            }
                        }
                    }
                    UH2::UH2_RegexChar(v38) => {
                        let v38: US3 = v38.clone();
                        return US1::US1_SymbolGreater;
                    }
                    UH2::UH2_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US1::US1_SymbolGreater;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexChar(v10) => {
                let v10: US3 = v10.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v13) => {
                        let v13: US3 = v13.clone();
                        match &v10 {
                            US3::US3_TriA => {
                                match &v13 {
                                    US3::US3_TriA => {
                                        return US1::US1_SymbolSame;
                                    }
                                    _ => {
                                        return US1::US1_SymbolLess;
                                    }
                                }
                            }
                            _ => {
                                match &v13 {
                                    US3::US3_TriA => {
                                        return US1::US1_SymbolGreater;
                                    }
                                    _ => {
                                        match &v10 {
                                            US3::US3_TriB => {
                                                match &v13 {
                                                    US3::US3_TriB => {
                                                        return US1::US1_SymbolSame;
                                                    }
                                                    US3::US3_TriC => {
                                                        return US1::US1_SymbolLess;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US3::US3_TriC => {
                                                match &v13 {
                                                    US3::US3_TriB => {
                                                        return US1::US1_SymbolGreater;
                                                    }
                                                    US3::US3_TriC => {
                                                        return US1::US1_SymbolSame;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            _ => unreachable!(),
                                        }
                                    }
                                }
                            }
                        }
                    }
                    UH2::UH2_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US1::US1_SymbolGreater;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexEmpty => {
                match &*v1 {
                    UH2::UH2_RegexEmpty => {
                        return US1::US1_SymbolSame;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexEpsilon => {
                match &*v1 {
                    UH2::UH2_RegexEmpty => {
                        return US1::US1_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US1::US1_SymbolSame;
                    }
                    _ => {
                        return US1::US1_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexStar(v50) => {
                let v50: Rc<UH2> = v50.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v51, v52) => {
                        let v51: Rc<UH2> = v51.clone();
                        let v52: Rc<UH2> = v52.clone();
                        return US1::US1_SymbolLess;
                    }
                    UH2::UH2_RegexStar(v54) => {
                        let v54: Rc<UH2> = v54.clone();
                        (v0, v1) = (v50.clone(), v54.clone());
                        continue;
                    }
                    _ => {
                        return US1::US1_SymbolGreater;
                    }
                }
            }
        }
    }
}
pub(crate) fn alt_insert_sorted_22(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v1 {
        UH2::UH2_RegexAlt(v2, v3) => {
            let v2: Rc<UH2> = v2.clone();
            let v3: Rc<UH2> = v3.clone();
            let v4: US1 = regex_compare_23(v0.clone(), v2.clone());
            match &v4 {
                US1::US1_SymbolGreater => {
                    let v6: Rc<UH2> = alt_insert_sorted_22(v0.clone(), v3);
                    Rc::new(UH2::UH2_RegexAlt(v2, v6))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH2::UH2_RegexAlt(v0.clone(), v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH2::UH2_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let v11: US1 = regex_compare_23(v0.clone(), v1.clone());
            match &v11 {
                US1::US1_SymbolGreater => {
                    Rc::new(UH2::UH2_RegexAlt(v1.clone(), v0.clone()))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH2::UH2_RegexAlt(v0, v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1
                }
            }
        }
    }
}
pub(crate) fn make_alt_21(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v2, v3) => {
                let v2: Rc<UH2> = v2.clone();
                let v3: Rc<UH2> = v3.clone();
                let v4: Rc<UH2> = alt_insert_sorted_22(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH2::UH2_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_22(v0.clone(), v1.clone());
            }
        }
    }
}
pub(crate) fn regex_equal_25(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v24, v25) => {
                let v24: Rc<UH2> = v24.clone();
                let v25: Rc<UH2> = v25.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v26, v27) => {
                        let v26: Rc<UH2> = v26.clone();
                        let v27: Rc<UH2> = v27.clone();
                        let v28: bool = regex_equal_25(v24.clone(), v26.clone());
                        if v28 {
                            (v0, v1) = (v25.clone(), v27.clone());
                            continue;
                        } else {
                            return false;
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_RegexCat(v32, v33) => {
                let v32: Rc<UH2> = v32.clone();
                let v33: Rc<UH2> = v33.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v34, v35) => {
                        let v34: Rc<UH2> = v34.clone();
                        let v35: Rc<UH2> = v35.clone();
                        let v36: bool = regex_equal_25(v32.clone(), v34.clone());
                        if v36 {
                            (v0, v1) = (v33.clone(), v35.clone());
                            continue;
                        } else {
                            return false;
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_RegexChar(v4) => {
                let v4: US3 = v4.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v5) => {
                        let v5: US3 = v5.clone();
                        let v21: US1 = match &v4 {
                            US3::US3_TriA => {
                                match &v5 {
                                    US3::US3_TriA => {
                                        US1::US1_SymbolSame
                                    }
                                    _ => {
                                        US1::US1_SymbolLess
                                    }
                                }
                            }
                            _ => {
                                match &v5 {
                                    US3::US3_TriA => {
                                        US1::US1_SymbolGreater
                                    }
                                    _ => {
                                        match &v4 {
                                            US3::US3_TriB => {
                                                match &v5 {
                                                    US3::US3_TriB => {
                                                        US1::US1_SymbolSame
                                                    }
                                                    US3::US3_TriC => {
                                                        US1::US1_SymbolLess
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US3::US3_TriC => {
                                                match &v5 {
                                                    US3::US3_TriB => {
                                                        US1::US1_SymbolGreater
                                                    }
                                                    US3::US3_TriC => {
                                                        US1::US1_SymbolSame
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            _ => unreachable!(),
                                        }
                                    }
                                }
                            }
                        };
                        match &v21 {
                            US1::US1_SymbolSame => {
                                return true;
                            }
                            _ => {
                                return false;
                            }
                        }
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_RegexEmpty => {
                match &*v1 {
                    UH2::UH2_RegexEmpty => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_RegexEpsilon => {
                match &*v1 {
                    UH2::UH2_RegexEpsilon => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_RegexStar(v40) => {
                let v40: Rc<UH2> = v40.clone();
                match &*v1 {
                    UH2::UH2_RegexStar(v41) => {
                        let v41: Rc<UH2> = v41.clone();
                        (v0, v1) = (v40.clone(), v41.clone());
                        continue;
                    }
                    _ => {
                        return false;
                    }
                }
            }
        }
    }
}
pub(crate) fn make_cat_24(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH2::UH2_RegexEmpty => {
                    { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH2::UH2_RegexEpsilon => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH2::UH2_RegexEpsilon => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH2::UH2_RegexCat(v12, v13) => {
                                            let v12: Rc<UH2> = v12.clone();
                                            let v13: Rc<UH2> = v13.clone();
                                            let v14: Rc<UH2> = make_cat_24(v13, v1.clone());
                                            Rc::new(UH2::UH2_RegexCat(v12, v14))
                                        }
                                        UH2::UH2_RegexStar(v4) => {
                                            let v4: Rc<UH2> = v4.clone();
                                            match &*v1 {
                                                UH2::UH2_RegexStar(v5) => {
                                                    let v5: Rc<UH2> = v5.clone();
                                                    let v6: bool = regex_equal_25(v4.clone(), v5);
                                                    if v6 {
                                                        Rc::new(UH2::UH2_RegexStar(v4))
                                                    } else {
                                                        Rc::new(UH2::UH2_RegexCat(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH2::UH2_RegexCat(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH2::UH2_RegexCat(v0, v1))
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
pub(crate) fn make_star_26(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexStar(v3) => {
            let v3: Rc<UH2> = v3.clone();
            Rc::new(UH2::UH2_RegexStar(v3))
        }
        _ => {
            Rc::new(UH2::UH2_RegexStar(v0))
        }
    }
}
pub(crate) fn normalize_20(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let v5: Rc<UH2> = v5.clone();
            let v6: Rc<UH2> = v6.clone();
            let v7: Rc<UH2> = normalize_20(v5);
            let v8: Rc<UH2> = normalize_20(v6);
            make_alt_21(v7, v8)
        }
        UH2::UH2_RegexCat(v10, v11) => {
            let v10: Rc<UH2> = v10.clone();
            let v11: Rc<UH2> = v11.clone();
            let v12: Rc<UH2> = normalize_20(v10);
            let v13: Rc<UH2> = normalize_20(v11);
            make_cat_24(v12, v13)
        }
        UH2::UH2_RegexChar(v3) => {
            let v3: US3 = v3.clone();
            Rc::new(UH2::UH2_RegexChar(v3))
        }
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexStar(v15) => {
            let v15: Rc<UH2> = v15.clone();
            let v16: Rc<UH2> = normalize_20(v15);
            make_star_26(v16)
        }
    }
}
pub(crate) fn nullable_28(mut v0: Rc<UH2>) -> US2 {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let v5: Rc<UH2> = v5.clone();
            let v6: Rc<UH2> = v6.clone();
            let v7: US2 = nullable_28(v5);
            let v8: US2 = nullable_28(v6);
            match &v7 {
                US2::US2_Nullable => {
                    US2::US2_Nullable
                }
                _ => {
                    match &v8 {
                        US2::US2_Nullable => {
                            US2::US2_Nullable
                        }
                        _ => {
                            match &v7 {
                                US2::US2_NonNullable => {
                                    match &v8 {
                                        US2::US2_NonNullable => {
                                            US2::US2_NonNullable
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                _ => unreachable!(),
                            }
                        }
                    }
                }
            }
        }
        UH2::UH2_RegexCat(v16, v17) => {
            let v16: Rc<UH2> = v16.clone();
            let v17: Rc<UH2> = v17.clone();
            let v18: US2 = nullable_28(v16);
            let v19: US2 = nullable_28(v17);
            match &v18 {
                US2::US2_Nullable => {
                    match &v19 {
                        US2::US2_Nullable => {
                            US2::US2_Nullable
                        }
                        _ => {
                            US2::US2_NonNullable
                        }
                    }
                }
                _ => {
                    US2::US2_NonNullable
                }
            }
        }
        UH2::UH2_RegexChar(v3) => {
            let v3: US3 = v3.clone();
            US2::US2_NonNullable
        }
        UH2::UH2_RegexEmpty => {
            US2::US2_NonNullable
        }
        UH2::UH2_RegexEpsilon => {
            US2::US2_Nullable
        }
        UH2::UH2_RegexStar(v25) => {
            let v25: Rc<UH2> = v25.clone();
            US2::US2_Nullable
        }
    }
}
pub(crate) fn derivative_27(mut v0: Rc<UH2>, mut v1: US3) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v25, v26) => {
            let v25: Rc<UH2> = v25.clone();
            let v26: Rc<UH2> = v26.clone();
            let v27: Rc<UH2> = derivative_27(v25, v1.clone());
            let v28: Rc<UH2> = derivative_27(v26, v1.clone());
            make_alt_21(v27, v28)
        }
        UH2::UH2_RegexCat(v30, v31) => {
            let v30: Rc<UH2> = v30.clone();
            let v31: Rc<UH2> = v31.clone();
            let v32: US2 = nullable_28(v30.clone());
            match &v32 {
                US2::US2_NonNullable => {
                    let v37: Rc<UH2> = derivative_27(v30.clone(), v1.clone());
                    make_cat_24(v37, v31.clone())
                }
                US2::US2_Nullable => {
                    let v33: Rc<UH2> = derivative_27(v30, v1.clone());
                    let v34: Rc<UH2> = make_cat_24(v33, v31.clone());
                    let v35: Rc<UH2> = derivative_27(v31, v1.clone());
                    make_alt_21(v34, v35)
                }
            }
        }
        UH2::UH2_RegexChar(v4) => {
            let v4: US3 = v4.clone();
            let v20: US1 = match &v4 {
                US3::US3_TriA => {
                    match &v1 {
                        US3::US3_TriA => {
                            US1::US1_SymbolSame
                        }
                        _ => {
                            US1::US1_SymbolLess
                        }
                    }
                }
                _ => {
                    match &v1 {
                        US3::US3_TriA => {
                            US1::US1_SymbolGreater
                        }
                        _ => {
                            match &v4 {
                                US3::US3_TriB => {
                                    match &v1 {
                                        US3::US3_TriB => {
                                            US1::US1_SymbolSame
                                        }
                                        US3::US3_TriC => {
                                            US1::US1_SymbolLess
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                US3::US3_TriC => {
                                    match &v1 {
                                        US3::US3_TriB => {
                                            US1::US1_SymbolGreater
                                        }
                                        US3::US3_TriC => {
                                            US1::US1_SymbolSame
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                _ => unreachable!(),
                            }
                        }
                    }
                }
            };
            let v21: bool = match &v20 {
                US1::US1_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v21 {
                { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
            }
        }
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexStar(v41) => {
            let v41: Rc<UH2> = v41.clone();
            let v42: Rc<UH2> = derivative_27(v41.clone(), v1);
            let v43: Rc<UH2> = make_star_26(v41);
            make_cat_24(v42, v43)
        }
    }
}
pub(crate) fn canonical_derivative_19(mut v0: Rc<UH2>, mut v1: US3) -> Rc<UH2> {
    let v2: Rc<UH2> = normalize_20(v0);
    let v3: Rc<UH2> = derivative_27(v2, v1);
    normalize_20(v3)
}
pub(crate) fn accepts_18(mut v0: Rc<UH2>, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v1 {
            UH3::UH3_InputCons(v6, v7) => {
                let v6: US3 = v6.clone();
                let v7: Rc<UH3> = v7.clone();
                let v8: Rc<UH2> = canonical_derivative_19(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH3::UH3_InputEmpty => {
                let v2: Rc<UH2> = normalize_20(v0.clone());
                let v3: US2 = nullable_28(v2.clone());
                match &v3 {
                    US2::US2_NonNullable => {
                        return false;
                    }
                    US2::US2_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
pub(crate) fn spiral_main() -> i32 {
    let v0: i32 = 200i32;
    let v1: i32 = 32i32;
    let v2: i32 = 16i32;
    let v3: US0 = US0::US0_BitZero;
    let v4: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v3));
    let v5: US0 = US0::US0_BitOne;
    let v6: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v5));
    let v7: Rc<UH0> = Rc::new(UH0::UH0_RegexAlt(v4, v6));
    let v8: Rc<UH0> = Rc::new(UH0::UH0_RegexStar(v7));
    let v9: US0 = US0::US0_BitZero;
    let v10: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v9));
    let v11: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v8, v10));
    let v12: u64 = 1u64;
    let v13: i32 = 0i32;
    let v14: i32 = loop_0(v1, v11, v0, v12, v13);
    let v15: bool = v14 == 93i32;
    if v15 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-ends-with-zero-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let v16: US0 = US0::US0_BitZero;
    let v17: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v16));
    let v18: US0 = US0::US0_BitZero;
    let v19: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v18));
    let v20: US0 = US0::US0_BitZero;
    let v21: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v20));
    let v22: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v19, v21));
    let v23: Rc<UH0> = Rc::new(UH0::UH0_RegexAlt(v17, v22));
    let v24: Rc<UH0> = Rc::new(UH0::UH0_RegexStar(v23));
    let v25: US0 = US0::US0_BitOne;
    let v26: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v25));
    let v27: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v24, v26));
    let v28: i32 = 1i32;
    let v29: i32 = 0i32;
    let v30: i32 = loop_14(v2, v27, v28, v29);
    let v31: bool = v30 == 16i32;
    if v31 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-zero-runs-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let v32: US3 = US3::US3_TriA;
    let v33: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v32));
    let v34: US3 = US3::US3_TriB;
    let v35: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v34));
    let v36: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v33, v35));
    let v37: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v36));
    let v38: US3 = US3::US3_TriC;
    let v39: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v38));
    let v40: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v37, v39));
    let v41: US3 = US3::US3_TriA;
    let v42: US3 = US3::US3_TriB;
    let v43: US3 = US3::US3_TriA;
    let v44: US3 = US3::US3_TriC;
    let v45: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_InputEmpty); } CASE.with(|case| case.clone()) };
    let v46: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v44, v45));
    let v47: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v43, v46));
    let v48: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v42, v47));
    let v49: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v41, v48));
    let v50: US3 = US3::US3_TriA;
    let v51: US3 = US3::US3_TriB;
    let v52: US3 = US3::US3_TriA;
    let v53: US3 = US3::US3_TriB;
    let v54: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_InputEmpty); } CASE.with(|case| case.clone()) };
    let v55: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v53, v54));
    let v56: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v52, v55));
    let v57: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v51, v56));
    let v58: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v50, v57));
    let v59: i32 = 0i32;
    let v60: bool = run_17(v59, v49.clone());
    let v62: bool = if v60 {
        accepts_18(v40.clone(), v49)
    } else {
        false
    };
    let v68: bool = if v62 {
        let v63: i32 = 0i32;
        let v64: bool = run_17(v63, v58.clone());
        if v64 {
            false
        } else {
            let v65: bool = accepts_18(v40, v58);
            let v66: bool = v65 == false;
            v66
        }
    } else {
        false
    };
    if v68 {
        0i32
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-ternary-disagrees"); } LIT.with(|lit| lit.clone()) }))
    }
}
