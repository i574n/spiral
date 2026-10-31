import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int) }
pub fn f_c0(capt: #(Int, Heap0)) -> fn(Int) -> #(Heap0, Int) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> #(v1, 0)
            False -> #(v1, v0)
        }
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v0)
    let v3 = f_c0(#(v1, v2))
    let #(v4, v5) = v3(1)
    let v6 = v4.l0
    let v7 = spiral_wrap_signed(v6 + v5, 32)
    let v8 = v7 == 7
    case v8 {
        True -> 0
        False -> 1
    }
}
