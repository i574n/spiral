pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn f_c0(capt: #(Int)) -> fn(Int) -> #(Us0, Int) {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                let v3 = Us0None
                #(v3, 0)
            }
            False -> {
                let v4 = Us0Some(v0)
                #(v4, v0)
            }
        }
    }
}
pub fn main() {
    let v0 = 7
    let v1 = f_c0(#(v0))
    let #(v2, v3) = v1(1)
    case v2  {
        Us0None -> {
            1
        }
        Us0Some(v4) -> {
            let v5 = v4 == 7
            let v7 =
                case v5 {
                    True -> {
                        let v6 = v3 == 7
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
    }
}
