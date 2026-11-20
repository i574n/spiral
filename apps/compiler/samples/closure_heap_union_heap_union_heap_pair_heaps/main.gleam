pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub type Heap3 { Heap3(l0 : Us0) }
pub type Us1 {
    Us1Absent
    Us1Box(f1i0 : Heap3)
}
pub type Heap4 { Heap4(l0 : Us1) }
pub fn f_c0(capt: #(Heap4)) -> fn(Int) -> Heap4 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v1) -> {
            let v2 = v1.l0
            case v2  {
                Us0Held(v3) -> {
                    let #(v4, v5) = #(v3.l0, v3.l1)
                    let #(v6, v7) = #(v4.l0, v4.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v7.l0, v7.l1)
                    let v12 = v8 == 7
                    let v14 =
                        case v12 {
                            True -> {
                                v9 == "hi"
                            }
                            False -> False
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                v10 == 4
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                v11 == "yo"
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                v5 == 2
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
    }
}
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 2)
    let v12 =
        case True {
            True -> Us0Held(v8)
            False -> Us0None
        }
    let v13 = Heap3(l0: v12)
    let v17 =
        case True {
            True -> Us1Box(v13)
            False -> Us1Absent
        }
    let v18 = Heap4(l0: v17)
    let v19 = f_c0(#(v18))
    let v20 = v19(1)
    let v21 = v20.l0
    score_0(v21)
}
