#![allow(unused_imports, unused_mut, non_snake_case)]
#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]
use crate::types_callable::*;

pub fn select0(flag: bool) -> ClosureValue0 {
    let mut selected: ClosureValue0;
    let values: Array0;
    values = ArrayCreate0(1, false);
    if flag {
        DynamicArraySet0(&values, 0, 7);
    } else {
        DynamicArraySet0(&values, 0, 8);
    }
    DynamicArrayClone0(&values);
    if flag {
        selected = ClosureValueCreate0(values.clone(), 0);
    } else {
        selected = ClosureValueCreate0(values.clone(), 1);
    }
    drop(values);
    return selected;
}
