#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
fn f_c0(mut v0: Rc<Heap0>) -> Rc<dyn Fn(i32) -> Rc<Heap0>> {
    Rc::new(move |mut v1: i32| -> Rc<Heap0> {
        v0.clone()
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let mut v2: Rc<dyn Fn(i32) -> Rc<Heap0>> = f_c0(v1);
    let v3: Rc<Heap0> = v2(1i32);
    let v4: i32 = v3.l0.clone();
    let v5: bool = v4 == 7i32;
    if v5 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
