#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Step(i32, i32, i32),
}
fn walk_0(mut v0: i32) -> i32 {
    let v1: bool = v0 > 2i32;
    let v6: US0 = if v1 {
        let v2: i32 = v0.wrapping_add(1i32);
        let v3: i32 = v0.wrapping_add(2i32);
        US0::US0_Step(v0, v2, v3)
    } else {
        US0::US0_Step(0i32, 1i32, 2i32)
    };
    match &v6 {
        US0::US0_Step(v7, v8, v9) => {
            let v7: i32 = *v7;
            let v8: i32 = *v8;
            let v9: i32 = *v9;
            let v10: i32 = v8.wrapping_mul(v9);
            let v11: i32 = v7.wrapping_add(v10);
            v11
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 5i32;
    let v1: i32 = walk_0(v0);
    let v2: i32 = v0.wrapping_sub(4i32);
    let v3: i32 = walk_0(v2);
    let v4: i32 = v1.wrapping_add(v3);
    v4
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
