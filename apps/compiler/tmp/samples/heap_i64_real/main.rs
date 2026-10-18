#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i64, l1: f64 }
fn spiral_main() -> i32 {
    let mut v0: i64 = 5000000000i64;
    let mut v1: f64 = 1.5f64;
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let (mut v3, mut v4): (i64, f64) = (v2.l0.clone(), v2.l1.clone());
    let mut v5: bool = v3 == 5000000000i64;
    let mut v7: bool = if v5 {
        let mut v6: bool = v4 == 1.5f64;
        v6
    } else {
        false
    };
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
