#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: i32 }
fn spiral_main() -> i32 {
    let mut v0: Rc<Heap0> = Rc::new(Heap0 { l0: 9i32, l1: 10i32 });
    let mut v1: i32 = v0.l0.clone();
    let mut v2: i32 = v0.l1.clone();
    let mut v3: i32 = v1 + v2;
    v3
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
