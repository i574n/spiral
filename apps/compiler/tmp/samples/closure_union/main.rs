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
fn f_c0(mut v0: i32) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v1: i32| -> US0 {
        let mut v2: bool = v1 == 0i32;
        if v2 {
            US0::US0_None
        } else {
            US0::US0_Some(v0)
        }
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: Rc<dyn Fn(i32) -> US0> = f_c0(v0);
    let mut v2: US0 = v1(1i32);
    match &v2 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v3) => {
            let mut v3: i32 = *v3;
            let mut v4: bool = v3 == 7i32;
            if v4 {
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
