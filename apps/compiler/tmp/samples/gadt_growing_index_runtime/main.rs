#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_VZ,
    UH0_VS(Rc<UH0>),
}
#[derive(Clone)]
enum UH1 {
    UH1_Var(Rc<UH0>),
    UH1_Lam(Rc<UH1>),
    UH1_App(Rc<UH1>, Rc<UH1>),
}
fn size_3(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_3(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_3(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_2(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_2(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_3(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_3(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_2(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_1(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_1(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_1(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_2(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_0(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_1(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_1(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_2(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH1> = Rc::new(UH1::UH1_Var(v0));
    let v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH0> = Rc::new(UH0::UH0_VS(v2));
    let v4: Rc<UH1> = Rc::new(UH1::UH1_Var(v3));
    let v5: Rc<UH1> = Rc::new(UH1::UH1_Lam(v4));
    let v6: Rc<UH1> = Rc::new(UH1::UH1_App(v1, v5));
    let v7: Rc<UH1> = Rc::new(UH1::UH1_Lam(v6));
    size_0(v7)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
