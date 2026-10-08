pub fn method0(v0: Int) -> Int {
    let v1 = v0 == 1
    case v1 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
pub fn main() {
let v0 = 1
method0(v0)
}
