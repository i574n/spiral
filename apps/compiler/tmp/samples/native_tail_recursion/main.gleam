import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method1(v0: Int) -> Int {
    let v1 = spiral_wrap_signed(v0 - 1, 32)
    let v2 = v1 == 0
    case v2 {
        True -> 0
        False -> method1(v1)
    }
}
pub fn method0(v0: Int) -> Int {
    let v1 = v0 == 0
    case v1 {
        True -> 0
        False -> method1(v0)
    }
}
pub fn main() {
    let v0 = 1000000
    method0(v0)
}
