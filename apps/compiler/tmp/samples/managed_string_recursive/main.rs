#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(Rc<str>, Rc<UH0>, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0 => 0,
            UH0::UH0_1(..) => 1,
        }
    }
}
fn method0(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_0 => { // Empty
            0i32
        }
        UH0::UH0_1(v1, v2, v3) => { // Node
            let mut v1: Rc<str> = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: i32 = (v1.clone().len() as i32);
            let mut v5: i32 = method0(v2.clone());
            let mut v6: i32 = v4.wrapping_add(v5);
            let mut v7: i32 = method0(v3.clone());
            let mut v8: i32 = v6.wrapping_add(v7);
            v8
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("qwe"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v2.clone(), v2.clone()));
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_1(v0.clone(), v3.clone(), v3.clone()));
    let mut v5: i32 = method0(v4.clone());
    let mut v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v6.clone(), v6.clone()));
    let mut v8: Rc<UH0> = Rc::new(UH0::UH0_1(v0.clone(), v7.clone(), v7.clone()));
    let mut v9: i32 = method0(v8.clone());
    let mut v10: i32 = v5.wrapping_add(v9);
    let mut v11: i32 = v10.wrapping_sub(16i32);
    v11
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
