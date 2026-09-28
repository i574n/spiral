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
        let mut v0: Rc<str>;
        v0 = x.v0.clone();
        let closure0_v2: i32;
        closure0_v2 = v0.len() as i32;
        let closure0_v3: i32;
        closure0_v3 = closure0_v2 + v1;
        return closure0_v3;
    } else {
        let mut v0: Rc<str>;
        v0 = x.v0.clone();
        let closure1_v2: i32;
        closure1_v2 = v0.len() as i32;
        let closure1_v3: i32;
        closure1_v3 = closure1_v2 + v1 - 1;
        return closure1_v3;
    }
}
