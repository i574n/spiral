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


pub fn fib_0(v0: Int) -> Int {
    let v1 = v0 <= 1
    case v1 {
        True -> v0
        False -> {
            let v2 = spiral_wrap_i32(v0 - 1)
            let v3 = fib_0(v2)
            let v4 = spiral_wrap_i32(v0 - 2)
            let v5 = fib_0(v4)
            spiral_wrap_i32(v3 + v5)
        }
    }
}
pub fn main() {
    let v1 = fib_0(10)
    spiral_wrap_i32(v1 - 55)
}
