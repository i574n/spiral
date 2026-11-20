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
    Uh0Nil
    Uh0Cons(Int, Uh0)
}
pub fn sum_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Cons(v1, v2) -> {
            let v3 = sum_0(v2)
            spiral_wrap_i32(v1 + v3)
        }
        Uh0Nil -> 0
    }
}
pub fn main() {
    let v4 = Uh0Cons(3, Uh0Nil)
    let v5 = Uh0Cons(2, v4)
    let v6 = Uh0Cons(1, v5)
    let v7 = sum_0(v6)
    spiral_wrap_i32(v7 - 6)
}
