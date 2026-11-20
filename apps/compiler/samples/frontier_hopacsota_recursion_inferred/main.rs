#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn count_0(mut v0: i32) -> i32 {
    loop {
        let v1: bool = v0 <= 0i32;
        if v1 {
            return 0i32;
        } else {
            let v2: i32 = v0.wrapping_sub(1i32);
            v0 = v2;
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 5i32;
    count_0(v0)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
