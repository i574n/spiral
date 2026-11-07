pub fn method0(v0: Int, v1: String) -> #(Int, String) {
    let v2 = v0 == 0
    case v2 {
        True -> {
            #(0, "no")
        }
        False -> #(v0, v1)
    }
}
pub fn main() {
    let #(v2, v3) = method0(7, "hi")
    let v4 = v2 == 7
    let v6 =
        case v4 {
            True -> {
                v3 == "hi"
            }
            False -> False
        }
    case v6 {
        True -> 0
        False -> 1
    }
}
