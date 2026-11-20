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


pub type Heap0 { Heap0(l0 : Int) }
pub fn method0(v0: Int, v1: Heap0) -> #(Heap0, Int) {
    #(v1, v0)
}
pub fn main() {
    let v2 = Heap0(l0: 3)
    let #(v3, v4) = method0(4, v2)
    let v5 = v3.l0
    let v6 = spiral_wrap_i32(v5 + v4)
    let v7 = v6 == 7
    case v7 {
        True -> 0
        False -> 1
    }
}
