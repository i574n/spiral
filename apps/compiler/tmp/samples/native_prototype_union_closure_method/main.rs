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
fn closure0(mut v0: US0) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v7: i32 = match &v0 {
            US0::US0_2(v3) => { // Flag
                let mut v3: bool = v3.clone();
                if v3 {
                    11i32
                } else {
                    5i32
                }
            }
            US0::US0_1(v2) => { // Hit
                let mut v2: i32 = v2.clone();
                v2
            }
            US0::US0_0 => { // Idle
                3i32
            }
            _ => unreachable!(),
        };
        let mut v8: i32 = v7 + v1;
        v8
    })
}
fn method0(mut v0: Rc<dyn Fn(i32) -> i32>) -> i32 {
    v0(31i32)
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
    let mut v8: Rc<dyn Fn(i32) -> i32> = closure0(v7.clone());
    method0(v8.clone())
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
