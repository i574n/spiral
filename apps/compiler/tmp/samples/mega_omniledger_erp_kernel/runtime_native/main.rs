#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_TypedFxHashedStatementChecksumValidationAccepted(i64, i64, i64, i64, i64, Rc<str>),
    US0_TypedFxHashedStatementChecksumValidationRejected(i64, i64, Rc<str>),
}
#[path = "main_part1.rs"] mod part1;
pub(crate) use part1::*;
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
