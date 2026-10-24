#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Idle,
    US0_Hit(i32),
    US0_Flag(bool),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Flag(v2) => {
            let v2: bool = *v2;
            if v2 {
                11i32
            } else {
                5i32
            }
        }
        US0::US0_Hit(v1) => {
            let v1: i32 = *v1;
            v1
        }
        US0::US0_Idle => {
            3i32
        }
    }
}
fn closure0(mut v0: US0) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let v2: i32 = score_0(v0.clone());
        let v3: i32 = v2.wrapping_add(v1);
        v3
    })
}
fn method1(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(31i32)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let v1: bool = v0 == 0i32;
    let v7: US0 = if v1 {
        US0::US0_Idle
    } else {
        let v3: bool = v0 == 1i32;
        if v3 {
            US0::US0_Hit(7i32)
        } else {
            US0::US0_Flag(true)
        }
    };
    let v8: Rc<dyn Fn(i32) -> i32> = closure0(v7);
    method1(v8)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
