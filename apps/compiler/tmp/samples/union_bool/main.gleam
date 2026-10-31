pub type Us0 {
    Us0No(f0i0 : Bool)
    Us0Yes(f1i0 : Int)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0No(v1) -> {
            case v1 {
                True -> 1
                False -> 2
            }
        }
        Us0Yes(v3) -> v3
    }
}
pub fn main() {
    let v0 = True
    let v3 =
        case v0 {
            True -> Us0Yes(7)
            False -> Us0No(False)
        }
    let v6 =
        case v0 {
            True -> Us0No(True)
            False -> Us0Yes(1)
        }
    let v7 = score_0(v3)
    let v8 = v7 == 7
    let v11 =
        case v8 {
            True -> {
                let v9 = score_0(v6)
                let v10 = v9 == 1
                v10
            }
            False -> False
        }
    case v11 {
        True -> 0
        False -> 1
    }
}
