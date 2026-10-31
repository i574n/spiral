#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn choose_0(mut v0: bool) -> Rc<str> {
    if v0 {
        let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("alpha"); } LIT.with(|lit| lit.clone()) };
        v1
    } else {
        let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("beta"); } LIT.with(|lit| lit.clone()) };
        v2
    }
}
fn measure_1(mut v0: Rc<str>) -> i32 {
    let v1: i32 = (v0.len() as i32);
    v1
}
fn spiral_main() -> i32 {
    let v0: bool = true;
    let v1: Rc<str> = choose_0(v0);
    let v2: bool = false;
    let v3: Rc<str> = choose_0(v2);
    let v4: i32 = measure_1(v1.clone());
    let v5: i32 = measure_1(v1);
    let v6: i32 = v4.wrapping_add(v5);
    let v7: i32 = measure_1(v3);
    let v8: i32 = v6.wrapping_add(v7);
    let v9: i32 = v8.wrapping_sub(14i32);
    v9
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
