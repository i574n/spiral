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
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_Some(..) => 0,
            US0::US0_None => 1,
        }
    }
}
#[derive(Clone)]
enum US3 {
    US3_Verbose,
    US3_Debug,
    US3_Info,
    US3_Warning,
    US3_Critical,
}
impl US3 {
    fn tag(&self) -> i32 {
        match self {
            US3::US3_Verbose => 0,
            US3::US3_Debug => 1,
            US3::US3_Info => 2,
            US3::US3_Warning => 3,
            US3::US3_Critical => 4,
        }
    }
}
impl Default for US3 {
    fn default() -> Self {
        US3::US3_Verbose
    }
}
#[derive(Clone)]
enum US2 {
    US2_Some(US3),
    US2_None,
}
impl US2 {
    fn tag(&self) -> i32 {
        match self {
            US2::US2_Some(..) => 0,
            US2::US2_None => 1,
        }
    }
}
impl Default for US2 {
    fn default() -> Self {
        US2::US2_Some(<US3>::default())
    }
}
#[derive(Clone)]
enum US1 {
    US1_Some(US2),
    US1_None,
}
impl US1 {
    fn tag(&self) -> i32 {
        match self {
            US1::US1_Some(..) => 0,
            US1::US1_None => 1,
        }
    }
}
impl Default for US1 {
    fn default() -> Self {
        US1::US1_Some(<US2>::default())
    }
}
struct Mut0 { l0: i32, l1: US2 }
impl Default for Mut0 {
    fn default() -> Self {
        Mut0 { l0: <i32>::default(), l1: <US2>::default() }
    }
}
struct Mut1 { l0: i64 }
impl Default for Mut1 {
    fn default() -> Self {
        Mut1 { l0: <i64>::default() }
    }
}
struct Mut2 { l0: Rc<dyn Fn(Rc<str>) -> ()> }
impl Default for Mut2 {
    fn default() -> Self {
        Mut2 { l0: { let f: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(|mut v0: Rc<str>| -> () { () }); f } }
    }
}
struct Mut3 { l0: bool }
impl Default for Mut3 {
    fn default() -> Self {
        Mut3 { l0: <bool>::default() }
    }
}
struct Mut4 { l0: Rc<str> }
impl Default for Mut4 {
    fn default() -> Self {
        Mut4 { l0: { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } }
    }
}
struct Mut5 { l0: US3 }
impl Default for Mut5 {
    fn default() -> Self {
        Mut5 { l0: <US3>::default() }
    }
}
#[derive(Clone)]
enum US4 {
    US4_Some(Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>),
    US4_None,
}
impl US4 {
    fn tag(&self) -> i32 {
        match self {
            US4::US4_Some(..) => 0,
            US4::US4_None => 1,
        }
    }
}
#[derive(Clone)]
enum US5 {
    US5_Some(Rc<str>),
    US5_None,
}
impl US5 {
    fn tag(&self) -> i32 {
        match self {
            US5::US5_Some(..) => 0,
            US5::US5_None => 1,
        }
    }
}
impl Default for US5 {
    fn default() -> Self {
        US5::US5_Some({ thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) })
    }
}
#[derive(Clone)]
enum US6 {
    US6_Ok(u8, US5),
    US6_Error(u8, US5),
}
impl US6 {
    fn tag(&self) -> i32 {
        match self {
            US6::US6_Ok(..) => 0,
            US6::US6_Error(..) => 1,
        }
    }
}
impl Default for US6 {
    fn default() -> Self {
        US6::US6_Ok(<u8>::default(), <US5>::default())
    }
}
#[derive(Clone)]
enum US7 {
    US7_Ok(US5),
    US7_Error(std::string::String),
}
impl US7 {
    fn tag(&self) -> i32 {
        match self {
            US7::US7_Ok(..) => 0,
            US7::US7_Error(..) => 1,
        }
    }
}
impl Default for US7 {
    fn default() -> Self {
        US7::US7_Ok(<US5>::default())
    }
}
#[derive(Clone)]
enum US8 {
    US8_Ok(u8),
    US8_Error(std::string::String),
}
impl US8 {
    fn tag(&self) -> i32 {
        match self {
            US8::US8_Ok(..) => 0,
            US8::US8_Error(..) => 1,
        }
    }
}
impl Default for US8 {
    fn default() -> Self {
        US8::US8_Ok(<u8>::default())
    }
}
fn closure0() -> Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = Rc::new(move |mut v0: (Rc<str>)| -> clap::builder::PossibleValue {
        let mut v1: Rc<str> = (v0);
        let mut v3: &str = &*v1;
        let mut v5: std::string::String = String::from(v3);
        let mut v7: Box<std::string::String> = Box::new(v5);
        let mut v9: &'static mut std::string::String = Box::leak(v7);
        let mut v11: clap::builder::PossibleValue = clap::builder::PossibleValue::new(&**v9);
        v11.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn get_command_0() -> clap::Command {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("command"); } LIT.with(|lit| lit.clone()) };
    let mut v1: &'static str = Box::leak(String::from(&*v0).into_boxed_str());
    let mut v3: clap::Command = clap::Command::new(v1);
    let mut v5: clap::Command = clap::Command::args_override_self(v3, true);
    let mut v6: usize = ((0i32) as usize);
    let mut v7: usize = ((1i32) as usize);
    let mut v8: usize = ((0i32) as usize);
    let mut v9: bool = v7 == v8 ;
    let mut v15: clap::builder::ValueRange = if v9 {
        let mut v11: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..);
        v11.clone()
    } else {
        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
        let mut v14: clap::builder::ValueRange = clap::builder::ValueRange::new(v6..=v7);
        v14.clone()
    };
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("exception"); } LIT.with(|lit| lit.clone()) };
    let mut v17: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v19: clap::Arg = clap::Arg::new(v17);
    let mut v21: clap::Arg = v19.short(b'e' as char);
    let mut v22: &'static str = Box::leak(String::from(&*v16).into_boxed_str());
    let mut v24: clap::Arg = v21.long(v22);
    let mut v26: clap::Arg = v24.num_args(v15);
    let mut v28: clap::Arg = v26.require_equals(true);
    let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let mut v30: &str = (&*v29);
    let mut v32: clap::Arg = v28.default_missing_value(&*Box::leak(String::from(v30).into_boxed_str()));
    let mut v34: clap::Command = clap::Command::arg(v5, v32);
    let mut v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("trace_level"); } LIT.with(|lit| lit.clone()) };
    let mut v36: &'static str = Box::leak(String::from(&*v35).into_boxed_str());
    let mut v38: clap::Arg = clap::Arg::new(v36);
    let mut v40: clap::Arg = v38.short(b't' as char);
    let mut v41: &'static str = Box::leak(String::from(&*v35).into_boxed_str());
    let mut v43: clap::Arg = v40.long(v41);
    ;
    ;
    ;
    ;
    ;
    let mut v44: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
    let mut v45: Rc<str> = Rc::<str>::from(v44.to_lowercase());
    let mut v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
    let mut v47: Rc<str> = Rc::<str>::from(v46.to_lowercase());
    let mut v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v49: Rc<str> = Rc::<str>::from(v48.to_lowercase());
    let mut v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
    let mut v51: Rc<str> = Rc::<str>::from(v50.to_lowercase());
    let mut v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
    let mut v53: Rc<str> = Rc::<str>::from(v52.to_lowercase());
    let mut v54: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    v54.borrow_mut().push(v53);
    v54.borrow_mut().push(v51);
    v54.borrow_mut().push(v49);
    v54.borrow_mut().push(v47);
    v54.borrow_mut().push(v45);
    let mut v55: Rc<Vec<Rc<str>>> = Rc::new(v54.borrow().clone());
    let mut v56: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((v55).as_ref().clone()));
    let mut v57: Vec<Rc<str>> = (v56).borrow().clone();
    let mut v59: Rc<dyn Fn((Rc<str>)) -> clap::builder::PossibleValue> = closure0();
    let mut v60: Vec<clap::builder::PossibleValue> = v57.iter().map(|x| v59(x.clone())).collect::<Vec<_>>();
    let mut v62: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(clap::builder::PossibleValuesParser::new(v60));
    let mut v64: clap::Arg = v43.value_parser(v62);
    let mut v66: clap::Command = clap::Command::arg(v34, v64);
    let mut v67: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
    let mut v68: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v70: clap::Arg = clap::Arg::new(v68);
    let mut v72: clap::Arg = v70.short(b'w' as char);
    let mut v73: &'static str = Box::leak(String::from(&*v67).into_boxed_str());
    let mut v75: clap::Arg = v72.long(v73);
    let mut v77: clap::Arg = v75.required(true);
    let mut v79: clap::Command = clap::Command::arg(v66, v77);
    v79.clone()
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
        US0::US0_Some(v1.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method3(mut v0: i32, mut v1: Rc<RefCell<Mut0>>) -> bool {
    let mut v2: i32 = v1.borrow().l0.clone();
    let mut v3: bool = v2 < v0;
    v3
}
fn get_environment_variable_5(mut v0: Rc<str>) -> Rc<str> {
    let mut v1: Rc<str> = Rc::<str>::from(std::env::var(&*v0).unwrap_or_default());
    v1.clone()
}
fn closure3() -> Rc<dyn Fn(Rc<str>) -> ()> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> ()> = Rc::new(move |mut v0: Rc<str>| -> () {
        ()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn new_trace_state_4(mut v0: US3) -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("TRACE_LEVEL"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = get_environment_variable_5(v1.clone());
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
    let mut v14: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v11.clone(), v14.clone()));
    let mut v15: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v9.clone(), v15.clone()));
    let mut v16: US3 = US3::US3_Info;
    v13.borrow_mut().push((v7.clone(), v16.clone()));
    let mut v17: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v5.clone(), v17.clone()));
    let mut v18: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v3.clone(), v18.clone()));
    let mut v19: US3 = US3::US3_Verbose;
    v13.borrow_mut().push((v12.clone(), v19.clone()));
    let mut v20: US3 = US3::US3_Debug;
    v13.borrow_mut().push((v10.clone(), v20.clone()));
    let mut v21: US3 = US3::US3_Info;
    v13.borrow_mut().push((v8.clone(), v21.clone()));
    let mut v22: US3 = US3::US3_Warning;
    v13.borrow_mut().push((v6.clone(), v22.clone()));
    let mut v23: US3 = US3::US3_Critical;
    v13.borrow_mut().push((v4.clone(), v23.clone()));
    let mut v24: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v13.borrow().clone());
    let mut v25: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v24).as_ref().clone()));
    let mut v26: i32 = (v25.clone().borrow().len() as i32);
    let mut v27: US2 = US2::US2_None;
    let mut v28: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v27.clone() }));
    while method3(v26, v28.clone()) {
        let mut v30: i32 = v28.borrow().l0.clone();
        let mut v31: i32 = v30.wrapping_neg();
        let mut v32: i32 = v31.wrapping_add(v26);
        let mut v33: i32 = v32.wrapping_sub(1i32);
        let mut v34: US2 = v28.borrow().l1.clone();
        let (mut v35, mut v36): (Rc<str>, US3) = v25.clone().borrow()[v33 as usize].clone();
        let mut v43: US2 = match &v34 {
            US2::US2_None => {
                let mut v38: bool = v35 == v2 ;
                if v38 {
                    US2::US2_Some(v36.clone())
                } else {
                    US2::US2_None
                }
            }
            US2::US2_Some(v37) => {
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
        US2::US2_None => {
            v0.clone()
        }
        US2::US2_Some(v52) => {
            let mut v52: US3 = v52.clone();
            v52.clone()
        }
    };
    let mut v55: Rc<RefCell<Mut5>> = Rc::new(RefCell::new(Mut5 { l0: v54.clone() }));
    let mut v56: Option<i64> = None;
    (v46.clone(), v48.clone(), v49.clone(), v51.clone(), v55.clone(), v56.clone())
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
    let mut v6: u64 = { #[cfg(target_arch = "wasm32")] let (h, m, s) = { let secs = near_sdk::env::block_timestamp() / 1_000_000_000; ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; #[cfg(all(windows, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C)] struct St([u16; 8]); unsafe extern "system" { fn GetLocalTime(t: *mut St); } let mut t = St([0; 8]); unsafe { GetLocalTime(&mut t) }; (t.0[4] as u64, t.0[5] as u64, t.0[6] as u64) }; #[cfg(all(unix, not(target_arch = "wasm32")))] let (h, m, s) = { #[repr(C, align(8))] struct Tm([i32; 16]); unsafe extern "C" { fn localtime_r(t: *const std::os::raw::c_long, tm: *mut Tm) -> *mut Tm; } let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0) as std::os::raw::c_long; let mut tm = Tm([0; 16]); unsafe { localtime_r(&secs, &mut tm) }; (tm.0[2] as u64, tm.0[1] as u64, tm.0[0] as u64) }; #[cfg(not(any(windows, unix, target_arch = "wasm32")))] let (h, m, s) = { let secs = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).map(|d| d.as_secs()).unwrap_or(0); ((secs / 3600) % 24, (secs / 60) % 60, secs % 60) }; h * 3600 + m * 60 + s };
    let mut v7: u64 = v6.wrapping_div(3600u64);
    let mut v8: bool = v7 < 10u64;
    let mut v11: Rc<str> = if v8 {
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v9.clone()
    } else {
        let mut v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v10.clone()
    };
    let mut v12: Rc<str> = Rc::<str>::from(format!("{:?}", v7));
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: u64 = v6.wrapping_div(60u64);
    let mut v17: u64 = v16.wrapping_rem(60u64);
    let mut v18: bool = v17 < 10u64;
    let mut v21: Rc<str> = if v18 {
        let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v19.clone()
    } else {
        let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v20.clone()
    };
    let mut v22: Rc<str> = Rc::<str>::from(format!("{:?}", v17));
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    let mut v24: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v23));
    let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v24, v14));
    let mut v26: u64 = v6.wrapping_rem(60u64);
    let mut v27: bool = v26 < 10u64;
    let mut v30: Rc<str> = if v27 {
        let mut v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
        v28.clone()
    } else {
        let mut v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v29.clone()
    };
    let mut v31: Rc<str> = Rc::<str>::from(format!("{:?}", v26));
    let mut v32: Rc<str> = Rc::<str>::from(format!("{}{}", v30, v31));
    let mut v33: Rc<str> = Rc::<str>::from(format!("{}{}", v25, v32));
    v33.clone()
}
fn method9(mut v0: Rc<RefCell<Mut4>>, mut v1: Rc<str>) -> () {
    let mut v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v2, v1));
    v0.borrow_mut().l0 = v3.clone();
    ()
}
fn format_real_8(mut v0: u8) -> Rc<str> {
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
    let mut v4: Rc<str> = format_real_8(v3);
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
fn format_real_14(mut v0: i64) -> Rc<str> {
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
fn format_real_15(mut v0: Rc<RefCell<Vec<Rc<str>>>>) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.main"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_15(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
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
        US5::US5_Some(v1.clone())
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
fn format_real_27(mut v0: Rc<str>) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_27(v8.clone());
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
fn format_real_32(mut v0: u8, mut v1: near_workspaces::Worker<near_workspaces::network::Sandbox>, mut v2: near_workspaces::Contract) -> Rc<str> {
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
    let mut v14: Rc<str> = format_real_14(v11);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v7));
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v12));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = format_real_32(v8, v9.clone(), v10.clone());
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
fn format_real_38(mut v0: u8, mut v1: near_workspaces::result::ExecutionFinalResult) -> Rc<str> {
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
    let mut v13: Rc<str> = format_real_14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = format_real_38(v8, v9.clone());
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
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[92m"); } LIT.with(|lit| lit.clone()) };
    ;
    ;
    ;
    ;
    ;
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = Rc::<str>::from(v1.to_lowercase());
    let mut v3: u8 = v2.clone().as_bytes()[0i32 as usize];
    let mut v4: Rc<str> = format_real_8(v3);
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
fn format_real_42(mut v0: u8, mut v1: f64, mut v2: u64) -> Rc<str> {
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
    let mut v14: Rc<str> = format_real_14(v11);
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v14));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v7));
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v12));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd"); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = format_real_42(v8, v9, v10);
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
fn format_real_46(mut v0: bool, mut v1: f64, mut v2: f64, mut v3: u64, mut v4: u128) -> Rc<str> {
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
    let mut v16: Rc<str> = format_real_14(v13);
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v7));
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v14));
    let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("near_workspaces.print_usd / outcome"); } LIT.with(|lit| lit.clone()) };
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
    let mut v24: Rc<str> = format_real_46(v8, v9, v10, v11, v12.clone());
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
        let mut v19: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
        { let _ = spiral_trace_hold(&v19); };
        let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
        let (mut v22, mut v23, mut v24, mut v25, mut v26, mut v27): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v21) };
        let mut v28: US3 = v26.borrow().l0.clone();
        let mut v33: i32 = match &v28 {
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
            US4::US4_None
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
            US4::US4_Some(v53.clone(), v54.clone(), v55.clone(), v56.clone(), v57.clone(), v58.clone())
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
fn format_real_53(mut v0: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure>) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_53(v8.clone());
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
fn format_real_57(mut v0: i32, mut v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
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
    let mut v13: Rc<str> = format_real_14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = format_real_57(v8, v9.clone());
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
fn format_real_62(mut v0: i32, mut v1: Vec<near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
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
    let mut v13: Rc<str> = format_real_14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = format_real_62(v8, v9.clone());
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
fn format_real_66(mut v0: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_66(v8);
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
fn format_real_69(mut v0: Result<std::string::String, near_workspaces::error::Error>) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_69(v8);
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn format_real_71(mut v0: i32, mut v1: u8, mut v2: Vec<&near_workspaces::result::ExecutionOutcome>) -> Rc<str> {
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
fn fn_30(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let mut v7: bool = */ ();
    let mut v9: Result<near_workspaces::Worker<near_workspaces::network::Sandbox>, near_workspaces::error::Error> = near_workspaces::sandbox().await;
    let mut v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
    let mut v13: near_workspaces::Worker<near_workspaces::network::Sandbox> = v11.clone();
    let mut v15: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::Contract, near_workspaces::error::Error>>>> = Box::pin(v13.dev_deploy(&v0));
    let mut v17: Result<near_workspaces::Contract, near_workspaces::error::Error> = v15.await;
    let mut v19: near_workspaces::Contract = v17?;
    let mut v21: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v21); };
    let mut v23: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v24, mut v25, mut v26, mut v27, mut v28, mut v29): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v30: US3 = v28.borrow().l0.clone();
    let mut v35: i32 = match &v30 {
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
        US4::US4_None
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
        US4::US4_Some(v55.clone(), v56.clone(), v57.clone(), v58.clone(), v59.clone(), v60.clone())
    };
    let mut v87: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("state_main"); } LIT.with(|lit| lit.clone()) };
    let mut v88: near_workspaces::operations::CallTransaction = v19.call(&*v87);
    let mut v90: near_workspaces::types::Gas = near_workspaces::types::Gas::from_tgas(300i32 as u64);
    let mut v92: near_workspaces::operations::CallTransaction = v88.gas(v90);
    let mut v94: std::pin::Pin<Box<dyn std::future::Future<Output = Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error>>>> = Box::pin(v92.transact());
    let mut v96: Result<near_workspaces::result::ExecutionFinalResult, near_workspaces::error::Error> = v94.await;
    let mut v98: near_workspaces::result::ExecutionFinalResult = v96?;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v101, mut v102, mut v103, mut v104, mut v105, mut v106): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v107: US3 = v105.borrow().l0.clone();
    let mut v112: i32 = match &v107 {
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
    let mut v113: bool = v103.borrow().l0.clone();
    let mut v114: bool = v113 == false;
    let mut v116: bool = if v114 {
        false
    } else {
        let mut v115: bool = 10i32 >= v112;
        v115
    };
    let mut v117: bool = v116 == false;
    let mut v162: US4 = if v117 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v121, mut v122, mut v123, mut v124, mut v125, mut v126): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v127: Rc<str> = method6(v121.clone(), v122.clone(), v123.clone(), v124.clone(), v125.clone(), v126.clone());
        let mut v128: Rc<str> = method7();
        let mut v129: Rc<str> = method37(v121.clone(), v122.clone(), v123.clone(), v124.clone(), v125.clone(), v126.clone(), v127.clone(), v128.clone(), v1, v98.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v132, mut v133, mut v134, mut v135, mut v136, mut v137): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v138: i64 = v132.borrow().l0.clone();
        let mut v139: i64 = v138.wrapping_add(1i64);
        v132.borrow_mut().l0 = v139;
        let mut v140: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v141: bool = cfg!(target_arch = "wasm32");
        if v141 {
            let mut v142: Rc<str> = v135.borrow().l0.clone();
            let mut v143: bool = v142.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v151: Rc<str> = if v143 {
                v129.clone()
            } else {
                let mut v144: bool = v129.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v144 {
                    let mut v145: Rc<str> = v135.borrow().l0.clone();
                    v145.clone()
                } else {
                    let mut v146: Rc<str> = v135.borrow().l0.clone();
                    let mut v147: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v148: Rc<str> = Rc::<str>::from(format!("{}{}", v146, v147));
                    let mut v149: Rc<str> = Rc::<str>::from(format!("{}{}", v148, v129));
                    v149.clone()
                }
            };
            let mut v153: i32 = ((v151.chars().count() + 14999) / 15000) as i32;
            let mut v154: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v155: bool = v129 != v154 ;
            let mut v157: bool = if v155 {
                let mut v156: bool = v153 <= 1i32;
                v156
            } else {
                false
            };
            if v157 {
                v135.borrow_mut().l0 = v151.clone();
                ()
            } else {
                v135.borrow_mut().l0 = v154.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v151); };
                ()
            }
        } else {
            println!("{}", v129);
            ()
        };
        let mut v160: Rc<dyn Fn(Rc<str>) -> ()> = v133.borrow().l0.clone();
        v160(v129.clone());
        US4::US4_Some(v132.clone(), v133.clone(), v134.clone(), v135.clone(), v136.clone(), v137.clone())
    };
    let mut v164: Vec<&str> = v98.logs();
    let mut v166: Rc<dyn Fn((&str)) -> std::string::String> = closure10();
    let mut v167: Vec<std::string::String> = v164.iter().map(|x| v166(x.clone())).collect::<Vec<_>>();
    let mut v169: Rc<dyn Fn(std::string::String) -> ()> = closure11();
    let mut v170: bool = true; v167.iter().for_each(|x| { v169(x.clone()); }); //;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v173, mut v174, mut v175, mut v176, mut v177, mut v178): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v179: US3 = v177.borrow().l0.clone();
    let mut v184: i32 = match &v179 {
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
    let mut v185: bool = v175.borrow().l0.clone();
    let mut v186: bool = v185 == false;
    let mut v188: bool = if v186 {
        false
    } else {
        let mut v187: bool = 30i32 >= v184;
        v187
    };
    let mut v189: bool = v188 == false;
    let mut v224: US4 = if v189 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v193, mut v194, mut v195, mut v196, mut v197, mut v198): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v199: i64 = v193.borrow().l0.clone();
        let mut v200: i64 = v199.wrapping_add(1i64);
        v193.borrow_mut().l0 = v200;
        let mut v201: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v202: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v203: bool = cfg!(target_arch = "wasm32");
        if v203 {
            let mut v204: Rc<str> = v196.borrow().l0.clone();
            let mut v205: bool = v204.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v213: Rc<str> = if v205 {
                v201.clone()
            } else {
                let mut v206: bool = v201.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v206 {
                    let mut v207: Rc<str> = v196.borrow().l0.clone();
                    v207.clone()
                } else {
                    let mut v208: Rc<str> = v196.borrow().l0.clone();
                    let mut v209: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v210: Rc<str> = Rc::<str>::from(format!("{}{}", v208, v209));
                    let mut v211: Rc<str> = Rc::<str>::from(format!("{}{}", v210, v201));
                    v211.clone()
                }
            };
            let mut v215: i32 = ((v213.chars().count() + 14999) / 15000) as i32;
            let mut v216: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v217: bool = v201 != v216 ;
            let mut v219: bool = if v217 {
                let mut v218: bool = v215 <= 1i32;
                v218
            } else {
                false
            };
            if v219 {
                v196.borrow_mut().l0 = v213.clone();
                ()
            } else {
                v196.borrow_mut().l0 = v216.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v213); };
                ()
            }
        } else {
            println!("{}", v201);
            ()
        };
        let mut v222: Rc<dyn Fn(Rc<str>) -> ()> = v194.borrow().l0.clone();
        v222(v201.clone());
        US4::US4_Some(v193.clone(), v194.clone(), v195.clone(), v196.clone(), v197.clone(), v198.clone())
    };
    let mut v226: near_workspaces::types::Gas = v98.total_gas_burnt;
    let mut v228: u64 = v226.as_gas();
    let mut v229: f64 = (v228 as f64);
    let mut v230: f64 = v229 / 10000000000000000.0f64;
    let mut v231: f64 = v230 * 6.68f64;
    { let _ = spiral_trace_hold(&v21); };
    let (mut v234, mut v235, mut v236, mut v237, mut v238, mut v239): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v240: US3 = v238.borrow().l0.clone();
    let mut v245: i32 = match &v240 {
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
    let mut v246: bool = v236.borrow().l0.clone();
    let mut v247: bool = v246 == false;
    let mut v249: bool = if v247 {
        false
    } else {
        let mut v248: bool = 30i32 >= v245;
        v248
    };
    let mut v250: bool = v249 == false;
    let mut v295: US4 = if v250 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v254, mut v255, mut v256, mut v257, mut v258, mut v259): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v260: Rc<str> = method6(v254.clone(), v255.clone(), v256.clone(), v257.clone(), v258.clone(), v259.clone());
        let mut v261: Rc<str> = method40();
        let mut v262: Rc<str> = method41(v254.clone(), v255.clone(), v256.clone(), v257.clone(), v258.clone(), v259.clone(), v260.clone(), v261.clone(), v1, v231, v228);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v265, mut v266, mut v267, mut v268, mut v269, mut v270): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v271: i64 = v265.borrow().l0.clone();
        let mut v272: i64 = v271.wrapping_add(1i64);
        v265.borrow_mut().l0 = v272;
        let mut v273: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v274: bool = cfg!(target_arch = "wasm32");
        if v274 {
            let mut v275: Rc<str> = v268.borrow().l0.clone();
            let mut v276: bool = v275.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v284: Rc<str> = if v276 {
                v262.clone()
            } else {
                let mut v277: bool = v262.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v277 {
                    let mut v278: Rc<str> = v268.borrow().l0.clone();
                    v278.clone()
                } else {
                    let mut v279: Rc<str> = v268.borrow().l0.clone();
                    let mut v280: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v281: Rc<str> = Rc::<str>::from(format!("{}{}", v279, v280));
                    let mut v282: Rc<str> = Rc::<str>::from(format!("{}{}", v281, v262));
                    v282.clone()
                }
            };
            let mut v286: i32 = ((v284.chars().count() + 14999) / 15000) as i32;
            let mut v287: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v288: bool = v262 != v287 ;
            let mut v290: bool = if v288 {
                let mut v289: bool = v286 <= 1i32;
                v289
            } else {
                false
            };
            if v290 {
                v268.borrow_mut().l0 = v284.clone();
                ()
            } else {
                v268.borrow_mut().l0 = v287.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v284); };
                ()
            }
        } else {
            println!("{}", v262);
            ()
        };
        let mut v293: Rc<dyn Fn(Rc<str>) -> ()> = v266.borrow().l0.clone();
        v293(v262.clone());
        US4::US4_Some(v265.clone(), v266.clone(), v267.clone(), v268.clone(), v269.clone(), v270.clone())
    };
    let mut v297: near_workspaces::result::ExecutionFinalResult = v98.clone();
    let mut v299: Vec<&near_workspaces::result::ExecutionOutcome> = v297.outcomes();
    let mut v301: _ = v299.into_iter();
    let mut v303: _ = v301.cloned();
    let mut v305: Rc<dyn Fn(near_workspaces::result::ExecutionOutcome) -> ()> = closure12();
    let mut v306: bool = true; v303.for_each(|x| v305(x));
    let mut v308: Result<near_workspaces::result::ExecutionSuccess, near_workspaces::result::ExecutionFailure> = v98.clone().into_result();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v311, mut v312, mut v313, mut v314, mut v315, mut v316): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v317: US3 = v315.borrow().l0.clone();
    let mut v322: i32 = match &v317 {
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
    let mut v323: bool = v313.borrow().l0.clone();
    let mut v324: bool = v323 == false;
    let mut v326: bool = if v324 {
        false
    } else {
        let mut v325: bool = 10i32 >= v322;
        v325
    };
    let mut v327: bool = v326 == false;
    let mut v372: US4 = if v327 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v331, mut v332, mut v333, mut v334, mut v335, mut v336): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v337: Rc<str> = method6(v331.clone(), v332.clone(), v333.clone(), v334.clone(), v335.clone(), v336.clone());
        let mut v338: Rc<str> = method7();
        let mut v339: Rc<str> = method52(v331.clone(), v332.clone(), v333.clone(), v334.clone(), v335.clone(), v336.clone(), v337.clone(), v338.clone(), v308.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v342, mut v343, mut v344, mut v345, mut v346, mut v347): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v348: i64 = v342.borrow().l0.clone();
        let mut v349: i64 = v348.wrapping_add(1i64);
        v342.borrow_mut().l0 = v349;
        let mut v350: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v351: bool = cfg!(target_arch = "wasm32");
        if v351 {
            let mut v352: Rc<str> = v345.borrow().l0.clone();
            let mut v353: bool = v352.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v361: Rc<str> = if v353 {
                v339.clone()
            } else {
                let mut v354: bool = v339.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v354 {
                    let mut v355: Rc<str> = v345.borrow().l0.clone();
                    v355.clone()
                } else {
                    let mut v356: Rc<str> = v345.borrow().l0.clone();
                    let mut v357: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v358: Rc<str> = Rc::<str>::from(format!("{}{}", v356, v357));
                    let mut v359: Rc<str> = Rc::<str>::from(format!("{}{}", v358, v339));
                    v359.clone()
                }
            };
            let mut v363: i32 = ((v361.chars().count() + 14999) / 15000) as i32;
            let mut v364: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v365: bool = v339 != v364 ;
            let mut v367: bool = if v365 {
                let mut v366: bool = v363 <= 1i32;
                v366
            } else {
                false
            };
            if v367 {
                v345.borrow_mut().l0 = v361.clone();
                ()
            } else {
                v345.borrow_mut().l0 = v364.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v361); };
                ()
            }
        } else {
            println!("{}", v339);
            ()
        };
        let mut v370: Rc<dyn Fn(Rc<str>) -> ()> = v343.borrow().l0.clone();
        v370(v339.clone());
        US4::US4_Some(v342.clone(), v343.clone(), v344.clone(), v345.clone(), v346.clone(), v347.clone())
    };
    let mut v373: near_workspaces::result::ExecutionFinalResult = method55(v98.clone());
    let mut v375: Vec<&near_workspaces::result::ExecutionOutcome> = v373.receipt_failures();
    let mut v376: usize = ((v375).len() as usize);
    let mut v377: i32 = (v376 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v380, mut v381, mut v382, mut v383, mut v384, mut v385): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v386: US3 = v384.borrow().l0.clone();
    let mut v391: i32 = match &v386 {
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
    let mut v392: bool = v382.borrow().l0.clone();
    let mut v393: bool = v392 == false;
    let mut v395: bool = if v393 {
        false
    } else {
        let mut v394: bool = 10i32 >= v391;
        v394
    };
    let mut v396: bool = v395 == false;
    let mut v441: US4 = if v396 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v400, mut v401, mut v402, mut v403, mut v404, mut v405): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v406: Rc<str> = method6(v400.clone(), v401.clone(), v402.clone(), v403.clone(), v404.clone(), v405.clone());
        let mut v407: Rc<str> = method7();
        let mut v408: Rc<str> = method56(v400.clone(), v401.clone(), v402.clone(), v403.clone(), v404.clone(), v405.clone(), v406.clone(), v407.clone(), v377, v375.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v411, mut v412, mut v413, mut v414, mut v415, mut v416): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v417: i64 = v411.borrow().l0.clone();
        let mut v418: i64 = v417.wrapping_add(1i64);
        v411.borrow_mut().l0 = v418;
        let mut v419: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v420: bool = cfg!(target_arch = "wasm32");
        if v420 {
            let mut v421: Rc<str> = v414.borrow().l0.clone();
            let mut v422: bool = v421.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v430: Rc<str> = if v422 {
                v408.clone()
            } else {
                let mut v423: bool = v408.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v423 {
                    let mut v424: Rc<str> = v414.borrow().l0.clone();
                    v424.clone()
                } else {
                    let mut v425: Rc<str> = v414.borrow().l0.clone();
                    let mut v426: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v427: Rc<str> = Rc::<str>::from(format!("{}{}", v425, v426));
                    let mut v428: Rc<str> = Rc::<str>::from(format!("{}{}", v427, v408));
                    v428.clone()
                }
            };
            let mut v432: i32 = ((v430.chars().count() + 14999) / 15000) as i32;
            let mut v433: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v434: bool = v408 != v433 ;
            let mut v436: bool = if v434 {
                let mut v435: bool = v432 <= 1i32;
                v435
            } else {
                false
            };
            if v436 {
                v414.borrow_mut().l0 = v430.clone();
                ()
            } else {
                v414.borrow_mut().l0 = v433.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v430); };
                ()
            }
        } else {
            println!("{}", v408);
            ()
        };
        let mut v439: Rc<dyn Fn(Rc<str>) -> ()> = v412.borrow().l0.clone();
        v439(v408.clone());
        US4::US4_Some(v411.clone(), v412.clone(), v413.clone(), v414.clone(), v415.clone(), v416.clone())
    };
    let mut v442: near_workspaces::result::ExecutionFinalResult = method60(v98.clone());
    let mut v444: &[near_workspaces::result::ExecutionOutcome] = v442.receipt_outcomes();
    let mut v446: Vec<near_workspaces::result::ExecutionOutcome> = v444.into();
    let mut v447: usize = ((v446).len() as usize);
    let mut v448: i32 = (v447 as i32);
    { let _ = spiral_trace_hold(&v21); };
    let (mut v451, mut v452, mut v453, mut v454, mut v455, mut v456): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v457: US3 = v455.borrow().l0.clone();
    let mut v462: i32 = match &v457 {
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
    let mut v463: bool = v453.borrow().l0.clone();
    let mut v464: bool = v463 == false;
    let mut v466: bool = if v464 {
        false
    } else {
        let mut v465: bool = 10i32 >= v462;
        v465
    };
    let mut v467: bool = v466 == false;
    let mut v512: US4 = if v467 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v471, mut v472, mut v473, mut v474, mut v475, mut v476): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v477: Rc<str> = method6(v471.clone(), v472.clone(), v473.clone(), v474.clone(), v475.clone(), v476.clone());
        let mut v478: Rc<str> = method7();
        let mut v479: Rc<str> = method61(v471.clone(), v472.clone(), v473.clone(), v474.clone(), v475.clone(), v476.clone(), v477.clone(), v478.clone(), v448, v446.clone());
        { let _ = spiral_trace_hold(&v21); };
        let (mut v482, mut v483, mut v484, mut v485, mut v486, mut v487): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v488: i64 = v482.borrow().l0.clone();
        let mut v489: i64 = v488.wrapping_add(1i64);
        v482.borrow_mut().l0 = v489;
        let mut v490: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v491: bool = cfg!(target_arch = "wasm32");
        if v491 {
            let mut v492: Rc<str> = v485.borrow().l0.clone();
            let mut v493: bool = v492.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v501: Rc<str> = if v493 {
                v479.clone()
            } else {
                let mut v494: bool = v479.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v494 {
                    let mut v495: Rc<str> = v485.borrow().l0.clone();
                    v495.clone()
                } else {
                    let mut v496: Rc<str> = v485.borrow().l0.clone();
                    let mut v497: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v498: Rc<str> = Rc::<str>::from(format!("{}{}", v496, v497));
                    let mut v499: Rc<str> = Rc::<str>::from(format!("{}{}", v498, v479));
                    v499.clone()
                }
            };
            let mut v503: i32 = ((v501.chars().count() + 14999) / 15000) as i32;
            let mut v504: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v505: bool = v479 != v504 ;
            let mut v507: bool = if v505 {
                let mut v506: bool = v503 <= 1i32;
                v506
            } else {
                false
            };
            if v507 {
                v485.borrow_mut().l0 = v501.clone();
                ()
            } else {
                v485.borrow_mut().l0 = v504.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v501); };
                ()
            }
        } else {
            println!("{}", v479);
            ()
        };
        let mut v510: Rc<dyn Fn(Rc<str>) -> ()> = v483.borrow().l0.clone();
        v510(v479.clone());
        US4::US4_Some(v482.clone(), v483.clone(), v484.clone(), v485.clone(), v486.clone(), v487.clone())
    };
    let mut v514: near_workspaces::result::ExecutionFinalResult = v98.clone();
    let mut v516: Result<std::string::String, near_workspaces::error::Error> = v514.json();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v519, mut v520, mut v521, mut v522, mut v523, mut v524): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v525: US3 = v523.borrow().l0.clone();
    let mut v530: i32 = match &v525 {
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
    let mut v531: bool = v521.borrow().l0.clone();
    let mut v532: bool = v531 == false;
    let mut v534: bool = if v532 {
        false
    } else {
        let mut v533: bool = 10i32 >= v530;
        v533
    };
    let mut v535: bool = v534 == false;
    let mut v580: US4 = if v535 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v539, mut v540, mut v541, mut v542, mut v543, mut v544): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v545: Rc<str> = method6(v539.clone(), v540.clone(), v541.clone(), v542.clone(), v543.clone(), v544.clone());
        let mut v546: Rc<str> = method7();
        let mut v547: Rc<str> = method65(v539.clone(), v540.clone(), v541.clone(), v542.clone(), v543.clone(), v544.clone(), v545.clone(), v546.clone(), v516);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v550, mut v551, mut v552, mut v553, mut v554, mut v555): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v556: i64 = v550.borrow().l0.clone();
        let mut v557: i64 = v556.wrapping_add(1i64);
        v550.borrow_mut().l0 = v557;
        let mut v558: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v559: bool = cfg!(target_arch = "wasm32");
        if v559 {
            let mut v560: Rc<str> = v553.borrow().l0.clone();
            let mut v561: bool = v560.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v569: Rc<str> = if v561 {
                v547.clone()
            } else {
                let mut v562: bool = v547.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v562 {
                    let mut v563: Rc<str> = v553.borrow().l0.clone();
                    v563.clone()
                } else {
                    let mut v564: Rc<str> = v553.borrow().l0.clone();
                    let mut v565: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v566: Rc<str> = Rc::<str>::from(format!("{}{}", v564, v565));
                    let mut v567: Rc<str> = Rc::<str>::from(format!("{}{}", v566, v547));
                    v567.clone()
                }
            };
            let mut v571: i32 = ((v569.chars().count() + 14999) / 15000) as i32;
            let mut v572: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v573: bool = v547 != v572 ;
            let mut v575: bool = if v573 {
                let mut v574: bool = v571 <= 1i32;
                v574
            } else {
                false
            };
            if v575 {
                v553.borrow_mut().l0 = v569.clone();
                ()
            } else {
                v553.borrow_mut().l0 = v572.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v569); };
                ()
            }
        } else {
            println!("{}", v547);
            ()
        };
        let mut v578: Rc<dyn Fn(Rc<str>) -> ()> = v551.borrow().l0.clone();
        v578(v547.clone());
        US4::US4_Some(v550.clone(), v551.clone(), v552.clone(), v553.clone(), v554.clone(), v555.clone())
    };
    let mut v582: near_workspaces::result::ExecutionFinalResult = v98.clone();
    let mut v584: Result<std::string::String, near_workspaces::error::Error> = v582.borsh();
    { let _ = spiral_trace_hold(&v21); };
    let (mut v587, mut v588, mut v589, mut v590, mut v591, mut v592): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
    let mut v593: US3 = v591.borrow().l0.clone();
    let mut v598: i32 = match &v593 {
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
    let mut v599: bool = v589.borrow().l0.clone();
    let mut v600: bool = v599 == false;
    let mut v602: bool = if v600 {
        false
    } else {
        let mut v601: bool = 10i32 >= v598;
        v601
    };
    let mut v603: bool = v602 == false;
    let mut v648: US4 = if v603 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v21); };
        let (mut v607, mut v608, mut v609, mut v610, mut v611, mut v612): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v613: Rc<str> = method6(v607.clone(), v608.clone(), v609.clone(), v610.clone(), v611.clone(), v612.clone());
        let mut v614: Rc<str> = method7();
        let mut v615: Rc<str> = method68(v607.clone(), v608.clone(), v609.clone(), v610.clone(), v611.clone(), v612.clone(), v613.clone(), v614.clone(), v584);
        { let _ = spiral_trace_hold(&v21); };
        let (mut v618, mut v619, mut v620, mut v621, mut v622, mut v623): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v23) };
        let mut v624: i64 = v618.borrow().l0.clone();
        let mut v625: i64 = v624.wrapping_add(1i64);
        v618.borrow_mut().l0 = v625;
        let mut v626: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v627: bool = cfg!(target_arch = "wasm32");
        if v627 {
            let mut v628: Rc<str> = v621.borrow().l0.clone();
            let mut v629: bool = v628.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v637: Rc<str> = if v629 {
                v615.clone()
            } else {
                let mut v630: bool = v615.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v630 {
                    let mut v631: Rc<str> = v621.borrow().l0.clone();
                    v631.clone()
                } else {
                    let mut v632: Rc<str> = v621.borrow().l0.clone();
                    let mut v633: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v634: Rc<str> = Rc::<str>::from(format!("{}{}", v632, v633));
                    let mut v635: Rc<str> = Rc::<str>::from(format!("{}{}", v634, v615));
                    v635.clone()
                }
            };
            let mut v639: i32 = ((v637.chars().count() + 14999) / 15000) as i32;
            let mut v640: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v641: bool = v615 != v640 ;
            let mut v643: bool = if v641 {
                let mut v642: bool = v639 <= 1i32;
                v642
            } else {
                false
            };
            if v643 {
                v621.borrow_mut().l0 = v637.clone();
                ()
            } else {
                v621.borrow_mut().l0 = v640.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v637); };
                ()
            }
        } else {
            println!("{}", v615);
            ()
        };
        let mut v646: Rc<dyn Fn(Rc<str>) -> ()> = v619.borrow().l0.clone();
        v646(v615.clone());
        US4::US4_Some(v618.clone(), v619.clone(), v620.clone(), v621.clone(), v622.clone(), v623.clone())
    };
    let mut v649: Rc<str> = format_real_71(v448, v1, v375.clone());
    let mut v650: bool = v377 > 0i32;
    let mut v661: Result<US5, anyhow::Error> = if v650 {
        let mut v651: US5 = US5::US5_Some(v649.clone());
        let mut v652: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v651);
        v652
    } else {
        let mut v653: bool = v448 > 1i32;
        if v653 {
            let mut v654: US5 = US5::US5_None;
            let mut v655: Result<US5, anyhow::Error> = Ok::<US5, anyhow::Error>(v654);
            v655
        } else {
            let mut v657: anyhow::Error = anyhow::anyhow!("{}", v649);
            let mut v659: Result<US5, anyhow::Error> = Err(v657);
            v659
        }
    };
    let mut v662: bool = true; (v661) }); //;
    let mut v664: _ = __future_init;
    let mut v666: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = v664;
    v666
}
fn closure13() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(anyhow::Error) -> std::string::String> = Rc::new(move |mut v0: anyhow::Error| -> std::string::String {
        let mut v2: std::string::String = format!("{}", v0);
        v2.clone()
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method72() -> Rc<dyn Fn(anyhow::Error) -> std::string::String> {
    closure13()
}
fn ok_c14() -> Rc<dyn Fn(US5) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US5) -> US7> = Rc::new(move |mut v0: US5| -> US7 {
        US7::US7_Ok(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method73() -> Rc<dyn Fn(US5) -> US7> {
    ok_c14()
}
fn error_c15() -> Rc<dyn Fn(std::string::String) -> US7> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US7> = Rc::new(move |mut v0: std::string::String| -> US7 {
        US7::US7_Error(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method74() -> Rc<dyn Fn(std::string::String) -> US7> {
    error_c15()
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
    let mut v4: Rc<str> = format_real_8(v3);
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
fn format_real_77(mut v0: u8, mut v1: std::string::String) -> Rc<str> {
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
    let mut v13: Rc<str> = format_real_14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Error error"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = format_real_77(v8, v9.clone());
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
    let mut v4: Rc<str> = format_real_8(v3);
    let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v0, v4));
    let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[0m"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v5, v6));
    v7.clone()
}
fn format_real_81(mut v0: u8, mut v1: Rc<str>) -> Rc<str> {
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
    let mut v13: Rc<str> = format_real_14(v10);
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
    let mut v16: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v11));
    let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run / Ok (Some error)"); } LIT.with(|lit| lit.clone()) };
    let mut v18: Rc<str> = Rc::<str>::from(format!("{}{}", v16, v17));
    let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v20: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v19));
    let mut v21: Rc<str> = format_real_81(v8, v9.clone());
    let mut v22: Rc<str> = Rc::<str>::from(format!("{}{}", v20, v21));
    method11(v22.clone())
}
fn method29(mut v0: Vec<u8>, mut v1: u8) -> std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> {
    let mut v3: bool = true; let __future_init = Box::pin(/*;
    let mut v5: bool = */ async move { /*;
    let mut v7: bool = */ ();
    let mut v8: std::pin::Pin<Box<dyn std::future::Future<Output = Result<US5, anyhow::Error>>>> = fn_30(v0.clone(), v1);
    let mut v10: Result<US5, anyhow::Error> = v8.await;
    let mut v11: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v13: Result<US5, std::string::String> = v10.map_err(|x| v11(x));
    let mut v14: Rc<dyn Fn(US5) -> US7> = method73();
    let mut v15: Rc<dyn Fn(std::string::String) -> US7> = method74();
    let mut v16: US7 = match v13 { Ok(x) => v14(x), Err(e) => v15(e) };
    let mut v381: US6 = match &v16 {
        US7::US7_Error(v119) => {
            let mut v119: std::string::String = v119.clone();
            let mut v120: bool = v1 >= 15u8;
            if v120 {
                let mut v122: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                { let _ = spiral_trace_hold(&v122); };
                let mut v124: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                let (mut v125, mut v126, mut v127, mut v128, mut v129, mut v130): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v124) };
                let mut v131: US3 = v129.borrow().l0.clone();
                let mut v136: i32 = match &v131 {
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
                let mut v137: bool = v127.borrow().l0.clone();
                let mut v138: bool = v137 == false;
                let mut v140: bool = if v138 {
                    false
                } else {
                    let mut v139: bool = 40i32 >= v136;
                    v139
                };
                let mut v141: bool = v140 == false;
                let mut v186: US4 = if v141 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v122); };
                    let (mut v145, mut v146, mut v147, mut v148, mut v149, mut v150): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v124) };
                    let mut v151: Rc<str> = method6(v145.clone(), v146.clone(), v147.clone(), v148.clone(), v149.clone(), v150.clone());
                    let mut v152: Rc<str> = method75();
                    let mut v153: Rc<str> = method76(v145.clone(), v146.clone(), v147.clone(), v148.clone(), v149.clone(), v150.clone(), v151.clone(), v152.clone(), v1, v119.clone());
                    { let _ = spiral_trace_hold(&v122); };
                    let (mut v156, mut v157, mut v158, mut v159, mut v160, mut v161): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v124) };
                    let mut v162: i64 = v156.borrow().l0.clone();
                    let mut v163: i64 = v162.wrapping_add(1i64);
                    v156.borrow_mut().l0 = v163;
                    let mut v164: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v165: bool = cfg!(target_arch = "wasm32");
                    if v165 {
                        let mut v166: Rc<str> = v159.borrow().l0.clone();
                        let mut v167: bool = v166.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v175: Rc<str> = if v167 {
                            v153.clone()
                        } else {
                            let mut v168: bool = v153.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v168 {
                                let mut v169: Rc<str> = v159.borrow().l0.clone();
                                v169.clone()
                            } else {
                                let mut v170: Rc<str> = v159.borrow().l0.clone();
                                let mut v171: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v172: Rc<str> = Rc::<str>::from(format!("{}{}", v170, v171));
                                let mut v173: Rc<str> = Rc::<str>::from(format!("{}{}", v172, v153));
                                v173.clone()
                            }
                        };
                        let mut v177: i32 = ((v175.chars().count() + 14999) / 15000) as i32;
                        let mut v178: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v179: bool = v153 != v178 ;
                        let mut v181: bool = if v179 {
                            let mut v180: bool = v177 <= 1i32;
                            v180
                        } else {
                            false
                        };
                        if v181 {
                            v159.borrow_mut().l0 = v175.clone();
                            ()
                        } else {
                            v159.borrow_mut().l0 = v178.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v175); };
                            ()
                        }
                    } else {
                        println!("{}", v153);
                        ()
                    };
                    let mut v184: Rc<dyn Fn(Rc<str>) -> ()> = v157.borrow().l0.clone();
                    v184(v153.clone());
                    US4::US4_Some(v156.clone(), v157.clone(), v158.clone(), v159.clone(), v160.clone(), v161.clone())
                };
                { let _ = spiral_trace_hold(&v122); };
                let (mut v189, mut v190, mut v191, mut v192, mut v193, mut v194): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v124) };
                let mut v195: US3 = v193.borrow().l0.clone();
                let mut v200: i32 = match &v195 {
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
                let mut v201: bool = v191.borrow().l0.clone();
                let mut v202: bool = v201 == false;
                let mut v204: bool = if v202 {
                    false
                } else {
                    let mut v203: bool = 40i32 >= v200;
                    v203
                };
                let mut v205: bool = v204 == false;
                let mut v239: US4 = if v205 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v122); };
                    let (mut v209, mut v210, mut v211, mut v212, mut v213, mut v214): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v124) };
                    let mut v215: i64 = v209.borrow().l0.clone();
                    let mut v216: i64 = v215.wrapping_add(1i64);
                    v209.borrow_mut().l0 = v216;
                    let mut v217: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v218: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v219: bool = cfg!(target_arch = "wasm32");
                    if v219 {
                        let mut v220: Rc<str> = v212.borrow().l0.clone();
                        let mut v221: bool = v220.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v228: Rc<str> = if v221 {
                            v217.clone()
                        } else {
                            let mut v222: bool = v217.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v222 {
                                let mut v223: Rc<str> = v212.borrow().l0.clone();
                                v223.clone()
                            } else {
                                let mut v224: Rc<str> = v212.borrow().l0.clone();
                                let mut v225: Rc<str> = Rc::<str>::from(format!("{}{}", v224, v217));
                                let mut v226: Rc<str> = Rc::<str>::from(format!("{}{}", v225, v217));
                                v226.clone()
                            }
                        };
                        let mut v230: i32 = ((v228.chars().count() + 14999) / 15000) as i32;
                        let mut v231: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v232: bool = v217 != v231 ;
                        let mut v234: bool = if v232 {
                            let mut v233: bool = v230 <= 1i32;
                            v233
                        } else {
                            false
                        };
                        if v234 {
                            v212.borrow_mut().l0 = v228.clone();
                            ()
                        } else {
                            v212.borrow_mut().l0 = v231.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v228); };
                            ()
                        }
                    } else {
                        println!("{}", v217);
                        ()
                    };
                    let mut v237: Rc<dyn Fn(Rc<str>) -> ()> = v210.borrow().l0.clone();
                    v237(v217.clone());
                    US4::US4_Some(v209.clone(), v210.clone(), v211.clone(), v212.clone(), v213.clone(), v214.clone())
                };
                let mut v241: bool = true; let __future_init = Box::pin(/*;
                let mut v243: bool = */ async move { /*;
                let mut v245: bool = */ ();
                let mut v246: US5 = US5::US5_None;
                let mut v247: bool = true; ((v1, v246.clone())) }); //;
                let mut v249: _ = __future_init;
                let mut v251: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v249;
                let (mut v253, mut v254): (u8, US5) = v251.await;
                US6::US6_Ok(v253, v254.clone())
            } else {
                let mut v257: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                { let _ = spiral_trace_hold(&v257); };
                let mut v259: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                let (mut v260, mut v261, mut v262, mut v263, mut v264, mut v265): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v259) };
                let mut v266: US3 = v264.borrow().l0.clone();
                let mut v271: i32 = match &v266 {
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
                let mut v272: bool = v262.borrow().l0.clone();
                let mut v273: bool = v272 == false;
                let mut v275: bool = if v273 {
                    false
                } else {
                    let mut v274: bool = 40i32 >= v271;
                    v274
                };
                let mut v276: bool = v275 == false;
                let mut v321: US4 = if v276 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v257); };
                    let (mut v280, mut v281, mut v282, mut v283, mut v284, mut v285): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v259) };
                    let mut v286: Rc<str> = method6(v280.clone(), v281.clone(), v282.clone(), v283.clone(), v284.clone(), v285.clone());
                    let mut v287: Rc<str> = method75();
                    let mut v288: Rc<str> = method76(v280.clone(), v281.clone(), v282.clone(), v283.clone(), v284.clone(), v285.clone(), v286.clone(), v287.clone(), v1, v119.clone());
                    { let _ = spiral_trace_hold(&v257); };
                    let (mut v291, mut v292, mut v293, mut v294, mut v295, mut v296): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v259) };
                    let mut v297: i64 = v291.borrow().l0.clone();
                    let mut v298: i64 = v297.wrapping_add(1i64);
                    v291.borrow_mut().l0 = v298;
                    let mut v299: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v300: bool = cfg!(target_arch = "wasm32");
                    if v300 {
                        let mut v301: Rc<str> = v294.borrow().l0.clone();
                        let mut v302: bool = v301.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v310: Rc<str> = if v302 {
                            v288.clone()
                        } else {
                            let mut v303: bool = v288.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v303 {
                                let mut v304: Rc<str> = v294.borrow().l0.clone();
                                v304.clone()
                            } else {
                                let mut v305: Rc<str> = v294.borrow().l0.clone();
                                let mut v306: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                let mut v307: Rc<str> = Rc::<str>::from(format!("{}{}", v305, v306));
                                let mut v308: Rc<str> = Rc::<str>::from(format!("{}{}", v307, v288));
                                v308.clone()
                            }
                        };
                        let mut v312: i32 = ((v310.chars().count() + 14999) / 15000) as i32;
                        let mut v313: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v314: bool = v288 != v313 ;
                        let mut v316: bool = if v314 {
                            let mut v315: bool = v312 <= 1i32;
                            v315
                        } else {
                            false
                        };
                        if v316 {
                            v294.borrow_mut().l0 = v310.clone();
                            ()
                        } else {
                            v294.borrow_mut().l0 = v313.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v310); };
                            ()
                        }
                    } else {
                        println!("{}", v288);
                        ()
                    };
                    let mut v319: Rc<dyn Fn(Rc<str>) -> ()> = v292.borrow().l0.clone();
                    v319(v288.clone());
                    US4::US4_Some(v291.clone(), v292.clone(), v293.clone(), v294.clone(), v295.clone(), v296.clone())
                };
                { let _ = spiral_trace_hold(&v257); };
                let (mut v324, mut v325, mut v326, mut v327, mut v328, mut v329): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v259) };
                let mut v330: US3 = v328.borrow().l0.clone();
                let mut v335: i32 = match &v330 {
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
                let mut v336: bool = v326.borrow().l0.clone();
                let mut v337: bool = v336 == false;
                let mut v339: bool = if v337 {
                    false
                } else {
                    let mut v338: bool = 40i32 >= v335;
                    v338
                };
                let mut v340: bool = v339 == false;
                let mut v374: US4 = if v340 {
                    US4::US4_None
                } else {
                    { let _ = spiral_trace_hold(&v257); };
                    let (mut v344, mut v345, mut v346, mut v347, mut v348, mut v349): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v259) };
                    let mut v350: i64 = v344.borrow().l0.clone();
                    let mut v351: i64 = v350.wrapping_add(1i64);
                    v344.borrow_mut().l0 = v351;
                    let mut v352: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v353: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                    let mut v354: bool = cfg!(target_arch = "wasm32");
                    if v354 {
                        let mut v355: Rc<str> = v347.borrow().l0.clone();
                        let mut v356: bool = v355.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v363: Rc<str> = if v356 {
                            v352.clone()
                        } else {
                            let mut v357: bool = v352.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            if v357 {
                                let mut v358: Rc<str> = v347.borrow().l0.clone();
                                v358.clone()
                            } else {
                                let mut v359: Rc<str> = v347.borrow().l0.clone();
                                let mut v360: Rc<str> = Rc::<str>::from(format!("{}{}", v359, v352));
                                let mut v361: Rc<str> = Rc::<str>::from(format!("{}{}", v360, v352));
                                v361.clone()
                            }
                        };
                        let mut v365: i32 = ((v363.chars().count() + 14999) / 15000) as i32;
                        let mut v366: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                        let mut v367: bool = v352 != v366 ;
                        let mut v369: bool = if v367 {
                            let mut v368: bool = v365 <= 1i32;
                            v368
                        } else {
                            false
                        };
                        if v369 {
                            v347.borrow_mut().l0 = v363.clone();
                            ()
                        } else {
                            v347.borrow_mut().l0 = v366.clone();
                            { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v363); };
                            ()
                        }
                    } else {
                        println!("{}", v352);
                        ()
                    };
                    let mut v372: Rc<dyn Fn(Rc<str>) -> ()> = v345.borrow().l0.clone();
                    v372(v352.clone());
                    US4::US4_Some(v344.clone(), v345.clone(), v346.clone(), v347.clone(), v348.clone(), v349.clone())
                };
                let mut v375: u8 = v1.wrapping_add(1u8);
                let mut v376: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = method29(v0.clone(), v375);
                let mut v378: US6 = v376.await;
                v378.clone()
            }
        }
        US7::US7_Ok(v17) => {
            let mut v17: US5 = v17.clone();
            match &v17 {
                US5::US5_None => {
                    let mut v19: bool = true; let __future_init = Box::pin(/*;
                    let mut v21: bool = */ async move { /*;
                    let mut v23: bool = */ ();
                    let mut v24: US5 = US5::US5_None;
                    let mut v25: bool = true; ((v1, v24.clone())) }); //;
                    let mut v27: _ = __future_init;
                    let mut v29: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v27;
                    let (mut v31, mut v32): (u8, US5) = v29.await;
                    US6::US6_Ok(v31, v32.clone())
                }
                US5::US5_Some(v34) => {
                    let mut v34: Rc<str> = v34.clone();
                    let mut v36: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
                    { let _ = spiral_trace_hold(&v36); };
                    let mut v38: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
                    let (mut v39, mut v40, mut v41, mut v42, mut v43, mut v44): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                    let mut v45: US3 = v43.borrow().l0.clone();
                    let mut v50: i32 = match &v45 {
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
                    let mut v51: bool = v41.borrow().l0.clone();
                    let mut v52: bool = v51 == false;
                    let mut v54: bool = if v52 {
                        false
                    } else {
                        let mut v53: bool = 50i32 >= v50;
                        v53
                    };
                    let mut v55: bool = v54 == false;
                    let mut v100: US4 = if v55 {
                        US4::US4_None
                    } else {
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v59, mut v60, mut v61, mut v62, mut v63, mut v64): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                        let mut v65: Rc<str> = method6(v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone(), v64.clone());
                        let mut v66: Rc<str> = method79();
                        let mut v67: Rc<str> = method80(v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone(), v64.clone(), v65.clone(), v66.clone(), v1, v34.clone());
                        { let _ = spiral_trace_hold(&v36); };
                        let (mut v70, mut v71, mut v72, mut v73, mut v74, mut v75): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v38) };
                        let mut v76: i64 = v70.borrow().l0.clone();
                        let mut v77: i64 = v76.wrapping_add(1i64);
                        v70.borrow_mut().l0 = v77;
                        let mut v78: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
                        let mut v79: bool = cfg!(target_arch = "wasm32");
                        if v79 {
                            let mut v80: Rc<str> = v73.borrow().l0.clone();
                            let mut v81: bool = v80.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v89: Rc<str> = if v81 {
                                v67.clone()
                            } else {
                                let mut v82: bool = v67.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                                if v82 {
                                    let mut v83: Rc<str> = v73.borrow().l0.clone();
                                    v83.clone()
                                } else {
                                    let mut v84: Rc<str> = v73.borrow().l0.clone();
                                    let mut v85: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                                    let mut v86: Rc<str> = Rc::<str>::from(format!("{}{}", v84, v85));
                                    let mut v87: Rc<str> = Rc::<str>::from(format!("{}{}", v86, v67));
                                    v87.clone()
                                }
                            };
                            let mut v91: i32 = ((v89.chars().count() + 14999) / 15000) as i32;
                            let mut v92: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            let mut v93: bool = v67 != v92 ;
                            let mut v95: bool = if v93 {
                                let mut v94: bool = v91 <= 1i32;
                                v94
                            } else {
                                false
                            };
                            if v95 {
                                v73.borrow_mut().l0 = v89.clone();
                                ()
                            } else {
                                v73.borrow_mut().l0 = v92.clone();
                                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v89); };
                                ()
                            }
                        } else {
                            println!("{}", v67);
                            ()
                        };
                        let mut v98: Rc<dyn Fn(Rc<str>) -> ()> = v71.borrow().l0.clone();
                        v98(v67.clone());
                        US4::US4_Some(v70.clone(), v71.clone(), v72.clone(), v73.clone(), v74.clone(), v75.clone())
                    };
                    let mut v102: bool = true; let __future_init = Box::pin(/*;
                    let mut v104: bool = */ async move { /*;
                    let mut v106: bool = */ ();
                    let mut v107: US5 = US5::US5_Some(v34.clone());
                    let mut v108: bool = true; ((v1, v107.clone())) }); //;
                    let mut v110: _ = __future_init;
                    let mut v112: std::pin::Pin<Box<dyn std::future::Future<Output = (u8, US5)>>> = v110;
                    let (mut v114, mut v115): (u8, US5) = v112.await;
                    US6::US6_Error(v114, v115.clone())
                }
            }
        }
    };
    let mut v382: bool = true; (v381) }); //;
    let mut v384: _ = __future_init;
    let mut v386: std::pin::Pin<Box<dyn std::future::Future<Output = US6>>> = v384;
    v386
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
        US5::US5_None => {
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("None"); } LIT.with(|lit| lit.clone()) };
            v8.clone()
        }
        US5::US5_Some(v1) => {
            let mut v1: Rc<str> = v1.clone();
            let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v3: Rc<str> = Rc::<str>::from(format!("{}{}", v1, v2));
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = Rc::<str>::from(format!("{}{}", v4, v3));
            let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Some"); } LIT.with(|lit| lit.clone()) };
            let mut v7: Rc<str> = Rc::<str>::from(format!("{}{}", v6, v5));
            v7.clone()
        }
    }
}
fn method85(mut v0: US6) -> Rc<str> {
    match &v0 {
        US6::US6_Error(v28, v29) => {
            let mut v28: u8 = *v28;
            let mut v29: US5 = v29.clone();
            let mut v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v33: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let mut v36: Rc<str> = Rc::<str>::from(format!("{:?}", v28));
            let mut v37: Rc<str> = Rc::<str>::from(format!("{}{}", v35, v36));
            let mut v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v39: Rc<str> = Rc::<str>::from(format!("{}{}", v37, v38));
            let mut v40: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let mut v41: Rc<str> = Rc::<str>::from(format!("{}{}", v39, v40));
            let mut v42: Rc<str> = Rc::<str>::from(format!("{}{}", v41, v34));
            let mut v43: Rc<str> = method86(v29.clone());
            let mut v44: Rc<str> = Rc::<str>::from(format!("{}{}", v42, v43));
            let mut v45: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v46: Rc<str> = Rc::<str>::from(format!("{}{}", v45, v44));
            let mut v47: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let mut v48: Rc<str> = Rc::<str>::from(format!("{}{}", v46, v47));
            let mut v49: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v50: Rc<str> = Rc::<str>::from(format!("{}{}", v48, v49));
            let mut v51: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v52: Rc<str> = Rc::<str>::from(format!("{}{}", v51, v50));
            let mut v53: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Error"); } LIT.with(|lit| lit.clone()) };
            let mut v54: Rc<str> = Rc::<str>::from(format!("{}{}", v53, v52));
            v54.clone()
        }
        US6::US6_Ok(v1, v2) => {
            let mut v1: u8 = *v1;
            let mut v2: US5 = v2.clone();
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry"); } LIT.with(|lit| lit.clone()) };
            let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
            let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("retry = "); } LIT.with(|lit| lit.clone()) };
            let mut v9: Rc<str> = Rc::<str>::from(format!("{:?}", v1));
            let mut v10: Rc<str> = Rc::<str>::from(format!("{}{}", v8, v9));
            let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("; "); } LIT.with(|lit| lit.clone()) };
            let mut v12: Rc<str> = Rc::<str>::from(format!("{}{}", v10, v11));
            let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("error"); } LIT.with(|lit| lit.clone()) };
            let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v12, v13));
            let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v7));
            let mut v16: Rc<str> = method86(v2.clone());
            let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
            let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{ "); } LIT.with(|lit| lit.clone()) };
            let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v18, v17));
            let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" }"); } LIT.with(|lit| lit.clone()) };
            let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
            let mut v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let mut v23: Rc<str> = Rc::<str>::from(format!("{}{}", v21, v22));
            let mut v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let mut v25: Rc<str> = Rc::<str>::from(format!("{}{}", v24, v23));
            let mut v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Ok"); } LIT.with(|lit| lit.clone()) };
            let mut v27: Rc<str> = Rc::<str>::from(format!("{}{}", v26, v25));
            v27.clone()
        }
    }
}
fn format_real_83(mut v0: US6) -> Rc<str> {
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
    let mut v12: Rc<str> = format_real_14(v9);
    let mut v13: Rc<str> = Rc::<str>::from(format!("{}{}", v11, v12));
    let mut v14: Rc<str> = Rc::<str>::from(format!("{}{}", v13, v7));
    let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", v14, v10));
    let mut v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral_wasm.run"); } LIT.with(|lit| lit.clone()) };
    let mut v17: Rc<str> = Rc::<str>::from(format!("{}{}", v15, v16));
    let mut v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" / "); } LIT.with(|lit| lit.clone()) };
    let mut v19: Rc<str> = Rc::<str>::from(format!("{}{}", v17, v18));
    let mut v20: Rc<str> = format_real_83(v8.clone());
    let mut v21: Rc<str> = Rc::<str>::from(format!("{}{}", v19, v20));
    method11(v21.clone())
}
fn format_real_87(mut v0: US6, mut v1: US5) -> Rc<str> {
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
fn run_24(mut v0: clap::ArgMatches) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> {
    let mut v2: bool = true; let __future_init = Box::pin(/*;
    let mut v4: bool = */ async move { /*;
    let mut v6: bool = */ ();
    let mut v7: Rc<str> = method25();
    let mut v9: &str = &*v7;
    let mut v11: Option<std::string::String> = clap::ArgMatches::get_one(&v0, v9).cloned();
    let mut v12: Option<std::string::String> = method2(v11.clone());
    let mut v13: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v14: Option<US0> = v12.map(|x| v13(x));
    let mut v15: US0 = US0::US0_None;
    let mut v16: US0 = v14.unwrap_or(v15);
    let mut v20: std::string::String = match &v16 {
        US0::US0_None => {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_Some(v17) => {
            let mut v17: std::string::String = v17.clone();
            v17.clone()
        }
    };
    let mut v22: Rc<str> = Rc::<str>::from(String::as_str(&v20));
    let mut v24: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v24); };
    let mut v26: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v27, mut v28, mut v29, mut v30, mut v31, mut v32): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v26) };
    let mut v33: US3 = v31.borrow().l0.clone();
    let mut v38: i32 = match &v33 {
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
        US4::US4_None
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
        US4::US4_Some(v58.clone(), v59.clone(), v60.clone(), v61.clone(), v62.clone(), v63.clone())
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
        US4::US4_None
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
        US4::US4_Some(v130.clone(), v131.clone(), v132.clone(), v133.clone(), v134.clone(), v135.clone())
    };
    let mut v172: Result<u8, anyhow::Error> = match &v96 {
        US6::US6_Error(v164, v165) => {
            let mut v164: u8 = *v164;
            let mut v165: US5 = v165.clone();
            let mut v166: Rc<str> = format_real_87(v96.clone(), v165.clone());
            let mut v168: anyhow::Error = anyhow::anyhow!("{}", v166);
            let mut v170: Result<u8, anyhow::Error> = Err(v168);
            v170
        }
        US6::US6_Ok(v161, v162) => {
            let mut v161: u8 = *v161;
            let mut v162: US5 = v162.clone();
            let mut v163: Result<u8, anyhow::Error> = Ok::<u8, anyhow::Error>(v161);
            v163
        }
    };
    let mut v173: bool = true; (v172) }); //;
    let mut v175: _ = __future_init;
    let mut v177: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = v175;
    v177
}
fn ok_c16() -> Rc<dyn Fn(u8) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(u8) -> US8> = Rc::new(move |mut v0: u8| -> US8 {
        US8::US8_Ok(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method88() -> Rc<dyn Fn(u8) -> US8> {
    ok_c16()
}
fn error_c17() -> Rc<dyn Fn(std::string::String) -> US8> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::string::String) -> US8> = Rc::new(move |mut v0: std::string::String| -> US8 {
        US8::US8_Error(v0.clone())
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method89() -> Rc<dyn Fn(std::string::String) -> US8> {
    error_c17()
}
fn spiral_main() -> i32 {
    let mut v0: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(std::env::args().skip(1).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
    let mut v1: clap::Command = get_command_0();
    let mut v3: clap::ArgMatches = clap::Command::get_matches(v1);
    let mut v4: Rc<str> = method1();
    let mut v6: &str = &*v4;
    let mut v8: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v6).cloned();
    let mut v9: Option<std::string::String> = method2(v8.clone());
    let mut v10: Rc<dyn Fn((std::string::String)) -> US0> = closure1();
    let mut v11: Option<US0> = v9.map(|x| v10(x));
    let mut v12: US0 = US0::US0_None;
    let mut v13: US0 = v11.unwrap_or(v12);
    let mut v63: US1 = match &v13 {
        US0::US0_None => {
            US1::US1_None
        }
        US0::US0_Some(v14) => {
            let mut v14: std::string::String = v14.clone();
            let mut v16: Rc<str> = Rc::<str>::from(String::as_str(&v14));
            ;
            ;
            ;
            ;
            ;
            let mut v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Critical"); } LIT.with(|lit| lit.clone()) };
            let mut v18: Rc<str> = Rc::<str>::from(v17.to_lowercase());
            let mut v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Warning"); } LIT.with(|lit| lit.clone()) };
            let mut v20: Rc<str> = Rc::<str>::from(v19.to_lowercase());
            let mut v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Info"); } LIT.with(|lit| lit.clone()) };
            let mut v22: Rc<str> = Rc::<str>::from(v21.to_lowercase());
            let mut v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Debug"); } LIT.with(|lit| lit.clone()) };
            let mut v24: Rc<str> = Rc::<str>::from(v23.to_lowercase());
            let mut v25: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Verbose"); } LIT.with(|lit| lit.clone()) };
            let mut v26: Rc<str> = Rc::<str>::from(v25.to_lowercase());
            let mut v27: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new(Vec::new()));
            let mut v28: US3 = US3::US3_Verbose;
            v27.borrow_mut().push((v25.clone(), v28.clone()));
            let mut v29: US3 = US3::US3_Debug;
            v27.borrow_mut().push((v23.clone(), v29.clone()));
            let mut v30: US3 = US3::US3_Info;
            v27.borrow_mut().push((v21.clone(), v30.clone()));
            let mut v31: US3 = US3::US3_Warning;
            v27.borrow_mut().push((v19.clone(), v31.clone()));
            let mut v32: US3 = US3::US3_Critical;
            v27.borrow_mut().push((v17.clone(), v32.clone()));
            let mut v33: US3 = US3::US3_Verbose;
            v27.borrow_mut().push((v26.clone(), v33.clone()));
            let mut v34: US3 = US3::US3_Debug;
            v27.borrow_mut().push((v24.clone(), v34.clone()));
            let mut v35: US3 = US3::US3_Info;
            v27.borrow_mut().push((v22.clone(), v35.clone()));
            let mut v36: US3 = US3::US3_Warning;
            v27.borrow_mut().push((v20.clone(), v36.clone()));
            let mut v37: US3 = US3::US3_Critical;
            v27.borrow_mut().push((v18.clone(), v37.clone()));
            let mut v38: Rc<Vec<(Rc<str>, US3)>> = Rc::new(v27.borrow().clone());
            let mut v39: Rc<RefCell<Vec<(Rc<str>, US3)>>> = Rc::new(RefCell::new((v38).as_ref().clone()));
            let mut v40: i32 = (v39.clone().borrow().len() as i32);
            let mut v41: US2 = US2::US2_None;
            let mut v42: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v41.clone() }));
            while method3(v40, v42.clone()) {
                let mut v44: i32 = v42.borrow().l0.clone();
                let mut v45: i32 = v44.wrapping_neg();
                let mut v46: i32 = v45.wrapping_add(v40);
                let mut v47: i32 = v46.wrapping_sub(1i32);
                let mut v48: US2 = v42.borrow().l1.clone();
                let (mut v49, mut v50): (Rc<str>, US3) = v39.clone().borrow()[v47 as usize].clone();
                let mut v57: US2 = match &v48 {
                    US2::US2_None => {
                        let mut v52: bool = v49 == v16 ;
                        if v52 {
                            US2::US2_Some(v50.clone())
                        } else {
                            US2::US2_None
                        }
                    }
                    US2::US2_Some(v51) => {
                        let mut v51: US3 = v51.clone();
                        v48.clone()
                    }
                };
                let mut v58: i32 = v44.wrapping_add(1i32);
                v42.borrow_mut().l0 = v58;
                v42.borrow_mut().l1 = v57.clone();
                ()
            };
            let mut v59: US2 = v42.borrow().l1.clone();
            US1::US1_Some(v59.clone())
        }
    };
    let mut v70: US2 = match &v63 {
        US1::US1_Some(v64) => {
            let mut v64: US2 = v64.clone();
            match &v64 {
                US2::US2_Some(v65) => {
                    let mut v65: US3 = v65.clone();
                    US2::US2_Some(v65.clone())
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
    let mut v74: US3 = match &v70 {
        US2::US2_None => {
            US3::US3_Verbose
        }
        US2::US2_Some(v71) => {
            let mut v71: US3 = v71.clone();
            v71.clone()
        }
    };
    let mut v76: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c2(v74.clone());
    { let _ = spiral_trace_hold(&v76); };
    let mut v78: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c4(v74.clone());
    let (mut v79, mut v80, mut v81, mut v82, mut v83, mut v84): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v78) };
    let mut v86: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c5();
    { let _ = spiral_trace_hold(&v86); };
    let mut v88: Rc<dyn Fn() -> (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>)> = fresh_c6();
    let (mut v89, mut v90, mut v91, mut v92, mut v93, mut v94): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v88) };
    let mut v95: US3 = v93.borrow().l0.clone();
    let mut v100: i32 = match &v95 {
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
    let mut v101: bool = v91.borrow().l0.clone();
    let mut v102: bool = v101 == false;
    let mut v104: bool = if v102 {
        false
    } else {
        let mut v103: bool = 10i32 >= v100;
        v103
    };
    let mut v105: bool = v104 == false;
    let mut v150: US4 = if v105 {
        US4::US4_None
    } else {
        { let _ = spiral_trace_hold(&v86); };
        let (mut v109, mut v110, mut v111, mut v112, mut v113, mut v114): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v88) };
        let mut v115: Rc<str> = method6(v109.clone(), v110.clone(), v111.clone(), v112.clone(), v113.clone(), v114.clone());
        let mut v116: Rc<str> = method7();
        let mut v117: Rc<str> = method10(v109.clone(), v110.clone(), v111.clone(), v112.clone(), v113.clone(), v114.clone(), v115.clone(), v116.clone(), v0.clone());
        { let _ = spiral_trace_hold(&v86); };
        let (mut v120, mut v121, mut v122, mut v123, mut v124, mut v125): (Rc<RefCell<Mut1>>, Rc<RefCell<Mut2>>, Rc<RefCell<Mut3>>, Rc<RefCell<Mut4>>, Rc<RefCell<Mut5>>, Option<i64>) = { spiral_trace_hold(&v88) };
        let mut v126: i64 = v120.borrow().l0.clone();
        let mut v127: i64 = v126.wrapping_add(1i64);
        v120.borrow_mut().l0 = v127;
        let mut v128: Rc<dyn Fn(Rc<str>) -> ()> = closure7();
        let mut v129: bool = cfg!(target_arch = "wasm32");
        if v129 {
            let mut v130: Rc<str> = v123.borrow().l0.clone();
            let mut v131: bool = v130.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v139: Rc<str> = if v131 {
                v117.clone()
            } else {
                let mut v132: bool = v117.clone() == { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                if v132 {
                    let mut v133: Rc<str> = v123.borrow().l0.clone();
                    v133.clone()
                } else {
                    let mut v134: Rc<str> = v123.borrow().l0.clone();
                    let mut v135: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let mut v136: Rc<str> = Rc::<str>::from(format!("{}{}", v134, v135));
                    let mut v137: Rc<str> = Rc::<str>::from(format!("{}{}", v136, v117));
                    v137.clone()
                }
            };
            let mut v141: i32 = ((v139.chars().count() + 14999) / 15000) as i32;
            let mut v142: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let mut v143: bool = v117 != v142 ;
            let mut v145: bool = if v143 {
                let mut v144: bool = v141 <= 1i32;
                v144
            } else {
                false
            };
            if v145 {
                v123.borrow_mut().l0 = v139.clone();
                ()
            } else {
                v123.borrow_mut().l0 = v142.clone();
                { #[cfg(target_arch = "wasm32")] spiral_trace_near_log(&v139); };
                ()
            }
        } else {
            println!("{}", v117);
            ()
        };
        let mut v148: Rc<dyn Fn(Rc<str>) -> ()> = v121.borrow().l0.clone();
        v148(v117.clone());
        US4::US4_Some(v120.clone(), v121.clone(), v122.clone(), v123.clone(), v124.clone(), v125.clone())
    };
    let mut v151: Rc<str> = method20();
    let mut v153: &str = &*v151;
    let mut v155: Option<std::string::String> = clap::ArgMatches::get_one(&v3, v153).cloned();
    let mut v156: Option<std::string::String> = method2(v155.clone());
    let mut v157: Rc<dyn Fn((std::string::String)) -> Rc<str>> = closure8();
    let mut v158: Option<Rc<str>> = v156.map(|x| v157(x));
    let mut v159: Option<Rc<str>> = method23(v158.clone());
    let mut v160: Rc<dyn Fn((Rc<str>)) -> US5> = closure9();
    let mut v161: Option<US5> = v159.map(|x| v160(x));
    let mut v162: US5 = US5::US5_None;
    let mut v163: US5 = v161.unwrap_or(v162);
    let mut v164: std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>> = run_24(v3.clone());
    let mut v166: _ = tokio::runtime::Builder::new_multi_thread().enable_all().build().unwrap();
    let mut v168: Result<u8, anyhow::Error> = v166.handle().block_on(v164);
    let mut v169: Rc<dyn Fn(anyhow::Error) -> std::string::String> = method72();
    let mut v171: Result<u8, std::string::String> = v168.map_err(|x| v169(x));
    let mut v173: Result<u8, std::string::String> = v171.clone();
    let mut v174: Rc<dyn Fn(u8) -> US8> = method88();
    let mut v175: Rc<dyn Fn(std::string::String) -> US8> = method89();
    let mut v176: US8 = match v173 { Ok(x) => v174(x), Err(e) => v175(e) };
    match &v176 {
        US8::US8_Error(v183) => {
            let mut v183: std::string::String = v183.clone();
            match &v163 {
                US5::US5_Some(v184) => {
                    let mut v184: Rc<str> = v184.clone();
                    let mut v185: bool = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) } == v184.clone();
                    if v185 {
                        ()
                    } else {
                        let mut v187: Rc<str> = Rc::<str>::from(String::as_str(&v183));
                        let mut v188: bool = v187.contains(&*v184);
                        if v188 {
                            ()
                        } else {
                            let mut v189: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / exception: '{}' / error: {}", v184, v183));
                            let mut v191: Result<(), Rc<str>> = Err(v189);
                            v191.unwrap();
                            ()
                        }
                    }
                }
                _ => {
                    let mut v194: u8 = v171.unwrap();
                    ()
                }
            }
        }
        US8::US8_Ok(v177) => {
            let mut v177: u8 = *v177;
            match &v163 {
                US5::US5_Some(v178) => {
                    let mut v178: Rc<str> = v178.clone();
                    let mut v179: Rc<str> = Rc::<str>::from(format!("spiral_wasm.main / retries: {} / exception: '{}'", v177, v178));
                    let mut v181: Result<(), Rc<str>> = Err(v179);
                    v181.unwrap();
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
