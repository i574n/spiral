#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
#[derive(Clone)]
enum US0 {
    US0_Missing,
    US0_Box(Rc<Heap0>),
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let v2: bool = true;
    let v5: US0 = if v2 {
        US0::US0_Box(v1)
    } else {
        US0::US0_Missing
    };
    match &v5 {
        US0::US0_Box(v6) => {
            let v6: Rc<Heap0> = v6.clone();
            let v7: i32 = v6.l0.clone();
            let v8: bool = v7 == 7i32;
            if v8 {
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
