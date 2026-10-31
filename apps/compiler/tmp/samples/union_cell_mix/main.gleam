import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Heap0 { Heap0(l0 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Int)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1, v2) -> {
            let v3 = v1.l0
            let v4 = spiral_wrap_signed(v3 + v2, 32)
            let v5 = v4 == 7
            case v5 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v0)
    let v3 = True
    let v6 =
        case v3 {
            True -> Us0Held(v2, v1)
            False -> Us0None
        }
    score_0(v6)
}
