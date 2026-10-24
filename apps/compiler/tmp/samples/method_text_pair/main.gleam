pub fn method0(v0: String, v1: String) -> #(String, String) {
    let v2 = v0 == ""
    case v2 {
        True -> {
            let v3 = "no"
            let v4 = "nay"
            #(v3, v4)
        }
        False -> {
            #(v0, v1)
        }
    }
}
pub fn main() {
    let v0 = "hi"
    let v1 = "yo"
    let #(v2, v3) = method0(v0, v1)
    let v4 = v2 == "hi"
    let v6 =
        case v4 {
            True -> {
                let v5 = v3 == "yo"
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
