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


pub fn g_c1(capt: #(Int, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v1 == 0
        case v3 {
            True -> 0
            False -> {
                spiral_wrap_i32(v2 + v0)
            }
        }
    }
}
pub fn f_c0(capt: #(Int)) -> fn(Int) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        g_c1(#(v0, v1))
    }
}
pub fn main() {
    let v1 = f_c0(#(7))
    let v2 = v1(1)
    let v3 = v2(0)
    let v4 = v3 == 7
    case v4 {
        True -> 0
        False -> 1
    }
}
