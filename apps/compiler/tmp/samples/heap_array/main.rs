#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: Rc<RefCell<Vec<i32>>> }
fn spiral_main() -> i32 {
    let v0: i32 = 2i32;
    let v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let v2: i32 = 7i32;
    v1.clone().borrow_mut()[0i32 as usize] = v2;
    let v3: Rc<Heap0> = Rc::new(Heap0 { l0: v1 });
    let v4: Rc<RefCell<Vec<i32>>> = v3.l0.clone();
    let v5: i32 = v4.borrow()[0i32 as usize].clone();
    let v6: bool = v5 == 7i32;
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
