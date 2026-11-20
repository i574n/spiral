pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Heap0, f1i2 : Heap0)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1, v2, v3) -> {
            let #(v4, v5) = #(v1.l0, v1.l1)
            let #(v6, v7) = #(v2.l0, v2.l1)
            let #(v8, v9) = #(v3.l0, v3.l1)
            let v10 = v4 == 7
            let v12 =
                case v10 {
                    True -> {
                        v5 == "hi"
                    }
                    False -> False
                }
            let v14 =
                case v12 {
                    True -> {
                        v6 == 4
                    }
                    False -> False
                }
            let v16 =
                case v14 {
                    True -> {
                        v7 == "yo"
                    }
                    False -> False
                }
            let v18 =
                case v16 {
                    True -> {
                        v8 == 9
                    }
                    False -> False
                }
            let v20 =
                case v18 {
                    True -> {
                        v9 == "ok"
                    }
                    False -> False
                }
            case v20 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v8 = Heap0(l0: 9, l1: "ok")
    let v12 =
        case True {
            True -> Us0Held(v2, v5, v8)
            False -> Us0None
        }
    score_0(v12)
}
