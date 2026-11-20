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


pub fn method1(v0: Int, v1: Int) -> #(Int, Int) {
    #(v0, v1)
}
pub fn method0(v0: Int, v1: Int) -> Int {
    let #(v2, v3) = method1(v0, v1)
    spiral_wrap_i32(v2 + v3)
}
pub fn method3(v0: Int, v1: Int, v2: Int) -> #(Int, Int, Int) {
    #(v0, v1, v2)
}
pub fn method2(v0: Int, v1: Int, v2: Int) -> Int {
    let #(v3, v4, v5) = method3(v0, v1, v2)
    let v6 = spiral_wrap_i32(v3 + v4)
    spiral_wrap_i32(v6 + v5)
}
pub fn main() {
    let v0 = 1
    let v1 = 2
    let v3 = method0(v0, v1)
    let v4 = method2(v0, v1, 3)
    let v5 = spiral_wrap_i32(v3 + v4)
    spiral_wrap_i32(v5 - 9)
}
