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
    Uh0Leaf
    Uh0Node(Int, Uh0, Uh0)
}
pub fn sum_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Leaf -> {
            0
        }
        Uh0Node(v1, v2, v3) -> {
            let v4 = sum_0(v2)
            let v5 = sum_0(v3)
            let v6 = spiral_wrap_signed(v4 + v5, 32)
            let v7 = spiral_wrap_signed(v1 + v6, 32)
            v7
        }
    }
}
pub fn closure0(capt: #(Uh0)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = sum_0(v0)
        let v3 = spiral_wrap_signed(v2 + v1, 32)
        v3
    }
}
pub fn main() {
let v0 = Uh0Leaf
let v1 = 2
let v2 = Uh0Node(v1, v0, v0)
let v3 = closure0(#(v2))
let v4 = v3( 19  )
let v5 = v3( 19  )
let v6 = spiral_wrap_signed(v4 + v5, 32)
v6
}
