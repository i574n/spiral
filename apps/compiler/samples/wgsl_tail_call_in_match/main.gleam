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
    Us0Done(f0i0 : Int)
    Us0More(f1i0 : Int)
}
pub fn layers_0(v0: Int) -> Int {
    let v1 = v0 >= 5
    let v4 =
        case v1 {
            True -> Us0Done(v0)
            False -> Us0More(v0)
        }
    case v4  {
        Us0Done(v8) -> {
            spiral_wrap_i32(v8 * 2)
        }
        Us0More(v5) -> {
            let v6 = spiral_wrap_i32(v5 + 1)
            layers_0(v6)
        }
    }
}
pub fn main() {
    layers_0(0)
}
