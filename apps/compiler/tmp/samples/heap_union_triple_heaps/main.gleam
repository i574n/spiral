pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Heap0, f1i2 : Heap0)
}
pub type Heap1 { Heap1(l0 : Us0) }
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
                        let v11 = v5 == "hi"
                        v11
                    }
                    False -> False
                }
            let v14 =
                case v12 {
                    True -> {
                        let v13 = v6 == 4
                        v13
                    }
                    False -> False
                }
            let v16 =
                case v14 {
                    True -> {
                        let v15 = v7 == "yo"
                        v15
                    }
                    False -> False
                }
            let v18 =
                case v16 {
                    True -> {
                        let v17 = v8 == 9
                        v17
                    }
                    False -> False
                }
            let v20 =
                case v18 {
                    True -> {
                        let v19 = v9 == "ok"
                        v19
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
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 4
    let v4 = "yo"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = 9
    let v7 = "ok"
    let v8 = Heap0(l0: v6, l1: v7)
    let v9 = True
    let v12 =
        case v9 {
            True -> Us0Held(v2, v5, v8)
            False -> Us0None
        }
    let v13 = Heap1(l0: v12)
    let v14 = v13.l0
    score_0(v14)
}
