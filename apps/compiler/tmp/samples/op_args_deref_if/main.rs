#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct Mut0 { l0: Rc<str> }
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("deref"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v0.clone() }));
    let mut v2: i32 = 3i32;
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("deref!"); } LIT.with(|lit| lit.clone()) };
    v1.borrow_mut().l0 = v3.clone();
    let mut v4: Rc<str> = v1.borrow().l0.clone();
    let mut v5: bool = v2 == 3i32;
    let mut v7: i32 = if v5 {
        let mut v6: i32 = v2.wrapping_add(1i32);
        v6
    } else {
        0i32
    };
    print!("{} {}\n", v4.clone(), v7);
    let mut v8: i32 = v2.wrapping_mul(2i32);
    let mut v9: bool = v2 > 0i32;
    let mut v10: i32 = if v9 {
        6i32
    } else {
        0i32
    };
    let mut v11: bool = v8 == v10;
    if v11 {
        0i32
    } else {
        1i32
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
