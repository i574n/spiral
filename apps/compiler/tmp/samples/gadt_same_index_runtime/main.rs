#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Leaf,
    UH0_Node(Rc<UH0>, Rc<UH0>),
}
fn count_0(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_Leaf => {
            1i32
        }
        UH0::UH0_Node(v1, v2) => {
            let v1: Rc<UH0> = v1.clone();
            let v2: Rc<UH0> = v2.clone();
            let v3: i32 = count_0(v1);
            let v4: i32 = count_0(v2);
            let v5: i32 = v3.wrapping_add(v4);
            v5
        }
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH0> = Rc::new(UH0::UH0_Node(v1, v2));
    let v4: Rc<UH0> = Rc::new(UH0::UH0_Node(v0, v3));
    count_0(v4)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
