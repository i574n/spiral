import gleam/int

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn method0(v0: Int) -> Bool {
    let v1 = spiral_wrap_unsigned(v0 + 5, 32)
    let v2 = v1 % 4
    let v3 = v2 == 0
    v3
}
pub fn main() {
    let v0 = 7
    let v1 = method0(v0)
    case v1 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
