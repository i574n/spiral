pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Heap0)
}
pub fn f_c0(capt: #(Heap0, Heap0)) -> fn(Int) -> Us0 {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                Us0None
            }
            False -> {
                Us0Held(v0, v1)
            }
        }
    }
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1, v2) -> {
            let #(v3, v4) = #(v1.l0, v1.l1)
            let #(v5, v6) = #(v2.l0, v2.l1)
            let v7 = v3 == 7
            let v9 =
                case v7 {
                    True -> {
                        let v8 = v4 == "hi"
                        v8
                    }
                    False -> {
                        False
                    }
                }
            let v11 =
                case v9 {
                    True -> {
                        let v10 = v5 == 4
                        v10
                    }
                    False -> {
                        False
                    }
                }
            let v13 =
                case v11 {
                    True -> {
                        let v12 = v6 == "yo"
                        v12
                    }
                    False -> {
                        False
                    }
                }
            case v13 {
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
    let v6 = f_c0(#(v2, v5))
    let v7 = v6(1)
    score_0(v7)
}
