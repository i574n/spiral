import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn h_c2(capt: #(Int, Int)) -> fn(Int) -> Int {
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
pub fn g_c1(capt: #(Int, Int)) -> fn(Int) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        h_c2(#(v0, v1))
    }
}
pub fn f_c0(capt: #(Int)) -> fn(Int) -> fn(Int) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        g_c1(#(v0, v1))
    }
}
pub fn main() {
    let v0 = 7
    let v1 = f_c0(#(v0))
    let v2 = v1(1)
    let v3 = v2(0)
    let v4 = v3(0)
    let v5 = v4 == 7
    case v5 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
