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

pub fn method1(v0: Int) -> #(Int, Int, Bool) {
    let v1 = spiral_wrap_signed(v0 + 2, 32)
    let v2 = v0 > 0
    #(v0, v1, v2)
}
pub fn method2(v0: Int, v1: Int, v2: Bool) -> Int {
    case v2 {
        True -> {
            let v3 = spiral_wrap_signed(v0 + v1, 32)
            let v4 = spiral_wrap_signed(v3 - 4, 32)
            v4
        }
        False -> {
            1
        }
    }
}
pub fn method4(v0: Float) -> #(Bool, Float, Int) {
    let v1 = v0 >=. 3.5
    #(v1, v0, 7)
}
pub fn method5(v0: Bool, v1: Float, v2: Int) -> Int {
    case v0 {
        True -> {
            let v3 = v1 >=. 3.5
            case v3 {
                True -> {
                    let v4 = spiral_wrap_signed(v2 - 7, 32)
                    v4
                }
                False -> {
                    1
                }
            }
        }
        False -> {
            2
        }
    }
}
pub fn method7(_v0: String) -> Bool {
    True
}
pub fn method9(v0: Int) -> Bool {
    let v1 = spiral_wrap_unsigned(v0 + 5, 32)
    let v2 = v1 % 4
    let v3 = v2 == 0
    v3
}
pub fn method11(v0: Int, v1: Int) -> Int {
    let v2 = spiral_wrap_signed(v0 * v1, 32)
    let v3 = spiral_wrap_signed(v2 + 5, 32)
    let v4 = v3 / 3
    v4
}
pub fn method10(v0: Int) -> Int {
    let v1 = 4
    let v2 = 4
    let v3 = method11(v1, v2)
    let v4 = spiral_wrap_signed(v0 + v3, 32)
    let v5 = spiral_wrap_signed(v4 - 7, 32)
    v5
}
pub fn method8(v0: Int) -> Int {
    let v1 = 7
    let v2 = method9(v1)
    case v2 {
        True -> {
            method10(v0)
        }
        False -> {
            1
        }
    }
}
pub fn method6(v0: Int) -> Int {
    let v1 = "spiral"
    let v2 = method7(v1)
    case v2 {
        True -> {
            method8(v0)
        }
        False -> {
            1
        }
    }
}
pub fn method3(v0: Int) -> Int {
    let v1 = 4.0
    let #(v2, v3, v4) = method4(v1)
    let v5 = method5(v2, v3, v4)
    let v6 = spiral_wrap_signed(v0 + v5, 32)
    method6(v6)
}
pub fn method0(v0: Int) -> Int {
    let v1 = 1
    let #(v2, v3, v4) = method1(v1)
    let v5 = method2(v2, v3, v4)
    let v6 = spiral_wrap_signed(v0 + v5, 32)
    method3(v6)
}
pub fn main() {
let v0 = 0
method0(v0)
}
