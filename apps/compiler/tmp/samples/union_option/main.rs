#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Empty,
    US0_Full(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Empty => 0,
            US0::US0_Full(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Empty
    }
}
fn pick_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Empty => {
            0i32
        }
        US0::US0_Full(v1) => {
            let mut v1: i32 = *v1;
            v1
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v3: US0 = if v0 {
        US0::US0_Full(7i32)
    } else {
        US0::US0_Empty
    };
    let mut v6: US0 = if v0 {
        US0::US0_Empty
    } else {
        US0::US0_Full(1i32)
    };
    let mut v7: i32 = pick_0(v3.clone());
    let mut v8: bool = v7 == 7i32;
    let mut v11: bool = if v8 {
        let mut v9: i32 = pick_0(v6.clone());
        let mut v10: bool = v9 == 0i32;
        v10
    } else {
        false
    };
    if v11 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
