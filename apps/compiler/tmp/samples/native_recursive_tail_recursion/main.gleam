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


pub type Uh0 {
    Uh0Empty
    Uh0Box(Int, Uh0)
}
pub fn method2(v0: Int) -> Uh0 {
    let v1 = spiral_wrap_i32(v0 - 1)
    let v2 = v1 == 0
    case v2 {
        True -> {
            Uh0Box(7, Uh0Empty)
        }
        False -> method1(v1)
    }
}
pub fn method1(v0: Int) -> Uh0 {
    let v1 = spiral_wrap_i32(v0 - 1)
    let v2 = v1 == 0
    case v2 {
        True -> {
            Uh0Box(11, Uh0Empty)
        }
        False -> method2(v1)
    }
}
pub fn method0() -> Uh0 {
    let v0 = 1000000
    let v1 = v0 == 0
    case v1 {
        True -> {
            Uh0Box(7, Uh0Empty)
        }
        False -> method1(v0)
    }
}
pub fn main() {
    let v0 = method0()
    case v0  {
        Uh0Box(v1, v2) -> {
            let v3 = v1 == 7
            case v3 {
                True -> 0
                False -> 3
            }
        }
        Uh0Empty -> 1
    }
}
