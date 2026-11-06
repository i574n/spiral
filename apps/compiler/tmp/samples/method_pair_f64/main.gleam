pub fn method0(v0: Int) -> #(Float, Float) {
    let v1 = v0 == 0
    case v1 {
        True -> #(0.0, 0.0)
        False -> #(1.5, 2.5)
    }
}
pub fn main() {
    let #(v1, v2) = method0(7)
    let v3 = v1 == 1.5
    let v5 =
        case v3 {
            True -> {
                v2 == 2.5
            }
            False -> False
        }
    case v5 {
        True -> 0
        False -> 1
    }
}
