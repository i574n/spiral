#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Idle,
    US0_Hit(i32),
    US0_Flag(bool),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Idle => 0,
            US0::US0_Hit(..) => 1,
            US0::US0_Flag(..) => 2,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Idle
    }
}
fn closure0(mut v0: i32) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v1: i32| -> US0 {
        let mut v2: bool = v1 == v0;
        US0::US0_Flag(v2)
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> US0>, mut v1: i32) -> US0 {
    v0(v1)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<dyn Fn(i32) -> US0> = closure0(v0);
    let mut v2: US0 = method0(v1.clone(), v0);
    let mut v8: i32 = match &v2 {
        US0::US0_Flag(v4) => {
            let mut v4: bool = *v4;
            if v4 {
                11i32
            } else {
                5i32
            }
        }
        US0::US0_Hit(v3) => {
            let mut v3: i32 = *v3;
            v3
        }
        US0::US0_Idle => {
            3i32
        }
    };
    let mut v9: i32 = v8.wrapping_add(31i32);
    v9
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
