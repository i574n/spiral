#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_trace_hold<T: Clone>(fresh: &std::rc::Rc<dyn Fn() -> T>) -> T {
    use std::sync::OnceLock;
    static SLOT: OnceLock<usize> = OnceLock::new();
    let raw = *SLOT.get_or_init(|| Box::into_raw(Box::new((*fresh)())) as usize);
    unsafe { (*(raw as *const T)).clone() }
}
#[cfg(target_arch = "wasm32")]
fn spiral_trace_near_log(text: &str) {
    use std::sync::atomic::{AtomicUsize, Ordering};
    static LOGGED: AtomicUsize = AtomicUsize::new(0);
    let cs: Vec<char> = text.chars().collect();
    for c in cs.chunks(15000) {
        let s: String = c.iter().collect();
        let used = LOGGED.load(Ordering::Relaxed);
        let budget = 16000usize.saturating_sub(used);
        if budget < 13 {
            break;
        }
        let s = if s.len() <= budget {
            s
        } else {
            let mut end = budget - 12;
            while !s.is_char_boundary(end) {
                end -= 1;
            }
            format!("{} [truncated]", &s[..end])
        };
        LOGGED.store(used + s.len(), Ordering::Relaxed);
        near_sdk::env::log_str(&s);
    }
}
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }; }
    // A slice that starts or ends inside a code point fails like the C and Delphi backends (abort / Halt(3)).
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
#[derive(Clone)]
enum US0 {
    US0_0(std::string::String),
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
#[derive(Clone)]
enum US3 {
    US3_0,
    US3_1,
    US3_2,
    US3_3,
    US3_4,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_0 => 0,
            US3::US3_1 => 1,
            US3::US3_2 => 2,
            US3::US3_3 => 3,
            US3::US3_4 => 4,
        }
    }
}
#[derive(Clone)]
enum US2 {
    US2_0(US3),
    US2_1,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_0(..) => 0,
            US2::US2_1 => 1,
        }
    }
}
#[derive(Clone)]
enum US1 {
    US1_0(US2),
    US1_1,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_0(..) => 0,
            US1::US1_1 => 1,
        }
    }
}
struct Mut0 { l0: i32, l1: US2 }
struct Mut1 { l0: i64 }
struct Mut2 { l0: Rc<dyn Fn(Rc<str>) -> ()> }
struct Mut3 { l0: bool }
struct Mut4 { l0: Rc<str> }
struct Mut5 { l0: US3 }
#[derive(Clone)]
enum US4 {
    US4_0(Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>),
    US4_1,
}
impl US4 {
    fn tag(&self) -> i32 {
        match self {
            US4::US4_0(..) => 0,
            US4::US4_1 => 1,
        }
    }
}
#[derive(Clone)]
enum US5 {
    US5_0(Rc<str>),
    US5_1,
}
impl US5 {
    fn tag(&self) -> i32 {
        match self {
            US5::US5_0(..) => 0,
            US5::US5_1 => 1,
        }
    }
}
#[derive(Clone)]
enum US6 {
    US6_0(u8, US5),
    US6_1(u8, US5),
}
impl US6 {
    fn tag(&self) -> i32 {
        match self {
            US6::US6_0(..) => 0,
            US6::US6_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US7 {
    US7_0(US5),
    US7_1(std::string::String),
}
impl US7 {
    fn tag(&self) -> i32 {
        match self {
            US7::US7_0(..) => 0,
            US7::US7_1(..) => 1,
        }
    }
}
#[derive(Clone)]
enum US8 {
    US8_0(u8),
    US8_1(std::string::String),
}
impl US8 {
    fn tag(&self) -> i32 {
        match self {
            US8::US8_0(..) => 0,
            US8::US8_1(..) => 1,
        }
    }
}
fn closure0() -> Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = Rc::new(move |mut v0: (Rc<str>)| -> clap::builder::PossibleValue {
        let mut v1: Rc<str> = (v0);
        let mut v13: &str = &*v1;
        let mut v15: std::string::String = String::from(v13);
        let mut v17: Box<std::string::String> = Box::new(v15);
        let mut v19: &'static mut std::string::String = Box::leak(v17);
        let mut v21: clap::builder::PossibleValue = clap::builder::PossibleValue::new(&**v19);
        v21.clone()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method0() -> clap::Command {
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("command"); } LIT.with(|lit| lit.clone()) };
    let mut v4: &'static str = Box::leak(String::from(&*v3).into_boxed_str());
    let mut v6: clap::Command = clap::Command::new(v4);
    let mut v8: clap::Command = clap::Command::args_override_self(v6, true);
    let mut v16: usize = ((0i32) as usize);
    let mut v24: usize = ((1i32) as usize);
    let mut v25: usize = ((0i32) as usize);
    let mut v27: bool = v24 == v25 ;
    let mut v33: clap::builder::ValueRange = if v27 {
        let mut v29: clap::builder::ValueRange = clap::builder::ValueRange::new(v16..);
        v29.clone()
    } else {
        let mut v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
        let mut v32: clap::builder::ValueRange = clap::builder::ValueRange::new(v16..=v24);
        v32.clone()
    };
    let mut v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    let mut v38: &'static str = Box::leak(String::from(&*v37).into_boxed_str());
    let mut v40: clap::Arg = clap::Arg::new(v38);
    let mut v42: clap::Arg = v40.short(b'e' as char);
    let mut v43: &'static str = Box::leak(String::from(&*v37).into_boxed_str());
    let mut v45: clap::Arg = v42.long(v43);
    let mut v47: clap::Arg = v45.num_args(v33);
    let mut v49: clap::Arg = v47.require_equals(true);
    let mut v53: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v54: &str = (&*v53);
    let mut v58: clap::Arg = v49.default_missing_value(&*Box::leak(String::from(v54).into_boxed_str()));
    let mut v60: clap::Command = clap::Command::arg(v8, v58);
    let mut v64: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    let mut v65: &'static str = Box::leak(String::from(&*v64).into_boxed_str());
    let mut v67: clap::Arg = clap::Arg::new(v65);
    let mut v69: clap::Arg = v67.short(b't' as char);
    let mut v70: &'static str = Box::leak(String::from(&*v64).into_boxed_str());
    let mut v72: clap::Arg = v69.long(v70);
    ;
    ;
    ;
    ;
    ;
    let mut v73: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v74: Rc<str> = Rc::<str>::from(v73.to_lowercase());
    let mut v75: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v76: Rc<str> = Rc::<str>::from(v75.to_lowercase());
    let mut v77: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v78: Rc<str> = Rc::<str>::from(v77.to_lowercase());
    let mut v79: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let mut v80: Rc<str> = Rc::<str>::from(v79.to_lowercase());
    let mut v81: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v82: Rc<str> = Rc::<str>::from(v81.to_lowercase());
    let mut v115: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v115.borrow_mut().push(v82);
    v115.borrow_mut().push(v80);
    v115.borrow_mut().push(v78);
    v115.borrow_mut().push(v76);
    v115.borrow_mut().push(v74);
    let mut v116: Rc<Vec<Rc<str>>> = Rc::new(v115.borrow().clone());
    let mut v119: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v116).as_ref().clone()));
    let mut v122: Vec<Rc<str>> = (v119).borrow().clone();
    let mut v124: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v125: Vec<clap::builder::PossibleValue> = v122.iter().map(|x| v124(x.clone())).collect::<Vec<_>>();
    let mut v127: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v125));
    let mut v129: clap::Arg = v72.value_parser(v127);
    let mut v131: clap::Command = clap::Command::arg(v60, v129);
    let mut v135: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let mut v136: &'static str = Box::leak(String::from(&*v135).into_boxed_str());
    let mut v138: clap::Arg = clap::Arg::new(v136);
    let mut v140: clap::Arg = v138.short(b'w' as char);
    let mut v141: &'static str = Box::leak(String::from(&*v135).into_boxed_str());
    let mut v143: clap::Arg = v140.long(v141);
    let mut v145: clap::Arg = v143.required(true);
    let mut v147: clap::Command = clap::Command::arg(v131, v145);
    v147.clone()
}
fn method1() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method2(mut v0: Option<std::string::String>) -> Option<std::string::String> {
    v0.clone()
}
fn closure1() -> Rc<dyn Fn((std::string::String)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> US0> = Rc::new(move |mut v0: (std::string::String)| -> US0 {
        let mut v1: std::string::String = (v0);
        US0::US0_0(v1.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method3(mut v0: i32, mut v1: Rc<RefCell<Mut0>>) -> bool {
    let mut v2: i32 = v1.borrow().l0.clone();
    let mut v3: bool = v2 < v0;
    v3
}
fn method5(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from(std::env::var(&*v0).unwrap_or_default());
    v1.clone()
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        ()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method4(mut v0: US3) -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("TRACE_LEVEL"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = method5(v1.clone());
    ;
    ;
    ;
    ;
    ;
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = Rc::<str>::from(v3.to_lowercase());
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v6: Rc<str> = Rc::<str>::from(v5.to_lowercase());
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = Rc::<str>::from(v7.to_lowercase());
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let mut v10: Rc<str> = Rc::<str>::from(v9.to_lowercase());
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(v11.to_lowercase());
    let mut v13: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
    let mut v14: US3 = US3::US3_0;
    v13.borrow_mut().push((v11.clone(), v14.clone()));
    let mut v15: US3 = US3::US3_1;
    v13.borrow_mut().push((v9.clone(), v15.clone()));
    let mut v16: US3 = US3::US3_2;
    v13.borrow_mut().push((v7.clone(), v16.clone()));
    let mut v17: US3 = US3::US3_3;
    v13.borrow_mut().push((v5.clone(), v17.clone()));
    let mut v18: US3 = US3::US3_4;
    v13.borrow_mut().push((v3.clone(), v18.clone()));
    let mut v19: US3 = US3::US3_0;
    v13.borrow_mut().push((v12.clone(), v19.clone()));
    let mut v20: US3 = US3::US3_1;
    v13.borrow_mut().push((v10.clone(), v20.clone()));
    let mut v21: US3 = US3::US3_2;
    v13.borrow_mut().push((v8.clone(), v21.clone()));
    let mut v22: US3 = US3::US3_3;
    v13.borrow_mut().push((v6.clone(), v22.clone()));
    let mut v23: US3 = US3::US3_4;
    v13.borrow_mut().push((v4.clone(), v23.clone()));
    let mut v24: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v13.borrow().clone());
    let mut v25: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v24).as_ref().clone()));
    let mut v26: i32 = (v25.clone().borrow().len() as i32);
    let mut v27: US2 = US2::US2_1;
    let mut v28: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v27.clone() }));
    while method3(v26, v28.clone()) {
        let mut v30: i32 = v28.borrow().l0.clone();
        let mut v31: i32 = -(v30);
        let mut v32: i32 = v31 + v26;
        let mut v33: i32 = v32 - 1i32;
        let mut v34: US2 = v28.borrow().l1.clone();
        let (mut v35, mut v36): (Rc<str>, US3) = v25.clone().borrow()[v33 as usize].clone();
        let mut v43: US2 = match &v34 {
            US2::US2_1 => { // None
                let mut v38: bool = v35 == v2 ;
                if v38 {
                    US2::US2_0(v36.clone())
                } else {
                    US2::US2_1
                }
            }
            US2::US2_0(v37) => { // Some
                let mut v37: US3 = v37.clone();
                v34.clone()
            }
            _ => unreachable!(),
        };
        let mut v44: i32 = v30 + 1i32;
        v28.borrow_mut().l0 = v44;
        v28.borrow_mut().l1 = v43.clone();
        ()
    };
    let mut v45: US2 = v28.borrow().l1.clone();
    let mut v46: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: 1i64 }));
    let mut v47: Rc<dyn Fn(Rc<str>) -> ()> = closure3();
    let mut v48: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: v47.clone() }));
    let mut v49: Rc<RefCell<Mut3>> = Rc::new(RefCell::new(Mut3 { l0: true }));
    let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v51: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v50.clone() }));
    let mut v54: US3 = match &v45 {
        US2::US2_1 => { // None
            v0.clone()
        }
        US2::US2_0(v52) => { // Some
            let mut v52: US3 = v52.clone();
            v52.clone()
        }
        _ => unreachable!(),
    };
    let mut v55: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v54.clone() }));
    let mut v56: Option<i64> = None;
    (v46.clone(), v48.clone(), v49.clone(), v51.clone(), v55.clone(), v56.clone())
}
fn closure2(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = method4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    })
}
fn closure4(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = method4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    })
}
fn closure5() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_0;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = method4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure6() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_0;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = method4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method6(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>) -> Rc<str> {
    let mut v7: Rc<str> = { #[cfg(target_arch = "wasm32")] let (h, m, s) = { let secs = near_sdk::env::block_timestamp() / 1_000_000_000; ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; #[cfg(all(windows, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C)] struct St([u16; 8]); unsafe extern "system" { fn GetLocalTime(t: *mut St); } let mut t = St([0; 8]); unsafe { GetLocalTime(&mut t) }; (t.0[4] as u64, t.0[5] as u64, t.0[6] as u64) }; #[cfg(all(unix, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C, align(8))] struct Tm([i32; 16]); unsafe extern "C" { fn localtime_r(t: *const std::os::raw::c_long, tm: *mut Tm) -> *mut Tm; } let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0) as std::os::raw::c_long; let mut tm = Tm([0; 16]); unsafe { localtime_r(&secs, &mut tm) }; (tm.0[2] as u64, tm.0[1] as u64, tm.0[0] as u64) }; #[cfg(not(any(windows, unix, target_arch = "wasm32")))] let (h, m, s) = { let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0); ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; let mut buf = String::new(); let push = |buf: &mut String, n: u64| { if n < 10 { buf.push(char::from(48)); } buf.push_str(&n.to_string()); }; push(&mut buf, h); buf.push(char::from(58)); push(&mut buf, m); buf.push(char::from(58)); push(&mut buf, s); Rc::<str>::from(buf) };
    v7.clone()
}
fn method9(mut v0: Rc<RefCell<Mut4>>, mut v1: Rc<str>) -> () {
    let mut v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, v1));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method8(mut v0: u8) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0 as char));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method7() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[90m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = method8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method12(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v2 >= v1;
        if v3 {
            return v1;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v5: bool = v4 == b' ';
            let mut v11: bool = if v5 {
                true
            } else {
                let mut v6: bool = v4 == b'\t';
                if v6 {
                    true
                } else {
                    let mut v7: bool = v4 == b'\r';
                    if v7 {
                        true
                    } else {
                        let mut v8: bool = v4 == b'\n';
                        v8
                    }
                }
            };
            if v11 {
                let mut v12: i32 = v2 + 1i32;
                (v0, v1, v2) = (v0.clone(), v1, v12);
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn method13(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 <= 0i32;
        if v2 {
            return -1i32;
        } else {
            let mut v3: i32 = v1 - 1i32;
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v5: bool = v4 == b' ';
            let mut v7: bool = if v5 {
                true
            } else {
                let mut v6: bool = v4 == b'/';
                v6
            };
            if v7 {
                (v0, v1) = (v0.clone(), v3);
                continue;
            } else {
                return v3;
            }
        }
    }
}
fn method11(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: i32 = 0i32;
    let mut v3: i32 = method12(v0.clone(), v1, v2);
    let mut v4: i32 = v1 - 1i32;
    let mut v5: Rc<str> = string_slice(&v0.clone(), v3 as i64, v4 as i64);
    let mut v6: i32 = (v5.clone().len() as i32);
    let mut v7: i32 = method13(v5.clone(), v6);
    let mut v8: Rc<str> = string_slice(&v5.clone(), 0i32 as i64, v7 as i64);
    v8.clone()
}
fn method14(mut v0: i64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method16(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method17(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("args"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method18(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method19(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method15(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method17(v2.clone());
    method18(v2.clone());
    let mut v3: Rc<str> = Rc::<str>::from(format!("{:?}", v0.borrow()));
    method9(v2.clone(), v3.clone());
    method19(v2.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method10(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.main"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method15(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        println!("{}", v0);
        ()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method20() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method21(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v2 >= v1;
        if v3 {
            return v1;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v5: bool = v4 == b'\\';
            if v5 {
                let mut v6: i32 = v2 + 1i32;
                (v0, v1, v2) = (v0.clone(), v1, v6);
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn method22(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 <= 0i32;
        if v2 {
            return -1i32;
        } else {
            let mut v3: i32 = v1 - 1i32;
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v5: bool = v4 == b'\\';
            if v5 {
                (v0, v1) = (v0.clone(), v3);
                continue;
            } else {
                return v3;
            }
        }
    }
}
fn closure8() -> Rc<dyn Fn((std::string::String)) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> Rc<str>> = Rc::new(move |mut v0: (std::string::String)| -> Rc<str> {
        let mut v1: std::string::String = (v0);
        let mut v3: Rc<str> = Rc::<str>::from(String::as_str(&v1));
        let mut v4: i32 = (v3.clone().len() as i32);
        let mut v5: i32 = 0i32;
        let mut v6: i32 = method21(v3.clone(), v4, v5);
        let mut v7: i32 = v4 - 1i32;
        let mut v8: Rc<str> = string_slice(&v3.clone(), v6 as i64, v7 as i64);
        let mut v9: i32 = (v8.clone().len() as i32);
        let mut v10: i32 = method22(v8.clone(), v9);
        let mut v11: Rc<str> = string_slice(&v8.clone(), 0i32 as i64, v10 as i64);
        v11.clone()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method23(mut v0: Option<Rc<str>>) -> Option<Rc<str>> {
    v0.clone()
}
fn closure9() -> Rc<dyn Fn((Rc<str>)) -> US5> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> US5> = Rc::new(move |mut v0: (Rc<str>)| -> US5 {
        let mut v1: Rc<str> = (v0);
        US5::US5_0(v1.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method25() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method28(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm_path"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method27(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method28(v2.clone());
    method18(v2.clone());
    method9(v2.clone(), v0.clone());
    method19(v2.clone());
    let mut v3: Rc<str> = v2.borrow().l0.clone();
    v3.clone()
}
fn method26(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<str>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method27(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn method33(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method34(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method35(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("worker"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method36(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("contract"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method32(mut v0: u8, mut v1: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v2: near_workspaces::Contract) -> Rc<str> {
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v3.clone() }));
    method16(v4.clone());
    method33(v4.clone());
    method18(v4.clone());
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v4.clone(), v5.clone());
    method34(v4.clone());
    method35(v4.clone());
    method18(v4.clone());
    let mut v7: std::string::String = format!("{:#?}", v1);
    let mut v9: Rc<str> = Rc::<str>::from(v7);
    method9(v4.clone(), v9.clone());
    method34(v4.clone());
    method36(v4.clone());
    method18(v4.clone());
    let mut v11: std::string::String = format!("{:#?}", v2);
    let mut v13: Rc<str> = Rc::<str>::from(v11);
    method9(v4.clone(), v13.clone());
    method19(v4.clone());
    let mut v14: Rc<str> = v4.borrow().l0.clone();
    v14.clone()
}
fn method31(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v10: near_workspaces::Contract) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0.clone();
    let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v12));
    let mut v14: Rc<str> = method14(v11);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v7));
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v12));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = method32(v8, v9.clone(), v10.clone());
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    method11(v23.clone())
}
fn method39(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method38(mut v0: u8, mut v1: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method33(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method39(v3.clone());
    method18(v3.clone());
    let mut v6: std::string::String = format!("{:#?}", v1);
    let mut v8: Rc<str> = Rc::<str>::from(v6);
    method9(v3.clone(), v8.clone());
    method19(v3.clone());
    let mut v9: Rc<str> = v3.borrow().l0.clone();
    v9.clone()
}
fn method37(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = method38(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn closure10() -> Rc<dyn Fn((&str)) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((&str)) -> std::string::String> = Rc::new(move |mut v0: (&str)| -> std::string::String {
        let mut v1: &str = (v0);
        let mut v3: std::string::String = String::from(v1);
        v3.clone()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure11() -> Rc<dyn Fn(std::string::String) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> ()> = Rc::new(move |mut v0: std::string::String| -> () {
        println!("{}", v0);
        ()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method40() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = method8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method43(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method44(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method42(mut v0: u8, mut v1: f64, mut v2: u64) -> Rc<str> {
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v3.clone() }));
    method16(v4.clone());
    method33(v4.clone());
    method18(v4.clone());
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v4.clone(), v5.clone());
    method34(v4.clone());
    method43(v4.clone());
    method18(v4.clone());
    let mut v6: Rc<str> = Rc::<str>::from({ let v = v1; if v.is_finite() { format!("{:+.6}", v) } else if v.is_nan() { String::from("NaN") } else if v > 0.0 { String::from("Infinity") } else { String::from("-Infinity") } });
    method9(v4.clone(), v6.clone());
    method34(v4.clone());
    method44(v4.clone());
    method18(v4.clone());
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}", v2));
    method9(v4.clone(), v7.clone());
    method19(v4.clone());
    let mut v8: Rc<str> = v4.borrow().l0.clone();
    v8.clone()
}
fn method41(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: f64, mut v10: u64) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0.clone();
    let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v12));
    let mut v14: Rc<str> = method14(v11);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v7));
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v12));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = method42(v8, v9, v10);
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    method11(v23.clone())
}
fn method47(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("is_success"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method48(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method49(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method50(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method51(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method46(mut v0: bool, mut v1: f64, mut v2: f64, mut v3: u64, mut v4: u128) -> Rc<str> {
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v6: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v5.clone() }));
    method16(v6.clone());
    method47(v6.clone());
    method18(v6.clone());
    let mut v9: Rc<str> = if v0 {
        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("true"); } LIT.with(|lit| lit.clone()) };
        v7.clone()
    } else {
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("false"); } LIT.with(|lit| lit.clone()) };
        v8.clone()
    };
    method9(v6.clone(), v9.clone());
    method34(v6.clone());
    method48(v6.clone());
    method18(v6.clone());
    let mut v10: Rc<str> = Rc::<str>::from({ let v = v1; if v.is_finite() { format!("{:+.6}", v) } else if v.is_nan() { String::from("NaN") } else if v > 0.0 { String::from("Infinity") } else { String::from("-Infinity") } });
    method9(v6.clone(), v10.clone());
    method34(v6.clone());
    method49(v6.clone());
    method18(v6.clone());
    let mut v11: Rc<str> = Rc::<str>::from({ let v = v2; if v.is_finite() { format!("{:+.6}", v) } else if v.is_nan() { String::from("NaN") } else if v > 0.0 { String::from("Infinity") } else { String::from("-Infinity") } });
    method9(v6.clone(), v11.clone());
    method34(v6.clone());
    method50(v6.clone());
    method18(v6.clone());
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}", v3));
    method9(v6.clone(), v12.clone());
    method34(v6.clone());
    method51(v6.clone());
    method18(v6.clone());
    let mut v14: std::string::String = format!("{:#?}", v4);
    let mut v16: Rc<str> = Rc::<str>::from(v14);
    method9(v6.clone(), v16.clone());
    method19(v6.clone());
    let mut v17: Rc<str> = v6.borrow().l0.clone();
    v17.clone()
}
fn method45(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: bool, mut v9: f64, mut v10: f64, mut v11: u64, mut v12: u128) -> Rc<str> {
    let mut v13: i64 = v0.borrow().l0.clone();
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v14));
    let mut v16: Rc<str> = method14(v13);
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v7));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v14));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd / outcome"); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    let mut v24: Rc<str> = method46(v8, v9, v10, v11, v12.clone());
    let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    method11(v25.clone())
}
fn closure12() -> Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = Rc::new(move |mut v0: near_workspaces::result::ExecutionOutcome| -> () {
        let mut v2: bool = v0.is_success();
        let mut v4: near_workspaces::types::Gas = v0.gas_burnt;
        let mut v6: u64 = v4.as_gas();
        let mut v7: f64 = (v6 as f64);
        let mut v8: f64 = v7 / 10000000000000000.0f64;
        let mut v9: f64 = v8 * 6.68f64;
        let mut v11: near_workspaces::types::NearToken = v0.tokens_burnt;
        let mut v13: u128 = v11.as_yoctonear();
        let mut v15: f64 = v13 as f64;
        let mut v16: f64 = v15 / 1E+24f64;
        let mut v17: f64 = v16 * 6.68f64;
        let mut v22: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
        { let _ = spiral_trace_hold(&v22); };
        let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
        let (mut v25, mut v26, mut v27, mut v28, mut v29, mut v30): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v24) };
        let mut v31: US3 = v29.borrow().l0.clone();
        let mut v36: i32 = match &v31 {
            US3::US3_4 => { // Critical
                50i32
            }
            US3::US3_1 => { // Debug
                20i32
            }
            US3::US3_2 => { // Info
                30i32
            }
            US3::US3_0 => { // Verbose
                10i32
            }
            US3::US3_3 => { // Warning
                40i32
            }
            _ => unreachable!(),
        };
        let mut v37: bool = v27.borrow().l0.clone();
        let mut v38: bool = v37 == false;
        let mut v40: bool = if v38 {
            false
        } else {
            let mut v39: bool = 30i32 >= v36;
            v39
        };
        let mut v41: bool = v40 == false;
        let mut v86: US4 = if v41 {
            US4::US4_1
        } else {
            { let _ = spiral_trace_hold(&v22); };
            let (mut v45, mut v46, mut v47, mut v48, mut v49, mut v50): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v24) };
            let mut v51: Rc<str> = method6(v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v50.clone());
            let mut v52: Rc<str> = method40();
            let mut v53: Rc<str> = method45(v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v52.clone(), v2, v9, v17, v6, v13.clone());
            { let _ = spiral_trace_hold(&v22); };
            let (mut v56, mut v57, mut v58, mut v59, mut v60, mut v61): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v24) };
            let mut v62: i64 = v56.borrow().l0.clone();
            let mut v63: i64 = v62 + 1i64;
            v56.borrow_mut().l0 = v63;
            let mut v64: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
            let mut v65: bool = cfg!(target_arch = "wasm32");
            if v65 {
                let mut v66: Rc<str> = v59.borrow().l0.clone();
                let mut v67: bool = v66.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let mut v75: Rc<str> = if v67 {
                    v53.clone()
                } else {
                    let mut v68: bool = v53.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                    if v68 {
                        let mut v69: Rc<str> = v59.borrow().l0.clone();
                        v69.clone()
                    } else {
                        let mut v70: Rc<str> = v59.borrow().l0.clone();
                        let mut v71: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                        let mut v72: Rc<str> = Rc::<str>::from(format!("{}{}", v70, v71));
                        let mut v73: Rc<str> = Rc::<str>::from(format!("{}{}", v72, v53));
                        v73.clone()
                    }
                };
                let mut v77: i32 = ((v75.chars().count() + 14999) / 15000) as i32;
                let mut v78: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let mut v79: bool = v53 != v78 ;
                let mut v81: bool = if v79 {
                    let mut v80: bool = v77 <= 1i32;
                    v80
                } else {
                    false
                };
                if v81 {
                    v59.borrow_mut().l0 = v75.clone();
                    ()
                } else {
                    v59.borrow_mut().l0 = v78.clone();
                    { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v75); };
                    ()
                }
            } else {
                println!("{}", v53);
                ()
            };
            let mut v84: Rc<dyn Fn(Rc<str>) -> ()> = v57.borrow().l0.clone();
            v84(v53.clone());
            US4::US4_0(v56.clone(), v57.clone(), v58.clone(), v59.clone(), v60.clone(), v61.clone())
        };
        ()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method54(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result2"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method53(mut v0: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method54(v2.clone());
    method18(v2.clone());
    let mut v4: std::string::String = format!("{:#?}", v0);
    let mut v6: Rc<str> = Rc::<str>::from(v4);
    method9(v2.clone(), v6.clone());
    method19(v2.clone());
    let mut v7: Rc<str> = v2.borrow().l0.clone();
    v7.clone()
}
fn method52(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method53(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn method55(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0.clone()
}
fn method58(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures_len"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method59(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method57(mut v0: i32, mut v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method58(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method59(v3.clone());
    method18(v3.clone());
    let mut v6: std::string::String = format!("{:#?}", v1);
    let mut v8: Rc<str> = Rc::<str>::from(v6);
    method9(v3.clone(), v8.clone());
    method19(v3.clone());
    let mut v9: Rc<str> = v3.borrow().l0.clone();
    v9.clone()
}
fn method56(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = method57(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn method60(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0.clone()
}
fn method63(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method64(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method62(mut v0: i32, mut v1: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method63(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method64(v3.clone());
    method18(v3.clone());
    let mut v6: std::string::String = format!("{:#?}", v1);
    let mut v8: Rc<str> = Rc::<str>::from(v6);
    method9(v3.clone(), v8.clone());
    method19(v3.clone());
    let mut v9: Rc<str> = v3.borrow().l0.clone();
    v9.clone()
}
fn method61(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = method62(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn method67(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("json"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method66(mut v0: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method67(v2.clone());
    method18(v2.clone());
    let mut v4: std::string::String = format!("{:#?}", v0);
    let mut v6: Rc<str> = Rc::<str>::from(v4);
    method9(v2.clone(), v6.clone());
    method19(v2.clone());
    let mut v7: Rc<str> = v2.borrow().l0.clone();
    v7.clone()
}
fn method65(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method66(v8);
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn method70(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("borsh"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method69(mut v0: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method70(v2.clone());
    method18(v2.clone());
    let mut v4: std::string::String = format!("{:#?}", v0);
    let mut v6: Rc<str> = Rc::<str>::from(v4);
    method9(v2.clone(), v6.clone());
    method19(v2.clone());
    let mut v7: Rc<str> = v2.borrow().l0.clone();
    v7.clone()
}
fn method68(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method69(v8);
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn method71(mut v0: i32, mut v1: u8, mut v2: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v3.clone() }));
    method16(v4.clone());
    method63(v4.clone());
    method18(v4.clone());
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v4.clone(), v5.clone());
    method34(v4.clone());
    method33(v4.clone());
    method18(v4.clone());
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}", v1));
    method9(v4.clone(), v6.clone());
    method34(v4.clone());
    method59(v4.clone());
    method18(v4.clone());
    let mut v8: std::string::String = format!("{:#?}", v2);
    let mut v10: Rc<str> = Rc::<str>::from(v8);
    method9(v4.clone(), v10.clone());
    method19(v4.clone());
    let mut v11: Rc<str> = v4.borrow().l0.clone();
    v11.clone()
}
fn method30(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let mut v7: bool = */ ();
    let mut v9: Result<near_workspaces::Worker<near_workspaces::network::Sandbox>, near_workspaces::error::Error> = near_workspaces::sandbox().await;
    let mut v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
    let mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox> = v11.clone();
    let mut v15: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::Contract, near_workspaces::error::Error>>>> = Box::pin(v13.dev_deploy(&v0));
    let mut v17: Result<near_workspaces::Contract, near_workspaces::error::Error> = v15.await;
    let mut v19: near_workspaces::Contract = v17?;
    let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v24); };
    let mut v26: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v27, mut v28, mut v29, mut v30, mut v31, mut v32): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v33: US3 = v31.borrow().l0.clone();
    let mut v38: i32 = match &v33 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v39: bool = v29.borrow().l0.clone();
    let mut v40: bool = v39 == false;
    let mut v42: bool = if v40 {
        false
    } else {
        let mut v41: bool = 10i32 >= v38;
        v41
    };
    let mut v43: bool = v42 == false;
    let mut v88: US4 = if v43 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v47, mut v48, mut v49, mut v50, mut v51, mut v52): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v53: Rc<str> = method6(v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v52.clone());
        let mut v54: Rc<str> = method7();
        let mut v55: Rc<str> = method31(v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone(), v1, v11.clone(), v19.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v58, mut v59, mut v60, mut v61, mut v62, mut v63): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v64: i64 = v58.borrow().l0.clone();
        let mut v65: i64 = v64 + 1i64;
        v58.borrow_mut().l0 = v65;
        let mut v66: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v67: bool = cfg!(target_arch = "wasm32");
        if v67 {
            let mut v68: Rc<str> = v61.borrow().l0.clone();
            let mut v69: bool = v68.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v77: Rc<str> = if v69 {
                v55.clone()
            } else {
                let mut v70: bool = v55.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v70 {
                    let mut v71: Rc<str> = v61.borrow().l0.clone();
                    v71.clone()
                } else {
                    let mut v72: Rc<str> = v61.borrow().l0.clone();
                    let mut v73: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v74: Rc<str> = Rc::<str>::from(format!("{}{}", v72, v73));
                    let mut v75: Rc<str> = Rc::<str>::from(format!("{}{}", v74, v55));
                    v75.clone()
                }
            };
            let mut v79: i32 = ((v77.chars().count() + 14999) / 15000) as i32;
            let mut v80: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v81: bool = v55 != v80 ;
            let mut v83: bool = if v81 {
                let mut v82: bool = v79 <= 1i32;
                v82
            } else {
                false
            };
            if v83 {
                v61.borrow_mut().l0 = v77.clone();
                ()
            } else {
                v61.borrow_mut().l0 = v80.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v77); };
                ()
            }
        } else {
            println!("{}", v55);
            ()
        };
        let mut v86: Rc<dyn Fn(Rc<str>) -> ()> = v59.borrow().l0.clone();
        v86(v55.clone());
        US4::US4_0(v58.clone(), v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone())
    };
    let mut v90: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v91: near_workspaces::operations::CallTransaction = v19.call(&*v90);
    let mut v95: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v97: near_workspaces::operations::CallTransaction = v91.gas(v95);
    let mut v99: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v97.transact());
    let mut v101: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v99.await;
    let mut v103: near_workspaces::result::ExecutionFinalResult = v101?;
    { let _ = spiral_trace_hold(&v24); };
    let (mut v109, mut v110, mut v111, mut v112, mut v113, mut v114): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v115: US3 = v113.borrow().l0.clone();
    let mut v120: i32 = match &v115 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v121: bool = v111.borrow().l0.clone();
    let mut v122: bool = v121 == false;
    let mut v124: bool = if v122 {
        false
    } else {
        let mut v123: bool = 10i32 >= v120;
        v123
    };
    let mut v125: bool = v124 == false;
    let mut v170: US4 = if v125 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v129, mut v130, mut v131, mut v132, mut v133, mut v134): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v135: Rc<str> = method6(v129.clone(), v130.clone(), v131.clone(), v132.clone(), v133.clone(), v134.clone());
        let mut v136: Rc<str> = method7();
        let mut v137: Rc<str> = method37(v129.clone(), v130.clone(), v131.clone(), v132.clone(), v133.clone(), v134.clone(), v135.clone(), v136.clone(), v1, v103.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v140, mut v141, mut v142, mut v143, mut v144, mut v145): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v146: i64 = v140.borrow().l0.clone();
        let mut v147: i64 = v146 + 1i64;
        v140.borrow_mut().l0 = v147;
        let mut v148: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v149: bool = cfg!(target_arch = "wasm32");
        if v149 {
            let mut v150: Rc<str> = v143.borrow().l0.clone();
            let mut v151: bool = v150.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v159: Rc<str> = if v151 {
                v137.clone()
            } else {
                let mut v152: bool = v137.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v152 {
                    let mut v153: Rc<str> = v143.borrow().l0.clone();
                    v153.clone()
                } else {
                    let mut v154: Rc<str> = v143.borrow().l0.clone();
                    let mut v155: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v156: Rc<str> = Rc::<str>::from(format!("{}{}", v154, v155));
                    let mut v157: Rc<str> = Rc::<str>::from(format!("{}{}", v156, v137));
                    v157.clone()
                }
            };
            let mut v161: i32 = ((v159.chars().count() + 14999) / 15000) as i32;
            let mut v162: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v163: bool = v137 != v162 ;
            let mut v165: bool = if v163 {
                let mut v164: bool = v161 <= 1i32;
                v164
            } else {
                false
            };
            if v165 {
                v143.borrow_mut().l0 = v159.clone();
                ()
            } else {
                v143.borrow_mut().l0 = v162.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v159); };
                ()
            }
        } else {
            println!("{}", v137);
            ()
        };
        let mut v168: Rc<dyn Fn(Rc<str>) -> ()> = v141.borrow().l0.clone();
        v168(v137.clone());
        US4::US4_0(v140.clone(), v141.clone(), v142.clone(), v143.clone(), v144.clone(), v145.clone())
    };
    let mut v172: Vec<&str> = v103.logs();
    let mut v174: Rc<dyn Fn((&str)) -> std::string::String> = closure10();
    let mut v175: Vec<std::string::String> = v172.iter().map(|x| v174(x.clone())).collect::<Vec<_>>();
    let mut v177: Rc<dyn Fn(std::string::String) -> ()> = closure11();
    let mut v178: bool = true; v175.iter().for_each(|x| { v177(x.clone()); }); //;
    { let _ = spiral_trace_hold(&v24); };
    let (mut v184, mut v185, mut v186, mut v187, mut v188, mut v189): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v190: US3 = v188.borrow().l0.clone();
    let mut v195: i32 = match &v190 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v196: bool = v186.borrow().l0.clone();
    let mut v197: bool = v196 == false;
    let mut v199: bool = if v197 {
        false
    } else {
        let mut v198: bool = 30i32 >= v195;
        v198
    };
    let mut v200: bool = v199 == false;
    let mut v235: US4 = if v200 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v204, mut v205, mut v206, mut v207, mut v208, mut v209): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v210: i64 = v204.borrow().l0.clone();
        let mut v211: i64 = v210 + 1i64;
        v204.borrow_mut().l0 = v211;
        let mut v212: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v213: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v214: bool = cfg!(target_arch = "wasm32");
        if v214 {
            let mut v215: Rc<str> = v207.borrow().l0.clone();
            let mut v216: bool = v215.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v224: Rc<str> = if v216 {
                v212.clone()
            } else {
                let mut v217: bool = v212.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v217 {
                    let mut v218: Rc<str> = v207.borrow().l0.clone();
                    v218.clone()
                } else {
                    let mut v219: Rc<str> = v207.borrow().l0.clone();
                    let mut v220: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v221: Rc<str> = Rc::<str>::from(format!("{}{}", v219, v220));
                    let mut v222: Rc<str> = Rc::<str>::from(format!("{}{}", v221, v212));
                    v222.clone()
                }
            };
            let mut v226: i32 = ((v224.chars().count() + 14999) / 15000) as i32;
            let mut v227: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v228: bool = v212 != v227 ;
            let mut v230: bool = if v228 {
                let mut v229: bool = v226 <= 1i32;
                v229
            } else {
                false
            };
            if v230 {
                v207.borrow_mut().l0 = v224.clone();
                ()
            } else {
                v207.borrow_mut().l0 = v227.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v224); };
                ()
            }
        } else {
            println!("{}", v212);
            ()
        };
        let mut v233: Rc<dyn Fn(Rc<str>) -> ()> = v205.borrow().l0.clone();
        v233(v212.clone());
        US4::US4_0(v204.clone(), v205.clone(), v206.clone(), v207.clone(), v208.clone(), v209.clone())
    };
    let mut v237: near_workspaces::types::Gas = v103.total_gas_burnt;
    let mut v239: u64 = v237.as_gas();
    let mut v242: f64 = (v239 as f64);
    let mut v243: f64 = v242 / 10000000000000000.0f64;
    let mut v244: f64 = v243 * 6.68f64;
    { let _ = spiral_trace_hold(&v24); };
    let (mut v250, mut v251, mut v252, mut v253, mut v254, mut v255): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v256: US3 = v254.borrow().l0.clone();
    let mut v261: i32 = match &v256 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v262: bool = v252.borrow().l0.clone();
    let mut v263: bool = v262 == false;
    let mut v265: bool = if v263 {
        false
    } else {
        let mut v264: bool = 30i32 >= v261;
        v264
    };
    let mut v266: bool = v265 == false;
    let mut v311: US4 = if v266 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v270, mut v271, mut v272, mut v273, mut v274, mut v275): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v276: Rc<str> = method6(v270.clone(), v271.clone(), v272.clone(), v273.clone(), v274.clone(), v275.clone());
        let mut v277: Rc<str> = method40();
        let mut v278: Rc<str> = method41(v270.clone(), v271.clone(), v272.clone(), v273.clone(), v274.clone(), v275.clone(), v276.clone(), v277.clone(), v1, v244, v239);
        { let _ = spiral_trace_hold(&v24); };
        let (mut v281, mut v282, mut v283, mut v284, mut v285, mut v286): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v287: i64 = v281.borrow().l0.clone();
        let mut v288: i64 = v287 + 1i64;
        v281.borrow_mut().l0 = v288;
        let mut v289: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v290: bool = cfg!(target_arch = "wasm32");
        if v290 {
            let mut v291: Rc<str> = v284.borrow().l0.clone();
            let mut v292: bool = v291.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v300: Rc<str> = if v292 {
                v278.clone()
            } else {
                let mut v293: bool = v278.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v293 {
                    let mut v294: Rc<str> = v284.borrow().l0.clone();
                    v294.clone()
                } else {
                    let mut v295: Rc<str> = v284.borrow().l0.clone();
                    let mut v296: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v297: Rc<str> = Rc::<str>::from(format!("{}{}", v295, v296));
                    let mut v298: Rc<str> = Rc::<str>::from(format!("{}{}", v297, v278));
                    v298.clone()
                }
            };
            let mut v302: i32 = ((v300.chars().count() + 14999) / 15000) as i32;
            let mut v303: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v304: bool = v278 != v303 ;
            let mut v306: bool = if v304 {
                let mut v305: bool = v302 <= 1i32;
                v305
            } else {
                false
            };
            if v306 {
                v284.borrow_mut().l0 = v300.clone();
                ()
            } else {
                v284.borrow_mut().l0 = v303.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v300); };
                ()
            }
        } else {
            println!("{}", v278);
            ()
        };
        let mut v309: Rc<dyn Fn(Rc<str>) -> ()> = v282.borrow().l0.clone();
        v309(v278.clone());
        US4::US4_0(v281.clone(), v282.clone(), v283.clone(), v284.clone(), v285.clone(), v286.clone())
    };
    let mut v313: near_workspaces::result::ExecutionFinalResult = v103.clone();
    let mut v315: Vec<&near_workspaces::result::ExecutionOutcome> = v313.outcomes();
    let mut v317: _ = v315.into_iter();
    let mut v319: _ = v317.cloned();
    let mut v321: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure12();
    let mut v322: bool = true; v319.for_each(|x| v321(x));
    let mut v324: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v103.clone().into_result();
    { let _ = spiral_trace_hold(&v24); };
    let (mut v330, mut v331, mut v332, mut v333, mut v334, mut v335): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v336: US3 = v334.borrow().l0.clone();
    let mut v341: i32 = match &v336 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v342: bool = v332.borrow().l0.clone();
    let mut v343: bool = v342 == false;
    let mut v345: bool = if v343 {
        false
    } else {
        let mut v344: bool = 10i32 >= v341;
        v344
    };
    let mut v346: bool = v345 == false;
    let mut v391: US4 = if v346 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v350, mut v351, mut v352, mut v353, mut v354, mut v355): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v356: Rc<str> = method6(v350.clone(), v351.clone(), v352.clone(), v353.clone(), v354.clone(), v355.clone());
        let mut v357: Rc<str> = method7();
        let mut v358: Rc<str> = method52(v350.clone(), v351.clone(), v352.clone(), v353.clone(), v354.clone(), v355.clone(), v356.clone(), v357.clone(), v324.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v361, mut v362, mut v363, mut v364, mut v365, mut v366): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v367: i64 = v361.borrow().l0.clone();
        let mut v368: i64 = v367 + 1i64;
        v361.borrow_mut().l0 = v368;
        let mut v369: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v370: bool = cfg!(target_arch = "wasm32");
        if v370 {
            let mut v371: Rc<str> = v364.borrow().l0.clone();
            let mut v372: bool = v371.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v380: Rc<str> = if v372 {
                v358.clone()
            } else {
                let mut v373: bool = v358.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v373 {
                    let mut v374: Rc<str> = v364.borrow().l0.clone();
                    v374.clone()
                } else {
                    let mut v375: Rc<str> = v364.borrow().l0.clone();
                    let mut v376: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v377: Rc<str> = Rc::<str>::from(format!("{}{}", v375, v376));
                    let mut v378: Rc<str> = Rc::<str>::from(format!("{}{}", v377, v358));
                    v378.clone()
                }
            };
            let mut v382: i32 = ((v380.chars().count() + 14999) / 15000) as i32;
            let mut v383: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v384: bool = v358 != v383 ;
            let mut v386: bool = if v384 {
                let mut v385: bool = v382 <= 1i32;
                v385
            } else {
                false
            };
            if v386 {
                v364.borrow_mut().l0 = v380.clone();
                ()
            } else {
                v364.borrow_mut().l0 = v383.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v380); };
                ()
            }
        } else {
            println!("{}", v358);
            ()
        };
        let mut v389: Rc<dyn Fn(Rc<str>) -> ()> = v362.borrow().l0.clone();
        v389(v358.clone());
        US4::US4_0(v361.clone(), v362.clone(), v363.clone(), v364.clone(), v365.clone(), v366.clone())
    };
    let mut v392: near_workspaces::result::ExecutionFinalResult = method55(v103.clone());
    let mut v394: Vec<&near_workspaces::result::ExecutionOutcome> = v392.receipt_failures();
    let mut v397: usize = ((v394).len() as usize);
    let mut v409: i32 = (v397 as i32);
    { let _ = spiral_trace_hold(&v24); };
    let (mut v415, mut v416, mut v417, mut v418, mut v419, mut v420): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v421: US3 = v419.borrow().l0.clone();
    let mut v426: i32 = match &v421 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v427: bool = v417.borrow().l0.clone();
    let mut v428: bool = v427 == false;
    let mut v430: bool = if v428 {
        false
    } else {
        let mut v429: bool = 10i32 >= v426;
        v429
    };
    let mut v431: bool = v430 == false;
    let mut v476: US4 = if v431 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v435, mut v436, mut v437, mut v438, mut v439, mut v440): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v441: Rc<str> = method6(v435.clone(), v436.clone(), v437.clone(), v438.clone(), v439.clone(), v440.clone());
        let mut v442: Rc<str> = method7();
        let mut v443: Rc<str> = method56(v435.clone(), v436.clone(), v437.clone(), v438.clone(), v439.clone(), v440.clone(), v441.clone(), v442.clone(), v409, v394.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v446, mut v447, mut v448, mut v449, mut v450, mut v451): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v452: i64 = v446.borrow().l0.clone();
        let mut v453: i64 = v452 + 1i64;
        v446.borrow_mut().l0 = v453;
        let mut v454: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v455: bool = cfg!(target_arch = "wasm32");
        if v455 {
            let mut v456: Rc<str> = v449.borrow().l0.clone();
            let mut v457: bool = v456.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v465: Rc<str> = if v457 {
                v443.clone()
            } else {
                let mut v458: bool = v443.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v458 {
                    let mut v459: Rc<str> = v449.borrow().l0.clone();
                    v459.clone()
                } else {
                    let mut v460: Rc<str> = v449.borrow().l0.clone();
                    let mut v461: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v462: Rc<str> = Rc::<str>::from(format!("{}{}", v460, v461));
                    let mut v463: Rc<str> = Rc::<str>::from(format!("{}{}", v462, v443));
                    v463.clone()
                }
            };
            let mut v467: i32 = ((v465.chars().count() + 14999) / 15000) as i32;
            let mut v468: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v469: bool = v443 != v468 ;
            let mut v471: bool = if v469 {
                let mut v470: bool = v467 <= 1i32;
                v470
            } else {
                false
            };
            if v471 {
                v449.borrow_mut().l0 = v465.clone();
                ()
            } else {
                v449.borrow_mut().l0 = v468.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v465); };
                ()
            }
        } else {
            println!("{}", v443);
            ()
        };
        let mut v474: Rc<dyn Fn(Rc<str>) -> ()> = v447.borrow().l0.clone();
        v474(v443.clone());
        US4::US4_0(v446.clone(), v447.clone(), v448.clone(), v449.clone(), v450.clone(), v451.clone())
    };
    let mut v477: near_workspaces::result::ExecutionFinalResult = method60(v103.clone());
    let mut v479: &[near_workspaces::result::ExecutionOutcome] = v477.receipt_outcomes();
    let mut v481: Vec<near_workspaces::result::ExecutionOutcome> = v479.into();
    let mut v484: usize = ((v481).len() as usize);
    let mut v485: i32 = (v484 as i32);
    { let _ = spiral_trace_hold(&v24); };
    let (mut v491, mut v492, mut v493, mut v494, mut v495, mut v496): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v497: US3 = v495.borrow().l0.clone();
    let mut v502: i32 = match &v497 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v503: bool = v493.borrow().l0.clone();
    let mut v504: bool = v503 == false;
    let mut v506: bool = if v504 {
        false
    } else {
        let mut v505: bool = 10i32 >= v502;
        v505
    };
    let mut v507: bool = v506 == false;
    let mut v552: US4 = if v507 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v511, mut v512, mut v513, mut v514, mut v515, mut v516): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v517: Rc<str> = method6(v511.clone(), v512.clone(), v513.clone(), v514.clone(), v515.clone(), v516.clone());
        let mut v518: Rc<str> = method7();
        let mut v519: Rc<str> = method61(v511.clone(), v512.clone(), v513.clone(), v514.clone(), v515.clone(), v516.clone(), v517.clone(), v518.clone(), v485, v481.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v522, mut v523, mut v524, mut v525, mut v526, mut v527): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v528: i64 = v522.borrow().l0.clone();
        let mut v529: i64 = v528 + 1i64;
        v522.borrow_mut().l0 = v529;
        let mut v530: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v531: bool = cfg!(target_arch = "wasm32");
        if v531 {
            let mut v532: Rc<str> = v525.borrow().l0.clone();
            let mut v533: bool = v532.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v541: Rc<str> = if v533 {
                v519.clone()
            } else {
                let mut v534: bool = v519.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v534 {
                    let mut v535: Rc<str> = v525.borrow().l0.clone();
                    v535.clone()
                } else {
                    let mut v536: Rc<str> = v525.borrow().l0.clone();
                    let mut v537: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v538: Rc<str> = Rc::<str>::from(format!("{}{}", v536, v537));
                    let mut v539: Rc<str> = Rc::<str>::from(format!("{}{}", v538, v519));
                    v539.clone()
                }
            };
            let mut v543: i32 = ((v541.chars().count() + 14999) / 15000) as i32;
            let mut v544: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v545: bool = v519 != v544 ;
            let mut v547: bool = if v545 {
                let mut v546: bool = v543 <= 1i32;
                v546
            } else {
                false
            };
            if v547 {
                v525.borrow_mut().l0 = v541.clone();
                ()
            } else {
                v525.borrow_mut().l0 = v544.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v541); };
                ()
            }
        } else {
            println!("{}", v519);
            ()
        };
        let mut v550: Rc<dyn Fn(Rc<str>) -> ()> = v523.borrow().l0.clone();
        v550(v519.clone());
        US4::US4_0(v522.clone(), v523.clone(), v524.clone(), v525.clone(), v526.clone(), v527.clone())
    };
    let mut v554: near_workspaces::result::ExecutionFinalResult = v103.clone();
    let mut v556: Result<std::string::String, near_workspaces::error::Error> = v554.json();
    { let _ = spiral_trace_hold(&v24); };
    let (mut v562, mut v563, mut v564, mut v565, mut v566, mut v567): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v568: US3 = v566.borrow().l0.clone();
    let mut v573: i32 = match &v568 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v574: bool = v564.borrow().l0.clone();
    let mut v575: bool = v574 == false;
    let mut v577: bool = if v575 {
        false
    } else {
        let mut v576: bool = 10i32 >= v573;
        v576
    };
    let mut v578: bool = v577 == false;
    let mut v623: US4 = if v578 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v582, mut v583, mut v584, mut v585, mut v586, mut v587): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v588: Rc<str> = method6(v582.clone(), v583.clone(), v584.clone(), v585.clone(), v586.clone(), v587.clone());
        let mut v589: Rc<str> = method7();
        let mut v590: Rc<str> = method65(v582.clone(), v583.clone(), v584.clone(), v585.clone(), v586.clone(), v587.clone(), v588.clone(), v589.clone(), v556);
        { let _ = spiral_trace_hold(&v24); };
        let (mut v593, mut v594, mut v595, mut v596, mut v597, mut v598): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v599: i64 = v593.borrow().l0.clone();
        let mut v600: i64 = v599 + 1i64;
        v593.borrow_mut().l0 = v600;
        let mut v601: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v602: bool = cfg!(target_arch = "wasm32");
        if v602 {
            let mut v603: Rc<str> = v596.borrow().l0.clone();
            let mut v604: bool = v603.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v612: Rc<str> = if v604 {
                v590.clone()
            } else {
                let mut v605: bool = v590.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v605 {
                    let mut v606: Rc<str> = v596.borrow().l0.clone();
                    v606.clone()
                } else {
                    let mut v607: Rc<str> = v596.borrow().l0.clone();
                    let mut v608: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v609: Rc<str> = Rc::<str>::from(format!("{}{}", v607, v608));
                    let mut v610: Rc<str> = Rc::<str>::from(format!("{}{}", v609, v590));
                    v610.clone()
                }
            };
            let mut v614: i32 = ((v612.chars().count() + 14999) / 15000) as i32;
            let mut v615: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v616: bool = v590 != v615 ;
            let mut v618: bool = if v616 {
                let mut v617: bool = v614 <= 1i32;
                v617
            } else {
                false
            };
            if v618 {
                v596.borrow_mut().l0 = v612.clone();
                ()
            } else {
                v596.borrow_mut().l0 = v615.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v612); };
                ()
            }
        } else {
            println!("{}", v590);
            ()
        };
        let mut v621: Rc<dyn Fn(Rc<str>) -> ()> = v594.borrow().l0.clone();
        v621(v590.clone());
        US4::US4_0(v593.clone(), v594.clone(), v595.clone(), v596.clone(), v597.clone(), v598.clone())
    };
    let mut v625: near_workspaces::result::ExecutionFinalResult = v103.clone();
    let mut v627: Result<std::string::String, near_workspaces::error::Error> = v625.borsh();
    { let _ = spiral_trace_hold(&v24); };
    let (mut v633, mut v634, mut v635, mut v636, mut v637, mut v638): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v639: US3 = v637.borrow().l0.clone();
    let mut v644: i32 = match &v639 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v645: bool = v635.borrow().l0.clone();
    let mut v646: bool = v645 == false;
    let mut v648: bool = if v646 {
        false
    } else {
        let mut v647: bool = 10i32 >= v644;
        v647
    };
    let mut v649: bool = v648 == false;
    let mut v694: US4 = if v649 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v653, mut v654, mut v655, mut v656, mut v657, mut v658): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v659: Rc<str> = method6(v653.clone(), v654.clone(), v655.clone(), v656.clone(), v657.clone(), v658.clone());
        let mut v660: Rc<str> = method7();
        let mut v661: Rc<str> = method68(v653.clone(), v654.clone(), v655.clone(), v656.clone(), v657.clone(), v658.clone(), v659.clone(), v660.clone(), v627);
        { let _ = spiral_trace_hold(&v24); };
        let (mut v664, mut v665, mut v666, mut v667, mut v668, mut v669): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v670: i64 = v664.borrow().l0.clone();
        let mut v671: i64 = v670 + 1i64;
        v664.borrow_mut().l0 = v671;
        let mut v672: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v673: bool = cfg!(target_arch = "wasm32");
        if v673 {
            let mut v674: Rc<str> = v667.borrow().l0.clone();
            let mut v675: bool = v674.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v683: Rc<str> = if v675 {
                v661.clone()
            } else {
                let mut v676: bool = v661.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v676 {
                    let mut v677: Rc<str> = v667.borrow().l0.clone();
                    v677.clone()
                } else {
                    let mut v678: Rc<str> = v667.borrow().l0.clone();
                    let mut v679: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v680: Rc<str> = Rc::<str>::from(format!("{}{}", v678, v679));
                    let mut v681: Rc<str> = Rc::<str>::from(format!("{}{}", v680, v661));
                    v681.clone()
                }
            };
            let mut v685: i32 = ((v683.chars().count() + 14999) / 15000) as i32;
            let mut v686: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v687: bool = v661 != v686 ;
            let mut v689: bool = if v687 {
                let mut v688: bool = v685 <= 1i32;
                v688
            } else {
                false
            };
            if v689 {
                v667.borrow_mut().l0 = v683.clone();
                ()
            } else {
                v667.borrow_mut().l0 = v686.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v683); };
                ()
            }
        } else {
            println!("{}", v661);
            ()
        };
        let mut v692: Rc<dyn Fn(Rc<str>) -> ()> = v665.borrow().l0.clone();
        v692(v661.clone());
        US4::US4_0(v664.clone(), v665.clone(), v666.clone(), v667.clone(), v668.clone(), v669.clone())
    };
    let mut v695: Rc<str> = method71(v485, v1, v394.clone());
    let mut v696: bool = v409 > 0i32;
    let mut v723: Result<US5, anyhow::Error> = if v696 {
        let mut v699: US5 = US5::US5_0(v695.clone());
        let mut v700: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v699);
        v700
    } else {
        let mut v701: bool = v485 > 1i32;
        if v701 {
            let mut v704: US5 = US5::US5_1;
            let mut v705: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v704);
            v705
        } else {
            let mut v709: anyhow::Error = anyhow::anyhow!("{}", v695);
            let mut v721: Result<US5, anyhow::Error> = Err(v709);
            v721
        }
    };
    let mut v739: bool = true; (v723) }); //;
    let mut v741: _ = __future_init;
    let mut v743: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = v741;
    v743
}
fn closure13() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let mut v12: std::string::String = format!("{}", v0);
        v12.clone()
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method72() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure13()
}
fn closure14() -> Rc<dyn Fn(US5) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US5) -> US7> = Rc::new(move |mut v0: US5| -> US7 {
        US7::US7_0(v0.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method73() -> Rc<dyn Fn(US5) -> US7> {
    closure14()
}
fn closure15() -> Rc<dyn Fn(std::string::String) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US7> = Rc::new(move |mut v0: std::string::String| -> US7 {
        US7::US7_1(v0.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method74() -> Rc<dyn Fn(std::string::String) -> US7> {
    closure15()
}
fn method75() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[93m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = method8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method78(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method77(mut v0: u8, mut v1: std::string::String) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method33(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method78(v3.clone());
    method18(v3.clone());
    let mut v6: std::string::String = format!("{:#?}", v1);
    let mut v8: Rc<str> = Rc::<str>::from(v6);
    method9(v3.clone(), v8.clone());
    method19(v3.clone());
    let mut v9: Rc<str> = v3.borrow().l0.clone();
    v9.clone()
}
fn method76(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: std::string::String) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Error error"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = method77(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn method79() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[91m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = method8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method81(mut v0: u8, mut v1: Rc<str>) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method33(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method78(v3.clone());
    method18(v3.clone());
    method9(v3.clone(), v1.clone());
    method19(v3.clone());
    let mut v5: Rc<str> = v3.borrow().l0.clone();
    v5.clone()
}
fn method80(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: Rc<str>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Ok (Some error)"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = method81(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn method29(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let mut v7: bool = */ ();
    let mut v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = method30(v0.clone(), v1);
    let mut v10: Result<US5, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v23: Result<US5, std::string::String> = v10.map_err(|x| v11(x));
    let mut v24: Rc<dyn Fn(US5) -> US7> = method73();
    let mut v25: Rc<dyn Fn(std::string::String) -> US7> = method74();
    let mut v27: US7 = match v23 { Ok(x) => v24(x), Err(e) => v25(e) };
    let mut v439: US6 = match &v27 {
        US7::US7_1(v165) => { // Error
            let mut v165: std::string::String = v165.clone();
            let mut v166: bool = v1 >= 15u8;
            if v166 {
                let mut v171: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                { let _ = spiral_trace_hold(&v171); };
                let mut v173: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                let (mut v174, mut v175, mut v176, mut v177, mut v178, mut v179): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v173) };
                let mut v180: US3 = v178.borrow().l0.clone();
                let mut v185: i32 = match &v180 {
                    US3::US3_4 => { // Critical
                        50i32
                    }
                    US3::US3_1 => { // Debug
                        20i32
                    }
                    US3::US3_2 => { // Info
                        30i32
                    }
                    US3::US3_0 => { // Verbose
                        10i32
                    }
                    US3::US3_3 => { // Warning
                        40i32
                    }
                    _ => unreachable!(),
                };
                let mut v186: bool = v176.borrow().l0.clone();
                let mut v187: bool = v186 == false;
                let mut v189: bool = if v187 {
                    false
                } else {
                    let mut v188: bool = 40i32 >= v185;
                    v188
                };
                let mut v190: bool = v189 == false;
                let mut v235: US4 = if v190 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v171); };
                    let (mut v194, mut v195, mut v196, mut v197, mut v198, mut v199): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v173) };
                    let mut v200: Rc<str> = method6(v194.clone(), v195.clone(), v196.clone(), v197.clone(), v198.clone(), v199.clone());
                    let mut v201: Rc<str> = method75();
                    let mut v202: Rc<str> = method76(v194.clone(), v195.clone(), v196.clone(), v197.clone(), v198.clone(), v199.clone(), v200.clone(), v201.clone(), v1, v165.clone());
                    { let _ = spiral_trace_hold(&v171); };
                    let (mut v205, mut v206, mut v207, mut v208, mut v209, mut v210): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v173) };
                    let mut v211: i64 = v205.borrow().l0.clone();
                    let mut v212: i64 = v211 + 1i64;
                    v205.borrow_mut().l0 = v212;
                    let mut v213: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v214: bool = cfg!(target_arch = "wasm32");
                    if v214 {
                        let mut v215: Rc<str> = v208.borrow().l0.clone();
                        let mut v216: bool = v215.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v224: Rc<str> = if v216 {
                            v202.clone()
                        } else {
                            let mut v217: bool = v202.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v217 {
                                let mut v218: Rc<str> = v208.borrow().l0.clone();
                                v218.clone()
                            } else {
                                let mut v219: Rc<str> = v208.borrow().l0.clone();
                                let mut v220: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v221: Rc<str> = Rc::<str>::from(format!("{}{}", v219, v220));
                                let mut v222: Rc<str> = Rc::<str>::from(format!("{}{}", v221, v202));
                                v222.clone()
                            }
                        };
                        let mut v226: i32 = ((v224.chars().count() + 14999) / 15000) as i32;
                        let mut v227: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v228: bool = v202 != v227 ;
                        let mut v230: bool = if v228 {
                            let mut v229: bool = v226 <= 1i32;
                            v229
                        } else {
                            false
                        };
                        if v230 {
                            v208.borrow_mut().l0 = v224.clone();
                            ()
                        } else {
                            v208.borrow_mut().l0 = v227.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v224); };
                            ()
                        }
                    } else {
                        println!("{}", v202);
                        ()
                    };
                    let mut v233: Rc<dyn Fn(Rc<str>) -> ()> = v206.borrow().l0.clone();
                    v233(v202.clone());
                    US4::US4_0(v205.clone(), v206.clone(), v207.clone(), v208.clone(), v209.clone(), v210.clone())
                };
                { let _ = spiral_trace_hold(&v171); };
                let (mut v241, mut v242, mut v243, mut v244, mut v245, mut v246): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v173) };
                let mut v247: US3 = v245.borrow().l0.clone();
                let mut v252: i32 = match &v247 {
                    US3::US3_4 => { // Critical
                        50i32
                    }
                    US3::US3_1 => { // Debug
                        20i32
                    }
                    US3::US3_2 => { // Info
                        30i32
                    }
                    US3::US3_0 => { // Verbose
                        10i32
                    }
                    US3::US3_3 => { // Warning
                        40i32
                    }
                    _ => unreachable!(),
                };
                let mut v253: bool = v243.borrow().l0.clone();
                let mut v254: bool = v253 == false;
                let mut v256: bool = if v254 {
                    false
                } else {
                    let mut v255: bool = 40i32 >= v252;
                    v255
                };
                let mut v257: bool = v256 == false;
                let mut v291: US4 = if v257 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v171); };
                    let (mut v261, mut v262, mut v263, mut v264, mut v265, mut v266): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v173) };
                    let mut v267: i64 = v261.borrow().l0.clone();
                    let mut v268: i64 = v267 + 1i64;
                    v261.borrow_mut().l0 = v268;
                    let mut v269: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v270: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v271: bool = cfg!(target_arch = "wasm32");
                    if v271 {
                        let mut v272: Rc<str> = v264.borrow().l0.clone();
                        let mut v273: bool = v272.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v280: Rc<str> = if v273 {
                            v269.clone()
                        } else {
                            let mut v274: bool = v269.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v274 {
                                let mut v275: Rc<str> = v264.borrow().l0.clone();
                                v275.clone()
                            } else {
                                let mut v276: Rc<str> = v264.borrow().l0.clone();
                                let mut v277: Rc<str> = Rc::<str>::from(format!("{}{}", v276, v269));
                                let mut v278: Rc<str> = Rc::<str>::from(format!("{}{}", v277, v269));
                                v278.clone()
                            }
                        };
                        let mut v282: i32 = ((v280.chars().count() + 14999) / 15000) as i32;
                        let mut v283: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v284: bool = v269 != v283 ;
                        let mut v286: bool = if v284 {
                            let mut v285: bool = v282 <= 1i32;
                            v285
                        } else {
                            false
                        };
                        if v286 {
                            v264.borrow_mut().l0 = v280.clone();
                            ()
                        } else {
                            v264.borrow_mut().l0 = v283.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v280); };
                            ()
                        }
                    } else {
                        println!("{}", v269);
                        ()
                    };
                    let mut v289: Rc<dyn Fn(Rc<str>) -> ()> = v262.borrow().l0.clone();
                    v289(v269.clone());
                    US4::US4_0(v261.clone(), v262.clone(), v263.clone(), v264.clone(), v265.clone(), v266.clone())
                };
                let mut v293: bool = true; let __future_init = Box::pin(/*;
                let mut v295: bool = */ async move { /*;
                let mut v297: bool = */ ();
                let mut v298: US5 = US5::US5_1;
                let mut v299: bool = true; ((v1, v298.clone())) }); //;
                let mut v301: _ = __future_init;
                let mut v303: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v301;
                let (mut v305, mut v306): (u8, US5) = v303.await;
                US6::US6_0(v305, v306.clone())
            } else {
                let mut v312: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                { let _ = spiral_trace_hold(&v312); };
                let mut v314: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                let (mut v315, mut v316, mut v317, mut v318, mut v319, mut v320): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v314) };
                let mut v321: US3 = v319.borrow().l0.clone();
                let mut v326: i32 = match &v321 {
                    US3::US3_4 => { // Critical
                        50i32
                    }
                    US3::US3_1 => { // Debug
                        20i32
                    }
                    US3::US3_2 => { // Info
                        30i32
                    }
                    US3::US3_0 => { // Verbose
                        10i32
                    }
                    US3::US3_3 => { // Warning
                        40i32
                    }
                    _ => unreachable!(),
                };
                let mut v327: bool = v317.borrow().l0.clone();
                let mut v328: bool = v327 == false;
                let mut v330: bool = if v328 {
                    false
                } else {
                    let mut v329: bool = 40i32 >= v326;
                    v329
                };
                let mut v331: bool = v330 == false;
                let mut v376: US4 = if v331 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v312); };
                    let (mut v335, mut v336, mut v337, mut v338, mut v339, mut v340): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v314) };
                    let mut v341: Rc<str> = method6(v335.clone(), v336.clone(), v337.clone(), v338.clone(), v339.clone(), v340.clone());
                    let mut v342: Rc<str> = method75();
                    let mut v343: Rc<str> = method76(v335.clone(), v336.clone(), v337.clone(), v338.clone(), v339.clone(), v340.clone(), v341.clone(), v342.clone(), v1, v165.clone());
                    { let _ = spiral_trace_hold(&v312); };
                    let (mut v346, mut v347, mut v348, mut v349, mut v350, mut v351): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v314) };
                    let mut v352: i64 = v346.borrow().l0.clone();
                    let mut v353: i64 = v352 + 1i64;
                    v346.borrow_mut().l0 = v353;
                    let mut v354: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v355: bool = cfg!(target_arch = "wasm32");
                    if v355 {
                        let mut v356: Rc<str> = v349.borrow().l0.clone();
                        let mut v357: bool = v356.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v365: Rc<str> = if v357 {
                            v343.clone()
                        } else {
                            let mut v358: bool = v343.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v358 {
                                let mut v359: Rc<str> = v349.borrow().l0.clone();
                                v359.clone()
                            } else {
                                let mut v360: Rc<str> = v349.borrow().l0.clone();
                                let mut v361: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v362: Rc<str> = Rc::<str>::from(format!("{}{}", v360, v361));
                                let mut v363: Rc<str> = Rc::<str>::from(format!("{}{}", v362, v343));
                                v363.clone()
                            }
                        };
                        let mut v367: i32 = ((v365.chars().count() + 14999) / 15000) as i32;
                        let mut v368: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v369: bool = v343 != v368 ;
                        let mut v371: bool = if v369 {
                            let mut v370: bool = v367 <= 1i32;
                            v370
                        } else {
                            false
                        };
                        if v371 {
                            v349.borrow_mut().l0 = v365.clone();
                            ()
                        } else {
                            v349.borrow_mut().l0 = v368.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v365); };
                            ()
                        }
                    } else {
                        println!("{}", v343);
                        ()
                    };
                    let mut v374: Rc<dyn Fn(Rc<str>) -> ()> = v347.borrow().l0.clone();
                    v374(v343.clone());
                    US4::US4_0(v346.clone(), v347.clone(), v348.clone(), v349.clone(), v350.clone(), v351.clone())
                };
                { let _ = spiral_trace_hold(&v312); };
                let (mut v382, mut v383, mut v384, mut v385, mut v386, mut v387): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v314) };
                let mut v388: US3 = v386.borrow().l0.clone();
                let mut v393: i32 = match &v388 {
                    US3::US3_4 => { // Critical
                        50i32
                    }
                    US3::US3_1 => { // Debug
                        20i32
                    }
                    US3::US3_2 => { // Info
                        30i32
                    }
                    US3::US3_0 => { // Verbose
                        10i32
                    }
                    US3::US3_3 => { // Warning
                        40i32
                    }
                    _ => unreachable!(),
                };
                let mut v394: bool = v384.borrow().l0.clone();
                let mut v395: bool = v394 == false;
                let mut v397: bool = if v395 {
                    false
                } else {
                    let mut v396: bool = 40i32 >= v393;
                    v396
                };
                let mut v398: bool = v397 == false;
                let mut v432: US4 = if v398 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v312); };
                    let (mut v402, mut v403, mut v404, mut v405, mut v406, mut v407): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v314) };
                    let mut v408: i64 = v402.borrow().l0.clone();
                    let mut v409: i64 = v408 + 1i64;
                    v402.borrow_mut().l0 = v409;
                    let mut v410: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v411: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v412: bool = cfg!(target_arch = "wasm32");
                    if v412 {
                        let mut v413: Rc<str> = v405.borrow().l0.clone();
                        let mut v414: bool = v413.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v421: Rc<str> = if v414 {
                            v410.clone()
                        } else {
                            let mut v415: bool = v410.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v415 {
                                let mut v416: Rc<str> = v405.borrow().l0.clone();
                                v416.clone()
                            } else {
                                let mut v417: Rc<str> = v405.borrow().l0.clone();
                                let mut v418: Rc<str> = Rc::<str>::from(format!("{}{}", v417, v410));
                                let mut v419: Rc<str> = Rc::<str>::from(format!("{}{}", v418, v410));
                                v419.clone()
                            }
                        };
                        let mut v423: i32 = ((v421.chars().count() + 14999) / 15000) as i32;
                        let mut v424: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v425: bool = v410 != v424 ;
                        let mut v427: bool = if v425 {
                            let mut v426: bool = v423 <= 1i32;
                            v426
                        } else {
                            false
                        };
                        if v427 {
                            v405.borrow_mut().l0 = v421.clone();
                            ()
                        } else {
                            v405.borrow_mut().l0 = v424.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v421); };
                            ()
                        }
                    } else {
                        println!("{}", v410);
                        ()
                    };
                    let mut v430: Rc<dyn Fn(Rc<str>) -> ()> = v403.borrow().l0.clone();
                    v430(v410.clone());
                    US4::US4_0(v402.clone(), v403.clone(), v404.clone(), v405.clone(), v406.clone(), v407.clone())
                };
                let mut v433: u8 = v1 + 1u8;
                let mut v434: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method29(v0.clone(), v433);
                let mut v436: US6 = v434.await;
                v436.clone()
            }
        }
        US7::US7_0(v28) => { // Ok
            let mut v28: US5 = v28.clone();
            match &v28 {
                US5::US5_1 => { // None
                    let mut v30: bool = true; let __future_init = Box::pin(/*;
                    let mut v32: bool = */ async move { /*;
                    let mut v34: bool = */ ();
                    let mut v51: US5 = US5::US5_1;
                    let mut v52: bool = true; ((v1, v51.clone())) }); //;
                    let mut v54: _ = __future_init;
                    let mut v56: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v54;
                    let (mut v58, mut v59): (u8, US5) = v56.await;
                    US6::US6_0(v58, v59.clone())
                }
                US5::US5_0(v61) => { // Some
                    let mut v61: Rc<str> = v61.clone();
                    let mut v66: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                    { let _ = spiral_trace_hold(&v66); };
                    let mut v68: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                    let (mut v69, mut v70, mut v71, mut v72, mut v73, mut v74): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v68) };
                    let mut v75: US3 = v73.borrow().l0.clone();
                    let mut v80: i32 = match &v75 {
                        US3::US3_4 => { // Critical
                            50i32
                        }
                        US3::US3_1 => { // Debug
                            20i32
                        }
                        US3::US3_2 => { // Info
                            30i32
                        }
                        US3::US3_0 => { // Verbose
                            10i32
                        }
                        US3::US3_3 => { // Warning
                            40i32
                        }
                        _ => unreachable!(),
                    };
                    let mut v81: bool = v71.borrow().l0.clone();
                    let mut v82: bool = v81 == false;
                    let mut v84: bool = if v82 {
                        false
                    } else {
                        let mut v83: bool = 50i32 >= v80;
                        v83
                    };
                    let mut v85: bool = v84 == false;
                    let mut v130: US4 = if v85 {
                        US4::US4_1
                    } else {
                        { let _ = spiral_trace_hold(&v66); };
                        let (mut v89, mut v90, mut v91, mut v92, mut v93, mut v94): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v68) };
                        let mut v95: Rc<str> = method6(v89.clone(), v90.clone(), v91.clone(), v92.clone(), v93.clone(), v94.clone());
                        let mut v96: Rc<str> = method79();
                        let mut v97: Rc<str> = method80(v89.clone(), v90.clone(), v91.clone(), v92.clone(), v93.clone(), v94.clone(), v95.clone(), v96.clone(), v1, v61.clone());
                        { let _ = spiral_trace_hold(&v66); };
                        let (mut v100, mut v101, mut v102, mut v103, mut v104, mut v105): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v68) };
                        let mut v106: i64 = v100.borrow().l0.clone();
                        let mut v107: i64 = v106 + 1i64;
                        v100.borrow_mut().l0 = v107;
                        let mut v108: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                        let mut v109: bool = cfg!(target_arch = "wasm32");
                        if v109 {
                            let mut v110: Rc<str> = v103.borrow().l0.clone();
                            let mut v111: bool = v110.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v119: Rc<str> = if v111 {
                                v97.clone()
                            } else {
                                let mut v112: bool = v97.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                                if v112 {
                                    let mut v113: Rc<str> = v103.borrow().l0.clone();
                                    v113.clone()
                                } else {
                                    let mut v114: Rc<str> = v103.borrow().l0.clone();
                                    let mut v115: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                    let mut v116: Rc<str> = Rc::<str>::from(format!("{}{}", v114, v115));
                                    let mut v117: Rc<str> = Rc::<str>::from(format!("{}{}", v116, v97));
                                    v117.clone()
                                }
                            };
                            let mut v121: i32 = ((v119.chars().count() + 14999) / 15000) as i32;
                            let mut v122: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v123: bool = v97 != v122 ;
                            let mut v125: bool = if v123 {
                                let mut v124: bool = v121 <= 1i32;
                                v124
                            } else {
                                false
                            };
                            if v125 {
                                v103.borrow_mut().l0 = v119.clone();
                                ()
                            } else {
                                v103.borrow_mut().l0 = v122.clone();
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v119); };
                                ()
                            }
                        } else {
                            println!("{}", v97);
                            ()
                        };
                        let mut v128: Rc<dyn Fn(Rc<str>) -> ()> = v101.borrow().l0.clone();
                        v128(v97.clone());
                        US4::US4_0(v100.clone(), v101.clone(), v102.clone(), v103.clone(), v104.clone(), v105.clone())
                    };
                    let mut v132: bool = true; let __future_init = Box::pin(/*;
                    let mut v134: bool = */ async move { /*;
                    let mut v136: bool = */ ();
                    let mut v153: US5 = US5::US5_0(v61.clone());
                    let mut v154: bool = true; ((v1, v153.clone())) }); //;
                    let mut v156: _ = __future_init;
                    let mut v158: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v156;
                    let (mut v160, mut v161): (u8, US5) = v158.await;
                    US6::US6_1(v160, v161.clone())
                }
                _ => unreachable!(),
            }
        }
        _ => unreachable!(),
    };
    let mut v455: bool = true; (v439) }); //;
    let mut v457: _ = __future_init;
    let mut v459: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = v457;
    v459
}
fn method84(mut v0: Rc<RefCell<Mut4>>) -> () {
    let mut v1: Rc<str> = v0.borrow().l0.clone();
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn method86(mut v0: US5) -> Rc<str> {
    match &v0 {
        US5::US5_1 => { // None
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v8.clone()
        }
        US5::US5_0(v1) => { // Some
            let mut v1: Rc<str> = v1.clone();
            let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v4, v3));
            let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some"); } LIT.with(|lit| lit.clone()) };
            let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v5));
            v7.clone()
        }
        _ => unreachable!(),
    }
}
fn method85(mut v0: US6) -> Rc<str> {
    match &v0 {
        US6::US6_1(v42, v43) => { // Error
            let mut v42: u8 = v42.clone();
            let mut v43: US5 = v43.clone();
            let mut v44: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v45: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v47: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v49: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let mut v50: Rc<str> = Rc::<str>::from(format!("{:?}", v42));
            let mut v51: Rc<str> = Rc::<str>::from(format!("{}{}", v49, v50));
            let mut v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v53: Rc<str> = Rc::<str>::from(format!("{}{}", v51, v52));
            let mut v54: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let mut v55: Rc<str> = Rc::<str>::from(format!("{}{}", v53, v54));
            let mut v56: Rc<str> = Rc::<str>::from(format!("{}{}", v55, v48));
            let mut v57: Rc<str> = method86(v43.clone());
            let mut v58: Rc<str> = Rc::<str>::from(format!("{}{}", v56, v57));
            let mut v59: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v60: Rc<str> = Rc::<str>::from(format!("{}{}", v59, v58));
            let mut v61: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let mut v62: Rc<str> = Rc::<str>::from(format!("{}{}", v60, v61));
            let mut v63: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v64: Rc<str> = Rc::<str>::from(format!("{}{}", v62, v63));
            let mut v65: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v66: Rc<str> = Rc::<str>::from(format!("{}{}", v65, v64));
            let mut v77: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error"); } LIT.with(|lit| lit.clone()) };
            let mut v78: Rc<str> = Rc::<str>::from(format!("{}{}", v77, v66));
            v78.clone()
        }
        US6::US6_0(v1, v2) => { // Ok
            let mut v1: u8 = v1.clone();
            let mut v2: US5 = v2.clone();
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let mut v10: Rc<str> = Rc::<str>::from(format!("{:?}", v1));
            let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v9, v10));
            let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
            let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
            let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v8));
            let mut v17: Rc<str> = method86(v2.clone());
            let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
            let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v18));
            let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
            let mut v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
            let mut v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v24));
            let mut v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ok"); } LIT.with(|lit| lit.clone()) };
            let mut v38: Rc<str> = Rc::<str>::from(format!("{}{}", v37, v26));
            v38.clone()
        }
        _ => unreachable!(),
    }
}
fn method83(mut v0: US6) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method84(v2.clone());
    method18(v2.clone());
    let mut v3: Rc<str> = method85(v0.clone());
    method9(v2.clone(), v3.clone());
    method19(v2.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method82(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: US6) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = method83(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn method87(mut v0: US6, mut v1: US5) -> Rc<str> {
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v2.clone() }));
    method16(v3.clone());
    method84(v3.clone());
    method18(v3.clone());
    let mut v4: Rc<str> = method85(v0.clone());
    method9(v3.clone(), v4.clone());
    method34(v3.clone());
    method78(v3.clone());
    method18(v3.clone());
    let mut v5: Rc<str> = method86(v1.clone());
    method9(v3.clone(), v5.clone());
    method19(v3.clone());
    let mut v6: Rc<str> = v3.borrow().l0.clone();
    v6.clone()
}
fn method24(mut v0: clap::ArgMatches) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> {
    let mut v2: bool = true; let __future_init = Box::pin(/*;
    let mut v4: bool = */ async move { /*;
    let mut v6: bool = */ ();
    let mut v7: Rc<str> = method25();
    let mut v9: &str = &*v7;
    let mut v11: Option<std::string::String> = clap::ArgMatches::get_one(&v0, v9).cloned();
    let mut v12: Option<std::string::String> = method2(v11.clone());
    let mut v13: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v14: Option<US0> = v12.map(|x| v13(x));
    let mut v15: US0 = US0::US0_1;
    let mut v16: US0 = v14.unwrap_or(v15);
    let mut v20: std::string::String = match &v16 {
        US0::US0_1 => { // None
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_0(v17) => { // Some
            let mut v17: std::string::String = v17.clone();
            v17.clone()
        }
        _ => unreachable!(),
    };
    let mut v22: Rc<str> = Rc::<str>::from(String::as_str(&v20));
    let mut v27: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v27); };
    let mut v29: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v30, mut v31, mut v32, mut v33, mut v34, mut v35): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
    let mut v36: US3 = v34.borrow().l0.clone();
    let mut v41: i32 = match &v36 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v42: bool = v32.borrow().l0.clone();
    let mut v43: bool = v42 == false;
    let mut v45: bool = if v43 {
        false
    } else {
        let mut v44: bool = 10i32 >= v41;
        v44
    };
    let mut v46: bool = v45 == false;
    let mut v91: US4 = if v46 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v27); };
        let (mut v50, mut v51, mut v52, mut v53, mut v54, mut v55): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
        let mut v56: Rc<str> = method6(v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone(), v55.clone());
        let mut v57: Rc<str> = method7();
        let mut v58: Rc<str> = method26(v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone(), v55.clone(), v56.clone(), v57.clone(), v22.clone());
        { let _ = spiral_trace_hold(&v27); };
        let (mut v61, mut v62, mut v63, mut v64, mut v65, mut v66): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
        let mut v67: i64 = v61.borrow().l0.clone();
        let mut v68: i64 = v67 + 1i64;
        v61.borrow_mut().l0 = v68;
        let mut v69: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v70: bool = cfg!(target_arch = "wasm32");
        if v70 {
            let mut v71: Rc<str> = v64.borrow().l0.clone();
            let mut v72: bool = v71.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v80: Rc<str> = if v72 {
                v58.clone()
            } else {
                let mut v73: bool = v58.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v73 {
                    let mut v74: Rc<str> = v64.borrow().l0.clone();
                    v74.clone()
                } else {
                    let mut v75: Rc<str> = v64.borrow().l0.clone();
                    let mut v76: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v77: Rc<str> = Rc::<str>::from(format!("{}{}", v75, v76));
                    let mut v78: Rc<str> = Rc::<str>::from(format!("{}{}", v77, v58));
                    v78.clone()
                }
            };
            let mut v82: i32 = ((v80.chars().count() + 14999) / 15000) as i32;
            let mut v83: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v84: bool = v58 != v83 ;
            let mut v86: bool = if v84 {
                let mut v85: bool = v82 <= 1i32;
                v85
            } else {
                false
            };
            if v86 {
                v64.borrow_mut().l0 = v80.clone();
                ()
            } else {
                v64.borrow_mut().l0 = v83.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v80); };
                ()
            }
        } else {
            println!("{}", v58);
            ()
        };
        let mut v89: Rc<dyn Fn(Rc<str>) -> ()> = v62.borrow().l0.clone();
        v89(v58.clone());
        US4::US4_0(v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone(), v66.clone())
    };
    let mut v93: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v22);
    let mut v95: Vec<u8> = v93?;
    let mut v96: u8 = 1u8;
    let mut v97: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method29(v95.clone(), v96);
    let mut v99: US6 = v97.await;
    { let _ = spiral_trace_hold(&v27); };
    let (mut v105, mut v106, mut v107, mut v108, mut v109, mut v110): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
    let mut v111: US3 = v109.borrow().l0.clone();
    let mut v116: i32 = match &v111 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v117: bool = v107.borrow().l0.clone();
    let mut v118: bool = v117 == false;
    let mut v120: bool = if v118 {
        false
    } else {
        let mut v119: bool = 10i32 >= v116;
        v119
    };
    let mut v121: bool = v120 == false;
    let mut v166: US4 = if v121 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v27); };
        let (mut v125, mut v126, mut v127, mut v128, mut v129, mut v130): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
        let mut v131: Rc<str> = method6(v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone(), v130.clone());
        let mut v132: Rc<str> = method7();
        let mut v133: Rc<str> = method82(v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone(), v130.clone(), v131.clone(), v132.clone(), v99.clone());
        { let _ = spiral_trace_hold(&v27); };
        let (mut v136, mut v137, mut v138, mut v139, mut v140, mut v141): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v29) };
        let mut v142: i64 = v136.borrow().l0.clone();
        let mut v143: i64 = v142 + 1i64;
        v136.borrow_mut().l0 = v143;
        let mut v144: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v145: bool = cfg!(target_arch = "wasm32");
        if v145 {
            let mut v146: Rc<str> = v139.borrow().l0.clone();
            let mut v147: bool = v146.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v155: Rc<str> = if v147 {
                v133.clone()
            } else {
                let mut v148: bool = v133.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v148 {
                    let mut v149: Rc<str> = v139.borrow().l0.clone();
                    v149.clone()
                } else {
                    let mut v150: Rc<str> = v139.borrow().l0.clone();
                    let mut v151: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v152: Rc<str> = Rc::<str>::from(format!("{}{}", v150, v151));
                    let mut v153: Rc<str> = Rc::<str>::from(format!("{}{}", v152, v133));
                    v153.clone()
                }
            };
            let mut v157: i32 = ((v155.chars().count() + 14999) / 15000) as i32;
            let mut v158: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v159: bool = v133 != v158 ;
            let mut v161: bool = if v159 {
                let mut v160: bool = v157 <= 1i32;
                v160
            } else {
                false
            };
            if v161 {
                v139.borrow_mut().l0 = v155.clone();
                ()
            } else {
                v139.borrow_mut().l0 = v158.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v155); };
                ()
            }
        } else {
            println!("{}", v133);
            ()
        };
        let mut v164: Rc<dyn Fn(Rc<str>) -> ()> = v137.borrow().l0.clone();
        v164(v133.clone());
        US4::US4_0(v136.clone(), v137.clone(), v138.clone(), v139.clone(), v140.clone(), v141.clone())
    };
    let mut v189: Result<u8, anyhow::Error> = match &v99 {
        US6::US6_1(v171, v172) => { // Error
            let mut v171: u8 = v171.clone();
            let mut v172: US5 = v172.clone();
            let mut v173: Rc<str> = method87(v99.clone(), v172.clone());
            let mut v175: anyhow::Error = anyhow::anyhow!("{}", v173);
            let mut v187: Result<u8, anyhow::Error> = Err(v175);
            v187
        }
        US6::US6_0(v167, v168) => { // Ok
            let mut v167: u8 = v167.clone();
            let mut v168: US5 = v168.clone();
            let mut v170: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v167);
            v170
        }
        _ => unreachable!(),
    };
    let mut v205: bool = true; (v189) }); //;
    let mut v207: _ = __future_init;
    let mut v209: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v207;
    v209
}
fn closure16() -> Rc<dyn Fn(u8) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US8> = Rc::new(move |mut v0: u8| -> US8 {
        US8::US8_0(v0)
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method88() -> Rc<dyn Fn(u8) -> US8> {
    closure16()
}
fn closure17() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_1(v0.clone())
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method89() -> Rc<dyn Fn(std::string::String) -> US8> {
    closure17()
}
fn spiral_main() -> i32 {
    let mut v9: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(std::env::args().skip(1).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
    let mut v10: clap::Command = method0();
    let mut v12: clap::ArgMatches = clap::Command::get_matches(v10);
    let mut v13: Rc<str> = method1();
    let mut v15: &str = &*v13;
    let mut v17: Option<std::string::String> = clap::ArgMatches::get_one(&v12, v15).cloned();
    let mut v20: Option<std::string::String> = method2(v17.clone());
    let mut v21: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v22: Option<US0> = v20.map(|x| v21(x));
    let mut v25: US0 = US0::US0_1;
    let mut v26: US0 = v22.unwrap_or(v25);
    let mut v76: US1 = match &v26 {
        US0::US0_1 => { // None
            US1::US1_1
        }
        US0::US0_0(v27) => { // Some
            let mut v27: std::string::String = v27.clone();
            let mut v29: Rc<str> = Rc::<str>::from(String::as_str(&v27));
            ;
            ;
            ;
            ;
            ;
            let mut v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
            let mut v31: Rc<str> = Rc::<str>::from(v30.to_lowercase());
            let mut v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
            let mut v33: Rc<str> = Rc::<str>::from(v32.to_lowercase());
            let mut v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
            let mut v35: Rc<str> = Rc::<str>::from(v34.to_lowercase());
            let mut v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
            let mut v37: Rc<str> = Rc::<str>::from(v36.to_lowercase());
            let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
            let mut v39: Rc<str> = Rc::<str>::from(v38.to_lowercase());
            let mut v40: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
            let mut v41: US3 = US3::US3_0;
            v40.borrow_mut().push((v38.clone(), v41.clone()));
            let mut v42: US3 = US3::US3_1;
            v40.borrow_mut().push((v36.clone(), v42.clone()));
            let mut v43: US3 = US3::US3_2;
            v40.borrow_mut().push((v34.clone(), v43.clone()));
            let mut v44: US3 = US3::US3_3;
            v40.borrow_mut().push((v32.clone(), v44.clone()));
            let mut v45: US3 = US3::US3_4;
            v40.borrow_mut().push((v30.clone(), v45.clone()));
            let mut v46: US3 = US3::US3_0;
            v40.borrow_mut().push((v39.clone(), v46.clone()));
            let mut v47: US3 = US3::US3_1;
            v40.borrow_mut().push((v37.clone(), v47.clone()));
            let mut v48: US3 = US3::US3_2;
            v40.borrow_mut().push((v35.clone(), v48.clone()));
            let mut v49: US3 = US3::US3_3;
            v40.borrow_mut().push((v33.clone(), v49.clone()));
            let mut v50: US3 = US3::US3_4;
            v40.borrow_mut().push((v31.clone(), v50.clone()));
            let mut v51: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v40.borrow().clone());
            let mut v52: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v51).as_ref().clone()));
            let mut v53: i32 = (v52.clone().borrow().len() as i32);
            let mut v54: US2 = US2::US2_1;
            let mut v55: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v54.clone() }));
            while method3(v53, v55.clone()) {
                let mut v57: i32 = v55.borrow().l0.clone();
                let mut v58: i32 = -(v57);
                let mut v59: i32 = v58 + v53;
                let mut v60: i32 = v59 - 1i32;
                let mut v61: US2 = v55.borrow().l1.clone();
                let (mut v62, mut v63): (Rc<str>, US3) = v52.clone().borrow()[v60 as usize].clone();
                let mut v70: US2 = match &v61 {
                    US2::US2_1 => { // None
                        let mut v65: bool = v62 == v29 ;
                        if v65 {
                            US2::US2_0(v63.clone())
                        } else {
                            US2::US2_1
                        }
                    }
                    US2::US2_0(v64) => { // Some
                        let mut v64: US3 = v64.clone();
                        v61.clone()
                    }
                    _ => unreachable!(),
                };
                let mut v71: i32 = v57 + 1i32;
                v55.borrow_mut().l0 = v71;
                v55.borrow_mut().l1 = v70.clone();
                ()
            };
            let mut v72: US2 = v55.borrow().l1.clone();
            US1::US1_0(v72.clone())
        }
        _ => unreachable!(),
    };
    let mut v83: US2 = match &v76 {
        US1::US1_0(v77) => { // Some
            let mut v77: US2 = v77.clone();
            match &v77 {
                US2::US2_0(v78) => { // Some
                    let mut v78: US3 = v78.clone();
                    US2::US2_0(v78.clone())
                }
                _ => {
                    US2::US2_1
                }
            }
        }
        _ => {
            US2::US2_1
        }
    };
    let mut v87: US3 = match &v83 {
        US2::US2_1 => { // None
            US3::US3_0
        }
        US2::US2_0(v84) => { // Some
            let mut v84: US3 = v84.clone();
            v84.clone()
        }
        _ => unreachable!(),
    };
    let mut v92: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure2(v87.clone());
    { let _ = spiral_trace_hold(&v92); };
    let mut v100: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure4(v87.clone());
    let (mut v101, mut v102, mut v103, mut v104, mut v105, mut v106): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v100) };
    let mut v111: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v111); };
    let mut v113: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v114, mut v115, mut v116, mut v117, mut v118, mut v119): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v113) };
    let mut v120: US3 = v118.borrow().l0.clone();
    let mut v125: i32 = match &v120 {
        US3::US3_4 => { // Critical
            50i32
        }
        US3::US3_1 => { // Debug
            20i32
        }
        US3::US3_2 => { // Info
            30i32
        }
        US3::US3_0 => { // Verbose
            10i32
        }
        US3::US3_3 => { // Warning
            40i32
        }
        _ => unreachable!(),
    };
    let mut v126: bool = v116.borrow().l0.clone();
    let mut v127: bool = v126 == false;
    let mut v129: bool = if v127 {
        false
    } else {
        let mut v128: bool = 10i32 >= v125;
        v128
    };
    let mut v130: bool = v129 == false;
    let mut v175: US4 = if v130 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v111); };
        let (mut v134, mut v135, mut v136, mut v137, mut v138, mut v139): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v113) };
        let mut v140: Rc<str> = method6(v134.clone(), v135.clone(), v136.clone(), v137.clone(), v138.clone(), v139.clone());
        let mut v141: Rc<str> = method7();
        let mut v142: Rc<str> = method10(v134.clone(), v135.clone(), v136.clone(), v137.clone(), v138.clone(), v139.clone(), v140.clone(), v141.clone(), v9.clone());
        { let _ = spiral_trace_hold(&v111); };
        let (mut v145, mut v146, mut v147, mut v148, mut v149, mut v150): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v113) };
        let mut v151: i64 = v145.borrow().l0.clone();
        let mut v152: i64 = v151 + 1i64;
        v145.borrow_mut().l0 = v152;
        let mut v153: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v154: bool = cfg!(target_arch = "wasm32");
        if v154 {
            let mut v155: Rc<str> = v148.borrow().l0.clone();
            let mut v156: bool = v155.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v164: Rc<str> = if v156 {
                v142.clone()
            } else {
                let mut v157: bool = v142.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v157 {
                    let mut v158: Rc<str> = v148.borrow().l0.clone();
                    v158.clone()
                } else {
                    let mut v159: Rc<str> = v148.borrow().l0.clone();
                    let mut v160: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v161: Rc<str> = Rc::<str>::from(format!("{}{}", v159, v160));
                    let mut v162: Rc<str> = Rc::<str>::from(format!("{}{}", v161, v142));
                    v162.clone()
                }
            };
            let mut v166: i32 = ((v164.chars().count() + 14999) / 15000) as i32;
            let mut v167: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v168: bool = v142 != v167 ;
            let mut v170: bool = if v168 {
                let mut v169: bool = v166 <= 1i32;
                v169
            } else {
                false
            };
            if v170 {
                v148.borrow_mut().l0 = v164.clone();
                ()
            } else {
                v148.borrow_mut().l0 = v167.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v164); };
                ()
            }
        } else {
            println!("{}", v142);
            ()
        };
        let mut v173: Rc<dyn Fn(Rc<str>) -> ()> = v146.borrow().l0.clone();
        v173(v142.clone());
        US4::US4_0(v145.clone(), v146.clone(), v147.clone(), v148.clone(), v149.clone(), v150.clone())
    };
    let mut v176: Rc<str> = method20();
    let mut v178: &str = &*v176;
    let mut v180: Option<std::string::String> = clap::ArgMatches::get_one(&v12, v178).cloned();
    let mut v183: Option<std::string::String> = method2(v180.clone());
    let mut v184: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure8();
    let mut v185: Option<Rc<str>> = v183.map(|x| v184(x));
    let mut v186: Option<Rc<str>> = method23(v185.clone());
    let mut v187: Rc<dyn Fn((Rc<str>)) -> US5> = closure9();
    let mut v188: Option<US5> = v186.map(|x| v187(x));
    let mut v189: US5 = US5::US5_1;
    let mut v190: US5 = v188.unwrap_or(v189);
    let mut v191: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = method24(v12.clone());
    let mut v193: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v195: Result<u8, anyhow::Error> = v193.handle().block_on(v191);
    let mut v196: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v208: Result<u8, std::string::String> = v195.map_err(|x| v196(x));
    let mut v210: Result<u8, std::string::String> = v208.clone();
    let mut v211: Rc<dyn Fn(u8) -> US8> = method88();
    let mut v212: Rc<dyn Fn(std::string::String) -> US8> = method89();
    let mut v214: US8 = match v210 { Ok(x) => v211(x), Err(e) => v212(e) };
    match &v214 {
        US8::US8_1(v231) => { // Error
            let mut v231: std::string::String = v231.clone();
            match &v190 {
                US5::US5_0(v232) => { // Some
                    let mut v232: Rc<str> = v232.clone();
                    let mut v233: bool = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } == v232.clone();
                    if v233 {
                        ()
                    } else {
                        let mut v235: Rc<str> = Rc::<str>::from(String::as_str(&v231));
                        let mut v237: bool = v235.contains(&*v232);
                        if v237 {
                            ()
                        } else {
                            let mut v238: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / exception: '{}' / error: {}", v232, v231));
                            let mut v240: Result<(), Rc<str>> = Err(v238);
                            v240.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let mut v243: u8 = v208.unwrap();
                    ()
                }
            }
        }
        US8::US8_0(v215) => { // Ok
            let mut v215: u8 = v215.clone();
            match &v190 {
                US5::US5_0(v216) => { // Some
                    let mut v216: Rc<str> = v216.clone();
                    let mut v217: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / retries: {} / exception: '{}'", v215, v216));
                    let mut v229: Result<(), Rc<str>> = Err(v217);
                    v229.unwrap();
                    ()
                }
                _ => {
                    ()
                }
            }
        }
        _ => unreachable!(),
    }
    0
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
