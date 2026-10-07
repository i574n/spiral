#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0(Rc<str>),
    US0_1(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1(..) => 1,
        }
    }
}
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_1(v3) => { // Number
            let mut v3: i32 = *v3;
            v3
        }
        US0::US0_0(v1) => { // Text
            let mut v1: Rc<str> = v1.clone();
            let mut v2: i32 = (v1.clone().len() as i32);
            v2
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = false;
    let mut v4: US0 = if v0 {
        US0::US0_1(7i32)
    } else {
        let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("qwe"); } LIT.with(|lit| lit.clone()) };
        US0::US0_0(v2.clone())
    };
    let mut v5: i32 = method0(v4.clone());
    let mut v6: i32 = method0(v4.clone());
    let mut v7: i32 = v5.wrapping_add(v6);
    let mut v8: i32 = v7.wrapping_sub(6i32);
    v8
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
