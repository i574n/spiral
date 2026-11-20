import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


pub fn h_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> 0
            False -> {
                spiral_wrap_i32(v1 + v0)
            }
        }
    }
}
pub fn g_c0(capt: #(Int)) -> fn(Int) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        h_c1(#(v0))
    }
}
pub fn method0(v0: Int) -> fn(Int) -> fn(Int) -> Int {
    g_c0(#(v0))
}
pub fn main() {
    let v1 = method0(7)
    let v2 = v1(0)
    let v3 = v2(0)
    let v4 = v3 == 7
    case v4 {
        True -> 0
        False -> 1
    }
}
