import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn main() {
    let v0 = 43
    let v1 = 15
    let v2 = 2
    let v3 = 5
    let v4 = int.bitwise_and(v0, v1)
    let v5 = int.bitwise_or(v0, v1)
    let v6 = int.bitwise_exclusive_or(v0, v1)
    let v7 = spiral_wrap_signed(int.bitwise_not(v0), 32)
    let v8 = int.bitwise_and(v7, 255)
    let v9 = spiral_wrap_signed(int.bitwise_shift_left(1, v3), 32)
    let v10 = int.bitwise_shift_right(168, v2)
    let v11 = spiral_wrap_signed(v4 - 11, 32)
    let v12 = spiral_wrap_signed(v10 + v11, 32)
    let v13 = spiral_wrap_signed(v5 - 47, 32)
    let v14 = spiral_wrap_signed(v12 + v13, 32)
    let v15 = spiral_wrap_signed(v6 - 36, 32)
    let v16 = spiral_wrap_signed(v14 + v15, 32)
    let v17 = spiral_wrap_signed(v8 - 212, 32)
    let v18 = spiral_wrap_signed(v16 + v17, 32)
    let v19 = spiral_wrap_signed(v9 - 32, 32)
    let v20 = spiral_wrap_signed(v18 + v19, 32)
    v20
}
