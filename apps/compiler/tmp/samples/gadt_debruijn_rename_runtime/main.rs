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
fn closure0() -> Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = Rc::new(move |mut v0: Rc<UH0>| -> Rc<UH0> {
        Rc::new(UH0::UH0_VS(v0))
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure1(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>) -> Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> {
    Rc::new(move |mut v1: Rc<UH0>| -> Rc<UH0> {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_VS(v3) => {
                let v3: Rc<UH0> = v3;
                let v4: Rc<UH0> = v0(v3);
                Rc::new(UH0::UH0_VS(v4))
            }
            UH0::UH0_VZ => {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) }
            }
        }
    })
}
fn closure2(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>) -> Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> {
    Rc::new(move |mut v1: Rc<UH0>| -> Rc<UH0> {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_VS(v3) => {
                let v3: Rc<UH0> = v3;
                let v4: Rc<UH0> = v0(v3);
                Rc::new(UH0::UH0_VS(v4))
            }
            UH0::UH0_VZ => {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) }
            }
        }
    })
}
fn closure3(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>) -> Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> {
    Rc::new(move |mut v1: Rc<UH0>| -> Rc<UH0> {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_VS(v3) => {
                let v3: Rc<UH0> = v3;
                let v4: Rc<UH0> = v0(v3);
                Rc::new(UH0::UH0_VS(v4))
            }
            UH0::UH0_VZ => {
                { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) }
            }
        }
    })
}
fn rename_5(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v1) {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9;
            let v10: Rc<UH1> = v10;
            let v11: Rc<UH1> = rename_5(v0.clone(), v9);
            let v12: Rc<UH1> = rename_5(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure3(v0);
            let v7: Rc<UH1> = rename_4(v6, v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2;
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn rename_4(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v1) {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9;
            let v10: Rc<UH1> = v10;
            let v11: Rc<UH1> = rename_5(v0.clone(), v9);
            let v12: Rc<UH1> = rename_5(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure3(v0);
            let v7: Rc<UH1> = rename_4(v6, v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2;
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn rename_3(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v1) {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9;
            let v10: Rc<UH1> = v10;
            let v11: Rc<UH1> = rename_3(v0.clone(), v9);
            let v12: Rc<UH1> = rename_3(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure2(v0);
            let v7: Rc<UH1> = rename_4(v6, v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2;
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn rename_2(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: &Rc<UH1>) -> Rc<UH1> {
    match &**v1 {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9.clone();
            let v10: Rc<UH1> = v10.clone();
            let v11: Rc<UH1> = rename_3(v0.clone(), v9);
            let v12: Rc<UH1> = rename_3(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5.clone();
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure2(v0);
            let v7: Rc<UH1> = rename_4(v6, v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2.clone();
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn rename_1(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v1) {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9;
            let v10: Rc<UH1> = v10;
            let v11: Rc<UH1> = rename_1(v0.clone(), v9);
            let v12: Rc<UH1> = rename_1(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure1(v0);
            let v7: Rc<UH1> = rename_2(v6, &v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2;
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn rename_0(mut v0: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>>, mut v1: &Rc<UH1>) -> Rc<UH1> {
    match &**v1 {
        UH1::UH1_App(v9, v10) => {
            let v9: Rc<UH1> = v9.clone();
            let v10: Rc<UH1> = v10.clone();
            let v11: Rc<UH1> = rename_1(v0.clone(), v9);
            let v12: Rc<UH1> = rename_1(v0, v10);
            Rc::new(UH1::UH1_App(v11, v12))
        }
        UH1::UH1_Lam(v5) => {
            let v5: Rc<UH1> = v5.clone();
            let v6: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure1(v0);
            let v7: Rc<UH1> = rename_2(v6, &v5);
            Rc::new(UH1::UH1_Lam(v7))
        }
        UH1::UH1_Var(v2) => {
            let v2: Rc<UH0> = v2.clone();
            let v3: Rc<UH0> = v0(v2);
            Rc::new(UH1::UH1_Var(v3))
        }
    }
}
fn size_9(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_9(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_9(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_8(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_8(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_9(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_9(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_8(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_7(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_7(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_7(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_8(v2);
            let v4: i32 = 1i32.wrapping_add(v3);
            v4
        }
        UH1::UH1_Var(v1) => {
            let v1: Rc<UH0> = v1;
            1i32
        }
    }
}
fn size_6(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_App(v5, v6) => {
            let v5: Rc<UH1> = v5;
            let v6: Rc<UH1> = v6;
            let v7: i32 = size_7(v5);
            let v8: i32 = 1i32.wrapping_add(v7);
            let v9: i32 = size_7(v6);
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
        UH1::UH1_Lam(v2) => {
            let v2: Rc<UH1> = v2;
            let v3: i32 = size_8(v2);
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
    let mut v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH1> = Rc::new(UH1::UH1_Var(v0));
    let v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_VZ); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH0> = Rc::new(UH0::UH0_VS(v2));
    let v4: Rc<UH1> = Rc::new(UH1::UH1_Var(v3));
    let v5: Rc<UH1> = Rc::new(UH1::UH1_Lam(v4));
    let v6: Rc<UH1> = Rc::new(UH1::UH1_App(v1, v5));
    let v7: Rc<UH1> = Rc::new(UH1::UH1_Lam(v6));
    let v8: Rc<dyn Fn(Rc<UH0>) -> Rc<UH0>> = closure0();
    let v9: Rc<UH1> = rename_0(v8, &v7);
    size_6(v9)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
