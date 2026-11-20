pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn method0(v0: Int) -> #(Us0, Us0) {
    let v1 = v0 == 0
    case v1 {
        True -> {
            #(Us0None, Us0None)
        }
        False -> {
            let v4 = Us0Some(v0)
            #(v4, Us0None)
        }
    }
}
pub fn main() {
    let #(v1, v2) = method0(7)
    case v1  {
        Us0None -> 1
        Us0Some(v3) -> {
            case v2  {
                Us0None -> {
                    let v4 = v3 == 7
                    case v4 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0Some(v6) -> 1
            }
        }
    }
}
