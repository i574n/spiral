#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn fill_0(mut v0: i32, mut v1: Rc<RefCell<Vec<i32>>>, mut v2: i32) -> () {
    loop {
        let mut v3: bool = v2 < v0;
        if v3 {
            v1.clone().borrow_mut()[v2 as usize] = v2;
            let mut v4: i32 = v2.wrapping_add(1i32);
            (v0, v1, v2) = (v0, v1.clone(), v4);
            continue;
        }
        return ();
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 6i32;
    let mut v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 6i32 as usize]));
    let mut v2: i32 = 0i32;
    fill_0(v0, v1.clone(), v2);
    let mut v3: i32 = v1.clone().borrow()[5i32 as usize].clone();
    let mut v4: i32 = v3.wrapping_add(2i32);
    v4
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
