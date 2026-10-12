#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: Rc<RefCell<Vec<f64>>> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <Rc<RefCell<Vec<f64>>>>::default() }
    }
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<f64>>> = Rc::new(RefCell::new(vec![<f64>::default(); 1i32 as usize]));
    let mut v1: f64 = 1.5f64;
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0.clone() });
    let mut v3: Rc<RefCell<Vec<f64>>> = v2.l0.clone();
    let mut v4: f64 = v3.clone().borrow()[0i32 as usize].clone();
    let mut v5: bool = v4 == 1.5f64;
    if v5 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
