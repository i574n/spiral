#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_Leaf,
    UH0_Node(i32, Rc<UH0>, Rc<UH0>),
}
fn sum_1(mut v0: Rc<UH0>) -> i32 {
    match &*v0 {
        UH0::UH0_Leaf => {
            0i32
        }
        UH0::UH0_Node(v1, v2, v3) => {
            let v1: i32 = *v1;
            let v2: Rc<UH0> = v2.clone();
            let v3: Rc<UH0> = v3.clone();
            let v4: i32 = sum_1(v2);
            let v5: i32 = sum_1(v3);
            let v6: i32 = v4.wrapping_add(v5);
            let v7: i32 = v1.wrapping_add(v6);
            v7
        }
    }
}
fn consume_pair_0(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> i32 {
    let v2: i32 = sum_1(v0);
    let v3: i32 = sum_1(v1);
    let v4: i32 = v2.wrapping_add(v3);
    v4
}
fn spiral_main() -> i32 {
    let v0: i32 = 1i32;
    let v1: i32 = 2i32;
    let v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let v3: Rc<UH0> = Rc::new(UH0::UH0_Node(v1, v2.clone(), v2.clone()));
    let v4: Rc<UH0> = Rc::new(UH0::UH0_Node(v0, v3.clone(), v3.clone()));
    let v5: i32 = 1i32;
    let v6: i32 = 2i32;
    let v7: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Leaf); } CASE.with(|case| case.clone()) };
    let v8: Rc<UH0> = Rc::new(UH0::UH0_Node(v6, v7.clone(), v7.clone()));
    let v9: Rc<UH0> = Rc::new(UH0::UH0_Node(v5, v8.clone(), v8.clone()));
    let v10: i32 = consume_pair_0(v4.clone(), v9.clone());
    let v11: i32 = v10.wrapping_sub(10i32);
    v11
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
