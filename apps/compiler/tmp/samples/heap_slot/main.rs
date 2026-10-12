#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_None => 0,
            US0::US0_Some(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
struct Heap0 { l0: US0, l1: i32 }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <US0>::default(), l1: <i32>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 4i32;
    let mut v2: US0 = US0::US0_Some(v0);
    let mut v3: Rc<Heap0> = Rc::new(Heap0 { l0: v2.clone(), l1: v1 });
    let (mut v4, mut v5): (US0, i32) = (v3.l0.clone(), v3.l1.clone());
    match &v4 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v6) => {
            let mut v6: i32 = *v6;
            let mut v7: i32 = v6.wrapping_add(v5);
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
