#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1 => 1,
        }
    }
}
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(US0, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0 => 0,
            UH0::UH0_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH2 {
    UH2_0,
    UH2_1(US0, Rc<UH2>),
}
impl UH2 {
    fn tag(&self) -> i32 {
        match self {
            UH2::UH2_0 => 0,
            UH2::UH2_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH1 {
    UH1_0,
    UH1_1(Rc<UH2>, Rc<UH1>),
}
impl UH1 {
    fn tag(&self) -> i32 {
        match self {
            UH1::UH1_0 => 0,
            UH1::UH1_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US1 {
    US1_0,
    US1_1,
    US1_2,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_0 => 0,
            US1::US1_1 => 1,
            US1::US1_2 => 2,
        }
    }
}
#[derive(Clone)]
enum UH3 {
    UH3_0,
    UH3_1(US1, Rc<UH3>),
}
impl UH3 {
    fn tag(&self) -> i32 {
        match self {
            UH3::UH3_0 => 0,
            UH3::UH3_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH5 {
    UH5_0,
    UH5_1(US1, Rc<UH5>),
}
impl UH5 {
    fn tag(&self) -> i32 {
        match self {
            UH5::UH5_0 => 0,
            UH5::UH5_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH4 {
    UH4_0,
    UH4_1(Rc<UH5>, Rc<UH4>),
}
impl UH4 {
    fn tag(&self) -> i32 {
        match self {
            UH4::UH4_0 => 0,
            UH4::UH4_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US2 {
    US2_0,
    US2_1,
    US2_2,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_0 => 0,
            US2::US2_1 => 1,
            US2::US2_2 => 2,
        }
    }
}
#[derive(Clone)]
enum UH6 {
    UH6_0,
    UH6_1(US2, Rc<UH6>),
}
impl UH6 {
    fn tag(&self) -> i32 {
        match self {
            UH6::UH6_0 => 0,
            UH6::UH6_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum UH7 {
    UH7_0,
    UH7_1,
    UH7_2(US0),
    UH7_3(Rc<UH7>, Rc<UH7>),
    UH7_4(Rc<UH7>, Rc<UH7>),
    UH7_5(Rc<UH7>),
}
impl UH7 {
    fn tag(&self) -> i32 {
        match self {
            UH7::UH7_0 => 0,
            UH7::UH7_1 => 1,
            UH7::UH7_2(..) => 2,
            UH7::UH7_3(..) => 3,
            UH7::UH7_4(..) => 4,
            UH7::UH7_5(..) => 5,
        }
    }
}
#[derive(Clone)]
enum US3 {
    US3_0,
    US3_1,
    US3_2,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_0 => 0,
            US3::US3_1 => 1,
            US3::US3_2 => 2,
        }
    }
}
#[derive(Clone)]
enum US4 {
    US4_0,
    US4_1,
    US4_2,
}
impl US4 {
    fn tag(&self) -> i32 {
        match self {
            US4::US4_0 => 0,
            US4::US4_1 => 1,
            US4::US4_2 => 2,
        }
    }
}
#[derive(Clone)]
enum US5 {
    US5_0,
    US5_1,
}
impl US5 {
    fn tag(&self) -> i32 {
        match self {
            US5::US5_0 => 0,
            US5::US5_1 => 1,
        }
    }
}
#[derive(Clone)]
enum UH8 {
    UH8_0,
    UH8_1,
    UH8_2(US1),
    UH8_3(Rc<UH8>, Rc<UH8>),
    UH8_4(Rc<UH8>, Rc<UH8>),
    UH8_5(Rc<UH8>),
}
impl UH8 {
    fn tag(&self) -> i32 {
        match self {
            UH8::UH8_0 => 0,
            UH8::UH8_1 => 1,
            UH8::UH8_2(..) => 2,
            UH8::UH8_3(..) => 3,
            UH8::UH8_4(..) => 4,
            UH8::UH8_5(..) => 5,
        }
    }
}
fn method0(mut v0: Rc<UH0>) -> Rc<UH1> {
    match &*v0 {
        UH0::UH0_1(v2, v3) => { // SymbolListCons
            let mut v2: US0 = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: Rc<UH1> = method0(v3.clone());
            let mut v5: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH2> = Rc::new(UH2::UH2_1(v2.clone(), v5.clone()));
            Rc::new(UH1::UH1_1(v6.clone(), v4.clone()))
        }
        UH0::UH0_0 => { // SymbolListNil
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method2(mut v0: Rc<UH1>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v0 {
        UH1::UH1_1(v2, v3) => { // InputListCons
            let mut v2: Rc<UH2> = v2.clone();
            let mut v3: Rc<UH1> = v3.clone();
            let mut v4: Rc<UH1> = method2(v3.clone(), v1.clone());
            Rc::new(UH1::UH1_1(v2.clone(), v4.clone()))
        }
        UH1::UH1_0 => { // InputListNil
            v1.clone()
        }
    }
}
fn method3(mut v0: US0, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v1 {
        UH1::UH1_1(v3, v4) => { // InputListCons
            let mut v3: Rc<UH2> = v3.clone();
            let mut v4: Rc<UH1> = v4.clone();
            let mut v5: Rc<UH1> = method3(v0.clone(), v4.clone());
            let mut v6: Rc<UH2> = Rc::new(UH2::UH2_1(v0.clone(), v3.clone()));
            Rc::new(UH1::UH1_1(v6.clone(), v5.clone()))
        }
        UH1::UH1_0 => { // InputListNil
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method1(mut v0: Rc<UH0>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match &*v0 {
        UH0::UH0_1(v3, v4) => { // SymbolListCons
            let mut v3: US0 = v3.clone();
            let mut v4: Rc<UH0> = v4.clone();
            let mut v5: Rc<UH1> = method3(v3.clone(), v1.clone());
            let mut v6: Rc<UH1> = method1(v4.clone(), v1.clone());
            method2(v5.clone(), v6.clone())
        }
        UH0::UH0_0 => { // SymbolListNil
            { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method4(mut v0: Rc<UH3>) -> Rc<UH4> {
    match &*v0 {
        UH3::UH3_1(v2, v3) => { // SymbolListCons
            let mut v2: US1 = v2.clone();
            let mut v3: Rc<UH3> = v3.clone();
            let mut v4: Rc<UH4> = method4(v3.clone());
            let mut v5: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_0); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH5> = Rc::new(UH5::UH5_1(v2.clone(), v5.clone()));
            Rc::new(UH4::UH4_1(v6.clone(), v4.clone()))
        }
        UH3::UH3_0 => { // SymbolListNil
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method6(mut v0: Rc<UH4>, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v0 {
        UH4::UH4_1(v2, v3) => { // InputListCons
            let mut v2: Rc<UH5> = v2.clone();
            let mut v3: Rc<UH4> = v3.clone();
            let mut v4: Rc<UH4> = method6(v3.clone(), v1.clone());
            Rc::new(UH4::UH4_1(v2.clone(), v4.clone()))
        }
        UH4::UH4_0 => { // InputListNil
            v1.clone()
        }
    }
}
fn method7(mut v0: US1, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v1 {
        UH4::UH4_1(v3, v4) => { // InputListCons
            let mut v3: Rc<UH5> = v3.clone();
            let mut v4: Rc<UH4> = v4.clone();
            let mut v5: Rc<UH4> = method7(v0.clone(), v4.clone());
            let mut v6: Rc<UH5> = Rc::new(UH5::UH5_1(v0.clone(), v3.clone()));
            Rc::new(UH4::UH4_1(v6.clone(), v5.clone()))
        }
        UH4::UH4_0 => { // InputListNil
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method5(mut v0: Rc<UH3>, mut v1: Rc<UH4>) -> Rc<UH4> {
    match &*v0 {
        UH3::UH3_1(v3, v4) => { // SymbolListCons
            let mut v3: US1 = v3.clone();
            let mut v4: Rc<UH3> = v4.clone();
            let mut v5: Rc<UH4> = method7(v3.clone(), v1.clone());
            let mut v6: Rc<UH4> = method5(v4.clone(), v1.clone());
            method6(v5.clone(), v6.clone())
        }
        UH3::UH3_0 => { // SymbolListNil
            { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_0); } CASE.with(|case| case.clone()) }
        }
    }
}
fn method9(mut v0: i32, mut v1: Rc<UH2>) -> US3 {
    loop {
        match &*v1 {
            UH2::UH2_1(v6, v7) => { // InputCons
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH2> = v7.clone();
                let mut v11: US4 = match &v6 {
                    US0::US0_1 => { // BitOne
                        US4::US4_2
                    }
                    US0::US0_0 => { // BitZero
                        US4::US4_1
                    }
                };
                let mut v12: bool = match &v11 {
                    US4::US4_1 => { // SymbolSame
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
                        US0::US0_1 => { // BitOne
                            US4::US4_1
                        }
                        US0::US0_0 => { // BitZero
                            US4::US4_0
                        }
                    };
                    let mut v17: bool = match &v16 {
                        US4::US4_1 => { // SymbolSame
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
                    return US3::US3_2;
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
            UH2::UH2_0 => { // InputEmpty
                let mut v2: bool = v0 == 0i32;
                if v2 {
                    return US3::US3_0;
                } else {
                    return US3::US3_1;
                }
            }
        }
    }
}
fn method15(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> US4 {
    loop {
        match &*v0 {
            UH7::UH7_3(v53, v54) => { // RegexAlt
                let mut v53: Rc<UH7> = v53.clone();
                let mut v54: Rc<UH7> = v54.clone();
                match &*v1 {
                    UH7::UH7_3(v55, v56) => { // RegexAlt
                        let mut v55: Rc<UH7> = v55.clone();
                        let mut v56: Rc<UH7> = v56.clone();
                        let mut v57: US4 = method15(v53.clone(), v55.clone());
                        match &v57 {
                            US4::US4_1 => { // SymbolSame
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US4::US4_2;
                    }
                }
            }
            UH7::UH7_4(v28, v29) => { // RegexCat
                let mut v28: Rc<UH7> = v28.clone();
                let mut v29: Rc<UH7> = v29.clone();
                match &*v1 {
                    UH7::UH7_4(v34, v35) => { // RegexCat
                        let mut v34: Rc<UH7> = v34.clone();
                        let mut v35: Rc<UH7> = v35.clone();
                        let mut v36: US4 = method15(v28.clone(), v34.clone());
                        match &v36 {
                            US4::US4_1 => { // SymbolSame
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH7::UH7_2(v32) => { // RegexChar
                        let mut v32: US0 = v32.clone();
                        return US4::US4_2;
                    }
                    UH7::UH7_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH7::UH7_1 => { // RegexEpsilon
                        return US4::US4_2;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH7::UH7_2(v10) => { // RegexChar
                let mut v10: US0 = v10.clone();
                match &*v1 {
                    UH7::UH7_2(v13) => { // RegexChar
                        let mut v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_1 => { // BitOne
                                match &v13 {
                                    US0::US0_1 => { // BitOne
                                        return US4::US4_1;
                                    }
                                    US0::US0_0 => { // BitZero
                                        return US4::US4_2;
                                    }
                                }
                            }
                            US0::US0_0 => { // BitZero
                                match &v13 {
                                    US0::US0_1 => { // BitOne
                                        return US4::US4_0;
                                    }
                                    US0::US0_0 => { // BitZero
                                        return US4::US4_1;
                                    }
                                }
                            }
                        }
                    }
                    UH7::UH7_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH7::UH7_1 => { // RegexEpsilon
                        return US4::US4_2;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH7::UH7_0 => { // RegexEmpty
                match &*v1 {
                    UH7::UH7_0 => { // RegexEmpty
                        return US4::US4_1;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH7::UH7_1 => { // RegexEpsilon
                match &*v1 {
                    UH7::UH7_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH7::UH7_1 => { // RegexEpsilon
                        return US4::US4_1;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH7::UH7_5(v44) => { // RegexStar
                let mut v44: Rc<UH7> = v44.clone();
                match &*v1 {
                    UH7::UH7_3(v45, v46) => { // RegexAlt
                        let mut v45: Rc<UH7> = v45.clone();
                        let mut v46: Rc<UH7> = v46.clone();
                        return US4::US4_0;
                    }
                    UH7::UH7_5(v48) => { // RegexStar
                        let mut v48: Rc<UH7> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US4::US4_2;
                    }
                }
            }
        }
    }
}
fn method14(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    match &*v1 {
        UH7::UH7_3(v2, v3) => { // RegexAlt
            let mut v2: Rc<UH7> = v2.clone();
            let mut v3: Rc<UH7> = v3.clone();
            let mut v4: US4 = method15(v0.clone(), v2.clone());
            match &v4 {
                US4::US4_2 => { // SymbolGreater
                    let mut v6: Rc<UH7> = method14(v0.clone(), v3.clone());
                    Rc::new(UH7::UH7_3(v2.clone(), v6.clone()))
                }
                US4::US4_0 => { // SymbolLess
                    Rc::new(UH7::UH7_3(v0.clone(), v1.clone()))
                }
                US4::US4_1 => { // SymbolSame
                    v1.clone()
                }
            }
        }
        UH7::UH7_0 => { // RegexEmpty
            v0.clone()
        }
        _ => {
            let mut v11: US4 = method15(v0.clone(), v1.clone());
            match &v11 {
                US4::US4_2 => { // SymbolGreater
                    Rc::new(UH7::UH7_3(v1.clone(), v0.clone()))
                }
                US4::US4_0 => { // SymbolLess
                    Rc::new(UH7::UH7_3(v0.clone(), v1.clone()))
                }
                US4::US4_1 => { // SymbolSame
                    v1.clone()
                }
            }
        }
    }
}
fn method13(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    loop {
        match &*v0 {
            UH7::UH7_3(v2, v3) => { // RegexAlt
                let mut v2: Rc<UH7> = v2.clone();
                let mut v3: Rc<UH7> = v3.clone();
                let mut v4: Rc<UH7> = method14(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH7::UH7_0 => { // RegexEmpty
                return v1.clone();
            }
            _ => {
                return method14(v0.clone(), v1.clone());
            }
        }
    }
}
fn method17(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> bool {
    loop {
        match &*v0 {
            UH7::UH7_3(v18, v19) => { // RegexAlt
                let mut v18: Rc<UH7> = v18.clone();
                let mut v19: Rc<UH7> = v19.clone();
                match &*v1 {
                    UH7::UH7_3(v20, v21) => { // RegexAlt
                        let mut v20: Rc<UH7> = v20.clone();
                        let mut v21: Rc<UH7> = v21.clone();
                        let mut v22: bool = method17(v18.clone(), v20.clone());
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
            UH7::UH7_4(v26, v27) => { // RegexCat
                let mut v26: Rc<UH7> = v26.clone();
                let mut v27: Rc<UH7> = v27.clone();
                match &*v1 {
                    UH7::UH7_4(v28, v29) => { // RegexCat
                        let mut v28: Rc<UH7> = v28.clone();
                        let mut v29: Rc<UH7> = v29.clone();
                        let mut v30: bool = method17(v26.clone(), v28.clone());
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
            UH7::UH7_2(v4) => { // RegexChar
                let mut v4: US0 = v4.clone();
                match &*v1 {
                    UH7::UH7_2(v5) => { // RegexChar
                        let mut v5: US0 = v5.clone();
                        let mut v15: US4 = match &v4 {
                            US0::US0_1 => { // BitOne
                                match &v5 {
                                    US0::US0_1 => { // BitOne
                                        US4::US4_1
                                    }
                                    US0::US0_0 => { // BitZero
                                        US4::US4_2
                                    }
                                }
                            }
                            US0::US0_0 => { // BitZero
                                match &v5 {
                                    US0::US0_1 => { // BitOne
                                        US4::US4_0
                                    }
                                    US0::US0_0 => { // BitZero
                                        US4::US4_1
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US4::US4_1 => { // SymbolSame
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
            UH7::UH7_0 => { // RegexEmpty
                match &*v1 {
                    UH7::UH7_0 => { // RegexEmpty
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH7::UH7_1 => { // RegexEpsilon
                match &*v1 {
                    UH7::UH7_1 => { // RegexEpsilon
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH7::UH7_5(v34) => { // RegexStar
                let mut v34: Rc<UH7> = v34.clone();
                match &*v1 {
                    UH7::UH7_5(v35) => { // RegexStar
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
fn method16(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH7::UH7_0 => { // RegexEmpty
                    { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH7::UH7_1 => { // RegexEpsilon
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH7::UH7_1 => { // RegexEpsilon
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH7::UH7_4(v12, v13) => { // RegexCat
                                            let mut v12: Rc<UH7> = v12.clone();
                                            let mut v13: Rc<UH7> = v13.clone();
                                            let mut v14: Rc<UH7> = method16(v13.clone(), v1.clone());
                                            Rc::new(UH7::UH7_4(v12.clone(), v14.clone()))
                                        }
                                        UH7::UH7_5(v4) => { // RegexStar
                                            let mut v4: Rc<UH7> = v4.clone();
                                            match &*v1 {
                                                UH7::UH7_5(v5) => { // RegexStar
                                                    let mut v5: Rc<UH7> = v5.clone();
                                                    let mut v6: bool = method17(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH7::UH7_5(v4.clone()))
                                                    } else {
                                                        Rc::new(UH7::UH7_4(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH7::UH7_4(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH7::UH7_4(v0.clone(), v1.clone()))
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
fn method18(mut v0: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_1); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_1); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_5(v3) => { // RegexStar
            let mut v3: Rc<UH7> = v3.clone();
            Rc::new(UH7::UH7_5(v3.clone()))
        }
        _ => {
            Rc::new(UH7::UH7_5(v0.clone()))
        }
    }
}
fn method12(mut v0: Rc<UH7>) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_3(v5, v6) => { // RegexAlt
            let mut v5: Rc<UH7> = v5.clone();
            let mut v6: Rc<UH7> = v6.clone();
            let mut v7: Rc<UH7> = method12(v5.clone());
            let mut v8: Rc<UH7> = method12(v6.clone());
            method13(v7.clone(), v8.clone())
        }
        UH7::UH7_4(v10, v11) => { // RegexCat
            let mut v10: Rc<UH7> = v10.clone();
            let mut v11: Rc<UH7> = v11.clone();
            let mut v12: Rc<UH7> = method12(v10.clone());
            let mut v13: Rc<UH7> = method12(v11.clone());
            method16(v12.clone(), v13.clone())
        }
        UH7::UH7_2(v3) => { // RegexChar
            let mut v3: US0 = v3.clone();
            Rc::new(UH7::UH7_2(v3.clone()))
        }
        UH7::UH7_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_1); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_5(v15) => { // RegexStar
            let mut v15: Rc<UH7> = v15.clone();
            let mut v16: Rc<UH7> = method12(v15.clone());
            method18(v16.clone())
        }
    }
}
fn method20(mut v0: Rc<UH7>) -> US5 {
    match &*v0 {
        UH7::UH7_3(v5, v6) => { // RegexAlt
            let mut v5: Rc<UH7> = v5.clone();
            let mut v6: Rc<UH7> = v6.clone();
            let mut v7: US5 = method20(v5.clone());
            let mut v8: US5 = method20(v6.clone());
            match &v7 {
                US5::US5_0 => { // Nullable
                    US5::US5_0
                }
                _ => {
                    match &v8 {
                        US5::US5_0 => { // Nullable
                            US5::US5_0
                        }
                        _ => {
                            match &v7 {
                                US5::US5_1 => { // NonNullable
                                    match &v8 {
                                        US5::US5_1 => { // NonNullable
                                            US5::US5_1
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
        UH7::UH7_4(v16, v17) => { // RegexCat
            let mut v16: Rc<UH7> = v16.clone();
            let mut v17: Rc<UH7> = v17.clone();
            let mut v18: US5 = method20(v16.clone());
            let mut v19: US5 = method20(v17.clone());
            match &v18 {
                US5::US5_0 => { // Nullable
                    match &v19 {
                        US5::US5_0 => { // Nullable
                            US5::US5_0
                        }
                        _ => {
                            US5::US5_1
                        }
                    }
                }
                _ => {
                    US5::US5_1
                }
            }
        }
        UH7::UH7_2(v3) => { // RegexChar
            let mut v3: US0 = v3.clone();
            US5::US5_1
        }
        UH7::UH7_0 => { // RegexEmpty
            US5::US5_1
        }
        UH7::UH7_1 => { // RegexEpsilon
            US5::US5_0
        }
        UH7::UH7_5(v25) => { // RegexStar
            let mut v25: Rc<UH7> = v25.clone();
            US5::US5_0
        }
    }
}
fn method19(mut v0: Rc<UH7>, mut v1: US0) -> Rc<UH7> {
    match &*v0 {
        UH7::UH7_3(v19, v20) => { // RegexAlt
            let mut v19: Rc<UH7> = v19.clone();
            let mut v20: Rc<UH7> = v20.clone();
            let mut v21: Rc<UH7> = method19(v19.clone(), v1.clone());
            let mut v22: Rc<UH7> = method19(v20.clone(), v1.clone());
            method13(v21.clone(), v22.clone())
        }
        UH7::UH7_4(v24, v25) => { // RegexCat
            let mut v24: Rc<UH7> = v24.clone();
            let mut v25: Rc<UH7> = v25.clone();
            let mut v26: US5 = method20(v24.clone());
            match &v26 {
                US5::US5_1 => { // NonNullable
                    let mut v31: Rc<UH7> = method19(v24.clone(), v1.clone());
                    method16(v31.clone(), v25.clone())
                }
                US5::US5_0 => { // Nullable
                    let mut v27: Rc<UH7> = method19(v24.clone(), v1.clone());
                    let mut v28: Rc<UH7> = method16(v27.clone(), v25.clone());
                    let mut v29: Rc<UH7> = method19(v25.clone(), v1.clone());
                    method13(v28.clone(), v29.clone())
                }
            }
        }
        UH7::UH7_2(v4) => { // RegexChar
            let mut v4: US0 = v4.clone();
            let mut v14: US4 = match &v4 {
                US0::US0_1 => { // BitOne
                    match &v1 {
                        US0::US0_1 => { // BitOne
                            US4::US4_1
                        }
                        US0::US0_0 => { // BitZero
                            US4::US4_2
                        }
                    }
                }
                US0::US0_0 => { // BitZero
                    match &v1 {
                        US0::US0_1 => { // BitOne
                            US4::US4_0
                        }
                        US0::US0_0 => { // BitZero
                            US4::US4_1
                        }
                    }
                }
            };
            let mut v15: bool = match &v14 {
                US4::US4_1 => { // SymbolSame
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
                { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_1); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
            }
        }
        UH7::UH7_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_0); } CASE.with(|case| case.clone()) }
        }
        UH7::UH7_5(v35) => { // RegexStar
            let mut v35: Rc<UH7> = v35.clone();
            let mut v36: Rc<UH7> = method19(v35.clone(), v1.clone());
            let mut v37: Rc<UH7> = method18(v35.clone());
            method16(v36.clone(), v37.clone())
        }
    }
}
fn method11(mut v0: Rc<UH7>, mut v1: US0) -> Rc<UH7> {
    let mut v2: Rc<UH7> = method12(v0.clone());
    let mut v3: Rc<UH7> = method19(v2.clone(), v1.clone());
    method12(v3.clone())
}
fn method10(mut v0: Rc<UH7>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v1 {
            UH2::UH2_1(v6, v7) => { // InputCons
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH2> = v7.clone();
                let mut v8: Rc<UH7> = method11(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH2::UH2_0 => { // InputEmpty
                let mut v2: Rc<UH7> = method12(v0.clone());
                let mut v3: US5 = method20(v2.clone());
                match &v3 {
                    US5::US5_1 => { // NonNullable
                        return false;
                    }
                    US5::US5_0 => { // Nullable
                        return true;
                    }
                }
            }
        }
    }
}
fn method8(mut v0: Rc<UH7>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v2, v3) => { // InputListCons
                let mut v2: Rc<UH2> = v2.clone();
                let mut v3: Rc<UH1> = v3.clone();
                let mut v4: i32 = 1i32;
                let mut v5: US3 = method9(v4, v2.clone());
                let mut v11: bool = match &v5 {
                    US3::US3_0 => { // InventoryDfaAccepted
                        method10(v0.clone(), v2.clone())
                    }
                    US3::US3_2 => { // InventoryDfaInputOutsideInventory
                        false
                    }
                    US3::US3_1 => { // InventoryDfaRejected
                        let mut v7: bool = method10(v0.clone(), v2.clone());
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
            UH1::UH1_0 => { // InputListNil
                return true;
            }
        }
    }
}
fn method22(mut v0: i32, mut v1: Rc<UH5>) -> US3 {
    loop {
        match &*v1 {
            UH5::UH5_1(v8, v9) => { // InputCons
                let mut v8: US1 = v8.clone();
                let mut v9: Rc<UH5> = v9.clone();
                let mut v12: US4 = match &v8 {
                    US1::US1_0 => { // TriA
                        US4::US4_1
                    }
                    _ => {
                        US4::US4_2
                    }
                };
                let mut v13: bool = match &v12 {
                    US4::US4_1 => { // SymbolSame
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
                        US1::US1_0 => { // TriA
                            US4::US4_0
                        }
                        US1::US1_1 => { // TriB
                            US4::US4_1
                        }
                        US1::US1_2 => { // TriC
                            US4::US4_2
                        }
                    };
                    let mut v20: bool = match &v19 {
                        US4::US4_1 => { // SymbolSame
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
                            US1::US1_0 => { // TriA
                                US4::US4_0
                            }
                            US1::US1_1 => { // TriB
                                US4::US4_0
                            }
                            US1::US1_2 => { // TriC
                                US4::US4_1
                            }
                        };
                        let mut v27: bool = match &v26 {
                            US4::US4_1 => { // SymbolSame
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
                    return US3::US3_2;
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
            UH5::UH5_0 => { // InputEmpty
                let mut v2: bool = v0 == 0i32;
                let mut v4: bool = if v2 {
                    false
                } else {
                    let mut v3: bool = v0 == 1i32;
                    v3
                };
                if v4 {
                    return US3::US3_0;
                } else {
                    return US3::US3_1;
                }
            }
        }
    }
}
fn method28(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> US4 {
    loop {
        match &*v0 {
            UH8::UH8_3(v59, v60) => { // RegexAlt
                let mut v59: Rc<UH8> = v59.clone();
                let mut v60: Rc<UH8> = v60.clone();
                match &*v1 {
                    UH8::UH8_3(v61, v62) => { // RegexAlt
                        let mut v61: Rc<UH8> = v61.clone();
                        let mut v62: Rc<UH8> = v62.clone();
                        let mut v63: US4 = method28(v59.clone(), v61.clone());
                        match &v63 {
                            US4::US4_1 => { // SymbolSame
                                (v0, v1) = (v60.clone(), v62.clone());
                                continue;
                            }
                            _ => {
                                return v63.clone();
                            }
                        }
                    }
                    _ => {
                        return US4::US4_2;
                    }
                }
            }
            UH8::UH8_4(v34, v35) => { // RegexCat
                let mut v34: Rc<UH8> = v34.clone();
                let mut v35: Rc<UH8> = v35.clone();
                match &*v1 {
                    UH8::UH8_4(v40, v41) => { // RegexCat
                        let mut v40: Rc<UH8> = v40.clone();
                        let mut v41: Rc<UH8> = v41.clone();
                        let mut v42: US4 = method28(v34.clone(), v40.clone());
                        match &v42 {
                            US4::US4_1 => { // SymbolSame
                                (v0, v1) = (v35.clone(), v41.clone());
                                continue;
                            }
                            _ => {
                                return v42.clone();
                            }
                        }
                    }
                    UH8::UH8_2(v38) => { // RegexChar
                        let mut v38: US1 = v38.clone();
                        return US4::US4_2;
                    }
                    UH8::UH8_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH8::UH8_1 => { // RegexEpsilon
                        return US4::US4_2;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH8::UH8_2(v10) => { // RegexChar
                let mut v10: US1 = v10.clone();
                match &*v1 {
                    UH8::UH8_2(v13) => { // RegexChar
                        let mut v13: US1 = v13.clone();
                        match &v10 {
                            US1::US1_0 => { // TriA
                                match &v13 {
                                    US1::US1_0 => { // TriA
                                        return US4::US4_1;
                                    }
                                    _ => {
                                        return US4::US4_0;
                                    }
                                }
                            }
                            _ => {
                                match &v13 {
                                    US1::US1_0 => { // TriA
                                        return US4::US4_2;
                                    }
                                    _ => {
                                        match &v10 {
                                            US1::US1_1 => { // TriB
                                                match &v13 {
                                                    US1::US1_1 => { // TriB
                                                        return US4::US4_1;
                                                    }
                                                    US1::US1_2 => { // TriC
                                                        return US4::US4_0;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_2 => { // TriC
                                                match &v13 {
                                                    US1::US1_1 => { // TriB
                                                        return US4::US4_2;
                                                    }
                                                    US1::US1_2 => { // TriC
                                                        return US4::US4_1;
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
                    UH8::UH8_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH8::UH8_1 => { // RegexEpsilon
                        return US4::US4_2;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH8::UH8_0 => { // RegexEmpty
                match &*v1 {
                    UH8::UH8_0 => { // RegexEmpty
                        return US4::US4_1;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH8::UH8_1 => { // RegexEpsilon
                match &*v1 {
                    UH8::UH8_0 => { // RegexEmpty
                        return US4::US4_2;
                    }
                    UH8::UH8_1 => { // RegexEpsilon
                        return US4::US4_1;
                    }
                    _ => {
                        return US4::US4_0;
                    }
                }
            }
            UH8::UH8_5(v50) => { // RegexStar
                let mut v50: Rc<UH8> = v50.clone();
                match &*v1 {
                    UH8::UH8_3(v51, v52) => { // RegexAlt
                        let mut v51: Rc<UH8> = v51.clone();
                        let mut v52: Rc<UH8> = v52.clone();
                        return US4::US4_0;
                    }
                    UH8::UH8_5(v54) => { // RegexStar
                        let mut v54: Rc<UH8> = v54.clone();
                        (v0, v1) = (v50.clone(), v54.clone());
                        continue;
                    }
                    _ => {
                        return US4::US4_2;
                    }
                }
            }
        }
    }
}
fn method27(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    match &*v1 {
        UH8::UH8_3(v2, v3) => { // RegexAlt
            let mut v2: Rc<UH8> = v2.clone();
            let mut v3: Rc<UH8> = v3.clone();
            let mut v4: US4 = method28(v0.clone(), v2.clone());
            match &v4 {
                US4::US4_2 => { // SymbolGreater
                    let mut v6: Rc<UH8> = method27(v0.clone(), v3.clone());
                    Rc::new(UH8::UH8_3(v2.clone(), v6.clone()))
                }
                US4::US4_0 => { // SymbolLess
                    Rc::new(UH8::UH8_3(v0.clone(), v1.clone()))
                }
                US4::US4_1 => { // SymbolSame
                    v1.clone()
                }
            }
        }
        UH8::UH8_0 => { // RegexEmpty
            v0.clone()
        }
        _ => {
            let mut v11: US4 = method28(v0.clone(), v1.clone());
            match &v11 {
                US4::US4_2 => { // SymbolGreater
                    Rc::new(UH8::UH8_3(v1.clone(), v0.clone()))
                }
                US4::US4_0 => { // SymbolLess
                    Rc::new(UH8::UH8_3(v0.clone(), v1.clone()))
                }
                US4::US4_1 => { // SymbolSame
                    v1.clone()
                }
            }
        }
    }
}
fn method26(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    loop {
        match &*v0 {
            UH8::UH8_3(v2, v3) => { // RegexAlt
                let mut v2: Rc<UH8> = v2.clone();
                let mut v3: Rc<UH8> = v3.clone();
                let mut v4: Rc<UH8> = method27(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH8::UH8_0 => { // RegexEmpty
                return v1.clone();
            }
            _ => {
                return method27(v0.clone(), v1.clone());
            }
        }
    }
}
fn method30(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> bool {
    loop {
        match &*v0 {
            UH8::UH8_3(v24, v25) => { // RegexAlt
                let mut v24: Rc<UH8> = v24.clone();
                let mut v25: Rc<UH8> = v25.clone();
                match &*v1 {
                    UH8::UH8_3(v26, v27) => { // RegexAlt
                        let mut v26: Rc<UH8> = v26.clone();
                        let mut v27: Rc<UH8> = v27.clone();
                        let mut v28: bool = method30(v24.clone(), v26.clone());
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
            UH8::UH8_4(v32, v33) => { // RegexCat
                let mut v32: Rc<UH8> = v32.clone();
                let mut v33: Rc<UH8> = v33.clone();
                match &*v1 {
                    UH8::UH8_4(v34, v35) => { // RegexCat
                        let mut v34: Rc<UH8> = v34.clone();
                        let mut v35: Rc<UH8> = v35.clone();
                        let mut v36: bool = method30(v32.clone(), v34.clone());
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
            UH8::UH8_2(v4) => { // RegexChar
                let mut v4: US1 = v4.clone();
                match &*v1 {
                    UH8::UH8_2(v5) => { // RegexChar
                        let mut v5: US1 = v5.clone();
                        let mut v21: US4 = match &v4 {
                            US1::US1_0 => { // TriA
                                match &v5 {
                                    US1::US1_0 => { // TriA
                                        US4::US4_1
                                    }
                                    _ => {
                                        US4::US4_0
                                    }
                                }
                            }
                            _ => {
                                match &v5 {
                                    US1::US1_0 => { // TriA
                                        US4::US4_2
                                    }
                                    _ => {
                                        match &v4 {
                                            US1::US1_1 => { // TriB
                                                match &v5 {
                                                    US1::US1_1 => { // TriB
                                                        US4::US4_1
                                                    }
                                                    US1::US1_2 => { // TriC
                                                        US4::US4_0
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_2 => { // TriC
                                                match &v5 {
                                                    US1::US1_1 => { // TriB
                                                        US4::US4_2
                                                    }
                                                    US1::US1_2 => { // TriC
                                                        US4::US4_1
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
                            US4::US4_1 => { // SymbolSame
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
            UH8::UH8_0 => { // RegexEmpty
                match &*v1 {
                    UH8::UH8_0 => { // RegexEmpty
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH8::UH8_1 => { // RegexEpsilon
                match &*v1 {
                    UH8::UH8_1 => { // RegexEpsilon
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH8::UH8_5(v40) => { // RegexStar
                let mut v40: Rc<UH8> = v40.clone();
                match &*v1 {
                    UH8::UH8_5(v41) => { // RegexStar
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
fn method29(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH8::UH8_0 => { // RegexEmpty
                    { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH8::UH8_1 => { // RegexEpsilon
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH8::UH8_1 => { // RegexEpsilon
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH8::UH8_4(v12, v13) => { // RegexCat
                                            let mut v12: Rc<UH8> = v12.clone();
                                            let mut v13: Rc<UH8> = v13.clone();
                                            let mut v14: Rc<UH8> = method29(v13.clone(), v1.clone());
                                            Rc::new(UH8::UH8_4(v12.clone(), v14.clone()))
                                        }
                                        UH8::UH8_5(v4) => { // RegexStar
                                            let mut v4: Rc<UH8> = v4.clone();
                                            match &*v1 {
                                                UH8::UH8_5(v5) => { // RegexStar
                                                    let mut v5: Rc<UH8> = v5.clone();
                                                    let mut v6: bool = method30(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH8::UH8_5(v4.clone()))
                                                    } else {
                                                        Rc::new(UH8::UH8_4(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH8::UH8_4(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH8::UH8_4(v0.clone(), v1.clone()))
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
fn method31(mut v0: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_1); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_1); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_5(v3) => { // RegexStar
            let mut v3: Rc<UH8> = v3.clone();
            Rc::new(UH8::UH8_5(v3.clone()))
        }
        _ => {
            Rc::new(UH8::UH8_5(v0.clone()))
        }
    }
}
fn method25(mut v0: Rc<UH8>) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_3(v5, v6) => { // RegexAlt
            let mut v5: Rc<UH8> = v5.clone();
            let mut v6: Rc<UH8> = v6.clone();
            let mut v7: Rc<UH8> = method25(v5.clone());
            let mut v8: Rc<UH8> = method25(v6.clone());
            method26(v7.clone(), v8.clone())
        }
        UH8::UH8_4(v10, v11) => { // RegexCat
            let mut v10: Rc<UH8> = v10.clone();
            let mut v11: Rc<UH8> = v11.clone();
            let mut v12: Rc<UH8> = method25(v10.clone());
            let mut v13: Rc<UH8> = method25(v11.clone());
            method29(v12.clone(), v13.clone())
        }
        UH8::UH8_2(v3) => { // RegexChar
            let mut v3: US1 = v3.clone();
            Rc::new(UH8::UH8_2(v3.clone()))
        }
        UH8::UH8_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_1); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_5(v15) => { // RegexStar
            let mut v15: Rc<UH8> = v15.clone();
            let mut v16: Rc<UH8> = method25(v15.clone());
            method31(v16.clone())
        }
    }
}
fn method33(mut v0: Rc<UH8>) -> US5 {
    match &*v0 {
        UH8::UH8_3(v5, v6) => { // RegexAlt
            let mut v5: Rc<UH8> = v5.clone();
            let mut v6: Rc<UH8> = v6.clone();
            let mut v7: US5 = method33(v5.clone());
            let mut v8: US5 = method33(v6.clone());
            match &v7 {
                US5::US5_0 => { // Nullable
                    US5::US5_0
                }
                _ => {
                    match &v8 {
                        US5::US5_0 => { // Nullable
                            US5::US5_0
                        }
                        _ => {
                            match &v7 {
                                US5::US5_1 => { // NonNullable
                                    match &v8 {
                                        US5::US5_1 => { // NonNullable
                                            US5::US5_1
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
        UH8::UH8_4(v16, v17) => { // RegexCat
            let mut v16: Rc<UH8> = v16.clone();
            let mut v17: Rc<UH8> = v17.clone();
            let mut v18: US5 = method33(v16.clone());
            let mut v19: US5 = method33(v17.clone());
            match &v18 {
                US5::US5_0 => { // Nullable
                    match &v19 {
                        US5::US5_0 => { // Nullable
                            US5::US5_0
                        }
                        _ => {
                            US5::US5_1
                        }
                    }
                }
                _ => {
                    US5::US5_1
                }
            }
        }
        UH8::UH8_2(v3) => { // RegexChar
            let mut v3: US1 = v3.clone();
            US5::US5_1
        }
        UH8::UH8_0 => { // RegexEmpty
            US5::US5_1
        }
        UH8::UH8_1 => { // RegexEpsilon
            US5::US5_0
        }
        UH8::UH8_5(v25) => { // RegexStar
            let mut v25: Rc<UH8> = v25.clone();
            US5::US5_0
        }
    }
}
fn method32(mut v0: Rc<UH8>, mut v1: US1) -> Rc<UH8> {
    match &*v0 {
        UH8::UH8_3(v25, v26) => { // RegexAlt
            let mut v25: Rc<UH8> = v25.clone();
            let mut v26: Rc<UH8> = v26.clone();
            let mut v27: Rc<UH8> = method32(v25.clone(), v1.clone());
            let mut v28: Rc<UH8> = method32(v26.clone(), v1.clone());
            method26(v27.clone(), v28.clone())
        }
        UH8::UH8_4(v30, v31) => { // RegexCat
            let mut v30: Rc<UH8> = v30.clone();
            let mut v31: Rc<UH8> = v31.clone();
            let mut v32: US5 = method33(v30.clone());
            match &v32 {
                US5::US5_1 => { // NonNullable
                    let mut v37: Rc<UH8> = method32(v30.clone(), v1.clone());
                    method29(v37.clone(), v31.clone())
                }
                US5::US5_0 => { // Nullable
                    let mut v33: Rc<UH8> = method32(v30.clone(), v1.clone());
                    let mut v34: Rc<UH8> = method29(v33.clone(), v31.clone());
                    let mut v35: Rc<UH8> = method32(v31.clone(), v1.clone());
                    method26(v34.clone(), v35.clone())
                }
            }
        }
        UH8::UH8_2(v4) => { // RegexChar
            let mut v4: US1 = v4.clone();
            let mut v20: US4 = match &v4 {
                US1::US1_0 => { // TriA
                    match &v1 {
                        US1::US1_0 => { // TriA
                            US4::US4_1
                        }
                        _ => {
                            US4::US4_0
                        }
                    }
                }
                _ => {
                    match &v1 {
                        US1::US1_0 => { // TriA
                            US4::US4_2
                        }
                        _ => {
                            match &v4 {
                                US1::US1_1 => { // TriB
                                    match &v1 {
                                        US1::US1_1 => { // TriB
                                            US4::US4_1
                                        }
                                        US1::US1_2 => { // TriC
                                            US4::US4_0
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                US1::US1_2 => { // TriC
                                    match &v1 {
                                        US1::US1_1 => { // TriB
                                            US4::US4_2
                                        }
                                        US1::US1_2 => { // TriC
                                            US4::US4_1
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
                US4::US4_1 => { // SymbolSame
                    true
                }
                _ => {
                    false
                }
            };
            if v21 {
                { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_1); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
            }
        }
        UH8::UH8_0 => { // RegexEmpty
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_1 => { // RegexEpsilon
            { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_0); } CASE.with(|case| case.clone()) }
        }
        UH8::UH8_5(v41) => { // RegexStar
            let mut v41: Rc<UH8> = v41.clone();
            let mut v42: Rc<UH8> = method32(v41.clone(), v1.clone());
            let mut v43: Rc<UH8> = method31(v41.clone());
            method29(v42.clone(), v43.clone())
        }
    }
}
fn method24(mut v0: Rc<UH8>, mut v1: US1) -> Rc<UH8> {
    let mut v2: Rc<UH8> = method25(v0.clone());
    let mut v3: Rc<UH8> = method32(v2.clone(), v1.clone());
    method25(v3.clone())
}
fn method23(mut v0: Rc<UH8>, mut v1: Rc<UH5>) -> bool {
    loop {
        match &*v1 {
            UH5::UH5_1(v6, v7) => { // InputCons
                let mut v6: US1 = v6.clone();
                let mut v7: Rc<UH5> = v7.clone();
                let mut v8: Rc<UH8> = method24(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH5::UH5_0 => { // InputEmpty
                let mut v2: Rc<UH8> = method25(v0.clone());
                let mut v3: US5 = method33(v2.clone());
                match &v3 {
                    US5::US5_1 => { // NonNullable
                        return false;
                    }
                    US5::US5_0 => { // Nullable
                        return true;
                    }
                }
            }
        }
    }
}
fn method21(mut v0: Rc<UH8>, mut v1: Rc<UH4>) -> bool {
    loop {
        match &*v1 {
            UH4::UH4_1(v2, v3) => { // InputListCons
                let mut v2: Rc<UH5> = v2.clone();
                let mut v3: Rc<UH4> = v3.clone();
                let mut v4: i32 = 2i32;
                let mut v5: US3 = method22(v4, v2.clone());
                let mut v11: bool = match &v5 {
                    US3::US3_0 => { // InventoryDfaAccepted
                        method23(v0.clone(), v2.clone())
                    }
                    US3::US3_2 => { // InventoryDfaInputOutsideInventory
                        false
                    }
                    US3::US3_1 => { // InventoryDfaRejected
                        let mut v7: bool = method23(v0.clone(), v2.clone());
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
            UH4::UH4_0 => { // InputListNil
                return true;
            }
        }
    }
}
fn method34(mut v0: i32, mut v1: Rc<UH6>) -> US3 {
    loop {
        match &*v1 {
            UH6::UH6_1(v7, v8) => { // InputCons
                let mut v7: US2 = v7.clone();
                let mut v8: Rc<UH6> = v8.clone();
                let mut v11: US4 = match &v7 {
                    US2::US2_0 => { // ModelA
                        US4::US4_1
                    }
                    _ => {
                        US4::US4_2
                    }
                };
                let mut v12: bool = match &v11 {
                    US4::US4_1 => { // SymbolSame
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
                        US2::US2_0 => { // ModelA
                            US4::US4_0
                        }
                        US2::US2_1 => { // ModelB
                            US4::US4_1
                        }
                        US2::US2_2 => { // ModelC
                            US4::US4_2
                        }
                    };
                    let mut v19: bool = match &v18 {
                        US4::US4_1 => { // SymbolSame
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
                    return US3::US3_2;
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
            UH6::UH6_0 => { // InputEmpty
                let mut v2: bool = v0 == 0i32;
                let mut v3: bool = v2 == false;
                if v3 {
                    return US3::US3_0;
                } else {
                    return US3::US3_1;
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: US0 = US0::US0_0;
    let mut v1: US0 = US0::US0_1;
    let mut v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v2.clone()));
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_1(v0.clone(), v3.clone()));
    let mut v5: Rc<UH1> = method0(v4.clone());
    let mut v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH1> = Rc::new(UH1::UH1_1(v6.clone(), v5.clone()));
    let mut v8: US0 = US0::US0_0;
    let mut v9: US0 = US0::US0_1;
    let mut v10: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v11: Rc<UH0> = Rc::new(UH0::UH0_1(v9.clone(), v10.clone()));
    let mut v12: Rc<UH0> = Rc::new(UH0::UH0_1(v8.clone(), v11.clone()));
    let mut v13: US0 = US0::US0_0;
    let mut v14: US0 = US0::US0_1;
    let mut v15: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v16: Rc<UH0> = Rc::new(UH0::UH0_1(v14.clone(), v15.clone()));
    let mut v17: Rc<UH0> = Rc::new(UH0::UH0_1(v13.clone(), v16.clone()));
    let mut v18: Rc<UH1> = method0(v17.clone());
    let mut v19: Rc<UH1> = method1(v12.clone(), v18.clone());
    let mut v20: Rc<UH1> = method2(v7.clone(), v19.clone());
    let mut v21: US1 = US1::US1_0;
    let mut v22: US1 = US1::US1_1;
    let mut v23: US1 = US1::US1_2;
    let mut v24: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) };
    let mut v25: Rc<UH3> = Rc::new(UH3::UH3_1(v23.clone(), v24.clone()));
    let mut v26: Rc<UH3> = Rc::new(UH3::UH3_1(v22.clone(), v25.clone()));
    let mut v27: Rc<UH3> = Rc::new(UH3::UH3_1(v21.clone(), v26.clone()));
    let mut v28: Rc<UH4> = method4(v27.clone());
    let mut v29: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_0); } CASE.with(|case| case.clone()) };
    let mut v30: Rc<UH4> = Rc::new(UH4::UH4_1(v29.clone(), v28.clone()));
    let mut v31: US1 = US1::US1_0;
    let mut v32: US1 = US1::US1_1;
    let mut v33: US1 = US1::US1_2;
    let mut v34: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) };
    let mut v35: Rc<UH3> = Rc::new(UH3::UH3_1(v33.clone(), v34.clone()));
    let mut v36: Rc<UH3> = Rc::new(UH3::UH3_1(v32.clone(), v35.clone()));
    let mut v37: Rc<UH3> = Rc::new(UH3::UH3_1(v31.clone(), v36.clone()));
    let mut v38: US1 = US1::US1_0;
    let mut v39: US1 = US1::US1_1;
    let mut v40: US1 = US1::US1_2;
    let mut v41: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) };
    let mut v42: Rc<UH3> = Rc::new(UH3::UH3_1(v40.clone(), v41.clone()));
    let mut v43: Rc<UH3> = Rc::new(UH3::UH3_1(v39.clone(), v42.clone()));
    let mut v44: Rc<UH3> = Rc::new(UH3::UH3_1(v38.clone(), v43.clone()));
    let mut v45: Rc<UH4> = method4(v44.clone());
    let mut v46: Rc<UH4> = method5(v37.clone(), v45.clone());
    let mut v47: Rc<UH4> = method6(v30.clone(), v46.clone());
    let mut v48: US2 = US2::US2_2;
    let mut v49: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_0); } CASE.with(|case| case.clone()) };
    let mut v50: Rc<UH6> = Rc::new(UH6::UH6_1(v48.clone(), v49.clone()));
    let mut v51: US0 = US0::US0_0;
    let mut v52: Rc<UH7> = Rc::new(UH7::UH7_2(v51.clone()));
    let mut v53: US0 = US0::US0_1;
    let mut v54: Rc<UH7> = Rc::new(UH7::UH7_2(v53.clone()));
    let mut v55: Rc<UH7> = Rc::new(UH7::UH7_3(v52.clone(), v54.clone()));
    let mut v56: Rc<UH7> = Rc::new(UH7::UH7_5(v55.clone()));
    let mut v57: US0 = US0::US0_0;
    let mut v58: Rc<UH7> = Rc::new(UH7::UH7_2(v57.clone()));
    let mut v59: Rc<UH7> = Rc::new(UH7::UH7_4(v56.clone(), v58.clone()));
    let mut v60: bool = method8(v59.clone(), v20.clone());
    let mut v75: bool = if v60 {
        let mut v61: US1 = US1::US1_0;
        let mut v62: Rc<UH8> = Rc::new(UH8::UH8_2(v61.clone()));
        let mut v63: US1 = US1::US1_1;
        let mut v64: Rc<UH8> = Rc::new(UH8::UH8_2(v63.clone()));
        let mut v65: Rc<UH8> = Rc::new(UH8::UH8_3(v62.clone(), v64.clone()));
        let mut v66: Rc<UH8> = Rc::new(UH8::UH8_5(v65.clone()));
        let mut v67: US1 = US1::US1_2;
        let mut v68: Rc<UH8> = Rc::new(UH8::UH8_2(v67.clone()));
        let mut v69: Rc<UH8> = Rc::new(UH8::UH8_4(v66.clone(), v68.clone()));
        let mut v70: bool = method21(v69.clone(), v47.clone());
        if v70 {
            let mut v71: i32 = 1i32;
            let mut v72: US3 = method34(v71, v50.clone());
            match &v72 {
                US3::US3_2 => { // InventoryDfaInputOutsideInventory
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
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
