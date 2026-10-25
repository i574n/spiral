import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn h_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> {
                0
            }
            False -> {
                let v3 = spiral_wrap_signed(v1 + v0, 32)
                v3
            }
        }
    }
}
pub fn g_c0(capt: #(Int)) -> fn(Int) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        h_c1(#(v0))
    }
}
pub fn method0(v0: Int) -> fn(Int) -> fn(Int) -> Int {
    g_c0(#(v0))
}
pub fn main() {
    let v0 = 7
    let v1 = method0(v0)
    let v2 = v1(0)
    let v3 = v2(0)
    let v4 = v3 == 7
    case v4 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
