import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

pub type Uh0 {
    Uh0Empty
    Uh0Box(Int, Uh0)
}
pub fn method2(v0: Int) -> Uh0 {
    let v1 = spiral_wrap_signed(v0 - 1, 32)
    let v2 = v1 == 0
    case v2 {
        True -> {
            let v3 = Uh0Empty
            Uh0Box(7, v3)
        }
        False -> {
            method1(v1)
        }
    }
}
pub fn method1(v0: Int) -> Uh0 {
    let v1 = spiral_wrap_signed(v0 - 1, 32)
    let v2 = v1 == 0
    case v2 {
        True -> {
            let v3 = Uh0Empty
            Uh0Box(11, v3)
        }
        False -> {
            method2(v1)
        }
    }
}
pub fn method0() -> Uh0 {
    let v0 = 1000000
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = Uh0Empty
            Uh0Box(7, v2)
        }
        False -> {
            method1(v0)
        }
    }
}
pub fn main() {
let v0 = method0()
case v0  {
    Uh0Box(v1, v2) -> {
        let v3 = v1 == 7
        case v3 {
            True -> {
                0
            }
            False -> {
                3
            }
        }
    }
    Uh0Empty -> {
        1
    }
}
}
