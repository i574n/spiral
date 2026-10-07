#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0(i32),
    US0_1,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1 => 1,
        }
    }
}
struct Mut0 { l0: Rc<str> }
fn method2(mut v0: US0) -> Rc<str> {
    match &v0 {
        US0::US0_1 => { // None
            let mut v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v27.clone()
        }
        US0::US0_0(v1) => { // Some
            let mut v1: i32 = *v1;
            let mut v3: Rc<str> = Rc::<str>::from(format!("{:?}", v1));
            let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v3, v6));
            let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v7));
            let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some"); } LIT.with(|lit| lit.clone()) };
            let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v11));
            v23.clone()
        }
    }
}
fn method3(mut v0: Rc<RefCell<Mut0>>, mut v1: Rc<str>) -> () {
    let mut v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, v1));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method1(mut v0: US0) -> Rc<str> {
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v18.clone() }));
    let mut v26: Rc<str> = method2(v0.clone());
    method3(v19.clone(), v26.clone());
    let mut v45: Rc<str> = v19.borrow().l0.clone();
    v45.clone()
}
fn method0() -> Rc<str> {
    let mut v0: i32 = 1i32;
    let mut v1: US0 = US0::US0_0(v0);
    let mut v2: Rc<str> = method1(v1.clone());
    let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("x: "); } LIT.with(|lit| lit.clone()) };
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v2));
    v14.clone()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = method0();
    let mut v1: bool = v0.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    if v1 {
        1i32
    } else {
        0i32
    }
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
