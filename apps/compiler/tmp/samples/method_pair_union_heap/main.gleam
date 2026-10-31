import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int) }
pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn method0(v0: Int, v1: Heap0) -> #(Us0, Heap0) {
    let v2 = Us0Some(v0)
    #(v2, v1)
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v1)
    let #(v3, v4) = method0(v0, v2)
    case v3  {
        Us0None -> 1
        Us0Some(v5) -> {
            let v6 = v4.l0
            let v7 = spiral_wrap_signed(v5 + v6, 32)
            let v8 = v7 == 7
            case v8 {
                True -> 0
                False -> 1
            }
        }
    }
}
