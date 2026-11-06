pub fn is_answer_1(v0: Int) -> Bool {
    v0 == 42
}
pub fn method0(v0: Int) -> Bool {
    is_answer_1(v0)
}
pub fn main() {
    let v1 = method0(42)
    case v1 {
        True -> 0
        False -> 1
    }
}
