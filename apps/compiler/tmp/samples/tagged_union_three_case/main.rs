#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(i32),
    US0_2(bool),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1(..) => 1,
            US0::US0_2(..) => 2,
        }
    }
}
fn method0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_2(v2) => { // Flag
            let mut v2: bool = v2.clone();
            if v2 {
                11i32
            } else {
                5i32
            }
        }
        US0::US0_1(v1) => { // Hit
            let mut v1: i32 = v1.clone();
            v1
        }
        US0::US0_0 => { // Idle
            3i32
        }
        _ => unreachable!(),
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: bool = v0 == 0i32;
    let mut v7: US0 = if v1 {
        US0::US0_0
    } else {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            US0::US0_1(7i32)
        } else {
            US0::US0_2(true)
        }
    };
    let mut v8: i32 = method0(v7.clone());
    let mut v9: i32 = v8 - 11i32;
    v9
}
fn main() {
    std::process::exit(spiral_main());
}
