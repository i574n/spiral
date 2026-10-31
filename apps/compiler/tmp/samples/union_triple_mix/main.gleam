pub type Us0 {
    Us0One(f0i0 : Int)
    Us0All(f1i0 : Int, f1i1 : String, f1i2 : Bool)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0All(v2, v3, v4) -> {
            let v5 = v2 == 7
            let v7 =
                case v5 {
                    True -> {
                        let v6 = v3 == "hi"
                        v6
                    }
                    False -> False
                }
            let v8 = v7 && v4
            case v8 {
                True -> 0
                False -> 1
            }
        }
        Us0One(v1) -> v1
    }
}
pub fn main() {
    let v0 = True
    let v1 = 7
    let v2 = "hi"
    let v3 = True
    let v6 =
        case v0 {
            True -> Us0All(v1, v2, v3)
            False -> Us0One(1)
        }
    score_0(v6)
}
