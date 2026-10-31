import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int) }
pub fn f_c0(capt: #(Heap0, Heap0)) -> fn(Int) -> #(Heap0, Heap0) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> #(v1, v0)
            False -> #(v0, v1)
        }
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v0)
    let v3 = Heap0(l0: v1)
    let v4 = f_c0(#(v2, v3))
    let #(v5, v6) = v4(1)
    let v7 = v5.l0
    let v8 = v6.l0
    let v9 = spiral_wrap_signed(v7 + v8, 32)
    let v10 = v9 == 7
    case v10 {
        True -> 0
        False -> 1
    }
}
