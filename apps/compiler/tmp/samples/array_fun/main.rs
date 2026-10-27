#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn f_c0(mut v0: i32) -> Rc<dyn Fn(i32) -> i32> {
    Rc::new(move |mut v1: i32| -> i32 {
        let v2: i32 = v1.wrapping_add(v0);
        v2
    })
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<dyn Fn(i32) -> i32> = f_c0(v0);
    let v2: i32 = 1i32;
    let v3: Rc<RefCell<Vec<Rc<dyn Fn(i32) -> i32>>>> = Rc::new(RefCell::new(vec![{ let f: Rc<dyn Fn(i32) -> i32> = Rc::new(|mut v0: i32| -> i32 { <i32>::default() }); f }; v2 as usize]));
    v3.clone().borrow_mut()[0i32 as usize] = v1.clone();
    let mut v4: Rc<dyn Fn(i32) -> i32> = v3.clone().borrow()[0i32 as usize].clone();
    let v5: i32 = v4(4i32);
    let v6: bool = v5 == 7i32;
    if v6 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
