#![allow(unused_imports, unused_mut, non_snake_case)]
#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]
use std::rc::Rc;

#[derive(Clone)]
pub struct ClosureValue0 {
    pub v0: Rc<str>,
    pub variant: i32,
}

pub fn ClosureValueCreate0(v0: Rc<str>, variant: i32) -> ClosureValue0 {
    ClosureValue0 { v0, variant }
}

pub fn ClosureInvoke0(x: ClosureValue0, v1: i32) -> i32 {
    if x.variant == 0 {
        if v1 == 0 {
            panic!("package-owned managed closure zero argument");
        }
        panic!("package-owned managed closure failure");
    } else {
        if v1 == 0 {
            panic!("package-owned managed closure alternate zero argument");
        }
        panic!("package-owned managed closure failure");
    }
}
