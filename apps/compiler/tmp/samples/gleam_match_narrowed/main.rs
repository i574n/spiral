#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Circle(i32),
    US0_Square(i32),
    US0_Tri(i32),
    US0_Dot,
}
fn pick_0(mut v0: i32) -> US0 {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        US0::US0_Circle(5i32)
    } else {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            US0::US0_Square(4i32)
        } else {
            let mut v5: bool = v0 == 2i32;
            if v5 {
                US0::US0_Tri(7i32)
            } else {
                US0::US0_Dot
            }
        }
    }
}
fn measure_1(mut v0: US0, mut v1: i32) -> i32 {
    match &v0 {
        US0::US0_Circle(v2) => {
            let mut v2: i32 = *v2;
            let mut v3: i32 = v2.wrapping_mul(3i32);
            v3
        }
        _ => {
            let mut v4: i32 = v1.wrapping_mul(v1);
            let mut v5: bool = v4 > 3i32;
            match &v0 {
                US0::US0_Dot => {
                    v4
                }
                US0::US0_Square(v6) => {
                    let mut v6: i32 = *v6;
                    if v5 {
                        let mut v7: i32 = v6.wrapping_mul(v6);
                        v7
                    } else {
                        v6
                    }
                }
                US0::US0_Tri(v9) => {
                    let mut v9: i32 = *v9;
                    if v5 {
                        let mut v10: i32 = v9.wrapping_mul(2i32);
                        v10
                    } else {
                        v9
                    }
                }
                _ => unreachable!(),
            }
        }
    }
}
fn measure_tri_2(mut v0: US0, mut v1: i32) -> i32 {
    match &v0 {
        US0::US0_Circle(v2) => {
            let mut v2: i32 = *v2;
            v2
        }
        US0::US0_Dot => {
            0i32
        }
        US0::US0_Square(v3) => {
            let mut v3: i32 = *v3;
            v3
        }
        _ => {
            let mut v4: i32 = v1.wrapping_add(2i32);
            match &v0 {
                US0::US0_Tri(v5) => {
                    let mut v5: i32 = *v5;
                    let mut v6: i32 = v5.wrapping_mul(v4);
                    v6
                }
                _ => unreachable!(),
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    let mut v1: US0 = pick_0(v0);
    let mut v2: i32 = measure_1(v1.clone(), v0);
    let mut v3: i32 = v0.wrapping_add(1i32);
    let mut v4: US0 = pick_0(v3);
    let mut v5: i32 = measure_1(v4.clone(), v3);
    let mut v6: i32 = v2.wrapping_add(v5);
    let mut v7: i32 = v0.wrapping_add(2i32);
    let mut v8: US0 = pick_0(v7);
    let mut v9: i32 = measure_1(v8.clone(), v7);
    let mut v10: i32 = v6.wrapping_add(v9);
    let mut v11: i32 = v0.wrapping_add(3i32);
    let mut v12: US0 = pick_0(v11);
    let mut v13: i32 = measure_1(v12.clone(), v11);
    let mut v14: i32 = v10.wrapping_add(v13);
    let mut v15: US0 = pick_0(v7);
    let mut v16: i32 = measure_tri_2(v15.clone(), v0);
    let mut v17: i32 = v14.wrapping_add(v16);
    let mut v18: US0 = pick_0(v0);
    let mut v19: i32 = measure_tri_2(v18.clone(), v0);
    let mut v20: i32 = v17.wrapping_add(v19);
    v20
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
