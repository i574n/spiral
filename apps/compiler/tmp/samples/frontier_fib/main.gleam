import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn fib_0(v0: Int) -> Int {
    let v1 = v0 <= 1
    case v1 {
        True -> v0
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            let v3 = fib_0(v2)
            let v4 = spiral_wrap_signed(v0 - 2, 32)
            let v5 = fib_0(v4)
            let v6 = spiral_wrap_signed(v3 + v5, 32)
            v6
        }
    }
}
pub fn main() {
    let v0 = 10
    let v1 = fib_0(v0)
    let v2 = spiral_wrap_signed(v1 - 55, 32)
    v2
}
