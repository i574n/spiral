#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn g_c1(mut v0: i32, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let v3: bool = v1 == 0i32;
        if v3 {
            0i32
        } else {
            let v4: i32 = v2.wrapping_add(v0);
            v4
        }
    })
}
fn f_c0(mut v0: i32) -> Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> {
    Rc::new(move |mut v1: i32| -> Rc<dyn Fn(i32) -> i32> {
        g_c1(v0, v1)
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(i32) -> i32>> = f_c0(v0);
    let mut v2: Rc<dyn Fn(i32) -> i32> = v1(1i32);
    let v3: i32 = v2(0i32);
    let v4: bool = v3 == 7i32;
    if v4 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
