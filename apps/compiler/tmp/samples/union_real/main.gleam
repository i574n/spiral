import gleam/float
pub type Us0 {
    Us0Real(f0i0 : Float)
    Us0Whole(f1i0 : Int)
}
pub fn twice_1(v0: Float) -> Int {
    let v1 = v0 *. 2.0
    let v2 = float.truncate(v1)
    v2
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Real(v1) -> {
            twice_1(v1)
        }
        Us0Whole(v3) -> {
            v3
        }
    }
}
pub fn main() {
    let v0 = True
    let v1 = 1.5
    let v4 =
        case v0 {
            True -> {
                Us0Real(v1)
            }
            False -> {
                Us0Whole(1)
            }
        }
    let v7 =
        case v0 {
            True -> {
                Us0Whole(5)
            }
            False -> {
                Us0Real(v1)
            }
        }
    let v8 = score_0(v4)
    let v9 = v8 == 3
    let v12 =
        case v9 {
            True -> {
                let v10 = score_0(v7)
                let v11 = v10 == 5
                v11
            }
            False -> {
                False
            }
        }
    case v12 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
