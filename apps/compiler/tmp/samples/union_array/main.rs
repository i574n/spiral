#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Missing,
    US0_Held(Rc<RefCell<Vec<i32>>>),
}
fn spiral_main() -> i32 {
    let v0: i32 = 2i32;
    let v1: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); v0 as usize]));
    let v2: i32 = 7i32;
    v1.clone().borrow_mut()[0i32 as usize] = v2;
    let v3: bool = true;
    let v6: US0 = if v3 {
        US0::US0_Held(v1)
    } else {
        US0::US0_Missing
    };
    match &v6 {
        US0::US0_Held(v7) => {
            let v7: Rc<RefCell<Vec<i32>>> = v7.clone();
            let v8: i32 = v7.borrow()[0i32 as usize].clone();
            let v9: bool = v8 == 7i32;
            if v9 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_Missing => {
            1i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
