#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Real(f64),
    US0_Whole(i32),
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Real(..) => 0,
            US0::US0_Whole(..) => 1,
        }
    }
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Real(<f64>::default())
    }
}
fn twice_1(mut v0: f64) -> i32 {
    let mut v1: f64 = v0 * 2.0f64;
    let mut v2: i32 = (v1 as i32);
    v2
}
fn score_0(mut v0: US0) -> i32 {
    match &v0 {
        US0::US0_Real(v1) => {
            let mut v1: f64 = *v1;
            twice_1(v1)
        }
        US0::US0_Whole(v3) => {
            let mut v3: i32 = *v3;
            v3
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: bool = true;
    let mut v1: f64 = 1.5f64;
    let mut v4: US0 = if v0 {
        US0::US0_Real(v1)
    } else {
        US0::US0_Whole(1i32)
    };
    let mut v7: US0 = if v0 {
        US0::US0_Whole(5i32)
    } else {
        US0::US0_Real(v1)
    };
    let mut v8: i32 = score_0(v4.clone());
    let mut v9: bool = v8 == 3i32;
    let mut v12: bool = if v9 {
        let mut v10: i32 = score_0(v7.clone());
        let mut v11: bool = v10 == 5i32;
        v11
    } else {
        false
    };
    if v12 {
        0i32
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
