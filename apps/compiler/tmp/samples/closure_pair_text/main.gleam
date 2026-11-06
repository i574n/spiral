pub fn f_c0(capt: #(String)) -> fn(Int) -> #(String, String) {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                let v3 = "no"
                #(v3, v3)
            }
            False -> {
                #(v0, "yo")
            }
        }
    }
}
pub fn main() {
    let v1 = f_c0(#("hi"))
    let #(v2, v3) = v1(1)
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
