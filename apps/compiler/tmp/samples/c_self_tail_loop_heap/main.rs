#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn loop_0(mut v0: i32, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
    loop {
        let v5: bool = v3 >= v0;
        if v5 {
            return v4;
        } else {
            let v6: i32 = v3.wrapping_rem(4i32);
            let v7: i32 = v1.clone().borrow()[v6 as usize].clone();
            let v8: i32 = v3.wrapping_add(1i32);
            let v9: i32 = v4.wrapping_mul(7i32);
            let v10: i32 = v9.wrapping_add(v7);
            let v11: i32 = v10.wrapping_add(v2);
            let v12: i32 = v11.wrapping_rem(9973i32);
            (v0, v1, v2, v3, v4) = (v0, v1.clone(), v2, v8, v12);
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 4i32 as usize]));
    v0.clone().borrow_mut()[0i32 as usize] = 1i32;
    v0.clone().borrow_mut()[1i32 as usize] = 2i32;
    v0.clone().borrow_mut()[2i32 as usize] = 3i32;
    v0.clone().borrow_mut()[3i32 as usize] = 4i32;
    let v1: i32 = 0i32;
    let v2: i32 = 1000000i32;
    let v3: i32 = 0i32;
    let v4: i32 = 0i32;
    let v5: i32 = loop_0(v2, v0, v1, v3, v4);
    let v6: i32 = v5.wrapping_rem(256i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
