import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method2(v0: Int, v1: Int, v2: Int) -> #(Int, Int) {
    let v3 = spiral_wrap_signed(v0 - 1, 32)
    let v4 = spiral_wrap_signed(v1 + 1, 32)
    let v5 = spiral_wrap_signed(v2 + 2, 32)
    let v6 = v3 == 0
    case v6 {
        True -> {
            #(v4, v5)
        }
        False -> {
            method2(v3, v4, v5)
        }
    }
}
pub fn method1(v0: Int) -> #(Int, Int) {
    let v1 = 0
    let v2 = 0
    let v3 = v0 == 0
    case v3 {
        True -> {
            #(v1, v2)
        }
        False -> {
            method2(v0, v1, v2)
        }
    }
}
pub fn method0(v0: Int) -> Int {
    let #(v1, v2) = method1(v0)
    let v3 = v1 == 4
    let v5 =
        case v3 {
            True -> {
                let v4 = v2 == 8
                v4
            }
            False -> {
                False
            }
        }
    case v5 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
pub fn main() {
    let v0 = 4
    method0(v0)
}
