import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn is_odd_1(v0: Int) -> Bool {
    let v1 = v0 == 0
    case v1 {
        True -> {
            False
        }
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            is_even_0(v2)
        }
    }
}
pub fn is_even_0(v0: Int) -> Bool {
    let v1 = v0 == 0
    case v1 {
        True -> {
            True
        }
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            is_odd_1(v2)
        }
    }
}
pub fn main() {
    let v0 = 10
    let v1 = is_even_0(v0)
    case v1 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
