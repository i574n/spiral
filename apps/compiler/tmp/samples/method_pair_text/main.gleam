pub fn method0(v0: Int) -> #(String, String) {
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = "no"
            #(v2, v2)
        }
        False -> {
            let v3 = "hi"
            let v4 = "yo"
            #(v3, v4)
        }
    }
}
pub fn main() {
    let v0 = 7
    let #(v1, v2) = method0(v0)
    let v3 = v1 == "hi"
    let v5 =
        case v3 {
            True -> {
                let v4 = v2 == "yo"
                v4
            }
            False -> False
        }
    case v5 {
        True -> 0
        False -> 1
    }
}
