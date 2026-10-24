#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap0>, i32),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2) => {
            let v1: Rc<Heap0> = v1.clone();
            let v2: i32 = *v2;
            let v3: i32 = v1.l0.clone();
            let v4: i32 = v3.wrapping_add(v2);
            let v5: bool = v4 == 7i32;
            if v5 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_None => {
            1i32
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = 4i32;
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let v3: bool = true;
    let v6: US0 = if v3 {
        US0::US0_Held(v2, v1)
    } else {
        US0::US0_None
    };
    score_0(v6)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
