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
pub fn f_c0(capt: #(Int, Heap0)) -> fn(Int) -> #(Us0, Heap0) {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                let v4 = Us0None
                #(v4, v1)
            }
            False -> {
                let v5 = Us0Some(v0)
                #(v5, v1)
            }
        }
    }
}
pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = Heap0(l0: v1)
    let v3 = f_c0(#(v0, v2))
    let #(v4, v5) = v3(1)
    case v4  {
        Us0None -> 1
        Us0Some(v6) -> {
            let v7 = v5.l0
            let v8 = spiral_wrap_signed(v6 + v7, 32)
            let v9 = v8 == 7
            case v9 {
                True -> 0
                False -> 1
            }
        }
    }
}
