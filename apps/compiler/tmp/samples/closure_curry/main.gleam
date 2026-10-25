import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn closure1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_signed(v0 * 10, 32)
        let v3 = spiral_wrap_signed(v2 + v1, 32)
        v3
    }
}
pub fn f_c0(capt: Nil) -> fn(Int) -> fn(Int) -> Int {
    fn (v0) {
        closure1(#(v0))
    }
}
pub fn main() {
    let v0 = f_c0(Nil)
    let v1 = v0(3)
    let v2 = v1(4)
    let v3 = v2 == 34
    case v3 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
