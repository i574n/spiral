#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = v0.wrapping_mul(4i32);
    let v2: Rc<RefCell<Vec<u32>>> = Rc::new(RefCell::new(vec![<u32>::default(); v1 as usize]));
    let v3: i32 = (v2.borrow().len() as i32);
    let v4: i32 = v3.wrapping_sub(12i32);
    v4
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
