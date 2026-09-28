extern crate spiral_exports;

#[test]
fn scalar_and_binary_exports_keep_values() {
    assert_eq!(spiral_exports::export_scalar(), 7);
    assert_eq!(spiral_exports::export_choose(i32::MIN, i32::MAX), i32::MIN);
    assert_eq!(spiral_exports::export_choose(9, -4), -4);
}

#[test]
fn string_results_outlive_the_borrowed_input() {
    let (echo, five) = {
        let input = String::from("retained \0 λ🌀");
        (spiral_exports::export_echo(&input), spiral_exports::export_five(&input))
    };
    assert_eq!(echo.as_ref(), "retained \0 λ🌀");
    assert_eq!(five.0, echo);
    assert_eq!((five.1.as_ref(), five.2.as_ref(), five.3.as_ref(), five.4.as_ref()),
               ("second", "", "fourth", "fifth"));
    assert_eq!(spiral_exports::export_echo("").as_ref(), "");
}

#[test]
fn u64_exports_keep_width_and_argument_order() {
    assert_eq!(spiral_exports::export_size(""), 0);
    assert_eq!(spiral_exports::export_size("λ🌀"), "λ🌀".len() as u64);
    assert_eq!(spiral_exports::export_opaque("λ🌀"), "λ🌀".len() as u64);
    assert_eq!(spiral_exports::export_ordered("a", "bb", "ccc", "dddd", "eeeee"), u64::MAX);
    assert_eq!(spiral_exports::export_ordered("bb", "a", "ccc", "dddd", "eeeee"), 1);
    assert_eq!(spiral_exports::export_ordered("a", "bb", "ccc", "eeeee", "dddd"), 4);
}
