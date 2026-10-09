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
    UH0_SymbolListNil,
    UH0_SymbolListCons(US0, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_SymbolListNil => 0,
            UH0::UH0_SymbolListCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH2 {
    UH2_InputEmpty,
    UH2_InputCons(US0, Rc<UH2>),
}
impl UH2 {
    fn tag(&self) -> i32 {
        match self {
            UH2::UH2_InputEmpty => 0,
            UH2::UH2_InputCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH1 {
    UH1_InputListNil,
    UH1_InputListCons(Rc<UH2>, Rc<UH1>),
}
impl UH1 {
    fn tag(&self) -> i32 {
        match self {
            UH1::UH1_InputListNil => 0,
            UH1::UH1_InputListCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US1 {
    US1_TriA,
    US1_TriB,
    US1_TriC,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_TriA => 0,
            US1::US1_TriB => 1,
            US1::US1_TriC => 2,
        }
    }
}
#[derive(Clone)]
enum UH3 {
    UH3_SymbolListNil,
    UH3_SymbolListCons(US1, Rc<UH3>),
}
impl UH3 {
    fn tag(&self) -> i32 {
        match self {
            UH3::UH3_SymbolListNil => 0,
            UH3::UH3_SymbolListCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH5 {
    UH5_InputEmpty,
    UH5_InputCons(US1, Rc<UH5>),
}
impl UH5 {
    fn tag(&self) -> i32 {
        match self {
            UH5::UH5_InputEmpty => 0,
            UH5::UH5_InputCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH4 {
    UH4_InputListNil,
    UH4_InputListCons(Rc<UH5>, Rc<UH4>),
}
impl UH4 {
    fn tag(&self) -> i32 {
        match self {
            UH4::UH4_InputListNil => 0,
            UH4::UH4_InputListCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US2 {
    US2_ModelA,
    US2_ModelB,
    US2_ModelC,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_ModelA => 0,
            US2::US2_ModelB => 1,
            US2::US2_ModelC => 2,
        }
    }
}
#[derive(Clone)]
enum UH6 {
    UH6_InputEmpty,
    UH6_InputCons(US2, Rc<UH6>),
}
impl UH6 {
    fn tag(&self) -> i32 {
        match self {
            UH6::UH6_InputEmpty => 0,
            UH6::UH6_InputCons(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH7 {
    UH7_RegexEmpty,
    UH7_RegexEpsilon,
    UH7_RegexChar(US0),
    UH7_RegexAlt(Rc<UH7>, Rc<UH7>),
    UH7_RegexCat(Rc<UH7>, Rc<UH7>),
    UH7_RegexStar(Rc<UH7>),
}
impl UH7 {
    fn tag(&self) -> i32 {
        match self {
            UH7::UH7_RegexEmpty => 0,
            UH7::UH7_RegexEpsilon => 1,
            UH7::UH7_RegexChar(..) => 2,
            UH7::UH7_RegexAlt(..) => 3,
            UH7::UH7_RegexCat(..) => 4,
            UH7::UH7_RegexStar(..) => 5,
        }
    }
}
#[derive(Clone)]
enum US3 {
    US3_InventoryDfaAccepted,
    US3_InventoryDfaRejected,
    US3_InventoryDfaInputOutsideInventory,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_InventoryDfaAccepted => 0,
            US3::US3_InventoryDfaRejected => 1,
            US3::US3_InventoryDfaInputOutsideInventory => 2,
        }
    }
}
#[derive(Clone)]
enum US4 {
    US4_SymbolLess,
    US4_SymbolSame,
    US4_SymbolGreater,
}
impl US4 {
    fn tag(&self) -> i32 {
        match self {
            US4::US4_SymbolLess => 0,
            US4::US4_SymbolSame => 1,
            US4::US4_SymbolGreater => 2,
        }
    }
}
#[derive(Clone)]
enum US5 {
    US5_Nullable,
    US5_NonNullable,
}
impl US5 {
    fn tag(&self) -> i32 {
        match self {
            US5::US5_Nullable => 0,
            US5::US5_NonNullable => 1,
        }
    }
}
#[derive(Clone)]
enum UH8 {
    UH8_RegexEmpty,
    UH8_RegexEpsilon,
    UH8_RegexChar(US1),
    UH8_RegexAlt(Rc<UH8>, Rc<UH8>),
    UH8_RegexCat(Rc<UH8>, Rc<UH8>),
    UH8_RegexStar(Rc<UH8>),
}
impl UH8 {
    fn tag(&self) -> i32 {
        match self {
            UH8::UH8_RegexEmpty => 0,
            UH8::UH8_RegexEpsilon => 1,
            UH8::UH8_RegexChar(..) => 2,
            UH8::UH8_RegexAlt(..) => 3,
            UH8::UH8_RegexCat(..) => 4,
            UH8::UH8_RegexStar(..) => 5,
        }
    }
}
fn input_singletons_from_symbols_0(mut v0: Rc<UH0>) -> Rc<UH1> {
    match &*v0 {
        UH0::UH0_SymbolListCons(v2, v3) => {
            let mut v2: US0 = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: Rc<UH1> = input_singletons_from_symbols_0(v3.clone());
            let mut v5: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_InputEmpty); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH2> = Rc::new(UH2::UH2_InputCons(v2.clone(), v5.clone()));
            Rc::new(UH1::UH1_InputListCons(v6.clone(), v4.clone()))
        }
        UH0::UH0_SymbolListNil => {
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn input_list_append_2(mut v0: Rc<UH1>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v0 {
        UH1::UH1_InputListCons(v2, v3) => {
            let mut v2: Rc<UH2> = v2.clone();
            let mut v3: Rc<UH1> = v3.clone();
            let mut v4: Rc<UH1> = input_list_append_2(v3.clone(), v1.clone());
            Rc::new(UH1::UH1_InputListCons(v2.clone(), v4.clone()))
        }
        UH1::UH1_InputListNil => {
            v1.clone()
        }
    }
}
fn input_prepend_symbol_to_corpus_3(mut v0: US0, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v1 {
        UH1::UH1_InputListCons(v3, v4) => {
            let mut v3: Rc<UH2> = v3.clone();
            let mut v4: Rc<UH1> = v4.clone();
            let mut v5: Rc<UH1> = input_prepend_symbol_to_corpus_3(v0.clone(), v4.clone());
            let mut v6: Rc<UH2> = Rc::new(UH2::UH2_InputCons(v0.clone(), v3.clone()));
            Rc::new(UH1::UH1_InputListCons(v6.clone(), v5.clone()))
        }
        UH1::UH1_InputListNil => {
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn input_prepend_symbols_to_corpus_1(mut v0: Rc<UH0>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v0 {
        UH0::UH0_SymbolListCons(v3, v4) => {
            let mut v3: US0 = v3.clone();
            let mut v4: Rc<UH0> = v4.clone();
            let mut v5: Rc<UH1> = input_prepend_symbol_to_corpus_3(v3.clone(), v1.clone());
            let mut v6: Rc<UH1> = input_prepend_symbols_to_corpus_1(v4.clone(), v1.clone());
            input_list_append_2(v5.clone(), v6.clone())
        }
        UH0::UH0_SymbolListNil => {
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn input_singletons_from_symbols_4(mut v0: Rc<UH3>) -> Rc<UH4> {
    match &*v0 {
        UH3::UH3_SymbolListCons(v2, v3) => {
            let mut v2: US1 = v2.clone();
            let mut v3: Rc<UH3> = v3.clone();
            let mut v4: Rc<UH4> = input_singletons_from_symbols_4(v3.clone());
            let mut v5: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_InputEmpty); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH5> = Rc::new(UH5::UH5_InputCons(v2.clone(), v5.clone()));
            Rc::new(UH4::UH4_InputListCons(v6.clone(), v4.clone()))
        }
        UH3::UH3_SymbolListNil => {
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn input_list_append_6(mut v0: Rc<UH4>, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v0 {
        UH4::UH4_InputListCons(v2, v3) => {
            let mut v2: Rc<UH5> = v2.clone();
            let mut v3: Rc<UH4> = v3.clone();
            let mut v4: Rc<UH4> = input_list_append_6(v3.clone(), v1.clone());
            Rc::new(UH4::UH4_InputListCons(v2.clone(), v4.clone()))
        }
        UH4::UH4_InputListNil => {
            v1.clone()
        }
    }
}
fn input_prepend_symbol_to_corpus_7(mut v0: US1, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v1 {
        UH4::UH4_InputListCons(v3, v4) => {
            let mut v3: Rc<UH5> = v3.clone();
            let mut v4: Rc<UH4> = v4.clone();
            let mut v5: Rc<UH4> = input_prepend_symbol_to_corpus_7(v0.clone(), v4.clone());
            let mut v6: Rc<UH5> = Rc::new(UH5::UH5_InputCons(v0.clone(), v3.clone()));
            Rc::new(UH4::UH4_InputListCons(v6.clone(), v5.clone()))
        }
        UH4::UH4_InputListNil => {
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn input_prepend_symbols_to_corpus_5(mut v0: Rc<UH3>, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v0 {
        UH3::UH3_SymbolListCons(v3, v4) => {
            let mut v3: US1 = v3.clone();
            let mut v4: Rc<UH3> = v4.clone();
            let mut v5: Rc<UH4> = input_prepend_symbol_to_corpus_7(v3.clone(), v1.clone());
            let mut v6: Rc<UH4> = input_prepend_symbols_to_corpus_5(v4.clone(), v1.clone());
            input_list_append_6(v5.clone(), v6.clone())
        }
        UH3::UH3_SymbolListNil => {
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_InputListNil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn loop_9(mut v0: i32, mut v1: Rc<UH2>) -> US3 {
    loop {
        match &*v1 {
            UH2::UH2_InputCons(v6, v7) => {
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH2> = v7.clone();
                let mut v11: US4 = match &v6 {
                    US0::US0_BitOne => {
                        US4::US4_SymbolGreater
                    }
                    US0::US0_BitZero => {
                        US4::US4_SymbolSame
                    }
                };
                let mut v12: bool = match &v11 {
                    US4::US4_SymbolSame => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v19: i32 = if v12 {
                    0i32
                } else {
                    let mut v16: US4 = match &v6 {
                        US0::US0_BitOne => {
                            US4::US4_SymbolSame
                        }
                        US0::US0_BitZero => {
                            US4::US4_SymbolLess
                        }
                    };
                    let mut v17: bool = match &v16 {
                        US4::US4_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v17 {
                        1i32
                    } else {
                        -1i32
                    }
                };
                let mut v20: bool = v19 < 0i32;
                if v20 {
                    return US3::US3_InventoryDfaInputOutsideInventory;
                } else {
                    let mut v22: bool = v0 == 0i32;
                    let mut v27: i32 = if v22 {
                        let mut v23: bool = v19 == 0i32;
                        if v23 {
                            0i32
                        } else {
                            1i32
                        }
                    } else {
                        let mut v25: bool = v19 == 0i32;
                        if v25 {
                            0i32
                        } else {
                            1i32
                        }
                    };
                    (v0, v1) = (v27, v7.clone());
                    continue;
                }
            }
            UH2::UH2_InputEmpty => {
                let mut v2: bool = v0 == 0i32;
                if v2 {
                    return US3::US3_InventoryDfaAccepted;
                } else {
                    return US3::US3_InventoryDfaRejected;
                }
            }
        }
    }
}
fn regex_compare_15(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> US4 {
    loop {
        match &*v0 {
            UH7::UH7_RegexAlt(v53, v54) => {
                let mut v53: Rc<UH7> = v53.clone();
                let mut v54: Rc<UH7> = v54.clone();
                match &*v1 {
                    UH7::UH7_RegexAlt(v55, v56) => {
                        let mut v55: Rc<UH7> = v55.clone();
                        let mut v56: Rc<UH7> = v56.clone();
                        let mut v57: US4 = regex_compare_15(v53.clone(), v55.clone());
                        match &v57 {
                            US4::US4_SymbolSame => {
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US4::US4_SymbolGreater;
                    }
                }
            }
            UH7::UH7_RegexCat(v28, v29) => {
                let mut v28: Rc<UH7> = v28.clone();
                let mut v29: Rc<UH7> = v29.clone();
                match &*v1 {
                    UH7::UH7_RegexCat(v34, v35) => {
                        let mut v34: Rc<UH7> = v34.clone();
                        let mut v35: Rc<UH7> = v35.clone();
                        let mut v36: US4 = regex_compare_15(v28.clone(), v34.clone());
                        match &v36 {
                            US4::US4_SymbolSame => {
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH7::UH7_RegexChar(v32) => {
                        let mut v32: US0 = v32.clone();
                        return US4::US4_SymbolGreater;
                    }
                    UH7::UH7_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH7::UH7_RegexEpsilon => {
                        return US4::US4_SymbolGreater;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH7::UH7_RegexChar(v10) => {
                let mut v10: US0 = v10.clone();
                match &*v1 {
                    UH7::UH7_RegexChar(v13) => {
                        let mut v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_BitOne => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US4::US4_SymbolSame;
                                    }
                                    US0::US0_BitZero => {
                                        return US4::US4_SymbolGreater;
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v13 {
                                    US0::US0_BitOne => {
                                        return US4::US4_SymbolLess;
                                    }
                                    US0::US0_BitZero => {
                                        return US4::US4_SymbolSame;
                                    }
                                }
                            }
                        }
                    }
                    UH7::UH7_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH7::UH7_RegexEpsilon => {
                        return US4::US4_SymbolGreater;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH7::UH7_RegexEmpty => {
                match &*v1 {
                    UH7::UH7_RegexEmpty => {
                        return US4::US4_SymbolSame;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH7::UH7_RegexEpsilon => {
                match &*v1 {
                    UH7::UH7_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH7::UH7_RegexEpsilon => {
                        return US4::US4_SymbolSame;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH7::UH7_RegexStar(v44) => {
                let mut v44: Rc<UH7> = v44.clone();
                match &*v1 {
                    UH7::UH7_RegexAlt(v45, v46) => {
                        let mut v45: Rc<UH7> = v45.clone();
                        let mut v46: Rc<UH7> = v46.clone();
                        return US4::US4_SymbolLess;
                    }
                    UH7::UH7_RegexStar(v48) => {
                        let mut v48: Rc<UH7> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US4::US4_SymbolGreater;
                    }
                }
            }
        }
    }
}
fn alt_insert_sorted_14(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    match &*v1 {
        UH7::UH7_RegexAlt(v2, v3) => {
            let mut v2: Rc<UH7> = v2.clone();
            let mut v3: Rc<UH7> = v3.clone();
            let mut v4: US4 = regex_compare_15(v0.clone(), v2.clone());
            match &v4 {
                US4::US4_SymbolGreater => {
                    let mut v6: Rc<UH7> = alt_insert_sorted_14(v0.clone(), v3.clone());
                    Rc::new(UH7::UH7_RegexAlt(v2.clone(), v6.clone()))
                }
                US4::US4_SymbolLess => {
                    Rc::new(UH7::UH7_RegexAlt(v0.clone(), v1.clone()))
                }
                US4::US4_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH7::UH7_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let mut v11: US4 = regex_compare_15(v0.clone(), v1.clone());
            match &v11 {
                US4::US4_SymbolGreater => {
                    Rc::new(UH7::UH7_RegexAlt(v1.clone(), v0.clone()))
                }
                US4::US4_SymbolLess => {
                    Rc::new(UH7::UH7_RegexAlt(v0.clone(), v1.clone()))
                }
                US4::US4_SymbolSame => {
                    v1.clone()
                }
            }
        }
    }
}
fn make_alt_13(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    loop {
        match &*v0 {
            UH7::UH7_RegexAlt(v2, v3) => {
                let mut v2: Rc<UH7> = v2.clone();
                let mut v3: Rc<UH7> = v3.clone();
                let mut v4: Rc<UH7> = alt_insert_sorted_14(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH7::UH7_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_14(v0.clone(), v1.clone());
            }
        }
    }
}
fn regex_equal_17(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> bool {
    loop {
        match &*v0 {
            UH7::UH7_RegexAlt(v18, v19) => {
                let mut v18: Rc<UH7> = v18.clone();
                let mut v19: Rc<UH7> = v19.clone();
                match &*v1 {
                    UH7::UH7_RegexAlt(v20, v21) => {
                        let mut v20: Rc<UH7> = v20.clone();
                        let mut v21: Rc<UH7> = v21.clone();
                        let mut v22: bool = regex_equal_17(v18.clone(), v20.clone());
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
            UH7::UH7_RegexCat(v26, v27) => {
                let mut v26: Rc<UH7> = v26.clone();
                let mut v27: Rc<UH7> = v27.clone();
                match &*v1 {
                    UH7::UH7_RegexCat(v28, v29) => {
                        let mut v28: Rc<UH7> = v28.clone();
                        let mut v29: Rc<UH7> = v29.clone();
                        let mut v30: bool = regex_equal_17(v26.clone(), v28.clone());
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
            UH7::UH7_RegexChar(v4) => {
                let mut v4: US0 = v4.clone();
                match &*v1 {
                    UH7::UH7_RegexChar(v5) => {
                        let mut v5: US0 = v5.clone();
                        let mut v15: US4 = match &v4 {
                            US0::US0_BitOne => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US4::US4_SymbolSame
                                    }
                                    US0::US0_BitZero => {
                                        US4::US4_SymbolGreater
                                    }
                                }
                            }
                            US0::US0_BitZero => {
                                match &v5 {
                                    US0::US0_BitOne => {
                                        US4::US4_SymbolLess
                                    }
                                    US0::US0_BitZero => {
                                        US4::US4_SymbolSame
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US4::US4_SymbolSame => {
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
            UH7::UH7_RegexEmpty => {
                match &*v1 {
                    UH7::UH7_RegexEmpty => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH7::UH7_RegexEpsilon => {
                match &*v1 {
                    UH7::UH7_RegexEpsilon => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH7::UH7_RegexStar(v34) => {
                let mut v34: Rc<UH7> = v34.clone();
                match &*v1 {
                    UH7::UH7_RegexStar(v35) => {
                        let mut v35: Rc<UH7> = v35.clone();
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
fn make_cat_16(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH7::UH7_RegexEmpty => {
                    { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH7::UH7_RegexEpsilon => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH7::UH7_RegexEpsilon => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH7::UH7_RegexCat(v12, v13) => {
                                            let mut v12: Rc<UH7> = v12.clone();
                                            let mut v13: Rc<UH7> = v13.clone();
                                            let mut v14: Rc<UH7> = make_cat_16(v13.clone(), v1.clone());
                                            Rc::new(UH7::UH7_RegexCat(v12.clone(), v14.clone()))
                                        }
                                        UH7::UH7_RegexStar(v4) => {
                                            let mut v4: Rc<UH7> = v4.clone();
                                            match &*v1 {
                                                UH7::UH7_RegexStar(v5) => {
                                                    let mut v5: Rc<UH7> = v5.clone();
                                                    let mut v6: bool = regex_equal_17(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH7::UH7_RegexStar(v4.clone()))
                                                    } else {
                                                        Rc::new(UH7::UH7_RegexCat(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH7::UH7_RegexCat(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH7::UH7_RegexCat(v0.clone(), v1.clone()))
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
fn make_star_18(mut v0: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexStar(v3) => {
            let mut v3: Rc<UH7> = v3.clone();
            Rc::new(UH7::UH7_RegexStar(v3.clone()))
        }
        _ => {
            Rc::new(UH7::UH7_RegexStar(v0.clone()))
        }
    }
}
fn normalize_12(mut v0: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH7> = v5.clone();
            let mut v6: Rc<UH7> = v6.clone();
            let mut v7: Rc<UH7> = normalize_12(v5.clone());
            let mut v8: Rc<UH7> = normalize_12(v6.clone());
            make_alt_13(v7.clone(), v8.clone())
        }
        UH7::UH7_RegexCat(v10, v11) => {
            let mut v10: Rc<UH7> = v10.clone();
            let mut v11: Rc<UH7> = v11.clone();
            let mut v12: Rc<UH7> = normalize_12(v10.clone());
            let mut v13: Rc<UH7> = normalize_12(v11.clone());
            make_cat_16(v12.clone(), v13.clone())
        }
        UH7::UH7_RegexChar(v3) => {
            let mut v3: US0 = v3.clone();
            Rc::new(UH7::UH7_RegexChar(v3.clone()))
        }
        UH7::UH7_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexStar(v15) => {
            let mut v15: Rc<UH7> = v15.clone();
            let mut v16: Rc<UH7> = normalize_12(v15.clone());
            make_star_18(v16.clone())
        }
    }
}
fn nullable_20(mut v0: Rc<UH7>) -> US5 {
    match &*v0 {
        UH7::UH7_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH7> = v5.clone();
            let mut v6: Rc<UH7> = v6.clone();
            let mut v7: US5 = nullable_20(v5.clone());
            let mut v8: US5 = nullable_20(v6.clone());
            match &v7 {
                US5::US5_Nullable => {
                    US5::US5_Nullable
                }
                _ => {
                    match &v8 {
                        US5::US5_Nullable => {
                            US5::US5_Nullable
                        }
                        _ => {
                            match &v7 {
                                US5::US5_NonNullable => {
                                    match &v8 {
                                        US5::US5_NonNullable => {
                                            US5::US5_NonNullable
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
        UH7::UH7_RegexCat(v16, v17) => {
            let mut v16: Rc<UH7> = v16.clone();
            let mut v17: Rc<UH7> = v17.clone();
            let mut v18: US5 = nullable_20(v16.clone());
            let mut v19: US5 = nullable_20(v17.clone());
            match &v18 {
                US5::US5_Nullable => {
                    match &v19 {
                        US5::US5_Nullable => {
                            US5::US5_Nullable
                        }
                        _ => {
                            US5::US5_NonNullable
                        }
                    }
                }
                _ => {
                    US5::US5_NonNullable
                }
            }
        }
        UH7::UH7_RegexChar(v3) => {
            let mut v3: US0 = v3.clone();
            US5::US5_NonNullable
        }
        UH7::UH7_RegexEmpty => {
            US5::US5_NonNullable
        }
        UH7::UH7_RegexEpsilon => {
            US5::US5_Nullable
        }
        UH7::UH7_RegexStar(v25) => {
            let mut v25: Rc<UH7> = v25.clone();
            US5::US5_Nullable
        }
    }
}
fn derivative_19(mut v0: Rc<UH7>, mut v1: US0) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_RegexAlt(v19, v20) => {
            let mut v19: Rc<UH7> = v19.clone();
            let mut v20: Rc<UH7> = v20.clone();
            let mut v21: Rc<UH7> = derivative_19(v19.clone(), v1.clone());
            let mut v22: Rc<UH7> = derivative_19(v20.clone(), v1.clone());
            make_alt_13(v21.clone(), v22.clone())
        }
        UH7::UH7_RegexCat(v24, v25) => {
            let mut v24: Rc<UH7> = v24.clone();
            let mut v25: Rc<UH7> = v25.clone();
            let mut v26: US5 = nullable_20(v24.clone());
            match &v26 {
                US5::US5_NonNullable => {
                    let mut v31: Rc<UH7> = derivative_19(v24.clone(), v1.clone());
                    make_cat_16(v31.clone(), v25.clone())
                }
                US5::US5_Nullable => {
                    let mut v27: Rc<UH7> = derivative_19(v24.clone(), v1.clone());
                    let mut v28: Rc<UH7> = make_cat_16(v27.clone(), v25.clone());
                    let mut v29: Rc<UH7> = derivative_19(v25.clone(), v1.clone());
                    make_alt_13(v28.clone(), v29.clone())
                }
            }
        }
        UH7::UH7_RegexChar(v4) => {
            let mut v4: US0 = v4.clone();
            let mut v14: US4 = match &v4 {
                US0::US0_BitOne => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US4::US4_SymbolSame
                        }
                        US0::US0_BitZero => {
                            US4::US4_SymbolGreater
                        }
                    }
                }
                US0::US0_BitZero => {
                    match &v1 {
                        US0::US0_BitOne => {
                            US4::US4_SymbolLess
                        }
                        US0::US0_BitZero => {
                            US4::US4_SymbolSame
                        }
                    }
                }
            };
            let mut v15: bool = match &v14 {
                US4::US4_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
                { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEpsilon); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
            }
        }
        UH7::UH7_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_RegexStar(v35) => {
            let mut v35: Rc<UH7> = v35.clone();
            let mut v36: Rc<UH7> = derivative_19(v35.clone(), v1.clone());
            let mut v37: Rc<UH7> = make_star_18(v35.clone());
            make_cat_16(v36.clone(), v37.clone())
        }
    }
}
fn canonical_derivative_11(mut v0: Rc<UH7>, mut v1: US0) -> Rc<UH7> {
    let mut v2: Rc<UH7> = normalize_12(v0.clone());
    let mut v3: Rc<UH7> = derivative_19(v2.clone(), v1.clone());
    normalize_12(v3.clone())
}
fn accepts_10(mut v0: Rc<UH7>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v1 {
            UH2::UH2_InputCons(v6, v7) => {
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH2> = v7.clone();
                let mut v8: Rc<UH7> = canonical_derivative_11(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH2::UH2_InputEmpty => {
                let mut v2: Rc<UH7> = normalize_12(v0.clone());
                let mut v3: US5 = nullable_20(v2.clone());
                match &v3 {
                    US5::US5_NonNullable => {
                        return false;
                    }
                    US5::US5_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
fn loop_8(mut v0: Rc<UH7>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_InputListCons(v2, v3) => {
                let mut v2: Rc<UH2> = v2.clone();
                let mut v3: Rc<UH1> = v3.clone();
                let mut v4: i32 = 1i32;
                let mut v5: US3 = loop_9(v4, v2.clone());
                let mut v11: bool = match &v5 {
                    US3::US3_InventoryDfaAccepted => {
                        accepts_10(v0.clone(), v2.clone())
                    }
                    US3::US3_InventoryDfaInputOutsideInventory => {
                        false
                    }
                    US3::US3_InventoryDfaRejected => {
                        let mut v7: bool = accepts_10(v0.clone(), v2.clone());
                        let mut v8: bool = v7 == false;
                        v8
                    }
                };
                if v11 {
                    (v0, v1) = (v0.clone(), v3.clone());
                    continue;
                } else {
                    return false;
                }
            }
            UH1::UH1_InputListNil => {
                return true;
            }
        }
    }
}
fn loop_22(mut v0: i32, mut v1: Rc<UH5>) -> US3 {
    loop {
        match &*v1 {
            UH5::UH5_InputCons(v8, v9) => {
                let mut v8: US1 = v8.clone();
                let mut v9: Rc<UH5> = v9.clone();
                let mut v12: US4 = match &v8 {
                    US1::US1_TriA => {
                        US4::US4_SymbolSame
                    }
                    _ => {
                        US4::US4_SymbolGreater
                    }
                };
                let mut v13: bool = match &v12 {
                    US4::US4_SymbolSame => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v30: i32 = if v13 {
                    0i32
                } else {
                    let mut v19: US4 = match &v8 {
                        US1::US1_TriA => {
                            US4::US4_SymbolLess
                        }
                        US1::US1_TriB => {
                            US4::US4_SymbolSame
                        }
                        US1::US1_TriC => {
                            US4::US4_SymbolGreater
                        }
                    };
                    let mut v20: bool = match &v19 {
                        US4::US4_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v20 {
                        1i32
                    } else {
                        let mut v26: US4 = match &v8 {
                            US1::US1_TriA => {
                                US4::US4_SymbolLess
                            }
                            US1::US1_TriB => {
                                US4::US4_SymbolLess
                            }
                            US1::US1_TriC => {
                                US4::US4_SymbolSame
                            }
                        };
                        let mut v27: bool = match &v26 {
                            US4::US4_SymbolSame => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        if v27 {
                            2i32
                        } else {
                            -1i32
                        }
                    }
                };
                let mut v31: bool = v30 < 0i32;
                if v31 {
                    return US3::US3_InventoryDfaInputOutsideInventory;
                } else {
                    let mut v33: bool = v0 == 0i32;
                    let mut v46: i32 = if v33 {
                        let mut v34: bool = v30 == 0i32;
                        if v34 {
                            0i32
                        } else {
                            let mut v35: bool = v30 == 1i32;
                            0i32
                        }
                    } else {
                        let mut v37: bool = v0 == 1i32;
                        if v37 {
                            let mut v38: bool = v30 == 0i32;
                            if v38 {
                                0i32
                            } else {
                                let mut v39: bool = v30 == 1i32;
                                0i32
                            }
                        } else {
                            let mut v41: bool = v30 == 0i32;
                            if v41 {
                                2i32
                            } else {
                                let mut v42: bool = v30 == 1i32;
                                if v42 {
                                    2i32
                                } else {
                                    1i32
                                }
                            }
                        }
                    };
                    (v0, v1) = (v46, v9.clone());
                    continue;
                }
            }
            UH5::UH5_InputEmpty => {
                let mut v2: bool = v0 == 0i32;
                let mut v4: bool = if v2 {
                    false
                } else {
                    let mut v3: bool = v0 == 1i32;
                    v3
                };
                if v4 {
                    return US3::US3_InventoryDfaAccepted;
                } else {
                    return US3::US3_InventoryDfaRejected;
                }
            }
        }
    }
}
fn regex_compare_28(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> US4 {
    loop {
        match &*v0 {
            UH8::UH8_RegexAlt(v59, v60) => {
                let mut v59: Rc<UH8> = v59.clone();
                let mut v60: Rc<UH8> = v60.clone();
                match &*v1 {
                    UH8::UH8_RegexAlt(v61, v62) => {
                        let mut v61: Rc<UH8> = v61.clone();
                        let mut v62: Rc<UH8> = v62.clone();
                        let mut v63: US4 = regex_compare_28(v59.clone(), v61.clone());
                        match &v63 {
                            US4::US4_SymbolSame => {
                                (v0, v1) = (v60.clone(), v62.clone());
                                continue;
                            }
                            _ => {
                                return v63.clone();
                            }
                        }
                    }
                    _ => {
                        return US4::US4_SymbolGreater;
                    }
                }
            }
            UH8::UH8_RegexCat(v34, v35) => {
                let mut v34: Rc<UH8> = v34.clone();
                let mut v35: Rc<UH8> = v35.clone();
                match &*v1 {
                    UH8::UH8_RegexCat(v40, v41) => {
                        let mut v40: Rc<UH8> = v40.clone();
                        let mut v41: Rc<UH8> = v41.clone();
                        let mut v42: US4 = regex_compare_28(v34.clone(), v40.clone());
                        match &v42 {
                            US4::US4_SymbolSame => {
                                (v0, v1) = (v35.clone(), v41.clone());
                                continue;
                            }
                            _ => {
                                return v42.clone();
                            }
                        }
                    }
                    UH8::UH8_RegexChar(v38) => {
                        let mut v38: US1 = v38.clone();
                        return US4::US4_SymbolGreater;
                    }
                    UH8::UH8_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH8::UH8_RegexEpsilon => {
                        return US4::US4_SymbolGreater;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH8::UH8_RegexChar(v10) => {
                let mut v10: US1 = v10.clone();
                match &*v1 {
                    UH8::UH8_RegexChar(v13) => {
                        let mut v13: US1 = v13.clone();
                        match &v10 {
                            US1::US1_TriA => {
                                match &v13 {
                                    US1::US1_TriA => {
                                        return US4::US4_SymbolSame;
                                    }
                                    _ => {
                                        return US4::US4_SymbolLess;
                                    }
                                }
                            }
                            _ => {
                                match &v13 {
                                    US1::US1_TriA => {
                                        return US4::US4_SymbolGreater;
                                    }
                                    _ => {
                                        match &v10 {
                                            US1::US1_TriB => {
                                                match &v13 {
                                                    US1::US1_TriB => {
                                                        return US4::US4_SymbolSame;
                                                    }
                                                    US1::US1_TriC => {
                                                        return US4::US4_SymbolLess;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_TriC => {
                                                match &v13 {
                                                    US1::US1_TriB => {
                                                        return US4::US4_SymbolGreater;
                                                    }
                                                    US1::US1_TriC => {
                                                        return US4::US4_SymbolSame;
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
                    UH8::UH8_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH8::UH8_RegexEpsilon => {
                        return US4::US4_SymbolGreater;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH8::UH8_RegexEmpty => {
                match &*v1 {
                    UH8::UH8_RegexEmpty => {
                        return US4::US4_SymbolSame;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH8::UH8_RegexEpsilon => {
                match &*v1 {
                    UH8::UH8_RegexEmpty => {
                        return US4::US4_SymbolGreater;
                    }
                    UH8::UH8_RegexEpsilon => {
                        return US4::US4_SymbolSame;
                    }
                    _ => {
                        return US4::US4_SymbolLess;
                    }
                }
            }
            UH8::UH8_RegexStar(v50) => {
                let mut v50: Rc<UH8> = v50.clone();
                match &*v1 {
                    UH8::UH8_RegexAlt(v51, v52) => {
                        let mut v51: Rc<UH8> = v51.clone();
                        let mut v52: Rc<UH8> = v52.clone();
                        return US4::US4_SymbolLess;
                    }
                    UH8::UH8_RegexStar(v54) => {
                        let mut v54: Rc<UH8> = v54.clone();
                        (v0, v1) = (v50.clone(), v54.clone());
                        continue;
                    }
                    _ => {
                        return US4::US4_SymbolGreater;
                    }
                }
            }
        }
    }
}
fn alt_insert_sorted_27(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    match &*v1 {
        UH8::UH8_RegexAlt(v2, v3) => {
            let mut v2: Rc<UH8> = v2.clone();
            let mut v3: Rc<UH8> = v3.clone();
            let mut v4: US4 = regex_compare_28(v0.clone(), v2.clone());
            match &v4 {
                US4::US4_SymbolGreater => {
                    let mut v6: Rc<UH8> = alt_insert_sorted_27(v0.clone(), v3.clone());
                    Rc::new(UH8::UH8_RegexAlt(v2.clone(), v6.clone()))
                }
                US4::US4_SymbolLess => {
                    Rc::new(UH8::UH8_RegexAlt(v0.clone(), v1.clone()))
                }
                US4::US4_SymbolSame => {
                    v1.clone()
                }
            }
        }
        UH8::UH8_RegexEmpty => {
            v0.clone()
        }
        _ => {
            let mut v11: US4 = regex_compare_28(v0.clone(), v1.clone());
            match &v11 {
                US4::US4_SymbolGreater => {
                    Rc::new(UH8::UH8_RegexAlt(v1.clone(), v0.clone()))
                }
                US4::US4_SymbolLess => {
                    Rc::new(UH8::UH8_RegexAlt(v0.clone(), v1.clone()))
                }
                US4::US4_SymbolSame => {
                    v1.clone()
                }
            }
        }
    }
}
fn make_alt_26(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    loop {
        match &*v0 {
            UH8::UH8_RegexAlt(v2, v3) => {
                let mut v2: Rc<UH8> = v2.clone();
                let mut v3: Rc<UH8> = v3.clone();
                let mut v4: Rc<UH8> = alt_insert_sorted_27(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH8::UH8_RegexEmpty => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_27(v0.clone(), v1.clone());
            }
        }
    }
}
fn regex_equal_30(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> bool {
    loop {
        match &*v0 {
            UH8::UH8_RegexAlt(v24, v25) => {
                let mut v24: Rc<UH8> = v24.clone();
                let mut v25: Rc<UH8> = v25.clone();
                match &*v1 {
                    UH8::UH8_RegexAlt(v26, v27) => {
                        let mut v26: Rc<UH8> = v26.clone();
                        let mut v27: Rc<UH8> = v27.clone();
                        let mut v28: bool = regex_equal_30(v24.clone(), v26.clone());
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
            UH8::UH8_RegexCat(v32, v33) => {
                let mut v32: Rc<UH8> = v32.clone();
                let mut v33: Rc<UH8> = v33.clone();
                match &*v1 {
                    UH8::UH8_RegexCat(v34, v35) => {
                        let mut v34: Rc<UH8> = v34.clone();
                        let mut v35: Rc<UH8> = v35.clone();
                        let mut v36: bool = regex_equal_30(v32.clone(), v34.clone());
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
            UH8::UH8_RegexChar(v4) => {
                let mut v4: US1 = v4.clone();
                match &*v1 {
                    UH8::UH8_RegexChar(v5) => {
                        let mut v5: US1 = v5.clone();
                        let mut v21: US4 = match &v4 {
                            US1::US1_TriA => {
                                match &v5 {
                                    US1::US1_TriA => {
                                        US4::US4_SymbolSame
                                    }
                                    _ => {
                                        US4::US4_SymbolLess
                                    }
                                }
                            }
                            _ => {
                                match &v5 {
                                    US1::US1_TriA => {
                                        US4::US4_SymbolGreater
                                    }
                                    _ => {
                                        match &v4 {
                                            US1::US1_TriB => {
                                                match &v5 {
                                                    US1::US1_TriB => {
                                                        US4::US4_SymbolSame
                                                    }
                                                    US1::US1_TriC => {
                                                        US4::US4_SymbolLess
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_TriC => {
                                                match &v5 {
                                                    US1::US1_TriB => {
                                                        US4::US4_SymbolGreater
                                                    }
                                                    US1::US1_TriC => {
                                                        US4::US4_SymbolSame
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
                            US4::US4_SymbolSame => {
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
            UH8::UH8_RegexEmpty => {
                match &*v1 {
                    UH8::UH8_RegexEmpty => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH8::UH8_RegexEpsilon => {
                match &*v1 {
                    UH8::UH8_RegexEpsilon => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH8::UH8_RegexStar(v40) => {
                let mut v40: Rc<UH8> = v40.clone();
                match &*v1 {
                    UH8::UH8_RegexStar(v41) => {
                        let mut v41: Rc<UH8> = v41.clone();
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
fn make_cat_29(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH8::UH8_RegexEmpty => {
                    { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH8::UH8_RegexEpsilon => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH8::UH8_RegexEpsilon => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH8::UH8_RegexCat(v12, v13) => {
                                            let mut v12: Rc<UH8> = v12.clone();
                                            let mut v13: Rc<UH8> = v13.clone();
                                            let mut v14: Rc<UH8> = make_cat_29(v13.clone(), v1.clone());
                                            Rc::new(UH8::UH8_RegexCat(v12.clone(), v14.clone()))
                                        }
                                        UH8::UH8_RegexStar(v4) => {
                                            let mut v4: Rc<UH8> = v4.clone();
                                            match &*v1 {
                                                UH8::UH8_RegexStar(v5) => {
                                                    let mut v5: Rc<UH8> = v5.clone();
                                                    let mut v6: bool = regex_equal_30(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH8::UH8_RegexStar(v4.clone()))
                                                    } else {
                                                        Rc::new(UH8::UH8_RegexCat(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH8::UH8_RegexCat(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH8::UH8_RegexCat(v0.clone(), v1.clone()))
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
fn make_star_31(mut v0: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexStar(v3) => {
            let mut v3: Rc<UH8> = v3.clone();
            Rc::new(UH8::UH8_RegexStar(v3.clone()))
        }
        _ => {
            Rc::new(UH8::UH8_RegexStar(v0.clone()))
        }
    }
}
fn normalize_25(mut v0: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH8> = v5.clone();
            let mut v6: Rc<UH8> = v6.clone();
            let mut v7: Rc<UH8> = normalize_25(v5.clone());
            let mut v8: Rc<UH8> = normalize_25(v6.clone());
            make_alt_26(v7.clone(), v8.clone())
        }
        UH8::UH8_RegexCat(v10, v11) => {
            let mut v10: Rc<UH8> = v10.clone();
            let mut v11: Rc<UH8> = v11.clone();
            let mut v12: Rc<UH8> = normalize_25(v10.clone());
            let mut v13: Rc<UH8> = normalize_25(v11.clone());
            make_cat_29(v12.clone(), v13.clone())
        }
        UH8::UH8_RegexChar(v3) => {
            let mut v3: US1 = v3.clone();
            Rc::new(UH8::UH8_RegexChar(v3.clone()))
        }
        UH8::UH8_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEpsilon); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexStar(v15) => {
            let mut v15: Rc<UH8> = v15.clone();
            let mut v16: Rc<UH8> = normalize_25(v15.clone());
            make_star_31(v16.clone())
        }
    }
}
fn nullable_33(mut v0: Rc<UH8>) -> US5 {
    match &*v0 {
        UH8::UH8_RegexAlt(v5, v6) => {
            let mut v5: Rc<UH8> = v5.clone();
            let mut v6: Rc<UH8> = v6.clone();
            let mut v7: US5 = nullable_33(v5.clone());
            let mut v8: US5 = nullable_33(v6.clone());
            match &v7 {
                US5::US5_Nullable => {
                    US5::US5_Nullable
                }
                _ => {
                    match &v8 {
                        US5::US5_Nullable => {
                            US5::US5_Nullable
                        }
                        _ => {
                            match &v7 {
                                US5::US5_NonNullable => {
                                    match &v8 {
                                        US5::US5_NonNullable => {
                                            US5::US5_NonNullable
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
        UH8::UH8_RegexCat(v16, v17) => {
            let mut v16: Rc<UH8> = v16.clone();
            let mut v17: Rc<UH8> = v17.clone();
            let mut v18: US5 = nullable_33(v16.clone());
            let mut v19: US5 = nullable_33(v17.clone());
            match &v18 {
                US5::US5_Nullable => {
                    match &v19 {
                        US5::US5_Nullable => {
                            US5::US5_Nullable
                        }
                        _ => {
                            US5::US5_NonNullable
                        }
                    }
                }
                _ => {
                    US5::US5_NonNullable
                }
            }
        }
        UH8::UH8_RegexChar(v3) => {
            let mut v3: US1 = v3.clone();
            US5::US5_NonNullable
        }
        UH8::UH8_RegexEmpty => {
            US5::US5_NonNullable
        }
        UH8::UH8_RegexEpsilon => {
            US5::US5_Nullable
        }
        UH8::UH8_RegexStar(v25) => {
            let mut v25: Rc<UH8> = v25.clone();
            US5::US5_Nullable
        }
    }
}
fn derivative_32(mut v0: Rc<UH8>, mut v1: US1) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_RegexAlt(v25, v26) => {
            let mut v25: Rc<UH8> = v25.clone();
            let mut v26: Rc<UH8> = v26.clone();
            let mut v27: Rc<UH8> = derivative_32(v25.clone(), v1.clone());
            let mut v28: Rc<UH8> = derivative_32(v26.clone(), v1.clone());
            make_alt_26(v27.clone(), v28.clone())
        }
        UH8::UH8_RegexCat(v30, v31) => {
            let mut v30: Rc<UH8> = v30.clone();
            let mut v31: Rc<UH8> = v31.clone();
            let mut v32: US5 = nullable_33(v30.clone());
            match &v32 {
                US5::US5_NonNullable => {
                    let mut v37: Rc<UH8> = derivative_32(v30.clone(), v1.clone());
                    make_cat_29(v37.clone(), v31.clone())
                }
                US5::US5_Nullable => {
                    let mut v33: Rc<UH8> = derivative_32(v30.clone(), v1.clone());
                    let mut v34: Rc<UH8> = make_cat_29(v33.clone(), v31.clone());
                    let mut v35: Rc<UH8> = derivative_32(v31.clone(), v1.clone());
                    make_alt_26(v34.clone(), v35.clone())
                }
            }
        }
        UH8::UH8_RegexChar(v4) => {
            let mut v4: US1 = v4.clone();
            let mut v20: US4 = match &v4 {
                US1::US1_TriA => {
                    match &v1 {
                        US1::US1_TriA => {
                            US4::US4_SymbolSame
                        }
                        _ => {
                            US4::US4_SymbolLess
                        }
                    }
                }
                _ => {
                    match &v1 {
                        US1::US1_TriA => {
                            US4::US4_SymbolGreater
                        }
                        _ => {
                            match &v4 {
                                US1::US1_TriB => {
                                    match &v1 {
                                        US1::US1_TriB => {
                                            US4::US4_SymbolSame
                                        }
                                        US1::US1_TriC => {
                                            US4::US4_SymbolLess
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                US1::US1_TriC => {
                                    match &v1 {
                                        US1::US1_TriB => {
                                            US4::US4_SymbolGreater
                                        }
                                        US1::US1_TriC => {
                                            US4::US4_SymbolSame
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
                US4::US4_SymbolSame => {
                    true
                }
                _ => {
                    false
                }
            };
            if v21 {
                { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEpsilon); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
            }
        }
        UH8::UH8_RegexEmpty => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexEpsilon => {
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_RegexEmpty); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_RegexStar(v41) => {
            let mut v41: Rc<UH8> = v41.clone();
            let mut v42: Rc<UH8> = derivative_32(v41.clone(), v1.clone());
            let mut v43: Rc<UH8> = make_star_31(v41.clone());
            make_cat_29(v42.clone(), v43.clone())
        }
    }
}
fn canonical_derivative_24(mut v0: Rc<UH8>, mut v1: US1) -> Rc<UH8> {
    let mut v2: Rc<UH8> = normalize_25(v0.clone());
    let mut v3: Rc<UH8> = derivative_32(v2.clone(), v1.clone());
    normalize_25(v3.clone())
}
fn accepts_23(mut v0: Rc<UH8>, mut v1: Rc<UH5>) -> bool {
    loop {
        match &*v1 {
            UH5::UH5_InputCons(v6, v7) => {
                let mut v6: US1 = v6.clone();
                let mut v7: Rc<UH5> = v7.clone();
                let mut v8: Rc<UH8> = canonical_derivative_24(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH5::UH5_InputEmpty => {
                let mut v2: Rc<UH8> = normalize_25(v0.clone());
                let mut v3: US5 = nullable_33(v2.clone());
                match &v3 {
                    US5::US5_NonNullable => {
                        return false;
                    }
                    US5::US5_Nullable => {
                        return true;
                    }
                }
            }
        }
    }
}
fn loop_21(mut v0: Rc<UH8>, mut v1: Rc<UH4>) -> bool {
    loop {
        match &*v1 {
            UH4::UH4_InputListCons(v2, v3) => {
                let mut v2: Rc<UH5> = v2.clone();
                let mut v3: Rc<UH4> = v3.clone();
                let mut v4: i32 = 2i32;
                let mut v5: US3 = loop_22(v4, v2.clone());
                let mut v11: bool = match &v5 {
                    US3::US3_InventoryDfaAccepted => {
                        accepts_23(v0.clone(), v2.clone())
                    }
                    US3::US3_InventoryDfaInputOutsideInventory => {
                        false
                    }
                    US3::US3_InventoryDfaRejected => {
                        let mut v7: bool = accepts_23(v0.clone(), v2.clone());
                        let mut v8: bool = v7 == false;
                        v8
                    }
                };
                if v11 {
                    (v0, v1) = (v0.clone(), v3.clone());
                    continue;
                } else {
                    return false;
                }
            }
            UH4::UH4_InputListNil => {
                return true;
            }
        }
    }
}
fn loop_34(mut v0: i32, mut v1: Rc<UH6>) -> US3 {
    loop {
        match &*v1 {
            UH6::UH6_InputCons(v7, v8) => {
                let mut v7: US2 = v7.clone();
                let mut v8: Rc<UH6> = v8.clone();
                let mut v11: US4 = match &v7 {
                    US2::US2_ModelA => {
                        US4::US4_SymbolSame
                    }
                    _ => {
                        US4::US4_SymbolGreater
                    }
                };
                let mut v12: bool = match &v11 {
                    US4::US4_SymbolSame => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v21: i32 = if v12 {
                    0i32
                } else {
                    let mut v18: US4 = match &v7 {
                        US2::US2_ModelA => {
                            US4::US4_SymbolLess
                        }
                        US2::US2_ModelB => {
                            US4::US4_SymbolSame
                        }
                        US2::US2_ModelC => {
                            US4::US4_SymbolGreater
                        }
                    };
                    let mut v19: bool = match &v18 {
                        US4::US4_SymbolSame => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    if v19 {
                        1i32
                    } else {
                        -1i32
                    }
                };
                let mut v22: bool = v21 < 0i32;
                if v22 {
                    return US3::US3_InventoryDfaInputOutsideInventory;
                } else {
                    let mut v24: bool = v0 == 0i32;
                    let mut v28: i32 = if v24 {
                        let mut v25: bool = v21 == 0i32;
                        0i32
                    } else {
                        let mut v26: bool = v21 == 0i32;
                        if v26 {
                            1i32
                        } else {
                            0i32
                        }
                    };
                    (v0, v1) = (v28, v8.clone());
                    continue;
                }
            }
            UH6::UH6_InputEmpty => {
                let mut v2: bool = v0 == 0i32;
                let mut v3: bool = v2 == false;
                if v3 {
                    return US3::US3_InventoryDfaAccepted;
                } else {
                    return US3::US3_InventoryDfaRejected;
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: US0 = US0::US0_BitZero;
    let mut v1: US0 = US0::US0_BitOne;
    let mut v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v1.clone(), v2.clone()));
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v0.clone(), v3.clone()));
    let mut v5: Rc<UH1> = input_singletons_from_symbols_0(v4.clone());
    let mut v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_InputEmpty); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH1> = Rc::new(UH1::UH1_InputListCons(v6.clone(), v5.clone()));
    let mut v8: US0 = US0::US0_BitZero;
    let mut v9: US0 = US0::US0_BitOne;
    let mut v10: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v11: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v9.clone(), v10.clone()));
    let mut v12: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v8.clone(), v11.clone()));
    let mut v13: US0 = US0::US0_BitZero;
    let mut v14: US0 = US0::US0_BitOne;
    let mut v15: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v16: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v14.clone(), v15.clone()));
    let mut v17: Rc<UH0> = Rc::new(UH0::UH0_SymbolListCons(v13.clone(), v16.clone()));
    let mut v18: Rc<UH1> = input_singletons_from_symbols_0(v17.clone());
    let mut v19: Rc<UH1> = input_prepend_symbols_to_corpus_1(v12.clone(), v18.clone());
    let mut v20: Rc<UH1> = input_list_append_2(v7.clone(), v19.clone());
    let mut v21: US1 = US1::US1_TriA;
    let mut v22: US1 = US1::US1_TriB;
    let mut v23: US1 = US1::US1_TriC;
    let mut v24: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v25: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v23.clone(), v24.clone()));
    let mut v26: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v22.clone(), v25.clone()));
    let mut v27: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v21.clone(), v26.clone()));
    let mut v28: Rc<UH4> = input_singletons_from_symbols_4(v27.clone());
    let mut v29: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_InputEmpty); } CASE.with(|case| case.clone()) };
    let mut v30: Rc<UH4> = Rc::new(UH4::UH4_InputListCons(v29.clone(), v28.clone()));
    let mut v31: US1 = US1::US1_TriA;
    let mut v32: US1 = US1::US1_TriB;
    let mut v33: US1 = US1::US1_TriC;
    let mut v34: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v35: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v33.clone(), v34.clone()));
    let mut v36: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v32.clone(), v35.clone()));
    let mut v37: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v31.clone(), v36.clone()));
    let mut v38: US1 = US1::US1_TriA;
    let mut v39: US1 = US1::US1_TriB;
    let mut v40: US1 = US1::US1_TriC;
    let mut v41: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_SymbolListNil); } CASE.with(|case| case.clone()) };
    let mut v42: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v40.clone(), v41.clone()));
    let mut v43: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v39.clone(), v42.clone()));
    let mut v44: Rc<UH3> = Rc::new(UH3::UH3_SymbolListCons(v38.clone(), v43.clone()));
    let mut v45: Rc<UH4> = input_singletons_from_symbols_4(v44.clone());
    let mut v46: Rc<UH4> = input_prepend_symbols_to_corpus_5(v37.clone(), v45.clone());
    let mut v47: Rc<UH4> = input_list_append_6(v30.clone(), v46.clone());
    let mut v48: US2 = US2::US2_ModelC;
    let mut v49: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_InputEmpty); } CASE.with(|case| case.clone()) };
    let mut v50: Rc<UH6> = Rc::new(UH6::UH6_InputCons(v48.clone(), v49.clone()));
    let mut v51: US0 = US0::US0_BitZero;
    let mut v52: Rc<UH7> = Rc::new(UH7::UH7_RegexChar(v51.clone()));
    let mut v53: US0 = US0::US0_BitOne;
    let mut v54: Rc<UH7> = Rc::new(UH7::UH7_RegexChar(v53.clone()));
    let mut v55: Rc<UH7> = Rc::new(UH7::UH7_RegexAlt(v52.clone(), v54.clone()));
    let mut v56: Rc<UH7> = Rc::new(UH7::UH7_RegexStar(v55.clone()));
    let mut v57: US0 = US0::US0_BitZero;
    let mut v58: Rc<UH7> = Rc::new(UH7::UH7_RegexChar(v57.clone()));
    let mut v59: Rc<UH7> = Rc::new(UH7::UH7_RegexCat(v56.clone(), v58.clone()));
    let mut v60: bool = loop_8(v59.clone(), v20.clone());
    let mut v75: bool = if v60 {
        let mut v61: US1 = US1::US1_TriA;
        let mut v62: Rc<UH8> = Rc::new(UH8::UH8_RegexChar(v61.clone()));
        let mut v63: US1 = US1::US1_TriB;
        let mut v64: Rc<UH8> = Rc::new(UH8::UH8_RegexChar(v63.clone()));
        let mut v65: Rc<UH8> = Rc::new(UH8::UH8_RegexAlt(v62.clone(), v64.clone()));
        let mut v66: Rc<UH8> = Rc::new(UH8::UH8_RegexStar(v65.clone()));
        let mut v67: US1 = US1::US1_TriC;
        let mut v68: Rc<UH8> = Rc::new(UH8::UH8_RegexChar(v67.clone()));
        let mut v69: Rc<UH8> = Rc::new(UH8::UH8_RegexCat(v66.clone(), v68.clone()));
        let mut v70: bool = loop_21(v69.clone(), v47.clone());
        if v70 {
            let mut v71: i32 = 1i32;
            let mut v72: US3 = loop_34(v71, v50.clone());
            match &v72 {
                US3::US3_InventoryDfaInputOutsideInventory => {
                    true
                }
                _ => {
                    false
                }
            }
        } else {
            false
        }
    } else {
        false
    };
    if v75 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
