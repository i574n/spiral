#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_VZ,
}
#[derive(Clone)]
enum UH3 {
    UH3_VZ,
    UH3_VS(Rc<UH0>),
}
#[derive(Clone)]
enum UH5 {
    UH5_VZ,
    UH5_VS(Rc<UH3>),
}
#[derive(Clone)]
enum UH7 {
    UH7_VZ,
    UH7_VS(Rc<UH5>),
}
#[derive(Clone)]
enum UH9 {
    UH9_VZ,
    UH9_VS(Rc<UH9>),
}
#[derive(Clone)]
enum UH8 {
    UH8_Var(Rc<UH9>),
    UH8_Lam(Rc<UH8>),
    UH8_App(Rc<UH8>, Rc<UH8>),
}
#[derive(Clone)]
enum UH6 {
    UH6_Var(Rc<UH7>),
    UH6_Lam(Rc<UH8>),
    UH6_App(Rc<UH6>, Rc<UH6>),
}
#[derive(Clone)]
enum UH4 {
    UH4_Var(Rc<UH5>),
    UH4_Lam(Rc<UH6>),
    UH4_App(Rc<UH4>, Rc<UH4>),
}
#[derive(Clone)]
enum UH2 {
    UH2_Var(Rc<UH3>),
    UH2_Lam(Rc<UH4>),
    UH2_App(Rc<UH2>, Rc<UH2>),
}
#[derive(Clone)]
enum UH1 {
    UH1_Var(Rc<UH0>),
    UH1_Lam(Rc<UH2>),
    UH1_App(Rc<UH1>, Rc<UH1>),
}
#[derive(Clone)]
enum UH10 {
    UH10_Lam(Rc<UH1>),
    UH10_App(Rc<UH10>, Rc<UH10>),
}
fn size_7(mut v0: Rc<UH8>) -> i32 {
    match &*v0 {
        UH8::UH8_App(v5, v6) => {
            let v5: Rc<UH8> = v5.clone();
            let v6: Rc<UH8> = v6.clone();
            let v7: i32 = size_6(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_6(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH8::UH8_Lam(v2) => {
            let v2: Rc<UH8> = v2.clone();
            let v3: i32 = size_7(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH8::UH8_Var(v1) => {
            let v1: Rc<UH9> = v1.clone();
            1i32
        }
    }
}
fn size_6(mut v0: Rc<UH8>) -> i32 {
    match &*v0 {
        UH8::UH8_App(v5, v6) => {
            let v5: Rc<UH8> = v5.clone();
            let v6: Rc<UH8> = v6.clone();
            let v7: i32 = size_6(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_6(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH8::UH8_Lam(v2) => {
            let v2: Rc<UH8> = v2.clone();
            let v3: i32 = size_7(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH8::UH8_Var(v1) => {
            let v1: Rc<UH9> = v1.clone();
            1i32
        }
    }
}
fn size_5(mut v0: Rc<UH8>) -> i32 {
    match &*v0 {
        UH8::UH8_App(v5, v6) => {
            let v5: Rc<UH8> = v5.clone();
            let v6: Rc<UH8> = v6.clone();
            let v7: i32 = size_6(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_6(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH8::UH8_Lam(v2) => {
            let v2: Rc<UH8> = v2.clone();
            let v3: i32 = size_7(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH8::UH8_Var(v1) => {
            let v1: Rc<UH9> = v1.clone();
            1i32
        }
    }
}
fn size_4(mut v0: Rc<UH6>) -> i32 {
    match &*v0 {
        UH6::UH6_App(v5, v6) => {
            let v5: Rc<UH6> = v5.clone();
            let v6: Rc<UH6> = v6.clone();
            let v7: i32 = size_4(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_4(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH6::UH6_Lam(v2) => {
            let v2: Rc<UH8> = v2.clone();
            let v3: i32 = size_5(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH6::UH6_Var(v1) => {
            let v1: Rc<UH7> = v1.clone();
            1i32
        }
    }
}
fn size_3(mut v0: Rc<UH4>) -> i32 {
    match &*v0 {
        UH4::UH4_App(v5, v6) => {
            let v5: Rc<UH4> = v5.clone();
            let v6: Rc<UH4> = v6.clone();
            let v7: i32 = size_3(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_3(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH4::UH4_Lam(v2) => {
            let v2: Rc<UH6> = v2.clone();
            let v3: i32 = size_4(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH4::UH4_Var(v1) => {
            let v1: Rc<UH5> = v1.clone();
            1i32
        }
    }
}
fn size_2(mut v0: Rc<UH2>) -> i32 {
    match &*v0 {
        UH2::UH2_App(v5, v6) => {
            let v5: Rc<UH2> = v5.clone();
            let v6: Rc<UH2> = v6.clone();
            let v7: i32 = size_2(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_2(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH2::UH2_Lam(v2) => {
            let v2: Rc<UH4> = v2.clone();
            let v3: i32 = size_3(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH2::UH2_Var(v1) => {
            let v1: Rc<UH3> = v1.clone();
            1i32
        }
    }
}
fn size_1(mut v0: Rc<UH1>) -> i32 {
    match &*v0 {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5.clone();
            let v6: Rc<UH1> = v6.clone();
            let v7: i32 = size_1(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_1(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH2> = v2.clone();
            let v3: i32 = size_2(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1.clone();
            1i32
        }
    }
}
fn size_0(mut v0: Rc<UH10>) -> i32 {
    match &*v0 {
        UH10::UH10_App(v4, v5) => {
            let v4: Rc<UH10> = v4.clone();
            let v5: Rc<UH10> = v5.clone();
            let v6: i32 = size_0(v4);
            let v7: i32 = 1i32.wrapping_add(v6);
            let v8: i32 = size_0(v5);
            let v9: i32 = v7.wrapping_add(v8);
            v9
        }
        UH10::UH10_Lam(v1) => {
            let v1: Rc<UH1> = v1.clone();
            let v2: i32 = size_1(v1);
            let v3: i32 = 1i32.wrapping_add(v2);
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH1> = Rc::new(UH1::UH1_Var(v0));
    let v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH3> = Rc::new(UH3::UH3_VS(v2));
    let v4: Rc<UH2> = Rc::new(UH2::UH2_Var(v3));
    let v5: Rc<UH1> = Rc::new(UH1::UH1_Lam(v4));
    let v6: Rc<UH1> = Rc::new(UH1::UH1_App(v1, v5));
    let v7: Rc<UH10> = Rc::new(UH10::UH10_Lam(v6));
    size_0(v7)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
