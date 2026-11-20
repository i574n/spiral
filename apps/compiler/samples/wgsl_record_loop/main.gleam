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


pub fn loop_0(v0: Int, v1: Int, v2: Int, v3: Int) -> #(Int, Int) {
    let v4 = v1 >= v0
    let #(v9, v10) =
        case v4 {
            True -> #(v2, v3)
            False -> {
                let v5 = spiral_wrap_i32(v1 + 1)
                let v6 = spiral_wrap_i32(v2 + 1)
                let #(v7, v8) = loop_0(v0, v5, v6, v3)
                #(v7, v8)
            }
        }
    #(v9, v10)
}
pub fn main() {
    let #(v4, v5) = loop_0(5, 0, 1, 2)
    spiral_wrap_i32(v4 + v5)
}
