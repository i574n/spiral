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
    UH0_1,
    UH0_2(US0),
    UH0_3(Rc<UH0>, Rc<UH0>),
    UH0_4(Rc<UH0>, Rc<UH0>),
    UH0_5(Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0 => 0,
            UH0::UH0_1 => 1,
            UH0::UH0_2(..) => 2,
            UH0::UH0_3(..) => 3,
            UH0::UH0_4(..) => 4,
            UH0::UH0_5(..) => 5,
        }
    }
}
#[derive(Clone)]
enum UH1 {
    UH1_0,
    UH1_1(US0, Rc<UH1>),
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
enum US2 {
    US2_0,
    US2_1,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_0 => 0,
            US2::US2_1 => 1,
        }
    }
}
#[derive(Clone)]
enum UH2 {
    UH2_0,
    UH2_1(Rc<UH0>, Rc<UH2>),
}
impl UH2 {
    fn tag(&self) -> i32 {
        match self {
            UH2::UH2_0 => 0,
            UH2::UH2_1(..) => 1,
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
                let mut v11: US0 = US0::US0_0;
                v11.clone()
            } else {
                let mut v12: US0 = US0::US0_1;
                v12.clone()
            };
            let mut v14: Rc<UH1> = Rc::new(UH1::UH1_1(v13.clone(), v2.clone()));
            (v0, v1, v2) = (v6, v7, v14.clone());
            continue;
        } else {
            return (v2.clone(), v0);
        }
    }
}
fn regex_compare_7(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> US1 {
    loop {
        match &*v0 {
            UH0::UH0_3(v53, v54) => {
                let mut v53: Rc<UH0> = v53.clone();
                let mut v54: Rc<UH0> = v54.clone();
                match &*v1 {
                    UH0::UH0_3(v55, v56) => {
                        let mut v55: Rc<UH0> = v55.clone();
                        let mut v56: Rc<UH0> = v56.clone();
                        let mut v57: US1 = regex_compare_7(v53.clone(), v55.clone());
                        match &v57 {
                            US1::US1_1 => {
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US1::US1_2;
                    }
                }
            }
            UH0::UH0_4(v28, v29) => {
                let mut v28: Rc<UH0> = v28.clone();
                let mut v29: Rc<UH0> = v29.clone();
                match &*v1 {
                    UH0::UH0_4(v34, v35) => {
                        let mut v34: Rc<UH0> = v34.clone();
                        let mut v35: Rc<UH0> = v35.clone();
                        let mut v36: US1 = regex_compare_7(v28.clone(), v34.clone());
                        match &v36 {
                            US1::US1_1 => {
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH0::UH0_2(v32) => {
                        let mut v32: US0 = v32.clone();
                        return US1::US1_2;
                    }
                    UH0::UH0_0 => {
                        return US1::US1_2;
                    }
                    UH0::UH0_1 => {
                        return US1::US1_2;
                    }
                    _ => {
                        return US1::US1_0;
                    }
                }
            }
            UH0::UH0_2(v10) => {
                let mut v10: US0 = v10.clone();
                match &*v1 {
                    UH0::UH0_2(v13) => {
                        let mut v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_1 => {
                                match &v13 {
                                    US0::US0_1 => {
                                        return US1::US1_1;
                                    }
                                    US0::US0_0 => {
                                        return US1::US1_2;
                                    }
                                }
                            }
                            US0::US0_0 => {
                                match &v13 {
                                    US0::US0_1 => {
                                        return US1::US1_0;
                                    }
                                    US0::US0_0 => {
                                        return US1::US1_1;
                                    }
                                }
                            }
                        }
                    }
                    UH0::UH0_0 => {
                        return US1::US1_2;
                    }
                    UH0::UH0_1 => {
                        return US1::US1_2;
                    }
                    _ => {
                        return US1::US1_0;
                    }
                }
            }
            UH0::UH0_0 => {
                match &*v1 {
                    UH0::UH0_0 => {
                        return US1::US1_1;
                    }
                    _ => {
                        return US1::US1_0;
                    }
                }
            }
            UH0::UH0_1 => {
                match &*v1 {
                    UH0::UH0_0 => {
                        return US1::US1_2;
                    }
                    UH0::UH0_1 => {
                        return US1::US1_1;
                    }
                    _ => {
                        return US1::US1_0;
                    }
                }
            }
            UH0::UH0_5(v44) => {
                let mut v44: Rc<UH0> = v44.clone();
                match &*v1 {
                    UH0::UH0_3(v45, v46) => {
                        let mut v45: Rc<UH0> = v45.clone();
                        let mut v46: Rc<UH0> = v46.clone();
                        return US1::US1_0;
                    }
                    UH0::UH0_5(v48) => {
                        let mut v48: Rc<UH0> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US1::US1_2;
                    }
                }
            }
        }
    }
}
fn alt_insert_sorted_6(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    match &*v1 {
        UH0::UH0_3(v2, v3) => {
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: US1 = regex_compare_7(v0.clone(), v2.clone());
            match &v4 {
                US1::US1_2 => {
                    let mut v6: Rc<UH0> = alt_insert_sorted_6(v0.clone(), v3.clone());
                    Rc::new(UH0::UH0_3(v2.clone(), v6.clone()))
                }
                US1::US1_0 => {
                    Rc::new(UH0::UH0_3(v0.clone(), v1.clone()))
                }
                US1::US1_1 => {
                    v1.clone()
                }
            }
        }
        UH0::UH0_0 => {
            v0.clone()
        }
        _ => {
            let mut v11: US1 = regex_compare_7(v0.clone(), v1.clone());
            match &v11 {
                US1::US1_2 => {
                    Rc::new(UH0::UH0_3(v1.clone(), v0.clone()))
                }
                US1::US1_0 => {
                    Rc::new(UH0::UH0_3(v0.clone(), v1.clone()))
                }
                US1::US1_1 => {
                    v1.clone()
                }
            }
        }
    }
}
fn make_alt_5(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match &*v0 {
            UH0::UH0_3(v2, v3) => {
                let mut v2: Rc<UH0> = v2.clone();
                let mut v3: Rc<UH0> = v3.clone();
                let mut v4: Rc<UH0> = alt_insert_sorted_6(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH0::UH0_0 => {
                return v1.clone();
            }
            _ => {
                return alt_insert_sorted_6(v0.clone(), v1.clone());
            }
        }
    }
}
fn regex_equal_9(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> bool {
    loop {
        match &*v0 {
            UH0::UH0_3(v18, v19) => {
                let mut v18: Rc<UH0> = v18.clone();
                let mut v19: Rc<UH0> = v19.clone();
                match &*v1 {
                    UH0::UH0_3(v20, v21) => {
                        let mut v20: Rc<UH0> = v20.clone();
                        let mut v21: Rc<UH0> = v21.clone();
                        let mut v22: bool = regex_equal_9(v18.clone(), v20.clone());
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
            UH0::UH0_4(v26, v27) => {
                let mut v26: Rc<UH0> = v26.clone();
                let mut v27: Rc<UH0> = v27.clone();
                match &*v1 {
                    UH0::UH0_4(v28, v29) => {
                        let mut v28: Rc<UH0> = v28.clone();
                        let mut v29: Rc<UH0> = v29.clone();
                        let mut v30: bool = regex_equal_9(v26.clone(), v28.clone());
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
            UH0::UH0_2(v4) => {
                let mut v4: US0 = v4.clone();
                match &*v1 {
                    UH0::UH0_2(v5) => {
                        let mut v5: US0 = v5.clone();
                        let mut v15: US1 = match &v4 {
                            US0::US0_1 => {
                                match &v5 {
                                    US0::US0_1 => {
                                        US1::US1_1
                                    }
                                    US0::US0_0 => {
                                        US1::US1_2
                                    }
                                }
                            }
                            US0::US0_0 => {
                                match &v5 {
                                    US0::US0_1 => {
                                        US1::US1_0
                                    }
                                    US0::US0_0 => {
                                        US1::US1_1
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US1::US1_1 => {
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
            UH0::UH0_0 => {
                match &*v1 {
                    UH0::UH0_0 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_1 => {
                match &*v1 {
                    UH0::UH0_1 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH0::UH0_5(v34) => {
                let mut v34: Rc<UH0> = v34.clone();
                match &*v1 {
                    UH0::UH0_5(v35) => {
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
fn make_cat_8(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_0 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH0::UH0_0 => {
                    { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH0::UH0_1 => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH0::UH0_1 => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH0::UH0_4(v12, v13) => {
                                            let mut v12: Rc<UH0> = v12.clone();
                                            let mut v13: Rc<UH0> = v13.clone();
                                            let mut v14: Rc<UH0> = make_cat_8(v13.clone(), v1.clone());
                                            Rc::new(UH0::UH0_4(v12.clone(), v14.clone()))
                                        }
                                        UH0::UH0_5(v4) => {
                                            let mut v4: Rc<UH0> = v4.clone();
                                            match &*v1 {
                                                UH0::UH0_5(v5) => {
                                                    let mut v5: Rc<UH0> = v5.clone();
                                                    let mut v6: bool = regex_equal_9(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH0::UH0_5(v4.clone()))
                                                    } else {
                                                        Rc::new(UH0::UH0_4(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH0::UH0_4(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH0::UH0_4(v0.clone(), v1.clone()))
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
fn make_star_10(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_0 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_1 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_5(v3) => {
            let mut v3: Rc<UH0> = v3.clone();
            Rc::new(UH0::UH0_5(v3.clone()))
        }
        _ => {
            Rc::new(UH0::UH0_5(v0.clone()))
        }
    }
}
fn normalize_4(mut v0: Rc<UH0>) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_3(v5, v6) => {
            let mut v5: Rc<UH0> = v5.clone();
            let mut v6: Rc<UH0> = v6.clone();
            let mut v7: Rc<UH0> = normalize_4(v5.clone());
            let mut v8: Rc<UH0> = normalize_4(v6.clone());
            make_alt_5(v7.clone(), v8.clone())
        }
        UH0::UH0_4(v10, v11) => {
            let mut v10: Rc<UH0> = v10.clone();
            let mut v11: Rc<UH0> = v11.clone();
            let mut v12: Rc<UH0> = normalize_4(v10.clone());
            let mut v13: Rc<UH0> = normalize_4(v11.clone());
            make_cat_8(v12.clone(), v13.clone())
        }
        UH0::UH0_2(v3) => {
            let mut v3: US0 = v3.clone();
            Rc::new(UH0::UH0_2(v3.clone()))
        }
        UH0::UH0_0 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_1 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_5(v15) => {
            let mut v15: Rc<UH0> = v15.clone();
            let mut v16: Rc<UH0> = normalize_4(v15.clone());
            make_star_10(v16.clone())
        }
    }
}
fn nullable_12(mut v0: Rc<UH0>) -> US2 {
    match &*v0 {
        UH0::UH0_3(v5, v6) => {
            let mut v5: Rc<UH0> = v5.clone();
            let mut v6: Rc<UH0> = v6.clone();
            let mut v7: US2 = nullable_12(v5.clone());
            let mut v8: US2 = nullable_12(v6.clone());
            match &v7 {
                US2::US2_0 => {
                    US2::US2_0
                }
                _ => {
                    match &v8 {
                        US2::US2_0 => {
                            US2::US2_0
                        }
                        _ => {
                            match &v7 {
                                US2::US2_1 => {
                                    match &v8 {
                                        US2::US2_1 => {
                                            US2::US2_1
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
        UH0::UH0_4(v16, v17) => {
            let mut v16: Rc<UH0> = v16.clone();
            let mut v17: Rc<UH0> = v17.clone();
            let mut v18: US2 = nullable_12(v16.clone());
            let mut v19: US2 = nullable_12(v17.clone());
            match &v18 {
                US2::US2_0 => {
                    match &v19 {
                        US2::US2_0 => {
                            US2::US2_0
                        }
                        _ => {
                            US2::US2_1
                        }
                    }
                }
                _ => {
                    US2::US2_1
                }
            }
        }
        UH0::UH0_2(v3) => {
            let mut v3: US0 = v3.clone();
            US2::US2_1
        }
        UH0::UH0_0 => {
            US2::US2_1
        }
        UH0::UH0_1 => {
            US2::US2_0
        }
        UH0::UH0_5(v25) => {
            let mut v25: Rc<UH0> = v25.clone();
            US2::US2_0
        }
    }
}
fn derivative_11(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    match &*v0 {
        UH0::UH0_3(v19, v20) => {
            let mut v19: Rc<UH0> = v19.clone();
            let mut v20: Rc<UH0> = v20.clone();
            let mut v21: Rc<UH0> = derivative_11(v19.clone(), v1.clone());
            let mut v22: Rc<UH0> = derivative_11(v20.clone(), v1.clone());
            make_alt_5(v21.clone(), v22.clone())
        }
        UH0::UH0_4(v24, v25) => {
            let mut v24: Rc<UH0> = v24.clone();
            let mut v25: Rc<UH0> = v25.clone();
            let mut v26: US2 = nullable_12(v24.clone());
            match &v26 {
                US2::US2_1 => {
                    let mut v31: Rc<UH0> = derivative_11(v24.clone(), v1.clone());
                    make_cat_8(v31.clone(), v25.clone())
                }
                US2::US2_0 => {
                    let mut v27: Rc<UH0> = derivative_11(v24.clone(), v1.clone());
                    let mut v28: Rc<UH0> = make_cat_8(v27.clone(), v25.clone());
                    let mut v29: Rc<UH0> = derivative_11(v25.clone(), v1.clone());
                    make_alt_5(v28.clone(), v29.clone())
                }
            }
        }
        UH0::UH0_2(v4) => {
            let mut v4: US0 = v4.clone();
            let mut v14: US1 = match &v4 {
                US0::US0_1 => {
                    match &v1 {
                        US0::US0_1 => {
                            US1::US1_1
                        }
                        US0::US0_0 => {
                            US1::US1_2
                        }
                    }
                }
                US0::US0_0 => {
                    match &v1 {
                        US0::US0_1 => {
                            US1::US1_0
                        }
                        US0::US0_0 => {
                            US1::US1_1
                        }
                    }
                }
            };
            let mut v15: bool = match &v14 {
                US1::US1_1 => {
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
            }
        }
        UH0::UH0_0 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_1 => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) }
        }
        UH0::UH0_5(v35) => {
            let mut v35: Rc<UH0> = v35.clone();
            let mut v36: Rc<UH0> = derivative_11(v35.clone(), v1.clone());
            let mut v37: Rc<UH0> = make_star_10(v35.clone());
            make_cat_8(v36.clone(), v37.clone())
        }
    }
}
fn canonical_derivative_3(mut v0: Rc<UH0>, mut v1: US0) -> Rc<UH0> {
    let mut v2: Rc<UH0> = normalize_4(v0.clone());
    let mut v3: Rc<UH0> = derivative_11(v2.clone(), v1.clone());
    normalize_4(v3.clone())
}
fn accepts_2(mut v0: Rc<UH0>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v6, v7) => {
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH1> = v7.clone();
                let mut v8: Rc<UH0> = canonical_derivative_3(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH1::UH1_0 => {
                let mut v2: Rc<UH0> = normalize_4(v0.clone());
                let mut v3: US2 = nullable_12(v2.clone());
                match &v3 {
                    US2::US2_1 => {
                        return false;
                    }
                    US2::US2_0 => {
                        return true;
                    }
                }
            }
        }
    }
}
fn loop_0(mut v0: Rc<UH0>, mut v1: i32, mut v2: i32, mut v3: u64, mut v4: i32) -> i32 {
    loop {
        let mut v5: bool = 0i32 < v2;
        if v5 {
            let mut v6: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let (mut v7, mut v8): (Rc<UH1>, u64) = random_bit_input_1(v3, v1, v6.clone());
            let mut v9: bool = accepts_2(v0.clone(), v7.clone());
            let mut v11: i32 = if v9 {
                let mut v10: i32 = v4.wrapping_add(1i32);
                v10
            } else {
                v4
            };
            let mut v12: i32 = v2.wrapping_sub(1i32);
            (v0, v1, v2, v3, v4) = (v0.clone(), v1, v12, v8, v11);
            continue;
        } else {
            return v4;
        }
    }
}
fn zeros_input_14(mut v0: i32, mut v1: Rc<UH1>) -> Rc<UH1> {
    loop {
        let mut v2: bool = 0i32 < v0;
        if v2 {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: US0 = US0::US0_0;
            let mut v5: Rc<UH1> = Rc::new(UH1::UH1_1(v4.clone(), v1.clone()));
            (v0, v1) = (v3, v5.clone());
            continue;
        } else {
            return v1.clone();
        }
    }
}
fn loop_13(mut v0: Rc<UH0>, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = v1 < v2;
        if v4 {
            return v3;
        } else {
            let mut v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH1> = zeros_input_14(v2, v5.clone());
            let mut v7: bool = accepts_2(v0.clone(), v6.clone());
            let mut v9: i32 = if v7 {
                let mut v8: i32 = v3.wrapping_add(1i32);
                v8
            } else {
                v3
            };
            let mut v10: US0 = US0::US0_1;
            let mut v11: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v12: Rc<UH1> = Rc::new(UH1::UH1_1(v10.clone(), v11.clone()));
            let mut v13: Rc<UH1> = zeros_input_14(v2, v12.clone());
            let mut v14: bool = accepts_2(v0.clone(), v13.clone());
            let mut v16: i32 = if v14 {
                let mut v15: i32 = v9.wrapping_add(1i32);
                v15
            } else {
                v9
            };
            let mut v17: i32 = v2.wrapping_add(1i32);
            (v0, v1, v2, v3) = (v0.clone(), v1, v17, v16);
            continue;
        }
    }
}
fn backtrack_stack_16(mut v0: Rc<UH2>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v0 {
            UH2::UH2_1(v6, v7) => {
                let mut v6: Rc<UH0> = v6.clone();
                let mut v7: Rc<UH2> = v7.clone();
                match &*v6 {
                    UH0::UH0_3(v27, v28) => {
                        let mut v27: Rc<UH0> = v27.clone();
                        let mut v28: Rc<UH0> = v28.clone();
                        let mut v29: Rc<UH2> = Rc::new(UH2::UH2_1(v27.clone(), v7.clone()));
                        let mut v30: bool = backtrack_stack_16(v29.clone(), v1.clone());
                        if v30 {
                            return true;
                        } else {
                            let mut v31: Rc<UH2> = Rc::new(UH2::UH2_1(v28.clone(), v7.clone()));
                            (v0, v1) = (v31.clone(), v1.clone());
                            continue;
                        }
                    }
                    UH0::UH0_4(v34, v35) => {
                        let mut v34: Rc<UH0> = v34.clone();
                        let mut v35: Rc<UH0> = v35.clone();
                        let mut v36: Rc<UH2> = Rc::new(UH2::UH2_1(v35.clone(), v7.clone()));
                        let mut v37: Rc<UH2> = Rc::new(UH2::UH2_1(v34.clone(), v36.clone()));
                        (v0, v1) = (v37.clone(), v1.clone());
                        continue;
                    }
                    UH0::UH0_2(v9) => {
                        let mut v9: US0 = v9.clone();
                        match &*v1 {
                            UH1::UH1_1(v10, v11) => {
                                let mut v10: US0 = v10.clone();
                                let mut v11: Rc<UH1> = v11.clone();
                                let mut v21: US1 = match &v9 {
                                    US0::US0_1 => {
                                        match &v10 {
                                            US0::US0_1 => {
                                                US1::US1_1
                                            }
                                            US0::US0_0 => {
                                                US1::US1_2
                                            }
                                        }
                                    }
                                    US0::US0_0 => {
                                        match &v10 {
                                            US0::US0_1 => {
                                                US1::US1_0
                                            }
                                            US0::US0_0 => {
                                                US1::US1_1
                                            }
                                        }
                                    }
                                };
                                let mut v22: bool = match &v21 {
                                    US1::US1_1 => {
                                        true
                                    }
                                    _ => {
                                        false
                                    }
                                };
                                if v22 {
                                    (v0, v1) = (v7.clone(), v11.clone());
                                    continue;
                                } else {
                                    return false;
                                }
                            }
                            UH1::UH1_0 => {
                                return false;
                            }
                        }
                    }
                    UH0::UH0_0 => {
                        return false;
                    }
                    UH0::UH0_1 => {
                        (v0, v1) = (v7.clone(), v1.clone());
                        continue;
                    }
                    UH0::UH0_5(v39) => {
                        let mut v39: Rc<UH0> = v39.clone();
                        let mut v40: Rc<UH2> = Rc::new(UH2::UH2_1(v39.clone(), v0.clone()));
                        let mut v41: bool = backtrack_stack_16(v40.clone(), v1.clone());
                        if v41 {
                            return true;
                        } else {
                            (v0, v1) = (v7.clone(), v1.clone());
                            continue;
                        }
                    }
                }
            }
            UH2::UH2_0 => {
                match &*v1 {
                    UH1::UH1_1(v2, v3) => {
                        let mut v2: US0 = v2.clone();
                        let mut v3: Rc<UH1> = v3.clone();
                        return false;
                    }
                    UH1::UH1_0 => {
                        return true;
                    }
                }
            }
        }
    }
}
fn loop_15(mut v0: Rc<UH0>, mut v1: i32, mut v2: i32, mut v3: u64, mut v4: i32) -> i32 {
    loop {
        let mut v5: bool = 0i32 < v2;
        if v5 {
            let mut v6: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let (mut v7, mut v8): (Rc<UH1>, u64) = random_bit_input_1(v3, v1, v6.clone());
            let mut v9: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) };
            let mut v10: Rc<UH2> = Rc::new(UH2::UH2_1(v0.clone(), v9.clone()));
            let mut v11: bool = backtrack_stack_16(v10.clone(), v7.clone());
            let mut v13: i32 = if v11 {
                let mut v12: i32 = v4.wrapping_add(1i32);
                v12
            } else {
                v4
            };
            let mut v14: i32 = v2.wrapping_sub(1i32);
            (v0, v1, v2, v3, v4) = (v0.clone(), v1, v14, v8, v13);
            continue;
        } else {
            return v4;
        }
    }
}
fn loop_17(mut v0: Rc<UH0>, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = v1 < v2;
        if v4 {
            return v3;
        } else {
            let mut v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v6: Rc<UH1> = zeros_input_14(v2, v5.clone());
            let mut v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) };
            let mut v8: Rc<UH2> = Rc::new(UH2::UH2_1(v0.clone(), v7.clone()));
            let mut v9: bool = backtrack_stack_16(v8.clone(), v6.clone());
            let mut v11: i32 = if v9 {
                let mut v10: i32 = v3.wrapping_add(1i32);
                v10
            } else {
                v3
            };
            let mut v12: US0 = US0::US0_1;
            let mut v13: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v14: Rc<UH1> = Rc::new(UH1::UH1_1(v12.clone(), v13.clone()));
            let mut v15: Rc<UH1> = zeros_input_14(v2, v14.clone());
            let mut v16: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) };
            let mut v17: Rc<UH2> = Rc::new(UH2::UH2_1(v0.clone(), v16.clone()));
            let mut v18: bool = backtrack_stack_16(v17.clone(), v15.clone());
            let mut v20: i32 = if v18 {
                let mut v19: i32 = v11.wrapping_add(1i32);
                v19
            } else {
                v11
            };
            let mut v21: i32 = v2.wrapping_add(1i32);
            (v0, v1, v2, v3) = (v0.clone(), v1, v21, v20);
            continue;
        }
    }
}
fn run_19(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v3, v4) => {
                let mut v3: US0 = v3.clone();
                let mut v4: Rc<UH1> = v4.clone();
                match &v3 {
                    US0::US0_1 => {
                        let mut v8: bool = v0 == 0i32;
                        let mut v9: i32 = 0i32;
                        (v0, v1) = (v9, v4.clone());
                        continue;
                    }
                    US0::US0_0 => {
                        let mut v5: bool = v0 == 0i32;
                        let mut v6: i32 = 1i32;
                        (v0, v1) = (v6, v4.clone());
                        continue;
                    }
                }
            }
            UH1::UH1_0 => {
                let mut v2: bool = v0 == 1i32;
                return v2;
            }
        }
    }
}
fn loop_18(mut v0: i32, mut v1: i32, mut v2: u64, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = 0i32 < v1;
        if v4 {
            let mut v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let (mut v6, mut v7): (Rc<UH1>, u64) = random_bit_input_1(v2, v0, v5.clone());
            let mut v8: i32 = 0i32;
            let mut v9: bool = run_19(v8, v6.clone());
            let mut v11: i32 = if v9 {
                let mut v10: i32 = v3.wrapping_add(1i32);
                v10
            } else {
                v3
            };
            let mut v12: i32 = v1.wrapping_sub(1i32);
            (v0, v1, v2, v3) = (v0, v12, v7, v11);
            continue;
        } else {
            return v3;
        }
    }
}
fn run_21(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v17, v18) => {
                let mut v17: US0 = v17.clone();
                let mut v18: Rc<UH1> = v18.clone();
                match &v17 {
                    US0::US0_1 => {
                        let mut v50: bool = v0 == 0i32;
                        let mut v79: i32 = if v50 {
                            1i32
                        } else {
                            let mut v51: bool = v0 == 1i32;
                            if v51 {
                                6i32
                            } else {
                                let mut v52: bool = v0 == 2i32;
                                if v52 {
                                    11i32
                                } else {
                                    let mut v53: bool = v0 == 3i32;
                                    if v53 {
                                        5i32
                                    } else {
                                        let mut v54: bool = v0 == 4i32;
                                        if v54 {
                                            1i32
                                        } else {
                                            let mut v55: bool = v0 == 5i32;
                                            if v55 {
                                                6i32
                                            } else {
                                                let mut v56: bool = v0 == 6i32;
                                                if v56 {
                                                    13i32
                                                } else {
                                                    let mut v57: bool = v0 == 7i32;
                                                    if v57 {
                                                        9i32
                                                    } else {
                                                        let mut v58: bool = v0 == 8i32;
                                                        if v58 {
                                                            5i32
                                                        } else {
                                                            let mut v59: bool = v0 == 9i32;
                                                            if v59 {
                                                                12i32
                                                            } else {
                                                                let mut v60: bool = v0 == 10i32;
                                                                if v60 {
                                                                    11i32
                                                                } else {
                                                                    let mut v61: bool = v0 == 11i32;
                                                                    if v61 {
                                                                        12i32
                                                                    } else {
                                                                        let mut v62: bool = v0 == 12i32;
                                                                        if v62 {
                                                                            13i32
                                                                        } else {
                                                                            let mut v63: bool = v0 == 13i32;
                                                                            if v63 {
                                                                                15i32
                                                                            } else {
                                                                                let mut v64: bool = v0 == 14i32;
                                                                                if v64 {
                                                                                    9i32
                                                                                } else {
                                                                                    15i32
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
                        };
                        (v0, v1) = (v79, v18.clone());
                        continue;
                    }
                    US0::US0_0 => {
                        let mut v19: bool = v0 == 0i32;
                        let mut v48: i32 = if v19 {
                            0i32
                        } else {
                            let mut v20: bool = v0 == 1i32;
                            if v20 {
                                2i32
                            } else {
                                let mut v21: bool = v0 == 2i32;
                                if v21 {
                                    3i32
                                } else {
                                    let mut v22: bool = v0 == 3i32;
                                    if v22 {
                                        4i32
                                    } else {
                                        let mut v23: bool = v0 == 4i32;
                                        if v23 {
                                            0i32
                                        } else {
                                            let mut v24: bool = v0 == 5i32;
                                            if v24 {
                                                2i32
                                            } else {
                                                let mut v25: bool = v0 == 6i32;
                                                if v25 {
                                                    7i32
                                                } else {
                                                    let mut v26: bool = v0 == 7i32;
                                                    if v26 {
                                                        8i32
                                                    } else {
                                                        let mut v27: bool = v0 == 8i32;
                                                        if v27 {
                                                            4i32
                                                        } else {
                                                            let mut v28: bool = v0 == 9i32;
                                                            if v28 {
                                                                10i32
                                                            } else {
                                                                let mut v29: bool = v0 == 10i32;
                                                                if v29 {
                                                                    3i32
                                                                } else {
                                                                    let mut v30: bool = v0 == 11i32;
                                                                    if v30 {
                                                                        10i32
                                                                    } else {
                                                                        let mut v31: bool = v0 == 12i32;
                                                                        if v31 {
                                                                            7i32
                                                                        } else {
                                                                            let mut v32: bool = v0 == 13i32;
                                                                            if v32 {
                                                                                14i32
                                                                            } else {
                                                                                let mut v33: bool = v0 == 14i32;
                                                                                if v33 {
                                                                                    8i32
                                                                                } else {
                                                                                    14i32
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
                        };
                        (v0, v1) = (v48, v18.clone());
                        continue;
                    }
                }
            }
            UH1::UH1_0 => {
                let mut v2: bool = v0 == 4i32;
                if v2 {
                    return true;
                } else {
                    let mut v3: bool = v0 == 5i32;
                    if v3 {
                        return true;
                    } else {
                        let mut v4: bool = v0 == 8i32;
                        if v4 {
                            return true;
                        } else {
                            let mut v5: bool = v0 == 9i32;
                            if v5 {
                                return true;
                            } else {
                                let mut v6: bool = v0 == 10i32;
                                if v6 {
                                    return true;
                                } else {
                                    let mut v7: bool = v0 == 12i32;
                                    if v7 {
                                        return true;
                                    } else {
                                        let mut v8: bool = v0 == 14i32;
                                        if v8 {
                                            return true;
                                        } else {
                                            let mut v9: bool = v0 == 15i32;
                                            return v9;
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
fn loop_20(mut v0: i32, mut v1: i32, mut v2: u64, mut v3: i32) -> i32 {
    loop {
        let mut v4: bool = 0i32 < v1;
        if v4 {
            let mut v5: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let (mut v6, mut v7): (Rc<UH1>, u64) = random_bit_input_1(v2, v0, v5.clone());
            let mut v8: i32 = 0i32;
            let mut v9: bool = run_21(v8, v6.clone());
            let mut v11: i32 = if v9 {
                let mut v10: i32 = v3.wrapping_add(1i32);
                v10
            } else {
                v3
            };
            let mut v12: i32 = v1.wrapping_sub(1i32);
            (v0, v1, v2, v3) = (v0, v12, v7, v11);
            continue;
        } else {
            return v3;
        }
    }
}
fn run_23(mut v0: i32, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v3, v4) => {
                let mut v3: US0 = v3.clone();
                let mut v4: Rc<UH1> = v4.clone();
                match &v3 {
                    US0::US0_1 => {
                        let mut v13: bool = v0 == 0i32;
                        let mut v19: i32 = if v13 {
                            3i32
                        } else {
                            let mut v14: bool = v0 == 1i32;
                            if v14 {
                                3i32
                            } else {
                                let mut v15: bool = v0 == 2i32;
                                if v15 {
                                    3i32
                                } else {
                                    let mut v16: bool = v0 == 3i32;
                                    4i32
                                }
                            }
                        };
                        (v0, v1) = (v19, v4.clone());
                        continue;
                    }
                    US0::US0_0 => {
                        let mut v5: bool = v0 == 0i32;
                        let mut v11: i32 = if v5 {
                            1i32
                        } else {
                            let mut v6: bool = v0 == 1i32;
                            if v6 {
                                2i32
                            } else {
                                let mut v7: bool = v0 == 2i32;
                                if v7 {
                                    2i32
                                } else {
                                    let mut v8: bool = v0 == 3i32;
                                    4i32
                                }
                            }
                        };
                        (v0, v1) = (v11, v4.clone());
                        continue;
                    }
                }
            }
            UH1::UH1_0 => {
                let mut v2: bool = v0 == 3i32;
                return v2;
            }
        }
    }
}
fn loop_22(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v0 < v1;
        if v3 {
            return v2;
        } else {
            let mut v4: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v5: Rc<UH1> = zeros_input_14(v1, v4.clone());
            let mut v6: i32 = 0i32;
            let mut v7: bool = run_23(v6, v5.clone());
            let mut v9: i32 = if v7 {
                let mut v8: i32 = v2.wrapping_add(1i32);
                v8
            } else {
                v2
            };
            let mut v10: US0 = US0::US0_1;
            let mut v11: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v12: Rc<UH1> = Rc::new(UH1::UH1_1(v10.clone(), v11.clone()));
            let mut v13: Rc<UH1> = zeros_input_14(v1, v12.clone());
            let mut v14: i32 = 0i32;
            let mut v15: bool = run_23(v14, v13.clone());
            let mut v17: i32 = if v15 {
                let mut v16: i32 = v9.wrapping_add(1i32);
                v16
            } else {
                v9
            };
            let mut v18: i32 = v1.wrapping_add(1i32);
            (v0, v1, v2) = (v0, v18, v17);
            continue;
        }
    }
}
fn loop_24(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: i32) -> () {
    loop {
        let mut v2: bool = v1 < 8192i32;
        if v2 {
            v0.clone().borrow_mut()[v1 as usize] = 0i32;
            let mut v3: i32 = v1.wrapping_add(1i32);
            (v0, v1) = (v0.clone(), v3);
            continue;
        }
        return ();
    }
}
fn loop_25(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: i32) -> () {
    loop {
        let mut v2: bool = v1 < 1i32;
        if v2 {
            v0.clone().borrow_mut()[v1 as usize] = 0i32;
            let mut v3: i32 = v1.wrapping_add(1i32);
            (v0, v1) = (v0.clone(), v3);
            continue;
        }
        return ();
    }
}
fn probe_27(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32, mut v9: i32, mut v10: i32) -> i32 {
    loop {
        let mut v11: i32 = v4.clone().borrow()[v10 as usize].clone();
        let mut v12: bool = v11 == 0i32;
        if v12 {
            let mut v13: i32 = v6.clone().borrow()[0i32 as usize].clone();
            let mut v14: bool = v13 < 4096i32;
            if v14 {
                v0.clone().borrow_mut()[v13 as usize] = v7;
                v1.clone().borrow_mut()[v13 as usize] = v8;
                v2.clone().borrow_mut()[v13 as usize] = v9;
                let mut v15: bool = v7 == 1i32;
                let mut v32: bool = if v15 {
                    true
                } else {
                    let mut v16: bool = v7 == 5i32;
                    if v16 {
                        true
                    } else {
                        let mut v17: bool = v7 == 3i32;
                        if v17 {
                            let mut v18: i32 = v3.clone().borrow()[v8 as usize].clone();
                            let mut v19: bool = v18 == 1i32;
                            if v19 {
                                true
                            } else {
                                let mut v20: i32 = v3.clone().borrow()[v9 as usize].clone();
                                let mut v21: bool = v20 == 1i32;
                                v21
                            }
                        } else {
                            let mut v23: bool = v7 == 4i32;
                            if v23 {
                                let mut v24: i32 = v3.clone().borrow()[v8 as usize].clone();
                                let mut v25: bool = v24 == 1i32;
                                if v25 {
                                    let mut v26: i32 = v3.clone().borrow()[v9 as usize].clone();
                                    let mut v27: bool = v26 == 1i32;
                                    v27
                                } else {
                                    false
                                }
                            } else {
                                false
                            }
                        }
                    }
                };
                let mut v33: i32 = if v32 {
                    1i32
                } else {
                    0i32
                };
                v3.clone().borrow_mut()[v13 as usize] = v33;
                let mut v34: i32 = v13.wrapping_add(1i32);
                v4.clone().borrow_mut()[v10 as usize] = v34;
                v6.clone().borrow_mut()[0i32 as usize] = v34;
                return v13;
            } else {
                return std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-interned-store-full"); } LIT.with(|lit| lit.clone()) }));
            }
        } else {
            let mut v37: i32 = v11.wrapping_sub(1i32);
            let mut v38: i32 = v0.clone().borrow()[v37 as usize].clone();
            let mut v39: bool = v38 == v7;
            let mut v42: bool = if v39 {
                let mut v40: i32 = v1.clone().borrow()[v37 as usize].clone();
                let mut v41: bool = v40 == v8;
                v41
            } else {
                false
            };
            let mut v45: bool = if v42 {
                let mut v43: i32 = v2.clone().borrow()[v37 as usize].clone();
                let mut v44: bool = v43 == v9;
                v44
            } else {
                false
            };
            if v45 {
                return v37;
            } else {
                let mut v46: i32 = v10.wrapping_add(1i32);
                let mut v47: i32 = v46 & 8191i32;
                (v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = (v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8, v9, v47);
                continue;
            }
        }
    }
}
fn interned_node_26(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32, mut v9: i32) -> i32 {
    let mut v10: i32 = v7.wrapping_mul(1024i32);
    let mut v11: i32 = v10.wrapping_add(v8);
    let mut v12: i32 = v11.wrapping_mul(4099i32);
    let mut v13: i32 = v12.wrapping_add(v9);
    let mut v14: i32 = v13 & 8191i32;
    probe_27(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8, v9, v14)
}
fn interned_alt_insert_30(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32) -> i32 {
    let mut v9: bool = v8 == 0i32;
    if v9 {
        v7
    } else {
        let mut v10: i32 = v0.clone().borrow()[v8 as usize].clone();
        let mut v11: bool = v10 == 3i32;
        if v11 {
            let mut v12: i32 = v1.clone().borrow()[v8 as usize].clone();
            let mut v13: bool = v7 < v12;
            if v13 {
                let mut v14: i32 = 3i32;
                interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v14, v7, v8)
            } else {
                let mut v16: bool = v7 == v12;
                if v16 {
                    v8
                } else {
                    let mut v17: i32 = 3i32;
                    let mut v18: i32 = v2.clone().borrow()[v8 as usize].clone();
                    let mut v19: i32 = interned_alt_insert_30(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v18);
                    interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v17, v12, v19)
                }
            }
        } else {
            let mut v23: bool = v7 < v8;
            if v23 {
                let mut v24: i32 = 3i32;
                interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v24, v7, v8)
            } else {
                let mut v26: bool = v7 == v8;
                if v26 {
                    v8
                } else {
                    let mut v27: i32 = 3i32;
                    interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v27, v8, v7)
                }
            }
        }
    }
}
fn interned_make_alt_29(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32) -> i32 {
    loop {
        let mut v9: bool = v7 == 0i32;
        if v9 {
            return v8;
        } else {
            let mut v10: i32 = v0.clone().borrow()[v7 as usize].clone();
            let mut v11: bool = v10 == 3i32;
            if v11 {
                let mut v12: i32 = v2.clone().borrow()[v7 as usize].clone();
                let mut v13: i32 = v1.clone().borrow()[v7 as usize].clone();
                let mut v14: i32 = interned_alt_insert_30(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v13, v8);
                (v0, v1, v2, v3, v4, v5, v6, v7, v8) = (v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v12, v14);
                continue;
            } else {
                return interned_alt_insert_30(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8);
            }
        }
    }
}
fn interned_make_cat_31(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32) -> i32 {
    let mut v9: bool = v7 == 0i32;
    if v9 {
        0i32
    } else {
        let mut v10: bool = v8 == 0i32;
        if v10 {
            0i32
        } else {
            let mut v11: bool = v7 == 1i32;
            if v11 {
                v8
            } else {
                let mut v12: bool = v8 == 1i32;
                if v12 {
                    v7
                } else {
                    let mut v13: i32 = v0.clone().borrow()[v7 as usize].clone();
                    let mut v14: bool = v13 == 5i32;
                    let mut v17: bool = if v14 {
                        let mut v15: i32 = v0.clone().borrow()[v8 as usize].clone();
                        let mut v16: bool = v15 == 5i32;
                        v16
                    } else {
                        false
                    };
                    if v17 {
                        let mut v18: i32 = v1.clone().borrow()[v7 as usize].clone();
                        let mut v19: i32 = v1.clone().borrow()[v8 as usize].clone();
                        let mut v20: bool = v18 == v19;
                        if v20 {
                            v7
                        } else {
                            let mut v21: i32 = 4i32;
                            interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v21, v7, v8)
                        }
                    } else {
                        let mut v24: i32 = v0.clone().borrow()[v7 as usize].clone();
                        let mut v25: bool = v24 == 4i32;
                        if v25 {
                            let mut v26: i32 = 4i32;
                            let mut v27: i32 = v1.clone().borrow()[v7 as usize].clone();
                            let mut v28: i32 = v2.clone().borrow()[v7 as usize].clone();
                            let mut v29: i32 = interned_make_cat_31(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v28, v8);
                            interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v26, v27, v29)
                        } else {
                            let mut v31: i32 = 4i32;
                            interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v31, v7, v8)
                        }
                    }
                }
            }
        }
    }
}
fn interned_of_regex_raw_28(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: Rc<UH0>) -> i32 {
    match &*v7 {
        UH0::UH0_3(v14, v15) => {
            let mut v14: Rc<UH0> = v14.clone();
            let mut v15: Rc<UH0> = v15.clone();
            let mut v16: i32 = interned_of_regex_raw_28(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v14.clone());
            let mut v17: i32 = interned_of_regex_raw_28(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v15.clone());
            interned_make_alt_29(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v16, v17)
        }
        UH0::UH0_4(v19, v20) => {
            let mut v19: Rc<UH0> = v19.clone();
            let mut v20: Rc<UH0> = v20.clone();
            let mut v21: i32 = interned_of_regex_raw_28(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v19.clone());
            let mut v22: i32 = interned_of_regex_raw_28(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v20.clone());
            interned_make_cat_31(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v21, v22)
        }
        UH0::UH0_2(v8) => {
            let mut v8: US0 = v8.clone();
            let mut v9: i32 = 2i32;
            let mut v11: i32 = match &v8 {
                US0::US0_1 => {
                    1i32
                }
                US0::US0_0 => {
                    0i32
                }
            };
            let mut v12: i32 = 0i32;
            interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v9, v11, v12)
        }
        UH0::UH0_0 => {
            0i32
        }
        UH0::UH0_1 => {
            1i32
        }
        UH0::UH0_5(v24) => {
            let mut v24: Rc<UH0> = v24.clone();
            let mut v25: i32 = interned_of_regex_raw_28(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v24.clone());
            let mut v26: i32 = v0.clone().borrow()[v25 as usize].clone();
            let mut v27: bool = v26 < 2i32;
            if v27 {
                1i32
            } else {
                let mut v28: bool = v26 == 5i32;
                if v28 {
                    v25
                } else {
                    let mut v29: i32 = 5i32;
                    let mut v30: i32 = 0i32;
                    interned_node_26(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v29, v25, v30)
                }
            }
        }
    }
}
fn interned_derivative_raw_35(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32) -> i32 {
    let mut v9: i32 = v7.wrapping_mul(2i32);
    let mut v10: i32 = v9.wrapping_add(v8);
    let mut v11: i32 = v5.clone().borrow()[v10 as usize].clone();
    let mut v12: bool = v11 == 0i32;
    if v12 {
        let mut v13: i32 = v0.clone().borrow()[v7 as usize].clone();
        let mut v14: bool = v13 < 2i32;
        let mut v41: i32 = if v14 {
            0i32
        } else {
            let mut v15: bool = v13 == 2i32;
            if v15 {
                let mut v16: i32 = v1.clone().borrow()[v7 as usize].clone();
                let mut v17: bool = v16 == v8;
                if v17 {
                    1i32
                } else {
                    0i32
                }
            } else {
                let mut v19: bool = v13 == 3i32;
                if v19 {
                    let mut v20: i32 = v1.clone().borrow()[v7 as usize].clone();
                    let mut v21: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v20, v8);
                    let mut v22: i32 = v2.clone().borrow()[v7 as usize].clone();
                    let mut v23: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v22, v8);
                    interned_make_alt_29(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v21, v23)
                } else {
                    let mut v25: bool = v13 == 4i32;
                    if v25 {
                        let mut v26: i32 = v1.clone().borrow()[v7 as usize].clone();
                        let mut v27: i32 = v2.clone().borrow()[v7 as usize].clone();
                        let mut v28: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v26, v8);
                        let mut v29: i32 = interned_make_cat_31(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v28, v27);
                        let mut v30: i32 = v3.clone().borrow()[v26 as usize].clone();
                        let mut v31: bool = v30 == 1i32;
                        if v31 {
                            let mut v32: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v27, v8);
                            interned_make_alt_29(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v29, v32)
                        } else {
                            v29
                        }
                    } else {
                        let mut v35: i32 = v1.clone().borrow()[v7 as usize].clone();
                        let mut v36: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v35, v8);
                        interned_make_cat_31(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v36, v7)
                    }
                }
            }
        };
        let mut v42: i32 = v41.wrapping_add(1i32);
        v5.clone().borrow_mut()[v10 as usize] = v42;
        v41
    } else {
        let mut v43: i32 = v11.wrapping_sub(1i32);
        v43
    }
}
fn loop_34(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: Rc<UH1>) -> bool {
    loop {
        let mut v9: bool = v7 == 0i32;
        if v9 {
            return false;
        } else {
            match &*v8 {
                UH1::UH1_1(v12, v13) => {
                    let mut v12: US0 = v12.clone();
                    let mut v13: Rc<UH1> = v13.clone();
                    let mut v15: i32 = match &v12 {
                        US0::US0_1 => {
                            1i32
                        }
                        US0::US0_0 => {
                            0i32
                        }
                    };
                    let mut v16: i32 = interned_derivative_raw_35(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v15);
                    (v0, v1, v2, v3, v4, v5, v6, v7, v8) = (v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v16, v13.clone());
                    continue;
                }
                UH1::UH1_0 => {
                    let mut v10: i32 = v3.clone().borrow()[v7 as usize].clone();
                    let mut v11: bool = v10 == 1i32;
                    return v11;
                }
            }
        }
    }
}
fn interned_accepts_33(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: Rc<UH1>) -> bool {
    loop_34(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8.clone())
}
fn loop_32(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32, mut v9: i32, mut v10: u64, mut v11: i32) -> i32 {
    loop {
        let mut v12: bool = 0i32 < v9;
        if v12 {
            let mut v13: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let (mut v14, mut v15): (Rc<UH1>, u64) = random_bit_input_1(v10, v7, v13.clone());
            let mut v16: bool = interned_accepts_33(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v8, v14.clone());
            let mut v18: i32 = if v16 {
                let mut v17: i32 = v11.wrapping_add(1i32);
                v17
            } else {
                v11
            };
            let mut v19: i32 = v9.wrapping_sub(1i32);
            (v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11) = (v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8, v19, v15, v18);
            continue;
        } else {
            return v11;
        }
    }
}
fn loop_36(mut v0: Rc<RefCell<Vec<i32>>>, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: Rc<RefCell<Vec<i32>>>, mut v3: Rc<RefCell<Vec<i32>>>, mut v4: Rc<RefCell<Vec<i32>>>, mut v5: Rc<RefCell<Vec<i32>>>, mut v6: Rc<RefCell<Vec<i32>>>, mut v7: i32, mut v8: i32, mut v9: i32, mut v10: i32) -> i32 {
    loop {
        let mut v11: bool = v7 < v9;
        if v11 {
            return v10;
        } else {
            let mut v12: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v13: Rc<UH1> = zeros_input_14(v9, v12.clone());
            let mut v14: bool = interned_accepts_33(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v8, v13.clone());
            let mut v16: i32 = if v14 {
                let mut v15: i32 = v10.wrapping_add(1i32);
                v15
            } else {
                v10
            };
            let mut v17: US0 = US0::US0_1;
            let mut v18: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
            let mut v19: Rc<UH1> = Rc::new(UH1::UH1_1(v17.clone(), v18.clone()));
            let mut v20: Rc<UH1> = zeros_input_14(v9, v19.clone());
            let mut v21: bool = interned_accepts_33(v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v8, v20.clone());
            let mut v23: i32 = if v21 {
                let mut v22: i32 = v16.wrapping_add(1i32);
                v22
            } else {
                v16
            };
            let mut v24: i32 = v9.wrapping_add(1i32);
            (v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10) = (v0.clone(), v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone(), v7, v8, v24, v23);
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 200i32;
    let mut v1: i32 = 32i32;
    let mut v2: US0 = US0::US0_0;
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_2(v2.clone()));
    let mut v4: US0 = US0::US0_1;
    let mut v5: Rc<UH0> = Rc::new(UH0::UH0_2(v4.clone()));
    let mut v6: Rc<UH0> = Rc::new(UH0::UH0_3(v3.clone(), v5.clone()));
    let mut v7: Rc<UH0> = Rc::new(UH0::UH0_5(v6.clone()));
    let mut v8: US0 = US0::US0_0;
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_2(v8.clone()));
    let mut v10: Rc<UH0> = Rc::new(UH0::UH0_4(v7.clone(), v9.clone()));
    let mut v11: US0 = US0::US0_0;
    let mut v12: Rc<UH0> = Rc::new(UH0::UH0_2(v11.clone()));
    let mut v13: US0 = US0::US0_1;
    let mut v14: Rc<UH0> = Rc::new(UH0::UH0_2(v13.clone()));
    let mut v15: Rc<UH0> = Rc::new(UH0::UH0_3(v12.clone(), v14.clone()));
    let mut v16: Rc<UH0> = Rc::new(UH0::UH0_5(v15.clone()));
    let mut v17: US0 = US0::US0_1;
    let mut v18: Rc<UH0> = Rc::new(UH0::UH0_2(v17.clone()));
    let mut v19: US0 = US0::US0_0;
    let mut v20: Rc<UH0> = Rc::new(UH0::UH0_2(v19.clone()));
    let mut v21: US0 = US0::US0_1;
    let mut v22: Rc<UH0> = Rc::new(UH0::UH0_2(v21.clone()));
    let mut v23: Rc<UH0> = Rc::new(UH0::UH0_3(v20.clone(), v22.clone()));
    let mut v24: US0 = US0::US0_0;
    let mut v25: Rc<UH0> = Rc::new(UH0::UH0_2(v24.clone()));
    let mut v26: US0 = US0::US0_1;
    let mut v27: Rc<UH0> = Rc::new(UH0::UH0_2(v26.clone()));
    let mut v28: Rc<UH0> = Rc::new(UH0::UH0_3(v25.clone(), v27.clone()));
    let mut v29: US0 = US0::US0_0;
    let mut v30: Rc<UH0> = Rc::new(UH0::UH0_2(v29.clone()));
    let mut v31: US0 = US0::US0_1;
    let mut v32: Rc<UH0> = Rc::new(UH0::UH0_2(v31.clone()));
    let mut v33: Rc<UH0> = Rc::new(UH0::UH0_3(v30.clone(), v32.clone()));
    let mut v34: Rc<UH0> = Rc::new(UH0::UH0_4(v28.clone(), v33.clone()));
    let mut v35: Rc<UH0> = Rc::new(UH0::UH0_4(v23.clone(), v34.clone()));
    let mut v36: Rc<UH0> = Rc::new(UH0::UH0_4(v18.clone(), v35.clone()));
    let mut v37: Rc<UH0> = Rc::new(UH0::UH0_4(v16.clone(), v36.clone()));
    let mut v38: u64 = 1u64;
    let mut v39: i32 = 0i32;
    let mut v40: i32 = loop_0(v10.clone(), v1, v0, v38, v39);
    let mut v41: i32 = loop_0(v37.clone(), v1, v0, v38, v39);
    let mut v42: i32 = 16i32;
    let mut v43: US0 = US0::US0_0;
    let mut v44: Rc<UH0> = Rc::new(UH0::UH0_2(v43.clone()));
    let mut v45: US0 = US0::US0_0;
    let mut v46: Rc<UH0> = Rc::new(UH0::UH0_2(v45.clone()));
    let mut v47: US0 = US0::US0_0;
    let mut v48: Rc<UH0> = Rc::new(UH0::UH0_2(v47.clone()));
    let mut v49: Rc<UH0> = Rc::new(UH0::UH0_4(v46.clone(), v48.clone()));
    let mut v50: Rc<UH0> = Rc::new(UH0::UH0_3(v44.clone(), v49.clone()));
    let mut v51: Rc<UH0> = Rc::new(UH0::UH0_5(v50.clone()));
    let mut v52: US0 = US0::US0_1;
    let mut v53: Rc<UH0> = Rc::new(UH0::UH0_2(v52.clone()));
    let mut v54: Rc<UH0> = Rc::new(UH0::UH0_4(v51.clone(), v53.clone()));
    let mut v55: i32 = 0i32;
    let mut v56: i32 = 1i32;
    let mut v57: i32 = loop_13(v54.clone(), v42, v56, v55);
    let mut v58: i32 = 200i32;
    let mut v59: i32 = 32i32;
    let mut v60: US0 = US0::US0_0;
    let mut v61: Rc<UH0> = Rc::new(UH0::UH0_2(v60.clone()));
    let mut v62: US0 = US0::US0_1;
    let mut v63: Rc<UH0> = Rc::new(UH0::UH0_2(v62.clone()));
    let mut v64: Rc<UH0> = Rc::new(UH0::UH0_3(v61.clone(), v63.clone()));
    let mut v65: Rc<UH0> = Rc::new(UH0::UH0_5(v64.clone()));
    let mut v66: US0 = US0::US0_0;
    let mut v67: Rc<UH0> = Rc::new(UH0::UH0_2(v66.clone()));
    let mut v68: Rc<UH0> = Rc::new(UH0::UH0_4(v65.clone(), v67.clone()));
    let mut v69: US0 = US0::US0_0;
    let mut v70: Rc<UH0> = Rc::new(UH0::UH0_2(v69.clone()));
    let mut v71: US0 = US0::US0_1;
    let mut v72: Rc<UH0> = Rc::new(UH0::UH0_2(v71.clone()));
    let mut v73: Rc<UH0> = Rc::new(UH0::UH0_3(v70.clone(), v72.clone()));
    let mut v74: Rc<UH0> = Rc::new(UH0::UH0_5(v73.clone()));
    let mut v75: US0 = US0::US0_1;
    let mut v76: Rc<UH0> = Rc::new(UH0::UH0_2(v75.clone()));
    let mut v77: US0 = US0::US0_0;
    let mut v78: Rc<UH0> = Rc::new(UH0::UH0_2(v77.clone()));
    let mut v79: US0 = US0::US0_1;
    let mut v80: Rc<UH0> = Rc::new(UH0::UH0_2(v79.clone()));
    let mut v81: Rc<UH0> = Rc::new(UH0::UH0_3(v78.clone(), v80.clone()));
    let mut v82: US0 = US0::US0_0;
    let mut v83: Rc<UH0> = Rc::new(UH0::UH0_2(v82.clone()));
    let mut v84: US0 = US0::US0_1;
    let mut v85: Rc<UH0> = Rc::new(UH0::UH0_2(v84.clone()));
    let mut v86: Rc<UH0> = Rc::new(UH0::UH0_3(v83.clone(), v85.clone()));
    let mut v87: US0 = US0::US0_0;
    let mut v88: Rc<UH0> = Rc::new(UH0::UH0_2(v87.clone()));
    let mut v89: US0 = US0::US0_1;
    let mut v90: Rc<UH0> = Rc::new(UH0::UH0_2(v89.clone()));
    let mut v91: Rc<UH0> = Rc::new(UH0::UH0_3(v88.clone(), v90.clone()));
    let mut v92: Rc<UH0> = Rc::new(UH0::UH0_4(v86.clone(), v91.clone()));
    let mut v93: Rc<UH0> = Rc::new(UH0::UH0_4(v81.clone(), v92.clone()));
    let mut v94: Rc<UH0> = Rc::new(UH0::UH0_4(v76.clone(), v93.clone()));
    let mut v95: Rc<UH0> = Rc::new(UH0::UH0_4(v74.clone(), v94.clone()));
    let mut v96: u64 = 1u64;
    let mut v97: i32 = 0i32;
    let mut v98: i32 = loop_15(v68.clone(), v59, v58, v96, v97);
    let mut v99: i32 = loop_15(v95.clone(), v59, v58, v96, v97);
    let mut v100: i32 = 16i32;
    let mut v101: US0 = US0::US0_0;
    let mut v102: Rc<UH0> = Rc::new(UH0::UH0_2(v101.clone()));
    let mut v103: US0 = US0::US0_0;
    let mut v104: Rc<UH0> = Rc::new(UH0::UH0_2(v103.clone()));
    let mut v105: US0 = US0::US0_0;
    let mut v106: Rc<UH0> = Rc::new(UH0::UH0_2(v105.clone()));
    let mut v107: Rc<UH0> = Rc::new(UH0::UH0_4(v104.clone(), v106.clone()));
    let mut v108: Rc<UH0> = Rc::new(UH0::UH0_3(v102.clone(), v107.clone()));
    let mut v109: Rc<UH0> = Rc::new(UH0::UH0_5(v108.clone()));
    let mut v110: US0 = US0::US0_1;
    let mut v111: Rc<UH0> = Rc::new(UH0::UH0_2(v110.clone()));
    let mut v112: Rc<UH0> = Rc::new(UH0::UH0_4(v109.clone(), v111.clone()));
    let mut v113: i32 = 0i32;
    let mut v114: i32 = 1i32;
    let mut v115: i32 = loop_17(v112.clone(), v100, v114, v113);
    let mut v116: bool = v40 == v98;
    let mut v118: bool = if v116 {
        let mut v117: bool = v41 == v99;
        v117
    } else {
        false
    };
    let mut v120: bool = if v118 {
        let mut v119: bool = v57 == v115;
        v119
    } else {
        false
    };
    if v120 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-engines-disagree"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v121: i32 = 200i32;
    let mut v122: i32 = 32i32;
    let mut v123: u64 = 1u64;
    let mut v124: i32 = 0i32;
    let mut v125: i32 = loop_18(v122, v121, v123, v124);
    let mut v126: i32 = loop_20(v122, v121, v123, v124);
    let mut v127: i32 = 16i32;
    let mut v128: i32 = 0i32;
    let mut v129: i32 = 1i32;
    let mut v130: i32 = loop_22(v127, v129, v128);
    let mut v131: bool = v40 == v125;
    let mut v133: bool = if v131 {
        let mut v132: bool = v41 == v126;
        v132
    } else {
        false
    };
    let mut v135: bool = if v133 {
        let mut v134: bool = v57 == v130;
        v134
    } else {
        false
    };
    if v135 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-engines-disagree"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v136: i32 = 200i32;
    let mut v137: i32 = 32i32;
    let mut v138: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v139: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v140: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v141: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v142: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 8192i32 as usize]));
    let mut v143: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 8192i32 as usize]));
    let mut v144: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 1i32 as usize]));
    let mut v145: i32 = 0i32;
    loop_24(v142.clone(), v145);
    let mut v146: i32 = 0i32;
    loop_24(v143.clone(), v146);
    let mut v147: i32 = 0i32;
    loop_25(v144.clone(), v147);
    let mut v148: i32 = 0i32;
    let mut v149: i32 = 0i32;
    let mut v150: i32 = 0i32;
    let mut v151: i32 = interned_node_26(v138.clone(), v139.clone(), v140.clone(), v141.clone(), v142.clone(), v143.clone(), v144.clone(), v148, v149, v150);
    let mut v152: i32 = 1i32;
    let mut v153: i32 = 0i32;
    let mut v154: i32 = 0i32;
    let mut v155: i32 = interned_node_26(v138.clone(), v139.clone(), v140.clone(), v141.clone(), v142.clone(), v143.clone(), v144.clone(), v152, v153, v154);
    let mut v156: bool = v151 == 0i32;
    let mut v158: bool = if v156 {
        let mut v157: bool = v155 == 1i32;
        v157
    } else {
        false
    };
    let (mut v166, mut v167, mut v168, mut v169, mut v170, mut v171, mut v172): (Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>) = if v158 {
        (v138.clone(), v139.clone(), v140.clone(), v141.clone(), v142.clone(), v143.clone(), v144.clone())
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-interned-store-init"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v173: US0 = US0::US0_0;
    let mut v174: Rc<UH0> = Rc::new(UH0::UH0_2(v173.clone()));
    let mut v175: US0 = US0::US0_1;
    let mut v176: Rc<UH0> = Rc::new(UH0::UH0_2(v175.clone()));
    let mut v177: Rc<UH0> = Rc::new(UH0::UH0_3(v174.clone(), v176.clone()));
    let mut v178: Rc<UH0> = Rc::new(UH0::UH0_5(v177.clone()));
    let mut v179: US0 = US0::US0_0;
    let mut v180: Rc<UH0> = Rc::new(UH0::UH0_2(v179.clone()));
    let mut v181: Rc<UH0> = Rc::new(UH0::UH0_4(v178.clone(), v180.clone()));
    let mut v182: i32 = interned_of_regex_raw_28(v166.clone(), v167.clone(), v168.clone(), v169.clone(), v170.clone(), v171.clone(), v172.clone(), v181.clone());
    let mut v183: u64 = 1u64;
    let mut v184: i32 = 0i32;
    let mut v185: i32 = loop_32(v166.clone(), v167.clone(), v168.clone(), v169.clone(), v170.clone(), v171.clone(), v172.clone(), v137, v182, v136, v183, v184);
    let mut v186: US0 = US0::US0_0;
    let mut v187: Rc<UH0> = Rc::new(UH0::UH0_2(v186.clone()));
    let mut v188: US0 = US0::US0_1;
    let mut v189: Rc<UH0> = Rc::new(UH0::UH0_2(v188.clone()));
    let mut v190: Rc<UH0> = Rc::new(UH0::UH0_3(v187.clone(), v189.clone()));
    let mut v191: Rc<UH0> = Rc::new(UH0::UH0_5(v190.clone()));
    let mut v192: US0 = US0::US0_1;
    let mut v193: Rc<UH0> = Rc::new(UH0::UH0_2(v192.clone()));
    let mut v194: US0 = US0::US0_0;
    let mut v195: Rc<UH0> = Rc::new(UH0::UH0_2(v194.clone()));
    let mut v196: US0 = US0::US0_1;
    let mut v197: Rc<UH0> = Rc::new(UH0::UH0_2(v196.clone()));
    let mut v198: Rc<UH0> = Rc::new(UH0::UH0_3(v195.clone(), v197.clone()));
    let mut v199: US0 = US0::US0_0;
    let mut v200: Rc<UH0> = Rc::new(UH0::UH0_2(v199.clone()));
    let mut v201: US0 = US0::US0_1;
    let mut v202: Rc<UH0> = Rc::new(UH0::UH0_2(v201.clone()));
    let mut v203: Rc<UH0> = Rc::new(UH0::UH0_3(v200.clone(), v202.clone()));
    let mut v204: US0 = US0::US0_0;
    let mut v205: Rc<UH0> = Rc::new(UH0::UH0_2(v204.clone()));
    let mut v206: US0 = US0::US0_1;
    let mut v207: Rc<UH0> = Rc::new(UH0::UH0_2(v206.clone()));
    let mut v208: Rc<UH0> = Rc::new(UH0::UH0_3(v205.clone(), v207.clone()));
    let mut v209: Rc<UH0> = Rc::new(UH0::UH0_4(v203.clone(), v208.clone()));
    let mut v210: Rc<UH0> = Rc::new(UH0::UH0_4(v198.clone(), v209.clone()));
    let mut v211: Rc<UH0> = Rc::new(UH0::UH0_4(v193.clone(), v210.clone()));
    let mut v212: Rc<UH0> = Rc::new(UH0::UH0_4(v191.clone(), v211.clone()));
    let mut v213: i32 = interned_of_regex_raw_28(v166.clone(), v167.clone(), v168.clone(), v169.clone(), v170.clone(), v171.clone(), v172.clone(), v212.clone());
    let mut v214: u64 = 1u64;
    let mut v215: i32 = 0i32;
    let mut v216: i32 = loop_32(v166.clone(), v167.clone(), v168.clone(), v169.clone(), v170.clone(), v171.clone(), v172.clone(), v137, v213, v136, v214, v215);
    let mut v217: i32 = 16i32;
    let mut v218: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v219: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v220: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v221: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4096i32 as usize]));
    let mut v222: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 8192i32 as usize]));
    let mut v223: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 8192i32 as usize]));
    let mut v224: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 1i32 as usize]));
    let mut v225: i32 = 0i32;
    loop_24(v222.clone(), v225);
    let mut v226: i32 = 0i32;
    loop_24(v223.clone(), v226);
    let mut v227: i32 = 0i32;
    loop_25(v224.clone(), v227);
    let mut v228: i32 = 0i32;
    let mut v229: i32 = 0i32;
    let mut v230: i32 = 0i32;
    let mut v231: i32 = interned_node_26(v218.clone(), v219.clone(), v220.clone(), v221.clone(), v222.clone(), v223.clone(), v224.clone(), v228, v229, v230);
    let mut v232: i32 = 1i32;
    let mut v233: i32 = 0i32;
    let mut v234: i32 = 0i32;
    let mut v235: i32 = interned_node_26(v218.clone(), v219.clone(), v220.clone(), v221.clone(), v222.clone(), v223.clone(), v224.clone(), v232, v233, v234);
    let mut v236: bool = v231 == 0i32;
    let mut v238: bool = if v236 {
        let mut v237: bool = v235 == 1i32;
        v237
    } else {
        false
    };
    let (mut v246, mut v247, mut v248, mut v249, mut v250, mut v251, mut v252): (Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>, Rc<RefCell<Vec<i32>>>) = if v238 {
        (v218.clone(), v219.clone(), v220.clone(), v221.clone(), v222.clone(), v223.clone(), v224.clone())
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-interned-store-init"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v253: US0 = US0::US0_0;
    let mut v254: Rc<UH0> = Rc::new(UH0::UH0_2(v253.clone()));
    let mut v255: US0 = US0::US0_0;
    let mut v256: Rc<UH0> = Rc::new(UH0::UH0_2(v255.clone()));
    let mut v257: US0 = US0::US0_0;
    let mut v258: Rc<UH0> = Rc::new(UH0::UH0_2(v257.clone()));
    let mut v259: Rc<UH0> = Rc::new(UH0::UH0_4(v256.clone(), v258.clone()));
    let mut v260: Rc<UH0> = Rc::new(UH0::UH0_3(v254.clone(), v259.clone()));
    let mut v261: Rc<UH0> = Rc::new(UH0::UH0_5(v260.clone()));
    let mut v262: US0 = US0::US0_1;
    let mut v263: Rc<UH0> = Rc::new(UH0::UH0_2(v262.clone()));
    let mut v264: Rc<UH0> = Rc::new(UH0::UH0_4(v261.clone(), v263.clone()));
    let mut v265: i32 = interned_of_regex_raw_28(v246.clone(), v247.clone(), v248.clone(), v249.clone(), v250.clone(), v251.clone(), v252.clone(), v264.clone());
    let mut v266: i32 = 1i32;
    let mut v267: i32 = 0i32;
    let mut v268: i32 = loop_36(v246.clone(), v247.clone(), v248.clone(), v249.clone(), v250.clone(), v251.clone(), v252.clone(), v217, v265, v266, v267);
    let mut v269: bool = v40 == v185;
    let mut v271: bool = if v269 {
        let mut v270: bool = v41 == v216;
        v270
    } else {
        false
    };
    let mut v273: bool = if v271 {
        let mut v272: bool = v57 == v268;
        v272
    } else {
        false
    };
    if v273 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-engines-disagree"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v274: bool = v57 == 16i32;
    if v274 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-zero-runs-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v275: bool = v40 == 93i32;
    if v275 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-ends-with-zero-count"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v276: bool = v41 == 97i32;
    if v276 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-bench-fourth-from-end-count"); } LIT.with(|lit| lit.clone()) }))
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
