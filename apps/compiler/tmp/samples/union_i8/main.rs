#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Missing,
    US0_Held(i8),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Missing => 0,
            US0::US0_Held(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Missing
    }
}
fn spiral_main() -> i32 {
    let mut v0: i8 = 100i8;
    let mut v1: bool = true;
    let mut v4: US0 = if v1 {
        US0::US0_Held(v0)
    } else {
        US0::US0_Missing
    };
    match &v4 {
        US0::US0_Held(v5) => {
            let mut v5: i8 = *v5;
            let mut v6: bool = v5 == 100i8;
            if v6 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_Missing => {
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
