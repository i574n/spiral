#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<str>) -> () {
    let mut v1: i32 = (v0.clone().len() as i32);
    ()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q"); } LIT.with(|lit| lit.clone()) };
    method0(v0.clone());
    method0(v0.clone());
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C"); } LIT.with(|lit| lit.clone()) };
    method0(v1.clone());
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo="); } LIT.with(|lit| lit.clone()) };
    method0(v2.clone());
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_ITEM_METADATA_TEST_test-item"); } LIT.with(|lit| lit.clone()) };
    method0(v3.clone());
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q"); } LIT.with(|lit| lit.clone()) };
    method0(v4.clone());
    method0(v4.clone());
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C"); } LIT.with(|lit| lit.clone()) };
    method0(v5.clone());
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo="); } LIT.with(|lit| lit.clone()) };
    method0(v6.clone());
    0i32
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
