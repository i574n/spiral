#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
    // one copy of this multi-line global, whatever the call count
    // the closing quote sits left of the content on purpose
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: i32 = v0.wrapping_add(1i32);
    let v2: i32 = v1.wrapping_add(v1);
    let v3: i32 = v2.wrapping_add(v1);
    let v4: i32 = v3.wrapping_sub(6i32);
    v4
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
