import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn method1(v0: Int, v1: Int) -> #(Int, Int) {
    #(v0, v1)
}
pub fn method0(v0: Int, v1: Int) -> Int {
    let #(v2, v3) = method1(v0, v1)
    let v4 = spiral_wrap_signed(v2 + v3, 32)
    v4
}
pub fn method3(v0: Int, v1: Int, v2: Int) -> #(Int, Int, Int) {
    #(v0, v1, v2)
}
pub fn method2(v0: Int, v1: Int, v2: Int) -> Int {
    let #(v3, v4, v5) = method3(v0, v1, v2)
    let v6 = spiral_wrap_signed(v3 + v4, 32)
    let v7 = spiral_wrap_signed(v6 + v5, 32)
    v7
}
pub fn main() {
let v0 = 1
let v1 = 2
let v2 = 3
let v3 = method0(v0, v1)
let v4 = method2(v0, v1, v2)
let v5 = spiral_wrap_signed(v3 + v4, 32)
let v6 = spiral_wrap_signed(v5 - 9, 32)
v6
}
