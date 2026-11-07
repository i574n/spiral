#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Nothing,
    US0_Just(Rc<str>),
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Nothing
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<(Rc<str>, US0, bool)>>> = Rc::new(RefCell::new(vec![<(Rc<str>, US0, bool)>::default(); v0 as usize]));
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("x"); } LIT.with(|lit| lit.clone()) };
    let v4: US0 = US0::US0_Just(v3);
    v1.borrow_mut()[0i32 as usize] = (v2, v4, true);
    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
    let v6: US0 = US0::US0_Nothing;
    v1.borrow_mut()[1i32 as usize] = (v5, v6, false);
    let (mut v7, mut v8, mut v9): (Rc<str>, US0, bool) = v1.borrow()[0i32 as usize].clone();
    match v8 {
        US0::US0_Just(v10) => {
            let v10: Rc<str> = v10;
            let v11: bool = &*v10 == "x";
            if v11 {
                7i32
            } else {
                1i32
            }
        }
        US0::US0_Nothing => {
            2i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
