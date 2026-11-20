#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)] #![recursion_limit = "256"]
use std::cell::RefCell;
use std::rc::Rc;
pub fn cells_budget_walk(root: &str) -> std::rc::Rc<str> {
    fn walk(p: &std::path::Path, top: bool, out: &mut Vec<String>) {
        let meta = if top { std::fs::metadata(p) } else { std::fs::symlink_metadata(p) };
        let Ok(meta) = meta else { return };
        if meta.is_dir() {
            let skip = ["target", "node_modules", "deps", "bin", "obj", "_build", ".git", ".history"];
            if !top && p.file_name().map(|n| skip.contains(&n.to_string_lossy().as_ref())).unwrap_or(false) { return }
            let mut entries: Vec<std::path::PathBuf> = std::fs::read_dir(p).map(|es| es.flatten().map(|e| e.path()).collect()).unwrap_or_default();
            entries.sort();
            for path in entries { walk(&path, false, out) }
        } else if meta.is_file() && (top || p.extension().map(|x| x == "spi" || x == "spir" || x == "livemd").unwrap_or(false)) {
            out.push(p.to_string_lossy().replace('\\', "/"))
        }
    }
    let mut out = Vec::new();
    walk(std::path::Path::new(root), true, &mut out);
    out.sort();
    out.dedup();
    out.join("\n").into()
}
pub fn cells_budget_imports(file: &str, source: &str) -> std::rc::Rc<str> {
    let lib = std::env::var("SPIRAL_LIB").map(std::path::PathBuf::from).unwrap_or_else(|_| std::env::current_exe().ok().and_then(|e| e.ancestors().nth(6).map(|p| p.join("lib").join("spiral"))).unwrap_or_default());
    let dir = std::path::Path::new(file).parent().map(|p| p.to_path_buf()).unwrap_or_default();
    let mut out = Vec::new();
    for line in source.lines() {
        let Some(rest) = line.strip_prefix(":<") else { continue };
        let name_start = rest.trim_start();
        if name_start.len() == rest.len() { continue }
        let name: String = name_start.chars().take_while(|c| c.is_ascii_alphanumeric() || *c == '_' || *c == '\'').collect();
        if !name.chars().next().map(|c| c.is_ascii_lowercase() || c == '_').unwrap_or(false) { continue }
        for candidate in [dir.join(format!("{name}.spi")), lib.join(format!("{name}.spi"))] {
            if candidate.is_file() { out.push(candidate.to_string_lossy().replace('\\', "/")) }
        }
    }
    out.join("\n").into()
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
#[derive(Clone)]
enum UH0 {
    UH0_Nil,
    UH0_Cons(Rc<str>, Rc<UH0>),
}
#[derive(Clone)]
enum US0 {
    US0_Some(Rc<str>),
    US0_None,
}
#[derive(Clone)]
enum US1 {
    US1_Some(i32),
    US1_None,
}
pub struct Mut0 { pub l0: i32, pub l1: Rc<UH0> }
#[derive(Clone)]
enum UH1 {
    UH1_Nil,
    UH1_Cons(Rc<str>, Rc<str>, Rc<UH1>),
}
#[derive(Clone)]
enum UH2 {
    UH2_Nil,
    UH2_Cons(i32, Rc<UH2>),
}
#[derive(Clone)]
enum US2 {
    US2_Listed(Rc<UH0>),
    US2_Iana,
}
#[derive(Clone)]
enum US4 {
    US4_OverBudget(i32, i32, i32),
}
#[derive(Clone)]
enum US5 {
    US5_OverRuled(i32, i32, i32),
}
#[derive(Clone)]
enum US7 {
    US7_Hashtag,
    US7_Mention,
    US7_Cashtag,
    US7_Autolink,
}
#[derive(Clone)]
enum US6 {
    US6_Rewritten(US7, i32, i32, Rc<str>),
}
#[derive(Clone)]
enum US3 {
    US3_BudgetFinding(US4),
    US3_RuledFinding(US5),
    US3_RewriteFinding(US6),
}
#[derive(Clone)]
enum UH3 {
    UH3_Nil,
    UH3_Cons(US3, Rc<UH3>),
}
#[derive(Clone)]
enum UH4 {
    UH4_Nil,
    UH4_Cons(i32, Rc<str>, Rc<UH4>),
}
#[derive(Clone)]
enum UH5 {
    UH5_Nil,
    UH5_Cons(i32, Rc<str>, Rc<UH5>),
}
#[derive(Clone)]
enum UH6 {
    UH6_Nil,
    UH6_Cons(Rc<UH2>, Rc<UH6>),
}
#[derive(Clone)]
enum UH7 {
    UH7_Nil,
    UH7_Cons(Rc<str>, Rc<UH0>, Rc<UH7>),
}
#[derive(Clone)]
enum US8 {
    US8_Some(Rc<UH0>, Rc<UH0>),
    US8_None,
}
#[derive(Clone)]
enum US9 {
    US9_Flat(Rc<str>, Rc<UH0>),
    US9_NotFlat,
}
#[derive(Clone)]
enum US10 {
    US10_Some(Rc<UH2>, Rc<UH2>),
    US10_None,
}
#[derive(Clone)]
enum US11 {
    US11_Some(Rc<UH2>),
    US11_None,
}
#[derive(Clone)]
enum US12 {
    US12_Body(Rc<UH0>),
    US12_NoHeader,
}
pub struct Mut1 { pub l0: Rc<str> }
#[derive(Clone)]
enum UH8 {
    UH8_Nil,
    UH8_Cons(US7, i32, i32, Rc<str>, Rc<UH8>),
}
#[derive(Clone)]
enum UH9 {
    UH9_Nil,
    UH9_Cons(Rc<UH8>, Rc<UH9>),
}
#[derive(Clone)]
enum US13 {
    US13_Some(US7, Rc<UH2>, Rc<UH2>),
    US13_None,
}
#[derive(Clone)]
enum UH10 {
    UH10_Nil,
    UH10_Cons(Rc<str>, i32, Rc<UH10>),
}
#[derive(Clone)]
enum US14 {
    US14_CodeKind,
    US14_DataKind,
    US14_TemplateKind,
    US14_TypeKind,
    US14_TestKind,
}
#[derive(Clone)]
enum UH11 {
    UH11_Nil,
    UH11_Cons(US14, bool, i32, Rc<UH11>),
}
fn command_line_argument_count_1() -> i32 {
    let mut backend_v0: usize = std::env::args().count();
    let x_v1: i32 = ((backend_v0) as i32);
    let mut v2: i32 = x_v1.wrapping_sub(1i32);
    v2
}
fn command_line_argument_2(mut v0: i32) -> Rc<str> {
    let x_v1: i32 = v0.wrapping_add(1i32);
    let x_v2: usize = ((x_v1) as usize);
    let mut v3: Rc<str> = Rc::<str>::from(std::env::args().nth(x_v2).unwrap_or_default());
    v3
}
fn arguments_from_0(mut index_v0: i32) -> Rc<UH0> {
    let mut v1: bool = index_v0 >= 0i32;
    let mut v4: bool = if v1 {
        let mut v2: i32 = command_line_argument_count_1();
        let mut v3: bool = index_v0 < v2;
        v3
    } else {
        false
    };
    let mut v8: US0 = if v4 {
        let mut v5: Rc<str> = command_line_argument_2(index_v0);
        US0::US0_Some(v5)
    } else {
        US0::US0_None
    };
    match v8 {
        US0::US0_None => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) }
        }
        US0::US0_Some(argument_v10) => {
            let argument_v10: Rc<str> = argument_v10;
            let index_v11: i32 = index_v0.wrapping_add(1i32);
            let mut v12: Rc<UH0> = arguments_from_0(index_v11);
            Rc::new(UH0::UH0_Cons(argument_v10, v12))
        }
    }
}
fn closure0(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    Rc::new(move |mut v1: Rc<UH0>| -> US1 {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                let mut v5: bool = &*v3 == "--version";
                if v5 {
                    US1::US1_Some(v0)
                } else {
                    let mut v7: i32 = v0.wrapping_add(1i32);
                    let mut v8: Rc<dyn Fn(Rc<UH0>) -> US1> = method3(v7);
                    v8(v4)
                }
            }
            UH0::UH0_Nil => {
                US1::US1_None
            }
        }
    })
}
fn method3(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    closure0(v0)
}
fn printed_stamps_4() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c2887404a47b7b686ac349fb85cbdead65b7c3c0c3989954cd3a5e5c69ab7290  apps/cells/spi/cell_budget.spi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v0);
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("54b22ad763c186cbe30067d3b32e0c281f3334d8fb78acfcba355161c563f44d  apps/cells/spi/cell_budget_ruled.spi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v1);
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("b297208d63dab2350bd3a8463a98d286faaf59035e479c6b0dd9172b31fd983d  apps/cells/budget/cell_budget_cli.spi"); } LIT.with(|lit| lit.clone()) };
    println!("{}", v2);
    0i32
}
fn closure1(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    Rc::new(move |mut v1: Rc<UH0>| -> US1 {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                let mut v5: bool = &*v3 == "--check";
                if v5 {
                    US1::US1_Some(v0)
                } else {
                    let mut v7: i32 = v0.wrapping_add(1i32);
                    let mut v8: Rc<dyn Fn(Rc<UH0>) -> US1> = method5(v7);
                    v8(v4)
                }
            }
            UH0::UH0_Nil => {
                US1::US1_None
            }
        }
    })
}
fn method5(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    closure1(v0)
}
fn closure2(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    Rc::new(move |mut v1: Rc<UH0>| -> US1 {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                let mut v5: bool = &*v3 == "--granular";
                if v5 {
                    US1::US1_Some(v0)
                } else {
                    let mut v7: i32 = v0.wrapping_add(1i32);
                    let mut v8: Rc<dyn Fn(Rc<UH0>) -> US1> = method6(v7);
                    v8(v4)
                }
            }
            UH0::UH0_Nil => {
                US1::US1_None
            }
        }
    })
}
fn method6(mut v0: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    closure2(v0)
}
fn method7(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method7(v3, s_v1);
            let mut v5: bool = &*v2 != "--check";
            let mut v7: bool = if v5 {
                let v6: bool = &*v2 != "--granular";
                v6
            } else {
                false
            };
            if v7 {
                Rc::new(UH0::UH0_Cons(v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method9(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method9(v3, s_v1);
            Rc::new(UH0::UH0_Cons(v2, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method11(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method11(v3, s_v1);
            let mut v5: bool = &*v2 != "";
            if v5 {
                Rc::new(UH0::UH0_Cons(v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method13(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(v2, v3) => {
                let mut v2: Rc<str> = v2;
                let mut v3: Rc<UH0> = v3;
                let s_v4: Rc<UH0> = Rc::new(UH0::UH0_Cons(v2, v1));
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn method14(mut v0: i32, mut v1: &Rc<RefCell<Mut0>>) -> bool {
    let mut v2: i32 = v1.borrow().l0;
    let mut v3: bool = v2 < v0;
    v3
}
fn split_list_12(mut backend_v0: Rc<str>, mut backend_v1: Rc<str>) -> Rc<UH0> {
    let mut v2: i32 = (backend_v0.clone().len() as i32);
    let mut v3: bool = v2 == 0i32;
    if v3 {
        let mut v4: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        Rc::new(UH0::UH0_Cons(backend_v1, v4))
    } else {
        let v6: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(backend_v1.split(&*backend_v0).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
        let mut v7: i32 = (v6.clone().borrow().len() as i32);
        let mut v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut s_v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v8 }));
        while method14(v7, &s_v9) {
            let i_v11: i32 = s_v9.borrow().l0;
            let mut v12: Rc<UH0> = s_v9.borrow().l1.clone();
            let mut v13: Rc<str> = v6.borrow()[i_v11 as usize].clone();
            let mut v14: i32 = i_v11.wrapping_add(1i32);
            let mut v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v13, v12));
            s_v9.borrow_mut().l0 = v14;
            s_v9.borrow_mut().l1 = v15;
            ()
        };
        let v16: Rc<UH0> = s_v9.borrow().l1.clone();
        let s_v17: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        method13(v16, s_v17)
    }
}
fn files_of_10(mut v0: Rc<str>) -> Rc<UH0> {
    let s_v1: Rc<str> = cells_budget_walk(&*v0);
    let separator_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<UH0> = split_list_12(separator_v2, s_v1);
    let s_v4: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method11(v3, s_v4)
}
fn method8(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(path_v2, v3) => {
            let path_v2: Rc<str> = path_v2;
            let mut v3: Rc<UH0> = v3;
            let s_v4: Rc<UH0> = method8(v3, s_v1);
            let mut v5: Rc<UH0> = files_of_10(path_v2);
            method9(v5, s_v4)
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method16(mut v0: Rc<UH1>, mut s_v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v0) {
        UH1::UH1_Cons(v2, v3, v4) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<str> = v3;
            let mut v4: Rc<UH1> = v4;
            let mut v5: Rc<UH1> = method16(v4, s_v1);
            Rc::new(UH1::UH1_Cons(v2, v3, v5))
        }
        UH1::UH1_Nil => {
            s_v1
        }
    }
}
fn method20(mut v0: Rc<RefCell<Vec<Rc<str>>>>, mut v1: Rc<UH0>, mut v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                v0.borrow_mut().push(v3);
                let s_v5: i32 = v2.wrapping_add(1i32);
                (v1, v2) = (v4, s_v5);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn row_of_19(mut s_v0: Rc<str>) -> (Rc<str>, Rc<str>) {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1.clone(), s_v0.clone());
    match Rc::unwrap_or_clone(v2) {
        UH0::UH0_Cons(v3, backend_v4) => {
            let mut v3: Rc<str> = v3;
            let backend_v4: Rc<UH0> = backend_v4;
            let acc_v5: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
            let s_v6: i32 = 0i32;
            let mut v7: i32 = method20(acc_v5.clone(), backend_v4, s_v6);
            let backend_v8: Rc<Vec<Rc<str>>> = Rc::new(acc_v5.borrow().clone());
            let items_v9: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v8).as_ref().clone()));
            let v10: Rc<str> = Rc::<str>::from((*items_v9.borrow()).join(&*separator_v1));
            (v3, v10)
        }
        UH0::UH0_Nil => {
            let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            (v11, s_v0)
        }
    }
}
fn method18(mut v0: Rc<UH0>, mut s_v1: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(row_v2, v3) => {
            let row_v2: Rc<str> = row_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH1> = method18(v3, s_v1);
            let (mut v5, mut v6): (Rc<str>, Rc<str>) = row_of_19(row_v2);
            Rc::new(UH1::UH1_Cons(v5, v6, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method21(mut v0: Vec<u8>) -> Vec<u8> {
    v0
}
fn method25(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method25(v3, s_v1);
            let mut v5: bool = &*v2 != "";
            if v5 {
                Rc::new(UH0::UH0_Cons(v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn lines_of_24(mut s_v0: Rc<str>) -> Rc<UH0> {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1, s_v0);
    let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method25(v2, s_v3)
}
fn tail_after_30(mut backend_v0: i32, mut backend_v1: Rc<str>) -> Rc<str> {
    let n_v2: i32 = (backend_v1.clone().len() as i32);
    let mut v3: bool = backend_v0 >= n_v2;
    if v3 {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v4
    } else {
        let backend_v5: i32 = n_v2.wrapping_sub(backend_v0);
        let x_v6: usize = ((backend_v0) as usize);
        let backend_v7: i32 = backend_v0.wrapping_add(backend_v5);
        let x_v8: usize = ((backend_v7) as usize);
        let mut v9: Rc<str> = Rc::<str>::from(&(backend_v1)[x_v6..x_v8]);
        v9
    }
}
fn ascii_letter_33(mut v0: i32) -> bool {
    let mut v1: bool = v0 >= 65i32;
    let mut v3: bool = if v1 {
        let mut v2: bool = v0 <= 90i32;
        v2
    } else {
        false
    };
    if v3 {
        true
    } else {
        let mut v4: bool = v0 >= 97i32;
        if v4 {
            let mut v5: bool = v0 <= 122i32;
            v5
        } else {
            false
        }
    }
}
fn ascii_alnum_32(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_letter_33(c_v0);
    if v1 {
        true
    } else {
        let mut v2: bool = c_v0 >= 48i32;
        if v2 {
            let mut v3: bool = c_v0 <= 57i32;
            v3
        } else {
            false
        }
    }
}
fn word_char_31(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_alnum_32(c_v0);
    if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 95i32;
        v2
    }
}
fn closure3() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        let mut v1: bool = word_char_31(v0);
        if v1 {
            true
        } else {
            let mut v2: bool = v0 == 39i32;
            v2
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method34(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v2 >= v1;
        if v3 {
            return v1;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v5: bool = v4 == b' ';
            let mut v7: bool = if v5 {
                true
            } else {
                let v6: bool = v4 == b'\t';
                v6
            };
            if v7 {
                let i_v8: i32 = v2.wrapping_add(1i32);
                v2 = i_v8;
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn method35(mut v0: Rc<Vec<char>>, mut v1: i32, mut backend_v2: i32, mut v3: Rc<UH2>) -> Rc<UH2> {
    loop {
        let mut v4: bool = backend_v2 >= v1;
        if v4 {
            return v3;
        } else {
            let x_v5: usize = ((backend_v2) as usize);
            let item_v6: char = (v0)[x_v5].clone();
            let i_v7: i32 = backend_v2.wrapping_add(1i32);
            let mut v8: u32 = u32::from(item_v6);
            let mut v9: i32 = (v8 as i32);
            let acc_v10: Rc<UH2> = Rc::new(UH2::UH2_Cons(v9, v3));
            (backend_v2, v3) = (i_v7, acc_v10);
            continue;
        }
    }
}
fn method37(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v2, v3) => {
                let mut v2: i32 = v2;
                let mut v3: Rc<UH2> = v3;
                let s_v4: Rc<UH2> = Rc::new(UH2::UH2_Cons(v2, v1));
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH2::UH2_Nil => {
                return v1;
            }
        }
    }
}
fn run_while_36(mut f_v0: Rc<dyn Fn(i32) -> bool>, mut v1: Rc<UH2>, mut v2: Rc<UH2>) -> (Rc<UH2>, Rc<UH2>) {
    loop {
        match &*v1 {
            UH2::UH2_Nil => {
                let s_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                let mut v4: Rc<UH2> = method37(v2, s_v3);
                let mut v5: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                return (v4, v5);
            }
            _ => {
                match &*v1 {
                    UH2::UH2_Cons(v6, cps_v7) => {
                        let v6: i32 = *v6;
                        let cps_v7: Rc<UH2> = cps_v7.clone();
                        let mut v8: bool = f_v0(v6);
                        if v8 {
                            let acc_v9: Rc<UH2> = Rc::new(UH2::UH2_Cons(v6, v2));
                            (v1, v2) = (cps_v7, acc_v9);
                            continue;
                        } else {
                            let s_v12: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                            let mut v13: Rc<UH2> = method37(v2, s_v12);
                            return (v13, v1);
                        }
                    }
                    _ => unreachable!(),
                }
            }
        }
    }
}
fn first_point_38(mut v0: &Rc<UH2>) -> i32 {
    match &**v0 {
        UH2::UH2_Cons(v1, _) => {
            let mut v1: i32 = *v1;
            v1
        }
        UH2::UH2_Nil => {
            -1i32
        }
    }
}
fn method40(mut v0: Rc<UH2>, mut a_v1: Rc<str>) -> Rc<str> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(backend_v2, v3) => {
                let backend_v2: i32 = backend_v2;
                let mut v3: Rc<UH2> = v3;
                let mut v4: bool = backend_v2 >= 0i32;
                let v6: bool = if v4 {
                    let mut v5: bool = backend_v2 <= 1114111i32;
                    v5
                } else {
                    false
                };
                let v10: bool = if v6 {
                    let mut v7: bool = backend_v2 < 55296i32;
                    if v7 {
                        true
                    } else {
                        let mut v8: bool = backend_v2 > 57343i32;
                        v8
                    }
                } else {
                    false
                };
                let b_v17: Rc<str> = if v10 {
                    let c_v11: u32 = (backend_v2 as u32);
                    let mut v12: Option<char> = char::from_u32(c_v11);
                    let backend_v14: char = v12.unwrap();
                    let mut v15: Rc<str> = Rc::<str>::from(format!("{}", backend_v14));
                    v15
                } else {
                    let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                    v16
                };
                let s_v18: Rc<str> = string_concat(&[&*a_v1, &*b_v17]);
                (v0, a_v1) = (v3, s_v18);
                continue;
            }
            UH2::UH2_Nil => {
                return a_v1;
            }
        }
    }
}
fn written_of_39(mut v0: Rc<UH2>) -> Rc<str> {
    let s_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    method40(v0, s_v1)
}
fn nominal_of_29(mut s_v0: Rc<str>) -> US0 {
    let at_v1: i32 = 2i32;
    let rest_v2: Rc<str> = tail_after_30(at_v1, s_v0.clone());
    let f_v3: Rc<dyn Fn(i32) -> bool> = closure3();
    let len_v4: i32 = (rest_v2.clone().len() as i32);
    let i_v5: i32 = 0i32;
    let backend_v6: i32 = method34(rest_v2.clone(), len_v4, i_v5);
    let backend_v7: i32 = len_v4.wrapping_sub(1i32);
    let backend_v8: Rc<str> = string_slice(&rest_v2.clone(), backend_v6 as i64, backend_v7 as i64);
    let backend_v9: Rc<Vec<char>> = Rc::new((&*backend_v8).chars().collect());
    let backend_v10: Rc<Vec<char>> = Rc::new((backend_v9).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v11: usize = (backend_v10).len();
    let x_v12: i32 = ((backend_v11) as i32);
    let i_v13: i32 = 0i32;
    let acc_v14: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v15: Rc<UH2> = method35(backend_v10, x_v12, i_v13, acc_v14);
    let acc_v16: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut name_v17, mut v18): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v3, cps_v15, acc_v16);
    let first_v19: i32 = first_point_38(&name_v17);
    let search_v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":!"); } LIT.with(|lit| lit.clone()) };
    let v21: bool = s_v0.starts_with(&*search_v20);
    let v27: bool = if v21 {
        let search_v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let v23: bool = rest_v2.starts_with(&*search_v22);
        if v23 {
            true
        } else {
            let search_v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t"); } LIT.with(|lit| lit.clone()) };
            let v25: bool = rest_v2.starts_with(&*search_v24);
            v25
        }
    } else {
        false
    };
    let v33: bool = if v27 {
        let v28: bool = first_v19 >= 97i32;
        let v30: bool = if v28 {
            let v29: bool = first_v19 <= 122i32;
            v29
        } else {
            false
        };
        if v30 {
            true
        } else {
            let v31: bool = first_v19 == 95i32;
            v31
        }
    } else {
        false
    };
    if v33 {
        let v34: Rc<str> = written_of_39(name_v17);
        US0::US0_Some(v34)
    } else {
        US0::US0_None
    }
}
fn method28(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(line_v2, v3) => {
                let line_v2: Rc<str> = line_v2;
                let mut v3: Rc<UH0> = v3;
                let mut v4: US0 = nominal_of_29(line_v2);
                let s_v8: Rc<UH0> = match v4 {
                    US0::US0_None => {
                        v1
                    }
                    US0::US0_Some(n_v5) => {
                        let n_v5: Rc<str> = n_v5;
                        Rc::new(UH0::UH0_Cons(n_v5, v1))
                    }
                };
                (v0, v1) = (v3, s_v8);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn declared_nominals_27(mut backend_v0: Rc<str>) -> Rc<UH0> {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let old_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\r\n"); } LIT.with(|lit| lit.clone()) };
    let s_v3: Rc<str> = Rc::<str>::from(backend_v0.replace(&*old_v2, &*separator_v1));
    let mut v4: Rc<UH0> = split_list_12(separator_v1, s_v3);
    let s_v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v6: Rc<UH0> = method28(v4, s_v5);
    let s_v7: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method13(v6, s_v7)
}
fn nominals_wire_26(mut source_v0: Rc<str>) -> Rc<str> {
    let backend_v1: Rc<UH0> = declared_nominals_27(source_v0);
    let acc_v2: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v3: i32 = 0i32;
    let mut v4: i32 = method20(acc_v2.clone(), backend_v1, s_v3);
    let backend_v5: Rc<Vec<Rc<str>>> = Rc::new(acc_v2.borrow().clone());
    let items_v6: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v5).as_ref().clone()));
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = Rc::<str>::from((*items_v6.borrow()).join(&*v7));
    v8
}
fn declared_23(mut source_v0: Rc<str>) -> Rc<UH0> {
    let text_v1: Rc<str> = nominals_wire_26(source_v0);
    lines_of_24(text_v1)
}
fn method42(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let mut v3: Rc<UH0> = v3;
            let s_v4: Rc<UH0> = method42(v3, s_v1);
            let v6: Result<Vec<u8>, std::io::Error> = std::fs::read(&*backend_v2);
            let mut v8: Vec<u8> = v6.unwrap();
            let bytes_v9: Vec<u8> = method21(v8);
            let mut v11: Result<std::string::String, std::string::FromUtf8Error> = std::string::String::from_utf8(bytes_v9);
            let backend_v13: std::string::String = v11.unwrap();
            let source_v15: Rc<str> = Rc::<str>::from(String::as_str(&backend_v13));
            let v16: Rc<UH0> = declared_23(source_v15);
            method9(v16, s_v4)
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn imported_41(mut v0: Rc<str>, mut v1: Rc<str>) -> Rc<UH0> {
    let text_v2: Rc<str> = cells_budget_imports(&*v0, &*v1);
    let mut v3: Rc<UH0> = lines_of_24(text_v2);
    let s_v4: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method42(v3, s_v4)
}
fn closure4(mut v0: Rc<str>, mut v1: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    Rc::new(move |mut v2: Rc<UH0>| -> US1 {
        match Rc::unwrap_or_clone(v2) {
            UH0::UH0_Cons(v4, v5) => {
                let mut v4: Rc<str> = v4;
                let mut v5: Rc<UH0> = v5;
                let v6: bool = &*v4 == &*v0;
                if v6 {
                    US1::US1_Some(v1)
                } else {
                    let mut v8: i32 = v1.wrapping_add(1i32);
                    let mut v9: Rc<dyn Fn(Rc<UH0>) -> US1> = method45(v0.clone(), v8);
                    v9(v5)
                }
            }
            UH0::UH0_Nil => {
                US1::US1_None
            }
        }
    })
}
fn method45(mut v0: Rc<str>, mut v1: i32) -> Rc<dyn Fn(Rc<UH0>) -> US1> {
    closure4(v0, v1)
}
fn method44(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(v2, v3) => {
                let mut v2: Rc<str> = v2;
                let mut v3: Rc<UH0> = v3;
                let i_v4: i32 = 0i32;
                let mut v5: Rc<dyn Fn(Rc<UH0>) -> US1> = method45(v2.clone(), i_v4);
                let body_v6: US1 = v5(v1.clone());
                let mut v7: bool = match body_v6 {
                    US1::US1_None => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v8: bool = v7 != true;
                let s_v10: Rc<UH0> = if v8 {
                    v1
                } else {
                    Rc::new(UH0::UH0_Cons(v2, v1))
                };
                (v0, v1) = (v3, s_v10);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn distinct_43(mut v0: Rc<UH0>) -> Rc<UH0> {
    let s_v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v2: Rc<UH0> = method44(v0, s_v1);
    let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method13(v2, s_v3)
}
fn nominals_of_22(mut path_v0: Rc<str>, mut source_v1: Rc<str>) -> Rc<str> {
    let mut v2: Rc<UH0> = declared_23(source_v1.clone());
    let s_v3: Rc<UH0> = imported_41(path_v0, source_v1);
    let names_v4: Rc<UH0> = method9(v2, s_v3);
    let backend_v5: Rc<UH0> = distinct_43(names_v4);
    let acc_v6: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v7: i32 = 0i32;
    let mut v8: i32 = method20(acc_v6.clone(), backend_v5, s_v7);
    let backend_v9: Rc<Vec<Rc<str>>> = Rc::new(acc_v6.borrow().clone());
    let items_v10: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v9).as_ref().clone()));
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<str> = Rc::<str>::from((*items_v10.borrow()).join(&*v11));
    v12
}
fn wire_list_48(mut s_v0: Rc<str>) -> Rc<UH0> {
    let mut v1: bool = &*s_v0 == "";
    if v1 {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) }
    } else {
        let separator_v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
        split_list_12(separator_v3, s_v0)
    }
}
fn method50(mut v0: Rc<UH3>, mut s_v1: Rc<UH3>) -> Rc<UH3> {
    match Rc::unwrap_or_clone(v0) {
        UH3::UH3_Cons(v2, v3) => {
            let mut v2: US3 = v2;
            let mut v3: Rc<UH3> = v3;
            let mut v4: Rc<UH3> = method50(v3, s_v1);
            Rc::new(UH3::UH3_Cons(v2, v4))
        }
        UH3::UH3_Nil => {
            s_v1
        }
    }
}
fn method53(mut v0: Rc<UH3>, mut v1: Rc<UH3>) -> Rc<UH3> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH3::UH3_Cons(v2, v3) => {
                let mut v2: US3 = v2;
                let mut v3: Rc<UH3> = v3;
                let s_v4: Rc<UH3> = Rc::new(UH3::UH3_Cons(v2, v1));
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH3::UH3_Nil => {
                return v1;
            }
        }
    }
}
fn weight_value_59(mut v0: i32) -> i32 {
    v0
}
fn run_point_65(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_alnum_32(c_v0);
    let mut v3: bool = if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 45i32;
        v2
    };
    let mut v5: bool = if v3 {
        true
    } else {
        let mut v4: bool = c_v0 == 95i32;
        v4
    };
    if v5 {
        true
    } else {
        let v6: bool = c_v0 == 46i32;
        v6
    }
}
fn closure5() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        run_point_65(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method70(mut v0: Rc<UH2>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(_, v3) => {
                let mut v3: Rc<UH2> = v3;
                let s_v4: i32 = v1.wrapping_add(1i32);
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH2::UH2_Nil => {
                return v1;
            }
        }
    }
}
fn method69(mut v0: Rc<UH6>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(v2, v3) => {
                let mut v2: Rc<UH2> = v2;
                let mut v3: Rc<UH6> = v3;
                let s_v4: i32 = 0i32;
                let mut v5: i32 = method70(v2, s_v4);
                let s_v6: i32 = v1.wrapping_add(v5);
                (v0, v1) = (v3, s_v6);
                continue;
            }
            UH6::UH6_Nil => {
                return v1;
            }
        }
    }
}
fn method71(mut v0: Rc<UH6>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(_, v3) => {
                let mut v3: Rc<UH6> = v3;
                let s_v4: i32 = v1.wrapping_add(1i32);
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH6::UH6_Nil => {
                return v1;
            }
        }
    }
}
fn span_68(mut v0: Rc<UH6>) -> i32 {
    let s_v1: i32 = 0i32;
    let mut v2: i32 = method71(v0.clone(), s_v1);
    let s_v3: i32 = v2.wrapping_sub(1i32);
    method69(v0, s_v3)
}
fn method73(mut v0: Rc<UH6>, mut a_v1: Rc<str>) -> Rc<str> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(p_v2, v3) => {
                let p_v2: Rc<UH2> = p_v2;
                let mut v3: Rc<UH6> = v3;
                let mut v4: bool = &*a_v1 == "";
                let mut s_v9: Rc<str> = if v4 {
                    written_of_39(p_v2)
                } else {
                    let b_v7: Rc<str> = written_of_39(p_v2);
                    let mut v8: Rc<str> = string_concat(&[&*a_v1, ".", &*b_v7]);
                    v8
                };
                (v0, a_v1) = (v3, s_v9);
                continue;
            }
            UH6::UH6_Nil => {
                return a_v1;
            }
        }
    }
}
fn written_dotted_72(mut v0: Rc<UH6>) -> Rc<str> {
    let s_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    method73(v0, s_v1)
}
fn counted_67(mut v0: i32, mut v1: i32, mut v2: Rc<UH5>, mut v3: i32, mut ps_v4: Rc<UH6>) -> (i32, i32, Rc<UH5>) {
    let mut v5: i32 = v0.wrapping_add(1i32);
    let v6: i32 = span_68(ps_v4.clone());
    let mut v7: i32 = v1.wrapping_add(v6);
    let mut v8: Rc<str> = written_dotted_72(ps_v4);
    let mut v9: Rc<UH5> = Rc::new(UH5::UH5_Cons(v3, v8, v2));
    (v5, v7, v9)
}
fn method75(mut v0: Rc<UH6>, mut v1: Rc<UH6>) -> Rc<UH6> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(v2, v3) => {
                let mut v2: Rc<UH2> = v2;
                let mut v3: Rc<UH6> = v3;
                let s_v4: Rc<UH6> = Rc::new(UH6::UH6_Cons(v2, v1));
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH6::UH6_Nil => {
                return v1;
            }
        }
    }
}
fn dot_parts_74(mut v0: Rc<UH2>, mut v1: Rc<UH2>, mut acc_v2: Rc<UH6>) -> Rc<UH6> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v8, cps_v9) => {
                let mut v8: i32 = v8;
                let cps_v9: Rc<UH2> = cps_v9;
                let v10: bool = v8 == 46i32;
                if v10 {
                    let cur_v11: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                    let s_v12: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                    let mut v13: Rc<UH2> = method37(v1, s_v12);
                    let acc_v14: Rc<UH6> = Rc::new(UH6::UH6_Cons(v13, acc_v2));
                    (v0, v1, acc_v2) = (cps_v9, cur_v11, acc_v14);
                    continue;
                } else {
                    let cur_v16: Rc<UH2> = Rc::new(UH2::UH2_Cons(v8, v1));
                    (v0, v1) = (cps_v9, cur_v16);
                    continue;
                }
            }
            UH2::UH2_Nil => {
                let s_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                let mut v4: Rc<UH2> = method37(v1, s_v3);
                let mut v5: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
                let s_v6: Rc<UH6> = Rc::new(UH6::UH6_Cons(v4, v5));
                return method75(acc_v2, s_v6);
            }
        }
    }
}
fn nth_78(mut v0: i32, mut v1: Rc<UH6>) -> Rc<UH2> {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH6::UH6_Cons(v3, ps_v4) => {
                let mut v3: Rc<UH2> = v3;
                let ps_v4: Rc<UH6> = ps_v4;
                let mut v5: bool = v0 <= 0i32;
                if v5 {
                    return v3;
                } else {
                    let i_v6: i32 = v0.wrapping_sub(1i32);
                    (v0, v1) = (i_v6, ps_v4);
                    continue;
                }
            }
            UH6::UH6_Nil => {
                return { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
            }
        }
    }
}
fn method81(mut v0: Rc<dyn Fn(i32) -> bool>, mut v1: Rc<UH2>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH2::UH2_Cons(v3, v4) => {
                let mut v3: i32 = v3;
                let mut v4: Rc<UH2> = v4;
                let s_v6: bool = if v2 {
                    v0(v3)
                } else {
                    false
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH2::UH2_Nil => {
                return v2;
            }
        }
    }
}
fn all_points_80(mut v0: Rc<dyn Fn(i32) -> bool>, mut v1: Rc<UH2>) -> bool {
    let s_v2: bool = true;
    method81(v0, v1, s_v2)
}
fn closure6() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        ascii_letter_33(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn tld_79(mut p_v0: Rc<UH2>) -> bool {
    let s_v1: i32 = 0i32;
    let n_v2: i32 = method70(p_v0.clone(), s_v1);
    let mut v3: bool = n_v2 >= 2i32;
    let mut v5: bool = if v3 {
        let mut v4: bool = n_v2 <= 63i32;
        v4
    } else {
        false
    };
    if v5 {
        let f_v6: Rc<dyn Fn(i32) -> bool> = closure6();
        all_points_80(f_v6, p_v0)
    } else {
        false
    }
}
fn wide_word_82(mut v0: i32) -> bool {
    let mut v1: bool = v0 >= 128i32;
    let mut v5: bool = if v1 {
        let mut v2: bool = v0 < 8192i32;
        if v2 {
            true
        } else {
            let mut v3: bool = v0 > 8303i32;
            v3
        }
    } else {
        false
    };
    if v5 {
        let v6: bool = v0 < 12288i32;
        if v6 {
            true
        } else {
            let mut v7: bool = v0 > 12351i32;
            v7
        }
    } else {
        false
    }
}
fn link_end_77(mut ps_v0: Rc<UH6>, mut k_v1: i32, mut v2: i32, mut c_v3: i32) -> i32 {
    loop {
        let mut v4: bool = v2 < 2i32;
        if v4 {
            return 0i32;
        } else {
            let i_v5: i32 = v2.wrapping_sub(1i32);
            let p_v6: Rc<UH2> = nth_78(i_v5, ps_v0.clone());
            let mut v7: bool = tld_79(p_v6);
            let mut v12: bool = if v7 {
                let mut v8: bool = v2 < k_v1;
                if v8 {
                    true
                } else {
                    let mut v9: bool = wide_word_82(c_v3);
                    let v10: bool = v9 == false;
                    v10
                }
            } else {
                false
            };
            if v12 {
                return v2;
            } else {
                v2 = i_v5;
                continue;
            }
        }
    }
}
fn last_point_85(mut v0: Rc<UH2>, mut d_v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v2, p_v3) => {
                let mut v2: i32 = v2;
                let p_v3: Rc<UH2> = p_v3;
                match &*p_v3 {
                    UH2::UH2_Nil => {
                        return v2;
                    }
                    _ => {
                        v0 = p_v3;
                        continue;
                    }
                }
            }
            UH2::UH2_Nil => {
                return d_v1;
            }
        }
    }
}
fn inner_c7() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        let mut v1: bool = ascii_alnum_32(v0);
        let mut v3: bool = if v1 {
            true
        } else {
            let mut v2: bool = v0 == 45i32;
            v2
        };
        if v3 {
            true
        } else {
            let mut v4: bool = v0 == 95i32;
            v4
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn label_84(mut p_v0: Rc<UH2>) -> bool {
    let c_v1: i32 = first_point_38(&p_v0);
    let mut v2: bool = ascii_alnum_32(c_v1);
    let v6: bool = if v2 {
        let d_v3: i32 = 0i32;
        let c_v4: i32 = last_point_85(p_v0.clone(), d_v3);
        ascii_alnum_32(c_v4)
    } else {
        false
    };
    if v6 {
        let f_v7: Rc<dyn Fn(i32) -> bool> = inner_c7();
        all_points_80(f_v7, p_v0)
    } else {
        false
    }
}
fn leading_labels_83(mut v0: Rc<UH6>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(p_v2, ps_v3) => {
                let p_v2: Rc<UH2> = p_v2;
                let ps_v3: Rc<UH6> = ps_v3;
                let mut v4: bool = label_84(p_v2);
                if v4 {
                    let n_v5: i32 = v1.wrapping_add(1i32);
                    (v0, v1) = (ps_v3, n_v5);
                    continue;
                } else {
                    return v1;
                }
            }
            UH6::UH6_Nil => {
                return v1;
            }
        }
    }
}
fn blocks_link_86(mut c_v0: i32) -> bool {
    let mut v1: bool = wide_word_82(c_v0);
    let mut v3: bool = if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 64i32;
        v2
    };
    if v3 {
        true
    } else {
        let mut v4: bool = c_v0 == 47i32;
        v4
    }
}
fn link_of_76(mut prev_v0: i32, mut ps_v1: Rc<UH6>, mut next_v2: i32) -> i32 {
    let s_v3: i32 = 0i32;
    let k_v4: i32 = method71(ps_v1.clone(), s_v3);
    let n_v5: i32 = 0i32;
    let l_v6: i32 = leading_labels_83(ps_v1.clone(), n_v5);
    let mut v7: bool = blocks_link_86(prev_v0);
    if v7 {
        0i32
    } else {
        let mut v8: i32 = l_v6.wrapping_add(1i32);
        let mut v9: bool = v8 < k_v4;
        let j_v10: i32 = if v9 {
            v8
        } else {
            k_v4
        };
        link_end_77(ps_v1, k_v4, j_v10, next_v2)
    }
}
fn taken_87(mut v0: i32, mut v1: Rc<UH6>) -> Rc<UH6> {
    match Rc::unwrap_or_clone(v1) {
        UH6::UH6_Cons(v2, ps_v3) => {
            let mut v2: Rc<UH2> = v2;
            let ps_v3: Rc<UH6> = ps_v3;
            let mut v4: bool = v0 <= 0i32;
            if v4 {
                { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) }
            } else {
                let j_v6: i32 = v0.wrapping_sub(1i32);
                let mut v7: Rc<UH6> = taken_87(j_v6, ps_v3);
                Rc::new(UH6::UH6_Cons(v2, v7))
            }
        }
        UH6::UH6_Nil => {
            { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn is_tld_90(mut backend_v0: Rc<str>) -> bool {
    let b_v1: Rc<str> = Rc::<str>::from(backend_v0.to_lowercase());
    let key_v3: Rc<str> = string_concat(&["|", &*b_v1, "|"]);
    let s_v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|aaa|aarp|abb|abbott|abbvie|abc|able|abogado|abudhabi|ac|academy|accenture|accountant|accountants|aco|actor|ad|ads|adult|ae|aeg|aero|aetna|af|afl|africa|ag|agakhan|agency|ai|aig|airbus|airforce|"); } LIT.with(|lit| lit.clone()) };
    let mut v5: bool = s_v4.contains(&*key_v3);
    if v5 {
        true
    } else {
        let s_v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|airtel|akdn|al|alibaba|alipay|allfinanz|allstate|ally|alsace|alstom|am|amazon|americanexpress|americanfamily|amex|amfam|amica|amsterdam|analytics|android|anquan|anz|ao|aol|apartments|app|apple|"); } LIT.with(|lit| lit.clone()) };
        let mut v7: bool = s_v6.contains(&*key_v3);
        if v7 {
            true
        } else {
            let s_v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|aq|aquarelle|ar|arab|aramco|archi|army|arpa|art|arte|as|asda|asia|associates|at|athleta|attorney|au|auction|audi|audible|audio|auspost|author|auto|autos|aw|aws|ax|axa|az|azure|ba|baby|baidu|"); } LIT.with(|lit| lit.clone()) };
            let mut v9: bool = s_v8.contains(&*key_v3);
            if v9 {
                true
            } else {
                let s_v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|banamex|band|bank|bar|barcelona|barclaycard|barclays|barefoot|bargains|baseball|basketball|bauhaus|bayern|bb|bbc|bbt|bbva|bcg|bcn|bd|be|beats|beauty|beer|berlin|best|bestbuy|bet|bf|bg|bh|bharti|bi|"); } LIT.with(|lit| lit.clone()) };
                let mut v11: bool = s_v10.contains(&*key_v3);
                if v11 {
                    true
                } else {
                    let s_v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|bible|bid|bike|bing|bingo|bio|biz|bj|black|blackfriday|blockbuster|blog|bloomberg|blue|bm|bms|bmw|bn|bnpparibas|bo|boats|boehringer|bofa|bom|bond|boo|book|booking|bosch|bostik|boston|bot|boutique|"); } LIT.with(|lit| lit.clone()) };
                    let mut v13: bool = s_v12.contains(&*key_v3);
                    if v13 {
                        true
                    } else {
                        let s_v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|box|br|bradesco|bridgestone|broadway|broker|brother|brussels|bs|bt|build|builders|business|buy|buzz|bv|bw|by|bz|bzh|ca|cab|cafe|cal|call|calvinklein|cam|camera|camp|canon|capetown|capital|"); } LIT.with(|lit| lit.clone()) };
                        let mut v15: bool = s_v14.contains(&*key_v3);
                        if v15 {
                            true
                        } else {
                            let s_v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|capitalone|car|caravan|cards|care|career|careers|cars|casa|case|cash|casino|cat|catering|catholic|cba|cbn|cbre|cc|cd|center|ceo|cern|cf|cfa|cfd|cg|ch|chanel|channel|charity|chase|chat|cheap|"); } LIT.with(|lit| lit.clone()) };
                            let v17: bool = s_v16.contains(&*key_v3);
                            if v17 {
                                true
                            } else {
                                let s_v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|chintai|christmas|chrome|church|ci|cipriani|circle|cisco|citadel|citi|citic|city|ck|cl|claims|cleaning|click|clinic|clinique|clothing|cloud|club|clubmed|cm|cn|co|coach|codes|coffee|college|"); } LIT.with(|lit| lit.clone()) };
                                let v19: bool = s_v18.contains(&*key_v3);
                                if v19 {
                                    true
                                } else {
                                    let s_v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|cologne|com|commbank|community|company|compare|computer|comsec|condos|construction|consulting|contact|contractors|cooking|cool|coop|corsica|country|coupon|coupons|courses|cpa|cr|credit|"); } LIT.with(|lit| lit.clone()) };
                                    let v21: bool = s_v20.contains(&*key_v3);
                                    if v21 {
                                        true
                                    } else {
                                        let s_v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|creditcard|creditunion|cricket|crown|crs|cruise|cruises|cu|cuisinella|cv|cw|cx|cy|cymru|cyou|cz|dad|dance|data|date|dating|datsun|day|dclk|dds|de|deal|dealer|deals|degree|delivery|dell|deloitte|"); } LIT.with(|lit| lit.clone()) };
                                        let v23: bool = s_v22.contains(&*key_v3);
                                        if v23 {
                                            true
                                        } else {
                                            let s_v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|delta|democrat|dental|dentist|desi|design|dev|dhl|diamonds|diet|digital|direct|directory|discount|discover|dish|diy|dj|dk|dm|dnp|do|docs|doctor|dog|domains|dot|download|drive|dtv|dubai|dupont|"); } LIT.with(|lit| lit.clone()) };
                                            let v25: bool = s_v24.contains(&*key_v3);
                                            if v25 {
                                                true
                                            } else {
                                                let s_v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|durban|dvag|dvr|dz|earth|eat|ec|eco|edeka|edu|education|ee|eg|email|emerck|energy|engineer|engineering|enterprises|epson|equipment|er|ericsson|erni|es|esq|estate|et|eu|eurovision|eus|events|"); } LIT.with(|lit| lit.clone()) };
                                                let v27: bool = s_v26.contains(&*key_v3);
                                                if v27 {
                                                    true
                                                } else {
                                                    let s_v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|exchange|expert|exposed|express|extraspace|fage|fail|fairwinds|faith|family|fan|fans|farm|farmers|fashion|fast|fedex|feedback|ferrari|ferrero|fi|fidelity|fido|film|final|finance|financial|fire|"); } LIT.with(|lit| lit.clone()) };
                                                    let v29: bool = s_v28.contains(&*key_v3);
                                                    if v29 {
                                                        true
                                                    } else {
                                                        let s_v30: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|firestone|firmdale|fish|fishing|fit|fitness|fj|fk|flickr|flights|flir|florist|flowers|fly|fm|fo|foo|food|football|ford|forex|forsale|forum|foundation|fox|fr|free|fresenius|frl|frogans|frontier|"); } LIT.with(|lit| lit.clone()) };
                                                        let v31: bool = s_v30.contains(&*key_v3);
                                                        if v31 {
                                                            true
                                                        } else {
                                                            let s_v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|ftr|fujitsu|fun|fund|furniture|futbol|fyi|ga|gal|gallery|gallo|gallup|game|games|gap|garden|gay|gb|gbiz|gd|gdn|ge|gea|gent|genting|george|gf|gg|ggee|gh|gi|gift|gifts|gives|giving|gl|glass|gle|"); } LIT.with(|lit| lit.clone()) };
                                                            let v33: bool = s_v32.contains(&*key_v3);
                                                            if v33 {
                                                                true
                                                            } else {
                                                                let s_v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|global|globo|gm|gmail|gmbh|gmo|gmx|gn|godaddy|gold|goldpoint|golf|goodyear|goog|google|gop|got|gov|gp|gq|gr|grainger|graphics|gratis|green|gripe|grocery|group|gs|gt|gu|gucci|guge|guide|guitars|guru|"); } LIT.with(|lit| lit.clone()) };
                                                                let v35: bool = s_v34.contains(&*key_v3);
                                                                if v35 {
                                                                    true
                                                                } else {
                                                                    let s_v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|gw|gy|hair|hamburg|hangout|haus|hbo|hdfc|hdfcbank|health|healthcare|help|helsinki|here|hermes|hiphop|hisamitsu|hitachi|hiv|hk|hkt|hm|hn|hockey|holdings|holiday|homedepot|homegoods|homes|"); } LIT.with(|lit| lit.clone()) };
                                                                    let v37: bool = s_v36.contains(&*key_v3);
                                                                    if v37 {
                                                                        true
                                                                    } else {
                                                                        let s_v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|homesense|honda|horse|hospital|host|hosting|hot|hotels|hotmail|house|how|hr|hsbc|ht|hu|hughes|hyatt|hyundai|ibm|icbc|ice|icu|id|ie|ieee|ifm|ikano|il|im|imamat|imdb|immo|immobilien|in|inc|"); } LIT.with(|lit| lit.clone()) };
                                                                        let v39: bool = s_v38.contains(&*key_v3);
                                                                        if v39 {
                                                                            true
                                                                        } else {
                                                                            let s_v40: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|industries|infiniti|info|ing|ink|institute|insurance|insure|int|international|intuit|investments|io|ipiranga|iq|ir|irish|is|ismaili|ist|istanbul|it|itau|itv|jaguar|java|jcb|je|jeep|jetzt|jewelry|"); } LIT.with(|lit| lit.clone()) };
                                                                            let v41: bool = s_v40.contains(&*key_v3);
                                                                            if v41 {
                                                                                true
                                                                            } else {
                                                                                let s_v42: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|jio|jll|jm|jmp|jnj|jo|jobs|joburg|jot|joy|jp|jpmorgan|jprs|juegos|kaufen|kddi|ke|kerryhotels|kerryproperties|kfh|kg|kh|ki|kia|kids|kim|kindle|kitchen|kiwi|km|kn|koeln|komatsu|kosher|kp|kpmg|"); } LIT.with(|lit| lit.clone()) };
                                                                                let v43: bool = s_v42.contains(&*key_v3);
                                                                                if v43 {
                                                                                    true
                                                                                } else {
                                                                                    let s_v44: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|kpn|kr|krd|kred|kuokgroup|kw|ky|kyoto|kz|la|lacaixa|lamborghini|lamer|land|landrover|lanxess|lasalle|lat|latino|latrobe|law|lawyer|lb|lc|lds|lease|leclerc|lefrak|legal|lego|lexus|lgbt|li|lidl|"); } LIT.with(|lit| lit.clone()) };
                                                                                    let v45: bool = s_v44.contains(&*key_v3);
                                                                                    if v45 {
                                                                                        true
                                                                                    } else {
                                                                                        let s_v46: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|life|lifeinsurance|lifestyle|lighting|like|lilly|limited|limo|lincoln|link|live|living|lk|llc|llp|loan|loans|locker|locus|lol|london|lotte|lotto|love|lpl|lplfinancial|lr|ls|lt|ltd|ltda|lu|lundbeck|"); } LIT.with(|lit| lit.clone()) };
                                                                                        let v47: bool = s_v46.contains(&*key_v3);
                                                                                        if v47 {
                                                                                            true
                                                                                        } else {
                                                                                            let s_v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|luxe|luxury|lv|ly|ma|madrid|maif|maison|makeup|man|management|mango|map|market|marketing|markets|marriott|marshalls|mattel|mba|mc|mckinsey|md|me|med|media|meet|melbourne|meme|memorial|men|menu|"); } LIT.with(|lit| lit.clone()) };
                                                                                            let v49: bool = s_v48.contains(&*key_v3);
                                                                                            if v49 {
                                                                                                true
                                                                                            } else {
                                                                                                let s_v50: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|merck|merckmsd|mg|mh|miami|microsoft|mil|mini|mint|mit|mitsubishi|mk|ml|mlb|mls|mm|mma|mn|mo|mobi|mobile|moda|moe|moi|mom|monash|money|monster|mormon|mortgage|moscow|moto|motorcycles|mov|movie|mp|"); } LIT.with(|lit| lit.clone()) };
                                                                                                let v51: bool = s_v50.contains(&*key_v3);
                                                                                                if v51 {
                                                                                                    true
                                                                                                } else {
                                                                                                    let s_v52: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|mq|mr|ms|msd|mt|mtn|mtr|mu|museum|music|mv|mw|mx|my|mz|na|nab|nagoya|name|navy|nba|nc|ne|nec|net|netbank|netflix|network|neustar|new|news|next|nextdirect|nexus|nf|nfl|ng|ngo|nhk|ni|nico|nike|"); } LIT.with(|lit| lit.clone()) };
                                                                                                    let v53: bool = s_v52.contains(&*key_v3);
                                                                                                    if v53 {
                                                                                                        true
                                                                                                    } else {
                                                                                                        let s_v54: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|nikon|ninja|nissan|nissay|nl|no|nokia|norton|now|nowruz|nowtv|np|nr|nra|nrw|ntt|nu|nyc|nz|obi|observer|office|okinawa|olayan|olayangroup|ollo|om|omega|one|ong|onl|online|ooo|open|oracle|orange|"); } LIT.with(|lit| lit.clone()) };
                                                                                                        let v55: bool = s_v54.contains(&*key_v3);
                                                                                                        if v55 {
                                                                                                            true
                                                                                                        } else {
                                                                                                            let s_v56: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|org|organic|origins|osaka|otsuka|ott|ovh|pa|page|panasonic|paris|pars|partners|parts|party|pay|pccw|pe|pet|pf|pfizer|pg|ph|pharmacy|phd|philips|phone|photo|photography|photos|physio|pics|pictet|"); } LIT.with(|lit| lit.clone()) };
                                                                                                            let v57: bool = s_v56.contains(&*key_v3);
                                                                                                            if v57 {
                                                                                                                true
                                                                                                            } else {
                                                                                                                let s_v58: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|pictures|pid|pin|ping|pink|pioneer|pizza|pk|pl|place|play|playstation|plumbing|plus|pm|pn|pnc|pohl|poker|politie|porn|post|pr|praxi|press|prime|pro|prod|productions|prof|progressive|promo|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                let v59: bool = s_v58.contains(&*key_v3);
                                                                                                                if v59 {
                                                                                                                    true
                                                                                                                } else {
                                                                                                                    let s_v60: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|properties|property|protection|pru|prudential|ps|pt|pub|pw|pwc|py|qa|qpon|quebec|quest|racing|radio|re|read|realestate|realtor|realty|recipes|red|redumbrella|rehab|reise|reisen|reit|reliance|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                    let v61: bool = s_v60.contains(&*key_v3);
                                                                                                                    if v61 {
                                                                                                                        true
                                                                                                                    } else {
                                                                                                                        let s_v62: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|ren|rent|rentals|repair|report|republican|rest|restaurant|review|reviews|rexroth|rich|richardli|ricoh|ril|rio|rip|ro|rocks|rodeo|rogers|room|rs|rsvp|ru|rugby|ruhr|run|rw|rwe|ryukyu|sa|saarland|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                        let v63: bool = s_v62.contains(&*key_v3);
                                                                                                                        if v63 {
                                                                                                                            true
                                                                                                                        } else {
                                                                                                                            let s_v64: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|safe|safety|sakura|sale|salon|samsclub|samsung|sandvik|sandvikcoromant|sanofi|sap|sarl|sas|save|saxo|sb|sbi|sbs|sc|scb|schaeffler|schmidt|scholarships|school|schule|schwarz|science|scot|sd|se|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                            let v65: bool = s_v64.contains(&*key_v3);
                                                                                                                            if v65 {
                                                                                                                                true
                                                                                                                            } else {
                                                                                                                                let s_v66: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|search|seat|secure|security|seek|select|sener|services|seven|sew|sex|sexy|sfr|sg|sh|shangrila|sharp|shell|shia|shiksha|shoes|shop|shopping|shouji|show|si|silk|sina|singles|site|sj|sk|ski|skin|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                let v67: bool = s_v66.contains(&*key_v3);
                                                                                                                                if v67 {
                                                                                                                                    true
                                                                                                                                } else {
                                                                                                                                    let s_v68: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|sky|skype|sl|sling|sm|smart|smile|sn|sncf|so|soccer|social|softbank|software|sohu|solar|solutions|song|sony|soy|spa|space|sport|spot|sr|srl|ss|st|stada|staples|star|statebank|statefarm|stc|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                    let v69: bool = s_v68.contains(&*key_v3);
                                                                                                                                    if v69 {
                                                                                                                                        true
                                                                                                                                    } else {
                                                                                                                                        let s_v70: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|stcgroup|stockholm|storage|store|stream|studio|study|style|su|sucks|supplies|supply|support|surf|surgery|suzuki|sv|swatch|swiss|sx|sy|sydney|systems|sz|tab|taipei|talk|taobao|target|tatamotors|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                        let v71: bool = s_v70.contains(&*key_v3);
                                                                                                                                        if v71 {
                                                                                                                                            true
                                                                                                                                        } else {
                                                                                                                                            let s_v72: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|tatar|tattoo|tax|taxi|tc|tci|td|tdk|team|tech|technology|tel|temasek|tennis|teva|tf|tg|th|thd|theater|theatre|tiaa|tickets|tienda|tips|tires|tirol|tj|tjmaxx|tjx|tk|tkmaxx|tl|tm|tmall|tn|to|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                            let v73: bool = s_v72.contains(&*key_v3);
                                                                                                                                            if v73 {
                                                                                                                                                true
                                                                                                                                            } else {
                                                                                                                                                let s_v74: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|today|tokyo|tools|top|toray|toshiba|total|tours|town|toyota|toys|tr|trade|trading|training|travel|travelers|travelersinsurance|trust|trv|tt|tube|tui|tunes|tushu|tv|tvs|tw|tz|ua|ubank|ubs|ug|uk|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                                let v75: bool = s_v74.contains(&*key_v3);
                                                                                                                                                if v75 {
                                                                                                                                                    true
                                                                                                                                                } else {
                                                                                                                                                    let s_v76: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|unicom|university|uno|uol|ups|us|uy|uz|va|vacations|vana|vanguard|vc|ve|vegas|ventures|verisign|versicherung|vet|vg|vi|viajes|video|vig|viking|villas|vin|vip|virgin|visa|vision|viva|vivo|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                                    let v77: bool = s_v76.contains(&*key_v3);
                                                                                                                                                    if v77 {
                                                                                                                                                        true
                                                                                                                                                    } else {
                                                                                                                                                        let s_v78: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|vlaanderen|vn|vodka|volvo|vote|voting|voto|voyage|vu|wales|walmart|walter|wang|wanggou|watch|watches|weather|weatherchannel|web|webcam|weber|website|wed|wedding|weibo|weir|wf|whoswho|wien|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                                        let v79: bool = s_v78.contains(&*key_v3);
                                                                                                                                                        if v79 {
                                                                                                                                                            true
                                                                                                                                                        } else {
                                                                                                                                                            let s_v80: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|wiki|williamhill|win|windows|wine|winners|wme|woodside|work|works|world|wow|ws|wtc|wtf|xbox|xerox|xihuan|xin|xxx|xyz|yachts|yahoo|yamaxun|yandex|ye|yodobashi|yoga|yokohama|you|youtube|yt|yun|za|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                                            let v81: bool = s_v80.contains(&*key_v3);
                                                                                                                                                            if v81 {
                                                                                                                                                                true
                                                                                                                                                            } else {
                                                                                                                                                                let s_v82: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|zappos|zara|zero|zip|zm|zone|zuerich|zw|"); } LIT.with(|lit| lit.clone()) };
                                                                                                                                                                let v83: bool = s_v82.contains(&*key_v3);
                                                                                                                                                                v83
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
fn method91(mut v0: Rc<str>, mut v1: Rc<UH0>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                let s_v6: bool = if v2 {
                    true
                } else {
                    let mut v5: bool = &*v3 == &*v0;
                    v5
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn lower_94(mut v0: i32) -> i32 {
    let mut v1: bool = v0 >= 65i32;
    let mut v3: bool = if v1 {
        let mut v2: bool = v0 <= 90i32;
        v2
    } else {
        false
    };
    if v3 {
        let mut v4: i32 = v0.wrapping_add(32i32);
        v4
    } else {
        v0
    }
}
fn method93(mut v0: Rc<UH2>, mut a_v1: Rc<str>) -> Rc<str> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(c_v2, v3) => {
                let c_v2: i32 = c_v2;
                let mut v3: Rc<UH2> = v3;
                let backend_v4: i32 = lower_94(c_v2);
                let mut v5: bool = backend_v4 >= 0i32;
                let mut v7: bool = if v5 {
                    let v6: bool = backend_v4 <= 1114111i32;
                    v6
                } else {
                    false
                };
                let mut v11: bool = if v7 {
                    let mut v8: bool = backend_v4 < 55296i32;
                    if v8 {
                        true
                    } else {
                        let mut v9: bool = backend_v4 > 57343i32;
                        v9
                    }
                } else {
                    false
                };
                let b_v18: Rc<str> = if v11 {
                    let mut v12: u32 = (backend_v4 as u32);
                    let mut v13: Option<char> = char::from_u32(v12);
                    let backend_v15: char = v13.unwrap();
                    let v16: Rc<str> = Rc::<str>::from(format!("{}", backend_v15));
                    v16
                } else {
                    let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                    v17
                };
                let s_v19: Rc<str> = string_concat(&[&*a_v1, &*b_v18]);
                (v0, a_v1) = (v3, s_v19);
                continue;
            }
            UH2::UH2_Nil => {
                return a_v1;
            }
        }
    }
}
fn text_of_92(mut v0: Rc<UH2>) -> Rc<str> {
    let s_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    method93(v0, s_v1)
}
fn known_89(mut v0: US2, mut p_v1: Rc<UH2>) -> bool {
    let t_v2: Rc<str> = text_of_92(p_v1);
    match v0 {
        US2::US2_Iana => {
            is_tld_90(t_v2)
        }
        US2::US2_Listed(ts_v3) => {
            let ts_v3: Rc<UH0> = ts_v3;
            let s_v4: bool = false;
            method91(t_v2, ts_v3, s_v4)
        }
    }
}
fn method96(mut v0: Rc<UH6>, mut a_v1: Rc<str>) -> Rc<str> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(p_v2, v3) => {
                let p_v2: Rc<UH2> = p_v2;
                let mut v3: Rc<UH6> = v3;
                let mut v4: bool = &*a_v1 == "";
                let mut s_v9: Rc<str> = if v4 {
                    text_of_92(p_v2)
                } else {
                    let b_v7: Rc<str> = text_of_92(p_v2);
                    let mut v8: Rc<str> = string_concat(&[&*a_v1, ".", &*b_v7]);
                    v8
                };
                (v0, a_v1) = (v3, s_v9);
                continue;
            }
            UH6::UH6_Nil => {
                return a_v1;
            }
        }
    }
}
fn dotted_95(mut v0: Rc<UH6>) -> Rc<str> {
    let s_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    method96(v0, s_v1)
}
fn accepted_88(mut set_v0: US2, mut ps_v1: Rc<UH6>, mut v2: i32) -> bool {
    let i_v3: i32 = v2.wrapping_sub(1i32);
    let last_v4: Rc<UH2> = nth_78(i_v3, ps_v1.clone());
    let mut v5: bool = known_89(set_v0, last_v4.clone());
    let v6: bool = v5 == false;
    if v6 {
        false
    } else {
        let mut v7: Rc<str> = dotted_95(ps_v1.clone());
        let mut v8: bool = &*v7 == "t.co";
        if v8 {
            true
        } else {
            let mut s_v9: i32 = 0i32;
            let v10: i32 = method70(last_v4, s_v9);
            let mut v11: bool = v10 != 2i32;
            if v11 {
                true
            } else {
                let i_v12: i32 = v2.wrapping_sub(2i32);
                let mut v13: Rc<UH2> = nth_78(i_v12, ps_v1);
                let s_v14: i32 = 0i32;
                let mut v15: i32 = method70(v13, s_v14);
                let v16: bool = v15 > 2i32;
                v16
            }
        }
    }
}
fn link_count_66(mut tlds_v0: US2, mut prev_v1: i32, mut at_v2: i32, mut cps_v3: Rc<UH2>, mut next_v4: i32, mut n_v5: i32, mut n_v6: i32, mut n_v7: Rc<UH5>) -> (i32, i32, Rc<UH5>) {
    let cur_v8: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let acc_v9: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
    let parts_v10: Rc<UH6> = dot_parts_74(cps_v3, cur_v8, acc_v9);
    let j_v11: i32 = link_of_76(prev_v1, parts_v10.clone(), next_v4);
    let mut v12: bool = j_v11 >= 2i32;
    let mut v15: bool = if v12 {
        let link_v13: Rc<UH6> = taken_87(j_v11, parts_v10.clone());
        accepted_88(tlds_v0, link_v13, j_v11)
    } else {
        false
    };
    let (mut v20, mut v21, mut v22): (i32, i32, Rc<UH5>) = if v15 {
        let link_v16: Rc<UH6> = taken_87(j_v11, parts_v10);
        let (mut v17, mut v18, mut v19): (i32, i32, Rc<UH5>) = counted_67(n_v5, n_v6, n_v7, at_v2, link_v16);
        (v17, v18, v19)
    } else {
        (n_v5, n_v6, n_v7)
    };
    (v20, v21, v22)
}
fn through_run_64(mut tlds_v0: US2, mut prev_v1: i32, mut at_v2: i32, mut cps_v3: Rc<UH2>, mut n_v4: i32, mut n_v5: i32, mut n_v6: Rc<UH5>) -> (i32, i32, Rc<UH2>, i32, i32, Rc<UH5>) {
    let f_v7: Rc<dyn Fn(i32) -> bool> = closure5();
    let acc_v8: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut s_v9, mut s_v10): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v7, cps_v3, acc_v8);
    let next_v11: i32 = first_point_38(&s_v10);
    let (mut counts_v12, mut counts_v13, mut counts_v14): (i32, i32, Rc<UH5>) = link_count_66(tlds_v0, prev_v1, at_v2, s_v9.clone(), next_v11, n_v4, n_v5, n_v6);
    let s_v15: i32 = 0i32;
    let v16: i32 = method70(s_v9, s_v15);
    let v17: i32 = at_v2.wrapping_add(v16);
    (46i32, v17, s_v10, counts_v12, counts_v13, counts_v14)
}
fn stepped_63(mut tlds_v0: US2, mut c_v1: i32, mut c_v2: i32, mut c_v3: Rc<UH2>, mut c_v4: i32, mut c_v5: i32, mut c_v6: Rc<UH5>, mut c_v7: i32, mut v8: Rc<UH2>) -> (i32, i32, Rc<UH2>, i32, i32, Rc<UH5>) {
    let mut v9: bool = run_point_65(c_v7);
    let (mut v17, mut v18, mut v19, mut v20, mut v21, mut v22): (i32, i32, Rc<UH2>, i32, i32, Rc<UH5>) = if v9 {
        let (mut v10, mut v11, mut v12, mut v13, mut v14, mut v15): (i32, i32, Rc<UH2>, i32, i32, Rc<UH5>) = through_run_64(tlds_v0, c_v1, c_v2, c_v3, c_v4, c_v5, c_v6);
        (v10, v11, v12, v13, v14, v15)
    } else {
        let v16: i32 = c_v2.wrapping_add(1i32);
        (c_v7, v16, v8, c_v4, c_v5, c_v6)
    };
    (v17, v18, v19, v20, v21, v22)
}
fn link_totals_of_62(mut tlds_v0: US2, mut c_v1: i32, mut c_v2: i32, mut c_v3: Rc<UH2>, mut c_v4: i32, mut c_v5: i32, mut c_v6: Rc<UH5>) -> (i32, i32, Rc<UH5>) {
    loop {
        match &*c_v3 {
            UH2::UH2_Nil => {
                return (c_v4, c_v5, c_v6);
            }
            _ => {
                match &*c_v3 {
                    UH2::UH2_Cons(x_v7, more_v8) => {
                        let x_v7: i32 = *x_v7;
                        let more_v8: Rc<UH2> = more_v8.clone();
                        let (mut c_v9, mut c_v10, mut c_v11, mut c_v12, mut c_v13, mut c_v14): (i32, i32, Rc<UH2>, i32, i32, Rc<UH5>) = stepped_63(tlds_v0.clone(), c_v1, c_v2, c_v3, c_v4, c_v5, c_v6, x_v7, more_v8);
                        (c_v1, c_v2, c_v3, c_v4, c_v5, c_v6) = (c_v9, c_v10, c_v11, c_v12, c_v13, c_v14);
                        continue;
                    }
                    _ => unreachable!(),
                }
            }
        }
    }
}
fn links_in_61(mut tlds_v0: US2, mut c_v1: Rc<UH2>) -> (i32, i32, Rc<UH5>) {
    let c_v2: i32 = -1i32;
    let c_v3: i32 = 0i32;
    let c_v4: i32 = 0i32;
    let c_v5: i32 = 0i32;
    let c_v6: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_Nil); } CASE.with(|case| case.clone()) };
    let (mut v7, mut v8, mut v9): (i32, i32, Rc<UH5>) = link_totals_of_62(tlds_v0, c_v2, c_v3, c_v1, c_v4, c_v5, c_v6);
    (v7, v8, v9)
}
fn code_weight_98(mut v0: i32) -> i32 {
    let mut v1: bool = v0 <= 4351i32;
    let mut v5: bool = if v1 {
        true
    } else {
        let mut v2: bool = v0 >= 8192i32;
        if v2 {
            let mut v3: bool = v0 <= 8205i32;
            v3
        } else {
            false
        }
    };
    if v5 {
        1i32
    } else {
        let v6: bool = v0 >= 8208i32;
        let mut v8: bool = if v6 {
            let mut v7: bool = v0 <= 8223i32;
            v7
        } else {
            false
        };
        let mut v12: bool = if v8 {
            true
        } else {
            let mut v9: bool = v0 >= 8242i32;
            if v9 {
                let v10: bool = v0 <= 8247i32;
                v10
            } else {
                false
            }
        };
        if v12 {
            1i32
        } else {
            2i32
        }
    }
}
fn points_weight_97(mut v0: Rc<UH2>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(c_v2, cs_v3) => {
                let c_v2: i32 = c_v2;
                let cs_v3: Rc<UH2> = cs_v3;
                let mut v4: i32 = code_weight_98(c_v2);
                let n_v5: i32 = v1.wrapping_add(v4);
                (v0, v1) = (cs_v3, n_v5);
                continue;
            }
            UH2::UH2_Nil => {
                return v1;
            }
        }
    }
}
fn link_weight_99() -> i32 {
    23i32
}
fn text_weight_60(mut tlds_v0: US2, mut backend_v1: Rc<str>) -> i32 {
    let backend_v2: Rc<Vec<char>> = Rc::new((&*backend_v1).chars().collect());
    let backend_v3: Rc<Vec<char>> = Rc::new((backend_v2).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v4: usize = (backend_v3).len();
    let x_v5: i32 = ((backend_v4) as i32);
    let i_v6: i32 = 0i32;
    let acc_v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v8: Rc<UH2> = method35(backend_v3, x_v5, i_v6, acc_v7);
    let (mut n_v9, mut n_v10, mut n_v11): (i32, i32, Rc<UH5>) = links_in_61(tlds_v0, cps_v8.clone());
    let n_v12: i32 = 0i32;
    let mut v13: i32 = points_weight_97(cps_v8, n_v12);
    let mut v14: i32 = v13.wrapping_sub(n_v10);
    let mut v15: i32 = link_weight_99();
    let v16: i32 = v15.wrapping_mul(n_v9);
    let v17: i32 = v14.wrapping_add(v16);
    v17
}
fn weight_of_58(mut tlds_v0: US2, mut s_v1: Rc<str>) -> i32 {
    let mut v2: i32 = text_weight_60(tlds_v0, s_v1);
    weight_value_59(v2)
}
fn method57(mut tlds_v0: US2, mut v1: Rc<UH0>, mut v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(text_v3, v4) => {
                let text_v3: Rc<str> = text_v3;
                let mut v4: Rc<UH0> = v4;
                let mut v5: i32 = weight_of_58(tlds_v0.clone(), text_v3.clone());
                let v6: bool = v5 > v2;
                let s_v8: i32 = if v6 {
                    weight_of_58(tlds_v0.clone(), text_v3)
                } else {
                    v2
                };
                (v1, v2) = (v4, s_v8);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn heaviest_56(mut v0: US2, mut v1: Rc<UH0>) -> i32 {
    let s_v2: i32 = 0i32;
    method57(v0, v1, s_v2)
}
fn flat_weight_101(mut tlds_v0: US2, mut text_v1: Rc<str>, mut texts_v2: Rc<UH0>) -> i32 {
    let mut v3: i32 = weight_of_58(tlds_v0.clone(), text_v1);
    let mut v4: i32 = heaviest_56(tlds_v0, texts_v2);
    let mut v5: i32 = v3.wrapping_add(v4);
    v5
}
fn method106(mut v0: Rc<UH7>, mut v1: Rc<UH7>) -> Rc<UH7> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH7::UH7_Cons(v2, v3, v4) => {
                let mut v2: Rc<str> = v2;
                let mut v3: Rc<UH0> = v3;
                let mut v4: Rc<UH7> = v4;
                let s_v5: Rc<UH7> = Rc::new(UH7::UH7_Cons(v2, v3, v1));
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH7::UH7_Nil => {
                return v1;
            }
        }
    }
}
fn done_tables_105(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>, mut v2: Rc<UH7>) -> (Rc<UH0>, Rc<UH7>) {
    let mut v3: Rc<UH0> = method9(v0, s_v1);
    let s_v4: Rc<UH7> = { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_Nil); } CASE.with(|case| case.clone()) };
    let mut v5: Rc<UH7> = method106(v2, s_v4);
    (v3, v5)
}
fn table_head_108(mut backend_v0: Rc<str>) -> bool {
    let t_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("backend_switch"); } LIT.with(|lit| lit.clone()) };
    let mut v3: bool = t_v1.starts_with(&*v2);
    let v6: bool = if v3 {
        let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{"); } LIT.with(|lit| lit.clone()) };
        let mut v5: bool = t_v1.ends_with(&*v4);
        v5
    } else {
        false
    };
    if v6 {
        true
    } else {
        let search_v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("run_target"); } LIT.with(|lit| lit.clone()) };
        let mut v8: bool = t_v1.starts_with(&*search_v7);
        if v8 {
            let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\|"); } LIT.with(|lit| lit.clone()) };
            let v10: bool = t_v1.ends_with(&*v9);
            v10
        } else {
            false
        }
    }
}
fn table_split_107(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> US8 {
    loop {
        match &*v1 {
            UH0::UH0_Cons(l_v3, lines_v4) => {
                let l_v3: Rc<str> = l_v3.clone();
                let lines_v4: Rc<UH0> = lines_v4.clone();
                let mut v5: bool = table_head_108(l_v3.clone());
                if v5 {
                    let s_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                    let mut v7: Rc<UH0> = method13(v0, s_v6);
                    return US8::US8_Some(v7, v1);
                } else {
                    let before_v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(l_v3, v0));
                    (v0, v1) = (before_v9, lines_v4);
                    continue;
                }
            }
            UH0::UH0_Nil => {
                return US8::US8_None;
            }
        }
    }
}
fn method114(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method114(v3, s_v1);
            let mut v5: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let v6: bool = &*v5 != "";
            if v6 {
                Rc::new(UH0::UH0_Cons(backend_v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn non_blank_113(mut v0: Rc<UH0>) -> Rc<UH0> {
    let s_v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method114(v0, s_v1)
}
fn method119(mut backend_v0: Rc<str>, mut v1: Rc<UH0>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(backend_v3, v4) => {
                let backend_v3: Rc<str> = backend_v3;
                let mut v4: Rc<UH0> = v4;
                let s_v6: bool = if v2 {
                    true
                } else {
                    let mut v5: bool = backend_v0.contains(&*backend_v3);
                    v5
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn contains_any_118(mut v0: Rc<UH0>, mut v1: Rc<str>) -> bool {
    let s_v2: bool = false;
    method119(v1, v0, s_v2)
}
fn plain_call_117(mut backend_v0: Rc<str>) -> bool {
    let mut v1: bool = &*backend_v0 != "";
    let mut v5: bool = if v1 {
        let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v3: bool = backend_v0.starts_with(&*v2);
        let mut v4: bool = v3 == false;
        v4
    } else {
        false
    };
    if v5 {
        let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
        let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\ "); } LIT.with(|lit| lit.clone()) };
        let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
        let mut v12: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v13: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v12));
        let mut v14: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v13));
        let mut v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v14));
        let v16: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v15));
        let v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v16));
        let parts_v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v17));
        let v19: bool = contains_any_118(parts_v18, backend_v0);
        let mut v20: bool = v19 == false;
        v20
    } else {
        false
    }
}
fn typed_open_120() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = (\\ () => "); } LIT.with(|lit| lit.clone()) };
    v0
}
fn method121(mut v0: Option<usize>) -> Option<usize> {
    v0
}
fn closure9() -> Rc<dyn Fn((usize)) -> i32> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((usize)) -> i32> = Rc::new(move |mut v0: (usize)| -> i32 {
        let mut v1: usize = (v0);
        let mut v2: i32 = ((v1) as i32);
        v2
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method124(mut v0: Rc<dyn Fn(i32) -> bool>, mut v1: Rc<UH2>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH2::UH2_Cons(v3, v4) => {
                let mut v3: i32 = v3;
                let mut v4: Rc<UH2> = v4;
                let s_v6: bool = if v2 {
                    v0(v3)
                } else {
                    false
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH2::UH2_Nil => {
                return v2;
            }
        }
    }
}
fn all_of_123(mut v0: Rc<dyn Fn(i32) -> bool>, mut v1: Rc<UH2>) -> bool {
    let s_v2: bool = true;
    method124(v0, v1, s_v2)
}
fn capital_word_122(mut backend_v0: Rc<str>) -> bool {
    let backend_v1: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v2: Rc<Vec<char>> = Rc::new((backend_v1).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v3: usize = (backend_v2).len();
    let x_v4: i32 = ((backend_v3) as i32);
    let i_v5: i32 = 0i32;
    let acc_v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH2> = method35(backend_v2, x_v4, i_v5, acc_v6);
    match Rc::unwrap_or_clone(v7) {
        UH2::UH2_Cons(v8, xs_v9) => {
            let mut v8: i32 = v8;
            let xs_v9: Rc<UH2> = xs_v9;
            let v10: bool = v8 >= 65i32;
            let mut v12: bool = if v10 {
                let mut v11: bool = v8 <= 90i32;
                v11
            } else {
                false
            };
            if v12 {
                let f_v13: Rc<dyn Fn(i32) -> bool> = closure6();
                all_of_123(f_v13, xs_v9)
            } else {
                false
            }
        }
        UH2::UH2_Nil => {
            false
        }
    }
}
fn closure10() -> Rc<dyn Fn((usize)) -> i32> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((usize)) -> i32> = Rc::new(move |mut v0: (usize)| -> i32 {
        let mut v1: usize = (v0);
        let mut v2: i32 = ((v1) as i32);
        v2
    }); } CLOSURE.with(|closure| closure.clone())
}
fn typed_close_126(mut backend_v0: Rc<str>) -> i32 {
    let x_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(") : "); } LIT.with(|lit| lit.clone()) };
    let backend_v2: Option<usize> = backend_v0.rfind(&*x_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure10();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let mut v7: i32 = v5.unwrap_or(-1i32);
    v7
}
fn typed_body_125(mut backend_v0: Rc<str>) -> Rc<str> {
    let backend_v1: Rc<str> = typed_open_120();
    let backend_v2: Option<usize> = backend_v0.find(&*backend_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let mut v7: i32 = v5.unwrap_or(-1i32);
    let from_v8: i32 = v7.wrapping_add(12i32);
    let mut v9: i32 = typed_close_126(backend_v0.clone());
    let v10: bool = v9 > from_v8;
    if v10 {
        let mut v11: i32 = typed_close_126(backend_v0.clone());
        let backend_v12: i32 = v11.wrapping_sub(from_v8);
        let x_v13: usize = ((from_v8) as usize);
        let backend_v14: i32 = from_v8.wrapping_add(backend_v12);
        let x_v15: usize = ((backend_v14) as usize);
        let v16: Rc<str> = Rc::<str>::from(&(backend_v0)[x_v13..x_v15]);
        v16
    } else {
        let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v17
    }
}
fn typed_arm_116(mut backend_v0: Rc<str>) -> bool {
    let backend_v1: Rc<str> = typed_open_120();
    let backend_v2: Option<usize> = backend_v0.find(&*backend_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let at_v7: i32 = v5.unwrap_or(-1i32);
    let mut v8: bool = at_v7 > 0i32;
    let mut v13: bool = if v8 {
        let x_v9: usize = ((0i32) as usize);
        let x_v10: usize = ((at_v7) as usize);
        let w_v11: Rc<str> = Rc::<str>::from(&(backend_v0)[x_v9..x_v10]);
        capital_word_122(w_v11)
    } else {
        false
    };
    let v16: bool = if v13 {
        let call_v14: Rc<str> = typed_body_125(backend_v0.clone());
        plain_call_117(call_v14)
    } else {
        false
    };
    if v16 {
        let v17: i32 = typed_close_126(backend_v0.clone());
        let at_v18: i32 = v17.wrapping_add(4i32);
        let call_v19: Rc<str> = tail_after_30(at_v18, backend_v0);
        plain_call_117(call_v19)
    } else {
        false
    }
}
fn bare_arm_127(mut backend_v0: Rc<str>) -> bool {
    let search_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = \\ () => "); } LIT.with(|lit| lit.clone()) };
    let backend_v2: Option<usize> = backend_v0.find(&*search_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let at_v7: i32 = v5.unwrap_or(-1i32);
    let mut v8: bool = at_v7 > 0i32;
    let mut v13: bool = if v8 {
        let x_v9: usize = ((0i32) as usize);
        let x_v10: usize = ((at_v7) as usize);
        let w_v11: Rc<str> = Rc::<str>::from(&(backend_v0)[x_v9..x_v10]);
        capital_word_122(w_v11)
    } else {
        false
    };
    if v13 {
        let at_v14: i32 = at_v7.wrapping_add(11i32);
        let call_v15: Rc<str> = tail_after_30(at_v14, backend_v0);
        plain_call_117(call_v15)
    } else {
        false
    }
}
fn switch_arm_115(mut backend_v0: Rc<str>) -> bool {
    let arm_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: i32 = (backend_v0.len() as i32);
    let mut v3: bool = v2 <= 120i32;
    if v3 {
        let mut v4: bool = bare_arm_127(arm_v1.clone());
        if v4 {
            true
        } else {
            typed_arm_116(arm_v1)
        }
    } else {
        false
    }
}
fn closure8() -> Rc<dyn Fn(Rc<str>) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> bool> = Rc::new(move |mut v0: Rc<str>| -> bool {
        switch_arm_115(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method129(mut v0: Rc<dyn Fn(Rc<str>) -> bool>, mut v1: Rc<UH0>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH0> = v4;
                let s_v6: bool = if v2 {
                    v0(v3)
                } else {
                    false
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn all_of_128(mut v0: Rc<dyn Fn(Rc<str>) -> bool>, mut v1: Rc<UH0>) -> bool {
    let s_v2: bool = true;
    method129(v0, v1, s_v2)
}
fn method130(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method130(v3, s_v1);
            let mut v5: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            Rc::new(UH0::UH0_Cons(v5, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn flat_switch_112(mut v0: Rc<UH0>) -> US9 {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, lines_v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let lines_v3: Rc<UH0> = lines_v3;
            let t_v4: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let mut v5: Rc<UH0> = non_blank_113(lines_v3);
            let s_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
            let mut v7: Rc<UH0> = method13(v5, s_v6);
            match Rc::unwrap_or_clone(v7) {
                UH0::UH0_Cons(backend_v8, v9) => {
                    let backend_v8: Rc<str> = backend_v8;
                    let mut v9: Rc<UH0> = v9;
                    let s_v10: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                    let arms_v11: Rc<UH0> = method13(v9, s_v10);
                    let search_v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("backend_switch"); } LIT.with(|lit| lit.clone()) };
                    let mut v13: bool = t_v4.starts_with(&*search_v12);
                    let v16: bool = if v13 {
                        let search_v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{"); } LIT.with(|lit| lit.clone()) };
                        let mut v15: bool = t_v4.ends_with(&*search_v14);
                        v15
                    } else {
                        false
                    };
                    let v19: bool = if v16 {
                        let v17: Rc<str> = Rc::<str>::from((backend_v8).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                        let v18: bool = &*v17 == "}";
                        v18
                    } else {
                        false
                    };
                    let v22: bool = if v19 {
                        let mut v20: bool = match &*arms_v11 {
                            UH0::UH0_Nil => {
                                true
                            }
                            _ => {
                                false
                            }
                        };
                        let v21: bool = v20 != true;
                        v21
                    } else {
                        false
                    };
                    let v25: bool = if v22 {
                        let f_v23: Rc<dyn Fn(Rc<str>) -> bool> = closure8();
                        all_of_128(f_v23, arms_v11.clone())
                    } else {
                        false
                    };
                    if v25 {
                        let s_v26: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                        let v27: Rc<UH0> = method130(arms_v11, s_v26);
                        US9::US9_Flat(t_v4, v27)
                    } else {
                        US9::US9_NotFlat
                    }
                }
                UH0::UH0_Nil => {
                    US9::US9_NotFlat
                }
            }
        }
        UH0::UH0_Nil => {
            US9::US9_NotFlat
        }
    }
}
fn run_target_head_132(mut backend_v0: Rc<str>) -> bool {
    let search_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("run_target_args"); } LIT.with(|lit| lit.clone()) };
    let mut v2: bool = backend_v0.starts_with(&*search_v1);
    let mut v5: bool = if v2 {
        true
    } else {
        let search_v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("run_target "); } LIT.with(|lit| lit.clone()) };
        let mut v4: bool = backend_v0.starts_with(&*search_v3);
        v4
    };
    if v5 {
        let search_v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\|"); } LIT.with(|lit| lit.clone()) };
        let mut v7: bool = backend_v0.ends_with(&*search_v6);
        v7
    } else {
        false
    }
}
fn target_call_134(mut backend_v0: Rc<str>) -> bool {
    let search_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" => "); } LIT.with(|lit| lit.clone()) };
    let backend_v2: Option<usize> = backend_v0.find(&*search_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let b_v7: i32 = v5.unwrap_or(-1i32);
    let mut v8: bool = b_v7 > 0i32;
    let mut v15: bool = if v8 {
        let x_v9: usize = ((0i32) as usize);
        let x_v10: usize = ((b_v7) as usize);
        let backend_v11: Rc<str> = Rc::<str>::from(&(backend_v0)[x_v9..x_v10]);
        let search_v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
        let mut v13: bool = backend_v11.contains(&*search_v12);
        let mut v14: bool = v13 == false;
        v14
    } else {
        false
    };
    if v15 {
        let at_v16: i32 = b_v7.wrapping_add(4i32);
        let call_v17: Rc<str> = tail_after_30(at_v16, backend_v0);
        plain_call_117(call_v17)
    } else {
        false
    }
}
fn closure13() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        let mut v1: bool = word_char_31(v0);
        if v1 {
            true
        } else {
            let mut v2: bool = v0 == 39i32;
            v2
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn identifier_135(mut backend_v0: Rc<str>) -> bool {
    let backend_v1: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v2: Rc<Vec<char>> = Rc::new((backend_v1).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v3: usize = (backend_v2).len();
    let x_v4: i32 = ((backend_v3) as i32);
    let i_v5: i32 = 0i32;
    let acc_v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH2> = method35(backend_v2, x_v4, i_v5, acc_v6);
    match Rc::unwrap_or_clone(v7) {
        UH2::UH2_Cons(c_v8, xs_v9) => {
            let c_v8: i32 = c_v8;
            let xs_v9: Rc<UH2> = xs_v9;
            let v10: bool = ascii_letter_33(c_v8);
            let mut v12: bool = if v10 {
                true
            } else {
                let mut v11: bool = c_v8 == 95i32;
                v11
            };
            if v12 {
                let f_v13: Rc<dyn Fn(i32) -> bool> = closure13();
                all_of_123(f_v13, xs_v9)
            } else {
                false
            }
        }
        UH2::UH2_Nil => {
            false
        }
    }
}
fn closure12() -> Rc<dyn Fn(Rc<str>) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> bool> = Rc::new(move |mut v0: Rc<str>| -> bool {
        identifier_135(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn run_target_arm_133(mut backend_v0: Rc<str>) -> bool {
    let arm_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let at_v2: i32 = 2i32;
    let rest_v3: Rc<str> = tail_after_30(at_v2, arm_v1.clone());
    let search_v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" => \\ "); } LIT.with(|lit| lit.clone()) };
    let backend_v5: Option<usize> = rest_v3.find(&*search_v4);
    let x_v6: Option<usize> = method121(backend_v5);
    let mut v7: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v8: Option<i32> = x_v6.map(|x| v7(x));
    let a_v10: i32 = v8.unwrap_or(-1i32);
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("| "); } LIT.with(|lit| lit.clone()) };
    let mut v12: bool = arm_v1.starts_with(&*v11);
    let mut v14: bool = if v12 {
        let mut v13: bool = a_v10 > 0i32;
        v13
    } else {
        false
    };
    let v22: bool = if v14 {
        let f_v15: Rc<dyn Fn(Rc<str>) -> bool> = closure12();
        let separator_v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let x_v17: usize = ((0i32) as usize);
        let x_v18: usize = ((a_v10) as usize);
        let s_v19: Rc<str> = Rc::<str>::from(&(rest_v3)[x_v17..x_v18]);
        let xs_v20: Rc<UH0> = split_list_12(separator_v16, s_v19);
        all_of_128(f_v15, xs_v20)
    } else {
        false
    };
    let v25: bool = if v22 {
        let v23: i32 = (backend_v0.len() as i32);
        let v24: bool = v23 <= 120i32;
        v24
    } else {
        false
    };
    if v25 {
        let at_v26: i32 = a_v10.wrapping_add(6i32);
        let params_call_v27: Rc<str> = tail_after_30(at_v26, rest_v3);
        target_call_134(params_call_v27)
    } else {
        false
    }
}
fn closure11() -> Rc<dyn Fn(Rc<str>) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> bool> = Rc::new(move |mut v0: Rc<str>| -> bool {
        run_target_arm_133(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn flat_run_target_131(mut v0: Rc<UH0>) -> US9 {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, lines_v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let lines_v3: Rc<UH0> = lines_v3;
            let t_v4: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let arms_v5: Rc<UH0> = non_blank_113(lines_v3);
            let v6: bool = run_target_head_132(t_v4.clone());
            let mut v9: bool = if v6 {
                let mut v7: bool = match &*arms_v5 {
                    UH0::UH0_Nil => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v8: bool = v7 != true;
                v8
            } else {
                false
            };
            let mut v12: bool = if v9 {
                let f_v10: Rc<dyn Fn(Rc<str>) -> bool> = closure11();
                all_of_128(f_v10, arms_v5.clone())
            } else {
                false
            };
            if v12 {
                let s_v13: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                let mut v14: Rc<UH0> = method130(arms_v5, s_v13);
                US9::US9_Flat(t_v4, v14)
            } else {
                US9::US9_NotFlat
            }
        }
        UH0::UH0_Nil => {
            US9::US9_NotFlat
        }
    }
}
fn table_shape_111(mut backend_v0: Rc<str>, mut v1: Rc<UH0>) -> US9 {
    let backend_v2: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("backend_switch"); } LIT.with(|lit| lit.clone()) };
    let mut v4: bool = backend_v2.starts_with(&*v3);
    if v4 {
        let body_v5: Rc<UH0> = Rc::new(UH0::UH0_Cons(backend_v0, v1));
        flat_switch_112(body_v5)
    } else {
        let body_v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(backend_v0, v1));
        flat_run_target_131(body_v7)
    }
}
fn shaped_step_136(mut v0: Rc<UH0>, mut v1: Rc<UH7>, mut v2: Rc<str>, mut v3: Rc<UH0>, mut v4: US9) -> (Rc<UH0>, Rc<UH7>) {
    match v4 {
        US9::US9_Flat(v5, v6) => {
            let mut v5: Rc<str> = v5;
            let v6: Rc<UH0> = v6;
            let mut v7: Rc<UH7> = Rc::new(UH7::UH7_Cons(v5, v6, v1));
            (v0, v7)
        }
        US9::US9_NotFlat => {
            let s_v8: Rc<UH0> = Rc::new(UH0::UH0_Cons(v2, v3));
            let mut v9: Rc<UH0> = method9(v0, s_v8);
            (v9, v1)
        }
    }
}
fn stepped_110(mut kept_v0: Rc<UH0>, mut flats_v1: Rc<UH7>, mut head_v2: Rc<str>, mut rows_v3: Rc<UH0>, mut v4: Rc<UH0>) -> (Rc<UH0>, Rc<UH7>, Rc<UH0>) {
    let shape_v5: US9 = table_shape_111(head_v2.clone(), rows_v3.clone());
    let (mut v6, mut v7): (Rc<UH0>, Rc<UH7>) = shaped_step_136(kept_v0, flats_v1, head_v2, rows_v3, shape_v5);
    (v6, v7, v4)
}
fn method138(mut v0: Rc<str>, mut v1: i32, mut v2: i32) -> i32 {
    loop {
        let mut v3: bool = v2 >= v1;
        if v3 {
            return v1;
        } else {
            let mut v4: u8 = v0.clone().as_bytes()[v2 as usize];
            let mut v5: bool = v4 == b' ';
            if v5 {
                let i_v6: i32 = v2.wrapping_add(1i32);
                v2 = i_v6;
                continue;
            } else {
                return v2;
            }
        }
    }
}
fn indent_of_137(mut backend_v0: Rc<str>) -> i32 {
    let len_v1: i32 = (backend_v0.clone().len() as i32);
    let i_v2: i32 = 0i32;
    let backend_v3: i32 = method138(backend_v0.clone(), len_v1, i_v2);
    let backend_v4: i32 = len_v1.wrapping_sub(1i32);
    let mut v5: Rc<str> = string_slice(&backend_v0, backend_v3 as i64, backend_v4 as i64);
    let v6: i32 = (v5.len() as i32);
    let mut v7: i32 = len_v1.wrapping_sub(v6);
    v7
}
fn closes_table_141(mut v0: i32, mut backend_v1: Rc<str>) -> bool {
    let mut v2: Rc<str> = Rc::<str>::from((backend_v1).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v3: bool = &*v2 == "}";
    if v3 {
        let mut v4: i32 = indent_of_137(backend_v1);
        let mut v5: bool = v4 == v0;
        v5
    } else {
        false
    }
}
fn table_stop_140(mut depth_v0: i32, mut v1: Rc<UH0>, mut l_v2: Rc<str>, mut v3: Rc<UH0>) -> (Rc<UH0>, Rc<UH0>) {
    let mut v4: bool = closes_table_141(depth_v0, l_v2.clone());
    if v4 {
        let mut v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let s_v6: Rc<UH0> = Rc::new(UH0::UH0_Cons(l_v2, v5));
        let mut v7: Rc<UH0> = method13(v1, s_v6);
        (v7, v3)
    } else {
        let s_v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v9: Rc<UH0> = method13(v1, s_v8);
        let v10: Rc<UH0> = Rc::new(UH0::UH0_Cons(l_v2, v3));
        (v9, v10)
    }
}
fn inside_table_142(mut v0: i32, mut backend_v1: Rc<str>) -> bool {
    let mut v2: Rc<str> = Rc::<str>::from((backend_v1).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v3: bool = &*v2 == "";
    if v3 {
        true
    } else {
        let mut v4: i32 = indent_of_137(backend_v1);
        let mut v5: bool = v4 > v0;
        v5
    }
}
fn table_end_139(mut depth_v0: i32, mut taken_v1: Rc<UH0>, mut v2: Rc<UH0>) -> (Rc<UH0>, Rc<UH0>) {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH0::UH0_Cons(l_v6, lines_v7) => {
                let l_v6: Rc<str> = l_v6;
                let lines_v7: Rc<UH0> = lines_v7;
                let mut v8: bool = inside_table_142(depth_v0, l_v6.clone());
                if v8 {
                    let taken_v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(l_v6, taken_v1));
                    (taken_v1, v2) = (taken_v9, lines_v7);
                    continue;
                } else {
                    return table_stop_140(depth_v0, taken_v1, l_v6, lines_v7);
                }
            }
            UH0::UH0_Nil => {
                let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                let mut v4: Rc<UH0> = method13(taken_v1, s_v3);
                let mut v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                return (v4, v5);
            }
        }
    }
}
fn table_next_109(mut v0: Rc<UH0>, mut flats_v1: Rc<UH7>, mut s_v2: Rc<UH0>, mut l_v3: Rc<str>, mut lines_v4: Rc<UH0>) -> (Rc<UH0>, Rc<UH7>, Rc<UH0>) {
    let depth_v5: i32 = indent_of_137(l_v3.clone());
    let taken_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let (mut rows_v7, mut rest_v8): (Rc<UH0>, Rc<UH0>) = table_end_139(depth_v5, taken_v6, lines_v4);
    let kept_v9: Rc<UH0> = method9(v0, s_v2);
    stepped_110(kept_v9, flats_v1, l_v3, rows_v7, rest_v8)
}
fn split_tables_104(mut lines_v0: Rc<UH0>, mut frame_v1: Rc<UH0>, mut flats_v2: Rc<UH7>) -> (Rc<UH0>, Rc<UH7>) {
    loop {
        let before_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v4: US8 = table_split_107(before_v3, lines_v0.clone());
        match v4 {
            US8::US8_Some(prefix_v5, v6) => {
                let prefix_v5: Rc<UH0> = prefix_v5;
                let v6: Rc<UH0> = v6;
                match Rc::unwrap_or_clone(v6) {
                    UH0::UH0_Cons(head_v7, after_v8) => {
                        let head_v7: Rc<str> = head_v7;
                        let after_v8: Rc<UH0> = after_v8;
                        let (mut fr_v9, mut fl_v10, mut ls_v11): (Rc<UH0>, Rc<UH7>, Rc<UH0>) = table_next_109(frame_v1, flats_v2, prefix_v5, head_v7, after_v8);
                        (lines_v0, frame_v1, flats_v2) = (ls_v11, fr_v9, fl_v10);
                        continue;
                    }
                    _ => {
                        return done_tables_105(frame_v1, lines_v0, flats_v2);
                    }
                }
            }
            _ => {
                return done_tables_105(frame_v1, lines_v0, flats_v2);
            }
        }
    }
}
fn joined_lines_143(mut v0: Rc<UH0>) -> Rc<str> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(a_v2, ls_v3) => {
            let a_v2: Rc<str> = a_v2;
            let ls_v3: Rc<UH0> = ls_v3;
            match &*ls_v3 {
                UH0::UH0_Nil => {
                    a_v2
                }
                _ => {
                    let b_v5: Rc<str> = joined_lines_143(ls_v3);
                    let v6: Rc<str> = string_concat(&[&*a_v2, "\n", &*b_v5]);
                    v6
                }
            }
        }
        UH0::UH0_Nil => {
            let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            v1
        }
    }
}
fn flat_part_145(mut tlds_v0: US2, mut v1: i32, mut text_v2: Rc<str>, mut texts_v3: Rc<UH0>) -> i32 {
    let mut v4: i32 = weight_of_58(tlds_v0.clone(), text_v2);
    let mut v5: i32 = v1.wrapping_add(v4);
    let v6: i32 = heaviest_56(tlds_v0, texts_v3);
    let mut v7: i32 = v5.wrapping_add(v6);
    v7
}
fn method144(mut v0: US2, mut v1: Rc<UH7>, mut n_v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH7::UH7_Cons(p_v3, p_v4, v5) => {
                let p_v3: Rc<str> = p_v3;
                let p_v4: Rc<UH0> = p_v4;
                let mut v5: Rc<UH7> = v5;
                let s_v6: i32 = flat_part_145(v0.clone(), n_v2, p_v3, p_v4);
                (v1, n_v2) = (v5, s_v6);
                continue;
            }
            UH7::UH7_Nil => {
                return n_v2;
            }
        }
    }
}
fn framed_103(mut tlds_v0: US2, mut ls_v1: Rc<UH0>, mut text_v2: Rc<str>) -> i32 {
    let fr_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let fl_v4: Rc<UH7> = { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_Nil); } CASE.with(|case| case.clone()) };
    let (mut ls_v5, mut v6): (Rc<UH0>, Rc<UH7>) = split_tables_104(ls_v1, fr_v3, fl_v4);
    match &*v6 {
        UH7::UH7_Nil => {
            weight_of_58(tlds_v0, text_v2)
        }
        _ => {
            let text_v8: Rc<str> = joined_lines_143(ls_v5);
            let mut v9: i32 = weight_of_58(tlds_v0.clone(), text_v8);
            let s_v10: i32 = 0i32;
            let mut v11: i32 = method144(tlds_v0, v6, s_v10);
            let mut v12: i32 = v9.wrapping_add(v11);
            v12
        }
    }
}
fn digit_or_suffix_149(mut v0: i32) -> bool {
    let mut v1: bool = v0 >= 48i32;
    let mut v3: bool = if v1 {
        let mut v2: bool = v0 <= 57i32;
        v2
    } else {
        false
    };
    if v3 {
        true
    } else {
        let mut v4: bool = v0 == 105i32;
        v4
    }
}
fn closure14() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        digit_or_suffix_149(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn result_literal_148(mut backend_v0: Rc<str>) -> bool {
    let mut v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: bool = &*v1 != "";
    if v2 {
        let f_v3: Rc<dyn Fn(i32) -> bool> = closure14();
        let backend_v4: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
        let backend_v5: Rc<Vec<char>> = Rc::new((&*backend_v4).chars().collect());
        let backend_v6: Rc<Vec<char>> = Rc::new((backend_v5).as_ref().iter().rev().cloned().collect::<Vec<_>>());
        let backend_v7: usize = (backend_v6).len();
        let x_v8: i32 = ((backend_v7) as i32);
        let i_v9: i32 = 0i32;
        let acc_v10: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
        let xs_v11: Rc<UH2> = method35(backend_v6, x_v8, i_v9, acc_v10);
        all_of_123(f_v3, xs_v11)
    } else {
        false
    }
}
fn export_rows_147(mut v0: Rc<UH0>) -> Rc<UH0> {
    let s_v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v2: Rc<UH0> = method13(v0.clone(), s_v1);
    match Rc::unwrap_or_clone(v2) {
        UH0::UH0_Cons(raw_v3, v4) => {
            let raw_v3: Rc<str> = raw_v3;
            let mut v4: Rc<UH0> = v4;
            let mut v5: bool = result_literal_148(raw_v3);
            if v5 {
                let s_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                method13(v4, s_v6)
            } else {
                v0
            }
        }
        UH0::UH0_Nil => {
            { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) }
        }
    }
}
fn control_logic_151() -> Rc<UH0> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v6: Rc<UH0> = Rc::new(UH0::UH0_Cons(v4, v5));
    let mut v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(v3, v6));
    let mut v8: Rc<UH0> = Rc::new(UH0::UH0_Cons(v2, v7));
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v1, v8));
    Rc::new(UH0::UH0_Cons(v0, v9))
}
fn export_row_150(mut backend_v0: Rc<str>) -> bool {
    let backend_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("export \""); } LIT.with(|lit| lit.clone()) };
    let mut v3: bool = backend_v1.starts_with(&*v2);
    if v3 {
        let parts_v4: Rc<UH0> = control_logic_151();
        let mut v5: bool = contains_any_118(parts_v4, backend_v0);
        let v6: bool = v5 == false;
        v6
    } else {
        false
    }
}
fn closure15() -> Rc<dyn Fn(Rc<str>) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> bool> = Rc::new(move |mut v0: Rc<str>| -> bool {
        export_row_150(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn flat_exports_146(mut lines_v0: Rc<UH0>) -> US9 {
    let kept_v1: Rc<UH0> = non_blank_113(lines_v0);
    let rows_v2: Rc<UH0> = export_rows_147(kept_v1);
    let mut v3: bool = match &*rows_v2 {
        UH0::UH0_Nil => {
            true
        }
        _ => {
            false
        }
    };
    let mut v4: bool = v3 != true;
    let mut v7: bool = if v4 {
        let f_v5: Rc<dyn Fn(Rc<str>) -> bool> = closure15();
        all_of_128(f_v5, rows_v2.clone())
    } else {
        false
    };
    if v7 {
        let s_v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v9: Rc<UH0> = method130(rows_v2, s_v8);
        let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        US9::US9_Flat(v10, v9)
    } else {
        US9::US9_NotFlat
    }
}
fn exports_or_framed_102(mut tlds_v0: US2, mut body_v1: Rc<UH0>, mut text_v2: Rc<str>) -> i32 {
    let mut v3: US9 = flat_exports_146(body_v1.clone());
    match v3 {
        US9::US9_Flat(h_v4, arms_v5) => {
            let h_v4: Rc<str> = h_v4;
            let arms_v5: Rc<UH0> = arms_v5;
            flat_weight_101(tlds_v0, h_v4, arms_v5)
        }
        US9::US9_NotFlat => {
            framed_103(tlds_v0, body_v1, text_v2)
        }
    }
}
fn dispatch_arm_153(mut backend_v0: Rc<str>) -> bool {
    let arm_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("| "); } LIT.with(|lit| lit.clone()) };
    let mut v3: bool = arm_v1.starts_with(&*v2);
    let v6: bool = if v3 {
        let mut v4: i32 = (backend_v0.len() as i32);
        let mut v5: bool = v4 <= 120i32;
        v5
    } else {
        false
    };
    if v6 {
        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
        let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
        let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\ "); } LIT.with(|lit| lit.clone()) };
        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
        let mut v13: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v14: Rc<UH0> = Rc::new(UH0::UH0_Cons(v12, v13));
        let mut v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v14));
        let v16: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v15));
        let v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v16));
        let v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v17));
        let parts_v19: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v18));
        let mut v20: bool = contains_any_118(parts_v19, arm_v1);
        let v21: bool = v20 == false;
        v21
    } else {
        false
    }
}
fn closure16() -> Rc<dyn Fn(Rc<str>) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> bool> = Rc::new(move |mut v0: Rc<str>| -> bool {
        dispatch_arm_153(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn flat_dispatch_152(mut v0: &Rc<UH0>) -> US9 {
    match &**v0 {
        UH0::UH0_Cons(backend_v2, lines_v3) => {
            let backend_v2: Rc<str> = backend_v2.clone();
            let lines_v3: Rc<UH0> = lines_v3.clone();
            let t_v4: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let kept_v5: Rc<UH0> = non_blank_113(lines_v3);
            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
            let mut v7: bool = t_v4.starts_with(&*v6);
            let v10: bool = if v7 {
                let search_v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?|"); } LIT.with(|lit| lit.clone()) };
                let mut v9: bool = t_v4.ends_with(&*search_v8);
                v9
            } else {
                false
            };
            let mut v13: bool = if v10 {
                let mut v11: bool = match &*kept_v5 {
                    UH0::UH0_Nil => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v12: bool = v11 != true;
                v12
            } else {
                false
            };
            let v16: bool = if v13 {
                let f_v14: Rc<dyn Fn(Rc<str>) -> bool> = closure16();
                all_of_128(f_v14, kept_v5.clone())
            } else {
                false
            };
            if v16 {
                let s_v17: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                let v18: Rc<UH0> = method130(kept_v5, s_v17);
                US9::US9_Flat(t_v4, v18)
            } else {
                US9::US9_NotFlat
            }
        }
        UH0::UH0_Nil => {
            US9::US9_NotFlat
        }
    }
}
fn shaped_weight_100(mut tlds_v0: US2, mut body_v1: Rc<UH0>, mut text_v2: Rc<str>) -> i32 {
    let mut v3: US9 = flat_dispatch_152(&body_v1);
    let mut v4: US9 = flat_switch_112(body_v1.clone());
    let mut v5: US9 = flat_run_target_131(body_v1.clone());
    match v3 {
        US9::US9_Flat(h_v6, arms_v7) => {
            let h_v6: Rc<str> = h_v6;
            let arms_v7: Rc<UH0> = arms_v7;
            flat_weight_101(tlds_v0, h_v6, arms_v7)
        }
        US9::US9_NotFlat => {
            match v4 {
                US9::US9_Flat(h_v9, arms_v10) => {
                    let h_v9: Rc<str> = h_v9;
                    let arms_v10: Rc<UH0> = arms_v10;
                    flat_weight_101(tlds_v0, h_v9, arms_v10)
                }
                US9::US9_NotFlat => {
                    match v5 {
                        US9::US9_Flat(h_v12, arms_v13) => {
                            let h_v12: Rc<str> = h_v12;
                            let arms_v13: Rc<UH0> = arms_v13;
                            flat_weight_101(tlds_v0, h_v12, arms_v13)
                        }
                        US9::US9_NotFlat => {
                            exports_or_framed_102(tlds_v0, body_v1, text_v2)
                        }
                    }
                }
            }
        }
    }
}
enum Group158 {
    M158(Rc<UH2>, Rc<UH2>),
    M159(Rc<UH2>, Rc<UH2>),
}
fn group_158(mut st: Group158) -> US10 {
    loop {
        match st {
            Group158::M158(mut v0, mut v1) => {
                match Rc::unwrap_or_clone(v0) {
                    UH2::UH2_Cons(v3, cps_v4) => {
                        let mut v3: i32 = v3;
                        let cps_v4: Rc<UH2> = cps_v4;
                        let mut v5: bool = v3 == 34i32;
                        if v5 {
                            let v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                            let s_v7: Rc<UH2> = Rc::new(UH2::UH2_Cons(v3, v6));
                            let mut v8: Rc<UH2> = method37(v1, s_v7);
                            return US10::US10_Some(v8, cps_v4);
                        } else {
                            let v10: bool = v3 == 92i32;
                            if v10 {
                                let acc_v11: Rc<UH2> = Rc::new(UH2::UH2_Cons(v3, v1));
                                st = Group158::M159(cps_v4, acc_v11);
                                continue;
                            } else {
                                let acc_v13: Rc<UH2> = Rc::new(UH2::UH2_Cons(v3, v1));
                                st = Group158::M158(cps_v4, acc_v13);
                                continue;
                            }
                        }
                    }
                    UH2::UH2_Nil => {
                        return US10::US10_None;
                    }
                }
            }
            Group158::M159(mut v0, mut v1) => {
                match Rc::unwrap_or_clone(v0) {
                    UH2::UH2_Cons(v3, cps_v4) => {
                        let mut v3: i32 = v3;
                        let cps_v4: Rc<UH2> = cps_v4;
                        let acc_v5: Rc<UH2> = Rc::new(UH2::UH2_Cons(v3, v1));
                        st = Group158::M158(cps_v4, acc_v5);
                        continue;
                    }
                    UH2::UH2_Nil => {
                        return US10::US10_None;
                    }
                }
            }
        }
    }
}
fn escaped_body_159(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US10 {
    group_158(Group158::M159(v0, v1))
}
fn quoted_body_158(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US10 {
    group_158(Group158::M158(v0, v1))
}
fn method161(mut v0: Rc<UH2>, mut s_v1: Rc<UH2>) -> Rc<UH2> {
    match Rc::unwrap_or_clone(v0) {
        UH2::UH2_Cons(v2, v3) => {
            let mut v2: i32 = v2;
            let mut v3: Rc<UH2> = v3;
            let mut v4: Rc<UH2> = method161(v3, s_v1);
            Rc::new(UH2::UH2_Cons(v2, v4))
        }
        UH2::UH2_Nil => {
            s_v1
        }
    }
}
fn kept_piece_160(mut v0: Rc<UH2>, mut v1: Rc<UH2>, mut v2: &Rc<UH2>, mut s_v3: Rc<UH2>, mut v4: Rc<UH6>) -> (Rc<UH2>, Rc<UH6>) {
    let s_v5: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let v6: Rc<UH2> = method37(v0, s_v5);
    let mut v7: Rc<UH2> = method161(v6, s_v3);
    let mut v8: Rc<UH6> = Rc::new(UH6::UH6_Cons(v1, v4));
    (v7, v8)
}
fn kept_point_162(mut v0: i32, mut v1: Rc<UH2>, mut v2: Rc<UH6>) -> (Rc<UH2>, Rc<UH6>) {
    let mut v3: Rc<UH2> = Rc::new(UH2::UH2_Cons(v0, v1));
    (v3, v2)
}
fn split_literals_157(mut fill_v0: Rc<UH2>, mut v1: Rc<UH2>, mut s_v2: Rc<UH2>, mut s_v3: Rc<UH6>) -> (Rc<UH2>, Rc<UH6>) {
    loop {
        match &*v1 {
            UH2::UH2_Nil => {
                return (s_v2, s_v3);
            }
            _ => {
                match Rc::unwrap_or_clone(v1) {
                    UH2::UH2_Cons(c_v4, cps_v5) => {
                        let c_v4: i32 = c_v4;
                        let cps_v5: Rc<UH2> = cps_v5;
                        let v6: bool = c_v4 == 34i32;
                        let quoted_v11: US10 = if v6 {
                            let mut v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                            let acc_v8: Rc<UH2> = Rc::new(UH2::UH2_Cons(c_v4, v7));
                            quoted_body_158(cps_v5.clone(), acc_v8)
                        } else {
                            US10::US10_None
                        };
                        match &quoted_v11 {
                            US10::US10_Some(q_v12, q_v13) => {
                                let q_v12: Rc<UH2> = q_v12.clone();
                                let q_v13: Rc<UH2> = q_v13.clone();
                                let (mut s_v14, mut s_v15): (Rc<UH2>, Rc<UH6>) = kept_piece_160(fill_v0.clone(), q_v12, &q_v13, s_v2, s_v3);
                                (v1, s_v2, s_v3) = (q_v13, s_v14, s_v15);
                                continue;
                            }
                            _ => {
                                match quoted_v11 {
                                    US10::US10_None => {
                                        let (mut s_v18, mut s_v19): (Rc<UH2>, Rc<UH6>) = kept_point_162(c_v4, s_v2, s_v3);
                                        (v1, s_v2, s_v3) = (cps_v5, s_v18, s_v19);
                                        continue;
                                    }
                                    _ => unreachable!(),
                                }
                            }
                        }
                    }
                    _ => unreachable!(),
                }
            }
        }
    }
}
fn literal_split_of_156(mut backend_v0: Rc<str>, mut backend_v1: Rc<str>) -> (Rc<UH2>, Rc<UH6>) {
    let backend_v2: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v3: Rc<Vec<char>> = Rc::new((backend_v2).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v4: usize = (backend_v3).len();
    let x_v5: i32 = ((backend_v4) as i32);
    let i_v6: i32 = 0i32;
    let acc_v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let fill_v8: Rc<UH2> = method35(backend_v3, x_v5, i_v6, acc_v7);
    let backend_v9: Rc<Vec<char>> = Rc::new((&*backend_v1).chars().collect());
    let backend_v10: Rc<Vec<char>> = Rc::new((backend_v9).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v11: usize = (backend_v10).len();
    let x_v12: i32 = ((backend_v11) as i32);
    let i_v13: i32 = 0i32;
    let acc_v14: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v15: Rc<UH2> = method35(backend_v10, x_v12, i_v13, acc_v14);
    let s_v16: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let s_v17: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
    let (mut v18, mut v19): (Rc<UH2>, Rc<UH6>) = split_literals_157(fill_v8, cps_v15, s_v16, s_v17);
    (v18, v19)
}
fn without_literals_155(mut fill_v0: Rc<str>, mut text_v1: Rc<str>) -> Rc<str> {
    let (mut v2, mut v3): (Rc<UH2>, Rc<UH6>) = literal_split_of_156(fill_v0, text_v1);
    let s_v4: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let p_v5: Rc<UH2> = method37(v2, s_v4);
    written_of_39(p_v5)
}
fn prefix_rest_167(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US11 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v14, name_v15) => {
                let mut v14: i32 = v14;
                let name_v15: Rc<UH2> = name_v15;
                match Rc::unwrap_or_clone(v1) {
                    UH2::UH2_Cons(v16, cps_v17) => {
                        let v16: i32 = v16;
                        let cps_v17: Rc<UH2> = cps_v17;
                        let v18: bool = v14 == v16;
                        if v18 {
                            (v0, v1) = (name_v15, cps_v17);
                            continue;
                        } else {
                            return US11::US11_None;
                        }
                    }
                    _ => {
                        return US11::US11_None;
                    }
                }
            }
            UH2::UH2_Nil => {
                match &*v1 {
                    UH2::UH2_Cons(v2, _) => {
                        let mut v2: i32 = *v2;
                        let mut v4: bool = v2 == 32i32;
                        let v6: bool = if v4 {
                            true
                        } else {
                            let mut v5: bool = v2 == 9i32;
                            v5
                        };
                        let mut v8: bool = if v6 {
                            true
                        } else {
                            let mut v7: bool = v2 == 40i32;
                            v7
                        };
                        if v8 {
                            return US11::US11_Some(v1);
                        } else {
                            return US11::US11_None;
                        }
                    }
                    _ => {
                        return US11::US11_None;
                    }
                }
            }
        }
    }
}
fn name_at_166(mut name_v0: Rc<UH2>, mut c_v1: i32, mut cps_v2: Rc<UH2>) -> US11 {
    let mut v3: bool = word_char_31(c_v1);
    let mut v5: bool = if v3 {
        true
    } else {
        let mut v4: bool = c_v1 == 46i32;
        v4
    };
    let mut v7: bool = if v5 {
        true
    } else {
        let v6: bool = c_v1 == 39i32;
        v6
    };
    let guarded_v9: bool = if v7 {
        true
    } else {
        let mut v8: bool = c_v1 == 34i32;
        v8
    };
    if guarded_v9 {
        US11::US11_None
    } else {
        prefix_rest_167(name_v0, cps_v2)
    }
}
fn strip_name_165(mut name_v0: Rc<UH2>, mut prev_v1: i32, mut cps_v2: Rc<UH2>, mut acc_v3: Rc<UH2>) -> Rc<UH2> {
    loop {
        match &*cps_v2 {
            UH2::UH2_Cons(prev_v6, cps_v7) => {
                let prev_v6: i32 = *prev_v6;
                let cps_v7: Rc<UH2> = cps_v7.clone();
                let mut v8: US11 = name_at_166(name_v0.clone(), prev_v1, cps_v2);
                match v8 {
                    US11::US11_None => {
                        let acc_v12: Rc<UH2> = Rc::new(UH2::UH2_Cons(prev_v6, acc_v3));
                        (prev_v1, cps_v2, acc_v3) = (prev_v6, cps_v7, acc_v12);
                        continue;
                    }
                    US11::US11_Some(after_v9) => {
                        let after_v9: Rc<UH2> = after_v9;
                        let prev_v10: i32 = 32i32;
                        (prev_v1, cps_v2) = (prev_v10, after_v9);
                        continue;
                    }
                }
            }
            UH2::UH2_Nil => {
                let s_v4: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                return method37(acc_v3, s_v4);
            }
        }
    }
}
fn without_name_164(mut backend_v0: Rc<str>, mut backend_v1: Rc<str>) -> Rc<str> {
    let backend_v2: Rc<Vec<char>> = Rc::new((&*backend_v1).chars().collect());
    let backend_v3: Rc<Vec<char>> = Rc::new((backend_v2).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v4: usize = (backend_v3).len();
    let x_v5: i32 = ((backend_v4) as i32);
    let i_v6: i32 = 0i32;
    let acc_v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let name_v8: Rc<UH2> = method35(backend_v3, x_v5, i_v6, acc_v7);
    let prev_v9: i32 = -1i32;
    let backend_v10: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v11: Rc<Vec<char>> = Rc::new((backend_v10).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v12: usize = (backend_v11).len();
    let x_v13: i32 = ((backend_v12) as i32);
    let i_v14: i32 = 0i32;
    let acc_v15: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v16: Rc<UH2> = method35(backend_v11, x_v13, i_v14, acc_v15);
    let acc_v17: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let p_v18: Rc<UH2> = strip_name_165(name_v8, prev_v9, cps_v16, acc_v17);
    written_of_39(p_v18)
}
fn method163(mut v0: Rc<UH0>, mut text_v1: Rc<str>) -> Rc<str> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(name_v2, v3) => {
                let name_v2: Rc<str> = name_v2;
                let mut v3: Rc<UH0> = v3;
                let s_v4: Rc<str> = without_name_164(text_v1, name_v2);
                (v0, text_v1) = (v3, s_v4);
                continue;
            }
            UH0::UH0_Nil => {
                return text_v1;
            }
        }
    }
}
fn method169(mut backend_v0: Rc<str>, mut v1: Rc<UH0>, mut v2: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(backend_v3, v4) => {
                let backend_v3: Rc<str> = backend_v3;
                let mut v4: Rc<UH0> = v4;
                let s_v6: bool = if v2 {
                    true
                } else {
                    let mut v5: bool = backend_v0.starts_with(&*backend_v3);
                    v5
                };
                (v1, v2) = (v4, s_v6);
                continue;
            }
            UH0::UH0_Nil => {
                return v2;
            }
        }
    }
}
fn starts_with_any_168(mut v0: Rc<UH0>, mut v1: Rc<str>) -> bool {
    let s_v2: bool = false;
    method169(v1, v0, s_v2)
}
fn closure17() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        let mut v1: bool = word_char_31(v0);
        if v1 {
            true
        } else {
            let mut v2: bool = v0 == 39i32;
            v2
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn stops_application_173(mut v0: i32) -> bool {
    let mut v1: bool = 61i32 == v0;
    let mut v3: bool = if v1 {
        true
    } else {
        let mut v2: bool = 58i32 == v0;
        v2
    };
    let mut v5: bool = if v3 {
        true
    } else {
        let mut v4: bool = 59i32 == v0;
        v4
    };
    let mut v7: bool = if v5 {
        true
    } else {
        let v6: bool = 44i32 == v0;
        v6
    };
    let mut v9: bool = if v7 {
        true
    } else {
        let mut v8: bool = 93i32 == v0;
        v8
    };
    let mut v11: bool = if v9 {
        true
    } else {
        let v10: bool = 125i32 == v0;
        v10
    };
    let mut v13: bool = if v11 {
        true
    } else {
        let mut v12: bool = 41i32 == v0;
        v12
    };
    let mut v15: bool = if v13 {
        true
    } else {
        let mut v14: bool = 124i32 == v0;
        v14
    };
    let v17: bool = if v15 {
        true
    } else {
        let v16: bool = 32i32 == v0;
        v16
    };
    let v19: bool = if v17 {
        true
    } else {
        let v18: bool = 9i32 == v0;
        v18
    };
    let v21: bool = if v19 {
        true
    } else {
        let mut v20: bool = 10i32 == v0;
        v20
    };
    if v21 {
        true
    } else {
        let v22: bool = 13i32 == v0;
        v22
    }
}
fn spaced_application_172(mut v0: Rc<UH2>) -> bool {
    match Rc::unwrap_or_clone(v0) {
        UH2::UH2_Cons(c_v1, _) => {
            let c_v1: i32 = c_v1;
            let mut v3: bool = stops_application_173(c_v1);
            let mut v4: bool = v3 == false;
            v4
        }
        UH2::UH2_Nil => {
            true
        }
    }
}
fn closure18() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        let mut v1: bool = v0 == 32i32;
        if v1 {
            true
        } else {
            let mut v2: bool = v0 == 9i32;
            v2
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn applies_after_171(mut cps_v0: Rc<UH2>) -> bool {
    let f_v1: Rc<dyn Fn(i32) -> bool> = closure18();
    let acc_v2: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut spaces_v3, mut spaces_v4): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v1, cps_v0.clone(), acc_v2);
    match Rc::unwrap_or_clone(cps_v0) {
        UH2::UH2_Cons(v5, _) => {
            let mut v5: i32 = v5;
            let mut v7: bool = v5 == 40i32;
            if v7 {
                true
            } else {
                let mut v8: bool = v5 == 32i32;
                let v10: bool = if v8 {
                    true
                } else {
                    let mut v9: bool = v5 == 9i32;
                    v9
                };
                if v10 {
                    spaced_application_172(spaces_v4)
                } else {
                    false
                }
            }
        }
        UH2::UH2_Nil => {
            false
        }
    }
}
fn application_in_170(mut c_v0: i32, mut cps_v1: Rc<UH2>) -> bool {
    loop {
        match &*cps_v1 {
            UH2::UH2_Cons(d_v2, cps_v3) => {
                let d_v2: i32 = *d_v2;
                let cps_v3: Rc<UH2> = cps_v3.clone();
                let mut v4: bool = d_v2 >= 97i32;
                let v6: bool = if v4 {
                    let mut v5: bool = d_v2 <= 122i32;
                    v5
                } else {
                    false
                };
                let mut v8: bool = if v6 {
                    true
                } else {
                    let mut v7: bool = d_v2 == 95i32;
                    v7
                };
                let starts_v17: bool = if v8 {
                    let mut v9: bool = word_char_31(c_v0);
                    let mut v11: bool = if v9 {
                        true
                    } else {
                        let v10: bool = c_v0 == 46i32;
                        v10
                    };
                    let mut v13: bool = if v11 {
                        true
                    } else {
                        let mut v12: bool = c_v0 == 39i32;
                        v12
                    };
                    let mut v15: bool = if v13 {
                        true
                    } else {
                        let mut v14: bool = c_v0 == 34i32;
                        v14
                    };
                    let v16: bool = v15 == false;
                    v16
                } else {
                    false
                };
                if starts_v17 {
                    let f_v18: Rc<dyn Fn(i32) -> bool> = closure17();
                    let acc_v19: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                    let (mut w_v20, mut w_v21): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v18, cps_v1, acc_v19);
                    let v22: bool = applies_after_171(w_v21.clone());
                    if v22 {
                        return true;
                    } else {
                        let prev_v23: i32 = last_point_85(w_v20, d_v2);
                        (c_v0, cps_v1) = (prev_v23, w_v21);
                        continue;
                    }
                } else {
                    (c_v0, cps_v1) = (d_v2, cps_v3);
                    continue;
                }
            }
            UH2::UH2_Nil => {
                return false;
            }
        }
    }
}
fn data_literal_154(mut v0: Rc<UH0>, mut text_v1: Rc<str>) -> bool {
    let fill_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\"\""); } LIT.with(|lit| lit.clone()) };
    let backend_v3: Rc<str> = without_literals_155(fill_v2, text_v1);
    let quoted_v4: Rc<str> = Rc::<str>::from((backend_v3).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let backend_v5: Rc<str> = method163(v0, quoted_v4);
    let bare_v6: Rc<str> = Rc::<str>::from((backend_v5).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("{"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("["); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(";["); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v12: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v11));
    let mut v13: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v12));
    let mut v14: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v13));
    let prefixes_v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v14));
    let v16: bool = starts_with_any_168(prefixes_v15, bare_v6.clone());
    let v36: bool = if v16 {
        let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
        let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
        let v19: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
        let mut v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
        let v21: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\ "); } LIT.with(|lit| lit.clone()) };
        let v22: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
        let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|>"); } LIT.with(|lit| lit.clone()) };
        let v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("<|"); } LIT.with(|lit| lit.clone()) };
        let v25: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let v26: Rc<UH0> = Rc::new(UH0::UH0_Cons(v24, v25));
        let v27: Rc<UH0> = Rc::new(UH0::UH0_Cons(v23, v26));
        let v28: Rc<UH0> = Rc::new(UH0::UH0_Cons(v22, v27));
        let v29: Rc<UH0> = Rc::new(UH0::UH0_Cons(v21, v28));
        let v30: Rc<UH0> = Rc::new(UH0::UH0_Cons(v20, v29));
        let v31: Rc<UH0> = Rc::new(UH0::UH0_Cons(v19, v30));
        let v32: Rc<UH0> = Rc::new(UH0::UH0_Cons(v18, v31));
        let parts_v33: Rc<UH0> = Rc::new(UH0::UH0_Cons(v17, v32));
        let v34: bool = contains_any_118(parts_v33, bare_v6.clone());
        let v35: bool = v34 == false;
        v35
    } else {
        false
    };
    if v36 {
        let prev_v37: i32 = -1i32;
        let backend_v38: Rc<Vec<char>> = Rc::new((&*bare_v6).chars().collect());
        let backend_v39: Rc<Vec<char>> = Rc::new((backend_v38).as_ref().iter().rev().cloned().collect::<Vec<_>>());
        let backend_v40: usize = (backend_v39).len();
        let x_v41: i32 = ((backend_v40) as i32);
        let i_v42: i32 = 0i32;
        let acc_v43: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
        let cps_v44: Rc<UH2> = method35(backend_v39, x_v41, i_v42, acc_v43);
        let v45: bool = application_in_170(prev_v37, cps_v44);
        let v46: bool = v45 == false;
        v46
    } else {
        false
    }
}
fn capital_start_177(mut backend_v0: Rc<str>) -> bool {
    let backend_v1: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v2: Rc<Vec<char>> = Rc::new((backend_v1).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v3: usize = (backend_v2).len();
    let x_v4: i32 = ((backend_v3) as i32);
    let i_v5: i32 = 0i32;
    let acc_v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH2> = method35(backend_v2, x_v4, i_v5, acc_v6);
    match Rc::unwrap_or_clone(v7) {
        UH2::UH2_Cons(v8, _) => {
            let mut v8: i32 = v8;
            let v10: bool = v8 >= 65i32;
            if v10 {
                let mut v11: bool = v8 <= 90i32;
                v11
            } else {
                false
            }
        }
        UH2::UH2_Nil => {
            false
        }
    }
}
fn applied_178(mut backend_v0: Rc<str>) -> bool {
    let prev_v1: i32 = -1i32;
    let backend_v2: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v3: Rc<Vec<char>> = Rc::new((backend_v2).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v4: usize = (backend_v3).len();
    let x_v5: i32 = ((backend_v4) as i32);
    let i_v6: i32 = 0i32;
    let acc_v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v8: Rc<UH2> = method35(backend_v3, x_v5, i_v6, acc_v7);
    application_in_170(prev_v1, cps_v8)
}
fn bound_vars_only_176(mut backend_v0: Rc<str>) -> bool {
    let t_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v2: bool = &*t_v1 != "";
    let mut v5: bool = if v2 {
        let mut v3: bool = capital_start_177(t_v1.clone());
        let mut v4: bool = v3 == false;
        v4
    } else {
        false
    };
    let v25: bool = if v5 {
        let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
        let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\ "); } LIT.with(|lit| lit.clone()) };
        let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|>"); } LIT.with(|lit| lit.clone()) };
        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("<|"); } LIT.with(|lit| lit.clone()) };
        let mut v14: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v13, v14));
        let v16: Rc<UH0> = Rc::new(UH0::UH0_Cons(v12, v15));
        let v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v16));
        let v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v17));
        let v19: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v18));
        let mut v20: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v19));
        let v21: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v20));
        let parts_v22: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v21));
        let v23: bool = contains_any_118(parts_v22, t_v1.clone());
        let v24: bool = v23 == false;
        v24
    } else {
        false
    };
    let v29: bool = if v25 {
        let v26: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\""); } LIT.with(|lit| lit.clone()) };
        let v27: bool = t_v1.contains(&*v26);
        let v28: bool = v27 == false;
        v28
    } else {
        false
    };
    if v29 {
        let v30: bool = applied_178(t_v1);
        let v31: bool = v30 == false;
        v31
    } else {
        false
    }
}
fn scrutinee_line_179(mut backend_v0: Rc<str>) -> bool {
    let t_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let search_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
    let mut v3: bool = t_v1.starts_with(&*search_v2);
    let v6: bool = if v3 {
        let search_v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ?|"); } LIT.with(|lit| lit.clone()) };
        let mut v5: bool = t_v1.ends_with(&*search_v4);
        v5
    } else {
        false
    };
    if v6 {
        let at_v7: i32 = 3i32;
        let backend_v8: Rc<str> = tail_after_30(at_v7, t_v1);
        let old_v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ?|"); } LIT.with(|lit| lit.clone()) };
        let new_v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        let backend_v11: Rc<str> = Rc::<str>::from(backend_v8.replace(&*old_v9, &*new_v10));
        let w_v12: Rc<str> = Rc::<str>::from((backend_v11).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
        identifier_135(w_v12)
    } else {
        false
    }
}
fn method181(mut v0: Rc<UH0>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(backend_v2, v3) => {
                let backend_v2: Rc<str> = backend_v2;
                let mut v3: Rc<UH0> = v3;
                let backend_v4: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                let search_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("| "); } LIT.with(|lit| lit.clone()) };
                let v6: bool = backend_v4.starts_with(&*search_v5);
                let s_v8: i32 = if v6 {
                    let mut v7: i32 = v1.wrapping_add(1i32);
                    v7
                } else {
                    v1
                };
                (v0, v1) = (v3, s_v8);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn arm_count_180(mut v0: Rc<UH0>) -> i32 {
    let s_v1: i32 = 0i32;
    method181(v0, s_v1)
}
fn projection_175(mut lines_v0: Rc<UH0>) -> bool {
    let mut v1: Rc<UH0> = non_blank_113(lines_v0);
    match Rc::unwrap_or_clone(v1) {
        UH0::UH0_Cons(l_v2, ls_v3) => {
            let l_v2: Rc<str> = l_v2;
            let ls_v3: Rc<UH0> = ls_v3;
            let arms_v4: Rc<str> = joined_lines_143(ls_v3.clone());
            let search_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("=>"); } LIT.with(|lit| lit.clone()) };
            let backend_v6: Option<usize> = arms_v4.find(&*search_v5);
            let x_v7: Option<usize> = method121(backend_v6);
            let mut v8: Rc<dyn Fn((usize)) -> i32> = closure9();
            let mut v9: Option<i32> = x_v7.map(|x| v8(x));
            let at_v11: i32 = v9.unwrap_or(-1i32);
            let mut v12: bool = scrutinee_line_179(l_v2);
            let mut v15: bool = if v12 {
                let mut v13: i32 = arm_count_180(ls_v3);
                let mut v14: bool = v13 == 1i32;
                v14
            } else {
                false
            };
            let v17: bool = if v15 {
                let v16: bool = at_v11 > 0i32;
                v16
            } else {
                false
            };
            if v17 {
                let at_v18: i32 = at_v11.wrapping_add(2i32);
                let rhs_v19: Rc<str> = tail_after_30(at_v18, arms_v4);
                bound_vars_only_176(rhs_v19)
            } else {
                false
            }
        }
        UH0::UH0_Nil => {
            false
        }
    }
}
fn constructor_term_182(mut v0: Rc<UH0>, mut text_v1: Rc<str>) -> bool {
    let fill_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\"\""); } LIT.with(|lit| lit.clone()) };
    let backend_v3: Rc<str> = without_literals_155(fill_v2, text_v1);
    let s_v4: Rc<str> = Rc::<str>::from((backend_v3).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let backend_v5: Rc<str> = method163(v0, s_v4);
    let bare_v6: Rc<str> = Rc::<str>::from((backend_v5).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let mut v7: bool = capital_start_177(bare_v6.clone());
    let v27: bool = if v7 {
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?= "); } LIT.with(|lit| lit.clone()) };
        let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ? "); } LIT.with(|lit| lit.clone()) };
        let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("?> "); } LIT.with(|lit| lit.clone()) };
        let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":= "); } LIT.with(|lit| lit.clone()) };
        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\ "); } LIT.with(|lit| lit.clone()) };
        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fun "); } LIT.with(|lit| lit.clone()) };
        let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("|>"); } LIT.with(|lit| lit.clone()) };
        let mut v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("<|"); } LIT.with(|lit| lit.clone()) };
        let v16: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v15, v16));
        let v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(v14, v17));
        let v19: Rc<UH0> = Rc::new(UH0::UH0_Cons(v13, v18));
        let mut v20: Rc<UH0> = Rc::new(UH0::UH0_Cons(v12, v19));
        let v21: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v20));
        let v22: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v21));
        let v23: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v22));
        let parts_v24: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v23));
        let v25: bool = contains_any_118(parts_v24, bare_v6.clone());
        let v26: bool = v25 == false;
        v26
    } else {
        false
    };
    if v27 {
        let v28: bool = applied_178(bare_v6);
        let v29: bool = v28 == false;
        v29
    } else {
        false
    }
}
fn structural_174(mut nominals_v0: Rc<UH0>, mut body_v1: Rc<UH0>, mut text_v2: Rc<str>) -> bool {
    let mut v3: bool = constructor_term_182(nominals_v0, text_v2);
    if v3 {
        true
    } else {
        projection_175(body_v1)
    }
}
fn method185(mut v0: Rc<UH6>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH6::UH6_Cons(p_v2, v3) => {
            let p_v2: Rc<UH2> = p_v2;
            let mut v3: Rc<UH6> = v3;
            let mut v4: Rc<UH0> = method185(v3, s_v1);
            let mut v5: Rc<str> = written_of_39(p_v2);
            Rc::new(UH0::UH0_Cons(v5, v4))
        }
        UH6::UH6_Nil => {
            s_v1
        }
    }
}
fn literal_pieces_184(mut text_v0: Rc<str>) -> Rc<UH0> {
    let fill_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let (mut v2, mut v3): (Rc<UH2>, Rc<UH6>) = literal_split_of_156(fill_v1, text_v0);
    let s_v4: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
    let mut v5: Rc<UH6> = method75(v3, s_v4);
    let s_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method185(v5, s_v6)
}
fn template_183(mut text_v0: Rc<str>) -> bool {
    let fill_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let backend_v2: Rc<str> = without_literals_155(fill_v1.clone(), text_v0.clone());
    let old_v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("++#"); } LIT.with(|lit| lit.clone()) };
    let backend_v4: Rc<str> = Rc::<str>::from(backend_v2.replace(&*old_v3, &*fill_v1));
    let old_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("^^"); } LIT.with(|lit| lit.clone()) };
    let backend_v6: Rc<str> = Rc::<str>::from(backend_v4.replace(&*old_v5, &*fill_v1));
    let old_v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
    let backend_v8: Rc<str> = Rc::<str>::from(backend_v6.replace(&*old_v7, &*fill_v1));
    let old_v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
    let bare_v10: Rc<str> = Rc::<str>::from(backend_v8.replace(&*old_v9, &*fill_v1));
    let body_v11: Rc<UH0> = literal_pieces_184(text_v0);
    let mut v12: bool = match Rc::unwrap_or_clone(body_v11) {
        UH0::UH0_Nil => {
            true
        }
        _ => {
            false
        }
    };
    let mut v13: bool = v12 != true;
    if v13 {
        let mut v14: Rc<str> = Rc::<str>::from((bare_v10).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
        let mut v15: bool = &*v14 == "";
        v15
    } else {
        false
    }
}
fn body_weight_55(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut ls_v2: Rc<UH0>) -> i32 {
    let text_v3: Rc<str> = joined_lines_143(ls_v2.clone());
    let mut v4: bool = data_literal_154(nominals_v1.clone(), text_v3.clone());
    let v6: bool = if v4 {
        true
    } else {
        structural_174(nominals_v1, ls_v2.clone(), text_v3.clone())
    };
    if v6 {
        0i32
    } else {
        let mut v7: bool = template_183(text_v3.clone());
        if v7 {
            let texts_v8: Rc<UH0> = literal_pieces_184(text_v3);
            heaviest_56(tlds_v0, texts_v8)
        } else {
            shaped_weight_100(tlds_v0, ls_v2, text_v3)
        }
    }
}
fn drop_docs_187(mut v0: Rc<UH0>) -> Rc<UH0> {
    loop {
        match &*v0 {
            UH0::UH0_Cons(backend_v1, lines_v2) => {
                let backend_v1: Rc<str> = backend_v1.clone();
                let lines_v2: Rc<UH0> = lines_v2.clone();
                let search_v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("///"); } LIT.with(|lit| lit.clone()) };
                let mut v4: bool = backend_v1.starts_with(&*search_v3);
                let mut v8: bool = if v4 {
                    let search_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("///>"); } LIT.with(|lit| lit.clone()) };
                    let v6: bool = backend_v1.starts_with(&*search_v5);
                    let mut v7: bool = v6 == false;
                    v7
                } else {
                    false
                };
                if v8 {
                    v0 = lines_v2;
                    continue;
                } else {
                    return v0;
                }
            }
            UH0::UH0_Nil => {
                return { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
            }
        }
    }
}
fn undocumented_186(mut lines_v0: Rc<UH0>) -> Rc<UH0> {
    let rest_v1: Rc<UH0> = drop_docs_187(lines_v0.clone());
    match &*rest_v1 {
        UH0::UH0_Nil => {
            lines_v0
        }
        _ => {
            rest_v1
        }
    }
}
fn plain_ident_192(mut backend_v0: Rc<str>) -> bool {
    let mut v1: bool = &*backend_v0 != "";
    if v1 {
        let search_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v3: bool = backend_v0.contains(&*search_v2);
        let mut v4: bool = v3 == false;
        let mut v8: bool = if v4 {
            let search_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("("); } LIT.with(|lit| lit.clone()) };
            let v6: bool = backend_v0.contains(&*search_v5);
            let mut v7: bool = v6 == false;
            v7
        } else {
            false
        };
        let mut v12: bool = if v8 {
            let search_v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(")"); } LIT.with(|lit| lit.clone()) };
            let v10: bool = backend_v0.contains(&*search_v9);
            let mut v11: bool = v10 == false;
            v11
        } else {
            false
        };
        let v16: bool = if v12 {
            let search_v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\\"); } LIT.with(|lit| lit.clone()) };
            let mut v14: bool = backend_v0.contains(&*search_v13);
            let mut v15: bool = v14 == false;
            v15
        } else {
            false
        };
        if v16 {
            let search_v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\""); } LIT.with(|lit| lit.clone()) };
            let v18: bool = backend_v0.contains(&*search_v17);
            let v19: bool = v18 == false;
            v19
        } else {
            false
        }
    } else {
        false
    }
}
fn drop_front_193(mut backend_v0: i32, mut backend_v1: Rc<str>) -> Rc<str> {
    let mut v2: i32 = (backend_v1.clone().len() as i32);
    let backend_v3: i32 = v2.wrapping_sub(backend_v0);
    let x_v4: usize = ((backend_v0) as usize);
    let backend_v5: i32 = backend_v0.wrapping_add(backend_v3);
    let x_v6: usize = ((backend_v5) as usize);
    let mut v7: Rc<str> = Rc::<str>::from(&(backend_v1)[x_v4..x_v6]);
    v7
}
fn export_line_191(mut backend_v0: Rc<str>) -> bool {
    let t_v1: Rc<str> = Rc::<str>::from((backend_v0).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
    let search_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("export \""); } LIT.with(|lit| lit.clone()) };
    let mut v3: bool = t_v1.starts_with(&*search_v2);
    let rest_v7: Rc<str> = if v3 {
        let n_v4: i32 = 8i32;
        drop_front_193(n_v4, t_v1)
    } else {
        let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v6
    };
    let search_v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\" "); } LIT.with(|lit| lit.clone()) };
    let backend_v9: Option<usize> = rest_v7.find(&*search_v8);
    let x_v10: Option<usize> = method121(backend_v9);
    let mut v11: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v12: Option<i32> = x_v10.map(|x| v11(x));
    let close_v14: i32 = v12.unwrap_or(-1i32);
    let mut v15: bool = close_v14 > 0i32;
    if v15 {
        let n_v16: i32 = close_v14.wrapping_add(2i32);
        let s_v17: Rc<str> = drop_front_193(n_v16, rest_v7);
        plain_ident_192(s_v17)
    } else {
        false
    }
}
fn export_body_190(mut v0: Rc<UH0>) -> bool {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(backend_v1, body_v2) => {
                let backend_v1: Rc<str> = backend_v1;
                let body_v2: Rc<UH0> = body_v2;
                let mut v3: bool = match &*body_v2 {
                    UH0::UH0_Nil => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                if v3 {
                    let mut v4: Rc<str> = Rc::<str>::from((backend_v1).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                    let mut v5: bool = &*v4 == "0i32";
                    return v5;
                } else {
                    let v6: bool = export_line_191(backend_v1);
                    if v6 {
                        v0 = body_v2;
                        continue;
                    } else {
                        return false;
                    }
                }
            }
            UH0::UH0_Nil => {
                return false;
            }
        }
    }
}
fn method194(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method194(v3, s_v1);
            let mut v5: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let v6: bool = &*v5 != "";
            if v6 {
                Rc::new(UH0::UH0_Cons(backend_v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn export_table_189(mut s_v0: Rc<str>) -> bool {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1, s_v0);
    let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v4: Rc<UH0> = method194(v2, s_v3);
    match Rc::unwrap_or_clone(v4) {
        UH0::UH0_Cons(backend_v5, lines_v6) => {
            let backend_v5: Rc<str> = backend_v5;
            let lines_v6: Rc<UH0> = lines_v6;
            let mut v7: Rc<str> = Rc::<str>::from((backend_v5).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let mut v8: bool = &*v7 == ":= main () : i32 =";
            if v8 {
                export_body_190(lines_v6)
            } else {
                false
            }
        }
        UH0::UH0_Nil => {
            false
        }
    }
}
fn host_body_196(mut v0: Rc<UH0>) -> bool {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(backend_v1, body_v2) => {
                let backend_v1: Rc<str> = backend_v1;
                let body_v2: Rc<UH0> = body_v2;
                let mut v3: bool = match &*body_v2 {
                    UH0::UH0_Nil => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                if v3 {
                    let mut v4: Rc<str> = Rc::<str>::from((backend_v1).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                    let mut v5: bool = &*v4 == "\"\"\"";
                    return v5;
                } else {
                    let search_v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("        "); } LIT.with(|lit| lit.clone()) };
                    let mut v7: bool = backend_v1.starts_with(&*search_v6);
                    if v7 {
                        v0 = body_v2;
                        continue;
                    } else {
                        return false;
                    }
                }
            }
            UH0::UH0_Nil => {
                return false;
            }
        }
    }
}
fn method197(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method197(v3, s_v1);
            let mut v5: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            let v6: bool = &*v5 != "";
            if v6 {
                Rc::new(UH0::UH0_Cons(backend_v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn host_global_195(mut s_v0: Rc<str>) -> bool {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1, s_v0);
    let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let lines_v4: Rc<UH0> = method197(v2, s_v3);
    match Rc::unwrap_or_clone(lines_v4) {
        UH0::UH0_Cons(_, v6) => {
            let v6: Rc<UH0> = v6;
            match Rc::unwrap_or_clone(v6) {
                UH0::UH0_Cons(backend_v7, lines_v8) => {
                    let backend_v7: Rc<str> = backend_v7;
                    let lines_v8: Rc<UH0> = lines_v8;
                    let mut v9: Rc<str> = Rc::<str>::from((backend_v7).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                    let v10: bool = &*v9 == "global \"\"\"";
                    if v10 {
                        host_body_196(lines_v8)
                    } else {
                        false
                    }
                }
                _ => {
                    false
                }
            }
        }
        _ => {
            false
        }
    }
}
fn declared_block_188(mut text_v0: Rc<str>) -> bool {
    let mut v1: bool = host_global_195(text_v0.clone());
    if v1 {
        true
    } else {
        export_table_189(text_v0)
    }
}
fn after_equals_199(mut v0: Rc<UH0>) -> US12 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(backend_v2, rest_v3) => {
                let backend_v2: Rc<str> = backend_v2;
                let rest_v3: Rc<UH0> = rest_v3;
                let mut v4: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                let mut v5: bool = &*v4 == "=";
                if v5 {
                    return US12::US12_Body(rest_v3);
                } else {
                    v0 = rest_v3;
                    continue;
                }
            }
            UH0::UH0_Nil => {
                return US12::US12_NoHeader;
            }
        }
    }
}
fn method200(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 <= 0i32;
        if v2 {
            return -1i32;
        } else {
            let i_v3: i32 = v1.wrapping_sub(1i32);
            let mut v4: u8 = v0.clone().as_bytes()[i_v3 as usize];
            let mut v5: bool = v4 == b' ';
            let mut v9: bool = if v5 {
                true
            } else {
                let v6: bool = v4 == b'\t';
                if v6 {
                    true
                } else {
                    let mut v7: bool = v4 == b'\r';
                    v7
                }
            };
            if v9 {
                v1 = i_v3;
                continue;
            } else {
                return i_v3;
            }
        }
    }
}
fn inline_at_202(mut backend_v0: Rc<str>) -> i32 {
    let search_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" = "); } LIT.with(|lit| lit.clone()) };
    let backend_v2: Option<usize> = backend_v0.find(&*search_v1);
    let x_v3: Option<usize> = method121(backend_v2);
    let mut v4: Rc<dyn Fn((usize)) -> i32> = closure9();
    let mut v5: Option<i32> = x_v3.map(|x| v4(x));
    let mut v7: i32 = v5.unwrap_or(-1i32);
    v7
}
fn has_inline_body_201(mut first_v0: Rc<str>) -> bool {
    let at_v1: i32 = inline_at_202(first_v0.clone());
    let backend_v2: i32 = at_v1.wrapping_add(3i32);
    let x_v3: usize = ((backend_v2) as usize);
    let backend_v4: i32 = backend_v2.wrapping_add(1i32);
    let x_v5: usize = ((backend_v4) as usize);
    let next_v6: Rc<str> = Rc::<str>::from(&(first_v0)[x_v3..x_v5]);
    let mut v7: bool = at_v1 >= 0i32;
    let v10: bool = if v7 {
        let mut v8: i32 = (first_v0.len() as i32);
        let mut v9: bool = backend_v2 < v8;
        v9
    } else {
        false
    };
    let mut v12: bool = if v10 {
        let mut v11: bool = &*next_v6 != " ";
        v11
    } else {
        false
    };
    if v12 {
        let mut v13: bool = &*next_v6 != "\t";
        v13
    } else {
        false
    }
}
fn inline_body_203(mut first_v0: Rc<str>) -> Rc<str> {
    let at_v1: i32 = inline_at_202(first_v0.clone());
    let backend_v2: i32 = at_v1.wrapping_add(3i32);
    let mut v3: i32 = (first_v0.clone().len() as i32);
    let mut v4: i32 = v3.wrapping_sub(at_v1);
    let backend_v5: i32 = v4.wrapping_sub(3i32);
    let x_v6: usize = ((backend_v2) as usize);
    let backend_v7: i32 = backend_v2.wrapping_add(backend_v5);
    let x_v8: usize = ((backend_v7) as usize);
    let mut v9: Rc<str> = Rc::<str>::from(&(first_v0)[x_v6..x_v8]);
    v9
}
fn split_header_198(mut v0: &Rc<UH0>) -> US12 {
    match &**v0 {
        UH0::UH0_Cons(s_v2, rest_v3) => {
            let s_v2: Rc<str> = s_v2.clone();
            let rest_v3: Rc<UH0> = rest_v3.clone();
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("///"); } LIT.with(|lit| lit.clone()) };
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":#"); } LIT.with(|lit| lit.clone()) };
            let v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
            let mut v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(v5, v6));
            let prefixes_v8: Rc<UH0> = Rc::new(UH0::UH0_Cons(v4, v7));
            let mut v9: bool = starts_with_any_168(prefixes_v8, s_v2.clone());
            if v9 {
                US12::US12_NoHeader
            } else {
                let len_v11: i32 = (s_v2.clone().len() as i32);
                let backend_v12: i32 = method200(s_v2.clone(), len_v11);
                let backend_v13: Rc<str> = string_slice(&s_v2.clone(), 0i32 as i64, backend_v12 as i64);
                let search_v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" ="); } LIT.with(|lit| lit.clone()) };
                let mut v15: bool = backend_v13.ends_with(&*search_v14);
                if v15 {
                    US12::US12_Body(rest_v3)
                } else {
                    let v17: bool = has_inline_body_201(s_v2.clone());
                    let v21: bool = if v17 {
                        let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
                        let v19: bool = s_v2.starts_with(&*v18);
                        let mut v20: bool = v19 == false;
                        v20
                    } else {
                        false
                    };
                    if v21 {
                        let v22: Rc<str> = inline_body_203(s_v2);
                        let v23: Rc<UH0> = Rc::new(UH0::UH0_Cons(v22, rest_v3));
                        US12::US12_Body(v23)
                    } else {
                        after_equals_199(rest_v3)
                    }
                }
            }
        }
        UH0::UH0_Nil => {
            US12::US12_NoHeader
        }
    }
}
fn ruled_weight_54(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut s_v2: Rc<str>) -> i32 {
    let separator_v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let lines_v4: Rc<UH0> = split_list_12(separator_v3, s_v2.clone());
    let lines_v5: Rc<UH0> = undocumented_186(lines_v4);
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":|"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":=="); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":!"); } LIT.with(|lit| lit.clone()) };
    let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("type "); } LIT.with(|lit| lit.clone()) };
    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("union "); } LIT.with(|lit| lit.clone()) };
    let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("nominal "); } LIT.with(|lit| lit.clone()) };
    let mut v12: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v13: Rc<UH0> = Rc::new(UH0::UH0_Cons(v11, v12));
    let mut v14: Rc<UH0> = Rc::new(UH0::UH0_Cons(v10, v13));
    let mut v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v9, v14));
    let v16: Rc<UH0> = Rc::new(UH0::UH0_Cons(v8, v15));
    let v17: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v16));
    let prefixes_v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v17));
    let s_v19: Rc<str> = joined_lines_143(lines_v5.clone());
    let mut v20: bool = starts_with_any_168(prefixes_v18, s_v19);
    let v22: bool = if v20 {
        true
    } else {
        declared_block_188(s_v2.clone())
    };
    if v22 {
        0i32
    } else {
        let v23: US12 = split_header_198(&lines_v5);
        match v23 {
            US12::US12_Body(body_v24) => {
                let body_v24: Rc<UH0> = body_v24;
                body_weight_55(tlds_v0, nominals_v1, body_v24)
            }
            US12::US12_NoHeader => {
                weight_of_58(tlds_v0, s_v2)
            }
        }
    }
}
fn no_tlds_205() -> US2 {
    let mut v0: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    US2::US2_Listed(v0)
}
fn method208(mut v0: &Rc<RefCell<Mut1>>, mut x_v1: Rc<str>) -> () {
    let s_v2: Rc<str> = v0.borrow().l0.clone();
    let mut v3: Rc<str> = string_concat(&[&*s_v2, &*x_v1]);
    v0.borrow_mut().l0 = v3;
    ()
}
fn format_real_207(mut x_v0: i32) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let result_v2: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v1 }));
    let s_v3: Rc<str> = Rc::<str>::from(format!("{}", x_v0));
    method208(&result_v2, s_v3);
    let mut v4: Rc<str> = result_v2.borrow().l0.clone();
    v4
}
fn header_text_206(mut x_v0: i32) -> Rc<str> {
    let b_v1: Rc<str> = format_real_207(x_v0);
    let mut v3: Rc<str> = string_concat(&["c", &*b_v1, " 1/1\n"]);
    v3
}
fn cell_limit_204(mut k_v0: i32) -> i32 {
    let tlds_v1: US2 = no_tlds_205();
    let s_v2: Rc<str> = header_text_206(k_v0);
    let mut v3: i32 = text_weight_60(tlds_v1, s_v2);
    let mut v4: i32 = weight_value_59(v3);
    let mut v5: i32 = 280i32.wrapping_sub(v4);
    v5
}
fn ruled_finding_209(mut v0: i32, mut v1: i32, mut v2: i32) -> US3 {
    let mut v3: US5 = US5::US5_OverRuled(v0, v1, v2);
    US3::US3_RuledFinding(v3)
}
fn ruled_from_52(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut v2: Rc<UH4>, mut k_v3: i32, mut v4: Rc<UH3>) -> Rc<UH3> {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH4::UH4_Cons(o_v7, block_v8, bs_v9) => {
                let o_v7: i32 = o_v7;
                let block_v8: Rc<str> = block_v8;
                let bs_v9: Rc<UH4> = bs_v9;
                let w_v10: i32 = ruled_weight_54(tlds_v0.clone(), nominals_v1.clone(), block_v8);
                let limit_v11: i32 = cell_limit_204(k_v3);
                let mut v12: i32 = weight_value_59(w_v10);
                let mut v13: i32 = weight_value_59(limit_v11);
                let mut v14: bool = v12 > v13;
                let acc_v17: Rc<UH3> = if v14 {
                    let mut v15: US3 = ruled_finding_209(o_v7, w_v10, limit_v11);
                    Rc::new(UH3::UH3_Cons(v15, v4))
                } else {
                    v4
                };
                let k_v18: i32 = k_v3.wrapping_add(1i32);
                (v2, k_v3, v4) = (bs_v9, k_v18, acc_v17);
                continue;
            }
            UH4::UH4_Nil => {
                let s_v5: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
                return method53(v4, s_v5);
            }
        }
    }
}
fn method211(mut v0: Rc<UH4>, mut v1: Rc<UH4>) -> Rc<UH4> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH4::UH4_Cons(v2, v3, v4) => {
                let mut v2: i32 = v2;
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH4> = v4;
                let s_v5: Rc<UH4> = Rc::new(UH4::UH4_Cons(v2, v3, v1));
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH4::UH4_Nil => {
                return v1;
            }
        }
    }
}
fn base_lines_213(mut a_v0: Rc<RefCell<Vec<Rc<str>>>>, mut backend_v1: i32, mut v2: Rc<UH0>) -> Rc<UH0> {
    loop {
        let mut v3: bool = backend_v1 < 0i32;
        if v3 {
            return v2;
        } else {
            let i_v4: i32 = backend_v1.wrapping_sub(1i32);
            let mut v5: Rc<str> = a_v0.borrow()[backend_v1 as usize].clone();
            let acc_v6: Rc<UH0> = Rc::new(UH0::UH0_Cons(v5, v2));
            (backend_v1, v2) = (i_v4, acc_v6);
            continue;
        }
    }
}
fn source_lines_212(mut backend_v0: Rc<str>) -> Rc<UH0> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\r\n"); } LIT.with(|lit| lit.clone()) };
    let separator_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let backend_v3: Rc<str> = Rc::<str>::from(backend_v0.replace(&*v1, &*separator_v2));
    let a_v4: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(backend_v3.split(&*separator_v2).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
    let mut v5: i32 = (a_v4.clone().borrow().len() as i32);
    let i_v6: i32 = v5.wrapping_sub(1i32);
    let acc_v7: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    base_lines_213(a_v4, i_v6, acc_v7)
}
fn blank_seen_216(mut v0: Rc<UH4>, mut v1: Rc<UH0>, mut v2: i32, mut v3: i32, mut v4: bool) -> (Rc<UH4>, Rc<UH0>, i32, i32, bool) {
    let mut v5: i32 = v3.wrapping_add(1i32);
    (v0, v1, v2, v5, v4)
}
fn method219(mut v0: Rc<str>, mut v1: i32) -> i32 {
    loop {
        let mut v2: bool = v1 <= 0i32;
        if v2 {
            return -1i32;
        } else {
            let i_v3: i32 = v1.wrapping_sub(1i32);
            let mut v4: u8 = v0.clone().as_bytes()[i_v3 as usize];
            let mut v5: bool = v4 == b' ';
            let mut v9: bool = if v5 {
                true
            } else {
                let v6: bool = v4 == b'\t';
                if v6 {
                    true
                } else {
                    let mut v7: bool = v4 == b'\n';
                    v7
                }
            };
            if v9 {
                v1 = i_v3;
                continue;
            } else {
                return i_v3;
            }
        }
    }
}
fn finished_218(mut v0: Rc<UH4>, mut cur_v1: Rc<UH0>, mut v2: i32, mut v3: i32, mut v4: bool) -> Rc<UH4> {
    match &*cur_v1 {
        UH0::UH0_Nil => {
            v0
        }
        _ => {
            let s_v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
            let ls_v6: Rc<UH0> = method13(cur_v1, s_v5);
            let backend_v7: Rc<str> = joined_lines_143(ls_v6);
            let len_v8: i32 = (backend_v7.clone().len() as i32);
            let backend_v9: i32 = method219(backend_v7.clone(), len_v8);
            let v10: Rc<str> = string_slice(&backend_v7, 0i32 as i64, backend_v9 as i64);
            Rc::new(UH4::UH4_Cons(v2, v10, v0))
        }
    }
}
fn new_block_217(mut s_v0: Rc<UH4>, mut s_v1: Rc<UH0>, mut s_v2: i32, mut s_v3: i32, mut s_v4: bool, mut v5: i32, mut v6: Rc<str>) -> (Rc<UH4>, Rc<UH0>, i32, i32, bool) {
    let mut v7: Rc<UH4> = finished_218(s_v0, s_v1, s_v2, s_v3, s_v4);
    let mut v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v8));
    (v7, v9, v5, 0i32, true)
}
fn blank_lines_221(mut v0: i32, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        let mut v2: bool = v0 <= 0i32;
        if v2 {
            return v1;
        } else {
            let n_v3: i32 = v0.wrapping_sub(1i32);
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
            let acc_v5: Rc<UH0> = Rc::new(UH0::UH0_Cons(v4, v1));
            (v0, v1) = (n_v3, acc_v5);
            continue;
        }
    }
}
fn grown_220(mut v0: Rc<UH4>, mut acc_v1: Rc<UH0>, mut v2: i32, mut n_v3: i32, mut v4: bool, mut v5: i32, mut v6: Rc<str>) -> (Rc<UH4>, Rc<UH0>, i32, i32, bool) {
    let start_v7: i32 = if v4 {
        v2
    } else {
        v5
    };
    let mut v8: Rc<UH0> = blank_lines_221(n_v3, acc_v1);
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v8));
    (v0, v9, start_v7, 0i32, true)
}
fn opens_block_222(mut v0: &Rc<UH4>, mut v1: &Rc<UH0>, mut v2: i32, mut v3: i32, mut v4: bool, mut backend_v5: Rc<str>) -> bool {
    let v6: bool = v3 > 0i32;
    let mut v7: bool = v6 && v4;
    if v7 {
        let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" "); } LIT.with(|lit| lit.clone()) };
        let mut v9: bool = backend_v5.starts_with(&*v8);
        let mut v12: bool = if v9 {
            true
        } else {
            let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t"); } LIT.with(|lit| lit.clone()) };
            let mut v11: bool = backend_v5.starts_with(&*v10);
            v11
        };
        let mut v13: bool = v12 == false;
        v13
    } else {
        false
    }
}
fn scan_line_215(mut s_v0: Rc<UH4>, mut s_v1: Rc<UH0>, mut s_v2: i32, mut s_v3: i32, mut s_v4: bool, mut row_v5: i32, mut line_v6: Rc<str>) -> (Rc<UH4>, Rc<UH0>, i32, i32, bool) {
    let mut v7: bool = &*line_v6 == "";
    let (mut v29, mut v30, mut v31, mut v32, mut v33): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = if v7 {
        let (mut v8, mut v9, mut v10, mut v11, mut v12): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = blank_seen_216(s_v0, s_v1, s_v2, s_v3, s_v4);
        (v8, v9, v10, v11, v12)
    } else {
        let mut v13: bool = opens_block_222(&s_v0, &s_v1, s_v2, s_v3, s_v4, line_v6.clone());
        let (mut v24, mut v25, mut v26, mut v27, mut v28): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = if v13 {
            let (mut v14, mut v15, mut v16, mut v17, mut v18): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = new_block_217(s_v0, s_v1, s_v2, s_v3, s_v4, row_v5, line_v6);
            (v14, v15, v16, v17, v18)
        } else {
            let (mut v19, mut v20, mut v21, mut v22, mut v23): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = grown_220(s_v0, s_v1, s_v2, s_v3, s_v4, row_v5, line_v6);
            (v19, v20, v21, v22, v23)
        };
        (v24, v25, v26, v27, v28)
    };
    (v29, v30, v31, v32, v33)
}
fn scan_lines_214(mut s_v0: Rc<UH4>, mut s_v1: Rc<UH0>, mut s_v2: i32, mut s_v3: i32, mut s_v4: bool, mut row_v5: i32, mut v6: Rc<UH0>) -> (Rc<UH4>, Rc<UH0>, i32, i32, bool) {
    loop {
        match &*v6 {
            UH0::UH0_Nil => {
                return (s_v0, s_v1, s_v2, s_v3, s_v4);
            }
            _ => {
                match Rc::unwrap_or_clone(v6) {
                    UH0::UH0_Cons(line_v7, lines_v8) => {
                        let line_v7: Rc<str> = line_v7;
                        let lines_v8: Rc<UH0> = lines_v8;
                        let (mut s_v9, mut s_v10, mut s_v11, mut s_v12, mut s_v13): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = scan_line_215(s_v0, s_v1, s_v2, s_v3, s_v4, row_v5, line_v7);
                        let row_v14: i32 = row_v5.wrapping_add(1i32);
                        (s_v0, s_v1, s_v2, s_v3, s_v4, row_v5, v6) = (s_v9, s_v10, s_v11, s_v12, s_v13, row_v14, lines_v8);
                        continue;
                    }
                    _ => unreachable!(),
                }
            }
        }
    }
}
fn blocks_210(mut source_v0: Rc<str>) -> Rc<UH4> {
    let s_v1: Rc<UH4> = { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_Nil); } CASE.with(|case| case.clone()) };
    let s_v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let s_v3: i32 = 1i32;
    let s_v4: i32 = 0i32;
    let s_v5: bool = false;
    let row_v6: i32 = 1i32;
    let lines_v7: Rc<UH0> = source_lines_212(source_v0);
    let (mut s_v8, mut s_v9, mut s_v10, mut s_v11, mut s_v12): (Rc<UH4>, Rc<UH0>, i32, i32, bool) = scan_lines_214(s_v1, s_v2, s_v3, s_v4, s_v5, row_v6, lines_v7);
    let mut v13: Rc<UH4> = finished_218(s_v8, s_v9, s_v10, s_v11, s_v12);
    let s_v14: Rc<UH4> = { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_Nil); } CASE.with(|case| case.clone()) };
    method211(v13, s_v14)
}
fn ruled_over_51(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut source_v2: Rc<str>) -> Rc<UH3> {
    let bs_v3: Rc<UH4> = blocks_210(source_v2);
    let k_v4: i32 = 1i32;
    let acc_v5: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
    ruled_from_52(tlds_v0, nominals_v1, bs_v3, k_v4, acc_v5)
}
fn block_over_226(mut tlds_v0: US2, mut v1: i32, mut s_v2: Rc<str>, mut k_v3: i32) -> (i32, i32, i32) {
    let mut v4: i32 = text_weight_60(tlds_v0, s_v2);
    let mut v5: i32 = cell_limit_204(k_v3);
    (v1, v4, v5)
}
fn budget_finding_227(mut v0: i32, mut v1: i32, mut v2: i32) -> US3 {
    let mut v3: US4 = US4::US4_OverBudget(v0, v1, v2);
    US3::US3_BudgetFinding(v3)
}
fn block_finding_225(mut tlds_v0: US2, mut b_v1: i32, mut b_v2: Rc<str>, mut k_v3: i32, mut v4: Rc<UH3>) -> Rc<UH3> {
    let (mut o_v5, mut o_v6, mut o_v7): (i32, i32, i32) = block_over_226(tlds_v0, b_v1, b_v2, k_v3);
    let mut v8: i32 = weight_value_59(o_v6);
    let mut v9: i32 = weight_value_59(o_v7);
    let v10: bool = v8 > v9;
    if v10 {
        let mut v11: US3 = budget_finding_227(o_v5, o_v6, o_v7);
        Rc::new(UH3::UH3_Cons(v11, v4))
    } else {
        v4
    }
}
fn over_from_224(mut tlds_v0: US2, mut v1: Rc<UH4>, mut k_v2: i32, mut a_v3: Rc<UH3>) -> Rc<UH3> {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH4::UH4_Cons(b_v6, text_v7, bs_v8) => {
                let b_v6: i32 = b_v6;
                let text_v7: Rc<str> = text_v7;
                let bs_v8: Rc<UH4> = bs_v8;
                let k_v9: i32 = k_v2.wrapping_add(1i32);
                let v10: bool = declared_block_188(text_v7.clone());
                let acc_v12: Rc<UH3> = if v10 {
                    a_v3
                } else {
                    block_finding_225(tlds_v0.clone(), b_v6, text_v7, k_v2, a_v3)
                };
                (v1, k_v2, a_v3) = (bs_v8, k_v9, acc_v12);
                continue;
            }
            UH4::UH4_Nil => {
                let s_v4: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
                return method53(a_v3, s_v4);
            }
        }
    }
}
fn over_budget_223(mut tlds_v0: US2, mut source_v1: Rc<str>) -> Rc<UH3> {
    let bs_v2: Rc<UH4> = blocks_210(source_v1);
    let k_v3: i32 = 1i32;
    let acc_v4: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
    over_from_224(tlds_v0, bs_v2, k_v3, acc_v4)
}
fn rewrite_finding_230(mut v0: US7, mut v1: i32, mut v2: i32, mut v3: Rc<str>) -> US3 {
    let mut v4: US6 = US6::US6_Rewritten(v0, v1, v2, v3);
    US3::US3_RewriteFinding(v4)
}
fn method229(mut v0: Rc<UH8>, mut s_v1: Rc<UH3>) -> Rc<UH3> {
    match Rc::unwrap_or_clone(v0) {
        UH8::UH8_Cons(r_v2, r_v3, r_v4, r_v5, v6) => {
            let r_v2: US7 = r_v2;
            let r_v3: i32 = r_v3;
            let r_v4: i32 = r_v4;
            let r_v5: Rc<str> = r_v5;
            let v6: Rc<UH8> = v6;
            let mut v7: Rc<UH3> = method229(v6, s_v1);
            let mut v8: US3 = rewrite_finding_230(r_v2, r_v3, r_v4, r_v5);
            Rc::new(UH3::UH3_Cons(v8, v7))
        }
        UH8::UH8_Nil => {
            s_v1
        }
    }
}
fn method232(mut v0: Rc<UH8>, mut v1: Rc<UH8>) -> Rc<UH8> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH8::UH8_Cons(v2, v3, v4, v5, v6) => {
                let mut v2: US7 = v2;
                let mut v3: i32 = v3;
                let mut v4: i32 = v4;
                let mut v5: Rc<str> = v5;
                let v6: Rc<UH8> = v6;
                let s_v7: Rc<UH8> = Rc::new(UH8::UH8_Cons(v2, v3, v4, v5, v1));
                (v0, v1) = (v6, s_v7);
                continue;
            }
            UH8::UH8_Nil => {
                return v1;
            }
        }
    }
}
fn method238(mut v0: Rc<UH8>, mut s_v1: Rc<UH8>) -> Rc<UH8> {
    match Rc::unwrap_or_clone(v0) {
        UH8::UH8_Cons(v2, v3, v4, v5, v6) => {
            let mut v2: US7 = v2;
            let mut v3: i32 = v3;
            let mut v4: i32 = v4;
            let mut v5: Rc<str> = v5;
            let v6: Rc<UH8> = v6;
            let mut v7: Rc<UH8> = method238(v6, s_v1);
            Rc::new(UH8::UH8_Cons(v2, v3, v4, v5, v7))
        }
        UH8::UH8_Nil => {
            s_v1
        }
    }
}
fn merged_237(mut f_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut s_v1: Rc<UH8>, mut s_v2: Rc<UH8>, mut v3: Rc<UH8>) -> Rc<UH8> {
    loop {
        match &*s_v1 {
            UH8::UH8_Cons(v7, v8, v9, v10, a_v11) => {
                let mut v7: US7 = v7.clone();
                let mut v8: i32 = *v8;
                let mut v9: i32 = *v9;
                let v10: Rc<str> = v10.clone();
                let a_v11: Rc<UH8> = a_v11.clone();
                match &*s_v2 {
                    UH8::UH8_Cons(v15, v16, v17, v18, b_v19) => {
                        let mut v15: US7 = v15.clone();
                        let v16: i32 = *v16;
                        let v17: i32 = *v17;
                        let v18: Rc<str> = v18.clone();
                        let b_v19: Rc<UH8> = b_v19.clone();
                        let mut v20: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> = f_v0(v15.clone(), v16, v17, v18.clone());
                        let v21: bool = v20(v7.clone(), v8, v9, v10.clone());
                        if v21 {
                            let o_v22: Rc<UH8> = Rc::new(UH8::UH8_Cons(v15, v16, v17, v18, v3));
                            (s_v2, v3) = (b_v19, o_v22);
                            continue;
                        } else {
                            let o_v24: Rc<UH8> = Rc::new(UH8::UH8_Cons(v7, v8, v9, v10, v3));
                            (s_v1, v3) = (a_v11, o_v24);
                            continue;
                        }
                    }
                    UH8::UH8_Nil => {
                        let s_v12: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                        let mut v13: Rc<UH8> = method232(v3, s_v12);
                        return method238(v13, s_v1);
                    }
                }
            }
            UH8::UH8_Nil => {
                let s_v4: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                let mut v5: Rc<UH8> = method232(v3, s_v4);
                return method238(v5, s_v2);
            }
        }
    }
}
fn merged_pairs_236(mut f_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut v1: Rc<UH9>) -> Rc<UH9> {
    match &*v1 {
        UH9::UH9_Cons(a_v2, v3) => {
            let a_v2: Rc<UH8> = a_v2.clone();
            let mut v3: Rc<UH9> = v3.clone();
            match Rc::unwrap_or_clone(v3) {
                UH9::UH9_Cons(b_v4, runs_v5) => {
                    let b_v4: Rc<UH8> = b_v4;
                    let runs_v5: Rc<UH9> = runs_v5;
                    let o_v6: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                    let mut v7: Rc<UH8> = merged_237(f_v0.clone(), a_v2, b_v4, o_v6);
                    let mut v8: Rc<UH9> = merged_pairs_236(f_v0, runs_v5);
                    Rc::new(UH9::UH9_Cons(v7, v8))
                }
                _ => {
                    v1
                }
            }
        }
        _ => {
            v1
        }
    }
}
fn merged_all_235(mut first_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut runs_v1: Rc<UH9>) -> Rc<UH8> {
    loop {
        match &*runs_v1 {
            UH9::UH9_Cons(v3, v4) => {
                let mut v3: Rc<UH8> = v3.clone();
                let mut v4: Rc<UH9> = v4.clone();
                match Rc::unwrap_or_clone(v4) {
                    UH9::UH9_Nil => {
                        return v3;
                    }
                    _ => {
                        let runs_v5: Rc<UH9> = merged_pairs_236(first_v0.clone(), runs_v1);
                        runs_v1 = runs_v5;
                        continue;
                    }
                }
            }
            UH9::UH9_Nil => {
                return { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
            }
        }
    }
}
fn method240(mut v0: Rc<UH9>, mut v1: Rc<UH9>) -> Rc<UH9> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH9::UH9_Cons(v2, v3) => {
                let mut v2: Rc<UH8> = v2;
                let mut v3: Rc<UH9> = v3;
                let s_v4: Rc<UH9> = Rc::new(UH9::UH9_Cons(v2, v1));
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH9::UH9_Nil => {
                return v1;
            }
        }
    }
}
fn falling_241(mut first_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut v1: Rc<UH8>, mut v2: Rc<UH8>) -> (Rc<UH8>, Rc<UH8>) {
    loop {
        match &*v1 {
            UH8::UH8_Cons(v3, v4, v5, v6, l_v7) => {
                let mut v3: US7 = v3.clone();
                let mut v4: i32 = *v4;
                let mut v5: i32 = *v5;
                let v6: Rc<str> = v6.clone();
                let l_v7: Rc<UH8> = l_v7.clone();
                let v16: bool = match &*v2 {
                    UH8::UH8_Cons(v8, v9, v10, v11, _) => {
                        let mut v8: US7 = v8.clone();
                        let mut v9: i32 = *v9;
                        let v10: i32 = *v10;
                        let mut v11: Rc<str> = v11.clone();
                        let mut v13: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> = first_v0(v3.clone(), v4, v5, v6.clone());
                        v13(v8, v9, v10, v11)
                    }
                    UH8::UH8_Nil => {
                        true
                    }
                };
                if v16 {
                    let cur_v17: Rc<UH8> = Rc::new(UH8::UH8_Cons(v3, v4, v5, v6, v2));
                    (v1, v2) = (l_v7, cur_v17);
                    continue;
                } else {
                    return (v2, v1);
                }
            }
            _ => {
                return (v2, v1);
            }
        }
    }
}
fn rising_242(mut first_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut v1: Rc<UH8>, mut v2: Rc<UH8>) -> (Rc<UH8>, Rc<UH8>) {
    loop {
        match &*v1 {
            UH8::UH8_Cons(v3, v4, v5, v6, l_v7) => {
                let mut v3: US7 = v3.clone();
                let mut v4: i32 = *v4;
                let mut v5: i32 = *v5;
                let v6: Rc<str> = v6.clone();
                let l_v7: Rc<UH8> = l_v7.clone();
                let v17: bool = match &*v2 {
                    UH8::UH8_Cons(v8, v9, v10, v11, _) => {
                        let mut v8: US7 = v8.clone();
                        let mut v9: i32 = *v9;
                        let v10: i32 = *v10;
                        let mut v11: Rc<str> = v11.clone();
                        let mut v13: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> = first_v0(v3.clone(), v4, v5, v6.clone());
                        let mut v14: bool = v13(v8, v9, v10, v11);
                        let mut v15: bool = v14 == false;
                        v15
                    }
                    UH8::UH8_Nil => {
                        true
                    }
                };
                if v17 {
                    let cur_v18: Rc<UH8> = Rc::new(UH8::UH8_Cons(v3, v4, v5, v6, v2));
                    (v1, v2) = (l_v7, cur_v18);
                    continue;
                } else {
                    let s_v21: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                    let v22: Rc<UH8> = method232(v2, s_v21);
                    return (v22, v1);
                }
            }
            _ => {
                let s_v25: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                let v26: Rc<UH8> = method232(v2, s_v25);
                return (v26, v1);
            }
        }
    }
}
fn runs_of_239(mut first_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut l_v1: Rc<UH8>, mut v2: Rc<UH9>) -> Rc<UH9> {
    loop {
        match &*l_v1 {
            UH8::UH8_Cons(v5, v6, v7, v8, v9) => {
                let mut v5: US7 = v5.clone();
                let v6: i32 = *v6;
                let mut v7: i32 = *v7;
                let mut v8: Rc<str> = v8.clone();
                let mut v9: Rc<UH8> = v9.clone();
                match Rc::unwrap_or_clone(v9) {
                    UH8::UH8_Cons(v10, v11, v12, v13, _) => {
                        let v10: US7 = v10;
                        let mut v11: i32 = v11;
                        let mut v12: i32 = v12;
                        let mut v13: Rc<str> = v13;
                        let mut v15: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> = first_v0(v10, v11, v12, v13);
                        let v16: bool = v15(v5, v6, v7, v8);
                        if v16 {
                            let cur_v17: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                            let (mut v18, mut l_v19): (Rc<UH8>, Rc<UH8>) = falling_241(first_v0.clone(), l_v1, cur_v17);
                            let acc_v20: Rc<UH9> = Rc::new(UH9::UH9_Cons(v18, v2));
                            (l_v1, v2) = (l_v19, acc_v20);
                            continue;
                        } else {
                            let cur_v22: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                            let (mut v23, mut l_v24): (Rc<UH8>, Rc<UH8>) = rising_242(first_v0.clone(), l_v1, cur_v22);
                            let acc_v25: Rc<UH9> = Rc::new(UH9::UH9_Cons(v23, v2));
                            (l_v1, v2) = (l_v24, acc_v25);
                            continue;
                        }
                    }
                    _ => {
                        let cur_v28: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                        let (mut v29, mut l_v30): (Rc<UH8>, Rc<UH8>) = rising_242(first_v0.clone(), l_v1, cur_v28);
                        let acc_v31: Rc<UH9> = Rc::new(UH9::UH9_Cons(v29, v2));
                        (l_v1, v2) = (l_v30, acc_v31);
                        continue;
                    }
                }
            }
            UH8::UH8_Nil => {
                let s_v3: Rc<UH9> = { thread_local!{ static CASE: Rc<UH9> = Rc::new(UH9::UH9_Nil); } CASE.with(|case| case.clone()) };
                return method240(v2, s_v3);
            }
        }
    }
}
fn sorted_by_234(mut first_v0: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>>, mut l_v1: Rc<UH8>) -> Rc<UH8> {
    let acc_v2: Rc<UH9> = { thread_local!{ static CASE: Rc<UH9> = Rc::new(UH9::UH9_Nil); } CASE.with(|case| case.clone()) };
    let runs_v3: Rc<UH9> = runs_of_239(first_v0.clone(), l_v1, acc_v2);
    merged_all_235(first_v0, runs_v3)
}
fn word_point_247(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_alnum_32(c_v0);
    let mut v3: bool = if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 95i32;
        v2
    };
    if v3 {
        true
    } else {
        wide_word_82(c_v0)
    }
}
fn closure19() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        word_point_247(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn letter_point_250(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_letter_33(c_v0);
    if v1 {
        true
    } else {
        wide_word_82(c_v0)
    }
}
fn method249(mut v0: Rc<UH2>, mut v1: bool) -> bool {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(c_v2, v3) => {
                let c_v2: i32 = c_v2;
                let mut v3: Rc<UH2> = v3;
                let s_v5: bool = if v1 {
                    true
                } else {
                    letter_point_250(c_v2)
                };
                (v0, v1) = (v3, s_v5);
                continue;
            }
            UH2::UH2_Nil => {
                return v1;
            }
        }
    }
}
fn has_letter_248(mut v0: Rc<UH2>) -> bool {
    let s_v1: bool = false;
    method249(v0, s_v1)
}
fn hashtag_body_246(mut v0: i32, mut cps_v1: Rc<UH2>) -> US10 {
    let f_v2: Rc<dyn Fn(i32) -> bool> = closure19();
    let acc_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut r_v4, mut r_v5): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v2, cps_v1, acc_v3);
    let v6: bool = has_letter_248(r_v4.clone());
    if v6 {
        let mut v7: Rc<UH2> = Rc::new(UH2::UH2_Cons(v0, r_v4));
        US10::US10_Some(v7, r_v5)
    } else {
        US10::US10_None
    }
}
fn hash_sign_251(mut v0: i32) -> bool {
    let mut v1: bool = v0 == 35i32;
    if v1 {
        true
    } else {
        let mut v2: bool = v0 == 65283i32;
        v2
    }
}
fn blocks_hashtag_252(mut c_v0: i32) -> bool {
    let mut v1: bool = word_point_247(c_v0);
    let mut v3: bool = if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 38i32;
        v2
    };
    if v3 {
        true
    } else {
        hash_sign_251(c_v0)
    }
}
fn hashtag_at_245(mut prev_v0: i32, mut v1: &Rc<UH2>) -> US10 {
    match &**v1 {
        UH2::UH2_Cons(c_v2, rest_v3) => {
            let c_v2: i32 = *c_v2;
            let rest_v3: Rc<UH2> = rest_v3.clone();
            let mut v4: bool = hash_sign_251(c_v2);
            let mut v7: bool = if v4 {
                let mut v5: bool = blocks_hashtag_252(prev_v0);
                let v6: bool = v5 == false;
                v6
            } else {
                false
            };
            if v7 {
                hashtag_body_246(c_v2, rest_v3)
            } else {
                US10::US10_None
            }
        }
        UH2::UH2_Nil => {
            US10::US10_None
        }
    }
}
fn handle_point_255(mut c_v0: i32) -> bool {
    let mut v1: bool = ascii_alnum_32(c_v0);
    if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 95i32;
        v2
    }
}
fn closure20() -> Rc<dyn Fn(i32) -> bool> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> bool> = Rc::new(move |mut v0: i32| -> bool {
        handle_point_255(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn at_sign_257(mut v0: i32) -> bool {
    let mut v1: bool = v0 == 64i32;
    if v1 {
        true
    } else {
        let mut v2: bool = v0 == 65312i32;
        v2
    }
}
fn handle_ends_256(mut c_v0: i32) -> bool {
    let mut v1: bool = handle_point_255(c_v0);
    let mut v2: bool = v1 == false;
    if v2 {
        let mut v3: bool = at_sign_257(c_v0);
        let mut v4: bool = v3 == false;
        v4
    } else {
        false
    }
}
fn mention_body_254(mut v0: i32, mut cps_v1: Rc<UH2>) -> US10 {
    let f_v2: Rc<dyn Fn(i32) -> bool> = closure20();
    let acc_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut r_v4, mut r_v5): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v2, cps_v1, acc_v3);
    let s_v6: i32 = 0i32;
    let n_v7: i32 = method70(r_v4.clone(), s_v6);
    let mut v8: bool = n_v7 >= 1i32;
    let v10: bool = if v8 {
        let mut v9: bool = n_v7 <= 15i32;
        v9
    } else {
        false
    };
    let mut v13: bool = if v10 {
        let next_v11: i32 = first_point_38(&r_v5);
        handle_ends_256(next_v11)
    } else {
        false
    };
    if v13 {
        let mut v14: Rc<UH2> = Rc::new(UH2::UH2_Cons(v0, r_v4));
        US10::US10_Some(v14, r_v5)
    } else {
        US10::US10_None
    }
}
fn blocks_mention_258(mut c_v0: i32) -> bool {
    let mut v1: bool = word_point_247(c_v0);
    let mut v3: bool = if v1 {
        true
    } else {
        at_sign_257(c_v0)
    };
    let mut v5: bool = if v3 {
        true
    } else {
        let mut v4: bool = c_v0 == 33i32;
        v4
    };
    let mut v7: bool = if v5 {
        true
    } else {
        let v6: bool = c_v0 == 35i32;
        v6
    };
    let mut v9: bool = if v7 {
        true
    } else {
        let mut v8: bool = c_v0 == 36i32;
        v8
    };
    let mut v11: bool = if v9 {
        true
    } else {
        let v10: bool = c_v0 == 37i32;
        v10
    };
    let mut v13: bool = if v11 {
        true
    } else {
        let mut v12: bool = c_v0 == 38i32;
        v12
    };
    if v13 {
        true
    } else {
        let mut v14: bool = c_v0 == 42i32;
        v14
    }
}
fn mention_at_253(mut prev_v0: i32, mut v1: &Rc<UH2>) -> US10 {
    match &**v1 {
        UH2::UH2_Cons(c_v2, rest_v3) => {
            let c_v2: i32 = *c_v2;
            let rest_v3: Rc<UH2> = rest_v3.clone();
            let mut v4: bool = at_sign_257(c_v2);
            let mut v7: bool = if v4 {
                let mut v5: bool = blocks_mention_258(prev_v0);
                let v6: bool = v5 == false;
                v6
            } else {
                false
            };
            if v7 {
                mention_body_254(c_v2, rest_v3)
            } else {
                US10::US10_None
            }
        }
        UH2::UH2_Nil => {
            US10::US10_None
        }
    }
}
fn suffix_fits_262(mut v0: i32, mut v1: Rc<UH2>, mut p_v2: &Rc<UH2>) -> bool {
    let s_v3: i32 = 0i32;
    let m_v4: i32 = method70(v1, s_v3);
    let mut v5: bool = v0 == 46i32;
    let mut v7: bool = if v5 {
        true
    } else {
        let v6: bool = v0 == 95i32;
        v6
    };
    let mut v9: bool = if v7 {
        let mut v8: bool = m_v4 >= 1i32;
        v8
    } else {
        false
    };
    let mut v11: bool = if v9 {
        let v10: bool = m_v4 <= 2i32;
        v10
    } else {
        false
    };
    if v11 {
        let c_v12: i32 = first_point_38(p_v2);
        let mut v13: bool = word_point_247(c_v12);
        let mut v14: bool = v13 == false;
        v14
    } else {
        false
    }
}
fn cashtag_end_261(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> US10 {
    match &*v1 {
        UH2::UH2_Cons(d_v4, cps_v5) => {
            let d_v4: i32 = *d_v4;
            let cps_v5: Rc<UH2> = cps_v5.clone();
            let f_v6: Rc<dyn Fn(i32) -> bool> = closure6();
            let acc_v7: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
            let (mut g_v8, mut g_v9): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v6, cps_v5, acc_v7);
            let v10: bool = suffix_fits_262(d_v4, g_v8.clone(), &g_v9);
            if v10 {
                let s_v11: Rc<UH2> = Rc::new(UH2::UH2_Cons(d_v4, g_v8));
                let mut v12: Rc<UH2> = method161(v0, s_v11);
                US10::US10_Some(v12, g_v9)
            } else {
                let mut v14: bool = word_point_247(d_v4);
                if v14 {
                    US10::US10_None
                } else {
                    US10::US10_Some(v0, v1)
                }
            }
        }
        UH2::UH2_Nil => {
            let mut v2: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
            US10::US10_Some(v0, v2)
        }
    }
}
fn cashtag_body_260(mut v0: i32, mut cps_v1: Rc<UH2>) -> US10 {
    let f_v2: Rc<dyn Fn(i32) -> bool> = closure6();
    let acc_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let (mut r_v4, mut r_v5): (Rc<UH2>, Rc<UH2>) = run_while_36(f_v2, cps_v1, acc_v3);
    let s_v6: i32 = 0i32;
    let n_v7: i32 = method70(r_v4.clone(), s_v6);
    let mut v8: bool = n_v7 >= 1i32;
    let v10: bool = if v8 {
        let mut v9: bool = n_v7 <= 6i32;
        v9
    } else {
        false
    };
    if v10 {
        let head_v11: Rc<UH2> = Rc::new(UH2::UH2_Cons(v0, r_v4));
        cashtag_end_261(head_v11, r_v5)
    } else {
        US10::US10_None
    }
}
fn blocks_cashtag_263(mut c_v0: i32) -> bool {
    let mut v1: bool = word_point_247(c_v0);
    if v1 {
        true
    } else {
        let mut v2: bool = c_v0 == 36i32;
        v2
    }
}
fn cashtag_at_259(mut prev_v0: i32, mut v1: &Rc<UH2>) -> US10 {
    match &**v1 {
        UH2::UH2_Cons(s_v2, rest_v3) => {
            let s_v2: i32 = *s_v2;
            let rest_v3: Rc<UH2> = rest_v3.clone();
            let mut v4: bool = s_v2 == 36i32;
            let mut v7: bool = if v4 {
                let mut v5: bool = blocks_cashtag_263(prev_v0);
                let v6: bool = v5 == false;
                v6
            } else {
                false
            };
            if v7 {
                cashtag_body_260(s_v2, rest_v3)
            } else {
                US10::US10_None
            }
        }
        UH2::UH2_Nil => {
            US10::US10_None
        }
    }
}
fn first_mark_244(mut prev_v0: i32, mut cps_v1: &Rc<UH2>) -> US13 {
    let mut v2: US10 = hashtag_at_245(prev_v0, cps_v1);
    let mut v3: US10 = mention_at_253(prev_v0, cps_v1);
    let mut v4: US10 = cashtag_at_259(prev_v0, cps_v1);
    match v2 {
        US10::US10_None => {
            match v3 {
                US10::US10_None => {
                    match v4 {
                        US10::US10_None => {
                            US13::US13_None
                        }
                        US10::US10_Some(c_v13, c_v14) => {
                            let c_v13: Rc<UH2> = c_v13;
                            let c_v14: Rc<UH2> = c_v14;
                            let mut v15: US7 = US7::US7_Cashtag;
                            US13::US13_Some(v15, c_v13, c_v14)
                        }
                    }
                }
                US10::US10_Some(m_v9, m_v10) => {
                    let m_v9: Rc<UH2> = m_v9;
                    let m_v10: Rc<UH2> = m_v10;
                    let mut v11: US7 = US7::US7_Mention;
                    US13::US13_Some(v11, m_v9, m_v10)
                }
            }
        }
        US10::US10_Some(h_v5, h_v6) => {
            let h_v5: Rc<UH2> = h_v5;
            let h_v6: Rc<UH2> = h_v6;
            let mut v7: US7 = US7::US7_Hashtag;
            US13::US13_Some(v7, h_v5, h_v6)
        }
    }
}
fn marked_264(mut v0: i32, mut v1: i32, mut v2: US7, mut p_v3: Rc<UH2>) -> (US7, i32, i32, Rc<str>) {
    let mut v4: i32 = v1.wrapping_add(1i32);
    let mut v5: Rc<str> = written_of_39(p_v3);
    (v2, v0, v4, v5)
}
fn scan_marks_243(mut row_v0: i32, mut prev_v1: i32, mut at_v2: i32, mut cps_v3: Rc<UH2>, mut acc_v4: Rc<UH8>) -> Rc<UH8> {
    loop {
        match &*cps_v3 {
            UH2::UH2_Cons(d_v5, cps_v6) => {
                let d_v5: i32 = *d_v5;
                let cps_v6: Rc<UH2> = cps_v6.clone();
                let mut v7: US13 = first_mark_244(prev_v1, &cps_v3);
                match v7 {
                    US13::US13_None => {
                        let at_v21: i32 = at_v2.wrapping_add(1i32);
                        (prev_v1, at_v2, cps_v3) = (d_v5, at_v21, cps_v6);
                        continue;
                    }
                    US13::US13_Some(m_v8, p_v9, cps_v10) => {
                        let m_v8: US7 = m_v8;
                        let p_v9: Rc<UH2> = p_v9;
                        let cps_v10: Rc<UH2> = cps_v10;
                        let prev_v11: i32 = last_point_85(p_v9.clone(), d_v5);
                        let s_v12: i32 = 0i32;
                        let mut v13: i32 = method70(p_v9.clone(), s_v12);
                        let at_v14: i32 = at_v2.wrapping_add(v13);
                        let (mut v15, mut v16, mut v17, mut v18): (US7, i32, i32, Rc<str>) = marked_264(row_v0, at_v2, m_v8, p_v9);
                        let acc_v19: Rc<UH8> = Rc::new(UH8::UH8_Cons(v15, v16, v17, v18, acc_v4));
                        (prev_v1, at_v2, cps_v3, acc_v4) = (prev_v11, at_v14, cps_v10, acc_v19);
                        continue;
                    }
                }
            }
            UH2::UH2_Nil => {
                return acc_v4;
            }
        }
    }
}
fn method265(mut v0: Rc<UH5>, mut v1: Rc<UH5>) -> Rc<UH5> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH5::UH5_Cons(v2, v3, v4) => {
                let mut v2: i32 = v2;
                let mut v3: Rc<str> = v3;
                let mut v4: Rc<UH5> = v4;
                let s_v5: Rc<UH5> = Rc::new(UH5::UH5_Cons(v2, v3, v1));
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH5::UH5_Nil => {
                return v1;
            }
        }
    }
}
fn link_rewrite_267(mut v0: i32, mut v1: Rc<str>, mut v2: i32) -> (US7, i32, i32, Rc<str>) {
    let mut v3: i32 = v2.wrapping_add(1i32);
    let mut v4: US7 = US7::US7_Autolink;
    (v4, v0, v3, v1)
}
fn method266(mut v0: i32, mut v1: Rc<UH5>, mut s_v2: Rc<UH8>) -> Rc<UH8> {
    match Rc::unwrap_or_clone(v1) {
        UH5::UH5_Cons(v3, v4, v5) => {
            let mut v3: i32 = v3;
            let mut v4: Rc<str> = v4;
            let mut v5: Rc<UH5> = v5;
            let v6: Rc<UH8> = method266(v0, v5, s_v2);
            let (mut v7, mut v8, mut v9, mut v10): (US7, i32, i32, Rc<str>) = link_rewrite_267(v0, v4, v3);
            Rc::new(UH8::UH8_Cons(v7, v8, v9, v10, v6))
        }
        UH5::UH5_Nil => {
            s_v2
        }
    }
}
fn closure22(mut v0: US7, mut v1: i32, mut v2: i32, mut v3: Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> {
    Rc::new(move |mut v4: US7, mut v5: i32, mut v6: i32, mut v7: Rc<str>| -> bool {
        let mut v8: bool = v2 < v6;
        v8
    })
}
fn closure21() -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>> = Rc::new(move |mut v0: US7, mut v1: i32, mut v2: i32, mut v3: Rc<str>| -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool> {
        closure22(v0, v1, v2, v3)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn line_rewrites_233(mut tlds_v0: US2, mut row_v1: i32, mut backend_v2: Rc<str>) -> Rc<UH8> {
    let backend_v3: Rc<Vec<char>> = Rc::new((&*backend_v2).chars().collect());
    let backend_v4: Rc<Vec<char>> = Rc::new((backend_v3).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v5: usize = (backend_v4).len();
    let x_v6: i32 = ((backend_v5) as i32);
    let i_v7: i32 = 0i32;
    let acc_v8: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let cps_v9: Rc<UH2> = method35(backend_v4, x_v6, i_v7, acc_v8);
    let prev_v10: i32 = -1i32;
    let at_v11: i32 = 0i32;
    let acc_v12: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
    let mut v13: Rc<UH8> = scan_marks_243(row_v1, prev_v10, at_v11, cps_v9.clone(), acc_v12);
    let s_v14: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
    let marks_v15: Rc<UH8> = method232(v13, s_v14);
    let (mut v16, mut v17, mut v18): (i32, i32, Rc<UH5>) = links_in_61(tlds_v0, cps_v9);
    let s_v19: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_Nil); } CASE.with(|case| case.clone()) };
    let mut v20: Rc<UH5> = method265(v18, s_v19);
    let s_v21: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
    let links_v22: Rc<UH8> = method266(row_v1, v20, s_v21);
    let first_v23: Rc<dyn Fn(US7, i32, i32, Rc<str>) -> Rc<dyn Fn(US7, i32, i32, Rc<str>) -> bool>> = closure21();
    let l_v24: Rc<UH8> = method238(marks_v15, links_v22);
    sorted_by_234(first_v23, l_v24)
}
fn rewrites_from_231(mut tlds_v0: US2, mut row_v1: i32, mut v2: Rc<UH0>, mut s_v3: Rc<UH8>) -> Rc<UH8> {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH0::UH0_Cons(line_v6, lines_v7) => {
                let line_v6: Rc<str> = line_v6;
                let lines_v7: Rc<UH0> = lines_v7;
                let row_v8: i32 = row_v1.wrapping_add(1i32);
                let mut v9: Rc<UH8> = line_rewrites_233(tlds_v0.clone(), row_v1, line_v6);
                let s_v10: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                let mut v11: Rc<UH8> = method232(v9, s_v10);
                let acc_v12: Rc<UH8> = method238(v11, s_v3);
                (row_v1, v2, s_v3) = (row_v8, lines_v7, acc_v12);
                continue;
            }
            UH0::UH0_Nil => {
                let s_v4: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                return method232(s_v3, s_v4);
            }
        }
    }
}
fn rewrites_228(mut tlds_v0: US2, mut source_v1: Rc<str>) -> Rc<UH3> {
    let row_v2: i32 = 1i32;
    let lines_v3: Rc<UH0> = source_lines_212(source_v1);
    let acc_v4: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
    let mut v5: Rc<UH8> = rewrites_from_231(tlds_v0, row_v2, lines_v3, acc_v4);
    let s_v6: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
    method229(v5, s_v6)
}
fn file_findings_49(mut tlds_v0: US2, mut v1: bool, mut nominals_v2: Rc<UH0>, mut source_v3: Rc<str>) -> Rc<UH3> {
    let over_v6: Rc<UH3> = if v1 {
        ruled_over_51(tlds_v0.clone(), nominals_v2, source_v3.clone())
    } else {
        over_budget_223(tlds_v0.clone(), source_v3.clone())
    };
    let mut v7: Rc<UH3> = rewrites_228(tlds_v0, source_v3);
    method50(v7, over_v6)
}
fn mark_name_270(mut body_v0: US7) -> Rc<str> {
    ;
    ;
    ;
    ;
    let mut v1: bool = match &body_v0 {
        US7::US7_Hashtag => {
            true
        }
        _ => {
            false
        }
    };
    let mut v5: US0 = if v1 {
        let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Hashtag"); } LIT.with(|lit| lit.clone()) };
        US0::US0_Some(v2)
    } else {
        US0::US0_None
    };
    let v37: US0 = match v5 {
        US0::US0_None => {
            let mut v8: bool = match &body_v0 {
                US7::US7_Mention => {
                    true
                }
                _ => {
                    false
                }
            };
            let mut v12: US0 = if v8 {
                let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Mention"); } LIT.with(|lit| lit.clone()) };
                US0::US0_Some(v9)
            } else {
                US0::US0_None
            };
            match v12 {
                US0::US0_None => {
                    let mut v15: bool = match &body_v0 {
                        US7::US7_Cashtag => {
                            true
                        }
                        _ => {
                            false
                        }
                    };
                    let v19: US0 = if v15 {
                        let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Cashtag"); } LIT.with(|lit| lit.clone()) };
                        US0::US0_Some(v16)
                    } else {
                        US0::US0_None
                    };
                    match v19 {
                        US0::US0_None => {
                            let v22: bool = match body_v0 {
                                US7::US7_Autolink => {
                                    true
                                }
                                _ => {
                                    false
                                }
                            };
                            let v26: US0 = if v22 {
                                let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Autolink"); } LIT.with(|lit| lit.clone()) };
                                US0::US0_Some(v23)
                            } else {
                                US0::US0_None
                            };
                            match v26 {
                                US0::US0_None => {
                                    US0::US0_None
                                }
                                US0::US0_Some(y_v27) => {
                                    let y_v27: Rc<str> = y_v27;
                                    US0::US0_Some(y_v27)
                                }
                            }
                        }
                        US0::US0_Some(y_v20) => {
                            let y_v20: Rc<str> = y_v20;
                            US0::US0_Some(y_v20)
                        }
                    }
                }
                US0::US0_Some(y_v13) => {
                    let y_v13: Rc<str> = y_v13;
                    US0::US0_Some(y_v13)
                }
            }
        }
        US0::US0_Some(y_v6) => {
            let y_v6: Rc<str> = y_v6;
            US0::US0_Some(y_v6)
        }
    };
    let backend_v41: Rc<str> = match v37 {
        US0::US0_None => {
            std::panic::panic_any::<std::string::String>(format!("{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("Option does not have a value."); } LIT.with(|lit| lit.clone()) }))
        }
        US0::US0_Some(x_v38) => {
            let x_v38: Rc<str> = x_v38;
            x_v38
        }
    };
    let v42: Rc<str> = Rc::<str>::from(backend_v41.to_lowercase());
    v42
}
fn finding_kind_269(mut v0: US3) -> Rc<str> {
    match v0 {
        US3::US3_BudgetFinding(_) => {
            let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("over_budget"); } LIT.with(|lit| lit.clone()) };
            v9
        }
        US3::US3_RewriteFinding(v1) => {
            let mut v1: US6 = v1;
            match v1 {
                US6::US6_Rewritten(r_v2, _, _, _) => {
                    let r_v2: US7 = r_v2;
                    mark_name_270(r_v2)
                }
            }
        }
        US3::US3_RuledFinding(_) => {
            let mut v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("over_budget"); } LIT.with(|lit| lit.clone()) };
            v11
        }
    }
}
fn located_273(mut a_v0: Rc<str>, mut x_v1: i32, mut x_v2: i32) -> Rc<str> {
    let b_v4: Rc<str> = format_real_207(x_v1);
    let b_v7: Rc<str> = format_real_207(x_v2);
    let mut v8: Rc<str> = string_concat(&[&*a_v0, ":", &*b_v4, ":", &*b_v7]);
    v8
}
fn over_line_272(mut path_v0: Rc<str>, mut line_v1: i32, mut v2: i32, mut v3: i32, mut b_v4: Rc<str>) -> Rc<str> {
    let x_v5: i32 = weight_value_59(v2);
    let b_v6: Rc<str> = format_real_207(x_v5);
    let x_v9: i32 = weight_value_59(v3);
    let b_v10: Rc<str> = format_real_207(x_v9);
    let column_v12: i32 = 1i32;
    let a_v13: Rc<str> = located_273(path_v0, line_v1, column_v12);
    let v18: Rc<str> = string_concat(&[&*a_v13, ": over_budget: weight ", &*b_v6, " > ", &*b_v10, " (", &*b_v4, ")"]);
    v18
}
fn mark_hint_275(mut v0: US7) -> Rc<str> {
    match v0 {
        US7::US7_Autolink => {
            let x_v4: i32 = link_weight_99();
            let b_v5: Rc<str> = format_real_207(x_v4);
            let mut v7: Rc<str> = string_concat(&["a renderer shortens what looks like a domain to a ", &*b_v5, "-character link"]);
            v7
        }
        US7::US7_Cashtag => {
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a renderer turns '$' before letters into a cashtag link"); } LIT.with(|lit| lit.clone()) };
            v3
        }
        US7::US7_Hashtag => {
            let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a renderer turns '#' before a letter into a hashtag link"); } LIT.with(|lit| lit.clone()) };
            v1
        }
        US7::US7_Mention => {
            let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a renderer turns '@' before a name into a mention"); } LIT.with(|lit| lit.clone()) };
            v2
        }
    }
}
fn rewrite_line_274(mut path_v0: Rc<str>, mut m_v1: US7, mut line_v2: i32, mut column_v3: i32, mut b_v4: Rc<str>) -> Rc<str> {
    let a_v5: Rc<str> = located_273(path_v0, line_v2, column_v3);
    let b_v7: Rc<str> = mark_name_270(m_v1.clone());
    let b_v12: Rc<str> = mark_hint_275(m_v1);
    let mut v14: Rc<str> = string_concat(&[&*a_v5, ": ", &*b_v7, ": ", &*b_v4, " (", &*b_v12, ")"]);
    v14
}
fn budget_hint_276() -> Rc<str> {
    let x_v0: i32 = link_weight_99();
    let b_v1: Rc<str> = format_real_207(x_v0);
    let mut v3: Rc<str> = string_concat(&["a cell holds 280 weighted characters (CJK and emoji weigh 2, links ", &*b_v1, "), less the cell header; split this definition (gate bar: granular excess <= baseline)"]);
    v3
}
fn ruled_hint_277() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("measured with the GRANULAR rules (a one-line-arm match counts its longest arm, the header is excluded, a literal-only template counts its heaviest piece, type declarations and pure literals weigh 0, declared :! nominals count as constructors); split this body (gate bar: granular excess <= baseline)"); } LIT.with(|lit| lit.clone()) };
    v0
}
fn finding_line_271(mut path_v0: Rc<str>, mut v1: US3) -> Rc<str> {
    match v1 {
        US3::US3_BudgetFinding(v9) => {
            let mut v9: US4 = v9;
            match v9 {
                US4::US4_OverBudget(o_v10, o_v11, o_v12) => {
                    let o_v10: i32 = o_v10;
                    let o_v11: i32 = o_v11;
                    let o_v12: i32 = o_v12;
                    let hint_v13: Rc<str> = budget_hint_276();
                    over_line_272(path_v0, o_v10, o_v11, o_v12, hint_v13)
                }
            }
        }
        US3::US3_RewriteFinding(v2) => {
            let mut v2: US6 = v2;
            match v2 {
                US6::US6_Rewritten(r_v3, r_v4, r_v5, r_v6) => {
                    let r_v3: US7 = r_v3;
                    let r_v4: i32 = r_v4;
                    let r_v5: i32 = r_v5;
                    let r_v6: Rc<str> = r_v6;
                    rewrite_line_274(path_v0, r_v3, r_v4, r_v5, r_v6)
                }
            }
        }
        US3::US3_RuledFinding(v16) => {
            let v16: US5 = v16;
            match v16 {
                US5::US5_OverRuled(o_v17, o_v18, o_v19) => {
                    let o_v17: i32 = o_v17;
                    let o_v18: i32 = o_v18;
                    let o_v19: i32 = o_v19;
                    let hint_v20: Rc<str> = ruled_hint_277();
                    over_line_272(path_v0, o_v17, o_v18, o_v19, hint_v20)
                }
            }
        }
    }
}
fn method268(mut path_v0: Rc<str>, mut v1: Rc<UH3>, mut s_v2: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v1) {
        UH3::UH3_Cons(f_v3, v4) => {
            let f_v3: US3 = f_v3;
            let mut v4: Rc<UH3> = v4;
            let mut v5: Rc<UH0> = method268(path_v0.clone(), v4, s_v2);
            let a_v6: Rc<str> = finding_kind_269(f_v3.clone());
            let b_v8: Rc<str> = finding_line_271(path_v0, f_v3);
            let mut v9: Rc<str> = string_concat(&[&*a_v6, "\t", &*b_v8]);
            Rc::new(UH0::UH0_Cons(v9, v5))
        }
        UH3::UH3_Nil => {
            s_v2
        }
    }
}
fn findings_rows_47(mut tlds_v0: US2, mut granular_v1: bool, mut text_v2: Rc<str>, mut v3: Rc<str>, mut source_v4: Rc<str>) -> Rc<str> {
    let nominals_v5: Rc<UH0> = wire_list_48(text_v2);
    let v6: Rc<UH3> = file_findings_49(tlds_v0, granular_v1, nominals_v5, source_v4);
    let s_v7: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let backend_v8: Rc<UH0> = method268(v3, v6, s_v7);
    let acc_v9: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v10: i32 = 0i32;
    let mut v11: i32 = method20(acc_v9.clone(), backend_v8, s_v10);
    let backend_v12: Rc<Vec<Rc<str>>> = Rc::new(acc_v9.borrow().clone());
    let items_v13: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v12).as_ref().clone()));
    let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v15: Rc<str> = Rc::<str>::from((*items_v13.borrow()).join(&*v14));
    v15
}
fn findings_wire_46(mut granular_v0: bool, mut nominals_v1: Rc<str>, mut path_v2: Rc<str>, mut source_v3: Rc<str>) -> Rc<str> {
    let tlds_v4: US2 = US2::US2_Iana;
    findings_rows_47(tlds_v4, granular_v0, nominals_v1, path_v2, source_v3)
}
fn file_rows_17(mut granular_v0: bool, mut backend_v1: Rc<str>) -> Rc<UH1> {
    let mut v3: Result<Vec<u8>, std::io::Error> = std::fs::read(&*backend_v1);
    let mut v5: Vec<u8> = v3.unwrap();
    let bytes_v6: Vec<u8> = method21(v5);
    let mut v8: Result<std::string::String, std::string::FromUtf8Error> = std::string::String::from_utf8(bytes_v6);
    let backend_v10: std::string::String = v8.unwrap();
    let source_v12: Rc<str> = Rc::<str>::from(String::as_str(&backend_v10));
    let nominals_v15: Rc<str> = if granular_v0 {
        nominals_of_22(backend_v1.clone(), source_v12.clone())
    } else {
        let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v14
    };
    let text_v16: Rc<str> = findings_wire_46(granular_v0, nominals_v15, backend_v1, source_v12);
    let v17: Rc<UH0> = lines_of_24(text_v16);
    let s_v18: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_Nil); } CASE.with(|case| case.clone()) };
    method18(v17, s_v18)
}
fn method15(mut v0: bool, mut v1: Rc<UH0>, mut s_v2: Rc<UH1>) -> Rc<UH1> {
    match Rc::unwrap_or_clone(v1) {
        UH0::UH0_Cons(path_v3, v4) => {
            let path_v3: Rc<str> = path_v3;
            let mut v4: Rc<UH0> = v4;
            let s_v5: Rc<UH1> = method15(v0, v4, s_v2);
            let v6: Rc<UH1> = file_rows_17(v0, path_v3);
            method16(v6, s_v5)
        }
        UH0::UH0_Nil => {
            s_v2
        }
    }
}
fn method278(mut v0: Rc<UH1>) -> () {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH1::UH1_Cons(_, backend_v2, v3) => {
                let backend_v2: Rc<str> = backend_v2;
                let mut v3: Rc<UH1> = v3;
                println!("{}", backend_v2);
                v0 = v3;
                continue;
            }
            UH1::UH1_Nil => {
                return ();
            }
        }
        return ();
    }
}
fn method279(mut v0: Rc<UH0>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(_, v3) => {
                let mut v3: Rc<UH0> = v3;
                let s_v4: i32 = v1.wrapping_add(1i32);
                (v0, v1) = (v3, s_v4);
                continue;
            }
            UH0::UH0_Nil => {
                return v1;
            }
        }
    }
}
fn kinds_282() -> Rc<UH0> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("autolink"); } LIT.with(|lit| lit.clone()) };
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cashtag"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("hashtag"); } LIT.with(|lit| lit.clone()) };
    let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("mention"); } LIT.with(|lit| lit.clone()) };
    let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("over_budget"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let v6: Rc<UH0> = Rc::new(UH0::UH0_Cons(v4, v5));
    let mut v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(v3, v6));
    let mut v8: Rc<UH0> = Rc::new(UH0::UH0_Cons(v2, v7));
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v1, v8));
    Rc::new(UH0::UH0_Cons(v0, v9))
}
fn method285(mut v0: Rc<str>, mut v1: Rc<UH1>, mut v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH1::UH1_Cons(v3, _, v5) => {
                let mut v3: Rc<str> = v3;
                let mut v5: Rc<UH1> = v5;
                let v6: bool = &*v3 == &*v0;
                let s_v8: i32 = if v6 {
                    let mut v7: i32 = v2.wrapping_add(1i32);
                    v7
                } else {
                    v2
                };
                (v1, v2) = (v5, s_v8);
                continue;
            }
            UH1::UH1_Nil => {
                return v2;
            }
        }
    }
}
fn count_of_284(mut v0: Rc<str>, mut v1: Rc<UH1>) -> i32 {
    let s_v2: i32 = 0i32;
    method285(v0, v1, s_v2)
}
fn method283(mut rows_v0: Rc<UH1>, mut v1: Rc<UH0>, mut s_v2: Rc<UH10>) -> Rc<UH10> {
    match Rc::unwrap_or_clone(v1) {
        UH0::UH0_Cons(kind_v3, v4) => {
            let kind_v3: Rc<str> = kind_v3;
            let mut v4: Rc<UH0> = v4;
            let mut v5: Rc<UH10> = method283(rows_v0.clone(), v4, s_v2);
            let v6: i32 = count_of_284(kind_v3.clone(), rows_v0);
            Rc::new(UH10::UH10_Cons(kind_v3, v6, v5))
        }
        UH0::UH0_Nil => {
            s_v2
        }
    }
}
fn method286(mut v0: Rc<UH10>, mut s_v1: Rc<UH10>) -> Rc<UH10> {
    match Rc::unwrap_or_clone(v0) {
        UH10::UH10_Cons(v2, v3, v4) => {
            let mut v2: Rc<str> = v2;
            let mut v3: i32 = v3;
            let mut v4: Rc<UH10> = v4;
            let mut v5: Rc<UH10> = method286(v4, s_v1);
            let v6: bool = v3 > 0i32;
            if v6 {
                Rc::new(UH10::UH10_Cons(v2, v3, v5))
            } else {
                v5
            }
        }
        UH10::UH10_Nil => {
            s_v1
        }
    }
}
fn method287(mut v0: Rc<UH10>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH10::UH10_Cons(a_v2, x_v3, v4) => {
            let a_v2: Rc<str> = a_v2;
            let x_v3: i32 = x_v3;
            let mut v4: Rc<UH10> = v4;
            let mut v5: Rc<UH0> = method287(v4, s_v1);
            let b_v7: Rc<str> = format_real_207(x_v3);
            let mut v8: Rc<str> = string_concat(&[&*a_v2, " ", &*b_v7]);
            Rc::new(UH0::UH0_Cons(v8, v5))
        }
        UH10::UH10_Nil => {
            s_v1
        }
    }
}
fn by_kind_281(mut v0: Rc<UH1>) -> Rc<str> {
    let mut v1: Rc<UH0> = kinds_282();
    let s_v2: Rc<UH10> = { thread_local!{ static CASE: Rc<UH10> = Rc::new(UH10::UH10_Nil); } CASE.with(|case| case.clone()) };
    let mut v3: Rc<UH10> = method283(v0, v1, s_v2);
    let s_v4: Rc<UH10> = { thread_local!{ static CASE: Rc<UH10> = Rc::new(UH10::UH10_Nil); } CASE.with(|case| case.clone()) };
    let mut v5: Rc<UH10> = method286(v3, s_v4);
    let s_v6: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let backend_v7: Rc<UH0> = method287(v5, s_v6);
    let acc_v8: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let mut s_v9: i32 = 0i32;
    let v10: i32 = method20(acc_v8.clone(), backend_v7, s_v9);
    let backend_v11: Rc<Vec<Rc<str>>> = Rc::new(acc_v8.borrow().clone());
    let items_v12: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v11).as_ref().clone()));
    let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(", "); } LIT.with(|lit| lit.clone()) };
    let mut v14: Rc<str> = Rc::<str>::from((*items_v12.borrow()).join(&*v13));
    v14
}
fn method288(mut v0: Rc<UH1>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH1::UH1_Cons(_, _, v4) => {
                let mut v4: Rc<UH1> = v4;
                let s_v5: i32 = v1.wrapping_add(1i32);
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH1::UH1_Nil => {
                return v1;
            }
        }
    }
}
fn report_line_280(mut rows_v0: Rc<UH1>, mut x_v1: i32) -> Rc<str> {
    let kinds_v2: Rc<str> = by_kind_281(rows_v0.clone());
    let s_v3: i32 = 0i32;
    let found_v4: i32 = method288(rows_v0, s_v3);
    let b_v5: Rc<str> = format_real_207(found_v4);
    let b_v8: Rc<str> = format_real_207(x_v1);
    let a_v10: Rc<str> = string_concat(&["cell-budget report: ", &*b_v5, " finding(s) in ", &*b_v8, " file(s)"]);
    let mut v11: bool = &*kinds_v2 == "";
    let b_v15: Rc<str> = if v11 {
        let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
        v12
    } else {
        let mut v14: Rc<str> = string_concat(&[" (", &*kinds_v2, ")"]);
        v14
    };
    let v16: Rc<str> = string_concat(&[&*a_v10, &*b_v15]);
    v16
}
fn method293(mut body_v0: US14, mut v1: Rc<UH11>, mut v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH11::UH11_Cons(body_v3, _, _, v6) => {
                let body_v3: US14 = body_v3;
                let v6: Rc<UH11> = v6;
                let mut v7: bool = match (&body_v3, &body_v0) {
                    (US14::US14_CodeKind, US14::US14_CodeKind) => {
                        true
                    }
                    (US14::US14_DataKind, US14::US14_DataKind) => {
                        true
                    }
                    (US14::US14_TemplateKind, US14::US14_TemplateKind) => {
                        true
                    }
                    (US14::US14_TestKind, US14::US14_TestKind) => {
                        true
                    }
                    (US14::US14_TypeKind, US14::US14_TypeKind) => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut s_v9: i32 = if v7 {
                    let mut v8: i32 = v2.wrapping_add(1i32);
                    v8
                } else {
                    v2
                };
                (v1, v2) = (v6, s_v9);
                continue;
            }
            UH11::UH11_Nil => {
                return v2;
            }
        }
    }
}
fn count_kind_292(mut v0: Rc<UH11>, mut v1: US14) -> i32 {
    let s_v2: i32 = 0i32;
    method293(v1, v0, s_v2)
}
fn method295(mut v0: Rc<UH11>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH11::UH11_Cons(body_v2, v3, _, v5) => {
                let body_v2: US14 = body_v2;
                let mut v3: bool = v3;
                let mut v5: Rc<UH11> = v5;
                let v6: bool = match body_v2 {
                    US14::US14_CodeKind => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let mut v7: bool = v6 && v3;
                let mut s_v9: i32 = if v7 {
                    let mut v8: i32 = v1.wrapping_add(1i32);
                    v8
                } else {
                    v1
                };
                (v0, v1) = (v5, s_v9);
                continue;
            }
            UH11::UH11_Nil => {
                return v1;
            }
        }
    }
}
fn count_over_code_294(mut v0: Rc<UH11>) -> i32 {
    let s_v1: i32 = 0i32;
    method295(v0, s_v1)
}
fn tenths_text_297(mut v0: i32, mut v1: i32) -> Rc<str> {
    let mut v2: bool = v1 < 1i32;
    let c_v3: i32 = if v2 {
        1i32
    } else {
        v1
    };
    let mut v4: i32 = v0.wrapping_mul(2000i32);
    let mut v5: i32 = v4.wrapping_add(c_v3);
    let v6: i32 = 2i32.wrapping_mul(c_v3);
    let tenths_v7: i32 = v5.wrapping_div(v6);
    let x_v8: i32 = tenths_v7.wrapping_div(10i32);
    let a_v9: Rc<str> = format_real_207(x_v8);
    let x_v11: i32 = tenths_v7.wrapping_rem(10i32);
    let b_v12: Rc<str> = format_real_207(x_v11);
    let mut v13: Rc<str> = string_concat(&[&*a_v9, ".", &*b_v12]);
    v13
}
fn code_text_296(mut x_v0: i32, mut x_v1: i32) -> Rc<str> {
    let b_v2: Rc<str> = format_real_207(x_v0);
    let b_v5: Rc<str> = format_real_207(x_v1);
    let b_v8: Rc<str> = tenths_text_297(x_v1, x_v0);
    let v10: Rc<str> = string_concat(&["cell-budget granular: code ", &*b_v2, " (over ", &*b_v5, ", ", &*b_v8, "%), "]);
    v10
}
fn method299(mut v0: Rc<UH11>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH11::UH11_Cons(body_v2, _, v4, v5) => {
                let body_v2: US14 = body_v2;
                let mut v4: i32 = v4;
                let mut v5: Rc<UH11> = v5;
                let v6: bool = match body_v2 {
                    US14::US14_CodeKind => {
                        true
                    }
                    _ => {
                        false
                    }
                };
                let s_v8: i32 = if v6 {
                    let mut v7: i32 = v1.wrapping_add(v4);
                    v7
                } else {
                    v1
                };
                (v0, v1) = (v5, s_v8);
                continue;
            }
            UH11::UH11_Nil => {
                return v1;
            }
        }
    }
}
fn code_excess_298(mut v0: Rc<UH11>) -> i32 {
    let s_v1: i32 = 0i32;
    method299(v0, s_v1)
}
fn kinds_line_291(mut rows_v0: Rc<UH11>) -> Rc<str> {
    let k_v1: US14 = US14::US14_DataKind;
    let x_v2: i32 = count_kind_292(rows_v0.clone(), k_v1);
    let b_v3: Rc<str> = format_real_207(x_v2);
    let k_v6: US14 = US14::US14_TemplateKind;
    let x_v7: i32 = count_kind_292(rows_v0.clone(), k_v6);
    let b_v8: Rc<str> = format_real_207(x_v7);
    let k_v10: US14 = US14::US14_TypeKind;
    let x_v11: i32 = count_kind_292(rows_v0.clone(), k_v10);
    let b_v12: Rc<str> = format_real_207(x_v11);
    let k_v15: US14 = US14::US14_TestKind;
    let x_v16: i32 = count_kind_292(rows_v0.clone(), k_v15);
    let b_v17: Rc<str> = format_real_207(x_v16);
    let k_v19: US14 = US14::US14_CodeKind;
    let code_v20: i32 = count_kind_292(rows_v0.clone(), k_v19);
    let over_v21: i32 = count_over_code_294(rows_v0.clone());
    let a_v22: Rc<str> = code_text_296(code_v20, over_v21);
    let x_v26: i32 = code_excess_298(rows_v0);
    let b_v27: Rc<str> = format_real_207(x_v26);
    let v29: Rc<str> = string_concat(&[&*a_v22, "data ", &*b_v3, ", template ", &*b_v8, ", type ", &*b_v12, ", test ", &*b_v17, ", excess ", &*b_v27, " (gated)"]);
    v29
}
fn method300(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method300(v3, s_v1);
            let mut v5: bool = &*v2 != "";
            if v5 {
                Rc::new(UH0::UH0_Cons(v2, v4))
            } else {
                v4
            }
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn kind_named_304(mut v0: Rc<str>) -> US14 {
    let mut v1: bool = &*v0 == "data";
    if v1 {
        US14::US14_DataKind
    } else {
        let mut v3: bool = &*v0 == "template";
        if v3 {
            US14::US14_TemplateKind
        } else {
            let mut v5: bool = &*v0 == "type";
            if v5 {
                US14::US14_TypeKind
            } else {
                let mut v7: bool = &*v0 == "test";
                if v7 {
                    US14::US14_TestKind
                } else {
                    US14::US14_CodeKind
                }
            }
        }
    }
}
fn row_of_303(mut s_v0: Rc<str>, mut v1: Rc<str>, mut v2: i32) -> (US14, bool, i32) {
    let mut v3: US14 = kind_named_304(s_v0);
    let mut v4: bool = &*v1 == "1";
    (v3, v4, v2)
}
fn method306(mut v0: Rc<UH2>, mut v1: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v2, v3) => {
                let mut v2: i32 = v2;
                let mut v3: Rc<UH2> = v3;
                let mut v4: bool = v2 >= 48i32;
                let v6: bool = if v4 {
                    let mut v5: bool = v2 <= 57i32;
                    v5
                } else {
                    false
                };
                let s_v10: i32 = if v6 {
                    let mut v7: i32 = v1.wrapping_mul(10i32);
                    let mut v8: i32 = v2.wrapping_sub(48i32);
                    let mut v9: i32 = v7.wrapping_add(v8);
                    v9
                } else {
                    v1
                };
                (v0, v1) = (v3, s_v10);
                continue;
            }
            UH2::UH2_Nil => {
                return v1;
            }
        }
    }
}
fn digits_value_305(mut backend_v0: Rc<str>) -> i32 {
    let backend_v1: Rc<Vec<char>> = Rc::new((&*backend_v0).chars().collect());
    let backend_v2: Rc<Vec<char>> = Rc::new((backend_v1).as_ref().iter().rev().cloned().collect::<Vec<_>>());
    let backend_v3: usize = (backend_v2).len();
    let x_v4: i32 = ((backend_v3) as i32);
    let i_v5: i32 = 0i32;
    let acc_v6: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
    let mut v7: Rc<UH2> = method35(backend_v2, x_v4, i_v5, acc_v6);
    let s_v8: i32 = 0i32;
    method306(v7, s_v8)
}
fn kind_row_of_302(mut s_v0: Rc<str>) -> (US14, bool, i32) {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1, s_v0);
    let (mut v34, mut v35, mut v36): (US14, bool, i32) = match Rc::unwrap_or_clone(v2) {
        UH0::UH0_Cons(name_v3, v4) => {
            let name_v3: Rc<str> = name_v3;
            let mut v4: Rc<UH0> = v4;
            match Rc::unwrap_or_clone(v4) {
                UH0::UH0_Cons(flag_v5, v6) => {
                    let flag_v5: Rc<str> = flag_v5;
                    let v6: Rc<UH0> = v6;
                    match Rc::unwrap_or_clone(v6) {
                        UH0::UH0_Cons(s_v7, _) => {
                            let s_v7: Rc<str> = s_v7;
                            let excess_v9: i32 = digits_value_305(s_v7);
                            row_of_303(name_v3, flag_v5, excess_v9)
                        }
                        _ => {
                            let excess_v13: i32 = 0i32;
                            let (mut v14, mut v15, mut v16): (US14, bool, i32) = row_of_303(name_v3, flag_v5, excess_v13);
                            (v14, v15, v16)
                        }
                    }
                }
                _ => {
                    let flag_v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
                    let excess_v21: i32 = 0i32;
                    let (mut v22, mut v23, mut v24): (US14, bool, i32) = row_of_303(name_v3, flag_v20, excess_v21);
                    (v22, v23, v24)
                }
            }
        }
        _ => {
            let name_v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("code"); } LIT.with(|lit| lit.clone()) };
            let flag_v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("0"); } LIT.with(|lit| lit.clone()) };
            let excess_v30: i32 = 0i32;
            let (mut v31, mut v32, mut v33): (US14, bool, i32) = row_of_303(name_v28, flag_v29, excess_v30);
            (v31, v32, v33)
        }
    };
    (v34, v35, v36)
}
fn method301(mut v0: Rc<UH0>, mut s_v1: Rc<UH11>) -> Rc<UH11> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(line_v2, v3) => {
            let line_v2: Rc<str> = line_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH11> = method301(v3, s_v1);
            let (mut v5, mut v6, mut v7): (US14, bool, i32) = kind_row_of_302(line_v2);
            Rc::new(UH11::UH11_Cons(v5, v6, v7, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn kinds_line_of_rows_290(mut s_v0: Rc<str>) -> Rc<str> {
    let separator_v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v2: Rc<UH0> = split_list_12(separator_v1, s_v0);
    let s_v3: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v4: Rc<UH0> = method300(v2, s_v3);
    let s_v5: Rc<UH11> = { thread_local!{ static CASE: Rc<UH11> = Rc::new(UH11::UH11_Nil); } CASE.with(|case| case.clone()) };
    let rows_v6: Rc<UH11> = method301(v4, s_v5);
    kinds_line_291(rows_v6)
}
fn method313(mut v0: Rc<UH11>, mut v1: Rc<UH11>) -> Rc<UH11> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH11::UH11_Cons(v2, v3, v4, v5) => {
                let mut v2: US14 = v2;
                let mut v3: bool = v3;
                let mut v4: i32 = v4;
                let mut v5: Rc<UH11> = v5;
                let s_v6: Rc<UH11> = Rc::new(UH11::UH11_Cons(v2, v3, v4, v1));
                (v0, v1) = (v5, s_v6);
                continue;
            }
            UH11::UH11_Nil => {
                return v1;
            }
        }
    }
}
fn body_kind_316(mut nominals_v0: Rc<UH0>, mut ls_v1: Rc<UH0>) -> US14 {
    let text_v2: Rc<str> = joined_lines_143(ls_v1.clone());
    let mut v3: bool = data_literal_154(nominals_v0.clone(), text_v2.clone());
    let mut v5: bool = if v3 {
        true
    } else {
        structural_174(nominals_v0, ls_v1, text_v2.clone())
    };
    if v5 {
        US14::US14_DataKind
    } else {
        let mut v7: bool = template_183(text_v2);
        if v7 {
            US14::US14_TemplateKind
        } else {
            US14::US14_CodeKind
        }
    }
}
fn classify_315(mut nominals_v0: Rc<UH0>, mut s_v1: Rc<str>) -> US14 {
    let separator_v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let lines_v3: Rc<UH0> = split_list_12(separator_v2, s_v1);
    let lines_v4: Rc<UH0> = undocumented_186(lines_v3);
    let code_v5: Rc<str> = joined_lines_143(lines_v4.clone());
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("///>"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":#"); } LIT.with(|lit| lit.clone()) };
    let mut v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let mut v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v7, v8));
    let prefixes_v10: Rc<UH0> = Rc::new(UH0::UH0_Cons(v6, v9));
    let mut v11: bool = starts_with_any_168(prefixes_v10, code_v5.clone());
    if v11 {
        US14::US14_TestKind
    } else {
        let mut v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":|"); } LIT.with(|lit| lit.clone()) };
        let mut v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":=="); } LIT.with(|lit| lit.clone()) };
        let mut v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(":!"); } LIT.with(|lit| lit.clone()) };
        let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("type "); } LIT.with(|lit| lit.clone()) };
        let v17: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("union "); } LIT.with(|lit| lit.clone()) };
        let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("nominal "); } LIT.with(|lit| lit.clone()) };
        let v19: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut v20: Rc<UH0> = Rc::new(UH0::UH0_Cons(v18, v19));
        let v21: Rc<UH0> = Rc::new(UH0::UH0_Cons(v17, v20));
        let v22: Rc<UH0> = Rc::new(UH0::UH0_Cons(v16, v21));
        let v23: Rc<UH0> = Rc::new(UH0::UH0_Cons(v15, v22));
        let v24: Rc<UH0> = Rc::new(UH0::UH0_Cons(v14, v23));
        let prefixes_v25: Rc<UH0> = Rc::new(UH0::UH0_Cons(v13, v24));
        let v26: bool = starts_with_any_168(prefixes_v25, code_v5);
        if v26 {
            US14::US14_TypeKind
        } else {
            let v28: US12 = split_header_198(&lines_v4);
            match v28 {
                US12::US12_Body(body_v29) => {
                    let body_v29: Rc<UH0> = body_v29;
                    body_kind_316(nominals_v0, body_v29)
                }
                US12::US12_NoHeader => {
                    US14::US14_CodeKind
                }
            }
        }
    }
}
fn row_for_314(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut v2: i32, mut block_v3: Rc<str>, mut k_v4: i32) -> (US14, bool, i32) {
    let mut v5: i32 = ruled_weight_54(tlds_v0, nominals_v1.clone(), block_v3.clone());
    let v6: i32 = cell_limit_204(k_v4);
    let mut v7: i32 = weight_value_59(v6);
    let gap_v8: i32 = v5.wrapping_sub(v7);
    let mut v9: US14 = classify_315(nominals_v1, block_v3);
    let v10: bool = gap_v8 > 0i32;
    let mut v11: i32 = if v10 {
        gap_v8
    } else {
        0i32
    };
    (v9, v10, v11)
}
fn kinds_from_312(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut v2: Rc<UH4>, mut k_v3: i32, mut v4: Rc<UH11>) -> Rc<UH11> {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH4::UH4_Cons(b_v7, b_v8, bs_v9) => {
                let b_v7: i32 = b_v7;
                let b_v8: Rc<str> = b_v8;
                let bs_v9: Rc<UH4> = bs_v9;
                let k_v10: i32 = k_v3.wrapping_add(1i32);
                let (mut v11, mut v12, mut v13): (US14, bool, i32) = row_for_314(tlds_v0.clone(), nominals_v1.clone(), b_v7, b_v8, k_v3);
                let acc_v14: Rc<UH11> = Rc::new(UH11::UH11_Cons(v11, v12, v13, v4));
                (v2, k_v3, v4) = (bs_v9, k_v10, acc_v14);
                continue;
            }
            UH4::UH4_Nil => {
                let s_v5: Rc<UH11> = { thread_local!{ static CASE: Rc<UH11> = Rc::new(UH11::UH11_Nil); } CASE.with(|case| case.clone()) };
                return method313(v4, s_v5);
            }
        }
    }
}
fn kinds_311(mut tlds_v0: US2, mut nominals_v1: Rc<UH0>, mut source_v2: Rc<str>) -> Rc<UH11> {
    let bs_v3: Rc<UH4> = blocks_210(source_v2);
    let k_v4: i32 = 1i32;
    let acc_v5: Rc<UH11> = { thread_local!{ static CASE: Rc<UH11> = Rc::new(UH11::UH11_Nil); } CASE.with(|case| case.clone()) };
    kinds_from_312(tlds_v0, nominals_v1, bs_v3, k_v4, acc_v5)
}
fn kind_name_318(mut v0: US14) -> Rc<str> {
    match v0 {
        US14::US14_CodeKind => {
            let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("code"); } LIT.with(|lit| lit.clone()) };
            v1
        }
        US14::US14_DataKind => {
            let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("data"); } LIT.with(|lit| lit.clone()) };
            v2
        }
        US14::US14_TemplateKind => {
            let mut v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("template"); } LIT.with(|lit| lit.clone()) };
            v3
        }
        US14::US14_TestKind => {
            let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("test"); } LIT.with(|lit| lit.clone()) };
            v5
        }
        US14::US14_TypeKind => {
            let mut v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("type"); } LIT.with(|lit| lit.clone()) };
            v4
        }
    }
}
fn method317(mut v0: Rc<UH11>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH11::UH11_Cons(k_v2, v3, x_v4, v5) => {
            let k_v2: US14 = k_v2;
            let mut v3: bool = v3;
            let x_v4: i32 = x_v4;
            let mut v5: Rc<UH11> = v5;
            let v6: Rc<UH0> = method317(v5, s_v1);
            let a_v7: Rc<str> = kind_name_318(k_v2);
            let b_v10: Rc<str> = if v3 {
                let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t1\t"); } LIT.with(|lit| lit.clone()) };
                v8
            } else {
                let mut v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\t0\t"); } LIT.with(|lit| lit.clone()) };
                v9
            };
            let b_v12: Rc<str> = format_real_207(x_v4);
            let mut v13: Rc<str> = string_concat(&[&*a_v7, &*b_v10, &*b_v12]);
            Rc::new(UH0::UH0_Cons(v13, v6))
        }
        UH11::UH11_Nil => {
            s_v1
        }
    }
}
fn kind_rows_310(mut tlds_v0: US2, mut text_v1: Rc<str>, mut source_v2: Rc<str>) -> Rc<str> {
    let nominals_v3: Rc<UH0> = wire_list_48(text_v1);
    let mut v4: Rc<UH11> = kinds_311(tlds_v0, nominals_v3, source_v2);
    let s_v5: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let backend_v6: Rc<UH0> = method317(v4, s_v5);
    let acc_v7: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v8: i32 = 0i32;
    let mut v9: i32 = method20(acc_v7.clone(), backend_v6, s_v8);
    let backend_v10: Rc<Vec<Rc<str>>> = Rc::new(acc_v7.borrow().clone());
    let items_v11: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v10).as_ref().clone()));
    let mut v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let mut v13: Rc<str> = Rc::<str>::from((*items_v11.borrow()).join(&*v12));
    v13
}
fn kind_rows_wire_309(mut nominals_v0: Rc<str>, mut source_v1: Rc<str>) -> Rc<str> {
    let tlds_v2: US2 = US2::US2_Iana;
    kind_rows_310(tlds_v2, nominals_v0, source_v1)
}
fn kind_rows_308(mut backend_v0: Rc<str>) -> Rc<str> {
    let mut v2: Result<Vec<u8>, std::io::Error> = std::fs::read(&*backend_v0);
    let mut v4: Vec<u8> = v2.unwrap();
    let bytes_v5: Vec<u8> = method21(v4);
    let mut v7: Result<std::string::String, std::string::FromUtf8Error> = std::string::String::from_utf8(bytes_v5);
    let backend_v9: std::string::String = v7.unwrap();
    let source_v11: Rc<str> = Rc::<str>::from(String::as_str(&backend_v9));
    let nominals_v12: Rc<str> = nominals_of_22(backend_v0, source_v11.clone());
    kind_rows_wire_309(nominals_v12, source_v11)
}
fn method307(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(path_v2, v3) => {
            let path_v2: Rc<str> = path_v2;
            let mut v3: Rc<UH0> = v3;
            let mut v4: Rc<UH0> = method307(v3, s_v1);
            let mut v5: Rc<str> = kind_rows_308(path_v2);
            Rc::new(UH0::UH0_Cons(v5, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn kinds_line_289(mut v0: Rc<UH0>) -> Rc<str> {
    let s_v1: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let backend_v2: Rc<UH0> = method307(v0, s_v1);
    let acc_v3: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v4: i32 = 0i32;
    let mut v5: i32 = method20(acc_v3.clone(), backend_v2, s_v4);
    let backend_v6: Rc<Vec<Rc<str>>> = Rc::new(acc_v3.borrow().clone());
    let items_v7: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v6).as_ref().clone()));
    let mut v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
    let rows_v9: Rc<str> = Rc::<str>::from((*items_v7.borrow()).join(&*v8));
    kinds_line_of_rows_290(rows_v9)
}
fn refused_319(mut x_v0: i32) -> i32 {
    let b_v1: Rc<str> = format_real_207(x_v0);
    let backend_v3: Rc<str> = string_concat(&["cell-budget: ", &*b_v1, " definition(s) over the cell budget; split them"]);
    eprintln!("{}", backend_v3);
    1i32
}
fn spiral_main() -> i32 {
    let index_v0: i32 = 0i32;
    let args_v1: Rc<UH0> = arguments_from_0(index_v0);
    let i_v2: i32 = 0i32;
    let mut v3: Rc<dyn Fn(Rc<UH0>) -> US1> = method3(i_v2);
    let body_v4: US1 = v3(args_v1.clone());
    let mut v5: bool = match body_v4 {
        US1::US1_None => {
            true
        }
        _ => {
            false
        }
    };
    let v6: bool = v5 != true;
    if v6 {
        printed_stamps_4()
    } else {
        let i_v8: i32 = 0i32;
        let mut v9: Rc<dyn Fn(Rc<UH0>) -> US1> = method5(i_v8);
        let body_v10: US1 = v9(args_v1.clone());
        let mut v11: bool = match body_v10 {
            US1::US1_None => {
                true
            }
            _ => {
                false
            }
        };
        let check_v12: bool = v11 != true;
        let i_v13: i32 = 0i32;
        let mut v14: Rc<dyn Fn(Rc<UH0>) -> US1> = method6(i_v13);
        let body_v15: US1 = v14(args_v1.clone());
        let v16: bool = match body_v15 {
            US1::US1_None => {
                true
            }
            _ => {
                false
            }
        };
        let granular_v17: bool = v16 != true;
        let s_v18: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let v19: Rc<UH0> = method7(args_v1, s_v18);
        let s_v20: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let files_v21: Rc<UH0> = method8(v19, s_v20);
        let s_v22: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_Nil); } CASE.with(|case| case.clone()) };
        let rows_v23: Rc<UH1> = method15(granular_v17, files_v21.clone(), s_v22);
        method278(rows_v23.clone());
        let s_v24: i32 = 0i32;
        let files_v25: i32 = method279(files_v21.clone(), s_v24);
        let backend_v26: Rc<str> = report_line_280(rows_v23.clone(), files_v25);
        println!("{}", backend_v26);
        if granular_v17 {
            let backend_v27: Rc<str> = kinds_line_289(files_v21);
            println!("{}", backend_v27);
            ()
        };
        let kind_v28: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("over_budget"); } LIT.with(|lit| lit.clone()) };
        let over_v29: i32 = count_of_284(kind_v28, rows_v23);
        let v31: bool = if check_v12 {
            let v30: bool = over_v29 > 0i32;
            v30
        } else {
            false
        };
        if v31 {
            refused_319(over_v29)
        } else {
            0i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
pub type SpiralShape_652accfc6a8d = Mut0;
pub type SpiralShape_97df63ebabc3 = Mut1;
