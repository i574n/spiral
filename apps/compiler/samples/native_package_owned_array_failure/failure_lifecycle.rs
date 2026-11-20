use spiral_generated::*;
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::rc::Rc;

#[test]
fn package_owned_array_is_released_once_on_failure() {
    let array = ArrayCreate0(1, false);
    DynamicArraySet0(&array, 0, 7);
    let value = TupleCreate0(array.clone(), 41);
    assert_eq!(Rc::strong_count(&array), 2);

    let result = catch_unwind(AssertUnwindSafe(|| {
        let _ = method0(value);
    }));

    assert!(result.is_err());
    assert_eq!(Rc::strong_count(&array), 1);
    assert_eq!(DynamicArrayGet0(&array, 0), 7);
}
