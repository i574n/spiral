#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0(i32),
    US0_1(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0(v1) => { // Hit
            let mut v1: i32 = *v1;
            v1
        }
        US0::US0_1(v2) => { // Miss
            let mut v2: i32 = *v2;
            let mut v3: i32 = v2.wrapping_neg();
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v3: US0 = if v0 {
        US0::US0_0(7i32)
    } else {
        US0::US0_1(3i32)
    };
    let mut v4: i32 = method0(v3.clone());
    let mut v5: i32 = v4.wrapping_sub(7i32);
    v5
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
