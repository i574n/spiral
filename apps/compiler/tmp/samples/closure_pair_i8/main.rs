#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn f_c0(mut v0: i8) -> Rc<dyn Fn(i32) -> (i8, i8)> {
    Rc::new(move |mut v1: i32| -> (i8, i8) {
        let mut v2: bool = v1 == 0i32;
        if v2 {
            (0i8, 0i8)
        } else {
            (v0, 7i8)
        }
    })
}
fn spiral_main() -> i32 {
    let mut v0: i8 = 100i8;
    let mut v1: Rc<dyn Fn(i32) -> (i8, i8)> = f_c0(v0);
    let (mut v2, mut v3): (i8, i8) = v1(1i32);
    let mut v4: bool = v2 == 100i8;
    let mut v6: bool = if v4 {
        let mut v5: bool = v3 == 7i8;
        v5
    } else {
        false
    };
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
