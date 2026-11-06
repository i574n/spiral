import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn a_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        spiral_wrap_signed(v1 + v0, 32)
    }
}
pub fn b_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        spiral_wrap_signed(v1 + v0, 32)
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(40)
}
pub fn main() {
    let v5 =
        case True {
            True -> a_c0(#(2))
            False -> b_c1(#(3))
        }
    method0(v5)
}
