#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_First,
    US0_Second,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_First => 1,
            US0::US0_Second => 2,
        }
    }
}
fn spiral_main() -> i32 {
    let v0: US0 = US0::US0_Second;
    let v1: i32 = (v0.tag() as i32);
    let v2: i32 = v1.wrapping_mul(10i32);
    let v3: i32 = v2.wrapping_add(2i32);
    v3
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
