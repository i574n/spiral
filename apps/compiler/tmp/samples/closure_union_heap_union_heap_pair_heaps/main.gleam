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
pub fn f_c0(capt: #(Heap3)) -> fn(Int) -> Us1 {
    fn (v1) {
        let #(v0) = capt
        let v2 = v1 == 0
        case v2 {
            True -> {
                Us1Absent
            }
            False -> {
                Us1Box(v0)
            }
        }
    }
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> {
            1
        }
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
                                let v13 = v9 == "hi"
                                v13
                            }
                            False -> {
                                False
                            }
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                let v15 = v10 == 4
                                v15
                            }
                            False -> {
                                False
                            }
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v11 == "yo"
                                v17
                            }
                            False -> {
                                False
                            }
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v5 == 2
                                v19
                            }
                            False -> {
                                False
                            }
                        }
                    case v20 {
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
    let v9 = True
    let v12 =
        case v9 {
            True -> {
                Us0Held(v8)
            }
            False -> {
                Us0None
            }
        }
    let v13 = Heap3(l0: v12)
    let v14 = f_c0(#(v13))
    let v15 = v14(1)
    score_0(v15)
}
