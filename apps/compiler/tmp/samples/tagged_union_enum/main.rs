#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Cold,
    US0_Warm,
    US0_Hot,
    US0_Done,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Cold => 0,
            US0::US0_Warm => 1,
            US0::US0_Hot => 2,
            US0::US0_Done => 3,
        }
    }
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Cold => {
            1i32
        }
        US0::US0_Done => {
            4i32
        }
        US0::US0_Hot => {
            3i32
        }
        US0::US0_Warm => {
            2i32
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: bool = v0 == 0i32;
    let mut v10: US0 = if v1 {
        US0::US0_Cold
    } else {
        let mut v3: bool = v0 == 1i32;
        if v3 {
            US0::US0_Warm
        } else {
            let mut v5: bool = v0 == 2i32;
            if v5 {
                US0::US0_Hot
            } else {
                US0::US0_Done
            }
        }
    };
    let mut v11: i32 = score_0(v10.clone());
    let mut v12: i32 = v11.wrapping_sub(4i32);
    v12
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
