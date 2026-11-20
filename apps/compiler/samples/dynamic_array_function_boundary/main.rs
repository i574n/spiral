#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut xs_v0: &Rc<RefCell<Vec<i32>>>, mut i_v1: i32) -> i32 {
    let v2: i32 = xs_v0.borrow()[i_v1 as usize];
    let v3: i32 = (xs_v0.borrow().len() as i32);
    let v4: i32 = v2.wrapping_add(v3);
    let v5: i32 = v4.wrapping_sub(10i32);
    v5
}
fn spiral_main() -> i32 {
    let n_v0: i32 = 3i32;
    let mut xs_v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); n_v0 as usize]));
    xs_v1.borrow_mut()[0i32 as usize] = 2i32;
    xs_v1.borrow_mut()[1i32 as usize] = 5i32;
    xs_v1.borrow_mut()[2i32 as usize] = 7i32;
    let i_v2: i32 = 2i32;
    method0(&xs_v1, i_v2)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
