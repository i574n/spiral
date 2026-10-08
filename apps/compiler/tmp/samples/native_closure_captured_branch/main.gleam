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

pub fn closure0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_signed(v1 + v0, 32)
        v2
    }
}
pub fn closure1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_signed(v1 + v0, 32)
        v2
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0( 40  )
}
pub fn main() {
let v0 = 2
let v1 = 3
let v2 = True
let v5 =
    case v2 {
        True -> {
            closure0(#(v0))
        }
        False -> {
            closure1(#(v1))
        }
    }
method0(v5)
}
