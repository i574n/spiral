import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0Done(f0i0 : Int)
    Us0More(f1i0 : Int)
}
pub fn layers_0(v0: Int) -> Int {
    let v1 = v0 >= 5
    let v4 =
        case v1 {
            True -> {
                Us0Done(v0)
            }
            False -> {
                Us0More(v0)
            }
        }
    case v4  {
        Us0Done(v8) -> {
            let v9 = spiral_wrap_signed(v8 * 2, 32)
            v9
        }
        Us0More(v5) -> {
            let v6 = spiral_wrap_signed(v5 + 1, 32)
            layers_0(v6)
        }
    }
}
pub fn main() {
let v0 = 0
layers_0(v0)
}
