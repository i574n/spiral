pub fn f_c0(capt: #(Int, String, Bool)) -> fn(Int) -> #(Int, String, Bool) {
    fn (v3) {
        let #(v0, v1, v2) = capt
        let v4 = v3 == 0
        case v4 {
            True -> {
                #(0, "no", False)
            }
            False -> #(v0, v1, v2)
        }
    }
}
pub fn main() {
    let v3 = f_c0(#(7, "hi", True))
    let #(v4, v5, v6) = v3(1)
    let v7 = v4 == 7
    let v9 =
        case v7 {
            True -> {
                v5 == "hi"
            }
            False -> False
        }
    let v10 = v9 && v6
    case v10 {
        True -> 0
        False -> 1
    }
}
