import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn sum_0(v0: Int) -> Int {
    let v1 = v0 < 1
    case v1 {
        True -> {
            0
        }
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            let v3 = sum_0(v2)
            let v4 = spiral_wrap_signed(v0 + v3, 32)
            v4
        }
    }
}
pub fn main() {
    let v0 = 4
    let v1 = sum_0(v0)
    let v2 = v1 == 10
    case v2 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
