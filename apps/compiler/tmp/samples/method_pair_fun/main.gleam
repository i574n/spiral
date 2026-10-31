import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn left_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> 0
            False -> {
                let v3 = spiral_wrap_signed(v1 + v0, 32)
                v3
            }
        }
    }
}
pub fn right_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> 0
            False -> {
                let v3 = spiral_wrap_signed(v1 + v0, 32)
                v3
            }
        }
    }
}
pub fn method0(v0: Int, v1: Int) -> #(fn(Int) -> Int, fn(Int) -> Int) {
    let v2 = left_c0(#(v0))
    let v3 = right_c1(#(v1))
    #(v2, v3)
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let #(v2, v3) = method0(v0, v1)
    let v4 = v2(0)
    let v5 = v3(0)
    let v6 = spiral_wrap_signed(v4 + v5, 32)
    let v7 = v6 == 7
    case v7 {
        True -> 0
        False -> 1
    }
}
