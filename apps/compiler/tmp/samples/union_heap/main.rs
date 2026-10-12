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
    US0_Missing,
    US0_Box(Rc<Heap0>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Missing => 0,
            US0::US0_Box(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Missing
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<Heap0> = Rc::new(Heap0 { l0: v0 });
    let mut v2: bool = true;
    let mut v5: US0 = if v2 {
        US0::US0_Box(v1.clone())
    } else {
        US0::US0_Missing
    };
    match &v5 {
        US0::US0_Box(v6) => {
            let mut v6: Rc<Heap0> = v6.clone();
            let mut v7: i32 = v6.l0.clone();
            let mut v8: bool = v7 == 7i32;
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
