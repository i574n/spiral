#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Missing,
    US0_Call(Rc<dyn Fn(i32) -> i32>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Missing => 0,
            US0::US0_Call(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Missing
    }
}
fn f_c0(mut v0: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = v1.wrapping_add(v0);
        v2
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<dyn Fn(i32) -> i32> = f_c0(v0);
    let mut v2: bool = true;
    let mut v5: US0 = if v2 {
        US0::US0_Call(v1.clone())
    } else {
        US0::US0_Missing
    };
    match &v5 {
        US0::US0_Call(v6) => {
            let mut v6: Rc<dyn Fn(i32) -> i32> = v6.clone();
            let mut v7: i32 = v6(4i32);
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
