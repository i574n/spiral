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
    Uh0Marker
    Uh0Node(Int, Uh0, Uh0)
}
pub fn sum_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Leaf -> 0
        Uh0Marker -> 0
        Uh0Node(v1, v2, v3) -> {
            let v4 = sum_0(v2)
            let v5 = sum_0(v3)
            let v6 = spiral_wrap_i32(v4 + v5)
            spiral_wrap_i32(v1 + v6)
        }
    }
}
pub fn main() {
    let v4 = Uh0Node(2, Uh0Leaf, Uh0Marker)
    let v5 = Uh0Node(1, v4, v4)
    let v6 = sum_0(v5)
    spiral_wrap_i32(v6 - 5)
}
