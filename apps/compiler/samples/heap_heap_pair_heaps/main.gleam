pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 2)
    let #(v9, v10) = #(v8.l0, v8.l1)
    let #(v11, v12) = #(v9.l0, v9.l1)
    let #(v13, v14) = #(v11.l0, v11.l1)
    let #(v15, v16) = #(v12.l0, v12.l1)
    let v17 = v13 == 7
    let v19 =
        case v17 {
            True -> {
                v14 == "hi"
            }
            False -> False
        }
    let v21 =
        case v19 {
            True -> {
                v15 == 4
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v16 == "yo"
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v10 == 2
            }
            False -> False
        }
    case v25 {
        True -> 0
        False -> 1
    }
}
