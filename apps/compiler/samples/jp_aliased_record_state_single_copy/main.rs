#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn walk_0(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let v3: bool = v0 < 1i32;
        if v3 {
            let v4: i32 = v1.wrapping_add(v2);
            return v4;
        } else {
            let n_v5: i32 = v0.wrapping_sub(1i32);
            let s_v6: i32 = v1.wrapping_add(v0);
            let s_v7: i32 = v2.wrapping_mul(2i32);
            (v0, v1, v2) = (n_v5, s_v6, s_v7);
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let x_v0: i32 = 1i32;
    let k_v1: i32 = 10i32;
    let v2: i32 = walk_0(k_v1, x_v0, x_v0);
    let v3: i32 = v2.wrapping_sub(1080i32);
    v3
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
