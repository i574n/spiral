pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub fn f_c0(capt: #(Heap2)) -> fn(Int) -> Us0 {
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
            let #(v6, v7) = #(v4.l0, v4.l1)
            let #(v8, v9) = #(v5.l0, v5.l1)
            let v10 = v6 == 7
            let v12 =
                case v10 {
                    True -> {
                        let v11 = v7 == "hi"
                        v11
                    }
                    False -> {
                        False
                    }
                }
            let v14 =
                case v12 {
                    True -> {
                        let v13 = v8 == 4
                        v13
                    }
                    False -> {
                        False
                    }
                }
            let v16 =
                case v14 {
                    True -> {
                        let v15 = v9 == "yo"
                        v15
                    }
                    False -> {
                        False
                    }
                }
            let v18 =
                case v16 {
                    True -> {
                        let v17 = v3 == 2
                        v17
                    }
                    False -> {
                        False
                    }
                }
            case v18 {
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
let v3 = 4
let v4 = "yo"
let v5 = Heap0(l0: v3, l1: v4)
let v6 = Heap1(l0: v2, l1: v5)
let v7 = 2
let v8 = Heap2(l0: v6, l1: v7)
let v9 = f_c0(#(v8))
let v10 = v9( 1  )
score_0(v10)
}
