#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Done(i32),
    US0_More(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Done(..) => 0,
            US0::US0_More(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Done(<i32>::default())
    }
}
fn layers_0(mut v0: i32) -> i32 {
    loop {
        let mut v1: bool = v0 >= 5i32;
        let mut v4: US0 = if v1 {
            US0::US0_Done(v0)
        } else {
            US0::US0_More(v0)
        };
        match &v4 {
            US0::US0_Done(v8) => {
                let mut v8: i32 = *v8;
                let mut v9: i32 = v8.wrapping_mul(2i32);
                return v9;
            }
            US0::US0_More(v5) => {
                let mut v5: i32 = *v5;
                let mut v6: i32 = v5.wrapping_add(1i32);
                v0 = v6;
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 0i32;
    layers_0(v0)
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
