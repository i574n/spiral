#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)] #![recursion_limit = "256"]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_trace_hold<T: Clone>(fresh: &std::rc::Rc<dyn Fn() -> T>) -> T {
    use std::sync::OnceLock;
    static SLOT: OnceLock<usize> = OnceLock::new();
    let raw = *SLOT.get_or_init(|| Box::into_raw(Box::new((*fresh)())) as usize);
    unsafe { (*(raw as *const T)).clone() }
}
struct SpiralDebug<T>(T);
trait SpiralDebugShow {
    fn show(&self) -> String;
}
impl<T: std::fmt::Debug> SpiralDebugShow for SpiralDebug<T> {
    fn show(&self) -> String { format!("{:?}", self.0) }
}
trait SpiralTypeShow {
    fn show(&self) -> String;
}
impl<T> SpiralTypeShow for &SpiralDebug<T> {
    fn show(&self) -> String { String::from(std::any::type_name::<T>()) }
}
#[cfg(target_arch = "wasm32")]
fn spiral_cfg_local_clock() -> Option<[i64; 3]> { None }
#[cfg(all(windows, not(target_arch = "wasm32")))]
fn spiral_cfg_local_clock() -> Option<[i64; 3]> {
    #[repr(C)] struct St([u16; 8]);
    unsafe extern "system" { fn GetLocalTime(t: *mut St); }
    let mut t = St([0; 8]);
    unsafe { GetLocalTime(&mut t) };
    Some([i64::from(t.0[4]), i64::from(t.0[5]), i64::from(t.0[6])])
}
#[cfg(all(unix, not(target_arch = "wasm32")))]
fn spiral_cfg_local_clock() -> Option<[i64; 3]> {
    #[repr(C, align(8))] struct Tm([i32; 16]);
    unsafe extern "C" { fn localtime_r(t: *const std::os::raw::c_long, tm: *mut Tm) -> *mut Tm; }
    let now = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs());
    let secs = std::os::raw::c_long::try_from(now.unwrap_or(0)).unwrap_or(0);
    let mut tm = Tm([0; 16]);
    unsafe { localtime_r(&secs, &mut tm) };
    Some([i64::from(tm.0[2]), i64::from(tm.0[1]), i64::from(tm.0[0])])
}
#[cfg(not(any(windows, unix, target_arch = "wasm32")))]
fn spiral_cfg_local_clock() -> Option<[i64; 3]> { None }
#[cfg(target_arch = "wasm32")]
fn spiral_cfg_epoch_nanos() -> u64 { near_sdk::env::block_timestamp() }
#[cfg(not(target_arch = "wasm32"))]
fn spiral_cfg_epoch_nanos() -> u64 {
    let since = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH);
    since.map(|d| u64::try_from(d.as_nanos()).unwrap_or(0)).unwrap_or(0)
}
#[cfg(target_arch = "wasm32")]
fn spiral_trace_near_log(text: &str) {
    use std::sync::atomic::{AtomicUsize, Ordering};
    static LOGGED: AtomicUsize = AtomicUsize::new(0);
    let mut rest = text;
    while !rest.is_empty() {
        let used = LOGGED.load(Ordering::Relaxed);
        let budget = 16000usize.saturating_sub(used);
        if budget < 13 {
            break;
        }
        let mut end = rest.len().min(15000);
        while !rest.is_char_boundary(end) {
            end -= 1;
        }
        let (chunk, tail) = rest.split_at(end);
        if chunk.len() <= budget {
            LOGGED.store(used + chunk.len(), Ordering::Relaxed);
            near_sdk::env::log_str(chunk);
            rest = tail;
        } else {
            let mut cut = budget - 12;
            while !chunk.is_char_boundary(cut) {
                cut -= 1;
            }
            let s = format!("{} [truncated]", &chunk[..cut]);
            LOGGED.store(used + s.len(), Ordering::Relaxed);
            near_sdk::env::log_str(&s);
            break;
        }
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
struct Mut0 { l0: i32 }
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
struct Mut1 { l0: i32, l1: US2 }
struct Mut2 { l0: i64 }
struct Mut3 { l0: Rc<dyn Fn(Rc<str>) -> ()> }
struct Mut4 { l0: bool }
struct Mut5 { l0: Rc<str> }
struct Mut6 { l0: US3 }
#[derive(Clone)]
enum US4 {
    US4_Some(Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>),
    US4_None,
}
struct Mut7 { l0: u64 }
#[derive(Clone)]
enum US5 {
    US5_Some([i64; 3]),
    US5_None,
}
#[derive(Clone)]
enum US6 {
    US6_Some(Rc<str>),
    US6_None,
}
#[derive(Clone)]
enum US7 {
    US7_Ok(u8, US6),
    US7_Error(u8, US6),
}
#[derive(Clone)]
enum US8 {
    US8_Ok(US6),
    US8_Error(std::string::String),
}
#[derive(Clone)]
enum US9 {
    US9_Ok(u8),
    US9_Error(std::string::String),
}
fn command_line_argument_count_0() -> i32 {
    let mut v0: usize = std::env::args().count();
    let mut v1: i32 = ((v0) as i32);
    let mut v2: i32 = v1.wrapping_sub(1i32);
    v2
}
fn method1(mut v0: i32, mut v1: &Rc<RefCell<Mut0>>) -> bool {
    let mut v2: i32 = v1.borrow().l0;
    let mut v3: bool = v2 < v0;
    v3
}
fn command_line_argument_2(mut v0: i32) -> Rc<str> {
    let mut v1: i32 = v0.wrapping_add(1i32);
    let mut v2: usize = ((v1) as usize);
    let mut v3: Rc<str> = Rc::<str>::from(std::env::args().nth(v2).unwrap_or_default());
    v3
}
fn closure0() -> Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = Rc::new(move |mut v0: (Rc<str>)| -> clap::builder::PossibleValue {
        let mut v1: Rc<str> = (v0);
        let mut v3: &str = &*v1;
        let mut v5: std::string::String = String::from(v3);
        let v7: Box<std::string::String> = Box::new(v5);
        let mut v9: &'static mut std::string::String = Box::leak(v7);
        let mut v11: clap::builder::PossibleValue = clap::builder::PossibleValue::new(&**v9);
        v11
    }); } CLOSURE.with(|closure| closure.clone())
}
fn get_command_3() -> clap::Command {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("command"); } LIT.with(|lit| lit.clone()) };
    let mut v1: &'static str = Box::leak(String::from(&*v0).into_boxed_str());
    let mut v3: clap::Command = clap::Command::new(v1);
    let mut v5: clap::Command = clap::Command::args_override_self(v3, true);
    let v6: usize = ((0i32) as usize);
    let v7: usize = ((1i32) as usize);
    let mut v8: usize = ((0i32) as usize);
    let mut v9: bool = v7 == v8 ;
    let mut v15: clap::builder::ValueRange = if v9 {
        let mut v11: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..);
        v11
    } else {
        let mut v14: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..=v7);
        v14
    };
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    let mut v17: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v19: clap::Arg = clap::Arg::new(v17);
    let mut v21: clap::Arg = v19.short(b'e' as char);
    let v22: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v24: clap::Arg = v21.long(v22);
    let mut v26: clap::Arg = v24.num_args(v15);
    let mut v28: clap::Arg = v26.require_equals(true);
    let v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v30: &str = (&*v29);
    let v32: clap::Arg = v28.default_missing_value(&*Box::leak(String::from(v30).into_boxed_str()));
    let v34: clap::Command = clap::Command::arg(v5, v32);
    let mut v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
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
    let v44: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let v45: Rc<str> = Rc::<str>::from(v44.to_lowercase());
    let v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let v47: Rc<str> = Rc::<str>::from(v46.to_lowercase());
    let v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let v49: Rc<str> = Rc::<str>::from(v48.to_lowercase());
    let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let v51: Rc<str> = Rc::<str>::from(v50.to_lowercase());
    let v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let v53: Rc<str> = Rc::<str>::from(v52.to_lowercase());
    let mut v54: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v54.borrow_mut().push(v53);
    v54.borrow_mut().push(v51);
    v54.borrow_mut().push(v49);
    v54.borrow_mut().push(v47);
    v54.borrow_mut().push(v45);
    let mut v55: Rc<Vec<Rc<str>>> = Rc::new(v54.borrow().clone());
    let v56: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v55).as_ref().clone()));
    let mut v57: Vec<Rc<str>> = (v56).borrow().clone();
    let mut v59: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v60: Vec<clap::builder::PossibleValue> = v57.iter().map(|x| v59(x.clone())).collect::<Vec<_>>();
    let mut v62: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v60));
    let v64: clap::Arg = v43.value_parser(v62);
    let v66: clap::Command = clap::Command::arg(v34, v64);
    let v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let mut v68: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v70: clap::Arg = clap::Arg::new(v68);
    let mut v72: clap::Arg = v70.short(b'w' as char);
    let v73: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v75: clap::Arg = v72.long(v73);
    let v77: clap::Arg = v75.required(true);
    let v79: clap::Command = clap::Command::arg(v66, v77);
    v79
}
fn method4() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method5(mut v0: Option<std::string::String>) -> Option<std::string::String> {
    v0
}
fn closure1() -> Rc<dyn Fn((std::string::String)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> US0> = Rc::new(move |mut v0: (std::string::String)| -> US0 {
        let mut v1: std::string::String = (v0);
        US0::US0_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method6(mut v0: &Rc<RefCell<Mut1>>) -> bool {
    let mut v1: i32 = v0.borrow().l0;
    let mut v2: bool = v1 > 0i32;
    v2
}
fn get_environment_variable_8(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from(std::env::var(&*v0).unwrap_or_default());
    v1
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn new_trace_state_7(mut v0: US3) -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) {
    let mut v1: bool = cfg!(target_arch = "wasm32");
    let v45: US2 = if v1 {
        US2::US2_None
    } else {
        let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("TRACE_LEVEL"); } LIT.with(|lit| lit.clone()) };
        let mut v4: Rc<str> = get_environment_variable_8(v3);
        ;
        ;
        ;
        ;
        ;
        let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
        let v6: Rc<str> = Rc::<str>::from(v5.to_lowercase());
        let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
        let mut v8: Rc<str> = Rc::<str>::from(v7.to_lowercase());
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
        let mut v10: Rc<str> = Rc::<str>::from(v9.to_lowercase());
        let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
        let v12: Rc<str> = Rc::<str>::from(v11.to_lowercase());
        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
        let mut v14: Rc<str> = Rc::<str>::from(v13.to_lowercase());
        let mut v15: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
        let mut v16: US3 = US3::US3_Verbose;
        v15.borrow_mut().push((v13, v16));
        let mut v17: US3 = US3::US3_Debug;
        v15.borrow_mut().push((v11, v17));
        let v18: US3 = US3::US3_Info;
        v15.borrow_mut().push((v9, v18));
        let mut v19: US3 = US3::US3_Warning;
        v15.borrow_mut().push((v7, v19));
        let v20: US3 = US3::US3_Critical;
        v15.borrow_mut().push((v5, v20));
        let mut v21: US3 = US3::US3_Verbose;
        v15.borrow_mut().push((v14, v21));
        let v22: US3 = US3::US3_Debug;
        v15.borrow_mut().push((v12, v22));
        let v23: US3 = US3::US3_Info;
        v15.borrow_mut().push((v10, v23));
        let mut v24: US3 = US3::US3_Warning;
        v15.borrow_mut().push((v8, v24));
        let v25: US3 = US3::US3_Critical;
        v15.borrow_mut().push((v6, v25));
        let mut v26: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v15.borrow().clone());
        let v27: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v26).as_ref().clone()));
        let mut v28: i32 = (v27.clone().borrow().len() as i32);
        let v29: US2 = US2::US2_None;
        let mut v30: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v28, l1: v29 }));
        while method6(&v30) {
            let v32: i32 = v30.borrow().l0;
            let v33: i32 = v32.wrapping_sub(1i32);
            let v34: US2 = v30.borrow().l1.clone();
            let (mut v35, mut v36): (Rc<str>, US3) = v27.borrow()[v33 as usize].clone();
            let mut v43: US2 = match &v34 {
                US2::US2_None => {
                    let mut v38: bool = v35 == v4 ;
                    if v38 {
                        US2::US2_Some(v36)
                    } else {
                        US2::US2_None
                    }
                }
                US2::US2_Some(v37) => {
                    let v37: US3 = v37.clone();
                    v34
                }
            };
            v30.borrow_mut().l0 = v33;
            v30.borrow_mut().l1 = v43;
            ()
        };
        let v44: US2 = v30.borrow().l1.clone();
        v44
    };
    let v46: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: 1i64 }));
    let v47: Rc<dyn Fn(Rc<str>) -> ()> = closure3();
    let v48: Rc<RefCell<Mut3>> = Rc::new(RefCell::new(Mut3 { l0: v47 }));
    let v49: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: true }));
    let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v51: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v50 }));
    let mut v54: US3 = match v45 {
        US2::US2_None => {
            v0
        }
        US2::US2_Some(v52) => {
            let v52: US3 = v52;
            v52
        }
    };
    let mut v55: Rc<RefCell<Mut6>> = Rc::new(RefCell::new(Mut6 { l0: v54 }));
    let v56: Option<i64> = None;
    (v46, v48, v49, v51, v55, v56)
}
fn fresh_c2(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = new_trace_state_7(v0.clone());
        (v1, v2, v3, v4, v5, v6)
    })
}
fn fresh_c4(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = new_trace_state_7(v0.clone());
        (v1, v2, v3, v4, v5, v6)
    })
}
fn fresh_c5() -> Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = new_trace_state_7(v0);
        (v1, v2, v3, v4, v5, v6)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn fresh_c6() -> Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = new_trace_state_7(v0);
        (v1, v2, v3, v4, v5, v6)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method11(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
                        let mut v8: bool = v4 == b'\n';
                        v8
                    }
                }
            };
            if v11 {
                let v12: i32 = v2.wrapping_add(1i32);
                v2 = v12;
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn method12(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 <= 0i32;
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
                v1 = v3;
                continue;
            } else {
                return v3;
            }
        }
    }
}
fn method10(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: i32 = 0i32;
    let mut v3: i32 = method11(v0.clone(), v1, v2);
    let mut v4: i32 = v1.wrapping_sub(1i32);
    let mut v5: Rc<str> = string_slice(&v0, v3 as i64, v4 as i64);
    let v6: i32 = (v5.clone().len() as i32);
    let v7: i32 = method12(v5.clone(), v6);
    let mut v8: Rc<str> = string_slice(&v5, 0i32 as i64, v7 as i64);
    v8
}
fn method14(mut v0: u64, mut v1: &Rc<RefCell<Mut7>>) -> bool {
    let mut v2: u64 = v1.borrow().l0;
    let mut v3: bool = v2 < v0;
    v3
}
fn method13(mut v0: &Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v1: u64 = (v0.clone().borrow().len() as u64);
    let mut v2: u64 = 0u64;
    let mut v3: Rc<RefCell<Mut7>> = Rc::new(RefCell::new(Mut7 { l0: v2 }));
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v4 }));
    while method14(v1, &v3) {
        let v7: u64 = v3.borrow().l0;
        let mut v8: Rc<str> = v0.borrow()[v7 as usize].clone();
        let mut v9: bool = v7 == 0u64;
        let mut v13: Rc<str> = if v9 {
            v8
        } else {
            let mut v10: Rc<str> = v5.borrow().l0.clone();
            let v12: Rc<str> = string_concat(&[&*v10, ", ", &*v8]);
            v12
        };
        v5.borrow_mut().l0 = v13;
        let mut v14: u64 = v7.wrapping_add(1u64);
        v3.borrow_mut().l0 = v14;
        ()
    };
    let mut v15: Rc<str> = v5.borrow().l0.clone();
    let mut v17: Rc<str> = string_concat(&["[", &*v15, "]"]);
    v17
}
fn method16(mut v0: Option<[i64; 3]>) -> Option<[i64; 3]> {
    v0
}
fn closure7() -> Rc<dyn Fn(([i64; 3])) -> US5> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(([i64; 3])) -> US5> = Rc::new(move |mut v0: ([i64; 3])| -> US5 {
        let mut v1: [i64; 3] = (v0);
        US5::US5_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn time_15(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>) -> Rc<str> {
    let v6: Option<[i64; 3]> = spiral_cfg_local_clock();
    let v7: Option<[i64; 3]> = method16(v6);
    let mut v8: Rc<dyn Fn(([i64; 3])) -> US5> = closure7();
    let mut v9: Option<US5> = v7.map(|x| v8(x));
    let mut v11: US5 = US5::US5_None;
    let v12: US5 = v11.clone();
    let mut v13: US5 = v9.unwrap_or(v12);
    let v27: u64 = match v13 {
        US5::US5_None => {
            let v23: u64 = spiral_cfg_epoch_nanos();
            let mut v24: u64 = v23.wrapping_div(1000000000u64);
            let v25: u64 = v24.wrapping_rem(86400u64);
            v25
        }
        US5::US5_Some(v14) => {
            let mut v14: [i64; 3] = v14;
            let mut v15: i64 = v14[0];
            let mut v16: i64 = v15.wrapping_mul(3600i64);
            let mut v17: i64 = v14[1];
            let v18: i64 = v17.wrapping_mul(60i64);
            let mut v19: i64 = v16.wrapping_add(v18);
            let v20: i64 = v14[2];
            let mut v21: i64 = v19.wrapping_add(v20);
            let v22: u64 = (v21 as u64);
            v22
        }
    };
    let mut v28: u64 = v27.wrapping_div(3600u64);
    let v29: u64 = v28.wrapping_rem(24u64);
    let mut v30: bool = v29 < 10u64;
    let v33: Rc<str> = if v30 {
        let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v31
    } else {
        let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v32
    };
    let v34: Rc<str> = Rc::<str>::from((v29).to_string());
    let v36: Rc<str> = string_concat(&[&*v33, &*v34, ":"]);
    let v37: u64 = v27.wrapping_div(60u64);
    let mut v38: u64 = v37.wrapping_rem(60u64);
    let v39: bool = v38 < 10u64;
    let v42: Rc<str> = if v39 {
        let mut v40: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v40
    } else {
        let v41: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v41
    };
    let mut v43: Rc<str> = Rc::<str>::from((v38).to_string());
    let v46: Rc<str> = string_concat(&[&*v36, &*v42, &*v43, ":"]);
    let v47: u64 = v27.wrapping_rem(60u64);
    let v48: bool = v47 < 10u64;
    let v51: Rc<str> = if v48 {
        let v49: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v49
    } else {
        let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v50
    };
    let v52: Rc<str> = Rc::<str>::from((v47).to_string());
    let mut v54: Rc<str> = string_concat(&[&*v46, &*v51, &*v52]);
    v54
}
fn method18(mut v0: &Rc<RefCell<Mut5>>, mut v1: Rc<str>) -> () {
    let mut v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = string_concat(&[&*v2, &*v1]);
    v0.borrow_mut().l0 = v3;
    ()
}
fn format_real_17(mut v0: i64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method18(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn level_str_19() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[90m"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = string_concat(&[&*v0, "v", &*v2]);
    v3
}
fn method9(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: &Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v34: Rc<str> = if v13 {
        let mut v14: Rc<str> = method13(v12);
        let v18: Rc<str> = string_concat(&["v spiral_wasm.main / { args = ", &*v14, " }"]);
        v18
    } else {
        let mut v19: i64 = v0.borrow().l0;
        let v20: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v22: Rc<str> = format_real_17(v19);
        let mut v24: Rc<str> = level_str_19();
        let v29: Rc<str> = method13(v12);
        let v33: Rc<str> = string_concat(&[&*v20, " ", &*v22, &*v24, " spiral_wasm.main / { args = ", &*v29, " }"]);
        v33
    };
    method10(v34)
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method20() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    v0
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
                let v6: i32 = v2.wrapping_add(1i32);
                v2 = v6;
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
                v1 = v3;
                continue;
            } else {
                return v3;
            }
        }
    }
}
fn closure9() -> Rc<dyn Fn((std::string::String)) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> Rc<str>> = Rc::new(move |mut v0: (std::string::String)| -> Rc<str> {
        let mut v1: std::string::String = (v0);
        let mut v3: Rc<str> = Rc::<str>::from(String::as_str(&v1));
        let mut v4: i32 = (v3.clone().len() as i32);
        let mut v5: i32 = 0i32;
        let v6: i32 = method21(v3.clone(), v4, v5);
        let v7: i32 = v4.wrapping_sub(1i32);
        let mut v8: Rc<str> = string_slice(&v3, v6 as i64, v7 as i64);
        let mut v9: i32 = (v8.clone().len() as i32);
        let mut v10: i32 = method22(v8.clone(), v9);
        let mut v11: Rc<str> = string_slice(&v8, 0i32 as i64, v10 as i64);
        v11
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method23(mut v0: Option<Rc<str>>) -> Option<Rc<str>> {
    v0
}
fn closure10() -> Rc<dyn Fn((Rc<str>)) -> US6> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> US6> = Rc::new(move |mut v0: (Rc<str>)| -> US6 {
        let mut v1: Rc<str> = (v0);
        US6::US6_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method25() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method26(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: Rc<str>) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v32: Rc<str> = if v13 {
        let mut v17: Rc<str> = string_concat(&["v spiral_wasm.run / { wasm_path = ", &*v12, " }"]);
        v17
    } else {
        let v18: i64 = v0.borrow().l0;
        let mut v19: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v21: Rc<str> = format_real_17(v18);
        let v23: Rc<str> = level_str_19();
        let v31: Rc<str> = string_concat(&[&*v19, " ", &*v21, &*v23, " spiral_wasm.run / { wasm_path = ", &*v12, " }"]);
        v31
    };
    method10(v32)
}
fn format_real_30(mut v0: u8) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method18(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method29(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: u8, mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v14: near_workspaces::Contract) -> Rc<str> {
    let mut v15: bool = cfg!(target_arch = "wasm32");
    let v48: Rc<str> = if v15 {
        let mut v16: Rc<str> = format_real_30(v12);
        let mut v19: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Worker<near_workspaces::network::Sandbox>>") } } (&&W(&v13)).s() });
        let v22: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Contract>") } } (&&W(&v14)).s() });
        let mut v26: Rc<str> = string_concat(&["v spiral_wasm.run / { retry = ", &*v16, "; worker = ", &*v19, "; contract = ", &*v22, " }"]);
        v26
    } else {
        let v27: i64 = v0.borrow().l0;
        let mut v28: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v30: Rc<str> = format_real_17(v27);
        let v32: Rc<str> = level_str_19();
        let v37: Rc<str> = format_real_30(v12);
        let mut v40: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Worker<near_workspaces::network::Sandbox>>") } } (&&W(&v13)).s() });
        let mut v43: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Contract>") } } (&&W(&v14)).s() });
        let v47: Rc<str> = string_concat(&[&*v28, " ", &*v30, &*v32, " spiral_wasm.run / { retry = ", &*v37, "; worker = ", &*v40, "; contract = ", &*v43, " }"]);
        v47
    };
    method10(v48)
}
fn method31(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: u8, mut v13: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
    let mut v14: bool = cfg!(target_arch = "wasm32");
    let v41: Rc<str> = if v14 {
        let mut v15: Rc<str> = format_real_30(v12);
        let v18: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::result::ExecutionFinalResult>") } } (&&W(&v13)).s() });
        let v22: Rc<str> = string_concat(&["v spiral_wasm.run / { retry = ", &*v15, "; result = ", &*v18, " }"]);
        v22
    } else {
        let v23: i64 = v0.borrow().l0;
        let mut v24: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v26: Rc<str> = format_real_17(v23);
        let mut v28: Rc<str> = level_str_19();
        let v33: Rc<str> = format_real_30(v12);
        let v36: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::result::ExecutionFinalResult>") } } (&&W(&v13)).s() });
        let mut v40: Rc<str> = string_concat(&[&*v24, " ", &*v26, &*v28, " spiral_wasm.run / { retry = ", &*v33, "; result = ", &*v36, " }"]);
        v40
    };
    method10(v41)
}
fn closure11() -> Rc<dyn Fn((&str)) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((&str)) -> std::string::String> = Rc::new(move |mut v0: (&str)| -> std::string::String {
        let mut v1: &str = (v0);
        let mut v3: std::string::String = String::from(v1);
        v3
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure12() -> Rc<dyn Fn(std::string::String) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> ()> = Rc::new(move |mut v0: std::string::String| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn position_of_34(mut v0: u8, mut v1: Rc<str>, mut v2: i32) -> i32 {
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
                v2 = v7;
                continue;
            }
        }
    }
}
fn digits_value_35(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: i32 = (v0.clone().len() as i32);
        let mut v4: bool = v1 >= v3;
        if v4 {
            return v2;
        } else {
            let mut v5: i32 = v1.wrapping_add(1i32);
            let v6: i32 = v2.wrapping_mul(10i32);
            let v7: u8 = v0.clone().as_bytes()[v1 as usize];
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0123456789"); } LIT.with(|lit| lit.clone()) };
            let mut v9: i32 = 0i32;
            let mut v10: i32 = position_of_34(v7, v8, v9);
            let mut v11: i32 = v6.wrapping_add(v10);
            (v1, v2) = (v5, v11);
            continue;
        }
    }
}
fn zeros_from_36(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: i32 = (v0.clone().len() as i32);
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
            v1 = v7;
            continue;
        } else {
            return v1;
        }
    }
}
fn zeros_before_37(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 > 0i32;
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
            v1 = v7;
            continue;
        } else {
            return v1;
        }
    }
}
fn repeated_zeros_38(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let mut v2: bool = v0 <= 0i32;
        if v2 {
            return v1;
        } else {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: Rc<str> = string_concat(&[&*v1, "0"]);
            (v0, v1) = (v3, v4);
            continue;
        }
    }
}
fn digits_text_39(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let mut v2: i32 = v0.wrapping_rem(10i32);
        let mut v3: i32 = v2.wrapping_add(1i32);
        let mut v4: i32 = v3.wrapping_sub(1i32);
        let mut v5: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0123456789"); } LIT.with(|lit| lit.clone()) }, v2 as i64, v4 as i64);
        let v6: bool = v0 < 10i32;
        if v6 {
            let v7: Rc<str> = string_concat(&[&*v5, &*v1]);
            return v7;
        } else {
            let mut v8: i32 = v0.wrapping_div(10i32);
            let mut v9: Rc<str> = string_concat(&[&*v5, &*v1]);
            (v0, v1) = (v8, v9);
            continue;
        }
    }
}
fn format_real_33(mut v0: f64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1.clone() }));
    () /* backend_switch: no Rust arm (lib/spiral) */;
    let mut v3: bool = v0.is_nan();
    let mut v13: Rc<str> = if v3 {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("NaN"); } LIT.with(|lit| lit.clone()) };
        v4
    } else {
        () /* backend_switch: no Rust arm (lib/spiral) */;
        let mut v5: bool = v0.is_infinite();
        if v5 {
            let v6: f64 = -(v0);
            let v7: bool = v0 > v6;
            if v7 {
                let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Infinity"); } LIT.with(|lit| lit.clone()) };
                v8
            } else {
                let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-Infinity"); } LIT.with(|lit| lit.clone()) };
                v9
            }
        } else {
            let mut v11: Rc<str> = Rc::<str>::from(format!("{:?}", v0));
            v11
        }
    };
    let mut v14: bool = &*v13 == "NaN";
    let mut v16: bool = if v14 {
        true
    } else {
        let mut v15: bool = &*v13 == "Infinity";
        v15
    };
    let v18: bool = if v16 {
        true
    } else {
        let mut v17: bool = &*v13 == "-Infinity";
        v17
    };
    let v165: Rc<str> = if v18 {
        v13
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
        let mut v30: Rc<str> = if v23 {
            let mut v24: i32 = v19.wrapping_sub(1i32);
            let v25: bool = v24 <= 0i32;
            if v25 {
                v1.clone()
            } else {
                let mut v26: i32 = 1i32.wrapping_add(v24);
                let v27: i32 = v26.wrapping_sub(1i32);
                let mut v28: Rc<str> = string_slice(&v13, 1i32 as i64, v27 as i64);
                v28
            }
        } else {
            v13
        };
        let v32: Rc<str> = if v23 {
            let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-"); } LIT.with(|lit| lit.clone()) };
            v31
        } else {
            v1.clone()
        };
        let v33: u8 = b'e';
        let v34: i32 = 0i32;
        let mut v35: i32 = position_of_34(v33, v30.clone(), v34);
        let v36: bool = v35 >= 0i32;
        let mut v40: i32 = if v36 {
            v35
        } else {
            let v37: u8 = b'E';
            let mut v38: i32 = 0i32;
            position_of_34(v37, v30.clone(), v38)
        };
        let v41: bool = v40 < 0i32;
        let v46: Rc<str> = if v41 {
            v30.clone()
        } else {
            let v42: bool = v40 <= 0i32;
            if v42 {
                v1.clone()
            } else {
                let mut v43: i32 = v40.wrapping_sub(1i32);
                let v44: Rc<str> = string_slice(&v30.clone(), 0i32 as i64, v43 as i64);
                v44
            }
        };
        let v47: u8 = b'.';
        let v48: i32 = 0i32;
        let v49: i32 = position_of_34(v47, v46.clone(), v48);
        let mut v50: bool = v49 < 0i32;
        let mut v55: Rc<str> = if v50 {
            v46.clone()
        } else {
            let v51: bool = v49 <= 0i32;
            if v51 {
                v1.clone()
            } else {
                let v52: i32 = v49.wrapping_sub(1i32);
                let v53: Rc<str> = string_slice(&v46.clone(), 0i32 as i64, v52 as i64);
                v53
            }
        };
        let mut v65: Rc<str> = if v50 {
            v1.clone()
        } else {
            let v56: i32 = v49.wrapping_add(1i32);
            let mut v57: i32 = (v46.clone().len() as i32);
            let mut v58: i32 = v57.wrapping_sub(v49);
            let mut v59: i32 = v58.wrapping_sub(1i32);
            let mut v60: bool = v59 <= 0i32;
            if v60 {
                v1.clone()
            } else {
                let v61: i32 = v56.wrapping_add(v59);
                let mut v62: i32 = v61.wrapping_sub(1i32);
                let v63: Rc<str> = string_slice(&v46, v56 as i64, v62 as i64);
                v63
            }
        };
        let v66: Rc<str> = string_concat(&[&*v55, &*v65]);
        let v67: i32 = (v55.len() as i32);
        let v95: i32 = if v41 {
            0i32
        } else {
            let mut v68: i32 = v40.wrapping_add(1i32);
            let v69: i32 = (v30.clone().len() as i32);
            let mut v70: i32 = v69.wrapping_sub(v40);
            let mut v71: i32 = v70.wrapping_sub(1i32);
            let mut v72: bool = v71 <= 0i32;
            let v76: Rc<str> = if v72 {
                v1.clone()
            } else {
                let v73: i32 = v68.wrapping_add(v71);
                let v74: i32 = v73.wrapping_sub(1i32);
                let mut v75: Rc<str> = string_slice(&v30, v68 as i64, v74 as i64);
                v75
            };
            let v77: i32 = (v76.clone().len() as i32);
            let v78: bool = v77 == 0i32;
            if v78 {
                0i32
            } else {
                let v79: u8 = v76.clone().as_bytes()[0i32 as usize];
                let v80: bool = v79 == b'-';
                if v80 {
                    let v81: i32 = 1i32;
                    let v82: i32 = 0i32;
                    let v83: i32 = digits_value_35(v76, v81, v82);
                    let v84: i32 = v83.wrapping_neg();
                    v84
                } else {
                    let mut v85: bool = v79 == b'+';
                    if v85 {
                        let v86: i32 = 1i32;
                        let mut v87: i32 = 0i32;
                        digits_value_35(v76, v86, v87)
                    } else {
                        let v89: i32 = 0i32;
                        let v90: i32 = 0i32;
                        digits_value_35(v76, v89, v90)
                    }
                }
            }
        };
        let mut v96: i32 = v67.wrapping_add(v95);
        let v97: i32 = 0i32;
        let mut v98: i32 = zeros_from_36(v66.clone(), v97);
        let v99: i32 = (v66.clone().len() as i32);
        let v100: i32 = zeros_before_37(v66.clone(), v99);
        let v101: bool = v98 >= v100;
        if v101 {
            let mut v102: Rc<str> = string_concat(&[&*v32, "0.0"]);
            v102
        } else {
            let v103: i32 = v100.wrapping_sub(v98);
            let v104: bool = v103 <= 0i32;
            let v108: Rc<str> = if v104 {
                v1.clone()
            } else {
                let v105: i32 = v98.wrapping_add(v103);
                let v106: i32 = v105.wrapping_sub(1i32);
                let v107: Rc<str> = string_slice(&v66, v98 as i64, v106 as i64);
                v107
            };
            let v109: i32 = v96.wrapping_sub(v98);
            let v110: i32 = v109.wrapping_sub(1i32);
            let v111: bool = -4i32 <= v110;
            let v113: bool = if v111 {
                let v112: bool = v110 < 16i32;
                v112
            } else {
                false
            };
            if v113 {
                let v114: i32 = (v108.clone().len() as i32);
                let v115: bool = v109 <= 0i32;
                let v135: Rc<str> = if v115 {
                    let v116: i32 = v109.wrapping_neg();
                    let v117: Rc<str> = repeated_zeros_38(v116, v1);
                    let v119: Rc<str> = string_concat(&["0.", &*v117, &*v108]);
                    v119
                } else {
                    let v120: bool = v114 <= v109;
                    if v120 {
                        let v121: i32 = v109.wrapping_sub(v114);
                        let v122: Rc<str> = repeated_zeros_38(v121, v1);
                        let v124: Rc<str> = string_concat(&[&*v108, &*v122, ".0"]);
                        v124
                    } else {
                        let v125: Rc<str> = string_slice(&v108.clone(), 0i32 as i64, v110 as i64);
                        let v126: i32 = v114.wrapping_sub(v109);
                        let mut v127: bool = v126 <= 0i32;
                        let v131: Rc<str> = if v127 {
                            v1
                        } else {
                            let v128: i32 = v109.wrapping_add(v126);
                            let v129: i32 = v128.wrapping_sub(1i32);
                            let mut v130: Rc<str> = string_slice(&v108, v109 as i64, v129 as i64);
                            v130
                        };
                        let v133: Rc<str> = string_concat(&[&*v125, ".", &*v131]);
                        v133
                    }
                };
                let v136: Rc<str> = string_concat(&[&*v32, &*v135]);
                v136
            } else {
                let v137: i32 = (v108.clone().len() as i32);
                let v138: bool = v137 > 1i32;
                let v146: Rc<str> = if v138 {
                    let v139: i32 = v137.wrapping_sub(1i32);
                    let mut v140: bool = v139 <= 0i32;
                    let v144: Rc<str> = if v140 {
                        v1.clone()
                    } else {
                        let v141: i32 = 1i32.wrapping_add(v139);
                        let v142: i32 = v141.wrapping_sub(1i32);
                        let mut v143: Rc<str> = string_slice(&v108.clone(), 1i32 as i64, v142 as i64);
                        v143
                    };
                    let v145: Rc<str> = string_concat(&[".", &*v144]);
                    v145
                } else {
                    v1.clone()
                };
                let v147: Rc<str> = string_slice(&v108, 0i32 as i64, 0i32 as i64);
                let v148: bool = v110 < 0i32;
                let v151: Rc<str> = if v148 {
                    let v149: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e-"); } LIT.with(|lit| lit.clone()) };
                    v149
                } else {
                    let v150: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e+"); } LIT.with(|lit| lit.clone()) };
                    v150
                };
                let v153: i32 = if v148 {
                    let v152: i32 = v110.wrapping_neg();
                    v152
                } else {
                    v110
                };
                let v154: bool = v153 < 10i32;
                let mut v158: Rc<str> = if v154 {
                    let v155: Rc<str> = digits_text_39(v153, v1);
                    let v156: Rc<str> = string_concat(&["0", &*v155]);
                    v156
                } else {
                    digits_text_39(v153, v1)
                };
                let v162: Rc<str> = string_concat(&[&*v32, &*v147, &*v146, &*v151, &*v158]);
                v162
            }
        }
    };
    method18(&v2, v165);
    let mut v166: Rc<str> = v2.borrow().l0.clone();
    v166
}
fn format_real_40(mut v0: u64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method18(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn level_str_41() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = string_concat(&[&*v0, "i", &*v2]);
    v3
}
fn method32(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: u8, mut v13: f64, mut v14: u64) -> Rc<str> {
    let mut v15: bool = cfg!(target_arch = "wasm32");
    let v48: Rc<str> = if v15 {
        let mut v16: Rc<str> = format_real_30(v12);
        let mut v19: Rc<str> = format_real_33(v13);
        let v22: Rc<str> = format_real_40(v14);
        let mut v26: Rc<str> = string_concat(&["i near_workspaces.print_usd / { retry = ", &*v16, "; total_gas_burnt_usd = ", &*v19, "; total_gas_burnt = ", &*v22, " }"]);
        v26
    } else {
        let v27: i64 = v0.borrow().l0;
        let mut v28: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v30: Rc<str> = format_real_17(v27);
        let v32: Rc<str> = level_str_41();
        let v37: Rc<str> = format_real_30(v12);
        let mut v40: Rc<str> = format_real_33(v13);
        let mut v43: Rc<str> = format_real_40(v14);
        let v47: Rc<str> = string_concat(&[&*v28, " ", &*v30, &*v32, " near_workspaces.print_usd / { retry = ", &*v37, "; total_gas_burnt_usd = ", &*v40, "; total_gas_burnt = ", &*v43, " }"]);
        v47
    };
    method10(v48)
}
fn format_real_43(mut v0: bool) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1 }));
    let mut v5: Rc<str> = if v0 {
        let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("true"); } LIT.with(|lit| lit.clone()) };
        v3
    } else {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("false"); } LIT.with(|lit| lit.clone()) };
        v4
    };
    method18(&v2, v5);
    let v6: Rc<str> = v2.borrow().l0.clone();
    v6
}
fn method42(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: bool, mut v13: f64, mut v14: f64, mut v15: u64, mut v16: u128) -> Rc<str> {
    let mut v17: bool = cfg!(target_arch = "wasm32");
    let mut v62: Rc<str> = if v17 {
        let v18: Rc<str> = format_real_43(v12);
        let mut v21: Rc<str> = format_real_33(v13);
        let mut v24: Rc<str> = format_real_33(v14);
        let v27: Rc<str> = format_real_40(v15);
        let mut v30: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<u128>") } } (&&W(&v16)).s() });
        let v34: Rc<str> = string_concat(&["i near_workspaces.print_usd / outcome / { is_success = ", &*v18, "; gas_burnt_usd = ", &*v21, "; tokens_burnt_usd = ", &*v24, "; gas_burnt = ", &*v27, "; tokens_burnt = ", &*v30, " }"]);
        v34
    } else {
        let mut v35: i64 = v0.borrow().l0;
        let v36: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v38: Rc<str> = format_real_17(v35);
        let mut v40: Rc<str> = level_str_41();
        let v45: Rc<str> = format_real_43(v12);
        let v48: Rc<str> = format_real_33(v13);
        let v51: Rc<str> = format_real_33(v14);
        let mut v54: Rc<str> = format_real_40(v15);
        let mut v57: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<u128>") } } (&&W(&v16)).s() });
        let v61: Rc<str> = string_concat(&[&*v36, " ", &*v38, &*v40, " near_workspaces.print_usd / outcome / { is_success = ", &*v45, "; gas_burnt_usd = ", &*v48, "; tokens_burnt_usd = ", &*v51, "; gas_burnt = ", &*v54, "; tokens_burnt = ", &*v57, " }"]);
        v61
    };
    method10(v62)
}
fn closure13() -> Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = Rc::new(move |mut v0: near_workspaces::result::ExecutionOutcome| -> () {
        let mut v2: bool = v0.is_success();
        let mut v4: near_workspaces::types::Gas = v0.gas_burnt;
        let v6: u64 = v4.as_gas();
        let v7: f64 = (v6 as f64);
        let mut v8: f64 = v7 / 10000000000000000.0f64;
        let mut v9: f64 = v8 * 6.68f64;
        let mut v11: near_workspaces::types::NearToken = v0.tokens_burnt;
        let mut v13: u128 = v11.as_yoctonear();
        let mut v15: f64 = v13 as f64;
        let mut v16: f64 = v15 / 1E+24f64;
        let mut v17: f64 = v16 * 6.68f64;
        let v18: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
        let mut v40: bool = if v18 {
            true
        } else {
            let v20: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
            { let _ = spiral_trace_hold(&v20); };
            let v22: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
            let (mut v23, mut v24, mut v25, mut v26, mut v27, mut v28): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v22);
            let v29: US3 = v27.borrow().l0.clone();
            let v34: i32 = match v29 {
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
            let mut v35: bool = v25.borrow().l0;
            let v36: bool = v35 == false;
            let mut v38: bool = if v36 {
                false
            } else {
                let v37: bool = 30i32 >= v34;
                v37
            };
            let v39: bool = v38 == false;
            v39
        };
        let mut v87: US4 = if v40 {
            US4::US4_None
        } else {
            let mut v43: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
            { let _ = spiral_trace_hold(&v43); };
            let v45: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
            let (mut v46, mut v47, mut v48, mut v49, mut v50, mut v51): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v45);
            let v52: Rc<str> = method42(&v46, &v47, &v48, &v49, &v50, v51.clone(), &v46, &v47, &v48, &v49, &v50, v51.clone(), v2, v9, v17, v6, v13);
            { let _ = spiral_trace_hold(&v43); };
            let (mut v55, mut v56, mut v57, mut v58, mut v59, mut v60): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v45);
            let v61: i64 = v55.borrow().l0;
            let mut v62: i64 = v61.wrapping_add(1i64);
            v55.borrow_mut().l0 = v62;
            let v63: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
            let v64: bool = cfg!(target_arch = "wasm32");
            if v64 {
                let mut v65: Rc<str> = v58.borrow().l0.clone();
                let v66: bool = &*v65 == "";
                let v73: Rc<str> = if v66 {
                    v52.clone()
                } else {
                    let v67: bool = &*v52 == "";
                    if v67 {
                        let mut v68: Rc<str> = v58.borrow().l0.clone();
                        v68
                    } else {
                        let v69: Rc<str> = v58.borrow().l0.clone();
                        let mut v71: Rc<str> = string_concat(&[&*v69, "\n", &*v52]);
                        v71
                    }
                };
                let mut v75: usize = v73.len();
                let v76: i32 = ((v75) as i32);
                let v77: i32 = v76.wrapping_add(14999i32);
                let v78: i32 = v77.wrapping_div(15000i32);
                let v79: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                let v80: bool = v52 != v79 ;
                let v82: bool = if v80 {
                    let v81: bool = v78 <= 1i32;
                    v81
                } else {
                    false
                };
                if v82 {
                    v58.borrow_mut().l0 = v73;
                    ()
                } else {
                    v58.borrow_mut().l0 = v79;
                    { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v73); };
                    ()
                }
            } else {
                println!("{}", v52);
                ()
            };
            let mut v85: Rc<dyn Fn(Rc<str>) -> ()> = v56.borrow().l0.clone();
            v85(v52);
            US4::US4_Some(v55, v56, v57, v58, v59, v60)
        };
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method44(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v34: Rc<str> = if v13 {
        let mut v14: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>>") } } (&&W(&v12)).s() });
        let v18: Rc<str> = string_concat(&["v spiral_wasm.run / { result2 = ", &*v14, " }"]);
        v18
    } else {
        let mut v19: i64 = v0.borrow().l0;
        let v20: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v22: Rc<str> = format_real_17(v19);
        let mut v24: Rc<str> = level_str_19();
        let v29: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>>") } } (&&W(&v12)).s() });
        let v33: Rc<str> = string_concat(&[&*v20, " ", &*v22, &*v24, " spiral_wasm.run / { result2 = ", &*v29, " }"]);
        v33
    };
    method10(v34)
}
fn method45(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn format_real_47(mut v0: i32) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method18(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method46(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: i32, mut v13: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v14: bool = cfg!(target_arch = "wasm32");
    let v41: Rc<str> = if v14 {
        let mut v15: Rc<str> = format_real_47(v12);
        let v18: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v13)).s() });
        let v22: Rc<str> = string_concat(&["v spiral_wasm.run / { receipt_failures_len = ", &*v15, "; receipt_failures = ", &*v18, " }"]);
        v22
    } else {
        let v23: i64 = v0.borrow().l0;
        let mut v24: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v26: Rc<str> = format_real_17(v23);
        let mut v28: Rc<str> = level_str_19();
        let v33: Rc<str> = format_real_47(v12);
        let v36: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v13)).s() });
        let mut v40: Rc<str> = string_concat(&[&*v24, " ", &*v26, &*v28, " spiral_wasm.run / { receipt_failures_len = ", &*v33, "; receipt_failures = ", &*v36, " }"]);
        v40
    };
    method10(v41)
}
fn method48(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn method49(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: i32, mut v13: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v14: bool = cfg!(target_arch = "wasm32");
    let v41: Rc<str> = if v14 {
        let mut v15: Rc<str> = format_real_47(v12);
        let v18: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v13)).s() });
        let v22: Rc<str> = string_concat(&["v spiral_wasm.run / { receipt_outcomes_len = ", &*v15, "; receipt_outcomes = ", &*v18, " }"]);
        v22
    } else {
        let v23: i64 = v0.borrow().l0;
        let mut v24: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v26: Rc<str> = format_real_17(v23);
        let mut v28: Rc<str> = level_str_19();
        let v33: Rc<str> = format_real_47(v12);
        let v36: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v13)).s() });
        let mut v40: Rc<str> = string_concat(&[&*v24, " ", &*v26, &*v28, " spiral_wasm.run / { receipt_outcomes_len = ", &*v33, "; receipt_outcomes = ", &*v36, " }"]);
        v40
    };
    method10(v41)
}
fn method50(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v34: Rc<str> = if v13 {
        let mut v14: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v12)).s() });
        let v18: Rc<str> = string_concat(&["v spiral_wasm.run / { json = ", &*v14, " }"]);
        v18
    } else {
        let mut v19: i64 = v0.borrow().l0;
        let v20: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v22: Rc<str> = format_real_17(v19);
        let mut v24: Rc<str> = level_str_19();
        let v29: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v12)).s() });
        let v33: Rc<str> = string_concat(&[&*v20, " ", &*v22, &*v24, " spiral_wasm.run / { json = ", &*v29, " }"]);
        v33
    };
    method10(v34)
}
fn method51(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v34: Rc<str> = if v13 {
        let mut v14: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v12)).s() });
        let v18: Rc<str> = string_concat(&["v spiral_wasm.run / { borsh = ", &*v14, " }"]);
        v18
    } else {
        let mut v19: i64 = v0.borrow().l0;
        let v20: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v22: Rc<str> = format_real_17(v19);
        let mut v24: Rc<str> = level_str_19();
        let v29: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v12)).s() });
        let v33: Rc<str> = string_concat(&[&*v20, " ", &*v22, &*v24, " spiral_wasm.run / { borsh = ", &*v29, " }"]);
        v33
    };
    method10(v34)
}
fn fn_28(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let mut v9: Result<near_workspaces::Worker<near_workspaces::network::Sandbox>, near_workspaces::error::Error> = near_workspaces::sandbox().await;
    let mut v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
    let mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox> = v11.clone();
    let mut v15: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::Contract, near_workspaces::error::Error>>>> = Box::pin(v13.dev_deploy(&v0));
    let mut v17: Result<near_workspaces::Contract, near_workspaces::error::Error> = v15.await;
    let mut v19: near_workspaces::Contract = v17?;
    let v20: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v42: bool = if v20 {
        true
    } else {
        let v22: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v22); };
        let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v25, mut v26, mut v27, mut v28, mut v29, mut v30): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v24);
        let v31: US3 = v29.borrow().l0.clone();
        let v36: i32 = match v31 {
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
        let v37: bool = v27.borrow().l0;
        let mut v38: bool = v37 == false;
        let mut v40: bool = if v38 {
            false
        } else {
            let v39: bool = 10i32 >= v36;
            v39
        };
        let v41: bool = v40 == false;
        v41
    };
    let v89: US4 = if v42 {
        US4::US4_None
    } else {
        let v45: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v45); };
        let v47: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v48, mut v49, mut v50, mut v51, mut v52, mut v53): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v47);
        let mut v54: Rc<str> = method29(&v48, &v49, &v50, &v51, &v52, v53.clone(), &v48, &v49, &v50, &v51, &v52, v53.clone(), v1, v11, v19.clone());
        { let _ = spiral_trace_hold(&v45); };
        let (mut v57, mut v58, mut v59, mut v60, mut v61, mut v62): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v47);
        let v63: i64 = v57.borrow().l0;
        let v64: i64 = v63.wrapping_add(1i64);
        v57.borrow_mut().l0 = v64;
        let mut v65: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v66: bool = cfg!(target_arch = "wasm32");
        if v66 {
            let v67: Rc<str> = v60.borrow().l0.clone();
            let mut v68: bool = &*v67 == "";
            let mut v75: Rc<str> = if v68 {
                v54.clone()
            } else {
                let v69: bool = &*v54 == "";
                if v69 {
                    let mut v70: Rc<str> = v60.borrow().l0.clone();
                    v70
                } else {
                    let mut v71: Rc<str> = v60.borrow().l0.clone();
                    let v73: Rc<str> = string_concat(&[&*v71, "\n", &*v54]);
                    v73
                }
            };
            let v77: usize = v75.len();
            let v78: i32 = ((v77) as i32);
            let v79: i32 = v78.wrapping_add(14999i32);
            let v80: i32 = v79.wrapping_div(15000i32);
            let v81: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v82: bool = v54 != v81 ;
            let v84: bool = if v82 {
                let v83: bool = v80 <= 1i32;
                v83
            } else {
                false
            };
            if v84 {
                v60.borrow_mut().l0 = v75;
                ()
            } else {
                v60.borrow_mut().l0 = v81;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v75); };
                ()
            }
        } else {
            println!("{}", v54);
            ()
        };
        let mut v87: Rc<dyn Fn(Rc<str>) -> ()> = v58.borrow().l0.clone();
        v87(v54);
        US4::US4_Some(v57, v58, v59, v60, v61, v62)
    };
    let v91: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v92: near_workspaces::operations::CallTransaction = v19.call(&*v91);
    let v94: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v96: near_workspaces::operations::CallTransaction = v92.gas(v94);
    let mut v98: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v96.transact());
    let v100: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v98.await;
    let mut v102: near_workspaces::result::ExecutionFinalResult = v100?;
    let v103: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v125: bool = if v103 {
        true
    } else {
        let v105: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v105); };
        let v107: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v108, mut v109, mut v110, mut v111, mut v112, mut v113): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v107);
        let v114: US3 = v112.borrow().l0.clone();
        let v119: i32 = match v114 {
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
        let v120: bool = v110.borrow().l0;
        let v121: bool = v120 == false;
        let v123: bool = if v121 {
            false
        } else {
            let v122: bool = 10i32 >= v119;
            v122
        };
        let v124: bool = v123 == false;
        v124
    };
    let v172: US4 = if v125 {
        US4::US4_None
    } else {
        let v128: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v128); };
        let mut v130: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v131, mut v132, mut v133, mut v134, mut v135, mut v136): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v130);
        let v137: Rc<str> = method31(&v131, &v132, &v133, &v134, &v135, v136.clone(), &v131, &v132, &v133, &v134, &v135, v136.clone(), v1, v102.clone());
        { let _ = spiral_trace_hold(&v128); };
        let (mut v140, mut v141, mut v142, mut v143, mut v144, mut v145): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v130);
        let v146: i64 = v140.borrow().l0;
        let v147: i64 = v146.wrapping_add(1i64);
        v140.borrow_mut().l0 = v147;
        let v148: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v149: bool = cfg!(target_arch = "wasm32");
        if v149 {
            let v150: Rc<str> = v143.borrow().l0.clone();
            let v151: bool = &*v150 == "";
            let mut v158: Rc<str> = if v151 {
                v137.clone()
            } else {
                let v152: bool = &*v137 == "";
                if v152 {
                    let v153: Rc<str> = v143.borrow().l0.clone();
                    v153
                } else {
                    let v154: Rc<str> = v143.borrow().l0.clone();
                    let v156: Rc<str> = string_concat(&[&*v154, "\n", &*v137]);
                    v156
                }
            };
            let v160: usize = v158.len();
            let mut v161: i32 = ((v160) as i32);
            let v162: i32 = v161.wrapping_add(14999i32);
            let v163: i32 = v162.wrapping_div(15000i32);
            let v164: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v165: bool = v137 != v164 ;
            let v167: bool = if v165 {
                let mut v166: bool = v163 <= 1i32;
                v166
            } else {
                false
            };
            if v167 {
                v143.borrow_mut().l0 = v158;
                ()
            } else {
                v143.borrow_mut().l0 = v164;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v158); };
                ()
            }
        } else {
            println!("{}", v137);
            ()
        };
        let mut v170: Rc<dyn Fn(Rc<str>) -> ()> = v141.borrow().l0.clone();
        v170(v137);
        US4::US4_Some(v140, v141, v142, v143, v144, v145)
    };
    let v174: Vec<&str> = v102.logs();
    let mut v176: Rc<dyn Fn((&str)) -> std::string::String> = closure11();
    let mut v177: Vec<std::string::String> = v174.iter().map(|x| v176(x.clone())).collect::<Vec<_>>();
    let mut v179: Rc<dyn Fn(std::string::String) -> ()> = closure12();
    let mut v180: bool = true; v177.iter().for_each(|x| { v179(x.clone()); }); //;
    let v181: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
    let v203: bool = if v181 {
        true
    } else {
        let v183: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v183); };
        let mut v185: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v186, mut v187, mut v188, mut v189, mut v190, mut v191): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v185);
        let v192: US3 = v190.borrow().l0.clone();
        let v197: i32 = match v192 {
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
        let v198: bool = v188.borrow().l0;
        let v199: bool = v198 == false;
        let v201: bool = if v199 {
            false
        } else {
            let v200: bool = 30i32 >= v197;
            v200
        };
        let v202: bool = v201 == false;
        v202
    };
    let v242: US4 = if v203 {
        US4::US4_None
    } else {
        let v206: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v206); };
        let v208: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v209, mut v210, mut v211, mut v212, mut v213, mut v214): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v208);
        let v215: i64 = v209.borrow().l0;
        let v216: i64 = v215.wrapping_add(1i64);
        v209.borrow_mut().l0 = v216;
        let v217: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let v218: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v219: bool = cfg!(target_arch = "wasm32");
        if v219 {
            let v220: Rc<str> = v212.borrow().l0.clone();
            let v221: bool = &*v220 == "";
            let v228: Rc<str> = if v221 {
                v217.clone()
            } else {
                let mut v222: bool = &*v217 == "";
                if v222 {
                    let v223: Rc<str> = v212.borrow().l0.clone();
                    v223
                } else {
                    let v224: Rc<str> = v212.borrow().l0.clone();
                    let v226: Rc<str> = string_concat(&[&*v224, "\n", &*v217]);
                    v226
                }
            };
            let v230: usize = v228.len();
            let v231: i32 = ((v230) as i32);
            let v232: i32 = v231.wrapping_add(14999i32);
            let v233: i32 = v232.wrapping_div(15000i32);
            let v234: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v235: bool = v217 != v234 ;
            let v237: bool = if v235 {
                let v236: bool = v233 <= 1i32;
                v236
            } else {
                false
            };
            if v237 {
                v212.borrow_mut().l0 = v228;
                ()
            } else {
                v212.borrow_mut().l0 = v234;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v228); };
                ()
            }
        } else {
            println!("{}", v217);
            ()
        };
        let mut v240: Rc<dyn Fn(Rc<str>) -> ()> = v210.borrow().l0.clone();
        v240(v217);
        US4::US4_Some(v209, v210, v211, v212, v213, v214)
    };
    let mut v244: near_workspaces::types::Gas = v102.total_gas_burnt;
    let v246: u64 = v244.as_gas();
    let v247: f64 = (v246 as f64);
    let v248: f64 = v247 / 10000000000000000.0f64;
    let v249: f64 = v248 * 6.68f64;
    let mut v250: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
    let v272: bool = if v250 {
        true
    } else {
        let v252: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v252); };
        let v254: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v255, mut v256, mut v257, mut v258, mut v259, mut v260): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v254);
        let v261: US3 = v259.borrow().l0.clone();
        let v266: i32 = match v261 {
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
        let v267: bool = v257.borrow().l0;
        let v268: bool = v267 == false;
        let v270: bool = if v268 {
            false
        } else {
            let v269: bool = 30i32 >= v266;
            v269
        };
        let v271: bool = v270 == false;
        v271
    };
    let v319: US4 = if v272 {
        US4::US4_None
    } else {
        let v275: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v275); };
        let v277: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v278, mut v279, mut v280, mut v281, mut v282, mut v283): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v277);
        let v284: Rc<str> = method32(&v278, &v279, &v280, &v281, &v282, v283.clone(), &v278, &v279, &v280, &v281, &v282, v283.clone(), v1, v249, v246);
        { let _ = spiral_trace_hold(&v275); };
        let (mut v287, mut v288, mut v289, mut v290, mut v291, mut v292): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v277);
        let v293: i64 = v287.borrow().l0;
        let v294: i64 = v293.wrapping_add(1i64);
        v287.borrow_mut().l0 = v294;
        let v295: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v296: bool = cfg!(target_arch = "wasm32");
        if v296 {
            let v297: Rc<str> = v290.borrow().l0.clone();
            let v298: bool = &*v297 == "";
            let v305: Rc<str> = if v298 {
                v284.clone()
            } else {
                let v299: bool = &*v284 == "";
                if v299 {
                    let v300: Rc<str> = v290.borrow().l0.clone();
                    v300
                } else {
                    let v301: Rc<str> = v290.borrow().l0.clone();
                    let v303: Rc<str> = string_concat(&[&*v301, "\n", &*v284]);
                    v303
                }
            };
            let v307: usize = v305.len();
            let v308: i32 = ((v307) as i32);
            let mut v309: i32 = v308.wrapping_add(14999i32);
            let v310: i32 = v309.wrapping_div(15000i32);
            let v311: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v312: bool = v284 != v311 ;
            let v314: bool = if v312 {
                let v313: bool = v310 <= 1i32;
                v313
            } else {
                false
            };
            if v314 {
                v290.borrow_mut().l0 = v305;
                ()
            } else {
                v290.borrow_mut().l0 = v311;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v305); };
                ()
            }
        } else {
            println!("{}", v284);
            ()
        };
        let mut v317: Rc<dyn Fn(Rc<str>) -> ()> = v288.borrow().l0.clone();
        v317(v284);
        US4::US4_Some(v287, v288, v289, v290, v291, v292)
    };
    let mut v321: near_workspaces::result::ExecutionFinalResult = v102.clone();
    let mut v323: Vec<&near_workspaces::result::ExecutionOutcome> = v321.outcomes();
    let v325: _ = v323.into_iter();
    let mut v327: _ = v325.cloned();
    let mut v329: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure13();
    let v330: bool = true; v327.for_each(|x| v329(x));
    let v332: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v102.clone().into_result();
    let v333: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v355: bool = if v333 {
        true
    } else {
        let v335: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v335); };
        let v337: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v338, mut v339, mut v340, mut v341, mut v342, mut v343): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v337);
        let v344: US3 = v342.borrow().l0.clone();
        let v349: i32 = match v344 {
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
        let v350: bool = v340.borrow().l0;
        let v351: bool = v350 == false;
        let v353: bool = if v351 {
            false
        } else {
            let v352: bool = 10i32 >= v349;
            v352
        };
        let v354: bool = v353 == false;
        v354
    };
    let v402: US4 = if v355 {
        US4::US4_None
    } else {
        let v358: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v358); };
        let v360: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v361, mut v362, mut v363, mut v364, mut v365, mut v366): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v360);
        let mut v367: Rc<str> = method44(&v361, &v362, &v363, &v364, &v365, v366.clone(), &v361, &v362, &v363, &v364, &v365, v366.clone(), v332);
        { let _ = spiral_trace_hold(&v358); };
        let (mut v370, mut v371, mut v372, mut v373, mut v374, mut v375): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v360);
        let v376: i64 = v370.borrow().l0;
        let v377: i64 = v376.wrapping_add(1i64);
        v370.borrow_mut().l0 = v377;
        let v378: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v379: bool = cfg!(target_arch = "wasm32");
        if v379 {
            let v380: Rc<str> = v373.borrow().l0.clone();
            let v381: bool = &*v380 == "";
            let v388: Rc<str> = if v381 {
                v367.clone()
            } else {
                let v382: bool = &*v367 == "";
                if v382 {
                    let v383: Rc<str> = v373.borrow().l0.clone();
                    v383
                } else {
                    let v384: Rc<str> = v373.borrow().l0.clone();
                    let v386: Rc<str> = string_concat(&[&*v384, "\n", &*v367]);
                    v386
                }
            };
            let v390: usize = v388.len();
            let v391: i32 = ((v390) as i32);
            let v392: i32 = v391.wrapping_add(14999i32);
            let v393: i32 = v392.wrapping_div(15000i32);
            let v394: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v395: bool = v367 != v394 ;
            let v397: bool = if v395 {
                let v396: bool = v393 <= 1i32;
                v396
            } else {
                false
            };
            if v397 {
                v373.borrow_mut().l0 = v388;
                ()
            } else {
                v373.borrow_mut().l0 = v394;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v388); };
                ()
            }
        } else {
            println!("{}", v367);
            ()
        };
        let mut v400: Rc<dyn Fn(Rc<str>) -> ()> = v371.borrow().l0.clone();
        v400(v367);
        US4::US4_Some(v370, v371, v372, v373, v374, v375)
    };
    let mut v403: near_workspaces::result::ExecutionFinalResult = method45(v102.clone());
    let v405: Vec<&near_workspaces::result::ExecutionOutcome> = v403.receipt_failures();
    let v406: usize = ((v405).len() as usize);
    let v407: i32 = (v406 as i32);
    let v408: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v430: bool = if v408 {
        true
    } else {
        let v410: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v410); };
        let v412: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v413, mut v414, mut v415, mut v416, mut v417, mut v418): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v412);
        let v419: US3 = v417.borrow().l0.clone();
        let v424: i32 = match v419 {
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
        let v425: bool = v415.borrow().l0;
        let v426: bool = v425 == false;
        let v428: bool = if v426 {
            false
        } else {
            let v427: bool = 10i32 >= v424;
            v427
        };
        let v429: bool = v428 == false;
        v429
    };
    let v477: US4 = if v430 {
        US4::US4_None
    } else {
        let v433: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v433); };
        let v435: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v436, mut v437, mut v438, mut v439, mut v440, mut v441): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v435);
        let v442: Rc<str> = method46(&v436, &v437, &v438, &v439, &v440, v441.clone(), &v436, &v437, &v438, &v439, &v440, v441.clone(), v407, v405.clone());
        { let _ = spiral_trace_hold(&v433); };
        let (mut v445, mut v446, mut v447, mut v448, mut v449, mut v450): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v435);
        let v451: i64 = v445.borrow().l0;
        let v452: i64 = v451.wrapping_add(1i64);
        v445.borrow_mut().l0 = v452;
        let v453: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v454: bool = cfg!(target_arch = "wasm32");
        if v454 {
            let v455: Rc<str> = v448.borrow().l0.clone();
            let v456: bool = &*v455 == "";
            let v463: Rc<str> = if v456 {
                v442.clone()
            } else {
                let v457: bool = &*v442 == "";
                if v457 {
                    let v458: Rc<str> = v448.borrow().l0.clone();
                    v458
                } else {
                    let v459: Rc<str> = v448.borrow().l0.clone();
                    let v461: Rc<str> = string_concat(&[&*v459, "\n", &*v442]);
                    v461
                }
            };
            let v465: usize = v463.len();
            let v466: i32 = ((v465) as i32);
            let v467: i32 = v466.wrapping_add(14999i32);
            let v468: i32 = v467.wrapping_div(15000i32);
            let v469: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v470: bool = v442 != v469 ;
            let v472: bool = if v470 {
                let v471: bool = v468 <= 1i32;
                v471
            } else {
                false
            };
            if v472 {
                v448.borrow_mut().l0 = v463;
                ()
            } else {
                v448.borrow_mut().l0 = v469;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v463); };
                ()
            }
        } else {
            println!("{}", v442);
            ()
        };
        let mut v475: Rc<dyn Fn(Rc<str>) -> ()> = v446.borrow().l0.clone();
        v475(v442);
        US4::US4_Some(v445, v446, v447, v448, v449, v450)
    };
    let mut v478: near_workspaces::result::ExecutionFinalResult = method48(v102.clone());
    let v480: &[near_workspaces::result::ExecutionOutcome] = v478.receipt_outcomes();
    let v482: Vec<near_workspaces::result::ExecutionOutcome> = v480.into();
    let v483: usize = ((v482).len() as usize);
    let v484: i32 = (v483 as i32);
    let v485: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v507: bool = if v485 {
        true
    } else {
        let v487: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v487); };
        let v489: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v490, mut v491, mut v492, mut v493, mut v494, mut v495): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v489);
        let v496: US3 = v494.borrow().l0.clone();
        let v501: i32 = match v496 {
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
        let v502: bool = v492.borrow().l0;
        let v503: bool = v502 == false;
        let v505: bool = if v503 {
            false
        } else {
            let v504: bool = 10i32 >= v501;
            v504
        };
        let v506: bool = v505 == false;
        v506
    };
    let v554: US4 = if v507 {
        US4::US4_None
    } else {
        let v510: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v510); };
        let v512: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v513, mut v514, mut v515, mut v516, mut v517, mut v518): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v512);
        let v519: Rc<str> = method49(&v513, &v514, &v515, &v516, &v517, v518.clone(), &v513, &v514, &v515, &v516, &v517, v518.clone(), v484, v482);
        { let _ = spiral_trace_hold(&v510); };
        let (mut v522, mut v523, mut v524, mut v525, mut v526, mut v527): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v512);
        let v528: i64 = v522.borrow().l0;
        let v529: i64 = v528.wrapping_add(1i64);
        v522.borrow_mut().l0 = v529;
        let v530: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v531: bool = cfg!(target_arch = "wasm32");
        if v531 {
            let v532: Rc<str> = v525.borrow().l0.clone();
            let v533: bool = &*v532 == "";
            let v540: Rc<str> = if v533 {
                v519.clone()
            } else {
                let v534: bool = &*v519 == "";
                if v534 {
                    let v535: Rc<str> = v525.borrow().l0.clone();
                    v535
                } else {
                    let v536: Rc<str> = v525.borrow().l0.clone();
                    let v538: Rc<str> = string_concat(&[&*v536, "\n", &*v519]);
                    v538
                }
            };
            let v542: usize = v540.len();
            let v543: i32 = ((v542) as i32);
            let v544: i32 = v543.wrapping_add(14999i32);
            let v545: i32 = v544.wrapping_div(15000i32);
            let v546: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v547: bool = v519 != v546 ;
            let v549: bool = if v547 {
                let v548: bool = v545 <= 1i32;
                v548
            } else {
                false
            };
            if v549 {
                v525.borrow_mut().l0 = v540;
                ()
            } else {
                v525.borrow_mut().l0 = v546;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v540); };
                ()
            }
        } else {
            println!("{}", v519);
            ()
        };
        let mut v552: Rc<dyn Fn(Rc<str>) -> ()> = v523.borrow().l0.clone();
        v552(v519);
        US4::US4_Some(v522, v523, v524, v525, v526, v527)
    };
    let mut v556: near_workspaces::result::ExecutionFinalResult = v102.clone();
    let v558: Result<std::string::String, near_workspaces::error::Error> = v556.json();
    let v559: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v581: bool = if v559 {
        true
    } else {
        let v561: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v561); };
        let v563: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v564, mut v565, mut v566, mut v567, mut v568, mut v569): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v563);
        let v570: US3 = v568.borrow().l0.clone();
        let v575: i32 = match v570 {
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
        let v576: bool = v566.borrow().l0;
        let v577: bool = v576 == false;
        let v579: bool = if v577 {
            false
        } else {
            let v578: bool = 10i32 >= v575;
            v578
        };
        let v580: bool = v579 == false;
        v580
    };
    let v628: US4 = if v581 {
        US4::US4_None
    } else {
        let v584: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v584); };
        let v586: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v587, mut v588, mut v589, mut v590, mut v591, mut v592): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v586);
        let v593: Rc<str> = method50(&v587, &v588, &v589, &v590, &v591, v592.clone(), &v587, &v588, &v589, &v590, &v591, v592.clone(), v558);
        { let _ = spiral_trace_hold(&v584); };
        let (mut v596, mut v597, mut v598, mut v599, mut v600, mut v601): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v586);
        let v602: i64 = v596.borrow().l0;
        let v603: i64 = v602.wrapping_add(1i64);
        v596.borrow_mut().l0 = v603;
        let v604: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v605: bool = cfg!(target_arch = "wasm32");
        if v605 {
            let v606: Rc<str> = v599.borrow().l0.clone();
            let v607: bool = &*v606 == "";
            let v614: Rc<str> = if v607 {
                v593.clone()
            } else {
                let v608: bool = &*v593 == "";
                if v608 {
                    let v609: Rc<str> = v599.borrow().l0.clone();
                    v609
                } else {
                    let v610: Rc<str> = v599.borrow().l0.clone();
                    let v612: Rc<str> = string_concat(&[&*v610, "\n", &*v593]);
                    v612
                }
            };
            let v616: usize = v614.len();
            let v617: i32 = ((v616) as i32);
            let v618: i32 = v617.wrapping_add(14999i32);
            let v619: i32 = v618.wrapping_div(15000i32);
            let v620: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v621: bool = v593 != v620 ;
            let v623: bool = if v621 {
                let v622: bool = v619 <= 1i32;
                v622
            } else {
                false
            };
            if v623 {
                v599.borrow_mut().l0 = v614;
                ()
            } else {
                v599.borrow_mut().l0 = v620;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v614); };
                ()
            }
        } else {
            println!("{}", v593);
            ()
        };
        let mut v626: Rc<dyn Fn(Rc<str>) -> ()> = v597.borrow().l0.clone();
        v626(v593);
        US4::US4_Some(v596, v597, v598, v599, v600, v601)
    };
    let mut v630: near_workspaces::result::ExecutionFinalResult = v102.clone();
    let v632: Result<std::string::String, near_workspaces::error::Error> = v630.borsh();
    let v633: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v655: bool = if v633 {
        true
    } else {
        let v635: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v635); };
        let v637: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v638, mut v639, mut v640, mut v641, mut v642, mut v643): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v637);
        let v644: US3 = v642.borrow().l0.clone();
        let v649: i32 = match v644 {
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
        let v650: bool = v640.borrow().l0;
        let v651: bool = v650 == false;
        let v653: bool = if v651 {
            false
        } else {
            let v652: bool = 10i32 >= v649;
            v652
        };
        let v654: bool = v653 == false;
        v654
    };
    let v702: US4 = if v655 {
        US4::US4_None
    } else {
        let v658: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v658); };
        let v660: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v661, mut v662, mut v663, mut v664, mut v665, mut v666): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v660);
        let v667: Rc<str> = method51(&v661, &v662, &v663, &v664, &v665, v666.clone(), &v661, &v662, &v663, &v664, &v665, v666.clone(), v632);
        { let _ = spiral_trace_hold(&v658); };
        let (mut v670, mut v671, mut v672, mut v673, mut v674, mut v675): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v660);
        let v676: i64 = v670.borrow().l0;
        let v677: i64 = v676.wrapping_add(1i64);
        v670.borrow_mut().l0 = v677;
        let v678: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v679: bool = cfg!(target_arch = "wasm32");
        if v679 {
            let v680: Rc<str> = v673.borrow().l0.clone();
            let v681: bool = &*v680 == "";
            let v688: Rc<str> = if v681 {
                v667.clone()
            } else {
                let v682: bool = &*v667 == "";
                if v682 {
                    let v683: Rc<str> = v673.borrow().l0.clone();
                    v683
                } else {
                    let v684: Rc<str> = v673.borrow().l0.clone();
                    let v686: Rc<str> = string_concat(&[&*v684, "\n", &*v667]);
                    v686
                }
            };
            let v690: usize = v688.len();
            let v691: i32 = ((v690) as i32);
            let v692: i32 = v691.wrapping_add(14999i32);
            let v693: i32 = v692.wrapping_div(15000i32);
            let v694: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v695: bool = v667 != v694 ;
            let v697: bool = if v695 {
                let v696: bool = v693 <= 1i32;
                v696
            } else {
                false
            };
            if v697 {
                v673.borrow_mut().l0 = v688;
                ()
            } else {
                v673.borrow_mut().l0 = v694;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v688); };
                ()
            }
        } else {
            println!("{}", v667);
            ()
        };
        let mut v700: Rc<dyn Fn(Rc<str>) -> ()> = v671.borrow().l0.clone();
        v700(v667);
        US4::US4_Some(v670, v671, v672, v673, v674, v675)
    };
    let v703: Rc<str> = format_real_47(v484);
    let v706: Rc<str> = format_real_30(v1);
    let v709: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v405)).s() });
    let v712: Rc<str> = string_concat(&["{ receipt_outcomes_len = ", &*v703, "; retry = ", &*v706, "; receipt_failures = ", &*v709, " }"]);
    let v713: bool = v407 > 0i32;
    let v724: Result<US6, anyhow::Error> = if v713 {
        let v714: US6 = US6::US6_Some(v712);
        let v715: Result<US6, anyhow::Error> = Ok::<US6, anyhow::Error>(v714);
        v715
    } else {
        let v716: bool = v484 > 1i32;
        if v716 {
            let v717: US6 = US6::US6_None;
            let v718: Result<US6, anyhow::Error> = Ok::<US6, anyhow::Error>(v717);
            v718
        } else {
            let v720: anyhow::Error = anyhow::anyhow!("{}", v712);
            let v722: Result<US6, anyhow::Error> = Err(v720);
            v722
        }
    };
    let v725: bool = true; (v724) }); //;
    let v727: _ = __future_init;
    let v729: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> = v727;
    v729
}
fn closure14() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let mut v2: std::string::String = format!("{}", v0);
        v2
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method52() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure14()
}
fn ok_c15() -> Rc<dyn Fn(US6) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US6) -> US8> = Rc::new(move |mut v0: US6| -> US8 {
        US8::US8_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method53() -> Rc<dyn Fn(US6) -> US8> {
    ok_c15()
}
fn error_c16() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_Error(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method54() -> Rc<dyn Fn(std::string::String) -> US8> {
    error_c16()
}
fn level_str_56() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[93m"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = string_concat(&[&*v0, "w", &*v2]);
    v3
}
fn method55(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: u8, mut v13: std::string::String) -> Rc<str> {
    let mut v14: bool = cfg!(target_arch = "wasm32");
    let v41: Rc<str> = if v14 {
        let mut v15: Rc<str> = format_real_30(v12);
        let v18: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<std::string::String>") } } (&&W(&v13)).s() });
        let v22: Rc<str> = string_concat(&["w spiral_wasm.run / Error error / { retry = ", &*v15, "; error = ", &*v18, " }"]);
        v22
    } else {
        let v23: i64 = v0.borrow().l0;
        let mut v24: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let mut v26: Rc<str> = format_real_17(v23);
        let mut v28: Rc<str> = level_str_56();
        let v33: Rc<str> = format_real_30(v12);
        let v36: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<std::string::String>") } } (&&W(&v13)).s() });
        let mut v40: Rc<str> = string_concat(&[&*v24, " ", &*v26, &*v28, " spiral_wasm.run / Error error / { retry = ", &*v33, "; error = ", &*v36, " }"]);
        v40
    };
    method10(v41)
}
fn level_str_58() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[91m"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = string_concat(&[&*v0, "c", &*v2]);
    v3
}
fn method57(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: u8, mut v13: Rc<str>) -> Rc<str> {
    let mut v14: bool = cfg!(target_arch = "wasm32");
    let v39: Rc<str> = if v14 {
        let mut v15: Rc<str> = format_real_30(v12);
        let mut v21: Rc<str> = string_concat(&["c spiral_wasm.run / Ok (Some error) / { retry = ", &*v15, "; error = ", &*v13, " }"]);
        v21
    } else {
        let v22: i64 = v0.borrow().l0;
        let v23: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v25: Rc<str> = format_real_17(v22);
        let v27: Rc<str> = level_str_58();
        let v32: Rc<str> = format_real_30(v12);
        let mut v38: Rc<str> = string_concat(&[&*v23, " ", &*v25, &*v27, " spiral_wasm.run / Ok (Some error) / { retry = ", &*v32, "; error = ", &*v13, " }"]);
        v38
    };
    method10(v39)
}
fn method27(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let mut v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> = fn_28(v0.clone(), v1);
    let mut v10: Result<US6, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method52();
    let mut v13: Result<US6, std::string::String> = v10.map_err(|x| v11(x));
    let mut v14: Rc<dyn Fn(US6) -> US8> = method53();
    let mut v15: Rc<dyn Fn(std::string::String) -> US8> = method54();
    let mut v16: US8 = match v13 { Ok(x) => v14(x), Err(e) => v15(e) };
    let v407: US7 = match v16 {
        US8::US8_Error(v119) => {
            let v119: std::string::String = v119;
            let v120: bool = v1 >= 15u8;
            if v120 {
                let v121: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let mut v143: bool = if v121 {
                    true
                } else {
                    let v123: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v123); };
                    let v125: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v126, mut v127, mut v128, mut v129, mut v130, mut v131): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v125);
                    let v132: US3 = v130.borrow().l0.clone();
                    let v137: i32 = match v132 {
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
                    let v138: bool = v128.borrow().l0;
                    let v139: bool = v138 == false;
                    let v141: bool = if v139 {
                        false
                    } else {
                        let mut v140: bool = 40i32 >= v137;
                        v140
                    };
                    let v142: bool = v141 == false;
                    v142
                };
                let v190: US4 = if v143 {
                    US4::US4_None
                } else {
                    let v146: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v146); };
                    let v148: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v149, mut v150, mut v151, mut v152, mut v153, mut v154): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v148);
                    let v155: Rc<str> = method55(&v149, &v150, &v151, &v152, &v153, v154.clone(), &v149, &v150, &v151, &v152, &v153, v154.clone(), v1, v119);
                    { let _ = spiral_trace_hold(&v146); };
                    let (mut v158, mut v159, mut v160, mut v161, mut v162, mut v163): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v148);
                    let v164: i64 = v158.borrow().l0;
                    let v165: i64 = v164.wrapping_add(1i64);
                    v158.borrow_mut().l0 = v165;
                    let mut v166: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v167: bool = cfg!(target_arch = "wasm32");
                    if v167 {
                        let v168: Rc<str> = v161.borrow().l0.clone();
                        let mut v169: bool = &*v168 == "";
                        let mut v176: Rc<str> = if v169 {
                            v155.clone()
                        } else {
                            let mut v170: bool = &*v155 == "";
                            if v170 {
                                let v171: Rc<str> = v161.borrow().l0.clone();
                                v171
                            } else {
                                let v172: Rc<str> = v161.borrow().l0.clone();
                                let v174: Rc<str> = string_concat(&[&*v172, "\n", &*v155]);
                                v174
                            }
                        };
                        let v178: usize = v176.len();
                        let mut v179: i32 = ((v178) as i32);
                        let mut v180: i32 = v179.wrapping_add(14999i32);
                        let v181: i32 = v180.wrapping_div(15000i32);
                        let v182: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v183: bool = v155 != v182 ;
                        let mut v185: bool = if v183 {
                            let v184: bool = v181 <= 1i32;
                            v184
                        } else {
                            false
                        };
                        if v185 {
                            v161.borrow_mut().l0 = v176;
                            ()
                        } else {
                            v161.borrow_mut().l0 = v182;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v176); };
                            ()
                        }
                    } else {
                        println!("{}", v155);
                        ()
                    };
                    let mut v188: Rc<dyn Fn(Rc<str>) -> ()> = v159.borrow().l0.clone();
                    v188(v155);
                    US4::US4_Some(v158, v159, v160, v161, v162, v163)
                };
                let v191: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v213: bool = if v191 {
                    true
                } else {
                    let v193: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v193); };
                    let v195: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v196, mut v197, mut v198, mut v199, mut v200, mut v201): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v195);
                    let v202: US3 = v200.borrow().l0.clone();
                    let v207: i32 = match v202 {
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
                    let v208: bool = v198.borrow().l0;
                    let mut v209: bool = v208 == false;
                    let v211: bool = if v209 {
                        false
                    } else {
                        let v210: bool = 40i32 >= v207;
                        v210
                    };
                    let mut v212: bool = v211 == false;
                    v212
                };
                let v252: US4 = if v213 {
                    US4::US4_None
                } else {
                    let v216: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v216); };
                    let v218: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v219, mut v220, mut v221, mut v222, mut v223, mut v224): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v218);
                    let v225: i64 = v219.borrow().l0;
                    let v226: i64 = v225.wrapping_add(1i64);
                    v219.borrow_mut().l0 = v226;
                    let v227: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v228: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v229: bool = cfg!(target_arch = "wasm32");
                    if v229 {
                        let v230: Rc<str> = v222.borrow().l0.clone();
                        let v231: bool = &*v230 == "";
                        let v238: Rc<str> = if v231 {
                            v227.clone()
                        } else {
                            let v232: bool = &*v227 == "";
                            if v232 {
                                let v233: Rc<str> = v222.borrow().l0.clone();
                                v233
                            } else {
                                let v234: Rc<str> = v222.borrow().l0.clone();
                                let v236: Rc<str> = string_concat(&[&*v234, "\n", &*v227]);
                                v236
                            }
                        };
                        let mut v240: usize = v238.len();
                        let v241: i32 = ((v240) as i32);
                        let v242: i32 = v241.wrapping_add(14999i32);
                        let v243: i32 = v242.wrapping_div(15000i32);
                        let mut v244: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v245: bool = v227 != v244 ;
                        let v247: bool = if v245 {
                            let v246: bool = v243 <= 1i32;
                            v246
                        } else {
                            false
                        };
                        if v247 {
                            v222.borrow_mut().l0 = v238;
                            ()
                        } else {
                            v222.borrow_mut().l0 = v244;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v238); };
                            ()
                        }
                    } else {
                        println!("{}", v227);
                        ()
                    };
                    let mut v250: Rc<dyn Fn(Rc<str>) -> ()> = v220.borrow().l0.clone();
                    v250(v227);
                    US4::US4_Some(v219, v220, v221, v222, v223, v224)
                };
                let v254: bool = true; let __future_init = Box::pin(/*;
                let v256: bool = */ async move { /*;
                let v258: bool = */ ();
                let v259: US6 = US6::US6_None;
                let v260: bool = true; ((v1, v259)) }); //;
                let v262: _ = __future_init;
                let v264: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v262;
                let (mut v266, mut v267): (u8, US6) = v264.await;
                US7::US7_Ok(v266, v267)
            } else {
                let v269: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v291: bool = if v269 {
                    true
                } else {
                    let v271: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v271); };
                    let v273: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v274, mut v275, mut v276, mut v277, mut v278, mut v279): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v273);
                    let v280: US3 = v278.borrow().l0.clone();
                    let v285: i32 = match v280 {
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
                    let v286: bool = v276.borrow().l0;
                    let mut v287: bool = v286 == false;
                    let v289: bool = if v287 {
                        false
                    } else {
                        let v288: bool = 40i32 >= v285;
                        v288
                    };
                    let mut v290: bool = v289 == false;
                    v290
                };
                let v338: US4 = if v291 {
                    US4::US4_None
                } else {
                    let v294: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v294); };
                    let v296: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v297, mut v298, mut v299, mut v300, mut v301, mut v302): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v296);
                    let v303: Rc<str> = method55(&v297, &v298, &v299, &v300, &v301, v302.clone(), &v297, &v298, &v299, &v300, &v301, v302.clone(), v1, v119);
                    { let _ = spiral_trace_hold(&v294); };
                    let (mut v306, mut v307, mut v308, mut v309, mut v310, mut v311): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v296);
                    let v312: i64 = v306.borrow().l0;
                    let v313: i64 = v312.wrapping_add(1i64);
                    v306.borrow_mut().l0 = v313;
                    let v314: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v315: bool = cfg!(target_arch = "wasm32");
                    if v315 {
                        let v316: Rc<str> = v309.borrow().l0.clone();
                        let mut v317: bool = &*v316 == "";
                        let v324: Rc<str> = if v317 {
                            v303.clone()
                        } else {
                            let v318: bool = &*v303 == "";
                            if v318 {
                                let v319: Rc<str> = v309.borrow().l0.clone();
                                v319
                            } else {
                                let v320: Rc<str> = v309.borrow().l0.clone();
                                let v322: Rc<str> = string_concat(&[&*v320, "\n", &*v303]);
                                v322
                            }
                        };
                        let v326: usize = v324.len();
                        let mut v327: i32 = ((v326) as i32);
                        let v328: i32 = v327.wrapping_add(14999i32);
                        let mut v329: i32 = v328.wrapping_div(15000i32);
                        let v330: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v331: bool = v303 != v330 ;
                        let v333: bool = if v331 {
                            let v332: bool = v329 <= 1i32;
                            v332
                        } else {
                            false
                        };
                        if v333 {
                            v309.borrow_mut().l0 = v324;
                            ()
                        } else {
                            v309.borrow_mut().l0 = v330;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v324); };
                            ()
                        }
                    } else {
                        println!("{}", v303);
                        ()
                    };
                    let mut v336: Rc<dyn Fn(Rc<str>) -> ()> = v307.borrow().l0.clone();
                    v336(v303);
                    US4::US4_Some(v306, v307, v308, v309, v310, v311)
                };
                let v339: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v361: bool = if v339 {
                    true
                } else {
                    let v341: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v341); };
                    let v343: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v344, mut v345, mut v346, mut v347, mut v348, mut v349): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v343);
                    let v350: US3 = v348.borrow().l0.clone();
                    let v355: i32 = match v350 {
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
                    let v356: bool = v346.borrow().l0;
                    let v357: bool = v356 == false;
                    let v359: bool = if v357 {
                        false
                    } else {
                        let v358: bool = 40i32 >= v355;
                        v358
                    };
                    let v360: bool = v359 == false;
                    v360
                };
                let mut v400: US4 = if v361 {
                    US4::US4_None
                } else {
                    let v364: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v364); };
                    let v366: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v367, mut v368, mut v369, mut v370, mut v371, mut v372): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v366);
                    let mut v373: i64 = v367.borrow().l0;
                    let v374: i64 = v373.wrapping_add(1i64);
                    v367.borrow_mut().l0 = v374;
                    let v375: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v376: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v377: bool = cfg!(target_arch = "wasm32");
                    if v377 {
                        let v378: Rc<str> = v370.borrow().l0.clone();
                        let v379: bool = &*v378 == "";
                        let v386: Rc<str> = if v379 {
                            v375.clone()
                        } else {
                            let v380: bool = &*v375 == "";
                            if v380 {
                                let v381: Rc<str> = v370.borrow().l0.clone();
                                v381
                            } else {
                                let v382: Rc<str> = v370.borrow().l0.clone();
                                let v384: Rc<str> = string_concat(&[&*v382, "\n", &*v375]);
                                v384
                            }
                        };
                        let v388: usize = v386.len();
                        let v389: i32 = ((v388) as i32);
                        let v390: i32 = v389.wrapping_add(14999i32);
                        let v391: i32 = v390.wrapping_div(15000i32);
                        let v392: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v393: bool = v375 != v392 ;
                        let v395: bool = if v393 {
                            let v394: bool = v391 <= 1i32;
                            v394
                        } else {
                            false
                        };
                        if v395 {
                            v370.borrow_mut().l0 = v386;
                            ()
                        } else {
                            v370.borrow_mut().l0 = v392;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v386); };
                            ()
                        }
                    } else {
                        println!("{}", v375);
                        ()
                    };
                    let mut v398: Rc<dyn Fn(Rc<str>) -> ()> = v368.borrow().l0.clone();
                    v398(v375);
                    US4::US4_Some(v367, v368, v369, v370, v371, v372)
                };
                let v401: u8 = v1.wrapping_add(1u8);
                let v402: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = method27(v0, v401);
                let v404: US7 = v402.await;
                v404
            }
        }
        US8::US8_Ok(v17) => {
            let mut v17: US6 = v17;
            match v17 {
                US6::US6_None => {
                    let mut v19: bool = true; let __future_init = Box::pin(/*;
                    let mut v21: bool = */ async move { /*;
                    let v23: bool = */ ();
                    let mut v24: US6 = US6::US6_None;
                    let v25: bool = true; ((v1, v24)) }); //;
                    let v27: _ = __future_init;
                    let v29: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v27;
                    let (mut v31, mut v32): (u8, US6) = v29.await;
                    US7::US7_Ok(v31, v32)
                }
                US6::US6_Some(v34) => {
                    let v34: Rc<str> = v34;
                    let v36: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v36); };
                    let mut v38: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
                    let (mut v39, mut v40, mut v41, mut v42, mut v43, mut v44): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v38);
                    let v45: US3 = v43.borrow().l0.clone();
                    let mut v50: i32 = match v45 {
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
                    let v51: bool = v41.borrow().l0;
                    let v52: bool = v51 == false;
                    let mut v54: bool = if v52 {
                        false
                    } else {
                        let v53: bool = 50i32 >= v50;
                        v53
                    };
                    let mut v55: bool = v54 == false;
                    let v100: US4 = if v55 {
                        US4::US4_None
                    } else {
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v59, mut v60, mut v61, mut v62, mut v63, mut v64): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v38);
                        let mut v65: Rc<str> = method57(&v59, &v60, &v61, &v62, &v63, v64.clone(), &v59, &v60, &v61, &v62, &v63, v64.clone(), v1, v34.clone());
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v68, mut v69, mut v70, mut v71, mut v72, mut v73): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v38);
                        let v74: i64 = v68.borrow().l0;
                        let mut v75: i64 = v74.wrapping_add(1i64);
                        v68.borrow_mut().l0 = v75;
                        let v76: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                        let v77: bool = cfg!(target_arch = "wasm32");
                        if v77 {
                            let v78: Rc<str> = v71.borrow().l0.clone();
                            let v79: bool = &*v78 == "";
                            let v86: Rc<str> = if v79 {
                                v65.clone()
                            } else {
                                let v80: bool = &*v65 == "";
                                if v80 {
                                    let v81: Rc<str> = v71.borrow().l0.clone();
                                    v81
                                } else {
                                    let v82: Rc<str> = v71.borrow().l0.clone();
                                    let v84: Rc<str> = string_concat(&[&*v82, "\n", &*v65]);
                                    v84
                                }
                            };
                            let v88: usize = v86.len();
                            let v89: i32 = ((v88) as i32);
                            let v90: i32 = v89.wrapping_add(14999i32);
                            let v91: i32 = v90.wrapping_div(15000i32);
                            let mut v92: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let v93: bool = v65 != v92 ;
                            let v95: bool = if v93 {
                                let v94: bool = v91 <= 1i32;
                                v94
                            } else {
                                false
                            };
                            if v95 {
                                v71.borrow_mut().l0 = v86;
                                ()
                            } else {
                                v71.borrow_mut().l0 = v92;
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v86); };
                                ()
                            }
                        } else {
                            println!("{}", v65);
                            ()
                        };
                        let mut v98: Rc<dyn Fn(Rc<str>) -> ()> = v69.borrow().l0.clone();
                        v98(v65);
                        US4::US4_Some(v68, v69, v70, v71, v72, v73)
                    };
                    let mut v102: bool = true; let __future_init = Box::pin(/*;
                    let v104: bool = */ async move { /*;
                    let v106: bool = */ ();
                    let v107: US6 = US6::US6_Some(v34);
                    let v108: bool = true; ((v1, v107)) }); //;
                    let v110: _ = __future_init;
                    let v112: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v110;
                    let (mut v114, mut v115): (u8, US6) = v112.await;
                    US7::US7_Error(v114, v115)
                }
            }
        }
    };
    let v408: bool = true; (v407) }); //;
    let v410: _ = __future_init;
    let v412: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = v410;
    v412
}
fn method61(mut v0: US6) -> Rc<str> {
    match v0 {
        US6::US6_None => {
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v4
        }
        US6::US6_Some(v1) => {
            let mut v1: Rc<str> = v1;
            let mut v3: Rc<str> = string_concat(&["Some(", &*v1, ")"]);
            v3
        }
    }
}
fn method60(mut v0: US7) -> Rc<str> {
    match v0 {
        US7::US7_Error(v12, v13) => {
            let v12: u8 = v12;
            let mut v13: US6 = v13;
            let mut v14: Rc<str> = format_real_30(v12);
            let mut v17: Rc<str> = method61(v13);
            let v22: Rc<str> = string_concat(&["Error({ retry = ", &*v14, "; error = ", &*v17, " })"]);
            v22
        }
        US7::US7_Ok(v1, v2) => {
            let mut v1: u8 = v1;
            let mut v2: US6 = v2;
            let mut v3: Rc<str> = format_real_30(v1);
            let v6: Rc<str> = method61(v2);
            let mut v11: Rc<str> = string_concat(&["Ok({ retry = ", &*v3, "; error = ", &*v6, " })"]);
            v11
        }
    }
}
fn method59(mut v0: &Rc<RefCell<Mut2>>, mut v1: &Rc<RefCell<Mut3>>, mut v2: &Rc<RefCell<Mut4>>, mut v3: &Rc<RefCell<Mut5>>, mut v4: &Rc<RefCell<Mut6>>, mut v5: Option<i64>, mut v6: &Rc<RefCell<Mut2>>, mut v7: &Rc<RefCell<Mut3>>, mut v8: &Rc<RefCell<Mut4>>, mut v9: &Rc<RefCell<Mut5>>, mut v10: &Rc<RefCell<Mut6>>, mut v11: Option<i64>, mut v12: US7) -> Rc<str> {
    let mut v13: bool = cfg!(target_arch = "wasm32");
    let v34: Rc<str> = if v13 {
        let mut v14: Rc<str> = method60(v12);
        let v18: Rc<str> = string_concat(&["v spiral_wasm.run / { retries = ", &*v14, " }"]);
        v18
    } else {
        let mut v19: i64 = v0.borrow().l0;
        let v20: Rc<str> = time_15(v6, v7, v8, v9, v10, v11);
        let v22: Rc<str> = format_real_17(v19);
        let mut v24: Rc<str> = level_str_19();
        let v29: Rc<str> = method60(v12);
        let v33: Rc<str> = string_concat(&[&*v20, " ", &*v22, &*v24, " spiral_wasm.run / { retries = ", &*v29, " }"]);
        v33
    };
    method10(v34)
}
fn run_24(mut v0: clap::ArgMatches) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> {
    let mut v2: bool = true; let __future_init = Box::pin(/*;
    let mut v4: bool = */ async move { /*;
    let v6: bool = */ ();
    let v7: Rc<str> = method25();
    let mut v9: &str = &*v7;
    let mut v11: Option<std::string::String> = clap::ArgMatches::get_one(&v0, v9).cloned();
    let v12: Option<std::string::String> = method5(v11);
    let mut v13: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v14: Option<US0> = v12.map(|x| v13(x));
    let mut v16: US0 = US0::US0_None;
    let mut v17: US0 = v16.clone();
    let v18: US0 = v14.unwrap_or(v17);
    let v22: std::string::String = match v18 {
        US0::US0_None => {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_Some(v19) => {
            let mut v19: std::string::String = v19;
            v19
        }
    };
    let mut v24: Rc<str> = Rc::<str>::from(String::as_str(&v22));
    let v25: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v47: bool = if v25 {
        true
    } else {
        let v27: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v27); };
        let v29: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v30, mut v31, mut v32, mut v33, mut v34, mut v35): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v29);
        let v36: US3 = v34.borrow().l0.clone();
        let v41: i32 = match v36 {
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
        let v42: bool = v32.borrow().l0;
        let mut v43: bool = v42 == false;
        let v45: bool = if v43 {
            false
        } else {
            let v44: bool = 10i32 >= v41;
            v44
        };
        let v46: bool = v45 == false;
        v46
    };
    let v94: US4 = if v47 {
        US4::US4_None
    } else {
        let mut v50: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v50); };
        let v52: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v53, mut v54, mut v55, mut v56, mut v57, mut v58): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v52);
        let mut v59: Rc<str> = method26(&v53, &v54, &v55, &v56, &v57, v58.clone(), &v53, &v54, &v55, &v56, &v57, v58.clone(), v24.clone());
        { let _ = spiral_trace_hold(&v50); };
        let (mut v62, mut v63, mut v64, mut v65, mut v66, mut v67): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v52);
        let mut v68: i64 = v62.borrow().l0;
        let v69: i64 = v68.wrapping_add(1i64);
        v62.borrow_mut().l0 = v69;
        let mut v70: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v71: bool = cfg!(target_arch = "wasm32");
        if v71 {
            let mut v72: Rc<str> = v65.borrow().l0.clone();
            let v73: bool = &*v72 == "";
            let v80: Rc<str> = if v73 {
                v59.clone()
            } else {
                let v74: bool = &*v59 == "";
                if v74 {
                    let mut v75: Rc<str> = v65.borrow().l0.clone();
                    v75
                } else {
                    let v76: Rc<str> = v65.borrow().l0.clone();
                    let v78: Rc<str> = string_concat(&[&*v76, "\n", &*v59]);
                    v78
                }
            };
            let v82: usize = v80.len();
            let v83: i32 = ((v82) as i32);
            let v84: i32 = v83.wrapping_add(14999i32);
            let mut v85: i32 = v84.wrapping_div(15000i32);
            let v86: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v87: bool = v59 != v86 ;
            let v89: bool = if v87 {
                let v88: bool = v85 <= 1i32;
                v88
            } else {
                false
            };
            if v89 {
                v65.borrow_mut().l0 = v80;
                ()
            } else {
                v65.borrow_mut().l0 = v86;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v80); };
                ()
            }
        } else {
            println!("{}", v59);
            ()
        };
        let mut v92: Rc<dyn Fn(Rc<str>) -> ()> = v63.borrow().l0.clone();
        v92(v59);
        US4::US4_Some(v62, v63, v64, v65, v66, v67)
    };
    let mut v96: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v24);
    let mut v98: Vec<u8> = v96?;
    let v99: u8 = 1u8;
    let v100: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = method27(v98, v99);
    let mut v102: US7 = v100.await;
    let v103: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v125: bool = if v103 {
        true
    } else {
        let v105: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v105); };
        let v107: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v108, mut v109, mut v110, mut v111, mut v112, mut v113): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v107);
        let v114: US3 = v112.borrow().l0.clone();
        let v119: i32 = match v114 {
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
        let v120: bool = v110.borrow().l0;
        let v121: bool = v120 == false;
        let v123: bool = if v121 {
            false
        } else {
            let v122: bool = 10i32 >= v119;
            v122
        };
        let v124: bool = v123 == false;
        v124
    };
    let v172: US4 = if v125 {
        US4::US4_None
    } else {
        let v128: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v128); };
        let mut v130: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v131, mut v132, mut v133, mut v134, mut v135, mut v136): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v130);
        let v137: Rc<str> = method59(&v131, &v132, &v133, &v134, &v135, v136.clone(), &v131, &v132, &v133, &v134, &v135, v136.clone(), v102.clone());
        { let _ = spiral_trace_hold(&v128); };
        let (mut v140, mut v141, mut v142, mut v143, mut v144, mut v145): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v130);
        let v146: i64 = v140.borrow().l0;
        let v147: i64 = v146.wrapping_add(1i64);
        v140.borrow_mut().l0 = v147;
        let v148: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v149: bool = cfg!(target_arch = "wasm32");
        if v149 {
            let v150: Rc<str> = v143.borrow().l0.clone();
            let v151: bool = &*v150 == "";
            let mut v158: Rc<str> = if v151 {
                v137.clone()
            } else {
                let v152: bool = &*v137 == "";
                if v152 {
                    let v153: Rc<str> = v143.borrow().l0.clone();
                    v153
                } else {
                    let v154: Rc<str> = v143.borrow().l0.clone();
                    let v156: Rc<str> = string_concat(&[&*v154, "\n", &*v137]);
                    v156
                }
            };
            let v160: usize = v158.len();
            let mut v161: i32 = ((v160) as i32);
            let v162: i32 = v161.wrapping_add(14999i32);
            let v163: i32 = v162.wrapping_div(15000i32);
            let v164: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v165: bool = v137 != v164 ;
            let v167: bool = if v165 {
                let mut v166: bool = v163 <= 1i32;
                v166
            } else {
                false
            };
            if v167 {
                v143.borrow_mut().l0 = v158;
                ()
            } else {
                v143.borrow_mut().l0 = v164;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v158); };
                ()
            }
        } else {
            println!("{}", v137);
            ()
        };
        let mut v170: Rc<dyn Fn(Rc<str>) -> ()> = v141.borrow().l0.clone();
        v170(v137);
        US4::US4_Some(v140, v141, v142, v143, v144, v145)
    };
    let v190: Result<u8, anyhow::Error> = match &v102 {
        US7::US7_Error(v176, v177) => {
            let mut v176: u8 = *v176;
            let mut v177: US6 = v177.clone();
            let v178: Rc<str> = method60(v102);
            let v181: Rc<str> = method61(v177);
            let v184: Rc<str> = string_concat(&["{ retries = ", &*v178, "; error = ", &*v181, " }"]);
            let mut v186: anyhow::Error = anyhow::anyhow!("{}", v184);
            let mut v188: Result<u8, anyhow::Error> = Err(v186);
            v188
        }
        US7::US7_Ok(v173, v174) => {
            let v173: u8 = *v173;
            let v174: US6 = v174.clone();
            let v175: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v173);
            v175
        }
    };
    let v191: bool = true; (v190) }); //;
    let v193: _ = __future_init;
    let v195: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v193;
    v195
}
fn ok_c17() -> Rc<dyn Fn(u8) -> US9> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US9> = Rc::new(move |mut v0: u8| -> US9 {
        US9::US9_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method62() -> Rc<dyn Fn(u8) -> US9> {
    ok_c17()
}
fn error_c18() -> Rc<dyn Fn(std::string::String) -> US9> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US9> = Rc::new(move |mut v0: std::string::String| -> US9 {
        US9::US9_Error(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method63() -> Rc<dyn Fn(std::string::String) -> US9> {
    error_c18()
}
fn spiral_main() -> i32 {
    let mut v0: i32 = command_line_argument_count_0();
    let mut v1: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec![<Rc<str>>::default(); v0 as usize]));
    let mut v2: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32 }));
    while method1(v0, &v2) {
        let mut v4: i32 = v2.borrow().l0;
        let mut v5: Rc<str> = command_line_argument_2(v4);
        v1.borrow_mut()[v4 as usize] = v5;
        let v6: i32 = v4.wrapping_add(1i32);
        v2.borrow_mut().l0 = v6;
        ()
    };
    let v7: clap::Command = get_command_3();
    let mut v9: clap::ArgMatches = clap::Command::get_matches(v7);
    let mut v10: Rc<str> = method4();
    let v12: &str = &*v10;
    let mut v14: Option<std::string::String> = clap::ArgMatches::get_one(&v9, v12).cloned();
    let mut v15: Option<std::string::String> = method5(v14);
    let mut v16: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v17: Option<US0> = v15.map(|x| v16(x));
    let mut v19: US0 = US0::US0_None;
    let v20: US0 = v19.clone();
    let mut v21: US0 = v17.unwrap_or(v20);
    let mut v68: US1 = match v21 {
        US0::US0_None => {
            US1::US1_None
        }
        US0::US0_Some(v22) => {
            let v22: std::string::String = v22;
            let mut v24: Rc<str> = Rc::<str>::from(String::as_str(&v22));
            ;
            ;
            ;
            ;
            ;
            let v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
            let mut v26: Rc<str> = Rc::<str>::from(v25.to_lowercase());
            let v27: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
            let mut v28: Rc<str> = Rc::<str>::from(v27.to_lowercase());
            let v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
            let mut v30: Rc<str> = Rc::<str>::from(v29.to_lowercase());
            let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
            let v32: Rc<str> = Rc::<str>::from(v31.to_lowercase());
            let v33: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
            let v34: Rc<str> = Rc::<str>::from(v33.to_lowercase());
            let mut v35: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
            let v36: US3 = US3::US3_Verbose;
            v35.borrow_mut().push((v33, v36));
            let v37: US3 = US3::US3_Debug;
            v35.borrow_mut().push((v31, v37));
            let mut v38: US3 = US3::US3_Info;
            v35.borrow_mut().push((v29, v38));
            let v39: US3 = US3::US3_Warning;
            v35.borrow_mut().push((v27, v39));
            let mut v40: US3 = US3::US3_Critical;
            v35.borrow_mut().push((v25, v40));
            let v41: US3 = US3::US3_Verbose;
            v35.borrow_mut().push((v34, v41));
            let v42: US3 = US3::US3_Debug;
            v35.borrow_mut().push((v32, v42));
            let mut v43: US3 = US3::US3_Info;
            v35.borrow_mut().push((v30, v43));
            let v44: US3 = US3::US3_Warning;
            v35.borrow_mut().push((v28, v44));
            let v45: US3 = US3::US3_Critical;
            v35.borrow_mut().push((v26, v45));
            let v46: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v35.borrow().clone());
            let v47: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v46).as_ref().clone()));
            let v48: i32 = (v47.clone().borrow().len() as i32);
            let v49: US2 = US2::US2_None;
            let mut v50: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v48, l1: v49 }));
            while method6(&v50) {
                let v52: i32 = v50.borrow().l0;
                let v53: i32 = v52.wrapping_sub(1i32);
                let mut v54: US2 = v50.borrow().l1.clone();
                let (mut v55, mut v56): (Rc<str>, US3) = v47.borrow()[v53 as usize].clone();
                let v63: US2 = match &v54 {
                    US2::US2_None => {
                        let mut v58: bool = v55 == v24 ;
                        if v58 {
                            US2::US2_Some(v56)
                        } else {
                            US2::US2_None
                        }
                    }
                    US2::US2_Some(v57) => {
                        let mut v57: US3 = v57.clone();
                        v54
                    }
                };
                v50.borrow_mut().l0 = v53;
                v50.borrow_mut().l1 = v63;
                ()
            };
            let v64: US2 = v50.borrow().l1.clone();
            US1::US1_Some(v64)
        }
    };
    let mut v75: US2 = match v68 {
        US1::US1_Some(v69) => {
            let v69: US2 = v69;
            match v69 {
                US2::US2_Some(v70) => {
                    let mut v70: US3 = v70;
                    US2::US2_Some(v70)
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
    let v79: US3 = match v75 {
        US2::US2_None => {
            US3::US3_Verbose
        }
        US2::US2_Some(v76) => {
            let v76: US3 = v76;
            v76
        }
    };
    let v81: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c2(v79.clone());
    { let _ = spiral_trace_hold(&v81); };
    let v83: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c4(v79);
    let (mut v84, mut v85, mut v86, mut v87, mut v88, mut v89): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v83);
    let v90: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v112: bool = if v90 {
        true
    } else {
        let mut v92: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v92); };
        let v94: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v95, mut v96, mut v97, mut v98, mut v99, mut v100): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v94);
        let v101: US3 = v99.borrow().l0.clone();
        let v106: i32 = match v101 {
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
        let v107: bool = v97.borrow().l0;
        let v108: bool = v107 == false;
        let v110: bool = if v108 {
            false
        } else {
            let v109: bool = 10i32 >= v106;
            v109
        };
        let v111: bool = v110 == false;
        v111
    };
    let v159: US4 = if v112 {
        US4::US4_None
    } else {
        let v115: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v115); };
        let v117: Rc<dyn Fn() -> (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>)> = fresh_c6();
        let (mut v118, mut v119, mut v120, mut v121, mut v122, mut v123): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v117);
        let v124: Rc<str> = method9(&v118, &v119, &v120, &v121, &v122, v123.clone(), &v118, &v119, &v120, &v121, &v122, v123.clone(), &v1);
        { let _ = spiral_trace_hold(&v115); };
        let (mut v127, mut v128, mut v129, mut v130, mut v131, mut v132): (Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Rc<RefCell<Mut6>>, Option<i64>) = spiral_trace_hold(&v117);
        let v133: i64 = v127.borrow().l0;
        let v134: i64 = v133.wrapping_add(1i64);
        v127.borrow_mut().l0 = v134;
        let v135: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v136: bool = cfg!(target_arch = "wasm32");
        if v136 {
            let v137: Rc<str> = v130.borrow().l0.clone();
            let v138: bool = &*v137 == "";
            let v145: Rc<str> = if v138 {
                v124.clone()
            } else {
                let v139: bool = &*v124 == "";
                if v139 {
                    let mut v140: Rc<str> = v130.borrow().l0.clone();
                    v140
                } else {
                    let v141: Rc<str> = v130.borrow().l0.clone();
                    let mut v143: Rc<str> = string_concat(&[&*v141, "\n", &*v124]);
                    v143
                }
            };
            let v147: usize = v145.len();
            let v148: i32 = ((v147) as i32);
            let v149: i32 = v148.wrapping_add(14999i32);
            let v150: i32 = v149.wrapping_div(15000i32);
            let v151: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v152: bool = v124 != v151 ;
            let v154: bool = if v152 {
                let v153: bool = v150 <= 1i32;
                v153
            } else {
                false
            };
            if v154 {
                v130.borrow_mut().l0 = v145;
                ()
            } else {
                v130.borrow_mut().l0 = v151;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v145); };
                ()
            }
        } else {
            println!("{}", v124);
            ()
        };
        let mut v157: Rc<dyn Fn(Rc<str>) -> ()> = v128.borrow().l0.clone();
        v157(v124);
        US4::US4_Some(v127, v128, v129, v130, v131, v132)
    };
    let v160: Rc<str> = method20();
    let v162: &str = &*v160;
    let v164: Option<std::string::String> = clap::ArgMatches::get_one(&v9, v162).cloned();
    let v165: Option<std::string::String> = method5(v164);
    let mut v166: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure9();
    let v167: Option<Rc<str>> = v165.map(|x| v166(x));
    let v168: Option<Rc<str>> = method23(v167);
    let mut v169: Rc<dyn Fn((Rc<str>)) -> US6> = closure10();
    let mut v170: Option<US6> = v168.map(|x| v169(x));
    let v172: US6 = US6::US6_None;
    let v173: US6 = v172.clone();
    let v174: US6 = v170.unwrap_or(v173);
    let v175: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = run_24(v9);
    let mut v177: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v179: Result<u8, anyhow::Error> = v177.handle().block_on(v175);
    let mut v180: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method52();
    let v182: Result<u8, std::string::String> = v179.map_err(|x| v180(x));
    let v184: Result<u8, std::string::String> = v182.clone();
    let mut v185: Rc<dyn Fn(u8) -> US9> = method62();
    let mut v186: Rc<dyn Fn(std::string::String) -> US9> = method63();
    let v187: US9 = match v184 { Ok(x) => v185(x), Err(e) => v186(e) };
    match v187 {
        US9::US9_Error(v198) => {
            let v198: std::string::String = v198;
            match v174 {
                US6::US6_Some(v199) => {
                    let v199: Rc<str> = v199;
                    let v200: bool = "" == &*v199;
                    if v200 {
                        ()
                    } else {
                        let v202: Rc<str> = Rc::<str>::from(String::as_str(&v198));
                        let v203: bool = v202.contains(&*v199);
                        if v203 {
                            ()
                        } else {
                            let v207: Rc<str> = Rc::<str>::from(String::as_str(&v198));
                            let v208: Rc<str> = string_concat(&["spiral_wasm.main / exception: '", &*v199, "' / error: ", &*v207]);
                            let v210: Result<(), Rc<str>> = Err(v208);
                            v210.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let v213: u8 = v182.unwrap();
                    ()
                }
            }
        }
        US9::US9_Ok(v188) => {
            let mut v188: u8 = v188;
            match v174 {
                US6::US6_Some(v189) => {
                    let v189: Rc<str> = v189;
                    let v190: Rc<str> = format_real_30(v188);
                    let v194: Rc<str> = string_concat(&["spiral_wasm.main / retries: ", &*v190, " / exception: '", &*v189, "'"]);
                    let v196: Result<(), Rc<str>> = Err(v194);
                    v196.unwrap();
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
