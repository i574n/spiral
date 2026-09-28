#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(clippy::needless_return, clippy::needless_late_init)]
use std::cell::RefCell;
use std::rc::Rc;
fn inspection_negative_run() -> i32 {
    if eoie_proxy_search::inspection_tree_sha256(std::path::Path::new("/tmp"), "../escape").is_err() { 0 } else { 1 }
}

fn spiral_main() -> i32 {
    let mut v0: i32 = inspection_negative_run();
    v0
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
