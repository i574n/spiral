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
#[derive(Clone)]
enum US5 {
    US5_Some([i64; 3]),
    US5_None,
}
struct Mut6 { l0: u64 }
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
fn get_command_0() -> clap::Command {
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
        let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
        let mut v14: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..=v7);
        v14
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
    let v53: Rc<str> = Rc::<str>::from(v52.to_lowercase());
    let mut v54: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v54.borrow_mut().push(v53);
    v54.borrow_mut().push(v51);
    v54.borrow_mut().push(v49);
    v54.borrow_mut().push(v47);
    v54.borrow_mut().push(v45);
    let v55: Rc<Vec<Rc<str>>> = Rc::new(v54.borrow().clone());
    let v56: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v55).as_ref().clone()));
    let mut v57: Vec<Rc<str>> = (v56).borrow().clone();
    let mut v59: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v60: Vec<clap::builder::PossibleValue> = v57.iter().map(|x| v59(x.clone())).collect::<Vec<_>>();
    let mut v62: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v60));
    let mut v64: clap::Arg = v43.value_parser(v62);
    let v66: clap::Command = clap::Command::arg(v34, v64);
    let mut v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let v68: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v70: clap::Arg = clap::Arg::new(v68);
    let mut v72: clap::Arg = v70.short(b'w' as char);
    let mut v73: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v75: clap::Arg = v72.long(v73);
    let v77: clap::Arg = v75.required(true);
    let v79: clap::Command = clap::Command::arg(v66, v77);
    v79
}
fn method1() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method2(mut v0: Option<std::string::String>) -> Option<std::string::String> {
    v0
}
fn closure1() -> Rc<dyn Fn((std::string::String)) -> US0> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((std::string::String)) -> US0> = Rc::new(move |mut v0: (std::string::String)| -> US0 {
        let mut v1: std::string::String = (v0);
        US0::US0_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method3(mut v0: &Rc<RefCell<Mut0>>) -> bool {
    let mut v1: i32 = v0.borrow().l0;
    let mut v2: bool = v1 > 0i32;
    v2
}
fn get_environment_variable_5(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from(std::env::var(&*v0).unwrap_or_default());
    v1
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn new_trace_state_4(mut v0: US3) -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("TRACE_LEVEL"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = get_environment_variable_5(v1);
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
    let mut v8: Rc<str> = Rc::<str>::from(v7.to_lowercase());
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let mut v10: Rc<str> = Rc::<str>::from(v9.to_lowercase());
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let v12: Rc<str> = Rc::<str>::from(v11.to_lowercase());
    let mut v13: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
    let mut v14: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v11, v14));
    let mut v15: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v9, v15));
    let v16: US3 = US3::US3_Info;
    v13.borrow_mut().push((v7, v16));
    let v17: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v5, v17));
    let v18: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v3, v18));
    let mut v19: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v12, v19));
    let v20: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v10, v20));
    let mut v21: US3 = US3::US3_Info;
    v13.borrow_mut().push((v8, v21));
    let v22: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v6, v22));
    let v23: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v4, v23));
    let mut v24: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v13.borrow().clone());
    let v25: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v24).as_ref().clone()));
    let mut v26: i32 = (v25.clone().borrow().len() as i32);
    let v27: US2 = US2::US2_None;
    let mut v28: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v26, l1: v27 }));
    while method3(&v28) {
        let v30: i32 = v28.borrow().l0;
        let v31: i32 = v30.wrapping_sub(1i32);
        let v32: US2 = v28.borrow().l1.clone();
        let (mut v33, mut v34): (Rc<str>, US3) = v25.borrow()[v31 as usize].clone();
        let v41: US2 = match &v32 {
            US2::US2_None => {
                let v36: bool = v33 == v2 ;
                if v36 {
                    US2::US2_Some(v34)
                } else {
                    US2::US2_None
                }
            }
            US2::US2_Some(v35) => {
                let v35: US3 = v35.clone();
                v32
            }
        };
        v28.borrow_mut().l0 = v31;
        v28.borrow_mut().l1 = v41;
        ()
    };
    let v42: US2 = v28.borrow().l1.clone();
    let mut v43: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: 1i64 }));
    let mut v44: Rc<dyn Fn(Rc<str>) -> ()> = closure3();
    let v45: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: v44 }));
    let v46: Rc<RefCell<Mut3>> = Rc::new(RefCell::new(Mut3 { l0: true }));
    let v47: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let v48: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v47 }));
    let v51: US3 = match v42 {
        US2::US2_None => {
            v0
        }
        US2::US2_Some(v49) => {
            let v49: US3 = v49;
            v49
        }
    };
    let v52: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v51 }));
    let v53: Option<i64> = None;
    (v43, v45, v46, v48, v52, v53)
}
fn fresh_c2(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1, v2, v3, v4, v5, v6)
    })
}
fn fresh_c4(mut v0: US3) -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0.clone());
        (v1, v2, v3, v4, v5, v6)
    })
}
fn fresh_c5() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0);
        (v1, v2, v3, v4, v5, v6)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn fresh_c6() -> Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = Rc::new(move || -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
        let mut v0: US3 = US3::US3_Verbose;
        let (mut v1, mut v2, mut v3, mut v4, mut v5, mut v6): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = new_trace_state_4(v0);
        (v1, v2, v3, v4, v5, v6)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method7(mut v0: Option<[i64; 3]>) -> Option<[i64; 3]> {
    v0
}
fn closure7() -> Rc<dyn Fn(([i64; 3])) -> US5> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(([i64; 3])) -> US5> = Rc::new(move |mut v0: ([i64; 3])| -> US5 {
        let mut v1: [i64; 3] = (v0);
        US5::US5_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method6(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>) -> Rc<str> {
    let v6: Option<[i64; 3]> = spiral_cfg_local_clock();
    let v7: Option<[i64; 3]> = method7(v6);
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
            let v16: i64 = v15.wrapping_mul(3600i64);
            let v17: i64 = v14[1];
            let v18: i64 = v17.wrapping_mul(60i64);
            let mut v19: i64 = v16.wrapping_add(v18);
            let v20: i64 = v14[2];
            let mut v21: i64 = v19.wrapping_add(v20);
            let v22: u64 = (v21 as u64);
            v22
        }
    };
    let mut v28: u64 = v27.wrapping_div(3600u64);
    let mut v29: u64 = v28.wrapping_rem(24u64);
    let v30: bool = v29 < 10u64;
    let v33: Rc<str> = if v30 {
        let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v31
    } else {
        let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v32
    };
    let v34: Rc<str> = Rc::<str>::from((v29).to_string());
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v33, v34));
    let v36: Rc<str> = Rc::<str>::from(format!("{}{}", v35, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":"); } LIT.with(|lit| lit.clone()) }));
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
    let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", v42, v43));
    let v45: Rc<str> = Rc::<str>::from(format!("{}{}", v36, v44));
    let v46: Rc<str> = Rc::<str>::from(format!("{}{}", v45, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":"); } LIT.with(|lit| lit.clone()) }));
    let v47: u64 = v27.wrapping_rem(60u64);
    let v48: bool = v47 < 10u64;
    let v51: Rc<str> = if v48 {
        let v49: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v49
    } else {
        let v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v50
    };
    let v52: Rc<str> = Rc::<str>::from((v47).to_string());
    let v53: Rc<str> = Rc::<str>::from(format!("{}{}", v51, v52));
    let mut v54: Rc<str> = Rc::<str>::from(format!("{}{}", v46, v53));
    v54
}
fn method10(mut v0: &Rc<RefCell<Mut4>>, mut v1: Rc<str>) -> () {
    let mut v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, v1));
    v0.borrow_mut().l0 = v3;
    ()
}
fn format_real_9(mut v0: u8) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0 as char));
    method10(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method8() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[90m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_9(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7
}
fn method13(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
fn method14(mut v0: Rc<str>, mut v1: i32) -> i32 {
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
fn method12(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: i32 = (v0.clone().len() as i32);
    let mut v2: i32 = 0i32;
    let mut v3: i32 = method13(v0.clone(), v1, v2);
    let mut v4: i32 = v1.wrapping_sub(1i32);
    let mut v5: Rc<str> = string_slice(&v0, v3 as i64, v4 as i64);
    let v6: i32 = (v5.clone().len() as i32);
    let v7: i32 = method14(v5.clone(), v6);
    let mut v8: Rc<str> = string_slice(&v5, 0i32 as i64, v7 as i64);
    v8
}
fn format_real_15(mut v0: i64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method10(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method17(mut v0: u64, mut v1: &Rc<RefCell<Mut6>>) -> bool {
    let mut v2: u64 = v1.borrow().l0;
    let mut v3: bool = v2 < v0;
    v3
}
fn method16(mut v0: &Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v1: u64 = (v0.clone().borrow().len() as u64);
    let mut v2: u64 = 0u64;
    let mut v3: Rc<RefCell<Mut6>> = Rc::new(RefCell::new(Mut6 { l0: v2 }));
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v4 }));
    while method17(v1, &v3) {
        let v7: u64 = v3.borrow().l0;
        let mut v8: Rc<str> = v0.borrow()[v7 as usize].clone();
        let mut v9: bool = v7 == 0u64;
        let mut v13: Rc<str> = if v9 {
            v8
        } else {
            let mut v10: Rc<str> = v5.borrow().l0.clone();
            let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v10, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(", "); } LIT.with(|lit| lit.clone()) }));
            let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v8));
            v12
        };
        v5.borrow_mut().l0 = v13;
        let mut v14: u64 = v7.wrapping_add(1u64);
        v3.borrow_mut().l0 = v14;
        ()
    };
    let mut v15: Rc<str> = v5.borrow().l0.clone();
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("["); } LIT.with(|lit| lit.clone()) }, v15));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("]"); } LIT.with(|lit| lit.clone()) }));
    v17
}
fn method11(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: &Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.main"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = method16(v8);
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("args = "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v20));
    method12(v21)
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        println!("{}", v0);
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method18() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method19(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
fn method20(mut v0: Rc<str>, mut v1: i32) -> i32 {
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
        let v6: i32 = method19(v3.clone(), v4, v5);
        let v7: i32 = v4.wrapping_sub(1i32);
        let mut v8: Rc<str> = string_slice(&v3, v6 as i64, v7 as i64);
        let mut v9: i32 = (v8.clone().len() as i32);
        let mut v10: i32 = method20(v8.clone(), v9);
        let mut v11: Rc<str> = string_slice(&v8, 0i32 as i64, v10 as i64);
        v11
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method21(mut v0: Option<Rc<str>>) -> Option<Rc<str>> {
    v0
}
fn closure10() -> Rc<dyn Fn((Rc<str>)) -> US6> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> US6> = Rc::new(move |mut v0: (Rc<str>)| -> US6 {
        let mut v1: Rc<str> = (v0);
        US6::US6_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method23() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method24(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Rc<str>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm_path = "); } LIT.with(|lit| lit.clone()) }, v8));
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v19));
    method12(v20)
}
fn format_real_28(mut v0: u8) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method10(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method27(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v10: near_workspaces::Contract) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0;
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v13: Rc<str> = format_real_15(v11);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let mut v19: Rc<str> = format_real_28(v8);
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v19));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("worker"); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from(format!("{}{}", v22, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let mut v24: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Worker<near_workspaces::network::Sandbox>>") } } (&&W(&v9)).s() });
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v26, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("contract"); } LIT.with(|lit| lit.clone()) }));
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v27, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let mut v29: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::Contract>") } } (&&W(&v10)).s() });
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v30));
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v31, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v32));
    method12(v33)
}
fn method29(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0;
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v12: Rc<str> = format_real_15(v10);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = format_real_28(v8);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result"); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<near_workspaces::result::ExecutionFinalResult>") } } (&&W(&v9)).s() });
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v26));
    method12(v27)
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
fn method30() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_9(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7
}
fn position_of_33(mut v0: u8, mut v1: Rc<str>, mut v2: i32) -> i32 {
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
fn digits_value_34(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
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
            let mut v10: i32 = position_of_33(v7, v8, v9);
            let mut v11: i32 = v6.wrapping_add(v10);
            (v1, v2) = (v5, v11);
            continue;
        }
    }
}
fn zeros_from_35(mut v0: Rc<str>, mut v1: i32) -> i32 {
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
fn zeros_before_36(mut v0: Rc<str>, mut v1: i32) -> i32 {
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
fn repeated_zeros_37(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let mut v2: bool = v0 <= 0i32;
        if v2 {
            return v1;
        } else {
            let mut v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", v1, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) }));
            (v0, v1) = (v3, v4);
            continue;
        }
    }
}
fn digits_text_38(mut v0: i32, mut v1: Rc<str>) -> Rc<str> {
    loop {
        let mut v2: i32 = v0.wrapping_rem(10i32);
        let mut v3: i32 = v2.wrapping_add(1i32);
        let mut v4: i32 = v3.wrapping_sub(1i32);
        let mut v5: Rc<str> = string_slice(&{ thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0123456789"); } LIT.with(|lit| lit.clone()) }, v2 as i64, v4 as i64);
        let v6: bool = v0 < 10i32;
        if v6 {
            let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v1));
            return v7;
        } else {
            let mut v8: i32 = v0.wrapping_div(10i32);
            let mut v9: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v1));
            (v0, v1) = (v8, v9);
            continue;
        }
    }
}
fn format_real_32(mut v0: f64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1.clone() }));
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
    let mut v165: Rc<str> = if v18 {
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
        let v30: Rc<str> = if v23 {
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
        let v35: i32 = position_of_33(v33, v30.clone(), v34);
        let v36: bool = v35 >= 0i32;
        let mut v40: i32 = if v36 {
            v35
        } else {
            let v37: u8 = b'E';
            let mut v38: i32 = 0i32;
            position_of_33(v37, v30.clone(), v38)
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
                let mut v44: Rc<str> = string_slice(&v30.clone(), 0i32 as i64, v43 as i64);
                v44
            }
        };
        let v47: u8 = b'.';
        let v48: i32 = 0i32;
        let v49: i32 = position_of_33(v47, v46.clone(), v48);
        let v50: bool = v49 < 0i32;
        let v55: Rc<str> = if v50 {
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
        let v65: Rc<str> = if v50 {
            v1.clone()
        } else {
            let v56: i32 = v49.wrapping_add(1i32);
            let mut v57: i32 = (v46.clone().len() as i32);
            let v58: i32 = v57.wrapping_sub(v49);
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
        let v66: Rc<str> = Rc::<str>::from(format!("{}{}", v55.clone(), v65));
        let mut v67: i32 = (v55.len() as i32);
        let v95: i32 = if v41 {
            0i32
        } else {
            let v68: i32 = v40.wrapping_add(1i32);
            let v69: i32 = (v30.clone().len() as i32);
            let mut v70: i32 = v69.wrapping_sub(v40);
            let v71: i32 = v70.wrapping_sub(1i32);
            let mut v72: bool = v71 <= 0i32;
            let v76: Rc<str> = if v72 {
                v1.clone()
            } else {
                let mut v73: i32 = v68.wrapping_add(v71);
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
                    let v83: i32 = digits_value_34(v76, v81, v82);
                    let v84: i32 = v83.wrapping_neg();
                    v84
                } else {
                    let v85: bool = v79 == b'+';
                    if v85 {
                        let v86: i32 = 1i32;
                        let mut v87: i32 = 0i32;
                        digits_value_34(v76, v86, v87)
                    } else {
                        let mut v89: i32 = 0i32;
                        let v90: i32 = 0i32;
                        digits_value_34(v76, v89, v90)
                    }
                }
            }
        };
        let v96: i32 = v67.wrapping_add(v95);
        let v97: i32 = 0i32;
        let mut v98: i32 = zeros_from_35(v66.clone(), v97);
        let v99: i32 = (v66.clone().len() as i32);
        let mut v100: i32 = zeros_before_36(v66.clone(), v99);
        let v101: bool = v98 >= v100;
        if v101 {
            let v102: Rc<str> = Rc::<str>::from(format!("{}{}", v32, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0.0"); } LIT.with(|lit| lit.clone()) }));
            v102
        } else {
            let v103: i32 = v100.wrapping_sub(v98);
            let mut v104: bool = v103 <= 0i32;
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
                    let v117: Rc<str> = repeated_zeros_37(v116, v1);
                    let v118: Rc<str> = Rc::<str>::from(format!("{}{}", v117, v108));
                    let v119: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0."); } LIT.with(|lit| lit.clone()) }, v118));
                    v119
                } else {
                    let v120: bool = v114 <= v109;
                    if v120 {
                        let v121: i32 = v109.wrapping_sub(v114);
                        let v122: Rc<str> = repeated_zeros_37(v121, v1);
                        let mut v123: Rc<str> = Rc::<str>::from(format!("{}{}", v122, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(".0"); } LIT.with(|lit| lit.clone()) }));
                        let v124: Rc<str> = Rc::<str>::from(format!("{}{}", v108, v123));
                        v124
                    } else {
                        let v125: Rc<str> = string_slice(&v108.clone(), 0i32 as i64, v110 as i64);
                        let mut v126: i32 = v114.wrapping_sub(v109);
                        let v127: bool = v126 <= 0i32;
                        let v131: Rc<str> = if v127 {
                            v1
                        } else {
                            let v128: i32 = v109.wrapping_add(v126);
                            let v129: i32 = v128.wrapping_sub(1i32);
                            let v130: Rc<str> = string_slice(&v108, v109 as i64, v129 as i64);
                            v130
                        };
                        let v132: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) }, v131));
                        let v133: Rc<str> = Rc::<str>::from(format!("{}{}", v125, v132));
                        v133
                    }
                };
                let v136: Rc<str> = Rc::<str>::from(format!("{}{}", v32, v135));
                v136
            } else {
                let v137: i32 = (v108.clone().len() as i32);
                let v138: bool = v137 > 1i32;
                let v146: Rc<str> = if v138 {
                    let v139: i32 = v137.wrapping_sub(1i32);
                    let v140: bool = v139 <= 0i32;
                    let mut v144: Rc<str> = if v140 {
                        v1.clone()
                    } else {
                        let v141: i32 = 1i32.wrapping_add(v139);
                        let v142: i32 = v141.wrapping_sub(1i32);
                        let v143: Rc<str> = string_slice(&v108.clone(), 1i32 as i64, v142 as i64);
                        v143
                    };
                    let v145: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) }, v144));
                    v145
                } else {
                    v1.clone()
                };
                let mut v147: Rc<str> = string_slice(&v108, 0i32 as i64, 0i32 as i64);
                let v148: bool = v110 < 0i32;
                let v151: Rc<str> = if v148 {
                    let v149: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e-"); } LIT.with(|lit| lit.clone()) };
                    v149
                } else {
                    let v150: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("e+"); } LIT.with(|lit| lit.clone()) };
                    v150
                };
                let mut v153: i32 = if v148 {
                    let v152: i32 = v110.wrapping_neg();
                    v152
                } else {
                    v110
                };
                let v154: bool = v153 < 10i32;
                let v158: Rc<str> = if v154 {
                    let v155: Rc<str> = digits_text_38(v153, v1);
                    let v156: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) }, v155));
                    v156
                } else {
                    digits_text_38(v153, v1)
                };
                let v159: Rc<str> = Rc::<str>::from(format!("{}{}", v151, v158));
                let v160: Rc<str> = Rc::<str>::from(format!("{}{}", v146, v159));
                let v161: Rc<str> = Rc::<str>::from(format!("{}{}", v147, v160));
                let mut v162: Rc<str> = Rc::<str>::from(format!("{}{}", v32, v161));
                v162
            }
        }
    };
    method10(&v2, v165);
    let mut v166: Rc<str> = v2.borrow().l0.clone();
    v166
}
fn format_real_39(mut v0: u64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method10(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method31(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: f64, mut v10: u64) -> Rc<str> {
    let mut v11: i64 = v0.borrow().l0;
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v13: Rc<str> = format_real_15(v11);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd"); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let mut v19: Rc<str> = format_real_28(v8);
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v19));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt_usd"); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from(format!("{}{}", v22, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let mut v24: Rc<str> = format_real_32(v9);
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v23, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v26, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("total_gas_burnt"); } LIT.with(|lit| lit.clone()) }));
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v27, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let mut v29: Rc<str> = format_real_39(v10);
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v28, v29));
    let v31: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v30));
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v31, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v32));
    method12(v33)
}
fn format_real_41(mut v0: bool) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v5: Rc<str> = if v0 {
        let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("true"); } LIT.with(|lit| lit.clone()) };
        v3
    } else {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("false"); } LIT.with(|lit| lit.clone()) };
        v4
    };
    method10(&v2, v5);
    let v6: Rc<str> = v2.borrow().l0.clone();
    v6
}
fn method40(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: bool, mut v9: f64, mut v10: f64, mut v11: u64, mut v12: u128) -> Rc<str> {
    let mut v13: i64 = v0.borrow().l0;
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = format_real_15(v13);
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v15));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v7));
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd / outcome"); } LIT.with(|lit| lit.clone()) }));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = format_real_41(v8);
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("is_success = "); } LIT.with(|lit| lit.clone()) }, v21));
    let v23: Rc<str> = Rc::<str>::from(format!("{}{}", v22, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v23, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt_usd"); } LIT.with(|lit| lit.clone()) }));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v24, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let mut v26: Rc<str> = format_real_32(v9);
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v26));
    let mut v28: Rc<str> = Rc::<str>::from(format!("{}{}", v27, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v29: Rc<str> = Rc::<str>::from(format!("{}{}", v28, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt_usd"); } LIT.with(|lit| lit.clone()) }));
    let v30: Rc<str> = Rc::<str>::from(format!("{}{}", v29, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v31: Rc<str> = format_real_32(v10);
    let v32: Rc<str> = Rc::<str>::from(format!("{}{}", v30, v31));
    let v33: Rc<str> = Rc::<str>::from(format!("{}{}", v32, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v34: Rc<str> = Rc::<str>::from(format!("{}{}", v33, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gas_burnt"); } LIT.with(|lit| lit.clone()) }));
    let v35: Rc<str> = Rc::<str>::from(format!("{}{}", v34, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v36: Rc<str> = format_real_39(v11);
    let v37: Rc<str> = Rc::<str>::from(format!("{}{}", v35, v36));
    let mut v38: Rc<str> = Rc::<str>::from(format!("{}{}", v37, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v39: Rc<str> = Rc::<str>::from(format!("{}{}", v38, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("tokens_burnt"); } LIT.with(|lit| lit.clone()) }));
    let mut v40: Rc<str> = Rc::<str>::from(format!("{}{}", v39, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v41: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<u128>") } } (&&W(&v12)).s() });
    let v42: Rc<str> = Rc::<str>::from(format!("{}{}", v40, v41));
    let mut v43: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v42));
    let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", v43, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v45: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v44));
    method12(v45)
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
        let v16: f64 = v15 / 1E+24f64;
        let v17: f64 = v16 * 6.68f64;
        let v18: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
        let mut v40: bool = if v18 {
            true
        } else {
            let v20: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
            { let _ = spiral_trace_hold(&v20); };
            let v22: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
            let (mut v23, mut v24, mut v25, mut v26, mut v27, mut v28): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v22);
            let mut v29: US3 = v27.borrow().l0.clone();
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
            let v35: bool = v25.borrow().l0;
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
        let mut v89: US4 = if v40 {
            US4::US4_None
        } else {
            let mut v43: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
            { let _ = spiral_trace_hold(&v43); };
            let v45: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
            let (mut v46, mut v47, mut v48, mut v49, mut v50, mut v51): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v45);
            let v52: Rc<str> = method6(&v46, &v47, &v48, &v49, &v50, v51.clone());
            let v53: Rc<str> = method30();
            let mut v54: Rc<str> = method40(&v46, &v47, &v48, &v49, &v50, v51, v52, v53, v2, v9, v17, v6, v13);
            { let _ = spiral_trace_hold(&v43); };
            let (mut v57, mut v58, mut v59, mut v60, mut v61, mut v62): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v45);
            let v63: i64 = v57.borrow().l0;
            let mut v64: i64 = v63.wrapping_add(1i64);
            v57.borrow_mut().l0 = v64;
            let v65: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
            let v66: bool = cfg!(target_arch = "wasm32");
            if v66 {
                let mut v67: Rc<str> = v60.borrow().l0.clone();
                let v68: bool = &*v67 == "";
                let mut v75: Rc<str> = if v68 {
                    v54.clone()
                } else {
                    let v69: bool = &*v54 == "";
                    if v69 {
                        let mut v70: Rc<str> = v60.borrow().l0.clone();
                        v70
                    } else {
                        let v71: Rc<str> = v60.borrow().l0.clone();
                        let mut v72: Rc<str> = Rc::<str>::from(format!("{}{}", v71, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                        let mut v73: Rc<str> = Rc::<str>::from(format!("{}{}", v72, v54.clone()));
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
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method42(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>>") } } (&&W(&v8)).s() });
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("result2 = "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v20));
    method12(v21)
}
fn method43(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn format_real_45(mut v0: i32) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<RefCell<Mut4>> = Rc::new(RefCell::new(Mut4 { l0: v1 }));
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}", v0));
    method10(&v2, v3);
    let mut v4: Rc<str> = v2.borrow().l0.clone();
    v4
}
fn method44(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0;
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v12: Rc<str> = format_real_15(v10);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = format_real_45(v8);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures_len = "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures"); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v9)).s() });
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v26));
    method12(v27)
}
fn method46(mut v0: near_workspaces::result::ExecutionFinalResult) -> near_workspaces::result::ExecutionFinalResult {
    v0
}
fn method47(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: i32, mut v9: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0;
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v12: Rc<str> = format_real_15(v10);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = format_real_45(v8);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len = "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes"); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v9)).s() });
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v26));
    method12(v27)
}
fn method48(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v8)).s() });
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("json = "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v20));
    method12(v21)
}
fn method49(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Result<std::string::String, near_workspaces::error::Error>>") } } (&&W(&v8)).s() });
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("borsh = "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v20));
    method12(v21)
}
fn fn_26(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let mut v9: Result<near_workspaces::Worker<near_workspaces::network::Sandbox>, near_workspaces::error::Error> = near_workspaces::sandbox().await;
    let mut v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
    let mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox> = v11.clone();
    let mut v15: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::Contract, near_workspaces::error::Error>>>> = Box::pin(v13.dev_deploy(&v0));
    let v17: Result<near_workspaces::Contract, near_workspaces::error::Error> = v15.await;
    let mut v19: near_workspaces::Contract = v17?;
    let v20: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v42: bool = if v20 {
        true
    } else {
        let v22: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v22); };
        let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v25, mut v26, mut v27, mut v28, mut v29, mut v30): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v24);
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
    let v91: US4 = if v42 {
        US4::US4_None
    } else {
        let v45: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v45); };
        let v47: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v48, mut v49, mut v50, mut v51, mut v52, mut v53): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v47);
        let mut v54: Rc<str> = method6(&v48, &v49, &v50, &v51, &v52, v53.clone());
        let v55: Rc<str> = method8();
        let v56: Rc<str> = method27(&v48, &v49, &v50, &v51, &v52, v53, v54, v55, v1, v11, v19.clone());
        { let _ = spiral_trace_hold(&v45); };
        let (mut v59, mut v60, mut v61, mut v62, mut v63, mut v64): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v47);
        let v65: i64 = v59.borrow().l0;
        let v66: i64 = v65.wrapping_add(1i64);
        v59.borrow_mut().l0 = v66;
        let mut v67: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v68: bool = cfg!(target_arch = "wasm32");
        if v68 {
            let v69: Rc<str> = v62.borrow().l0.clone();
            let mut v70: bool = &*v69 == "";
            let v77: Rc<str> = if v70 {
                v56.clone()
            } else {
                let v71: bool = &*v56 == "";
                if v71 {
                    let mut v72: Rc<str> = v62.borrow().l0.clone();
                    v72
                } else {
                    let mut v73: Rc<str> = v62.borrow().l0.clone();
                    let v74: Rc<str> = Rc::<str>::from(format!("{}{}", v73, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let mut v75: Rc<str> = Rc::<str>::from(format!("{}{}", v74, v56.clone()));
                    v75
                }
            };
            let v79: usize = v77.len();
            let v80: i32 = ((v79) as i32);
            let v81: i32 = v80.wrapping_add(14999i32);
            let v82: i32 = v81.wrapping_div(15000i32);
            let v83: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v84: bool = v56 != v83 ;
            let v86: bool = if v84 {
                let v85: bool = v82 <= 1i32;
                v85
            } else {
                false
            };
            if v86 {
                v62.borrow_mut().l0 = v77;
                ()
            } else {
                v62.borrow_mut().l0 = v83;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v77); };
                ()
            }
        } else {
            println!("{}", v56);
            ()
        };
        let mut v89: Rc<dyn Fn(Rc<str>) -> ()> = v60.borrow().l0.clone();
        v89(v56);
        US4::US4_Some(v59, v60, v61, v62, v63, v64)
    };
    let v93: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v94: near_workspaces::operations::CallTransaction = v19.call(&*v93);
    let v96: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v98: near_workspaces::operations::CallTransaction = v94.gas(v96);
    let mut v100: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v98.transact());
    let v102: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v100.await;
    let mut v104: near_workspaces::result::ExecutionFinalResult = v102?;
    let v105: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v127: bool = if v105 {
        true
    } else {
        let v107: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v107); };
        let v109: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v110, mut v111, mut v112, mut v113, mut v114, mut v115): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v109);
        let v116: US3 = v114.borrow().l0.clone();
        let v121: i32 = match v116 {
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
        let v122: bool = v112.borrow().l0;
        let mut v123: bool = v122 == false;
        let v125: bool = if v123 {
            false
        } else {
            let v124: bool = 10i32 >= v121;
            v124
        };
        let mut v126: bool = v125 == false;
        v126
    };
    let mut v176: US4 = if v127 {
        US4::US4_None
    } else {
        let v130: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v130); };
        let v132: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v133, mut v134, mut v135, mut v136, mut v137, mut v138): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v132);
        let v139: Rc<str> = method6(&v133, &v134, &v135, &v136, &v137, v138.clone());
        let v140: Rc<str> = method8();
        let v141: Rc<str> = method29(&v133, &v134, &v135, &v136, &v137, v138, v139, v140, v1, v104.clone());
        { let _ = spiral_trace_hold(&v130); };
        let (mut v144, mut v145, mut v146, mut v147, mut v148, mut v149): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v132);
        let v150: i64 = v144.borrow().l0;
        let v151: i64 = v150.wrapping_add(1i64);
        v144.borrow_mut().l0 = v151;
        let v152: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v153: bool = cfg!(target_arch = "wasm32");
        if v153 {
            let v154: Rc<str> = v147.borrow().l0.clone();
            let v155: bool = &*v154 == "";
            let mut v162: Rc<str> = if v155 {
                v141.clone()
            } else {
                let v156: bool = &*v141 == "";
                if v156 {
                    let v157: Rc<str> = v147.borrow().l0.clone();
                    v157
                } else {
                    let v158: Rc<str> = v147.borrow().l0.clone();
                    let v159: Rc<str> = Rc::<str>::from(format!("{}{}", v158, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v160: Rc<str> = Rc::<str>::from(format!("{}{}", v159, v141.clone()));
                    v160
                }
            };
            let v164: usize = v162.len();
            let mut v165: i32 = ((v164) as i32);
            let mut v166: i32 = v165.wrapping_add(14999i32);
            let v167: i32 = v166.wrapping_div(15000i32);
            let v168: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v169: bool = v141 != v168 ;
            let v171: bool = if v169 {
                let v170: bool = v167 <= 1i32;
                v170
            } else {
                false
            };
            if v171 {
                v147.borrow_mut().l0 = v162;
                ()
            } else {
                v147.borrow_mut().l0 = v168;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v162); };
                ()
            }
        } else {
            println!("{}", v141);
            ()
        };
        let mut v174: Rc<dyn Fn(Rc<str>) -> ()> = v145.borrow().l0.clone();
        v174(v141);
        US4::US4_Some(v144, v145, v146, v147, v148, v149)
    };
    let v178: Vec<&str> = v104.logs();
    let mut v180: Rc<dyn Fn((&str)) -> std::string::String> = closure11();
    let mut v181: Vec<std::string::String> = v178.iter().map(|x| v180(x.clone())).collect::<Vec<_>>();
    let mut v183: Rc<dyn Fn(std::string::String) -> ()> = closure12();
    let v184: bool = true; v181.iter().for_each(|x| { v183(x.clone()); }); //;
    let v185: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
    let v207: bool = if v185 {
        true
    } else {
        let v187: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v187); };
        let v189: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v190, mut v191, mut v192, mut v193, mut v194, mut v195): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v189);
        let v196: US3 = v194.borrow().l0.clone();
        let v201: i32 = match v196 {
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
        let v202: bool = v192.borrow().l0;
        let v203: bool = v202 == false;
        let v205: bool = if v203 {
            false
        } else {
            let v204: bool = 30i32 >= v201;
            v204
        };
        let v206: bool = v205 == false;
        v206
    };
    let v246: US4 = if v207 {
        US4::US4_None
    } else {
        let v210: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v210); };
        let v212: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v213, mut v214, mut v215, mut v216, mut v217, mut v218): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v212);
        let v219: i64 = v213.borrow().l0;
        let v220: i64 = v219.wrapping_add(1i64);
        v213.borrow_mut().l0 = v220;
        let v221: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let v222: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v223: bool = cfg!(target_arch = "wasm32");
        if v223 {
            let v224: Rc<str> = v216.borrow().l0.clone();
            let v225: bool = &*v224 == "";
            let v232: Rc<str> = if v225 {
                v221.clone()
            } else {
                let mut v226: bool = &*v221 == "";
                if v226 {
                    let v227: Rc<str> = v216.borrow().l0.clone();
                    v227
                } else {
                    let v228: Rc<str> = v216.borrow().l0.clone();
                    let v229: Rc<str> = Rc::<str>::from(format!("{}{}", v228, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v230: Rc<str> = Rc::<str>::from(format!("{}{}", v229, v221.clone()));
                    v230
                }
            };
            let v234: usize = v232.len();
            let v235: i32 = ((v234) as i32);
            let v236: i32 = v235.wrapping_add(14999i32);
            let v237: i32 = v236.wrapping_div(15000i32);
            let v238: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v239: bool = v221 != v238 ;
            let v241: bool = if v239 {
                let v240: bool = v237 <= 1i32;
                v240
            } else {
                false
            };
            if v241 {
                v216.borrow_mut().l0 = v232;
                ()
            } else {
                v216.borrow_mut().l0 = v238;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v232); };
                ()
            }
        } else {
            println!("{}", v221);
            ()
        };
        let mut v244: Rc<dyn Fn(Rc<str>) -> ()> = v214.borrow().l0.clone();
        v244(v221);
        US4::US4_Some(v213, v214, v215, v216, v217, v218)
    };
    let mut v248: near_workspaces::types::Gas = v104.total_gas_burnt;
    let v250: u64 = v248.as_gas();
    let v251: f64 = (v250 as f64);
    let v252: f64 = v251 / 10000000000000000.0f64;
    let v253: f64 = v252 * 6.68f64;
    let mut v254: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Warning" | "Critical"));
    let v276: bool = if v254 {
        true
    } else {
        let v256: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v256); };
        let v258: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v259, mut v260, mut v261, mut v262, mut v263, mut v264): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v258);
        let v265: US3 = v263.borrow().l0.clone();
        let v270: i32 = match v265 {
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
        let v271: bool = v261.borrow().l0;
        let v272: bool = v271 == false;
        let v274: bool = if v272 {
            false
        } else {
            let v273: bool = 30i32 >= v270;
            v273
        };
        let v275: bool = v274 == false;
        v275
    };
    let v325: US4 = if v276 {
        US4::US4_None
    } else {
        let v279: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v279); };
        let v281: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v282, mut v283, mut v284, mut v285, mut v286, mut v287): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v281);
        let v288: Rc<str> = method6(&v282, &v283, &v284, &v285, &v286, v287.clone());
        let v289: Rc<str> = method30();
        let v290: Rc<str> = method31(&v282, &v283, &v284, &v285, &v286, v287, v288, v289, v1, v253, v250);
        { let _ = spiral_trace_hold(&v279); };
        let (mut v293, mut v294, mut v295, mut v296, mut v297, mut v298): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v281);
        let v299: i64 = v293.borrow().l0;
        let v300: i64 = v299.wrapping_add(1i64);
        v293.borrow_mut().l0 = v300;
        let v301: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v302: bool = cfg!(target_arch = "wasm32");
        if v302 {
            let v303: Rc<str> = v296.borrow().l0.clone();
            let v304: bool = &*v303 == "";
            let v311: Rc<str> = if v304 {
                v290.clone()
            } else {
                let v305: bool = &*v290 == "";
                if v305 {
                    let v306: Rc<str> = v296.borrow().l0.clone();
                    v306
                } else {
                    let v307: Rc<str> = v296.borrow().l0.clone();
                    let v308: Rc<str> = Rc::<str>::from(format!("{}{}", v307, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v309: Rc<str> = Rc::<str>::from(format!("{}{}", v308, v290.clone()));
                    v309
                }
            };
            let v313: usize = v311.len();
            let v314: i32 = ((v313) as i32);
            let mut v315: i32 = v314.wrapping_add(14999i32);
            let v316: i32 = v315.wrapping_div(15000i32);
            let v317: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v318: bool = v290 != v317 ;
            let v320: bool = if v318 {
                let v319: bool = v316 <= 1i32;
                v319
            } else {
                false
            };
            if v320 {
                v296.borrow_mut().l0 = v311;
                ()
            } else {
                v296.borrow_mut().l0 = v317;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v311); };
                ()
            }
        } else {
            println!("{}", v290);
            ()
        };
        let mut v323: Rc<dyn Fn(Rc<str>) -> ()> = v294.borrow().l0.clone();
        v323(v290);
        US4::US4_Some(v293, v294, v295, v296, v297, v298)
    };
    let mut v327: near_workspaces::result::ExecutionFinalResult = v104.clone();
    let mut v329: Vec<&near_workspaces::result::ExecutionOutcome> = v327.outcomes();
    let v331: _ = v329.into_iter();
    let mut v333: _ = v331.cloned();
    let mut v335: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure13();
    let v336: bool = true; v333.for_each(|x| v335(x));
    let v338: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v104.clone().into_result();
    let v339: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v361: bool = if v339 {
        true
    } else {
        let v341: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v341); };
        let v343: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v344, mut v345, mut v346, mut v347, mut v348, mut v349): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v343);
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
            let v358: bool = 10i32 >= v355;
            v358
        };
        let v360: bool = v359 == false;
        v360
    };
    let v410: US4 = if v361 {
        US4::US4_None
    } else {
        let v364: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v364); };
        let v366: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v367, mut v368, mut v369, mut v370, mut v371, mut v372): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v366);
        let mut v373: Rc<str> = method6(&v367, &v368, &v369, &v370, &v371, v372.clone());
        let v374: Rc<str> = method8();
        let v375: Rc<str> = method42(&v367, &v368, &v369, &v370, &v371, v372, v373, v374, v338);
        { let _ = spiral_trace_hold(&v364); };
        let (mut v378, mut v379, mut v380, mut v381, mut v382, mut v383): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v366);
        let v384: i64 = v378.borrow().l0;
        let v385: i64 = v384.wrapping_add(1i64);
        v378.borrow_mut().l0 = v385;
        let v386: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v387: bool = cfg!(target_arch = "wasm32");
        if v387 {
            let v388: Rc<str> = v381.borrow().l0.clone();
            let v389: bool = &*v388 == "";
            let v396: Rc<str> = if v389 {
                v375.clone()
            } else {
                let v390: bool = &*v375 == "";
                if v390 {
                    let v391: Rc<str> = v381.borrow().l0.clone();
                    v391
                } else {
                    let v392: Rc<str> = v381.borrow().l0.clone();
                    let v393: Rc<str> = Rc::<str>::from(format!("{}{}", v392, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v394: Rc<str> = Rc::<str>::from(format!("{}{}", v393, v375.clone()));
                    v394
                }
            };
            let v398: usize = v396.len();
            let v399: i32 = ((v398) as i32);
            let v400: i32 = v399.wrapping_add(14999i32);
            let v401: i32 = v400.wrapping_div(15000i32);
            let v402: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v403: bool = v375 != v402 ;
            let v405: bool = if v403 {
                let mut v404: bool = v401 <= 1i32;
                v404
            } else {
                false
            };
            if v405 {
                v381.borrow_mut().l0 = v396;
                ()
            } else {
                v381.borrow_mut().l0 = v402;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v396); };
                ()
            }
        } else {
            println!("{}", v375);
            ()
        };
        let mut v408: Rc<dyn Fn(Rc<str>) -> ()> = v379.borrow().l0.clone();
        v408(v375);
        US4::US4_Some(v378, v379, v380, v381, v382, v383)
    };
    let mut v411: near_workspaces::result::ExecutionFinalResult = method43(v104.clone());
    let v413: Vec<&near_workspaces::result::ExecutionOutcome> = v411.receipt_failures();
    let v414: usize = ((v413).len() as usize);
    let v415: i32 = (v414 as i32);
    let v416: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v438: bool = if v416 {
        true
    } else {
        let v418: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v418); };
        let v420: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v421, mut v422, mut v423, mut v424, mut v425, mut v426): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v420);
        let v427: US3 = v425.borrow().l0.clone();
        let v432: i32 = match v427 {
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
        let v433: bool = v423.borrow().l0;
        let v434: bool = v433 == false;
        let v436: bool = if v434 {
            false
        } else {
            let v435: bool = 10i32 >= v432;
            v435
        };
        let v437: bool = v436 == false;
        v437
    };
    let v487: US4 = if v438 {
        US4::US4_None
    } else {
        let v441: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v441); };
        let v443: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v444, mut v445, mut v446, mut v447, mut v448, mut v449): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v443);
        let v450: Rc<str> = method6(&v444, &v445, &v446, &v447, &v448, v449.clone());
        let v451: Rc<str> = method8();
        let v452: Rc<str> = method44(&v444, &v445, &v446, &v447, &v448, v449, v450, v451, v415, v413.clone());
        { let _ = spiral_trace_hold(&v441); };
        let (mut v455, mut v456, mut v457, mut v458, mut v459, mut v460): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v443);
        let v461: i64 = v455.borrow().l0;
        let v462: i64 = v461.wrapping_add(1i64);
        v455.borrow_mut().l0 = v462;
        let v463: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v464: bool = cfg!(target_arch = "wasm32");
        if v464 {
            let v465: Rc<str> = v458.borrow().l0.clone();
            let v466: bool = &*v465 == "";
            let v473: Rc<str> = if v466 {
                v452.clone()
            } else {
                let v467: bool = &*v452 == "";
                if v467 {
                    let v468: Rc<str> = v458.borrow().l0.clone();
                    v468
                } else {
                    let v469: Rc<str> = v458.borrow().l0.clone();
                    let v470: Rc<str> = Rc::<str>::from(format!("{}{}", v469, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v471: Rc<str> = Rc::<str>::from(format!("{}{}", v470, v452.clone()));
                    v471
                }
            };
            let v475: usize = v473.len();
            let v476: i32 = ((v475) as i32);
            let v477: i32 = v476.wrapping_add(14999i32);
            let v478: i32 = v477.wrapping_div(15000i32);
            let v479: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v480: bool = v452 != v479 ;
            let v482: bool = if v480 {
                let v481: bool = v478 <= 1i32;
                v481
            } else {
                false
            };
            if v482 {
                v458.borrow_mut().l0 = v473;
                ()
            } else {
                v458.borrow_mut().l0 = v479;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v473); };
                ()
            }
        } else {
            println!("{}", v452);
            ()
        };
        let mut v485: Rc<dyn Fn(Rc<str>) -> ()> = v456.borrow().l0.clone();
        v485(v452);
        US4::US4_Some(v455, v456, v457, v458, v459, v460)
    };
    let mut v488: near_workspaces::result::ExecutionFinalResult = method46(v104.clone());
    let v490: &[near_workspaces::result::ExecutionOutcome] = v488.receipt_outcomes();
    let v492: Vec<near_workspaces::result::ExecutionOutcome> = v490.into();
    let v493: usize = ((v492).len() as usize);
    let v494: i32 = (v493 as i32);
    let v495: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v517: bool = if v495 {
        true
    } else {
        let v497: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v497); };
        let v499: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v500, mut v501, mut v502, mut v503, mut v504, mut v505): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v499);
        let v506: US3 = v504.borrow().l0.clone();
        let v511: i32 = match v506 {
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
        let v512: bool = v502.borrow().l0;
        let v513: bool = v512 == false;
        let v515: bool = if v513 {
            false
        } else {
            let v514: bool = 10i32 >= v511;
            v514
        };
        let v516: bool = v515 == false;
        v516
    };
    let v566: US4 = if v517 {
        US4::US4_None
    } else {
        let v520: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v520); };
        let v522: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v523, mut v524, mut v525, mut v526, mut v527, mut v528): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v522);
        let v529: Rc<str> = method6(&v523, &v524, &v525, &v526, &v527, v528.clone());
        let v530: Rc<str> = method8();
        let v531: Rc<str> = method47(&v523, &v524, &v525, &v526, &v527, v528, v529, v530, v494, v492);
        { let _ = spiral_trace_hold(&v520); };
        let (mut v534, mut v535, mut v536, mut v537, mut v538, mut v539): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v522);
        let v540: i64 = v534.borrow().l0;
        let v541: i64 = v540.wrapping_add(1i64);
        v534.borrow_mut().l0 = v541;
        let v542: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v543: bool = cfg!(target_arch = "wasm32");
        if v543 {
            let v544: Rc<str> = v537.borrow().l0.clone();
            let v545: bool = &*v544 == "";
            let v552: Rc<str> = if v545 {
                v531.clone()
            } else {
                let v546: bool = &*v531 == "";
                if v546 {
                    let v547: Rc<str> = v537.borrow().l0.clone();
                    v547
                } else {
                    let v548: Rc<str> = v537.borrow().l0.clone();
                    let v549: Rc<str> = Rc::<str>::from(format!("{}{}", v548, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v550: Rc<str> = Rc::<str>::from(format!("{}{}", v549, v531.clone()));
                    v550
                }
            };
            let v554: usize = v552.len();
            let v555: i32 = ((v554) as i32);
            let v556: i32 = v555.wrapping_add(14999i32);
            let v557: i32 = v556.wrapping_div(15000i32);
            let v558: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v559: bool = v531 != v558 ;
            let v561: bool = if v559 {
                let v560: bool = v557 <= 1i32;
                v560
            } else {
                false
            };
            if v561 {
                v537.borrow_mut().l0 = v552;
                ()
            } else {
                v537.borrow_mut().l0 = v558;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v552); };
                ()
            }
        } else {
            println!("{}", v531);
            ()
        };
        let mut v564: Rc<dyn Fn(Rc<str>) -> ()> = v535.borrow().l0.clone();
        v564(v531);
        US4::US4_Some(v534, v535, v536, v537, v538, v539)
    };
    let mut v568: near_workspaces::result::ExecutionFinalResult = v104.clone();
    let v570: Result<std::string::String, near_workspaces::error::Error> = v568.json();
    let v571: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v593: bool = if v571 {
        true
    } else {
        let v573: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v573); };
        let v575: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v576, mut v577, mut v578, mut v579, mut v580, mut v581): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v575);
        let v582: US3 = v580.borrow().l0.clone();
        let v587: i32 = match v582 {
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
        let v588: bool = v578.borrow().l0;
        let v589: bool = v588 == false;
        let v591: bool = if v589 {
            false
        } else {
            let v590: bool = 10i32 >= v587;
            v590
        };
        let v592: bool = v591 == false;
        v592
    };
    let v642: US4 = if v593 {
        US4::US4_None
    } else {
        let v596: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v596); };
        let v598: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v599, mut v600, mut v601, mut v602, mut v603, mut v604): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v598);
        let v605: Rc<str> = method6(&v599, &v600, &v601, &v602, &v603, v604.clone());
        let v606: Rc<str> = method8();
        let v607: Rc<str> = method48(&v599, &v600, &v601, &v602, &v603, v604, v605, v606, v570);
        { let _ = spiral_trace_hold(&v596); };
        let (mut v610, mut v611, mut v612, mut v613, mut v614, mut v615): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v598);
        let v616: i64 = v610.borrow().l0;
        let v617: i64 = v616.wrapping_add(1i64);
        v610.borrow_mut().l0 = v617;
        let v618: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v619: bool = cfg!(target_arch = "wasm32");
        if v619 {
            let v620: Rc<str> = v613.borrow().l0.clone();
            let v621: bool = &*v620 == "";
            let v628: Rc<str> = if v621 {
                v607.clone()
            } else {
                let v622: bool = &*v607 == "";
                if v622 {
                    let v623: Rc<str> = v613.borrow().l0.clone();
                    v623
                } else {
                    let v624: Rc<str> = v613.borrow().l0.clone();
                    let v625: Rc<str> = Rc::<str>::from(format!("{}{}", v624, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v626: Rc<str> = Rc::<str>::from(format!("{}{}", v625, v607.clone()));
                    v626
                }
            };
            let v630: usize = v628.len();
            let v631: i32 = ((v630) as i32);
            let v632: i32 = v631.wrapping_add(14999i32);
            let v633: i32 = v632.wrapping_div(15000i32);
            let v634: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v635: bool = v607 != v634 ;
            let v637: bool = if v635 {
                let v636: bool = v633 <= 1i32;
                v636
            } else {
                false
            };
            if v637 {
                v613.borrow_mut().l0 = v628;
                ()
            } else {
                v613.borrow_mut().l0 = v634;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v628); };
                ()
            }
        } else {
            println!("{}", v607);
            ()
        };
        let mut v640: Rc<dyn Fn(Rc<str>) -> ()> = v611.borrow().l0.clone();
        v640(v607);
        US4::US4_Some(v610, v611, v612, v613, v614, v615)
    };
    let mut v644: near_workspaces::result::ExecutionFinalResult = v104.clone();
    let v646: Result<std::string::String, near_workspaces::error::Error> = v644.borsh();
    let v647: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v669: bool = if v647 {
        true
    } else {
        let v649: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v649); };
        let v651: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v652, mut v653, mut v654, mut v655, mut v656, mut v657): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v651);
        let v658: US3 = v656.borrow().l0.clone();
        let v663: i32 = match v658 {
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
        let v664: bool = v654.borrow().l0;
        let v665: bool = v664 == false;
        let v667: bool = if v665 {
            false
        } else {
            let v666: bool = 10i32 >= v663;
            v666
        };
        let v668: bool = v667 == false;
        v668
    };
    let v718: US4 = if v669 {
        US4::US4_None
    } else {
        let v672: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v672); };
        let v674: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v675, mut v676, mut v677, mut v678, mut v679, mut v680): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v674);
        let v681: Rc<str> = method6(&v675, &v676, &v677, &v678, &v679, v680.clone());
        let v682: Rc<str> = method8();
        let v683: Rc<str> = method49(&v675, &v676, &v677, &v678, &v679, v680, v681, v682, v646);
        { let _ = spiral_trace_hold(&v672); };
        let (mut v686, mut v687, mut v688, mut v689, mut v690, mut v691): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v674);
        let v692: i64 = v686.borrow().l0;
        let v693: i64 = v692.wrapping_add(1i64);
        v686.borrow_mut().l0 = v693;
        let v694: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v695: bool = cfg!(target_arch = "wasm32");
        if v695 {
            let v696: Rc<str> = v689.borrow().l0.clone();
            let v697: bool = &*v696 == "";
            let v704: Rc<str> = if v697 {
                v683.clone()
            } else {
                let v698: bool = &*v683 == "";
                if v698 {
                    let v699: Rc<str> = v689.borrow().l0.clone();
                    v699
                } else {
                    let v700: Rc<str> = v689.borrow().l0.clone();
                    let v701: Rc<str> = Rc::<str>::from(format!("{}{}", v700, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v702: Rc<str> = Rc::<str>::from(format!("{}{}", v701, v683.clone()));
                    v702
                }
            };
            let v706: usize = v704.len();
            let v707: i32 = ((v706) as i32);
            let v708: i32 = v707.wrapping_add(14999i32);
            let v709: i32 = v708.wrapping_div(15000i32);
            let v710: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v711: bool = v683 != v710 ;
            let v713: bool = if v711 {
                let v712: bool = v709 <= 1i32;
                v712
            } else {
                false
            };
            if v713 {
                v689.borrow_mut().l0 = v704;
                ()
            } else {
                v689.borrow_mut().l0 = v710;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v704); };
                ()
            }
        } else {
            println!("{}", v683);
            ()
        };
        let mut v716: Rc<dyn Fn(Rc<str>) -> ()> = v687.borrow().l0.clone();
        v716(v683);
        US4::US4_Some(v686, v687, v688, v689, v690, v691)
    };
    let v719: Rc<str> = format_real_45(v494);
    let v720: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_outcomes_len = "); } LIT.with(|lit| lit.clone()) }, v719));
    let v721: Rc<str> = Rc::<str>::from(format!("{}{}", v720, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v722: Rc<str> = Rc::<str>::from(format!("{}{}", v721, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) }));
    let v723: Rc<str> = Rc::<str>::from(format!("{}{}", v722, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v724: Rc<str> = format_real_28(v1);
    let v725: Rc<str> = Rc::<str>::from(format!("{}{}", v723, v724));
    let v726: Rc<str> = Rc::<str>::from(format!("{}{}", v725, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let v727: Rc<str> = Rc::<str>::from(format!("{}{}", v726, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("receipt_failures"); } LIT.with(|lit| lit.clone()) }));
    let v728: Rc<str> = Rc::<str>::from(format!("{}{}", v727, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v729: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<Vec<&near_workspaces::result::ExecutionOutcome>>") } } (&&W(&v413)).s() });
    let v730: Rc<str> = Rc::<str>::from(format!("{}{}", v728, v729));
    let v731: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v730));
    let v732: Rc<str> = Rc::<str>::from(format!("{}{}", v731, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v733: bool = v415 > 0i32;
    let v744: Result<US6, anyhow::Error> = if v733 {
        let v734: US6 = US6::US6_Some(v732);
        let v735: Result<US6, anyhow::Error> = Ok::<US6, anyhow::Error>(v734);
        v735
    } else {
        let v736: bool = v494 > 1i32;
        if v736 {
            let v737: US6 = US6::US6_None;
            let v738: Result<US6, anyhow::Error> = Ok::<US6, anyhow::Error>(v737);
            v738
        } else {
            let v740: anyhow::Error = anyhow::anyhow!("{}", v732);
            let v742: Result<US6, anyhow::Error> = Err(v740);
            v742
        }
    };
    let v745: bool = true; (v744) }); //;
    let v747: _ = __future_init;
    let v749: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> = v747;
    v749
}
fn closure14() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let mut v2: std::string::String = format!("{}", v0);
        v2
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method50() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure14()
}
fn ok_c15() -> Rc<dyn Fn(US6) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US6) -> US8> = Rc::new(move |mut v0: US6| -> US8 {
        US8::US8_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method51() -> Rc<dyn Fn(US6) -> US8> {
    ok_c15()
}
fn error_c16() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_Error(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method52() -> Rc<dyn Fn(std::string::String) -> US8> {
    error_c16()
}
fn method53() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[93m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_9(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7
}
fn method54(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: std::string::String) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0;
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v12: Rc<str> = format_real_15(v10);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Error error"); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = format_real_28(v8);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<std::string::String>") } } (&&W(&v9)).s() });
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v23));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v24));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let v27: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v26));
    method12(v27)
}
fn method55() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[91m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_9(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7
}
fn method56(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: u8, mut v9: Rc<str>) -> Rc<str> {
    let mut v10: i64 = v0.borrow().l0;
    let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v12: Rc<str> = format_real_15(v10);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Ok (Some error)"); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v18: Rc<str> = format_real_28(v8);
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v20, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) }));
    let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v21, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
    let v23: Rc<str> = Rc::<str>::from(format!("{}{}", v22, v9));
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v23));
    let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v24, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v25));
    method12(v26)
}
fn method25(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let v7: bool = */ ();
    let mut v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US6, anyhow::Error>>>> = fn_26(v0.clone(), v1);
    let mut v10: Result<US6, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method50();
    let mut v13: Result<US6, std::string::String> = v10.map_err(|x| v11(x));
    let mut v14: Rc<dyn Fn(US6) -> US8> = method51();
    let mut v15: Rc<dyn Fn(std::string::String) -> US8> = method52();
    let v16: US8 = match v13 { Ok(x) => v14(x), Err(e) => v15(e) };
    let v413: US7 = match v16 {
        US8::US8_Error(v121) => {
            let v121: std::string::String = v121;
            let v122: bool = v1 >= 15u8;
            if v122 {
                let mut v123: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v145: bool = if v123 {
                    true
                } else {
                    let v125: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v125); };
                    let v127: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v128, mut v129, mut v130, mut v131, mut v132, mut v133): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v127);
                    let v134: US3 = v132.borrow().l0.clone();
                    let v139: i32 = match v134 {
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
                    let v140: bool = v130.borrow().l0;
                    let v141: bool = v140 == false;
                    let v143: bool = if v141 {
                        false
                    } else {
                        let v142: bool = 40i32 >= v139;
                        v142
                    };
                    let mut v144: bool = v143 == false;
                    v144
                };
                let v194: US4 = if v145 {
                    US4::US4_None
                } else {
                    let v148: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v148); };
                    let v150: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v151, mut v152, mut v153, mut v154, mut v155, mut v156): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v150);
                    let v157: Rc<str> = method6(&v151, &v152, &v153, &v154, &v155, v156.clone());
                    let v158: Rc<str> = method53();
                    let v159: Rc<str> = method54(&v151, &v152, &v153, &v154, &v155, v156, v157, v158, v1, v121);
                    { let _ = spiral_trace_hold(&v148); };
                    let (mut v162, mut v163, mut v164, mut v165, mut v166, mut v167): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v150);
                    let v168: i64 = v162.borrow().l0;
                    let v169: i64 = v168.wrapping_add(1i64);
                    v162.borrow_mut().l0 = v169;
                    let v170: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v171: bool = cfg!(target_arch = "wasm32");
                    if v171 {
                        let v172: Rc<str> = v165.borrow().l0.clone();
                        let mut v173: bool = &*v172 == "";
                        let mut v180: Rc<str> = if v173 {
                            v159.clone()
                        } else {
                            let mut v174: bool = &*v159 == "";
                            if v174 {
                                let mut v175: Rc<str> = v165.borrow().l0.clone();
                                v175
                            } else {
                                let mut v176: Rc<str> = v165.borrow().l0.clone();
                                let v177: Rc<str> = Rc::<str>::from(format!("{}{}", v176, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                                let v178: Rc<str> = Rc::<str>::from(format!("{}{}", v177, v159.clone()));
                                v178
                            }
                        };
                        let mut v182: usize = v180.len();
                        let mut v183: i32 = ((v182) as i32);
                        let v184: i32 = v183.wrapping_add(14999i32);
                        let v185: i32 = v184.wrapping_div(15000i32);
                        let v186: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v187: bool = v159 != v186 ;
                        let v189: bool = if v187 {
                            let v188: bool = v185 <= 1i32;
                            v188
                        } else {
                            false
                        };
                        if v189 {
                            v165.borrow_mut().l0 = v180;
                            ()
                        } else {
                            v165.borrow_mut().l0 = v186;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v180); };
                            ()
                        }
                    } else {
                        println!("{}", v159);
                        ()
                    };
                    let mut v192: Rc<dyn Fn(Rc<str>) -> ()> = v163.borrow().l0.clone();
                    v192(v159);
                    US4::US4_Some(v162, v163, v164, v165, v166, v167)
                };
                let v195: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v217: bool = if v195 {
                    true
                } else {
                    let v197: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v197); };
                    let v199: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v200, mut v201, mut v202, mut v203, mut v204, mut v205): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v199);
                    let v206: US3 = v204.borrow().l0.clone();
                    let v211: i32 = match v206 {
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
                    let v212: bool = v202.borrow().l0;
                    let mut v213: bool = v212 == false;
                    let v215: bool = if v213 {
                        false
                    } else {
                        let v214: bool = 40i32 >= v211;
                        v214
                    };
                    let mut v216: bool = v215 == false;
                    v216
                };
                let v256: US4 = if v217 {
                    US4::US4_None
                } else {
                    let v220: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v220); };
                    let v222: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v223, mut v224, mut v225, mut v226, mut v227, mut v228): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v222);
                    let v229: i64 = v223.borrow().l0;
                    let v230: i64 = v229.wrapping_add(1i64);
                    v223.borrow_mut().l0 = v230;
                    let v231: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v232: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v233: bool = cfg!(target_arch = "wasm32");
                    if v233 {
                        let v234: Rc<str> = v226.borrow().l0.clone();
                        let v235: bool = &*v234 == "";
                        let v242: Rc<str> = if v235 {
                            v231.clone()
                        } else {
                            let v236: bool = &*v231 == "";
                            if v236 {
                                let v237: Rc<str> = v226.borrow().l0.clone();
                                v237
                            } else {
                                let v238: Rc<str> = v226.borrow().l0.clone();
                                let v239: Rc<str> = Rc::<str>::from(format!("{}{}", v238, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                                let v240: Rc<str> = Rc::<str>::from(format!("{}{}", v239, v231.clone()));
                                v240
                            }
                        };
                        let mut v244: usize = v242.len();
                        let v245: i32 = ((v244) as i32);
                        let v246: i32 = v245.wrapping_add(14999i32);
                        let v247: i32 = v246.wrapping_div(15000i32);
                        let mut v248: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v249: bool = v231 != v248 ;
                        let v251: bool = if v249 {
                            let v250: bool = v247 <= 1i32;
                            v250
                        } else {
                            false
                        };
                        if v251 {
                            v226.borrow_mut().l0 = v242;
                            ()
                        } else {
                            v226.borrow_mut().l0 = v248;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v242); };
                            ()
                        }
                    } else {
                        println!("{}", v231);
                        ()
                    };
                    let mut v254: Rc<dyn Fn(Rc<str>) -> ()> = v224.borrow().l0.clone();
                    v254(v231);
                    US4::US4_Some(v223, v224, v225, v226, v227, v228)
                };
                let v258: bool = true; let __future_init = Box::pin(/*;
                let v260: bool = */ async move { /*;
                let v262: bool = */ ();
                let v263: US6 = US6::US6_None;
                let v264: bool = true; ((v1, v263)) }); //;
                let v266: _ = __future_init;
                let v268: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v266;
                let (mut v270, mut v271): (u8, US6) = v268.await;
                US7::US7_Ok(v270, v271)
            } else {
                let v273: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v295: bool = if v273 {
                    true
                } else {
                    let v275: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v275); };
                    let v277: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v278, mut v279, mut v280, mut v281, mut v282, mut v283): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v277);
                    let v284: US3 = v282.borrow().l0.clone();
                    let v289: i32 = match v284 {
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
                    let v290: bool = v280.borrow().l0;
                    let v291: bool = v290 == false;
                    let mut v293: bool = if v291 {
                        false
                    } else {
                        let v292: bool = 40i32 >= v289;
                        v292
                    };
                    let v294: bool = v293 == false;
                    v294
                };
                let v344: US4 = if v295 {
                    US4::US4_None
                } else {
                    let v298: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v298); };
                    let v300: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v301, mut v302, mut v303, mut v304, mut v305, mut v306): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v300);
                    let v307: Rc<str> = method6(&v301, &v302, &v303, &v304, &v305, v306.clone());
                    let v308: Rc<str> = method53();
                    let v309: Rc<str> = method54(&v301, &v302, &v303, &v304, &v305, v306, v307, v308, v1, v121);
                    { let _ = spiral_trace_hold(&v298); };
                    let (mut v312, mut v313, mut v314, mut v315, mut v316, mut v317): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v300);
                    let v318: i64 = v312.borrow().l0;
                    let v319: i64 = v318.wrapping_add(1i64);
                    v312.borrow_mut().l0 = v319;
                    let v320: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v321: bool = cfg!(target_arch = "wasm32");
                    if v321 {
                        let v322: Rc<str> = v315.borrow().l0.clone();
                        let mut v323: bool = &*v322 == "";
                        let v330: Rc<str> = if v323 {
                            v309.clone()
                        } else {
                            let v324: bool = &*v309 == "";
                            if v324 {
                                let v325: Rc<str> = v315.borrow().l0.clone();
                                v325
                            } else {
                                let v326: Rc<str> = v315.borrow().l0.clone();
                                let mut v327: Rc<str> = Rc::<str>::from(format!("{}{}", v326, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                                let v328: Rc<str> = Rc::<str>::from(format!("{}{}", v327, v309.clone()));
                                v328
                            }
                        };
                        let v332: usize = v330.len();
                        let mut v333: i32 = ((v332) as i32);
                        let v334: i32 = v333.wrapping_add(14999i32);
                        let mut v335: i32 = v334.wrapping_div(15000i32);
                        let v336: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v337: bool = v309 != v336 ;
                        let v339: bool = if v337 {
                            let v338: bool = v335 <= 1i32;
                            v338
                        } else {
                            false
                        };
                        if v339 {
                            v315.borrow_mut().l0 = v330;
                            ()
                        } else {
                            v315.borrow_mut().l0 = v336;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v330); };
                            ()
                        }
                    } else {
                        println!("{}", v309);
                        ()
                    };
                    let mut v342: Rc<dyn Fn(Rc<str>) -> ()> = v313.borrow().l0.clone();
                    v342(v309);
                    US4::US4_Some(v312, v313, v314, v315, v316, v317)
                };
                let v345: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Critical"));
                let v367: bool = if v345 {
                    true
                } else {
                    let v347: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v347); };
                    let v349: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v350, mut v351, mut v352, mut v353, mut v354, mut v355): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v349);
                    let v356: US3 = v354.borrow().l0.clone();
                    let v361: i32 = match v356 {
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
                    let v362: bool = v352.borrow().l0;
                    let v363: bool = v362 == false;
                    let v365: bool = if v363 {
                        false
                    } else {
                        let v364: bool = 40i32 >= v361;
                        v364
                    };
                    let v366: bool = v365 == false;
                    v366
                };
                let v406: US4 = if v367 {
                    US4::US4_None
                } else {
                    let v370: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v370); };
                    let v372: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v373, mut v374, mut v375, mut v376, mut v377, mut v378): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v372);
                    let v379: i64 = v373.borrow().l0;
                    let v380: i64 = v379.wrapping_add(1i64);
                    v373.borrow_mut().l0 = v380;
                    let mut v381: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v382: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                    let v383: bool = cfg!(target_arch = "wasm32");
                    if v383 {
                        let v384: Rc<str> = v376.borrow().l0.clone();
                        let v385: bool = &*v384 == "";
                        let v392: Rc<str> = if v385 {
                            v381.clone()
                        } else {
                            let v386: bool = &*v381 == "";
                            if v386 {
                                let v387: Rc<str> = v376.borrow().l0.clone();
                                v387
                            } else {
                                let v388: Rc<str> = v376.borrow().l0.clone();
                                let v389: Rc<str> = Rc::<str>::from(format!("{}{}", v388, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                                let v390: Rc<str> = Rc::<str>::from(format!("{}{}", v389, v381.clone()));
                                v390
                            }
                        };
                        let v394: usize = v392.len();
                        let v395: i32 = ((v394) as i32);
                        let v396: i32 = v395.wrapping_add(14999i32);
                        let v397: i32 = v396.wrapping_div(15000i32);
                        let v398: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let v399: bool = v381 != v398 ;
                        let v401: bool = if v399 {
                            let v400: bool = v397 <= 1i32;
                            v400
                        } else {
                            false
                        };
                        if v401 {
                            v376.borrow_mut().l0 = v392;
                            ()
                        } else {
                            v376.borrow_mut().l0 = v398;
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v392); };
                            ()
                        }
                    } else {
                        println!("{}", v381);
                        ()
                    };
                    let mut v404: Rc<dyn Fn(Rc<str>) -> ()> = v374.borrow().l0.clone();
                    v404(v381);
                    US4::US4_Some(v373, v374, v375, v376, v377, v378)
                };
                let v407: u8 = v1.wrapping_add(1u8);
                let mut v408: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = method25(v0, v407);
                let v410: US7 = v408.await;
                v410
            }
        }
        US8::US8_Ok(v17) => {
            let v17: US6 = v17;
            match v17 {
                US6::US6_None => {
                    let mut v19: bool = true; let __future_init = Box::pin(/*;
                    let mut v21: bool = */ async move { /*;
                    let v23: bool = */ ();
                    let mut v24: US6 = US6::US6_None;
                    let v25: bool = true; ((v1, v24)) }); //;
                    let v27: _ = __future_init;
                    let mut v29: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v27;
                    let (mut v31, mut v32): (u8, US6) = v29.await;
                    US7::US7_Ok(v31, v32)
                }
                US6::US6_Some(v34) => {
                    let v34: Rc<str> = v34;
                    let v36: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v36); };
                    let mut v38: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v39, mut v40, mut v41, mut v42, mut v43, mut v44): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v38);
                    let v45: US3 = v43.borrow().l0.clone();
                    let v50: i32 = match v45 {
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
                    let v55: bool = v54 == false;
                    let v102: US4 = if v55 {
                        US4::US4_None
                    } else {
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v59, mut v60, mut v61, mut v62, mut v63, mut v64): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v38);
                        let v65: Rc<str> = method6(&v59, &v60, &v61, &v62, &v63, v64.clone());
                        let v66: Rc<str> = method55();
                        let mut v67: Rc<str> = method56(&v59, &v60, &v61, &v62, &v63, v64, v65, v66, v1, v34.clone());
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v70, mut v71, mut v72, mut v73, mut v74, mut v75): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v38);
                        let v76: i64 = v70.borrow().l0;
                        let v77: i64 = v76.wrapping_add(1i64);
                        v70.borrow_mut().l0 = v77;
                        let v78: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
                        let v79: bool = cfg!(target_arch = "wasm32");
                        if v79 {
                            let v80: Rc<str> = v73.borrow().l0.clone();
                            let v81: bool = &*v80 == "";
                            let v88: Rc<str> = if v81 {
                                v67.clone()
                            } else {
                                let v82: bool = &*v67 == "";
                                if v82 {
                                    let v83: Rc<str> = v73.borrow().l0.clone();
                                    v83
                                } else {
                                    let v84: Rc<str> = v73.borrow().l0.clone();
                                    let v85: Rc<str> = Rc::<str>::from(format!("{}{}", v84, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                                    let v86: Rc<str> = Rc::<str>::from(format!("{}{}", v85, v67.clone()));
                                    v86
                                }
                            };
                            let v90: usize = v88.len();
                            let v91: i32 = ((v90) as i32);
                            let v92: i32 = v91.wrapping_add(14999i32);
                            let v93: i32 = v92.wrapping_div(15000i32);
                            let mut v94: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let v95: bool = v67 != v94 ;
                            let v97: bool = if v95 {
                                let v96: bool = v93 <= 1i32;
                                v96
                            } else {
                                false
                            };
                            if v97 {
                                v73.borrow_mut().l0 = v88;
                                ()
                            } else {
                                v73.borrow_mut().l0 = v94;
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v88); };
                                ()
                            }
                        } else {
                            println!("{}", v67);
                            ()
                        };
                        let mut v100: Rc<dyn Fn(Rc<str>) -> ()> = v71.borrow().l0.clone();
                        v100(v67);
                        US4::US4_Some(v70, v71, v72, v73, v74, v75)
                    };
                    let mut v104: bool = true; let __future_init = Box::pin(/*;
                    let v106: bool = */ async move { /*;
                    let v108: bool = */ ();
                    let v109: US6 = US6::US6_Some(v34);
                    let v110: bool = true; ((v1, v109)) }); //;
                    let v112: _ = __future_init;
                    let v114: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US6)>>> = v112;
                    let (mut v116, mut v117): (u8, US6) = v114.await;
                    US7::US7_Error(v116, v117)
                }
            }
        }
    };
    let v414: bool = true; (v413) }); //;
    let v416: _ = __future_init;
    let v418: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = v416;
    v418
}
fn method59(mut v0: US6) -> Rc<str> {
    match v0 {
        US6::US6_None => {
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v4
        }
        US6::US6_Some(v1) => {
            let mut v1: Rc<str> = v1;
            let mut v2: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some("); } LIT.with(|lit| lit.clone()) }, v1));
            let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) }));
            v3
        }
    }
}
fn method58(mut v0: US7) -> Rc<str> {
    match v0 {
        US7::US7_Error(v14, v15) => {
            let mut v14: u8 = v14;
            let mut v15: US6 = v15;
            let v16: Rc<str> = format_real_28(v14);
            let v17: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v16));
            let v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
            let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) }));
            let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
            let mut v21: Rc<str> = method59(v15);
            let v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
            let v23: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v22));
            let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v23, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
            let v25: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error("); } LIT.with(|lit| lit.clone()) }, v24));
            let mut v26: Rc<str> = Rc::<str>::from(format!("{}{}", v25, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) }));
            v26
        }
        US7::US7_Ok(v1, v2) => {
            let mut v1: u8 = v1;
            let mut v2: US6 = v2;
            let mut v3: Rc<str> = format_real_28(v1);
            let mut v4: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) }, v3));
            let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v4, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
            let v6: Rc<str> = Rc::<str>::from(format!("{}{}", v5, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) }));
            let v7: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
            let mut v8: Rc<str> = method59(v2);
            let mut v9: Rc<str> = Rc::<str>::from(format!("{}{}", v7, v8));
            let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v9));
            let mut v11: Rc<str> = Rc::<str>::from(format!("{}{}", v10, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
            let v12: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ok("); } LIT.with(|lit| lit.clone()) }, v11));
            let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) }));
            v13
        }
    }
}
fn method57(mut v0: &Rc<RefCell<Mut1>>, mut v1: &Rc<RefCell<Mut2>>, mut v2: &Rc<RefCell<Mut3>>, mut v3: &Rc<RefCell<Mut4>>, mut v4: &Rc<RefCell<Mut5>>, mut v5: Option<i64>, mut v6: Rc<str>, mut v7: Rc<str>, mut v8: US7) -> Rc<str> {
    let mut v9: i64 = v0.borrow().l0;
    let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v6, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v11: Rc<str> = format_real_15(v9);
    let v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v7));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) }));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) }));
    let v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) }));
    let v17: Rc<str> = method58(v8);
    let v18: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries = "); } LIT.with(|lit| lit.clone()) }, v17));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v18));
    let v20: Rc<str> = Rc::<str>::from(format!("{}{}", v19, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v20));
    method12(v21)
}
fn run_22(mut v0: clap::ArgMatches) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> {
    let mut v2: bool = true; let __future_init = Box::pin(/*;
    let mut v4: bool = */ async move { /*;
    let v6: bool = */ ();
    let v7: Rc<str> = method23();
    let mut v9: &str = &*v7;
    let mut v11: Option<std::string::String> = clap::ArgMatches::get_one(&v0, v9).cloned();
    let v12: Option<std::string::String> = method2(v11);
    let mut v13: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v14: Option<US0> = v12.map(|x| v13(x));
    let v16: US0 = US0::US0_None;
    let v17: US0 = v16.clone();
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
        let v27: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v27); };
        let mut v29: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v30, mut v31, mut v32, mut v33, mut v34, mut v35): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v29);
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
            let mut v44: bool = 10i32 >= v41;
            v44
        };
        let v46: bool = v45 == false;
        v46
    };
    let v96: US4 = if v47 {
        US4::US4_None
    } else {
        let v50: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v50); };
        let v52: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v53, mut v54, mut v55, mut v56, mut v57, mut v58): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v52);
        let mut v59: Rc<str> = method6(&v53, &v54, &v55, &v56, &v57, v58.clone());
        let mut v60: Rc<str> = method8();
        let v61: Rc<str> = method24(&v53, &v54, &v55, &v56, &v57, v58, v59, v60, v24.clone());
        { let _ = spiral_trace_hold(&v50); };
        let (mut v64, mut v65, mut v66, mut v67, mut v68, mut v69): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v52);
        let mut v70: i64 = v64.borrow().l0;
        let v71: i64 = v70.wrapping_add(1i64);
        v64.borrow_mut().l0 = v71;
        let mut v72: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v73: bool = cfg!(target_arch = "wasm32");
        if v73 {
            let v74: Rc<str> = v67.borrow().l0.clone();
            let mut v75: bool = &*v74 == "";
            let v82: Rc<str> = if v75 {
                v61.clone()
            } else {
                let v76: bool = &*v61 == "";
                if v76 {
                    let v77: Rc<str> = v67.borrow().l0.clone();
                    v77
                } else {
                    let v78: Rc<str> = v67.borrow().l0.clone();
                    let v79: Rc<str> = Rc::<str>::from(format!("{}{}", v78, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v80: Rc<str> = Rc::<str>::from(format!("{}{}", v79, v61.clone()));
                    v80
                }
            };
            let v84: usize = v82.len();
            let v85: i32 = ((v84) as i32);
            let v86: i32 = v85.wrapping_add(14999i32);
            let mut v87: i32 = v86.wrapping_div(15000i32);
            let v88: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v89: bool = v61 != v88 ;
            let v91: bool = if v89 {
                let v90: bool = v87 <= 1i32;
                v90
            } else {
                false
            };
            if v91 {
                v67.borrow_mut().l0 = v82;
                ()
            } else {
                v67.borrow_mut().l0 = v88;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v82); };
                ()
            }
        } else {
            println!("{}", v61);
            ()
        };
        let mut v94: Rc<dyn Fn(Rc<str>) -> ()> = v65.borrow().l0.clone();
        v94(v61);
        US4::US4_Some(v64, v65, v66, v67, v68, v69)
    };
    let mut v98: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v24);
    let mut v100: Vec<u8> = v98?;
    let v101: u8 = 1u8;
    let v102: std::pin::Pin<Box<dyn std::future::Future<Output = US7>>> = method25(v100, v101);
    let mut v104: US7 = v102.await;
    let v105: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v127: bool = if v105 {
        true
    } else {
        let v107: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v107); };
        let v109: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v110, mut v111, mut v112, mut v113, mut v114, mut v115): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v109);
        let v116: US3 = v114.borrow().l0.clone();
        let v121: i32 = match v116 {
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
        let v122: bool = v112.borrow().l0;
        let mut v123: bool = v122 == false;
        let v125: bool = if v123 {
            false
        } else {
            let v124: bool = 10i32 >= v121;
            v124
        };
        let mut v126: bool = v125 == false;
        v126
    };
    let mut v176: US4 = if v127 {
        US4::US4_None
    } else {
        let v130: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v130); };
        let v132: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v133, mut v134, mut v135, mut v136, mut v137, mut v138): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v132);
        let v139: Rc<str> = method6(&v133, &v134, &v135, &v136, &v137, v138.clone());
        let v140: Rc<str> = method8();
        let v141: Rc<str> = method57(&v133, &v134, &v135, &v136, &v137, v138, v139, v140, v104.clone());
        { let _ = spiral_trace_hold(&v130); };
        let (mut v144, mut v145, mut v146, mut v147, mut v148, mut v149): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v132);
        let v150: i64 = v144.borrow().l0;
        let v151: i64 = v150.wrapping_add(1i64);
        v144.borrow_mut().l0 = v151;
        let v152: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let mut v153: bool = cfg!(target_arch = "wasm32");
        if v153 {
            let v154: Rc<str> = v147.borrow().l0.clone();
            let v155: bool = &*v154 == "";
            let mut v162: Rc<str> = if v155 {
                v141.clone()
            } else {
                let v156: bool = &*v141 == "";
                if v156 {
                    let v157: Rc<str> = v147.borrow().l0.clone();
                    v157
                } else {
                    let v158: Rc<str> = v147.borrow().l0.clone();
                    let v159: Rc<str> = Rc::<str>::from(format!("{}{}", v158, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v160: Rc<str> = Rc::<str>::from(format!("{}{}", v159, v141.clone()));
                    v160
                }
            };
            let v164: usize = v162.len();
            let mut v165: i32 = ((v164) as i32);
            let mut v166: i32 = v165.wrapping_add(14999i32);
            let v167: i32 = v166.wrapping_div(15000i32);
            let v168: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v169: bool = v141 != v168 ;
            let v171: bool = if v169 {
                let v170: bool = v167 <= 1i32;
                v170
            } else {
                false
            };
            if v171 {
                v147.borrow_mut().l0 = v162;
                ()
            } else {
                v147.borrow_mut().l0 = v168;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v162); };
                ()
            }
        } else {
            println!("{}", v141);
            ()
        };
        let mut v174: Rc<dyn Fn(Rc<str>) -> ()> = v145.borrow().l0.clone();
        v174(v141);
        US4::US4_Some(v144, v145, v146, v147, v148, v149)
    };
    let v196: Result<u8, anyhow::Error> = match &v104 {
        US7::US7_Error(v180, v181) => {
            let mut v180: u8 = *v180;
            let mut v181: US6 = v181.clone();
            let mut v182: Rc<str> = method58(v104);
            let mut v183: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retries = "); } LIT.with(|lit| lit.clone()) }, v182));
            let v184: Rc<str> = Rc::<str>::from(format!("{}{}", v183, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) }));
            let v185: Rc<str> = Rc::<str>::from(format!("{}{}", v184, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) }));
            let v186: Rc<str> = Rc::<str>::from(format!("{}{}", v185, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) }));
            let v187: Rc<str> = method59(v181);
            let v188: Rc<str> = Rc::<str>::from(format!("{}{}", v186, v187));
            let v189: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) }, v188));
            let v190: Rc<str> = Rc::<str>::from(format!("{}{}", v189, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) }));
            let mut v192: anyhow::Error = anyhow::anyhow!("{}", v190);
            let v194: Result<u8, anyhow::Error> = Err(v192);
            v194
        }
        US7::US7_Ok(v177, v178) => {
            let v177: u8 = *v177;
            let v178: US6 = v178.clone();
            let v179: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v177);
            v179
        }
    };
    let v197: bool = true; (v196) }); //;
    let v199: _ = __future_init;
    let v201: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v199;
    v201
}
fn ok_c17() -> Rc<dyn Fn(u8) -> US9> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US9> = Rc::new(move |mut v0: u8| -> US9 {
        US9::US9_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method60() -> Rc<dyn Fn(u8) -> US9> {
    ok_c17()
}
fn error_c18() -> Rc<dyn Fn(std::string::String) -> US9> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US9> = Rc::new(move |mut v0: std::string::String| -> US9 {
        US9::US9_Error(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method61() -> Rc<dyn Fn(std::string::String) -> US9> {
    error_c18()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(std::env::args().skip(1).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
    let mut v1: clap::Command = get_command_0();
    let mut v3: clap::ArgMatches = clap::Command::get_matches(v1);
    let mut v4: Rc<str> = method1();
    let v6: &str = &*v4;
    let mut v8: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v6).cloned();
    let mut v9: Option<std::string::String> = method2(v8);
    let mut v10: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v11: Option<US0> = v9.map(|x| v10(x));
    let mut v13: US0 = US0::US0_None;
    let mut v14: US0 = v13.clone();
    let mut v15: US0 = v11.unwrap_or(v14);
    let mut v62: US1 = match v15 {
        US0::US0_None => {
            US1::US1_None
        }
        US0::US0_Some(v16) => {
            let v16: std::string::String = v16;
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
            v29.borrow_mut().push((v27, v30));
            let v31: US3 = US3::US3_Debug;
            v29.borrow_mut().push((v25, v31));
            let v32: US3 = US3::US3_Info;
            v29.borrow_mut().push((v23, v32));
            let v33: US3 = US3::US3_Warning;
            v29.borrow_mut().push((v21, v33));
            let v34: US3 = US3::US3_Critical;
            v29.borrow_mut().push((v19, v34));
            let v35: US3 = US3::US3_Verbose;
            v29.borrow_mut().push((v28, v35));
            let v36: US3 = US3::US3_Debug;
            v29.borrow_mut().push((v26, v36));
            let v37: US3 = US3::US3_Info;
            v29.borrow_mut().push((v24, v37));
            let mut v38: US3 = US3::US3_Warning;
            v29.borrow_mut().push((v22, v38));
            let v39: US3 = US3::US3_Critical;
            v29.borrow_mut().push((v20, v39));
            let mut v40: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v29.borrow().clone());
            let v41: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v40).as_ref().clone()));
            let v42: i32 = (v41.clone().borrow().len() as i32);
            let mut v43: US2 = US2::US2_None;
            let mut v44: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: v42, l1: v43 }));
            while method3(&v44) {
                let v46: i32 = v44.borrow().l0;
                let v47: i32 = v46.wrapping_sub(1i32);
                let v48: US2 = v44.borrow().l1.clone();
                let (mut v49, mut v50): (Rc<str>, US3) = v41.borrow()[v47 as usize].clone();
                let mut v57: US2 = match &v48 {
                    US2::US2_None => {
                        let v52: bool = v49 == v18 ;
                        if v52 {
                            US2::US2_Some(v50)
                        } else {
                            US2::US2_None
                        }
                    }
                    US2::US2_Some(v51) => {
                        let v51: US3 = v51.clone();
                        v48
                    }
                };
                v44.borrow_mut().l0 = v47;
                v44.borrow_mut().l1 = v57;
                ()
            };
            let v58: US2 = v44.borrow().l1.clone();
            US1::US1_Some(v58)
        }
    };
    let v69: US2 = match v62 {
        US1::US1_Some(v63) => {
            let v63: US2 = v63;
            match v63 {
                US2::US2_Some(v64) => {
                    let mut v64: US3 = v64;
                    US2::US2_Some(v64)
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
    let mut v73: US3 = match v69 {
        US2::US2_None => {
            US3::US3_Verbose
        }
        US2::US2_Some(v70) => {
            let mut v70: US3 = v70;
            v70
        }
    };
    let mut v75: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c2(v73.clone());
    { let _ = spiral_trace_hold(&v75); };
    let v77: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c4(v73);
    let (mut v78, mut v79, mut v80, mut v81, mut v82, mut v83): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v77);
    let v84: bool = matches!(option_env!("SPIRAL_TRACE_FLOOR"), Some("Debug" | "Info" | "Warning" | "Critical"));
    let v106: bool = if v84 {
        true
    } else {
        let v86: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v86); };
        let v88: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v89, mut v90, mut v91, mut v92, mut v93, mut v94): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v88);
        let v95: US3 = v93.borrow().l0.clone();
        let mut v100: i32 = match v95 {
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
        let v101: bool = v91.borrow().l0;
        let v102: bool = v101 == false;
        let mut v104: bool = if v102 {
            false
        } else {
            let v103: bool = 10i32 >= v100;
            v103
        };
        let v105: bool = v104 == false;
        v105
    };
    let v155: US4 = if v106 {
        US4::US4_None
    } else {
        let v109: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v109); };
        let v111: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v112, mut v113, mut v114, mut v115, mut v116, mut v117): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v111);
        let v118: Rc<str> = method6(&v112, &v113, &v114, &v115, &v116, v117.clone());
        let v119: Rc<str> = method8();
        let v120: Rc<str> = method11(&v112, &v113, &v114, &v115, &v116, v117, v118, v119, &v0);
        { let _ = spiral_trace_hold(&v109); };
        let (mut v123, mut v124, mut v125, mut v126, mut v127, mut v128): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = spiral_trace_hold(&v111);
        let v129: i64 = v123.borrow().l0;
        let v130: i64 = v129.wrapping_add(1i64);
        v123.borrow_mut().l0 = v130;
        let v131: Rc<dyn Fn(Rc<str>) -> ()> = closure8();
        let v132: bool = cfg!(target_arch = "wasm32");
        if v132 {
            let v133: Rc<str> = v126.borrow().l0.clone();
            let v134: bool = &*v133 == "";
            let v141: Rc<str> = if v134 {
                v120.clone()
            } else {
                let v135: bool = &*v120 == "";
                if v135 {
                    let v136: Rc<str> = v126.borrow().l0.clone();
                    v136
                } else {
                    let v137: Rc<str> = v126.borrow().l0.clone();
                    let v138: Rc<str> = Rc::<str>::from(format!("{}{}", v137, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) }));
                    let v139: Rc<str> = Rc::<str>::from(format!("{}{}", v138, v120.clone()));
                    v139
                }
            };
            let v143: usize = v141.len();
            let mut v144: i32 = ((v143) as i32);
            let v145: i32 = v144.wrapping_add(14999i32);
            let v146: i32 = v145.wrapping_div(15000i32);
            let mut v147: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let v148: bool = v120 != v147 ;
            let v150: bool = if v148 {
                let v149: bool = v146 <= 1i32;
                v149
            } else {
                false
            };
            if v150 {
                v126.borrow_mut().l0 = v141;
                ()
            } else {
                v126.borrow_mut().l0 = v147;
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v141); };
                ()
            }
        } else {
            println!("{}", v120);
            ()
        };
        let mut v153: Rc<dyn Fn(Rc<str>) -> ()> = v124.borrow().l0.clone();
        v153(v120);
        US4::US4_Some(v123, v124, v125, v126, v127, v128)
    };
    let v156: Rc<str> = method18();
    let v158: &str = &*v156;
    let v160: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v158).cloned();
    let v161: Option<std::string::String> = method2(v160);
    let mut v162: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure9();
    let v163: Option<Rc<str>> = v161.map(|x| v162(x));
    let v164: Option<Rc<str>> = method21(v163);
    let mut v165: Rc<dyn Fn((Rc<str>)) -> US6> = closure10();
    let mut v166: Option<US6> = v164.map(|x| v165(x));
    let v168: US6 = US6::US6_None;
    let v169: US6 = v168.clone();
    let v170: US6 = v166.unwrap_or(v169);
    let v171: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = run_22(v3);
    let mut v173: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v175: Result<u8, anyhow::Error> = v173.handle().block_on(v171);
    let mut v176: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method50();
    let v178: Result<u8, std::string::String> = v175.map_err(|x| v176(x));
    let mut v180: Result<u8, std::string::String> = v178.clone();
    let mut v181: Rc<dyn Fn(u8) -> US9> = method60();
    let mut v182: Rc<dyn Fn(std::string::String) -> US9> = method61();
    let mut v183: US9 = match v180 { Ok(x) => v181(x), Err(e) => v182(e) };
    match v183 {
        US9::US9_Error(v190) => {
            let v190: std::string::String = v190;
            match v170 {
                US6::US6_Some(v191) => {
                    let v191: Rc<str> = v191;
                    let mut v192: bool = "" == &*v191;
                    if v192 {
                        ()
                    } else {
                        let v194: Rc<str> = Rc::<str>::from(String::as_str(&v190));
                        let v195: bool = v194.contains(&*v191);
                        if v195 {
                            ()
                        } else {
                            let v196: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / exception: '{}' / error: {}", v191, v190));
                            let v198: Result<(), Rc<str>> = Err(v196);
                            v198.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let v201: u8 = v178.unwrap();
                    ()
                }
            }
        }
        US9::US9_Ok(v184) => {
            let v184: u8 = v184;
            match v170 {
                US6::US6_Some(v185) => {
                    let v185: Rc<str> = v185;
                    let v186: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / retries: {} / exception: '{}'", v184, v185));
                    let v188: Result<(), Rc<str>> = Err(v186);
                    v188.unwrap();
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
