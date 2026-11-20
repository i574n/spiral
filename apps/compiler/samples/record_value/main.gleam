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


pub fn method0(v0: Int) -> #(Int, Int, Bool) {
    let v1 = spiral_wrap_i32(v0 + 2)
    let v2 = v0 > 0
    #(v0, v1, v2)
}
pub fn method1(v0: Int, v1: Int, v2: Bool) -> Int {
    case v2 {
        True -> {
            let v3 = spiral_wrap_i32(v0 + v1)
            spiral_wrap_i32(v3 - 4)
        }
        False -> 1
    }
}
pub fn main() {
    let #(v1, v2, v3) = method0(1)
    method1(v1, v2, v3)
}
