pub type Us0 {
    Us0None
    Us0Both(f1i0 : Float, f1i1 : String)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Both(v1, v2) -> {
            let v3 = v1 == 1.5
            let v5 =
                case v3 {
                    True -> {
                        let v4 = v2 == "hi"
                        v4
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
    let v0 = 1.5
    let v1 = "hi"
    let v2 = True
    let v5 =
        case v2 {
            True -> Us0Both(v0, v1)
            False -> Us0None
        }
    score_0(v5)
}
