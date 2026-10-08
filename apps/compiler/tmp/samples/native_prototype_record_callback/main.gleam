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

pub fn closure0(capt: #(Int)) -> fn(#(Int, Int)) -> #(Int, Int) {
    fn (dom) {
        let #(v1, v2) = dom
        let #(v0) = capt
        let v3 = spiral_wrap_signed(v1 - 8, 32)
        let v4 = spiral_wrap_signed(v3 + v0, 32)
        let v5 = spiral_wrap_signed(v2 - 18, 32)
        #(v4, v5)
    }
}
pub fn method0(v0: fn(#(Int, Int)) -> #(Int, Int)) -> #(Int, Int) {
    v0( #(10, 20)  )
}
pub fn main() {
let v0 = 1
let v1 = closure0(#(v0))
let #(v2, v3) = method0(v1)
let v4 = spiral_wrap_signed(10 + v2, 32)
let v5 = spiral_wrap_signed(20 + v3, 32)
let v6 = spiral_wrap_signed(v4 + v5, 32)
let v7 = spiral_wrap_signed(v6 + 7, 32)
v7
}
