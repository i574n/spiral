#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<f64>>> = Rc::new(RefCell::new(vec![<f64>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 1.5f64;
    v1.clone().borrow_mut()[1i32 as usize] = 2.5f64;
    let mut v2: i32 = 1i32;
    let mut v3: f64 = v1.clone().borrow()[v2 as usize].clone();
    let mut v4: bool = v3 >= 2.0f64;
    if v4 {
        0i32
    } else {
        1i32
    }
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
