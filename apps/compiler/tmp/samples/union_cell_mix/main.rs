#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default() }
    }
}
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<Heap0>, i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_None => 0,
            US0::US0_Held(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2) => {
            let mut v1: Rc<Heap0> = v1.clone();
            let mut v2: i32 = *v2;
            let mut v3: i32 = v1.l0.clone();
            let mut v4: i32 = v3.wrapping_add(v2);
            let mut v5: bool = v4 == 7i32;
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
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 4i32;
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let mut v3: bool = true;
    let mut v6: US0 = if v3 {
        US0::US0_Held(v2.clone(), v1)
    } else {
        US0::US0_None
    };
    score_0(v6.clone())
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
