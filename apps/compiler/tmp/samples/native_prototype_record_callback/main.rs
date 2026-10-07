#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: i32) -> Rc<dyn Fn(i32, i32) -> (i32, i32)> {
    Rc::new(move |mut v1: i32, mut v2: i32| -> (i32, i32) {
        let mut v3: i32 = v1.wrapping_sub(8i32);
        let mut v4: i32 = v3.wrapping_add(v0);
        let mut v5: i32 = v2.wrapping_sub(18i32);
        (v4, v5)
    })
}
fn method0(mut v0: Rc<dyn Fn(i32, i32) -> (i32, i32)>) -> (i32, i32) {
    v0(10i32, 20i32)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: Rc<dyn Fn(i32, i32) -> (i32, i32)> = closure0(v0);
    let (mut v2, mut v3): (i32, i32) = method0(v1.clone());
    let mut v4: i32 = 10i32.wrapping_add(v2);
    let mut v5: i32 = 20i32.wrapping_add(v3);
    let mut v6: i32 = v4.wrapping_add(v5);
    let mut v7: i32 = v6.wrapping_add(7i32);
    v7
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
