#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure1(mut v0: Rc<str>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = (v0.clone().len() as i32);
        let mut v3: i32 = v2 + v1;
        v3
    })
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(i32) -> i32>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(i32) -> i32>> = Rc::new(move |mut v0: Rc<str>| -> Rc<dyn Fn(i32) -> i32> {
        closure1(v0.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(39i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(i32) -> i32>> = closure0();
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("abc"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<dyn Fn(i32) -> i32> = v0(v1.clone());
    method0(v2.clone())
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
