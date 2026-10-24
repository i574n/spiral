#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Held(Rc<RefCell<Vec<i32>>>, i32),
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Held(v1, v2) => {
            let v1: Rc<RefCell<Vec<i32>>> = v1.clone();
            let v2: i32 = *v2;
            let v3: i32 = v1.borrow()[0i32 as usize].clone();
            let v4: i32 = v3.wrapping_add(v2);
            let v5: bool = v4 == 7i32;
            if v5 {
                0i32
            } else {
                1i32
            }
        }
        US0::US0_None => {
            1i32
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: i32 = 4i32;
    let v2: Rc<RefCell<Vec<i32>>> = Rc::new(RefCell::new(vec![<i32>::default(); 1i32 as usize]));
    v2.clone().borrow_mut()[0i32 as usize] = v0;
    let v3: bool = true;
    let v6: US0 = if v3 {
        US0::US0_Held(v2, v1)
    } else {
        US0::US0_None
    };
    score_0(v6)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
