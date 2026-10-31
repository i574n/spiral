pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn f_c0(capt: #(Int)) -> fn(Int) -> Us0 {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> Us0None
            False -> Us0Some(v0)
        }
    }
}
pub fn main() {
    let v0 = 7
    let v1 = f_c0(#(v0))
    let v2 = v1(1)
    case v2  {
        Us0None -> 1
        Us0Some(v3) -> {
            let v4 = v3 == 7
            case v4 {
                True -> 0
                False -> 1
            }
        }
    }
}
