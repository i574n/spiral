pub type Us0 {
    Us0One(f0i0 : Int)
    Us0Both(f1i0 : Int, f1i1 : String)
}
pub fn method0(v0: Int, v1: String) -> Us0 {
    let v2 = v0 == 0
    case v2 {
        True -> {
            Us0One(0)
        }
        False -> {
            Us0Both(v0, v1)
        }
    }
}
pub fn main() {
let v0 = 3
let v1 = "hi"
let v2 = method0(v0, v1)
case v2  {
    Us0Both(v4, v5) -> {
        let v6 = v4 == 3
        let v8 =
            case v6 {
                True -> {
                    let v7 = v5 == "hi"
                    v7
                }
                False -> {
                    False
                }
            }
        case v8 {
            True -> {
                0
            }
            False -> {
                1
            }
        }
    }
    Us0One(v3) -> {
        1
    }
}
}
