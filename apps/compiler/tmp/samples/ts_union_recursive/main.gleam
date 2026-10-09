import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

pub type Uh0 {
    Uh0Nil
    Uh0Cons(Int, Uh0)
}
pub fn sum_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Cons(v1, v2) -> {
            let v3 = sum_0(v2)
            let v4 = spiral_wrap_signed(v1 + v3, 32)
            v4
        }
        Uh0Nil -> {
            0
        }
    }
}
pub fn main() {
let v0 = 1
let v1 = 2
let v2 = 3
let v3 = Uh0Nil
let v4 = Uh0Cons(v2, v3)
let v5 = Uh0Cons(v1, v4)
let v6 = Uh0Cons(v0, v5)
let v7 = sum_0(v6)
let v8 = spiral_wrap_signed(v7 - 6, 32)
v8
}
