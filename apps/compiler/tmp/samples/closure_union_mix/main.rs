#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_One(i32),
    US0_Both(i32, Rc<str>),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_One(..) => 0,
            US0::US0_Both(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_One(<i32>::default())
    }
}
fn f_c0(mut v0: i32, mut v1: Rc<str>) -> Rc<dyn Fn(i32) -> US0> {
    Rc::new(move |mut v2: i32| -> US0 {
        let mut v3: bool = v2 == 0i32;
        if v3 {
            US0::US0_One(0i32)
        } else {
            US0::US0_Both(v0, v1.clone())
        }
    })
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<dyn Fn(i32) -> US0> = f_c0(v0, v1.clone());
    let mut v3: US0 = v2(1i32);
    match &v3 {
        US0::US0_Both(v5, v6) => {
            let mut v5: i32 = *v5;
            let mut v6: Rc<str> = v6.clone();
            let mut v7: bool = v5 == 3i32;
            let mut v9: bool = if v7 {
                let mut v8: bool = v6.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
                v8
            } else {
                false
            };
            if v9 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_One(v4) => {
            let mut v4: i32 = *v4;
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
