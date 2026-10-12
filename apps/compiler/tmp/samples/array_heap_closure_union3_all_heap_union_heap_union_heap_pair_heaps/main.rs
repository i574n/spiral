#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
struct Heap1 { l0: Rc<Heap0>, l1: Rc<Heap0> }
impl Default for Heap1 {
    fn default() -> Self {
        Heap1 { l0: <Rc<Heap0>>::default(), l1: <Rc<Heap0>>::default() }
    }
}
struct Heap2 { l0: Rc<Heap1>, l1: i32 }
impl Default for Heap2 {
    fn default() -> Self {
        Heap2 { l0: <Rc<Heap1>>::default(), l1: <i32>::default() }
    }
}
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap2>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_None => 0,
            US0::US0_Held(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
struct Heap3 { l0: US0 }
impl Default for Heap3 {
    fn default() -> Self {
        Heap3 { l0: <US0>::default() }
    }
}
#[derive(Clone)]
enum US1 {
    US1_Absent,
    US1_Box(Rc<Heap3>),
    US1_Mark(i32),
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_Absent => 0,
            US1::US1_Box(..) => 1,
            US1::US1_Mark(..) => 2,
        }
    }
}
impl Default for US1 {
    fn default() -> Self {
        US1::US1_Absent
    }
}
struct Heap4 { l0: US1 }
impl Default for Heap4 {
    fn default() -> Self {
        Heap4 { l0: <US1>::default() }
    }
}
fn f_c0(mut v0: US1, mut v1: i32) -> Rc<dyn Fn(i32) -> US1> {
    Rc::new(move |mut v2: i32| -> US1 {
        let mut v3: bool = v2 == 0i32;
        if v3 {
            US1::US1_Absent
        } else {
            let mut v5: bool = v2 == 1i32;
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
            let mut v3: Rc<Heap3> = v3.clone();
            let mut v4: US0 = v3.l0.clone();
            match &v4 {
                US0::US0_Held(v5) => {
                    let mut v5: Rc<Heap2> = v5.clone();
                    let (mut v6, mut v7): (Rc<Heap1>, i32) = (v5.l0.clone(), v5.l1.clone());
                    let (mut v8, mut v9): (Rc<Heap0>, Rc<Heap0>) = (v6.l0.clone(), v6.l1.clone());
                    let (mut v10, mut v11): (i32, Rc<str>) = (v8.l0.clone(), v8.l1.clone());
                    let (mut v12, mut v13): (i32, Rc<str>) = (v9.l0.clone(), v9.l1.clone());
                    let mut v14: bool = v10 == 7i32;
                    let mut v16: bool = if v14 {
                        let mut v15: bool = v11.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                        v15
                    } else {
                        false
                    };
                    let mut v18: bool = if v16 {
                        let mut v17: bool = v12 == 4i32;
                        v17
                    } else {
                        false
                    };
                    let mut v20: bool = if v18 {
                        let mut v19: bool = v13.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("yo"); } LIT.with(|lit| lit.clone()) };
                        v19
                    } else {
                        false
                    };
                    let mut v22: bool = if v20 {
                        let mut v21: bool = v7 == 2i32;
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
            let mut v1: i32 = *v1;
            1i32
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
    let mut v9: bool = true;
    let mut v12: US0 = if v9 {
        US0::US0_Held(v8.clone())
    } else {
        US0::US0_None
    };
    let mut v13: Rc<Heap3> = Rc::new(Heap3 { l0: v12.clone() });
    let mut v14: bool = true;
    let mut v17: US1 = if v14 {
        US1::US1_Box(v13.clone())
    } else {
        US1::US1_Mark(1i32)
    };
    let mut v18: i32 = 3i32;
    let mut v19: Rc<dyn Fn(i32) -> US1> = f_c0(v17.clone(), v18);
    let mut v20: US1 = v19(1i32);
    let mut v21: Rc<Heap4> = Rc::new(Heap4 { l0: v20.clone() });
    let mut v22: US1 = v19(2i32);
    let mut v23: Rc<Heap4> = Rc::new(Heap4 { l0: v22.clone() });
    let mut v24: US1 = v19(0i32);
    let mut v25: Rc<Heap4> = Rc::new(Heap4 { l0: v24.clone() });
    let mut v26: Rc<RefCell<Vec<Rc<Heap4>>>> = Rc::new(RefCell::new(vec![<Rc<Heap4>>::default(); 3i32 as usize]));
    v26.clone().borrow_mut()[0i32 as usize] = v21.clone();
    v26.clone().borrow_mut()[1i32 as usize] = v23.clone();
    v26.clone().borrow_mut()[2i32 as usize] = v25.clone();
    let mut v27: Rc<Heap4> = v26.clone().borrow()[0i32 as usize].clone();
    let mut v28: US1 = v27.l0.clone();
    let mut v29: Rc<Heap4> = v26.clone().borrow()[1i32 as usize].clone();
    let mut v30: US1 = v29.l0.clone();
    let mut v31: Rc<Heap4> = v26.clone().borrow()[2i32 as usize].clone();
    let mut v32: US1 = v31.l0.clone();
    let mut v33: i32 = score_0(v28.clone());
    let mut v34: i32 = score_0(v30.clone());
    let mut v35: i32 = score_0(v32.clone());
    let mut v36: bool = v33 == 0i32;
    let mut v38: bool = if v36 {
        let mut v37: bool = v34 == 1i32;
        v37
    } else {
        false
    };
    let mut v40: bool = if v38 {
        let mut v39: bool = v35 == 1i32;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
