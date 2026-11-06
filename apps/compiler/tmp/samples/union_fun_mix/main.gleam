import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Us0 {
    Us0None
    Us0Call(f1i0 : fn(Int) -> Int, f1i1 : Int)
}
pub fn add_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        spiral_wrap_signed(v1 + v0, 32)
    }
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Call(v1, v2) -> {
            let v3 = v1(0)
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
    let v6 =
        case True {
            True -> {
                let v3 = add_c0(#(3))
                Us0Call(v3, 4)
            }
            False -> Us0None
        }
    score_0(v6)
}
