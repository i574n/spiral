#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0(u8),
    US0_1,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0(..) => 0,
            US0::US0_1 => 1,
        }
    }
}
fn method0(mut v0: u8, mut v1: i64) -> bool {
    loop {
        let mut v2: bool = v1 >= 2i64;
        if v2 {
            return false;
        } else {
            let mut v3: bool = v1 == 0i64;
            let mut v11: US0 = if v3 {
                US0::US0_0(b' ')
            } else {
                let mut v5: i64 = v1 - 1i64;
                let mut v6: bool = v5 == 0i64;
                if v6 {
                    US0::US0_0(b'/')
                } else {
                    let mut v8: i64 = v5 - 1i64;
                    US0::US0_1
                }
            };
            let mut v15: u8 = match &v11 {
                US0::US0_1 => { // None
                    { eprintln!("{}", Rc::<str>::from("Option does not have a value.")); std::process::exit(1) }
                }
                US0::US0_0(v12) => { // Some
                    let mut v12: u8 = v12.clone();
                    v12
                }
                _ => unreachable!(),
            };
            let mut v16: bool = v0 == v15;
            if v16 {
                return true;
            } else {
                let mut v17: i64 = v1 + 1i64;
                (v0, v1) = (v0, v17);
                continue;
            }
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: u8 = b'x';
    let mut v1: i64 = 0i64;
    let mut v2: bool = method0(v0, v1);
    if v2 {
        1i32
    } else {
        0i32
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
