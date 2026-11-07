#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Northward,
    US0_Eastward,
    US0_Southward,
    US0_Westward,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Northward => 0,
            US0::US0_Eastward => 1,
            US0::US0_Southward => 2,
            US0::US0_Westward => 3,
        }
    }
}
fn spiral_main() -> i32 {
    let v0: US0 = US0::US0_Southward;
    let v1: i32 = (v0.tag() as i32);
    let v2: bool = v1 == 2i32;
    if v2 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
