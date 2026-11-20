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


pub type Uh0 {
    Uh0Leaf
    Uh0Node(Int, Uh0, Uh0)
}
pub fn sum_1(v0: Uh0) -> Int {
    case v0  {
        Uh0Leaf -> 0
        Uh0Node(v1, v2, v3) -> {
            let v4 = sum_1(v2)
            let v5 = sum_1(v3)
            let v6 = spiral_wrap_i32(v4 + v5)
            spiral_wrap_i32(v1 + v6)
        }
    }
}
pub fn consume_pair_0(v0: Uh0, v1: Uh0) -> Int {
    let v2 = sum_1(v0)
    let v3 = sum_1(v1)
    spiral_wrap_i32(v2 + v3)
}
pub fn main() {
    let v2 = Uh0Leaf
    let v3 = Uh0Node(2, v2, v2)
    let v4 = Uh0Node(1, v3, v3)
    let v7 = Uh0Leaf
    let v8 = Uh0Node(2, v7, v7)
    let v9 = Uh0Node(1, v8, v8)
    let v10 = consume_pair_0(v4, v9)
    spiral_wrap_i32(v10 - 10)
}
