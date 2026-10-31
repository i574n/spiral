import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn a_c0(capt: Nil) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = spiral_wrap_signed(v0 + 2, 32)
        v1
    }
}
pub fn b_c1(capt: Nil) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = spiral_wrap_signed(v0 + 3, 32)
        v1
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(40)
}
pub fn main() {
    let v0 = True
    let v3 =
        case v0 {
            True -> a_c0(Nil)
            False -> b_c1(Nil)
        }
    method0(v3)
}
