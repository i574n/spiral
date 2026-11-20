#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_First,
    US0_Second,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_First => 1,
            US0::US0_Second => 2,
        }
    }
}
fn spiral_main() -> i32 {
    let v0: US0 = US0::US0_First;
    let v1: US0 = US0::US0_Second;
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("First"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Second"); } LIT.with(|lit| lit.clone()) };
    let v6: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v3.clone(), v4.clone(), v5.clone()]));
    let v7: i32 = (v0.tag() as i32);
    let v8: Rc<str> = v6.borrow()[v7 as usize].clone();
    let v9: bool = &*v8 == "First";
    let v14: bool = if v9 {
        let v10: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v3, v4, v5]));
        let v11: i32 = (v1.tag() as i32);
        let v12: Rc<str> = v10.borrow()[v11 as usize].clone();
        let v13: bool = &*v12 == "Second";
        v13
    } else {
        false
    };
    if v14 {
        42i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
