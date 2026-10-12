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
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_Absent => 0,
            US1::US1_Box(..) => 1,
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
        US1::US1_Absent
    };
    let mut v18: Rc<Heap4> = Rc::new(Heap4 { l0: v17.clone() });
    let mut v19: Rc<RefCell<Vec<Rc<Heap4>>>> = Rc::new(RefCell::new(vec![<Rc<Heap4>>::default(); 1i32 as usize]));
    v19.clone().borrow_mut()[0i32 as usize] = v18.clone();
    let mut v20: Rc<Heap4> = v19.clone().borrow()[0i32 as usize].clone();
    let mut v21: US1 = v20.l0.clone();
    score_0(v21.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
