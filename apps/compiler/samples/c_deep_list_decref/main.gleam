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
    Uh0Link(Int, Uh0)
    Uh0End
}
pub fn build_0(v0: Int, v1: Uh0) -> Uh0 {
    let v2 = v0 == 0
    case v2 {
        True -> v1
        False -> {
            let v3 = spiral_wrap_i32(v0 - 1)
            let v4 = Uh0Link(v0, v1)
            build_0(v3, v4)
        }
    }
}
pub fn sum_1(v0: Uh0, v1: Int) -> Int {
    case v0  {
        Uh0End -> v1
        Uh0Link(v2, v3) -> {
            let v4 = spiral_wrap_i32(v1 * 31)
            let v5 = spiral_wrap_i32(v4 + v2)
            let v6 = v5 % 9973
            sum_1(v3, v6)
        }
    }
}
pub fn main() {
    let v2 = build_0(1000000, Uh0End)
    let v4 = sum_1(v2, 0)
    v4 % 256
}
