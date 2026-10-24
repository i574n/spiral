#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 4i32;
    let v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 10i32;
    v1.clone().borrow_mut()[1i32 as usize] = 20i32;
    v1.clone().borrow_mut()[2i32 as usize] = 30i32;
    let v2: i32 = v1.clone().borrow()[0i32 as usize].clone();
    let v3: i32 = v1.clone().borrow()[1i32 as usize].clone();
    let v4: i32 = v2.wrapping_add(v3);
    v1.clone().borrow_mut()[3i32 as usize] = v4;
    let v5: i32 = v1.clone().borrow()[2i32 as usize].clone();
    let v6: i32 = v1.clone().borrow()[3i32 as usize].clone();
    let v7: i32 = v5.wrapping_add(v6);
    let v8: i32 = (v1.borrow().len() as i32);
    let v9: bool = v8 == v0;
    let v11: bool = if v9 {
        let v10: bool = v7 == 60i32;
        v10
    } else {
        false
    };
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
