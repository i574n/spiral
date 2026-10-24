#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: i32 }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <i32>::default() }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 2i32;
    let v1: Rc<RefCell<Vec<Rc<Heap0>>>> = Rc::new(RefCell::new(vec![<Rc<Heap0>>::default(); v0 as usize]));
    let v2: i32 = 4i32;
    let v3: i32 = 6i32;
    let v4: Rc<Heap0> = Rc::new(Heap0 { l0: v2 });
    v1.clone().borrow_mut()[0i32 as usize] = v4;
    let v5: Rc<Heap0> = Rc::new(Heap0 { l0: v3 });
    v1.clone().borrow_mut()[1i32 as usize] = v5;
    let v6: Rc<Heap0> = v1.clone().borrow()[0i32 as usize].clone();
    let v7: i32 = v6.l0.clone();
    let v8: Rc<Heap0> = v1.borrow()[1i32 as usize].clone();
    let v9: i32 = v8.l0.clone();
    let v10: i32 = v7.wrapping_add(v9);
    let v11: bool = v10 == 10i32;
    if v11 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
