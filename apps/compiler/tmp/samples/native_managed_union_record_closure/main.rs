#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<str>, i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn closure0() -> Rc<dyn Fn(i32) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> US0> = Rc::new(move |mut v0: i32| -> US0 {
        let mut v1: bool = v0 == 0i32;
        if v1 {
            US0::US0_0
        } else {
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("managed"); } LIT.with(|lit| lit.clone()) };
            US0::US0_1(v3.clone(), 32i32)
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(0i32)
}
fn method1(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(1i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> US0> = closure0();
    let mut v1: US0 = method0(v0.clone());
    let mut v7: i32 = match &v1 {
        US0::US0_0 => {
            3i32
        }
        US0::US0_1(v2, v3) => {
            let mut v2: Rc<str> = v2.clone();
            let mut v3: i32 = *v3;
            let mut v4: i32 = (v2.clone().len() as i32);
            let mut v5: i32 = v4.wrapping_add(v3);
            v5
        }
    };
    let mut v8: US0 = method1(v0.clone());
    let mut v14: i32 = match &v8 {
        US0::US0_0 => {
            3i32
        }
        US0::US0_1(v9, v10) => {
            let mut v9: Rc<str> = v9.clone();
            let mut v10: i32 = *v10;
            let mut v11: i32 = (v9.clone().len() as i32);
            let mut v12: i32 = v11.wrapping_add(v10);
            v12
        }
    };
    let mut v15: i32 = v7.wrapping_add(v14);
    v15
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
