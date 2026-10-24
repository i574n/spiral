pub fn f_c0(capt: #(String, String)) -> fn(Int) -> #(String, String) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                let v4 = "no"
                let v5 = "nay"
                #(v4, v5)
            }
            False -> {
                #(v0, v1)
            }
        }
    }
}
pub fn main() {
    let v0 = "hi"
    let v1 = "yo"
    let v2 = f_c0(#(v0, v1))
    let #(v3, v4) = v2(1)
    let v5 = v3 == "hi"
    let v7 =
        case v5 {
            True -> {
                let v6 = v4 == "yo"
                v6
            }
            False -> {
                False
            }
        }
    case v7 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
