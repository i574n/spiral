#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: Rc<RefCell<Vec<f32>>>, l1: i32 }
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<f32>>> = Rc::new(RefCell::new(vec![<f32>::default(); 1i32 as usize]));
    let v1: f32 = 1.5f32;
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let v2: i32 = 7i32;
    let v3: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v2 });
    let (mut v4, mut v5): (Rc<RefCell<Vec<f32>>>, i32) = (v3.l0.clone(), v3.l1.clone());
    let v6: f32 = v4.borrow()[0i32 as usize].clone();
    let v7: bool = v6 == 1.5f32;
    let v9: bool = if v7 {
        let v8: bool = v5 == 7i32;
        v8
    } else {
        false
    };
    if v9 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
