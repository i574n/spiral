#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
struct Heap0 { l0: US0 }
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: bool = true;
    let mut v4: US0 = if v1 {
        US0::US0_Some(v0)
    } else {
        US0::US0_None
    };
    let mut v5: Rc<Heap0> = Rc::new(Heap0 { l0: v4.clone() });
    let mut v6: US0 = v5.l0.clone();
    match &v6 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v7) => {
            let mut v7: i32 = *v7;
            let mut v8: bool = v7 == 7i32;
            if v8 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
