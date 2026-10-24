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
                let v4 = "yo"
                #(v0, v4)
            }
        }
    }
}
pub fn main() {
    let v0 = "hi"
    let v1 = f_c0(#(v0))
    let #(v2, v3) = v1(1)
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
