#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
enum US0 {
    US0_SBoxed(Box<dyn Fn() -> i32>),
    US0_SEmpty,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_SBoxed(..) => 0,
            US0::US0_SEmpty => 1,
        }
    }
}
enum UH0 {
    UH0_HBoxed(Box<dyn Fn() -> i32>),
    UH0_HEmpty,
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_HBoxed(..) => 0,
            UH0::UH0_HEmpty => 1,
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: bool = true;
    let mut v2: Box<dyn Fn() -> i32> = Box::new(move || v0 * 6) as Box<dyn Fn() -> i32>;
    let mut v5: US0 = if v1 {
        US0::US0_SBoxed(v2)
    } else {
        US0::US0_SEmpty
    };
    let mut v9: i32 = match v5 {
        US0::US0_SBoxed(v6) => {
            let mut v6: Box<dyn Fn() -> i32> = v6;
            let mut v7: i32 = (v6)();
            v7
        }
        US0::US0_SEmpty => {
            0i32
        }
    };
    let mut v10: Box<dyn Fn() -> i32> = Box::new(|| 7i32) as Box<dyn Fn() -> i32>;
    let mut v13: Rc<UH0> = if v1 {
        Rc::new(UH0::UH0_HBoxed(v10))
    } else {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_HEmpty); } CASE.with(|case| case.clone()) }
    };
    let mut v17: i32 = match &*v13 {
        UH0::UH0_HBoxed(v14) => {
            let mut v14 = v14;
            let mut v15: i32 = (v14)();
            v15
        }
        UH0::UH0_HEmpty => {
            0i32
        }
    };
    let mut v18: i32 = v9.wrapping_add(v17);
    v18
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
