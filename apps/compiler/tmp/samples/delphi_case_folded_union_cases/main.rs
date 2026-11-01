#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Foo,
    US0_FOO,
    US0_Bar,
}
fn spiral_main() -> i32 {
    let v0: US0 = US0::US0_Foo;
    let v1: US0 = US0::US0_FOO;
    let v4: i32 = match &v0 {
        US0::US0_Bar => {
            100i32
        }
        US0::US0_FOO => {
            10i32
        }
        US0::US0_Foo => {
            1i32
        }
    };
    let v7: i32 = match &v1 {
        US0::US0_Bar => {
            100i32
        }
        US0::US0_FOO => {
            10i32
        }
        US0::US0_Foo => {
            1i32
        }
    };
    let v8: i32 = v4.wrapping_add(v7);
    v8
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
