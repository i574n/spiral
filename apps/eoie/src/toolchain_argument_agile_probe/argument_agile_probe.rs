#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: i32 = 0i32;
    let mut v2: i32 = toolchain_argument_tail_domain::eoie_toolchain_argument_token_high(v0, v1);
    let mut v3: i32 = -1i32;
    let mut v4: i32 = 12i32;
    let mut v5: i32 = 1i32;
    let mut v6: i32 = toolchain_argument_domain::eoie_toolchain_argument_token_chunk(v4, v5);
    let mut v7: i32 = 1073722824i32;
    let mut v8: i32 = if v2 == v3 && v6 == v7 { 0 } else { 1 };
    v8
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
