#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0,
    UH0_1(Rc<RefCell<Vec<i32>>>, Rc<UH0>),
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
        UH0::UH0_1(v1, v2) => {
            let mut v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: i32 = (v1.clone().borrow().len() as i32);
            let mut v4: i32 = method0(v2.clone());
            let mut v5: i32 = v3.wrapping_add(v4);
            v5
        }
        UH0::UH0_0 => {
            0i32
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let mut v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_0); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v2.clone()));
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_1(v1.clone(), v3.clone()));
    let mut v5: i32 = method0(v4.clone());
    let mut v6: i32 = v5.wrapping_sub(4i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
