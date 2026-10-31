#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); 2i32 as usize]));
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
    v0.clone().borrow_mut()[0i32 as usize] = v1;
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cde"); } LIT.with(|lit| lit.clone()) };
    v0.clone().borrow_mut()[1i32 as usize] = v2;
    let v3: Rc<str> = v0.clone().borrow()[0i32 as usize].clone();
    let v4: Rc<str> = v0.borrow()[1i32 as usize].clone();
    let v5: i32 = (v3.len() as i32);
    let v6: i32 = (v4.len() as i32);
    let v7: i32 = v5.wrapping_add(v6);
    let v8: i32 = v7.wrapping_sub(5i32);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
