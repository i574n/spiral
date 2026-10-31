pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn f_c0(capt: #(Int)) -> fn(Int) -> #(Us0, Us0) {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                let v3 = Us0None
                let v4 = Us0None
                #(v3, v4)
            }
            False -> {
                let v5 = Us0Some(v0)
                let v6 = Us0None
                #(v5, v6)
            }
        }
    }
}
pub fn main() {
    let v0 = 7
    let v1 = f_c0(#(v0))
    let #(v2, v3) = v1(1)
    case v2  {
        Us0None -> 1
        Us0Some(v4) -> {
            case v3  {
                Us0None -> {
                    let v5 = v4 == 7
                    case v5 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0Some(v7) -> 1
            }
        }
    }
}
