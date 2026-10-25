#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Some(i32),
    US0_None,
}
fn method0(mut v0: Option<i32>) -> Option<i32> {
    v0.clone()
}
fn closure0() -> Rc<dyn Fn((i32)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((i32)) -> US0> = Rc::new(move |mut v0: (i32)| -> US0 {
        let mut v1: i32 = (v0);
        US0::US0_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ff"); } LIT.with(|lit| lit.clone()) };
    let mut v1: i32 = i32::from_str_radix(&*(v0), (16i32) as u32).unwrap();
    println!("{}", v1);
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("1011"); } LIT.with(|lit| lit.clone()) };
    let mut v3: i32 = i32::from_str_radix(&*(v2), (2i32) as u32).unwrap();
    println!("{}", v3);
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-42"); } LIT.with(|lit| lit.clone()) };
    let mut v5: i32 = i32::from_str_radix(&*(v4), (10i32) as u32).unwrap();
    println!("{}", v5);
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" 123 "); } LIT.with(|lit| lit.clone()) };
    let mut v7: Option<i32> = (v6).trim().parse::<i32>().ok();
    let mut v8: Option<i32> = method0(v7.clone());
    let mut v9: Rc<dyn Fn((i32)) -> US0> = closure0();
    let mut v10: Option<US0> = v8.map(|x| v9(x));
    let mut v11: US0 = US0::US0_None;
    let mut v12: US0 = v10.unwrap_or(v11);
    match &v12 {
        US0::US0_None => {
            let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v14);
            ()
        }
        US0::US0_Some(v13) => {
            let mut v13: i32 = *v13;
            println!("{}", v13);
            ()
        }
    };
    let mut v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("12x"); } LIT.with(|lit| lit.clone()) };
    let mut v16: Option<i32> = (v15).trim().parse::<i32>().ok();
    let mut v17: Option<i32> = method0(v16.clone());
    let mut v18: Option<US0> = v17.map(|x| v9(x));
    let mut v19: US0 = US0::US0_None;
    let mut v20: US0 = v18.unwrap_or(v19);
    match &v20 {
        US0::US0_None => {
            let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v22);
            ()
        }
        US0::US0_Some(v21) => {
            let mut v21: i32 = *v21;
            println!("{}", v21);
            ()
        }
    };
    let mut v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v24: Option<i32> = (v23).trim().parse::<i32>().ok();
    let mut v25: Option<i32> = method0(v24.clone());
    let mut v26: Option<US0> = v25.map(|x| v9(x));
    let mut v27: US0 = US0::US0_None;
    let mut v28: US0 = v26.unwrap_or(v27);
    match &v28 {
        US0::US0_None => {
            let mut v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v30);
            ()
        }
        US0::US0_Some(v29) => {
            let mut v29: i32 = *v29;
            println!("{}", v29);
            ()
        }
    };
    let mut v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+7"); } LIT.with(|lit| lit.clone()) };
    let mut v32: Option<i32> = (v31).trim().parse::<i32>().ok();
    let mut v33: Option<i32> = method0(v32.clone());
    let mut v34: Option<US0> = v33.map(|x| v9(x));
    let mut v35: US0 = US0::US0_None;
    let mut v36: US0 = v34.unwrap_or(v35);
    match &v36 {
        US0::US0_None => {
            let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v38);
            ()
        }
        US0::US0_Some(v37) => {
            let mut v37: i32 = *v37;
            println!("{}", v37);
            ()
        }
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
