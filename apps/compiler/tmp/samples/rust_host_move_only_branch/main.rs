#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
mod ureq { pub struct RequestBuilder<T>(pub T); }
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("xc_requests"); } LIT.with(|lit| lit.clone()) };
    let v1: bool = true;
    let v4: ureq::RequestBuilder<i32> = if v1 {
        let v2: ureq::RequestBuilder<i32> = ureq::RequestBuilder(40i32);
        v2
    } else {
        let v3: ureq::RequestBuilder<i32> = ureq::RequestBuilder(41i32);
        v3
    };
    let v5: i32 = v4.0;
    let v6: i32 = v0.len() as i32;
    let v7: i32 = v5.wrapping_add(v6);
    let v8: i32 = v7.wrapping_sub(51i32);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
