pub fn method0(v0: Int) -> String {
    let v1 = v0 == 0
    case v1 {
        True -> {
            "no"
        }
        False -> {
            "hi"
        }
    }
}
pub fn main() {
    let v1 = method0(7)
    let v2 = v1 == "hi"
    case v2 {
        True -> 0
        False -> 1
    }
}
