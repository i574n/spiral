#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
// m1
// a1
// c1
// a2
// b1
// m2
fn leaf_c_1() -> i32 {
    0i32
}
fn slow_a_0() -> i32 {
    let v0: i32 = leaf_c_1();
    v0
}
fn fast_b_2() -> i32 {
    0i32
}
fn spiral_main() -> i32 {
    let v0: i32 = slow_a_0();
    let v1: i32 = fast_b_2();
    let v2: i32 = v0.wrapping_add(v1);
    v2
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
