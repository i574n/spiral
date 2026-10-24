import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn right_c1(capt: #(Int, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v1 == 0
        case v3 {
            True -> {
                0
            }
            False -> {
                let v4 = spiral_wrap_signed(v2 + v0, 32)
                v4
            }
        }
    }
}
pub fn left_c2(capt: #(Int, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v1 == 0
        case v3 {
            True -> {
                0
            }
            False -> {
                let v4 = spiral_wrap_signed(v2 + v0, 32)
                v4
            }
        }
    }
}
pub fn f_c0(capt: #(Int, Int)) -> fn(Int) -> #(fn(Int) -> Int, fn(Int) -> Int) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                let v4 = right_c1(#(v1, v2))
                let v5 = left_c2(#(v0, v2))
                #(v4, v5)
            }
            False -> {
                let v6 = left_c2(#(v0, v2))
                let v7 = right_c1(#(v1, v2))
                #(v6, v7)
            }
        }
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = f_c0(#(v0, v1))
    let #(v3, v4) = v2(1)
    let v5 = v3(0)
    let v6 = v4(0)
    let v7 = spiral_wrap_signed(v5 + v6, 32)
    let v8 = v7 == 7
    case v8 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
