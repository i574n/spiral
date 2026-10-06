#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
enum US0 {
    US0_0(Box<dyn Fn() -> i32>),
    US0_1,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1 => 1,
        }
    }
}
enum UH0 {
    UH0_0(Box<dyn Fn() -> i32>),
    UH0_1,
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0(..) => 0,
            UH0::UH0_1 => 1,
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: bool = true;
    let mut v2: Box<dyn Fn() -> i32> = Box::new(move || v0 * 6) as Box<dyn Fn() -> i32>;
    let mut v5: US0 = if v1 {
        US0::US0_0(v2)
    } else {
        US0::US0_1
    };
    let mut v9: i32 = match v5 {
        US0::US0_0(v6) => { // SBoxed
            let mut v6: Box<dyn Fn() -> i32> = v6;
            let mut v7: i32 = (v6)();
            v7
        }
        US0::US0_1 => { // SEmpty
            0i32
        }
        _ => unreachable!(),
    };
    let mut v10: Box<dyn Fn() -> i32> = Box::new(|| 7i32) as Box<dyn Fn() -> i32>;
    let mut v13: Rc<UH0> = if v1 {
        Rc::new(UH0::UH0_0(v10))
    } else {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
    };
    let mut v17: i32 = match &*v13 {
        UH0::UH0_0(v14) => { // HBoxed
            let mut v14 = v14;
            let mut v15: i32 = (v14)();
            v15
        }
        UH0::UH0_1 => { // HEmpty
            0i32
        }
        _ => unreachable!(),
    };
    let mut v18: i32 = v9 + v17;
    v18
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
