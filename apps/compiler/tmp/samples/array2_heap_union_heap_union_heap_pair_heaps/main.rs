#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap2>),
}
struct Heap3 { l0: US0 }
#[derive(Clone)]
enum US1 {
    US1_Absent,
    US1_Box(Rc<Heap3>),
}
struct Heap4 { l0: US1 }
impl Default for US1 {
    fn default() -> Self {
        US1::US1_Absent
    }
}
impl Default for Heap4 {
    fn default() -> Self {
        Heap4 { l0: <US1>::default() }
    }
}
fn score_0(mut v0: US1) -> i32 {
    match &v0 {
        US1::US1_Absent => {
            1i32
        }
        US1::US1_Box(v1) => {
            let mut v1: Rc<Heap3> = v1.clone();
            let mut v2: US0 = v1.l0.clone();
            match &v2 {
                US0::US0_Held(v3) => {
                    let mut v3: Rc<Heap2> = v3.clone();
                    let (mut v4, mut v5): (Rc<Heap1>, i32) = (v3.l0.clone(), v3.l1.clone());
                    let (mut v6, mut v7): (Rc<Heap0>, Rc<Heap0>) = (v4.l0.clone(), v4.l1.clone());
                    let (mut v8, mut v9): (i32, Rc<str>) = (v6.l0.clone(), v6.l1.clone());
                    let (mut v10, mut v11): (i32, Rc<str>) = (v7.l0.clone(), v7.l1.clone());
                    let mut v12: bool = v8 == 7i32;
                    let mut v14: bool = if v12 {
                        let mut v13: bool = v9.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                        v13
                    } else {
                        false
                    };
                    let mut v16: bool = if v14 {
                        let mut v15: bool = v10 == 4i32;
                        v15
                    } else {
                        false
                    };
                    let mut v18: bool = if v16 {
                        let mut v17: bool = v11.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
                        v17
                    } else {
                        false
                    };
                    let mut v20: bool = if v18 {
                        let mut v19: bool = v5 == 2i32;
                        v19
                    } else {
                        false
                    };
                    if v20 {
                        0i32
                    } else {
                        1i32
                    }
                }
                US0::US0_None => {
                    1i32
                }
            }
        }
    }
}
fn score_b_1(mut v0: US1) -> i32 {
    match &v0 {
        US1::US1_Absent => {
            1i32
        }
        US1::US1_Box(v1) => {
            let mut v1: Rc<Heap3> = v1.clone();
            let mut v2: US0 = v1.l0.clone();
            match &v2 {
                US0::US0_Held(v3) => {
                    let mut v3: Rc<Heap2> = v3.clone();
                    let (mut v4, mut v5): (Rc<Heap1>, i32) = (v3.l0.clone(), v3.l1.clone());
                    let (mut v6, mut v7): (Rc<Heap0>, Rc<Heap0>) = (v4.l0.clone(), v4.l1.clone());
                    let (mut v8, mut v9): (i32, Rc<str>) = (v6.l0.clone(), v6.l1.clone());
                    let (mut v10, mut v11): (i32, Rc<str>) = (v7.l0.clone(), v7.l1.clone());
                    let mut v12: bool = v8 == 8i32;
                    let mut v14: bool = if v12 {
                        let mut v13: bool = v9.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
                        v13
                    } else {
                        false
                    };
                    let mut v16: bool = if v14 {
                        let mut v15: bool = v10 == 5i32;
                        v15
                    } else {
                        false
                    };
                    let mut v18: bool = if v16 {
                        let mut v17: bool = v11.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
                        v17
                    } else {
                        false
                    };
                    let mut v20: bool = if v18 {
                        let mut v19: bool = v5 == 9i32;
                        v19
                    } else {
                        false
                    };
                    if v20 {
                        0i32
                    } else {
                        1i32
                    }
                }
                US0::US0_None => {
                    1i32
                }
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: i32 = 4i32;
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4.clone() });
    let mut v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2.clone(), l1: v5.clone() });
    let mut v7: i32 = 2i32;
    let mut v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6.clone(), l1: v7 });
    let mut v9: US0 = US0::US0_Held(v8.clone());
    let mut v10: Rc<Heap3> = Rc::new(Heap3 { l0: v9.clone() });
    let mut v11: US1 = US1::US1_Box(v10.clone());
    let mut v12: Rc<Heap4> = Rc::new(Heap4 { l0: v11.clone() });
    let mut v13: i32 = 8i32;
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ok"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<Heap0> = Rc::new(Heap0 { l0: v13, l1: v14.clone() });
    let mut v16: i32 = 5i32;
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<Heap0> = Rc::new(Heap0 { l0: v16, l1: v17.clone() });
    let mut v19: Rc<Heap1> = Rc::new(Heap1 { l0: v15.clone(), l1: v18.clone() });
    let mut v20: i32 = 9i32;
    let mut v21: Rc<Heap2> = Rc::new(Heap2 { l0: v19.clone(), l1: v20 });
    let mut v22: US0 = US0::US0_Held(v21.clone());
    let mut v23: Rc<Heap3> = Rc::new(Heap3 { l0: v22.clone() });
    let mut v24: US1 = US1::US1_Box(v23.clone());
    let mut v25: Rc<Heap4> = Rc::new(Heap4 { l0: v24.clone() });
    let mut v26: Rc<RefCell<Vec<Rc<Heap4>>>> = Rc::new(RefCell::new(vec![<Rc<Heap4>>::default(); 2i32 as usize]));
    v26.clone().borrow_mut()[0i32 as usize] = v12.clone();
    v26.clone().borrow_mut()[1i32 as usize] = v25.clone();
    let mut v27: Rc<Heap4> = v26.clone().borrow()[0i32 as usize].clone();
    let mut v28: Rc<Heap4> = v26.clone().borrow()[1i32 as usize].clone();
    let mut v29: US1 = v27.l0.clone();
    let mut v30: US1 = v28.l0.clone();
    let mut v31: i32 = score_0(v29.clone());
    let mut v32: i32 = score_b_1(v30.clone());
    let mut v33: bool = v31 == 0i32;
    let mut v35: bool = if v33 {
        let mut v34: bool = v32 == 0i32;
        v34
    } else {
        false
    };
    if v35 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
