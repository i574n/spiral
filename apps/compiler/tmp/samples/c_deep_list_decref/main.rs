#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Link(i32, Rc<UH0>),
    UH0_End,
}
fn build_0(mut v0: i32, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        let mut v2: bool = v0 == 0i32;
        if v2 {
            return v1.clone();
        } else {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: Rc<UH0> = Rc::new(UH0::UH0_Link(v0, v1.clone()));
            (v0, v1) = (v3, v4.clone());
            continue;
        }
    }
}
fn sum_1(mut v0: Rc<UH0>, mut v1: i32) -> i32 {
    loop {
        match &*v0 {
            UH0::UH0_End => {
                return v1;
            }
            UH0::UH0_Link(v2, v3) => {
                let mut v2: i32 = *v2;
                let mut v3: Rc<UH0> = v3.clone();
                let mut v4: i32 = v1.wrapping_mul(31i32);
                let mut v5: i32 = v4.wrapping_add(v2);
                let mut v6: i32 = v5.wrapping_rem(9973i32);
                (v0, v1) = (v3.clone(), v6);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1000000i32;
    let mut v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_End); } CASE.with(|case| case.clone()) };
    let mut v2: Rc<UH0> = build_0(v0, v1.clone());
    let mut v3: i32 = 0i32;
    let mut v4: i32 = sum_1(v2.clone(), v3);
    let mut v5: i32 = v4.wrapping_rem(256i32);
    v5
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
