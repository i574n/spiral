pub fn f_c0(capt: #(Int)) -> fn(Int) -> #(Int, Int) {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                #(0, 0)
            }
            False -> {
                #(v0, 7)
            }
        }
    }
}
pub fn main() {
    let v0 = 100
    let v1 = f_c0(#(v0))
    let #(v2, v3) = v1(1)
    let v4 = v2 == 100
    let v6 =
        case v4 {
            True -> {
                let v5 = v3 == 7
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
