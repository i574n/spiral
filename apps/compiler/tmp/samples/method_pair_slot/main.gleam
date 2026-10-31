pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn method0(v0: Int) -> #(Us0, Int) {
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = Us0None
            #(v2, 0)
        }
        False -> {
            let v3 = Us0Some(v0)
            #(v3, v0)
        }
    }
}
pub fn main() {
    let v0 = 7
    let #(v1, v2) = method0(v0)
    case v1  {
        Us0None -> 1
        Us0Some(v3) -> {
            let v4 = v3 == 7
            let v6 =
                case v4 {
                    True -> {
                        let v5 = v2 == 7
                        v5
                    }
                    False -> False
                }
            case v6 {
                True -> 0
                False -> 1
            }
        }
    }
}
