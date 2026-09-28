#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("patch_resume.spi\n");
    let mut v2: bool = v0.starts_with(&*v1);
    if v2 {
        let mut v3: Rc<str> = Rc::<str>::from("PatchResumeReceipt (");
        let mut v4: bool = v0.contains(&*v3);
        let mut v7: bool = if v4 {
            let mut v5: Rc<str> = Rc::<str>::from("inl main () : i32 = 0i32");
            let mut v6: bool = v0.contains(&*v5);
            v6
        } else {
            false
        };
        if v7 {
            1u64
        } else {
            0u64
        }
    } else {
        let mut v9: Rc<str> = Rc::<str>::from("toolchain_process_receipt.spi\n");
        let mut v10: bool = v0.starts_with(&*v9);
        if v10 {
            let mut v11: Rc<str> = Rc::<str>::from("\n// toolchain-process-receipt|");
            let mut v12: bool = v0.contains(&*v11);
            let mut v15: bool = if v12 {
                let mut v13: Rc<str> = Rc::<str>::from("ToolchainProcessReceipt (");
                let mut v14: bool = v0.contains(&*v13);
                v14
            } else {
                false
            };
            let mut v18: bool = if v15 {
                let mut v16: Rc<str> = Rc::<str>::from("inl main () : i32 = 0i32");
                let mut v17: bool = v0.contains(&*v16);
                v17
            } else {
                false
            };
            if v18 {
                1u64
            } else {
                0u64
            }
        } else {
            0u64
        }
    }
}
fn closure0() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method0(v0.clone())
    })
}
fn method2(mut v0: Rc<str>) -> u64 {
    let mut v1: Rc<str> = Rc::<str>::from("typecheck_receipts.spi");
    let mut v2: bool = v0 == v1 ;
    if v2 {
        0u64
    } else {
        let mut v3: Rc<str> = Rc::<str>::from(".spi");
        let mut v4: bool = v0.ends_with(&*v3);
        if v4 {
            1u64
        } else {
            0u64
        }
    }
}
fn method1(mut v0: Rc<str>) -> u64 {
    method2(v0.clone())
}
fn closure1() -> Rc<dyn Fn(Rc<str>) -> u64> {
    Rc::new(move |mut v0: Rc<str>| -> u64 {
        method1(v0.clone())
    })
}
pub fn eoie_agile_state_transient_schema_code(v0: &str) -> u64 {
    closure0()(Rc::<str>::from(v0))
}
pub fn eoie_agile_state_path_candidate_code(v0: &str) -> u64 {
    closure1()(Rc::<str>::from(v0))
}
