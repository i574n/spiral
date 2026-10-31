pub type Us0 {
    Us0None
    Us0All(f1i0 : Int, f1i1 : String, f1i2 : Bool)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0All(v1, v2, v3) -> {
            let v4 = v1 == 4000000000
            let v6 =
                case v4 {
                    True -> {
                        let v5 = v2 == "hi"
                        v5
                    }
                    False -> False
                }
            let v7 = v6 && v3
            case v7 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v0 = 4000000000
    let v1 = "hi"
    let v2 = True
    let v3 = True
    let v6 =
        case v3 {
            True -> Us0All(v0, v1, v2)
            False -> Us0None
        }
    score_0(v6)
}
