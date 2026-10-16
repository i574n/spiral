pub type Us0 {
    Us0Missing
    Us0Held(f1i0 : Int)
}
pub fn main() {
let v0 = 100
let v1 = True
let v4 =
    case v1 {
        True -> {
            Us0Held(v0)
        }
        False -> {
            Us0Missing
        }
    }
case v4  {
    Us0Held(v5) -> {
        let v6 = v5 == 100
        case v6 {
            True -> {
                0
            }
            False -> {
                1
            }
        }
    }
    Us0Missing -> {
        1
    }
}
}
