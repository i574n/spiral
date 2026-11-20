use spiral_generated::types_callable::{ClosureInvoke0, ClosureValueCreate0};
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::rc::Rc;

#[test]
fn managed_capture_is_released_when_invoke_panics() {
    let external = Rc::<str>::from("abc");
    assert_eq!(Rc::strong_count(&external), 1);
    let closure = ClosureValueCreate0(external.clone(), 0);
    assert_eq!(Rc::strong_count(&external), 2);

    let result = catch_unwind(AssertUnwindSafe(|| ClosureInvoke0(closure, 39)));
    assert!(result.is_err());
    assert_eq!(Rc::strong_count(&external), 1);
    assert_eq!(&*external, "abc");
}
