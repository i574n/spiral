#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Hit(i32),
    US0_Hold,
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: US0 = US0::US0_Hit(v0);
    let mut v2: US0 = US0::US0_Hold;
    let mut v5: i32 = match &v1 {
        US0::US0_Hit(v3) => {
            let mut v3: i32 = *v3;
            v3
        }
        US0::US0_Hold => {
            40i32
        }
    };
    let mut v8: i32 = match &v2 {
        US0::US0_Hit(v6) => {
            let mut v6: i32 = *v6;
            v6
        }
        US0::US0_Hold => {
            40i32
        }
    };
    let mut v9: i32 = v5.wrapping_add(v8);
    v9
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
