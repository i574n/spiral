#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH1 {
    UH1_Eps,
    UH1_NotNo(Rc<UH0>),
}
#[derive(Clone)]
enum UH0 {
    UH0_Never,
    UH0_NotYes(Rc<UH1>),
}
fn no_depth_1(mut v0: &Rc<UH0>) -> i32 {
    match &**v0 {
        UH0::UH0_Never => {
            2i32
        }
        UH0::UH0_NotYes(v1) => {
            let v1: Rc<UH1> = v1.clone();
            let v2: i32 = yes_depth_0(v1);
            let v3: i32 = 1i32.wrapping_add(v2);
            v3
        }
    }
}
fn yes_depth_0(mut v0: Rc<UH1>) -> i32 {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_Eps => {
            1i32
        }
        UH1::UH1_NotNo(v1) => {
            let v1: Rc<UH0> = v1;
            let v2: i32 = no_depth_1(&v1);
            let v3: i32 = 1i32.wrapping_add(v2);
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Never); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH1> = Rc::new(UH1::UH1_NotNo(v0));
    let v2: Rc<UH0> = Rc::new(UH0::UH0_NotYes(v1));
    let v3: Rc<UH1> = Rc::new(UH1::UH1_NotNo(v2));
    yes_depth_0(v3)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
