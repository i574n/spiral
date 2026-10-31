#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Nil,
    UH0_Cons(i32, Rc<UH0>),
}
fn sum_0(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_Cons(v1, v2) => {
            let v1: i32 = *v1;
            let v2: Rc<UH0> = v2.clone();
            let v3: i32 = sum_0(v2);
            let v4: i32 = v1.wrapping_add(v3);
            v4
        }
        UH0::UH0_Nil => {
            0i32
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: i32 = 2i32;
    let v2: i32 = 3i32;
    let v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v4: Rc<UH0> = Rc::new(UH0::UH0_Cons(v2, v3));
    let v5: Rc<UH0> = Rc::new(UH0::UH0_Cons(v1, v4));
    let v6: Rc<UH0> = Rc::new(UH0::UH0_Cons(v0, v5));
    let v7: i32 = sum_0(v6);
    let v8: i32 = v7.wrapping_sub(6i32);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
