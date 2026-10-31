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
    US1_Mark(i32),
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
fn f_c0(mut v0: US1, mut v1: i32) -> Rc<dyn Fn(i32) -> US1> {
    Rc::new(move |mut v2: i32| -> US1 {
        let v3: bool = v2 == 0i32;
        if v3 {
            US1::US1_Absent
        } else {
            let v5: bool = v2 == 1i32;
            if v5 {
                v0.clone()
            } else {
                US1::US1_Mark(v1)
            }
        }
    })
}
fn score_0(mut v0: US1) -> i32 {
    match &v0 {
        US1::US1_Absent => {
            1i32
        }
        US1::US1_Box(v3) => {
            let v3: Rc<Heap3> = v3.clone();
            let v4: US0 = v3.l0.clone();
            match &v4 {
                US0::US0_Held(v5) => {
                    let v5: Rc<Heap2> = v5.clone();
                    let (mut v6, mut v7): (Rc<Heap1>, i32) = (v5.l0.clone(), v5.l1.clone());
                    let (mut v8, mut v9): (Rc<Heap0>, Rc<Heap0>) = (v6.l0.clone(), v6.l1.clone());
                    let (mut v10, mut v11): (i32, Rc<str>) = (v8.l0.clone(), v8.l1.clone());
                    let (mut v12, mut v13): (i32, Rc<str>) = (v9.l0.clone(), v9.l1.clone());
                    let v14: bool = v10 == 7i32;
                    let v16: bool = if v14 {
                        let v15: bool = &*v11 == "hi";
                        v15
                    } else {
                        false
                    };
                    let v18: bool = if v16 {
                        let v17: bool = v12 == 4i32;
                        v17
                    } else {
                        false
                    };
                    let v20: bool = if v18 {
                        let mut v19: bool = &*v13 == "yo";
                        v19
                    } else {
                        false
                    };
                    let v22: bool = if v20 {
                        let v21: bool = v7 == 2i32;
                        v21
                    } else {
                        false
                    };
                    if v22 {
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
        US1::US1_Mark(v1) => {
            let v1: i32 = *v1;
            1i32
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let v3: i32 = 4i32;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3, l1: v4 });
    let v6: Rc<Heap1> = Rc::new(Heap1 { l0: v2, l1: v5 });
    let v7: i32 = 2i32;
    let v8: Rc<Heap2> = Rc::new(Heap2 { l0: v6, l1: v7 });
    let v9: bool = true;
    let v12: US0 = if v9 {
        US0::US0_Held(v8)
    } else {
        US0::US0_None
    };
    let v13: Rc<Heap3> = Rc::new(Heap3 { l0: v12 });
    let v14: bool = true;
    let v17: US1 = if v14 {
        US1::US1_Box(v13)
    } else {
        US1::US1_Mark(1i32)
    };
    let v18: i32 = 3i32;
    let mut v19: Rc<dyn Fn(i32) -> US1> = f_c0(v17, v18);
    let v20: US1 = v19(1i32);
    let v21: Rc<Heap4> = Rc::new(Heap4 { l0: v20 });
    let v22: US1 = v19(2i32);
    let v23: Rc<Heap4> = Rc::new(Heap4 { l0: v22 });
    let v24: US1 = v19(0i32);
    let v25: Rc<Heap4> = Rc::new(Heap4 { l0: v24 });
    let v26: Rc<RefCell<Vec<Rc<Heap4>>>> = Rc::new(RefCell::new(vec![<Rc<Heap4>>::default(); 3i32 as usize]));
    v26.clone().borrow_mut()[0i32 as usize] = v21;
    v26.clone().borrow_mut()[1i32 as usize] = v23;
    v26.clone().borrow_mut()[2i32 as usize] = v25;
    let v27: Rc<Heap4> = v26.clone().borrow()[0i32 as usize].clone();
    let v28: US1 = v27.l0.clone();
    let v29: Rc<Heap4> = v26.clone().borrow()[1i32 as usize].clone();
    let v30: US1 = v29.l0.clone();
    let v31: Rc<Heap4> = v26.borrow()[2i32 as usize].clone();
    let v32: US1 = v31.l0.clone();
    let v33: i32 = score_0(v28);
    let v34: i32 = score_0(v30);
    let v35: i32 = score_0(v32);
    let v36: bool = v33 == 0i32;
    let v38: bool = if v36 {
        let v37: bool = v34 == 1i32;
        v37
    } else {
        false
    };
    let v40: bool = if v38 {
        let v39: bool = v35 == 1i32;
        v39
    } else {
        false
    };
    if v40 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
