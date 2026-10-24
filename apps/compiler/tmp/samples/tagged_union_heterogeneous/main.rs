#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Hit(i32),
    US0_Flag(bool),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Flag(v2) => {
            let v2: bool = *v2;
            if v2 {
                9i32
            } else {
                4i32
            }
        }
        US0::US0_Hit(v1) => {
            let v1: i32 = *v1;
            v1
        }
    }
}
fn spiral_main() -> i32 {
    let v0: bool = false;
    let v3: US0 = if v0 {
        US0::US0_Hit(7i32)
    } else {
        US0::US0_Flag(true)
    };
    let v4: i32 = score_0(v3);
    let v5: i32 = v4.wrapping_sub(9i32);
    v5
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
