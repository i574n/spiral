#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Empty,
    US0_Item(Rc<str>, Rc<RefCell<Vec<i32>>>),
}
fn closure0() -> Rc<dyn Fn(i32) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> US0> = Rc::new(move |mut v0: i32| -> US0 {
        let v1: bool = v0 == 0i32;
        if v1 {
            US0::US0_Empty
        } else {
            let v3: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 2i32 as usize]));
            v3.clone().borrow_mut()[0i32 as usize] = v0;
            let v4: i32 = v0.wrapping_add(1i32);
            v3.clone().borrow_mut()[1i32 as usize] = v4;
            let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hi"); } LIT.with(|lit| lit.clone()) };
            US0::US0_Item(v5.clone(), v3.clone())
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(0i32)
}
fn method1(mut v0: Rc<dyn Fn(i32) -> US0>) -> US0 {
    v0(4i32)
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> US0> = closure0();
    let v1: US0 = method0(v0.clone());
    let v12: i32 = match &v1 {
        US0::US0_Empty => {
            3i32
        }
        US0::US0_Item(v2, v3) => {
            let v2: Rc<str> = v2.clone();
            let v3: Rc<RefCell<Vec<i32>>> = v3.clone();
            let v4: i32 = (v2.len() as i32);
            let v5: i32 = (v3.clone().borrow().len() as i32);
            let v6: i32 = v4.wrapping_add(v5);
            let v7: i32 = v3.clone().borrow()[0i32 as usize].clone();
            let v8: i32 = v6.wrapping_add(v7);
            let v9: i32 = v3.borrow()[1i32 as usize].clone();
            let v10: i32 = v8.wrapping_add(v9);
            v10
        }
    };
    let v13: US0 = method1(v0);
    let v24: i32 = match &v13 {
        US0::US0_Empty => {
            3i32
        }
        US0::US0_Item(v14, v15) => {
            let v14: Rc<str> = v14.clone();
            let v15: Rc<RefCell<Vec<i32>>> = v15.clone();
            let v16: i32 = (v14.len() as i32);
            let v17: i32 = (v15.clone().borrow().len() as i32);
            let v18: i32 = v16.wrapping_add(v17);
            let v19: i32 = v15.clone().borrow()[0i32 as usize].clone();
            let v20: i32 = v18.wrapping_add(v19);
            let v21: i32 = v15.borrow()[1i32 as usize].clone();
            let v22: i32 = v20.wrapping_add(v21);
            v22
        }
    };
    let v25: i32 = v12.wrapping_add(v24);
    let v26: i32 = v25.wrapping_add(26i32);
    v26
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
