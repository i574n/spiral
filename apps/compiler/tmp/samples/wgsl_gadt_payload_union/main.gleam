pub type Us0 {
    Us0Living(f0i0 : Int, f0i1 : Int)
}
pub type Us2 {
    Us2Fallen(f0i0 : Int)
}
pub type Us1 {
    Us1Survived(f0i0 : Us0)
    Us1Slain(f1i0 : Us2)
}
pub fn main() {
let v0 = 60
let v1 = v0 > 0
let v6 =
    case v1 {
        True -> {
            let v2 = Us0Living(v0, 100)
            Us1Survived(v2)
        }
        False -> {
            let v4 = Us2Fallen(100)
            Us1Slain(v4)
        }
    }
case v6  {
    Us1Slain(v13) -> {
        2
    }
    Us1Survived(v7) -> {
        case v7  {
            Us0Living(v8, v9) -> {
                let v10 = v8 == 60
                case v10 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            }
        }
    }
}
}
