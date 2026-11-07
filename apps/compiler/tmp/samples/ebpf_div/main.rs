#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i32 = 7i32;
    let v1: i32 = -2i32;
    let v2: i32 = -7i32;
    let v3: u32 = 100u32;
    let v4: u32 = 7u32;
    let v5: i32 = v0.wrapping_div(v1);
    let v6: i32 = v0.wrapping_rem(v1);
    let v7: i32 = v2.wrapping_div(v1);
    let v8: i32 = v2.wrapping_rem(v1);
    let v9: u32 = v3.wrapping_div(v4);
    let v10: u32 = v3.wrapping_rem(v4);
    let v11: bool = v5 == -3i32;
    let v13: bool = if v11 {
        let v12: bool = v6 == 1i32;
        v12
    } else {
        false
    };
    let v15: bool = if v13 {
        let v14: bool = v7 == 3i32;
        v14
    } else {
        false
    };
    let v17: bool = if v15 {
        let v16: bool = v8 == -1i32;
        v16
    } else {
        false
    };
    let v19: bool = if v17 {
        let v18: bool = v9 == 14u32;
        v18
    } else {
        false
    };
    let v21: bool = if v19 {
        let v20: bool = v10 == 2u32;
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
