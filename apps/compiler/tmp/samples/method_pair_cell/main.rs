#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
fn method0(mut v0: i32, mut v1: Rc<Heap0>) -> (Rc<Heap0>, i32) {
    (v1.clone(), v0)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 4i32;
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let (mut v3, mut v4): (Rc<Heap0>, i32) = method0(v1, v2.clone());
    let mut v5: i32 = v3.l0.clone();
    let mut v6: i32 = v5.wrapping_add(v4);
    let mut v7: bool = v6 == 7i32;
    if v7 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
