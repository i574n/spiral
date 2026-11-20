import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


pub type Us0 {
    Us0Hit(f0i0 : Int)
    Us0Flag(f1i0 : Bool)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Flag(v2) -> {
            case v2 {
                True -> 9
                False -> 4
            }
        }
        Us0Hit(v1) -> v1
    }
}
pub fn main() {
    let v3 =
        case False {
            True -> Us0Hit(7)
            False -> Us0Flag(True)
        }
    let v4 = score_0(v3)
    spiral_wrap_i32(v4 - 9)
}
