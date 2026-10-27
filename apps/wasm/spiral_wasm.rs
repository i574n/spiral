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
    US0_Some(std::string::String),
    US0_None,
}
#[derive(Clone)]
enum US3 {
    US3_Verbose,
    US3_Debug,
    US3_Info,
    US3_Warning,
    US3_Critical,
}
#[derive(Clone)]
enum US2 {
    US2_Some(US3),
    US2_None,
}
#[derive(Clone)]
enum US1 {
    US1_Some(US2),
    US1_None,
}
struct Mut0 { l0: i32, l1: US2 }
struct Mut1 { l0: i64 }
struct Mut2 { l0: Rc<dyn Fn(Rc<str>) -> ()> }
struct Mut3 { l0: bool }
struct Mut4 { l0: Rc<str> }
struct Mut5 { l0: US3 }
#[derive(Clone)]
enum US4 {
    US4_Some(Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>),
    US4_None,
}
struct Mut6 { l0: u64 }
#[derive(Clone)]
enum US5 {
    US5_Some(Rc<str>),
    US5_None,
}
#[derive(Clone)]
enum US6 {
    US6_Ok(u8, US5),
    US6_Error(u8, US5),
}
#[derive(Clone)]
enum US7 {
    US7_Ok(US5),
    US7_Error(std::string::String),
}
#[derive(Clone)]
enum US8 {
    US8_Ok(u8),
    US8_Error(std::string::String),
}
fn closure0() -> Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = Rc::new(move |mut v0: (Rc<str>)| -> clap::builder::PossibleValue {
        let v1: Rc<str> = (v0);
        let mut v3: &str = &*v1;
        let mut v5: std::string::String = String::from(v3);
        let v7: Box<std::string::String> = Box::new(v5);
        let v9: &'static mut std::string::String = Box::leak(v7);
        let mut v11: clap::builder::PossibleValue = clap::builder::PossibleValue::new(&**v9);
        v11.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn get_command_0() -> clap::Command {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("command"); } LIT.with(|lit| lit.clone()) };
    let v1: &'static str = Box::leak(String::from(&*v0).into_boxed_str());
    let mut v3: clap::Command = clap::Command::new(v1);
    let mut v5: clap::Command = clap::Command::args_override_self(v3, true);
    let v6: usize = ((0i32) as usize);
    let v7: usize = ((1i32) as usize);
    let v8: usize = ((0i32) as usize);
    let v9: bool = v7 == v8 ;
    let mut v15: clap::builder::ValueRange = if v9 {
        let mut v11: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..);
        v11.clone()
    } else {
        let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
        let mut v14: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..=v7);
        v14.clone()
    };
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    let v17: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v19: clap::Arg = clap::Arg::new(v17);
    let mut v21: clap::Arg = v19.short(b'e' as char);
    let v22: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v24: clap::Arg = v21.long(v22);
    let mut v26: clap::Arg = v24.num_args(v15);
    let mut v28: clap::Arg = v26.require_equals(true);
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v30: &str = (&*v29);
    let v32: clap::Arg = v28.default_missing_value(&*Box::leak(String::from(v30).into_boxed_str()));
    let v34: clap::Command = clap::Command::arg(v5, v32);
    let v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    let v36: &'static str = Box::leak(String::from(&*v35).into_boxed_str());
    let mut v38: clap::Arg = clap::Arg::new(v36);
    let mut v40: clap::Arg = v38.short(b't' as char);
    let v41: &'static str = Box::leak(String::from(&*v35).into_boxed_str());
    let mut v43: clap::Arg = v40.long(v41);
    ;
    ;
    ;
    ;
    ;
    let mut v44: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let v45: Rc<str> = Rc::<str>::from(v44.to_lowercase());
    let v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let v47: Rc<str> = Rc::<str>::from(v46.to_lowercase());
    let v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let v49: Rc<str> = Rc::<str>::from(v48.to_lowercase());
    let v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let v51: Rc<str> = Rc::<str>::from(v50.to_lowercase());
    let v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v53: Rc<str> = Rc::<str>::from(v52.to_lowercase());
    let mut v54: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v54.borrow_mut().push(v53);
    v54.borrow_mut().push(v51);
    v54.borrow_mut().push(v49);
    v54.borrow_mut().push(v47);
    v54.borrow_mut().push(v45);
    let mut v55: Rc<Vec<Rc<str>>> = Rc::new(v54.borrow().clone());
    let mut v56: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v55).as_ref().clone()));
    let v57: Vec<Rc<str>> = (v56).borrow().clone();
    let mut v59: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v60: Vec<clap::builder::PossibleValue> = v57.iter().map(|x| v59(x.clone())).collect::<Vec<_>>();
    let v62: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v60));
    let v64: clap::Arg = v43.value_parser(v62);
    let v66: clap::Command = clap::Command::arg(v34, v64);
    let v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let v68: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v70: clap::Arg = clap::Arg::new(v68);
    let mut v72: clap::Arg = v70.short(b'w' as char);
    let mut v73: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v75: clap::Arg = v72.long(v73);
    let v77: clap::Arg = v75.required(true);
    let v79: clap::Command = clap::Command::arg(v66, v77);
    v79.clone()
}
fn method1() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method2(mut v0: Option<std::string::String>) -> Option<std::string::String> {
    v0
}
fn closure1() -> Rc<dyn Fn((std::string::String)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> US0> = Rc::new(move |mut v0: (std::string::String)| -> US0 {
        let v1: std::string::String = (v0);
        US0::US0_Some(v1.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method3(mut v0: Rc<RefCell<Mut0>>) -> bool {
    let v1: i32 = v0.borrow().l0.clone();
    let v2: bool = v1 > 0i32;
    v2
}
fn get_environment_variable_5(mut v0: Rc<str>) -> Rc<str> {
    let v1: Rc<str> = Rc::<str>::from(std::env::var(&*v0).unwrap_or_default());
    v1
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn new_trace_state_4(mut v0: US3) -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("TRACE_LEVEL"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = get_environment_variable_5(v1.clone());
    ;
    ;
    ;
    ;
    ;
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = Rc::<str>::from(v3.to_lowercase());
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let v6: Rc<str> = Rc::<str>::from(v5.to_lowercase());
    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let v8: Rc<str> = Rc::<str>::from(v7.to_lowercase());
    let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let mut v10: Rc<str> = Rc::<str>::from(v9.to_lowercase());
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(v11.to_lowercase());
    let mut v13: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
    let mut v14: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v11.clone(), v14.clone()));
    let mut v15: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v9.clone(), v15.clone()));
    let v16: US3 = US3::US3_Info;
    v13.borrow_mut().push((v7.clone(), v16.clone()));
    let v17: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v5.clone(), v17.clone()));
    let v18: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v3.clone(), v18.clone()));
    let mut v19: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v12.clone(), v19.clone()));
    let v20: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v10.clone(), v20.clone()));
    let mut v21: US3 = US3::US3_Info;
    v13.borrow_mut().push((v8.clone(), v21.clone()));
    let v22: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v6.clone(), v22.clone()));
    let v23: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v4.clone(), v23.clone()));
    let mut v24: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v13.borrow().clone());
    let v25: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v24).as_ref().clone()));
    let mut v26: i32 = (v25.clone().borrow().len() as i32);
    let v27: US2 = US2::US2_None;
    let mut v28: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v26, l1: v27.clone() }));
    while method3(v28.clone()) {
        let v30: i32 = v28.borrow().l0.clone();
        let v31: i32 = v30.wrapping_sub(1i32);
        let v32: US2 = v28.borrow().l1.clone();
        let (mut v33, mut v34): (Rc<str>, US3) = v25.clone().borrow()[v31 as usize].clone();
        let v41: US2 = match &v32 {
            US2::US2_None => {
                let v36: bool = v33 == v2 ;
                if v36 {
                    US2::US2_Some(v34.clone())
                } else {
                    US2::US2_None
                }
            }
            US2::US2_Some(v35) => {
                let v35: US3 = v35.clone();
                v32.clone()
            }
        };
        v28.borrow_mut().l0 = v31;
        v28.borrow_mut().l1 = v41.clone();
        ()
    };
    let v42: US2 = v28.borrow().l1.clone();
    let mut v43: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: 1i64 }));
    let mut v44: Rc<dyn Fn(Rc<str>) -> ()> = closure3();
    let v45: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: v44.clone() }));
    let v46: Rc<RefCell<Mut3>> = Rc::new(RefCell::new(Mut3 { l0: true }));
    let v47: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v48: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v47.clone() }));
    let v51: US3 = match &v42 {
        US2::US2_None => {
            v0.clone()
        }
        US2::US2_Some(v49) => {
            let v49: US3 = v49.clone();
            v49.clone()
        }
    };
    let v52: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v51.clone() }));
    let mut v53: Option<i64> = None;
    (v43.clone(), v45.clone(), v46.clone(), v48.clone(), v52.clone(), v53.clone())
}
fn fresh_c2(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    })
}
fn fresh_c4(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    })
}
fn fresh_c5() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn fresh_c6() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1.clone(), v2.clone(), v3.clone(), v4.clone(), v5.clone(), v6.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method6(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>) -> Rc<str> {
    let v6: u64 = { #[cfg(target_arch = "wasm32")] let (h, m, s) = { let secs = near_sdk::env::block_timestamp() / 1_000_000_000; ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; #[cfg(all(windows, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C)] struct St([u16; 8]); unsafe extern "system" { fn GetLocalTime(t: *mut St); } let mut t = St([0; 8]); unsafe { GetLocalTime(&mut t) }; (t.0[4] as u64, t.0[5] as u64, t.0[6] as u64) }; #[cfg(all(unix, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C, align(8))] struct Tm([i32; 16]); unsafe extern "C" { fn localtime_r(t: *const std::os::raw::c_long, tm: *mut Tm) -> *mut Tm; } let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0) as std::os::raw::c_long; let mut tm = Tm([0; 16]); unsafe { localtime_r(&secs, &mut tm) }; (tm.0[2] as u64, tm.0[1] as u64, tm.0[0] as u64) }; #[cfg(not(any(windows, unix, target_arch = "wasm32")))] let (h, m, s) = { let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0); ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; h * 3600 + m * 60 + s };
    let v7: u64 = v6.wrapping_div(3600u64);
    let v8: bool = v7 < 10u64;
    let mut v11: Rc<str> = if v8 {
        let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v9.clone()
    } else {
        let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v10.clone()
    };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, Rc::<str>::from(format!("{:?}", v7))));
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let v16: u64 = v6.wrapping_div(60u64);
    let v17: u64 = v16.wrapping_rem(60u64);
    let v18: bool = v17 < 10u64;
    let mut v21: Rc<str> = if v18 {
        let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v19.clone()
    } else {
        let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v20.clone()
    };
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v15, Rc::<str>::from(format!("{}{}", v21, Rc::<str>::from(format!("{:?}", v17)))))), v14));
    let mut v26: u64 = v6.wrapping_rem(60u64);
    let v27: bool = v26 < 10u64;
    let v30: Rc<str> = if v27 {
        let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v28.clone()
    } else {
        let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v29.clone()
    };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", v25, Rc::<str>::from(format!("{}{}", v30, Rc::<str>::from(format!("{:?}", v26))))));
    v33.clone()
}
fn method9(mut v0: Rc<RefCell<Mut4>>, mut v1: Rc<str>) -> () {
    let v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, v1));
    v0.borrow_mut().l0 = v3;
    ()
}
fn format_real_8(mut v0: u8) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
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
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
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
                let v6: bool = v4 == b'\t';
                if v6 {
                    true
                } else {
                    let v7: bool = v4 == b'\r';
                    if v7 {
                        true
                    } else {
                        let v8: bool = v4 == b'\n';
                        v8
                    }
                }
            };
            if v11 {
                let v12: i32 = v2.wrapping_add(1i32);
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
        let v2: bool = v1 <= 0i32;
        if v2 {
            return -1i32;
        } else {
            let mut v3: i32 = v1.wrapping_sub(1i32);
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v5: bool = v4 == b' ';
            let v7: bool = if v5 {
                true
            } else {
                let v6: bool = v4 == b'/';
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
    let v1: i32 = (v0.clone().len() as i32);
    let v2: i32 = 0i32;
    let mut v3: i32 = method12(v0.clone(), v1, v2);
    let mut v4: i32 = v1.wrapping_sub(1i32);
    let mut v5: Rc<str> = string_slice(&v0, v3 as i64, v4 as i64);
    let v6: i32 = (v5.clone().len() as i32);
    let v7: i32 = method13(v5.clone(), v6);
    let v8: Rc<str> = string_slice(&v5, 0i32 as i64, v7 as i64);
    v8
}
fn format_real_14(mut v0: i64) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method16(mut v0: u64, mut v1: Rc<RefCell<Mut6>>) -> bool {
    let v2: u64 = v1.borrow().l0.clone();
    let mut v3: bool = v2 < v0;
    v3
}
fn method15(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let v1: u64 = (v0.clone().borrow().len() as u64);
    let v2: u64 = 0u64;
    let mut v3: Rc<RefCell<Mut6>> = Rc::new(RefCell::new(Mut6 { l0: v2 }));
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v4.clone() }));
    while method16(v1, v3.clone()) {
        let v7: u64 = v3.borrow().l0.clone();
        let v8: Rc<str> = v0.clone().borrow()[v7 as usize].clone();
        let v9: bool = v7 == 0u64;
        let mut v14: Rc<str> = if v9 {
            v8.clone()
        } else {
            let mut v10: Rc<str> = v5.borrow().l0.clone();
            let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(", "); } LIT.with(|lit| lit.clone()) };
            let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v10, v11)), v8));
            v13.clone()
        };
        v5.borrow_mut().l0 = v14.clone();
        let mut v15: u64 = v7.wrapping_add(1u64);
        v3.borrow_mut().l0 = v15;
        ()
    };
    let v16: Rc<str> = v5.borrow().l0.clone();
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("["); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v16));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("]"); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    v20.clone()
}
fn method10(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.main"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("args"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("args"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("args = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = method15(v8.clone());
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v27));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v29, v30))));
    method11(v32.clone())
}
fn closure7() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method17() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method18(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v2 >= v1;
        if v3 {
            return v1;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v5: bool = v4 == b'\\';
            if v5 {
                let v6: i32 = v2.wrapping_add(1i32);
                (v0, v1, v2) = (v0.clone(), v1, v6);
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn method19(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let v2: bool = v1 <= 0i32;
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
        let v1: std::string::String = (v0);
        let mut v3: Rc<str> = Rc::<str>::from(String::as_str(&v1));
        let mut v4: i32 = (v3.clone().len() as i32);
        let mut v5: i32 = 0i32;
        let v6: i32 = method18(v3.clone(), v4, v5);
        let v7: i32 = v4.wrapping_sub(1i32);
        let v8: Rc<str> = string_slice(&v3.clone(), v6 as i64, v7 as i64);
        let v9: i32 = (v8.clone().len() as i32);
        let mut v10: i32 = method19(v8.clone(), v9);
        let mut v11: Rc<str> = string_slice(&v8.clone(), 0i32 as i64, v10 as i64);
        v11.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method20(mut v0: Option<Rc<str>>) -> Option<Rc<str>> {
    v0
}
fn closure9() -> Rc<dyn Fn((Rc<str>)) -> US5> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> US5> = Rc::new(move |mut v0: (Rc<str>)| -> US5 {
        let v1: Rc<str> = (v0);
        US5::US5_Some(v1.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method22() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    v0.clone()
}
fn method23(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<str>) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm_path"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm_path"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v23, v24)), v8));
    let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v27, v26));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v28, v29))));
    method11(v31.clone())
}
fn format_real_27(mut v0: u8) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method26(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v10: near_workspaces::Contract) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0.clone();
    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v12));
    let mut v14: Rc<str> = format_real_14(v11);
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v13, v14)), v7)), v12));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
    let mut v28: Rc<str> = format_real_27(v8);
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v27, v28));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", v29, v30));
    let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("worker"); } LIT.with(|lit| lit.clone()) };
    let v34: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v31, v32)), v26));
    let v35: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Worker<near_workspaces::network::Sandbox>>") } } (&&W(&v9)).s() });
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v34, v35)), v30));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("contract"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v37, v38)), v26));
    let v41: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Contract>") } } (&&W(&v10)).s() });
    let v42: Rc<str> = Rc::<str>::from(format!("{}{}", v40, v41));
    let mut v43: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", v43, v42));
    let v45: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v47: Rc<str> = Rc::<str>::from(format!("{}{}", v21, Rc::<str>::from(format!("{}{}", v44, v45))));
    method11(v47.clone())
}
fn method28(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = format_real_14(v10);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v12, v13)), v7)), v11));
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = format_real_27(v8);
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v27));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result"); } LIT.with(|lit| lit.clone()) };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v30, v31)), v25));
    let v34: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::result::ExecutionFinalResult>") } } (&&W(&v9)).s() });
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v33, v34));
    let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", v36, v35));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v20, Rc::<str>::from(format!("{}{}", v37, v38))));
    method11(v40.clone())
}
fn closure10() -> Rc<dyn Fn((&str)) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((&str)) -> std::string::String> = Rc::new(move |mut v0: (&str)| -> std::string::String {
        let v1: &str = (v0);
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
fn method29() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn position_of_32(mut v0: u8, mut v1: Rc<str>, mut v2: i32) -> i32 {
    loop {
        let mut v3: i32 = (v1.clone().len() as i32);
        let mut v4: bool = v2 >= v3;
        if v4 {
            return -1i32;
        } else {
            let mut v5: u8 = v1.clone().as_bytes()[v2 as usize];
            let v6: bool = v5 == v0;
            if v6 {
                return v2;
            } else {
                let v7: i32 = v2.wrapping_add(1i32);
                (v0, v1, v2) = (v0, v1.clone(), v7);
                continue;
            }
        }
    }
}
fn digits_value_33(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: i32 = (v0.clone().len() as i32);
        let mut v4: bool = v1 >= v3;
        if v4 {
            return v2;
        } else {
            let mut v5: i32 = v1.wrapping_add(1i32);
            let v6: i32 = v2.wrapping_mul(10i32);
            let v7: u8 = v0.clone().as_bytes()[v1 as usize];
            let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0123456789"); } LIT.with(|lit| lit.clone()) };
            let v9: i32 = 0i32;
            let mut v10: i32 = position_of_32(v7, v8.clone(), v9);
            let mut v11: i32 = v6.wrapping_add(v10);
            (v0, v1, v2) = (v0.clone(), v5, v11);
            continue;
        }
    }
}
fn zeros_from_34(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let v2: i32 = (v0.clone().len() as i32);
        let mut v3: bool = v1 < v2;
        let v6: bool = if v3 {
            let mut v4: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v5: bool = v4 == b'0';
            v5
        } else {
            false
        };
        if v6 {
            let v7: i32 = v1.wrapping_add(1i32);
            (v0, v1) = (v0.clone(), v7);
            continue;
        } else {
            return v1;
        }
    }
}
fn zeros_before_35(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let v2: bool = v1 > 0i32;
        let v6: bool = if v2 {
            let mut v3: i32 = v1.wrapping_sub(1i32);
            let mut v4: u8 = v0.clone().as_bytes()[v3 as usize];
            let mut v5: bool = v4 == b'0';
            v5
        } else {
            false
        };
        if v6 {
            let v7: i32 = v1.wrapping_sub(1i32);
            (v0, v1) = (v0.clone(), v7);
            continue;
        } else {
            return v1;
        }
    }
}
fn repeated_zeros_36(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let v2: bool = v0 <= 0i32;
        if v2 {
            return v1.clone();
        } else {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", v1.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) }));
            (v0, v1) = (v3, v4.clone());
            continue;
        }
    }
}
fn digits_text_37(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let v2: i32 = v0.wrapping_rem(10i32);
        let mut v3: i32 = v2.wrapping_add(1i32);
        let mut v4: i32 = v3.wrapping_sub(1i32);
        let mut v5: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0123456789"); } LIT.with(|lit| lit.clone()) }, v2 as i64, v4 as i64);
        let v6: bool = v0 < 10i32;
        if v6 {
            let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5.clone(), v1.clone()));
            return v7.clone();
        } else {
            let v8: i32 = v0.wrapping_div(10i32);
            let v9: Rc<str> = Rc::<str>::from(format!("{}{}", v5.clone(), v1.clone()));
            (v0, v1) = (v8, v9.clone());
            continue;
        }
    }
}
fn format_real_31(mut v0: f64) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    () /* backend_switch: no Rust arm (lib/spiral) */;
    let mut v3: bool = v0.is_nan();
    let mut v13: Rc<str> = if v3 {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("NaN"); } LIT.with(|lit| lit.clone()) };
        v4.clone()
    } else {
        () /* backend_switch: no Rust arm (lib/spiral) */;
        let mut v5: bool = v0.is_infinite();
        if v5 {
            let v6: f64 = -(v0);
            let v7: bool = v0 > v6;
            if v7 {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Infinity"); } LIT.with(|lit| lit.clone()) };
                v8.clone()
            } else {
                let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-Infinity"); } LIT.with(|lit| lit.clone()) };
                v9.clone()
            }
        } else {
            let mut v11: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
            v11.clone()
        }
    };
    let mut v14: bool = &*v13 == "NaN";
    let v16: bool = if v14 {
        true
    } else {
        let mut v15: bool = &*v13 == "Infinity";
        v15
    };
    let v18: bool = if v16 {
        true
    } else {
        let v17: bool = &*v13 == "-Infinity";
        v17
    };
    let mut v166: Rc<str> = if v18 {
        v13.clone()
    } else {
        let mut v19: i32 = (v13.clone().len() as i32);
        let v20: bool = v19 > 0i32;
        let v23: bool = if v20 {
            let mut v21: u8 = v13.clone().as_bytes()[0i32 as usize];
            let v22: bool = v21 == b'-';
            v22
        } else {
            false
        };
        let v25: Rc<str> = if v23 {
            let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-"); } LIT.with(|lit| lit.clone()) };
            v24.clone()
        } else {
            v1.clone()
        };
        let v32: Rc<str> = if v23 {
            let mut v26: i32 = v19.wrapping_sub(1i32);
            let v27: bool = v26 <= 0i32;
            if v27 {
                v1.clone()
            } else {
                let mut v28: i32 = 1i32.wrapping_add(v26);
                let mut v29: i32 = v28.wrapping_sub(1i32);
                let v30: Rc<str> = string_slice(&v13.clone(), 1i32 as i64, v29 as i64);
                v30.clone()
            }
        } else {
            v13.clone()
        };
        let v33: u8 = b'e';
        let v34: i32 = 0i32;
        let v35: i32 = position_of_32(v33, v32.clone(), v34);
        let v36: bool = v35 >= 0i32;
        let mut v40: i32 = if v36 {
            v35
        } else {
            let v37: u8 = b'E';
            let mut v38: i32 = 0i32;
            position_of_32(v37, v32.clone(), v38)
        };
        let v41: bool = v40 < 0i32;
        let v46: Rc<str> = if v41 {
            v32.clone()
        } else {
            let v42: bool = v40 <= 0i32;
            if v42 {
                v1.clone()
            } else {
                let mut v43: i32 = v40.wrapping_sub(1i32);
                let mut v44: Rc<str> = string_slice(&v32.clone(), 0i32 as i64, v43 as i64);
                v44.clone()
            }
        };
        let v74: i32 = if v41 {
            0i32
        } else {
            let v47: i32 = v40.wrapping_add(1i32);
            let v48: i32 = (v32.clone().len() as i32);
            let v49: i32 = v48.wrapping_sub(v40);
            let v50: i32 = v49.wrapping_sub(1i32);
            let v51: bool = v50 <= 0i32;
            let mut v55: Rc<str> = if v51 {
                v1.clone()
            } else {
                let v52: i32 = v47.wrapping_add(v50);
                let mut v53: i32 = v52.wrapping_sub(1i32);
                let mut v54: Rc<str> = string_slice(&v32.clone(), v47 as i64, v53 as i64);
                v54.clone()
            };
            let mut v56: i32 = (v55.clone().len() as i32);
            let v57: bool = v56 == 0i32;
            if v57 {
                0i32
            } else {
                let mut v58: u8 = v55.clone().as_bytes()[0i32 as usize];
                let mut v59: bool = v58 == b'-';
                if v59 {
                    let mut v60: i32 = 1i32;
                    let v61: i32 = 0i32;
                    let v62: i32 = digits_value_33(v55.clone(), v60, v61);
                    let mut v63: i32 = v62.wrapping_neg();
                    v63
                } else {
                    let v64: bool = v58 == b'+';
                    if v64 {
                        let v65: i32 = 1i32;
                        let v66: i32 = 0i32;
                        digits_value_33(v55.clone(), v65, v66)
                    } else {
                        let v68: i32 = 0i32;
                        let v69: i32 = 0i32;
                        digits_value_33(v55.clone(), v68, v69)
                    }
                }
            }
        };
        let mut v75: u8 = b'.';
        let v76: i32 = 0i32;
        let v77: i32 = position_of_32(v75, v46.clone(), v76);
        let v78: bool = v77 < 0i32;
        let v83: Rc<str> = if v78 {
            v46.clone()
        } else {
            let v79: bool = v77 <= 0i32;
            if v79 {
                v1.clone()
            } else {
                let v80: i32 = v77.wrapping_sub(1i32);
                let v81: Rc<str> = string_slice(&v46.clone(), 0i32 as i64, v80 as i64);
                v81.clone()
            }
        };
        let v93: Rc<str> = if v78 {
            v1.clone()
        } else {
            let mut v84: i32 = v77.wrapping_add(1i32);
            let v85: i32 = (v46.clone().len() as i32);
            let mut v86: i32 = v85.wrapping_sub(v77);
            let v87: i32 = v86.wrapping_sub(1i32);
            let v88: bool = v87 <= 0i32;
            if v88 {
                v1.clone()
            } else {
                let v89: i32 = v84.wrapping_add(v87);
                let v90: i32 = v89.wrapping_sub(1i32);
                let mut v91: Rc<str> = string_slice(&v46.clone(), v84 as i64, v90 as i64);
                v91.clone()
            }
        };
        let v94: Rc<str> = Rc::<str>::from(format!("{}{}", v83.clone(), v93.clone()));
        let mut v95: i32 = 0i32;
        let v96: i32 = zeros_from_34(v94.clone(), v95);
        let v97: i32 = (v94.clone().len() as i32);
        let v98: i32 = zeros_before_35(v94.clone(), v97);
        let v99: bool = v96 >= v98;
        if v99 {
            let v100: Rc<str> = Rc::<str>::from(format!("{}{}", v25.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0.0"); } LIT.with(|lit| lit.clone()) }));
            v100.clone()
        } else {
            let mut v101: i32 = v98.wrapping_sub(v96);
            let v102: bool = v101 <= 0i32;
            let v106: Rc<str> = if v102 {
                v1.clone()
            } else {
                let v103: i32 = v96.wrapping_add(v101);
                let v104: i32 = v103.wrapping_sub(1i32);
                let v105: Rc<str> = string_slice(&v94.clone(), v96 as i64, v104 as i64);
                v105.clone()
            };
            let v107: i32 = (v83.clone().len() as i32);
            let v108: i32 = v107.wrapping_add(v74);
            let v109: i32 = v108.wrapping_sub(v96);
            let v110: i32 = (v106.clone().len() as i32);
            let v111: i32 = v109.wrapping_sub(1i32);
            let v112: bool = -4i32 <= v111;
            let v114: bool = if v112 {
                let v113: bool = v111 < 16i32;
                v113
            } else {
                false
            };
            if v114 {
                let v115: bool = v109 <= 0i32;
                if v115 {
                    let v116: i32 = v109.wrapping_neg();
                    let v117: Rc<str> = repeated_zeros_36(v116, v1.clone());
                    let v118: Rc<str> = Rc::<str>::from(format!("{}{}", v117.clone(), v106.clone()));
                    let mut v119: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0."); } LIT.with(|lit| lit.clone()) }, v118.clone()));
                    let v120: Rc<str> = Rc::<str>::from(format!("{}{}", v25.clone(), v119.clone()));
                    v120.clone()
                } else {
                    let v121: bool = v110 <= v109;
                    if v121 {
                        let mut v122: i32 = v109.wrapping_sub(v110);
                        let v123: Rc<str> = repeated_zeros_36(v122, v1.clone());
                        let v124: Rc<str> = Rc::<str>::from(format!("{}{}", v123.clone(), { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(".0"); } LIT.with(|lit| lit.clone()) }));
                        let v125: Rc<str> = Rc::<str>::from(format!("{}{}", v106.clone(), v124.clone()));
                        let v126: Rc<str> = Rc::<str>::from(format!("{}{}", v25.clone(), v125.clone()));
                        v126.clone()
                    } else {
                        let v127: Rc<str> = string_slice(&v106.clone(), 0i32 as i64, v111 as i64);
                        let v128: i32 = v110.wrapping_sub(v109);
                        let v129: bool = v128 <= 0i32;
                        let v133: Rc<str> = if v129 {
                            v1.clone()
                        } else {
                            let v130: i32 = v109.wrapping_add(v128);
                            let v131: i32 = v130.wrapping_sub(1i32);
                            let v132: Rc<str> = string_slice(&v106.clone(), v109 as i64, v131 as i64);
                            v132.clone()
                        };
                        let v134: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) }, v133.clone()));
                        let mut v135: Rc<str> = Rc::<str>::from(format!("{}{}", v127.clone(), v134.clone()));
                        let v136: Rc<str> = Rc::<str>::from(format!("{}{}", v25.clone(), v135.clone()));
                        v136.clone()
                    }
                }
            } else {
                let v139: bool = v110 > 1i32;
                let v147: Rc<str> = if v139 {
                    let v140: i32 = v110.wrapping_sub(1i32);
                    let v141: bool = v140 <= 0i32;
                    let v145: Rc<str> = if v141 {
                        v1.clone()
                    } else {
                        let v142: i32 = 1i32.wrapping_add(v140);
                        let v143: i32 = v142.wrapping_sub(1i32);
                        let v144: Rc<str> = string_slice(&v106.clone(), 1i32 as i64, v143 as i64);
                        v144.clone()
                    };
                    let v146: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) }, v145.clone()));
                    v146.clone()
                } else {
                    v1.clone()
                };
                let v148: bool = v111 < 0i32;
                let mut v150: i32 = if v148 {
                    let v149: i32 = v111.wrapping_neg();
                    v149
                } else {
                    v111
                };
                let v151: bool = v150 < 10i32;
                let v155: Rc<str> = if v151 {
                    let v152: Rc<str> = digits_text_37(v150, v1.clone());
                    let v153: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) }, v152.clone()));
                    v153.clone()
                } else {
                    digits_text_37(v150, v1.clone())
                };
                let v158: Rc<str> = if v148 {
                    let v156: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e-"); } LIT.with(|lit| lit.clone()) };
                    v156.clone()
                } else {
                    let v157: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e+"); } LIT.with(|lit| lit.clone()) };
                    v157.clone()
                };
                let mut v159: Rc<str> = string_slice(&v106.clone(), 0i32 as i64, 0i32 as i64);
                let v160: Rc<str> = Rc::<str>::from(format!("{}{}", v158.clone(), v155.clone()));
                let v161: Rc<str> = Rc::<str>::from(format!("{}{}", v147.clone(), v160.clone()));
                let mut v162: Rc<str> = Rc::<str>::from(format!("{}{}", v159.clone(), v161.clone()));
                let mut v163: Rc<str> = Rc::<str>::from(format!("{}{}", v25.clone(), v162.clone()));
                v163.clone()
            }
        }
    };
    method9(v2.clone(), v166.clone());
    let v167: Rc<str> = v2.borrow().l0.clone();
    v167.clone()
}
fn format_real_38(mut v0: u64) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method30(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: f64, mut v10: u64) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0.clone();
    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v12));
    let mut v14: Rc<str> = format_real_14(v11);
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v13, v14)), v7)), v12));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
    let mut v28: Rc<str> = format_real_27(v8);
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v27, v28));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", v29, v30));
    let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let v34: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v31, v32)), v26));
    let v35: Rc<str> = format_real_31(v9);
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v34, v35)), v30));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v37, v38)), v26));
    let v41: Rc<str> = format_real_38(v10);
    let v42: Rc<str> = Rc::<str>::from(format!("{}{}", v40, v41));
    let mut v43: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", v43, v42));
    let v45: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v47: Rc<str> = Rc::<str>::from(format!("{}{}", v21, Rc::<str>::from(format!("{}{}", v44, v45))));
    method11(v47.clone())
}
fn format_real_40(mut v0: bool) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v5: Rc<str> = if v0 {
        let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("true"); } LIT.with(|lit| lit.clone()) };
        v3.clone()
    } else {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("false"); } LIT.with(|lit| lit.clone()) };
        v4.clone()
    };
    method9(v2.clone(), v5.clone());
    let v6: Rc<str> = v2.borrow().l0.clone();
    v6.clone()
}
fn method39(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: bool, mut v9: f64, mut v10: f64, mut v11: u64, mut v12: u128) -> Rc<str> {
    let mut v13: i64 = v0.borrow().l0.clone();
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v14));
    let v16: Rc<str> = format_real_14(v13);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v15, v16)), v7)), v14));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd / outcome"); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("is_success"); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("is_success"); } LIT.with(|lit| lit.clone()) };
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("is_success = "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = format_real_40(v8);
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", v29, v30));
    let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", v31, v32));
    let v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let v36: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v33, v34)), v28));
    let v37: Rc<str> = format_real_31(v9);
    let v39: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v36, v37)), v32));
    let mut v40: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt_usd"); } LIT.with(|lit| lit.clone()) };
    let v42: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v39, v40)), v28));
    let mut v43: Rc<str> = format_real_31(v10);
    let v45: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v42, v43)), v32));
    let v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt"); } LIT.with(|lit| lit.clone()) };
    let v48: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v45, v46)), v28));
    let v49: Rc<str> = format_real_38(v11);
    let v51: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v48, v49)), v32));
    let v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt"); } LIT.with(|lit| lit.clone()) };
    let mut v54: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v51, v52)), v28));
    let mut v55: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<u128>") } } (&&W(&v12)).s() });
    let mut v56: Rc<str> = Rc::<str>::from(format!("{}{}", v54, v55));
    let v57: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v58: Rc<str> = Rc::<str>::from(format!("{}{}", v57, v56));
    let mut v59: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v61: Rc<str> = Rc::<str>::from(format!("{}{}", v23, Rc::<str>::from(format!("{}{}", v58, v59))));
    method11(v61.clone())
}
fn closure12() -> Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = Rc::new(move |mut v0: near_workspaces::result::ExecutionOutcome| -> () {
        let v2: bool = v0.is_success();
        let mut v4: near_workspaces::types::Gas = v0.gas_burnt;
        let v6: u64 = v4.as_gas();
        let v7: f64 = (v6 as f64);
        let v8: f64 = v7 / 10000000000000000.0f64;
        let v9: f64 = v8 * 6.68f64;
        let mut v11: near_workspaces::types::NearToken = v0.tokens_burnt;
        let mut v13: u128 = v11.as_yoctonear();
        let mut v15: f64 = v13 as f64;
        let v16: f64 = v15 / 1E+24f64;
        let v17: f64 = v16 * 6.68f64;
        let mut v19: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v19); };
        let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v22, mut v23, mut v24, mut v25, mut v26, mut v27): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
        let mut v28: US3 = v26.borrow().l0.clone();
        let v33: i32 = match &v28 {
            US3::US3_Critical => {
                50i32
            }
            US3::US3_Debug => {
                20i32
            }
            US3::US3_Info => {
                30i32
            }
            US3::US3_Verbose => {
                10i32
            }
            US3::US3_Warning => {
                40i32
            }
        };
        let v34: bool = v24.borrow().l0.clone();
        let v35: bool = v34 == false;
        let v37: bool = if v35 {
            false
        } else {
            let v36: bool = 30i32 >= v33;
            v36
        };
        let mut v38: bool = v37 == false;
        let mut v86: US4 = if v38 {
            US4::US4_None
        } else {
            { let _ = spiral_trace_hold(&v19); };
            let (mut v42, mut v43, mut v44, mut v45, mut v46, mut v47): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
            let v48: Rc<str> = method6(v42.clone(), v43.clone(), v44.clone(), v45.clone(), v46.clone(), v47.clone());
            let v49: Rc<str> = method29();
            let v50: Rc<str> = method39(v42.clone(), v43.clone(), v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v2, v9, v17, v6, v13.clone());
            { let _ = spiral_trace_hold(&v19); };
            let (mut v53, mut v54, mut v55, mut v56, mut v57, mut v58): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
            let mut v59: i64 = v53.borrow().l0.clone();
            let mut v60: i64 = v59.wrapping_add(1i64);
            v53.borrow_mut().l0 = v60;
            let v61: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
            let v62: bool = cfg!(target_arch = "wasm32");
            if v62 {
                let mut v63: Rc<str> = v56.borrow().l0.clone();
                let v64: bool = &*v63 == "";
                let mut v72: Rc<str> = if v64 {
                    v50.clone()
                } else {
                    let v65: bool = &*v50 == "";
                    if v65 {
                        let v66: Rc<str> = v56.borrow().l0.clone();
                        v66.clone()
                    } else {
                        let v67: Rc<str> = v56.borrow().l0.clone();
                        let v68: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                        let mut v70: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v67, v68)), v50));
                        v70.clone()
                    }
                };
                let v74: usize = v72.chars().count();
                let mut v75: i32 = ((v74) as i32);
                let v76: i32 = v75.wrapping_add(14999i32);
                let v77: i32 = v76.wrapping_div(15000i32);
                let v78: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let v79: bool = v50 != v78 ;
                let v81: bool = if v79 {
                    let v80: bool = v77 <= 1i32;
                    v80
                } else {
                    false
                };
                if v81 {
                    v56.borrow_mut().l0 = v72.clone();
                    ()
                } else {
                    v56.borrow_mut().l0 = v78.clone();
                    { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v72); };
                    ()
                }
            } else {
                println!("{}", v50);
                ()
            };
            let mut v84: Rc<dyn Fn(Rc<str>) -> ()> = v54.borrow().l0.clone();
            v84(v50.clone());
            US4::US4_Some(v53.clone(), v54.clone(), v55.clone(), v56.clone(), v57.clone(), v58.clone())
        };
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method41(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result2"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result2"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result2 = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>>") } } (&&W(&v8)).s() });
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v27));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v29, v30))));
    method11(v32.clone())
}
fn method42(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn format_real_44(mut v0: i32) -> Rc<str> {
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method9(v2.clone(), v3.clone());
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4.clone()
}
fn method43(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = format_real_14(v10);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v12, v13)), v7)), v11));
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures_len"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures_len"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures_len = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = format_real_44(v8);
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v27));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures"); } LIT.with(|lit| lit.clone()) };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v30, v31)), v25));
    let v34: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v9)).s() });
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v33, v34));
    let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", v36, v35));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v20, Rc::<str>::from(format!("{}{}", v37, v38))));
    method11(v40.clone())
}
fn method45(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn method46(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = format_real_14(v10);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v12, v13)), v7)), v11));
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = format_real_44(v8);
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v27));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes"); } LIT.with(|lit| lit.clone()) };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v30, v31)), v25));
    let v34: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v9)).s() });
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v33, v34));
    let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", v36, v35));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v20, Rc::<str>::from(format!("{}{}", v37, v38))));
    method11(v40.clone())
}
fn method47(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("json"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("json"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("json = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v8)).s() });
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v27));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v29, v30))));
    method11(v32.clone())
}
fn method48(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("borsh"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("borsh"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("borsh = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v8)).s() });
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v27));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v29, v30))));
    method11(v32.clone())
}
fn fn_25(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let v9: Result<near_workspaces::Worker<near_workspaces::network::Sandbox>, near_workspaces::error::Error> = near_workspaces::sandbox().await;
    let mut v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
    let mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox> = v11.clone();
    let mut v15: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::Contract, near_workspaces::error::Error>>>> = Box::pin(v13.dev_deploy(&v0));
    let v17: Result<near_workspaces::Contract, near_workspaces::error::Error> = v15.await;
    let mut v19: near_workspaces::Contract = v17?;
    let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v21); };
    let v23: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v24, mut v25, mut v26, mut v27, mut v28, mut v29): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v30: US3 = v28.borrow().l0.clone();
    let v35: i32 = match &v30 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v36: bool = v26.borrow().l0.clone();
    let v37: bool = v36 == false;
    let v39: bool = if v37 {
        false
    } else {
        let mut v38: bool = 10i32 >= v35;
        v38
    };
    let mut v40: bool = v39 == false;
    let v88: US4 = if v40 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v44, mut v45, mut v46, mut v47, mut v48, mut v49): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v50: Rc<str> = method6(v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone());
        let v51: Rc<str> = method7();
        let v52: Rc<str> = method26(v44.clone(), v45.clone(), v46.clone(), v47.clone(), v48.clone(), v49.clone(), v50.clone(), v51.clone(), v1, v11.clone(), v19.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v55, mut v56, mut v57, mut v58, mut v59, mut v60): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v61: i64 = v55.borrow().l0.clone();
        let v62: i64 = v61.wrapping_add(1i64);
        v55.borrow_mut().l0 = v62;
        let mut v63: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v64: bool = cfg!(target_arch = "wasm32");
        if v64 {
            let v65: Rc<str> = v58.borrow().l0.clone();
            let v66: bool = &*v65 == "";
            let v74: Rc<str> = if v66 {
                v52.clone()
            } else {
                let v67: bool = &*v52 == "";
                if v67 {
                    let v68: Rc<str> = v58.borrow().l0.clone();
                    v68.clone()
                } else {
                    let v69: Rc<str> = v58.borrow().l0.clone();
                    let mut v70: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v72: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v69, v70)), v52));
                    v72.clone()
                }
            };
            let v76: usize = v74.chars().count();
            let v77: i32 = ((v76) as i32);
            let v78: i32 = v77.wrapping_add(14999i32);
            let v79: i32 = v78.wrapping_div(15000i32);
            let v80: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v81: bool = v52 != v80 ;
            let v83: bool = if v81 {
                let v82: bool = v79 <= 1i32;
                v82
            } else {
                false
            };
            if v83 {
                v58.borrow_mut().l0 = v74.clone();
                ()
            } else {
                v58.borrow_mut().l0 = v80.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v74); };
                ()
            }
        } else {
            println!("{}", v52);
            ()
        };
        let mut v86: Rc<dyn Fn(Rc<str>) -> ()> = v56.borrow().l0.clone();
        v86(v52.clone());
        US4::US4_Some(v55.clone(), v56.clone(), v57.clone(), v58.clone(), v59.clone(), v60.clone())
    };
    let v90: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v91: near_workspaces::operations::CallTransaction = v19.call(&*v90);
    let v93: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v95: near_workspaces::operations::CallTransaction = v91.gas(v93);
    let v97: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v95.transact());
    let v99: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v97.await;
    let mut v101: near_workspaces::result::ExecutionFinalResult = v99?;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v104, mut v105, mut v106, mut v107, mut v108, mut v109): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v110: US3 = v108.borrow().l0.clone();
    let v115: i32 = match &v110 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v116: bool = v106.borrow().l0.clone();
    let v117: bool = v116 == false;
    let mut v119: bool = if v117 {
        false
    } else {
        let v118: bool = 10i32 >= v115;
        v118
    };
    let v120: bool = v119 == false;
    let v168: US4 = if v120 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v124, mut v125, mut v126, mut v127, mut v128, mut v129): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v130: Rc<str> = method6(v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone());
        let v131: Rc<str> = method7();
        let v132: Rc<str> = method28(v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone(), v130.clone(), v131.clone(), v1, v101.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v135, mut v136, mut v137, mut v138, mut v139, mut v140): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v141: i64 = v135.borrow().l0.clone();
        let v142: i64 = v141.wrapping_add(1i64);
        v135.borrow_mut().l0 = v142;
        let v143: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v144: bool = cfg!(target_arch = "wasm32");
        if v144 {
            let v145: Rc<str> = v138.borrow().l0.clone();
            let v146: bool = &*v145 == "";
            let v154: Rc<str> = if v146 {
                v132.clone()
            } else {
                let v147: bool = &*v132 == "";
                if v147 {
                    let v148: Rc<str> = v138.borrow().l0.clone();
                    v148.clone()
                } else {
                    let v149: Rc<str> = v138.borrow().l0.clone();
                    let mut v150: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v152: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v149, v150)), v132));
                    v152.clone()
                }
            };
            let v156: usize = v154.chars().count();
            let v157: i32 = ((v156) as i32);
            let v158: i32 = v157.wrapping_add(14999i32);
            let mut v159: i32 = v158.wrapping_div(15000i32);
            let v160: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v161: bool = v132 != v160 ;
            let mut v163: bool = if v161 {
                let mut v162: bool = v159 <= 1i32;
                v162
            } else {
                false
            };
            if v163 {
                v138.borrow_mut().l0 = v154.clone();
                ()
            } else {
                v138.borrow_mut().l0 = v160.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v154); };
                ()
            }
        } else {
            println!("{}", v132);
            ()
        };
        let mut v166: Rc<dyn Fn(Rc<str>) -> ()> = v136.borrow().l0.clone();
        v166(v132.clone());
        US4::US4_Some(v135.clone(), v136.clone(), v137.clone(), v138.clone(), v139.clone(), v140.clone())
    };
    let mut v170: Vec<&str> = v101.logs();
    let mut v172: Rc<dyn Fn((&str)) -> std::string::String> = closure10();
    let mut v173: Vec<std::string::String> = v170.iter().map(|x| v172(x.clone())).collect::<Vec<_>>();
    let mut v175: Rc<dyn Fn(std::string::String) -> ()> = closure11();
    let v176: bool = true; v173.iter().for_each(|x| { v175(x.clone()); }); //;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v179, mut v180, mut v181, mut v182, mut v183, mut v184): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v185: US3 = v183.borrow().l0.clone();
    let mut v190: i32 = match &v185 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v191: bool = v181.borrow().l0.clone();
    let v192: bool = v191 == false;
    let v194: bool = if v192 {
        false
    } else {
        let v193: bool = 30i32 >= v190;
        v193
    };
    let v195: bool = v194 == false;
    let v233: US4 = if v195 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v199, mut v200, mut v201, mut v202, mut v203, mut v204): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v205: i64 = v199.borrow().l0.clone();
        let v206: i64 = v205.wrapping_add(1i64);
        v199.borrow_mut().l0 = v206;
        let v207: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let v208: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v209: bool = cfg!(target_arch = "wasm32");
        if v209 {
            let v210: Rc<str> = v202.borrow().l0.clone();
            let v211: bool = &*v210 == "";
            let v219: Rc<str> = if v211 {
                v207.clone()
            } else {
                let v212: bool = &*v207 == "";
                if v212 {
                    let v213: Rc<str> = v202.borrow().l0.clone();
                    v213.clone()
                } else {
                    let v214: Rc<str> = v202.borrow().l0.clone();
                    let mut v215: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v217: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v214, v215)), v207));
                    v217.clone()
                }
            };
            let v221: usize = v219.chars().count();
            let v222: i32 = ((v221) as i32);
            let v223: i32 = v222.wrapping_add(14999i32);
            let v224: i32 = v223.wrapping_div(15000i32);
            let v225: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v226: bool = v207 != v225 ;
            let v228: bool = if v226 {
                let v227: bool = v224 <= 1i32;
                v227
            } else {
                false
            };
            if v228 {
                v202.borrow_mut().l0 = v219.clone();
                ()
            } else {
                v202.borrow_mut().l0 = v225.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v219); };
                ()
            }
        } else {
            println!("{}", v207);
            ()
        };
        let mut v231: Rc<dyn Fn(Rc<str>) -> ()> = v200.borrow().l0.clone();
        v231(v207.clone());
        US4::US4_Some(v199.clone(), v200.clone(), v201.clone(), v202.clone(), v203.clone(), v204.clone())
    };
    let mut v235: near_workspaces::types::Gas = v101.total_gas_burnt;
    let v237: u64 = v235.as_gas();
    let v238: f64 = (v237 as f64);
    let v239: f64 = v238 / 10000000000000000.0f64;
    let v240: f64 = v239 * 6.68f64;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v243, mut v244, mut v245, mut v246, mut v247, mut v248): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v249: US3 = v247.borrow().l0.clone();
    let v254: i32 = match &v249 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v255: bool = v245.borrow().l0.clone();
    let v256: bool = v255 == false;
    let v258: bool = if v256 {
        false
    } else {
        let v257: bool = 30i32 >= v254;
        v257
    };
    let v259: bool = v258 == false;
    let v307: US4 = if v259 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v263, mut v264, mut v265, mut v266, mut v267, mut v268): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v269: Rc<str> = method6(v263.clone(), v264.clone(), v265.clone(), v266.clone(), v267.clone(), v268.clone());
        let v270: Rc<str> = method29();
        let v271: Rc<str> = method30(v263.clone(), v264.clone(), v265.clone(), v266.clone(), v267.clone(), v268.clone(), v269.clone(), v270.clone(), v1, v240, v237);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v274, mut v275, mut v276, mut v277, mut v278, mut v279): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v280: i64 = v274.borrow().l0.clone();
        let v281: i64 = v280.wrapping_add(1i64);
        v274.borrow_mut().l0 = v281;
        let v282: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v283: bool = cfg!(target_arch = "wasm32");
        if v283 {
            let v284: Rc<str> = v277.borrow().l0.clone();
            let v285: bool = &*v284 == "";
            let v293: Rc<str> = if v285 {
                v271.clone()
            } else {
                let v286: bool = &*v271 == "";
                if v286 {
                    let v287: Rc<str> = v277.borrow().l0.clone();
                    v287.clone()
                } else {
                    let v288: Rc<str> = v277.borrow().l0.clone();
                    let v289: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v291: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v288, v289)), v271));
                    v291.clone()
                }
            };
            let v295: usize = v293.chars().count();
            let v296: i32 = ((v295) as i32);
            let v297: i32 = v296.wrapping_add(14999i32);
            let v298: i32 = v297.wrapping_div(15000i32);
            let v299: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v300: bool = v271 != v299 ;
            let v302: bool = if v300 {
                let v301: bool = v298 <= 1i32;
                v301
            } else {
                false
            };
            if v302 {
                v277.borrow_mut().l0 = v293.clone();
                ()
            } else {
                v277.borrow_mut().l0 = v299.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v293); };
                ()
            }
        } else {
            println!("{}", v271);
            ()
        };
        let mut v305: Rc<dyn Fn(Rc<str>) -> ()> = v275.borrow().l0.clone();
        v305(v271.clone());
        US4::US4_Some(v274.clone(), v275.clone(), v276.clone(), v277.clone(), v278.clone(), v279.clone())
    };
    let mut v309: near_workspaces::result::ExecutionFinalResult = v101.clone();
    let mut v311: Vec<&near_workspaces::result::ExecutionOutcome> = v309.outcomes();
    let v313: _ = v311.into_iter();
    let mut v315: _ = v313.cloned();
    let mut v317: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure12();
    let v318: bool = true; v315.for_each(|x| v317(x));
    let v320: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v101.clone().into_result();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v323, mut v324, mut v325, mut v326, mut v327, mut v328): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v329: US3 = v327.borrow().l0.clone();
    let v334: i32 = match &v329 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v335: bool = v325.borrow().l0.clone();
    let v336: bool = v335 == false;
    let v338: bool = if v336 {
        false
    } else {
        let v337: bool = 10i32 >= v334;
        v337
    };
    let v339: bool = v338 == false;
    let mut v387: US4 = if v339 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v343, mut v344, mut v345, mut v346, mut v347, mut v348): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v349: Rc<str> = method6(v343.clone(), v344.clone(), v345.clone(), v346.clone(), v347.clone(), v348.clone());
        let v350: Rc<str> = method7();
        let v351: Rc<str> = method41(v343.clone(), v344.clone(), v345.clone(), v346.clone(), v347.clone(), v348.clone(), v349.clone(), v350.clone(), v320.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v354, mut v355, mut v356, mut v357, mut v358, mut v359): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v360: i64 = v354.borrow().l0.clone();
        let v361: i64 = v360.wrapping_add(1i64);
        v354.borrow_mut().l0 = v361;
        let v362: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v363: bool = cfg!(target_arch = "wasm32");
        if v363 {
            let v364: Rc<str> = v357.borrow().l0.clone();
            let v365: bool = &*v364 == "";
            let v373: Rc<str> = if v365 {
                v351.clone()
            } else {
                let v366: bool = &*v351 == "";
                if v366 {
                    let v367: Rc<str> = v357.borrow().l0.clone();
                    v367.clone()
                } else {
                    let v368: Rc<str> = v357.borrow().l0.clone();
                    let v369: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v371: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v368, v369)), v351));
                    v371.clone()
                }
            };
            let v375: usize = v373.chars().count();
            let v376: i32 = ((v375) as i32);
            let v377: i32 = v376.wrapping_add(14999i32);
            let v378: i32 = v377.wrapping_div(15000i32);
            let v379: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v380: bool = v351 != v379 ;
            let v382: bool = if v380 {
                let v381: bool = v378 <= 1i32;
                v381
            } else {
                false
            };
            if v382 {
                v357.borrow_mut().l0 = v373.clone();
                ()
            } else {
                v357.borrow_mut().l0 = v379.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v373); };
                ()
            }
        } else {
            println!("{}", v351);
            ()
        };
        let mut v385: Rc<dyn Fn(Rc<str>) -> ()> = v355.borrow().l0.clone();
        v385(v351.clone());
        US4::US4_Some(v354.clone(), v355.clone(), v356.clone(), v357.clone(), v358.clone(), v359.clone())
    };
    let mut v388: near_workspaces::result::ExecutionFinalResult = method42(v101.clone());
    let v390: Vec<&near_workspaces::result::ExecutionOutcome> = v388.receipt_failures();
    let v391: usize = ((v390).len() as usize);
    let v392: i32 = (v391 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v395, mut v396, mut v397, mut v398, mut v399, mut v400): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v401: US3 = v399.borrow().l0.clone();
    let v406: i32 = match &v401 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v407: bool = v397.borrow().l0.clone();
    let v408: bool = v407 == false;
    let v410: bool = if v408 {
        false
    } else {
        let v409: bool = 10i32 >= v406;
        v409
    };
    let v411: bool = v410 == false;
    let v459: US4 = if v411 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v415, mut v416, mut v417, mut v418, mut v419, mut v420): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v421: Rc<str> = method6(v415.clone(), v416.clone(), v417.clone(), v418.clone(), v419.clone(), v420.clone());
        let v422: Rc<str> = method7();
        let v423: Rc<str> = method43(v415.clone(), v416.clone(), v417.clone(), v418.clone(), v419.clone(), v420.clone(), v421.clone(), v422.clone(), v392, v390.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v426, mut v427, mut v428, mut v429, mut v430, mut v431): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v432: i64 = v426.borrow().l0.clone();
        let v433: i64 = v432.wrapping_add(1i64);
        v426.borrow_mut().l0 = v433;
        let v434: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v435: bool = cfg!(target_arch = "wasm32");
        if v435 {
            let v436: Rc<str> = v429.borrow().l0.clone();
            let v437: bool = &*v436 == "";
            let v445: Rc<str> = if v437 {
                v423.clone()
            } else {
                let v438: bool = &*v423 == "";
                if v438 {
                    let v439: Rc<str> = v429.borrow().l0.clone();
                    v439.clone()
                } else {
                    let v440: Rc<str> = v429.borrow().l0.clone();
                    let v441: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v443: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v440, v441)), v423));
                    v443.clone()
                }
            };
            let v447: usize = v445.chars().count();
            let v448: i32 = ((v447) as i32);
            let v449: i32 = v448.wrapping_add(14999i32);
            let v450: i32 = v449.wrapping_div(15000i32);
            let v451: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v452: bool = v423 != v451 ;
            let v454: bool = if v452 {
                let v453: bool = v450 <= 1i32;
                v453
            } else {
                false
            };
            if v454 {
                v429.borrow_mut().l0 = v445.clone();
                ()
            } else {
                v429.borrow_mut().l0 = v451.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v445); };
                ()
            }
        } else {
            println!("{}", v423);
            ()
        };
        let mut v457: Rc<dyn Fn(Rc<str>) -> ()> = v427.borrow().l0.clone();
        v457(v423.clone());
        US4::US4_Some(v426.clone(), v427.clone(), v428.clone(), v429.clone(), v430.clone(), v431.clone())
    };
    let mut v460: near_workspaces::result::ExecutionFinalResult = method45(v101.clone());
    let v462: &[near_workspaces::result::ExecutionOutcome] = v460.receipt_outcomes();
    let v464: Vec<near_workspaces::result::ExecutionOutcome> = v462.into();
    let v465: usize = ((v464).len() as usize);
    let v466: i32 = (v465 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v469, mut v470, mut v471, mut v472, mut v473, mut v474): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v475: US3 = v473.borrow().l0.clone();
    let v480: i32 = match &v475 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v481: bool = v471.borrow().l0.clone();
    let v482: bool = v481 == false;
    let v484: bool = if v482 {
        false
    } else {
        let v483: bool = 10i32 >= v480;
        v483
    };
    let v485: bool = v484 == false;
    let v533: US4 = if v485 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v489, mut v490, mut v491, mut v492, mut v493, mut v494): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v495: Rc<str> = method6(v489.clone(), v490.clone(), v491.clone(), v492.clone(), v493.clone(), v494.clone());
        let v496: Rc<str> = method7();
        let v497: Rc<str> = method46(v489.clone(), v490.clone(), v491.clone(), v492.clone(), v493.clone(), v494.clone(), v495.clone(), v496.clone(), v466, v464.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v500, mut v501, mut v502, mut v503, mut v504, mut v505): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v506: i64 = v500.borrow().l0.clone();
        let v507: i64 = v506.wrapping_add(1i64);
        v500.borrow_mut().l0 = v507;
        let v508: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v509: bool = cfg!(target_arch = "wasm32");
        if v509 {
            let v510: Rc<str> = v503.borrow().l0.clone();
            let v511: bool = &*v510 == "";
            let v519: Rc<str> = if v511 {
                v497.clone()
            } else {
                let v512: bool = &*v497 == "";
                if v512 {
                    let v513: Rc<str> = v503.borrow().l0.clone();
                    v513.clone()
                } else {
                    let v514: Rc<str> = v503.borrow().l0.clone();
                    let v515: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v517: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v514, v515)), v497));
                    v517.clone()
                }
            };
            let v521: usize = v519.chars().count();
            let v522: i32 = ((v521) as i32);
            let v523: i32 = v522.wrapping_add(14999i32);
            let v524: i32 = v523.wrapping_div(15000i32);
            let v525: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v526: bool = v497 != v525 ;
            let v528: bool = if v526 {
                let v527: bool = v524 <= 1i32;
                v527
            } else {
                false
            };
            if v528 {
                v503.borrow_mut().l0 = v519.clone();
                ()
            } else {
                v503.borrow_mut().l0 = v525.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v519); };
                ()
            }
        } else {
            println!("{}", v497);
            ()
        };
        let mut v531: Rc<dyn Fn(Rc<str>) -> ()> = v501.borrow().l0.clone();
        v531(v497.clone());
        US4::US4_Some(v500.clone(), v501.clone(), v502.clone(), v503.clone(), v504.clone(), v505.clone())
    };
    let mut v535: near_workspaces::result::ExecutionFinalResult = v101.clone();
    let v537: Result<std::string::String, near_workspaces::error::Error> = v535.json();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v540, mut v541, mut v542, mut v543, mut v544, mut v545): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v546: US3 = v544.borrow().l0.clone();
    let v551: i32 = match &v546 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v552: bool = v542.borrow().l0.clone();
    let v553: bool = v552 == false;
    let v555: bool = if v553 {
        false
    } else {
        let v554: bool = 10i32 >= v551;
        v554
    };
    let v556: bool = v555 == false;
    let v604: US4 = if v556 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v560, mut v561, mut v562, mut v563, mut v564, mut v565): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v566: Rc<str> = method6(v560.clone(), v561.clone(), v562.clone(), v563.clone(), v564.clone(), v565.clone());
        let v567: Rc<str> = method7();
        let v568: Rc<str> = method47(v560.clone(), v561.clone(), v562.clone(), v563.clone(), v564.clone(), v565.clone(), v566.clone(), v567.clone(), v537);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v571, mut v572, mut v573, mut v574, mut v575, mut v576): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v577: i64 = v571.borrow().l0.clone();
        let v578: i64 = v577.wrapping_add(1i64);
        v571.borrow_mut().l0 = v578;
        let v579: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v580: bool = cfg!(target_arch = "wasm32");
        if v580 {
            let v581: Rc<str> = v574.borrow().l0.clone();
            let v582: bool = &*v581 == "";
            let v590: Rc<str> = if v582 {
                v568.clone()
            } else {
                let v583: bool = &*v568 == "";
                if v583 {
                    let v584: Rc<str> = v574.borrow().l0.clone();
                    v584.clone()
                } else {
                    let v585: Rc<str> = v574.borrow().l0.clone();
                    let v586: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v588: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v585, v586)), v568));
                    v588.clone()
                }
            };
            let v592: usize = v590.chars().count();
            let v593: i32 = ((v592) as i32);
            let v594: i32 = v593.wrapping_add(14999i32);
            let v595: i32 = v594.wrapping_div(15000i32);
            let v596: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v597: bool = v568 != v596 ;
            let v599: bool = if v597 {
                let v598: bool = v595 <= 1i32;
                v598
            } else {
                false
            };
            if v599 {
                v574.borrow_mut().l0 = v590.clone();
                ()
            } else {
                v574.borrow_mut().l0 = v596.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v590); };
                ()
            }
        } else {
            println!("{}", v568);
            ()
        };
        let mut v602: Rc<dyn Fn(Rc<str>) -> ()> = v572.borrow().l0.clone();
        v602(v568.clone());
        US4::US4_Some(v571.clone(), v572.clone(), v573.clone(), v574.clone(), v575.clone(), v576.clone())
    };
    let mut v606: near_workspaces::result::ExecutionFinalResult = v101.clone();
    let v608: Result<std::string::String, near_workspaces::error::Error> = v606.borsh();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v611, mut v612, mut v613, mut v614, mut v615, mut v616): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let v617: US3 = v615.borrow().l0.clone();
    let v622: i32 = match &v617 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v623: bool = v613.borrow().l0.clone();
    let v624: bool = v623 == false;
    let v626: bool = if v624 {
        false
    } else {
        let v625: bool = 10i32 >= v622;
        v625
    };
    let v627: bool = v626 == false;
    let v675: US4 = if v627 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v631, mut v632, mut v633, mut v634, mut v635, mut v636): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v637: Rc<str> = method6(v631.clone(), v632.clone(), v633.clone(), v634.clone(), v635.clone(), v636.clone());
        let v638: Rc<str> = method7();
        let v639: Rc<str> = method48(v631.clone(), v632.clone(), v633.clone(), v634.clone(), v635.clone(), v636.clone(), v637.clone(), v638.clone(), v608);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v642, mut v643, mut v644, mut v645, mut v646, mut v647): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let v648: i64 = v642.borrow().l0.clone();
        let v649: i64 = v648.wrapping_add(1i64);
        v642.borrow_mut().l0 = v649;
        let v650: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v651: bool = cfg!(target_arch = "wasm32");
        if v651 {
            let v652: Rc<str> = v645.borrow().l0.clone();
            let v653: bool = &*v652 == "";
            let v661: Rc<str> = if v653 {
                v639.clone()
            } else {
                let v654: bool = &*v639 == "";
                if v654 {
                    let v655: Rc<str> = v645.borrow().l0.clone();
                    v655.clone()
                } else {
                    let v656: Rc<str> = v645.borrow().l0.clone();
                    let v657: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v659: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v656, v657)), v639));
                    v659.clone()
                }
            };
            let v663: usize = v661.chars().count();
            let v664: i32 = ((v663) as i32);
            let v665: i32 = v664.wrapping_add(14999i32);
            let v666: i32 = v665.wrapping_div(15000i32);
            let v667: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v668: bool = v639 != v667 ;
            let v670: bool = if v668 {
                let v669: bool = v666 <= 1i32;
                v669
            } else {
                false
            };
            if v670 {
                v645.borrow_mut().l0 = v661.clone();
                ()
            } else {
                v645.borrow_mut().l0 = v667.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v661); };
                ()
            }
        } else {
            println!("{}", v639);
            ()
        };
        let mut v673: Rc<dyn Fn(Rc<str>) -> ()> = v643.borrow().l0.clone();
        v673(v639.clone());
        US4::US4_Some(v642.clone(), v643.clone(), v644.clone(), v645.clone(), v646.clone(), v647.clone())
    };
    let v676: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v677: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v678: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len"); } LIT.with(|lit| lit.clone()) };
    let v679: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len"); } LIT.with(|lit| lit.clone()) };
    let v680: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v681: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len = "); } LIT.with(|lit| lit.clone()) };
    let v682: Rc<str> = format_real_44(v466);
    let v683: Rc<str> = Rc::<str>::from(format!("{}{}", v681, v682));
    let v684: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v685: Rc<str> = Rc::<str>::from(format!("{}{}", v683, v684));
    let v686: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v688: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v685, v686)), v680));
    let v689: Rc<str> = format_real_27(v1);
    let v691: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v688, v689)), v684));
    let v692: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures"); } LIT.with(|lit| lit.clone()) };
    let v694: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v691, v692)), v680));
    let v695: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v390)).s() });
    let v696: Rc<str> = Rc::<str>::from(format!("{}{}", v694, v695));
    let v697: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v698: Rc<str> = Rc::<str>::from(format!("{}{}", v697, v696));
    let v699: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v700: Rc<str> = Rc::<str>::from(format!("{}{}", v698, v699));
    let v701: bool = v392 > 0i32;
    let v712: Result<US5, anyhow::Error> = if v701 {
        let v702: US5 = US5::US5_Some(v700.clone());
        let v703: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v702);
        v703
    } else {
        let v704: bool = v466 > 1i32;
        if v704 {
            let v705: US5 = US5::US5_None;
            let v706: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v705);
            v706
        } else {
            let v708: anyhow::Error = anyhow::anyhow!("{}", v700);
            let v710: Result<US5, anyhow::Error> = Err(v708);
            v710
        }
    };
    let v713: bool = true; (v712) }); //;
    let v715: _ = __future_init;
    let v717: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = v715;
    v717
}
fn closure13() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let v2: std::string::String = format!("{}", v0);
        v2.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method49() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure13()
}
fn ok_c14() -> Rc<dyn Fn(US5) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US5) -> US7> = Rc::new(move |mut v0: US5| -> US7 {
        US7::US7_Ok(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method50() -> Rc<dyn Fn(US5) -> US7> {
    ok_c14()
}
fn error_c15() -> Rc<dyn Fn(std::string::String) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US7> = Rc::new(move |mut v0: std::string::String| -> US7 {
        US7::US7_Error(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method51() -> Rc<dyn Fn(std::string::String) -> US7> {
    error_c15()
}
fn method52() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[93m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method53(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: std::string::String) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = format_real_14(v10);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v12, v13)), v7)), v11));
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Error error"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = format_real_27(v8);
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v27));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v30, v31)), v25));
    let v34: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<std::string::String>") } } (&&W(&v9)).s() });
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v33, v34));
    let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", v36, v35));
    let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v20, Rc::<str>::from(format!("{}{}", v37, v38))));
    method11(v40.clone())
}
fn method54() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[91m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn method55(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: Rc<str>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0.clone();
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v11));
    let mut v13: Rc<str> = format_real_14(v10);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v12, v13)), v7)), v11));
    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Ok (Some error)"); } LIT.with(|lit| lit.clone()) };
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
    let v27: Rc<str> = format_real_27(v8);
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v27));
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
    let v34: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v30, v31)), v25)), v9));
    let v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let v36: Rc<str> = Rc::<str>::from(format!("{}{}", v35, v34));
    let v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v39: Rc<str> = Rc::<str>::from(format!("{}{}", v20, Rc::<str>::from(format!("{}{}", v36, v37))));
    method11(v39.clone())
}
fn method24(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = fn_25(v0.clone(), v1);
    let mut v10: Result<US5, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method49();
    let mut v13: Result<US5, std::string::String> = v10.map_err(|x| v11(x));
    let mut v14: Rc<dyn Fn(US5) -> US7> = method50();
    let mut v15: Rc<dyn Fn(std::string::String) -> US7> = method51();
    let v16: US7 = match v13 { Ok(x) => v14(x), Err(e) => v15(e) };
    let v396: US6 = match &v16 {
        US7::US7_Error(v122) => {
            let mut v122: std::string::String = v122.clone();
            let v123: bool = v1 >= 15u8;
            if v123 {
                let v125: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                { let _ = spiral_trace_hold(&v125); };
                let v127: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                let (mut v128, mut v129, mut v130, mut v131, mut v132, mut v133): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                let v134: US3 = v132.borrow().l0.clone();
                let v139: i32 = match &v134 {
                    US3::US3_Critical => {
                        50i32
                    }
                    US3::US3_Debug => {
                        20i32
                    }
                    US3::US3_Info => {
                        30i32
                    }
                    US3::US3_Verbose => {
                        10i32
                    }
                    US3::US3_Warning => {
                        40i32
                    }
                };
                let v140: bool = v130.borrow().l0.clone();
                let v141: bool = v140 == false;
                let v143: bool = if v141 {
                    false
                } else {
                    let v142: bool = 40i32 >= v139;
                    v142
                };
                let v144: bool = v143 == false;
                let v192: US4 = if v144 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v148, mut v149, mut v150, mut v151, mut v152, mut v153): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let v154: Rc<str> = method6(v148.clone(), v149.clone(), v150.clone(), v151.clone(), v152.clone(), v153.clone());
                    let v155: Rc<str> = method52();
                    let v156: Rc<str> = method53(v148.clone(), v149.clone(), v150.clone(), v151.clone(), v152.clone(), v153.clone(), v154.clone(), v155.clone(), v1, v122.clone());
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v159, mut v160, mut v161, mut v162, mut v163, mut v164): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let v165: i64 = v159.borrow().l0.clone();
                    let mut v166: i64 = v165.wrapping_add(1i64);
                    v159.borrow_mut().l0 = v166;
                    let v167: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let v168: bool = cfg!(target_arch = "wasm32");
                    if v168 {
                        let v169: Rc<str> = v162.borrow().l0.clone();
                        let mut v170: bool = &*v169 == "";
                        let mut v178: Rc<str> = if v170 {
                            v156.clone()
                        } else {
                            let v171: bool = &*v156 == "";
                            if v171 {
                                let mut v172: Rc<str> = v162.borrow().l0.clone();
                                v172.clone()
                            } else {
                                let mut v173: Rc<str> = v162.borrow().l0.clone();
                                let v174: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let v176: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v173, v174)), v156));
                                v176.clone()
                            }
                        };
                        let v180: usize = v178.chars().count();
                        let v181: i32 = ((v180) as i32);
                        let v182: i32 = v181.wrapping_add(14999i32);
                        let v183: i32 = v182.wrapping_div(15000i32);
                        let v184: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v185: bool = v156 != v184 ;
                        let v187: bool = if v185 {
                            let v186: bool = v183 <= 1i32;
                            v186
                        } else {
                            false
                        };
                        if v187 {
                            v162.borrow_mut().l0 = v178.clone();
                            ()
                        } else {
                            v162.borrow_mut().l0 = v184.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v178); };
                            ()
                        }
                    } else {
                        println!("{}", v156);
                        ()
                    };
                    let mut v190: Rc<dyn Fn(Rc<str>) -> ()> = v160.borrow().l0.clone();
                    v190(v156.clone());
                    US4::US4_Some(v159.clone(), v160.clone(), v161.clone(), v162.clone(), v163.clone(), v164.clone())
                };
                { let _ = spiral_trace_hold(&v125); };
                let (mut v195, mut v196, mut v197, mut v198, mut v199, mut v200): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                let v201: US3 = v199.borrow().l0.clone();
                let v206: i32 = match &v201 {
                    US3::US3_Critical => {
                        50i32
                    }
                    US3::US3_Debug => {
                        20i32
                    }
                    US3::US3_Info => {
                        30i32
                    }
                    US3::US3_Verbose => {
                        10i32
                    }
                    US3::US3_Warning => {
                        40i32
                    }
                };
                let v207: bool = v197.borrow().l0.clone();
                let v208: bool = v207 == false;
                let v210: bool = if v208 {
                    false
                } else {
                    let v209: bool = 40i32 >= v206;
                    v209
                };
                let v211: bool = v210 == false;
                let v248: US4 = if v211 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v125); };
                    let (mut v215, mut v216, mut v217, mut v218, mut v219, mut v220): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v127) };
                    let v221: i64 = v215.borrow().l0.clone();
                    let v222: i64 = v221.wrapping_add(1i64);
                    v215.borrow_mut().l0 = v222;
                    let v223: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v224: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let v225: bool = cfg!(target_arch = "wasm32");
                    if v225 {
                        let v226: Rc<str> = v218.borrow().l0.clone();
                        let v227: bool = &*v226 == "";
                        let v234: Rc<str> = if v227 {
                            v223.clone()
                        } else {
                            let v228: bool = &*v223 == "";
                            if v228 {
                                let v229: Rc<str> = v218.borrow().l0.clone();
                                v229.clone()
                            } else {
                                let v230: Rc<str> = v218.borrow().l0.clone();
                                let v232: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v230, v223)), v223));
                                v232.clone()
                            }
                        };
                        let v236: usize = v234.chars().count();
                        let v237: i32 = ((v236) as i32);
                        let v238: i32 = v237.wrapping_add(14999i32);
                        let v239: i32 = v238.wrapping_div(15000i32);
                        let v240: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v241: bool = v223 != v240 ;
                        let v243: bool = if v241 {
                            let v242: bool = v239 <= 1i32;
                            v242
                        } else {
                            false
                        };
                        if v243 {
                            v218.borrow_mut().l0 = v234.clone();
                            ()
                        } else {
                            v218.borrow_mut().l0 = v240.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v234); };
                            ()
                        }
                    } else {
                        println!("{}", v223);
                        ()
                    };
                    let mut v246: Rc<dyn Fn(Rc<str>) -> ()> = v216.borrow().l0.clone();
                    v246(v223.clone());
                    US4::US4_Some(v215.clone(), v216.clone(), v217.clone(), v218.clone(), v219.clone(), v220.clone())
                };
                let v250: bool = true; let __future_init = Box::pin(/*;
                let v252: bool = */ async move { /*;
                let v254: bool = */ ();
                let v255: US5 = US5::US5_None;
                let v256: bool = true; ((v1, v255.clone())) }); //;
                let v258: _ = __future_init;
                let v260: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v258;
                let (mut v262, mut v263): (u8, US5) = v260.await;
                US6::US6_Ok(v262, v263.clone())
            } else {
                let v266: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                { let _ = spiral_trace_hold(&v266); };
                let v268: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                let (mut v269, mut v270, mut v271, mut v272, mut v273, mut v274): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v268) };
                let v275: US3 = v273.borrow().l0.clone();
                let v280: i32 = match &v275 {
                    US3::US3_Critical => {
                        50i32
                    }
                    US3::US3_Debug => {
                        20i32
                    }
                    US3::US3_Info => {
                        30i32
                    }
                    US3::US3_Verbose => {
                        10i32
                    }
                    US3::US3_Warning => {
                        40i32
                    }
                };
                let v281: bool = v271.borrow().l0.clone();
                let v282: bool = v281 == false;
                let v284: bool = if v282 {
                    false
                } else {
                    let v283: bool = 40i32 >= v280;
                    v283
                };
                let v285: bool = v284 == false;
                let v333: US4 = if v285 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v266); };
                    let (mut v289, mut v290, mut v291, mut v292, mut v293, mut v294): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v268) };
                    let v295: Rc<str> = method6(v289.clone(), v290.clone(), v291.clone(), v292.clone(), v293.clone(), v294.clone());
                    let v296: Rc<str> = method52();
                    let v297: Rc<str> = method53(v289.clone(), v290.clone(), v291.clone(), v292.clone(), v293.clone(), v294.clone(), v295.clone(), v296.clone(), v1, v122.clone());
                    { let _ = spiral_trace_hold(&v266); };
                    let (mut v300, mut v301, mut v302, mut v303, mut v304, mut v305): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v268) };
                    let v306: i64 = v300.borrow().l0.clone();
                    let v307: i64 = v306.wrapping_add(1i64);
                    v300.borrow_mut().l0 = v307;
                    let v308: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v309: bool = cfg!(target_arch = "wasm32");
                    if v309 {
                        let v310: Rc<str> = v303.borrow().l0.clone();
                        let mut v311: bool = &*v310 == "";
                        let v319: Rc<str> = if v311 {
                            v297.clone()
                        } else {
                            let v312: bool = &*v297 == "";
                            if v312 {
                                let v313: Rc<str> = v303.borrow().l0.clone();
                                v313.clone()
                            } else {
                                let v314: Rc<str> = v303.borrow().l0.clone();
                                let mut v315: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v317: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v314, v315)), v297));
                                v317.clone()
                            }
                        };
                        let v321: usize = v319.chars().count();
                        let v322: i32 = ((v321) as i32);
                        let v323: i32 = v322.wrapping_add(14999i32);
                        let v324: i32 = v323.wrapping_div(15000i32);
                        let v325: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v326: bool = v297 != v325 ;
                        let v328: bool = if v326 {
                            let v327: bool = v324 <= 1i32;
                            v327
                        } else {
                            false
                        };
                        if v328 {
                            v303.borrow_mut().l0 = v319.clone();
                            ()
                        } else {
                            v303.borrow_mut().l0 = v325.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v319); };
                            ()
                        }
                    } else {
                        println!("{}", v297);
                        ()
                    };
                    let mut v331: Rc<dyn Fn(Rc<str>) -> ()> = v301.borrow().l0.clone();
                    v331(v297.clone());
                    US4::US4_Some(v300.clone(), v301.clone(), v302.clone(), v303.clone(), v304.clone(), v305.clone())
                };
                { let _ = spiral_trace_hold(&v266); };
                let (mut v336, mut v337, mut v338, mut v339, mut v340, mut v341): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v268) };
                let v342: US3 = v340.borrow().l0.clone();
                let v347: i32 = match &v342 {
                    US3::US3_Critical => {
                        50i32
                    }
                    US3::US3_Debug => {
                        20i32
                    }
                    US3::US3_Info => {
                        30i32
                    }
                    US3::US3_Verbose => {
                        10i32
                    }
                    US3::US3_Warning => {
                        40i32
                    }
                };
                let v348: bool = v338.borrow().l0.clone();
                let v349: bool = v348 == false;
                let v351: bool = if v349 {
                    false
                } else {
                    let v350: bool = 40i32 >= v347;
                    v350
                };
                let v352: bool = v351 == false;
                let v389: US4 = if v352 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v266); };
                    let (mut v356, mut v357, mut v358, mut v359, mut v360, mut v361): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v268) };
                    let v362: i64 = v356.borrow().l0.clone();
                    let v363: i64 = v362.wrapping_add(1i64);
                    v356.borrow_mut().l0 = v363;
                    let v364: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v365: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let v366: bool = cfg!(target_arch = "wasm32");
                    if v366 {
                        let v367: Rc<str> = v359.borrow().l0.clone();
                        let v368: bool = &*v367 == "";
                        let v375: Rc<str> = if v368 {
                            v364.clone()
                        } else {
                            let v369: bool = &*v364 == "";
                            if v369 {
                                let v370: Rc<str> = v359.borrow().l0.clone();
                                v370.clone()
                            } else {
                                let v371: Rc<str> = v359.borrow().l0.clone();
                                let v373: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v371, v364)), v364));
                                v373.clone()
                            }
                        };
                        let v377: usize = v375.chars().count();
                        let v378: i32 = ((v377) as i32);
                        let v379: i32 = v378.wrapping_add(14999i32);
                        let v380: i32 = v379.wrapping_div(15000i32);
                        let v381: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v382: bool = v364 != v381 ;
                        let v384: bool = if v382 {
                            let v383: bool = v380 <= 1i32;
                            v383
                        } else {
                            false
                        };
                        if v384 {
                            v359.borrow_mut().l0 = v375.clone();
                            ()
                        } else {
                            v359.borrow_mut().l0 = v381.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v375); };
                            ()
                        }
                    } else {
                        println!("{}", v364);
                        ()
                    };
                    let mut v387: Rc<dyn Fn(Rc<str>) -> ()> = v357.borrow().l0.clone();
                    v387(v364.clone());
                    US4::US4_Some(v356.clone(), v357.clone(), v358.clone(), v359.clone(), v360.clone(), v361.clone())
                };
                let v390: u8 = v1.wrapping_add(1u8);
                let v391: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method24(v0.clone(), v390);
                let v393: US6 = v391.await;
                v393.clone()
            }
        }
        US7::US7_Ok(v17) => {
            let v17: US5 = v17.clone();
            match &v17 {
                US5::US5_None => {
                    let mut v19: bool = true; let __future_init = Box::pin(/*;
                    let mut v21: bool = */ async move { /*;
                    let v23: bool = */ ();
                    let mut v24: US5 = US5::US5_None;
                    let v25: bool = true; ((v1, v24.clone())) }); //;
                    let v27: _ = __future_init;
                    let mut v29: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v27;
                    let (mut v31, mut v32): (u8, US5) = v29.await;
                    US6::US6_Ok(v31, v32.clone())
                }
                US5::US5_Some(v34) => {
                    let v34: Rc<str> = v34.clone();
                    let v36: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v36); };
                    let mut v38: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v39, mut v40, mut v41, mut v42, mut v43, mut v44): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                    let v45: US3 = v43.borrow().l0.clone();
                    let v50: i32 = match &v45 {
                        US3::US3_Critical => {
                            50i32
                        }
                        US3::US3_Debug => {
                            20i32
                        }
                        US3::US3_Info => {
                            30i32
                        }
                        US3::US3_Verbose => {
                            10i32
                        }
                        US3::US3_Warning => {
                            40i32
                        }
                    };
                    let v51: bool = v41.borrow().l0.clone();
                    let v52: bool = v51 == false;
                    let mut v54: bool = if v52 {
                        false
                    } else {
                        let mut v53: bool = 50i32 >= v50;
                        v53
                    };
                    let mut v55: bool = v54 == false;
                    let v103: US4 = if v55 {
                        US4::US4_None
                    } else {
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v59, mut v60, mut v61, mut v62, mut v63, mut v64): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                        let v65: Rc<str> = method6(v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone(), v64.clone());
                        let v66: Rc<str> = method54();
                        let v67: Rc<str> = method55(v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone(), v66.clone(), v1, v34.clone());
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v70, mut v71, mut v72, mut v73, mut v74, mut v75): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                        let v76: i64 = v70.borrow().l0.clone();
                        let v77: i64 = v76.wrapping_add(1i64);
                        v70.borrow_mut().l0 = v77;
                        let v78: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                        let v79: bool = cfg!(target_arch = "wasm32");
                        if v79 {
                            let v80: Rc<str> = v73.borrow().l0.clone();
                            let v81: bool = &*v80 == "";
                            let v89: Rc<str> = if v81 {
                                v67.clone()
                            } else {
                                let v82: bool = &*v67 == "";
                                if v82 {
                                    let v83: Rc<str> = v73.borrow().l0.clone();
                                    v83.clone()
                                } else {
                                    let mut v84: Rc<str> = v73.borrow().l0.clone();
                                    let v85: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                    let v87: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v84, v85)), v67));
                                    v87.clone()
                                }
                            };
                            let mut v91: usize = v89.chars().count();
                            let v92: i32 = ((v91) as i32);
                            let v93: i32 = v92.wrapping_add(14999i32);
                            let v94: i32 = v93.wrapping_div(15000i32);
                            let mut v95: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let v96: bool = v67 != v95 ;
                            let v98: bool = if v96 {
                                let v97: bool = v94 <= 1i32;
                                v97
                            } else {
                                false
                            };
                            if v98 {
                                v73.borrow_mut().l0 = v89.clone();
                                ()
                            } else {
                                v73.borrow_mut().l0 = v95.clone();
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v89); };
                                ()
                            }
                        } else {
                            println!("{}", v67);
                            ()
                        };
                        let mut v101: Rc<dyn Fn(Rc<str>) -> ()> = v71.borrow().l0.clone();
                        v101(v67.clone());
                        US4::US4_Some(v70.clone(), v71.clone(), v72.clone(), v73.clone(), v74.clone(), v75.clone())
                    };
                    let v105: bool = true; let __future_init = Box::pin(/*;
                    let v107: bool = */ async move { /*;
                    let v109: bool = */ ();
                    let v110: US5 = US5::US5_Some(v34.clone());
                    let v111: bool = true; ((v1, v110.clone())) }); //;
                    let v113: _ = __future_init;
                    let v115: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v113;
                    let (mut v117, mut v118): (u8, US5) = v115.await;
                    US6::US6_Error(v117, v118.clone())
                }
            }
        }
    };
    let v397: bool = true; (v396) }); //;
    let v399: _ = __future_init;
    let v401: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = v399;
    v401
}
fn method58(mut v0: US5) -> Rc<str> {
    match &v0 {
        US5::US5_None => {
            let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v8.clone()
        }
        US5::US5_Some(v1) => {
            let v1: Rc<str> = v1.clone();
            let v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some"); } LIT.with(|lit| lit.clone()) };
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v2, v3)), v1));
            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
            v7.clone()
        }
    }
}
fn method57(mut v0: US6) -> Rc<str> {
    match &v0 {
        US6::US6_Error(v28, v29) => {
            let mut v28: u8 = *v28;
            let mut v29: US5 = v29.clone();
            let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error"); } LIT.with(|lit| lit.clone()) };
            let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error("); } LIT.with(|lit| lit.clone()) };
            let v33: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let v39: Rc<str> = format_real_27(v28);
            let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v38, v39));
            let v41: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let v42: Rc<str> = Rc::<str>::from(format!("{}{}", v40, v41));
            let mut v43: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let v45: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v42, v43)), v37));
            let v46: Rc<str> = method58(v29.clone());
            let v47: Rc<str> = Rc::<str>::from(format!("{}{}", v45, v46));
            let v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let v49: Rc<str> = Rc::<str>::from(format!("{}{}", v48, v47));
            let v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let v52: Rc<str> = Rc::<str>::from(format!("{}{}", v32, Rc::<str>::from(format!("{}{}", v49, v50))));
            let mut v53: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v54: Rc<str> = Rc::<str>::from(format!("{}{}", v52, v53));
            v54.clone()
        }
        US6::US6_Ok(v1, v2) => {
            let v1: u8 = *v1;
            let v2: US5 = v2.clone();
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ok"); } LIT.with(|lit| lit.clone()) };
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ok("); } LIT.with(|lit| lit.clone()) };
            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let v12: Rc<str> = format_real_27(v1);
            let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
            let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
            let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let v18: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v15, v16)), v10));
            let mut v19: Rc<str> = method58(v2.clone());
            let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
            let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v20));
            let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v5, Rc::<str>::from(format!("{}{}", v22, v23))));
            let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
            v27.clone()
        }
    }
}
fn method56(mut v0: Rc<RefCell<Mut1>>, mut v1: Rc<RefCell<Mut2>>, mut v2: Rc<RefCell<Mut3>>, mut v3: Rc<RefCell<Mut4>>, mut v4: Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: US6) -> Rc<str> {
    let v9: i64 = v0.borrow().l0.clone();
    let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v10));
    let v12: Rc<str> = format_real_14(v9);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v11, v12)), v7)), v10));
    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries"); } LIT.with(|lit| lit.clone()) };
    let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries"); } LIT.with(|lit| lit.clone()) };
    let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries = "); } LIT.with(|lit| lit.clone()) };
    let mut v26: Rc<str> = method57(v8.clone());
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v27));
    let v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v19, Rc::<str>::from(format!("{}{}", v29, v30))));
    method11(v32.clone())
}
fn run_21(mut v0: clap::ArgMatches) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> {
    let v2: bool = true; let __future_init = Box::pin(/*;
    let mut v4: bool = */ async move { /*;
    let v6: bool = */ ();
    let v7: Rc<str> = method22();
    let v9: &str = &*v7;
    let mut v11: Option<std::string::String> = clap::ArgMatches::get_one(&v0, v9).cloned();
    let v12: Option<std::string::String> = method2(v11.clone());
    let mut v13: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v14: Option<US0> = v12.map(|x| v13(x));
    let v16: US0 = US0::US0_None;
    let v17: US0 = v16.clone();
    let v18: US0 = v14.unwrap_or(v17);
    let v22: std::string::String = match &v18 {
        US0::US0_None => {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_Some(v19) => {
            let mut v19: std::string::String = v19.clone();
            v19.clone()
        }
    };
    let mut v24: Rc<str> = Rc::<str>::from(String::as_str(&v22));
    let mut v26: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v26); };
    let mut v28: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v29, mut v30, mut v31, mut v32, mut v33, mut v34): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
    let v35: US3 = v33.borrow().l0.clone();
    let mut v40: i32 = match &v35 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v41: bool = v31.borrow().l0.clone();
    let v42: bool = v41 == false;
    let mut v44: bool = if v42 {
        false
    } else {
        let mut v43: bool = 10i32 >= v40;
        v43
    };
    let v45: bool = v44 == false;
    let v93: US4 = if v45 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v26); };
        let (mut v49, mut v50, mut v51, mut v52, mut v53, mut v54): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
        let mut v55: Rc<str> = method6(v49.clone(), v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone());
        let mut v56: Rc<str> = method7();
        let v57: Rc<str> = method23(v49.clone(), v50.clone(), v51.clone(), v52.clone(), v53.clone(), v54.clone(), v55.clone(), v56.clone(), v24.clone());
        { let _ = spiral_trace_hold(&v26); };
        let (mut v60, mut v61, mut v62, mut v63, mut v64, mut v65): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
        let v66: i64 = v60.borrow().l0.clone();
        let v67: i64 = v66.wrapping_add(1i64);
        v60.borrow_mut().l0 = v67;
        let v68: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v69: bool = cfg!(target_arch = "wasm32");
        if v69 {
            let mut v70: Rc<str> = v63.borrow().l0.clone();
            let v71: bool = &*v70 == "";
            let v79: Rc<str> = if v71 {
                v57.clone()
            } else {
                let mut v72: bool = &*v57 == "";
                if v72 {
                    let mut v73: Rc<str> = v63.borrow().l0.clone();
                    v73.clone()
                } else {
                    let v74: Rc<str> = v63.borrow().l0.clone();
                    let mut v75: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v77: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v74, v75)), v57));
                    v77.clone()
                }
            };
            let v81: usize = v79.chars().count();
            let v82: i32 = ((v81) as i32);
            let v83: i32 = v82.wrapping_add(14999i32);
            let mut v84: i32 = v83.wrapping_div(15000i32);
            let v85: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v86: bool = v57 != v85 ;
            let v88: bool = if v86 {
                let v87: bool = v84 <= 1i32;
                v87
            } else {
                false
            };
            if v88 {
                v63.borrow_mut().l0 = v79.clone();
                ()
            } else {
                v63.borrow_mut().l0 = v85.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v79); };
                ()
            }
        } else {
            println!("{}", v57);
            ()
        };
        let mut v91: Rc<dyn Fn(Rc<str>) -> ()> = v61.borrow().l0.clone();
        v91(v57.clone());
        US4::US4_Some(v60.clone(), v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone())
    };
    let mut v95: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v24);
    let v97: Vec<u8> = v95?;
    let v98: u8 = 1u8;
    let v99: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method24(v97.clone(), v98);
    let mut v101: US6 = v99.await;
    { let _ = spiral_trace_hold(&v26); };
    let (mut v104, mut v105, mut v106, mut v107, mut v108, mut v109): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
    let v110: US3 = v108.borrow().l0.clone();
    let v115: i32 = match &v110 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v116: bool = v106.borrow().l0.clone();
    let v117: bool = v116 == false;
    let mut v119: bool = if v117 {
        false
    } else {
        let v118: bool = 10i32 >= v115;
        v118
    };
    let v120: bool = v119 == false;
    let v168: US4 = if v120 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v26); };
        let (mut v124, mut v125, mut v126, mut v127, mut v128, mut v129): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
        let v130: Rc<str> = method6(v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone());
        let v131: Rc<str> = method7();
        let v132: Rc<str> = method56(v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v129.clone(), v130.clone(), v131.clone(), v101.clone());
        { let _ = spiral_trace_hold(&v26); };
        let (mut v135, mut v136, mut v137, mut v138, mut v139, mut v140): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v28) };
        let v141: i64 = v135.borrow().l0.clone();
        let v142: i64 = v141.wrapping_add(1i64);
        v135.borrow_mut().l0 = v142;
        let v143: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v144: bool = cfg!(target_arch = "wasm32");
        if v144 {
            let v145: Rc<str> = v138.borrow().l0.clone();
            let v146: bool = &*v145 == "";
            let v154: Rc<str> = if v146 {
                v132.clone()
            } else {
                let v147: bool = &*v132 == "";
                if v147 {
                    let v148: Rc<str> = v138.borrow().l0.clone();
                    v148.clone()
                } else {
                    let v149: Rc<str> = v138.borrow().l0.clone();
                    let mut v150: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v152: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v149, v150)), v132));
                    v152.clone()
                }
            };
            let v156: usize = v154.chars().count();
            let v157: i32 = ((v156) as i32);
            let v158: i32 = v157.wrapping_add(14999i32);
            let mut v159: i32 = v158.wrapping_div(15000i32);
            let v160: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v161: bool = v132 != v160 ;
            let mut v163: bool = if v161 {
                let mut v162: bool = v159 <= 1i32;
                v162
            } else {
                false
            };
            if v163 {
                v138.borrow_mut().l0 = v154.clone();
                ()
            } else {
                v138.borrow_mut().l0 = v160.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v154); };
                ()
            }
        } else {
            println!("{}", v132);
            ()
        };
        let mut v166: Rc<dyn Fn(Rc<str>) -> ()> = v136.borrow().l0.clone();
        v166(v132.clone());
        US4::US4_Some(v135.clone(), v136.clone(), v137.clone(), v138.clone(), v139.clone(), v140.clone())
    };
    let v198: Result<u8, anyhow::Error> = match &v101 {
        US6::US6_Error(v172, v173) => {
            let mut v172: u8 = *v172;
            let mut v173: US5 = v173.clone();
            let v174: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v175: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v176: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries"); } LIT.with(|lit| lit.clone()) };
            let v177: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries"); } LIT.with(|lit| lit.clone()) };
            let mut v178: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v179: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries = "); } LIT.with(|lit| lit.clone()) };
            let v180: Rc<str> = method57(v101.clone());
            let v181: Rc<str> = Rc::<str>::from(format!("{}{}", v179, v180));
            let v182: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let v183: Rc<str> = Rc::<str>::from(format!("{}{}", v181, v182));
            let v184: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let v186: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v183, v184)), v178));
            let v187: Rc<str> = method58(v173.clone());
            let v188: Rc<str> = Rc::<str>::from(format!("{}{}", v186, v187));
            let v189: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v190: Rc<str> = Rc::<str>::from(format!("{}{}", v189, v188));
            let v191: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let v192: Rc<str> = Rc::<str>::from(format!("{}{}", v190, v191));
            let v194: anyhow::Error = anyhow::anyhow!("{}", v192);
            let v196: Result<u8, anyhow::Error> = Err(v194);
            v196
        }
        US6::US6_Ok(v169, v170) => {
            let v169: u8 = *v169;
            let mut v170: US5 = v170.clone();
            let v171: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v169);
            v171
        }
    };
    let mut v199: bool = true; (v198) }); //;
    let v201: _ = __future_init;
    let v203: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v201;
    v203
}
fn ok_c16() -> Rc<dyn Fn(u8) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US8> = Rc::new(move |mut v0: u8| -> US8 {
        US8::US8_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method59() -> Rc<dyn Fn(u8) -> US8> {
    ok_c16()
}
fn error_c17() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_Error(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method60() -> Rc<dyn Fn(std::string::String) -> US8> {
    error_c17()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(std::env::args().skip(1).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
    let v1: clap::Command = get_command_0();
    let mut v3: clap::ArgMatches = clap::Command::get_matches(v1);
    let mut v4: Rc<str> = method1();
    let v6: &str = &*v4;
    let v8: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v6).cloned();
    let v9: Option<std::string::String> = method2(v8.clone());
    let mut v10: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v11: Option<US0> = v9.map(|x| v10(x));
    let mut v13: US0 = US0::US0_None;
    let mut v14: US0 = v13.clone();
    let mut v15: US0 = v11.unwrap_or(v14);
    let v62: US1 = match &v15 {
        US0::US0_None => {
            US1::US1_None
        }
        US0::US0_Some(v16) => {
            let v16: std::string::String = v16.clone();
            let v18: Rc<str> = Rc::<str>::from(String::as_str(&v16));
            ;
            ;
            ;
            ;
            ;
            let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
            let v20: Rc<str> = Rc::<str>::from(v19.to_lowercase());
            let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
            let v22: Rc<str> = Rc::<str>::from(v21.to_lowercase());
            let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
            let mut v24: Rc<str> = Rc::<str>::from(v23.to_lowercase());
            let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
            let mut v26: Rc<str> = Rc::<str>::from(v25.to_lowercase());
            let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
            let mut v28: Rc<str> = Rc::<str>::from(v27.to_lowercase());
            let mut v29: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
            let v30: US3 = US3::US3_Verbose;
            v29.borrow_mut().push((v27.clone(), v30.clone()));
            let v31: US3 = US3::US3_Debug;
            v29.borrow_mut().push((v25.clone(), v31.clone()));
            let v32: US3 = US3::US3_Info;
            v29.borrow_mut().push((v23.clone(), v32.clone()));
            let v33: US3 = US3::US3_Warning;
            v29.borrow_mut().push((v21.clone(), v33.clone()));
            let v34: US3 = US3::US3_Critical;
            v29.borrow_mut().push((v19.clone(), v34.clone()));
            let v35: US3 = US3::US3_Verbose;
            v29.borrow_mut().push((v28.clone(), v35.clone()));
            let v36: US3 = US3::US3_Debug;
            v29.borrow_mut().push((v26.clone(), v36.clone()));
            let v37: US3 = US3::US3_Info;
            v29.borrow_mut().push((v24.clone(), v37.clone()));
            let mut v38: US3 = US3::US3_Warning;
            v29.borrow_mut().push((v22.clone(), v38.clone()));
            let v39: US3 = US3::US3_Critical;
            v29.borrow_mut().push((v20.clone(), v39.clone()));
            let mut v40: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v29.borrow().clone());
            let v41: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v40).as_ref().clone()));
            let v42: i32 = (v41.clone().borrow().len() as i32);
            let mut v43: US2 = US2::US2_None;
            let mut v44: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v42, l1: v43.clone() }));
            while method3(v44.clone()) {
                let v46: i32 = v44.borrow().l0.clone();
                let v47: i32 = v46.wrapping_sub(1i32);
                let v48: US2 = v44.borrow().l1.clone();
                let (mut v49, mut v50): (Rc<str>, US3) = v41.clone().borrow()[v47 as usize].clone();
                let v57: US2 = match &v48 {
                    US2::US2_None => {
                        let v52: bool = v49 == v18 ;
                        if v52 {
                            US2::US2_Some(v50.clone())
                        } else {
                            US2::US2_None
                        }
                    }
                    US2::US2_Some(v51) => {
                        let v51: US3 = v51.clone();
                        v48.clone()
                    }
                };
                v44.borrow_mut().l0 = v47;
                v44.borrow_mut().l1 = v57.clone();
                ()
            };
            let mut v58: US2 = v44.borrow().l1.clone();
            US1::US1_Some(v58.clone())
        }
    };
    let v69: US2 = match &v62 {
        US1::US1_Some(v63) => {
            let mut v63: US2 = v63.clone();
            match &v63 {
                US2::US2_Some(v64) => {
                    let v64: US3 = v64.clone();
                    US2::US2_Some(v64.clone())
                }
                _ => {
                    US2::US2_None
                }
            }
        }
        _ => {
            US2::US2_None
        }
    };
    let mut v73: US3 = match &v69 {
        US2::US2_None => {
            US3::US3_Verbose
        }
        US2::US2_Some(v70) => {
            let mut v70: US3 = v70.clone();
            v70.clone()
        }
    };
    let mut v75: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c2(v73.clone());
    { let _ = spiral_trace_hold(&v75); };
    let v77: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c4(v73.clone());
    let (mut v78, mut v79, mut v80, mut v81, mut v82, mut v83): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v77) };
    let v85: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v85); };
    let v87: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v88, mut v89, mut v90, mut v91, mut v92, mut v93): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v87) };
    let v94: US3 = v92.borrow().l0.clone();
    let v99: i32 = match &v94 {
        US3::US3_Critical => {
            50i32
        }
        US3::US3_Debug => {
            20i32
        }
        US3::US3_Info => {
            30i32
        }
        US3::US3_Verbose => {
            10i32
        }
        US3::US3_Warning => {
            40i32
        }
    };
    let v100: bool = v90.borrow().l0.clone();
    let mut v101: bool = v100 == false;
    let v103: bool = if v101 {
        false
    } else {
        let v102: bool = 10i32 >= v99;
        v102
    };
    let v104: bool = v103 == false;
    let v152: US4 = if v104 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v85); };
        let (mut v108, mut v109, mut v110, mut v111, mut v112, mut v113): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v87) };
        let v114: Rc<str> = method6(v108.clone(), v109.clone(), v110.clone(), v111.clone(), v112.clone(), v113.clone());
        let v115: Rc<str> = method7();
        let v116: Rc<str> = method10(v108.clone(), v109.clone(), v110.clone(), v111.clone(), v112.clone(), v113.clone(), v114.clone(), v115.clone(), v0.clone());
        { let _ = spiral_trace_hold(&v85); };
        let (mut v119, mut v120, mut v121, mut v122, mut v123, mut v124): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v87) };
        let v125: i64 = v119.borrow().l0.clone();
        let v126: i64 = v125.wrapping_add(1i64);
        v119.borrow_mut().l0 = v126;
        let v127: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let v128: bool = cfg!(target_arch = "wasm32");
        if v128 {
            let v129: Rc<str> = v122.borrow().l0.clone();
            let v130: bool = &*v129 == "";
            let mut v138: Rc<str> = if v130 {
                v116.clone()
            } else {
                let v131: bool = &*v116 == "";
                if v131 {
                    let v132: Rc<str> = v122.borrow().l0.clone();
                    v132.clone()
                } else {
                    let v133: Rc<str> = v122.borrow().l0.clone();
                    let v134: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v136: Rc<str> = Rc::<str>::from(format!("{}{}", Rc::<str>::from(format!("{}{}", v133, v134)), v116));
                    v136.clone()
                }
            };
            let v140: usize = v138.chars().count();
            let v141: i32 = ((v140) as i32);
            let v142: i32 = v141.wrapping_add(14999i32);
            let v143: i32 = v142.wrapping_div(15000i32);
            let v144: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v145: bool = v116 != v144 ;
            let v147: bool = if v145 {
                let v146: bool = v143 <= 1i32;
                v146
            } else {
                false
            };
            if v147 {
                v122.borrow_mut().l0 = v138.clone();
                ()
            } else {
                v122.borrow_mut().l0 = v144.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v138); };
                ()
            }
        } else {
            println!("{}", v116);
            ()
        };
        let mut v150: Rc<dyn Fn(Rc<str>) -> ()> = v120.borrow().l0.clone();
        v150(v116.clone());
        US4::US4_Some(v119.clone(), v120.clone(), v121.clone(), v122.clone(), v123.clone(), v124.clone())
    };
    let v153: Rc<str> = method17();
    let v155: &str = &*v153;
    let v157: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v155).cloned();
    let v158: Option<std::string::String> = method2(v157.clone());
    let mut v159: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure8();
    let v160: Option<Rc<str>> = v158.map(|x| v159(x));
    let v161: Option<Rc<str>> = method20(v160.clone());
    let mut v162: Rc<dyn Fn((Rc<str>)) -> US5> = closure9();
    let mut v163: Option<US5> = v161.map(|x| v162(x));
    let v165: US5 = US5::US5_None;
    let mut v166: US5 = v165.clone();
    let v167: US5 = v163.unwrap_or(v166);
    let v168: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = run_21(v3.clone());
    let mut v170: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v172: Result<u8, anyhow::Error> = v170.handle().block_on(v168);
    let mut v173: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method49();
    let mut v175: Result<u8, std::string::String> = v172.map_err(|x| v173(x));
    let v177: Result<u8, std::string::String> = v175.clone();
    let mut v178: Rc<dyn Fn(u8) -> US8> = method59();
    let mut v179: Rc<dyn Fn(std::string::String) -> US8> = method60();
    let v180: US8 = match v177 { Ok(x) => v178(x), Err(e) => v179(e) };
    match &v180 {
        US8::US8_Error(v187) => {
            let v187: std::string::String = v187.clone();
            match &v167 {
                US5::US5_Some(v188) => {
                    let v188: Rc<str> = v188.clone();
                    let v189: bool = "" == &*v188;
                    if v189 {
                        ()
                    } else {
                        let v191: Rc<str> = Rc::<str>::from(String::as_str(&v187));
                        let v192: bool = v191.contains(&*v188);
                        if v192 {
                            ()
                        } else {
                            let v193: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / exception: '{}' / error: {}", v188, v187));
                            let v195: Result<(), Rc<str>> = Err(v193);
                            v195.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let v198: u8 = v175.unwrap();
                    ()
                }
            }
        }
        US8::US8_Ok(v181) => {
            let v181: u8 = *v181;
            match &v167 {
                US5::US5_Some(v182) => {
                    let v182: Rc<str> = v182.clone();
                    let v183: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / retries: {} / exception: '{}'", v181, v182));
                    let v185: Result<(), Rc<str>> = Err(v183);
                    v185.unwrap();
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
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
