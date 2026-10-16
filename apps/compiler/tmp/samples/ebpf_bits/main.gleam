import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
let v0 = 4294967295
let v1 = 15
let v2 = int.bitwise_and(v0, v1)
let v3 = int.bitwise_or(v0, v1)
let v4 = int.bitwise_exclusive_or(v0, v1)
let v5 = spiral_wrap_unsigned(int.bitwise_not(v1), 32)
let v6 = v2 == 15
let v8 =
    case v6 {
        True -> {
            let v7 = v3 == v0
            v7
        }
        False -> {
            False
        }
    }
let v10 =
    case v8 {
        True -> {
            let v9 = v4 == v5
            v9
        }
        False -> {
            False
        }
    }
let v12 =
    case v10 {
        True -> {
            let v11 = v5 == 4294967280
            v11
        }
        False -> {
            False
        }
    }
case v12 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
