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


pub fn main() {
    let v0 = 43
    let v1 = 15
    let v4 = int.bitwise_and(v0, v1)
    let v5 = int.bitwise_or(v0, v1)
    let v6 = int.bitwise_exclusive_or(v0, v1)
    let v7 = spiral_wrap_i32(int.bitwise_not(v0))
    let v8 = int.bitwise_and(v7, 255)
    let v9 = spiral_wrap_i32(int.bitwise_shift_left(1, 5))
    let v10 = int.bitwise_shift_right(168, 2)
    let v11 = spiral_wrap_i32(v4 - 11)
    let v12 = spiral_wrap_i32(v10 + v11)
    let v13 = spiral_wrap_i32(v5 - 47)
    let v14 = spiral_wrap_i32(v12 + v13)
    let v15 = spiral_wrap_i32(v6 - 36)
    let v16 = spiral_wrap_i32(v14 + v15)
    let v17 = spiral_wrap_i32(v8 - 212)
    let v18 = spiral_wrap_i32(v16 + v17)
    let v19 = spiral_wrap_i32(v9 - 32)
    spiral_wrap_i32(v18 + v19)
}
