#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_North,
    US0_East,
    US0_South,
    US0_West,
}
fn spiral_main() -> i32 {
    let mut v0: US0 = US0::US0_North;
    let mut v8: US0 = match &v0 {
        US0::US0_East => {
            US0::US0_South
        }
        US0::US0_North => {
            US0::US0_East
        }
        US0::US0_South => {
            US0::US0_West
        }
        US0::US0_West => {
            US0::US0_North
        }
    };
    let mut v16: US0 = match &v8 {
        US0::US0_East => {
            US0::US0_South
        }
        US0::US0_North => {
            US0::US0_East
        }
        US0::US0_South => {
            US0::US0_West
        }
        US0::US0_West => {
            US0::US0_North
        }
    };
    let mut v17: US0 = US0::US0_South;
    let mut v18: bool = match (&v16, &v17) {
        (US0::US0_East, US0::US0_East) => {
            true
        }
        (US0::US0_North, US0::US0_North) => {
            true
        }
        (US0::US0_South, US0::US0_South) => {
            true
        }
        (US0::US0_West, US0::US0_West) => {
            true
        }
        _ => {
            false
        }
    };
    let mut v19: i32 = if v18 {
        100i32
    } else {
        0i32
    };
    let mut v21: i32 = match &v0 {
        US0::US0_East => {
            2i32
        }
        US0::US0_North => {
            1i32
        }
        _ => {
            7i32
        }
    };
    let mut v23: i32 = match &v8 {
        US0::US0_East => {
            2i32
        }
        US0::US0_North => {
            1i32
        }
        _ => {
            7i32
        }
    };
    let mut v24: i32 = v23.wrapping_mul(3i32);
    let mut v25: i32 = v21.wrapping_add(v24);
    let mut v27: i32 = match &v16 {
        US0::US0_East => {
            2i32
        }
        US0::US0_North => {
            1i32
        }
        _ => {
            7i32
        }
    };
    let mut v28: i32 = v27.wrapping_mul(9i32);
    let mut v29: i32 = v25.wrapping_add(v28);
    let mut v30: i32 = v29.wrapping_add(v19);
    v30
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
