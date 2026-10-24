#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 5i32;
    let v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    v1.clone().borrow_mut()[0i32 as usize] = 0i32;
    v1.clone().borrow_mut()[1i32 as usize] = 1i32;
    v1.clone().borrow_mut()[2i32 as usize] = 4i32;
    let v2: i32 = 3i32;
    v1.clone().borrow_mut()[v2 as usize] = 9i32;
    let v3: i32 = v2.wrapping_add(1i32);
    v1.clone().borrow_mut()[v3 as usize] = 16i32;
    let v4: Rc<RefCell<Vec<bool>>> = Rc::new(RefCell::new(vec![<bool>::default(); 3i32 as usize]));
    v4.clone().borrow_mut()[0i32 as usize] = false;
    v4.clone().borrow_mut()[1i32 as usize] = true;
    v4.clone().borrow_mut()[2i32 as usize] = false;
    let v5: i32 = v1.clone().borrow()[1i32 as usize].clone();
    let v6: i32 = v1.clone().borrow()[2i32 as usize].clone();
    let v7: i32 = v5.wrapping_add(v6);
    let v8: i32 = v1.clone().borrow()[3i32 as usize].clone();
    let v9: i32 = v7.wrapping_add(v8);
    let v10: i32 = v1.clone().borrow()[4i32 as usize].clone();
    let v11: i32 = v9.wrapping_add(v10);
    let v12: bool = v4.clone().borrow()[1i32 as usize].clone();
    let v15: i32 = if v12 {
        let v13: bool = v4.borrow()[0i32 as usize].clone();
        if v13 {
            0i32
        } else {
            100i32
        }
    } else {
        0i32
    };
    let v16: i32 = v11.wrapping_add(v15);
    let v17: i32 = (v1.borrow().len() as i32);
    let v18: i32 = v16.wrapping_add(v17);
    v18
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
