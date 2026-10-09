#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_0(i32),
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
fn method0(mut v0: Option<i32>) -> Option<i32> {
    v0.clone()
}
fn closure0() -> Rc<dyn Fn((i32)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((i32)) -> US0> = Rc::new(move |mut v0: (i32)| -> US0 {
        let mut v1: i32 = (v0);
        US0::US0_0(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn spiral_main() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("ff"); } LIT.with(|lit| lit.clone()) };
    let mut v30: i32 = i32::from_str_radix(&*(v0), (16i32) as u32).unwrap();
    println!("{}", v30);
    let mut v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("1011"); } LIT.with(|lit| lit.clone()) };
    let mut v83: i32 = i32::from_str_radix(&*(v67), (2i32) as u32).unwrap();
    println!("{}", v83);
    let mut v91: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-42"); } LIT.with(|lit| lit.clone()) };
    let mut v130: i32 = i32::from_str_radix(&*(v91), (10i32) as u32).unwrap();
    println!("{}", v130);
    let mut v138: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" 123 "); } LIT.with(|lit| lit.clone()) };
    let mut v324: Option<i32> = (v138).trim().parse::<i32>().ok();
    let mut v521: Option<i32> = method0(v324.clone());
    let mut v522: Rc<dyn Fn((i32)) -> US0> = closure0();
    let mut v523: Option<US0> = v521.map(|x| v522(x));
    let mut v612: US0 = US0::US0_1;
    let mut v613: US0 = v523.unwrap_or(v612);
    match &v613 {
        US0::US0_1 => {
            let mut v707: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v707);
            ()
        }
        US0::US0_0(v700) => {
            let mut v700: i32 = *v700;
            println!("{}", v700);
            ()
        }
    };
    let mut v709: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("12x"); } LIT.with(|lit| lit.clone()) };
    let mut v710: Option<i32> = (v709).trim().parse::<i32>().ok();
    let mut v711: Option<i32> = method0(v710.clone());
    let mut v712: Option<US0> = v711.map(|x| v522(x));
    let mut v713: US0 = US0::US0_1;
    let mut v714: US0 = v712.unwrap_or(v713);
    match &v714 {
        US0::US0_1 => {
            let mut v716: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v716);
            ()
        }
        US0::US0_0(v715) => {
            let mut v715: i32 = *v715;
            println!("{}", v715);
            ()
        }
    };
    let mut v717: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v718: Option<i32> = (v717).trim().parse::<i32>().ok();
    let mut v719: Option<i32> = method0(v718.clone());
    let mut v720: Option<US0> = v719.map(|x| v522(x));
    let mut v721: US0 = US0::US0_1;
    let mut v722: US0 = v720.unwrap_or(v721);
    match &v722 {
        US0::US0_1 => {
            let mut v724: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v724);
            ()
        }
        US0::US0_0(v723) => {
            let mut v723: i32 = *v723;
            println!("{}", v723);
            ()
        }
    };
    let mut v725: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+7"); } LIT.with(|lit| lit.clone()) };
    let mut v726: Option<i32> = (v725).trim().parse::<i32>().ok();
    let mut v727: Option<i32> = method0(v726.clone());
    let mut v728: Option<US0> = v727.map(|x| v522(x));
    let mut v729: US0 = US0::US0_1;
    let mut v730: US0 = v728.unwrap_or(v729);
    match &v730 {
        US0::US0_1 => {
            let mut v732: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v732);
            ()
        }
        US0::US0_0(v731) => {
            let mut v731: i32 = *v731;
            println!("{}", v731);
            ()
        }
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
