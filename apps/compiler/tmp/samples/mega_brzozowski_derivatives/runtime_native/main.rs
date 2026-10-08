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
enum UH1 {
    UH1_0,
    UH1_1(US1, Rc<UH1>),
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
enum UH2 {
    UH2_0,
    UH2_1,
    UH2_2(US0),
    UH2_3(Rc<UH2>, Rc<UH2>),
    UH2_4(Rc<UH2>, Rc<UH2>),
    UH2_5(Rc<UH2>),
}
impl UH2 {
    fn tag(&self) -> i32 {
        match self {
            UH2::UH2_0 => 0,
            UH2::UH2_1 => 1,
            UH2::UH2_2(..) => 2,
            UH2::UH2_3(..) => 3,
            UH2::UH2_4(..) => 4,
            UH2::UH2_5(..) => 5,
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
enum US3 {
    US3_0,
    US3_1,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_0 => 0,
            US3::US3_1 => 1,
        }
    }
}
#[derive(Clone)]
enum UH3 {
    UH3_0,
    UH3_1,
    UH3_2(US1),
    UH3_3(Rc<UH3>, Rc<UH3>),
    UH3_4(Rc<UH3>, Rc<UH3>),
    UH3_5(Rc<UH3>),
}
impl UH3 {
    fn tag(&self) -> i32 {
        match self {
            UH3::UH3_0 => 0,
            UH3::UH3_1 => 1,
            UH3::UH3_2(..) => 2,
            UH3::UH3_3(..) => 3,
            UH3::UH3_4(..) => 4,
            UH3::UH3_5(..) => 5,
        }
    }
}
#[derive(Clone)]
enum US4 {
    US4_0(Rc<UH2>, Rc<UH0>),
}
impl US4 {
    fn tag(&self) -> i32 {
        match self {
            US4::US4_0(..) => 0,
        }
    }
}
#[derive(Clone)]
enum US5 {
    US5_1(Rc<UH2>, Rc<UH0>, bool),
}
impl US5 {
    fn tag(&self) -> i32 {
        match self {
            US5::US5_1(..) => 1,
        }
    }
}
fn method5(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US2 {
    loop {
        match &*v0 {
            UH2::UH2_3(v53, v54) => {
                let mut v53: Rc<UH2> = v53.clone();
                let mut v54: Rc<UH2> = v54.clone();
                match &*v1 {
                    UH2::UH2_3(v55, v56) => {
                        let mut v55: Rc<UH2> = v55.clone();
                        let mut v56: Rc<UH2> = v56.clone();
                        let mut v57: US2 = method5(v53.clone(), v55.clone());
                        match &v57 {
                            US2::US2_1 => {
                                (v0, v1) = (v54.clone(), v56.clone());
                                continue;
                            }
                            _ => {
                                return v57.clone();
                            }
                        }
                    }
                    _ => {
                        return US2::US2_2;
                    }
                }
            }
            UH2::UH2_4(v28, v29) => {
                let mut v28: Rc<UH2> = v28.clone();
                let mut v29: Rc<UH2> = v29.clone();
                match &*v1 {
                    UH2::UH2_4(v34, v35) => {
                        let mut v34: Rc<UH2> = v34.clone();
                        let mut v35: Rc<UH2> = v35.clone();
                        let mut v36: US2 = method5(v28.clone(), v34.clone());
                        match &v36 {
                            US2::US2_1 => {
                                (v0, v1) = (v29.clone(), v35.clone());
                                continue;
                            }
                            _ => {
                                return v36.clone();
                            }
                        }
                    }
                    UH2::UH2_2(v32) => {
                        let mut v32: US0 = v32.clone();
                        return US2::US2_2;
                    }
                    UH2::UH2_0 => {
                        return US2::US2_2;
                    }
                    UH2::UH2_1 => {
                        return US2::US2_2;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH2::UH2_2(v10) => {
                let mut v10: US0 = v10.clone();
                match &*v1 {
                    UH2::UH2_2(v13) => {
                        let mut v13: US0 = v13.clone();
                        match &v10 {
                            US0::US0_1 => {
                                match &v13 {
                                    US0::US0_1 => {
                                        return US2::US2_1;
                                    }
                                    US0::US0_0 => {
                                        return US2::US2_2;
                                    }
                                }
                            }
                            US0::US0_0 => {
                                match &v13 {
                                    US0::US0_1 => {
                                        return US2::US2_0;
                                    }
                                    US0::US0_0 => {
                                        return US2::US2_1;
                                    }
                                }
                            }
                        }
                    }
                    UH2::UH2_0 => {
                        return US2::US2_2;
                    }
                    UH2::UH2_1 => {
                        return US2::US2_2;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH2::UH2_0 => {
                match &*v1 {
                    UH2::UH2_0 => {
                        return US2::US2_1;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH2::UH2_1 => {
                match &*v1 {
                    UH2::UH2_0 => {
                        return US2::US2_2;
                    }
                    UH2::UH2_1 => {
                        return US2::US2_1;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH2::UH2_5(v44) => {
                let mut v44: Rc<UH2> = v44.clone();
                match &*v1 {
                    UH2::UH2_3(v45, v46) => {
                        let mut v45: Rc<UH2> = v45.clone();
                        let mut v46: Rc<UH2> = v46.clone();
                        return US2::US2_0;
                    }
                    UH2::UH2_5(v48) => {
                        let mut v48: Rc<UH2> = v48.clone();
                        (v0, v1) = (v44.clone(), v48.clone());
                        continue;
                    }
                    _ => {
                        return US2::US2_2;
                    }
                }
            }
        }
    }
}
fn method4(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v1 {
        UH2::UH2_3(v2, v3) => {
            let mut v2: Rc<UH2> = v2.clone();
            let mut v3: Rc<UH2> = v3.clone();
            let mut v4: US2 = method5(v0.clone(), v2.clone());
            match &v4 {
                US2::US2_2 => {
                    let mut v6: Rc<UH2> = method4(v0.clone(), v3.clone());
                    Rc::new(UH2::UH2_3(v2.clone(), v6.clone()))
                }
                US2::US2_0 => {
                    Rc::new(UH2::UH2_3(v0.clone(), v1.clone()))
                }
                US2::US2_1 => {
                    v1.clone()
                }
            }
        }
        UH2::UH2_0 => {
            v0.clone()
        }
        _ => {
            let mut v11: US2 = method5(v0.clone(), v1.clone());
            match &v11 {
                US2::US2_2 => {
                    Rc::new(UH2::UH2_3(v1.clone(), v0.clone()))
                }
                US2::US2_0 => {
                    Rc::new(UH2::UH2_3(v0.clone(), v1.clone()))
                }
                US2::US2_1 => {
                    v1.clone()
                }
            }
        }
    }
}
fn method3(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match &*v0 {
            UH2::UH2_3(v2, v3) => {
                let mut v2: Rc<UH2> = v2.clone();
                let mut v3: Rc<UH2> = v3.clone();
                let mut v4: Rc<UH2> = method4(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH2::UH2_0 => {
                return v1.clone();
            }
            _ => {
                return method4(v0.clone(), v1.clone());
            }
        }
    }
}
fn method7(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> bool {
    loop {
        match &*v0 {
            UH2::UH2_3(v18, v19) => {
                let mut v18: Rc<UH2> = v18.clone();
                let mut v19: Rc<UH2> = v19.clone();
                match &*v1 {
                    UH2::UH2_3(v20, v21) => {
                        let mut v20: Rc<UH2> = v20.clone();
                        let mut v21: Rc<UH2> = v21.clone();
                        let mut v22: bool = method7(v18.clone(), v20.clone());
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
            UH2::UH2_4(v26, v27) => {
                let mut v26: Rc<UH2> = v26.clone();
                let mut v27: Rc<UH2> = v27.clone();
                match &*v1 {
                    UH2::UH2_4(v28, v29) => {
                        let mut v28: Rc<UH2> = v28.clone();
                        let mut v29: Rc<UH2> = v29.clone();
                        let mut v30: bool = method7(v26.clone(), v28.clone());
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
            UH2::UH2_2(v4) => {
                let mut v4: US0 = v4.clone();
                match &*v1 {
                    UH2::UH2_2(v5) => {
                        let mut v5: US0 = v5.clone();
                        let mut v15: US2 = match &v4 {
                            US0::US0_1 => {
                                match &v5 {
                                    US0::US0_1 => {
                                        US2::US2_1
                                    }
                                    US0::US0_0 => {
                                        US2::US2_2
                                    }
                                }
                            }
                            US0::US0_0 => {
                                match &v5 {
                                    US0::US0_1 => {
                                        US2::US2_0
                                    }
                                    US0::US0_0 => {
                                        US2::US2_1
                                    }
                                }
                            }
                        };
                        match &v15 {
                            US2::US2_1 => {
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
            UH2::UH2_0 => {
                match &*v1 {
                    UH2::UH2_0 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_1 => {
                match &*v1 {
                    UH2::UH2_1 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH2::UH2_5(v34) => {
                let mut v34: Rc<UH2> = v34.clone();
                match &*v1 {
                    UH2::UH2_5(v35) => {
                        let mut v35: Rc<UH2> = v35.clone();
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
fn method6(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_0 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH2::UH2_0 => {
                    { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH2::UH2_1 => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH2::UH2_1 => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH2::UH2_4(v12, v13) => {
                                            let mut v12: Rc<UH2> = v12.clone();
                                            let mut v13: Rc<UH2> = v13.clone();
                                            let mut v14: Rc<UH2> = method6(v13.clone(), v1.clone());
                                            Rc::new(UH2::UH2_4(v12.clone(), v14.clone()))
                                        }
                                        UH2::UH2_5(v4) => {
                                            let mut v4: Rc<UH2> = v4.clone();
                                            match &*v1 {
                                                UH2::UH2_5(v5) => {
                                                    let mut v5: Rc<UH2> = v5.clone();
                                                    let mut v6: bool = method7(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH2::UH2_5(v4.clone()))
                                                    } else {
                                                        Rc::new(UH2::UH2_4(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH2::UH2_4(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH2::UH2_4(v0.clone(), v1.clone()))
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
fn method8(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_0 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_1); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_1 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_1); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_5(v3) => {
            let mut v3: Rc<UH2> = v3.clone();
            Rc::new(UH2::UH2_5(v3.clone()))
        }
        _ => {
            Rc::new(UH2::UH2_5(v0.clone()))
        }
    }
}
fn method2(mut v0: Rc<UH2>) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_3(v5, v6) => {
            let mut v5: Rc<UH2> = v5.clone();
            let mut v6: Rc<UH2> = v6.clone();
            let mut v7: Rc<UH2> = method2(v5.clone());
            let mut v8: Rc<UH2> = method2(v6.clone());
            method3(v7.clone(), v8.clone())
        }
        UH2::UH2_4(v10, v11) => {
            let mut v10: Rc<UH2> = v10.clone();
            let mut v11: Rc<UH2> = v11.clone();
            let mut v12: Rc<UH2> = method2(v10.clone());
            let mut v13: Rc<UH2> = method2(v11.clone());
            method6(v12.clone(), v13.clone())
        }
        UH2::UH2_2(v3) => {
            let mut v3: US0 = v3.clone();
            Rc::new(UH2::UH2_2(v3.clone()))
        }
        UH2::UH2_0 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_1 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_1); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_5(v15) => {
            let mut v15: Rc<UH2> = v15.clone();
            let mut v16: Rc<UH2> = method2(v15.clone());
            method8(v16.clone())
        }
    }
}
fn method10(mut v0: Rc<UH2>) -> US3 {
    match &*v0 {
        UH2::UH2_3(v5, v6) => {
            let mut v5: Rc<UH2> = v5.clone();
            let mut v6: Rc<UH2> = v6.clone();
            let mut v7: US3 = method10(v5.clone());
            let mut v8: US3 = method10(v6.clone());
            match &v7 {
                US3::US3_0 => {
                    US3::US3_0
                }
                _ => {
                    match &v8 {
                        US3::US3_0 => {
                            US3::US3_0
                        }
                        _ => {
                            match &v7 {
                                US3::US3_1 => {
                                    match &v8 {
                                        US3::US3_1 => {
                                            US3::US3_1
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
        UH2::UH2_4(v16, v17) => {
            let mut v16: Rc<UH2> = v16.clone();
            let mut v17: Rc<UH2> = v17.clone();
            let mut v18: US3 = method10(v16.clone());
            let mut v19: US3 = method10(v17.clone());
            match &v18 {
                US3::US3_0 => {
                    match &v19 {
                        US3::US3_0 => {
                            US3::US3_0
                        }
                        _ => {
                            US3::US3_1
                        }
                    }
                }
                _ => {
                    US3::US3_1
                }
            }
        }
        UH2::UH2_2(v3) => {
            let mut v3: US0 = v3.clone();
            US3::US3_1
        }
        UH2::UH2_0 => {
            US3::US3_1
        }
        UH2::UH2_1 => {
            US3::US3_0
        }
        UH2::UH2_5(v25) => {
            let mut v25: Rc<UH2> = v25.clone();
            US3::US3_0
        }
    }
}
fn method9(mut v0: Rc<UH2>, mut v1: US0) -> Rc<UH2> {
    match &*v0 {
        UH2::UH2_3(v19, v20) => {
            let mut v19: Rc<UH2> = v19.clone();
            let mut v20: Rc<UH2> = v20.clone();
            let mut v21: Rc<UH2> = method9(v19.clone(), v1.clone());
            let mut v22: Rc<UH2> = method9(v20.clone(), v1.clone());
            method3(v21.clone(), v22.clone())
        }
        UH2::UH2_4(v24, v25) => {
            let mut v24: Rc<UH2> = v24.clone();
            let mut v25: Rc<UH2> = v25.clone();
            let mut v26: US3 = method10(v24.clone());
            match &v26 {
                US3::US3_1 => {
                    let mut v31: Rc<UH2> = method9(v24.clone(), v1.clone());
                    method6(v31.clone(), v25.clone())
                }
                US3::US3_0 => {
                    let mut v27: Rc<UH2> = method9(v24.clone(), v1.clone());
                    let mut v28: Rc<UH2> = method6(v27.clone(), v25.clone());
                    let mut v29: Rc<UH2> = method9(v25.clone(), v1.clone());
                    method3(v28.clone(), v29.clone())
                }
            }
        }
        UH2::UH2_2(v4) => {
            let mut v4: US0 = v4.clone();
            let mut v14: US2 = match &v4 {
                US0::US0_1 => {
                    match &v1 {
                        US0::US0_1 => {
                            US2::US2_1
                        }
                        US0::US0_0 => {
                            US2::US2_2
                        }
                    }
                }
                US0::US0_0 => {
                    match &v1 {
                        US0::US0_1 => {
                            US2::US2_0
                        }
                        US0::US0_0 => {
                            US2::US2_1
                        }
                    }
                }
            };
            let mut v15: bool = match &v14 {
                US2::US2_1 => {
                    true
                }
                _ => {
                    false
                }
            };
            if v15 {
                { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_1); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
            }
        }
        UH2::UH2_0 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_1 => {
            { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_0); } CASE.with(|case| case.clone()) }
        }
        UH2::UH2_5(v35) => {
            let mut v35: Rc<UH2> = v35.clone();
            let mut v36: Rc<UH2> = method9(v35.clone(), v1.clone());
            let mut v37: Rc<UH2> = method8(v35.clone());
            method6(v36.clone(), v37.clone())
        }
    }
}
fn method1(mut v0: Rc<UH2>, mut v1: US0) -> Rc<UH2> {
    let mut v2: Rc<UH2> = method2(v0.clone());
    let mut v3: Rc<UH2> = method9(v2.clone(), v1.clone());
    method2(v3.clone())
}
fn method0(mut v0: Rc<UH2>, mut v1: Rc<UH0>) -> bool {
    loop {
        match &*v1 {
            UH0::UH0_1(v6, v7) => {
                let mut v6: US0 = v6.clone();
                let mut v7: Rc<UH0> = v7.clone();
                let mut v8: Rc<UH2> = method1(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH0::UH0_0 => {
                let mut v2: Rc<UH2> = method2(v0.clone());
                let mut v3: US3 = method10(v2.clone());
                match &v3 {
                    US3::US3_1 => {
                        return false;
                    }
                    US3::US3_0 => {
                        return true;
                    }
                }
            }
        }
    }
}
fn method16(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> US2 {
    loop {
        match &*v0 {
            UH3::UH3_3(v59, v60) => {
                let mut v59: Rc<UH3> = v59.clone();
                let mut v60: Rc<UH3> = v60.clone();
                match &*v1 {
                    UH3::UH3_3(v61, v62) => {
                        let mut v61: Rc<UH3> = v61.clone();
                        let mut v62: Rc<UH3> = v62.clone();
                        let mut v63: US2 = method16(v59.clone(), v61.clone());
                        match &v63 {
                            US2::US2_1 => {
                                (v0, v1) = (v60.clone(), v62.clone());
                                continue;
                            }
                            _ => {
                                return v63.clone();
                            }
                        }
                    }
                    _ => {
                        return US2::US2_2;
                    }
                }
            }
            UH3::UH3_4(v34, v35) => {
                let mut v34: Rc<UH3> = v34.clone();
                let mut v35: Rc<UH3> = v35.clone();
                match &*v1 {
                    UH3::UH3_4(v40, v41) => {
                        let mut v40: Rc<UH3> = v40.clone();
                        let mut v41: Rc<UH3> = v41.clone();
                        let mut v42: US2 = method16(v34.clone(), v40.clone());
                        match &v42 {
                            US2::US2_1 => {
                                (v0, v1) = (v35.clone(), v41.clone());
                                continue;
                            }
                            _ => {
                                return v42.clone();
                            }
                        }
                    }
                    UH3::UH3_2(v38) => {
                        let mut v38: US1 = v38.clone();
                        return US2::US2_2;
                    }
                    UH3::UH3_0 => {
                        return US2::US2_2;
                    }
                    UH3::UH3_1 => {
                        return US2::US2_2;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH3::UH3_2(v10) => {
                let mut v10: US1 = v10.clone();
                match &*v1 {
                    UH3::UH3_2(v13) => {
                        let mut v13: US1 = v13.clone();
                        match &v10 {
                            US1::US1_0 => {
                                match &v13 {
                                    US1::US1_0 => {
                                        return US2::US2_1;
                                    }
                                    _ => {
                                        return US2::US2_0;
                                    }
                                }
                            }
                            _ => {
                                match &v13 {
                                    US1::US1_0 => {
                                        return US2::US2_2;
                                    }
                                    _ => {
                                        match &v10 {
                                            US1::US1_1 => {
                                                match &v13 {
                                                    US1::US1_1 => {
                                                        return US2::US2_1;
                                                    }
                                                    US1::US1_2 => {
                                                        return US2::US2_0;
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_2 => {
                                                match &v13 {
                                                    US1::US1_1 => {
                                                        return US2::US2_2;
                                                    }
                                                    US1::US1_2 => {
                                                        return US2::US2_1;
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
                    UH3::UH3_0 => {
                        return US2::US2_2;
                    }
                    UH3::UH3_1 => {
                        return US2::US2_2;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH3::UH3_0 => {
                match &*v1 {
                    UH3::UH3_0 => {
                        return US2::US2_1;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH3::UH3_1 => {
                match &*v1 {
                    UH3::UH3_0 => {
                        return US2::US2_2;
                    }
                    UH3::UH3_1 => {
                        return US2::US2_1;
                    }
                    _ => {
                        return US2::US2_0;
                    }
                }
            }
            UH3::UH3_5(v50) => {
                let mut v50: Rc<UH3> = v50.clone();
                match &*v1 {
                    UH3::UH3_3(v51, v52) => {
                        let mut v51: Rc<UH3> = v51.clone();
                        let mut v52: Rc<UH3> = v52.clone();
                        return US2::US2_0;
                    }
                    UH3::UH3_5(v54) => {
                        let mut v54: Rc<UH3> = v54.clone();
                        (v0, v1) = (v50.clone(), v54.clone());
                        continue;
                    }
                    _ => {
                        return US2::US2_2;
                    }
                }
            }
        }
    }
}
fn method15(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    match &*v1 {
        UH3::UH3_3(v2, v3) => {
            let mut v2: Rc<UH3> = v2.clone();
            let mut v3: Rc<UH3> = v3.clone();
            let mut v4: US2 = method16(v0.clone(), v2.clone());
            match &v4 {
                US2::US2_2 => {
                    let mut v6: Rc<UH3> = method15(v0.clone(), v3.clone());
                    Rc::new(UH3::UH3_3(v2.clone(), v6.clone()))
                }
                US2::US2_0 => {
                    Rc::new(UH3::UH3_3(v0.clone(), v1.clone()))
                }
                US2::US2_1 => {
                    v1.clone()
                }
            }
        }
        UH3::UH3_0 => {
            v0.clone()
        }
        _ => {
            let mut v11: US2 = method16(v0.clone(), v1.clone());
            match &v11 {
                US2::US2_2 => {
                    Rc::new(UH3::UH3_3(v1.clone(), v0.clone()))
                }
                US2::US2_0 => {
                    Rc::new(UH3::UH3_3(v0.clone(), v1.clone()))
                }
                US2::US2_1 => {
                    v1.clone()
                }
            }
        }
    }
}
fn method14(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    loop {
        match &*v0 {
            UH3::UH3_3(v2, v3) => {
                let mut v2: Rc<UH3> = v2.clone();
                let mut v3: Rc<UH3> = v3.clone();
                let mut v4: Rc<UH3> = method15(v2.clone(), v1.clone());
                (v0, v1) = (v3.clone(), v4.clone());
                continue;
            }
            UH3::UH3_0 => {
                return v1.clone();
            }
            _ => {
                return method15(v0.clone(), v1.clone());
            }
        }
    }
}
fn method18(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> bool {
    loop {
        match &*v0 {
            UH3::UH3_3(v24, v25) => {
                let mut v24: Rc<UH3> = v24.clone();
                let mut v25: Rc<UH3> = v25.clone();
                match &*v1 {
                    UH3::UH3_3(v26, v27) => {
                        let mut v26: Rc<UH3> = v26.clone();
                        let mut v27: Rc<UH3> = v27.clone();
                        let mut v28: bool = method18(v24.clone(), v26.clone());
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
            UH3::UH3_4(v32, v33) => {
                let mut v32: Rc<UH3> = v32.clone();
                let mut v33: Rc<UH3> = v33.clone();
                match &*v1 {
                    UH3::UH3_4(v34, v35) => {
                        let mut v34: Rc<UH3> = v34.clone();
                        let mut v35: Rc<UH3> = v35.clone();
                        let mut v36: bool = method18(v32.clone(), v34.clone());
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
            UH3::UH3_2(v4) => {
                let mut v4: US1 = v4.clone();
                match &*v1 {
                    UH3::UH3_2(v5) => {
                        let mut v5: US1 = v5.clone();
                        let mut v21: US2 = match &v4 {
                            US1::US1_0 => {
                                match &v5 {
                                    US1::US1_0 => {
                                        US2::US2_1
                                    }
                                    _ => {
                                        US2::US2_0
                                    }
                                }
                            }
                            _ => {
                                match &v5 {
                                    US1::US1_0 => {
                                        US2::US2_2
                                    }
                                    _ => {
                                        match &v4 {
                                            US1::US1_1 => {
                                                match &v5 {
                                                    US1::US1_1 => {
                                                        US2::US2_1
                                                    }
                                                    US1::US1_2 => {
                                                        US2::US2_0
                                                    }
                                                    _ => unreachable!(),
                                                }
                                            }
                                            US1::US1_2 => {
                                                match &v5 {
                                                    US1::US1_1 => {
                                                        US2::US2_2
                                                    }
                                                    US1::US1_2 => {
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
                        };
                        match &v21 {
                            US2::US2_1 => {
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
            UH3::UH3_0 => {
                match &*v1 {
                    UH3::UH3_0 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH3::UH3_1 => {
                match &*v1 {
                    UH3::UH3_1 => {
                        return true;
                    }
                    _ => {
                        return false;
                    }
                }
            }
            UH3::UH3_5(v40) => {
                let mut v40: Rc<UH3> = v40.clone();
                match &*v1 {
                    UH3::UH3_5(v41) => {
                        let mut v41: Rc<UH3> = v41.clone();
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
fn method17(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_0 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
        }
        _ => {
            match &*v1 {
                UH3::UH3_0 => {
                    { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
                }
                _ => {
                    match &*v0 {
                        UH3::UH3_1 => {
                            v1.clone()
                        }
                        _ => {
                            match &*v1 {
                                UH3::UH3_1 => {
                                    v0.clone()
                                }
                                _ => {
                                    match &*v0 {
                                        UH3::UH3_4(v12, v13) => {
                                            let mut v12: Rc<UH3> = v12.clone();
                                            let mut v13: Rc<UH3> = v13.clone();
                                            let mut v14: Rc<UH3> = method17(v13.clone(), v1.clone());
                                            Rc::new(UH3::UH3_4(v12.clone(), v14.clone()))
                                        }
                                        UH3::UH3_5(v4) => {
                                            let mut v4: Rc<UH3> = v4.clone();
                                            match &*v1 {
                                                UH3::UH3_5(v5) => {
                                                    let mut v5: Rc<UH3> = v5.clone();
                                                    let mut v6: bool = method18(v4.clone(), v5.clone());
                                                    if v6 {
                                                        Rc::new(UH3::UH3_5(v4.clone()))
                                                    } else {
                                                        Rc::new(UH3::UH3_4(v0.clone(), v1.clone()))
                                                    }
                                                }
                                                _ => {
                                                    Rc::new(UH3::UH3_4(v0.clone(), v1.clone()))
                                                }
                                            }
                                        }
                                        _ => {
                                            Rc::new(UH3::UH3_4(v0.clone(), v1.clone()))
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
fn method19(mut v0: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_0 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_1); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_1 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_1); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_5(v3) => {
            let mut v3: Rc<UH3> = v3.clone();
            Rc::new(UH3::UH3_5(v3.clone()))
        }
        _ => {
            Rc::new(UH3::UH3_5(v0.clone()))
        }
    }
}
fn method13(mut v0: Rc<UH3>) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_3(v5, v6) => {
            let mut v5: Rc<UH3> = v5.clone();
            let mut v6: Rc<UH3> = v6.clone();
            let mut v7: Rc<UH3> = method13(v5.clone());
            let mut v8: Rc<UH3> = method13(v6.clone());
            method14(v7.clone(), v8.clone())
        }
        UH3::UH3_4(v10, v11) => {
            let mut v10: Rc<UH3> = v10.clone();
            let mut v11: Rc<UH3> = v11.clone();
            let mut v12: Rc<UH3> = method13(v10.clone());
            let mut v13: Rc<UH3> = method13(v11.clone());
            method17(v12.clone(), v13.clone())
        }
        UH3::UH3_2(v3) => {
            let mut v3: US1 = v3.clone();
            Rc::new(UH3::UH3_2(v3.clone()))
        }
        UH3::UH3_0 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_1 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_1); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_5(v15) => {
            let mut v15: Rc<UH3> = v15.clone();
            let mut v16: Rc<UH3> = method13(v15.clone());
            method19(v16.clone())
        }
    }
}
fn method21(mut v0: Rc<UH3>) -> US3 {
    match &*v0 {
        UH3::UH3_3(v5, v6) => {
            let mut v5: Rc<UH3> = v5.clone();
            let mut v6: Rc<UH3> = v6.clone();
            let mut v7: US3 = method21(v5.clone());
            let mut v8: US3 = method21(v6.clone());
            match &v7 {
                US3::US3_0 => {
                    US3::US3_0
                }
                _ => {
                    match &v8 {
                        US3::US3_0 => {
                            US3::US3_0
                        }
                        _ => {
                            match &v7 {
                                US3::US3_1 => {
                                    match &v8 {
                                        US3::US3_1 => {
                                            US3::US3_1
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
        UH3::UH3_4(v16, v17) => {
            let mut v16: Rc<UH3> = v16.clone();
            let mut v17: Rc<UH3> = v17.clone();
            let mut v18: US3 = method21(v16.clone());
            let mut v19: US3 = method21(v17.clone());
            match &v18 {
                US3::US3_0 => {
                    match &v19 {
                        US3::US3_0 => {
                            US3::US3_0
                        }
                        _ => {
                            US3::US3_1
                        }
                    }
                }
                _ => {
                    US3::US3_1
                }
            }
        }
        UH3::UH3_2(v3) => {
            let mut v3: US1 = v3.clone();
            US3::US3_1
        }
        UH3::UH3_0 => {
            US3::US3_1
        }
        UH3::UH3_1 => {
            US3::US3_0
        }
        UH3::UH3_5(v25) => {
            let mut v25: Rc<UH3> = v25.clone();
            US3::US3_0
        }
    }
}
fn method20(mut v0: Rc<UH3>, mut v1: US1) -> Rc<UH3> {
    match &*v0 {
        UH3::UH3_3(v25, v26) => {
            let mut v25: Rc<UH3> = v25.clone();
            let mut v26: Rc<UH3> = v26.clone();
            let mut v27: Rc<UH3> = method20(v25.clone(), v1.clone());
            let mut v28: Rc<UH3> = method20(v26.clone(), v1.clone());
            method14(v27.clone(), v28.clone())
        }
        UH3::UH3_4(v30, v31) => {
            let mut v30: Rc<UH3> = v30.clone();
            let mut v31: Rc<UH3> = v31.clone();
            let mut v32: US3 = method21(v30.clone());
            match &v32 {
                US3::US3_1 => {
                    let mut v37: Rc<UH3> = method20(v30.clone(), v1.clone());
                    method17(v37.clone(), v31.clone())
                }
                US3::US3_0 => {
                    let mut v33: Rc<UH3> = method20(v30.clone(), v1.clone());
                    let mut v34: Rc<UH3> = method17(v33.clone(), v31.clone());
                    let mut v35: Rc<UH3> = method20(v31.clone(), v1.clone());
                    method14(v34.clone(), v35.clone())
                }
            }
        }
        UH3::UH3_2(v4) => {
            let mut v4: US1 = v4.clone();
            let mut v20: US2 = match &v4 {
                US1::US1_0 => {
                    match &v1 {
                        US1::US1_0 => {
                            US2::US2_1
                        }
                        _ => {
                            US2::US2_0
                        }
                    }
                }
                _ => {
                    match &v1 {
                        US1::US1_0 => {
                            US2::US2_2
                        }
                        _ => {
                            match &v4 {
                                US1::US1_1 => {
                                    match &v1 {
                                        US1::US1_1 => {
                                            US2::US2_1
                                        }
                                        US1::US1_2 => {
                                            US2::US2_0
                                        }
                                        _ => unreachable!(),
                                    }
                                }
                                US1::US1_2 => {
                                    match &v1 {
                                        US1::US1_1 => {
                                            US2::US2_2
                                        }
                                        US1::US1_2 => {
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
            };
            let mut v21: bool = match &v20 {
                US2::US2_1 => {
                    true
                }
                _ => {
                    false
                }
            };
            if v21 {
                { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_1); } CASE.with(|case| case.clone()) }
            } else {
                { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
            }
        }
        UH3::UH3_0 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_1 => {
            { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_0); } CASE.with(|case| case.clone()) }
        }
        UH3::UH3_5(v41) => {
            let mut v41: Rc<UH3> = v41.clone();
            let mut v42: Rc<UH3> = method20(v41.clone(), v1.clone());
            let mut v43: Rc<UH3> = method19(v41.clone());
            method17(v42.clone(), v43.clone())
        }
    }
}
fn method12(mut v0: Rc<UH3>, mut v1: US1) -> Rc<UH3> {
    let mut v2: Rc<UH3> = method13(v0.clone());
    let mut v3: Rc<UH3> = method20(v2.clone(), v1.clone());
    method13(v3.clone())
}
fn method11(mut v0: Rc<UH3>, mut v1: Rc<UH1>) -> bool {
    loop {
        match &*v1 {
            UH1::UH1_1(v6, v7) => {
                let mut v6: US1 = v6.clone();
                let mut v7: Rc<UH1> = v7.clone();
                let mut v8: Rc<UH3> = method12(v0.clone(), v6.clone());
                (v0, v1) = (v8.clone(), v7.clone());
                continue;
            }
            UH1::UH1_0 => {
                let mut v2: Rc<UH3> = method13(v0.clone());
                let mut v3: US3 = method21(v2.clone());
                match &v3 {
                    US3::US3_1 => {
                        return false;
                    }
                    US3::US3_0 => {
                        return true;
                    }
                }
            }
        }
    }
}
fn method22(mut v0: US4) -> US5 {
    match &v0 {
        US4::US4_0(v1, v2) => {
            let mut v1: Rc<UH2> = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: bool = method0(v1.clone(), v2.clone());
            US5::US5_1(v1.clone(), v2.clone(), v3)
        }
    }
}
fn method23(mut v0: US5) -> bool {
    match &v0 {
        US5::US5_1(v1, v2, v3) => {
            let mut v1: Rc<UH2> = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: bool = *v3;
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: US0 = US0::US0_1;
    let mut v1: US0 = US0::US0_1;
    let mut v2: US0 = US0::US0_0;
    let mut v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_1(v2.clone(), v3.clone()));
    let mut v5: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v4.clone()));
    let mut v6: Rc<UH0> = Rc::new(UH0::UH0_1(v0.clone(), v5.clone()));
    let mut v7: US0 = US0::US0_1;
    let mut v8: US0 = US0::US0_1;
    let mut v9: US0 = US0::US0_1;
    let mut v10: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v11: Rc<UH0> = Rc::new(UH0::UH0_1(v9.clone(), v10.clone()));
    let mut v12: Rc<UH0> = Rc::new(UH0::UH0_1(v8.clone(), v11.clone()));
    let mut v13: Rc<UH0> = Rc::new(UH0::UH0_1(v7.clone(), v12.clone()));
    let mut v14: US1 = US1::US1_0;
    let mut v15: US1 = US1::US1_0;
    let mut v16: US1 = US1::US1_0;
    let mut v17: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
    let mut v18: Rc<UH1> = Rc::new(UH1::UH1_1(v16.clone(), v17.clone()));
    let mut v19: Rc<UH1> = Rc::new(UH1::UH1_1(v15.clone(), v18.clone()));
    let mut v20: Rc<UH1> = Rc::new(UH1::UH1_1(v14.clone(), v19.clone()));
    let mut v21: US1 = US1::US1_0;
    let mut v22: US1 = US1::US1_0;
    let mut v23: US1 = US1::US1_1;
    let mut v24: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_0); } CASE.with(|case| case.clone()) };
    let mut v25: Rc<UH1> = Rc::new(UH1::UH1_1(v23.clone(), v24.clone()));
    let mut v26: Rc<UH1> = Rc::new(UH1::UH1_1(v22.clone(), v25.clone()));
    let mut v27: Rc<UH1> = Rc::new(UH1::UH1_1(v21.clone(), v26.clone()));
    let mut v28: US0 = US0::US0_0;
    let mut v29: Rc<UH2> = Rc::new(UH2::UH2_2(v28.clone()));
    let mut v30: US0 = US0::US0_1;
    let mut v31: Rc<UH2> = Rc::new(UH2::UH2_2(v30.clone()));
    let mut v32: Rc<UH2> = Rc::new(UH2::UH2_3(v29.clone(), v31.clone()));
    let mut v33: Rc<UH2> = Rc::new(UH2::UH2_5(v32.clone()));
    let mut v34: US0 = US0::US0_0;
    let mut v35: Rc<UH2> = Rc::new(UH2::UH2_2(v34.clone()));
    let mut v36: Rc<UH2> = Rc::new(UH2::UH2_4(v33.clone(), v35.clone()));
    let mut v37: bool = method0(v36.clone(), v6.clone());
    if v37 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v38: US0 = US0::US0_0;
    let mut v39: Rc<UH2> = Rc::new(UH2::UH2_2(v38.clone()));
    let mut v40: US0 = US0::US0_1;
    let mut v41: Rc<UH2> = Rc::new(UH2::UH2_2(v40.clone()));
    let mut v42: Rc<UH2> = Rc::new(UH2::UH2_3(v39.clone(), v41.clone()));
    let mut v43: Rc<UH2> = Rc::new(UH2::UH2_5(v42.clone()));
    let mut v44: US0 = US0::US0_0;
    let mut v45: Rc<UH2> = Rc::new(UH2::UH2_2(v44.clone()));
    let mut v46: Rc<UH2> = Rc::new(UH2::UH2_4(v43.clone(), v45.clone()));
    let mut v47: bool = method0(v46.clone(), v13.clone());
    if v47 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v48: US1 = US1::US1_0;
    let mut v49: Rc<UH3> = Rc::new(UH3::UH3_2(v48.clone()));
    let mut v50: Rc<UH3> = Rc::new(UH3::UH3_5(v49.clone()));
    let mut v51: bool = method11(v50.clone(), v20.clone());
    if v51 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v52: US1 = US1::US1_0;
    let mut v53: Rc<UH3> = Rc::new(UH3::UH3_2(v52.clone()));
    let mut v54: Rc<UH3> = Rc::new(UH3::UH3_5(v53.clone()));
    let mut v55: bool = method11(v54.clone(), v27.clone());
    if v55 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v56: US0 = US0::US0_0;
    let mut v57: Rc<UH2> = Rc::new(UH2::UH2_2(v56.clone()));
    let mut v58: US0 = US0::US0_1;
    let mut v59: Rc<UH2> = Rc::new(UH2::UH2_2(v58.clone()));
    let mut v60: Rc<UH2> = Rc::new(UH2::UH2_3(v57.clone(), v59.clone()));
    let mut v61: Rc<UH2> = Rc::new(UH2::UH2_5(v60.clone()));
    let mut v62: US0 = US0::US0_0;
    let mut v63: Rc<UH2> = Rc::new(UH2::UH2_2(v62.clone()));
    let mut v64: Rc<UH2> = Rc::new(UH2::UH2_4(v61.clone(), v63.clone()));
    let mut v65: US4 = US4::US4_0(v64.clone(), v6.clone());
    let mut v66: US5 = method22(v65.clone());
    let mut v67: US0 = US0::US0_0;
    let mut v68: Rc<UH2> = Rc::new(UH2::UH2_2(v67.clone()));
    let mut v69: US0 = US0::US0_1;
    let mut v70: Rc<UH2> = Rc::new(UH2::UH2_2(v69.clone()));
    let mut v71: Rc<UH2> = Rc::new(UH2::UH2_3(v68.clone(), v70.clone()));
    let mut v72: Rc<UH2> = Rc::new(UH2::UH2_5(v71.clone()));
    let mut v73: US0 = US0::US0_0;
    let mut v74: Rc<UH2> = Rc::new(UH2::UH2_2(v73.clone()));
    let mut v75: Rc<UH2> = Rc::new(UH2::UH2_4(v72.clone(), v74.clone()));
    let mut v76: US4 = US4::US4_0(v75.clone(), v13.clone());
    let mut v77: US5 = method22(v76.clone());
    let mut v78: bool = method23(v66.clone());
    if v78 {
        ()
    } else {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-true"); } LIT.with(|lit| lit.clone()) }))
    };
    let mut v79: bool = method23(v77.clone());
    if v79 {
        std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("brzozowski-expected-false"); } LIT.with(|lit| lit.clone()) }))
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
