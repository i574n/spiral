pub fn f_c0(capt: #(String)) -> fn(Int) -> String {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                "no"
            }
            False -> v0
        }
    }
}
pub fn main() {
    let v1 = f_c0(#("hi"))
    let v2 = v1(1)
    let v3 = v2 == "hi"
    case v3 {
        True -> 0
        False -> 1
    }
}
