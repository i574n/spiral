import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Us0 {
    Us0Idle
    Us0Hit(f1i0 : Int)
    Us0Flag(f2i0 : Bool)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Flag(v2) -> {
            case v2 {
                True -> {
                    11
                }
                False -> {
                    5
                }
            }
        }
        Us0Hit(v1) -> {
            v1
        }
        Us0Idle -> {
            3
        }
    }
}
pub fn main() {
    let v0 = 2
    let v1 = v0 == 0
    let v7 =
        case v1 {
            True -> {
                Us0Idle
            }
            False -> {
                let v3 = v0 == 1
                case v3 {
                    True -> {
                        Us0Hit(7)
                    }
                    False -> {
                        Us0Flag(True)
                    }
                }
            }
        }
    let v8 = score_0(v7)
    let v9 = spiral_wrap_signed(v8 - 11, 32)
    v9
}
