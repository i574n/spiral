#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn target_global_0(mut v0: Rc<str>) -> () {
    ()
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q"); } LIT.with(|lit| lit.clone()) };
    target_global_0(v0.clone());
    target_global_0(v0);
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C"); } LIT.with(|lit| lit.clone()) };
    target_global_0(v1);
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo="); } LIT.with(|lit| lit.clone()) };
    target_global_0(v2);
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_ITEM_METADATA_TEST_test-item"); } LIT.with(|lit| lit.clone()) };
    target_global_0(v3);
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q"); } LIT.with(|lit| lit.clone()) };
    target_global_0(v4.clone());
    target_global_0(v4);
    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C"); } LIT.with(|lit| lit.clone()) };
    target_global_0(v5);
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo="); } LIT.with(|lit| lit.clone()) };
    target_global_0(v6);
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
