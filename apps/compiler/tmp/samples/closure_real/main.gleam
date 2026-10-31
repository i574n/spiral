pub fn f_c0(capt: #(Float)) -> fn(Int) -> Float {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> 0.0
            False -> v0
        }
    }
}
pub fn main() {
    let v0 = 1.5
    let v1 = f_c0(#(v0))
    let v2 = v1(1)
    let v3 = v2 == 1.5
    case v3 {
        True -> 0
        False -> 1
    }
}
