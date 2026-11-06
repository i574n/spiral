pub fn method0(v0: Int) -> #(String, String) {
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = "no"
            #(v2, v2)
        }
        False -> {
            #("hi", "yo")
        }
    }
}
pub fn main() {
    let #(v1, v2) = method0(7)
    let v3 = v1 == "hi"
    let v5 =
        case v3 {
            True -> {
                v2 == "yo"
            }
            False -> False
        }
    case v5 {
        True -> 0
        False -> 1
    }
}
