#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn gleam_marked_1(mut v0: i32) -> i32 {
    v0
}
fn picked_0(mut v0: i32) -> i32 {
    gleam_marked_1(v0)
}
fn spiral_main() -> i32 {
    let v0: i32 = 5i32;
    let v1: i32 = picked_0(v0);
    let v2: i32 = v1.wrapping_add(1i32);
    v2
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
