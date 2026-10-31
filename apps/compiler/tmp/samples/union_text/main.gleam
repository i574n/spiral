pub type Us0 {
    Us0Text(f0i0 : String)
    Us0Code(f1i0 : Int)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Code(v4) -> v4
        Us0Text(v1) -> {
            let v2 = v1 == "hi"
            case v2 {
                True -> 2
                False -> 3
            }
        }
    }
}
pub fn main() {
    let v0 = True
    let v1 = "hi"
    let v4 =
        case v0 {
            True -> Us0Text(v1)
            False -> Us0Code(1)
        }
    let v7 =
        case v0 {
            True -> Us0Code(5)
            False -> Us0Text(v1)
        }
    let v8 = score_0(v4)
    let v9 = v8 == 2
    let v12 =
        case v9 {
            True -> {
                let v10 = score_0(v7)
                let v11 = v10 == 5
                v11
            }
            False -> False
        }
    case v12 {
        True -> 0
        False -> 1
    }
}
