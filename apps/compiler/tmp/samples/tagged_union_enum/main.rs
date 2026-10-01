#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1,
    US0_2,
    US0_3,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1 => 1,
            US0::US0_2 => 2,
            US0::US0_3 => 3,
        }
    }
}
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Cold
            1i32
        }
        US0::US0_1 => { // Warm
            2i32
        }
        US0::US0_2 => { // Hot
            3i32
        }
        US0::US0_3 => { // Done
            4i32
        }
        _ => unreachable!(),
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: bool = v0 == 0i32;
    let mut v10: US0 = if v1 {
        US0::US0_0
    } else {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            US0::US0_1
        } else {
            let mut v5: bool = v0 == 2i32;
            if v5 {
                US0::US0_2
            } else {
                US0::US0_3
            }
        }
    };
    let mut v11: i32 = method0(v10.clone());
    let mut v12: i32 = v11 - 4i32;
    v12
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
