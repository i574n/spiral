pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap1)
}
pub fn f_c0(capt: #(Heap1)) -> fn(Int) -> Us0 {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                Us0None
            }
            False -> {
                Us0Held(v0)
            }
        }
    }
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1) -> {
            let #(v2, v3) = #(v1.l0, v1.l1)
            let #(v4, v5) = #(v2.l0, v2.l1)
            let v6 = v4 == 7
            let v8 =
                case v6 {
                    True -> {
                        let v7 = v5 == "hi"
                        v7
                    }
                    False -> {
                        False
                    }
                }
            let v10 =
                case v8 {
                    True -> {
                        let v9 = v3 == 1
                        v9
                    }
                    False -> {
                        False
                    }
                }
            case v10 {
                True -> {
                    0
                }
                False -> {
                    1
                }
            }
        }
        Us0None -> {
            1
        }
    }
}
pub fn main() {
let v0 = 7
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 1
let v4 = Heap1(l0: v2, l1: v3)
let v5 = f_c0(#(v4))
let v6 = v5( 1  )
score_0(v6)
}
