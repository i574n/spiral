#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<u64>>> = Rc::new(RefCell::new(vec![<u64>::default(); 1i32 as usize]));
    let v1: u64 = 4294967297u64;
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let v2: u64 = v0.borrow()[0i32 as usize].clone();
    let v3: bool = v2 == 4294967297u64;
    if v3 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
