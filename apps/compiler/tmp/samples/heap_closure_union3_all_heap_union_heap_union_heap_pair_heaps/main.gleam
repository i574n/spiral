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
    Us1Mark(f2i0 : Int)
}
pub type Heap4 { Heap4(l0 : Us1) }
pub fn f_c0(capt: #(Us1, Int)) -> fn(Int) -> Us1 {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> Us1Absent
            False -> {
                let v5 = v2 == 1
                case v5 {
                    True -> v0
                    False -> Us1Mark(v1)
                }
            }
        }
    }
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v3) -> {
            let v4 = v3.l0
            case v4  {
                Us0Held(v5) -> {
                    let #(v6, v7) = #(v5.l0, v5.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v8.l0, v8.l1)
                    let #(v12, v13) = #(v9.l0, v9.l1)
                    let v14 = v10 == 7
                    let v16 =
                        case v14 {
                            True -> {
                                v11 == "hi"
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                v12 == 4
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                v13 == "yo"
                            }
                            False -> False
                        }
                    let v22 =
                        case v20 {
                            True -> {
                                v7 == 2
                            }
                            False -> False
                        }
                    case v22 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
        Us1Mark(v1) -> 1
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
            False -> Us1Mark(1)
        }
    let v19 = f_c0(#(v17, 3))
    let v20 = v19(1)
    let v21 = Heap4(l0: v20)
    let v22 = v19(2)
    let v23 = Heap4(l0: v22)
    let v24 = v19(0)
    let v25 = Heap4(l0: v24)
    let v26 = v21.l0
    let v27 = v23.l0
    let v28 = v25.l0
    let v29 = score_0(v26)
    let v30 = score_0(v27)
    let v31 = score_0(v28)
    let v32 = v29 == 0
    let v34 =
        case v32 {
            True -> {
                v30 == 1
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                v31 == 1
            }
            False -> False
        }
    case v36 {
        True -> 0
        False -> 1
    }
}
