pub fn method0(v0: String, v1: String) -> #(String, String) {
    let v2 = v0 == ""
    case v2 {
        True -> {
            #("no", "nay")
        }
        False -> #(v0, v1)
    }
}
pub fn main() {
    let #(v2, v3) = method0("hi", "yo")
    let v4 = v2 == "hi"
    let v6 =
        case v4 {
            True -> {
                v3 == "yo"
            }
            False -> False
        }
    case v6 {
        True -> 0
        False -> 1
    }
}
