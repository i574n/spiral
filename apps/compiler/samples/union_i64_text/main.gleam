pub type Us0 {
    Us0None
    Us0Both(f1i0 : Int, f1i1 : String)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Both(v1, v2) -> {
            let v3 = v1 == 5000000000
            let v5 =
                case v3 {
                    True -> {
                        v2 == "hi"
                    }
                    False -> False
                }
            case v5 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v5 =
        case True {
            True -> Us0Both(5000000000, "hi")
            False -> Us0None
        }
    score_0(v5)
}
