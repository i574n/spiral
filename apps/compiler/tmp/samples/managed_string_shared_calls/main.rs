#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn measure_0(mut v0: Rc<str>) -> i32 {
    let v1: i32 = (v0.len() as i32);
    v1
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("qwe"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = measure_0(v0.clone());
    let v2: i32 = measure_0(v0.clone());
    let v3: i32 = v1.wrapping_add(v2);
    let v4: i32 = v3.wrapping_sub(6i32);
    v4
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
