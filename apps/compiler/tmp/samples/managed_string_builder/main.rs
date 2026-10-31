#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method2(mut v0: i32, mut v1: Rc<str>, mut v2: Rc<str>) -> Rc<str> {
    loop {
        let v3: i32 = v0.wrapping_sub(1i32);
        let v4: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), v2.clone()));
        let v5: bool = v3 == 0i32;
        if v5 {
            return v4.clone();
        } else {
            let v6: i32 = v3.wrapping_rem(2i32);
            let v7: bool = v6 == 0i32;
            let v10: Rc<str> = if v7 {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
                v8.clone()
            } else {
                let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
                v9.clone()
            };
            (v0, v1, v2) = (v3, v4.clone(), v10.clone());
            continue;
        }
    }
}
fn method1(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    let v2: i32 = v0.wrapping_sub(1i32);
    let v3: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }, v1));
    let v4: bool = v2 == 0i32;
    if v4 {
        v3.clone()
    } else {
        let v5: i32 = v2.wrapping_rem(2i32);
        let v6: bool = v5 == 0i32;
        let v9: Rc<str> = if v6 {
            let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
            v7
        } else {
            let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
            v8
        };
        method2(v2, v3, v9)
    }
}
fn method0() -> Rc<str> {
    let v0: i32 = 4i32;
    let v1: bool = v0 == 0i32;
    if v1 {
        let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v2
    } else {
        let v3: i32 = v0.wrapping_rem(2i32);
        let v4: bool = v3 == 0i32;
        let v7: Rc<str> = if v4 {
            let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ab"); } LIT.with(|lit| lit.clone()) };
            v5
        } else {
            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
            v6
        };
        method1(v0, v7)
    }
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = method0();
    let v1: i32 = (v0.clone().len() as i32);
    let v2: bool = v1 == 6i32;
    if v2 {
        let v3: u8 = v0.clone().as_bytes()[0i32 as usize];
        let v4: bool = v3 == b'a';
        if v4 {
            let v5: u8 = v0.as_bytes()[5i32 as usize];
            let v6: bool = v5 == b'c';
            if v6 {
                0i32
            } else {
                1i32
            }
        } else {
            2i32
        }
    } else {
        3i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
