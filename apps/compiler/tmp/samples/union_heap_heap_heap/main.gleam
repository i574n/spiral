pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1) -> {
            let #(v2, v3) = #(v1.l0, v1.l1)
            let #(v4, v5) = #(v2.l0, v2.l1)
            let #(v6, v7) = #(v4.l0, v4.l1)
            let v8 = v6 == 7
            let v10 =
                case v8 {
                    True -> {
                        let v9 = v7 == "hi"
                        v9
                    }
                    False -> {
                        False
                    }
                }
            let v12 =
                case v10 {
                    True -> {
                        let v11 = v5 == 1
                        v11
                    }
                    False -> {
                        False
                    }
                }
            let v14 =
                case v12 {
                    True -> {
                        let v13 = v3 == 2
                        v13
                    }
                    False -> {
                        False
                    }
                }
            case v14 {
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
    let v5 = 2
    let v6 = Heap2(l0: v4, l1: v5)
    let v7 = True
    let v10 =
        case v7 {
            True -> {
                Us0Held(v6)
            }
            False -> {
                Us0None
            }
        }
    score_0(v10)
}
