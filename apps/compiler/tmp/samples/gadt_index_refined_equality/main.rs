#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Vowel(i32),
}
#[derive(Clone)]
enum UH0 {
    UH0_Nil,
    UH0_Cons(US0, Rc<UH0>),
}
fn method0(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> bool {
    loop {
        match (Rc::unwrap_or_clone(v1), Rc::unwrap_or_clone(v0)) {
            (UH0::UH0_Cons(v2, v3), UH0::UH0_Cons(v4, v5)) => {
                let v2: US0 = v2;
                let v3: Rc<UH0> = v3;
                let v4: US0 = v4;
                let v5: Rc<UH0> = v5;
                let v9: bool = match (v2, v4) {
                    (US0::US0_Vowel(v6), US0::US0_Vowel(v7)) => {
                        let v6: i32 = v6;
                        let v7: i32 = v7;
                        let v8: bool = v6 == v7;
                        v8
                    }
                    _ => {
                        false
                    }
                };
                if v9 {
                    (v0, v1) = (v5, v3);
                    continue;
                } else {
                    return false;
                }
            }
            (UH0::UH0_Nil, UH0::UH0_Nil) => {
                return true;
            }
            _ => {
                return false;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: US0 = US0::US0_Vowel(v0);
    let v2: i32 = 1i32;
    let v3: US0 = US0::US0_Vowel(v2);
    let v4: i32 = 2i32;
    let v5: US0 = US0::US0_Vowel(v4);
    let v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(v5.clone(), v6));
    let v8: Rc<UH0> = Rc::new(UH0::UH0_Cons(v1.clone(), v7));
    let v9: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v10: Rc<UH0> = Rc::new(UH0::UH0_Cons(v5.clone(), v9));
    let v11: Rc<UH0> = Rc::new(UH0::UH0_Cons(v3.clone(), v10));
    let v12: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v13: Rc<UH0> = Rc::new(UH0::UH0_Cons(v1.clone(), v12));
    let v17: bool = match (&v1, &v3) {
        (US0::US0_Vowel(v14), US0::US0_Vowel(v15)) => {
            let v14: i32 = *v14;
            let v15: i32 = *v15;
            let v16: bool = v14 == v15;
            v16
        }
        _ => {
            false
        }
    };
    let v23: bool = if v17 {
        let v21: bool = match (&v1, &v5) {
            (US0::US0_Vowel(v18), US0::US0_Vowel(v19)) => {
                let v18: i32 = *v18;
                let v19: i32 = *v19;
                let v20: bool = v18 == v19;
                v20
            }
            _ => {
                false
            }
        };
        let v22: bool = v21 == false;
        v22
    } else {
        false
    };
    let v30: bool = if v23 {
        let v27: bool = match (&v1, &v3) {
            (US0::US0_Vowel(v24), US0::US0_Vowel(v25)) => {
                let v24: i32 = *v24;
                let v25: i32 = *v25;
                let v26: bool = v24 == v25;
                v26
            }
            _ => {
                false
            }
        };
        if v27 {
            method0(v11, v8.clone())
        } else {
            false
        }
    } else {
        false
    };
    let v38: bool = if v30 {
        let v34: bool = match (v1, v5) {
            (US0::US0_Vowel(v31), US0::US0_Vowel(v32)) => {
                let v31: i32 = v31;
                let v32: i32 = v32;
                let v33: bool = v31 == v32;
                v33
            }
            _ => {
                false
            }
        };
        let v36: bool = if v34 {
            method0(v13, v8)
        } else {
            false
        };
        let v37: bool = v36 == false;
        v37
    } else {
        false
    };
    if v38 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
