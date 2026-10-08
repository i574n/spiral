#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
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
        let mut v4: &str = &*v1;
        let mut v7: std::string::String = String::from(v4);
        let mut v9: Box<std::string::String> = Box::new(v7);
        let mut v11: &'static mut std::string::String = Box::leak(v9);
        let mut v13: clap::builder::PossibleValue = clap::builder::PossibleValue::new(&**v11);
        v13.clone()
    }); } CLOSURE.with(|closure| closure.clone())
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
    let mut v89: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v89.borrow_mut().push(v82);
    v89.borrow_mut().push(v80);
    v89.borrow_mut().push(v78);
    v89.borrow_mut().push(v76);
    v89.borrow_mut().push(v74);
    let mut v90: Rc<Vec<Rc<str>>> = Rc::new(v89.borrow().clone());
    let mut v93: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v90).as_ref().clone()));
    let mut v96: Vec<Rc<str>> = (v93).borrow().clone();
    let mut v98: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v99: Vec<clap::builder::PossibleValue> = v96.iter().map(|x| v98(x.clone())).collect::<Vec<_>>();
    let mut v101: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v99));
    let mut v103: clap::Arg = v72.value_parser(v101);
    let mut v105: clap::Command = clap::Command::arg(v60, v103);
    let mut v109: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let mut v110: &'static str = Box::leak(String::from(&*v109).into_boxed_str());
    let mut v112: clap::Arg = clap::Arg::new(v110);
    let mut v114: clap::Arg = v112.short(b'w' as char);
    let mut v115: &'static str = Box::leak(String::from(&*v109).into_boxed_str());
    let mut v117: clap::Arg = v114.long(v115);
    let mut v119: clap::Arg = v117.required(true);
    let mut v121: clap::Command = clap::Command::arg(v105, v119);
    v121.clone()
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
    }); } CLOSURE.with(|closure| closure.clone())
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
    }); } CLOSURE.with(|closure| closure.clone())
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
        let mut v31: i32 = v30.wrapping_neg();
        let mut v32: i32 = v31.wrapping_add(v26);
        let mut v33: i32 = v32.wrapping_sub(1i32);
        let mut v34: US2 = v28.borrow().l1.clone();
        let (mut v35, mut v36): (Rc<str>, US3) = v25.clone().borrow()[v33 as usize].clone();
        let mut v43: US2 = match &v34 {
            US2::US2_1 => {
                let mut v38: bool = v35 == v2 ;
                if v38 {
                    US2::US2_0(v36.clone())
                } else {
                    US2::US2_1
                }
            }
            US2::US2_0(v37) => {
                let mut v37: US3 = v37.clone();
                v34.clone()
            }
        };
        let mut v44: i32 = v30.wrapping_add(1i32);
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
        US2::US2_1 => {
            v0.clone()
        }
        US2::US2_0(v52) => {
            let mut v52: US3 = v52.clone();
            v52.clone()
        }
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
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure6() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_0;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = method4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method6(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>) -> Rc<str> {
    let mut v61: u64 = { #[cfg(target_arch = "wasm32")] let (h, m, s) = { let secs = near_sdk::env::block_timestamp() / 1_000_000_000; ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; #[cfg(all(windows, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C)] struct St([u16; 8]); unsafe extern "system" { fn GetLocalTime(t: *mut St); } let mut t = St([0; 8]); unsafe { GetLocalTime(&mut t) }; (t.0[4] as u64, t.0[5] as u64, t.0[6] as u64) }; #[cfg(all(unix, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C, align(8))] struct Tm([i32; 16]); unsafe extern "C" { fn localtime_r(t: *const std::os::raw::c_long, tm: *mut Tm) -> *mut Tm; } let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0) as std::os::raw::c_long; let mut tm = Tm([0; 16]); unsafe { localtime_r(&secs, &mut tm) }; (tm.0[2] as u64, tm.0[1] as u64, tm.0[0] as u64) }; #[cfg(not(any(windows, unix, target_arch = "wasm32")))] let (h, m, s) = { let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0); ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; h * 3600 + m * 60 + s };
    let mut v62: u64 = v61.wrapping_div(3600u64);
    let mut v63: bool = v62 < 10u64;
    let mut v66: Rc<str> = if v63 {
        let mut v64: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v64.clone()
    } else {
        let mut v65: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v65.clone()
    };
    let mut v67: Rc<str> = Rc::<str>::from(format!("{:?}", v62));
    let mut v68: Rc<str> = Rc::<str>::from(format!("{}{}", v66, v67));
    let mut v69: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":"); } LIT.with(|lit| lit.clone()) };
    let mut v70: Rc<str> = Rc::<str>::from(format!("{}{}", v68, v69));
    let mut v71: u64 = v61.wrapping_div(60u64);
    let mut v72: u64 = v71.wrapping_rem(60u64);
    let mut v73: bool = v72 < 10u64;
    let mut v76: Rc<str> = if v73 {
        let mut v74: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v74.clone()
    } else {
        let mut v75: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v75.clone()
    };
    let mut v77: Rc<str> = Rc::<str>::from(format!("{:?}", v72));
    let mut v78: Rc<str> = Rc::<str>::from(format!("{}{}", v76, v77));
    let mut v79: Rc<str> = Rc::<str>::from(format!("{}{}", v70, v78));
    let mut v80: Rc<str> = Rc::<str>::from(format!("{}{}", v79, v69));
    let mut v81: u64 = v61.wrapping_rem(60u64);
    let mut v82: bool = v81 < 10u64;
    let mut v85: Rc<str> = if v82 {
        let mut v83: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v83.clone()
    } else {
        let mut v84: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v84.clone()
    };
    let mut v86: Rc<str> = Rc::<str>::from(format!("{:?}", v81));
    let mut v87: Rc<str> = Rc::<str>::from(format!("{}{}", v85, v86));
    let mut v88: Rc<str> = Rc::<str>::from(format!("{}{}", v80, v87));
    v88.clone()
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
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0 as char));
    method9(v2.clone(), v4.clone());
    let mut v5: Rc<str> = v2.borrow().l0.clone();
    v5.clone()
}
fn method7() -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[90m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(v2.to_lowercase());
    let mut v4: u8 = v3.clone().as_bytes()[0i32 as usize];
    let mut v5: Rc<str> = method8(v4);
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v5));
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v8));
    v9.clone()
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
                let mut v12: i32 = v2.wrapping_add(1i32);
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
            let mut v3: i32 = v1.wrapping_sub(1i32);
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
    let mut v4: i32 = v1.wrapping_sub(1i32);
    let mut v5: Rc<str> = string_slice(&v0.clone(), v3 as i64, v4 as i64);
    let mut v6: i32 = (v5.clone().len() as i32);
    let mut v7: i32 = method13(v5.clone(), v6);
    let mut v8: Rc<str> = string_slice(&v5.clone(), 0i32 as i64, v7 as i64);
    v8.clone()
}
fn method14(mut v0: i64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v4: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v4.clone());
    let mut v5: Rc<str> = v2.borrow().l0.clone();
    v5.clone()
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
    let mut v4: Rc<str> = Rc::<str>::from(format!("{:?}", v0.borrow()));
    method9(v2.clone(), v4.clone());
    method19(v2.clone());
    let mut v5: Rc<str> = v2.borrow().l0.clone();
    v5.clone()
}
fn method10(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let mut v12: Rc<str> = method14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.main"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v18));
    let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v22));
    let mut v24: Rc<str> = method15(v8.clone());
    let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    method11(v25.clone())
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
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
                let mut v6: i32 = v2.wrapping_add(1i32);
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
            let mut v3: i32 = v1.wrapping_sub(1i32);
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
        let mut v7: i32 = v4.wrapping_sub(1i32);
        let mut v8: Rc<str> = string_slice(&v3.clone(), v6 as i64, v7 as i64);
        let mut v9: i32 = (v8.clone().len() as i32);
        let mut v10: i32 = method22(v8.clone(), v9);
        let mut v11: Rc<str> = string_slice(&v8.clone(), 0i32 as i64, v10 as i64);
        v11.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method23(mut v0: Option<Rc<str>>) -> Option<Rc<str>> {
    v0.clone()
}
fn closure9() -> Rc<dyn Fn((Rc<str>)) -> US5> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> US5> = Rc::new(move |mut v0: (Rc<str>)| -> US5 {
        let mut v1: Rc<str> = (v0);
        US5::US5_0(v1.clone())
    }); } CLOSURE.with(|closure| closure.clone())
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
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v18));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = method27(v8.clone());
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    method11(v23.clone())
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
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v4.clone(), v6.clone());
    method34(v4.clone());
    method35(v4.clone());
    method18(v4.clone());
    let mut v9: std::string::String = format!("{:#?}", v1);
    let mut v11: Rc<str> = Rc::<str>::from(v9);
    method9(v4.clone(), v11.clone());
    method34(v4.clone());
    method36(v4.clone());
    method18(v4.clone());
    let mut v14: std::string::String = format!("{:#?}", v2);
    let mut v16: Rc<str> = Rc::<str>::from(v14);
    method9(v4.clone(), v16.clone());
    method19(v4.clone());
    let mut v17: Rc<str> = v4.borrow().l0.clone();
    v17.clone()
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
    let mut v7: std::string::String = format!("{:#?}", v1);
    let mut v9: Rc<str> = Rc::<str>::from(v7);
    method9(v3.clone(), v9.clone());
    method19(v3.clone());
    let mut v10: Rc<str> = v3.borrow().l0.clone();
    v10.clone()
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
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure11() -> Rc<dyn Fn(std::string::String) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> ()> = Rc::new(move |mut v0: std::string::String| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method40() -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(v2.to_lowercase());
    let mut v4: u8 = v3.clone().as_bytes()[0i32 as usize];
    let mut v5: Rc<str> = method8(v4);
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v5));
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v7));
    v8.clone()
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
    let mut v7: Rc<str> = Rc::<str>::from({ let v = v1; if v.is_finite() { format!("{:+.6}", v) } else if v.is_nan() { String::from("NaN") } else if v > 0.0 { String::from("Infinity") } else { String::from("-Infinity") } });
    method9(v4.clone(), v7.clone());
    method34(v4.clone());
    method44(v4.clone());
    method18(v4.clone());
    let mut v9: Rc<str> = Rc::<str>::from(format!("{}", v2));
    method9(v4.clone(), v9.clone());
    method19(v4.clone());
    let mut v10: Rc<str> = v4.borrow().l0.clone();
    v10.clone()
}
fn method41(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: f64, mut v10: u64) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0.clone();
    let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v12));
    let mut v14: Rc<str> = method14(v11);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v7));
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v12));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v20));
    let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    let mut v24: Rc<str> = method42(v8, v9, v10);
    let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    method11(v25.clone())
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
    let mut v15: std::string::String = format!("{:#?}", v4);
    let mut v17: Rc<str> = Rc::<str>::from(v15);
    method9(v6.clone(), v17.clone());
    method19(v6.clone());
    let mut v18: Rc<str> = v6.borrow().l0.clone();
    v18.clone()
}
fn method45(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: bool, mut v9: f64, mut v10: f64, mut v11: u64, mut v12: u128) -> Rc<str> {
    let mut v13: i64 = v0.borrow().l0.clone();
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v14));
    let mut v16: Rc<str> = method14(v13);
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v7));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v14));
    let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd / outcome"); } LIT.with(|lit| lit.clone()) };
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v22));
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    let mut v26: Rc<str> = method46(v8, v9, v10, v11, v12.clone());
    let mut v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    method11(v27.clone())
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
        let mut v19: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
        { let _ = spiral_trace_hold(&v19); };
        let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
        let (mut v22, mut v23, mut v24, mut v25, mut v26, mut v27): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
        let mut v28: US3 = v26.borrow().l0.clone();
        let mut v33: i32 = match &v28 {
            US3::US3_4 => {
                50i32
            }
            US3::US3_1 => {
                20i32
            }
            US3::US3_2 => {
                30i32
            }
            US3::US3_0 => {
                10i32
            }
            US3::US3_3 => {
                40i32
            }
        };
        let mut v34: bool = v24.borrow().l0.clone();
        let mut v35: bool = v34 == false;
        let mut v37: bool = if v35 {
            false
        } else {
            let mut v36: bool = 30i32 >= v33;
            v36
        };
        let mut v38: bool = v37 == false;
        let mut v83: US4 = if v38 {
            US4::US4_1
        } else {
            { let _ = spiral_trace_hold(&v19); };
            let (mut v42, mut v43, mut v44, mut v45, mut v46, mut v47): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
            let mut v48: Rc<str> = method6(v42.clone(), v43.clone(), v44.clone(), v45.clone(), v46.clone(), v47.clone());
            let mut v49: Rc<str> = method40();
            let mut v50: Rc<str> = method45(v42.clone(), v43.clone(), v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v2, v9, v17, v6, v13.clone());
            { let _ = spiral_trace_hold(&v19); };
            let (mut v53, mut v54, mut v55, mut v56, mut v57, mut v58): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
            let mut v59: i64 = v53.borrow().l0.clone();
            let mut v60: i64 = v59.wrapping_add(1i64);
            v53.borrow_mut().l0 = v60;
            let mut v61: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
            let mut v62: bool = cfg!(target_arch = "wasm32");
            if v62 {
                let mut v63: Rc<str> = v56.borrow().l0.clone();
                let mut v64: bool = v63.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let mut v72: Rc<str> = if v64 {
                    v50.clone()
                } else {
                    let mut v65: bool = v50.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                    if v65 {
                        let mut v66: Rc<str> = v56.borrow().l0.clone();
                        v66.clone()
                    } else {
                        let mut v67: Rc<str> = v56.borrow().l0.clone();
                        let mut v68: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                        let mut v69: Rc<str> = Rc::<str>::from(format!("{}{}", v67, v68));
                        let mut v70: Rc<str> = Rc::<str>::from(format!("{}{}", v69, v50));
                        v70.clone()
                    }
                };
                let mut v74: i32 = ((v72.chars().count() + 14999) / 15000) as i32;
                let mut v75: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let mut v76: bool = v50 != v75 ;
                let mut v78: bool = if v76 {
                    let mut v77: bool = v74 <= 1i32;
                    v77
                } else {
                    false
                };
                if v78 {
                    v56.borrow_mut().l0 = v72.clone();
                    ()
                } else {
                    v56.borrow_mut().l0 = v75.clone();
                    { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v72); };
                    ()
                }
            } else {
                println!("{}", v50);
                ()
            };
            let mut v81: Rc<dyn Fn(Rc<str>) -> ()> = v54.borrow().l0.clone();
            v81(v50.clone());
            US4::US4_0(v53.clone(), v54.clone(), v55.clone(), v56.clone(), v57.clone(), v58.clone())
        };
        ()
    }); } CLOSURE.with(|closure| closure.clone())
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
    let mut v5: std::string::String = format!("{:#?}", v0);
    let mut v7: Rc<str> = Rc::<str>::from(v5);
    method9(v2.clone(), v7.clone());
    method19(v2.clone());
    let mut v8: Rc<str> = v2.borrow().l0.clone();
    v8.clone()
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
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v3.clone(), v5.clone());
    method34(v3.clone());
    method59(v3.clone());
    method18(v3.clone());
    let mut v8: std::string::String = format!("{:#?}", v1);
    let mut v10: Rc<str> = Rc::<str>::from(v8);
    method9(v3.clone(), v10.clone());
    method19(v3.clone());
    let mut v11: Rc<str> = v3.borrow().l0.clone();
    v11.clone()
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
    let mut v7: std::string::String = format!("{:#?}", v1);
    let mut v9: Rc<str> = Rc::<str>::from(v7);
    method9(v3.clone(), v9.clone());
    method19(v3.clone());
    let mut v10: Rc<str> = v3.borrow().l0.clone();
    v10.clone()
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
    let mut v5: std::string::String = format!("{:#?}", v0);
    let mut v7: Rc<str> = Rc::<str>::from(v5);
    method9(v2.clone(), v7.clone());
    method19(v2.clone());
    let mut v8: Rc<str> = v2.borrow().l0.clone();
    v8.clone()
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
    let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v21); };
    let mut v23: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v24, mut v25, mut v26, mut v27, mut v28, mut v29): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v30: US3 = v28.borrow().l0.clone();
    let mut v35: i32 = match &v30 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v36: bool = v26.borrow().l0.clone();
    let mut v37: bool = v36 == false;
    let mut v39: bool = if v37 {
        false
    } else {
        let mut v38: bool = 10i32 >= v35;
        v38
    };
    let mut v40: bool = v39 == false;
    let mut v85: US4 = if v40 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v44, mut v45, mut v46, mut v47, mut v48, mut v49): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v50: Rc<str> = method6(v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone());
        let mut v51: Rc<str> = method7();
        let mut v52: Rc<str> = method31(v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v1, v11.clone(), v19.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v55, mut v56, mut v57, mut v58, mut v59, mut v60): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v61: i64 = v55.borrow().l0.clone();
        let mut v62: i64 = v61.wrapping_add(1i64);
        v55.borrow_mut().l0 = v62;
        let mut v63: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v64: bool = cfg!(target_arch = "wasm32");
        if v64 {
            let mut v65: Rc<str> = v58.borrow().l0.clone();
            let mut v66: bool = v65.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v74: Rc<str> = if v66 {
                v52.clone()
            } else {
                let mut v67: bool = v52.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v67 {
                    let mut v68: Rc<str> = v58.borrow().l0.clone();
                    v68.clone()
                } else {
                    let mut v69: Rc<str> = v58.borrow().l0.clone();
                    let mut v70: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v71: Rc<str> = Rc::<str>::from(format!("{}{}", v69, v70));
                    let mut v72: Rc<str> = Rc::<str>::from(format!("{}{}", v71, v52));
                    v72.clone()
                }
            };
            let mut v76: i32 = ((v74.chars().count() + 14999) / 15000) as i32;
            let mut v77: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v78: bool = v52 != v77 ;
            let mut v80: bool = if v78 {
                let mut v79: bool = v76 <= 1i32;
                v79
            } else {
                false
            };
            if v80 {
                v58.borrow_mut().l0 = v74.clone();
                ()
            } else {
                v58.borrow_mut().l0 = v77.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v74); };
                ()
            }
        } else {
            println!("{}", v52);
            ()
        };
        let mut v83: Rc<dyn Fn(Rc<str>) -> ()> = v56.borrow().l0.clone();
        v83(v52.clone());
        US4::US4_0(v55.clone(), v56.clone(), v57.clone(), v58.clone(), v59.clone(), v60.clone())
    };
    let mut v87: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v88: near_workspaces::operations::CallTransaction = v19.call(&*v87);
    let mut v92: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v94: near_workspaces::operations::CallTransaction = v88.gas(v92);
    let mut v96: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v94.transact());
    let mut v98: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v96.await;
    let mut v100: near_workspaces::result::ExecutionFinalResult = v98?;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v103, mut v104, mut v105, mut v106, mut v107, mut v108): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v109: US3 = v107.borrow().l0.clone();
    let mut v114: i32 = match &v109 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v115: bool = v105.borrow().l0.clone();
    let mut v116: bool = v115 == false;
    let mut v118: bool = if v116 {
        false
    } else {
        let mut v117: bool = 10i32 >= v114;
        v117
    };
    let mut v119: bool = v118 == false;
    let mut v164: US4 = if v119 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v123, mut v124, mut v125, mut v126, mut v127, mut v128): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v129: Rc<str> = method6(v123.clone(), v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone());
        let mut v130: Rc<str> = method7();
        let mut v131: Rc<str> = method37(v123.clone(), v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone(), v130.clone(), v1, v100.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v134, mut v135, mut v136, mut v137, mut v138, mut v139): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v140: i64 = v134.borrow().l0.clone();
        let mut v141: i64 = v140.wrapping_add(1i64);
        v134.borrow_mut().l0 = v141;
        let mut v142: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v143: bool = cfg!(target_arch = "wasm32");
        if v143 {
            let mut v144: Rc<str> = v137.borrow().l0.clone();
            let mut v145: bool = v144.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v153: Rc<str> = if v145 {
                v131.clone()
            } else {
                let mut v146: bool = v131.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v146 {
                    let mut v147: Rc<str> = v137.borrow().l0.clone();
                    v147.clone()
                } else {
                    let mut v148: Rc<str> = v137.borrow().l0.clone();
                    let mut v149: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v150: Rc<str> = Rc::<str>::from(format!("{}{}", v148, v149));
                    let mut v151: Rc<str> = Rc::<str>::from(format!("{}{}", v150, v131));
                    v151.clone()
                }
            };
            let mut v155: i32 = ((v153.chars().count() + 14999) / 15000) as i32;
            let mut v156: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v157: bool = v131 != v156 ;
            let mut v159: bool = if v157 {
                let mut v158: bool = v155 <= 1i32;
                v158
            } else {
                false
            };
            if v159 {
                v137.borrow_mut().l0 = v153.clone();
                ()
            } else {
                v137.borrow_mut().l0 = v156.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v153); };
                ()
            }
        } else {
            println!("{}", v131);
            ()
        };
        let mut v162: Rc<dyn Fn(Rc<str>) -> ()> = v135.borrow().l0.clone();
        v162(v131.clone());
        US4::US4_0(v134.clone(), v135.clone(), v136.clone(), v137.clone(), v138.clone(), v139.clone())
    };
    let mut v166: Vec<&str> = v100.logs();
    let mut v168: Rc<dyn Fn((&str)) -> std::string::String> = closure10();
    let mut v169: Vec<std::string::String> = v166.iter().map(|x| v168(x.clone())).collect::<Vec<_>>();
    let mut v171: Rc<dyn Fn(std::string::String) -> ()> = closure11();
    let mut v172: bool = true; v169.iter().for_each(|x| { v171(x.clone()); }); //;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v175, mut v176, mut v177, mut v178, mut v179, mut v180): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v181: US3 = v179.borrow().l0.clone();
    let mut v186: i32 = match &v181 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v187: bool = v177.borrow().l0.clone();
    let mut v188: bool = v187 == false;
    let mut v190: bool = if v188 {
        false
    } else {
        let mut v189: bool = 30i32 >= v186;
        v189
    };
    let mut v191: bool = v190 == false;
    let mut v226: US4 = if v191 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v195, mut v196, mut v197, mut v198, mut v199, mut v200): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v201: i64 = v195.borrow().l0.clone();
        let mut v202: i64 = v201.wrapping_add(1i64);
        v195.borrow_mut().l0 = v202;
        let mut v203: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v204: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v205: bool = cfg!(target_arch = "wasm32");
        if v205 {
            let mut v206: Rc<str> = v198.borrow().l0.clone();
            let mut v207: bool = v206.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v215: Rc<str> = if v207 {
                v203.clone()
            } else {
                let mut v208: bool = v203.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v208 {
                    let mut v209: Rc<str> = v198.borrow().l0.clone();
                    v209.clone()
                } else {
                    let mut v210: Rc<str> = v198.borrow().l0.clone();
                    let mut v211: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v212: Rc<str> = Rc::<str>::from(format!("{}{}", v210, v211));
                    let mut v213: Rc<str> = Rc::<str>::from(format!("{}{}", v212, v203));
                    v213.clone()
                }
            };
            let mut v217: i32 = ((v215.chars().count() + 14999) / 15000) as i32;
            let mut v218: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v219: bool = v203 != v218 ;
            let mut v221: bool = if v219 {
                let mut v220: bool = v217 <= 1i32;
                v220
            } else {
                false
            };
            if v221 {
                v198.borrow_mut().l0 = v215.clone();
                ()
            } else {
                v198.borrow_mut().l0 = v218.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v215); };
                ()
            }
        } else {
            println!("{}", v203);
            ()
        };
        let mut v224: Rc<dyn Fn(Rc<str>) -> ()> = v196.borrow().l0.clone();
        v224(v203.clone());
        US4::US4_0(v195.clone(), v196.clone(), v197.clone(), v198.clone(), v199.clone(), v200.clone())
    };
    let mut v228: near_workspaces::types::Gas = v100.total_gas_burnt;
    let mut v230: u64 = v228.as_gas();
    let mut v233: f64 = (v230 as f64);
    let mut v234: f64 = v233 / 10000000000000000.0f64;
    let mut v235: f64 = v234 * 6.68f64;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v238, mut v239, mut v240, mut v241, mut v242, mut v243): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v244: US3 = v242.borrow().l0.clone();
    let mut v249: i32 = match &v244 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v250: bool = v240.borrow().l0.clone();
    let mut v251: bool = v250 == false;
    let mut v253: bool = if v251 {
        false
    } else {
        let mut v252: bool = 30i32 >= v249;
        v252
    };
    let mut v254: bool = v253 == false;
    let mut v299: US4 = if v254 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v258, mut v259, mut v260, mut v261, mut v262, mut v263): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v264: Rc<str> = method6(v258.clone(), v259.clone(), v260.clone(), v261.clone(), v262.clone(), v263.clone());
        let mut v265: Rc<str> = method40();
        let mut v266: Rc<str> = method41(v258.clone(), v259.clone(), v260.clone(), v261.clone(), v262.clone(), v263.clone(), v264.clone(), v265.clone(), v1, v235, v230);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v269, mut v270, mut v271, mut v272, mut v273, mut v274): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v275: i64 = v269.borrow().l0.clone();
        let mut v276: i64 = v275.wrapping_add(1i64);
        v269.borrow_mut().l0 = v276;
        let mut v277: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v278: bool = cfg!(target_arch = "wasm32");
        if v278 {
            let mut v279: Rc<str> = v272.borrow().l0.clone();
            let mut v280: bool = v279.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v288: Rc<str> = if v280 {
                v266.clone()
            } else {
                let mut v281: bool = v266.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v281 {
                    let mut v282: Rc<str> = v272.borrow().l0.clone();
                    v282.clone()
                } else {
                    let mut v283: Rc<str> = v272.borrow().l0.clone();
                    let mut v284: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v285: Rc<str> = Rc::<str>::from(format!("{}{}", v283, v284));
                    let mut v286: Rc<str> = Rc::<str>::from(format!("{}{}", v285, v266));
                    v286.clone()
                }
            };
            let mut v290: i32 = ((v288.chars().count() + 14999) / 15000) as i32;
            let mut v291: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v292: bool = v266 != v291 ;
            let mut v294: bool = if v292 {
                let mut v293: bool = v290 <= 1i32;
                v293
            } else {
                false
            };
            if v294 {
                v272.borrow_mut().l0 = v288.clone();
                ()
            } else {
                v272.borrow_mut().l0 = v291.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v288); };
                ()
            }
        } else {
            println!("{}", v266);
            ()
        };
        let mut v297: Rc<dyn Fn(Rc<str>) -> ()> = v270.borrow().l0.clone();
        v297(v266.clone());
        US4::US4_0(v269.clone(), v270.clone(), v271.clone(), v272.clone(), v273.clone(), v274.clone())
    };
    let mut v301: near_workspaces::result::ExecutionFinalResult = v100.clone();
    let mut v303: Vec<&near_workspaces::result::ExecutionOutcome> = v301.outcomes();
    let mut v305: _ = v303.into_iter();
    let mut v307: _ = v305.cloned();
    let mut v309: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure12();
    let mut v310: bool = true; v307.for_each(|x| v309(x));
    let mut v312: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v100.clone().into_result();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v315, mut v316, mut v317, mut v318, mut v319, mut v320): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v321: US3 = v319.borrow().l0.clone();
    let mut v326: i32 = match &v321 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v327: bool = v317.borrow().l0.clone();
    let mut v328: bool = v327 == false;
    let mut v330: bool = if v328 {
        false
    } else {
        let mut v329: bool = 10i32 >= v326;
        v329
    };
    let mut v331: bool = v330 == false;
    let mut v376: US4 = if v331 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v335, mut v336, mut v337, mut v338, mut v339, mut v340): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v341: Rc<str> = method6(v335.clone(), v336.clone(), v337.clone(), v338.clone(), v339.clone(), v340.clone());
        let mut v342: Rc<str> = method7();
        let mut v343: Rc<str> = method52(v335.clone(), v336.clone(), v337.clone(), v338.clone(), v339.clone(), v340.clone(), v341.clone(), v342.clone(), v312.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v346, mut v347, mut v348, mut v349, mut v350, mut v351): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v352: i64 = v346.borrow().l0.clone();
        let mut v353: i64 = v352.wrapping_add(1i64);
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
    let mut v377: near_workspaces::result::ExecutionFinalResult = method55(v100.clone());
    let mut v379: Vec<&near_workspaces::result::ExecutionOutcome> = v377.receipt_failures();
    let mut v382: usize = ((v379).len() as usize);
    let mut v394: i32 = (v382 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v397, mut v398, mut v399, mut v400, mut v401, mut v402): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v403: US3 = v401.borrow().l0.clone();
    let mut v408: i32 = match &v403 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v409: bool = v399.borrow().l0.clone();
    let mut v410: bool = v409 == false;
    let mut v412: bool = if v410 {
        false
    } else {
        let mut v411: bool = 10i32 >= v408;
        v411
    };
    let mut v413: bool = v412 == false;
    let mut v458: US4 = if v413 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v417, mut v418, mut v419, mut v420, mut v421, mut v422): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v423: Rc<str> = method6(v417.clone(), v418.clone(), v419.clone(), v420.clone(), v421.clone(), v422.clone());
        let mut v424: Rc<str> = method7();
        let mut v425: Rc<str> = method56(v417.clone(), v418.clone(), v419.clone(), v420.clone(), v421.clone(), v422.clone(), v423.clone(), v424.clone(), v394, v379.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v428, mut v429, mut v430, mut v431, mut v432, mut v433): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v434: i64 = v428.borrow().l0.clone();
        let mut v435: i64 = v434.wrapping_add(1i64);
        v428.borrow_mut().l0 = v435;
        let mut v436: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v437: bool = cfg!(target_arch = "wasm32");
        if v437 {
            let mut v438: Rc<str> = v431.borrow().l0.clone();
            let mut v439: bool = v438.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v447: Rc<str> = if v439 {
                v425.clone()
            } else {
                let mut v440: bool = v425.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v440 {
                    let mut v441: Rc<str> = v431.borrow().l0.clone();
                    v441.clone()
                } else {
                    let mut v442: Rc<str> = v431.borrow().l0.clone();
                    let mut v443: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v444: Rc<str> = Rc::<str>::from(format!("{}{}", v442, v443));
                    let mut v445: Rc<str> = Rc::<str>::from(format!("{}{}", v444, v425));
                    v445.clone()
                }
            };
            let mut v449: i32 = ((v447.chars().count() + 14999) / 15000) as i32;
            let mut v450: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v451: bool = v425 != v450 ;
            let mut v453: bool = if v451 {
                let mut v452: bool = v449 <= 1i32;
                v452
            } else {
                false
            };
            if v453 {
                v431.borrow_mut().l0 = v447.clone();
                ()
            } else {
                v431.borrow_mut().l0 = v450.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v447); };
                ()
            }
        } else {
            println!("{}", v425);
            ()
        };
        let mut v456: Rc<dyn Fn(Rc<str>) -> ()> = v429.borrow().l0.clone();
        v456(v425.clone());
        US4::US4_0(v428.clone(), v429.clone(), v430.clone(), v431.clone(), v432.clone(), v433.clone())
    };
    let mut v459: near_workspaces::result::ExecutionFinalResult = method60(v100.clone());
    let mut v461: &[near_workspaces::result::ExecutionOutcome] = v459.receipt_outcomes();
    let mut v463: Vec<near_workspaces::result::ExecutionOutcome> = v461.into();
    let mut v466: usize = ((v463).len() as usize);
    let mut v467: i32 = (v466 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v470, mut v471, mut v472, mut v473, mut v474, mut v475): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v476: US3 = v474.borrow().l0.clone();
    let mut v481: i32 = match &v476 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v482: bool = v472.borrow().l0.clone();
    let mut v483: bool = v482 == false;
    let mut v485: bool = if v483 {
        false
    } else {
        let mut v484: bool = 10i32 >= v481;
        v484
    };
    let mut v486: bool = v485 == false;
    let mut v531: US4 = if v486 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v490, mut v491, mut v492, mut v493, mut v494, mut v495): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v496: Rc<str> = method6(v490.clone(), v491.clone(), v492.clone(), v493.clone(), v494.clone(), v495.clone());
        let mut v497: Rc<str> = method7();
        let mut v498: Rc<str> = method61(v490.clone(), v491.clone(), v492.clone(), v493.clone(), v494.clone(), v495.clone(), v496.clone(), v497.clone(), v467, v463.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v501, mut v502, mut v503, mut v504, mut v505, mut v506): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v507: i64 = v501.borrow().l0.clone();
        let mut v508: i64 = v507.wrapping_add(1i64);
        v501.borrow_mut().l0 = v508;
        let mut v509: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v510: bool = cfg!(target_arch = "wasm32");
        if v510 {
            let mut v511: Rc<str> = v504.borrow().l0.clone();
            let mut v512: bool = v511.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v520: Rc<str> = if v512 {
                v498.clone()
            } else {
                let mut v513: bool = v498.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v513 {
                    let mut v514: Rc<str> = v504.borrow().l0.clone();
                    v514.clone()
                } else {
                    let mut v515: Rc<str> = v504.borrow().l0.clone();
                    let mut v516: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v517: Rc<str> = Rc::<str>::from(format!("{}{}", v515, v516));
                    let mut v518: Rc<str> = Rc::<str>::from(format!("{}{}", v517, v498));
                    v518.clone()
                }
            };
            let mut v522: i32 = ((v520.chars().count() + 14999) / 15000) as i32;
            let mut v523: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v524: bool = v498 != v523 ;
            let mut v526: bool = if v524 {
                let mut v525: bool = v522 <= 1i32;
                v525
            } else {
                false
            };
            if v526 {
                v504.borrow_mut().l0 = v520.clone();
                ()
            } else {
                v504.borrow_mut().l0 = v523.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v520); };
                ()
            }
        } else {
            println!("{}", v498);
            ()
        };
        let mut v529: Rc<dyn Fn(Rc<str>) -> ()> = v502.borrow().l0.clone();
        v529(v498.clone());
        US4::US4_0(v501.clone(), v502.clone(), v503.clone(), v504.clone(), v505.clone(), v506.clone())
    };
    let mut v533: near_workspaces::result::ExecutionFinalResult = v100.clone();
    let mut v535: Result<std::string::String, near_workspaces::error::Error> = v533.json();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v538, mut v539, mut v540, mut v541, mut v542, mut v543): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v544: US3 = v542.borrow().l0.clone();
    let mut v549: i32 = match &v544 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v550: bool = v540.borrow().l0.clone();
    let mut v551: bool = v550 == false;
    let mut v553: bool = if v551 {
        false
    } else {
        let mut v552: bool = 10i32 >= v549;
        v552
    };
    let mut v554: bool = v553 == false;
    let mut v599: US4 = if v554 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v558, mut v559, mut v560, mut v561, mut v562, mut v563): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v564: Rc<str> = method6(v558.clone(), v559.clone(), v560.clone(), v561.clone(), v562.clone(), v563.clone());
        let mut v565: Rc<str> = method7();
        let mut v566: Rc<str> = method65(v558.clone(), v559.clone(), v560.clone(), v561.clone(), v562.clone(), v563.clone(), v564.clone(), v565.clone(), v535);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v569, mut v570, mut v571, mut v572, mut v573, mut v574): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v575: i64 = v569.borrow().l0.clone();
        let mut v576: i64 = v575.wrapping_add(1i64);
        v569.borrow_mut().l0 = v576;
        let mut v577: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v578: bool = cfg!(target_arch = "wasm32");
        if v578 {
            let mut v579: Rc<str> = v572.borrow().l0.clone();
            let mut v580: bool = v579.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v588: Rc<str> = if v580 {
                v566.clone()
            } else {
                let mut v581: bool = v566.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v581 {
                    let mut v582: Rc<str> = v572.borrow().l0.clone();
                    v582.clone()
                } else {
                    let mut v583: Rc<str> = v572.borrow().l0.clone();
                    let mut v584: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v585: Rc<str> = Rc::<str>::from(format!("{}{}", v583, v584));
                    let mut v586: Rc<str> = Rc::<str>::from(format!("{}{}", v585, v566));
                    v586.clone()
                }
            };
            let mut v590: i32 = ((v588.chars().count() + 14999) / 15000) as i32;
            let mut v591: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v592: bool = v566 != v591 ;
            let mut v594: bool = if v592 {
                let mut v593: bool = v590 <= 1i32;
                v593
            } else {
                false
            };
            if v594 {
                v572.borrow_mut().l0 = v588.clone();
                ()
            } else {
                v572.borrow_mut().l0 = v591.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v588); };
                ()
            }
        } else {
            println!("{}", v566);
            ()
        };
        let mut v597: Rc<dyn Fn(Rc<str>) -> ()> = v570.borrow().l0.clone();
        v597(v566.clone());
        US4::US4_0(v569.clone(), v570.clone(), v571.clone(), v572.clone(), v573.clone(), v574.clone())
    };
    let mut v601: near_workspaces::result::ExecutionFinalResult = v100.clone();
    let mut v603: Result<std::string::String, near_workspaces::error::Error> = v601.borsh();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v606, mut v607, mut v608, mut v609, mut v610, mut v611): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v612: US3 = v610.borrow().l0.clone();
    let mut v617: i32 = match &v612 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v618: bool = v608.borrow().l0.clone();
    let mut v619: bool = v618 == false;
    let mut v621: bool = if v619 {
        false
    } else {
        let mut v620: bool = 10i32 >= v617;
        v620
    };
    let mut v622: bool = v621 == false;
    let mut v667: US4 = if v622 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v626, mut v627, mut v628, mut v629, mut v630, mut v631): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v632: Rc<str> = method6(v626.clone(), v627.clone(), v628.clone(), v629.clone(), v630.clone(), v631.clone());
        let mut v633: Rc<str> = method7();
        let mut v634: Rc<str> = method68(v626.clone(), v627.clone(), v628.clone(), v629.clone(), v630.clone(), v631.clone(), v632.clone(), v633.clone(), v603);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v637, mut v638, mut v639, mut v640, mut v641, mut v642): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v643: i64 = v637.borrow().l0.clone();
        let mut v644: i64 = v643.wrapping_add(1i64);
        v637.borrow_mut().l0 = v644;
        let mut v645: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v646: bool = cfg!(target_arch = "wasm32");
        if v646 {
            let mut v647: Rc<str> = v640.borrow().l0.clone();
            let mut v648: bool = v647.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v656: Rc<str> = if v648 {
                v634.clone()
            } else {
                let mut v649: bool = v634.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v649 {
                    let mut v650: Rc<str> = v640.borrow().l0.clone();
                    v650.clone()
                } else {
                    let mut v651: Rc<str> = v640.borrow().l0.clone();
                    let mut v652: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v653: Rc<str> = Rc::<str>::from(format!("{}{}", v651, v652));
                    let mut v654: Rc<str> = Rc::<str>::from(format!("{}{}", v653, v634));
                    v654.clone()
                }
            };
            let mut v658: i32 = ((v656.chars().count() + 14999) / 15000) as i32;
            let mut v659: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v660: bool = v634 != v659 ;
            let mut v662: bool = if v660 {
                let mut v661: bool = v658 <= 1i32;
                v661
            } else {
                false
            };
            if v662 {
                v640.borrow_mut().l0 = v656.clone();
                ()
            } else {
                v640.borrow_mut().l0 = v659.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v656); };
                ()
            }
        } else {
            println!("{}", v634);
            ()
        };
        let mut v665: Rc<dyn Fn(Rc<str>) -> ()> = v638.borrow().l0.clone();
        v665(v634.clone());
        US4::US4_0(v637.clone(), v638.clone(), v639.clone(), v640.clone(), v641.clone(), v642.clone())
    };
    let mut v668: Rc<str> = method71(v467, v1, v379.clone());
    let mut v669: bool = v394 > 0i32;
    let mut v686: Result<US5, anyhow::Error> = if v669 {
        let mut v672: US5 = US5::US5_0(v668.clone());
        let mut v673: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v672);
        v673
    } else {
        let mut v674: bool = v467 > 1i32;
        if v674 {
            let mut v677: US5 = US5::US5_1;
            let mut v678: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v677);
            v678
        } else {
            let mut v682: anyhow::Error = anyhow::anyhow!("{}", v668);
            let mut v684: Result<US5, anyhow::Error> = Err(v682);
            v684
        }
    };
    let mut v688: bool = true; (v686) }); //;
    let mut v690: _ = __future_init;
    let mut v692: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = v690;
    v692
}
fn closure13() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let mut v3: std::string::String = format!("{}", v0);
        v3.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method72() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure13()
}
fn closure14() -> Rc<dyn Fn(US5) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US5) -> US7> = Rc::new(move |mut v0: US5| -> US7 {
        US7::US7_0(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method73() -> Rc<dyn Fn(US5) -> US7> {
    closure14()
}
fn closure15() -> Rc<dyn Fn(std::string::String) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US7> = Rc::new(move |mut v0: std::string::String| -> US7 {
        US7::US7_1(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method74() -> Rc<dyn Fn(std::string::String) -> US7> {
    closure15()
}
fn method75() -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[93m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(v2.to_lowercase());
    let mut v4: u8 = v3.clone().as_bytes()[0i32 as usize];
    let mut v5: Rc<str> = method8(v4);
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v5));
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v7));
    v8.clone()
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
    let mut v7: std::string::String = format!("{:#?}", v1);
    let mut v9: Rc<str> = Rc::<str>::from(v7);
    method9(v3.clone(), v9.clone());
    method19(v3.clone());
    let mut v10: Rc<str> = v3.borrow().l0.clone();
    v10.clone()
}
fn method76(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: std::string::String) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = method14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Error error"); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    let mut v23: Rc<str> = method77(v8, v9.clone());
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    method11(v24.clone())
}
fn method79() -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[91m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = Rc::<str>::from(v2.to_lowercase());
    let mut v4: u8 = v3.clone().as_bytes()[0i32 as usize];
    let mut v5: Rc<str> = method8(v4);
    let mut v6: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v5));
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v7));
    v8.clone()
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
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Ok (Some error)"); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    let mut v23: Rc<str> = method81(v8, v9.clone());
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    method11(v24.clone())
}
fn method29(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let mut v7: bool = */ ();
    let mut v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = method30(v0.clone(), v1);
    let mut v10: Result<US5, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v13: Result<US5, std::string::String> = v10.map_err(|x| v11(x));
    let mut v14: Rc<dyn Fn(US5) -> US7> = method73();
    let mut v15: Rc<dyn Fn(std::string::String) -> US7> = method74();
    let mut v17: US7 = match v13 { Ok(x) => v14(x), Err(e) => v15(e) };
    let mut v384: US6 = match &v17 {
        US7::US7_1(v122) => {
            let mut v122: std::string::String = v122.clone();
            let mut v123: bool = v1 >= 15u8;
            if v123 {
                let mut v125: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                { let _ = spiral_trace_hold(&v125); };
                let mut v127: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                let (mut v128, mut v129, mut v130, mut v131, mut v132, mut v133): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                let mut v134: US3 = v132.borrow().l0.clone();
                let mut v139: i32 = match &v134 {
                    US3::US3_4 => {
                        50i32
                    }
                    US3::US3_1 => {
                        20i32
                    }
                    US3::US3_2 => {
                        30i32
                    }
                    US3::US3_0 => {
                        10i32
                    }
                    US3::US3_3 => {
                        40i32
                    }
                };
                let mut v140: bool = v130.borrow().l0.clone();
                let mut v141: bool = v140 == false;
                let mut v143: bool = if v141 {
                    false
                } else {
                    let mut v142: bool = 40i32 >= v139;
                    v142
                };
                let mut v144: bool = v143 == false;
                let mut v189: US4 = if v144 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v148, mut v149, mut v150, mut v151, mut v152, mut v153): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let mut v154: Rc<str> = method6(v148.clone(), v149.clone(), v150.clone(), v151.clone(), v152.clone(), v153.clone());
                    let mut v155: Rc<str> = method75();
                    let mut v156: Rc<str> = method76(v148.clone(), v149.clone(), v150.clone(), v151.clone(), v152.clone(), v153.clone(), v154.clone(), v155.clone(), v1, v122.clone());
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v159, mut v160, mut v161, mut v162, mut v163, mut v164): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let mut v165: i64 = v159.borrow().l0.clone();
                    let mut v166: i64 = v165.wrapping_add(1i64);
                    v159.borrow_mut().l0 = v166;
                    let mut v167: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v168: bool = cfg!(target_arch = "wasm32");
                    if v168 {
                        let mut v169: Rc<str> = v162.borrow().l0.clone();
                        let mut v170: bool = v169.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v178: Rc<str> = if v170 {
                            v156.clone()
                        } else {
                            let mut v171: bool = v156.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v171 {
                                let mut v172: Rc<str> = v162.borrow().l0.clone();
                                v172.clone()
                            } else {
                                let mut v173: Rc<str> = v162.borrow().l0.clone();
                                let mut v174: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v175: Rc<str> = Rc::<str>::from(format!("{}{}", v173, v174));
                                let mut v176: Rc<str> = Rc::<str>::from(format!("{}{}", v175, v156));
                                v176.clone()
                            }
                        };
                        let mut v180: i32 = ((v178.chars().count() + 14999) / 15000) as i32;
                        let mut v181: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v182: bool = v156 != v181 ;
                        let mut v184: bool = if v182 {
                            let mut v183: bool = v180 <= 1i32;
                            v183
                        } else {
                            false
                        };
                        if v184 {
                            v162.borrow_mut().l0 = v178.clone();
                            ()
                        } else {
                            v162.borrow_mut().l0 = v181.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v178); };
                            ()
                        }
                    } else {
                        println!("{}", v156);
                        ()
                    };
                    let mut v187: Rc<dyn Fn(Rc<str>) -> ()> = v160.borrow().l0.clone();
                    v187(v156.clone());
                    US4::US4_0(v159.clone(), v160.clone(), v161.clone(), v162.clone(), v163.clone(), v164.clone())
                };
                { let _ = spiral_trace_hold(&v125); };
                let (mut v192, mut v193, mut v194, mut v195, mut v196, mut v197): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                let mut v198: US3 = v196.borrow().l0.clone();
                let mut v203: i32 = match &v198 {
                    US3::US3_4 => {
                        50i32
                    }
                    US3::US3_1 => {
                        20i32
                    }
                    US3::US3_2 => {
                        30i32
                    }
                    US3::US3_0 => {
                        10i32
                    }
                    US3::US3_3 => {
                        40i32
                    }
                };
                let mut v204: bool = v194.borrow().l0.clone();
                let mut v205: bool = v204 == false;
                let mut v207: bool = if v205 {
                    false
                } else {
                    let mut v206: bool = 40i32 >= v203;
                    v206
                };
                let mut v208: bool = v207 == false;
                let mut v242: US4 = if v208 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v212, mut v213, mut v214, mut v215, mut v216, mut v217): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let mut v218: i64 = v212.borrow().l0.clone();
                    let mut v219: i64 = v218.wrapping_add(1i64);
                    v212.borrow_mut().l0 = v219;
                    let mut v220: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v221: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v222: bool = cfg!(target_arch = "wasm32");
                    if v222 {
                        let mut v223: Rc<str> = v215.borrow().l0.clone();
                        let mut v224: bool = v223.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v231: Rc<str> = if v224 {
                            v220.clone()
                        } else {
                            let mut v225: bool = v220.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v225 {
                                let mut v226: Rc<str> = v215.borrow().l0.clone();
                                v226.clone()
                            } else {
                                let mut v227: Rc<str> = v215.borrow().l0.clone();
                                let mut v228: Rc<str> = Rc::<str>::from(format!("{}{}", v227, v220));
                                let mut v229: Rc<str> = Rc::<str>::from(format!("{}{}", v228, v220));
                                v229.clone()
                            }
                        };
                        let mut v233: i32 = ((v231.chars().count() + 14999) / 15000) as i32;
                        let mut v234: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v235: bool = v220 != v234 ;
                        let mut v237: bool = if v235 {
                            let mut v236: bool = v233 <= 1i32;
                            v236
                        } else {
                            false
                        };
                        if v237 {
                            v215.borrow_mut().l0 = v231.clone();
                            ()
                        } else {
                            v215.borrow_mut().l0 = v234.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v231); };
                            ()
                        }
                    } else {
                        println!("{}", v220);
                        ()
                    };
                    let mut v240: Rc<dyn Fn(Rc<str>) -> ()> = v213.borrow().l0.clone();
                    v240(v220.clone());
                    US4::US4_0(v212.clone(), v213.clone(), v214.clone(), v215.clone(), v216.clone(), v217.clone())
                };
                let mut v244: bool = true; let __future_init = Box::pin(/*;
                let mut v246: bool = */ async move { /*;
                let mut v248: bool = */ ();
                let mut v249: US5 = US5::US5_1;
                let mut v250: bool = true; ((v1, v249.clone())) }); //;
                let mut v252: _ = __future_init;
                let mut v254: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v252;
                let (mut v256, mut v257): (u8, US5) = v254.await;
                US6::US6_0(v256, v257.clone())
            } else {
                let mut v260: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                { let _ = spiral_trace_hold(&v260); };
                let mut v262: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                let (mut v263, mut v264, mut v265, mut v266, mut v267, mut v268): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v262) };
                let mut v269: US3 = v267.borrow().l0.clone();
                let mut v274: i32 = match &v269 {
                    US3::US3_4 => {
                        50i32
                    }
                    US3::US3_1 => {
                        20i32
                    }
                    US3::US3_2 => {
                        30i32
                    }
                    US3::US3_0 => {
                        10i32
                    }
                    US3::US3_3 => {
                        40i32
                    }
                };
                let mut v275: bool = v265.borrow().l0.clone();
                let mut v276: bool = v275 == false;
                let mut v278: bool = if v276 {
                    false
                } else {
                    let mut v277: bool = 40i32 >= v274;
                    v277
                };
                let mut v279: bool = v278 == false;
                let mut v324: US4 = if v279 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v260); };
                    let (mut v283, mut v284, mut v285, mut v286, mut v287, mut v288): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v262) };
                    let mut v289: Rc<str> = method6(v283.clone(), v284.clone(), v285.clone(), v286.clone(), v287.clone(), v288.clone());
                    let mut v290: Rc<str> = method75();
                    let mut v291: Rc<str> = method76(v283.clone(), v284.clone(), v285.clone(), v286.clone(), v287.clone(), v288.clone(), v289.clone(), v290.clone(), v1, v122.clone());
                    { let _ = spiral_trace_hold(&v260); };
                    let (mut v294, mut v295, mut v296, mut v297, mut v298, mut v299): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v262) };
                    let mut v300: i64 = v294.borrow().l0.clone();
                    let mut v301: i64 = v300.wrapping_add(1i64);
                    v294.borrow_mut().l0 = v301;
                    let mut v302: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v303: bool = cfg!(target_arch = "wasm32");
                    if v303 {
                        let mut v304: Rc<str> = v297.borrow().l0.clone();
                        let mut v305: bool = v304.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v313: Rc<str> = if v305 {
                            v291.clone()
                        } else {
                            let mut v306: bool = v291.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v306 {
                                let mut v307: Rc<str> = v297.borrow().l0.clone();
                                v307.clone()
                            } else {
                                let mut v308: Rc<str> = v297.borrow().l0.clone();
                                let mut v309: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v310: Rc<str> = Rc::<str>::from(format!("{}{}", v308, v309));
                                let mut v311: Rc<str> = Rc::<str>::from(format!("{}{}", v310, v291));
                                v311.clone()
                            }
                        };
                        let mut v315: i32 = ((v313.chars().count() + 14999) / 15000) as i32;
                        let mut v316: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v317: bool = v291 != v316 ;
                        let mut v319: bool = if v317 {
                            let mut v318: bool = v315 <= 1i32;
                            v318
                        } else {
                            false
                        };
                        if v319 {
                            v297.borrow_mut().l0 = v313.clone();
                            ()
                        } else {
                            v297.borrow_mut().l0 = v316.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v313); };
                            ()
                        }
                    } else {
                        println!("{}", v291);
                        ()
                    };
                    let mut v322: Rc<dyn Fn(Rc<str>) -> ()> = v295.borrow().l0.clone();
                    v322(v291.clone());
                    US4::US4_0(v294.clone(), v295.clone(), v296.clone(), v297.clone(), v298.clone(), v299.clone())
                };
                { let _ = spiral_trace_hold(&v260); };
                let (mut v327, mut v328, mut v329, mut v330, mut v331, mut v332): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v262) };
                let mut v333: US3 = v331.borrow().l0.clone();
                let mut v338: i32 = match &v333 {
                    US3::US3_4 => {
                        50i32
                    }
                    US3::US3_1 => {
                        20i32
                    }
                    US3::US3_2 => {
                        30i32
                    }
                    US3::US3_0 => {
                        10i32
                    }
                    US3::US3_3 => {
                        40i32
                    }
                };
                let mut v339: bool = v329.borrow().l0.clone();
                let mut v340: bool = v339 == false;
                let mut v342: bool = if v340 {
                    false
                } else {
                    let mut v341: bool = 40i32 >= v338;
                    v341
                };
                let mut v343: bool = v342 == false;
                let mut v377: US4 = if v343 {
                    US4::US4_1
                } else {
                    { let _ = spiral_trace_hold(&v260); };
                    let (mut v347, mut v348, mut v349, mut v350, mut v351, mut v352): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v262) };
                    let mut v353: i64 = v347.borrow().l0.clone();
                    let mut v354: i64 = v353.wrapping_add(1i64);
                    v347.borrow_mut().l0 = v354;
                    let mut v355: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v356: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v357: bool = cfg!(target_arch = "wasm32");
                    if v357 {
                        let mut v358: Rc<str> = v350.borrow().l0.clone();
                        let mut v359: bool = v358.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v366: Rc<str> = if v359 {
                            v355.clone()
                        } else {
                            let mut v360: bool = v355.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v360 {
                                let mut v361: Rc<str> = v350.borrow().l0.clone();
                                v361.clone()
                            } else {
                                let mut v362: Rc<str> = v350.borrow().l0.clone();
                                let mut v363: Rc<str> = Rc::<str>::from(format!("{}{}", v362, v355));
                                let mut v364: Rc<str> = Rc::<str>::from(format!("{}{}", v363, v355));
                                v364.clone()
                            }
                        };
                        let mut v368: i32 = ((v366.chars().count() + 14999) / 15000) as i32;
                        let mut v369: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v370: bool = v355 != v369 ;
                        let mut v372: bool = if v370 {
                            let mut v371: bool = v368 <= 1i32;
                            v371
                        } else {
                            false
                        };
                        if v372 {
                            v350.borrow_mut().l0 = v366.clone();
                            ()
                        } else {
                            v350.borrow_mut().l0 = v369.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v366); };
                            ()
                        }
                    } else {
                        println!("{}", v355);
                        ()
                    };
                    let mut v375: Rc<dyn Fn(Rc<str>) -> ()> = v348.borrow().l0.clone();
                    v375(v355.clone());
                    US4::US4_0(v347.clone(), v348.clone(), v349.clone(), v350.clone(), v351.clone(), v352.clone())
                };
                let mut v378: u8 = v1.wrapping_add(1u8);
                let mut v379: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method29(v0.clone(), v378);
                let mut v381: US6 = v379.await;
                v381.clone()
            }
        }
        US7::US7_0(v18) => {
            let mut v18: US5 = v18.clone();
            match &v18 {
                US5::US5_1 => {
                    let mut v20: bool = true; let __future_init = Box::pin(/*;
                    let mut v22: bool = */ async move { /*;
                    let mut v24: bool = */ ();
                    let mut v26: US5 = US5::US5_1;
                    let mut v27: bool = true; ((v1, v26.clone())) }); //;
                    let mut v29: _ = __future_init;
                    let mut v31: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v29;
                    let (mut v33, mut v34): (u8, US5) = v31.await;
                    US6::US6_0(v33, v34.clone())
                }
                US5::US5_0(v36) => {
                    let mut v36: Rc<str> = v36.clone();
                    let mut v38: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
                    { let _ = spiral_trace_hold(&v38); };
                    let mut v40: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
                    let (mut v41, mut v42, mut v43, mut v44, mut v45, mut v46): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v40) };
                    let mut v47: US3 = v45.borrow().l0.clone();
                    let mut v52: i32 = match &v47 {
                        US3::US3_4 => {
                            50i32
                        }
                        US3::US3_1 => {
                            20i32
                        }
                        US3::US3_2 => {
                            30i32
                        }
                        US3::US3_0 => {
                            10i32
                        }
                        US3::US3_3 => {
                            40i32
                        }
                    };
                    let mut v53: bool = v43.borrow().l0.clone();
                    let mut v54: bool = v53 == false;
                    let mut v56: bool = if v54 {
                        false
                    } else {
                        let mut v55: bool = 50i32 >= v52;
                        v55
                    };
                    let mut v57: bool = v56 == false;
                    let mut v102: US4 = if v57 {
                        US4::US4_1
                    } else {
                        { let _ = spiral_trace_hold(&v38); };
                        let (mut v61, mut v62, mut v63, mut v64, mut v65, mut v66): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v40) };
                        let mut v67: Rc<str> = method6(v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone(), v66.clone());
                        let mut v68: Rc<str> = method79();
                        let mut v69: Rc<str> = method80(v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone(), v66.clone(), v67.clone(), v68.clone(), v1, v36.clone());
                        { let _ = spiral_trace_hold(&v38); };
                        let (mut v72, mut v73, mut v74, mut v75, mut v76, mut v77): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v40) };
                        let mut v78: i64 = v72.borrow().l0.clone();
                        let mut v79: i64 = v78.wrapping_add(1i64);
                        v72.borrow_mut().l0 = v79;
                        let mut v80: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                        let mut v81: bool = cfg!(target_arch = "wasm32");
                        if v81 {
                            let mut v82: Rc<str> = v75.borrow().l0.clone();
                            let mut v83: bool = v82.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v91: Rc<str> = if v83 {
                                v69.clone()
                            } else {
                                let mut v84: bool = v69.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                                if v84 {
                                    let mut v85: Rc<str> = v75.borrow().l0.clone();
                                    v85.clone()
                                } else {
                                    let mut v86: Rc<str> = v75.borrow().l0.clone();
                                    let mut v87: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                    let mut v88: Rc<str> = Rc::<str>::from(format!("{}{}", v86, v87));
                                    let mut v89: Rc<str> = Rc::<str>::from(format!("{}{}", v88, v69));
                                    v89.clone()
                                }
                            };
                            let mut v93: i32 = ((v91.chars().count() + 14999) / 15000) as i32;
                            let mut v94: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v95: bool = v69 != v94 ;
                            let mut v97: bool = if v95 {
                                let mut v96: bool = v93 <= 1i32;
                                v96
                            } else {
                                false
                            };
                            if v97 {
                                v75.borrow_mut().l0 = v91.clone();
                                ()
                            } else {
                                v75.borrow_mut().l0 = v94.clone();
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v91); };
                                ()
                            }
                        } else {
                            println!("{}", v69);
                            ()
                        };
                        let mut v100: Rc<dyn Fn(Rc<str>) -> ()> = v73.borrow().l0.clone();
                        v100(v69.clone());
                        US4::US4_0(v72.clone(), v73.clone(), v74.clone(), v75.clone(), v76.clone(), v77.clone())
                    };
                    let mut v104: bool = true; let __future_init = Box::pin(/*;
                    let mut v106: bool = */ async move { /*;
                    let mut v108: bool = */ ();
                    let mut v110: US5 = US5::US5_0(v36.clone());
                    let mut v111: bool = true; ((v1, v110.clone())) }); //;
                    let mut v113: _ = __future_init;
                    let mut v115: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v113;
                    let (mut v117, mut v118): (u8, US5) = v115.await;
                    US6::US6_1(v117, v118.clone())
                }
            }
        }
    };
    let mut v386: bool = true; (v384) }); //;
    let mut v388: _ = __future_init;
    let mut v390: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = v388;
    v390
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
        US5::US5_1 => {
            let mut v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v27.clone()
        }
        US5::US5_0(v1) => {
            let mut v1: Rc<str> = v1.clone();
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v4));
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v9: Rc<str> = Rc::<str>::from(format!("{}{}", v8, v5));
            let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some"); } LIT.with(|lit| lit.clone()) };
            let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v9));
            v21.clone()
        }
    }
}
fn method85(mut v0: US6) -> Rc<str> {
    match &v0 {
        US6::US6_1(v44, v45) => {
            let mut v44: u8 = *v44;
            let mut v45: US5 = v45.clone();
            let mut v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v47: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v49: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v51: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let mut v52: Rc<str> = Rc::<str>::from(format!("{:?}", v44));
            let mut v53: Rc<str> = Rc::<str>::from(format!("{}{}", v51, v52));
            let mut v54: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v55: Rc<str> = Rc::<str>::from(format!("{}{}", v53, v54));
            let mut v56: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let mut v57: Rc<str> = Rc::<str>::from(format!("{}{}", v55, v56));
            let mut v58: Rc<str> = Rc::<str>::from(format!("{}{}", v57, v50));
            let mut v59: Rc<str> = method86(v45.clone());
            let mut v60: Rc<str> = Rc::<str>::from(format!("{}{}", v58, v59));
            let mut v61: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v62: Rc<str> = Rc::<str>::from(format!("{}{}", v61, v60));
            let mut v63: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let mut v64: Rc<str> = Rc::<str>::from(format!("{}{}", v62, v63));
            let mut v65: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v66: Rc<str> = Rc::<str>::from(format!("{}{}", v64, v65));
            let mut v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v68: Rc<str> = Rc::<str>::from(format!("{}{}", v67, v66));
            let mut v79: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error"); } LIT.with(|lit| lit.clone()) };
            let mut v80: Rc<str> = Rc::<str>::from(format!("{}{}", v79, v68));
            v80.clone()
        }
        US6::US6_0(v1, v2) => {
            let mut v1: u8 = *v1;
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
    }
}
fn method83(mut v0: US6) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    method16(v2.clone());
    method84(v2.clone());
    method18(v2.clone());
    let mut v4: Rc<str> = method85(v0.clone());
    method9(v2.clone(), v4.clone());
    method19(v2.clone());
    let mut v5: Rc<str> = v2.borrow().l0.clone();
    v5.clone()
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
        US0::US0_1 => {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_0(v17) => {
            let mut v17: std::string::String = v17.clone();
            v17.clone()
        }
    };
    let mut v22: Rc<str> = Rc::<str>::from(String::as_str(&v20));
    let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v24); };
    let mut v26: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v27, mut v28, mut v29, mut v30, mut v31, mut v32): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v33: US3 = v31.borrow().l0.clone();
    let mut v38: i32 = match &v33 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
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
        let mut v55: Rc<str> = method26(v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone(), v22.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v58, mut v59, mut v60, mut v61, mut v62, mut v63): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v64: i64 = v58.borrow().l0.clone();
        let mut v65: i64 = v64.wrapping_add(1i64);
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
    let mut v90: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v22);
    let mut v92: Vec<u8> = v90?;
    let mut v93: u8 = 1u8;
    let mut v94: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method29(v92.clone(), v93);
    let mut v96: US6 = v94.await;
    { let _ = spiral_trace_hold(&v24); };
    let (mut v99, mut v100, mut v101, mut v102, mut v103, mut v104): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v105: US3 = v103.borrow().l0.clone();
    let mut v110: i32 = match &v105 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v111: bool = v101.borrow().l0.clone();
    let mut v112: bool = v111 == false;
    let mut v114: bool = if v112 {
        false
    } else {
        let mut v113: bool = 10i32 >= v110;
        v113
    };
    let mut v115: bool = v114 == false;
    let mut v160: US4 = if v115 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v24); };
        let (mut v119, mut v120, mut v121, mut v122, mut v123, mut v124): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v125: Rc<str> = method6(v119.clone(), v120.clone(), v121.clone(), v122.clone(), v123.clone(), v124.clone());
        let mut v126: Rc<str> = method7();
        let mut v127: Rc<str> = method82(v119.clone(), v120.clone(), v121.clone(), v122.clone(), v123.clone(), v124.clone(), v125.clone(), v126.clone(), v96.clone());
        { let _ = spiral_trace_hold(&v24); };
        let (mut v130, mut v131, mut v132, mut v133, mut v134, mut v135): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
        let mut v136: i64 = v130.borrow().l0.clone();
        let mut v137: i64 = v136.wrapping_add(1i64);
        v130.borrow_mut().l0 = v137;
        let mut v138: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v139: bool = cfg!(target_arch = "wasm32");
        if v139 {
            let mut v140: Rc<str> = v133.borrow().l0.clone();
            let mut v141: bool = v140.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v149: Rc<str> = if v141 {
                v127.clone()
            } else {
                let mut v142: bool = v127.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v142 {
                    let mut v143: Rc<str> = v133.borrow().l0.clone();
                    v143.clone()
                } else {
                    let mut v144: Rc<str> = v133.borrow().l0.clone();
                    let mut v145: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v146: Rc<str> = Rc::<str>::from(format!("{}{}", v144, v145));
                    let mut v147: Rc<str> = Rc::<str>::from(format!("{}{}", v146, v127));
                    v147.clone()
                }
            };
            let mut v151: i32 = ((v149.chars().count() + 14999) / 15000) as i32;
            let mut v152: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v153: bool = v127 != v152 ;
            let mut v155: bool = if v153 {
                let mut v154: bool = v151 <= 1i32;
                v154
            } else {
                false
            };
            if v155 {
                v133.borrow_mut().l0 = v149.clone();
                ()
            } else {
                v133.borrow_mut().l0 = v152.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v149); };
                ()
            }
        } else {
            println!("{}", v127);
            ()
        };
        let mut v158: Rc<dyn Fn(Rc<str>) -> ()> = v131.borrow().l0.clone();
        v158(v127.clone());
        US4::US4_0(v130.clone(), v131.clone(), v132.clone(), v133.clone(), v134.clone(), v135.clone())
    };
    let mut v173: Result<u8, anyhow::Error> = match &v96 {
        US6::US6_1(v165, v166) => {
            let mut v165: u8 = *v165;
            let mut v166: US5 = v166.clone();
            let mut v167: Rc<str> = method87(v96.clone(), v166.clone());
            let mut v169: anyhow::Error = anyhow::anyhow!("{}", v167);
            let mut v171: Result<u8, anyhow::Error> = Err(v169);
            v171
        }
        US6::US6_0(v161, v162) => {
            let mut v161: u8 = *v161;
            let mut v162: US5 = v162.clone();
            let mut v164: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v161);
            v164
        }
    };
    let mut v175: bool = true; (v173) }); //;
    let mut v177: _ = __future_init;
    let mut v179: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v177;
    v179
}
fn closure16() -> Rc<dyn Fn(u8) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US8> = Rc::new(move |mut v0: u8| -> US8 {
        US8::US8_0(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method88() -> Rc<dyn Fn(u8) -> US8> {
    closure16()
}
fn closure17() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_1(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
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
        US0::US0_1 => {
            US1::US1_1
        }
        US0::US0_0(v27) => {
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
                let mut v58: i32 = v57.wrapping_neg();
                let mut v59: i32 = v58.wrapping_add(v53);
                let mut v60: i32 = v59.wrapping_sub(1i32);
                let mut v61: US2 = v55.borrow().l1.clone();
                let (mut v62, mut v63): (Rc<str>, US3) = v52.clone().borrow()[v60 as usize].clone();
                let mut v70: US2 = match &v61 {
                    US2::US2_1 => {
                        let mut v65: bool = v62 == v29 ;
                        if v65 {
                            US2::US2_0(v63.clone())
                        } else {
                            US2::US2_1
                        }
                    }
                    US2::US2_0(v64) => {
                        let mut v64: US3 = v64.clone();
                        v61.clone()
                    }
                };
                let mut v71: i32 = v57.wrapping_add(1i32);
                v55.borrow_mut().l0 = v71;
                v55.borrow_mut().l1 = v70.clone();
                ()
            };
            let mut v72: US2 = v55.borrow().l1.clone();
            US1::US1_0(v72.clone())
        }
    };
    let mut v83: US2 = match &v76 {
        US1::US1_0(v77) => {
            let mut v77: US2 = v77.clone();
            match &v77 {
                US2::US2_0(v78) => {
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
        US2::US2_1 => {
            US3::US3_0
        }
        US2::US2_0(v84) => {
            let mut v84: US3 = v84.clone();
            v84.clone()
        }
    };
    let mut v97: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure2(v87.clone());
    { let _ = spiral_trace_hold(&v97); };
    let mut v105: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure4(v87.clone());
    let (mut v106, mut v107, mut v108, mut v109, mut v110, mut v111): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v105) };
    let mut v122: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure5();
    { let _ = spiral_trace_hold(&v122); };
    let mut v130: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = closure6();
    let (mut v131, mut v132, mut v133, mut v134, mut v135, mut v136): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v130) };
    let mut v137: US3 = v135.borrow().l0.clone();
    let mut v142: i32 = match &v137 {
        US3::US3_4 => {
            50i32
        }
        US3::US3_1 => {
            20i32
        }
        US3::US3_2 => {
            30i32
        }
        US3::US3_0 => {
            10i32
        }
        US3::US3_3 => {
            40i32
        }
    };
    let mut v143: bool = v133.borrow().l0.clone();
    let mut v144: bool = v143 == false;
    let mut v146: bool = if v144 {
        false
    } else {
        let mut v145: bool = 10i32 >= v142;
        v145
    };
    let mut v147: bool = v146 == false;
    let mut v192: US4 = if v147 {
        US4::US4_1
    } else {
        { let _ = spiral_trace_hold(&v122); };
        let (mut v151, mut v152, mut v153, mut v154, mut v155, mut v156): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v130) };
        let mut v157: Rc<str> = method6(v151.clone(), v152.clone(), v153.clone(), v154.clone(), v155.clone(), v156.clone());
        let mut v158: Rc<str> = method7();
        let mut v159: Rc<str> = method10(v151.clone(), v152.clone(), v153.clone(), v154.clone(), v155.clone(), v156.clone(), v157.clone(), v158.clone(), v9.clone());
        { let _ = spiral_trace_hold(&v122); };
        let (mut v162, mut v163, mut v164, mut v165, mut v166, mut v167): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v130) };
        let mut v168: i64 = v162.borrow().l0.clone();
        let mut v169: i64 = v168.wrapping_add(1i64);
        v162.borrow_mut().l0 = v169;
        let mut v170: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v171: bool = cfg!(target_arch = "wasm32");
        if v171 {
            let mut v172: Rc<str> = v165.borrow().l0.clone();
            let mut v173: bool = v172.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v181: Rc<str> = if v173 {
                v159.clone()
            } else {
                let mut v174: bool = v159.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v174 {
                    let mut v175: Rc<str> = v165.borrow().l0.clone();
                    v175.clone()
                } else {
                    let mut v176: Rc<str> = v165.borrow().l0.clone();
                    let mut v177: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v178: Rc<str> = Rc::<str>::from(format!("{}{}", v176, v177));
                    let mut v179: Rc<str> = Rc::<str>::from(format!("{}{}", v178, v159));
                    v179.clone()
                }
            };
            let mut v183: i32 = ((v181.chars().count() + 14999) / 15000) as i32;
            let mut v184: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v185: bool = v159 != v184 ;
            let mut v187: bool = if v185 {
                let mut v186: bool = v183 <= 1i32;
                v186
            } else {
                false
            };
            if v187 {
                v165.borrow_mut().l0 = v181.clone();
                ()
            } else {
                v165.borrow_mut().l0 = v184.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v181); };
                ()
            }
        } else {
            println!("{}", v159);
            ()
        };
        let mut v190: Rc<dyn Fn(Rc<str>) -> ()> = v163.borrow().l0.clone();
        v190(v159.clone());
        US4::US4_0(v162.clone(), v163.clone(), v164.clone(), v165.clone(), v166.clone(), v167.clone())
    };
    let mut v193: Rc<str> = method20();
    let mut v195: &str = &*v193;
    let mut v197: Option<std::string::String> = clap::ArgMatches::get_one(&v12, v195).cloned();
    let mut v200: Option<std::string::String> = method2(v197.clone());
    let mut v201: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure8();
    let mut v202: Option<Rc<str>> = v200.map(|x| v201(x));
    let mut v203: Option<Rc<str>> = method23(v202.clone());
    let mut v204: Rc<dyn Fn((Rc<str>)) -> US5> = closure9();
    let mut v205: Option<US5> = v203.map(|x| v204(x));
    let mut v206: US5 = US5::US5_1;
    let mut v207: US5 = v205.unwrap_or(v206);
    let mut v208: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = method24(v12.clone());
    let mut v210: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v212: Result<u8, anyhow::Error> = v210.handle().block_on(v208);
    let mut v213: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v215: Result<u8, std::string::String> = v212.map_err(|x| v213(x));
    let mut v217: Result<u8, std::string::String> = v215.clone();
    let mut v218: Rc<dyn Fn(u8) -> US8> = method88();
    let mut v219: Rc<dyn Fn(std::string::String) -> US8> = method89();
    let mut v221: US8 = match v217 { Ok(x) => v218(x), Err(e) => v219(e) };
    match &v221 {
        US8::US8_1(v228) => {
            let mut v228: std::string::String = v228.clone();
            match &v207 {
                US5::US5_0(v229) => {
                    let mut v229: Rc<str> = v229.clone();
                    let mut v230: bool = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } == v229.clone();
                    if v230 {
                        ()
                    } else {
                        let mut v232: Rc<str> = Rc::<str>::from(String::as_str(&v228));
                        let mut v234: bool = v232.contains(&*v229);
                        if v234 {
                            ()
                        } else {
                            let mut v235: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / exception: '{}' / error: {}", v229, v228));
                            let mut v237: Result<(), Rc<str>> = Err(v235);
                            v237.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let mut v240: u8 = v215.unwrap();
                    ()
                }
            }
        }
        US8::US8_0(v222) => {
            let mut v222: u8 = *v222;
            match &v207 {
                US5::US5_0(v223) => {
                    let mut v223: Rc<str> = v223.clone();
                    let mut v224: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / retries: {} / exception: '{}'", v222, v223));
                    let mut v226: Result<(), Rc<str>> = Err(v224);
                    v226.unwrap();
                    ()
                }
                _ => {
                    ()
                }
            }
        }
    }
    0
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
