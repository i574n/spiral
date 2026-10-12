#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = -8i32;
    let mut v1: i32 = 3i32;
    let mut v2: i32 = 1i32;
    let mut v3: u32 = 4294967295u32;
    let mut v4: i32 = 4i32;
    let mut v5: i32 = v0.wrapping_shr((v2) as u32);
    let mut v6: i32 = v1.wrapping_shl((v2) as u32);
    let mut v7: u32 = v3.wrapping_shr((v4) as u32);
    let mut v8: u32 = v3.wrapping_shl((v2) as u32);
    let mut v9: bool = v5 == -4i32;
    if v9 {
        let mut v10: bool = v6 == 6i32;
        if v10 {
            let mut v11: bool = v7 == 268435455u32;
            if v11 {
                let mut v12: bool = v8 == 4294967294u32;
                if v12 {
                    0i32
                } else {
                    4i32
                }
            } else {
                3i32
            }
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
