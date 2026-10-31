#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Circle(i32),
    US0_Square(i32),
    US0_Triangle(i32),
    US0_Dot,
}
fn method1(mut v0: i32) -> i32 {
    let v1: i32 = v0.wrapping_mul(v0);
    let v2: i32 = 7i32.wrapping_mul(v0);
    let v3: i32 = v1.wrapping_add(v2);
    let v4: i32 = v3.wrapping_sub(3i32);
    v4
}
fn area_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Circle(v1) => {
            let v1: i32 = *v1;
            method1(v1)
        }
        US0::US0_Dot => {
            0i32
        }
        US0::US0_Square(v3) => {
            let v3: i32 = *v3;
            method1(v3)
        }
        US0::US0_Triangle(v5) => {
            let v5: i32 = *v5;
            method1(v5)
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 4i32;
    let v1: US0 = US0::US0_Square(v0);
    area_0(v1)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
