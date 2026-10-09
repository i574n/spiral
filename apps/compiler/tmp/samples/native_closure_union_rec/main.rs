#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Cons(u64, Rc<dyn Fn() -> Rc<UH0>>),
    UH0_Nil,
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_Cons(..) => 0,
            UH0::UH0_Nil => 1,
        }
    }
}
fn closure0(mut v0: u64) -> Rc<dyn Fn() -> Rc<UH0>> {
    Rc::new(move || -> Rc<UH0> {
        let mut v1: u64 = v0.wrapping_sub(1u64);
        build_0(v1)
    })
}
fn build_0(mut v0: u64) -> Rc<UH0> {
    let mut v1: bool = v0 == 0u64;
    if v1 {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) }
    } else {
        let mut v3: Rc<dyn Fn() -> Rc<UH0>> = closure0(v0);
        Rc::new(UH0::UH0_Cons(v0, v3.clone()))
    }
}
fn sum_1(mut v0: Rc<UH0>, mut v1: u64) -> u64 {
    loop {
        match &*v0 {
            UH0::UH0_Cons(v2, v3) => {
                let mut v2: u64 = *v2;
                let mut v3: Rc<dyn Fn() -> Rc<UH0>> = v3.clone();
                let mut v4: Rc<UH0> = v3();
                let mut v5: u64 = v1.wrapping_add(v2);
                (v0, v1) = (v4.clone(), v5);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: u64 = 10u64;
    let mut v1: Rc<UH0> = build_0(v0);
    let mut v2: u64 = 0u64;
    let mut v3: u64 = sum_1(v1.clone(), v2);
    let mut v4: i32 = 5i32;
    let mut v5: i32 = (v3 as i32);
    let mut v6: i32 = v4.wrapping_mul(2i32);
    let mut v7: i32 = v4.wrapping_add(v6);
    let mut v8: i32 = v5.wrapping_add(v7);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
