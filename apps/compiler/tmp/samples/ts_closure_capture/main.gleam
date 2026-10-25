import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn f_c0(capt: #(Int, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = spiral_wrap_signed(v0 + v1, 32)
        let v4 = spiral_wrap_signed(v3 + v2, 32)
        v4
    }
}
pub fn main() {
    let v0 = 1
    let v1 = 2
    let v2 = f_c0(#(v0, v1))
    v2(39)
}
