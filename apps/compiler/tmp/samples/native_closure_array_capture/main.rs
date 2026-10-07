#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: Rc<RefCell<Vec<i32>>>) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let mut v2: i32 = (v0.clone().borrow().len() as i32);
        let mut v3: i32 = v2.wrapping_add(v1);
        v3
    })
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 2i32 as usize]));
    let mut v1: Rc<dyn Fn(i32) -> i32> = closure0(v0.clone());
    v1(40i32)
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
