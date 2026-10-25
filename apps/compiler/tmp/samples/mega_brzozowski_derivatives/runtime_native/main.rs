#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_BitZero,
    US0_BitOne,
}
#[derive(Clone)]
enum UH0 {
    UH0_InputEmpty,
    UH0_InputCons(US0, Rc<UH0>),
}
#[derive(Clone)]
enum US1 {
    US1_TriA,
    US1_TriB,
    US1_TriC,
}
#[derive(Clone)]
enum UH1 {
    UH1_InputEmpty,
    UH1_InputCons(US1, Rc<UH1>),
}
#[derive(Clone)]
enum UH2 {
    UH2_RegexEmpty,
    UH2_RegexEpsilon,
    UH2_RegexChar(US0),
    UH2_RegexAlt(Rc<UH2>, Rc<UH2>),
    UH2_RegexCat(Rc<UH2>, Rc<UH2>),
    UH2_RegexStar(Rc<UH2>),
}
#[derive(Clone)]
enum US2 {
    US2_SymbolLess,
    US2_SymbolSame,
    US2_SymbolGreater,
}
#[derive(Clone)]
enum US3 {
    US3_Nullable,
    US3_NonNullable,
}
#[derive(Clone)]
enum UH3 {
    UH3_RegexEmpty,
    UH3_RegexEpsilon,
    UH3_RegexChar(US1),
    UH3_RegexAlt(Rc<UH3>, Rc<UH3>),
    UH3_RegexCat(Rc<UH3>, Rc<UH3>),
    UH3_RegexStar(Rc<UH3>),
}
#[derive(Clone)]
enum US4 {
    US4_BitMatcherRaw(Rc<UH2>, Rc<UH0>),
}
#[derive(Clone)]
enum US5 {
    US5_BitMatcherDecided(Rc<UH2>, Rc<UH0>, bool),
}
fn regex_compare_5(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US2 {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v53, v54) => {
                let v53: Rc<UH2> = v53.clone();
                let v54: Rc<UH2> = v54.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v55, v56) => {
                        let v55: Rc<UH2> = v55.clone();
                        let v56: Rc<UH2> = v56.clone();
                        let v57: US2 = regex_compare_5(v53.clone(), v55.clone());
                        match &v57 {
                            US2::US2_SymbolSame => {
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US2::US2_SymbolGreater;
                    }
                }
            }
            UH2::UH2_RegexCat(v28, v29) => {
                let v28: Rc<UH2> = v28.clone();
                let v29: Rc<UH2> = v29.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v34, v35) => {
                        let v34: Rc<UH2> = v34.clone();
                        let v35: Rc<UH2> = v35.clone();
                        let v36: US2 = regex_compare_5(v28.clone(), v34.clone());
                        match &v36 {
                            US2::US2_SymbolSame => {
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH2::UH2_RegexChar(v32) => {
                        let v32: US0 = v32.clone();
                        return US2::US2_SymbolGreater;
                    }
                    UH2::UH2_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US2::US2_SymbolGreater;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexChar(v10) => {
                let v10: US0 = v10.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v13) => {
                        let v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_BitOne => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US2::US2_SymbolSame;
                                    }
                                    US0::US0_BitZero => {
                                        return US2::US2_SymbolGreater;
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US2::US2_SymbolLess;
                                    }
                                    US0::US0_BitZero => {
                                        return US2::US2_SymbolSame;
                                    }
                                }
                            }
                        }
                    }
                    UH2::UH2_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US2::US2_SymbolGreater;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexEmpty => {
                match &*v1 {
                    UH2::UH2_RegexEmpty => {
                        return US2::US2_SymbolSame;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexEpsilon => {
                match &*v1 {
                    UH2::UH2_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH2::UH2_RegexEpsilon => {
                        return US2::US2_SymbolSame;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH2::UH2_RegexStar(v44) => {
                let v44: Rc<UH2> = v44.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v45, v46) => {
                        let v45: Rc<UH2> = v45.clone();
                        let v46: Rc<UH2> = v46.clone();
                        return US2::US2_SymbolLess;
                    }
                    UH2::UH2_RegexStar(v48) => {
                        let v48: Rc<UH2> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US2::US2_SymbolGreater;
                    }
                }
            }
        }
    }
}
fn alt_insert_sorted_4(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v1 {
        UH2::UH2_RegexAlt(v2, v3) => {
            let v2: Rc<UH2> = v2.clone();
            let v3: Rc<UH2> = v3.clone();
            let v4: US2 = regex_compare_5(v0.clone(), v2.clone());
            match &v4 {
                US2::US2_SymbolGreater => {
                    let v6: Rc<UH2> = alt_insert_sorted_4(v0.clone(), v3);
                    Rc::new(UH2::UH2_RegexAlt(v2, v6))
                }
                US2::US2_SymbolLess => {
                    Rc::new(UH2::UH2_RegexAlt(v0.clone(), v1.clone()))
                }
                US2::US2_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH2::UH2_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let v11: US2 = regex_compare_5(v0.clone(), v1.clone());
            match &v11 {
                US2::US2_SymbolGreater => {
                    Rc::new(UH2::UH2_RegexAlt(v1.clone(), v0.clone()))
                }
                US2::US2_SymbolLess => {
                    Rc::new(UH2::UH2_RegexAlt(v0, v1.clone()))
                }
                US2::US2_SymbolSame => {
                    v1
                }
            }
        }
    }
}
fn make_alt_3(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v2, v3) => {
                let v2: Rc<UH2> = v2.clone();
                let v3: Rc<UH2> = v3.clone();
                let v4: Rc<UH2> = alt_insert_sorted_4(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH2::UH2_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_4(v0.clone(), v1.clone());
            }
        }
    }
}
fn regex_equal_7(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v18, v19) => {
                let v18: Rc<UH2> = v18.clone();
                let v19: Rc<UH2> = v19.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v20, v21) => {
                        let v20: Rc<UH2> = v20.clone();
                        let v21: Rc<UH2> = v21.clone();
                        let v22: bool = regex_equal_7(v18.clone(), v20.clone());
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
            UH2::UH2_RegexCat(v26, v27) => {
                let v26: Rc<UH2> = v26.clone();
                let v27: Rc<UH2> = v27.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v28, v29) => {
                        let v28: Rc<UH2> = v28.clone();
                        let v29: Rc<UH2> = v29.clone();
                        let v30: bool = regex_equal_7(v26.clone(), v28.clone());
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
            UH2::UH2_RegexChar(v4) => {
                let v4: US0 = v4.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v5) => {
                        let v5: US0 = v5.clone();
                        let v15: US2 = match &v4 {
                            US0::US0_BitOne => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US2::US2_SymbolSame
                                    }
                                    US0::US0_BitZero => {
                                        US2::US2_SymbolGreater
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US2::US2_SymbolLess
                                    }
                                    US0::US0_BitZero => {
                                        US2::US2_SymbolSame
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US2::US2_SymbolSame => {
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
            UH2::UH2_RegexStar(v34) => {
                let v34: Rc<UH2> = v34.clone();
                match &*v1 {
                    UH2::UH2_RegexStar(v35) => {
                        let v35: Rc<UH2> = v35.clone();
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
fn make_cat_6(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
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
                                            let v14: Rc<UH2> = make_cat_6(v13, v1.clone());
                                            Rc::new(UH2::UH2_RegexCat(v12, v14))
                                        }
                                        UH2::UH2_RegexStar(v4) => {
                                            let v4: Rc<UH2> = v4.clone();
                                            match &*v1 {
                                                UH2::UH2_RegexStar(v5) => {
                                                    let v5: Rc<UH2> = v5.clone();
                                                    let v6: bool = regex_equal_7(v4.clone(), v5);
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
fn make_star_8(mut v0: Rc<UH2>) -> Rc<UH2> {
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
fn normalize_2(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let v5: Rc<UH2> = v5.clone();
            let v6: Rc<UH2> = v6.clone();
            let v7: Rc<UH2> = normalize_2(v5);
            let v8: Rc<UH2> = normalize_2(v6);
            make_alt_3(v7, v8)
        }
        UH2::UH2_RegexCat(v10, v11) => {
            let v10: Rc<UH2> = v10.clone();
            let v11: Rc<UH2> = v11.clone();
            let v12: Rc<UH2> = normalize_2(v10);
            let v13: Rc<UH2> = normalize_2(v11);
            make_cat_6(v12, v13)
        }
        UH2::UH2_RegexChar(v3) => {
            let v3: US0 = v3.clone();
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
            let v16: Rc<UH2> = normalize_2(v15);
            make_star_8(v16)
        }
    }
}
fn nullable_10(mut v0: Rc<UH2>) -> US3 {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let v5: Rc<UH2> = v5.clone();
            let v6: Rc<UH2> = v6.clone();
            let v7: US3 = nullable_10(v5);
            let v8: US3 = nullable_10(v6);
            match &v7 {
                US3::US3_Nullable => {
                    US3::US3_Nullable
                }
                _ => {
                    match &v8 {
                        US3::US3_Nullable => {
                            US3::US3_Nullable
                        }
                        _ => {
                            match &v7 {
                                US3::US3_NonNullable => {
                                    match &v8 {
                                        US3::US3_NonNullable => {
                                            US3::US3_NonNullable
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
            let v18: US3 = nullable_10(v16);
            let v19: US3 = nullable_10(v17);
            match &v18 {
                US3::US3_Nullable => {
                    match &v19 {
                        US3::US3_Nullable => {
                            US3::US3_Nullable
                        }
                        _ => {
                            US3::US3_NonNullable
                        }
                    }
                }
                _ => {
                    US3::US3_NonNullable
                }
            }
        }
        UH2::UH2_RegexChar(v3) => {
            let v3: US0 = v3.clone();
            US3::US3_NonNullable
        }
        UH2::UH2_RegexEmpty => {
            US3::US3_NonNullable
        }
        UH2::UH2_RegexEpsilon => {
            US3::US3_Nullable
        }
        UH2::UH2_RegexStar(v25) => {
            let v25: Rc<UH2> = v25.clone();
            US3::US3_Nullable
        }
    }
}
fn derivative_9(mut v0: Rc<UH2>, mut v1: US0) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v19, v20) => {
            let v19: Rc<UH2> = v19.clone();
            let v20: Rc<UH2> = v20.clone();
            let v21: Rc<UH2> = derivative_9(v19, v1.clone());
            let v22: Rc<UH2> = derivative_9(v20, v1.clone());
            make_alt_3(v21, v22)
        }
        UH2::UH2_RegexCat(v24, v25) => {
            let v24: Rc<UH2> = v24.clone();
            let v25: Rc<UH2> = v25.clone();
            let v26: US3 = nullable_10(v24.clone());
            match &v26 {
                US3::US3_NonNullable => {
                    let v31: Rc<UH2> = derivative_9(v24.clone(), v1.clone());
                    make_cat_6(v31, v25.clone())
                }
                US3::US3_Nullable => {
                    let v27: Rc<UH2> = derivative_9(v24, v1.clone());
                    let v28: Rc<UH2> = make_cat_6(v27, v25.clone());
                    let v29: Rc<UH2> = derivative_9(v25, v1.clone());
                    make_alt_3(v28, v29)
                }
            }
        }
        UH2::UH2_RegexChar(v4) => {
            let v4: US0 = v4.clone();
            let v14: US2 = match &v4 {
                US0::US0_BitOne => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US2::US2_SymbolSame
                        }
                        US0::US0_BitZero => {
                            US2::US2_SymbolGreater
                        }
                    }
                }
                US0::US0_BitZero => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US2::US2_SymbolLess
                        }
                        US0::US0_BitZero => {
                            US2::US2_SymbolSame
                        }
                    }
                }
            };
            let v15: bool = match &v14 {
                US2::US2_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
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
        UH2::UH2_RegexStar(v35) => {
            let v35: Rc<UH2> = v35.clone();
            let v36: Rc<UH2> = derivative_9(v35.clone(), v1);
            let v37: Rc<UH2> = make_star_8(v35);
            make_cat_6(v36, v37)
        }
    }
}
fn canonical_derivative_1(mut v0: Rc<UH2>, mut v1: US0) -> Rc<UH2> {
    let v2: Rc<UH2> = normalize_2(v0);
    let v3: Rc<UH2> = derivative_9(v2, v1);
    normalize_2(v3)
}
fn accepts_0(mut v0: Rc<UH2>, mut v1: Rc<UH0>) -> bool {
    loop {
        match &*v1 {
            UH0::UH0_InputCons(v6, v7) => {
                let v6: US0 = v6.clone();
                let v7: Rc<UH0> = v7.clone();
                let v8: Rc<UH2> = canonical_derivative_1(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH0::UH0_InputEmpty => {
                let v2: Rc<UH2> = normalize_2(v0.clone());
                let v3: US3 = nullable_10(v2.clone());
                match &v3 {
                    US3::US3_NonNullable => {
                        return false;
                    }
                    US3::US3_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
fn regex_compare_16(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> US2 {
    loop {
        match &*v0 {
            UH3::UH3_RegexAlt(v59, v60) => {
                let v59: Rc<UH3> = v59.clone();
                let v60: Rc<UH3> = v60.clone();
                match &*v1 {
                    UH3::UH3_RegexAlt(v61, v62) => {
                        let v61: Rc<UH3> = v61.clone();
                        let v62: Rc<UH3> = v62.clone();
                        let v63: US2 = regex_compare_16(v59.clone(), v61.clone());
                        match &v63 {
                            US2::US2_SymbolSame => {
                                (v0, v1) = (v60.clone(), v62.clone());
                                continue;
                            }
                            _ => {
                                return v63.clone();
                            }
                        }
                    }
                    _ => {
                        return US2::US2_SymbolGreater;
                    }
                }
            }
            UH3::UH3_RegexCat(v34, v35) => {
                let v34: Rc<UH3> = v34.clone();
                let v35: Rc<UH3> = v35.clone();
                match &*v1 {
                    UH3::UH3_RegexCat(v40, v41) => {
                        let v40: Rc<UH3> = v40.clone();
                        let v41: Rc<UH3> = v41.clone();
                        let v42: US2 = regex_compare_16(v34.clone(), v40.clone());
                        match &v42 {
                            US2::US2_SymbolSame => {
                                (v0, v1) = (v35.clone(), v41.clone());
                                continue;
                            }
                            _ => {
                                return v42.clone();
                            }
                        }
                    }
                    UH3::UH3_RegexChar(v38) => {
                        let v38: US1 = v38.clone();
                        return US2::US2_SymbolGreater;
                    }
                    UH3::UH3_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH3::UH3_RegexEpsilon => {
                        return US2::US2_SymbolGreater;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH3::UH3_RegexChar(v10) => {
                let v10: US1 = v10.clone();
                match &*v1 {
                    UH3::UH3_RegexChar(v13) => {
                        let v13: US1 = v13.clone();
                        match &v10 {
                            US1::US1_TriA => {
                                match &v13 {
                                    US1::US1_TriA => {
                                        return US2::US2_SymbolSame;
                                    }
                                    _ => {
                                        return US2::US2_SymbolLess;
                                    }
                                }
                            }
                            _ => {
                                match &v13 {
                                    US1::US1_TriA => {
                                        return US2::US2_SymbolGreater;
                                    }
                                    _ => {
                                        match &v10 {
                                            US1::US1_TriB => {
                                                match &v13 {
                                                    US1::US1_TriB => {
                                                        return US2::US2_SymbolSame;
                                                    }
                                                    US1::US1_TriC => {
                                                        return US2::US2_SymbolLess;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_TriC => {
                                                match &v13 {
                                                    US1::US1_TriB => {
                                                        return US2::US2_SymbolGreater;
                                                    }
                                                    US1::US1_TriC => {
                                                        return US2::US2_SymbolSame;
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
                    UH3::UH3_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH3::UH3_RegexEpsilon => {
                        return US2::US2_SymbolGreater;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH3::UH3_RegexEmpty => {
                match &*v1 {
                    UH3::UH3_RegexEmpty => {
                        return US2::US2_SymbolSame;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH3::UH3_RegexEpsilon => {
                match &*v1 {
                    UH3::UH3_RegexEmpty => {
                        return US2::US2_SymbolGreater;
                    }
                    UH3::UH3_RegexEpsilon => {
                        return US2::US2_SymbolSame;
                    }
                    _ => {
                        return US2::US2_SymbolLess;
                    }
                }
            }
            UH3::UH3_RegexStar(v50) => {
                let v50: Rc<UH3> = v50.clone();
                match &*v1 {
                    UH3::UH3_RegexAlt(v51, v52) => {
                        let v51: Rc<UH3> = v51.clone();
                        let v52: Rc<UH3> = v52.clone();
                        return US2::US2_SymbolLess;
                    }
                    UH3::UH3_RegexStar(v54) => {
                        let v54: Rc<UH3> = v54.clone();
                        (v0, v1) = (v50.clone(), v54.clone());
                        continue;
                    }
                    _ => {
                        return US2::US2_SymbolGreater;
                    }
                }
            }
        }
    }
}
fn alt_insert_sorted_15(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    match &*v1 {
        UH3::UH3_RegexAlt(v2, v3) => {
            let v2: Rc<UH3> = v2.clone();
            let v3: Rc<UH3> = v3.clone();
            let v4: US2 = regex_compare_16(v0.clone(), v2.clone());
            match &v4 {
                US2::US2_SymbolGreater => {
                    let v6: Rc<UH3> = alt_insert_sorted_15(v0.clone(), v3);
                    Rc::new(UH3::UH3_RegexAlt(v2, v6))
                }
                US2::US2_SymbolLess => {
                    Rc::new(UH3::UH3_RegexAlt(v0.clone(), v1.clone()))
                }
                US2::US2_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH3::UH3_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let v11: US2 = regex_compare_16(v0.clone(), v1.clone());
            match &v11 {
                US2::US2_SymbolGreater => {
                    Rc::new(UH3::UH3_RegexAlt(v1.clone(), v0.clone()))
                }
                US2::US2_SymbolLess => {
                    Rc::new(UH3::UH3_RegexAlt(v0, v1.clone()))
                }
                US2::US2_SymbolSame => {
                    v1
                }
            }
        }
    }
}
fn make_alt_14(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    loop {
        match &*v0 {
            UH3::UH3_RegexAlt(v2, v3) => {
                let v2: Rc<UH3> = v2.clone();
                let v3: Rc<UH3> = v3.clone();
                let v4: Rc<UH3> = alt_insert_sorted_15(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH3::UH3_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_15(v0.clone(), v1.clone());
            }
        }
    }
}
fn regex_equal_18(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v0 {
            UH3::UH3_RegexAlt(v24, v25) => {
                let v24: Rc<UH3> = v24.clone();
                let v25: Rc<UH3> = v25.clone();
                match &*v1 {
                    UH3::UH3_RegexAlt(v26, v27) => {
                        let v26: Rc<UH3> = v26.clone();
                        let v27: Rc<UH3> = v27.clone();
                        let v28: bool = regex_equal_18(v24.clone(), v26.clone());
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
            UH3::UH3_RegexCat(v32, v33) => {
                let v32: Rc<UH3> = v32.clone();
                let v33: Rc<UH3> = v33.clone();
                match &*v1 {
                    UH3::UH3_RegexCat(v34, v35) => {
                        let v34: Rc<UH3> = v34.clone();
                        let v35: Rc<UH3> = v35.clone();
                        let v36: bool = regex_equal_18(v32.clone(), v34.clone());
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
            UH3::UH3_RegexChar(v4) => {
                let v4: US1 = v4.clone();
                match &*v1 {
                    UH3::UH3_RegexChar(v5) => {
                        let v5: US1 = v5.clone();
                        let v21: US2 = match &v4 {
                            US1::US1_TriA => {
                                match &v5 {
                                    US1::US1_TriA => {
                                        US2::US2_SymbolSame
                                    }
                                    _ => {
                                        US2::US2_SymbolLess
                                    }
                                }
                            }
                            _ => {
                                match &v5 {
                                    US1::US1_TriA => {
                                        US2::US2_SymbolGreater
                                    }
                                    _ => {
                                        match &v4 {
                                            US1::US1_TriB => {
                                                match &v5 {
                                                    US1::US1_TriB => {
                                                        US2::US2_SymbolSame
                                                    }
                                                    US1::US1_TriC => {
                                                        US2::US2_SymbolLess
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_TriC => {
                                                match &v5 {
                                                    US1::US1_TriB => {
                                                        US2::US2_SymbolGreater
                                                    }
                                                    US1::US1_TriC => {
                                                        US2::US2_SymbolSame
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
                            US2::US2_SymbolSame => {
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
            UH3::UH3_RegexEmpty => {
                match &*v1 {
                    UH3::UH3_RegexEmpty => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH3::UH3_RegexEpsilon => {
                match &*v1 {
                    UH3::UH3_RegexEpsilon => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH3::UH3_RegexStar(v40) => {
                let v40: Rc<UH3> = v40.clone();
                match &*v1 {
                    UH3::UH3_RegexStar(v41) => {
                        let v41: Rc<UH3> = v41.clone();
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
fn make_cat_17(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH3::UH3_RegexEmpty => {
                    { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH3::UH3_RegexEpsilon => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH3::UH3_RegexEpsilon => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH3::UH3_RegexCat(v12, v13) => {
                                            let v12: Rc<UH3> = v12.clone();
                                            let v13: Rc<UH3> = v13.clone();
                                            let v14: Rc<UH3> = make_cat_17(v13, v1.clone());
                                            Rc::new(UH3::UH3_RegexCat(v12, v14))
                                        }
                                        UH3::UH3_RegexStar(v4) => {
                                            let v4: Rc<UH3> = v4.clone();
                                            match &*v1 {
                                                UH3::UH3_RegexStar(v5) => {
                                                    let v5: Rc<UH3> = v5.clone();
                                                    let v6: bool = regex_equal_18(v4.clone(), v5);
                                                    if v6 {
                                                        Rc::new(UH3::UH3_RegexStar(v4))
                                                    } else {
                                                        Rc::new(UH3::UH3_RegexCat(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH3::UH3_RegexCat(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH3::UH3_RegexCat(v0, v1))
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
fn make_star_19(mut v0: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexStar(v3) => {
            let v3: Rc<UH3> = v3.clone();
            Rc::new(UH3::UH3_RegexStar(v3))
        }
        _ => {
            Rc::new(UH3::UH3_RegexStar(v0))
        }
    }
}
fn normalize_13(mut v0: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_RegexAlt(v5, v6) => {
            let v5: Rc<UH3> = v5.clone();
            let v6: Rc<UH3> = v6.clone();
            let v7: Rc<UH3> = normalize_13(v5);
            let v8: Rc<UH3> = normalize_13(v6);
            make_alt_14(v7, v8)
        }
        UH3::UH3_RegexCat(v10, v11) => {
            let v10: Rc<UH3> = v10.clone();
            let v11: Rc<UH3> = v11.clone();
            let v12: Rc<UH3> = normalize_13(v10);
            let v13: Rc<UH3> = normalize_13(v11);
            make_cat_17(v12, v13)
        }
        UH3::UH3_RegexChar(v3) => {
            let v3: US1 = v3.clone();
            Rc::new(UH3::UH3_RegexChar(v3))
        }
        UH3::UH3_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexStar(v15) => {
            let v15: Rc<UH3> = v15.clone();
            let v16: Rc<UH3> = normalize_13(v15);
            make_star_19(v16)
        }
    }
}
fn nullable_21(mut v0: Rc<UH3>) -> US3 {
    match &*v0 {
        UH3::UH3_RegexAlt(v5, v6) => {
            let v5: Rc<UH3> = v5.clone();
            let v6: Rc<UH3> = v6.clone();
            let v7: US3 = nullable_21(v5);
            let v8: US3 = nullable_21(v6);
            match &v7 {
                US3::US3_Nullable => {
                    US3::US3_Nullable
                }
                _ => {
                    match &v8 {
                        US3::US3_Nullable => {
                            US3::US3_Nullable
                        }
                        _ => {
                            match &v7 {
                                US3::US3_NonNullable => {
                                    match &v8 {
                                        US3::US3_NonNullable => {
                                            US3::US3_NonNullable
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
        UH3::UH3_RegexCat(v16, v17) => {
            let v16: Rc<UH3> = v16.clone();
            let v17: Rc<UH3> = v17.clone();
            let v18: US3 = nullable_21(v16);
            let v19: US3 = nullable_21(v17);
            match &v18 {
                US3::US3_Nullable => {
                    match &v19 {
                        US3::US3_Nullable => {
                            US3::US3_Nullable
                        }
                        _ => {
                            US3::US3_NonNullable
                        }
                    }
                }
                _ => {
                    US3::US3_NonNullable
                }
            }
        }
        UH3::UH3_RegexChar(v3) => {
            let v3: US1 = v3.clone();
            US3::US3_NonNullable
        }
        UH3::UH3_RegexEmpty => {
            US3::US3_NonNullable
        }
        UH3::UH3_RegexEpsilon => {
            US3::US3_Nullable
        }
        UH3::UH3_RegexStar(v25) => {
            let v25: Rc<UH3> = v25.clone();
            US3::US3_Nullable
        }
    }
}
fn derivative_20(mut v0: Rc<UH3>, mut v1: US1) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_RegexAlt(v25, v26) => {
            let v25: Rc<UH3> = v25.clone();
            let v26: Rc<UH3> = v26.clone();
            let v27: Rc<UH3> = derivative_20(v25, v1.clone());
            let v28: Rc<UH3> = derivative_20(v26, v1.clone());
            make_alt_14(v27, v28)
        }
        UH3::UH3_RegexCat(v30, v31) => {
            let v30: Rc<UH3> = v30.clone();
            let v31: Rc<UH3> = v31.clone();
            let v32: US3 = nullable_21(v30.clone());
            match &v32 {
                US3::US3_NonNullable => {
                    let v37: Rc<UH3> = derivative_20(v30.clone(), v1.clone());
                    make_cat_17(v37, v31.clone())
                }
                US3::US3_Nullable => {
                    let v33: Rc<UH3> = derivative_20(v30, v1.clone());
                    let v34: Rc<UH3> = make_cat_17(v33, v31.clone());
                    let v35: Rc<UH3> = derivative_20(v31, v1.clone());
                    make_alt_14(v34, v35)
                }
            }
        }
        UH3::UH3_RegexChar(v4) => {
            let v4: US1 = v4.clone();
            let v20: US2 = match &v4 {
                US1::US1_TriA => {
                    match &v1 {
                        US1::US1_TriA => {
                            US2::US2_SymbolSame
                        }
                        _ => {
                            US2::US2_SymbolLess
                        }
                    }
                }
                _ => {
                    match &v1 {
                        US1::US1_TriA => {
                            US2::US2_SymbolGreater
                        }
                        _ => {
                            match &v4 {
                                US1::US1_TriB => {
                                    match &v1 {
                                        US1::US1_TriB => {
                                            US2::US2_SymbolSame
                                        }
                                        US1::US1_TriC => {
                                            US2::US2_SymbolLess
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                US1::US1_TriC => {
                                    match &v1 {
                                        US1::US1_TriB => {
                                            US2::US2_SymbolGreater
                                        }
                                        US1::US1_TriC => {
                                            US2::US2_SymbolSame
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
                US2::US2_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v21 {
                { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEpsilon); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
            }
        }
        UH3::UH3_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_RegexStar(v41) => {
            let v41: Rc<UH3> = v41.clone();
            let v42: Rc<UH3> = derivative_20(v41.clone(), v1);
            let v43: Rc<UH3> = make_star_19(v41);
            make_cat_17(v42, v43)
        }
    }
}
fn canonical_derivative_12(mut v0: Rc<UH3>, mut v1: US1) -> Rc<UH3> {
    let v2: Rc<UH3> = normalize_13(v0);
    let v3: Rc<UH3> = derivative_20(v2, v1);
    normalize_13(v3)
}
fn accepts_11(mut v0: Rc<UH3>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v6, v7) => {
                let v6: US1 = v6.clone();
                let v7: Rc<UH1> = v7.clone();
                let v8: Rc<UH3> = canonical_derivative_12(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH1::UH1_InputEmpty => {
                let v2: Rc<UH3> = normalize_13(v0.clone());
                let v3: US3 = nullable_21(v2.clone());
                match &v3 {
                    US3::US3_NonNullable => {
                        return false;
                    }
                    US3::US3_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
fn decide_bit_match_22(mut v0: US4) -> US5 {
    match &v0 {
        US4::US4_BitMatcherRaw(v1, v2) => {
            let v1: Rc<UH2> = v1.clone();
            let v2: Rc<UH0> = v2.clone();
            let v3: bool = accepts_0(v1.clone(), v2.clone());
            US5::US5_BitMatcherDecided(v1, v2, v3)
        }
    }
}
fn bit_match_value_23(mut v0: US5) -> bool {
    match &v0 {
        US5::US5_BitMatcherDecided(v1, v2, v3) => {
            let v1: Rc<UH2> = v1.clone();
            let v2: Rc<UH0> = v2.clone();
            let v3: bool = *v3;
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let v0: US0 = US0::US0_BitOne;
    let v1: US0 = US0::US0_BitOne;
    let v2: US0 = US0::US0_BitZero;
    let v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_InputEmpty); } CASE.with(|case| case.clone()) };
    let v4: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v2, v3));
    let v5: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v1, v4));
    let v6: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v0, v5));
    let v7: US0 = US0::US0_BitOne;
    let v8: US0 = US0::US0_BitOne;
    let v9: US0 = US0::US0_BitOne;
    let v10: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_InputEmpty); } CASE.with(|case| case.clone()) };
    let v11: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v9, v10));
    let v12: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v8, v11));
    let v13: Rc<UH0> = Rc::new(UH0::UH0_InputCons(v7, v12));
    let v14: US1 = US1::US1_TriA;
    let v15: US1 = US1::US1_TriA;
    let v16: US1 = US1::US1_TriA;
    let v17: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
    let v18: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v16, v17));
    let v19: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v15, v18));
    let v20: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v14, v19));
    let v21: US1 = US1::US1_TriA;
    let v22: US1 = US1::US1_TriA;
    let v23: US1 = US1::US1_TriB;
    let v24: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
    let v25: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v23, v24));
    let v26: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v22, v25));
    let v27: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v21, v26));
    let v28: US0 = US0::US0_BitZero;
    let v29: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v28));
    let v30: US0 = US0::US0_BitOne;
    let v31: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v30));
    let v32: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v29, v31));
    let v33: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v32));
    let v34: US0 = US0::US0_BitZero;
    let v35: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v34));
    let v36: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v33, v35));
    let v37: bool = accepts_0(v36, v6.clone());
    if v37 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let v38: US0 = US0::US0_BitZero;
    let v39: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v38));
    let v40: US0 = US0::US0_BitOne;
    let v41: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v40));
    let v42: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v39, v41));
    let v43: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v42));
    let v44: US0 = US0::US0_BitZero;
    let v45: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v44));
    let v46: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v43, v45));
    let v47: bool = accepts_0(v46, v13.clone());
    if v47 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    let v48: US1 = US1::US1_TriA;
    let v49: Rc<UH3> = Rc::new(UH3::UH3_RegexChar(v48));
    let v50: Rc<UH3> = Rc::new(UH3::UH3_RegexStar(v49));
    let v51: bool = accepts_11(v50, v20);
    if v51 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let v52: US1 = US1::US1_TriA;
    let v53: Rc<UH3> = Rc::new(UH3::UH3_RegexChar(v52));
    let v54: Rc<UH3> = Rc::new(UH3::UH3_RegexStar(v53));
    let v55: bool = accepts_11(v54, v27);
    if v55 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    let v56: US0 = US0::US0_BitZero;
    let v57: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v56));
    let v58: US0 = US0::US0_BitOne;
    let v59: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v58));
    let v60: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v57, v59));
    let v61: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v60));
    let v62: US0 = US0::US0_BitZero;
    let v63: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v62));
    let v64: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v61, v63));
    let v65: US4 = US4::US4_BitMatcherRaw(v64, v6);
    let v66: US5 = decide_bit_match_22(v65);
    let v67: US0 = US0::US0_BitZero;
    let v68: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v67));
    let v69: US0 = US0::US0_BitOne;
    let v70: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v69));
    let v71: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v68, v70));
    let v72: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v71));
    let v73: US0 = US0::US0_BitZero;
    let v74: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v73));
    let v75: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v72, v74));
    let v76: US4 = US4::US4_BitMatcherRaw(v75, v13);
    let v77: US5 = decide_bit_match_22(v76);
    let v78: bool = bit_match_value_23(v66);
    if v78 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let v79: bool = bit_match_value_23(v77);
    if v79 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
