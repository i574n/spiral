pub type Us0 {
    Us0One(f0i0 : Int)
    Us0Both(f1i0 : Int, f1i1 : String)
}
pub fn f_c0(capt: #(Int, String)) -> fn(Int) -> Us0 {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                Us0One(0)
            }
            False -> {
                Us0Both(v0, v1)
            }
        }
    }
}
pub fn main() {
    let v0 = 3
    let v1 = "hi"
    let v2 = f_c0(#(v0, v1))
    let v3 = v2(1)
    case v3  {
        Us0Both(v5, v6) -> {
            let v7 = v5 == 3
            let v9 =
                case v7 {
                    True -> {
                        let v8 = v6 == "hi"
                        v8
                    }
                    False -> {
                        False
                    }
                }
            case v9 {
                True -> {
                    0
                }
                False -> {
                    1
                }
            }
        }
        Us0One(v4) -> {
            1
        }
    }
}
