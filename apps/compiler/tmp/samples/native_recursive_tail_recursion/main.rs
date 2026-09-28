#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(i32, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0 => 0,
            UH0::UH0_1(..) => 1,
        }
    }
}
fn method2(mut v0: i32) -> Rc<UH0> {
    let mut v1: i32 = v0 - 1i32;
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: Rc<UH0> = Rc::new(UH0::UH0_0);
        Rc::new(UH0::UH0_1(7i32, v3.clone()))
    } else {
        method1(v1)
    }
}
fn method1(mut v0: i32) -> Rc<UH0> {
    let mut v1: i32 = v0 - 1i32;
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: Rc<UH0> = Rc::new(UH0::UH0_0);
        Rc::new(UH0::UH0_1(11i32, v3.clone()))
    } else {
        method2(v1)
    }
}
fn method0() -> Rc<UH0> {
    let mut v0: i32 = 1000000i32;
    let mut v1: bool = v0 == 0i32;
    if v1 {
        let mut v2: Rc<UH0> = Rc::new(UH0::UH0_0);
        Rc::new(UH0::UH0_1(7i32, v2.clone()))
    } else {
        method1(v0)
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<UH0> = method0();
    match &*v0 {
        UH0::UH0_1(v1, v2) => { // Box
            let mut v1: i32 = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: bool = v1 == 7i32;
            if v3 {
                0i32
            } else {
                3i32
            }
        }
        UH0::UH0_0 => { // Empty
            1i32
        }
        _ => unreachable!(),
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
