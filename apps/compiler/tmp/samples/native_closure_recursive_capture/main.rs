#![allow(unused_mut, unused_variables, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(i32, Rc<UH0>, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0 => 0,
            UH0::UH0_1(..) => 1,
        }
    }
}
fn method0(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_0 => { // Leaf
            0i32
        }
        UH0::UH0_1(v1, v2, v3) => { // Node
            let mut v1: i32 = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: i32 = method0(v2.clone());
            let mut v5: i32 = method0(v3.clone());
            let mut v6: i32 = v4 + v5;
            let mut v7: i32 = v1 + v6;
            v7
        }
        _ => unreachable!(),
    }
}
fn closure0(mut v0: Rc<UH0>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = method0(v0.clone());
        let mut v3: i32 = v2 + v1;
        v3
    })
}
fn spiral_main() -> i32 {
    let mut v0: Rc<UH0> = Rc::new(UH0::UH0_0);
    let mut v1: i32 = 2i32;
    let mut v2: Rc<UH0> = Rc::new(UH0::UH0_1(v1, v0.clone(), v0.clone()));
    let mut v3: Rc<dyn Fn(i32) -> i32> = closure0(v2.clone());
    let mut v4: i32 = v3(19i32);
    let mut v5: i32 = v3(19i32);
    let mut v6: i32 = v4 + v5;
    v6
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
