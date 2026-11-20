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


pub type Heap0 { Heap0(l0 : Int, l1 : Int) }
pub fn main() {
    let v2 = Heap0(l0: 3, l1: 4)
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v5 = spiral_wrap_i32(v3 + v4)
    let v6 = v5 == 7
    case v6 {
        True -> 0
        False -> 1
    }
}
