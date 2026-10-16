import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Heap0 { Heap0(l0 : Int) }
pub fn method0(v0: Heap0, v1: Heap0) -> #(Heap0, Heap0) {
    #(v0, v1)
}
pub fn main() {
let v0 = 3
let v1 = 4
let v2 = Heap0(l0: v0)
let v3 = Heap0(l0: v1)
let #(v4, v5) = method0(v2, v3)
let v6 = v4.l0
let v7 = v5.l0
let v8 = spiral_wrap_signed(v6 + v7, 32)
let v9 = v8 == 7
case v9 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
