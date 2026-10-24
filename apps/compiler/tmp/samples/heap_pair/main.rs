#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32, l1: i32 }
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = 4i32;
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1 });
    let (mut v3, mut v4): (i32, i32) = (v2.l0.clone(), v2.l1.clone());
    let v5: i32 = v3.wrapping_add(v4);
    let v6: bool = v5 == 7i32;
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
