#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 43i32;
    let mut v1: i32 = 15i32;
    let mut v2: i32 = 2i32;
    let mut v3: i32 = 5i32;
    let mut v4: i32 = v0 & v1;
    let mut v5: i32 = v0 | v1;
    let mut v6: i32 = v0 ^ v1;
    let mut v7: i32 = !v0;
    let mut v8: i32 = v7 & 255i32;
    let mut v9: i32 = 1i32 << v3;
    let mut v10: i32 = 168i32 >> v2;
    let mut v11: i32 = v4 - 11i32;
    let mut v12: i32 = v10 + v11;
    let mut v13: i32 = v5 - 47i32;
    let mut v14: i32 = v12 + v13;
    let mut v15: i32 = v6 - 36i32;
    let mut v16: i32 = v14 + v15;
    let mut v17: i32 = v8 - 212i32;
    let mut v18: i32 = v16 + v17;
    let mut v19: i32 = v9 - 32i32;
    let mut v20: i32 = v18 + v19;
    v20
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
