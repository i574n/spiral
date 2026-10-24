pub fn g_c1(capt: #(String, Int)) -> fn(Int) -> String {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v1 == 0
        case v3 {
            True -> {
                let v4 = "no"
                v4
            }
            False -> {
                v0
            }
        }
    }
}
pub fn f_c0(capt: #(String)) -> fn(Int) -> fn(Int) -> String {
    fn (v1) {
        let #(v0) = capt
        g_c1(#(v0, v1))
    }
}
pub fn main() {
    let v0 = "hi"
    let v1 = f_c0(#(v0))
    let v2 = v1(1)
    let v3 = v2(0)
    let v4 = v3 == "hi"
    case v4 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
