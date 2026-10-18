#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 7i32;
    let mut v1: i32 = -2i32;
    let mut v2: i32 = -7i32;
    let mut v3: u32 = 100u32;
    let mut v4: u32 = 7u32;
    let mut v5: i32 = v0.wrapping_div(v1);
    let mut v6: i32 = v0.wrapping_rem(v1);
    let mut v7: i32 = v2.wrapping_div(v1);
    let mut v8: i32 = v2.wrapping_rem(v1);
    let mut v9: u32 = v3.wrapping_div(v4);
    let mut v10: u32 = v3.wrapping_rem(v4);
    let mut v11: bool = v5 == -3i32;
    let mut v13: bool = if v11 {
        let mut v12: bool = v6 == 1i32;
        v12
    } else {
        false
    };
    let mut v15: bool = if v13 {
        let mut v14: bool = v7 == 3i32;
        v14
    } else {
        false
    };
    let mut v17: bool = if v15 {
        let mut v16: bool = v8 == -1i32;
        v16
    } else {
        false
    };
    let mut v19: bool = if v17 {
        let mut v18: bool = v9 == 14u32;
        v18
    } else {
        false
    };
    let mut v21: bool = if v19 {
        let mut v20: bool = v10 == 2u32;
        v20
    } else {
        false
    };
    if v21 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
