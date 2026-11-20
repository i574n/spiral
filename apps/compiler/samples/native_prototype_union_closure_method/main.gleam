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
pub fn closure0(capt: #(Us0)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v7 =
            case v0  {
                Us0Flag(v3) -> {
                    case v3 {
                        True -> 11
                        False -> 5
                    }
                }
                Us0Hit(v2) -> v2
                Us0Idle -> 3
            }
        spiral_wrap_i32(v7 + v1)
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(31)
}
pub fn main() {
    let v0 = 2
    let v1 = v0 == 0
    let v7 =
        case v1 {
            True -> Us0Idle
            False -> {
                let v3 = v0 == 1
                case v3 {
                    True -> Us0Hit(7)
                    False -> Us0Flag(True)
                }
            }
        }
    let v8 = closure0(#(v7))
    method0(v8)
}
