import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Heap0 { Heap0(l0 : Int) }
pub fn method0(v0: Int, v1: Heap0) -> #(Heap0, Int) {
    #(v1, v0)
}
pub fn main() {
let v0 = 3
let v1 = 4
let v2 = Heap0(l0: v0)
let #(v3, v4) = method0(v1, v2)
let v5 = v3.l0
let v6 = spiral_wrap_signed(v5 + v4, 32)
let v7 = v6 == 7
case v7 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
