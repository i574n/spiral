#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4i32 as usize]));
    v0.clone().borrow_mut()[0i32 as usize] = 7i32;
    v0.clone().borrow_mut()[1i32 as usize] = 7i32;
    v0.clone().borrow_mut()[2i32 as usize] = 7i32;
    v0.clone().borrow_mut()[3i32 as usize] = 7i32;
    let v1: i32 = v0.borrow()[3i32 as usize].clone();
    let v2: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4i32 as usize]));
    v2.clone().borrow_mut()[0i32 as usize] = 5i32;
    let v3: i32 = v2.clone().borrow()[3i32 as usize].clone();
    let v4: i32 = v2.borrow()[0i32 as usize].clone();
    let v5: i32 = v3.wrapping_mul(100i32);
    let v6: i32 = v5.wrapping_add(v4);
    let v7: i32 = v1.wrapping_sub(7i32);
    let v8: i32 = v6.wrapping_add(v7);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
