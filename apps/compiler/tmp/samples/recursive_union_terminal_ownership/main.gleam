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
    Uh0i0
    Uh0i1(Int, Uh0, Uh0)
}
pub fn method1(v0: Uh0) -> Int {
    case v0  {
        Uh0i0 -> {
            0
        }
        Uh0i1(v1, v2, v3) -> {
            let v4 = method1(v2)
            let v5 = method1(v3)
            let v6 = spiral_wrap_signed(v4 + v5, 32)
            let v7 = spiral_wrap_signed(v1 + v6, 32)
            v7
        }
    }
}
pub fn method0(v0: Uh0, v1: Uh0) -> Int {
    let v2 = method1(v0)
    let v3 = method1(v1)
    let v4 = spiral_wrap_signed(v2 + v3, 32)
    v4
}
pub fn main() {
let v0 = 1
let v1 = 2
let v2 = Uh0i0
let v3 = Uh0i1(v1, v2, v2)
let v4 = Uh0i1(v0, v3, v3)
let v5 = 1
let v6 = 2
let v7 = Uh0i0
let v8 = Uh0i1(v6, v7, v7)
let v9 = Uh0i1(v5, v8, v8)
let v10 = method0(v4, v9)
let v11 = spiral_wrap_signed(v10 - 10, 32)
v11
}
