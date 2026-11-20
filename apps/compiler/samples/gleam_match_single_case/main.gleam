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
    Us0Step(f0i0 : Int, f0i1 : Int, f0i2 : Int)
}
pub fn walk_0(v0: Int) -> Int {
    let v1 = v0 > 2
    let v6 =
        case v1 {
            True -> {
                let v2 = spiral_wrap_i32(v0 + 1)
                let v3 = spiral_wrap_i32(v0 + 2)
                Us0Step(v0, v2, v3)
            }
            False -> Us0Step(0, 1, 2)
        }
    case v6  {
        Us0Step(v7, v8, v9) -> {
            let v10 = spiral_wrap_i32(v8 * v9)
            spiral_wrap_i32(v7 + v10)
        }
    }
}
pub fn main() {
    let v0 = 5
    let v1 = walk_0(v0)
    let v2 = spiral_wrap_i32(v0 - 4)
    let v3 = walk_0(v2)
    spiral_wrap_i32(v1 + v3)
}
