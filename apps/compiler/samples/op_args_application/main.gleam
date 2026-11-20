pub fn f_0(v0: Int) -> Int {
    let v1 = v0 == 1
    case v1 {
        True -> 0
        False -> 1
    }
}
pub fn main() {
    f_0(1)
}
