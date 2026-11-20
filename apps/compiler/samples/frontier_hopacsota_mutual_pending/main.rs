#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
enum Group0 {
    M0(i32),
    M1(i32),
}
fn group_0(mut st: Group0) -> bool {
    loop {
        match st {
            Group0::M0(mut v0) => {
                let v1: bool = v0 == 0i32;
                if v1 {
                    return true;
                } else {
                    let v2: i32 = v0.wrapping_sub(1i32);
                    st = Group0::M1(v2);
                    continue;
                }
            }
            Group0::M1(mut v0) => {
                let v1: bool = v0 == 0i32;
                if v1 {
                    return false;
                } else {
                    let v2: i32 = v0.wrapping_sub(1i32);
                    st = Group0::M0(v2);
                    continue;
                }
            }
        }
    }
}
fn is_odd_1(mut v0: i32) -> bool {
    group_0(Group0::M1(v0))
}
fn is_even_0(mut v0: i32) -> bool {
    group_0(Group0::M0(v0))
}
fn spiral_main() -> i32 {
    let v0: i32 = 10i32;
    let v1: bool = is_even_0(v0);
    if v1 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
