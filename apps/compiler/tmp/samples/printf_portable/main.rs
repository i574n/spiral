#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let mut v0: i32 = 60i32;
    let mut v1: i64 = -9000000000i64;
    let mut v2: u8 = 200u8;
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cube"); } LIT.with(|lit| lit.clone()) };
    print!("{}: {} frames, checksum {}\n", v3.clone(), v0, 970392i32);
    print!("big {}, small {}, byte {}\n", v1, -5i32, v2);
    print!("100% {{braces}} \"quoted\" \\ tab\tend\n");
    print!("{}\n", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("literal"); } LIT.with(|lit| lit.clone()) });
    print!("{}", v3.clone());
    print!("\n");
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
