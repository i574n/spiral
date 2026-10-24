#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure1(mut v0: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let v2: i32 = v0.wrapping_mul(10i32);
        let v3: i32 = v2.wrapping_add(v1);
        v3
    })
}
fn f_c0() -> Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> = Rc::new(move |mut v0: i32| -> Rc<dyn Fn(i32) -> i32> {
        closure1(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> = f_c0();
    let mut v1: Rc<dyn Fn(i32) -> i32> = v0(3i32);
    let v2: i32 = v1(4i32);
    let v3: bool = v2 == 34i32;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
