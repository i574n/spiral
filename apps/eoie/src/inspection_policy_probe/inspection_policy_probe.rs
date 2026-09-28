#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(clippy::needless_late_init)]
use std::cell::RefCell;
use std::rc::Rc;
fn inspection_policy_run() -> i32 {
    let path = std::env::temp_dir().join(format!("eoie-inspection-policy-{}", std::process::id()));
    let _ = std::fs::remove_file(&path);
    if std::fs::write(&path, b"abc").is_err() { return 10; }
    let hash = eoie_proxy_search::inspection_file_sha256(&path);
    let _ = std::fs::remove_file(&path);
    if hash.as_deref() == Ok("ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad") { 0 } else { 1 }
}

fn spiral_main() -> i32 {
    let mut v0: i32 = inspection_policy_run();
    v0
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
