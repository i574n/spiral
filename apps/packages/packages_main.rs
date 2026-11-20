#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct SpiralUse(std::rc::Rc<dyn Fn()>);
impl Drop for SpiralUse {
    fn drop(&mut self) { (self.0)() }
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
    US1_PublishDryRun(Rc<str>, Rc<str>),
    US1_Usage,
}
#[derive(Clone)]
enum US5 {
    US5_UnreadableLine(i32, Rc<str>),
    US5_UnclosedBlock(Rc<str>),
}
#[derive(Clone)]
enum US4 {
    US4_TomlRefused(US5),
    US4_MissingKey(Rc<str>),
    US4_BadValue(Rc<str>, Rc<str>),
}
#[derive(Clone)]
enum US6 {
    US6_CrlfInModule(Rc<str>),
    US6_DuplicateModulePath(Rc<str>),
    US6_NoModules,
}
#[derive(Clone)]
enum US3 {
    US3_ManifestMissing(Rc<str>),
    US3_ManifestRefused(US4),
    US3_ModuleMissing(Rc<str>),
    US3_PrepareRefused(US6),
}
#[derive(Clone)]
enum US2 {
    US2_Accepted(Rc<str>, Rc<str>, Rc<UH0>),
    US2_Rejected(US3),
}
struct Mut0 { l0: i32, l1: Rc<UH0> }
#[derive(Clone)]
enum US7 {
    US7_TomlText(Rc<str>),
    US7_TomlList(Rc<UH0>),
}
#[derive(Clone)]
enum UH1 {
    UH1_Nil,
    UH1_Cons(Rc<str>, US7, Rc<UH1>),
}
#[derive(Clone)]
enum US8 {
    US8_Ok(Rc<UH1>),
    US8_Error(US5),
}
#[derive(Clone)]
enum US9 {
    US9_Some(Rc<str>, Rc<UH0>),
    US9_None,
}
#[derive(Clone)]
enum US10 {
    US10_Some(Rc<UH0>),
    US10_None,
}
#[derive(Clone)]
enum US11 {
    US11_Some(Rc<str>, Rc<str>),
    US11_None,
}
#[derive(Clone)]
enum US12 {
    US12_Some(US7),
    US12_None,
}
#[derive(Clone)]
enum US14 {
    US14_UpstreamEdition2,
    US14_ForkEdition3,
}
#[derive(Clone)]
enum US15 {
    US15_DefaultI8,
    US15_DefaultI16,
    US15_DefaultI32,
    US15_DefaultI64,
    US15_DefaultU8,
    US15_DefaultU16,
    US15_DefaultU32,
    US15_DefaultU64,
}
#[derive(Clone)]
enum US16 {
    US16_DefaultF32,
    US16_DefaultF64,
}
#[derive(Clone)]
enum US17 {
    US17_TargetC,
    US17_TargetRust,
    US17_TargetFsharp,
    US17_TargetPython,
    US17_TargetCuda,
    US17_TargetGleam,
    US17_TargetLua,
    US17_TargetZig,
    US17_TargetWasm,
    US17_TargetWgsl,
    US17_TargetTypeScript,
}
#[derive(Clone)]
enum UH2 {
    UH2_Nil,
    UH2_Cons(US17, Rc<UH2>),
}
#[derive(Clone)]
enum US13 {
    US13_Accepted(Rc<str>, u32, u32, u32, u64, US14, US15, US16, Rc<UH2>, Rc<UH0>),
    US13_Rejected(US4),
}
#[derive(Clone)]
enum US18 {
    US18_Accepted(Rc<str>),
    US18_Rejected(US4),
}
#[derive(Clone)]
enum US19 {
    US19_Some(Rc<str>),
    US19_None,
}
#[derive(Clone)]
enum US20 {
    US20_Accepted(u32, u32, u32),
    US20_Rejected(US4),
}
#[derive(Clone)]
enum US21 {
    US21_Some(u32, u32, u32),
    US21_None,
}
#[derive(Clone)]
enum US22 {
    US22_Some(u32),
    US22_None,
}
#[derive(Clone)]
enum US23 {
    US23_Accepted(u64),
    US23_Rejected(US4),
}
#[derive(Clone)]
enum US24 {
    US24_Some(u64),
    US24_None,
}
#[derive(Clone)]
enum US25 {
    US25_Some(u64),
    US25_None,
}
#[derive(Clone)]
enum US26 {
    US26_Accepted(Rc<str>, u32, u32, u32, u64),
    US26_Rejected(US4),
}
#[derive(Clone)]
enum US27 {
    US27_Accepted(US14),
    US27_Rejected(US4),
}
#[derive(Clone)]
enum UH3 {
    UH3_Nil,
    UH3_Cons(US14, Rc<UH3>),
}
#[derive(Clone)]
enum US28 {
    US28_Some(US14),
    US28_None,
}
#[derive(Clone)]
enum US29 {
    US29_Accepted(US15),
    US29_Rejected(US4),
}
#[derive(Clone)]
enum UH4 {
    UH4_Nil,
    UH4_Cons(US15, Rc<UH4>),
}
#[derive(Clone)]
enum US30 {
    US30_Some(US15),
    US30_None,
}
#[derive(Clone)]
enum US31 {
    US31_Accepted(US16),
    US31_Rejected(US4),
}
#[derive(Clone)]
enum UH5 {
    UH5_Nil,
    UH5_Cons(US16, Rc<UH5>),
}
#[derive(Clone)]
enum US32 {
    US32_Some(US16),
    US32_None,
}
#[derive(Clone)]
enum US33 {
    US33_Accepted(Rc<UH2>),
    US33_Rejected(US4),
}
#[derive(Clone)]
enum US34 {
    US34_Some(US17),
    US34_None,
}
#[derive(Clone)]
enum US35 {
    US35_Some(Rc<UH2>),
    US35_None,
}
#[derive(Clone)]
enum US36 {
    US36_Accepted(US14, US15, US16, Rc<UH2>),
    US36_Rejected(US4),
}
#[derive(Clone)]
enum US37 {
    US37_Accepted(Rc<UH0>),
    US37_Rejected(US4),
}
#[derive(Clone)]
enum UH6 {
    UH6_Nil,
    UH6_Cons(Rc<str>, Rc<str>, Rc<UH6>),
}
#[derive(Clone)]
enum US38 {
    US38_Accepted(Rc<UH6>),
    US38_Rejected(US3),
}
#[derive(Clone)]
enum UH7 {
    UH7_Nil,
    UH7_Cons(Rc<str>, u32, u32, u32, Rc<str>, Rc<UH7>),
}
#[derive(Clone)]
enum UH9 {
    UH9_Nil,
    UH9_Cons(Rc<str>, Rc<UH9>),
}
#[derive(Clone)]
enum UH8 {
    UH8_Nil,
    UH8_Cons(Rc<str>, u32, u32, u32, Rc<UH9>, Rc<UH8>),
}
#[derive(Clone)]
enum US41 {
    US41_OwnPackageDirectory,
    US41_CallerWorkspace,
    US41_UnderRelativePath(Rc<str>),
}
#[derive(Clone)]
enum US40 {
    US40_ReadFiles(US41),
    US40_WriteFiles(US41),
    US40_NetworkTo(Rc<str>),
    US40_SpawnProcess(Rc<str>),
    US40_ReadEnvironment(Rc<str>),
    US40_ForeignLibrary(US17, Rc<str>),
    US40_GpuDevice,
    US40_WallClock,
}
#[derive(Clone)]
enum UH10 {
    UH10_Nil,
    UH10_Cons(US40, Rc<UH10>),
}
#[derive(Clone)]
enum UH11 {
    UH11_Nil,
    UH11_Cons(Rc<str>, Rc<str>, u64, Rc<UH11>),
}
#[derive(Clone)]
enum US42 {
    US42_SingleModule(Rc<str>, Rc<str>, u64),
    US42_ModuleDirectory(Rc<UH11>),
}
#[derive(Clone)]
enum UH12 {
    UH12_Nil,
    UH12_Cons(Rc<str>, Rc<str>, Rc<UH12>),
}
#[derive(Clone)]
enum US39 {
    US39_Accepted(Rc<str>, u32, u32, u32, u64, US14, US15, US16, Rc<UH2>, Rc<UH7>, Rc<UH8>, Rc<UH10>, US42, Rc<UH12>),
    US39_Rejected(US6),
}
#[derive(Clone)]
enum US43 {
    US43_Ok,
    US43_Error(Rc<str>),
}
struct Mut1 { l0: Rc<str> }
struct Mut2 { l0: i32 }
struct Mut3 { l0: i32 }
fn command_line_argument_count_1() -> i32 {
    let backend_v0: usize = std::env::args().count();
    let x_v1: i32 = ((backend_v0) as i32);
    let mut v2: i32 = x_v1.wrapping_sub(1i32);
    v2
}
fn command_line_argument_2(mut v0: i32) -> Rc<str> {
    let x_v1: i32 = v0.wrapping_add(1i32);
    let x_v2: usize = ((x_v1) as usize);
    let v3: Rc<str> = Rc::<str>::from(std::env::args().nth(x_v2).unwrap_or_default());
    v3
}
fn arguments_from_0(mut index_v0: i32) -> Rc<UH0> {
    let mut v1: bool = index_v0 >= 0i32;
    let v4: bool = if v1 {
        let mut v2: i32 = command_line_argument_count_1();
        let v3: bool = index_v0 < v2;
        v3
    } else {
        false
    };
    let v8: US0 = if v4 {
        let v5: Rc<str> = command_line_argument_2(index_v0);
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
            let v12: Rc<UH0> = arguments_from_0(index_v11);
            Rc::new(UH0::UH0_Cons(argument_v10, v12))
        }
    }
}
fn file_exists_4(mut backend_v0: Rc<str>) -> bool {
    let x_v2: &str = &*backend_v0;
    let backend_v4: std::string::String = String::from(x_v2);
    let mut path_buf_v6: std::path::PathBuf = std::path::PathBuf::from(backend_v4);
    let v8: bool = path_buf_v6.exists();
    if v8 {
        let v10: bool = path_buf_v6.is_file();
        v10
    } else {
        false
    }
}
fn method5(mut v0: Vec<u8>) -> Vec<u8> {
    v0
}
fn method7(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> Rc<UH0> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(v2, v3) => {
                let mut v2: Rc<str> = v2;
                let v3: Rc<UH0> = v3;
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
fn method8(mut v0: i32, mut v1: &Rc<RefCell<Mut0>>) -> bool {
    let mut v2: i32 = v1.borrow().l0;
    let v3: bool = v2 < v0;
    v3
}
fn split_list_6(mut backend_v0: Rc<str>, mut backend_v1: Rc<str>) -> Rc<UH0> {
    let mut v2: i32 = (backend_v0.clone().len() as i32);
    let v3: bool = v2 == 0i32;
    if v3 {
        let v4: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        Rc::new(UH0::UH0_Cons(backend_v1, v4))
    } else {
        let v6: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(backend_v1.split(&*backend_v0).map(|x| Rc::<str>::from(x)).collect::<Vec<Rc<str>>>()));
        let v7: i32 = (v6.borrow().len() as i32);
        let v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        let mut s_v9: Rc<RefCell<Mut0>> = Rc::new(RefCell::new(Mut0 { l0: 0i32, l1: v8 }));
        while method8(v7, &s_v9) {
            let i_v11: i32 = s_v9.borrow().l0;
            let v12: Rc<UH0> = s_v9.borrow().l1.clone();
            let v13: Rc<str> = v6.borrow()[i_v11 as usize].clone();
            let v14: i32 = i_v11.wrapping_add(1i32);
            let v15: Rc<UH0> = Rc::new(UH0::UH0_Cons(v13, v12));
            s_v9.borrow_mut().l0 = v14;
            s_v9.borrow_mut().l1 = v15;
            ()
        };
        let v16: Rc<UH0> = s_v9.borrow().l1.clone();
        let s_v17: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
        method7(v16, s_v17)
    }
}
fn method10(mut v0: Option<usize>) -> Option<usize> {
    v0
}
fn method12(mut v0: Rc<RefCell<Vec<Rc<str>>>>, mut v1: Rc<UH0>, mut v2: i32) -> i32 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v3, v4) => {
                let v3: Rc<str> = v3;
                let v4: Rc<UH0> = v4;
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
fn block_lines_11(mut key_v0: &Rc<str>, mut v1: Rc<UH0>, mut v2: Rc<UH0>) -> US9 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(backend_v4, lines_v5) => {
                let backend_v4: Rc<str> = backend_v4;
                let lines_v5: Rc<UH0> = lines_v5;
                let v6: Rc<str> = Rc::<str>::from((backend_v4).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                let v7: bool = &*v6 == "'''";
                if v7 {
                    let s_v8: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                    let backend_v9: Rc<UH0> = method7(v2, s_v8);
                    let acc_v10: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
                    let mut s_v11: i32 = 0i32;
                    let v12: i32 = method12(acc_v10.clone(), backend_v9, s_v11);
                    let backend_v13: Rc<Vec<Rc<str>>> = Rc::new(acc_v10.borrow().clone());
                    let items_v14: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v13).as_ref().clone()));
                    let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
                    let v16: Rc<str> = Rc::<str>::from((*items_v14.borrow()).join(&*v15));
                    return US9::US9_Some(v16, lines_v5);
                } else {
                    let acc_v18: Rc<UH0> = Rc::new(UH0::UH0_Cons(backend_v4, v2));
                    (v1, v2) = (lines_v5, acc_v18);
                    continue;
                }
            }
            UH0::UH0_Nil => {
                return US9::US9_None;
            }
        }
    }
}
fn quoted_all_13(mut v0: Rc<UH0>, mut v1: Rc<UH0>) -> US10 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH0::UH0_Cons(backend_v5, items_v6) => {
                let backend_v5: Rc<str> = backend_v5;
                let items_v6: Rc<UH0> = items_v6;
                let backend_v7: Rc<str> = Rc::<str>::from((backend_v5).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                let n_v8: i32 = (backend_v7.clone().len() as i32);
                let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("'"); } LIT.with(|lit| lit.clone()) };
                let v10: bool = backend_v7.starts_with(&*v9);
                let single_v12: bool = if v10 {
                    let v11: bool = backend_v7.ends_with(&*v9);
                    v11
                } else {
                    false
                };
                let v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\""); } LIT.with(|lit| lit.clone()) };
                let v14: bool = backend_v7.starts_with(&*v13);
                let double_v16: bool = if v14 {
                    let v15: bool = backend_v7.ends_with(&*v13);
                    v15
                } else {
                    false
                };
                let v17: bool = n_v8 >= 2i32;
                let mut v19: bool = if v17 {
                    let mut v18: bool = single_v12 || double_v16;
                    v18
                } else {
                    false
                };
                let v27: US0 = if v19 {
                    let backend_v20: i32 = n_v8.wrapping_sub(2i32);
                    let x_v21: usize = ((1i32) as usize);
                    let backend_v22: i32 = 1i32.wrapping_add(backend_v20);
                    let x_v23: usize = ((backend_v22) as usize);
                    let v24: Rc<str> = Rc::<str>::from(&(backend_v7)[x_v21..x_v23]);
                    US0::US0_Some(v24)
                } else {
                    US0::US0_None
                };
                match v27 {
                    US0::US0_None => {
                        return US10::US10_None;
                    }
                    US0::US0_Some(t_v28) => {
                        let t_v28: Rc<str> = t_v28;
                        let acc_v29: Rc<UH0> = Rc::new(UH0::UH0_Cons(t_v28, v1));
                        (v0, v1) = (items_v6, acc_v29);
                        continue;
                    }
                }
            }
            UH0::UH0_Nil => {
                let s_v2: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                let v3: Rc<UH0> = method7(v1, s_v2);
                return US10::US10_Some(v3);
            }
        }
    }
}
fn method14(mut v0: Rc<UH1>, mut v1: Rc<UH1>) -> Rc<UH1> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH1::UH1_Cons(v2, v3, v4) => {
                let mut v2: Rc<str> = v2;
                let v3: US7 = v3;
                let v4: Rc<UH1> = v4;
                let s_v5: Rc<UH1> = Rc::new(UH1::UH1_Cons(v2, v3, v1));
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH1::UH1_Nil => {
                return v1;
            }
        }
    }
}
fn closure0() -> Rc<dyn Fn((usize)) -> i32> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((usize)) -> i32> = Rc::new(move |mut v0: (usize)| -> i32 {
        let mut v1: usize = (v0);
        let mut v2: i32 = ((v1) as i32);
        v2
    }); } CLOSURE.with(|closure| closure.clone())
}
fn entries_9(mut v0: i32, mut v1: Rc<UH0>, mut acc_v2: Rc<UH1>) -> US8 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(backend_v6, lines_v7) => {
                let backend_v6: Rc<str> = backend_v6;
                let lines_v7: Rc<UH0> = lines_v7;
                let line_v8: Rc<str> = Rc::<str>::from((backend_v6).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                let v9: bool = &*line_v8 == "";
                let v12: bool = if v9 {
                    true
                } else {
                    let search_v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("#"); } LIT.with(|lit| lit.clone()) };
                    let v11: bool = line_v8.starts_with(&*search_v10);
                    v11
                };
                if v12 {
                    let n_v13: i32 = v0.wrapping_add(1i32);
                    (v0, v1) = (n_v13, lines_v7);
                    continue;
                } else {
                    let search_v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("="); } LIT.with(|lit| lit.clone()) };
                    let backend_v16: Option<usize> = line_v8.find(&*search_v15);
                    let x_v17: Option<usize> = method10(backend_v16);
                    let mut v18: Rc<dyn Fn((usize)) -> i32> = closure0();
                    let mut v19: Option<i32> = x_v17.map(|x| v18(x));
                    let at_v21: i32 = v19.unwrap_or(-1i32);
                    let v22: bool = at_v21 <= 0i32;
                    let v38: US11 = if v22 {
                        US11::US11_None
                    } else {
                        let x_v24: usize = ((0i32) as usize);
                        let x_v25: usize = ((at_v21) as usize);
                        let backend_v26: Rc<str> = Rc::<str>::from(&(line_v8)[x_v24..x_v25]);
                        let key_v27: Rc<str> = Rc::<str>::from((backend_v26).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                        let backend_v28: i32 = at_v21.wrapping_add(1i32);
                        let v29: i32 = (line_v8.clone().len() as i32);
                        let v30: i32 = v29.wrapping_sub(at_v21);
                        let backend_v31: i32 = v30.wrapping_sub(1i32);
                        let x_v32: usize = ((backend_v28) as usize);
                        let backend_v33: i32 = backend_v28.wrapping_add(backend_v31);
                        let x_v34: usize = ((backend_v33) as usize);
                        let rest_v35: Rc<str> = Rc::<str>::from(&(line_v8)[x_v32..x_v34]);
                        let v36: Rc<str> = Rc::<str>::from((rest_v35).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                        US11::US11_Some(key_v27, v36)
                    };
                    match v38 {
                        US11::US11_None => {
                            let v39: US5 = US5::US5_UnreadableLine(v0, line_v8);
                            return US8::US8_Error(v39);
                        }
                        US11::US11_Some(key_v41, backend_v42) => {
                            let key_v41: Rc<str> = key_v41;
                            let backend_v42: Rc<str> = backend_v42;
                            let v43: bool = "'''" == &*backend_v42;
                            if v43 {
                                let acc_v44: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let v45: US9 = block_lines_11(&key_v41, lines_v7, acc_v44);
                                match v45 {
                                    US9::US9_None => {
                                        let v52: US5 = US5::US5_UnclosedBlock(key_v41);
                                        return US8::US8_Error(v52);
                                    }
                                    US9::US9_Some(v46, lines_v47) => {
                                        let v46: Rc<str> = v46;
                                        let lines_v47: Rc<UH0> = lines_v47;
                                        let n_v48: i32 = v0.wrapping_add(1i32);
                                        let mut v49: US7 = US7::US7_TomlText(v46);
                                        let acc_v50: Rc<UH1> = Rc::new(UH1::UH1_Cons(key_v41, v49, acc_v2));
                                        (v0, v1, acc_v2) = (n_v48, lines_v47, acc_v50);
                                        continue;
                                    }
                                }
                            } else {
                                let n_v56: i32 = (backend_v42.clone().len() as i32);
                                let search_v57: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("'"); } LIT.with(|lit| lit.clone()) };
                                let v58: bool = backend_v42.starts_with(&*search_v57);
                                let single_v60: bool = if v58 {
                                    let v59: bool = backend_v42.ends_with(&*search_v57);
                                    v59
                                } else {
                                    false
                                };
                                let search_v61: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\""); } LIT.with(|lit| lit.clone()) };
                                let v62: bool = backend_v42.starts_with(&*search_v61);
                                let double_v64: bool = if v62 {
                                    let v63: bool = backend_v42.ends_with(&*search_v61);
                                    v63
                                } else {
                                    false
                                };
                                let v65: bool = n_v56 >= 2i32;
                                let v67: bool = if v65 {
                                    let v66: bool = single_v60 || double_v64;
                                    v66
                                } else {
                                    false
                                };
                                let v75: US0 = if v67 {
                                    let backend_v68: i32 = n_v56.wrapping_sub(2i32);
                                    let x_v69: usize = ((1i32) as usize);
                                    let backend_v70: i32 = 1i32.wrapping_add(backend_v68);
                                    let x_v71: usize = ((backend_v70) as usize);
                                    let v72: Rc<str> = Rc::<str>::from(&(backend_v42)[x_v69..x_v71]);
                                    US0::US0_Some(v72)
                                } else {
                                    US0::US0_None
                                };
                                let v108: US12 = match v75 {
                                    US0::US0_None => {
                                        let v81: bool = if v65 {
                                            let search_v79: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("["); } LIT.with(|lit| lit.clone()) };
                                            let v80: bool = backend_v42.starts_with(&*search_v79);
                                            v80
                                        } else {
                                            false
                                        };
                                        let v84: bool = if v81 {
                                            let search_v82: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("]"); } LIT.with(|lit| lit.clone()) };
                                            let v83: bool = backend_v42.ends_with(&*search_v82);
                                            v83
                                        } else {
                                            false
                                        };
                                        let v100: US10 = if v84 {
                                            let mut backend_v85: i32 = n_v56.wrapping_sub(2i32);
                                            let x_v86: usize = ((1i32) as usize);
                                            let backend_v87: i32 = 1i32.wrapping_add(backend_v85);
                                            let x_v88: usize = ((backend_v87) as usize);
                                            let backend_v89: Rc<str> = Rc::<str>::from(&(backend_v42)[x_v86..x_v88]);
                                            let inner_v90: Rc<str> = Rc::<str>::from((backend_v89).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
                                            let v91: bool = &*inner_v90 == "";
                                            if v91 {
                                                let v92: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                                US10::US10_Some(v92)
                                            } else {
                                                let separator_v94: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(","); } LIT.with(|lit| lit.clone()) };
                                                let items_v95: Rc<UH0> = split_list_6(separator_v94, inner_v90);
                                                let acc_v96: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                                quoted_all_13(items_v95, acc_v96)
                                            }
                                        } else {
                                            US10::US10_None
                                        };
                                        match v100 {
                                            US10::US10_None => {
                                                US12::US12_None
                                            }
                                            US10::US10_Some(a_v101) => {
                                                let a_v101: Rc<UH0> = a_v101;
                                                let v102: US7 = US7::US7_TomlList(a_v101);
                                                US12::US12_Some(v102)
                                            }
                                        }
                                    }
                                    US0::US0_Some(t_v76) => {
                                        let t_v76: Rc<str> = t_v76;
                                        let v77: US7 = US7::US7_TomlText(t_v76);
                                        US12::US12_Some(v77)
                                    }
                                };
                                match v108 {
                                    US12::US12_None => {
                                        let v113: US5 = US5::US5_UnreadableLine(v0, line_v8);
                                        return US8::US8_Error(v113);
                                    }
                                    US12::US12_Some(v_v109) => {
                                        let v_v109: US7 = v_v109;
                                        let n_v110: i32 = v0.wrapping_add(1i32);
                                        let acc_v111: Rc<UH1> = Rc::new(UH1::UH1_Cons(key_v41, v_v109, acc_v2));
                                        (v0, v1, acc_v2) = (n_v110, lines_v7, acc_v111);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            UH0::UH0_Nil => {
                let s_v3: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_Nil); } CASE.with(|case| case.clone()) };
                let v4: Rc<UH1> = method14(acc_v2, s_v3);
                return US8::US8_Ok(v4);
            }
        }
    }
}
fn lookup_15(mut key_v0: Rc<str>, mut v1: Rc<UH1>) -> US12 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH1::UH1_Cons(v3, v4, es_v5) => {
                let v3: Rc<str> = v3;
                let v4: US7 = v4;
                let es_v5: Rc<UH1> = es_v5;
                let v6: bool = &*v3 == &*key_v0;
                if v6 {
                    return US12::US12_Some(v4);
                } else {
                    v1 = es_v5;
                    continue;
                }
            }
            UH1::UH1_Nil => {
                return US12::US12_None;
            }
        }
    }
}
fn method16(mut v0: Option<u32>) -> Option<u32> {
    v0
}
fn closure1() -> Rc<dyn Fn((u32)) -> US22> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((u32)) -> US22> = Rc::new(move |mut v0: (u32)| -> US22 {
        let mut v1: u32 = (v0);
        US22::US22_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method17(mut v0: Option<u64>) -> Option<u64> {
    v0
}
fn closure2() -> Rc<dyn Fn((u64)) -> US24> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((u64)) -> US24> = Rc::new(move |mut v0: (u64)| -> US24 {
        let mut v1: u64 = (v0);
        US24::US24_Some(v1)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure3() -> Rc<dyn Fn(US14) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US14) -> Rc<str>> = Rc::new(move |mut v0: US14| -> Rc<str> {
        match v0 {
            US14::US14_ForkEdition3 => {
                let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("3"); } LIT.with(|lit| lit.clone()) };
                v2
            }
            US14::US14_UpstreamEdition2 => {
                let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("2"); } LIT.with(|lit| lit.clone()) };
                v1
            }
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn printed_as_18(mut show_v0: Rc<dyn Fn(US14) -> Rc<str>>, mut text_v1: Rc<str>, mut v2: Rc<UH3>) -> US28 {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH3::UH3_Cons(v4, cases_v5) => {
                let v4: US14 = v4;
                let cases_v5: Rc<UH3> = cases_v5;
                let v6: Rc<str> = show_v0(v4.clone());
                let v7: bool = &*v6 == &*text_v1;
                if v7 {
                    return US28::US28_Some(v4);
                } else {
                    v2 = cases_v5;
                    continue;
                }
            }
            UH3::UH3_Nil => {
                return US28::US28_None;
            }
        }
    }
}
fn closure4() -> Rc<dyn Fn(US15) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US15) -> Rc<str>> = Rc::new(move |mut v0: US15| -> Rc<str> {
        match v0 {
            US15::US15_DefaultI16 => {
                let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i16"); } LIT.with(|lit| lit.clone()) };
                v2
            }
            US15::US15_DefaultI32 => {
                let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i32"); } LIT.with(|lit| lit.clone()) };
                v3
            }
            US15::US15_DefaultI64 => {
                let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i64"); } LIT.with(|lit| lit.clone()) };
                v4
            }
            US15::US15_DefaultI8 => {
                let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i8"); } LIT.with(|lit| lit.clone()) };
                v1
            }
            US15::US15_DefaultU16 => {
                let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u16"); } LIT.with(|lit| lit.clone()) };
                v6
            }
            US15::US15_DefaultU32 => {
                let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u32"); } LIT.with(|lit| lit.clone()) };
                v7
            }
            US15::US15_DefaultU64 => {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u64"); } LIT.with(|lit| lit.clone()) };
                v8
            }
            US15::US15_DefaultU8 => {
                let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u8"); } LIT.with(|lit| lit.clone()) };
                v5
            }
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn printed_as_19(mut show_v0: Rc<dyn Fn(US15) -> Rc<str>>, mut text_v1: Rc<str>, mut v2: Rc<UH4>) -> US30 {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH4::UH4_Cons(v4, cases_v5) => {
                let v4: US15 = v4;
                let cases_v5: Rc<UH4> = cases_v5;
                let v6: Rc<str> = show_v0(v4.clone());
                let v7: bool = &*v6 == &*text_v1;
                if v7 {
                    return US30::US30_Some(v4);
                } else {
                    v2 = cases_v5;
                    continue;
                }
            }
            UH4::UH4_Nil => {
                return US30::US30_None;
            }
        }
    }
}
fn closure5() -> Rc<dyn Fn(US16) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US16) -> Rc<str>> = Rc::new(move |mut v0: US16| -> Rc<str> {
        match v0 {
            US16::US16_DefaultF32 => {
                let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f32"); } LIT.with(|lit| lit.clone()) };
                v1
            }
            US16::US16_DefaultF64 => {
                let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f64"); } LIT.with(|lit| lit.clone()) };
                v2
            }
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn printed_as_20(mut show_v0: Rc<dyn Fn(US16) -> Rc<str>>, mut text_v1: Rc<str>, mut v2: Rc<UH5>) -> US32 {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH5::UH5_Cons(v4, cases_v5) => {
                let v4: US16 = v4;
                let cases_v5: Rc<UH5> = cases_v5;
                let v6: Rc<str> = show_v0(v4.clone());
                let v7: bool = &*v6 == &*text_v1;
                if v7 {
                    return US32::US32_Some(v4);
                } else {
                    v2 = cases_v5;
                    continue;
                }
            }
            UH5::UH5_Nil => {
                return US32::US32_None;
            }
        }
    }
}
fn closure7() -> Rc<dyn Fn(US17) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(US17) -> Rc<str>> = Rc::new(move |mut v0: US17| -> Rc<str> {
        match v0 {
            US17::US17_TargetC => {
                let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
                v1
            }
            US17::US17_TargetCuda => {
                let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cuda"); } LIT.with(|lit| lit.clone()) };
                v5
            }
            US17::US17_TargetFsharp => {
                let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fsharp"); } LIT.with(|lit| lit.clone()) };
                v3
            }
            US17::US17_TargetGleam => {
                let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gleam"); } LIT.with(|lit| lit.clone()) };
                v6
            }
            US17::US17_TargetLua => {
                let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("lua"); } LIT.with(|lit| lit.clone()) };
                v7
            }
            US17::US17_TargetPython => {
                let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("python"); } LIT.with(|lit| lit.clone()) };
                v4
            }
            US17::US17_TargetRust => {
                let mut v2: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("rust"); } LIT.with(|lit| lit.clone()) };
                v2
            }
            US17::US17_TargetTypeScript => {
                let v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("typescript"); } LIT.with(|lit| lit.clone()) };
                v11
            }
            US17::US17_TargetWasm => {
                let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
                v9
            }
            US17::US17_TargetWgsl => {
                let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wgsl"); } LIT.with(|lit| lit.clone()) };
                v10
            }
            US17::US17_TargetZig => {
                let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zig"); } LIT.with(|lit| lit.clone()) };
                v8
            }
        }
    }); } CLOSURE.with(|closure| closure.clone())
}
fn printed_as_21(mut show_v0: Rc<dyn Fn(US17) -> Rc<str>>, mut text_v1: Rc<str>, mut v2: Rc<UH2>) -> US34 {
    loop {
        match Rc::unwrap_or_clone(v2) {
            UH2::UH2_Cons(v4, cases_v5) => {
                let v4: US17 = v4;
                let cases_v5: Rc<UH2> = cases_v5;
                let v6: Rc<str> = show_v0(v4.clone());
                let v7: bool = &*v6 == &*text_v1;
                if v7 {
                    return US34::US34_Some(v4);
                } else {
                    v2 = cases_v5;
                    continue;
                }
            }
            UH2::UH2_Nil => {
                return US34::US34_None;
            }
        }
    }
}
fn closure6() -> Rc<dyn Fn(Rc<str>) -> US34> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> US34> = Rc::new(move |mut v0: Rc<str>| -> US34 {
        let mut v1: Rc<dyn Fn(US17) -> Rc<str>> = closure7();
        let mut v2: US17 = US17::US17_TargetC;
        let v3: US17 = US17::US17_TargetRust;
        let v4: US17 = US17::US17_TargetFsharp;
        let v5: US17 = US17::US17_TargetPython;
        let v6: US17 = US17::US17_TargetCuda;
        let v7: US17 = US17::US17_TargetGleam;
        let v8: US17 = US17::US17_TargetLua;
        let v9: US17 = US17::US17_TargetZig;
        let v10: US17 = US17::US17_TargetWasm;
        let v11: US17 = US17::US17_TargetWgsl;
        let v12: US17 = US17::US17_TargetTypeScript;
        let v13: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
        let v14: Rc<UH2> = Rc::new(UH2::UH2_Cons(v12, v13));
        let v15: Rc<UH2> = Rc::new(UH2::UH2_Cons(v11, v14));
        let v16: Rc<UH2> = Rc::new(UH2::UH2_Cons(v10, v15));
        let v17: Rc<UH2> = Rc::new(UH2::UH2_Cons(v9, v16));
        let mut v18: Rc<UH2> = Rc::new(UH2::UH2_Cons(v8, v17));
        let mut v19: Rc<UH2> = Rc::new(UH2::UH2_Cons(v7, v18));
        let v20: Rc<UH2> = Rc::new(UH2::UH2_Cons(v6, v19));
        let v21: Rc<UH2> = Rc::new(UH2::UH2_Cons(v5, v20));
        let v22: Rc<UH2> = Rc::new(UH2::UH2_Cons(v4, v21));
        let v23: Rc<UH2> = Rc::new(UH2::UH2_Cons(v3, v22));
        let v24: Rc<UH2> = Rc::new(UH2::UH2_Cons(v2, v23));
        printed_as_21(v1, v0, v24)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method23(mut v0: Rc<UH2>, mut v1: Rc<UH2>) -> Rc<UH2> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH2::UH2_Cons(v2, v3) => {
                let mut v2: US17 = v2;
                let v3: Rc<UH2> = v3;
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
fn all_read_22(mut read_v0: Rc<dyn Fn(Rc<str>) -> US34>, mut v1: Rc<UH0>, mut v2: Rc<UH2>) -> US35 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v6, texts_v7) => {
                let v6: Rc<str> = v6;
                let texts_v7: Rc<UH0> = texts_v7;
                let v8: US34 = read_v0(v6);
                match v8 {
                    US34::US34_None => {
                        return US35::US35_None;
                    }
                    US34::US34_Some(v_v9) => {
                        let v_v9: US17 = v_v9;
                        let acc_v10: Rc<UH2> = Rc::new(UH2::UH2_Cons(v_v9, v2));
                        (v1, v2) = (texts_v7, acc_v10);
                        continue;
                    }
                }
            }
            UH0::UH0_Nil => {
                let s_v3: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                let v4: Rc<UH2> = method23(v2, s_v3);
                return US35::US35_Some(v4);
            }
        }
    }
}
fn method24(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(backend_v2, v3) => {
            let backend_v2: Rc<str> = backend_v2;
            let v3: Rc<UH0> = v3;
            let v4: Rc<UH0> = method24(v3, s_v1);
            let v5: Rc<str> = Rc::<str>::from((backend_v2).trim_matches(|c: char| { let n = c as u32; n == 32 || n == 9 || n == 13 || n == 10 }));
            Rc::new(UH0::UH0_Cons(v5, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method25(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let v3: Rc<UH0> = v3;
            let v4: Rc<UH0> = method25(v3, s_v1);
            let v5: bool = &*v2 != "";
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
fn method27(mut v0: Rc<UH6>, mut v1: Rc<UH6>) -> Rc<UH6> {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(v2, v3, v4) => {
                let mut v2: Rc<str> = v2;
                let v3: Rc<str> = v3;
                let v4: Rc<UH6> = v4;
                let s_v5: Rc<UH6> = Rc::new(UH6::UH6_Cons(v2, v3, v1));
                (v0, v1) = (v4, s_v5);
                continue;
            }
            UH6::UH6_Nil => {
                return v1;
            }
        }
    }
}
fn read_modules_26(mut dir_v0: Rc<str>, mut v1: Rc<UH0>, mut v2: Rc<UH6>) -> US38 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH0::UH0_Cons(v6, modules_v7) => {
                let v6: Rc<str> = v6;
                let modules_v7: Rc<UH0> = modules_v7;
                let v8: Rc<str> = string_concat(&[&*v6, ".spi"]);
                let path_v10: Rc<str> = string_concat(&[&*dir_v0, "/", &*v8]);
                let v11: bool = file_exists_4(path_v10.clone());
                if v11 {
                    let v13: Result<Vec<u8>, std::io::Error> = std::fs::read(&*path_v10);
                    let v15: Vec<u8> = v13.unwrap();
                    let bytes_v16: Vec<u8> = method5(v15);
                    let mut v18: Result<std::string::String, std::string::FromUtf8Error> = std::string::String::from_utf8(bytes_v16);
                    let backend_v20: std::string::String = v18.unwrap();
                    let v22: Rc<str> = Rc::<str>::from(String::as_str(&backend_v20));
                    let acc_v23: Rc<UH6> = Rc::new(UH6::UH6_Cons(v8, v22, v2));
                    (v1, v2) = (modules_v7, acc_v23);
                    continue;
                } else {
                    let v25: US3 = US3::US3_ModuleMissing(v8);
                    return US38::US38_Rejected(v25);
                }
            }
            UH0::UH0_Nil => {
                let s_v3: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
                let v4: Rc<UH6> = method27(v2, s_v3);
                return US38::US38_Accepted(v4);
            }
        }
    }
}
fn first_crlf_28(mut v0: Rc<UH6>) -> US0 {
    loop {
        match Rc::unwrap_or_clone(v0) {
            UH6::UH6_Cons(v2, backend_v3, files_v4) => {
                let mut v2: Rc<str> = v2;
                let backend_v3: Rc<str> = backend_v3;
                let files_v4: Rc<UH6> = files_v4;
                let search_v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\r"); } LIT.with(|lit| lit.clone()) };
                let v6: bool = backend_v3.contains(&*search_v5);
                if v6 {
                    return US0::US0_Some(v2);
                } else {
                    v0 = files_v4;
                    continue;
                }
            }
            UH6::UH6_Nil => {
                return US0::US0_None;
            }
        }
    }
}
fn closure8(mut v0: Rc<str>, mut v1: Rc<str>) -> Rc<dyn Fn(Rc<str>) -> bool> {
    Rc::new(move |mut v2: Rc<str>| -> bool {
        let v3: bool = &*v2 == &*v0;
        v3
    })
}
fn method30(mut v0: Rc<str>, mut v1: Rc<str>) -> Rc<dyn Fn(Rc<str>) -> bool> {
    closure8(v0, v1)
}
fn method31(mut v0: Rc<str>, mut v1: Rc<str>, mut v2: Rc<dyn Fn(Rc<str>) -> bool>, mut v3: Rc<UH0>) -> bool {
    loop {
        match Rc::unwrap_or_clone(v3) {
            UH0::UH0_Cons(v4, x_v5) => {
                let v4: Rc<str> = v4;
                let x_v5: Rc<UH0> = x_v5;
                let v6: bool = v2(v4);
                if v6 {
                    return true;
                } else {
                    let f_v7: Rc<dyn Fn(Rc<str>) -> bool> = method30(v0.clone(), v1.clone());
                    (v2, v3) = (f_v7, x_v5);
                    continue;
                }
            }
            UH0::UH0_Nil => {
                return false;
            }
        }
    }
}
fn first_duplicate_29(mut x_v0: Rc<UH0>, mut v1: Rc<UH6>) -> US0 {
    loop {
        match Rc::unwrap_or_clone(v1) {
            UH6::UH6_Cons(v3, v4, files_v5) => {
                let v3: Rc<str> = v3;
                let v4: Rc<str> = v4;
                let files_v5: Rc<UH6> = files_v5;
                let f_v6: Rc<dyn Fn(Rc<str>) -> bool> = method30(v3.clone(), v4.clone());
                let v7: bool = method31(v3.clone(), v4, f_v6, x_v0.clone());
                if v7 {
                    return US0::US0_Some(v3);
                } else {
                    let seen_v9: Rc<UH0> = Rc::new(UH0::UH0_Cons(v3, x_v0));
                    (x_v0, v1) = (seen_v9, files_v5);
                    continue;
                }
            }
            UH6::UH6_Nil => {
                return US0::US0_None;
            }
        }
    }
}
fn closure9() -> Rc<dyn Fn((u8)) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((u8)) -> Rc<str>> = Rc::new(move |mut v0: (u8)| -> Rc<str> {
        let mut v1: u8 = (v0);
        let v3: std::string::String = format!("{:02x}", v1);
        let v5: Rc<str> = Rc::<str>::from(String::as_str(&v3));
        v5
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method33(mut v0: Vec<Rc<str>>) -> Vec<Rc<str>> {
    v0
}
fn method34(mut v0: Rc<Vec<Rc<str>>>, mut backend_v1: i32, mut v2: Rc<UH0>) -> Rc<UH0> {
    loop {
        let v3: bool = backend_v1 < 0i32;
        if v3 {
            return v2;
        } else {
            let x_v4: usize = ((backend_v1) as usize);
            let item_v5: Rc<str> = (v0)[x_v4].clone();
            let i_v6: i32 = backend_v1.wrapping_sub(1i32);
            let acc_v7: Rc<UH0> = Rc::new(UH0::UH0_Cons(item_v5, v2));
            (backend_v1, v2) = (i_v6, acc_v7);
            continue;
        }
    }
}
fn method35() -> Rc<str> {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    v0
}
fn hash_text_32(mut backend_v0: Rc<str>) -> Rc<str> {
    let backend_v1: Rc<RefCell<Vec<u8>>> = Rc::new(RefCell::new(backend_v0.as_bytes().to_vec()));
    let mut v2: Vec<u8> = (backend_v1).borrow().clone();
    let v4: std::io::Cursor<Vec<u8>> = std::io::Cursor::new(v2);
    let mut reader_v6: std::io::BufReader<std::io::Cursor<Vec<u8>>> = std::io::BufReader::new(v4);
    let v8: bool = true; let mut reader_v6 = reader_v6;
    let v10: bool = true; let result : sha2::Sha256 = sha2::Digest::new();
    let mut hasher_v12: sha2::Sha256 = result;
    let v14: bool = true; let mut hasher_v12 = hasher_v12;
    let x_v15: usize = ((0i32) as usize);
    let mut buffer_v17: _ = [0u8; 1024i32 as usize];
    let mut v19: bool = true; loop { // rust.loop 1;
    let v21: bool = true; let mut buffer_v17 = buffer_v17;
    let count_v23: Result<usize, std::io::Error> = std::io::Read::read(&mut reader_v6, &mut buffer_v17);
    let count_v25: usize = count_v23.unwrap();
    let v26: bool = count_v25 == x_v15 ;
    let v29: bool = if v26 {
        let v28: bool = true; break ();
        true
    } else {
        false
    };
    let x_v30: usize = ((count_v25) as usize);
    let backend_v31: usize = (x_v30.clone());
    let backend_v33: usize = buffer_v17.len();
    let v34: bool = backend_v31 == backend_v33 ;
    let v39: &_ = if v34 {
        let v36: &_ = &buffer_v17[x_v15..];
        v36
    } else {
        let v38: &_ = &buffer_v17[x_v15..x_v30];
        v38
    };
    let v41: bool = true; sha2::Digest::update(&mut hasher_v12, v39);
    let v43: bool = true; } // rust.loop 3;
    let v45: &[u8] = &sha2::Digest::finalize(hasher_v12);
    let v47: Vec<u8> = v45.iter().map(|x| *x).collect::<Vec<_>>();
    let mut v49: Rc<dyn Fn((u8)) -> Rc<str>> = closure9();
    let backend_v50: Vec<Rc<str>> = v47.iter().map(|x| v49(x.clone())).collect::<Vec<_>>();
    let vec_v51: Vec<Rc<str>> = method33(backend_v50);
    let backend_v52: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(vec_v51));
    let backend_v53: Rc<Vec<Rc<str>>> = Rc::new((backend_v52).borrow().clone());
    let backend_v54: usize = (backend_v53).len();
    let x_v55: i32 = ((backend_v54) as i32);
    let i_v56: i32 = x_v55.wrapping_sub(1i32);
    let acc_v57: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    let backend_v58: Rc<UH0> = method34(backend_v53, i_v56, acc_v57);
    let backend_v59: Rc<str> = method35();
    let acc_v60: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v61: i32 = 0i32;
    let v62: i32 = method12(acc_v60.clone(), backend_v58, s_v61);
    let backend_v63: Rc<Vec<Rc<str>>> = Rc::new(acc_v60.borrow().clone());
    let items_v64: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v63).as_ref().clone()));
    let x_v65: Rc<str> = Rc::<str>::from((*items_v64.borrow()).join(&*backend_v59));
    let v66: Result<Rc<str>, std::io::Error> = Ok::<Rc<str>, std::io::Error>(x_v65);
    let v68: Rc<str> = v66.unwrap();
    v68
}
fn method36(mut v0: Rc<UH6>, mut s_v1: Rc<UH11>) -> Rc<UH11> {
    match Rc::unwrap_or_clone(v0) {
        UH6::UH6_Cons(v2, input_v3, v4) => {
            let mut v2: Rc<str> = v2;
            let input_v3: Rc<str> = input_v3;
            let v4: Rc<UH6> = v4;
            let v5: Rc<UH11> = method36(v4, s_v1);
            let v6: Rc<str> = hash_text_32(input_v3.clone());
            let v7: i32 = (input_v3.len() as i32);
            let v8: u64 = (v7 as u64);
            Rc::new(UH11::UH11_Cons(v2, v6, v8, v5))
        }
        UH6::UH6_Nil => {
            s_v1
        }
    }
}
fn method37(mut v0: Rc<UH6>, mut s_v1: Rc<UH12>) -> Rc<UH12> {
    match Rc::unwrap_or_clone(v0) {
        UH6::UH6_Cons(_, input_v3, v4) => {
            let input_v3: Rc<str> = input_v3;
            let v4: Rc<UH6> = v4;
            let v5: Rc<UH12> = method37(v4, s_v1);
            let v6: Rc<str> = hash_text_32(input_v3.clone());
            Rc::new(UH12::UH12_Cons(v6, input_v3, v5))
        }
        UH6::UH6_Nil => {
            s_v1
        }
    }
}
fn closure10() -> Rc<dyn Fn(std::io::Error) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(std::io::Error) -> Rc<str>> = Rc::new(move |mut v0: std::io::Error| -> Rc<str> {
        let mut v1: Rc<str> = Rc::<str>::from({ struct W<T>(T); trait D { fn s(&self) -> String; } impl<T: std::fmt::Debug> D for &W<T> { fn s(&self) -> String { format!("{:?}", self.0) } } trait P { fn s(&self) -> String; } impl<T> P for W<T> { fn s(&self) -> String { String::from("<std::io::Error>") } } (&&W(&v0)).s() });
        v1
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method38() -> Rc<dyn Fn(std::io::Error) -> Rc<str>> {
    closure10()
}
fn ok_c11() -> Rc<dyn Fn() -> US43> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> US43> = Rc::new(move || -> US43 {
        US43::US43_Ok
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method39() -> Rc<dyn Fn() -> US43> {
    ok_c11()
}
fn error_c12() -> Rc<dyn Fn(Rc<str>) -> US43> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(Rc<str>) -> US43> = Rc::new(move |mut v0: Rc<str>| -> US43 {
        US43::US43_Error(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method40() -> Rc<dyn Fn(Rc<str>) -> US43> {
    error_c12()
}
fn method42(mut v0: &Rc<RefCell<Mut1>>, mut x_v1: Rc<str>) -> () {
    let s_v2: Rc<str> = v0.borrow().l0.clone();
    let v3: Rc<str> = string_concat(&[&*s_v2, &*x_v1]);
    v0.borrow_mut().l0 = v3;
    ()
}
fn format_real_41(mut x_v0: u32) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let result_v2: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v1 }));
    let s_v3: Rc<str> = Rc::<str>::from(format!("{}", x_v0));
    method42(&result_v2, s_v3);
    let v4: Rc<str> = result_v2.borrow().l0.clone();
    v4
}
fn method43(mut v0: Rc<UH2>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH2::UH2_Cons(v2, v3) => {
            let mut v2: US17 = v2;
            let v3: Rc<UH2> = v3;
            let v4: Rc<UH0> = method43(v3, s_v1);
            let b_v26: Rc<str> = match v2 {
                US17::US17_TargetC => {
                    let v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
                    v5
                }
                US17::US17_TargetCuda => {
                    let v9: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cuda"); } LIT.with(|lit| lit.clone()) };
                    v9
                }
                US17::US17_TargetFsharp => {
                    let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fsharp"); } LIT.with(|lit| lit.clone()) };
                    v7
                }
                US17::US17_TargetGleam => {
                    let v10: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gleam"); } LIT.with(|lit| lit.clone()) };
                    v10
                }
                US17::US17_TargetLua => {
                    let v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("lua"); } LIT.with(|lit| lit.clone()) };
                    v11
                }
                US17::US17_TargetPython => {
                    let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("python"); } LIT.with(|lit| lit.clone()) };
                    v8
                }
                US17::US17_TargetRust => {
                    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("rust"); } LIT.with(|lit| lit.clone()) };
                    v6
                }
                US17::US17_TargetTypeScript => {
                    let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("typescript"); } LIT.with(|lit| lit.clone()) };
                    v15
                }
                US17::US17_TargetWasm => {
                    let v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
                    v13
                }
                US17::US17_TargetWgsl => {
                    let v14: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wgsl"); } LIT.with(|lit| lit.clone()) };
                    v14
                }
                US17::US17_TargetZig => {
                    let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zig"); } LIT.with(|lit| lit.clone()) };
                    v12
                }
            };
            let v27: Rc<str> = string_concat(&["target ", &*b_v26]);
            Rc::new(UH0::UH0_Cons(v27, v4))
        }
        UH2::UH2_Nil => {
            s_v1
        }
    }
}
fn closure13() -> Rc<dyn Fn((Rc<str>)) -> Rc<str>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn((Rc<str>)) -> Rc<str>> = Rc::new(move |mut v0: (Rc<str>)| -> Rc<str> {
        let mut v1: Rc<str> = (v0);
        v1
    }); } CLOSURE.with(|closure| closure.clone())
}
fn method45() -> Rc<dyn Fn((Rc<str>)) -> Rc<str>> {
    closure13()
}
fn method46(mut v0: i32, mut v1: &Rc<RefCell<Mut2>>) -> bool {
    let mut v2: i32 = v1.borrow().l0;
    let v3: bool = v2 < v0;
    v3
}
fn method47(mut backend_v0: &Rc<RefCell<Vec<Rc<str>>>>, mut v1: Rc<str>, mut v2: &Rc<RefCell<Mut3>>) -> bool {
    let v3: i32 = v2.borrow().l0;
    let v4: bool = v3 > 0i32;
    if v4 {
        let v5: i32 = v2.borrow().l0;
        let backend_v6: i32 = v5.wrapping_sub(1i32);
        let v7: Rc<str> = backend_v0.borrow()[backend_v6 as usize].clone();
        let v8: bool = &*v7 < &*v1;
        let v11: i32 = if v8 {
            -1i32
        } else {
            let v9: bool = &*v7 > &*v1;
            if v9 {
                1i32
            } else {
                0i32
            }
        };
        let v12: bool = v11 == 1i32;
        v12
    } else {
        false
    }
}
fn sorted_44(mut backend_v0: Rc<UH0>) -> Rc<UH0> {
    let acc_v1: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
    let s_v2: i32 = 0i32;
    let v3: i32 = method12(acc_v1.clone(), backend_v0, s_v2);
    let backend_v4: Rc<Vec<Rc<str>>> = Rc::new(acc_v1.borrow().clone());
    let backend_v5: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v4).as_ref().clone()));
    let a_v6: Rc<RefCell<Vec<Rc<str>>>> = backend_v5 ;
    let mut key_fn_v7: Rc<dyn Fn((Rc<str>)) -> Rc<str>> = method45();
    let mut r_v8: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(a_v6.borrow().clone()));
    let mut keys_v9: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(a_v6.borrow().iter().map(|x| key_fn_v7(x.clone())).collect::<Vec<_>>()));
    let v10: i32 = (a_v6.borrow().len() as i32);
    let mut s_v11: Rc<RefCell<Mut2>> = Rc::new(RefCell::new(Mut2 { l0: 1i32 }));
    while method46(v10, &s_v11) {
        let i_v13: i32 = s_v11.borrow().l0;
        let x_v14: Rc<str> = r_v8.borrow()[i_v13 as usize].clone();
        let k_v15: Rc<str> = keys_v9.borrow()[i_v13 as usize].clone();
        let mut s_v16: Rc<RefCell<Mut3>> = Rc::new(RefCell::new(Mut3 { l0: i_v13 }));
        while method47(&keys_v9, k_v15.clone(), &s_v16) {
            let j_v18: i32 = s_v16.borrow().l0;
            let backend_v19: i32 = j_v18.wrapping_sub(1i32);
            let v20: Rc<str> = r_v8.borrow()[backend_v19 as usize].clone();
            r_v8.borrow_mut()[j_v18 as usize] = v20;
            let v21: Rc<str> = keys_v9.borrow()[backend_v19 as usize].clone();
            keys_v9.borrow_mut()[j_v18 as usize] = v21;
            s_v16.borrow_mut().l0 = backend_v19;
            ()
        };
        let v22: i32 = s_v16.borrow().l0;
        r_v8.borrow_mut()[v22 as usize] = x_v14;
        let v23: i32 = s_v16.borrow().l0;
        keys_v9.borrow_mut()[v23 as usize] = k_v15;
        let v24: i32 = i_v13.wrapping_add(1i32);
        s_v11.borrow_mut().l0 = v24;
        ()
    };
    let backend_v25: Rc<RefCell<Vec<Rc<str>>>> = r_v8 ;
    let backend_v26: Rc<Vec<Rc<str>>> = Rc::new((backend_v25).borrow().clone());
    let backend_v27: usize = (backend_v26).len();
    let x_v28: i32 = ((backend_v27) as i32);
    let i_v29: i32 = x_v28.wrapping_sub(1i32);
    let acc_v30: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
    method34(backend_v26, i_v29, acc_v30)
}
fn method48(mut v0: Rc<UH7>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH7::UH7_Cons(b_v2, x_v3, x_v4, x_v5, b_v6, v7) => {
            let b_v2: Rc<str> = b_v2;
            let x_v3: u32 = x_v3;
            let x_v4: u32 = x_v4;
            let x_v5: u32 = x_v5;
            let b_v6: Rc<str> = b_v6;
            let v7: Rc<UH7> = v7;
            let v8: Rc<UH0> = method48(v7, s_v1);
            let a_v11: Rc<str> = format_real_41(x_v3);
            let b_v13: Rc<str> = format_real_41(x_v4);
            let b_v16: Rc<str> = format_real_41(x_v5);
            let v20: Rc<str> = string_concat(&["requires ", &*b_v2, " ", &*a_v11, ".", &*b_v13, ".", &*b_v16, " ", &*b_v6]);
            Rc::new(UH0::UH0_Cons(v20, v8))
        }
        UH7::UH7_Nil => {
            s_v1
        }
    }
}
fn method50(mut v0: Rc<UH9>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH9::UH9_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let v3: Rc<UH9> = v3;
            let v4: Rc<UH0> = method50(v3, s_v1);
            Rc::new(UH0::UH0_Cons(v2, v4))
        }
        UH9::UH9_Nil => {
            s_v1
        }
    }
}
fn method49(mut v0: Rc<UH8>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH8::UH8_Cons(b_v2, x_v3, x_v4, x_v5, v6, v7) => {
            let b_v2: Rc<str> = b_v2;
            let x_v3: u32 = x_v3;
            let x_v4: u32 = x_v4;
            let x_v5: u32 = x_v5;
            let v6: Rc<UH9> = v6;
            let v7: Rc<UH8> = v7;
            let v8: Rc<UH0> = method49(v7, s_v1);
            let a_v11: Rc<str> = format_real_41(x_v3);
            let b_v13: Rc<str> = format_real_41(x_v4);
            let b_v16: Rc<str> = format_real_41(x_v5);
            let a_v19: Rc<str> = string_concat(&["crate ", &*b_v2, " ", &*a_v11, ".", &*b_v13, ".", &*b_v16, " "]);
            let b_v31: Rc<str> = match &*v6 {
                UH9::UH9_Nil => {
                    let v20: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("-"); } LIT.with(|lit| lit.clone()) };
                    v20
                }
                _ => {
                    let s_v21: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                    let items_v22: Rc<UH0> = method50(v6, s_v21);
                    let backend_v23: Rc<UH0> = sorted_44(items_v22);
                    let acc_v24: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
                    let s_v25: i32 = 0i32;
                    let v26: i32 = method12(acc_v24.clone(), backend_v23, s_v25);
                    let backend_v27: Rc<Vec<Rc<str>>> = Rc::new(acc_v24.borrow().clone());
                    let items_v28: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v27).as_ref().clone()));
                    let v29: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(","); } LIT.with(|lit| lit.clone()) };
                    let v30: Rc<str> = Rc::<str>::from((*items_v28.borrow()).join(&*v29));
                    v30
                }
            };
            let v32: Rc<str> = string_concat(&[&*a_v19, &*b_v31]);
            Rc::new(UH0::UH0_Cons(v32, v8))
        }
        UH8::UH8_Nil => {
            s_v1
        }
    }
}
fn method51(mut v0: Rc<UH10>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH10::UH10_Cons(v2, v3) => {
            let mut v2: US40 = v2;
            let v3: Rc<UH10> = v3;
            let v4: Rc<UH0> = method51(v3, s_v1);
            let v65: Rc<str> = match v2 {
                US40::US40_ForeignLibrary(v29, b_v30) => {
                    let v29: US17 = v29;
                    let b_v30: Rc<str> = b_v30;
                    let b_v52: Rc<str> = match v29 {
                        US17::US17_TargetC => {
                            let v31: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("c"); } LIT.with(|lit| lit.clone()) };
                            v31
                        }
                        US17::US17_TargetCuda => {
                            let v35: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("cuda"); } LIT.with(|lit| lit.clone()) };
                            v35
                        }
                        US17::US17_TargetFsharp => {
                            let v33: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("fsharp"); } LIT.with(|lit| lit.clone()) };
                            v33
                        }
                        US17::US17_TargetGleam => {
                            let v36: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gleam"); } LIT.with(|lit| lit.clone()) };
                            v36
                        }
                        US17::US17_TargetLua => {
                            let v37: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("lua"); } LIT.with(|lit| lit.clone()) };
                            v37
                        }
                        US17::US17_TargetPython => {
                            let v34: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("python"); } LIT.with(|lit| lit.clone()) };
                            v34
                        }
                        US17::US17_TargetRust => {
                            let v32: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("rust"); } LIT.with(|lit| lit.clone()) };
                            v32
                        }
                        US17::US17_TargetTypeScript => {
                            let v41: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("typescript"); } LIT.with(|lit| lit.clone()) };
                            v41
                        }
                        US17::US17_TargetWasm => {
                            let v39: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wasm"); } LIT.with(|lit| lit.clone()) };
                            v39
                        }
                        US17::US17_TargetWgsl => {
                            let v40: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("wgsl"); } LIT.with(|lit| lit.clone()) };
                            v40
                        }
                        US17::US17_TargetZig => {
                            let v38: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("zig"); } LIT.with(|lit| lit.clone()) };
                            v38
                        }
                    };
                    let v55: Rc<str> = string_concat(&["capability foreign ", &*b_v52, " ", &*b_v30]);
                    v55
                }
                US40::US40_GpuDevice => {
                    let v56: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("capability gpu"); } LIT.with(|lit| lit.clone()) };
                    v56
                }
                US40::US40_NetworkTo(h_v23) => {
                    let h_v23: Rc<str> = h_v23;
                    let v24: Rc<str> = string_concat(&["capability network ", &*h_v23]);
                    v24
                }
                US40::US40_ReadEnvironment(v_v27) => {
                    let v_v27: Rc<str> = v_v27;
                    let v28: Rc<str> = string_concat(&["capability env ", &*v_v27]);
                    v28
                }
                US40::US40_ReadFiles(s_v5) => {
                    let s_v5: US41 = s_v5;
                    let b_v12: Rc<str> = match s_v5 {
                        US41::US41_CallerWorkspace => {
                            let v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("caller"); } LIT.with(|lit| lit.clone()) };
                            v7
                        }
                        US41::US41_OwnPackageDirectory => {
                            let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("own"); } LIT.with(|lit| lit.clone()) };
                            v6
                        }
                        US41::US41_UnderRelativePath(p_v8) => {
                            let p_v8: Rc<str> = p_v8;
                            let v9: Rc<str> = string_concat(&["path ", &*p_v8]);
                            v9
                        }
                    };
                    let v13: Rc<str> = string_concat(&["capability read-files ", &*b_v12]);
                    v13
                }
                US40::US40_SpawnProcess(p_v25) => {
                    let p_v25: Rc<str> = p_v25;
                    let v26: Rc<str> = string_concat(&["capability spawn ", &*p_v25]);
                    v26
                }
                US40::US40_WallClock => {
                    let v57: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("capability clock"); } LIT.with(|lit| lit.clone()) };
                    v57
                }
                US40::US40_WriteFiles(s_v14) => {
                    let s_v14: US41 = s_v14;
                    let b_v21: Rc<str> = match s_v14 {
                        US41::US41_CallerWorkspace => {
                            let v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("caller"); } LIT.with(|lit| lit.clone()) };
                            v16
                        }
                        US41::US41_OwnPackageDirectory => {
                            let v15: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("own"); } LIT.with(|lit| lit.clone()) };
                            v15
                        }
                        US41::US41_UnderRelativePath(p_v17) => {
                            let p_v17: Rc<str> = p_v17;
                            let mut v18: Rc<str> = string_concat(&["path ", &*p_v17]);
                            v18
                        }
                    };
                    let v22: Rc<str> = string_concat(&["capability write-files ", &*b_v21]);
                    v22
                }
            };
            Rc::new(UH0::UH0_Cons(v65, v4))
        }
        UH10::UH10_Nil => {
            s_v1
        }
    }
}
fn format_real_53(mut x_v0: u64) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let result_v2: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v1 }));
    let s_v3: Rc<str> = Rc::<str>::from(format!("{}", x_v0));
    method42(&result_v2, s_v3);
    let v4: Rc<str> = result_v2.borrow().l0.clone();
    v4
}
fn method52(mut v0: Rc<UH11>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH11::UH11_Cons(b_v2, b_v3, x_v4, v5) => {
            let b_v2: Rc<str> = b_v2;
            let b_v3: Rc<str> = b_v3;
            let x_v4: u64 = x_v4;
            let v5: Rc<UH11> = v5;
            let v6: Rc<UH0> = method52(v5, s_v1);
            let b_v11: Rc<str> = format_real_53(x_v4);
            let v12: Rc<str> = string_concat(&["module ", &*b_v2, " ", &*b_v3, " ", &*b_v11]);
            Rc::new(UH0::UH0_Cons(v12, v6))
        }
        UH11::UH11_Nil => {
            s_v1
        }
    }
}
fn method54(mut v0: Rc<UH0>, mut s_v1: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v0) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let v3: Rc<UH0> = v3;
            let v4: Rc<UH0> = method54(v3, s_v1);
            Rc::new(UH0::UH0_Cons(v2, v4))
        }
        UH0::UH0_Nil => {
            s_v1
        }
    }
}
fn method55(mut v0: Rc<str>, mut v1: Rc<UH12>, mut s_v2: Rc<UH0>) -> Rc<UH0> {
    match Rc::unwrap_or_clone(v1) {
        UH12::UH12_Cons(v3, backend_v4, v5) => {
            let v3: Rc<str> = v3;
            let backend_v4: Rc<str> = backend_v4;
            let v5: Rc<UH12> = v5;
            let v6: Rc<UH0> = method55(v0.clone(), v5, s_v2);
            let path_v9: Rc<str> = string_concat(&[&*v0, "/", &*v3, ".spi"]);
            std::fs::write(&*path_v9, &*backend_v4).unwrap();
            Rc::new(UH0::UH0_Cons(path_v9, v6))
        }
        UH12::UH12_Nil => {
            s_v2
        }
    }
}
fn format_real_56(mut x_v0: i32) -> Rc<str> {
    let mut v1: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
    let result_v2: Rc<RefCell<Mut1>> = Rc::new(RefCell::new(Mut1 { l0: v1 }));
    let s_v3: Rc<str> = Rc::<str>::from(format!("{}", x_v0));
    method42(&result_v2, s_v3);
    let v4: Rc<str> = result_v2.borrow().l0.clone();
    v4
}
fn published_3(mut dir_v0: Rc<str>, mut v1: Rc<str>) -> i32 {
    let manifest_v2: Rc<str> = string_concat(&[&*dir_v0, "/spiral.toml"]);
    let v3: bool = file_exists_4(manifest_v2.clone());
    let v642: US2 = if v3 {
        let v5: Result<Vec<u8>, std::io::Error> = std::fs::read(&*manifest_v2);
        let v7: Vec<u8> = v5.unwrap();
        let bytes_v8: Vec<u8> = method5(v7);
        let v10: Result<std::string::String, std::string::FromUtf8Error> = std::string::String::from_utf8(bytes_v8);
        let backend_v12: std::string::String = v10.unwrap();
        let s_v14: Rc<str> = Rc::<str>::from(String::as_str(&backend_v12));
        let n_v15: i32 = 1i32;
        let separator_v16: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("\n"); } LIT.with(|lit| lit.clone()) };
        let lines_v17: Rc<UH0> = split_list_6(separator_v16.clone(), s_v14);
        let acc_v18: Rc<UH1> = { thread_local!{ static CASE: Rc<UH1> = Rc::new(UH1::UH1_Nil); } CASE.with(|case| case.clone()) };
        let mut v19: US8 = entries_9(n_v15, lines_v17, acc_v18);
        let v361: US13 = match v19 {
            US8::US8_Error(e_v20) => {
                let e_v20: US5 = e_v20;
                let v21: US4 = US4::US4_TomlRefused(e_v20);
                US13::US13_Rejected(v21)
            }
            US8::US8_Ok(es_v23) => {
                let es_v23: Rc<UH1> = es_v23;
                let key_v24: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("name"); } LIT.with(|lit| lit.clone()) };
                let v25: US12 = lookup_15(key_v24.clone(), es_v23.clone());
                let v32: US0 = match v25 {
                    US12::US12_Some(v26) => {
                        let v26: US7 = v26;
                        match v26 {
                            US7::US7_TomlText(t_v27) => {
                                let t_v27: Rc<str> = t_v27;
                                US0::US0_Some(t_v27)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v47: US18 = match v32 {
                    US0::US0_None => {
                        let v33: US4 = US4::US4_MissingKey(key_v24);
                        US18::US18_Rejected(v33)
                    }
                    US0::US0_Some(text_v35) => {
                        let text_v35: Rc<str> = text_v35;
                        let v36: bool = &*text_v35 == "";
                        let v39: US19 = if v36 {
                            US19::US19_None
                        } else {
                            US19::US19_Some(text_v35.clone())
                        };
                        match v39 {
                            US19::US19_None => {
                                let v42: US4 = US4::US4_BadValue(key_v24, text_v35);
                                US18::US18_Rejected(v42)
                            }
                            US19::US19_Some(x_v40) => {
                                let x_v40: Rc<str> = x_v40;
                                US18::US18_Accepted(x_v40)
                            }
                        }
                    }
                };
                let key_v48: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("version"); } LIT.with(|lit| lit.clone()) };
                let mut v49: US12 = lookup_15(key_v48.clone(), es_v23.clone());
                let v56: US0 = match v49 {
                    US12::US12_Some(v50) => {
                        let v50: US7 = v50;
                        match v50 {
                            US7::US7_TomlText(t_v51) => {
                                let t_v51: Rc<str> = t_v51;
                                US0::US0_Some(t_v51)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v117: US20 = match v56 {
                    US0::US0_None => {
                        let v57: US4 = US4::US4_MissingKey(key_v48);
                        US20::US20_Rejected(v57)
                    }
                    US0::US0_Some(text_v59) => {
                        let text_v59: Rc<str> = text_v59;
                        let separator_v60: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("."); } LIT.with(|lit| lit.clone()) };
                        let v61: Rc<UH0> = split_list_6(separator_v60, text_v59.clone());
                        let v107: US21 = match Rc::unwrap_or_clone(v61) {
                            UH0::UH0_Cons(backend_v62, v63) => {
                                let backend_v62: Rc<str> = backend_v62;
                                let v63: Rc<UH0> = v63;
                                match Rc::unwrap_or_clone(v63) {
                                    UH0::UH0_Cons(backend_v64, v65) => {
                                        let backend_v64: Rc<str> = backend_v64;
                                        let v65: Rc<UH0> = v65;
                                        match Rc::unwrap_or_clone(v65) {
                                            UH0::UH0_Cons(backend_v66, v67) => {
                                                let backend_v66: Rc<str> = backend_v66;
                                                let v67: Rc<UH0> = v67;
                                                match Rc::unwrap_or_clone(v67) {
                                                    UH0::UH0_Nil => {
                                                        let backend_v68: Option<u32> = (backend_v62).trim().parse::<u32>().ok();
                                                        let x_v69: Option<u32> = method16(backend_v68);
                                                        let mut v70: Rc<dyn Fn((u32)) -> US22> = closure1();
                                                        let mut backend_v71: Option<US22> = x_v69.map(|x| v70(x));
                                                        let v73: US22 = US22::US22_None;
                                                        let value_v74: US22 = v73.clone();
                                                        let v75: US22 = backend_v71.unwrap_or(value_v74);
                                                        let backend_v76: Option<u32> = (backend_v64).trim().parse::<u32>().ok();
                                                        let x_v77: Option<u32> = method16(backend_v76);
                                                        let mut backend_v78: Option<US22> = x_v77.map(|x| v70(x));
                                                        let v80: US22 = US22::US22_None;
                                                        let value_v81: US22 = v80.clone();
                                                        let v82: US22 = backend_v78.unwrap_or(value_v81);
                                                        let backend_v83: Option<u32> = (backend_v66).trim().parse::<u32>().ok();
                                                        let x_v84: Option<u32> = method16(backend_v83);
                                                        let mut backend_v85: Option<US22> = x_v84.map(|x| v70(x));
                                                        let v87: US22 = US22::US22_None;
                                                        let value_v88: US22 = v87.clone();
                                                        let v89: US22 = backend_v85.unwrap_or(value_v88);
                                                        match v75 {
                                                            US22::US22_Some(x_v90) => {
                                                                let x_v90: u32 = x_v90;
                                                                match v82 {
                                                                    US22::US22_Some(y_v91) => {
                                                                        let y_v91: u32 = y_v91;
                                                                        match v89 {
                                                                            US22::US22_Some(z_v92) => {
                                                                                let z_v92: u32 = z_v92;
                                                                                US21::US21_Some(x_v90, y_v91, z_v92)
                                                                            }
                                                                            _ => {
                                                                                US21::US21_None
                                                                            }
                                                                        }
                                                                    }
                                                                    _ => {
                                                                        US21::US21_None
                                                                    }
                                                                }
                                                            }
                                                            _ => {
                                                                US21::US21_None
                                                            }
                                                        }
                                                    }
                                                    _ => {
                                                        US21::US21_None
                                                    }
                                                }
                                            }
                                            _ => {
                                                US21::US21_None
                                            }
                                        }
                                    }
                                    _ => {
                                        US21::US21_None
                                    }
                                }
                            }
                            _ => {
                                US21::US21_None
                            }
                        };
                        match v107 {
                            US21::US21_None => {
                                let v112: US4 = US4::US4_BadValue(key_v48, text_v59);
                                US20::US20_Rejected(v112)
                            }
                            US21::US21_Some(x_v108, x_v109, x_v110) => {
                                let x_v108: u32 = x_v108;
                                let x_v109: u32 = x_v109;
                                let x_v110: u32 = x_v110;
                                US20::US20_Accepted(x_v108, x_v109, x_v110)
                            }
                        }
                    }
                };
                let key_v118: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("author"); } LIT.with(|lit| lit.clone()) };
                let v119: US12 = lookup_15(key_v118.clone(), es_v23.clone());
                let v126: US0 = match v119 {
                    US12::US12_Some(v120) => {
                        let v120: US7 = v120;
                        match v120 {
                            US7::US7_TomlText(t_v121) => {
                                let t_v121: Rc<str> = t_v121;
                                US0::US0_Some(t_v121)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v150: US23 = match v126 {
                    US0::US0_None => {
                        let v127: US4 = US4::US4_MissingKey(key_v118);
                        US23::US23_Rejected(v127)
                    }
                    US0::US0_Some(text_v129) => {
                        let text_v129: Rc<str> = text_v129;
                        let backend_v130: Option<u64> = (text_v129).trim().parse::<u64>().ok();
                        let x_v131: Option<u64> = method17(backend_v130);
                        let mut v132: Rc<dyn Fn((u64)) -> US24> = closure2();
                        let mut backend_v133: Option<US24> = x_v131.map(|x| v132(x));
                        let v135: US24 = US24::US24_None;
                        let value_v136: US24 = v135.clone();
                        let v137: US24 = backend_v133.unwrap_or(value_v136);
                        let v142: US25 = match v137 {
                            US24::US24_None => {
                                US25::US25_None
                            }
                            US24::US24_Some(a_v138) => {
                                let a_v138: u64 = a_v138;
                                US25::US25_Some(a_v138)
                            }
                        };
                        match v142 {
                            US25::US25_None => {
                                let v145: US4 = US4::US4_BadValue(key_v118, text_v129);
                                US23::US23_Rejected(v145)
                            }
                            US25::US25_Some(x_v143) => {
                                let x_v143: u64 = x_v143;
                                US23::US23_Accepted(x_v143)
                            }
                        }
                    }
                };
                let v168: US26 = match v47 {
                    US18::US18_Accepted(n_v151) => {
                        let n_v151: Rc<str> = n_v151;
                        match v117 {
                            US20::US20_Accepted(v_v152, v_v153, v_v154) => {
                                let v_v152: u32 = v_v152;
                                let v_v153: u32 = v_v153;
                                let v_v154: u32 = v_v154;
                                match v150 {
                                    US23::US23_Accepted(a_v155) => {
                                        let a_v155: u64 = a_v155;
                                        US26::US26_Accepted(n_v151, v_v152, v_v153, v_v154, a_v155)
                                    }
                                    US23::US23_Rejected(x_v157) => {
                                        let x_v157: US4 = x_v157;
                                        US26::US26_Rejected(x_v157)
                                    }
                                }
                            }
                            US20::US20_Rejected(x_v161) => {
                                let x_v161: US4 = x_v161;
                                US26::US26_Rejected(x_v161)
                            }
                        }
                    }
                    US18::US18_Rejected(x_v165) => {
                        let x_v165: US4 = x_v165;
                        US26::US26_Rejected(x_v165)
                    }
                };
                let key_v169: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("edition"); } LIT.with(|lit| lit.clone()) };
                let v170: US12 = lookup_15(key_v169.clone(), es_v23.clone());
                let v177: US0 = match v170 {
                    US12::US12_Some(v171) => {
                        let v171: US7 = v171;
                        match v171 {
                            US7::US7_TomlText(t_v172) => {
                                let t_v172: Rc<str> = t_v172;
                                US0::US0_Some(t_v172)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v195: US27 = match v177 {
                    US0::US0_None => {
                        let v178: US4 = US4::US4_MissingKey(key_v169);
                        US27::US27_Rejected(v178)
                    }
                    US0::US0_Some(text_v180) => {
                        let text_v180: Rc<str> = text_v180;
                        let show_v181: Rc<dyn Fn(US14) -> Rc<str>> = closure3();
                        let v182: US14 = US14::US14_UpstreamEdition2;
                        let v183: US14 = US14::US14_ForkEdition3;
                        let v184: Rc<UH3> = { thread_local!{ static CASE: Rc<UH3> = Rc::new(UH3::UH3_Nil); } CASE.with(|case| case.clone()) };
                        let v185: Rc<UH3> = Rc::new(UH3::UH3_Cons(v183, v184));
                        let cases_v186: Rc<UH3> = Rc::new(UH3::UH3_Cons(v182, v185));
                        let v187: US28 = printed_as_18(show_v181, text_v180.clone(), cases_v186);
                        match v187 {
                            US28::US28_None => {
                                let v190: US4 = US4::US4_BadValue(key_v169, text_v180);
                                US27::US27_Rejected(v190)
                            }
                            US28::US28_Some(x_v188) => {
                                let x_v188: US14 = x_v188;
                                US27::US27_Accepted(x_v188)
                            }
                        }
                    }
                };
                let key_v196: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("int"); } LIT.with(|lit| lit.clone()) };
                let v197: US12 = lookup_15(key_v196.clone(), es_v23.clone());
                let v204: US0 = match v197 {
                    US12::US12_Some(v198) => {
                        let v198: US7 = v198;
                        match v198 {
                            US7::US7_TomlText(t_v199) => {
                                let t_v199: Rc<str> = t_v199;
                                US0::US0_Some(t_v199)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v234: US29 = match v204 {
                    US0::US0_None => {
                        let v205: US4 = US4::US4_MissingKey(key_v196);
                        US29::US29_Rejected(v205)
                    }
                    US0::US0_Some(text_v207) => {
                        let text_v207: Rc<str> = text_v207;
                        let show_v208: Rc<dyn Fn(US15) -> Rc<str>> = closure4();
                        let v209: US15 = US15::US15_DefaultI8;
                        let v210: US15 = US15::US15_DefaultI16;
                        let v211: US15 = US15::US15_DefaultI32;
                        let v212: US15 = US15::US15_DefaultI64;
                        let v213: US15 = US15::US15_DefaultU8;
                        let v214: US15 = US15::US15_DefaultU16;
                        let v215: US15 = US15::US15_DefaultU32;
                        let v216: US15 = US15::US15_DefaultU64;
                        let v217: Rc<UH4> = { thread_local!{ static CASE: Rc<UH4> = Rc::new(UH4::UH4_Nil); } CASE.with(|case| case.clone()) };
                        let v218: Rc<UH4> = Rc::new(UH4::UH4_Cons(v216, v217));
                        let v219: Rc<UH4> = Rc::new(UH4::UH4_Cons(v215, v218));
                        let v220: Rc<UH4> = Rc::new(UH4::UH4_Cons(v214, v219));
                        let v221: Rc<UH4> = Rc::new(UH4::UH4_Cons(v213, v220));
                        let v222: Rc<UH4> = Rc::new(UH4::UH4_Cons(v212, v221));
                        let v223: Rc<UH4> = Rc::new(UH4::UH4_Cons(v211, v222));
                        let v224: Rc<UH4> = Rc::new(UH4::UH4_Cons(v210, v223));
                        let cases_v225: Rc<UH4> = Rc::new(UH4::UH4_Cons(v209, v224));
                        let v226: US30 = printed_as_19(show_v208, text_v207.clone(), cases_v225);
                        match v226 {
                            US30::US30_None => {
                                let v229: US4 = US4::US4_BadValue(key_v196, text_v207);
                                US29::US29_Rejected(v229)
                            }
                            US30::US30_Some(x_v227) => {
                                let x_v227: US15 = x_v227;
                                US29::US29_Accepted(x_v227)
                            }
                        }
                    }
                };
                let key_v235: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("float"); } LIT.with(|lit| lit.clone()) };
                let v236: US12 = lookup_15(key_v235.clone(), es_v23.clone());
                let v243: US0 = match v236 {
                    US12::US12_Some(v237) => {
                        let v237: US7 = v237;
                        match v237 {
                            US7::US7_TomlText(t_v238) => {
                                let t_v238: Rc<str> = t_v238;
                                US0::US0_Some(t_v238)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v261: US31 = match v243 {
                    US0::US0_None => {
                        let v244: US4 = US4::US4_MissingKey(key_v235);
                        US31::US31_Rejected(v244)
                    }
                    US0::US0_Some(text_v246) => {
                        let text_v246: Rc<str> = text_v246;
                        let show_v247: Rc<dyn Fn(US16) -> Rc<str>> = closure5();
                        let v248: US16 = US16::US16_DefaultF32;
                        let v249: US16 = US16::US16_DefaultF64;
                        let v250: Rc<UH5> = { thread_local!{ static CASE: Rc<UH5> = Rc::new(UH5::UH5_Nil); } CASE.with(|case| case.clone()) };
                        let v251: Rc<UH5> = Rc::new(UH5::UH5_Cons(v249, v250));
                        let cases_v252: Rc<UH5> = Rc::new(UH5::UH5_Cons(v248, v251));
                        let v253: US32 = printed_as_20(show_v247, text_v246.clone(), cases_v252);
                        match v253 {
                            US32::US32_None => {
                                let v256: US4 = US4::US4_BadValue(key_v235, text_v246);
                                US31::US31_Rejected(v256)
                            }
                            US32::US32_Some(x_v254) => {
                                let x_v254: US16 = x_v254;
                                US31::US31_Accepted(x_v254)
                            }
                        }
                    }
                };
                let key_v262: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("targets"); } LIT.with(|lit| lit.clone()) };
                let v263: US12 = lookup_15(key_v262.clone(), es_v23.clone());
                let v270: US10 = match v263 {
                    US12::US12_Some(v264) => {
                        let v264: US7 = v264;
                        match v264 {
                            US7::US7_TomlList(l_v265) => {
                                let l_v265: Rc<UH0> = l_v265;
                                US10::US10_Some(l_v265)
                            }
                            _ => {
                                US10::US10_None
                            }
                        }
                    }
                    _ => {
                        US10::US10_None
                    }
                };
                let v295: US33 = match v270 {
                    US10::US10_None => {
                        let v271: US4 = US4::US4_MissingKey(key_v262);
                        US33::US33_Rejected(v271)
                    }
                    US10::US10_Some(texts_v273) => {
                        let texts_v273: Rc<UH0> = texts_v273;
                        match &*texts_v273 {
                            UH0::UH0_Nil => {
                                let v274: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("[]"); } LIT.with(|lit| lit.clone()) };
                                let v275: US4 = US4::US4_BadValue(key_v262, v274);
                                US33::US33_Rejected(v275)
                            }
                            _ => {
                                let read_v277: Rc<dyn Fn(Rc<str>) -> US34> = closure6();
                                let acc_v278: Rc<UH2> = { thread_local!{ static CASE: Rc<UH2> = Rc::new(UH2::UH2_Nil); } CASE.with(|case| case.clone()) };
                                let v279: US35 = all_read_22(read_v277, texts_v273.clone(), acc_v278);
                                match v279 {
                                    US35::US35_None => {
                                        let acc_v282: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
                                        let s_v283: i32 = 0i32;
                                        let v284: i32 = method12(acc_v282.clone(), texts_v273, s_v283);
                                        let backend_v285: Rc<Vec<Rc<str>>> = Rc::new(acc_v282.borrow().clone());
                                        let items_v286: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v285).as_ref().clone()));
                                        let v287: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(","); } LIT.with(|lit| lit.clone()) };
                                        let v288: Rc<str> = Rc::<str>::from((*items_v286.borrow()).join(&*v287));
                                        let v289: US4 = US4::US4_BadValue(key_v262, v288);
                                        US33::US33_Rejected(v289)
                                    }
                                    US35::US35_Some(ts_v280) => {
                                        let ts_v280: Rc<UH2> = ts_v280;
                                        US33::US33_Accepted(ts_v280)
                                    }
                                }
                            }
                        }
                    }
                };
                let v316: US36 = match v195 {
                    US27::US27_Accepted(e_v296) => {
                        let e_v296: US14 = e_v296;
                        match v234 {
                            US29::US29_Accepted(i_v297) => {
                                let i_v297: US15 = i_v297;
                                match v261 {
                                    US31::US31_Accepted(f_v298) => {
                                        let f_v298: US16 = f_v298;
                                        match v295 {
                                            US33::US33_Accepted(ts_v299) => {
                                                let ts_v299: Rc<UH2> = ts_v299;
                                                US36::US36_Accepted(e_v296, i_v297, f_v298, ts_v299)
                                            }
                                            US33::US33_Rejected(x_v301) => {
                                                let x_v301: US4 = x_v301;
                                                US36::US36_Rejected(x_v301)
                                            }
                                        }
                                    }
                                    US31::US31_Rejected(x_v305) => {
                                        let x_v305: US4 = x_v305;
                                        US36::US36_Rejected(x_v305)
                                    }
                                }
                            }
                            US29::US29_Rejected(x_v309) => {
                                let x_v309: US4 = x_v309;
                                US36::US36_Rejected(x_v309)
                            }
                        }
                    }
                    US27::US27_Rejected(x_v313) => {
                        let x_v313: US4 = x_v313;
                        US36::US36_Rejected(x_v313)
                    }
                };
                let key_v317: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("modules"); } LIT.with(|lit| lit.clone()) };
                let v318: US12 = lookup_15(key_v317.clone(), es_v23);
                let v325: US0 = match v318 {
                    US12::US12_Some(v319) => {
                        let v319: US7 = v319;
                        match v319 {
                            US7::US7_TomlText(t_v320) => {
                                let t_v320: Rc<str> = t_v320;
                                US0::US0_Some(t_v320)
                            }
                            _ => {
                                US0::US0_None
                            }
                        }
                    }
                    _ => {
                        US0::US0_None
                    }
                };
                let v336: US37 = match v325 {
                    US0::US0_None => {
                        let v326: US4 = US4::US4_MissingKey(key_v317);
                        US37::US37_Rejected(v326)
                    }
                    US0::US0_Some(block_v328) => {
                        let block_v328: Rc<str> = block_v328;
                        let v329: Rc<UH0> = split_list_6(separator_v16.clone(), block_v328);
                        let s_v330: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                        let v331: Rc<UH0> = method24(v329, s_v330);
                        let s_v332: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                        let v333: Rc<UH0> = method25(v331, s_v332);
                        US37::US37_Accepted(v333)
                    }
                };
                match v168 {
                    US26::US26_Accepted(i_v337, i_v338, i_v339, i_v340, i_v341) => {
                        let i_v337: Rc<str> = i_v337;
                        let i_v338: u32 = i_v338;
                        let i_v339: u32 = i_v339;
                        let i_v340: u32 = i_v340;
                        let i_v341: u64 = i_v341;
                        match v316 {
                            US36::US36_Accepted(b_v342, b_v343, b_v344, b_v345) => {
                                let b_v342: US14 = b_v342;
                                let b_v343: US15 = b_v343;
                                let b_v344: US16 = b_v344;
                                let b_v345: Rc<UH2> = b_v345;
                                match v336 {
                                    US37::US37_Accepted(ms_v346) => {
                                        let ms_v346: Rc<UH0> = ms_v346;
                                        US13::US13_Accepted(i_v337, i_v338, i_v339, i_v340, i_v341, b_v342, b_v343, b_v344, b_v345, ms_v346)
                                    }
                                    US37::US37_Rejected(x_v348) => {
                                        let x_v348: US4 = x_v348;
                                        US13::US13_Rejected(x_v348)
                                    }
                                }
                            }
                            US36::US36_Rejected(x_v352) => {
                                let x_v352: US4 = x_v352;
                                US13::US13_Rejected(x_v352)
                            }
                        }
                    }
                    US26::US26_Rejected(x_v356) => {
                        let x_v356: US4 = x_v356;
                        US13::US13_Rejected(x_v356)
                    }
                }
            }
        };
        match v361 {
            US13::US13_Accepted(input_v365, input_v366, input_v367, input_v368, input_v369, input_v370, input_v371, input_v372, input_v373, input_v374) => {
                let input_v365: Rc<str> = input_v365;
                let input_v366: u32 = input_v366;
                let input_v367: u32 = input_v367;
                let input_v368: u32 = input_v368;
                let input_v369: u64 = input_v369;
                let input_v370: US14 = input_v370;
                let input_v371: US15 = input_v371;
                let input_v372: US16 = input_v372;
                let input_v373: Rc<UH2> = input_v373;
                let input_v374: Rc<UH0> = input_v374;
                let acc_v375: Rc<UH6> = { thread_local!{ static CASE: Rc<UH6> = Rc::new(UH6::UH6_Nil); } CASE.with(|case| case.clone()) };
                let v376: US38 = read_modules_26(dir_v0, input_v374, acc_v375);
                match v376 {
                    US38::US38_Accepted(files_v379) => {
                        let files_v379: Rc<UH6> = files_v379;
                        let v380: US0 = first_crlf_28(files_v379.clone());
                        let seen_v381: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                        let v382: US0 = first_duplicate_29(seen_v381, files_v379.clone());
                        let v413: US39 = match &*files_v379 {
                            UH6::UH6_Nil => {
                                let v383: US6 = US6::US6_NoModules;
                                US39::US39_Rejected(v383)
                            }
                            _ => {
                                match v380 {
                                    US0::US0_None => {
                                        match v382 {
                                            US0::US0_None => {
                                                let v402: US42 = match &*files_v379 {
                                                    UH6::UH6_Cons(v391, input_v392, v393) => {
                                                        let v391: Rc<str> = v391.clone();
                                                        let input_v392: Rc<str> = input_v392.clone();
                                                        let v393: Rc<UH6> = v393.clone();
                                                        match Rc::unwrap_or_clone(v393) {
                                                            UH6::UH6_Nil => {
                                                                let v394: Rc<str> = hash_text_32(input_v392.clone());
                                                                let v395: i32 = (input_v392.len() as i32);
                                                                let v396: u64 = (v395 as u64);
                                                                US42::US42_SingleModule(v391, v394, v396)
                                                            }
                                                            _ => {
                                                                let s_v398: Rc<UH11> = { thread_local!{ static CASE: Rc<UH11> = Rc::new(UH11::UH11_Nil); } CASE.with(|case| case.clone()) };
                                                                let v399: Rc<UH11> = method36(files_v379.clone(), s_v398);
                                                                US42::US42_ModuleDirectory(v399)
                                                            }
                                                        }
                                                    }
                                                    _ => unreachable!(),
                                                };
                                                let s_v403: Rc<UH12> = { thread_local!{ static CASE: Rc<UH12> = Rc::new(UH12::UH12_Nil); } CASE.with(|case| case.clone()) };
                                                let v404: Rc<UH12> = method37(files_v379, s_v403);
                                                let v405: Rc<UH7> = { thread_local!{ static CASE: Rc<UH7> = Rc::new(UH7::UH7_Nil); } CASE.with(|case| case.clone()) };
                                                let v406: Rc<UH8> = { thread_local!{ static CASE: Rc<UH8> = Rc::new(UH8::UH8_Nil); } CASE.with(|case| case.clone()) };
                                                let v407: Rc<UH10> = { thread_local!{ static CASE: Rc<UH10> = Rc::new(UH10::UH10_Nil); } CASE.with(|case| case.clone()) };
                                                US39::US39_Accepted(input_v365, input_v366, input_v367, input_v368, input_v369, input_v370, input_v371, input_v372, input_v373, v405, v406, v407, v402, v404)
                                            }
                                            US0::US0_Some(path_v388) => {
                                                let path_v388: Rc<str> = path_v388;
                                                let v389: US6 = US6::US6_DuplicateModulePath(path_v388);
                                                US39::US39_Rejected(v389)
                                            }
                                        }
                                    }
                                    US0::US0_Some(path_v385) => {
                                        let path_v385: Rc<str> = path_v385;
                                        let v386: US6 = US6::US6_CrlfInModule(path_v385);
                                        US39::US39_Rejected(v386)
                                    }
                                }
                            }
                        };
                        match v413 {
                            US39::US39_Accepted(p_v417, p_v418, p_v419, p_v420, p_v421, p_v422, p_v423, p_v424, p_v425, p_v426, p_v427, p_v428, p_v429, p_v430) => {
                                let p_v417: Rc<str> = p_v417;
                                let p_v418: u32 = p_v418;
                                let p_v419: u32 = p_v419;
                                let p_v420: u32 = p_v420;
                                let p_v421: u64 = p_v421;
                                let p_v422: US14 = p_v422;
                                let p_v423: US15 = p_v423;
                                let p_v424: US16 = p_v424;
                                let p_v425: Rc<UH2> = p_v425;
                                let p_v426: Rc<UH7> = p_v426;
                                let p_v427: Rc<UH8> = p_v427;
                                let p_v428: Rc<UH10> = p_v428;
                                let p_v429: US42 = p_v429;
                                let p_v430: Rc<UH12> = p_v430;
                                let blobs_v431: Rc<str> = string_concat(&[&*v1, "/blobs"]);
                                let index_v432: Rc<str> = string_concat(&[&*v1, "/index"]);
                                let mut v434: Result<(), std::io::Error> = std::fs::create_dir_all(&*blobs_v431);
                                let mut fn_v435: Rc<dyn Fn(std::io::Error) -> Rc<str>> = method38();
                                let backend_v437: Result<(), Rc<str>> = v434.map_err(|x| fn_v435(x));
                                let mut ok_v438: Rc<dyn Fn() -> US43> = method39();
                                let mut error_v439: Rc<dyn Fn(Rc<str>) -> US43> = method40();
                                let v440: US43 = match backend_v437 { Ok(()) => ok_v438(), Err(e) => error_v439(e) };
                                let mut v442: Result<(), std::io::Error> = std::fs::create_dir_all(&*index_v432);
                                let mut fn_v443: Rc<dyn Fn(std::io::Error) -> Rc<str>> = method38();
                                let backend_v445: Result<(), Rc<str>> = v442.map_err(|x| fn_v443(x));
                                let mut ok_v446: Rc<dyn Fn() -> US43> = method39();
                                let mut error_v447: Rc<dyn Fn(Rc<str>) -> US43> = method40();
                                let v448: US43 = match backend_v445 { Ok(()) => ok_v446(), Err(e) => error_v447(e) };
                                let a_v450: Rc<str> = format_real_41(p_v418);
                                let b_v452: Rc<str> = format_real_41(p_v419);
                                let b_v455: Rc<str> = format_real_41(p_v420);
                                let a_v458: Rc<str> = string_concat(&[&*p_v417, " ", &*a_v450, ".", &*b_v452, ".", &*b_v455, " "]);
                                let s_v459: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v460: Rc<UH0> = method43(p_v425.clone(), s_v459);
                                let targets_v461: Rc<UH0> = sorted_44(items_v460);
                                let s_v462: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v463: Rc<UH0> = method48(p_v426.clone(), s_v462);
                                let requires_v464: Rc<UH0> = sorted_44(items_v463);
                                let s_v465: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v466: Rc<UH0> = method49(p_v427.clone(), s_v465);
                                let crates_v467: Rc<UH0> = sorted_44(items_v466);
                                let s_v468: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v469: Rc<UH0> = method51(p_v428.clone(), s_v468);
                                let capabilities_v470: Rc<UH0> = sorted_44(items_v469);
                                let s_v491: Rc<UH0> = match &p_v429 {
                                    US42::US42_ModuleDirectory(ms_v484) => {
                                        let ms_v484: Rc<UH11> = ms_v484.clone();
                                        let s_v485: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                        let items_v486: Rc<UH0> = method52(ms_v484, s_v485);
                                        let v487: Rc<UH0> = sorted_44(items_v486);
                                        let v488: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("layout directory"); } LIT.with(|lit| lit.clone()) };
                                        Rc::new(UH0::UH0_Cons(v488, v487))
                                    }
                                    US42::US42_SingleModule(m_v471, m_v472, m_v473) => {
                                        let m_v471: Rc<str> = m_v471.clone();
                                        let m_v472: Rc<str> = m_v472.clone();
                                        let m_v473: u64 = *m_v473;
                                        let b_v478: Rc<str> = format_real_53(m_v473);
                                        let v479: Rc<str> = string_concat(&["module ", &*m_v471, " ", &*m_v472, " ", &*b_v478]);
                                        let v480: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("layout single"); } LIT.with(|lit| lit.clone()) };
                                        let v481: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                        let v482: Rc<UH0> = Rc::new(UH0::UH0_Cons(v479, v481));
                                        Rc::new(UH0::UH0_Cons(v480, v482))
                                    }
                                };
                                let s_v492: Rc<UH0> = method54(capabilities_v470, s_v491);
                                let tail_v493: Rc<UH0> = method54(crates_v467, s_v492);
                                let backend_v494: Rc<str> = string_concat(&["name ", &*p_v417]);
                                let a_v495: Rc<str> = format_real_41(p_v418);
                                let b_v497: Rc<str> = format_real_41(p_v419);
                                let b_v500: Rc<str> = format_real_41(p_v420);
                                let backend_v502: Rc<str> = string_concat(&["version ", &*a_v495, ".", &*b_v497, ".", &*b_v500]);
                                let b_v503: Rc<str> = format_real_53(p_v421);
                                let backend_v504: Rc<str> = string_concat(&["author ", &*b_v503]);
                                let b_v508: Rc<str> = match &p_v422 {
                                    US14::US14_ForkEdition3 => {
                                        let v506: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("3"); } LIT.with(|lit| lit.clone()) };
                                        v506
                                    }
                                    US14::US14_UpstreamEdition2 => {
                                        let v505: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("2"); } LIT.with(|lit| lit.clone()) };
                                        v505
                                    }
                                };
                                let backend_v509: Rc<str> = string_concat(&["edition ", &*b_v508]);
                                let b_v525: Rc<str> = match &p_v423 {
                                    US15::US15_DefaultI16 => {
                                        let v511: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i16"); } LIT.with(|lit| lit.clone()) };
                                        v511
                                    }
                                    US15::US15_DefaultI32 => {
                                        let v512: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i32"); } LIT.with(|lit| lit.clone()) };
                                        v512
                                    }
                                    US15::US15_DefaultI64 => {
                                        let v513: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i64"); } LIT.with(|lit| lit.clone()) };
                                        v513
                                    }
                                    US15::US15_DefaultI8 => {
                                        let v510: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i8"); } LIT.with(|lit| lit.clone()) };
                                        v510
                                    }
                                    US15::US15_DefaultU16 => {
                                        let v515: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u16"); } LIT.with(|lit| lit.clone()) };
                                        v515
                                    }
                                    US15::US15_DefaultU32 => {
                                        let v516: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u32"); } LIT.with(|lit| lit.clone()) };
                                        v516
                                    }
                                    US15::US15_DefaultU64 => {
                                        let v517: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u64"); } LIT.with(|lit| lit.clone()) };
                                        v517
                                    }
                                    US15::US15_DefaultU8 => {
                                        let v514: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u8"); } LIT.with(|lit| lit.clone()) };
                                        v514
                                    }
                                };
                                let backend_v526: Rc<str> = string_concat(&["default-int ", &*b_v525]);
                                let b_v530: Rc<str> = match &p_v424 {
                                    US16::US16_DefaultF32 => {
                                        let v527: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f32"); } LIT.with(|lit| lit.clone()) };
                                        v527
                                    }
                                    US16::US16_DefaultF64 => {
                                        let v528: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f64"); } LIT.with(|lit| lit.clone()) };
                                        v528
                                    }
                                };
                                let backend_v531: Rc<str> = string_concat(&["default-float ", &*b_v530]);
                                let s_v532: Rc<UH0> = method54(requires_v464, tail_v493);
                                let backend_v533: Rc<UH0> = method54(targets_v461, s_v532);
                                let mut acc_v534: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
                                let v535: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("spiral-release 1"); } LIT.with(|lit| lit.clone()) };
                                acc_v534.borrow_mut().push(v535.clone());
                                acc_v534.borrow_mut().push(backend_v494.clone());
                                acc_v534.borrow_mut().push(backend_v502);
                                acc_v534.borrow_mut().push(backend_v504);
                                acc_v534.borrow_mut().push(backend_v509);
                                acc_v534.borrow_mut().push(backend_v526);
                                acc_v534.borrow_mut().push(backend_v531);
                                let s_v536: i32 = 7i32;
                                let v537: i32 = method12(acc_v534.clone(), backend_v533, s_v536);
                                let backend_v538: Rc<Vec<Rc<str>>> = Rc::new(acc_v534.borrow().clone());
                                let items_v539: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v538).as_ref().clone()));
                                let a_v540: Rc<str> = Rc::<str>::from((*items_v539.borrow()).join(&*separator_v16));
                                let input_v541: Rc<str> = string_concat(&[&*a_v540, "\n"]);
                                let b_v542: Rc<str> = hash_text_32(input_v541);
                                let line_v543: Rc<str> = string_concat(&[&*a_v458, &*b_v542]);
                                let s_v544: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v545: Rc<UH0> = method43(p_v425, s_v544);
                                let targets_v546: Rc<UH0> = sorted_44(items_v545);
                                let s_v547: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v548: Rc<UH0> = method48(p_v426, s_v547);
                                let requires_v549: Rc<UH0> = sorted_44(items_v548);
                                let s_v550: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v551: Rc<UH0> = method49(p_v427, s_v550);
                                let crates_v552: Rc<UH0> = sorted_44(items_v551);
                                let s_v553: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let items_v554: Rc<UH0> = method51(p_v428, s_v553);
                                let capabilities_v555: Rc<UH0> = sorted_44(items_v554);
                                let s_v576: Rc<UH0> = match p_v429 {
                                    US42::US42_ModuleDirectory(ms_v569) => {
                                        let ms_v569: Rc<UH11> = ms_v569;
                                        let s_v570: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                        let items_v571: Rc<UH0> = method52(ms_v569, s_v570);
                                        let v572: Rc<UH0> = sorted_44(items_v571);
                                        let v573: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("layout directory"); } LIT.with(|lit| lit.clone()) };
                                        Rc::new(UH0::UH0_Cons(v573, v572))
                                    }
                                    US42::US42_SingleModule(m_v556, m_v557, m_v558) => {
                                        let m_v556: Rc<str> = m_v556;
                                        let m_v557: Rc<str> = m_v557;
                                        let m_v558: u64 = m_v558;
                                        let b_v563: Rc<str> = format_real_53(m_v558);
                                        let v564: Rc<str> = string_concat(&["module ", &*m_v556, " ", &*m_v557, " ", &*b_v563]);
                                        let v565: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("layout single"); } LIT.with(|lit| lit.clone()) };
                                        let v566: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                        let v567: Rc<UH0> = Rc::new(UH0::UH0_Cons(v564, v566));
                                        Rc::new(UH0::UH0_Cons(v565, v567))
                                    }
                                };
                                let s_v577: Rc<UH0> = method54(capabilities_v555, s_v576);
                                let tail_v578: Rc<UH0> = method54(crates_v552, s_v577);
                                let a_v579: Rc<str> = format_real_41(p_v418);
                                let b_v581: Rc<str> = format_real_41(p_v419);
                                let b_v584: Rc<str> = format_real_41(p_v420);
                                let backend_v586: Rc<str> = string_concat(&["version ", &*a_v579, ".", &*b_v581, ".", &*b_v584]);
                                let b_v587: Rc<str> = format_real_53(p_v421);
                                let backend_v588: Rc<str> = string_concat(&["author ", &*b_v587]);
                                let b_v592: Rc<str> = match p_v422 {
                                    US14::US14_ForkEdition3 => {
                                        let v590: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("3"); } LIT.with(|lit| lit.clone()) };
                                        v590
                                    }
                                    US14::US14_UpstreamEdition2 => {
                                        let v589: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("2"); } LIT.with(|lit| lit.clone()) };
                                        v589
                                    }
                                };
                                let backend_v593: Rc<str> = string_concat(&["edition ", &*b_v592]);
                                let b_v609: Rc<str> = match p_v423 {
                                    US15::US15_DefaultI16 => {
                                        let v595: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i16"); } LIT.with(|lit| lit.clone()) };
                                        v595
                                    }
                                    US15::US15_DefaultI32 => {
                                        let v596: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i32"); } LIT.with(|lit| lit.clone()) };
                                        v596
                                    }
                                    US15::US15_DefaultI64 => {
                                        let v597: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i64"); } LIT.with(|lit| lit.clone()) };
                                        v597
                                    }
                                    US15::US15_DefaultI8 => {
                                        let v594: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("i8"); } LIT.with(|lit| lit.clone()) };
                                        v594
                                    }
                                    US15::US15_DefaultU16 => {
                                        let v599: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u16"); } LIT.with(|lit| lit.clone()) };
                                        v599
                                    }
                                    US15::US15_DefaultU32 => {
                                        let v600: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u32"); } LIT.with(|lit| lit.clone()) };
                                        v600
                                    }
                                    US15::US15_DefaultU64 => {
                                        let v601: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u64"); } LIT.with(|lit| lit.clone()) };
                                        v601
                                    }
                                    US15::US15_DefaultU8 => {
                                        let v598: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("u8"); } LIT.with(|lit| lit.clone()) };
                                        v598
                                    }
                                };
                                let backend_v610: Rc<str> = string_concat(&["default-int ", &*b_v609]);
                                let b_v614: Rc<str> = match p_v424 {
                                    US16::US16_DefaultF32 => {
                                        let v611: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f32"); } LIT.with(|lit| lit.clone()) };
                                        v611
                                    }
                                    US16::US16_DefaultF64 => {
                                        let v612: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("f64"); } LIT.with(|lit| lit.clone()) };
                                        v612
                                    }
                                };
                                let backend_v615: Rc<str> = string_concat(&["default-float ", &*b_v614]);
                                let s_v616: Rc<UH0> = method54(requires_v549, tail_v578);
                                let backend_v617: Rc<UH0> = method54(targets_v546, s_v616);
                                let mut acc_v618: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new(Vec::new()));
                                acc_v618.borrow_mut().push(v535);
                                acc_v618.borrow_mut().push(backend_v494);
                                acc_v618.borrow_mut().push(backend_v586);
                                acc_v618.borrow_mut().push(backend_v588);
                                acc_v618.borrow_mut().push(backend_v593);
                                acc_v618.borrow_mut().push(backend_v610);
                                acc_v618.borrow_mut().push(backend_v615);
                                let s_v619: i32 = 7i32;
                                let v620: i32 = method12(acc_v618.clone(), backend_v617, s_v619);
                                let backend_v621: Rc<Vec<Rc<str>>> = Rc::new(acc_v618.borrow().clone());
                                let items_v622: Rc<RefCell<Vec<Rc<str>>>> = Rc::new(RefCell::new((backend_v621).as_ref().clone()));
                                let a_v623: Rc<str> = Rc::<str>::from((*items_v622.borrow()).join(&*separator_v16));
                                let release_v624: Rc<str> = string_concat(&[&*a_v623, "\n"]);
                                let backend_v626: Rc<str> = string_concat(&[&*index_v432, "/", &*p_v417]);
                                let backend_v627: Rc<str> = string_concat(&[&*line_v543, "\n"]);
                                std::fs::write(&*backend_v626, &*backend_v627).unwrap();
                                let backend_v629: Rc<str> = string_concat(&[&*v1, "/release.txt"]);
                                std::fs::write(&*backend_v629, &*release_v624).unwrap();
                                let s_v631: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_Nil); } CASE.with(|case| case.clone()) };
                                let paths_v632: Rc<UH0> = method55(blobs_v431, p_v430, s_v631);
                                US2::US2_Accepted(line_v543, release_v624, paths_v632)
                            }
                            US39::US39_Rejected(e_v414) => {
                                let e_v414: US6 = e_v414;
                                let v415: US3 = US3::US3_PrepareRefused(e_v414);
                                US2::US2_Rejected(v415)
                            }
                        }
                    }
                    US38::US38_Rejected(e_v377) => {
                        let e_v377: US3 = e_v377;
                        US2::US2_Rejected(e_v377)
                    }
                }
            }
            US13::US13_Rejected(e_v362) => {
                let e_v362: US4 = e_v362;
                let v363: US3 = US3::US3_ManifestRefused(e_v362);
                US2::US2_Rejected(v363)
            }
        }
    } else {
        let v640: US3 = US3::US3_ManifestMissing(manifest_v2);
        US2::US2_Rejected(v640)
    };
    match v642 {
        US2::US2_Accepted(o_v643, _, _) => {
            let o_v643: Rc<str> = o_v643;
            println!("{}", o_v643);
            0i32
        }
        US2::US2_Rejected(e_v646) => {
            let e_v646: US3 = e_v646;
            let b_v686: Rc<str> = match e_v646 {
                US3::US3_ManifestMissing(path_v647) => {
                    let path_v647: Rc<str> = path_v647;
                    let v648: Rc<str> = string_concat(&["no manifest at ", &*path_v647]);
                    v648
                }
                US3::US3_ManifestRefused(m_v649) => {
                    let m_v649: US4 = m_v649;
                    match m_v649 {
                        US4::US4_BadValue(b_v664, b_v665) => {
                            let b_v664: Rc<str> = b_v664;
                            let b_v665: Rc<str> = b_v665;
                            let v668: Rc<str> = string_concat(&["spiral.toml ", &*b_v664, " has a bad value: ", &*b_v665]);
                            v668
                        }
                        US4::US4_MissingKey(key_v662) => {
                            let key_v662: Rc<str> = key_v662;
                            let v663: Rc<str> = string_concat(&["spiral.toml has no ", &*key_v662]);
                            v663
                        }
                        US4::US4_TomlRefused(t_v650) => {
                            let t_v650: US5 = t_v650;
                            match t_v650 {
                                US5::US5_UnclosedBlock(key_v657) => {
                                    let key_v657: Rc<str> = key_v657;
                                    let v659: Rc<str> = string_concat(&["spiral.toml block ", &*key_v657, " is never closed"]);
                                    v659
                                }
                                US5::US5_UnreadableLine(x_v651, b_v652) => {
                                    let x_v651: i32 = x_v651;
                                    let b_v652: Rc<str> = b_v652;
                                    let b_v653: Rc<str> = format_real_56(x_v651);
                                    let v656: Rc<str> = string_concat(&["spiral.toml line ", &*b_v653, " is not key = value: ", &*b_v652]);
                                    v656
                                }
                            }
                        }
                    }
                }
                US3::US3_ModuleMissing(path_v672) => {
                    let path_v672: Rc<str> = path_v672;
                    let v673: Rc<str> = string_concat(&["module file missing: ", &*path_v672]);
                    v673
                }
                US3::US3_PrepareRefused(p_v674) => {
                    let p_v674: US6 = p_v674;
                    match p_v674 {
                        US6::US6_CrlfInModule(path_v675) => {
                            let path_v675: Rc<str> = path_v675;
                            let v676: Rc<str> = string_concat(&[&*path_v675, " has CRLF line endings; publish takes LF text only"]);
                            v676
                        }
                        US6::US6_DuplicateModulePath(path_v677) => {
                            let path_v677: Rc<str> = path_v677;
                            let v678: Rc<str> = string_concat(&[&*path_v677, " is listed twice"]);
                            v678
                        }
                        US6::US6_NoModules => {
                            let v679: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("the package lists no modules"); } LIT.with(|lit| lit.clone()) };
                            v679
                        }
                    }
                }
            };
            let backend_v687: Rc<str> = string_concat(&["packages: ", &*b_v686]);
            eprintln!("{}", backend_v687);
            1i32
        }
    }
}
fn usage_57() -> i32 {
    let mut v0: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("usage: packages publish --dry-run <package dir> <out dir>"); } LIT.with(|lit| lit.clone()) };
    eprintln!("{}", v0);
    2i32
}
fn spiral_main() -> i32 {
    let index_v0: i32 = 0i32;
    let mut v1: Rc<UH0> = arguments_from_0(index_v0);
    let v25: US1 = match Rc::unwrap_or_clone(v1) {
        UH0::UH0_Cons(v2, v3) => {
            let mut v2: Rc<str> = v2;
            let v3: Rc<UH0> = v3;
            match Rc::unwrap_or_clone(v3) {
                UH0::UH0_Cons(v4, v5) => {
                    let v4: Rc<str> = v4;
                    let v5: Rc<UH0> = v5;
                    match Rc::unwrap_or_clone(v5) {
                        UH0::UH0_Cons(v6, v7) => {
                            let v6: Rc<str> = v6;
                            let v7: Rc<UH0> = v7;
                            match Rc::unwrap_or_clone(v7) {
                                UH0::UH0_Cons(v8, v9) => {
                                    let v8: Rc<str> = v8;
                                    let v9: Rc<UH0> = v9;
                                    match Rc::unwrap_or_clone(v9) {
                                        UH0::UH0_Nil => {
                                            let v10: bool = &*v2 == "publish";
                                            let v12: bool = if v10 {
                                                let v11: bool = &*v4 == "--dry-run";
                                                v11
                                            } else {
                                                false
                                            };
                                            if v12 {
                                                US1::US1_PublishDryRun(v6, v8)
                                            } else {
                                                US1::US1_Usage
                                            }
                                        }
                                        _ => {
                                            US1::US1_Usage
                                        }
                                    }
                                }
                                _ => {
                                    US1::US1_Usage
                                }
                            }
                        }
                        _ => {
                            US1::US1_Usage
                        }
                    }
                }
                _ => {
                    US1::US1_Usage
                }
            }
        }
        _ => {
            US1::US1_Usage
        }
    };
    match v25 {
        US1::US1_PublishDryRun(dir_v26, out_v27) => {
            let dir_v26: Rc<str> = dir_v26;
            let out_v27: Rc<str> = out_v27;
            published_3(dir_v26, out_v27)
        }
        US1::US1_Usage => {
            usage_57()
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
