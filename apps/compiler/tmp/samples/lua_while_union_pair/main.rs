#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
struct Mut1 { l0: i32 }
#[derive(Clone)]
enum UH0 {
    UH0_Nil,
    UH0_Cons(i32, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_Nil => 0,
            UH0::UH0_Cons(..) => 1,
        }
    }
}
struct Mut2 { l0: Rc<UH0> }
fn method0(mut v0: Rc<RefCell<Mut0>>) -> bool {
    let mut v1: i32 = v0.borrow().l0.clone();
    let mut v2: bool = v1 < 3i32;
    v2
}
fn method1(mut v0: Rc<RefCell<Mut1>>) -> bool {
    let mut v1: i32 = v0.borrow().l0.clone();
    let mut v2: bool = v1 < 4i32;
    v2
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 3i32 as usize]));
    let mut v1: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32 }));
    while method0(v1.clone()) {
        let mut v3: i32 = v1.borrow().l0.clone();
        let mut v4: i32 = v3.wrapping_mul(5i32);
        v0.clone().borrow_mut()[v3 as usize] = v4;
        let mut v5: i32 = v3.wrapping_add(1i32);
        v1.borrow_mut().l0 = v5;
        ()
    };
    let mut v6: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: 0i32 }));
    let mut v7: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: 0i32 }));
    let mut v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v9: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: v8.clone() }));
    while method1(v6.clone()) {
        let mut v11: i32 = v6.borrow().l0.clone();
        let mut v12: i32 = v11.wrapping_rem(2i32);
        let mut v13: bool = v12 == 1i32;
        if v13 {
            let mut v14: i32 = v7.borrow().l0.clone();
            let mut v15: i32 = v14.wrapping_add(1i32);
            v7.borrow_mut().l0 = v15;
            ()
        };
        let mut v16: Rc<UH0> = v9.borrow().l0.clone();
        let mut v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v16.clone()));
        v9.borrow_mut().l0 = v17.clone();
        let mut v18: i32 = v11.wrapping_add(1i32);
        v6.borrow_mut().l0 = v18;
        ()
    };
    let mut v19: Rc<UH0> = v9.borrow().l0.clone();
    let mut v38: i32 = match &*v19 {
        UH0::UH0_Cons(v20, v21) => {
            let mut v20: i32 = *v20;
            let mut v21: Rc<UH0> = v21.clone();
            match &*v21 {
                UH0::UH0_Cons(v22, v23) => {
                    let mut v22: i32 = *v22;
                    let mut v23: Rc<UH0> = v23.clone();
                    match &*v23 {
                        UH0::UH0_Cons(v24, v25) => {
                            let mut v24: i32 = *v24;
                            let mut v25: Rc<UH0> = v25.clone();
                            match &*v25 {
                                UH0::UH0_Cons(v26, v27) => {
                                    let mut v26: i32 = *v26;
                                    let mut v27: Rc<UH0> = v27.clone();
                                    match &*v27 {
                                        UH0::UH0_Nil => {
                                            let mut v28: i32 = v20.wrapping_mul(64i32);
                                            let mut v29: i32 = v22.wrapping_mul(16i32);
                                            let mut v30: i32 = v28.wrapping_add(v29);
                                            let mut v31: i32 = v24.wrapping_mul(4i32);
                                            let mut v32: i32 = v30.wrapping_add(v31);
                                            let mut v33: i32 = v32.wrapping_add(v26);
                                            v33
                                        }
                                        _ => {
                                            -1i32
                                        }
                                    }
                                }
                                _ => {
                                    -1i32
                                }
                            }
                        }
                        _ => {
                            -1i32
                        }
                    }
                }
                _ => {
                    -1i32
                }
            }
        }
        _ => {
            -1i32
        }
    };
    let mut v39: i32 = v7.borrow().l0.clone();
    let mut v40: i32 = v38.wrapping_add(v39);
    let mut v41: i32 = v0.clone().borrow()[2i32 as usize].clone();
    let mut v42: i32 = v40.wrapping_add(v41);
    let mut v43: i32 = v0.clone().borrow()[1i32 as usize].clone();
    let mut v44: i32 = v42.wrapping_sub(v43);
    v44
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
