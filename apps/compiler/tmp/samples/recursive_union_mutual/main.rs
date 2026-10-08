#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH1 {
    UH1_0(Rc<UH0>),
    UH1_1,
}
impl UH1 {
    fn tag(&self) -> i32 {
        match self {
            UH1::UH1_0(..) => 0,
            UH1::UH1_1 => 1,
        }
    }
}
#[derive(Clone)]
enum UH0 {
    UH0_0(Rc<UH1>),
    UH0_1,
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0(..) => 0,
            UH0::UH0_1 => 1,
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v5: Rc<UH0> = if v0 {
        let mut v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) };
        let mut v2: Rc<UH1> = Rc::new(UH1::UH1_0(v1.clone()));
        Rc::new(UH0::UH0_0(v2.clone()))
    } else {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
    };
    match &*v5 {
        UH0::UH0_0(v6) => {
            let mut v6: Rc<UH1> = v6.clone();
            0i32
        }
        UH0::UH0_1 => {
            0i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
