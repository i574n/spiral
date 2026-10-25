#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
fn f_c0(mut v0: i32, mut v1: Rc<Heap0>) -> Rc<dyn Fn(i32) -> (US0, Rc<Heap0>)> {
    Rc::new(move |mut v2: i32| -> (US0, Rc<Heap0>) {
        let mut v3: bool = v2 == 0i32;
        if v3 {
            let v4: US0 = US0::US0_None;
            (v4.clone(), v1.clone())
        } else {
            let v5: US0 = US0::US0_Some(v0);
            (v5.clone(), v1.clone())
        }
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = 4i32;
    let v2: Rc<Heap0> = Rc::new(Heap0 { l0: v1 });
    let mut v3: Rc<dyn Fn(i32) -> (US0, Rc<Heap0>)> = f_c0(v0, v2);
    let (mut v4, mut v5): (US0, Rc<Heap0>) = v3(1i32);
    match &v4 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v6) => {
            let v6: i32 = *v6;
            let v7: i32 = v5.l0.clone();
            let v8: i32 = v6.wrapping_add(v7);
            let v9: bool = v8 == 7i32;
            if v9 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
