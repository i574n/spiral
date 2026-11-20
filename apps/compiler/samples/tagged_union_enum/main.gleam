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
    Us0Cold
    Us0Warm
    Us0Hot
    Us0Done
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Cold -> 1
        Us0Done -> 4
        Us0Hot -> 3
        Us0Warm -> 2
    }
}
pub fn main() {
    let v0 = 3
    let v1 = v0 == 0
    let v10 =
        case v1 {
            True -> Us0Cold
            False -> {
                let v3 = v0 == 1
                case v3 {
                    True -> Us0Warm
                    False -> {
                        let v5 = v0 == 2
                        case v5 {
                            True -> Us0Hot
                            False -> Us0Done
                        }
                    }
                }
            }
        }
    let v11 = score_0(v10)
    spiral_wrap_i32(v11 - 4)
}
