#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn right_c1(mut v0: i32, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let mut v3: bool = v1 == 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: i32 = v2.wrapping_add(v0);
            v4
        }
    })
}
fn left_c2(mut v0: i32, mut v1: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v2: i32| -> i32 {
        let mut v3: bool = v1 == 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: i32 = v2.wrapping_add(v0);
            v4
        }
    })
}
fn f_c0(mut v0: i32, mut v1: i32) -> Rc<dyn Fn(i32) -> (Rc<dyn Fn(i32) -> i32>, Rc<dyn Fn(i32) -> i32>)> {
    Rc::new(move |mut v2: i32| -> (Rc<dyn Fn(i32) -> i32>, Rc<dyn Fn(i32) -> i32>) {
        let mut v3: bool = v2 == 0i32;
        if v3 {
            let mut v4: Rc<dyn Fn(i32) -> i32> = right_c1(v1, v2);
            let mut v5: Rc<dyn Fn(i32) -> i32> = left_c2(v0, v2);
            (v4.clone(), v5.clone())
        } else {
            let mut v6: Rc<dyn Fn(i32) -> i32> = left_c2(v0, v2);
            let mut v7: Rc<dyn Fn(i32) -> i32> = right_c1(v1, v2);
            (v6.clone(), v7.clone())
        }
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 4i32;
    let mut v2: Rc<dyn Fn(i32) -> (Rc<dyn Fn(i32) -> i32>, Rc<dyn Fn(i32) -> i32>)> = f_c0(v0, v1);
    let (mut v3, mut v4): (Rc<dyn Fn(i32) -> i32>, Rc<dyn Fn(i32) -> i32>) = v2(1i32);
    let mut v5: i32 = v3(0i32);
    let mut v6: i32 = v4(0i32);
    let mut v7: i32 = v5.wrapping_add(v6);
    let mut v8: bool = v7 == 7i32;
    if v8 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
