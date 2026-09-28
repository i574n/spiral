#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = v0 * v1;
    let mut v3: i32 = v2 + 5i32;
    let mut v4: i32 = v3 / 3i32;
    v4
}
fn method4(mut v0: i32) -> i32 {
    let mut v1: i32 = 4i32;
    let mut v2: i32 = 4i32;
    let mut v3: i32 = method5(v1, v2);
    let mut v4: i32 = v0 + v3;
    let mut v5: i32 = v4 - 7i32;
    v5
}
fn method6(mut v0: u32) -> bool {
    let mut v1: u32 = v0 + 5u32;
    let mut v2: u32 = v1 % 4u32;
    let mut v3: bool = v2 == 0u32;
    v3
}
fn method3(mut v0: i32) -> i32 {
    let mut v1: u32 = 7u32;
    let mut v2: bool = method6(v1);
    if v2 {
        method4(v0)
    } else {
        1i32
    }
}
fn method7(mut v0: Rc<str>) -> bool {
    true
}
fn method2(mut v0: i32) -> i32 {
    let mut v1: Rc<str> = Rc::<str>::from("spiral");
    let mut v2: bool = method7(v1.clone());
    if v2 {
        method3(v0)
    } else {
        1i32
    }
}
fn method8(mut v0: f32) -> (bool, f32, i32) {
    let mut v1: bool = v0 >= 3.5f32;
    (v1, v0, 7i32)
}
fn method9(mut v0: bool, mut v1: f32, mut v2: i32) -> i32 {
    if v0 {
        let mut v3: bool = v1 >= 3.5f32;
        if v3 {
            let mut v4: i32 = v2 - 7i32;
            v4
        } else {
            1i32
        }
    } else {
        2i32
    }
}
fn method1(mut v0: i32) -> i32 {
    let mut v1: f32 = 4.0f32;
    let (mut v2, mut v3, mut v4): (bool, f32, i32) = method8(v1);
    let mut v5: i32 = method9(v2, v3, v4);
    let mut v6: i32 = v0 + v5;
    method2(v6)
}
fn method10(mut v0: i32) -> (i32, i32, bool) {
    let mut v1: i32 = v0 + 2i32;
    let mut v2: bool = v0 > 0i32;
    (v0, v1, v2)
}
fn method11(mut v0: i32, mut v1: i32, mut v2: bool) -> i32 {
    if v2 {
        let mut v3: i32 = v0 + v1;
        let mut v4: i32 = v3 - 4i32;
        v4
    } else {
        1i32
    }
}
fn method0(mut v0: i32) -> i32 {
    let mut v1: i32 = 1i32;
    let (mut v2, mut v3, mut v4): (i32, i32, bool) = method10(v1);
    let mut v5: i32 = method11(v2, v3, v4);
    let mut v6: i32 = v0 + v5;
    method1(v6)
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    method0(v0)
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
