#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Circle(f64),
    US0_Square(f64),
    US0_Dot,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Circle(..) => 0,
            US0::US0_Square(..) => 1,
            US0::US0_Dot => 2,
        }
    }
}
fn spiral_main() -> i32 {
    let v0: f64 = 1.5f64;
    let v1: US0 = US0::US0_Circle(v0);
    let v2: f64 = 2.5f64;
    let v3: US0 = US0::US0_Square(v2);
    let v4: US0 = US0::US0_Dot;
    let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Circle"); } LIT.with(|lit| lit.clone()) };
    let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Square"); } LIT.with(|lit| lit.clone()) };
    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Dot"); } LIT.with(|lit| lit.clone()) };
    let v11: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v8.clone(), v9.clone(), v10.clone()]));
    let v12: i32 = (v1.tag() as i32);
    let v13: Rc<str> = v11.borrow()[v12 as usize].clone();
    let v14: bool = &*v13 == "Circle";
    let v19: bool = if v14 {
        let v15: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v8.clone(), v9.clone(), v10.clone()]));
        let v16: i32 = (v3.tag() as i32);
        let v17: Rc<str> = v15.borrow()[v16 as usize].clone();
        let v18: bool = &*v17 == "Square";
        v18
    } else {
        false
    };
    let v24: bool = if v19 {
        let v20: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v8, v9, v10]));
        let v21: i32 = (v4.tag() as i32);
        let v22: Rc<str> = v20.borrow()[v21 as usize].clone();
        let v23: bool = &*v22 == "Dot";
        v23
    } else {
        false
    };
    if v24 {
        42i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
