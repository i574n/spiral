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
    Us0None
    Us0Some(f1i0 : Int)
}
pub type Heap0 { Heap0(l0 : Us0, l1 : Int) }
pub fn main() {
    let v2 = Us0Some(3)
    let v3 = Heap0(l0: v2, l1: 4)
    let #(v4, v5) = #(v3.l0, v3.l1)
    case v4  {
        Us0None -> 1
        Us0Some(v6) -> {
            let v7 = spiral_wrap_i32(v6 + v5)
            let v8 = v7 == 7
            case v8 {
                True -> 0
                False -> 1
            }
        }
    }
}
