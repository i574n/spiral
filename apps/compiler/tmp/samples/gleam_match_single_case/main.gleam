import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0Step(f0i0 : Int, f0i1 : Int, f0i2 : Int)
}
pub fn walk_0(v0: Int) -> Int {
    let v1 = v0 > 2
    let v6 =
        case v1 {
            True -> {
                let v2 = spiral_wrap_signed(v0 + 1, 32)
                let v3 = spiral_wrap_signed(v0 + 2, 32)
                Us0Step(v0, v2, v3)
            }
            False -> {
                Us0Step(0, 1, 2)
            }
        }
    case v6  {
        Us0Step(v7, v8, v9) -> {
            let v10 = spiral_wrap_signed(v8 * v9, 32)
            let v11 = spiral_wrap_signed(v7 + v10, 32)
            v11
        }
    }
}
pub fn main() {
let v0 = 5
let v1 = walk_0(v0)
let v2 = spiral_wrap_signed(v0 - 4, 32)
let v3 = walk_0(v2)
let v4 = spiral_wrap_signed(v1 + v3, 32)
v4
}
