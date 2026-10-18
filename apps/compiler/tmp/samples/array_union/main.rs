#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_None,
    US0_Some(i32),
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_None
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 2i32;
    let mut v1: Rc<RefCell<Vec<US0>>> = Rc::new(RefCell::new(vec![<US0>::default(); v0 as usize]));
    let mut v2: i32 = 7i32;
    let mut v3: US0 = US0::US0_Some(v2);
    v1.clone().borrow_mut()[0i32 as usize] = v3.clone();
    let mut v4: US0 = US0::US0_None;
    v1.clone().borrow_mut()[1i32 as usize] = v4.clone();
    let mut v5: US0 = v1.clone().borrow()[0i32 as usize].clone();
    match &v5 {
        US0::US0_None => {
            1i32
        }
        US0::US0_Some(v6) => {
            let mut v6: i32 = *v6;
            let mut v7: US0 = v1.clone().borrow()[1i32 as usize].clone();
            match &v7 {
                US0::US0_None => {
                    let mut v8: bool = v6 == 7i32;
                    if v8 {
                        0i32
                    } else {
                        1i32
                    }
                }
                US0::US0_Some(v10) => {
                    let mut v10: i32 = *v10;
                    1i32
                }
            }
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
