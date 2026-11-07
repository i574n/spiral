#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn bump_2(mut v0: i32) -> i32 {
    let v1: bool = v0 == 4i32;
    if v1 {
        let v2: i32 = 0i32;
        let v3: i32 = 1i32;
        count_odd_1(v2, v3)
    } else {
        0i32
    }
}
enum Group0 {
    M0(i32, i32),
    M1(i32, i32),
}
fn group_0(mut st: Group0) -> i32 {
    loop {
        match st {
            Group0::M0(mut v0, mut v1) => {
                let v2: bool = v0 == 0i32;
                if v2 {
                    return v1;
                } else {
                    let v3: i32 = v0.wrapping_sub(1i32);
                    let v4: i32 = bump_2(v0);
                    let v5: i32 = v1.wrapping_add(v4);
                    st = Group0::M1(v3, v5);
                    continue;
                }
            }
            Group0::M1(mut v0, mut v1) => {
                let v2: bool = v0 == 0i32;
                if v2 {
                    return v1;
                } else {
                    let v3: i32 = v0.wrapping_sub(1i32);
                    st = Group0::M0(v3, v1);
                    continue;
                }
            }
        }
    }
}
fn count_odd_1(mut v0: i32, mut v1: i32) -> i32 {
    group_0(Group0::M1(v0, v1))
}
fn count_even_0(mut v0: i32, mut v1: i32) -> i32 {
    group_0(Group0::M0(v0, v1))
}
fn spiral_main() -> i32 {
    let v0: i32 = 10i32;
    let v1: i32 = 0i32;
    let v2: i32 = count_even_0(v0, v1);
    let v3: i32 = v2.wrapping_sub(1i32);
    v3
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
