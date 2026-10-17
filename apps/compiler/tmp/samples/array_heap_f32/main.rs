#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Heap0 { l0: f32, l1: Rc<str> }
impl Default for Heap0 {
    fn default() -> Self {
        Heap0 { l0: <f32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
fn spiral_main() -> i32 {
    let mut v0: f32 = 1.5f32;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<Heap0> = Rc::new(Heap0 { l0: v0, l1: v1.clone() });
    let mut v3: Rc<RefCell<Vec<Rc<Heap0>>>> = Rc::new(RefCell::new(vec![<Rc<Heap0>>::default(); 1i32 as usize]));
    v3.clone().borrow_mut()[0i32 as usize] = v2.clone();
    let mut v4: Rc<Heap0> = v3.clone().borrow()[0i32 as usize].clone();
    let (mut v5, mut v6): (f32, Rc<str>) = (v4.l0.clone(), v4.l1.clone());
    let mut v7: bool = v5 == 1.5f32;
    let mut v9: bool = if v7 {
        let mut v8: bool = v6.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
        v8
    } else {
        false
    };
    if v9 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
