#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1(Rc<RefCell<Vec<i32>>>),
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
            let mut v3: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 2i32 as usize]));
            v3.clone().borrow_mut()[0i32 as usize] = v0;
            let mut v4: i32 = v0 + 1i32;
            v3.clone().borrow_mut()[1i32 as usize] = v4;
            US0::US0_1(v3.clone())
        }
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(0i32)
}
fn method1(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_0 => { // Empty
            3i32
        }
        US0::US0_1(v1) => { // Values
            let mut v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            let mut v2: i32 = (v1.clone().borrow().len() as i32);
            let mut v3: i32 = v1.clone().borrow()[0i32 as usize].clone();
            let mut v4: i32 = v2 + v3;
            let mut v5: i32 = v1.clone().borrow()[1i32 as usize].clone();
            let mut v6: i32 = v4 + v5;
            v6
        }
        _ => unreachable!(),
    }
}
fn method2(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(4i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> US0> = closure0();
    let mut v1: US0 = method0(v0.clone());
    let mut v2: i32 = method1(v1.clone());
    let mut v3: US0 = method2(v0.clone());
    let mut v4: i32 = method1(v3.clone());
    let mut v5: i32 = v2 + v4;
    let mut v6: i32 = v5 + 28i32;
    v6
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
