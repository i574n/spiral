pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v4 = Heap1(l0: v2, l1: 1)
    let v6 = Heap2(l0: v4, l1: 2)
    let #(v7, v8) = #(v6.l0, v6.l1)
    let #(v9, v10) = #(v7.l0, v7.l1)
    let #(v11, v12) = #(v9.l0, v9.l1)
    let v13 = v11 == 7
    let v15 =
        case v13 {
            True -> {
                v12 == "hi"
            }
            False -> False
        }
    let v17 =
        case v15 {
            True -> {
                v10 == 1
            }
            False -> False
        }
    let v19 =
        case v17 {
            True -> {
                v8 == 2
            }
            False -> False
        }
    case v19 {
        True -> 0
        False -> 1
    }
}
