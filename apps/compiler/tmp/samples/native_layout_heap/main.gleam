import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int, l1 : Int) }
pub fn main() {
    let v0 = Heap0(l0: 9, l1: 10)
    let v1 = v0.l0
    let v2 = v0.l1
    let v3 = spiral_wrap_signed(v1 + v2, 32)
    v3
}
