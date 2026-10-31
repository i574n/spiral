pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0, l2 : Heap0) }
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
    let v9 = Heap1(l0: v2, l1: v5, l2: v8)
    let #(v10, v11, v12) = #(v9.l0, v9.l1, v9.l2)
    let #(v13, v14) = #(v10.l0, v10.l1)
    let #(v15, v16) = #(v11.l0, v11.l1)
    let #(v17, v18) = #(v12.l0, v12.l1)
    let v19 = v13 == 7
    let v21 =
        case v19 {
            True -> {
                let v20 = v14 == "hi"
                v20
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                let v22 = v15 == 4
                v22
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v16 == "yo"
                v24
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                let v26 = v17 == 9
                v26
            }
            False -> False
        }
    let v29 =
        case v27 {
            True -> {
                let v28 = v18 == "ok"
                v28
            }
            False -> False
        }
    case v29 {
        True -> 0
        False -> 1
    }
}
