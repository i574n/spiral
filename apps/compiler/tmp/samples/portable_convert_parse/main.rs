#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Some(i32),
    US0_None,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Some(..) => 0,
            US0::US0_None => 1,
        }
    }
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
    let mut v31: i32 = i32::from_str_radix(&*(v0), (16i32) as u32).unwrap();
    println!("{}", v31);
    let mut v69: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("1011"); } LIT.with(|lit| lit.clone()) };
    let mut v85: i32 = i32::from_str_radix(&*(v69), (2i32) as u32).unwrap();
    println!("{}", v85);
    let mut v94: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-42"); } LIT.with(|lit| lit.clone()) };
    let mut v134: i32 = i32::from_str_radix(&*(v94), (10i32) as u32).unwrap();
    println!("{}", v134);
    let mut v143: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" 123 "); } LIT.with(|lit| lit.clone()) };
    let mut v356: Option<i32> = (v143).trim().parse::<i32>().ok();
    let mut v582: Option<i32> = method0(v356.clone());
    let mut v583: Rc<dyn Fn((i32)) -> US0> = closure0();
    let mut v584: Option<US0> = v582.map(|x| v583(x));
    let mut v686: US0 = US0::US0_None;
    let mut v687: US0 = v584.unwrap_or(v686);
    match &v687 {
        US0::US0_None => {
            let mut v802: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v802);
            ()
        }
        US0::US0_Some(v795) => {
            let mut v795: i32 = *v795;
            println!("{}", v795);
            ()
        }
    };
    let mut v804: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("12x"); } LIT.with(|lit| lit.clone()) };
    let mut v805: Option<i32> = (v804).trim().parse::<i32>().ok();
    let mut v806: Option<i32> = method0(v805.clone());
    let mut v807: Option<US0> = v806.map(|x| v583(x));
    let mut v808: US0 = US0::US0_None;
    let mut v809: US0 = v807.unwrap_or(v808);
    match &v809 {
        US0::US0_None => {
            let mut v811: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v811);
            ()
        }
        US0::US0_Some(v810) => {
            let mut v810: i32 = *v810;
            println!("{}", v810);
            ()
        }
    };
    let mut v812: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v813: Option<i32> = (v812).trim().parse::<i32>().ok();
    let mut v814: Option<i32> = method0(v813.clone());
    let mut v815: Option<US0> = v814.map(|x| v583(x));
    let mut v816: US0 = US0::US0_None;
    let mut v817: US0 = v815.unwrap_or(v816);
    match &v817 {
        US0::US0_None => {
            let mut v819: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v819);
            ()
        }
        US0::US0_Some(v818) => {
            let mut v818: i32 = *v818;
            println!("{}", v818);
            ()
        }
    };
    let mut v820: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("+7"); } LIT.with(|lit| lit.clone()) };
    let mut v821: Option<i32> = (v820).trim().parse::<i32>().ok();
    let mut v822: Option<i32> = method0(v821.clone());
    let mut v823: Option<US0> = v822.map(|x| v583(x));
    let mut v824: US0 = US0::US0_None;
    let mut v825: US0 = v823.unwrap_or(v824);
    match &v825 {
        US0::US0_None => {
            let mut v827: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("none"); } LIT.with(|lit| lit.clone()) };
            println!("{}", v827);
            ()
        }
        US0::US0_Some(v826) => {
            let mut v826: i32 = *v826;
            println!("{}", v826);
            ()
        }
    };
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
