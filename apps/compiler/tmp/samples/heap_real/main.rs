#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: f64 }
fn spiral_main() -> i32 {
    let mut v0: f64 = 1.5f64;
    let mut v1: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let mut v2: f64 = v1.l0.clone();
    let mut v3: bool = v2 == 1.5f64;
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
