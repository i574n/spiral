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
    Us0Circle(f0i0 : Int)
    Us0Rect(f1i0 : Int, f1i1 : Int)
    Us0Empty
}
pub fn main() {
    let v1 = Us0Circle(2)
    let v4 = Us0Rect(3, 4)
    let v7 = Us0Circle(2)
    let v18 =
        case v1,v7  {
            Us0Circle(v8),Us0Circle(v9) -> {
                v8 == v9
            }
            Us0Empty,Us0Empty -> True
            Us0Rect(v11, v12),Us0Rect(v13, v14) -> {
                let v15 = v11 == v13
                case v15 {
                    True -> {
                        v12 == v14
                    }
                    False -> False
                }
            }
            _,_ -> False
        }
    let v19 =
        case v18 {
            True -> 100
            False -> 0
        }
    let v28 =
        case v1  {
            Us0Circle(v20) -> {
                let v21 = spiral_wrap_i32(3 * v20)
                spiral_wrap_i32(v21 * v20)
            }
            Us0Empty -> 0
            Us0Rect(v23, v24) -> {
                spiral_wrap_i32(v23 * v24)
            }
        }
    let v37 =
        case v4  {
            Us0Circle(v29) -> {
                let v30 = spiral_wrap_i32(3 * v29)
                spiral_wrap_i32(v30 * v29)
            }
            Us0Empty -> 0
            Us0Rect(v32, v33) -> {
                spiral_wrap_i32(v32 * v33)
            }
        }
    let v38 = spiral_wrap_i32(v28 + v37)
    let v47 =
        case Us0Empty  {
            Us0Circle(v39) -> {
                let v40 = spiral_wrap_i32(3 * v39)
                spiral_wrap_i32(v40 * v39)
            }
            Us0Empty -> 0
            Us0Rect(v42, v43) -> {
                spiral_wrap_i32(v42 * v43)
            }
        }
    let v48 = spiral_wrap_i32(v38 + v47)
    spiral_wrap_i32(v48 + v19)
}
