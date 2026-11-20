pub fn f_c0(capt: #(Int, String)) -> fn(Int) -> #(Int, String) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                #(0, "no")
            }
            False -> #(v0, v1)
        }
    }
}
pub fn main() {
    let v2 = f_c0(#(7, "hi"))
    let #(v3, v4) = v2(1)
    let v5 = v3 == 7
    let v7 =
        case v5 {
            True -> {
                v4 == "hi"
            }
            False -> False
        }
    case v7 {
        True -> 0
        False -> 1
    }
}
