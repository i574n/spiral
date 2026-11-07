#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: f32 = -2.0f32;
    let v1: f32 = -1.0f32;
    let v2: f32 = 0.0f32;
    let v3: bool = v0 < v1;
    let v5: bool = if v3 {
        let v4: bool = v1 < v2;
        v4
    } else {
        false
    };
    let v8: bool = if v5 {
        let v6: bool = v0 > v1;
        let v7: bool = v6 == false;
        v7
    } else {
        false
    };
    let v11: bool = if v8 {
        let v9: bool = v0 >= v1;
        let v10: bool = v9 == false;
        v10
    } else {
        false
    };
    let v13: bool = if v11 {
        let v12: bool = v1 <= v2;
        v12
    } else {
        false
    };
    if v13 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
