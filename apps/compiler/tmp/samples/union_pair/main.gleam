import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Us0 {
    Us0One(f0i0 : Int)
    Us0Both(f1i0 : Int, f1i1 : Int)
}
pub fn sum_0(v0: Us0) -> Int {
    case v0  {
        Us0Both(v2, v3) -> {
            let v4 = spiral_wrap_signed(v2 * 10, 32)
            let v5 = spiral_wrap_signed(v4 + v3, 32)
            v5
        }
        Us0One(v1) -> v1
    }
}
pub fn main() {
    let v0 = True
    let v3 =
        case v0 {
            True -> Us0Both(3, 4)
            False -> Us0One(1)
        }
    let v6 =
        case v0 {
            True -> Us0One(5)
            False -> Us0Both(1, 1)
        }
    let v7 = sum_0(v3)
    let v8 = v7 == 34
    let v11 =
        case v8 {
            True -> {
                let v9 = sum_0(v6)
                let v10 = v9 == 5
                v10
            }
            False -> False
        }
    case v11 {
        True -> 0
        False -> 1
    }
}
