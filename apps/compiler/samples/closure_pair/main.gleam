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


pub fn f_c0(capt: Nil) -> fn(Int) -> #(Int, Int) {
    fn (v0) {
        let v1 = spiral_wrap_i32(v0 + 1)
        #(v0, v1)
    }
}
pub fn main() {
    let v1 = f_c0(Nil)
    let #(v2, v3) = v1(3)
    let v4 = v2 == 3
    let v6 =
        case v4 {
            True -> {
                v3 == 4
            }
            False -> False
        }
    case v6 {
        True -> 0
        False -> 1
    }
}
