#![allow(unused_imports, unused_mut, non_snake_case)]
#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]
use crate::types_callable::*;
use std::rc::Rc;

pub fn select0(flag: bool) -> ClosureValue0 {
    let mut selected: ClosureValue0;
    if flag {
        let mut name: Rc<str>;
        name = Rc::<str>::from("abc");
        selected = ClosureValueCreate0(name.clone(), 0);
    } else {
        let mut name: Rc<str>;
        name = Rc::<str>::from("wxyz");
        selected = ClosureValueCreate0(name.clone(), 1);
    }
    return selected;
}
