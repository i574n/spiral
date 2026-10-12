#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Rc<RefCell<Vec<u32>>> = Rc::new(RefCell::new(vec![<u32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 4000000000u32;
    v1.clone().borrow_mut()[1i32 as usize] = 1u32;
    let mut v2: u32 = v1.clone().borrow()[0i32 as usize].clone();
    let mut v3: u32 = v1.clone().borrow()[1i32 as usize].clone();
    let mut v4: u32 = v2.wrapping_add(v3);
    let mut v5: i32 = (v1.clone().borrow().len() as i32);
    let mut v6: bool = v5 == v0;
    let mut v8: bool = if v6 {
        let mut v7: bool = v4 == 4000000001u32;
        v7
    } else {
        false
    };
    if v8 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
