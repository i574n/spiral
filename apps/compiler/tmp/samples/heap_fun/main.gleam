import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : fn(Int) -> Int, l1 : Int) }
pub fn add_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_signed(v1 + v0, 32)
        v2
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = add_c0(#(v0))
    let v3 = Heap0(l0: v2, l1: v1)
    let #(v4, v5) = #(v3.l0, v3.l1)
    let v6 = v4(0)
    let v7 = spiral_wrap_signed(v6 + v5, 32)
    let v8 = v7 == 7
    case v8 {
        True -> 0
        False -> 1
    }
}
