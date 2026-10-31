import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int, l1 : Int) }
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v0, l1: v1)
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v5 = spiral_wrap_signed(v3 + v4, 32)
    let v6 = v5 == 7
    case v6 {
        True -> 0
        False -> 1
    }
}
