pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Heap0)
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
                        v4 == "hi"
                    }
                    False -> False
                }
            let v11 =
                case v9 {
                    True -> {
                        v5 == 4
                    }
                    False -> False
                }
            let v13 =
                case v11 {
                    True -> {
                        v6 == "yo"
                    }
                    False -> False
                }
            case v13 {
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
    let v9 =
        case True {
            True -> Us0Held(v2, v5)
            False -> Us0None
        }
    score_0(v9)
}
