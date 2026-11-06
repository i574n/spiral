pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0, l2 : Heap0) }
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v8 = Heap0(l0: 9, l1: "ok")
    let v9 = Heap1(l0: v2, l1: v5, l2: v8)
    let #(v10, v11, v12) = #(v9.l0, v9.l1, v9.l2)
    let #(v13, v14) = #(v10.l0, v10.l1)
    let #(v15, v16) = #(v11.l0, v11.l1)
    let #(v17, v18) = #(v12.l0, v12.l1)
    let v19 = v13 == 7
    let v21 =
        case v19 {
            True -> {
                v14 == "hi"
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v15 == 4
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v16 == "yo"
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                v17 == 9
            }
            False -> False
        }
    let v29 =
        case v27 {
            True -> {
                v18 == "ok"
            }
            False -> False
        }
    case v29 {
        True -> 0
        False -> 1
    }
}
