#![allow(unused_imports, unused_mut, non_snake_case)]
#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]
use std::rc::Rc;
use std::cell::RefCell;

pub type Array0 = Rc<RefCell<Vec<i32>>>;
pub fn ArrayCreate0(len: i32, _init_at_zero: bool) -> Array0 {
    assert!(len >= 0, "negative Spiral array length");
    Rc::new(RefCell::new(vec![0; len as usize]))
}
pub fn DynamicArraySet0(array: &Array0, index: i32, value: i32) {
    assert!(index >= 0, "negative Spiral array index");
    let mut data = array.borrow_mut();
    let index = index as usize;
    assert!(index < data.len(), "Spiral array index out of bounds");
    data[index] = value;
}
pub fn DynamicArrayGet0(array: &Array0, index: i32) -> i32 {
    assert!(index >= 0, "negative Spiral array index");
    let data = array.borrow();
    let index = index as usize;
    assert!(index < data.len(), "Spiral array index out of bounds");
    data[index]
}
pub fn DynamicArrayLen0(array: &Array0) -> i32 {
    let len = array.borrow().len();
    assert!(len <= i32::MAX as usize, "Spiral array length exceeds i32");
    len as i32
}
pub fn DynamicArrayClone0(_array: &Array0) {}
pub fn DynamicArrayDrop0(_array: &Array0) {}

#[derive(Clone)]
pub struct ClosureValue0 {
    pub v0: Array0,
    pub variant: i32,
}

pub fn ClosureValueCreate0(v0: Array0, variant: i32) -> ClosureValue0 {
    ClosureValue0 { v0, variant }
}

pub fn ClosureInvoke0(x: ClosureValue0, v1: i32) -> i32 {
    if x.variant == 0 {
        let mut observed: i32;
        observed = DynamicArrayGet0(&x.v0, 0);
        if observed < 0 {
            panic!("package-owned managed array closure negative capture");
        }
        if v1 == 0 {
            panic!("package-owned managed array closure zero argument");
        }
        panic!("package-owned managed array closure failure");
    } else {
        let mut observed: i32;
        observed = DynamicArrayGet0(&x.v0, 0);
        if observed < 0 {
            panic!("package-owned managed array closure negative capture");
        }
        if v1 == 0 {
            panic!("package-owned managed array closure alternate zero argument");
        }
        panic!("package-owned managed array closure failure");
    }
}
