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


pub fn method2() -> Int {
    14
}
pub fn method1() -> Int {
    let v0 = method2()
    spiral_wrap_i32(14 + v0)
}
pub fn method0() -> Int {
    let v0 = method1()
    spiral_wrap_i32(14 + v0)
}
pub fn main() {
    method0()
}
