#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_concat(parts: &[&str]) -> Rc<str> {
    let mut joined = Rc::<[u8]>::new_uninit_slice(parts.iter().map(|part| part.len()).sum());
    let bytes = Rc::get_mut(&mut joined).unwrap().as_mut_ptr() as *mut u8;
    let mut at = 0;
    for part in parts {
        unsafe { std::ptr::copy_nonoverlapping(part.as_ptr(), bytes.add(at), part.len()) };
        at += part.len();
    }
    unsafe { Rc::from_raw(Rc::into_raw(joined.assume_init()) as *const str) }
}
fn label_1(mut v0: bool) -> Rc<str> {
    if v0 {
        let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a"); } LIT.with(|lit| lit.clone()) };
        v1
    } else {
        let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b"); } LIT.with(|lit| lit.clone()) };
        v2
    }
}
fn grow_0(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let v2: bool = v0 <= 0i32;
        if v2 {
            return v1;
        } else {
            let v3: i32 = v0.wrapping_rem(2i32);
            let v4: bool = v3 == 0i32;
            let v5: Rc<str> = label_1(v4);
            let v9: Rc<str> = string_concat(&[&*v1, &*v5, "-", &*v5, &*v5]);
            let v10: i32 = v0.wrapping_sub(1i32);
            (v0, v1) = (v10, v9);
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("s"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = grow_0(v0, v1);
    let v4: Rc<str> = string_concat(&[&*v2, &*v2, "!"]);
    let v5: i32 = (v4.clone().len() as i32);
    let v6: bool = v5 == 27i32;
    if v6 {
        let v7: u8 = v4.clone().as_bytes()[26i32 as usize];
        let v8: bool = v7 == b'!';
        if v8 {
            let v9: u8 = v4.clone().as_bytes()[13i32 as usize];
            let v10: bool = v9 == b's';
            if v10 {
                let v11: u8 = v4.as_bytes()[12i32 as usize];
                let v12: bool = v11 == b'b';
                if v12 {
                    0i32
                } else {
                    4i32
                }
            } else {
                3i32
            }
        } else {
            2i32
        }
    } else {
        1i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
