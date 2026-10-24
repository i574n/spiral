import gleam/int
import gleam/bit_array
import gleam/string
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn method1(v0: Int, v1: String) -> String {
    let v2 = spiral_wrap_signed(v0 - 1, 32)
    let v3 = v2 == 0
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = v2 % 2
            let v5 = v4 == 0
            let v8 =
                case v5 {
                    True -> {
                        let v6 = "ok"
                        v6
                    }
                    False -> {
                        let v7 = "go"
                        v7
                    }
                }
            method1(v2, v8)
        }
    }
}
pub fn method0() -> String {
    let v0 = 1000000
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = "seed"
            v2
        }
        False -> {
            let v3 = v0 % 2
            let v4 = v3 == 0
            let v7 =
                case v4 {
                    True -> {
                        let v5 = "ok"
                        v5
                    }
                    False -> {
                        let v6 = "go"
                        v6
                    }
                }
            method1(v0, v7)
        }
    }
}
pub fn main() {
    let v0 = method0()
    let v1 = spiral_string_length(v0)
    let v2 = v1 == 2
    case v2 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
