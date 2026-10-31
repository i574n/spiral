pub type Us0 {
    Us0One(f0i0 : Int)
    Us0Both(f1i0 : Int, f1i1 : String)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Both(v2, v3) -> {
            let v4 = v2 == 3
            let v6 =
                case v4 {
                    True -> {
                        let v5 = v3 == "hi"
                        v5
                    }
                    False -> False
                }
            case v6 {
                True -> 0
                False -> 1
            }
        }
        Us0One(v1) -> v1
    }
}
pub fn main() {
    let v0 = True
    let v1 = 3
    let v2 = "hi"
    let v5 =
        case v0 {
            True -> Us0Both(v1, v2)
            False -> Us0One(1)
        }
    score_0(v5)
}
