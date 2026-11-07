import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: Int) -> #(Int, Int, Bool) {
    let v1 = spiral_wrap_signed(v0 + 2, 32)
    let v2 = v0 > 0
    #(v0, v1, v2)
}
pub fn method1(v0: Int, v1: Int, v2: Bool) -> Int {
    case v2 {
        True -> {
            let v3 = spiral_wrap_signed(v0 + v1, 32)
            spiral_wrap_signed(v3 - 4, 32)
        }
        False -> 1
    }
}
pub fn main() {
    let #(v1, v2, v3) = method0(1)
    method1(v1, v2, v3)
}
