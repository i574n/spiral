#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: i32 }
#[derive(Clone)]
enum US0 {
    US0_Missing,
    US0_Held(Rc<RefCell<Mut0>>),
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 1i32 }));
    let mut v1: bool = true;
    let mut v4: US0 = if v1 {
        US0::US0_Held(v0.clone())
    } else {
        US0::US0_Missing
    };
    match &v4 {
        US0::US0_Held(v5) => {
            let mut v5: Rc<RefCell<Mut0>> = v5.clone();
            v5.borrow_mut().l0 = 7i32;
            let mut v6: i32 = v5.borrow().l0.clone();
            let mut v7: bool = v6 == 7i32;
            if v7 {
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
