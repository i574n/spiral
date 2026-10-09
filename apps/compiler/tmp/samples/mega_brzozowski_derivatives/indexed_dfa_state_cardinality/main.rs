#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_BitZero,
    US0_BitOne,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_BitZero => 0,
            US0::US0_BitOne => 1,
        }
    }
}
#[derive(Clone)]
enum UH0 {
    UH0_RegexEmpty,
    UH0_RegexEpsilon,
    UH0_RegexChar(US0),
    UH0_RegexAlt(Rc<UH0>, Rc<UH0>),
    UH0_RegexCat(Rc<UH0>, Rc<UH0>),
    UH0_RegexStar(Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_RegexEmpty => 0,
            UH0::UH0_RegexEpsilon => 1,
            UH0::UH0_RegexChar(..) => 2,
            UH0::UH0_RegexAlt(..) => 3,
            UH0::UH0_RegexCat(..) => 4,
            UH0::UH0_RegexStar(..) => 5,
        }
    }
}
#[derive(Clone)]
enum UH1 {
    UH1_InputEmpty,
    UH1_InputCons(US0, Rc<UH1>),
}
impl UH1 {
    fn tag(&self) -> i32 {
        match self {
            UH1::UH1_InputEmpty => 0,
            UH1::UH1_InputCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US1 {
    US1_SymbolLess,
    US1_SymbolSame,
    US1_SymbolGreater,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_SymbolLess => 0,
            US1::US1_SymbolSame => 1,
            US1::US1_SymbolGreater => 2,
        }
    }
}
#[derive(Clone)]
enum US2 {
    US2_Nullable,
    US2_NonNullable,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_Nullable => 0,
            US2::US2_NonNullable => 1,
        }
    }
}
#[derive(Clone)]
enum US3 {
    US3_TriA,
    US3_TriB,
    US3_TriC,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_TriA => 0,
            US3::US3_TriB => 1,
            US3::US3_TriC => 2,
        }
    }
}
#[derive(Clone)]
enum UH2 {
    UH2_RegexEmpty,
    UH2_RegexEpsilon,
    UH2_RegexChar(US3),
    UH2_RegexAlt(Rc<UH2>, Rc<UH2>),
    UH2_RegexCat(Rc<UH2>, Rc<UH2>),
    UH2_RegexStar(Rc<UH2>),
}
impl UH2 {
    fn tag(&self) -> i32 {
        match self {
            UH2::UH2_RegexEmpty => 0,
            UH2::UH2_RegexEpsilon => 1,
            UH2::UH2_RegexChar(..) => 2,
            UH2::UH2_RegexAlt(..) => 3,
            UH2::UH2_RegexCat(..) => 4,
            UH2::UH2_RegexStar(..) => 5,
        }
    }
}
#[derive(Clone)]
enum UH3 {
    UH3_InputEmpty,
    UH3_InputCons(US3, Rc<UH3>),
}
impl UH3 {
    fn tag(&self) -> i32 {
        match self {
            UH3::UH3_InputEmpty => 0,
            UH3::UH3_InputCons(..) => 1,
        }
    }
}
fn random_bit_input_1(mut v0: u64, mut v1: i32, mut v2: Rc<UH1>) -> (Rc<UH1>, u64) {
    loop {
        let mut v3: bool = 0i32 < v1;
        if v3 {
            let mut v4: u64 = v0.wrapping_mul(1103515245u64);
            let mut v5: u64 = v4.wrapping_add(12345u64);
            let mut v6: u64 = v5 & 2147483647u64;
            let mut v7: i32 = v1.wrapping_sub(1i32);
            let mut v8: u64 = v6.wrapping_shr((16i32) as u32);
            let mut v9: u64 = v8 & 1u64;
            let mut v10: bool = v9 == 0u64;
            let mut v13: US0 = if v10 {
                let mut v11: US0 = US0::US0_BitZero;
                v11.clone()
            } else {
                let mut v12: US0 = US0::US0_BitOne;
                v12.clone()
            };
            let mut v14: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v13.clone(), v2.clone()));
            (v0, v1, v2) = (v6, v7, v14.clone());
            continue;
        } else {
            return (v2.clone(), v0);
        }
    }
}
fn run_2(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v4, v5) => {
                let mut v4: US0 = v4.clone();
                let mut v5: Rc<UH1> = v5.clone();
                let mut v6: bool = v0 == 0i32;
                let mut v19: i32 = if v6 {
                    let mut v10: US1 = match &v4 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolGreater
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    };
                    let mut v11: bool = match &v10 {
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
                    let mut v16: US1 = match &v4 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolGreater
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    };
                    let mut v17: bool = match &v16 {
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
                let mut v2: bool = v0 == 0i32;
                let mut v3: bool = v2 == false;
                return v3;
            }
        }
    }
}
fn regex_compare_8(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> US1 {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v53, v54) => {
                let mut v53: Rc<UH0> = v53.clone();
                let mut v54: Rc<UH0> = v54.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v55, v56) => {
                        let mut v55: Rc<UH0> = v55.clone();
                        let mut v56: Rc<UH0> = v56.clone();
                        let mut v57: US1 = regex_compare_8(v53.clone(), v55.clone());
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
                let mut v28: Rc<UH0> = v28.clone();
                let mut v29: Rc<UH0> = v29.clone();
                match &*v1 {
                    UH0::UH0_RegexCat(v34, v35) => {
                        let mut v34: Rc<UH0> = v34.clone();
                        let mut v35: Rc<UH0> = v35.clone();
                        let mut v36: US1 = regex_compare_8(v28.clone(), v34.clone());
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
                        let mut v32: US0 = v32.clone();
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
                let mut v10: US0 = v10.clone();
                match &*v1 {
                    UH0::UH0_RegexChar(v13) => {
                        let mut v13: US0 = v13.clone();
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
                let mut v44: Rc<UH0> = v44.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v45, v46) => {
                        let mut v45: Rc<UH0> = v45.clone();
                        let mut v46: Rc<UH0> = v46.clone();
                        return US1::US1_SymbolLess;
                    }
                    UH0::UH0_RegexStar(v48) => {
                        let mut v48: Rc<UH0> = v48.clone();
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
fn alt_insert_sorted_7(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    match &*v1 {
        UH0::UH0_RegexAlt(v2, v3) => {
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: US1 = regex_compare_8(v0.clone(), v2.clone());
            match &v4 {
                US1::US1_SymbolGreater => {
                    let mut v6: Rc<UH0> = alt_insert_sorted_7(v0.clone(), v3.clone());
                    Rc::new(UH0::UH0_RegexAlt(v2.clone(), v6.clone()))
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
            let mut v11: US1 = regex_compare_8(v0.clone(), v1.clone());
            match &v11 {
                US1::US1_SymbolGreater => {
                    Rc::new(UH0::UH0_RegexAlt(v1.clone(), v0.clone()))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH0::UH0_RegexAlt(v0.clone(), v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1.clone()
                }
            }
        }
    }
}
fn make_alt_6(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v2, v3) => {
                let mut v2: Rc<UH0> = v2.clone();
                let mut v3: Rc<UH0> = v3.clone();
                let mut v4: Rc<UH0> = alt_insert_sorted_7(v2.clone(), v1.clone());
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
fn regex_equal_10(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> bool {
    loop {
        match &*v0 {
            UH0::UH0_RegexAlt(v18, v19) => {
                let mut v18: Rc<UH0> = v18.clone();
                let mut v19: Rc<UH0> = v19.clone();
                match &*v1 {
                    UH0::UH0_RegexAlt(v20, v21) => {
                        let mut v20: Rc<UH0> = v20.clone();
                        let mut v21: Rc<UH0> = v21.clone();
                        let mut v22: bool = regex_equal_10(v18.clone(), v20.clone());
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
                let mut v26: Rc<UH0> = v26.clone();
                let mut v27: Rc<UH0> = v27.clone();
                match &*v1 {
                    UH0::UH0_RegexCat(v28, v29) => {
                        let mut v28: Rc<UH0> = v28.clone();
                        let mut v29: Rc<UH0> = v29.clone();
                        let mut v30: bool = regex_equal_10(v26.clone(), v28.clone());
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
                let mut v4: US0 = v4.clone();
                match &*v1 {
                    UH0::UH0_RegexChar(v5) => {
                        let mut v5: US0 = v5.clone();
                        let mut v15: US1 = match &v4 {
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
                let mut v34: Rc<UH0> = v34.clone();
                match &*v1 {
                    UH0::UH0_RegexStar(v35) => {
                        let mut v35: Rc<UH0> = v35.clone();
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
fn make_cat_9(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
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
                                            let mut v12: Rc<UH0> = v12.clone();
                                            let mut v13: Rc<UH0> = v13.clone();
                                            let mut v14: Rc<UH0> = make_cat_9(v13.clone(), v1.clone());
                                            Rc::new(UH0::UH0_RegexCat(v12.clone(), v14.clone()))
                                        }
                                        UH0::UH0_RegexStar(v4) => {
                                            let mut v4: Rc<UH0> = v4.clone();
                                            match &*v1 {
                                                UH0::UH0_RegexStar(v5) => {
                                                    let mut v5: Rc<UH0> = v5.clone();
                                                    let mut v6: bool = regex_equal_10(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH0::UH0_RegexStar(v4.clone()))
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
                                            Rc::new(UH0::UH0_RegexCat(v0.clone(), v1.clone()))
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
fn make_star_11(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexStar(v3) => {
            let mut v3: Rc<UH0> = v3.clone();
            Rc::new(UH0::UH0_RegexStar(v3.clone()))
        }
        _ => {
            Rc::new(UH0::UH0_RegexStar(v0.clone()))
        }
    }
}
fn normalize_5(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH0> = v5.clone();
            let mut v6: Rc<UH0> = v6.clone();
            let mut v7: Rc<UH0> = normalize_5(v5.clone());
            let mut v8: Rc<UH0> = normalize_5(v6.clone());
            make_alt_6(v7.clone(), v8.clone())
        }
        UH0::UH0_RegexCat(v10, v11) => {
            let mut v10: Rc<UH0> = v10.clone();
            let mut v11: Rc<UH0> = v11.clone();
            let mut v12: Rc<UH0> = normalize_5(v10.clone());
            let mut v13: Rc<UH0> = normalize_5(v11.clone());
            make_cat_9(v12.clone(), v13.clone())
        }
        UH0::UH0_RegexChar(v3) => {
            let mut v3: US0 = v3.clone();
            Rc::new(UH0::UH0_RegexChar(v3.clone()))
        }
        UH0::UH0_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_RegexStar(v15) => {
            let mut v15: Rc<UH0> = v15.clone();
            let mut v16: Rc<UH0> = normalize_5(v15.clone());
            make_star_11(v16.clone())
        }
    }
}
fn nullable_13(mut v0: Rc<UH0>) -> US2 {
    match &*v0 {
        UH0::UH0_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH0> = v5.clone();
            let mut v6: Rc<UH0> = v6.clone();
            let mut v7: US2 = nullable_13(v5.clone());
            let mut v8: US2 = nullable_13(v6.clone());
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
            let mut v16: Rc<UH0> = v16.clone();
            let mut v17: Rc<UH0> = v17.clone();
            let mut v18: US2 = nullable_13(v16.clone());
            let mut v19: US2 = nullable_13(v17.clone());
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
            let mut v3: US0 = v3.clone();
            US2::US2_NonNullable
        }
        UH0::UH0_RegexEmpty => {
            US2::US2_NonNullable
        }
        UH0::UH0_RegexEpsilon => {
            US2::US2_Nullable
        }
        UH0::UH0_RegexStar(v25) => {
            let mut v25: Rc<UH0> = v25.clone();
            US2::US2_Nullable
        }
    }
}
fn derivative_12(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_RegexAlt(v19, v20) => {
            let mut v19: Rc<UH0> = v19.clone();
            let mut v20: Rc<UH0> = v20.clone();
            let mut v21: Rc<UH0> = derivative_12(v19.clone(), v1.clone());
            let mut v22: Rc<UH0> = derivative_12(v20.clone(), v1.clone());
            make_alt_6(v21.clone(), v22.clone())
        }
        UH0::UH0_RegexCat(v24, v25) => {
            let mut v24: Rc<UH0> = v24.clone();
            let mut v25: Rc<UH0> = v25.clone();
            let mut v26: US2 = nullable_13(v24.clone());
            match &v26 {
                US2::US2_NonNullable => {
                    let mut v31: Rc<UH0> = derivative_12(v24.clone(), v1.clone());
                    make_cat_9(v31.clone(), v25.clone())
                }
                US2::US2_Nullable => {
                    let mut v27: Rc<UH0> = derivative_12(v24.clone(), v1.clone());
                    let mut v28: Rc<UH0> = make_cat_9(v27.clone(), v25.clone());
                    let mut v29: Rc<UH0> = derivative_12(v25.clone(), v1.clone());
                    make_alt_6(v28.clone(), v29.clone())
                }
            }
        }
        UH0::UH0_RegexChar(v4) => {
            let mut v4: US0 = v4.clone();
            let mut v14: US1 = match &v4 {
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
            let mut v15: bool = match &v14 {
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
            let mut v35: Rc<UH0> = v35.clone();
            let mut v36: Rc<UH0> = derivative_12(v35.clone(), v1.clone());
            let mut v37: Rc<UH0> = make_star_11(v35.clone());
            make_cat_9(v36.clone(), v37.clone())
        }
    }
}
fn canonical_derivative_4(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    let mut v2: Rc<UH0> = normalize_5(v0.clone());
    let mut v3: Rc<UH0> = derivative_12(v2.clone(), v1.clone());
    normalize_5(v3.clone())
}
fn accepts_3(mut v0: Rc<UH0>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v6, v7) => {
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH1> = v7.clone();
                let mut v8: Rc<UH0> = canonical_derivative_4(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH1::UH1_InputEmpty => {
                let mut v2: Rc<UH0> = normalize_5(v0.clone());
                let mut v3: US2 = nullable_13(v2.clone());
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
fn loop_0(mut v0: i32, mut v1: Rc<UH0>, mut v2: i32, mut v3: u64, mut v4: i32) -> i32 {
    loop {
        let mut v5: bool = 0i32 < v2;
        if v5 {
            let mut v6: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let (mut v7, mut v8): (Rc<UH1>, u64) = random_bit_input_1(v3, v0, v6.clone());
            let mut v9: i32 = 0i32;
            let mut v10: bool = run_2(v9, v7.clone());
            let mut v11: bool = accepts_3(v1.clone(), v7.clone());
            let mut v13: bool = if v10 {
                v11
            } else {
                let mut v12: bool = false == v11;
                v12
            };
            if v13 {
                let mut v14: i32 = v2.wrapping_sub(1i32);
                let mut v16: i32 = if v10 {
                    let mut v15: i32 = v4.wrapping_add(1i32);
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
fn zeros_input_15(mut v0: i32, mut v1: Rc<UH1>) -> Rc<UH1> {
    loop {
        let mut v2: bool = 0i32 < v0;
        if v2 {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: US0 = US0::US0_BitZero;
            let mut v5: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v4.clone(), v1.clone()));
            (v0, v1) = (v3, v5.clone());
            continue;
        } else {
            return v1.clone();
        }
    }
}
fn run_16(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputCons(v5, v6) => {
                let mut v5: US0 = v5.clone();
                let mut v6: Rc<UH1> = v6.clone();
                let mut v7: bool = v0 == 0i32;
                let mut v26: i32 = if v7 {
                    let mut v11: US1 = match &v5 {
                        US0::US0_BitOne => {
                            US1::US1_SymbolGreater
                        }
                        US0::US0_BitZero => {
                            US1::US1_SymbolSame
                        }
                    };
                    let mut v12: bool = match &v11 {
                        US1::US1_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    1i32
                } else {
                    let mut v13: bool = v0 == 1i32;
                    if v13 {
                        let mut v17: US1 = match &v5 {
                            US0::US0_BitOne => {
                                US1::US1_SymbolGreater
                            }
                            US0::US0_BitZero => {
                                US1::US1_SymbolSame
                            }
                        };
                        let mut v18: bool = match &v17 {
                            US1::US1_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        1i32
                    } else {
                        let mut v22: US1 = match &v5 {
                            US0::US0_BitOne => {
                                US1::US1_SymbolGreater
                            }
                            US0::US0_BitZero => {
                                US1::US1_SymbolSame
                            }
                        };
                        let mut v23: bool = match &v22 {
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
                let mut v2: bool = v0 == 0i32;
                if v2 {
                    return true;
                } else {
                    let mut v3: bool = v0 == 1i32;
                    return false;
                }
            }
        }
    }
}
fn loop_14(mut v0: i32, mut v1: Rc<UH0>, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = v0 < v2;
        if v4 {
            return v3;
        } else {
            let mut v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH1> = zeros_input_15(v2, v5.clone());
            let mut v7: i32 = 2i32;
            let mut v8: bool = run_16(v7, v6.clone());
            let mut v9: bool = accepts_3(v1.clone(), v6.clone());
            let mut v11: bool = if v8 {
                v9
            } else {
                let mut v10: bool = false == v9;
                v10
            };
            let mut v15: i32 = if v11 {
                if v8 {
                    let mut v12: i32 = v3.wrapping_add(1i32);
                    v12
                } else {
                    v3
                }
            } else {
                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-core-disagrees-on-zero-run"); } LIT.with(|lit| lit.clone()) }))
            };
            let mut v16: US0 = US0::US0_BitOne;
            let mut v17: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputEmpty); } CASE.with(|case| case.clone()) };
            let mut v18: Rc<UH1> = Rc::new(UH1::UH1_InputCons(v16.clone(), v17.clone()));
            let mut v19: Rc<UH1> = zeros_input_15(v2, v18.clone());
            let mut v20: i32 = 2i32;
            let mut v21: bool = run_16(v20, v19.clone());
            let mut v22: bool = accepts_3(v1.clone(), v19.clone());
            let mut v24: bool = if v21 {
                v22
            } else {
                let mut v23: bool = false == v22;
                v23
            };
            let mut v28: i32 = if v24 {
                if v21 {
                    let mut v25: i32 = v15.wrapping_add(1i32);
                    v25
                } else {
                    v15
                }
            } else {
                std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-core-disagrees-on-zero-run"); } LIT.with(|lit| lit.clone()) }))
            };
            let mut v29: i32 = v2.wrapping_add(1i32);
            (v0, v1, v2, v3) = (v0, v1.clone(), v29, v28);
            continue;
        }
    }
}
fn run_17(mut v0: i32, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v1 {
            UH3::UH3_InputCons(v5, v6) => {
                let mut v5: US3 = v5.clone();
                let mut v6: Rc<UH3> = v6.clone();
                let mut v7: bool = v0 == 0i32;
                let mut v47: i32 = if v7 {
                    let mut v10: US1 = match &v5 {
                        US3::US3_TriA => {
                            US1::US1_SymbolSame
                        }
                        _ => {
                            US1::US1_SymbolGreater
                        }
                    };
                    let mut v11: bool = match &v10 {
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
                        let mut v17: US1 = match &v5 {
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
                        let mut v18: bool = match &v17 {
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
                    let mut v21: bool = v0 == 1i32;
                    if v21 {
                        let mut v24: US1 = match &v5 {
                            US3::US3_TriA => {
                                US1::US1_SymbolSame
                            }
                            _ => {
                                US1::US1_SymbolGreater
                            }
                        };
                        let mut v25: bool = match &v24 {
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
                            let mut v31: US1 = match &v5 {
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
                            let mut v32: bool = match &v31 {
                                US1::US1_SymbolSame => {
                                    true
                                }
                                _ => {
                                    false
                                }
                            };
                            2i32
                        }
                    } else {
                        let mut v36: US1 = match &v5 {
                            US3::US3_TriA => {
                                US1::US1_SymbolSame
                            }
                            _ => {
                                US1::US1_SymbolGreater
                            }
                        };
                        let mut v37: bool = match &v36 {
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
                            let mut v43: US1 = match &v5 {
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
                            let mut v44: bool = match &v43 {
                                US1::US1_SymbolSame => {
                                    true
                                }
                                _ => {
                                    false
                                }
                            };
                            2i32
                        }
                    }
                };
                (v0, v1) = (v47, v6.clone());
                continue;
            }
            UH3::UH3_InputEmpty => {
                let mut v2: bool = v0 == 0i32;
                if v2 {
                    return false;
                } else {
                    let mut v3: bool = v0 == 1i32;
                    return v3;
                }
            }
        }
    }
}
fn regex_compare_23(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US1 {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v59, v60) => {
                let mut v59: Rc<UH2> = v59.clone();
                let mut v60: Rc<UH2> = v60.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v61, v62) => {
                        let mut v61: Rc<UH2> = v61.clone();
                        let mut v62: Rc<UH2> = v62.clone();
                        let mut v63: US1 = regex_compare_23(v59.clone(), v61.clone());
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
                let mut v34: Rc<UH2> = v34.clone();
                let mut v35: Rc<UH2> = v35.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v40, v41) => {
                        let mut v40: Rc<UH2> = v40.clone();
                        let mut v41: Rc<UH2> = v41.clone();
                        let mut v42: US1 = regex_compare_23(v34.clone(), v40.clone());
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
                        let mut v38: US3 = v38.clone();
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
                let mut v10: US3 = v10.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v13) => {
                        let mut v13: US3 = v13.clone();
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
                let mut v50: Rc<UH2> = v50.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v51, v52) => {
                        let mut v51: Rc<UH2> = v51.clone();
                        let mut v52: Rc<UH2> = v52.clone();
                        return US1::US1_SymbolLess;
                    }
                    UH2::UH2_RegexStar(v54) => {
                        let mut v54: Rc<UH2> = v54.clone();
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
fn alt_insert_sorted_22(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v1 {
        UH2::UH2_RegexAlt(v2, v3) => {
            let mut v2: Rc<UH2> = v2.clone();
            let mut v3: Rc<UH2> = v3.clone();
            let mut v4: US1 = regex_compare_23(v0.clone(), v2.clone());
            match &v4 {
                US1::US1_SymbolGreater => {
                    let mut v6: Rc<UH2> = alt_insert_sorted_22(v0.clone(), v3.clone());
                    Rc::new(UH2::UH2_RegexAlt(v2.clone(), v6.clone()))
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
            let mut v11: US1 = regex_compare_23(v0.clone(), v1.clone());
            match &v11 {
                US1::US1_SymbolGreater => {
                    Rc::new(UH2::UH2_RegexAlt(v1.clone(), v0.clone()))
                }
                US1::US1_SymbolLess => {
                    Rc::new(UH2::UH2_RegexAlt(v0.clone(), v1.clone()))
                }
                US1::US1_SymbolSame => {
                    v1.clone()
                }
            }
        }
    }
}
fn make_alt_21(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v2, v3) => {
                let mut v2: Rc<UH2> = v2.clone();
                let mut v3: Rc<UH2> = v3.clone();
                let mut v4: Rc<UH2> = alt_insert_sorted_22(v2.clone(), v1.clone());
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
fn regex_equal_25(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v0 {
            UH2::UH2_RegexAlt(v24, v25) => {
                let mut v24: Rc<UH2> = v24.clone();
                let mut v25: Rc<UH2> = v25.clone();
                match &*v1 {
                    UH2::UH2_RegexAlt(v26, v27) => {
                        let mut v26: Rc<UH2> = v26.clone();
                        let mut v27: Rc<UH2> = v27.clone();
                        let mut v28: bool = regex_equal_25(v24.clone(), v26.clone());
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
                let mut v32: Rc<UH2> = v32.clone();
                let mut v33: Rc<UH2> = v33.clone();
                match &*v1 {
                    UH2::UH2_RegexCat(v34, v35) => {
                        let mut v34: Rc<UH2> = v34.clone();
                        let mut v35: Rc<UH2> = v35.clone();
                        let mut v36: bool = regex_equal_25(v32.clone(), v34.clone());
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
                let mut v4: US3 = v4.clone();
                match &*v1 {
                    UH2::UH2_RegexChar(v5) => {
                        let mut v5: US3 = v5.clone();
                        let mut v21: US1 = match &v4 {
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
                let mut v40: Rc<UH2> = v40.clone();
                match &*v1 {
                    UH2::UH2_RegexStar(v41) => {
                        let mut v41: Rc<UH2> = v41.clone();
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
fn make_cat_24(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
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
                                            let mut v12: Rc<UH2> = v12.clone();
                                            let mut v13: Rc<UH2> = v13.clone();
                                            let mut v14: Rc<UH2> = make_cat_24(v13.clone(), v1.clone());
                                            Rc::new(UH2::UH2_RegexCat(v12.clone(), v14.clone()))
                                        }
                                        UH2::UH2_RegexStar(v4) => {
                                            let mut v4: Rc<UH2> = v4.clone();
                                            match &*v1 {
                                                UH2::UH2_RegexStar(v5) => {
                                                    let mut v5: Rc<UH2> = v5.clone();
                                                    let mut v6: bool = regex_equal_25(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH2::UH2_RegexStar(v4.clone()))
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
                                            Rc::new(UH2::UH2_RegexCat(v0.clone(), v1.clone()))
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
fn make_star_26(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexStar(v3) => {
            let mut v3: Rc<UH2> = v3.clone();
            Rc::new(UH2::UH2_RegexStar(v3.clone()))
        }
        _ => {
            Rc::new(UH2::UH2_RegexStar(v0.clone()))
        }
    }
}
fn normalize_20(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH2> = v5.clone();
            let mut v6: Rc<UH2> = v6.clone();
            let mut v7: Rc<UH2> = normalize_20(v5.clone());
            let mut v8: Rc<UH2> = normalize_20(v6.clone());
            make_alt_21(v7.clone(), v8.clone())
        }
        UH2::UH2_RegexCat(v10, v11) => {
            let mut v10: Rc<UH2> = v10.clone();
            let mut v11: Rc<UH2> = v11.clone();
            let mut v12: Rc<UH2> = normalize_20(v10.clone());
            let mut v13: Rc<UH2> = normalize_20(v11.clone());
            make_cat_24(v12.clone(), v13.clone())
        }
        UH2::UH2_RegexChar(v3) => {
            let mut v3: US3 = v3.clone();
            Rc::new(UH2::UH2_RegexChar(v3.clone()))
        }
        UH2::UH2_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_RegexStar(v15) => {
            let mut v15: Rc<UH2> = v15.clone();
            let mut v16: Rc<UH2> = normalize_20(v15.clone());
            make_star_26(v16.clone())
        }
    }
}
fn nullable_28(mut v0: Rc<UH2>) -> US2 {
    match &*v0 {
        UH2::UH2_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH2> = v5.clone();
            let mut v6: Rc<UH2> = v6.clone();
            let mut v7: US2 = nullable_28(v5.clone());
            let mut v8: US2 = nullable_28(v6.clone());
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
            let mut v16: Rc<UH2> = v16.clone();
            let mut v17: Rc<UH2> = v17.clone();
            let mut v18: US2 = nullable_28(v16.clone());
            let mut v19: US2 = nullable_28(v17.clone());
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
            let mut v3: US3 = v3.clone();
            US2::US2_NonNullable
        }
        UH2::UH2_RegexEmpty => {
            US2::US2_NonNullable
        }
        UH2::UH2_RegexEpsilon => {
            US2::US2_Nullable
        }
        UH2::UH2_RegexStar(v25) => {
            let mut v25: Rc<UH2> = v25.clone();
            US2::US2_Nullable
        }
    }
}
fn derivative_27(mut v0: Rc<UH2>, mut v1: US3) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_RegexAlt(v25, v26) => {
            let mut v25: Rc<UH2> = v25.clone();
            let mut v26: Rc<UH2> = v26.clone();
            let mut v27: Rc<UH2> = derivative_27(v25.clone(), v1.clone());
            let mut v28: Rc<UH2> = derivative_27(v26.clone(), v1.clone());
            make_alt_21(v27.clone(), v28.clone())
        }
        UH2::UH2_RegexCat(v30, v31) => {
            let mut v30: Rc<UH2> = v30.clone();
            let mut v31: Rc<UH2> = v31.clone();
            let mut v32: US2 = nullable_28(v30.clone());
            match &v32 {
                US2::US2_NonNullable => {
                    let mut v37: Rc<UH2> = derivative_27(v30.clone(), v1.clone());
                    make_cat_24(v37.clone(), v31.clone())
                }
                US2::US2_Nullable => {
                    let mut v33: Rc<UH2> = derivative_27(v30.clone(), v1.clone());
                    let mut v34: Rc<UH2> = make_cat_24(v33.clone(), v31.clone());
                    let mut v35: Rc<UH2> = derivative_27(v31.clone(), v1.clone());
                    make_alt_21(v34.clone(), v35.clone())
                }
            }
        }
        UH2::UH2_RegexChar(v4) => {
            let mut v4: US3 = v4.clone();
            let mut v20: US1 = match &v4 {
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
            let mut v21: bool = match &v20 {
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
            let mut v41: Rc<UH2> = v41.clone();
            let mut v42: Rc<UH2> = derivative_27(v41.clone(), v1.clone());
            let mut v43: Rc<UH2> = make_star_26(v41.clone());
            make_cat_24(v42.clone(), v43.clone())
        }
    }
}
fn canonical_derivative_19(mut v0: Rc<UH2>, mut v1: US3) -> Rc<UH2> {
    let mut v2: Rc<UH2> = normalize_20(v0.clone());
    let mut v3: Rc<UH2> = derivative_27(v2.clone(), v1.clone());
    normalize_20(v3.clone())
}
fn accepts_18(mut v0: Rc<UH2>, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v1 {
            UH3::UH3_InputCons(v6, v7) => {
                let mut v6: US3 = v6.clone();
                let mut v7: Rc<UH3> = v7.clone();
                let mut v8: Rc<UH2> = canonical_derivative_19(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH3::UH3_InputEmpty => {
                let mut v2: Rc<UH2> = normalize_20(v0.clone());
                let mut v3: US2 = nullable_28(v2.clone());
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
fn spiral_main() -> i32 {
    let mut v0: i32 = 200i32;
    let mut v1: i32 = 32i32;
    let mut v2: i32 = 16i32;
    let mut v3: US0 = US0::US0_BitZero;
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v3.clone()));
    let mut v5: US0 = US0::US0_BitOne;
    let mut v6: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v5.clone()));
    let mut v7: Rc<UH0> = Rc::new(UH0::UH0_RegexAlt(v4.clone(), v6.clone()));
    let mut v8: Rc<UH0> = Rc::new(UH0::UH0_RegexStar(v7.clone()));
    let mut v9: US0 = US0::US0_BitZero;
    let mut v10: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v9.clone()));
    let mut v11: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v8.clone(), v10.clone()));
    let mut v12: u64 = 1u64;
    let mut v13: i32 = 0i32;
    let mut v14: i32 = loop_0(v1, v11.clone(), v0, v12, v13);
    let mut v15: bool = v14 == 93i32;
    if v15 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-ends-with-zero-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v16: US0 = US0::US0_BitZero;
    let mut v17: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v16.clone()));
    let mut v18: US0 = US0::US0_BitZero;
    let mut v19: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v18.clone()));
    let mut v20: US0 = US0::US0_BitZero;
    let mut v21: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v20.clone()));
    let mut v22: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v19.clone(), v21.clone()));
    let mut v23: Rc<UH0> = Rc::new(UH0::UH0_RegexAlt(v17.clone(), v22.clone()));
    let mut v24: Rc<UH0> = Rc::new(UH0::UH0_RegexStar(v23.clone()));
    let mut v25: US0 = US0::US0_BitOne;
    let mut v26: Rc<UH0> = Rc::new(UH0::UH0_RegexChar(v25.clone()));
    let mut v27: Rc<UH0> = Rc::new(UH0::UH0_RegexCat(v24.clone(), v26.clone()));
    let mut v28: i32 = 1i32;
    let mut v29: i32 = 0i32;
    let mut v30: i32 = loop_14(v2, v27.clone(), v28, v29);
    let mut v31: bool = v30 == 16i32;
    if v31 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-compiled-zero-runs-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v32: US3 = US3::US3_TriA;
    let mut v33: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v32.clone()));
    let mut v34: US3 = US3::US3_TriB;
    let mut v35: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v34.clone()));
    let mut v36: Rc<UH2> = Rc::new(UH2::UH2_RegexAlt(v33.clone(), v35.clone()));
    let mut v37: Rc<UH2> = Rc::new(UH2::UH2_RegexStar(v36.clone()));
    let mut v38: US3 = US3::US3_TriC;
    let mut v39: Rc<UH2> = Rc::new(UH2::UH2_RegexChar(v38.clone()));
    let mut v40: Rc<UH2> = Rc::new(UH2::UH2_RegexCat(v37.clone(), v39.clone()));
    let mut v41: US3 = US3::US3_TriA;
    let mut v42: US3 = US3::US3_TriB;
    let mut v43: US3 = US3::US3_TriA;
    let mut v44: US3 = US3::US3_TriC;
    let mut v45: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_InputEmpty); } CASE.with(|case| case.clone()) };
    let mut v46: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v44.clone(), v45.clone()));
    let mut v47: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v43.clone(), v46.clone()));
    let mut v48: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v42.clone(), v47.clone()));
    let mut v49: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v41.clone(), v48.clone()));
    let mut v50: US3 = US3::US3_TriA;
    let mut v51: US3 = US3::US3_TriB;
    let mut v52: US3 = US3::US3_TriA;
    let mut v53: US3 = US3::US3_TriB;
    let mut v54: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_InputEmpty); } CASE.with(|case| case.clone()) };
    let mut v55: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v53.clone(), v54.clone()));
    let mut v56: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v52.clone(), v55.clone()));
    let mut v57: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v51.clone(), v56.clone()));
    let mut v58: Rc<UH3> = Rc::new(UH3::UH3_InputCons(v50.clone(), v57.clone()));
    let mut v59: i32 = 0i32;
    let mut v60: bool = run_17(v59, v49.clone());
    let mut v62: bool = if v60 {
        accepts_18(v40.clone(), v49.clone())
    } else {
        false
    };
    let mut v68: bool = if v62 {
        let mut v63: i32 = 0i32;
        let mut v64: bool = run_17(v63, v58.clone());
        if v64 {
            false
        } else {
            let mut v65: bool = accepts_18(v40.clone(), v58.clone());
            let mut v66: bool = v65 == false;
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
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
