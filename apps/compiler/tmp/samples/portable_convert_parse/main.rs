#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Some(i32),
    US0_None,
}
fn method0(mut v0: Option<i32>) -> Option<i32> {
    v0
}
fn closure0() -> Rc<dyn Fn((i32)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((i32)) -> US0> = Rc::new(move |mut v0: (i32)| -> US0 {
        let v1: i32 = (v0);
        US0::US0_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn spiral_main() -> i32 {
    let v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ff"); } LIT.with(|lit| lit.clone()) };
    let v1: i32 = i32::from_str_radix(&*(v0), (16i32) as u32).unwrap();
    println!("{}", v1);
    let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("1011"); } LIT.with(|lit| lit.clone()) };
    let v3: i32 = i32::from_str_radix(&*(v2), (2i32) as u32).unwrap();
    println!("{}", v3);
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-42"); } LIT.with(|lit| lit.clone()) };
    let v5: i32 = i32::from_str_radix(&*(v4), (10i32) as u32).unwrap();
    println!("{}", v5);
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" 123 "); } LIT.with(|lit| lit.clone()) };
    let v7: Option<i32> = (v6).trim().parse::<i32>().ok();
    let v8: Option<i32> = method0(v7);
    let mut v9: Rc<dyn Fn((i32)) -> US0> = closure0();
    let mut v10: Option<US0> = v8.map(|x| v9(x));
    let v12: US0 = US0::US0_None;
    let v13: US0 = v12;
    let v14: US0 = v10.unwrap_or(v13);
    match &v14 {
        US0::US0_None => {
            let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v16);
            ()
        }
        US0::US0_Some(v15) => {
            let v15: i32 = *v15;
            println!("{}", v15);
            ()
        }
    };
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("12x"); } LIT.with(|lit| lit.clone()) };
    let v18: Option<i32> = (v17).trim().parse::<i32>().ok();
    let v19: Option<i32> = method0(v18);
    let mut v20: Option<US0> = v19.map(|x| v9(x));
    let v22: US0 = US0::US0_None;
    let v23: US0 = v22;
    let v24: US0 = v20.unwrap_or(v23);
    match &v24 {
        US0::US0_None => {
            let v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v26);
            ()
        }
        US0::US0_Some(v25) => {
            let v25: i32 = *v25;
            println!("{}", v25);
            ()
        }
    };
    let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v28: Option<i32> = (v27).trim().parse::<i32>().ok();
    let v29: Option<i32> = method0(v28);
    let mut v30: Option<US0> = v29.map(|x| v9(x));
    let v32: US0 = US0::US0_None;
    let v33: US0 = v32;
    let v34: US0 = v30.unwrap_or(v33);
    match &v34 {
        US0::US0_None => {
            let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v36);
            ()
        }
        US0::US0_Some(v35) => {
            let v35: i32 = *v35;
            println!("{}", v35);
            ()
        }
    };
    let v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+7"); } LIT.with(|lit| lit.clone()) };
    let v38: Option<i32> = (v37).trim().parse::<i32>().ok();
    let v39: Option<i32> = method0(v38);
    let mut v40: Option<US0> = v39.map(|x| v9(x));
    let v42: US0 = US0::US0_None;
    let v43: US0 = v42;
    let v44: US0 = v40.unwrap_or(v43);
    match &v44 {
        US0::US0_None => {
            let v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v46);
            ()
        }
        US0::US0_Some(v45) => {
            let v45: i32 = *v45;
            println!("{}", v45);
            ()
        }
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
