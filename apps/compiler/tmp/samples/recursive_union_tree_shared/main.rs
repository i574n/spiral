#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Leaf,
    UH0_Node(i32, Rc<UH0>, Rc<UH0>),
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_Leaf => 0,
            UH0::UH0_Node(..) => 1,
        }
    }
}
fn sum_0(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_Leaf => {
            0i32
        }
        UH0::UH0_Node(v1, v2, v3) => {
            let mut v1: i32 = *v1;
            let mut v2: Rc<UH0> = v2.clone();
            let mut v3: Rc<UH0> = v3.clone();
            let mut v4: i32 = sum_0(v2.clone());
            let mut v5: i32 = sum_0(v3.clone());
            let mut v6: i32 = v4.wrapping_add(v5);
            let mut v7: i32 = v1.wrapping_add(v6);
            v7
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 1i32;
    let mut v1: i32 = 2i32;
    let mut v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH0> = Rc::new(UH0::UH0_Node(v1, v2.clone(), v2.clone()));
    let mut v4: Rc<UH0> = Rc::new(UH0::UH0_Node(v0, v3.clone(), v3.clone()));
    let mut v5: i32 = sum_0(v4.clone());
    let mut v6: i32 = v5.wrapping_sub(5i32);
    v6
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
