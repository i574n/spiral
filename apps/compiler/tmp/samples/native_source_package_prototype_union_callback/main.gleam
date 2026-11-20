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


pub type Us0 {
    Us0Idle
    Us0Hit(f1i0 : Int)
    Us0Flag(f2i0 : Bool)
}
pub fn closure0(capt: #(Int)) -> fn(Int) -> Us0 {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == v0
        Us0Flag(v2)
    }
}
pub fn method0(v0: fn(Int) -> Us0, v1: Int) -> Us0 {
    v0(v1)
}
pub fn main() {
    let v0 = 2
    let v1 = closure0(#(v0))
    let v2 = method0(v1, v0)
    let v8 =
        case v2  {
            Us0Flag(v4) -> {
                case v4 {
                    True -> 11
                    False -> 5
                }
            }
            Us0Hit(v3) -> v3
            Us0Idle -> 3
        }
    spiral_wrap_i32(v8 + 31)
}
