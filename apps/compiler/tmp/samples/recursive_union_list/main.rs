#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(i32, Rc<UH0>),
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
        UH0::UH0_1(v1, v2) => { // Cons
            let mut v1: i32 = *v1;
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: i32 = method0(v2.clone());
            let mut v4: i32 = v1.wrapping_add(v3);
            v4
        }
        UH0::UH0_0 => { // Nil
            0i32
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: i32 = 3i32;
    let mut v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_1(v2, v3.clone()));
    let mut v5: Rc<UH0> = Rc::new(UH0::UH0_1(v1, v4.clone()));
    let mut v6: Rc<UH0> = Rc::new(UH0::UH0_1(v0, v5.clone()));
    let mut v7: i32 = method0(v6.clone());
    let mut v8: i32 = v7.wrapping_sub(6i32);
    v8
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
