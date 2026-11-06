pub fn method1(v0: Int, v1: Int, v2: Float) -> #(Int, Int, Float) {
    #(v0, v1, v2)
}
pub fn method0(v0: Int, v1: Int, v2: Float) -> Int {
    let #(v3, v4, v5) = method1(v0, v1, v2)
    let v6 = v3 == 2
    let v8 =
        case v6 {
            True -> {
                v4 == 3
            }
            False -> False
        }
    let v10 =
        case v8 {
            True -> {
                v5 == 1.5
            }
            False -> False
        }
    case v10 {
        True -> 0
        False -> 1
    }
}
pub fn main() {
    method0(2, 3, 1.5)
}
