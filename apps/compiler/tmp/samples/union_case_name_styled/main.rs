#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_DeepBlue,
    US0_LightGreen(f64),
    US0_Red,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_DeepBlue => 0,
            US0::US0_LightGreen(..) => 1,
            US0::US0_Red => 2,
        }
    }
}
fn spiral_main() -> i32 {
    let v0: f64 = 0.5f64;
    let v1: US0 = US0::US0_LightGreen(v0);
    let v2: US0 = US0::US0_DeepBlue;
    let v3: US0 = US0::US0_Red;
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("deep_blue"); } LIT.with(|lit| lit.clone()) };
    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("light_green"); } LIT.with(|lit| lit.clone()) };
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("red"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v4.clone(), v5.clone(), v6.clone()]));
    let v8: i32 = (v1.tag() as i32);
    let v9: Rc<str> = v7.borrow()[v8 as usize].clone();
    let v10: bool = &*v9 == "light_green";
    let v17: bool = if v10 {
        let v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("deep-blue"); } LIT.with(|lit| lit.clone()) };
        let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("light-green"); } LIT.with(|lit| lit.clone()) };
        let v13: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v11, v12, v6.clone()]));
        let v14: i32 = (v2.tag() as i32);
        let v15: Rc<str> = v13.borrow()[v14 as usize].clone();
        let v16: bool = &*v15 == "deep-blue";
        v16
    } else {
        false
    };
    let v23: bool = if v17 {
        let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("deepblue"); } LIT.with(|lit| lit.clone()) };
        let v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("lightgreen"); } LIT.with(|lit| lit.clone()) };
        let v20: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v18, v19, v6.clone()]));
        let v21: Rc<str> = v20.borrow()[v8 as usize].clone();
        let v22: bool = &*v21 == "lightgreen";
        v22
    } else {
        false
    };
    let v28: bool = if v23 {
        let v24: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v4, v5, v6]));
        let v25: i32 = (v3.tag() as i32);
        let v26: Rc<str> = v24.borrow()[v25 as usize].clone();
        let v27: bool = &*v26 == "red";
        v27
    } else {
        false
    };
    let v35: bool = if v28 {
        let v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("DeepBlue"); } LIT.with(|lit| lit.clone()) };
        let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("LightGreen"); } LIT.with(|lit| lit.clone()) };
        let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Red"); } LIT.with(|lit| lit.clone()) };
        let v32: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![v29, v30, v31]));
        let v33: Rc<str> = v32.borrow()[v8 as usize].clone();
        let v34: bool = &*v33 == "LightGreen";
        v34
    } else {
        false
    };
    if v35 {
        42i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
