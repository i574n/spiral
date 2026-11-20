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


pub fn closure1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_i32(v0 * 10)
        spiral_wrap_i32(v2 + v1)
    }
}
pub fn f_c0(capt: Nil) -> fn(Int) -> fn(Int) -> Int {
    fn (v0) {
        closure1(#(v0))
    }
}
pub fn main() {
    let v0 = f_c0(Nil)
    let v1 = v0(3)
    let v2 = v1(4)
    let v3 = v2 == 34
    case v3 {
        True -> 0
        False -> 1
    }
}
