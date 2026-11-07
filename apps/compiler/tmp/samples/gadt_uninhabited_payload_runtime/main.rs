#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_PayloadZero,
}
#[derive(Clone)]
enum UH1 {
    UH1_PayloadRowNil,
}
#[derive(Clone)]
enum UH2 {
    UH2_PayloadRowCons(Rc<UH0>, Rc<UH1>),
}
fn spiral_main() -> i32 {
    let v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_PayloadZero); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_PayloadZero); } CASE.with(|case| case.clone()) };
    let v2: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_PayloadRowNil); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH2> = Rc::new(UH2::UH2_PayloadRowCons(v1, v2));
    let v7: Rc<UH0> = match Rc::unwrap_or_clone(v0) {
        UH0::UH0_PayloadZero => {
            match Rc::unwrap_or_clone(v3) {
                UH2::UH2_PayloadRowCons(v4, v5) => {
                    let v4: Rc<UH0> = v4;
                    let v5: Rc<UH1> = v5;
                    v4
                }
            }
        }
    };
    let v8: bool = match Rc::unwrap_or_clone(v7) {
        UH0::UH0_PayloadZero => {
            true
        }
    };
    if v8 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
