#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = v1.wrapping_add(v0);
        v2
    })
}
fn closure1(mut v0: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = v1.wrapping_add(v0);
        v2
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(40i32)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: i32 = 3i32;
    let mut v2: bool = true;
    let mut v5: Rc<dyn Fn(i32) -> i32> = if v2 {
        closure0(v0)
    } else {
        closure1(v1)
    };
    method0(v5.clone())
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
