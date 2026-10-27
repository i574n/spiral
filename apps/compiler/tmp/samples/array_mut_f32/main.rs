#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: f32, l1: Rc<str> }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <f32>::default(), l1: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
fn spiral_main() -> i32 {
    let v0: f32 = 1.5f32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("no"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v0, l1: v1.clone() }));
    let v3: Rc<RefCell<Vec<Rc<RefCell<Mut0>>>>> = Rc::new(RefCell::new(vec![<Rc<RefCell<Mut0>>>::default(); 1i32 as usize]));
    v3.clone().borrow_mut()[0i32 as usize] = v2.clone();
    let mut v4: Rc<RefCell<Mut0>> = v3.clone().borrow()[0i32 as usize].clone();
    let v5: f32 = 2.5f32;
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
    v4.borrow_mut().l0 = v5;
    v4.borrow_mut().l1 = v6.clone();
    let (mut v7, mut v8): (f32, Rc<str>) = (v4.borrow().l0.clone(), v4.borrow().l1.clone());
    let v9: bool = v7 == 2.5f32;
    let v11: bool = if v9 {
        let v10: bool = &*v8 == "hi";
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
